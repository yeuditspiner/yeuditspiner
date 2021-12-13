namespace UI
{
    partial class FrmScheduling
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScheduling));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.חזורToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gbclass = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstStudentsWwithOutPlacment = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.gbclass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.חזורToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1905, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // חזורToolStripMenuItem
            // 
            this.חזורToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("חזורToolStripMenuItem.Image")));
            this.חזורToolStripMenuItem.Name = "חזורToolStripMenuItem";
            this.חזורToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.חזורToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.חזורToolStripMenuItem.Text = "חזור";
            this.חזורToolStripMenuItem.Click += new System.EventHandler(this.חזורToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "[לעזרה F1]הקש ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbclass
            // 
            this.gbclass.AutoSize = true;
            this.gbclass.Controls.Add(this.button4);
            this.gbclass.Controls.Add(this.pictureBox1);
            this.gbclass.Controls.Add(this.cmbStudent);
            this.gbclass.Controls.Add(this.button2);
            this.gbclass.Controls.Add(this.button3);
            this.gbclass.Controls.Add(this.button1);
            this.gbclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.gbclass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gbclass.Location = new System.Drawing.Point(12, 0);
            this.gbclass.Name = "gbclass";
            this.gbclass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbclass.Size = new System.Drawing.Size(1684, 788);
            this.gbclass.TabIndex = 4;
            this.gbclass.TabStop = false;
            this.gbclass.Text = "מראה כיתה";
            this.gbclass.UseCompatibleTextRendering = true;
            this.gbclass.DragDrop += new System.Windows.Forms.DragEventHandler(this.gbclass_DragEnter);
            this.gbclass.DragEnter += new System.Windows.Forms.DragEventHandler(this.gbclass_DragEnter);
            this.gbclass.Enter += new System.EventHandler(this.groupBox1_Enter_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 37);
            this.button4.TabIndex = 8;
            this.button4.Text = "ניקוי";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(759, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "שולחן מורה";
            // 
            // cmbStudent
            // 
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(228, 73);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(166, 24);
            this.cmbStudent.TabIndex = 6;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(228, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "עזרה";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lstStudentsWwithOutPlacment
            // 
            this.lstStudentsWwithOutPlacment.FormattingEnabled = true;
            this.lstStudentsWwithOutPlacment.ItemHeight = 16;
            this.lstStudentsWwithOutPlacment.Location = new System.Drawing.Point(1902, 70);
            this.lstStudentsWwithOutPlacment.Name = "lstStudentsWwithOutPlacment";
            this.lstStudentsWwithOutPlacment.Size = new System.Drawing.Size(135, 612);
            this.lstStudentsWwithOutPlacment.TabIndex = 5;
            this.lstStudentsWwithOutPlacment.SelectedIndexChanged += new System.EventHandler(this.lstStudentsWwithOutPlacment_SelectedIndexChanged);
            this.lstStudentsWwithOutPlacment.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstStudentsWwithOutPlacment_DragEnter);
            this.lstStudentsWwithOutPlacment.DragLeave += new System.EventHandler(this.lstStudentsWwithOutPlacment_DragLeave);
            this.lstStudentsWwithOutPlacment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstStudentsWwithOutPlacment_MouseDown);
            // 
            // FrmScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 831);
            this.Controls.Add(this.gbclass);
            this.Controls.Add(this.lstStudentsWwithOutPlacment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmScheduling";
            this.Text = "FrmScheduling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmScheduling_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmScheduling_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbclass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem חזורToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbclass;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstStudentsWwithOutPlacment;
        private System.Windows.Forms.Button button4;
    }
}