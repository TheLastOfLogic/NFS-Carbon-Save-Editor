using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EA_MD5_hasher
{
    public partial class Save_Form : Form
    {
        public static bool Xbox_360 = false;
        public Save_Form()
        {
            InitializeComponent();
            //File_Data_Hash_TB.Text = Get_Registry_Key.Fix_Get_Key(File_Data_Hash_TB,Form1.Find_Game);
            //Registry_CD_Key_TB.Text = Get_Registry_Key.SyncPhysicalKeyToVirtualStore(Form1.Find_Game);
            /*Save_File_CD_Key_TB.Text = Get_Registry_Key.Get_PC_Save_Key(Form1.Find_Game);
            Header_Data_MTB.Text = Get_Registry_Key.CRC32_Hash_To_String(Form1.Find_Game, 0);
            if (Save_File_CD_Key_TB.Text != Registry_CD_Key_TB.Text)
            {
                Save_File_CD_Key_TB.ForeColor = Color.Red;
            } */
            
               // File_Data_Hash_TB.ForeColor = Get_Registry_Key.Compare_PC_MD5(Form1.Find_Game);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper_Functions.Populate_JDLZ_List(JDLZ_List_View);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (JDLZ_List_View.SelectedIndices.Count > 0)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] JDLZ = new byte[0];
            Helper_Functions.Grabbing_Data(JDLZ_List_View, ref JDLZ);
            //Read_Data_Table.Read_Decompressed_Data(ref JDLZ);
            //File.WriteAllBytes("C:\\Users\\Logic\\Documents\\Xenia\\content\\454107EC\\00000001\\ALIAS_AAA\\ALIAS_AAA1", JDLZ);
        }
    }
}
