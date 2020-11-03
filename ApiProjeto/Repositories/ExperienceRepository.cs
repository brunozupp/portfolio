using ApiProjeto.Database;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ApiProjeto.Repositories
{
    public class ExperienceRepository : Connection, IRepositoryBase<Experience>
    {
        public ExperienceRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"DELETE FROM Experiences WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public async Task<Experience> Get(int id)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<Experience>(@"SELECT * FROM Experiences 
                WHERE ID = @id", new { id })).SingleOrDefault();
        }

        public async Task<IEnumerable<Experience>> GetAll()
        {
            using var conn = Conn;

            return await conn.QueryAsync<Experience>(@"SELECT * FROM Experiences");
        }

        public async Task<int> Insert(Experience entity)
        {
            using var conn = Conn;

            return (await conn.QueryAsync<int>(@"INSERT INTO Experiences(Company,Description,[Begin],[End]) 
            VALUES(@Company,@Description,@Begin,@End)
            SELECT SCOPE_IDENTITY()", entity)).SingleOrDefault();
        }

        public async Task<bool> Update(Experience entity)
        {
            using var conn = Conn;

            int rowsAffected = await conn.ExecuteAsync(@"UPDATE Experiences SET Company = @Company, 
                Description = @Description, [Begin] = @Begin, [End] = @End WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
