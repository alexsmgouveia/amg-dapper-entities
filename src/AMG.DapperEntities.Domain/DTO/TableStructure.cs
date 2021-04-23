using System.Collections.Generic;

namespace AMG.DapperEntities.Domain.DTO
{
    public class TableStructure
    {
        public string Name { get; set; }

        public List<ColumnStructure> Columns { get; set; }
    }
}
