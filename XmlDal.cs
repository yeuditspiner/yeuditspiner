using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace DalPlacementStudent
{
    public class XmlDal
    {
        public XElement currentClass;
        public XElement currentCoulm;
        public string  pathToLoad { get; set; }


        public string XmlPath { get; set; }

        public static XmlDal MapDalInstance { get; } = new XmlDal();
        public XmlDal()
        { }
        //טעינת קובץ הכיתה שהתקבל
        public void LoadXml(string pathToLoad)
        {
            if (pathToLoad == null)
                System.Windows.Forms.MessageBox.Show("הכנסי להגדרות ובחרי מפת כיתה");
                
            else
            {
                this.pathToLoad = pathToLoad;
                XDocument Class = XDocument.Load(pathToLoad);
                currentClass = Class.Root;
            }
        }
        //מחזירה את הטור הנוכחי
        public XElement GetCurrentCoulnm(int coulnm)
        {
            var currentcoulm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulnm)).FirstOrDefault();
            return currentCoulm;
        }
        //פעולה המקבלת מס טור ומחזירה האם קיים כזה טור בכיתה
        public bool IsFindCoulnm(int coulm)
        {
            var currentcoulm = GetCurrentCoulnm(coulm);
            if (currentcoulm == null)
                return false;
            return true;
        }
        public bool IsFind(int row,int coulm)
        
        {
            if (!IsFindCoulnm(coulm))
                return false;
            var currentcoulm = GetCurrentCoulnm(coulm);
               XElement table = currentcoulm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == Convert.ToInt32(row)).FirstOrDefault();
            if (table == null)
                return false;
            return true;
        }
        //פונקציה המחזירה את מס הטורים בכיתה הנוכחית
        public int NumOfCoulnms()
        {
            int c = currentClass.Descendants("Coulmn").Count();
            return c;
        }

        public XElement[] CoulmnsLst()
        {
           
                var coulmn = currentClass.Descendants("Coulmn").ToArray();
                return coulmn;
            
           
        }

       
        //מקבלת טור ומחזירה את מס השולחנות שלו
        public int NumOfTableInCoulnm(int coulmn)
        {
            //טור נוכחי
            var currentcoulm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulmn)).FirstOrDefault();
            if (currentcoulm !=null)
               return  currentcoulm.Descendants("Table").Count();
            return 0;
           
        }
        //מחזירה רשימת אילוצי שולחן
        public List<Constraints> GetTableConstraint(int row, int coulnm)
        {
            List < Constraints > Lstconstraints= new List<Constraints>();
            //טור נוכחי
            var correntCoulnm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulnm)).FirstOrDefault();
            //שולחן נוכחי
            var table = correntCoulnm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == row).ToList();
            var lstConstraint = table.Descendants("Constraint").ToList();
            var gf = lstConstraint.Attributes().ToList();
         
            foreach (var item in gf)
            {
                Constraints c = new Constraints(item.Name.ToString(),Convert.ToBoolean( item.Value));
                Lstconstraints.Add(c);
               
               
            }
            return Lstconstraints;


        }
    
     
        //XML  מקבלת 2 תלמידות ומס שולחן ומוסיפה אותם -שמירת קובץ ה 
        public void SavaInXml(int row,int coulm,string studen1FirstName,string student1LastName ,int studen1ID, string studen2FirstName, string student2LastName, int studen2ID)
        {
            if (studen1FirstName != null && studen2FirstName != null)
            {
                var correntCoulnm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == coulm).FirstOrDefault();
                var table = correntCoulnm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == row).FirstOrDefault();
                XElement studen1 = new XElement("Student1", new XAttribute("FirstName", studen1FirstName.Trim()), new XAttribute("LastName", student1LastName.Trim()), new XAttribute("Id", studen1ID));
                XElement studen2 = new XElement("Student2", new XAttribute("FirstName", studen2FirstName.Trim()), new XAttribute("LastName", student2LastName.Trim()), new XAttribute("Id", studen2ID));
                table.Add(studen1);
                table.Add(studen2);
                currentClass.Save(this.pathToLoad);
            }
            
        }
        ///מקבלת 2 תלמידות ומס שולחן ומוחקת אותם 

        public void DeleteStudentelement(int row, int coulm, string studen1FirstName, string student1LastName, int studen1ID, string studen2FirstName, string student2LastName, int studen2ID)
        {
         
            currentClass.Save(pathToLoad);
            var correntCoulnm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulm)).FirstOrDefault();
            var table = correntCoulnm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == row).FirstOrDefault();
            var s1 = table.Descendants("Student1").ToList();
            foreach (var item in s1 )
            {
                item.Remove();
                currentClass.Save(this.pathToLoad);
            }
            var s2 = table.Descendants("Student2").ToList();
            foreach (var item in s2)
            {
                item.Remove();
                currentClass.Save(this.pathToLoad);
            }
          
        }
        //יצירת טור חדש
        public void  CraeteNewCoulm(int coulm)
        {
            XElement coulmToAdd = new XElement("Coulmn", new XAttribute("num", coulm));
            this.currentClass.Add(coulmToAdd);
            this.currentClass.Save(this.pathToLoad);
    
        }
        //יצירת שולחן חדש
        public void craeteNewTable(int line,int coulnm)
        {
            this.currentCoulm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulnm)).FirstOrDefault();
            XElement tableToAdd = new XElement("Table", new XAttribute("line", line));
            this.currentCoulm.Add(tableToAdd);
            this.currentClass.Save(this.pathToLoad);

        }
        //הוספת אילוץ לשולחן
        public void AddConstraintToTable(Constraints c,int row,int coulm)
        {
            var correntCoulnm = GetCurrentCoulnm(coulm);
            var table = correntCoulnm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == row).FirstOrDefault();
            XElement constraintToAdd = new XElement("Constraint", new XAttribute(c.Name, c.Value));
            table.Add(constraintToAdd);
            this.currentClass.Save(this.pathToLoad);
        }
        //יצירת מפת כיתה חדשה
        public void CreatNewClass(string path,int coulm,int row,bool c1, bool c2, bool c3)
        {
            if (!IsFindCoulnm(coulm))
                CraeteNewCoulm(coulm);
            else
                this.currentCoulm = GetCurrentCoulnm(coulm);
            if (!IsFind(row, coulm))
            {
               
                XElement newTableToAdd = new XElement("Table", new XAttribute("line", row), new XElement("Constraint"), new XAttribute("isfirst", c1), new XElement("Constraint"), new XAttribute("isnearTheWindow", c2), new XElement("Constraint"), new XAttribute("isnearTheDoor", c3));
                this.currentCoulm.Add(newTableToAdd);
                currentClass.Save(this.pathToLoad);
            }
            System.Windows.Forms.MessageBox.Show("קיים כבר בכיתתך כזה שולחן"+ " "+"("+row+","+coulm+")");



        }
        //מחיקת טור
        public void DeleteCoulnm(int coulnm)
        {
            int c = NumOfTableInCoulnm(coulnm);
            {
                var cc = GetCurrentCoulnm(coulnm);
                if (cc != null)
                {
                    cc.Remove();
                    currentClass.Save(this.pathToLoad);
                }
            }

        }
        //מחיקת שולחן
        public void DeletTable(int row, int coulm)
        {

            int c = NumOfTableInCoulnm(coulm);
            if (c > 0)
            {
                var currentcoulm = currentClass.Descendants("Coulmn").Where(x => Convert.ToInt32(x.Attribute("num").Value) == Convert.ToInt32(coulm)).FirstOrDefault(); //GetCurrentCoulnm(coulm);
                var table = currentcoulm.Descendants("Table").Where(x => Convert.ToInt32(x.Attribute("line").Value) == row).FirstOrDefault();
                table.Remove();
                currentClass.Save(this.pathToLoad);
            }
            else
                System.Windows.Forms.MessageBox.Show("אין שולחנות למחוק");
        }
           //מקבלת מס טורים ומערך מס שולחנות בטורים ויוצרת מפת כיתה חדשה
        public void createNewXmlClass(int numCoulnm,int [] arrTables,string nameclass)
        {
            
            XElement newClass = new XElement("Class");
            XElement coulmToAdd;
            for (int i=1;i<numCoulnm+1;i++)
            {
                coulmToAdd = new XElement("Coulmn", new XAttribute("num",i));
                newClass.Add(coulmToAdd);
                for (int j =1; j <= arrTables[i]; j++)//יצירת שולחנות לכל טור
                {
                    XElement table = new XElement("Table", new XAttribute("line", j));
                    XElement constraintToAdd = new XElement("Constraint", new XAttribute("isfirst" ,"false"));
                    table.Add(constraintToAdd);
                    constraintToAdd = new XElement("Constraint", new XAttribute("isnearTheWindow", "false"));
                    table.Add(constraintToAdd);
                    constraintToAdd = new XElement("Constraint", new XAttribute("isnearTheDoor", "false"));
                    table.Add(constraintToAdd);
                    coulmToAdd.Add(table);

                }
            }
            

            XDocument doc = new XDocument();
            doc.Add(newClass);
            string path = @"files\" + (nameclass).ToString() + ".xml";
            doc.Save(path);

        }
        public void SaveXml()
        {
            currentClass.Save(this.pathToLoad);
            System.Windows.Forms.MessageBox.Show("השיבוץ נגמר בהצלחה");
           
            
           
        }
    }

}
