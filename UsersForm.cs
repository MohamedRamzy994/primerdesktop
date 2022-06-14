using PREMIER.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using PREMIER.data;

namespace PREMIER
{
    public partial class UsersForm : Form
    {
        private IEnumerable<UserModel> ListAllUsers;
        private UserModel SelectedUser;


        public static int selectedRowIndex;

        public UsersForm()
        {
            InitializeComponent();

        }

        private  void UsersForm_Load(object sender, EventArgs e)
        {
             GetAllUsers();
            var columns = from t in ListAllUsers
                          orderby t.UserName
                          select new
                          {
                              UserID = t.UserId,
                              UserName = t.UserName,
                              Status = t.Existing
                          };
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.DataSource = columns.ToList();
            dataGridView1.Columns[0].HeaderText = "رقم التعريف";
            dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
            dataGridView1.Columns[2].HeaderText = "الحالة";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.MdiParent.ActiveMdiChild != null)
            {
                this.MdiParent.ActiveMdiChild.Hide();
                AddUserForm addUserForm = new AddUserForm();
                addUserForm.MdiParent = this.ParentForm;
                addUserForm.Dock = DockStyle.Fill;
                addUserForm.Show();

            }
            else
            {
                AddUserForm addUserForm = new AddUserForm();
                addUserForm.MdiParent = this.ParentForm;
                addUserForm.Dock = DockStyle.Fill;
                addUserForm.Show();

            }

        }

        private  void pictureBox3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                GetSelectedUser(selectedRowIndex);


                DialogResult _result = MessageBox.Show(this, "هل تريد حذف المستخدم ؟", "رسالة تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
               
                if (_result == DialogResult.Yes)
                {

                  bool Result=  DeleteSelectedUser(SelectedUser);
                    if (Result ==  true)
                    {
                        string message = "تم حذف المستخدم بنجاح";
                        MessageBox.Show(this,message, "رسالة نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                         GetAllUsers();
                        var columns = from t in ListAllUsers
                                      orderby t.UserName
                                      select new
                                      {
                                          UserID = t.UserId,
                                          UserName = t.UserName,
                                          Status = t.Existing
                                      };
                        dataGridView1.EnableHeadersVisualStyles = false;
                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridView1.DataSource = columns.ToList();
                        dataGridView1.Columns[0].HeaderText = "رقم التعريف";
                        dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
                        dataGridView1.Columns[2].HeaderText = "الحالة";

                    }
                    else
                    {
                        string message = "شئ ما خاطئ يرجى المحاولة مرة أخرى";
                        MessageBox.Show(this, message, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                }

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.MdiParent.ActiveMdiChild != null)
            {
                this.MdiParent.ActiveMdiChild.Hide();
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);

                }
                editUserForm.Show();

            }
            else
            {
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);

                }
                editUserForm.Show();



            }



        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.MdiParent.ActiveMdiChild != null)
            {
                this.MdiParent.ActiveMdiChild.Hide();
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);

                }
                editUserForm.Show();

            }
            else
            {
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);
                }

                editUserForm.Show();

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MdiParent.ActiveMdiChild != null)
            {
                this.MdiParent.ActiveMdiChild.Hide();
                AddUserForm AddUserForm = new AddUserForm();
                AddUserForm.MdiParent = this.ParentForm;
                AddUserForm.Dock = DockStyle.Fill;
                AddUserForm.Show();

            }
            else
            {
                AddUserForm AddUserForm = new AddUserForm();
                AddUserForm.MdiParent = this.ParentForm;
                AddUserForm.Dock = DockStyle.Fill;
                AddUserForm.Show();

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MdiParent.ActiveMdiChild != null)
            {
                this.MdiParent.ActiveMdiChild.Hide();
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);

                }
                editUserForm.Show();

            }
            else
            {
                EditUserForm editUserForm = new EditUserForm();
                editUserForm.MdiParent = this.ParentForm;
                editUserForm.Dock = DockStyle.Fill;

                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                    selectedRowIndex = Convert.ToInt32(cellValue);
                }

                editUserForm.Show();

            }

        }

        private  void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["UserID"].Value);
                selectedRowIndex = Convert.ToInt32(cellValue);
                GetSelectedUser(selectedRowIndex);

                DialogResult _result = MessageBox.Show(this, "هل تريد حذف المستخدم ؟", "رسالة تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (_result == DialogResult.Yes)
                {

                    bool Result = DeleteSelectedUser(SelectedUser);
                    if (Result == true)
                    {
                        string message = "تم حذف المستخدم بنجاح";
                        MessageBox.Show(this, message, "رسالة نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                        GetAllUsers();
                        var columns = from t in ListAllUsers
                                      orderby t.UserName
                                      select new
                                      {
                                          UserID = t.UserId,
                                          UserName = t.UserName,
                                          Status = t.Existing
                                      };
                        dataGridView1.EnableHeadersVisualStyles = false;
                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Dubai", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        dataGridView1.DataSource = columns.ToList();
                        dataGridView1.Columns[0].HeaderText = "رقم التعريف";
                        dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
                        dataGridView1.Columns[2].HeaderText = "الحالة";

                    }
                    else
                    {
                        string message = "شئ ما خاطئ يرجى المحاولة مرة أخرى";
                        MessageBox.Show(this, message, "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                }

            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
               

                        var columns = from t in ListAllUsers
                                      where t.UserName.ToLower().Contains(e.KeyChar.ToString().ToLower())
                                      orderby t.UserName
                                      select new
                                      {
                                          UserID = t.UserId,
                                          UserName = t.UserName,
                                          Status = t.Existing
                                      };
                        label4.Text = columns.Count().ToString();

                        dataGridView1.DataSource = columns.ToList();
                        dataGridView1.Columns[0].HeaderText = "رقم التعريف";
                        dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
                        dataGridView1.Columns[2].HeaderText = "الحالة";


            }
            else
            {
              

                        var columns = from t in ListAllUsers
                                      orderby t.UserName
                                      select new
                                      {
                                          UserID = t.UserId,
                                          UserName = t.UserName,
                                          Status = t.Existing
                                      };

                        dataGridView1.DataSource = columns.ToList();
                        dataGridView1.Columns[0].HeaderText = "رقم التعريف";
                        dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
                        dataGridView1.Columns[2].HeaderText = "الحالة";


                  
            }
           

        }


        /// <summary>
        ///    this method will GetAllUsers avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All users avaliable on the system</returns>
        private  void GetAllUsers()
        {
            UserRepository userRepository = new UserRepository();
          
            IList<IEnumerable> AllUsers = userRepository.GetAllUser();
            if (AllUsers != null)
            {
                if (AllUsers[0].Cast<UserModel>().ToList().Count() > 0)
                {
                    ListAllUsers = AllUsers[0].Cast<UserModel>().ToList();
                   
                }
                else
                {

                    ListAllUsers = null;
                }
            }
        }

        /// <summary>
        ///    this method will Delete  the selected User from the datagridview
        /// </summary>
        /// <param name="UserId">userModel is required</param>
        /// <returns>returns Task<Result></returns>
        private  bool DeleteSelectedUser(UserModel userModel)
        {

            UserRepository userRepository = new UserRepository();
           
            if (userRepository.DeleteUser(userModel))
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

        /// <summary>
        ///    this method will GetAllUsers avaliable on the system
        /// </summary>
        /// <param name="">No Paramters required</param>
        /// <returns>returns List of All users avaliable on the system</returns>
        private void GetSelectedUser(int UserId)
        {
            UserRepository userRepository = new UserRepository();

            IList<IEnumerable> AllUsers = userRepository.GetAllUser();
            if (AllUsers != null)
            {
                if (AllUsers[0].Cast<UserModel>().ToList().Count() > 0)
                {
                    ListAllUsers = AllUsers[0].Cast<UserModel>().ToList();
                    SelectedUser = ListAllUsers.SingleOrDefault(x => x.UserId == UserId);
                }
                else
                {

                    SelectedUser = null;
                    ListAllUsers = null;
                }
            }
        }



    }

}
