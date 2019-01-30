using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace 五子棋
{
    public partial class ptob : System.Web.UI.Page
    {
        private const int live4 = 100000;
        private const int live3 = 10000;
        private const int live2 = 1000;
        private const int live1 = 100;
        private const int live0 = 10;


        private const int sleep4 = 100000;
        private const int sleep3 = 5000;
        private const int sleep2 = 500;
        private const int sleep1 = 50;
        private const int sleep0 = 5;


        private const int die4 = 100000;
        private const int die3 = 300;
        private const int die2 = 30;
        private const int die1 = 3;
        private const int die0 = 0;


        private static int[,] importtable = { { live0, live1, live2, live3, live4 }, { sleep0, sleep1, sleep2, sleep3, sleep4 }, { die0, die1, die2, die3, die4 } };


        public const int num = 15;



        public static int[,] boolBoard = new int[15, 15];
        public static int[, , ,] boardImport = new int[15, 15, 4, 2];
        public static int[, ,] boolImportdAll = new int[15, 15, 2];

        protected void Page_Load(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(Request["y"]);
            int x = Convert.ToInt32(Request["x"]);
            boolBoard[y, x] = 1;



            Import();
            Importall();
            ImportallPk();


        }

        //判断重要性PK
        private void ImportallPk()
        {
            int y1 = 0, x1 = 0, y2 = 0, x2 = 0, ypk, xpk, temp = 0;
            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                {
                    if (temp < boolImportdAll[y, x, 0])
                    {
                        temp = boolImportdAll[y, x, 0];
                        y1 = y;
                        x1 = x;
                    }

                }
            temp = 0;
            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                {
                    if (temp < boolImportdAll[y, x, 1])
                    {
                        temp = boolImportdAll[y, x, 1];
                        y2 = y;
                        x2 = x;
                    }

                }
            if (boolImportdAll[y1, x1, 0] <= boolImportdAll[y2, x2, 1])
            {
                ypk = y2;
                xpk = x2;
            }
            else
            {
                ypk = y1;
                xpk = x1;
            }

            boolBoard[ypk, xpk] = 2;
            Response.Write("y" + ypk + "x" + xpk);
        }

        //判断重要性和
        private void Importall()
        {
            boolImportdAll = new int[15, 15, 2];
            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                {
                    for (int who = 0; who < 2; who++)
                        for (int fangxiang = 0; fangxiang < 4; fangxiang++)
                        {

                            boolImportdAll[y, x, who] += boardImport[y, x, fangxiang, who];
                        }
                }
        }


        //判断重要性
        private void Import()
        {
            int maxin = 0;
            int yan = 0;
            boardImport = new int[15, 15, 4, 2];

            for (int whiteorblock = 0; whiteorblock < 2; whiteorblock++)
            {

                for (int y = 0; y < num; y++)
                {

                    for (int x = 0; x < num; x++)
                    {
                        if (boolBoard[y, x] == 0)
                        {
                            int x1 = 0;
                            int y1 = 0;
                            //x轴判断
                            maxin = 0;
                            yan = 0;
                            for (x1 = x; x1 >= 0 && x1 >= x - 4; x1--)
                            {
                                if (x1 == x) continue;
                                if (boolBoard[y, x1] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (x1 == 0) yan++;
                            for (x1 = x; x1 <= 14 && x1 <= x + 4; x1++)
                            {
                                if (x1 == x) continue;
                                if (boolBoard[y, x1] == (whiteorblock + 1))
                                {
                                    maxin++;

                                }
                                else if (boolBoard[y, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (x1 == 14) yan++;
                            if (maxin >= 4)
                            { maxin = 4; }
                            if (yan >= 2)
                            { yan = 2; }
                            boardImport[y, x, 0, whiteorblock] = importtable[yan, maxin];



                            //y轴判断
                            maxin = 0;
                            yan = 0;
                            for (y1 = y; y1 >= 0 && y1 >= y - 4; y1--)
                            {
                                if (y1 == y) continue;
                                if (boolBoard[y1, x] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 0) yan++;
                            for (y1 = y; y1 <= 14 && y1 <= y + 4; y1++)
                            {
                                if (y1 == y) continue;
                                if (boolBoard[y1, x] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 14) yan++;
                            if (maxin >= 4)
                            { maxin = 4; }
                            if (yan >= 2)
                            { yan = 2; }
                            boardImport[y, x, 1, whiteorblock] = importtable[yan, maxin];




                            //  \轴判断
                            maxin = 0;
                            yan = 0;
                            for (y1 = y, x1 = x; (y1 >= 0 && y1 >= y - 4) && (x1 >= 0 && x1 >= x - 4); y1--, x1--)
                            {
                                if ((y1 == y) && (x1 == x)) continue;
                                if (boolBoard[y1, x1] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 0 || x1 == 0) yan++;
                            for (y1 = y, x1 = x; (y1 <= 14 && y1 <= y + 4) && (x1 <= 14 && x1 <= x + 4); y1++, x1++)
                            {
                                if ((y1 == y) && (x1 == x)) continue;
                                if (boolBoard[y1, x1] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 14 || x1 == 14) yan++;
                            if (maxin >= 4)
                            { maxin = 4; }
                            if (yan >= 2)
                            { yan = 2; }
                            boardImport[y, x, 3, whiteorblock] = importtable[yan, maxin];




                            //  /轴判断
                            maxin = 0;
                            yan = 0;
                            for (y1 = y, x1 = x; (y1 >= 0 && y1 >= y - 4) && (x1 <= 14 && x1 <= x + 4); y1--, x1++)
                            {
                                if ((y1 == y) && (x1 == x)) continue;
                                if (boolBoard[y1, x1] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 0 || x1 == 14) yan++;
                            for (y1 = y, x1 = x; (y1 <= 14 && y1 <= y + 4) && (x1 >= 0 && x1 >= x - 4); y1++, x1--)
                            {
                                if ((y1 == y) && (x1 == x)) continue;
                                if (boolBoard[y1, x1] == (whiteorblock + 1))
                                {
                                    maxin++;
                                }
                                else if (boolBoard[y1, x1] != 0)
                                {
                                    yan++; break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (y1 == 14 || x1 == 0) yan++;
                            if (maxin >= 4)
                            { maxin = 4; }
                            if (yan >= 2)
                            { yan = 2; }
                            boardImport[y, x, 3, whiteorblock] = importtable[yan, maxin];





                        }







                    }
                }
            }



        }









    }
}
