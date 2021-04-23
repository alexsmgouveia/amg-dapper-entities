using AMG.DapperEntities.Domain.DTO;
using AMG.DapperEntities.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace AMG.DapperEntities.Domain.Data.Services
{
    public class ExtractorService
    { 
        private readonly string _destiny;
        private readonly ConfigurationItems configuration;

        public ExtractorService(ConfigurationItems configuration)
        { 
            this._destiny = $@"{DirectoryHelper.CurrentPath()}{configuration.projectsubfolder}";
            if (!Directory.Exists(_destiny))
            {
                Directory.CreateDirectory(_destiny);
            }
            this.configuration = configuration;
        }
         
         
        public void CreateClass() 
        {
            var tables = Bind(configuration);
            var classes = new ClassService(configuration.entitynamespace).Mapper(tables.ToArray());

            foreach (var @class in classes)
            { 
                var path = $@"{_destiny}\{@class.Item1}.cs";
                try
                {
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(@class.Item2);
                        }
                    } 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        public void UpdateClass() 
        {
            var tables = Bind(configuration);
            var classes = new ClassService(configuration.entitynamespace).Mapper(tables.ToArray());
             
            foreach (var @class in classes)
            {

                var path = $@"{_destiny}\{@class.Item1}.cs";
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path); 
                    }
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(@class.Item2); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            } 
        }



        private List<TableStructure> Bind(ConfigurationItems configuration)
        {
            var tabelsStructure = new List<TableStructure>();
            var credential = new DbCredential(configuration.server, configuration.database, configuration.user, configuration.password);
            var service = new DbExtractorService(credential);

            string[] schemas = null;
            string[] tables = null;

            if (configuration.schemas?.ToLower() != "all")
                schemas = configuration.schemas.Split(",");

            if (configuration.tables?.ToLower() != "all")
                tables = configuration.tables.Split(",");


            var alltables = service.TablesNames(schemas, tables);
            foreach (var tableName in alltables)
            {
                var tableStructure = new TableStructure();
                tableStructure.Name = tableName;
                tableStructure.Columns = service.TableProperties(tableName);
                tabelsStructure.Add(tableStructure);
            }
            return tabelsStructure;
        }

    }
}
