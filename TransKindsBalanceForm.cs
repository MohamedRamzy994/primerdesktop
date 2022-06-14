using Newtonsoft.Json;
using PREMIER.core;
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
using System.Net.Http.Formatting;
using PREMIER.data;

namespace PREMIER
{
    public partial class TransKindsBalanceForm : Form
    {
        public static int selectedRowIndex;
        private List<StoresModel> AllStores;
        private List<ListProductModel> AllProducts;
        private List<ProductUnitsModel> AllProductsUnits;
        List<int> lsIDs = new List<int>();
    
     


        public TransKindsBalanceForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        protected  override void OnLoad(EventArgs e)
        {
             GetAllStores();


            var columns = from t in AllStores
                          orderby t.StoreName
                          select new
                          {
                              StoreID = t.StoreID,
                              StoreName = t.StoreName

                          };


            comboBox1.DataSource = columns.ToList();

            comboBox1.DisplayMember = "StoreName";
            comboBox1.ValueMember = "StoreID";


            comboBox2.DataSource = columns.ToList();

            comboBox2.DisplayMember = "StoreName";
            comboBox2.ValueMember = "StoreID";

            comboBox1.Text = "اختر  المخزن المحول منه";
            comboBox2.Text = "اختر  المخزن المحول اليه";
            panel3.Visible = false;

            dataGridView2.Dock = DockStyle.Fill;


            textBox1.Enabled = false;



        }



        private  void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            panel3.Visible = false;
            panel6.Visible = false;



            GetAllProducts();
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                var columns = from t in AllProducts
                              where t.ProductName.Contains(e.KeyChar)
                              orderby t.ProductName

                              select new
                              {
                                  ProductID = t.ProductID,
                                  ProductName = t.ProductName

                              };


                dataGridView1.Columns[0].DataPropertyName = "ProductID";
                dataGridView1.Columns[1].DataPropertyName = "ProductName";
                dataGridView1.DataSource = columns.ToList();
                panel4.Visible = false;
            }
            else
            {
                var columns = from t in AllProducts
                              orderby t.ProductName

                              select new
                              {
                                  ProductID = t.ProductID,
                                  ProductName = t.ProductName

                              };


                dataGridView1.Columns[0].DataPropertyName = "ProductID";
                dataGridView1.Columns[1].DataPropertyName = "ProductName";
                dataGridView1.DataSource = columns.ToList();
                panel4.Visible = false;
                dataGridView1.ClearSelection();
            }



        }


        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
            if (!panel3.Visible)
            {
                dataGridView2.Dock = DockStyle.Fill;

            }
            else
            {

                dataGridView2.Dock = DockStyle.Fill;

            }

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
        ///    this method will GetAllProducts avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All Productss avaliable on the system</returns>
        private  void GetAllProducts()
        {

            ProductRepository productRepository = new ProductRepository();
            
            IList<IEnumerable> Result = productRepository.GetAllProducts();
            if (Result != null)
            {
                if (Result[0].Cast<ListProductModel>().ToList().Count() > 0)
                {
                    AllProducts = Result[0].Cast<ListProductModel>().ToList();
                    
                }
                else
                {
                    AllProducts = null;
                }
            }
           
           
        }

        /// <summary>
        ///    this method will GetAllProductsUnits avaliable on the system
        /// </summary>
        /// <param name="ProductID">ProductID Paramter required</param>
        /// <returns>returns List of All Productss avaliable on the system</returns>
        private void GetAllProductsUnits(int ProductID)
        {


            TransferKindsRepository transferKindsRepository = new TransferKindsRepository();
           
            IList<IEnumerable> Result = transferKindsRepository.GetProductUnites(ProductID);
            if (Result != null)
            {
                if (Result[0].Cast<ProductUnitsModel>().ToList().Count() > 0)
                {
                    AllProductsUnits = Result[0].Cast<ProductUnitsModel>().ToList();
                
                }
                else
                {
                    AllProductsUnits = null;
                }
            }
          

        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            lsIDs.Clear();
            panel6.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.WaitForInputIdle();
            NativeWindow.FromHandle(p.MainWindowHandle);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count>0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                int ProductID = Convert.ToInt32(selectedRow.Cells[0].Value);
                dataGridView2.Rows.RemoveAt(selectedrowindex);
                lsIDs.Remove(ProductID);
                if (dataGridView2.Rows.Count==0)
                {

                    panel6.Visible = true;

                }


            }
        }

        private  void dataGridView1_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;


            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];


                int ProductID = Convert.ToInt32(selectedRow.Cells[0].Value);



                 GetAllProductsInStore(Convert.ToInt32(comboBox1.SelectedValue));
                GetAllProductsUnits(ProductID);

                var columns = from t in AllProducts
                              where t.ProductID == ProductID
                              orderby t.ProductName
                              select new
                              {
                                  ProductID = t.ProductID,
                                  ProductName = t.ProductName,
                                  Num = 1,
                                  ProductUnits = AllProductsUnits,
                                  Stock = t.Stock,
                                  UnitID = AllProductsUnits[0].UnitID

                              };


                if (dataGridView2.Columns[3].Name == "QuantityUnit")
                {
                    ((DataGridViewComboBoxColumn)dataGridView2.Columns[3]).DataSource = columns.SingleOrDefault().ProductUnits;
                    ((DataGridViewComboBoxColumn)dataGridView2.Columns[3]).DisplayMember = "UnitName";
                    ((DataGridViewComboBoxColumn)dataGridView2.Columns[3]).ValueMember = "UnitID";



                }


                if (dataGridView2.Rows.Count > 0)
                {
                    if (lsIDs.Contains(ProductID))
                    {

                        MessageBox.Show(this, "قم باختيار صنف أخر لقد اخترت هذا الصنف بالفعل ", "رسالة تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        DataGridViewRow dataGridViewRow = new DataGridViewRow();
                        dataGridViewRow.CreateCells(dataGridView2);
                        dataGridViewRow.SetValues(
                                   columns.SingleOrDefault().ProductID,
                              columns.SingleOrDefault().ProductName,
                              columns.SingleOrDefault().Num.ToString("f"),
                              columns.SingleOrDefault().UnitID,
                              columns.SingleOrDefault().Stock.ToString("f")
                            );


                        dataGridView2.Rows.Add(dataGridViewRow);

                        lsIDs.Add(ProductID);

                    }








                }
                else
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(dataGridView2);
                    dataGridViewRow.SetValues(
                               columns.SingleOrDefault().ProductID,
                          columns.SingleOrDefault().ProductName,
                          columns.SingleOrDefault().Num.ToString("f"),
                          columns.SingleOrDefault().UnitID,
                          columns.SingleOrDefault().Stock.ToString("f")
                        );


                    dataGridView2.Rows.Add(dataGridViewRow);
                    lsIDs.Add(ProductID);



                }






            }

        }


        /// <summary>
        ///    this method will GetAllProductsInStore avaliable on the system
        /// </summary>
        /// <param name="StoreID">StoreID Paramters required</param>
        /// <returns>returns List of All ProductsInStore avaliable on the system</returns>
        private  void GetAllProductsInStore(int StoreID)
        {

            try
            {
                ProductRepository productRepository = new ProductRepository();
                
                IList<IEnumerable> Result = productRepository.SearchProductsByStore(StoreID);
                if (Result != null)
                {
                    if (Result[0].Cast<ListProductModel>().ToList().Count() > 0)
                    {
                        AllProducts = Result[0].Cast<ListProductModel>().ToList();
                     
                    }
                    else
                    {
                        AllProducts = null;
                    }
                }
            

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        private  void pictureBox2_Click(object sender, EventArgs e)
        {

            //if (Convert.ToInt32(comboBox1.SelectedValue)== Convert.ToInt32(comboBox2.SelectedValue))
            //{


            //    MessageBox.Show(this, "من فضلك لا يمكن نقل هذه الاصناف الى نفس المخزن", "رسالة تحذير", MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading);




            //}
            //else
            //{

              
            //    List<ListTransferKindInvoiceItemModel> listTransferKindInvoiceItemModels = new List<ListTransferKindInvoiceItemModel>();
            //    foreach (DataGridViewRow item in dataGridView2.Rows)
            //    {

            //        ListTransferKindInvoiceItemModel listTransferProductModel = new ListTransferKindInvoiceItemModel
            //        {
            //            ProductID = Convert.ToInt32(item.Cells[0].Value),
            //            Num=Convert.ToSingle(item.Cells[2].Value),
            //            UnitID = Convert.ToInt32(item.Cells[3].Value),
            //            ChangeNum=(int) AllProductsUnits.Where(x=>x.UnitID == Convert.ToInt32(item.Cells[3].Value)).SingleOrDefault().ChangeNum




            //        };                     
            //        listTransferKindInvoiceItemModels.Add(listTransferProductModel);

            //    }
            //    TransferKindsModel transferKindsModel = new TransferKindsModel();
            //    transferKindsModel.StoreIDFrom = Convert.ToInt32(comboBox1.SelectedValue);
            //    transferKindsModel.StoreIDTo = Convert.ToInt32(comboBox2.SelectedValue);
            //    transferKindsModel.UserID = CurrentUserConfigurations._authenticatedUserInfo.UserId;
            //    transferKindsModel.DateSubmit = DateTime.Now;
            //    transferKindsModel.InvoiceID = 0;


            //    transferKindsModel.InvoiceItems = listTransferKindInvoiceItemModels;

            



            //    ResultTransfer resultTransfer=  await SaveProductTransferInvoice(transferKindsModel);

            //    if (resultTransfer.Status)
            //    {
                  
            //        MessageBox.Show(this, resultTransfer.Message, "رسالة نجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);


            //        if (this.MdiParent.ActiveMdiChild != null)
            //        {
            //            this.MdiParent.ActiveMdiChild.Hide();
                        
                        
                        
                        
            //            TransKindsBalanceForm transKindsBalanceForm = new TransKindsBalanceForm();
            //            transKindsBalanceForm.MdiParent = this.MdiParent;
            //            transKindsBalanceForm.Dock = DockStyle.Fill;
            //            transKindsBalanceForm.Show();
            //            this.Close();

            //        }
            //        else
            //        {

            //            TransKindsBalanceForm transKindsBalanceForm = new TransKindsBalanceForm();
            //            transKindsBalanceForm.MdiParent = this.MdiParent;
            //            transKindsBalanceForm.Dock = DockStyle.Fill;
            //            transKindsBalanceForm.Show();

            //        }



                 
                  

            //    }
            //    else
            //    {
            //        MessageBox.Show(this, resultTransfer.Message, "رسالةنجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            //    }




            //}

        }

        /// <summary>
        ///    this method will SaveProductTransferInvoice avaliable on the system
        /// </summary>
        /// <param name="TransferKindsModel">TransferKindsModel Paramter required</param>
        /// <returns>returns ResultTransfer avaliable on the system</returns>
        //private async Task<ResultTransfer> SaveProductTransferInvoice(TransferKindsModel transferKindsModel)
        //{

        //    var client = new System.Net.Http.HttpClient()
        //    {
        //        BaseAddress = new Uri(CurrentUserConfigurations._baseWebApiUri) 
        //    };
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response;
        //    //var Content = new StringContent(JsonConvert.SerializeObject(transferKindsModel), Encoding.UTF8, "application/json");

        //    response = await client.PostAsJsonAsync("api/TransferKindsApi/AddTransferStock", transferKindsModel);
        //        ResultTransfer result = await response.Content.ReadAsAsync<ResultTransfer>();

        //        if (response.IsSuccessStatusCode)
        //        {

                  
        //            return result;
        //        }
        //        else
        //        {


        //            return result;
        //        }




           

        //}

    }
}
