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
    public partial class AddStoreForm : Form
    {

        public DataGridView dataGridView1;
        private List<StoresModel> AllStores;

        public AddStoreForm(DataGridView dataGridView)
        {
            InitializeComponent();
            this.dataGridView1 = dataGridView;
        }

        private  void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "الحقل مطلوب");

                this.FormClosing += AddStoreForm_FormClosing;

            }

            else
            {
                StoresModel storesModel = new StoresModel();
                storesModel.StoreName = textBox1.Text.Trim();
                AddStoreResult result =  AddStore(storesModel);


                DialogResult dialogResult = MessageBox.Show(this, result.Message, "رسالة نجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.OK)
                {
                    this.FormClosing += AddStoreForm_FormClosing1;

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
            if (string.IsNullOrEmpty(errorProvider1.GetError(textBox1)))
            {
                this.FormClosing += AddStoreForm_FormClosing1;
            }
            else
            {
                this.FormClosing += AddStoreForm_FormClosing1;
            }
        }


        /// <summary>
        ///    this method will add new store to the system
        /// </summary>
        /// <param name="">no parameters required</param>
        /// <returns>returns Task<ResultStores></returns>
        private  AddStoreResult AddStore(StoresModel storesModel)
        {
            StoresRepository storesRepository = new StoresRepository();
            AddStoreResult result = new AddStoreResult();

            if (storesRepository.StoresNameToValidate(storesModel) == true)
            {
                result.Status = false;

                result.Message = "اسم المخزن مسجل بالفعل  من فضلك قم باختيار اسم جديد او يمكنك تعديل القديم ";


            }
            else
            {


                if (storesRepository.AddStore(storesModel))
                {
                    result.Status = true;
                    result.Message = " تم اضافة المخزن بنجاح يمكنك الان فحص القسم الخاص بالمخازن واجراء جميع العمليات";
                }
                else
                {
                    result.Status = false;
                    result.Message = "شئ ما خاطئ يرجى المحاولة مرة اخرى ";
                }

            }

            return result;


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


    }
}
