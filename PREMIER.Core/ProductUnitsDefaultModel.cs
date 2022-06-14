using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductUnitsDefaultModel
    {
        public int RelationID { get; set; }
        public bool Buy_Or_Sale { get; set; }
        public int UnitCatID { get; set; }
        public int ProductID { get; set; }

        public string UnitCat { get; set; }
        public string UnitName { get; set; }

    }

    public class ProductSelectedUnitsModel
    {
        public int RelationID { get; set; }
        public int UnitID { get; set; }
        public int UnitCatID { get; set; }
        public int ChangeNum { get; set; }

        public string UnitName { get; set; }

    }



}
