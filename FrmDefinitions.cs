using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;
using System.IO;
using System.Windows.Forms;
using DalPlacementStudent;
using System.Xml.Linq;
using System.Threading;

namespace UI
{
    public partial class FrmDefinitions : Form
    {
        
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        string path=" ";
        XmlDal xmldal;
        CurrentCls clsDal;
       public static FrmDefinitions frmDefinitionsInctance { get; } = new FrmDefinitions();
        private FrmDefinitions()
        {
            InitializeComponent();
           
              cmbClassfiles.Items.AddRange(Directory.GetFiles(@"files").Where(x=>x.EndsWith("xml")).ToArray());
              cmbclassToSchudele.Items.AddRange(db.ClassTbl.Select(x => x.ClassNmae).ToArray());
              cmbclassToSchudele.DisplayMember = "ClassNmae";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clsDal = ClsDal.ClassDalInstance;
            //clsDal.Class = (ClassTbl)cmbclassToSchudele.SelectedItem;
        }

        private void FrmDefinitions_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(menuStrip1, "באפשרותך ליצור כיתה המתאימה לך או לשנות את מראה כיתתך");
         
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(cmbClassfiles.SelectedItem==null)
            {
                errorProvider1.SetError(cmbClassfiles, "לא נבחר קובץ כיתה");
            }
           else
            {
                clsDal = CurrentCls.ClsDalInstance;
                clsDal.Class = db.ClassTbl.Where(x => x.ClassNmae == cmbclassToSchudele.SelectedItem.ToString()).FirstOrDefault();
                FrmAddStudents frm = FrmAddStudents.frmAddStudentsInstance;
                xmldal= XmlDal.MapDalInstance;
                path = cmbClassfiles.SelectedItem.ToString();
                xmldal.LoadXml(path);
                frm.Show();
                this.Hide();
            }
        }

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOpening f = FrmOpening.FrmOpeningInctance;
           
            f.Show();
        }
        private void cmbClassfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
      
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
          
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new FrmGradeChange(linkLabel1.Text);
            f.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new FrmGradeChange(linkLabel2.Text);
            f.Show();
            this.Hide();
        }
    }
}
