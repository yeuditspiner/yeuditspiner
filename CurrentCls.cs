using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPlacementStudent
{
  public  class CurrentCls
    {
        public ClassTbl  Class { get; set; }
        public static CurrentCls ClsDalInstance { get; } = new CurrentCls();
        private CurrentCls()
        {

        }
    }
}
