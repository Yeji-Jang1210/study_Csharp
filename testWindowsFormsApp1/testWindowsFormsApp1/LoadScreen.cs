using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testWindowsFormsApp1
{
    public partial class LoadScreen : Form
    {
        public LoadScreen()
        {
            InitializeComponent();
            //var t = Task.Run(splashRun);
            
        }

        async void splashRun() 
        {
            await Task.Delay(2500);
            Main1 mainClass = new Main1();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
