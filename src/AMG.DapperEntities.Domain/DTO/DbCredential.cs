using AMG.DapperEntities.Domain.Values;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AMG.DapperEntities.Domain.DTO
{
    public class DbCredential
    { 
        public readonly DbEnginesValue _engines;
        private readonly string _connectionString;
        public DbCredential( string server, string database, string username, string password, DbEnginesValue engines = DbEnginesValue.SQLSERVER)
        {
            _connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            _engines = engines;

            if (engines != DbEnginesValue.SQLSERVER)
                throw new NotImplementedException();
        }

        public DbCredential(DbEnginesValue engines, string connectionString)
        {
            _connectionString = connectionString;
            _engines = engines;
        }
  
        public IDbConnection Connection 
        { 
            get 
            { 
                switch (_engines)
                {
                    case DbEnginesValue.MYSQL:
                        return new MySqlConnection(_connectionString); 

                    case DbEnginesValue.POSTGRESQL:
                        return new NpgsqlConnection(_connectionString);

                    case DbEnginesValue.SQLSERVER:
                    default: 
                        return new SqlConnection(_connectionString);
                } 


            } 
        }
    }
}
