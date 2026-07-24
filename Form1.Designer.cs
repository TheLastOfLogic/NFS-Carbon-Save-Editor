namespace EA_MD5_hasher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            button3 = new Button();
            button4 = new Button();
            JDLZ_Compress = new Button();
            JDLZ_Decompressor = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            groupBox1 = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            Grab_File_Path_2 = new Button();
            label4 = new Label();
            label3 = new Label();
            Write_File_Data = new Label();
            Extract_File_Data = new Label();
            Grab_File_Path_1 = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(521, 175);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(157, 293);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(337, 123);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(974, 321);
            button4.Name = "button4";
            button4.Size = new Size(106, 44);
            button4.TabIndex = 3;
            button4.Text = "Unlock All Fix Checksum";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // JDLZ_Compress
            // 
            JDLZ_Compress.Location = new Point(91, 32);
            JDLZ_Compress.Name = "JDLZ_Compress";
            JDLZ_Compress.Size = new Size(93, 54);
            JDLZ_Compress.TabIndex = 4;
            JDLZ_Compress.Text = "JDLZ Compress File";
            JDLZ_Compress.UseVisualStyleBackColor = true;
            JDLZ_Compress.Click += button5_Click;
            // 
            // JDLZ_Decompressor
            // 
            JDLZ_Decompressor.Enabled = false;
            JDLZ_Decompressor.Location = new Point(91, 92);
            JDLZ_Decompressor.Name = "JDLZ_Decompressor";
            JDLZ_Decompressor.Size = new Size(93, 54);
            JDLZ_Decompressor.TabIndex = 5;
            JDLZ_Decompressor.Text = "JDLZ Decompress File";
            JDLZ_Decompressor.UseVisualStyleBackColor = true;
            JDLZ_Decompressor.Click += JDLZ_Decompressor_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(621, 51);
            button5.Name = "button5";
            button5.Size = new Size(100, 35);
            button5.TabIndex = 6;
            button5.Text = "open and save";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.Location = new Point(195, 184);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = "Convert";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(339, 32);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 8;
            button7.Text = "HUFF MAN";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(677, 184);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 9;
            button8.Text = "Save";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(Grab_File_Path_2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(Write_File_Data);
            groupBox1.Controls.Add(Extract_File_Data);
            groupBox1.Controls.Add(Grab_File_Path_1);
            groupBox1.Location = new Point(810, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(421, 238);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(15, 159);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(79, 19);
            checkBox2.TabIndex = 19;
            checkBox2.Text = "Xbox Save";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(15, 74);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 19);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Xbox Save";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Grab_File_Path_2
            // 
            Grab_File_Path_2.Font = new Font("Segoe UI", 9F);
            Grab_File_Path_2.Location = new Point(379, 134);
            Grab_File_Path_2.Name = "Grab_File_Path_2";
            Grab_File_Path_2.Size = new Size(36, 22);
            Grab_File_Path_2.TabIndex = 17;
            Grab_File_Path_2.Text = "...";
            Grab_File_Path_2.UseVisualStyleBackColor = true;
            Grab_File_Path_2.Click += Grab_File_Path_2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(15, 112);
            label4.Name = "label4";
            label4.Size = new Size(144, 19);
            label4.TabIndex = 16;
            label4.Text = "File Being Overwritten";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(15, 24);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 15;
            label3.Text = "File To Copy From";
            // 
            // Write_File_Data
            // 
            Write_File_Data.AutoSize = true;
            Write_File_Data.Font = new Font("Segoe UI", 9F);
            Write_File_Data.Location = new Point(15, 141);
            Write_File_Data.Name = "Write_File_Data";
            Write_File_Data.Size = new Size(38, 15);
            Write_File_Data.TabIndex = 14;
            Write_File_Data.Text = "label2";
            // 
            // Extract_File_Data
            // 
            Extract_File_Data.AutoSize = true;
            Extract_File_Data.Font = new Font("Segoe UI", 9F);
            Extract_File_Data.Location = new Point(15, 56);
            Extract_File_Data.Name = "Extract_File_Data";
            Extract_File_Data.Size = new Size(38, 15);
            Extract_File_Data.TabIndex = 13;
            Extract_File_Data.Text = "label1";
            // 
            // Grab_File_Path_1
            // 
            Grab_File_Path_1.Font = new Font("Segoe UI", 9F);
            Grab_File_Path_1.Location = new Point(379, 49);
            Grab_File_Path_1.Name = "Grab_File_Path_1";
            Grab_File_Path_1.Size = new Size(36, 22);
            Grab_File_Path_1.TabIndex = 12;
            Grab_File_Path_1.Text = "...";
            Grab_File_Path_1.UseVisualStyleBackColor = true;
            Grab_File_Path_1.Click += Grab_File_Path_1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 450);
            Controls.Add(groupBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(JDLZ_Decompressor);
            Controls.Add(JDLZ_Compress);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private FileSystemWatcher fileSystemWatcher1;
        private Button button3;
        private Button button4;
        private Button JDLZ_Compress;
        private Button JDLZ_Decompressor;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private GroupBox groupBox1;
        private Button Grab_File_Path_1;
        private Button Grab_File_Path_2;
        private Label label4;
        private Label label3;
        private Label Write_File_Data;
        private Label Extract_File_Data;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}
