using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{


    public class ListTransferKindInvoiceItemModel
    {
        public int ProductID { get; set; }
        public float Num { get; set; }
        public int UnitID { get; set; }
        public int ChangeNum { get; set; }

    }

    public class TransferKindsModel
    {

        public int StoreIDFrom { get; set; }
        public int StoreIDTo { get; set; }
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public int InvoiceID { get; set; }
        public List<ListTransferKindInvoiceItemModel> InvoiceItems { get; set; }

    }

    public class ListTransferKindModel
    {
        public int InvoiceID { get; set; }
        public string StoreName { get; set; }
        public string StoreTo { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }





    }
    public class ListTransferInvoiceItemsModel
    {
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string StoreName { get; set; }
        public string StoreTo { get; set; }
        public DateTime DateSubmit { get; set; }
        public string UserName { get; set; }    
        public float Num { get; set; }
        public int UnitID { get; set; }
        public int ChangeNum { get; set; }

    }
}
