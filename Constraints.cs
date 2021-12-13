using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPlacementStudent
{
   public  class Constraints
    {
     

        public string  Name { get; set; }
        public bool Value { get; set; }
        public Constraints(string name,bool value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Constraints() { }

      
    }
}
