using PREMIER.core;
using PREMIER.data;
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

namespace PREMIER
{
    public partial class StoresForm : Form
    {
        public static int selectedRowIndex;
        private List<StoresModel> AllStores;
        private StoresModel SelectedStore;

        public StoresForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        protected override void OnLoad(EventArgs e)
        {


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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddStoreForm addStoreForm = new AddStoreForm(this.dataGridView1);
            addStoreForm.ShowDialog();
        }

        private  void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "هل تريد حذف المحزن ؟", "رسالة تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["StoreID"].Value);
                    string cellValueName = Convert.ToString(selectedRow.Cells["StoreName"].Value);

                    selectedRowIndex = Convert.ToInt32(cellValue);

                    GetSelectedStore(selectedRowIndex);



                    AddStoreResult result =  DeleteSelectedStore(SelectedStore);



                    if (result.Status)
                    {

                        DialogResult dialogResultConfirm = MessageBox.Show(this, result.Message, "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        if (dialogResultConfirm == DialogResult.OK)
                        {

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
            }
        }

        private void إضافةمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStoreForm addStoreForm = new AddStoreForm(this.dataGridView1);
            addStoreForm.ShowDialog();

        }

        private  void حذفمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "هل تريد حذف المحزن ؟", "رسالة تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["StoreID"].Value);
                    string cellValueName = Convert.ToString(selectedRow.Cells["StoreName"].Value);

                    selectedRowIndex = Convert.ToInt32(cellValue);

                    GetSelectedStore(selectedRowIndex);


                    AddStoreResult result =  DeleteSelectedStore(SelectedStore);



                    if (result.Status)
                    {

                        DialogResult dialogResultConfirm = MessageBox.Show(this, result.Message, "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        if (dialogResultConfirm == DialogResult.OK)
                        {

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
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["StoreID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                StoresModel storesModel = new StoresModel() {

                    StoreID = selectedRowIndex,


                };
                EditStoreForm editStoreForm = new EditStoreForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }




        }

        private void تعديلمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["StoreID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                StoresModel storesModel = new StoresModel()
                {

                    StoreID = selectedRowIndex,


                };
                EditStoreForm editStoreForm = new EditStoreForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["StoreID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                StoresModel storesModel = new StoresModel()
                {

                    StoreID = selectedRowIndex,


                };
                EditStoreForm editStoreForm = new EditStoreForm(storesModel, this.dataGridView1);
                editStoreForm.ShowDialog();



            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {


                var columns = from t in AllStores
                              where t.StoreName.ToLower().Contains(e.KeyChar.ToString().ToLower())
                              orderby t.StoreName
                              select new
                              {
                                  StoreID = t.StoreID,
                                  StoreName = t.StoreName

                              };
                label4.Text = columns.Count().ToString();

                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المخزن";
                dataGridView1.Columns[1].HeaderText = "اسم المخزن";
                dataGridView1.EnableHeadersVisualStyles = false;












            }
            else
            {


                var columns = from t in AllStores
                              orderby t.StoreName
                              select new
                              {
                                  StoreID = t.StoreID,
                                  StoreName = t.StoreName

                              };
                label4.Text = columns.Count().ToString();

                dataGridView1.DataSource = columns.ToList();
                dataGridView1.Columns[0].HeaderText = "رقم المخزن";
                dataGridView1.Columns[1].HeaderText = "اسم المخزن";
                dataGridView1.EnableHeadersVisualStyles = false;





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
        ///    this method will Delete  the selected Store from the datagridview
        /// </summary>
        /// <param name="StoreId">StoreId is required</param>
        /// <returns>returns Task<ResultStores></returns>
        private AddStoreResult DeleteSelectedStore(StoresModel storesModel)
        {
            StoresRepository storesRepository = new StoresRepository();
            AddStoreResult result = new AddStoreResult();
            if (storesRepository.DeleteStore(storesModel))
            {
                result.Status = true;
                result.Message = "تم حذف المخزن بنجاح يمكنك التحقق من قسم المخازن  الان ";
            }
            else
            {
                result.Status = false;
                result.Message = "شئ ما خاطئ يرجى المحاولة مرة اخرى ";
            }
            return result;
        }



        private void GetSelectedStore(int storeId)
        {

            StoresRepository storesRepository = new StoresRepository();

            IList<IEnumerable> Result = storesRepository.GetAllStores();
            if (Result != null)
            {
                if (Result[0].Cast<StoresModel>().ToList().Count() > 0)
                {
                    this.AllStores = Result[0].Cast<StoresModel>().ToList();
                    this.SelectedStore = AllStores.SingleOrDefault(x=>x.StoreID == storeId);

                }
                else
                {
                    this.AllStores = null;
                    this.SelectedStore = null;
                }
            }
        }


    }
    public class AddStoreResult {

        public bool Status { get; set; }
        public string Message { get; set; }

    }
}
