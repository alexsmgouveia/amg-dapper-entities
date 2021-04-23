using System;
using System.Collections.Generic;
using System.Text;

namespace AMG.DapperEntities.Domain.DTO
{
    public class ColumnStructure
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Length { get; set; } 

        public bool IsNullable { get; set; }
    }
}
