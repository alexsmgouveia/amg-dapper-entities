
using AMG.DapperEntities.Domain.Data.Services;
using AMG.DapperEntities.Domain.Values;
using System;

namespace AMG.DapperEntities
{
    class Program
    { 
        static void Main(string[] args)
        {
            var service = new CommandService();
            var cmd = string.Join(string.Empty, args);

            if(service.IsValid(cmd))
            {
                service.Action(cmd);
            }
            else 
            {
                Console.WriteLine(FeedbackValue.INVALID_COMMAND);
            }
              
        }
    }
}
