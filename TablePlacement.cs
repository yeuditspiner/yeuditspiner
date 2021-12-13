
using DalPlacementStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;


namespace Bll
{
   public  class TablePlacement
    {
        YeuditTablePlaceMentEntities db = new YeuditTablePlaceMentEntities();
        public StudentTbl  s1 { get; set; }
        public StudentTbl  s2 { get; set; }
        public TypicalToStudent_Tbl t { get; set; }
       public TablePlacement(StudentTbl s1,StudentTbl s2)
        {
           this. s1 = s1;
           this. s2 = s2;
           t = new TypicalToStudent_Tbl();
        }


        public string CompatibilityTest()
        {
            if ((s1.Chatter + s2.Chatter) > 5 && (s1.Chatter + s2.Chatter <= 7))
                return marks.Possible.ToString();
            if (s1.Chatter + s2.Chatter < 5)
                return marks.Exellent.ToString();
            return marks.Impossible.ToString();

        }
    }
}
