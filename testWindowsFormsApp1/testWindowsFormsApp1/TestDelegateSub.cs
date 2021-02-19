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
    public partial class TestDelegateSub : Form
    {
        //이벤트로 메인폼 넘겨줌
        public delegate int delPizzaComplete(string strResult, int iTime);
        public event delPizzaComplete eventDelPizzaComplete;    //이벤트 선언 event type : delegate

        public TestDelegateSub()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void PizzaCheck(Dictionary<string, int> dPizzaOrder) 
        {
            int iTotal = 0;
            foreach (KeyValuePair<string, int> oOrder in dPizzaOrder)
            {
                int iTime = 0;
                string strType = string.Empty;
                switch (oOrder.Key) 
                {
                    case "Original":
                        iTime = 3000;
                        strType = "Dow";
                        break;
                    case "Napoli":
                        iTime = 2000;
                        strType = "Dow";
                        break;
                    case "Thin":
                        iTime = 1000;
                        strType = "Dow";
                        break;
                    case "Rich Gold":
                        iTime = 800;
                        strType = "Edge";
                        break;
                    case "Cheese Crust":
                        strType = "Edge";
                        iTime = 900;
                        break;
                    case "Pepperoni":
                        strType = "Topping";
                        iTime = 880;
                        break;
                    case "Potato":
                        strType = "Topping";
                        iTime = 600;
                        break;
                    case "Meat":
                        strType = "Topping";
                        iTime = 700;
                        break;
                    case "White Mushroom":
                        strType = "Topping";
                        iTime = 300;
                        break;
                    case "Paprika":
                        strType = "Topping";
                        iTime = 350;
                        break;

                    default:
                        break;

                }
                iTotal = iTotal + iTime;
                lboxMake.Items.Add(string.Format("{0}) {1} : {2} Seconds...", strType, oOrder.Key, iTime));
                this.Refresh();
                Thread.Sleep(iTime);
            }
            eventDelPizzaComplete("Complete Total Time is {0} Seconds",iTotal);
        }
    }
}
