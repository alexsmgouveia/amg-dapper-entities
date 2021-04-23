using AMG.DapperEntities.Domain.DTO;
using AMG.DapperEntities.Domain.Values;
using System.Collections.Generic;
using System.Linq;

namespace AMG.DapperEntities.Domain.Data.Services
{
    public class ClassService
    { 
        private readonly string _namespace;
         

        public ClassService(string @namespace)
        {
            this._namespace = @namespace;
        }

        public List<(string, string)> Mapper(params TableStructure[] tableStructures) 
        {
            var list = new List<(string, string)>();
             
            foreach (var tableStructure in tableStructures)
            {
                var temaplateClass = ClassTemplate.CLASS;
                var className = tableStructure.Name;
                 
                temaplateClass = temaplateClass.Replace("${namespace}", _namespace);
                temaplateClass = temaplateClass.Replace("${className}", className);


                var properties = new List<string>();
                foreach (var column in tableStructure.Columns)
                {
                    var dbPropertyName = column.Name;
                    var dbPropertyType = column.Type;
                    var dbPropertyIsNull = column.IsNullable;
                    var dbPropertyLength = column.Length;
                    var propertyAnnotation = string.Empty;
                     
                    var temaplateProperty = $"{ClassTemplate.PROPERTY}";
                    var item = PropertyTypeValue.Items.First(x => x.Item1 == column.Type?.ToLower());

                    var propertyType = item.Item2;

                    if (propertyType == "string" && dbPropertyLength > 0)
                        temaplateProperty = temaplateProperty.Replace("${annotation}", $"[StringLength({dbPropertyLength})]");
                    else
                        temaplateProperty = temaplateProperty.Replace("${annotation}", string.Empty);
                     
                    if (dbPropertyIsNull && !new[] { "string", "byte[]"  }.Contains(propertyType))
                        temaplateProperty = temaplateProperty.Replace("${property}", $"{propertyType}?");
                    else
                        temaplateProperty = temaplateProperty.Replace("${property}", propertyType);

                    temaplateProperty = temaplateProperty.Replace("${propertyName}", dbPropertyName);

                    properties.Add(temaplateProperty);
                }

                temaplateClass = temaplateClass.Replace("${properties}", $"{string.Join(string.Empty, properties)}");
                list.Add((tableStructure.Name, temaplateClass));

            }
             
            return list;
        }
    }
}
