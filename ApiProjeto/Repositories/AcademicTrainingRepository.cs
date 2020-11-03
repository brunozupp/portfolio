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
    public class AcademicTrainingRepository : Connection, IRepositoryBase<AcademicTraining>
    {
        public AcademicTrainingRepository(IConfiguration configuration) : base(configuration) { }

        public bool Delete(int id)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"DELETE FROM AcademicTrainings WHERE ID = @id", new { id });

            return rowsAffected == 1;
        }

        public AcademicTraining Get(int id)
        {
            using var conn = Conn;

            return conn.Query<AcademicTraining>(@"SELECT * FROM AcademicTrainings WHERE ID = @id", new { id }).SingleOrDefault();
        }

        public IEnumerable<AcademicTraining> GetAll()
        {
            using var conn = Conn;

            return conn.Query<AcademicTraining>(@"SELECT * FROM AcademicTrainings");
        }

        public int Insert(AcademicTraining entity)
        {
            using var conn = Conn;

            return conn.Query<int>(@"INSERT INTO AcademicTrainings(Name,Institution,[Begin],[End]) 
                VALUES(@Name,@Institution,@Begin,@End)
                SELECT SCOPE_IDENTITY()", entity).SingleOrDefault();
        }

        public bool Update(AcademicTraining entity)
        {
            using var conn = Conn;

            int rowsAffected = conn.Execute(@"UPDATE AcademicTrainings SET Name = @Name, 
                Institution = @Institution, [Begin] = @Begin, [End] = @End WHERE ID = @ID", entity);

            return rowsAffected == 1;
        }
    }
}
