using System.IO;
using System.Security.AccessControl;

namespace addPermissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Directory.GetCurrentDirectory();
            DirectorySecurity fSecurity = Directory.GetAccessControl(fileName);
            fSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.Write, AccessControlType.Allow));
            Directory.SetAccessControl(fileName, fSecurity);
        }
    }
}
