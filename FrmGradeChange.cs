using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DalPlacementStudent;

namespace UI
{
    public partial class FrmGradeChange : Form
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
       
        public string path;
        XmlDal xmlDal;
        public bool flagDeleteTableOrCoulnm = false;
        public List<int> numTableInrow;
        public int numCoulminclass=0;
       
        public bool flag { get; set; }
        public List<int> lst;
        public int [] numTablrInCoulnm;
        int[] arr; 

        public FrmGradeChange(string chang)
        {
            InitializeComponent();
            switch (chang)
            {
                case "צור כיתה":
                    panel2.Visible = true;
                    panel1.Visible = false;
                    panel2.Location = new Point(78, 3);
                    break;
                case @"\ שנה כיתה":
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel1.Location = new Point(78, 3);
                    break;
                default:
                    break;
            }
            
            flag = false;
            lblAddtableToculm.Visible = false;
            txtclassnName.Text = null;
            numTableInrow = new List<int>();
            pictureBox1.Visible = false;
            checkedListBox1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            comboBox1.DataSource = db.ClassTbl.Select(x => x.ClassNmae).ToList();
            comboBox1.SelectedItem = null;
            start();
           // xmlDal = XmlDal.MapDalInstance;
            lst = new List<int>();
           
            
        }
        private void lblToChang_Click(object sender, EventArgs e)
        {

        }

        private void FrmGradeChange_Load(object sender, EventArgs e)
        {
            
        }
        public void start()
        {
            string d = comboBox1.Text.ToString();
            var t = Directory.GetFiles(@"files\").Where(x => x.EndsWith(d.TrimEnd() + ".xml")).First();
            this.path = t.ToString();
            xmlDal = XmlDal.MapDalInstance;
            xmlDal.LoadXml(path);
            int c = xmlDal.NumOfCoulnms();
            lst = new List<int>();
            for (int i = 1; i <= c; i++)
            {
                lst.Add(i);
            }
            comboBox2.DataSource = lst.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            flagDeleteTableOrCoulnm = true;
        }

        private void labelcoulmn_Click(object sender, EventArgs e)
        {
            flagDeleteTableOrCoulnm = false;
        }

        private void labetables_Click(object sender, EventArgs e)
        {
            flagDeleteTableOrCoulnm = true;
            checkedListBox1.Visible = true;
            label3.Visible =true ;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        }
        public void appear()
        {
            
            label2.Visible = true;
            pictureBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
           
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                errorProvider1.SetError(comboBox1, "בחר כיתה");
            else
            {
                if (flagDeleteTableOrCoulnm)
                {
                    if (!flag)
                        errorProvider1.SetError(label3, "לא נבחרו אילוצים");
                    else
                    {
                        var list = checkedListBox1.Items;
                        int numTable = xmlDal.NumOfTableInCoulnm(Convert.ToInt32(comboBox2.SelectedItem));
                        if (numTable >= 4)
                            errorProvider1.SetError(label1, " אין מקום לשולחן נוסף בטור  " + Convert.ToInt32(comboBox2.SelectedItem));
                        else
                        {
                            xmlDal.craeteNewTable(numTable + 1, Convert.ToInt32(comboBox2.SelectedItem));
                            Constraints c;
                            int i = 0;
                            foreach (var item in list)
                            {

                                if (checkedListBox1.GetItemChecked(i++))
                                    c = new Constraints(item.ToString(), true);
                                else
                                    c = new Constraints(item.ToString(), false);
                                if (!flag)

                                    errorProvider1.SetError(checkedListBox1, "לא נבחרו אילוצים");
                                else
                                    xmlDal.AddConstraintToTable(c, numTable + 1, Convert.ToInt32(comboBox2.SelectedItem));
                            }
                            appear();
                        }
                    }
                }
                else
                {
                    start();
                    int numC = xmlDal.NumOfCoulnms();//מס הטורים בכיתה
                    if (numC >= 4)
                        errorProvider1.SetError(label1, "אין מקום בכיתה לטור נוסף");
                    else
                    {
                        xmlDal.CraeteNewCoulm(numC + 1);
                        MessageBox.Show("נוסף לכיתתך הטור ה" + Convert.ToInt32(numC + 1));
                        lst.Add(numC + 1);
                        comboBox2.DataSource = lst.ToList();
                        appear();
                    }
                }
            }
            label5.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                errorProvider1.SetError(comboBox1, "בחר כיתה");
            else
            {
                if (flagDeleteTableOrCoulnm)
                {
                    int tabletodelete = xmlDal.NumOfTableInCoulnm(Convert.ToInt32(comboBox2.SelectedItem));
                    xmlDal.DeletTable(tabletodelete, Convert.ToInt32(comboBox2.SelectedItem));
                    label2.Text = "השולחן"+"("+tabletodelete+","+ Convert.ToInt32(comboBox2.SelectedItem)+")" + "נמחק בהצלחה";

                }
                else
                {
                    int ctd = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                    int ntic = xmlDal.NumOfTableInCoulnm(ctd);
                    if (ntic > 0)
                    {
                        DialogResult r = MessageBox.Show("במחיקת הטור ימחקו גם שולחנתיו", "לידיעתך", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (DialogResult.OK == r)
                            xmlDal.DeleteCoulnm(ctd);
                    }
                    else
                        xmlDal.DeleteCoulnm(ctd);

                }
                appear();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(78, 3);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            start();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            start();
        }
        
        private void btnAddxmlClass_Click(object sender, EventArgs e)
        {
            if (txtclassnName.Text == "")
                errorProvider1.SetError(txtclassnName, "לא נבחרה כיתה");
            else
            {
                arr = new int[Convert.ToInt32(textBox1.Text)+1 ];
                int i = 1;
                foreach (var item in panel2.Controls)
                {
                    Type t = item.GetType();
                    switch (t.Name)
                    {
                        case "NumericUpDown":
                            arr[i++] = Convert.ToInt32((item as NumericUpDown).Value);
                            break;
                        default:
                            break;

                    }
                }
                ClassTbl c = new ClassTbl();
                if (txtclassnName.Text == " ")
                    errorProvider1.SetError(txtclassnName, "לא נבחרה כיתה");
                else
                {
                    c.ClassID = db.ClassTbl.Count() + 100;
                    c.ClassNmae = txtclassnName.Text;
                    db.ClassTbl.Add(c);
                    db.SaveChanges();
                    xmlDal.createNewXmlClass(Convert.ToInt32(textBox1.Text), arr,txtclassnName.Text);
                    label2.Text = "כיתה חדשה נוספה בהצלחה";
                    appear();
                    label6.Visible = true;
                }
            }
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cls = this.xmlDal.NumOfTableInCoulnm(Convert.ToInt32(comboBox2.SelectedItem));
            
            lst = new List<int>();
            for (int i = 1; i <= cls; i++)
            {
                lst.Add(i);
            }
            comboBox3.DataSource = lst.ToList();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Location = new Point(78, 3);
        }
        //הוספת שולחנות לטורים
        private void lblAddtableToculm_Click(object sender, EventArgs e)
        {
            this.numCoulminclass++;
            int y = 290;
            int size = Convert.ToInt32(textBox1.Text.ToString());
            for (int i = 1; i <=size; i++)
            {
                Label l = new Label() { Location = new Point(110, y + i ), Text =   "טור " + i  + ":" };
                NumericUpDown n = new NumericUpDown() { Location = new Point(200, y+i),Maximum=4,Minimum=1 };
                this.panel2.Controls.Add(n);
                this.panel2.Controls.Add(l);
                 l.Show();
                 n.Show();
                y += 28;
                

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          
            
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true ;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void lblnumTableIncouln_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblAddtableToculm.Visible = true;
        }
    }
}
