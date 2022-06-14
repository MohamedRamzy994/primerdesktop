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
    public partial class EditCategoryForm : Form
    {

     
        public DataGridView dataGridView1;
        private List<ProductGroupsModel> AllCategories;
        private ProductGroupsModel SelectedCategory;

        public EditCategoryForm()
        {
                
        }
        public EditCategoryForm (ProductGroupsModel SelectedCategory, DataGridView dataGridView)
        {
            InitializeComponent();
            this.SelectedCategory = SelectedCategory;
            this.dataGridView1 = dataGridView;
        }
        protected  override void OnLoad(EventArgs e)
        {

             GetAllCategories();


            var columns = from t in AllCategories
                          where t.CatID == SelectedCategory.CatID
                          select new
                          {
                              CatID = t.CatID,
                              CatName = t.CatName

                          };
            textBoxedit.Text = columns.SingleOrDefault().CatName;

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

                ProductGroupsModel SelectedCategory = new ProductGroupsModel()
                {

                    CatID = this.SelectedCategory.CatID,
                    CatName = textBoxedit.Text.Trim()
                };

                EditCategory(SelectedCategory);

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



        /// <summary>
        ///    this method will add new store to the system
        /// </summary>
        /// <param name="">no parameters required</param>
        /// <returns>returns Task<ResultStores></returns>
        private AddStoreResult EditCategory(ProductGroupsModel SelectedCategory)
        {

            ProductGroupsRepository ProductGroupsRepository = new ProductGroupsRepository();
            AddStoreResult result = new AddStoreResult();
            if (ProductGroupsRepository.EditGroup(SelectedCategory))
            {
                result.Status = true;
                result.Message = "تمت عملية التعديل بنجاح يمكنك مراجعة  قسم المجموعات الان ";
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
