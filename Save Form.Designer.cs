namespace EA_MD5_hasher
{
    partial class Save_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "1" }, -1, Color.Empty, Color.Empty, new Font("Segoe UI", 11F));
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "2" }, -1, Color.Empty, Color.Empty, new Font("Segoe UI", 11F));
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "3" }, -1, Color.Empty, Color.Empty, new Font("Segoe UI", 11F));
            JDLZ_List_View = new ListView();
            Index = new ColumnHeader();
            Offset_C = new ColumnHeader();
            Packed_Size_C = new ColumnHeader();
            Unpacked_Size_C = new ColumnHeader();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // JDLZ_List_View
            // 
            JDLZ_List_View.Columns.AddRange(new ColumnHeader[] { Index, Offset_C, Packed_Size_C, Unpacked_Size_C });
            JDLZ_List_View.GridLines = true;
            JDLZ_List_View.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            JDLZ_List_View.LabelEdit = true;
            JDLZ_List_View.Location = new Point(6, 26);
            JDLZ_List_View.MultiSelect = false;
            JDLZ_List_View.Name = "JDLZ_List_View";
            JDLZ_List_View.Size = new Size(624, 369);
            JDLZ_List_View.TabIndex = 4;
            JDLZ_List_View.UseCompatibleStateImageBehavior = false;
            JDLZ_List_View.View = View.Details;
            // 
            // Index
            // 
            Index.Text = "#";
            Index.Width = 25;
            // 
            // Offset_C
            // 
            Offset_C.Text = "Offset";
            Offset_C.Width = 120;
            // 
            // Packed_Size_C
            // 
            Packed_Size_C.Text = "Packed Size";
            Packed_Size_C.Width = 120;
            // 
            // Unpacked_Size_C
            // 
            Unpacked_Size_C.Text = "Unpacked Szie";
            Unpacked_Size_C.Width = 120;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(JDLZ_List_View);
            groupBox1.Font = new Font("Segoe UI", 11F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(639, 439);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "JDLZ Compressed Blocks";
            // 
            // button3
            // 
            button3.Location = new Point(292, 401);
            button3.Name = "button3";
            button3.Size = new Size(87, 32);
            button3.TabIndex = 6;
            button3.Text = "Export";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(201, 401);
            button2.Name = "button2";
            button2.Size = new Size(85, 32);
            button2.TabIndex = 5;
            button2.Text = "Import...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Save_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 623);
            Controls.Add(groupBox1);
            Name = "Save_Form";
            Text = "Save_Form";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView JDLZ_List_View;
        private ColumnHeader Index;
        private ColumnHeader Offset_C;
        private ColumnHeader Packed_Size_C;
        private ColumnHeader Unpacked_Size_C;
        private GroupBox groupBox1;
        private Button button2;
        private Button button3;
    }
}