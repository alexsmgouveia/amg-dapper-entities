using System;
using System.Collections.Generic;
using System.Text;

namespace AMG.DapperEntities.Domain.Values
{
    public static class FeedbackValue
    {

        public static string INVALID_COMMAND => $"Invalid command. Try using {CommandValue.SIMPLE_HELP} or {CommandValue.HELP}";

        public static string SUCCESSFULLY => "Command Successfully Executed";

        public static string CONFIGURATION_EXISTS => $"The configuration already exists. Run the {CommandValue.CONFIG_DELETE} command before creating new configurations";

        public static List<(string Command, string Description)> _COMMAND_TYPES = new List<(string, string)>
        {
            (CommandValue.SIMPLE_HELP,       "Display this help message"),
            (CommandValue.HELP,              "Display this help message"),
            (CommandValue.SIMPLE_VERSION,    "Display this application version"),
            (CommandValue.VERSION,           "Display this application version"),
            (CommandValue.CONFIG_GET,        "Display the current configuration on the screen"),
            (CommandValue.CONFIG_TEST,       "Test the connection of the current configuration"),
            (CommandValue.CONFIG_INSTALL,    "Creates a new configuration"),
            (CommandValue.CONFIG_DELETE,     "Deletes the file from the current configuration"),
            (CommandValue.ENTITY_CREATE,     "Creates the entity class based on table properties"),
            (CommandValue.ENTITY_UPDATE,     "Updates the entity class based on table properties")

        };
        public static string DATABASE_IS_AVAILABLE => "Connection successful";
        public static string DATABASE_IS_NOT_AVAILABLE => "Error: Invalid connection"; 
        public static string WAIT_FINISH => "Wait for the command to finish";
    }
}
