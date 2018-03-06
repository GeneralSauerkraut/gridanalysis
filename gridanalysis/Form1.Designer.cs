namespace gridanalysis
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TPRibs = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBRibs = new System.Windows.Forms.ComboBox();
            this.BtRemoveRib = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtAddRib = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBRibAdd = new System.Windows.Forms.TextBox();
            this.LVRibs = new System.Windows.Forms.ListView();
            this.TPTop = new System.Windows.Forms.TabPage();
            this.TPBot = new System.Windows.Forms.TabPage();
            this.TPOver = new System.Windows.Forms.TabPage();
            this.TPAnal = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.LVRibsOver = new System.Windows.Forms.ListView();
            this.LVStrTopOver = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.LVStrBotOver = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.LVStrTop = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TBStrTopVert = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CbRibStr1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CbRibStr2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BtAddStrTop = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtStrTopRemove = new System.Windows.Forms.Button();
            this.CBStrTopRemove = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TPRibs.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TPTop.SuspendLayout();
            this.TPOver.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TPRibs);
            this.tabControl1.Controls.Add(this.TPTop);
            this.tabControl1.Controls.Add(this.TPBot);
            this.tabControl1.Controls.Add(this.TPOver);
            this.tabControl1.Controls.Add(this.TPAnal);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // TPRibs
            // 
            this.TPRibs.Controls.Add(this.label5);
            this.TPRibs.Controls.Add(this.groupBox2);
            this.TPRibs.Controls.Add(this.groupBox1);
            this.TPRibs.Controls.Add(this.LVRibs);
            this.TPRibs.Location = new System.Drawing.Point(4, 22);
            this.TPRibs.Name = "TPRibs";
            this.TPRibs.Size = new System.Drawing.Size(636, 534);
            this.TPRibs.TabIndex = 0;
            this.TPRibs.Text = "Ribs";
            this.TPRibs.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Overview of Ribs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBRibs);
            this.groupBox2.Controls.Add(this.BtRemoveRib);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(26, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 104);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove Rib";
            // 
            // CBRibs
            // 
            this.CBRibs.FormattingEnabled = true;
            this.CBRibs.Location = new System.Drawing.Point(123, 19);
            this.CBRibs.Name = "CBRibs";
            this.CBRibs.Size = new System.Drawing.Size(108, 21);
            this.CBRibs.TabIndex = 4;
            // 
            // BtRemoveRib
            // 
            this.BtRemoveRib.Location = new System.Drawing.Point(9, 58);
            this.BtRemoveRib.Name = "BtRemoveRib";
            this.BtRemoveRib.Size = new System.Drawing.Size(248, 40);
            this.BtRemoveRib.TabIndex = 3;
            this.BtRemoveRib.Text = "Remove";
            this.BtRemoveRib.UseVisualStyleBackColor = true;
            this.BtRemoveRib.Click += new System.EventHandler(this.BtRemoveRib_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Distance from the Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtAddRib);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBRibAdd);
            this.groupBox1.Location = new System.Drawing.Point(26, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Rib";
            // 
            // BtAddRib
            // 
            this.BtAddRib.Location = new System.Drawing.Point(9, 45);
            this.BtAddRib.Name = "BtAddRib";
            this.BtAddRib.Size = new System.Drawing.Size(248, 40);
            this.BtAddRib.TabIndex = 3;
            this.BtAddRib.Text = "Add";
            this.BtAddRib.UseVisualStyleBackColor = true;
            this.BtAddRib.Click += new System.EventHandler(this.BtAddRib_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Distance from the Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "mm";
            // 
            // TBRibAdd
            // 
            this.TBRibAdd.Location = new System.Drawing.Point(123, 19);
            this.TBRibAdd.Name = "TBRibAdd";
            this.TBRibAdd.Size = new System.Drawing.Size(108, 20);
            this.TBRibAdd.TabIndex = 0;
            this.TBRibAdd.Text = "100";
            // 
            // LVRibs
            // 
            this.LVRibs.GridLines = true;
            this.LVRibs.Location = new System.Drawing.Point(315, 36);
            this.LVRibs.Name = "LVRibs";
            this.LVRibs.Size = new System.Drawing.Size(226, 482);
            this.LVRibs.TabIndex = 0;
            this.LVRibs.UseCompatibleStateImageBehavior = false;
            this.LVRibs.View = System.Windows.Forms.View.List;
            // 
            // TPTop
            // 
            this.TPTop.Controls.Add(this.groupBox4);
            this.TPTop.Controls.Add(this.label16);
            this.TPTop.Controls.Add(this.label15);
            this.TPTop.Controls.Add(this.groupBox3);
            this.TPTop.Controls.Add(this.LVStrTop);
            this.TPTop.Location = new System.Drawing.Point(4, 22);
            this.TPTop.Name = "TPTop";
            this.TPTop.Size = new System.Drawing.Size(636, 534);
            this.TPTop.TabIndex = 1;
            this.TPTop.Text = "Stringers Top";
            this.TPTop.UseVisualStyleBackColor = true;
            // 
            // TPBot
            // 
            this.TPBot.Location = new System.Drawing.Point(4, 22);
            this.TPBot.Name = "TPBot";
            this.TPBot.Size = new System.Drawing.Size(636, 534);
            this.TPBot.TabIndex = 2;
            this.TPBot.Text = "Stringers Bot";
            this.TPBot.UseVisualStyleBackColor = true;
            // 
            // TPOver
            // 
            this.TPOver.Controls.Add(this.LVStrBotOver);
            this.TPOver.Controls.Add(this.label8);
            this.TPOver.Controls.Add(this.LVStrTopOver);
            this.TPOver.Controls.Add(this.label7);
            this.TPOver.Controls.Add(this.LVRibsOver);
            this.TPOver.Controls.Add(this.label6);
            this.TPOver.Location = new System.Drawing.Point(4, 22);
            this.TPOver.Name = "TPOver";
            this.TPOver.Size = new System.Drawing.Size(636, 534);
            this.TPOver.TabIndex = 4;
            this.TPOver.Text = "Overview";
            this.TPOver.UseVisualStyleBackColor = true;
            // 
            // TPAnal
            // 
            this.TPAnal.Location = new System.Drawing.Point(4, 22);
            this.TPAnal.Name = "TPAnal";
            this.TPAnal.Size = new System.Drawing.Size(636, 534);
            this.TPAnal.TabIndex = 3;
            this.TPAnal.Text = "Analysis";
            this.TPAnal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ribs";
            // 
            // LVRibsOver
            // 
            this.LVRibsOver.Location = new System.Drawing.Point(14, 56);
            this.LVRibsOver.Name = "LVRibsOver";
            this.LVRibsOver.Size = new System.Drawing.Size(66, 302);
            this.LVRibsOver.TabIndex = 1;
            this.LVRibsOver.UseCompatibleStateImageBehavior = false;
            this.LVRibsOver.View = System.Windows.Forms.View.List;
            // 
            // LVStrTopOver
            // 
            this.LVStrTopOver.Location = new System.Drawing.Point(201, 56);
            this.LVStrTopOver.Name = "LVStrTopOver";
            this.LVStrTopOver.Size = new System.Drawing.Size(142, 302);
            this.LVStrTopOver.TabIndex = 3;
            this.LVStrTopOver.UseCompatibleStateImageBehavior = false;
            this.LVStrTopOver.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stringers Top";
            // 
            // LVStrBotOver
            // 
            this.LVStrBotOver.Location = new System.Drawing.Point(416, 56);
            this.LVStrBotOver.Name = "LVStrBotOver";
            this.LVStrBotOver.Size = new System.Drawing.Size(161, 302);
            this.LVStrBotOver.TabIndex = 5;
            this.LVStrBotOver.UseCompatibleStateImageBehavior = false;
            this.LVStrBotOver.View = System.Windows.Forms.View.List;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Stringers Bot";
            // 
            // LVStrTop
            // 
            this.LVStrTop.Location = new System.Drawing.Point(434, 73);
            this.LVStrTop.Name = "LVStrTop";
            this.LVStrTop.Size = new System.Drawing.Size(142, 302);
            this.LVStrTop.TabIndex = 4;
            this.LVStrTop.UseCompatibleStateImageBehavior = false;
            this.LVStrTop.View = System.Windows.Forms.View.List;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtAddStrTop);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.CbRibStr2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.CbRibStr1);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TBStrTopVert);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(16, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 177);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Stringer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Position From the Top";
            // 
            // TBStrTopVert
            // 
            this.TBStrTopVert.Location = new System.Drawing.Point(128, 23);
            this.TBStrTopVert.Name = "TBStrTopVert";
            this.TBStrTopVert.Size = new System.Drawing.Size(84, 20);
            this.TBStrTopVert.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Starting Rib";
            // 
            // CbRibStr1
            // 
            this.CbRibStr1.FormattingEnabled = true;
            this.CbRibStr1.Location = new System.Drawing.Point(128, 58);
            this.CbRibStr1.Name = "CbRibStr1";
            this.CbRibStr1.Size = new System.Drawing.Size(84, 21);
            this.CbRibStr1.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(218, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(218, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "mm";
            // 
            // CbRibStr2
            // 
            this.CbRibStr2.FormattingEnabled = true;
            this.CbRibStr2.Location = new System.Drawing.Point(128, 90);
            this.CbRibStr2.Name = "CbRibStr2";
            this.CbRibStr2.Size = new System.Drawing.Size(84, 21);
            this.CbRibStr2.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Ending Rib";
            // 
            // BtAddStrTop
            // 
            this.BtAddStrTop.Location = new System.Drawing.Point(15, 128);
            this.BtAddStrTop.Name = "BtAddStrTop";
            this.BtAddStrTop.Size = new System.Drawing.Size(226, 35);
            this.BtAddStrTop.TabIndex = 9;
            this.BtAddStrTop.Text = "Add Stringer";
            this.BtAddStrTop.UseVisualStyleBackColor = true;
            this.BtAddStrTop.Click += new System.EventHandler(this.BtAddStrTop_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(431, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Stringers";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(431, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Vertical Position, Start, End";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.BtStrTopRemove);
            this.groupBox4.Controls.Add(this.CBStrTopRemove);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(16, 218);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 119);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remove Stringer";
            // 
            // BtStrTopRemove
            // 
            this.BtStrTopRemove.Location = new System.Drawing.Point(15, 73);
            this.BtStrTopRemove.Name = "BtStrTopRemove";
            this.BtStrTopRemove.Size = new System.Drawing.Size(226, 35);
            this.BtStrTopRemove.TabIndex = 9;
            this.BtStrTopRemove.Text = "Remove Stringer";
            this.BtStrTopRemove.UseVisualStyleBackColor = true;
            // 
            // CBStrTopRemove
            // 
            this.CBStrTopRemove.FormattingEnabled = true;
            this.CBStrTopRemove.Location = new System.Drawing.Point(94, 36);
            this.CBStrTopRemove.Name = "CBStrTopRemove";
            this.CBStrTopRemove.Size = new System.Drawing.Size(132, 21);
            this.CBStrTopRemove.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Select Stringer";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(91, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(135, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Vertical Position, Start, End";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 584);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.TPRibs.ResumeLayout(false);
            this.TPRibs.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TPTop.ResumeLayout(false);
            this.TPTop.PerformLayout();
            this.TPOver.ResumeLayout(false);
            this.TPOver.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TPRibs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtRemoveRib;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtAddRib;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBRibAdd;
        private System.Windows.Forms.ListView LVRibs;
        private System.Windows.Forms.TabPage TPTop;
        private System.Windows.Forms.TabPage TPBot;
        private System.Windows.Forms.TabPage TPOver;
        private System.Windows.Forms.TabPage TPAnal;
        private System.Windows.Forms.ComboBox CBRibs;
        private System.Windows.Forms.ListView LVStrBotOver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView LVStrTopOver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView LVRibsOver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBStrTopVert;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView LVStrTop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CbRibStr2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CbRibStr1;
        private System.Windows.Forms.Button BtAddStrTop;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtStrTopRemove;
        private System.Windows.Forms.ComboBox CBStrTopRemove;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}

