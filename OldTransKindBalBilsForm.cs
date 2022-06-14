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
    public partial class OldTransKindBalBilsForm : Form
    {
        private List<StoresModel> AllStores;
        private List<ListTransferKindModel> AllInvoices;


        public OldTransKindBalBilsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private  void OldTransKindBalBilsForm_Load(object sender, EventArgs e)
        {
             GetAllStores();
             GetAllTransKindBalanceInvoices();


            var columns = from t in AllStores
                          orderby t.StoreName
                          select new
                          {
                              StoreID = t.StoreID,
                              StoreName = t.StoreName

                          };
            var Tcolumns = from t in AllInvoices
                           orderby t.StoreName
                           select t;



            comboBox1.DataSource = columns.ToList();

            comboBox1.DisplayMember = "StoreName";
            comboBox1.ValueMember = "StoreID";


            comboBox2.DataSource = columns.ToList();

            comboBox2.DisplayMember = "StoreName";
            comboBox2.ValueMember = "StoreID";

            comboBox1.Text = "اختر  المخزن المحول منه";
            comboBox2.Text = "اختر  المخزن المحول اليه";


            dataGridView1.DataSource = Tcolumns.ToList();
            dataGridView1.Columns[0].HeaderText = "الكود";
            dataGridView1.Columns[1].HeaderText = "المخزن من";
            dataGridView1.Columns[2].HeaderText = "المخزن الى ";
            dataGridView1.Columns[3].HeaderText = "التاريخ";
            dataGridView1.Columns[4].HeaderText = "المستخدم";



        }

        private void button2_Click(object sender, EventArgs e)
        {

            GetAllTransKindBalanceInvoices();
            string storeName=  comboBox1.GetItemText(comboBox1.SelectedItem);
            string storeTo = comboBox2.GetItemText(comboBox2.SelectedItem);
            string userName = textBox1.Text.Trim();
            DateTime dateTimeFrom = dateTimePicker1.Value;
            DateTime dateTimeTo= dateTimePicker2.Value;

        


            var Tcolumns = from t in AllInvoices
                           where( t.StoreName == storeName ||t.StoreTo == storeTo || t.UserName==userName)
                           || (t.DateSubmit>= dateTimeFrom && t.DateSubmit<=dateTimeTo  )
                           orderby t.StoreName
                           select t;



            dataGridView1.DataSource = Tcolumns.ToList();


        }


        /// <summary>
        ///    this method will GetAllStores avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All stores avaliable on the system</returns>
        private void GetAllStores()
        {

            StoresRepository storesRepository = new StoresRepository();

            IList<IEnumerable> Result = storesRepository.GetAllStores();
            if (Result != null)
            {
                if (Result[0].Cast<StoresModel>().ToList().Count() > 0)
                {
                    this.AllStores = Result[0].Cast<StoresModel>().ToList();

                }
                else
                {
                    this.AllStores = null;
                }
            }
        }


        /// <summary>
        ///    this method will GetAllStores avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All stores avaliable on the system</returns>
        private void GetAllTransKindBalanceInvoices()
        {

            TransferKindsRepository transferKindsRepository = new TransferKindsRepository();
           
            IList<IEnumerable> Result = transferKindsRepository.GetAllTransferKindInvoices();
            if (Result != null)
            {
                if (Result[0].Cast<ListTransferKindModel>().ToList().Count() > 0)
                {
                  AllInvoices = Result[0].Cast<ListTransferKindModel>().ToList();
                  
                }
                else
                {
                    AllInvoices = null;
                }
            }
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count>0)
            {

                int index = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[index];

            

                if (this.MdiParent.ActiveMdiChild!=null)
                {


                    OldTransKindBalBilKindsForm oldTransKindBalBilKindsForm = new OldTransKindBalBilKindsForm(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToString(selectedRow.Cells[1].Value),
                        Convert.ToString(selectedRow.Cells[2].Value), Convert.ToString(selectedRow.Cells[4].Value), Convert.ToDateTime(selectedRow.Cells[3].Value));


                    this.MdiParent.ActiveMdiChild.Hide();
                    oldTransKindBalBilKindsForm.MdiParent = this.MdiParent;
                    oldTransKindBalBilKindsForm.Dock = DockStyle.Fill;
                    oldTransKindBalBilKindsForm.Show();






                }
                else
                {
                    OldTransKindBalBilKindsForm oldTransKindBalBilKindsForm = new OldTransKindBalBilKindsForm(Convert.ToInt32(selectedRow.Cells[0].Value), Convert.ToString(selectedRow.Cells[1].Value),
                      Convert.ToString(selectedRow.Cells[2].Value), Convert.ToString(selectedRow.Cells[4].Value), Convert.ToDateTime(selectedRow.Cells[3].Value));



                    this.MdiParent.ActiveMdiChild.Hide();
                    oldTransKindBalBilKindsForm.MdiParent = this.MdiParent;
                    oldTransKindBalBilKindsForm.Dock = DockStyle.Fill;
                    oldTransKindBalBilKindsForm.Show();
                }

            }
        }
    }
}
