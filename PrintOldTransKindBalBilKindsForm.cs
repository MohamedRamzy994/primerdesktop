using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PREMIER.core;
using PREMIER.data;

namespace PREMIER
{
    public partial class PrintOldTransKindBalBilKindsForm : Form
    {
        private int selectedKind;
        private string StoreFrom;
        private string StoreTo;
        private string UserName;
        private DateTime DateSubmit;



        private List<ListTransferInvoiceItemsModel> InvoiceItemsList;

        public  PrintOldTransKindBalBilKindsForm()
        {
            InitializeComponent();
            
        }

        public  PrintOldTransKindBalBilKindsForm(int InvoiceID, string storeFrom, string storeTo, string userName, DateTime dateSubmit)
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

          

            TextObject storeFrom = (TextObject)oldtransbalinvoice2.ReportDefinition.Sections["Section2"].ReportObjects["bindStoreFrom"];
            storeFrom.Text = StoreFrom;
            TextObject storeTo = (TextObject)oldtransbalinvoice2.ReportDefinition.Sections["Section2"].ReportObjects["bindStoreTo"];
            storeTo.Text = StoreTo;
            TextObject dateSubmit = (TextObject)oldtransbalinvoice2.ReportDefinition.Sections["Section2"].ReportObjects["bindDateSubmit"];
            dateSubmit.Text = DateSubmit.ToString();
            TextObject userName = (TextObject)oldtransbalinvoice2.ReportDefinition.Sections["Section2"].ReportObjects["bindUserName"];
            userName.Text = UserName;

            ParameterField InvoiceId = this.crystalReportViewer1.ParameterFieldInfo[0];
            ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
            parameterDiscreteValue.Value = selectedKind;
            InvoiceId.CurrentValues.Add(parameterDiscreteValue);




        }


    }
}
