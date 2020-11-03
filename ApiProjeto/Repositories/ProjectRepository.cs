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

        public async Task<bool> Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"DELETE FROM Projects WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public async Task<Project> Get(int id)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<Project>(@"SELECT * FROM Projects 
                WHERE ID = @id", new { id })).SingleOrDefault();
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            using var conn = Conn;

            return await conn.QueryAsync<Project>(@"SELECT * FROM Projects");
        }

        public async Task<int> Insert(Project entity)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<int>(@"INSERT INTO Projects(Name,Description) VALUES(@Name,@Description)
                SELECT SCOPE_IDENTITY()", entity)).SingleOrDefault();
        }

        public async Task<bool> Update(Project entity)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"UPDATE Projects SET Name = @Name, 
                Description = @Description WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
