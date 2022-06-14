using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREMIER.core
{
    public class OpeningBalanceModel
    {              
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public float Num { get; set; }
        public int UnitID { get; set; }
        public decimal ChangeNum { get; set; }
        public int StoreID { get; set; }        
        public int UserID { get; set; }
        public DateTime DateSubmit { get; set; }
        public bool Existing { get; set; }
                   
    }
}
