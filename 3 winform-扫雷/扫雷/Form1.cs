using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 扫雷
{
    public partial class Form1 : Form
    {
        private int mineNum;
        private int elementNumOfSqrt;
        private static int time = 0;
        private TextBox tbMineNum = new TextBox();
        private TextBox tbElementNumOfSqrt = new TextBox();
        private Form formSelf = new Form();

        public Form1()
        {
            InitializeComponent();
            mineNum = 10;
            elementNumOfSqrt = 10;
        }

        /// <summary>
        /// FORM1加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
            buttonAgain.BackgroundImage = Properties.Resources.笑脸;
            this.Size = new Size(elementNumOfSqrt * Element.length + 30, elementNumOfSqrt * Element.length + 100);
            Field field1 = new Field(buttonAgain, elementNumOfSqrt, mineNum, lbMineNum, timer1);
            this.Controls.Add(field1);
            field1.Left = 10;
            field1.Top = 60;
            field1.Size = new Size(elementNumOfSqrt * Element.length, elementNumOfSqrt * Element.length);
            field1.InitElements();
            field1.InitMine();
            timer1.Enabled=true ;
        }

        /// <summary>
        /// 重新开始函数
        /// </summary>
        private void Bagin()
        {
            buttonAgain.BackgroundImage = Properties.Resources.笑脸;
            this.Size = new Size(elementNumOfSqrt * Element.length + 30, elementNumOfSqrt * Element.length + 100);

            foreach (object field in this.Controls)
            {
                if (field as Field != null)
                {
                    Field field1 = field as Field;
                    field1.Controls.Clear();
                    field1.Size = new Size(elementNumOfSqrt * Element.length, elementNumOfSqrt * Element.length);
                    field1.mineNum = this.mineNum;
                    field1.elementNumOfSqrt = this.elementNumOfSqrt;
                    field1.InitElements();
                    field1.InitMine();
                }
            }

            time = 0;
            timer1.Enabled = true;

        }

        private void buttonAgain_Click(object sender, EventArgs e)
        {
            Bagin();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = time++.ToString();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bagin();
        }

        private void 初级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mineNum = 10;
            elementNumOfSqrt = 10;
            Bagin();
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mineNum = 20;
            elementNumOfSqrt = 15;
            Bagin();
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mineNum = 60;
            elementNumOfSqrt = 20;
            Bagin();
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.Size = new Size(250, 180);
            form.MaximizeBox = false;

            Label labelMineNum = new Label();
            labelMineNum.Left = 20;
            labelMineNum.Top = 30;
            labelMineNum.Text = "雷数";
            labelMineNum.Size = new Size(30, 30);
            form.Controls.Add(labelMineNum);

            Label labelElementNumOfSqrt = new Label();
            labelElementNumOfSqrt.Left = 20;
            labelElementNumOfSqrt.Top = 70;
            labelElementNumOfSqrt.Size = new Size(30, 30);
            labelElementNumOfSqrt.Text = "宽度";
            form.Controls.Add(labelElementNumOfSqrt);

            GroupBox prompt = new GroupBox();
            prompt.Left = 130;
            prompt.Top = 15;
            prompt.Size = new Size(105, 80);
            prompt.Text = "注意";
            Label label1 = new Label();
            label1.Text = "雷数<=宽度*宽度";
            label1.Left = 5;
            label1.Top = 25;
            Label label2 = new Label();
            label2.Text = "宽度<=30";
            label2.Left = 5;
            label2.Top = 60;
            prompt.Controls.Add(label1);
            prompt.Controls.Add(label2);
            form.Controls.Add(prompt);

            TextBox textBoxMineNum = new TextBox();
            textBoxMineNum.Left = 55;
            textBoxMineNum.Top = 30;
            textBoxMineNum.Size = new Size(55, 30);
            tbMineNum = textBoxMineNum;
            form.Controls.Add(textBoxMineNum);

            TextBox textBoxElementNumOfSqrt = new TextBox();
            textBoxElementNumOfSqrt.Left = 55;
            textBoxElementNumOfSqrt.Top = 70;
            textBoxElementNumOfSqrt.Size = new Size(55, 30);
            tbElementNumOfSqrt = textBoxElementNumOfSqrt;
            form.Controls.Add(textBoxElementNumOfSqrt);



            Button confirm = new Button();
            confirm.Left = 100;
            confirm.Top = 110;
            confirm.Size = new Size(60, 30);
            confirm.Text = "确定";
            confirm.Click += new EventHandler(confirm_Click);
            form.Controls.Add(confirm);

            formSelf = form;
            form.Show();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                int _mineNum = Convert.ToInt32(tbMineNum.Text);
                int _elementNumOfSqrt = Convert.ToInt32(tbElementNumOfSqrt.Text);
                formSelf.Close();
                if (_mineNum > _elementNumOfSqrt * _elementNumOfSqrt || _mineNum <= 0 || _elementNumOfSqrt > 30 || _elementNumOfSqrt <= 0)
                    return;
                else
                {
                    mineNum = _mineNum;
                    elementNumOfSqrt = _elementNumOfSqrt;
                    Bagin();
                }
            }
            catch
            {

                return;
            }


        }

        private void 关于扫雷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.Size = new Size(270, 350);
            form.MaximizeBox = false;
            form.BackgroundImageLayout = ImageLayout.Stretch;
            form.BackgroundImage = Properties.Resources.雷兄;

            form.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



    }
}
