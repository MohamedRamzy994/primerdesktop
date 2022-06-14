using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductsUnitsSupplierModel
    {


        public int RelationID11 { get; set; }
        public int RelationID12 { get; set; }
        public int RelationID13 { get; set; }

        public int UnitCat11 { get; set; }
        public int UnitCat12 { get; set; }
        public int UnitCat13 { get; set; }


        public int Unit11 { get; set; }
        public int Unit12 { get; set; }
        public int Unit13 { get; set; }

        public int ProductID { get; set; }

        public int ChangeNum12 { get; set; }
        public int ChangeNum13 { get; set; }

        public int UnitBuy { get; set; }
        public int UnitSale { get; set; }

        public int StoreId { get; set; }

        public int UnitId { get; set; }
        public int UnitCatId { get; set; }
        public int OpeningNum { get; set; }
        public int UserId { get; set; }

        public List<SupplierModel> ProductSuppliers { get; set; }

        public List<int> SelectedProductSuppliers { get; set; }







    }
}
