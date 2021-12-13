using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPlacementStudent
{
  public  class TableAndCoulm
    {
        public int coulm { get; set; }
        public int NumOfTableInCoulm { get; set; }
        public TableAndCoulm(int coulm,int numofcoulnm)
        {
            this.coulm = coulm;
            this.NumOfTableInCoulm = 0;
        }
    }
}
