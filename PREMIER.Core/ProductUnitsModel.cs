using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
   public class ProductUnitsModel
    {

        public int RelationID { get; set; }

        public int UnitID { get; set; }

        public float ChangeNum { get; set; }

        public string UnitName { get; set; }

    }


   public  class ProductUnitsCatModel
    {

        public int UnitCatID { get; set; }
        public string UnitCat { get; set; }

    }
}
