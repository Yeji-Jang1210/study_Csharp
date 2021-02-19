using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testWindowsFormsApp1
{
    public partial class Main1 : Form
    {
        public Main1()
        {
            LoadScreen screen = new LoadScreen();   //splash screen 불러옴
            screen.Show();  //화면에 출력
            Console.WriteLine("show splashScreen");
            Task splashScreen = Task.Run(() =>  //람다식
            {
                Thread.Sleep(2000);
                Console.WriteLine("SplashScreen 2seconds..");
            });
            Console.WriteLine("Loading Initialize");
            InitializeComponent();  //생성자 로딩
            Console.WriteLine("Loading Complete and Wait SplashScreen");
            splashScreen.Wait();    //호출한 스레드 작업이 완료 될 때까지 대기
            screen.Close(); //splash screen close
            Console.WriteLine("Splash Screen Closed and show main");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Main1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
