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

        public bool Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"DELETE FROM Skills WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public Skill Get(int id)
        {
            using var conn = Conn;

            return conn.Query<Skill>(@"SELECT * FROM Skills WHERE ID = @id", new { id }).SingleOrDefault();
        }

        public IEnumerable<Skill> GetAll()
        {
            using var conn = Conn;

            return conn.Query<Skill>(@"SELECT * FROM Skills");
        }

        public int Insert(Skill entity)
        {
            using var conn = Conn;

            return conn.Query<int>(@"INSERT INTO Skills(Name,Aptitude) VALUES(@Name,@Aptitude)
                SELECT SCOPE_IDENTITY()", entity).SingleOrDefault();
        }

        public bool Update(Skill entity)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"UPDATE Skills SET Name = @Name, 
                Aptitude = @Aptitude WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
