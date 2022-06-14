using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PREMIER.core;
using PREMIER.data;

namespace PREMIER
{
    public partial class OldTransKindBalBilKindsForm : Form
    {
        private int selectedKind;
        private string StoreFrom;
        private string StoreTo;
        private string UserName;
        private DateTime DateSubmit;



        private List<ListTransferInvoiceItemsModel> InvoiceItemsList;

        public OldTransKindBalBilKindsForm()
        {
            InitializeComponent();
        }

        public OldTransKindBalBilKindsForm(int InvoiceID, string storeFrom, string storeTo, string userName, DateTime dateSubmit)
        {
            InitializeComponent();
            this.selectedKind = InvoiceID;
            this.StoreFrom = storeFrom;
            this.StoreTo = storeTo;
            this.UserName = userName;
            this.DateSubmit = dateSubmit;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private  void OldTransKindBalBilsForm_Load(object sender, EventArgs e)
        {
             GetTransferInvoiceItems(selectedKind);


            var Tcolumns = from t in InvoiceItemsList
                           orderby t.StoreName
                           select new
                           {
                               ProductID = t.ProductID,
                               ProductName = t.ProductName,
                               Num = t.Num.ToString("f"),
                               UnitName = t.UnitName


                           };

            dataGridView1.Columns[0].DataPropertyName = "ProductID";
            dataGridView1.Columns[1].DataPropertyName = "ProductName";
            dataGridView1.Columns[2].DataPropertyName = "Num";
            dataGridView1.Columns[3].DataPropertyName = "UnitName";

            dataGridView1.DataSource = Tcolumns.ToList();

            textBox2.Text = StoreFrom;
            textBox1.Text = UserName;
            textBox3.Text = StoreTo;
            textBox4.Text = DateSubmit.ToString();





        }

        
        private void button3_Click(object sender, EventArgs e)
        {

            this.MdiParent.ActiveMdiChild.Hide();

            PrintOldTransKindBalBilKindsForm printOldTransKindBalBilKindsForm = new PrintOldTransKindBalBilKindsForm(this.selectedKind,StoreFrom,this.StoreTo,this.UserName,this.DateSubmit);

            printOldTransKindBalBilKindsForm.MdiParent = this.MdiParent;
            printOldTransKindBalBilKindsForm.Dock = DockStyle.Fill;
            printOldTransKindBalBilKindsForm.Show();
          

            this.Hide();

        }


        /// <summary>
        ///    this method will GetTransferInvoiceItems avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All InvoiceKinds avaliable on the system</returns>
        private  void GetTransferInvoiceItems(int InvoiceID)
        {

            TransferKindsRepository transferKindsRepository = new TransferKindsRepository();
          
            IList<IEnumerable> Result = transferKindsRepository.GetTransferInvoiceItems(InvoiceID);
            if (Result != null)
            {
                if (Result[0].Cast<ListTransferInvoiceItemsModel>().ToList().Count() > 0)
                {
                    InvoiceItemsList = Result[0].Cast<ListTransferInvoiceItemsModel>().ToList();
               
                }
                else
                {
                    InvoiceItemsList = null;
                }
            }
        
        }

      
    }
}
