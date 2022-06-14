using PREMIER.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using PREMIER.data;

namespace PREMIER
{
    public partial class EditStoreForm : Form
    {

        public StoresModel StoresModel;
        public DataGridView dataGridView1;
        private List<StoresModel> AllStores;

        public EditStoreForm(StoresModel storesModel, DataGridView dataGridView)
        {
            InitializeComponent();
            this.StoresModel = storesModel;
            this.dataGridView1 = dataGridView;
        }
        protected  override void OnLoad(EventArgs e)
        {

             GetAllStores();


            var columns = from t in AllStores
                          where t.StoreID == StoresModel.StoreID
                          select new
                          {
                              StoreID = t.StoreID,
                              StoreName = t.StoreName

                          };
            textBoxedit.Text = columns.SingleOrDefault().StoreName;

        }



        private  void button2_ClickAsync(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxedit.Text))
            {
                errorProvider1.SetError(textBoxedit, "الحقل مطلوب");

                this.FormClosing += AddStoreForm_FormClosing;

            }
            else
            {

                StoresModel storesModel = new StoresModel()
                {

                    StoreID = this.StoresModel.StoreID,
                    StoreName = textBoxedit.Text.Trim()
                };

                 EditStore(storesModel);

                GetAllStores();
                var columns = from t in AllStores
                              orderby t.StoreName
                              select new
                              {
                                  StoreID = t.StoreID,
                                  StoreName = t.StoreName

                              };

                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المخزن";
                dataGridView1.Columns[1].HeaderText = "اسم المخزن";
                dataGridView1.EnableHeadersVisualStyles = false;




            }



        }

        private void AddStoreForm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void AddStoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(errorProvider1.GetError(textBoxedit)))
            {
                this.FormClosing += AddStoreForm_FormClosing1;
            }
            else
            {
                this.FormClosing += AddStoreForm_FormClosing1;
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
        ///    this method will add new store to the system
        /// </summary>
        /// <param name="">no parameters required</param>
        /// <returns>returns Task<ResultStores></returns>
        private AddStoreResult EditStore(StoresModel storesModel)
        {

            StoresRepository storesRepository = new StoresRepository();
            AddStoreResult result = new AddStoreResult();
            if (storesRepository.EditStore(storesModel))
            {
                result.Status = true;
                result.Message = "تمت عملية التعديل بنجاح يمكنك مراجعة  قسم المخازن الان ";
            }
            else
            {
                result.Status = false;
                result.Message = "من فضلك شئ  خاطئ حدث اثناء اجراء التعديل من فضلك حاول مرة اخرى ";
            }
            return result;


        }


    }
}
