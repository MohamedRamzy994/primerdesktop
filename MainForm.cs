using PREMIER.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREMIER
{
    public partial class MainForm : Form
    {

       

        public MainForm()
        {
            InitializeComponent();
        
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // #1
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.WhiteSmoke;
                    
                    // 4#
                    break;
                }
            }

            toolStripStatusLabel4.Text = CurrentUserConfigurations._authenticatedUserInfo.LoginName;




        }
        protected override void OnClosing(CancelEventArgs e)
        {

            if (MessageBox.Show("متأكد أنك تريد غلق البرنامج ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("متأكد أنك تريد غلق البرنامج ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                if (MessageBox.Show("متأكد أنك تريد غلق البرنامج ؟", "رسالة تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    Application.Exit();
                }


            }
        }

        private void قائمةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Hide();
                UsersForm usersForm = new UsersForm();
                usersForm.MdiParent = this;
                usersForm.Dock = DockStyle.Fill;
                usersForm.Show();

            }
            else
            {
                UsersForm usersForm = new UsersForm();
                usersForm.MdiParent = this;
                usersForm.Dock = DockStyle.Fill;
                usersForm.Show();

            }














        }

        private void حسابىالخاصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Hide();
                UserInfoForm userInfoForm = new UserInfoForm();
                userInfoForm.MdiParent = this;
                userInfoForm.Dock = DockStyle.Fill;
                userInfoForm.Show();
            }
            else
            {
                UserInfoForm userInfoForm = new UserInfoForm();
                userInfoForm.MdiParent = this;
                userInfoForm.Dock = DockStyle.Fill;
                userInfoForm.Show();
            }
         
        }

        private void قائمةمخازنالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Hide();
                StoresForm storeInfoForm = new StoresForm();
                storeInfoForm.MdiParent = this;
                storeInfoForm.Dock = DockStyle.Fill;
                storeInfoForm.Show();
            }
            else
            {
                StoresForm storeInfoForm = new StoresForm();
                storeInfoForm.MdiParent = this;
                storeInfoForm.Dock = DockStyle.Fill;
                storeInfoForm.Show();
            }
        }

        private void تحويلأرصدةأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Hide();
                TransKindsBalanceForm transKindsBalanceForm = new TransKindsBalanceForm();
                transKindsBalanceForm.MdiParent = this;
                transKindsBalanceForm.Dock = DockStyle.Fill;
                transKindsBalanceForm.Show();
            }
            else
            {
                TransKindsBalanceForm transKindsBalanceForm = new TransKindsBalanceForm();
                transKindsBalanceForm.MdiParent = this;
                transKindsBalanceForm.Dock = DockStyle.Fill;
                transKindsBalanceForm.Show();
            }
        }

        private void فواتيرتحويلأرصدةسابقةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Hide();
                OldTransKindBalBilsForm oldTransKindBalBilsForm = new OldTransKindBalBilsForm();
                oldTransKindBalBilsForm.MdiParent = this;
                oldTransKindBalBilsForm.Dock = DockStyle.Fill;
                oldTransKindBalBilsForm.Show();
            }
            else
            {
                OldTransKindBalBilsForm oldTransKindBalBilsForm = new OldTransKindBalBilsForm();
                oldTransKindBalBilsForm.MdiParent = this;
                oldTransKindBalBilsForm.Dock = DockStyle.Fill;
                oldTransKindBalBilsForm.Show();
            }
        }

        private void مجموعةالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Hide();
                CategoriesForm categoriesForm = new CategoriesForm();
                categoriesForm.MdiParent = this;
                categoriesForm.Dock = DockStyle.Fill;
                categoriesForm.Show();
            }
            else
            {
                CategoriesForm categoriesForm = new CategoriesForm();
                categoriesForm.MdiParent = this;
                categoriesForm.Dock = DockStyle.Fill;
                categoriesForm.Show();
            }
        }

        private void مخازنالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
