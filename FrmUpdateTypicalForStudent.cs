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
    public partial class FrmUpdateTypicalForStudent : Form
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        ClassTbl c;
        TypicalTbl t;
        StudentTbl s1 = new StudentTbl();
        TypicalToStudent_Tbl typical;
        public static FrmUpdateTypicalForStudent FrmUpdateTypicalForStudentInstance { get; } = new FrmUpdateTypicalForStudent();
        private  FrmUpdateTypicalForStudent()
        {
            InitializeComponent();
            dgTypical.Visible = false;
            dgStudents.Visible = false;
            label3.Visible = false;
            cmbTypicls.DataSource = db.TypicalTbl.Select(x => x.DetailTypical).ToList();
            c = new ClassTbl();
            
        }
        public FrmUpdateTypicalForStudent(FrmAddStudents f, string cls)
        {
            
        }

        private void FrmUpdateTypicalForStudent_Load(object sender, EventArgs e)
        {
            cmbStudentName.Visible = false;
            label1.Visible = false;
            dgStudents.Visible = true;
            cmbTypicls.DataSource = db.TypicalTbl.Select(x => x.DetailTypical).ToList();
            cmbClass.Text = CurrentCls.ClsDalInstance.Class.ClassNmae;
            cmbClass.Enabled = false;
            c = db.ClassTbl.Where(x => x.ClassNmae == cmbClass.Text).FirstOrDefault();
            dgStudents.DataSource = db.StudentTbl.Where(x => x.ClassID == c.ClassID).Select(x => new { שם_פרטי = x.FirstName, שם_משפחה = x.LastName, פטפוט = x.Chatter,שורה_לשיבןץ = x.AdviceableLine,שורה=x.Line, טור = x.Coulnm }).ToList();
        }

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddStudents f = FrmAddStudents.frmAddStudentsInstance;
            this.Hide();
            f.Show();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }
        public bool CreateFields(TypicalToStudent_Tbl t)
        {
            btnDelete.Visible = false;
            bool ok = true ;
            //string st = dgStudents.SelectedRows[0].Cells[0].Value.ToString();
          //  s1 = db.StudentTbl.Where(x => x.FirstName == st.ToString()).FirstOrDefault();
            TypicalTbl ty = new TypicalTbl();
            try
            {
                ty = db.TypicalTbl.Where(x => x.DetailTypical == cmbTypicls.SelectedItem.ToString()).FirstOrDefault();
            }
            catch
            {
                errorProvider1.SetError(cmbTypicls, "לא נבחר אילוץ");
                 ok = false;
            }
          
           
            try
            {
                t.StudentID = this.s1.StudentID;

            }
            catch
            {
                errorProvider1.SetError(dgStudents, "לא נבחרה תלמידה");
                ok = false;
            }
            try
            {
                t.TypicalID = ty.TypicalID;
            }
            catch
            {
                errorProvider1.SetError(cmbTypicls, "לא נבחר אילוץ");
                ok = false;
            }
            try
            {
                t.Status = true;
            }
            catch
            {
                errorProvider1.SetError(cmbTypicls, "בחר אילוץ");
                ok = false;
            }
            return ok;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            TypicalToStudent_Tbl t1 = new TypicalToStudent_Tbl();
            if (CreateFields(t1))
            {
                DialogResult r = MessageBox.Show("האם להוסיף אילוץ זה?", "הוספה אישור", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
      
                    t1.Status = true;
                    db.TypicalToStudent_Tbl.Add(t1);
                    db.SaveChanges();
                    MessageBox.Show(  "אילוץ זה נוסף בהצלחה ל" + s1.FirstName.Trim() + " " + s1.LastName.Trim());
                    btnDelete.Visible = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string st = dgStudents.SelectedRows[0].Cells[0].Value.ToString();
                s1 = db.StudentTbl.Where(x => x.FirstName == st.ToString()).FirstOrDefault();
                btnUpdate.Visible = false;
            }
            catch
            {
                errorProvider1.SetError(btnDelete, "לא נבחר אילוץ למחיקה");
            }
            try
            {
                string so = dgTypical.SelectedRows[0].Cells[0].Value.ToString();
                t = db.TypicalTbl.Where(x => x.DetailTypical == so.ToString()).FirstOrDefault();
                typical = db.TypicalToStudent_Tbl.Where(x => x.StudentID == s1.StudentID && x.TypicalID == t.TypicalID).FirstOrDefault();
            }
            catch
            {
                errorProvider1.SetError(cmbStudentName, "לא נבחרה תלמידה");
            }
            //אילוץ
            try
            {   
            }
            catch
            {
                errorProvider1.SetError(cmbTypicls, "לא נבחר אילוץ");
            }
            try
            {
              typical.Status = false;
              db.TypicalToStudent_Tbl.Remove(typical);
              db.SaveChanges();
              MessageBox.Show("אילוץ זה נמחק בהצלחה");
            }
            catch
            {
                errorProvider1.SetError(btnDelete, "לא נבחרו שדות");
            }
           
        }

        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FrmScheduling frm = FrmScheduling.FrmSchedulingInstance;
           // Form f = new FrmScheduling(c.ClassNmae);
            frm.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            TypicalToStudentTbl v = new TypicalToStudentTbl
            {
                StudentID = 3,
                TypicalID = 1,
                Status = true
            };
            db.TypicalToStudentTbl.Add(v);
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (dgStudents.SelectedRows.Count >= 1)
            {
                string st = dgStudents.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
                MessageBox.Show("אין תלמידות בכיתה זו");
        }

        private void dgTypical_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            dgTypical.Visible = true;
            label3.Visible = true;

            StudentTbl s1 = new StudentTbl();
            if (dgStudents.SelectedRows.Count >= 1)
            {
                //התלמידה הנוכחית
                string Ln = dgStudents.SelectedRows[0].Cells[1].Value.ToString();
                string Fn = dgStudents.SelectedRows[0].Cells[0].Value.ToString();
                this.s1 = db.StudentTbl.Where(x => x.LastName.Trim() == Ln.ToString() && x.FirstName.Trim() == Fn.ToString()).FirstOrDefault();
                try
                {
                    label3.Text = (" אילוצי  " + (this.s1.FirstName.Trim()) + " " + (this.s1.LastName.Trim())).Trim();
                    List<TypicalTbl> lst = new List<TypicalTbl>();
                    //רשימת  האילוצים של התלמידה הנוכחית
                    dgStudents.Visible = false;
                    var f = db.TypicalToStudent_Tbl.Where(x => x.StudentID == this.s1.StudentID && x.Status == true).ToList();
                    var g = db.TypicalToStudent_Tbl.Where(x => x.StudentID == this.s1.StudentID).Select(x => new { אילוץ = x.TypicalTbl.DetailTypical, status = x.Status }).ToList();
                    dgTypical.DataSource = g.ToList();
                }
                catch
                {
                    label3.Text = ":אילוצים";
                    errorProvider1.SetError(label2, "לא קיימים אילוצים לתלמידה זו");
                }

            }
            else
            {
                MessageBox.Show("אין תלמידות בכיתה זו");
               
            }
           


        }
    }
}
