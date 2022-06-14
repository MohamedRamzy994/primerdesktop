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
using PREMIER.data;

namespace PREMIER
{
    public partial class CategoriesForm : Form
    {
        public static int selectedRowIndex;
        private List<ProductGroupsModel> AllCategories;
        private ProductGroupsModel SelectedCategory;

        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        protected  override void OnLoad(EventArgs e)
        {
               

                   GetAllCategories();


            var columns = from t in AllCategories
                          orderby t.CatName
                          select new
                          {
                              CatID = t.CatID,
                              CatName = t.CatName

                          };

            dataGridView1.DataSource = columns.ToList();
            dataGridView1.Columns[0].HeaderText = "رقم المجموعة";
            dataGridView1.Columns[1].HeaderText = "اسم المجموعة";
            dataGridView1.EnableHeadersVisualStyles = false;



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm(this.dataGridView1);
            addCategoryForm.ShowDialog();
        }

        private  void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "هل تريد حذف المجموعة ؟", "رسالة تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["CatID"].Value);
                    string cellValueName = Convert.ToString(selectedRow.Cells["CatName"].Value);

                    selectedRowIndex = Convert.ToInt32(cellValue);

                    SelectedCategory = new ProductGroupsModel()
                    {
                        CatID = selectedRowIndex,
                        CatName = cellValueName

                    };




                    AddStoreResult result = DeleteSelectedCategory(SelectedCategory);



                    if (result.Status)
                    {

                        DialogResult dialogResultConfirm = MessageBox.Show(this, result.Message, "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        if (dialogResultConfirm == DialogResult.OK)
                        {

                            GetAllCategories();
                            var columns = from t in AllCategories
                                          orderby t.CatName
                                          select new
                                          {
                                              CatID = t.CatID,
                                              CatName = t.CatName

                                          };

                            dataGridView1.DataSource = columns.ToList();
                            dataGridView1.Columns[0].HeaderText = "رقم المجموعة";
                            dataGridView1.Columns[1].HeaderText = "اسم المجموعة";
                            dataGridView1.EnableHeadersVisualStyles = false;





                        }





                    }

                }
            }
        }

        private void إضافةمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm(this.dataGridView1);
            addCategoryForm.ShowDialog();

        }

        private  void حذفمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "هل تريد حذف المجموعة ؟", "رسالة تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["CatID"].Value);
                    string cellValueName = Convert.ToString(selectedRow.Cells["CatName"].Value);

                    selectedRowIndex = Convert.ToInt32(cellValue);

                    SelectedCategory = new ProductGroupsModel()
                    {
                        CatID = selectedRowIndex,
                        CatName = cellValueName

                    };




                    AddStoreResult result = DeleteSelectedCategory(SelectedCategory);



                    if (result.Status)
                    {

                        DialogResult dialogResultConfirm = MessageBox.Show(this, result.Message, "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        if (dialogResultConfirm == DialogResult.OK)
                        {

                            GetAllCategories();
                            var columns = from t in AllCategories
                                          orderby t.CatName
                                          select new
                                          {
                                              CatID = t.CatID,
                                              CatName = t.CatName

                                          };

                            dataGridView1.DataSource = columns.ToList();
                            dataGridView1.Columns[0].HeaderText = "رقم المجموعة";
                            dataGridView1.Columns[1].HeaderText = "اسم المجموعة";
                            dataGridView1.EnableHeadersVisualStyles = false;





                        }





                    }

                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["CatID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                ProductGroupsModel storesModel = new ProductGroupsModel()
                {

                    CatID = selectedRowIndex,


                };
                EditCategoryForm editStoreForm = new EditCategoryForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }


        }

        private void تعديلمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["CatID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                ProductGroupsModel storesModel = new ProductGroupsModel()
                {

                    CatID = selectedRowIndex,


                };
                EditCategoryForm editStoreForm = new EditCategoryForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["CatID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                ProductGroupsModel storesModel = new ProductGroupsModel()
                {

                    CatID = selectedRowIndex,


                };
                EditCategoryForm editStoreForm = new EditCategoryForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {


                var columns = from t in AllCategories
                              where t.CatName.Contains(textBox1.Text.Trim().ToLower())
                              orderby t.CatName
                              select new
                              {
                                  CatID = t.CatID,
                                  CatName = t.CatName

                              };

                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المجموعة";
                dataGridView1.Columns[1].HeaderText = "اسم المجموعة";
                dataGridView1.EnableHeadersVisualStyles = false;






                label4.Text = columns.Count().ToString();




            }
            else
            {


                var columns = from t in AllCategories
                              orderby t.CatName
                              select new
                              {
                                  CatID = t.CatID,
                                  CatName = t.CatName

                              };

                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المجموعة";
                dataGridView1.Columns[1].HeaderText = "اسم المجموعة";
                dataGridView1.EnableHeadersVisualStyles = false;


                label4.Text = columns.Count().ToString();

            }



        }



        /// <summary>
        ///    this method will GetAllCategories avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All categories avaliable on the system</returns>
        private  void GetAllCategories()
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
        ///    this method will Delete  the selected Store from the datagridview
        /// </summary>
        /// <param name="StoreId">StoreId is required</param>
        /// <returns>returns Task<ResultCategories></returns>
        private  AddStoreResult DeleteSelectedCategory(ProductGroupsModel productGroupsModel)
        {
            ProductGroupsRepository ProductGroupsRepository = new ProductGroupsRepository();
            AddStoreResult result = new AddStoreResult();
            if (ProductGroupsRepository.DeleteGroup(productGroupsModel))
            {
                result.Status = true;
                result.Message = "تم حذف المجموعة بنجاح يمكنك التحقق من قسم المجموعات  الان ";
            }
            else
            {
                result.Status = false;
                result.Message = "شئ ما خاطئ يرجى المحاولة مرة اخرى ";
            }
            return result;




        }

    }


}
