#include <graphics.h>
#include <stdlib.h>
#include <dos.h>


#define UP      18432
#define DOWN    20480
#define LEFT    19200   
#define RIGHT   19712
#define ESC     283

#define X1 4
#define X2 14
#define Y1 4
#define Y2 20


int  kuangjia[24][18]={0};


int leftx=40,lefty=40,rightx=260,righty=380;
int fat=20;
int a,z,yuansux,yuansuy;

int count=4;
int tune;
struct time t1 ,t2;

int yuansu[7][4][4][4]=
{
        {   
                  {
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0
                  },
                  {
                    0,0,0,0,
                    1,1,1,1,
                    0,0,0,0,
                    0,0,0,0
                  },
                  {
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0,
                    0,1,0,0
                  },
                  {
                    0,0,0,0,
                    1,1,1,1,
                    0,0,0,0,
                    0,0,0,0
                  }
        },

          

        {
                  {
                    0,0,0,0,
                    0,1,1,0,
                    0,1,1,0,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,1,1,0,
                    0,1,1,0,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,1,1,0,
                    0,1,1,0,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,1,1,0,
                    0,1,1,0,
                    0,0,0,0
                  }
        },

          {
                  {
                    0,0,0,0,
                    0,0,1,0,
                    0,1,1,1,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,0,1,0,
                    0,1,1,0,
                    0,0,1,0
                  },
                  {
                    0,0,0,0,
                    0,0,0,0,
                    0,1,1,1,
                    0,0,1,0
                  },
                  {
                    0,0,0,0,
                    0,0,1,0,
                    0,0,1,1,
                    0,0,1,0
                  }
          },
          
          {

                  {
                    0,0,0,0,
                    0,0,1,0,
                    0,1,1,0,
                    0,1,0,0
                  },
                  {
                    0,0,0,0,
                    0,0,0,0,
                    1,1,0,0,
                    0,1,1,0
                  },
                  {
                    0,0,0,0,
                    0,0,1,0,
                    0,1,1,0,
                    0,1,0,0
                  },

                  {
                    0,0,0,0,
                    0,0,0,0,
                    1,1,0,0,
                    0,1,1,0
                  }

          },

          {
                  {
                    0,0,0,0,
                    0,1,0,0,
                    0,1,1,0,
                    0,0,1,0
                  },
                  {
                    0,0,0,0,
                    0,0,0,0,
                    0,1,1,0,
                    1,1,0,0
                  },

                  {
                    0,0,0,0,
                    0,1,0,0,
                    0,1,1,0,
                    0,0,1,0
                  },
                  {
                    0,0,0,0,
                    0,0,0,0,
                    0,1,1,0,
                    1,1,0,0
                  }

          },
          
          {
                  {
                    0,1,0,0,
                    0,1,1,1,
                    0,0,0,0,
                    0,0,0,0
                  },
                  {
                    0,0,1,0,
                    0,0,1,0,
                    0,1,1,0,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,1,1,1,
                    0,0,0,1,
                    0,0,0,0
                  },
                  {
                    0,1,1,0,
                    0,1,0,0,
                    0,1,0,0,
                    0,0,0,0
                  }

          },

          {

                  {
                    0,0,0,0,
                    0,0,0,1,
                    0,1,1,1,
                    0,0,0,0
                  },
                  {
                    0,1,1,0,
                    0,0,1,0,
                    0,0,1,0,
                    0,0,0,0
                  },
                  {
                    0,0,0,0,
                    0,1,1,1,
                    0,1,0,0,
                    0,0,0,0
                  },
                  {
                    0,0,1,0,
                    0,0,1,0,
                    0,0,1,1,
                    0,0,0,0
                  }

          }
};


/*初始化图形模式*/
void initgr()
{
  int gd =DETECT, gm = 0;
  registerbgidriver(EGAVGA_driver);
  initgraph(&gd, &gm, "");
}


/*初始化背景*/
void background()
{
    setfillstyle(11,GREEN);setcolor(GREEN);
    bar(leftx-10,lefty-10,leftx,righty+10);
    bar(leftx-10,lefty-10,rightx+10,lefty);
    bar(rightx,lefty-10,rightx+10,righty+10);
    bar(leftx-10,righty,rightx+10,righty+10);
}

/*初始化背景方格*/
void initdraw()
{
    int x,y;
    for(y=Y1;y<=Y2;y++)
        for(x=X1;x<=X2;x++)

              {  setcolor(GREEN);rectangle(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat); }


}
/*重画方格元素*/
void draw()
{
    int x,y;
    for(y=Y1;y<=Y2;y++)
        for(x=X1;x<=X2;x++)

          {
           if( kuangjia[y][x]==0 && getpixel(40+(x-4)*fat+10,40+(y-4)*fat+10)!=BLACK )
              {
                 setfillstyle(0,0);bar(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);
                setcolor(GREEN);rectangle(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);
              }

            if( kuangjia[y][x]==1 && getpixel(40+(x-4)*fat+10,40+(y-4)*fat+10)!=a+4 )
              {
                setfillstyle(1,a+4);bar(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);
                setcolor(GREEN);rectangle(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);
              }


          }

}

/*随即生成方格*/
void random_a()
{    
    int x,j,k;
    randomize();
    a=random(7) ;
    z=0;
    yuansux=X1+4;
    yuansuy=Y1;

    for(x=X1+4,j=0;j<=3;x++,j++)
        kuangjia[Y1][x]=yuansu[a][z][3][j];
}

 /*把掉落的方格固定,并产生新方格*/
void guding()
{
    int x,y;
    count=0;
    for(y=Y2;y>=Y1;y--)
        for(x=X2;x>=X1;x--)
            if(kuangjia[y][x]==1)
              {kuangjia[y][x]=2;count++;}
    sound(1500);delay(1000);delay(1000);delay(1000);delay(1000);
    sound(1900);delay(1000);delay(1000);delay(1000);delay(1000);
    nosound();
    random_a();
}

 /*判断是否消行*/
void disappear()
{
    int x,y,appear;
    for(y=Y2;y>=Y1;y--)
        {
            appear=0;
            for(x=X1;x<=X2;x++)
            if(kuangjia[y][x]==2) appear=appear+2;
            if(appear==22)disdown(y);
        }

}
/*消行*/
int disdown(int y)
{
    int x;
    for(x=X1;x<=X2;x++){setcolor(YELLOW);rectangle(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);}
    delay(1000);delay(1000);delay(1000);delay(1000);delay(1000);
    for(x=X1;x<=X2;x++){setcolor(GREEN);rectangle(40+(x-4)*fat,40+(y-4)*fat,40+(x-4)*fat+fat,40+(y-4)*fat+fat);}
    for(x=X1;x<=X2;x++) kuangjia[y][x]=0;
    for(y=y-1;y>=Y1;y--)
        for(x=X1;x<=X2;x++)
            if(kuangjia[y][x]==2)
                {
                    kuangjia[y+1][x]=2;
                    kuangjia[y][x]=0;

                    setfillstyle(1,getpixel(40+(x-4)*fat+10,40+(y-4)*fat+10));
                    bar(40+(x-4)*fat,40+(y+1-4)*fat,40+(x-4)*fat+fat,40+(y+1-4)*fat+fat);
                    setcolor(GREEN);rectangle(40+(x-4)*fat,40+(y+1-4)*fat,40+(x-4)*fat+fat,40+(y+1-4)*fat+fat);


                }
    for(tune=1000;tune<=2000;tune=tune+200)
        {sound(tune);delay(1000);delay(1000);delay(1000);delay(1000);delay(1000);delay(1000);delay(1000);}
    nosound();

}

 /*元素向下的动作*/
int down()
{
    int x,y,j,k;
 
    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
        {
            if(kuangjia[y+1][x]==2 && yuansu[a][z][k][j]==1){guding();return;}
            if(kuangjia[Y2][x]==1){guding();return;}
        }

    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
                {
                    if(kuangjia[y+1][x]==2||kuangjia[y][x]==2)continue;
                    kuangjia[y+1][x]=yuansu[a][z][k][j];
                    kuangjia[y][x]=0;
                }

    yuansuy++;
    return;

}
 /*元素向左的动作*/
int left()
{
    int x,y,j,k;
 
    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
        {
            if(kuangjia[y][x-1]==2 && yuansu[a][z][k][j]==1)return;
            if(kuangjia[y][X1]==1){return;}
            if(x==X1&&yuansu[a][z][k][j]==1)return;
        }

    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
                {
                    if(kuangjia[y][x-1]==2||kuangjia[y][x]==2)continue;
                    kuangjia[y][x-1]=yuansu[a][z][k][j];
                    kuangjia[y][x]=0;
                }

    yuansux--;
    return;

}
/*元素向有的动作*/
int right()
{
    int x,y,j,k;
 
    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux+3,j=3;j>=0;x--,j--)
        {
            if(kuangjia[y][x+1]==2 && yuansu[a][z][k][j]==1)return;
            if(kuangjia[y][X2]==1)return;
            if(x==X2&&yuansu[a][z][k][j]==1)return;
        }

    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux+3,j=3;j>=0;x--,j--)
                {
                    if(kuangjia[y][x+1]==2||kuangjia[y][x]==2)continue;
                    kuangjia[y][x+1]=yuansu[a][z][k][j];
                    kuangjia[y][x]=0;
                }

    yuansux++;
    return;

}

 /*元素向上的动作*/
int up()
{
    int x,y,j,k;
 
    for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
        {
            if(kuangjia[y][x]==2 && yuansu[a][z+1][k][j]==1)return;
            if((x>X2||x<X1||y>Y2||y<Y1)&&yuansu[a][z+1][k][j]==1)return;

        }
   if(z==3)z=0;
   else z++;
   for(y=yuansuy,k=3;k>=0;y--,k--)
        for(x=yuansux,j=0;j<=3;x++,j++)
        {
            if(kuangjia[y][x]!=2)
            kuangjia[y][x]=yuansu[a][z][k][j];
        }
   return;

}


void main()
{
    int press,first,second;
    initgr();
    background();
    initdraw();
    setcolor(RED);
    outtextxy(330,380,"xing yi long ");
    outtextxy(330,350,"QQ 535466181");
    gettime(&t2);
    random_a();
    while((press=bioskey(!kbhit()))!=ESC)
    {

        gettime(&t1);
        if(t1.ti_sec!=t2.ti_sec){first=0;second=0;}
        if(t1.ti_hund>50 &&first==0)  {down();gettime(&t2); first=1; }
        if(t1.ti_hund<=50 &&second==0){down();gettime(&t2); second=1;}

        switch(press)
            {
                case LEFT :left(); break;
                case RIGHT:right(); break;
                case DOWN : down();   break;
                case UP   : up(); break;
            }
        draw();
        disappear();
        if(count!=4)
        {   setcolor(WHITE);
            outtextxy(330,300,"GAME OVER");
            tune=2500;
            while(1)
            {
                if(tune>=1000)
                {sound(tune);tune=tune-300;delay(100000);delay(100000);delay(100000);delay(100000);delay(100000);delay(100000);}
                else nosound();
                if((press=bioskey(!kbhit()))==ESC) goto here;

            }

        }

    }
    here:;

}


