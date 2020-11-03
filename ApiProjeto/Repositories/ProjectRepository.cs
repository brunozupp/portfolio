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
    public class ProjectRepository : Connection, IRepositoryBase<Project>
    {
        public ProjectRepository(IConfiguration configuration) : base(configuration) { }

        public bool Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"DELETE FROM Projects WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public Project Get(int id)
        {
            using var conn = Conn;

            return conn.Query<Project>(@"SELECT * FROM Projects WHERE ID = @id", new { id }).SingleOrDefault();
        }

        public IEnumerable<Project> GetAll()
        {
            using var conn = Conn;

            return conn.Query<Project>(@"SELECT * FROM Projects");
        }

        public int Insert(Project entity)
        {
            using var conn = Conn;

            return conn.Query<int>(@"INSERT INTO Projects(Name,Description) VALUES(@Name,@Description)
                SELECT SCOPE_IDENTITY()", entity).SingleOrDefault();
        }

        public bool Update(Project entity)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"UPDATE Projects SET Name = @Name, 
                Description = @Description WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
