using System;
using System.Collections.Generic;
using System.Text;

namespace AMG.DapperEntities.Domain.DTO
{
    public class TableInfo
    {

        public string CHARACTER_MAXIMUM_LENGTH { get; set; }

        public string COLUMN_NAME { get; set; }

        public string DATA_TYPE { get; set; }

        public string IS_NULLABLE { get; set; }
    }
}
