using AMG.DapperEntities.Domain.Data.Services;
using AMG.DapperEntities.Domain.DTO;
using Xunit;

namespace AMG.DapperEntities.Test
{
    public class DatabaseTest
    {
        string server = "";
        string database = "";
        string user = "";
        string pwd = "";

        [Fact]
        public void SchemasAndTablesNames()
        {
            var credential = new DbCredential(server, database, user, pwd);
            var service = new DbExtractorService(credential);
            var names = service.SchemasAndTablesNames();
            Assert.True(names.Count > 0);
        }

        [Fact]
        public void SchemasNames()
        {
            var credential = new DbCredential(server, database, user, pwd);
            var service = new DbExtractorService(credential);
            var names = service.SchemasNames();
            Assert.True(names.Count > 0);
        }



        [Fact]
        public void TableStructures()
        {
            var credential = new DbCredential(server, database, user, pwd);
            var service = new DbExtractorService(credential);
            var names = service.SchemasNames();
            Assert.True(names.Count > 0);
        }


        [Fact]
        public void TableProperties()
        {
            var tableName = "Owner";
            var credential = new DbCredential(server, database, user, pwd);
            var service = new DbExtractorService(credential);
            var names = service.TableProperties(tableName);
            Assert.True(names.Count > 0);
        }
    }
}
