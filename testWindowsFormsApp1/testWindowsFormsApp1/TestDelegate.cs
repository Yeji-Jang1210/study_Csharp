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
    public partial class TestDelegate : Form
    {
        TestDelegateSub fPizza;
        List<CheckBox> list;
        public delegate int delFunc(int dOrder);   //delegate 선언
        // public delegate T delFunc<T>(T dOrder);
        public delegate int delFuncTopping();
        int totalPrice = 0;
        

        public TestDelegate()
        {
            list = new List<CheckBox>();    //checkbox List 선언
            list.Add(cBoxTopping1);
            list.Add(cBoxTopping2);
            list.Add(cBoxTopping3);
            list.Add(cBoxTopping4);
            list.Add(cBoxTopping5);
            InitializeComponent();  //생성자 로딩
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dPizzaOrder = new Dictionary<string, int>();    //Pizza 주문을 담을 그릇
            delFunc dDow = new delFunc(fDow);   //delegate 호출
            delFunc dEdge = new delFunc(fEdge);
            delFuncTopping dTopping = null;

            int dowIdx = 0;
            int edgeIdx = 0;

            //Dow
            if (rdoDow1.Checked) 
            {
                dowIdx = 1;
                dPizzaOrder.Add("Original",1);    //Dictionary에 key,value 추가
            }
            else if (rdoDow2.Checked)
            {
                dowIdx = 2;
                dPizzaOrder.Add("Napoli", 1);
            }
            else if (rdoDow3.Checked)
            {
                dowIdx = 3;
                dPizzaOrder.Add("Thin", 1);
            }

            //dDow(dowIdx);

            //Edge
            if (rdoEdge1.Checked)
            {
                edgeIdx = 1;
                dPizzaOrder.Add("Rich Gold", 1);
            }
            else if (rdoEdge2.Checked)
            {
                edgeIdx = 2;
                dPizzaOrder.Add("Cheese Crust", 2);
            }
            //dEdge(edgeIdx);

            fCallBack(dowIdx, dDow);
            fCallBack(edgeIdx, dEdge);

            if (cBoxTopping1.Checked)
            { 
                dTopping += fTopping1;      //delegate chain(함수를 연결시킴)
                dPizzaOrder.Add("Pepperoni", 1);
            }
            if (cBoxTopping2.Checked) 
            {
                dTopping += fTopping2;
                dPizzaOrder.Add("Potato", 1);
            }
            if (cBoxTopping3.Checked) 
            {
                dTopping += fTopping3;
                dPizzaOrder.Add("Meat", 1);
            }
            if (cBoxTopping4.Checked) 
            {
                dTopping += fTopping4;
                dPizzaOrder.Add("White Mushroom", 1);
            }
            if (cBoxTopping5.Checked) 
            {
                dTopping += fTopping5;
                dPizzaOrder.Add("Paprika", 1);
            }

            if (dTopping == null)
            {
                fOrderError("Topping");
            }
            else 
            {
                dTopping();
                fEndOrder("------------------------------------");
                fEndOrder(string.Format("Total Price is {0}.", totalPrice));
                frmLoading(dPizzaOrder);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fOrderReset();
            totalPrice = 0;
            lBoxOrder.Items.Clear();
        }

        #region Function
        private int fDow(int iOrder) 
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder == 1)
            {
                iPrice = 10000;
                strOrder = string.Format("Dow is Original. Price({0}).", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 11000;
                strOrder = string.Format("Dow is Napoli. Price({0}).", iPrice.ToString());
            }
            else if (iOrder == 3)
            {
                iPrice = 11000;
                strOrder = string.Format("Dow is Thin. Price({0}).", iPrice.ToString());
            }
            else
            {
                fOrderError("Dow");
            }

            fEndOrder(strOrder);

            return totalPrice = totalPrice + iPrice;
            
        }
        private int fEdge(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0;

            if (iOrder == 1)
            {
                iPrice = 1000;
                strOrder = string.Format("Edge is Rich Gord. Price({0}).", iPrice.ToString());
            }
            else if (iOrder == 2)
            {
                iPrice = 2000;
                strOrder = string.Format("Edge is Cheese Crust. Price({0}).", iPrice.ToString());
            }
            else
            {
                fOrderError("Edge");
            }

            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }

        private int fTopping1() 
        {
            string strOrder = string.Empty;
            int iPrice = 4000;
            strOrder = string.Format("Add Topping Pepperoni. Price({0})",iPrice);

            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }
        private int fTopping2()
        {
            string strOrder = string.Empty;
            int iPrice = 3000;
            strOrder = string.Format("Add Topping Potato. Price({0})", iPrice);

            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }
        private int fTopping3()
        {
            string strOrder = string.Empty;
            int iPrice = 6000;
            strOrder = string.Format("Add Topping Meat. Price({0})", iPrice);
            
            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }
        private int fTopping4()
        {
            string strOrder = string.Empty;
            int iPrice = 3000;
            strOrder = string.Format("Add Topping White Mushroom. Price({0})", iPrice);

            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }
        private int fTopping5()
        {
            string strOrder = string.Empty;
            int iPrice = 2000;
            strOrder = string.Format("Add Topping Paprika. Price({0})", iPrice);

            fEndOrder(strOrder);
            return totalPrice = totalPrice + iPrice;
        }

        public int fCallBack(int i, delFunc dFunc) 
        {
            return dFunc(i);
        }

        public void fEndOrder(string strOrder) 
        {
            lBoxOrder.Items.Add(strOrder);
        }
        private void fOrderError(string err)
        {
            DialogResult result = MessageBox.Show(string.Format("You missig checked {0}", err), "warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result == DialogResult.OK)
            {
                totalPrice = 0;
                lBoxOrder.Items.Clear();
            }
        }

        private void fOrderReset()
        {
            rdoDow1.Checked = true;
            rdoEdge1.Checked = true;
            foreach (CheckBox topping in list)
            {
                topping.Checked = false;
            }

        }

        #endregion

        #region eventFunction
        private void frmLoading(Dictionary<string, int> dPizzaOrder) 
        {
            if (fPizza != null)
            {
                fPizza.Dispose();
                fPizza = null;
            }

            fPizza = new TestDelegateSub();
            fPizza.eventDelPizzaComplete += FPizza_eventDelPizzaComplete;
            fPizza.Show();

            fPizza.PizzaCheck(dPizzaOrder);
        }

        private int FPizza_eventDelPizzaComplete(string strResult, int iTime)
        {
            fEndOrder("------------------------------------");
            fEndOrder(string.Format(strResult, iTime));

            return 0;
        }
        #endregion

    }
}
