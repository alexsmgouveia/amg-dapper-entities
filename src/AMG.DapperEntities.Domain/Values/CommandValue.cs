using System;
using System.Collections.Generic;
using System.Linq;

namespace AMG.DapperEntities.Domain.Values
{

    /// <summary>
    /// Commands
    /// </summary>
    public static class CommandValue
    { 
        public static string SIMPLE_HELP => "-h";
        public static string HELP => "--help";
        public static string SIMPLE_VERSION => "-v";
        public static string VERSION => "--version";
        public static string CONFIG_GET => "config-get";
        public static string CONFIG_TEST => "config-test";
        public static string CONFIG_INSTALL => "config-install";
        public static string CONFIG_DELETE => "config-delete";
        public static string ENTITY_CREATE => "entity-create";
        public static string ENTITY_UPDATE => "entity-update";
    }
}
