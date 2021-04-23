using System.Linq;

namespace AMG.DapperEntities.CrossCutting.Helpers
{
    public static class DirectoryHelper
    {
        public static string CurrentFolderName()
        {
            return System.IO.Directory.GetCurrentDirectory().Split('\\').Last();

        }

        public static string CurrentPath()
        {
            return System.IO.Directory.GetCurrentDirectory();

        }
    }
}
