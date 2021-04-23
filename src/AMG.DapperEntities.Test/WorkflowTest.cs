using AMG.DapperEntities.Domain.Data.Services;
using Xunit;

namespace AMG.DapperEntities.Test
{
    public class WorkflowTest
    {

        [Fact]
        public void CreateConfig() 
        { 
            try
            {
                var service = new ConfigurationService(@"D:\Temp\");
                service.Create();
                Assert.True(true);
            }
            catch 
            {
                Assert.True(false);
            }
           
        }





        [Fact]
        public void Generate()
        {
            try
            {
                var destiny = @"D:\Temp\";
                var service = new ConfigurationService(destiny);
                var config = service.Load();
                var extractor = new ExtractorService(config);
                extractor.CreateClass();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
