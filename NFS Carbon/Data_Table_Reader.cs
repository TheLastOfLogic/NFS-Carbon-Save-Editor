using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher
{
    internal class Data_Table_Reader
    {
        public static List<string> Unlocks = new List<string>();

        public static void Finding_Unlock_Location(byte[] data)
        {
            string giantString = System.Text.Encoding.ASCII.GetString(data);

            // Now you can search it easily
            if (giantString.Contains("12345: t/"))
            {
                int index = giantString.IndexOf("12345: t/");
                // Do something with the location
            }
        }

    }
}
