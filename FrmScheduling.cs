using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bll;
using DalPlacementStudent;


namespace UI
{
    public partial class FrmScheduling : Form
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
         XmlDal xmlDal;
        Placementstudents placementstudents;
        public List<Constraints> Tableconstraints;
        List<DeskControl> deskControls;
        ListBox lst;
        public  static string path;
        ClassTbl c;
        public static  int CheckedTables;
        public  List<StudentTbl> students;
        public static FrmScheduling FrmSchedulingInstance { get; } = new FrmScheduling();



        private   FrmScheduling()
        {
            InitializeComponent();
            CheckedTables = 0;
            students = db.StudentTbl.Where(x => x.ClassID == CurrentCls.ClsDalInstance.Class.ClassID).ToList();
            c = db.ClassTbl.Where(x => x.ClassID == CurrentCls.ClsDalInstance.Class.ClassID).FirstOrDefault();
            lstStudentsWwithOutPlacment.Items.AddRange(db.StudentTbl.Where(x => x.ClassID == c.ClassID && x.Coulnm == 0 && x.Line == 0).ToArray());
            lstStudentsWwithOutPlacment.DisplayMember = "LastName".Trim();// +" "+"FirstName".Trim();
            deskControls = new List<DeskControl>();
            this.Controls.Add(lst);
            cmbStudent.Visible = false;
            button4.Visible = false;
            xmlDal = XmlDal.MapDalInstance;
            errorProvider1.Clear();
     
        }
        //public FrmScheduling(string cls)
        //{
          
        //    InitializeComponent();
        //    CheckedTables = 0;
        //    c = db.ClassTbl.Where(x => x.ClassNmae == cls).FirstOrDefault();
        //    lstStudentsWwithOutPlacment.Items.AddRange(db.StudentTbl.Where(x => x.ClassID == c.ClassID && x.Coulnm == 0 && x.Line == 0).ToArray());
        //    lstStudentsWwithOutPlacment.DisplayMember = "LastName".Trim();// +" "+"FirstName".Trim();
        //    this.students = new List<StudentTbl>();
        //    deskControls = new List<DeskControl>();
        //    this.Controls.Add(lst);
        //    cmbStudent.Visible = false;
        //    button4.Visible = false;

        //}

        private void FrmScheduling_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            DrawClass();

        }
        public void DrawClass()
        {
            int location1 = 10;
            int location2 = 101;
            //רשימת טורים בכיתה
            for (int i = 1; i <=xmlDal.CoulmnsLst().Count(); i++)
            {


                //עבור כל טור מס שולחנות שלו:
                for (int j = 1; j <= xmlDal.NumOfTableInCoulnm(i); j++)
                {
                    Tableconstraints = new List<Constraints>();
                    Tableconstraints = this.xmlDal.GetTableConstraint(j, i);
                    this.students = db.StudentTbl.Where(x => x.ClassID == CurrentCls.ClsDalInstance.Class.ClassID).ToList();
                    DeskControl d = new DeskControl(CurrentCls.ClsDalInstance.Class.ClassID, j, i, this.lst, this.students, this.Tableconstraints, path) { Location = new Point(location1, location2 + i) };
                    gbclass.Controls.Add(d);
                    deskControls.Add(d);

                    d.Show();
                    location2 += 150;
                }
                location2 = 101;
                location1 += 300;

            }
        }

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            FrmOpening f = FrmOpening.FrmOpeningInctance;
            
            f.Show();
        }

        private void desktopUserControl1_Load(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void desktopUserControl1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = db.StudentTbl.Where(x => x.ClassID ==c.ClassID).ToList();
            foreach (var item in lst)
            {
                item.Coulnm = 0;
                item.Line = 0;
                db.SaveChanges();
            }
            foreach (var item in this.deskControls)
            {
                item.DeleteStudentFroXml();
                item.BackColor = Color.MediumTurquoise;
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {

            if (CheckedTables >= deskControls.Count())
           {
                foreach (var item in this.deskControls)
                {
               // if (xmlDal.IsFind(item.line, item.coulnm))
                            item.AddStudentToXml();
                }
                this.Hide();
            }
           else
               errorProvider1.SetError(button2, "בצעי שיבוץ לכל השולחנות"+ CheckedTables + " / "+this.deskControls.Count()+"שולחנות משובצים" );
        }

        private void groupBox1_Enter_2(object sender, EventArgs e)
        {
            
        }
        public void reset()
        {
            foreach (var item in deskControls)
            {
                item.BackColor = Color.MediumTurquoise;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            cmbStudent.Visible = true;
            button4.Visible = true;
            var list = db.StudentTbl.Where(x => x.ClassID == c.ClassID && x.Coulnm == 0 && x.Line == 0).Select(x=>x.FirstName.Trim()+" "+x.LastName.Trim()).ToList();
            cmbStudent.DataSource = list.ToList();

        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();
            StudentTbl  student = db.StudentTbl.Where(x =>( x.FirstName.Trim() + " " + x.LastName.Trim()).ToString() == cmbStudent.SelectedItem ).FirstOrDefault();
            this.placementstudents = new Placementstudents(student);
            foreach (var item in deskControls)
            {

                string str = placementstudents.CheckLocation(item.line);
                if (str != "Impossible"  && this.placementstudents.CheckConstraints(this.Tableconstraints))
                {
                    item.BackColor = Color.Yellow;

                }
                
            }
          
        }

        private void lstStudent_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void gbclass_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lstStudent_DragLeave(object sender, EventArgs e)
        {

        }

        private void lstStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            
        }

        private void lstStudentsWwithOutPlacment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstStudentsWwithOutPlacment_MouseDown(object sender, MouseEventArgs e)
        {
            DataObject dataObject = new DataObject(typeof(StudentTbl).FullName, (sender as ListBox).SelectedItem);
           lstStudentsWwithOutPlacment .DoDragDrop(dataObject, DragDropEffects.Copy);
        }

        private void lstStudentsWwithOutPlacment_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lstStudentsWwithOutPlacment_DragLeave(object sender, EventArgs e)
        {

        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmScheduling_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in deskControls )
            {
                item.BackColor = Color.MediumTurquoise;
            }
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
