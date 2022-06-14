using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    class ProductsModel
    {
    }
   public class ProductBasicModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CatID { get; set; }
        public float MinLimit { get; set; }
        public bool StopBuy { get; set; }
        public bool StopSale { get; set; }
        public bool PrintBarcode { get; set; }
        public float Price { get; set; }
        public float P_Price { get; set; }
        public float Discount { get; set; }
        public float MinSalePrice { get; set; }
        public string ProductCode { get; set; }



    }
    public class  ProductCodeModel{

        public int ProductID { get; set; }
        public string ProductCode { get; set; }
                              
    }

    public class ListProductModel {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CatID { get; set; }
        public float MinLimit { get; set; }
        public bool StopBuy { get; set; }
        public bool StopSale { get; set; }
        public bool PrintBarcode { get; set; }
        public float Price { get; set; }
        public float P_Price { get; set; }
        public float Discount { get; set; }
        public float MinSalePrice { get; set; }
        public string ProductCode { get; set; }
        public string CatName { get; set; }
        public float Stock { get; set; }



    }
}
