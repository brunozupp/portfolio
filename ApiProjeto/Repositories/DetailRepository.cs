using ApiProjeto.Database;
using Dapper;
using Infrastructure.DTOs;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjeto.Repositories
{
    public class DetailRepository : Connection, IRepositoryBase<Detail>
    {

        public DetailRepository(IConfiguration configuration) : base(configuration) { }

        // Não vai ser usado
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Não vai ser usado
        public async Task<IEnumerable<Detail>> GetAll()
        {
            using var conn = Conn;

            return await conn.QueryAsync<Detail>(@"SELECT * FROM Details");
        }

        public async Task<Detail> Get(int id)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<Detail>(@"SELECT * FROM Details 
                WHERE ID = @id", new { id })).SingleOrDefault();
        }

        public async Task<int> Insert(Detail entity)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<int>(@"INSERT INTO Details(Name,Email,Phone,BirthDate,Linkedin,
                Instagram,Facebook,Nationality,About,Goals)
                VALUES(@Name,@Email,@Phone,@BirthDate,@Linkedin,
                @Instagram,@Facebook,@Nationality,@About,@Goals)
                SELECT SCOPE_IDENTITY()", entity)).SingleOrDefault();
        }

        public async Task<bool> Update(Detail entity)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"UPDATE Details SET Name = @Name, Email = @Email,
                Phone = @Phone, BirthDate = @BirthDate, 
                Linkedin = @Linkedin, Instagram = @Instagram, 
                Facebook = @Facebook, Nationality = @Nationality, 
                About = @About, Goals = @Goals
                WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }

        public async Task<DetailsDTO> GetPortfolio()
        {
            using var conn = Conn;

            DetailsDTO detailsDTO = new DetailsDTO();

            detailsDTO.Detail = (await conn.QueryAsync<Detail>(@"SELECT D.* FROM Details D")).FirstOrDefault();

            detailsDTO.Skills = (await conn.QueryAsync<Skill>(@"SELECT S.* FROM Skills S")).ToList();

            detailsDTO.Experiences = (await conn.QueryAsync<Experience>(@"SELECT E.* FROM Experiences E")).ToList();

            detailsDTO.Projects = (await conn.QueryAsync<Project>(@"SELECT P.* FROM Projects P")).ToList();

            detailsDTO.AcademicTrainings = (await conn.QueryAsync<AcademicTraining>(@"SELECT A.* FROM AcademicTrainings A")).ToList();

            return detailsDTO;
        }
    }
}
