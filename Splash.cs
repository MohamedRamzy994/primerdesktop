using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PREMIER
{
    public partial class Splash : Form
    {
        int count = 1;
        SoundPlayer simpleSound;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

             simpleSound = new SoundPlayer("E:\\Project\\Desktop\\PREMIER\\bsmlah.wav");

             simpleSound.Play();


        }

    



        private void splashtimer_Tick(object sender, EventArgs e)
        {
            count++;

            if (count <= 5)
            {

                this.Show();
                
            }
            else
            {
                LoginForm homeForm = new LoginForm();
                homeForm.Show();
                this.Hide();
                count = 0;
                splashtimer.Stop();
                simpleSound.Stop();

            }

        }
        
    }
}
