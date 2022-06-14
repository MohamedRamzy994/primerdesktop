using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class ProductSearchModel
    {

        public int StoreID { get; set; }
        public int CatID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public float PriceFrom { get; set; }
        public float PriceTo { get; set; }
        public int SupplierID { get; set; }
        public bool StopBuy { get; set; }
        public bool StopSale { get; set; }
        public float HasStock { get; set; }
        public float HasNoStock { get; set; }









    }
}
