namespace UI
{
    partial class FrmUpdateTypicalForStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateTypicalForStudent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.חזורToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudentName = new System.Windows.Forms.ComboBox();
            this.cmbTypicls = new System.Windows.Forms.ComboBox();
            this.lbltypical = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgStudents = new System.Windows.Forms.DataGridView();
            this.dgTypical = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTypical)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.חזורToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1717, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // חזורToolStripMenuItem
            // 
            this.חזורToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("חזורToolStripMenuItem.Image")));
            this.חזורToolStripMenuItem.Name = "חזורToolStripMenuItem";
            this.חזורToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.חזורToolStripMenuItem.Text = "חזור";
            this.חזורToolStripMenuItem.Click += new System.EventHandler(this.חזורToolStripMenuItem_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(1544, 72);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(136, 24);
            this.cmbClass.TabIndex = 1;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(1645, 52);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(44, 17);
            this.lblClassName.TabIndex = 2;
            this.lblClassName.Text = ":כיתה";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1628, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = ":תלמידה";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbStudentName
            // 
            this.cmbStudentName.FormattingEnabled = true;
            this.cmbStudentName.Location = new System.Drawing.Point(1553, 147);
            this.cmbStudentName.Name = "cmbStudentName";
            this.cmbStudentName.Size = new System.Drawing.Size(136, 24);
            this.cmbStudentName.TabIndex = 4;
            this.cmbStudentName.SelectedIndexChanged += new System.EventHandler(this.cmbStudentName_SelectedIndexChanged);
            // 
            // cmbTypicls
            // 
            this.cmbTypicls.FormattingEnabled = true;
            this.cmbTypicls.Location = new System.Drawing.Point(303, 200);
            this.cmbTypicls.Name = "cmbTypicls";
            this.cmbTypicls.Size = new System.Drawing.Size(137, 24);
            this.cmbTypicls.TabIndex = 5;
            // 
            // lbltypical
            // 
            this.lbltypical.AutoSize = true;
            this.lbltypical.Location = new System.Drawing.Point(402, 180);
            this.lbltypical.Name = "lbltypical";
            this.lbltypical.Size = new System.Drawing.Size(48, 17);
            this.lbltypical.TabIndex = 6;
            this.lbltypical.Text = ":אילוץ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(26, 194);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(209, 34);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "הוספת אילוץ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(27, 234);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(209, 34);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "מחיקת אילוץ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(27, 708);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(168, 23);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "המשך";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgStudents
            // 
            this.dgStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudents.Location = new System.Drawing.Point(827, 147);
            this.dgStudents.Name = "dgStudents";
            this.dgStudents.RowHeadersWidth = 51;
            this.dgStudents.RowTemplate.Height = 24;
            this.dgStudents.Size = new System.Drawing.Size(336, 522);
            this.dgStudents.TabIndex = 11;
            this.dgStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudents_CellContentClick);
            // 
            // dgTypical
            // 
            this.dgTypical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTypical.Location = new System.Drawing.Point(605, 147);
            this.dgTypical.Name = "dgTypical";
            this.dgTypical.RowHeadersWidth = 51;
            this.dgTypical.RowTemplate.Height = 24;
            this.dgTypical.Size = new System.Drawing.Size(202, 522);
            this.dgTypical.TabIndex = 12;
            this.dgTypical.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTypical_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(1175, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "<< בחרי תלמידה";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(751, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 39);
            this.label4.TabIndex = 15;
            this.label4.Text = "עדכון אילוצי תלמידה";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(649, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = ":אילוצים קיימים";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FrmUpdateTypicalForStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 891);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgTypical);
            this.Controls.Add(this.dgStudents);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbltypical);
            this.Controls.Add(this.cmbTypicls);
            this.Controls.Add(this.cmbStudentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmUpdateTypicalForStudent";
            this.Text = "FrmUpdateTypicalForStudent";
            this.Load += new System.EventHandler(this.FrmUpdateTypicalForStudent_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTypical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem חזורToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStudentName;
        private System.Windows.Forms.ComboBox cmbTypicls;
        private System.Windows.Forms.Label lbltypical;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dgTypical;
        private System.Windows.Forms.DataGridView dgStudents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}