using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
using DalPlacementStudent;

namespace UI
{
    public partial class FrmOpening : Form
    {
       

        public static FrmOpening FrmOpeningInctance { get; } = new FrmOpening();
        private FrmOpening()
        {
            InitializeComponent();
        }

        private void הגדרותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                FrmDefinitions frmDefinition = FrmDefinitions.frmDefinitionsInctance;
                frmDefinition.Show();
            }
            catch
            {

                MessageBox.Show("עלייך להכנס תחילה לטופס הגדרות");
            }


        }

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            this.Close();
        }

        private void עדכוןאילוץתלמידהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentCls.ClsDalInstance.Class != null)
            {
                FrmUpdateTypicalForStudent f = FrmUpdateTypicalForStudent.FrmUpdateTypicalForStudentInstance;
                f.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("ראשית הגדירי כיתה בטופס הגדרות");
            }

        }

        private void הוספתתלמידותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CurrentCls.ClsDalInstance.Class !=null)
            {
                FrmAddStudents frmAddStudent = FrmAddStudents.frmAddStudentsInstance;
                frmAddStudent.Show();
                this.Hide();
            }
           
            else
            {
                MessageBox.Show("ראשית הגדירי כיתה בטופס הגדרות");
            }
        }

        private void שיבוץתלמידותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentCls.ClsDalInstance.Class != null)
            {
                FrmScheduling f = FrmScheduling.FrmSchedulingInstance;
                f.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("ראשית הגדירי כיתה בטופס הגדרות");
            }


        }

        private void FrmOpening_Load(object sender, EventArgs e)
        {
            
        }

        private void שינוימראהכיתהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new FrmGradeChange(@"\ שנה כיתה");
            f.Show();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
