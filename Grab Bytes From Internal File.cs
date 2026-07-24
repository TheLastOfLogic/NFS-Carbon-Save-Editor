using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    public static class Grab_Bytes_From_Internal_File
    {
       



        public static byte[] GetResourceBytes(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Hardcoded to match your exact project properties:
            // RootNamespace = EA_MD5_hasher
            // Folder = PC Data Dump (becomes PC_Data_Dump)
            string fullResourceName = $"EA_MD5_hasher.PC_Data_Dump.{fileName}";

            using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Could not find embedded resource: {fullResourceName}");
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
     