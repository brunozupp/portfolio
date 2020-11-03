using ApiProjeto.Database;
using Dapper;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjeto.Repositories
{
    public class SkillRepository : Connection, IRepositoryBase<Skill>
    {
        public SkillRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"DELETE FROM Skills WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public async Task<Skill> Get(int id)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<Skill>(@"SELECT * FROM Skills 
                WHERE ID = @id", new { id })).SingleOrDefault();
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            using var conn = Conn;

            return await conn.QueryAsync<Skill>(@"SELECT * FROM Skills");
        }

        public async Task<int> Insert(Skill entity)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<int>(@"INSERT INTO Skills(Name,Aptitude) VALUES(@Name,@Aptitude)
                SELECT SCOPE_IDENTITY()", entity)).SingleOrDefault();
        }

        public async Task<bool> Update(Skill entity)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"UPDATE Skills SET Name = @Name, 
                Aptitude = @Aptitude WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
