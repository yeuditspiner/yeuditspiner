using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DalPlacementStudent;
using Bll;
using System.Xml.Linq;
using System.Threading;

namespace UI
{
    public partial class DeskControl : UserControl
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        TablePlacement tablePlacement;
        Placementstudents placementstudents;
        public int line;
        public int coulnm;
        public bool isDone;
        ClassTbl cls;
        public   StudentTbl s1;
        public   StudentTbl s2;
        List<Constraints> constarints;
        public List<StudentTbl> Currentstudents;
        string str = " ";
        ListBox l;
        public string path;
        public DeskControl(int classid,int line,int coulmn,ListBox listBox, List<StudentTbl>students,List<Constraints> lst,string path)
        {
            InitializeComponent();
            isDone = false;
            errorProvider1.Clear();
            cls = new ClassTbl();
            this.cls.ClassID = classid;
            s1 = new StudentTbl();
            s2 = new StudentTbl();
            this.Currentstudents = students.ToList();
            this.constarints = lst;
            this.path = path;
            comboBox1.DataSource = this.Currentstudents.Select(x => x.FirstName.Trim() + " " + x.LastName.Trim()).ToList();
            comboBox2.DataSource = this.Currentstudents.Select(x => x.FirstName.Trim() + " " + x.LastName.Trim()).ToList();
            this.line = line;
            this.coulnm = coulmn;
            this.l = listBox;
            
        }

     
        private void DeskControl_Load(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            comboBox2.Text =" ";
            comboBox1.Text = "  ";
    
        }
       
        public bool  cheackChatter()
        {

            str = tablePlacement.CompatibilityTest();
            if (str == "Impossible" )
            {
                errorProvider1.SetError(this, "רמת פטפוט גבוהה");
                this.BackColor = Color.Red;
                return false;

            }
            if (str == "Possible")
            {
                this.BackColor = Color.Orange;
                this.BackColor = Color.Green;
                s1.Coulnm = this.coulnm;
                s1.Line = this.line;
                s2.Coulnm = this.coulnm;
                s2.Line = this.line;
                db.SaveChanges();
            }
            else
            {
                this.BackColor = Color.Green;
                s1.Coulnm = this.coulnm;
                s1.Line = this.line;
                s2.Coulnm = this.coulnm;
                s2.Line = this.line;
                db.SaveChanges();
                this.Currentstudents = db.StudentTbl.Where(x => x.ClassID == cls.ClassID && x.Line == 0 && x.Coulnm==0).ToList();
            }
                return true;
            
        }
        public void cheackCoinstarint(Control c)
        {
            if (!this.placementstudents.CheckConstraints(this.constarints))
            {
                errorProvider2.SetError(c, "התנגשות אילוץ");
            }
           
        }
            
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            s1 = db.StudentTbl.Where(x => (x.FirstName.Trim() + " " + x.LastName.Trim()).ToString() == comboBox1.SelectedItem).FirstOrDefault();
            this.placementstudents = new Placementstudents(s1);
            if (!MatchBetweenDeskAndStudent(placementstudents.student.StudentID))
                errorProvider1.SetError(comboBox1, "מיקום לא לבקשת התלמידה");
           cheackCoinstarint(comboBox1);
            
      


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            s2 = db.StudentTbl.Where(x => (x.FirstName.Trim() + " " + x.LastName.Trim()).ToString() == comboBox2.SelectedItem).FirstOrDefault();
            this.placementstudents = new Placementstudents(s2);
            if (!MatchBetweenDeskAndStudent(placementstudents.student.StudentID))
                errorProvider1.SetError(comboBox2, "מיקום לא לבקשת התלמידה");
               cheackCoinstarint(comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (comboBox1.Text == " " || comboBox2.Text == " ")
            {
                MessageBox.Show("בחרי 2 תלמידות לשיבוץ");
            }
            else
            {
                FrmScheduling.CheckedTables++;
                isDone = true;
                this.tablePlacement = new TablePlacement(this.s1, this.s2);
                str = this.tablePlacement.CompatibilityTest();
                switch (str)
                {
                    case "Exellent":
                        this.BackColor = Color.Green;
                        s1.Coulnm = this.coulnm;
                        s1.Line = this.line;
                        s2.Coulnm = this.coulnm;
                        s2.Line = this.line;
                        db.SaveChanges();
                        break;
                    case "Possible":
                        this.BackColor = Color.Orange;
                        break;
                    case "Impossible":
                        this.BackColor = Color.Red;
                        errorProvider1.SetError(this, "רמת פטפוט גבוהה");
                        break;
                    default:
                        break;
                }
            }

        }
        public override string ToString()
        {
            string str = " ";
            foreach (var item in this.constarints)
            {
                str += item.Name.ToString()+ ": "+ item.Value.ToString() + "\n";
            }
           
            return str;
        }
        private void DeskControl_MouseHover(object sender, EventArgs e)
        {

            toolTip1.SetToolTip(this, this.ToString());
            toolTip1.BackColor = Color.Blue;
        }
        public bool MatchBetweenDeskAndStudent(int studentid)
        {
           int listStudentInclass = db.StudentTbl.Where(x => x.StudentID == studentid && x.ClassID == cls.ClassID).Count();
            if (listStudentInclass == 0)
                return false;
            else
            {
                StudentTbl s = db.StudentTbl.Where(x => x.StudentID == studentid && x.ClassID == cls.ClassID).FirstOrDefault();
                this.placementstudents = new Placementstudents(s);
                string str1 = this.placementstudents.CheckLocation(this.line);
                if (str1 == "Impossible")
                    return false;
                return true;
            }

        }
        private void DeskControl_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

            string s = " ";
            int count = 0;
            var passibleStudent = db.StudentTbl.Where(x => x.ClassID == cls.ClassID).ToList();
           
            foreach (var item in passibleStudent)
            {
                if (MatchBetweenDeskAndStudent(item.StudentID) && this.placementstudents.CheckConstraints(this.constarints))
                {
                    s += item.FirstName.TrimEnd() + " " + item.LastName.TrimEnd() + "\n";
                    count++;
                }

            }
            s += " _______________ " + "\n" + count + ":סך הכל    " ;

            MessageBox.Show(s);
       
        }
        public void AddStudentToXml()
        {
             XmlDal.MapDalInstance.SavaInXml(this.line, this.coulnm, s1.FirstName, s1.LastName, s1.StudentID, s2.FirstName, s2.LastName, s2.StudentID);
     
        }
        public void DeleteStudentFroXml()
        {
            //xmldal = new XmlDal(path);
            XmlDal.MapDalInstance.DeleteStudentelement(this.line, this.coulnm, s1.FirstName, s1.LastName, s1.StudentID, s2.FirstName, s2.LastName, s2.StudentID);
        }
            

        private void button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            
        }

        private void DeskControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeskControl_StyleChanged(object sender, EventArgs e)
        {
           
        }

        private void DeskControl_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DeskControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void DeskControl_DragDrop(object sender, DragEventArgs e)
        {
        
        }

        private void comboBox1_DragDrop(object sender, DragEventArgs e)
        {
           
            StudentTbl dsd = (StudentTbl)e.Data.GetData(typeof(StudentTbl)) as StudentTbl ;
            (sender as ComboBox).SelectedItem = dsd.FirstName.Trim()+" "+dsd.LastName.Trim();

        }

        private void comboBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void comboBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void comboBox2_DragDrop(object sender, DragEventArgs e)
        {
            StudentTbl dsd = (StudentTbl)e.Data.GetData(typeof(StudentTbl)) as StudentTbl;
            (sender as ComboBox).SelectedItem = dsd.FirstName.Trim() + " " + dsd.LastName.Trim();
        }
    }
}
