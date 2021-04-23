using AMG.DapperEntities.Domain.DTO;
using AMG.DapperEntities.Infra;
using System;
using System.Collections.Generic;

namespace AMG.DapperEntities.Domain.Data.Services
{
    public class DbExtractorService
    {
        private readonly DbCredential _credential;
        private readonly DbRepository _repository;

        public DbExtractorService(DbCredential credential)
        {
            this._credential = credential;
            _repository = new DbRepository(_credential.Connection, _credential._engines);
        }

        /// <summary>
        /// Table names based on configuration
        /// </summary>
        /// <param name="schemas"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        public List<string> TablesNames(string[] schemas = null, string[] tables = null) => _repository.TablesNames(schemas, tables);

        /// <summary>
        /// Table names and Schemas names based on configuration
        /// </summary>
        /// <returns></returns>
        public List<string> SchemasAndTablesNames() => _repository.SchemasAndTablesNames();

        /// <summary>
        /// Schemas names based on configuration
        /// </summary>
        /// <returns></returns>
        public List<string> SchemasNames() => _repository.SchemasNames();

        /// <summary>
        /// Table structure based on configuration
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ColumnStructure> TableProperties(string tableName)  => 
            _repository.TableProperties(tableName);


        /// <summary>
        /// Validates the connection from your configuration file
        /// </summary>
        /// <returns></returns>
        public bool IsAvailable() =>
         _repository.IsAvailable();
    }
}
