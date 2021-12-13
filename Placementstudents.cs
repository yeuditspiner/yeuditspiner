
using DalPlacementStudent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll
{

    enum marks { Exellent, Possible, Impossible }
    public class Placementstudents
    {

        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        public StudentTbl student { get; set; }
        public Placementstudents() { 
              
        }
        //בדוק אילוצים
        public Placementstudents(StudentTbl s)
        {
            this.student = s;
        }
        public bool IsCointains(List<Constraints> constarints, string DetailTypical,bool yesOrNat)
        {
            
            foreach (var item in constarints)
            {
               
                if (item.Name == DetailTypical && Convert.ToBoolean(item.Value)==yesOrNat)
                    return true;
            }
            return false;
        }
        public bool CheckConstraints(List<Constraints> constarints)
        {
            var r = db.TypicalToStudent_Tbl.Where(x => x.StudentID ==this.student.StudentID).ToList();//רשימת אילוצי תלמידה
            foreach (var item in r)
            {
             
                string  id = (db.TypicalTbl.Where(x => x.TypicalID == item.TypicalID)).Select(x=>x.DetailTypical.Trim()).First();
                if (!IsCointains(constarints, id.Trim(), item.Status.Value))
                {
                    return false;
                }
               
            }
            return true;//אם הכל טוב 
        }

      
        //בדוק מיקום
        public string CheckLocation(int line)
        {
            if (this.student.AdviceableLine == line)
                return marks.Exellent.ToString();
            else
            if(Math.Abs((decimal)(this.student.AdviceableLine - line)) == 1)
             
            return marks.Possible.ToString();
            return marks.Impossible.ToString();
        }

    }
}
