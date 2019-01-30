using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 扫雷
{
    public partial class Field : UserControl
    {
        
        public  int elementNumOfSqrt{set;get;}
        public int mineNum { set; get; }
        private   Label labelMineNum;
        private  Button buttonAgain;
        private Timer time;


        public Field(Button _buttonAgain, int _elementNumOfSqrt, int _mineNum, Label _labelMineNum,Timer _time)
        {
            InitializeComponent();
            buttonAgain = _buttonAgain;
            elementNumOfSqrt = _elementNumOfSqrt;
            mineNum = _mineNum;
            labelMineNum = _labelMineNum;
            time = _time;

        }
        
        /// <summary>
        /// 初始化小方格集
        /// </summary>
        public  void InitElements()
        {
            int left=0;
            int top=0;
            for (int j = 0; j < elementNumOfSqrt; j++)
                for (int i = 0; i < elementNumOfSqrt; i++)
                {
                    Element element = new Element();
                    element.Left = i * Element.length;
                    left = element.Left;
                    element.Top = j * Element.length;
                    top = element.Top;
                    element .MouseDown +=new MouseEventHandler(element_MouseDown);
                    this.Controls.Add(element);
                                 
                }
                    
        }

        /// <summary>
        /// 布雷
        /// </summary>
        public   void InitMine()
        {
            Random random = new Random();
            int _mineNum = mineNum;
            while (_mineNum > 0)
            {
                
                int index = elementNumOfSqrt * elementNumOfSqrt;
                Element element= this.Controls[random.Next(index)] as Element;
                if (element.mine)
                    continue;
                else 
                {
                    element.mine = true;
                    _mineNum--;
                }
            }
            labelMineNum.Text = mineNum.ToString ();
            time.Enabled = true;
        }

        /// <summary>
        /// 按下鼠标所发生的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void element_MouseDown(object sender, EventArgs e)
        {
            MouseEventArgs MouseEA = e as MouseEventArgs;
            Element element = sender as Element;
            if (MouseEA.Button == MouseButtons.Left)
            {
                if (element.status == Element.Status.close||element .status==Element .Status .unknow )
                {
                    if (element.mine)
                    {
                        element.BackgroundImage = Properties.Resources.触雷;
                        element.status = Element.Status.open;
                        GameOver();
                        
                    }
                    else
                    {
                        element.Open(this,elementNumOfSqrt);
                        GameFinish();
                    }
                }
              
            }
            else
            {
                if (element.status == Element.Status.close && mineNum > 0)
                { element.Mark(); labelMineNum.Text = (--mineNum).ToString(); }
                else if (element.status == Element.Status.mark)
                { element.Unkonw(); labelMineNum.Text = (++mineNum).ToString(); }
                else if (element.status == Element.Status.unknow && mineNum > 0)
                { element.Mark(); labelMineNum.Text = (--mineNum).ToString(); }
                GameFinish();
            }
            
        }


        /// <summary>
        /// 游戏失败
        /// </summary>
        private void GameOver()
        {
            
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Element element = this.Controls[i] as Element;
                if (element.mine && element.status != Element.Status.mark && element .status !=Element .Status .open )
                {
                    element.BackgroundImage = Properties.Resources.地雷;
                }
                if (element.mine == false && element.status == Element.Status.mark)
                {
                    element.BackgroundImage = Properties.Resources.错雷;
                }
                element.status = Element.Status.open;
            }

            buttonAgain.BackgroundImage = Properties.Resources.哭脸;
            time.Enabled = false;
        }


        /// <summary>
        /// 判断游戏是否完成，如是则结束
        /// </summary>
        private void GameFinish()
        {
            bool finish=true ;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Element element = this.Controls[i] as Element;
                if (!(element.status == Element.Status.open || (element.status == Element.Status.mark && element.mine)))
                {
                    finish = false;
                }
            }
            if (finish && mineNum ==0)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Element element = this.Controls[i] as Element;
                    
                    element.status = Element.Status.open;
                }
                buttonAgain.BackgroundImage = Properties.Resources.墨镜;
                time.Enabled = false;
            }
        }
 
    
    }
}
