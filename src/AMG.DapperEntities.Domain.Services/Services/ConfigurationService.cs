using AMG.DapperEntities.Domain.DTO;
using AMG.DapperEntities.Domain.Values;
using AMG.DapperEntities.CrossCutting.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace AMG.DapperEntities.Domain.Data.Services
{
    public class ConfigurationService
    {
        private readonly string _destiny;

        public ConfigurationService(string destiny)
        {
            this._destiny = destiny;
        }

        public void Create() 
        {
            var json = ConfigurationValue.amg_dapper_entities;
            var str_json = Encoding.UTF8.GetString(json);
            var obj = JsonConvert.DeserializeObject<ConfigurationItems>(str_json);
            obj.entitynamespace = $"{DirectoryHelper.CurrentFolderName()}.Entities";
            obj.projectsubfolder = SystemConfigurationValue.SUBFOLDER_DEFAULT;
            str_json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            json = Encoding.UTF8.GetBytes(str_json);

            var fileName = $@"{_destiny}\{SystemConfigurationValue.FILE_NAME}";
            try
            {  
                if (File.Exists(fileName))
                {
                    Console.WriteLine(FeedbackValue.CONFIGURATION_EXISTS);
                }
                else
                {
                    using (FileStream fs = File.Create(fileName))
                    {
                        fs.Write(json, 0, json.Length);
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        public ConfigurationItems Load() 
        {

            try
            {
                var fileName = $@"{_destiny}\{SystemConfigurationValue.FILE_NAME}";
                using (var sr = new StreamReader(fileName))
                { 
                    var text = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<ConfigurationItems>(text);
                }
            }
            catch (IOException ex)
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        internal void Delete()
        {
            try
            {
                var fileName = $@"{_destiny}\{SystemConfigurationValue.FILE_NAME}";
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        public string LoadString()
        { 
            try
            {
                var fileName = $@"{_destiny}\{SystemConfigurationValue.FILE_NAME}";
                using (var sr = new StreamReader(fileName))
                {
                    return sr.ReadToEnd(); 
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

    }
}
