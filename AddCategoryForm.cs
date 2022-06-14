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
    public partial class AddCategoryForm : Form
    {

        public DataGridView dataGridView1;
        private List<ProductGroupsModel> AllCategories;

        public AddCategoryForm(DataGridView dataGridView)
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
                ProductGroupsModel productGroupsModel = new ProductGroupsModel();
                productGroupsModel.CatName = textBox1.Text.Trim();
                AddStoreResult result = AddCategory(productGroupsModel);


                DialogResult dialogResult = MessageBox.Show(this, result.Message, "رسالة نجاح", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.OK)
                {
                    this.FormClosing += AddStoreForm_FormClosing1;

                     GetAllCategories();
                    var columns = from t in AllCategories
                                  orderby t.CatName
                                  select new
                                  {
                                      CatID = t.CatID,
                                      CatName = t.CatName

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
        /// <returns>returns Task<ResultCategories></returns>
        private  AddStoreResult AddCategory(ProductGroupsModel productGroupsModel)
        {

            ProductGroupsRepository ProductGroupsRepository = new ProductGroupsRepository();
            AddStoreResult result = new AddStoreResult();

            if (ProductGroupsRepository.GroupsNameToValidate(productGroupsModel) == true)
            {
                result.Status = false;

                result.Message = "اسم المجموعة  مسجل بالفعل  من فضلك قم باختيار اسم جديد او يمكنك تعديل القديم ";


            }
            else
            {


                if (ProductGroupsRepository.AddGroup(productGroupsModel))
                {
                    result.Status = true;
                    result.Message = " تم اضافة المجموعة بنجاح يمكنك الان فحص القسم الخاص بالمجموعات واجراء جميع العمليات ";
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
        ///    this method will GetAllCategories avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All categories avaliable on the system</returns>
        private void GetAllCategories()
        {
            ProductGroupsRepository ProductGroupsRepository = new ProductGroupsRepository();

            IList<IEnumerable> Result = ProductGroupsRepository.GetAllGroups();
            if (Result != null)
            {
                if (Result[0].Cast<ProductGroupsModel>().ToList().Count() > 0)
                {
                    AllCategories = Result[0].Cast<ProductGroupsModel>().ToList();

                }
                else
                {

                    AllCategories = null;

                }
            }


        }


    }
}
