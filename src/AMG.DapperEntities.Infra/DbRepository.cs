 
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq; 
using AMG.DapperEntities.Domain.Values;
using AMG.DapperEntities.Domain.DTO;
using System.Data.SqlClient;

namespace AMG.DapperEntities.Infra
{
    public class DbRepository
    {
        private readonly IDbConnection _connection; 

        public DbRepository(IDbConnection connection, DbEnginesValue dbEngine)
        {
            this._connection = connection; 

            if (dbEngine != DbEnginesValue.SQLSERVER)
                throw new NotImplementedException();
        }

        /// <summary>
        /// SchemasAndTablesNames
        /// </summary>
        /// <returns></returns>
        public List<string> SchemasAndTablesNames()
        {
            return _connection.Query<string>(@"select schema_name(t.schema_id) + '.' + t.name as table_name from 
                                                sys.tables t order by table_name;").ToList();

        }

        /// <summary>
        /// TablesNames
        /// </summary>
        /// <param name="schemas"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        public List<string> TablesNames(string[] schemas = null, string[] tables = null)
        {
            if (!(schemas is null) && tables is null)
                return _connection.Query<string>(@$"select t.name as table_name 
                                                from  sys.tables t 
                                                where schema_name(t.schema_id) in ('{string.Join("','", schemas)}')
                                                order by table_name;").ToList();


            if (!(tables is null) && schemas is null)
                return _connection.Query<string>(@$"select t.name as table_name 
                                                from  sys.tables t 
                                                where  t.name in ('{string.Join("','", tables)}')
                                                order by table_name;").ToList();

            if (!(tables is null) && !(tables is null))
                return _connection.Query<string>(@$"select t.name as table_name 
                                                from  sys.tables t 
                                                where schema_name(t.schema_id) in ('{string.Join("','", schemas)}')
                                                and t.name in ('{string.Join("','", tables)}')
                                                order by table_name;").ToList();


            return _connection.Query<string>(@"select t.name as table_name 
                                                from  sys.tables t order by table_name;").ToList();

        }

        /// <summary>
        /// IsAvailable
        /// </summary>
        /// <returns></returns>
        public bool IsAvailable()
        {
            try
            {
                _connection.Open();
                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        } 

        /// <summary>
        /// TableProperties
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ColumnStructure> TableProperties(string tableName)
        {
            var result = new List<ColumnStructure>();
            var items = _connection.Query<TableInfo>($@" SELECT *  
                                                        FROM INFORMATION_SCHEMA.COLUMNS
                                                        WHERE TABLE_NAME = '{tableName}'
                                                        ORDER BY ORDINAL_POSITION").ToList();

            foreach (var item in items)
            {
                int length = 0;
                string max = $"{item.CHARACTER_MAXIMUM_LENGTH}";
                int.TryParse(max, out length);

                result.Add(new ColumnStructure
                {
                    Name = item.COLUMN_NAME,
                    Type = item.DATA_TYPE,
                    IsNullable = item.IS_NULLABLE == "YES" ? true : false,
                    Length = length
                });
            }
            return result;

        }

        /// <summary>
        /// SchemasNames
        /// </summary>
        /// <returns></returns>
        public List<string> SchemasNames()
        {
            return _connection.Query<string>("select distinct(schema_name(t.schema_id)) sc " +
                "from sys.tables t order by sc;").ToList();
        }
    }
}
