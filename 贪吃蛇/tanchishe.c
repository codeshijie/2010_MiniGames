#include<graphics.h>
#include<stdio.h>
#include <stdlib.h>
#include<conio.h>
#include<dos.h>

#define UP 18432
#define DOWN    20480
#define LEFT    19200
#define RIGHT   19712
#define ESC     283
#define DELAY   10000
int fat=10,score=0;

int leftx=30,lefty=20;
int rightx=330,righty=440;

struct snake
{
    int x;
    int y;
    struct snake * next;
};

struct snake *head;

struct Flood
{
   int x;
   int y;
   int z;
   int count;
}flood={0,0,0,0};

void initgr()
{
    int gdriver=DETECT,gmode=0;
    registerbgidriver(EGAVGA_driver);
    initgraph(&gdriver,&gmode,"");
}

void beijing()
{
    int a;
    setfillstyle(11,GREEN);setcolor(GREEN);
    bar(leftx,lefty,leftx+10,righty);
    bar(leftx,lefty,rightx,lefty+10);
    bar(rightx-10,lefty,rightx,righty);
    bar(leftx,righty-10,rightx,righty);
    for(a=leftx+10;a<=rightx-10;a=a+10)
    line(a,lefty+10,a,righty-10);
    for(a=lefty+10;a<=righty-10;a=a+10)
    line(leftx+10,a,rightx-10,a);



}
struct snake * initsnake()
{
    
    struct snake *p1= (struct snake *) malloc(sizeof(struct snake));
    struct snake *p2= (struct snake *) malloc(sizeof(struct snake));
    struct snake *p3= (struct snake *) malloc(sizeof(struct snake));
    head=p1;
    p2=p1->next;
    p2->next=p3;
    p3->next=NULL;
    p1->x=(leftx+rightx)/2;
    p1->y=60;
    p2->x=(leftx+rightx)/2;
    p2->y=60-fat;
    p3->x=(leftx+rightx)/2;
    p3->y=60-fat-fat;
}

void gsnake()
{
    struct snake * p;
    p=head;

    while(p!=NULL)
    {
      setfillstyle(1,RED);
      bar(p->x,p->y,p->x+fat,p->y+fat);
      setcolor(YELLOW);
      rectangle(p->x,p->y,p->x+fat,p->y+fat);
      p=p->next;

    }
}


void self()
{
    struct snake *sp1,*sp2;
    struct snake *sp= (struct snake *) malloc(sizeof(struct snake));
    sp1=head;
    sp2=sp1->next;
    sp->x=sp1->x - sp2->x + sp1->x;
    sp->y=sp1->y - sp2->y + sp1->y;
    head=sp;
    sp->next=sp1;
    
    while(sp2->next !=NULL)
    {
        sp1=sp2;
        sp2=sp2->next;
    }
    if(!(sp->x==flood.x&&sp->y==flood.y))
    {
        sp1->next=NULL;
        setfillstyle(0,GREEN);
        bar(sp2->x,sp2->y,sp2->x+fat,sp2->y+fat);
        setcolor(GREEN);
        rectangle(sp2->x,sp2->y,sp2->x+fat,sp2->y+fat);
    }
    else {flood.z=0;sound(2000);delay(DELAY);sound(4000);delay(DELAY);nosound();flood.count++;}
    gsnake();

    
}
void up()
{
    struct snake *p1,*p2;
    struct snake *p= (struct snake *) malloc(sizeof(struct snake));
    p1=head;
    p2=p1->next;
    if(p1->x!=p2->x)
    {
        p->x=p1->x;
        p->y=p1->y-fat;
        p->next=p1;
        head=p;

        while(p2->next !=NULL)
        {
            p1=p2;
            p2=p2->next;
        }
        if(!(p->x==flood.x&&p->y==flood.y))
        {
            p1->next=NULL;
            setfillstyle(0,GREEN);
            bar(p2->x,p2->y,p2->x+fat,p2->y+fat);
            setcolor(GREEN);
            rectangle(p2->x,p2->y,p2->x+fat,p2->y+fat);
        }
        else {flood.z=0;sound(2000);delay(DELAY);sound(4000);delay(DELAY);nosound();flood.count++;}
        gsnake();

    }
    else self();


}

void down()
{
    struct snake *p1,*p2;
    struct snake *p= (struct snake *) malloc(sizeof(struct snake));
    p1=head;
    p2=p1->next;
    if(p1->x!=p2->x)
    {
        p->x=p1->x;
        p->y=p1->y+fat;
        p->next=p1;
        head=p;

        while(p2->next !=NULL)
        {
            p1=p2;
            p2=p2->next;
        }
        if(!(p->x==flood.x&&p->y==flood.y))
        {

            p1->next=NULL;
            setfillstyle(0,GREEN);
            bar(p2->x,p2->y,p2->x+fat,p2->y+fat);
            setcolor(GREEN);
            rectangle(p2->x,p2->y,p2->x+fat,p2->y+fat);

        }
        else {flood.z=0;sound(2000);delay(DELAY);sound(4000);delay(DELAY);nosound();flood.count++;}
        gsnake();

    }
    else self();

}

void left()
{
    struct snake *p1,*p2;
    struct snake *p= (struct snake *) malloc(sizeof(struct snake));
    p1=head;
    p2=p1->next;
    if(p1->y!=p2->y)
    {
        p->x=p1->x-fat;
        p->y=p1->y;
        p->next=p1;
        head=p;

        while(p2->next !=NULL)
        {
            p1=p2;
            p2=p2->next;
        }
        if(!(p->x==flood.x&&p->y==flood.y))
        {
            p1->next=NULL;
            setfillstyle(0,GREEN);
            bar(p2->x,p2->y,p2->x+fat,p2->y+fat);
            setcolor(GREEN);
            rectangle(p2->x,p2->y,p2->x+fat,p2->y+fat);
        }
        else {flood.z=0;sound(2000);delay(DELAY);sound(4000);delay(DELAY);nosound();flood.count++;}
        gsnake();
    }
    else self();

}

void right()
{
    struct snake *p1,*p2;
    struct snake *p= (struct snake *) malloc(sizeof(struct snake));
    p1=head;
    p2=p1->next;
    if(p1->y!=p2->y)
    {
        p->x=p1->x+fat;
        p->y=p1->y;
        p->next=p1;
        head=p;

        while(p2->next !=NULL)
        {
            p1=p2;
            p2=p2->next;
        }
        if(!(p->x==flood.x&&p->y==flood.y))
        {
            p1->next=NULL;
            setfillstyle(0,GREEN);
            bar(p2->x,p2->y,p2->x+fat,p2->y+fat);
            setcolor(GREEN);
            rectangle(p2->x,p2->y,p2->x+fat,p2->y+fat);
        }
        else {flood.z=0;sound(2000);delay(DELAY);sound(4000);delay(DELAY);nosound();flood.count++;}
        gsnake();

    }
    else self();

}

int chongfu()
{
    struct snake *p1;
    p1=head;
    while(p1!=NULL)
    {
        p1=p1->next;
        if(p1->x==flood.x&&p1->y==flood.y)
        return 1;
    }
    return 0;
}
void F_flood()
{
    struct snake *p1;
    randomize();
    flood.x=(random(28)+4)*10;
    flood.y=(random(40)+3)*10;
    while(chongfu()==1)
    {   flood.x=(random(28)+4)*10;
        flood.y=(random(40)+3)*10;
    }
    flood.z=1;
    setfillstyle(1,RED);
    bar(flood.x,flood.y,flood.x+fat,flood.y+fat);
    setcolor(GREEN);
    rectangle(flood.x,flood.y,flood.x+fat,flood.y+fat);
}



int jieguo()
{
    struct snake *p1,*p2;
    int a=1;
    p1=head;
    while(p1!=NULL)
    {
        p1=p1->next;
        if(head->x==p1->x && head->y==p1->y)
        {a=0;return a;}
    }
    p1=head;
    if(p1->x<leftx+10 || p1->x>=rightx-10 || p1->y<lefty+10 || p1->y>=righty-10)
    {a=0;return a;}


    return a;


}




void main()
{
    int press,tune;
    initgr();
    beijing();
    initsnake();
    gsnake();
    setcolor (RED);
    outtextxy(350,410,"xing yi long ");
    outtextxy(350,430,"QQ 535466181");

    while((press=bioskey(!kbhit()))!=ESC)
    {
       if(flood.z==0)F_flood();
       switch(press)
       {
          case UP:   up();  break;
          case DOWN: down(); break;
          case LEFT: left(); break;
          case RIGHT:right();break;
          default: self();break;

       }
       delay(DELAY);delay(DELAY);delay(DELAY);delay(DELAY);
       if(jieguo()==0)
       {
            printf("\t\t\t\t\t    score    %d",flood.count);
            setcolor(WHITE);
            outtextxy(360,310,"GAME OVER");
            tune=2700;
            while(1)
            {
                if(tune>=1000)
                {
                    sound(tune);tune=tune-300;delay(100000);delay(100000);delay(100000);delay(100000);delay(100000);delay(100000); }
                    else nosound();
                    if((press=bioskey(!kbhit()))==ESC) goto here;

            }
        }

    }
    here:;

}
















