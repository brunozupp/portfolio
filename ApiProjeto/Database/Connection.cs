using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjeto.Database
{
    public class Connection
    {

        private readonly IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Conn
        {
            get
            {
                //return new SqlConnection(@"Server=DESKTOP-M2I96DS\SQLEXPRESS;Database=Portifolio;Trusted_Connection=True;");
                return new SqlConnection(_configuration.GetConnectionString("stringConnection"));
            }
        }
    }
}
