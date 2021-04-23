using System.Collections.Generic;

namespace AMG.DapperEntities.Domain.Values
{
    public static class PropertyTypeValue
    {

        public static List<(string, string)> Items = new List<(string, string)>() 
        {
            ("bigint","long"),
            ("binary","byte[]"),
            ("bit","bool"),
            ("char","string"),
            ("date","DateTime"),
            ("datetime","DateTime"),
            ("datetime2","DateTime"),
            ("datetimeoffset","DateTimeOffset"),
            ("decimal","decimal"),
            ("float","float"),
            ("image","byte[]"),
            ("int","int"),
            ("money","decimal"),
            ("nchar","char"),
            ("ntext","string"),
            ("numeric","decimal"),
            ("nvarchar","string"),
            ("real","double"),
            ("smalldatetime","DateTime"),
            ("smallint","short"),
            ("smallmoney","decimal"),
            ("text","string"),
            ("time","TimeSpan"),
            ("timestamp","DateTime"),
            ("tinyint","byte"),
            ("uniqueidentifier","Guid"),
            ("varbinary","byte[]"),
            ("varchar","string") 
        };

            
    }
}
