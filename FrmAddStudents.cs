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
    public partial class FrmAddStudents : Form
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        public static FrmAddStudents frmAddStudentsInstance { get; } = new FrmAddStudents();
        ClassTbl c;

        //public FrmAddStudents(FrmDefinitions f, string cls)
        //{
        //    InitializeComponent();
        //    button2.Visible = false;
        //    comboBox1.Text = cls;
        //    c = db.ClassTbl.Where(x => x.ClassNmae == cls).FirstOrDefault();
        //    var v = db.ClassTbl.Where(x => x.ClassNmae == comboBox1.Text).FirstOrDefault();
        //    int b = db.StudentTbl.Where(x => x.ClassID == v.ClassID).Count();
        //    txtID.Text =( db.StudentTbl.Count() + 2).ToString();
        //    comboBox1.Enabled = false;
        //    txtID.ReadOnly = true;
        //    txtLine.Text = 0.ToString();
        //    txtColunm.Text = 0.ToString();
        //    txtColunm.ReadOnly = true;
        //    txtLine.ReadOnly = true;
        //}
        private  FrmAddStudents()
        {
            InitializeComponent();
            button2.Visible = false;
            
            comboBox1.Text =CurrentCls.ClsDalInstance.Class.ClassNmae;
            c = db.ClassTbl.Where(x => x.ClassNmae == comboBox1.Text).FirstOrDefault();
            txtID.Text = (db.StudentTbl.Count() + 2).ToString();
            button2.Visible = false;
            var v = db.ClassTbl.Where(x => x.ClassNmae == comboBox1.Text).FirstOrDefault();
            int b = db.StudentTbl.Where(x => x.ClassID == v.ClassID).Count();
            txtID.Text = (db.StudentTbl.Count() + 2).ToString();
            comboBox1.Enabled = false;
            txtID.ReadOnly = true;
            txtLine.Text = 0.ToString();
            txtColunm.Text = 0.ToString();
            txtColunm.ReadOnly = true;
            txtLine.ReadOnly = true;


        }

        public bool CreateFileds(StudentTbl s)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
            
                s.StudentID = Convert.ToInt32(txtID.Text);

            }
            catch
            {
                errorProvider1.SetError(txtID, "הכנס מספרים בלבד");
                ok = false;
            }

            try
            {
                s.FirstName = txtFname.Text.ToString();
            }
            catch
            {
                errorProvider1.SetError(txtFname, "הכנס תווים בלבד");
                ok = false;
            }
            try
            {
                s.LastName = txtLname.Text.ToString();
            }
            catch
            {
                errorProvider1.SetError(txtLname, "הכנס תווים בלבד");
                ok = false;
            }
            try
            {
                s.ClassID = c.ClassID;
            }
            catch
            {
                errorProvider1.SetError(comboBox1, "כיתה זו לא נמצאה");
                ok = false;
            }
            try
            {
                s.Chatter = Convert.ToInt32(numericUpDown1.Value);
            }
            catch
            {
                errorProvider1.SetError(numericUpDown1, "לא בטווח");
                ok = false;
            }
            try
            {
                s.AdviceableLine = Convert.ToInt32(txtAdviceLine.Text);
            }
            catch
            {
                errorProvider1.SetError(txtAdviceLine, "הכנס ערך מספרי בלבד");
                ok = false;
            }
            try
            {
                s.Coulnm = Convert.ToInt32(txtColunm.Text);
            }
            catch
            {
                errorProvider1.SetError(txtColunm, "הכנס ערך מספרי בלבד");
                ok = false;
            }
            try
            {
                s.Line = Convert.ToInt32(txtLine.Text);
            }
            catch
            {
                errorProvider1.SetError(txtLine, "הכנס ערך מספרי בלבד");
                ok = false;
            }
            return ok;

        }
        private void FrmAddStudents_Load(object sender, EventArgs e)
        {
            
        }
        public bool IsCointains(StudentTbl s)
        {
            foreach (var item in db.StudentTbl )
            {
                if (item.FirstName == s.FirstName && item.LastName == item.LastName && item.ClassID == s.ClassID)
                    return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StudentTbl s = new StudentTbl();
            if (CreateFileds(s))
            {
                DialogResult r = MessageBox.Show("את האם להוסיף?" + txtFname.Text + " " + txtLname.Text, "אישור הוספה ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (r == DialogResult.Yes )
                {
                    db.StudentTbl.Add(s);
                    db.SaveChanges();
                    MessageBox.Show(" התלמידה " + txtFname.Text + " " + txtLname.Text + " נוספה לכיתתך ");
                    button2.Visible = true;

                }
                else
                {
                    MessageBox.Show("התלמידה " + txtFname.Text + " " + txtLname.Text + "  קיימת בכיתתך ");
                   
                }
            }
            txtID.Text =( db.StudentTbl.Count() + 1).ToString();
           

        }

            

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDefinitions f = FrmDefinitions.frmDefinitionsInctance;
            this.Hide();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUpdateTypicalForStudent f = FrmUpdateTypicalForStudent.FrmUpdateTypicalForStudentInstance;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                txtID.Text = (db.StudentTbl.Count() + 2).ToString();
                txtFname.Text = " ";
                txtLname.Text = " ";
                txtColunm.Text = 0.ToString();
                txtLine.Text = 0.ToString();
                txtAdviceLine.Text = " ";

                    
                 
        }
    }
}
