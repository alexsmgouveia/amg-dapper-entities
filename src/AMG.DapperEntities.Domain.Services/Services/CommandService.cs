using AMG.DapperEntities.Domain.DTO;
using AMG.DapperEntities.Domain.Values;
using AMG.DapperEntities.CrossCutting.Helpers;
using System;
using System.Linq;

namespace AMG.DapperEntities.Domain.Data.Services
{
    public class CommandService
    {
        private readonly ConfigurationService _configurationService;

        public CommandService()
        {
            this._configurationService = new ConfigurationService(DirectoryHelper.CurrentPath());
        }
        /// <summary>
        /// Command Action
        /// </summary>
        /// <param name="cmd"></param>
        public void Action(string cmd) 
        {

            if (cmd.CompareIgnoreCase(CommandValue.SIMPLE_VERSION, CommandValue.SIMPLE_VERSION))
            {
                var version = ApplicationHelper.Version();
                Console.WriteLine(version);
            } 
            
            else if (cmd.CompareIgnoreCase(CommandValue.SIMPLE_HELP, CommandValue.HELP))
            {
                Help(); 
            } 

            else if (cmd.CompareIgnoreCase(CommandValue.CONFIG_GET))
            {
                var str_config = _configurationService.LoadString();
                Console.WriteLine(str_config);
            }

            else if (cmd.CompareIgnoreCase(CommandValue.CONFIG_INSTALL))
            {
                _configurationService.Create();
                Console.WriteLine(FeedbackValue.SUCCESSFULLY);
            }

            else if (cmd.CompareIgnoreCase(CommandValue.CONFIG_DELETE))
            {
                _configurationService.Delete();
                Console.WriteLine(FeedbackValue.SUCCESSFULLY);
            }

            else if (cmd.CompareIgnoreCase(CommandValue.CONFIG_TEST))
            {
                var config = _configurationService.Load();
                if(config != null)
                {
                    var credential = new DbCredential(config.server, config.database, config.user, config.password);
                    var service = new DbExtractorService(credential);
                    var isSuccess = service.IsAvailable();
                    if(isSuccess)
                    {
                        Console.WriteLine(FeedbackValue.DATABASE_IS_AVAILABLE);
                    }
                    else
                    {
                        Console.WriteLine(FeedbackValue.DATABASE_IS_NOT_AVAILABLE);
                    }


                }
            }

            else if (cmd.CompareIgnoreCase(CommandValue.ENTITY_CREATE))
            {
                var config = _configurationService.Load();
                if (config != null)
                {
                    Console.WriteLine(FeedbackValue.WAIT_FINISH);

                    var extractor = new ExtractorService(config);
                    extractor.CreateClass();

                    Console.WriteLine(FeedbackValue.SUCCESSFULLY);
                }
            }

            else if (cmd.CompareIgnoreCase(CommandValue.ENTITY_UPDATE))
            {
                var config = _configurationService.Load();
                if (config != null)
                {
                    Console.WriteLine(FeedbackValue.WAIT_FINISH);

                    var extractor = new ExtractorService(config);
                    extractor.UpdateClass();

                    Console.WriteLine(FeedbackValue.SUCCESSFULLY);
                }
            }
        }


        /// <summary>
        /// Command Valid
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool IsValid(string cmd)
            => FeedbackValue._COMMAND_TYPES
            .Any(x => x.Command.CompareIgnoreCase(cmd));


        /// <summary>
        /// Help Options
        /// </summary>
        public void Help()
        {
            var commandTypes = FeedbackValue._COMMAND_TYPES;
            var spaceLength = commandTypes.Select(x => x.Command.Length).OrderByDescending(x => x).First();
            foreach (var type in commandTypes)
            {
                var cmd = type.Command;
                var description = type.Description;

                var len = cmd.Length;
                var space = string.Empty;

                if (len < spaceLength)
                {
                    for (int i = len; i < spaceLength; i++) 
                        space += " "; 
                }
                Console.WriteLine($"{cmd}{space} : {description}");
            }

        }

    }
}
