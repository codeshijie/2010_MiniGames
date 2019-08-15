using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace 扫雷
{
    class Element:Button
    {
        public  enum Status
        { 
            close,
            open,
            mark,
            unknow
        }
        public bool mine { set; get; }
        public Status status { set; get; }
        public const int length = 20;

        public Element()
        {
            mine = false;
            status = Status .close ;
            this.BackColor = Color.YellowGreen;
            this.Size = new Size(Element .length  ,Element .length  );
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        /// <summary>
        ///标记方法
        /// </summary>
        public void Mark()
        {
            this.BackgroundImage = Properties.Resources.旗;
            this.status = Element.Status.mark;
        }

        /// <summary>
        /// 疑问方法
        /// </summary>
        public void Unkonw()
        {
            this.BackgroundImage = Properties.Resources.问号 ;
            this.status = Element.Status.unknow ;
        }

        /// <summary>
        /// 翻开方法
        /// </summary>
        /// <param name="field"></param>
        /// <param name="elementNumOfSqrt"></param>
        public void Open(Field field, int elementNumOfSqrt)
        {
            int x = this.Left / Element.length;
            int y = this.Top / Element.length;
            int mineNumAround = 0;
            for (int j = -1; j <= 1; j++)
                for (int i = -1; i <= 1; i++)
                {
                    if (x - i >= 0 && x - i < elementNumOfSqrt  && y - j >= 0 && y - j < elementNumOfSqrt )
                    {
                        Element element = field.Controls[(y - j) * elementNumOfSqrt + x - i] as Element;
                        if (element.mine) mineNumAround++;
                    }
                          
                }
            switch (mineNumAround)
            {

                case 0: Around(field, elementNumOfSqrt); break;
                case 1: this.BackgroundImage = Properties.Resources._1;
                    this.status = Element.Status.open; ; break;
                case 2: this.BackgroundImage = Properties.Resources._2;
                    this.status = Element.Status.open; ; break;
                case 3: this.BackgroundImage = Properties.Resources._3;
                    this.status = Element.Status.open; ; break;
                case 4: this.BackgroundImage = Properties.Resources._4;
                    this.status = Element.Status.open; ; break;
                case 5: this.BackgroundImage = Properties.Resources._5;
                    this.status = Element.Status.open; ; break;
                case 6: this.BackgroundImage = Properties.Resources._6;
                    this.status = Element.Status.unknow; ; break;
                case 7: this.BackgroundImage = Properties.Resources._7;
                    this.status = Element.Status.open; ; break;
                case 8: this.BackgroundImage = Properties.Resources._8;
                    this.status = Element.Status.open; ; break;

            }
          
          
        }

        /// <summary>
        /// 把自己和周围元素翻开
        /// </summary>
        /// <param name="field"></param>
        /// <param name="elementNumOfSqrt"></param>
        private void Around(Field field, int elementNumOfSqrt)
        {
            int x = this.Left / Element.length;
            int y = this.Top / Element.length;
            this.BackgroundImage = Properties.Resources.空;
            this.status = Element.Status.open;
            for (int j = -1; j <= 1; j++)
                for (int i = -1; i <= 1; i++)
                {
                    if (x - i >= 0 && x - i < elementNumOfSqrt  && y - j >= 0 && y - j < elementNumOfSqrt )
                    {
                        Element element = field.Controls[(y - j) * elementNumOfSqrt + x - i] as Element;
                        if (element.status == Element.Status.close || element.status == Element.Status.unknow)
                        {
                            element.Open(field, elementNumOfSqrt);
                        }
                    }

                }
        }


    }
}
