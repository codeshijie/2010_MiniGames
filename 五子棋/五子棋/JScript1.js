
//初始化参数
var r=17; //半径
var num=15; //列数
var precision=0.01 //圆形精度
var whiteorblock="block";
var boolBoard=new Array( );

var wait=true;
var finish=false;
var ptoporptob="ptop";

//浏览器判断
var myIE="";
myIE=myBrowser();


var xmlhttp;
if (window.XMLHttpRequest)
  {// code for IE7+, Firefox, Chrome, Opera, Safari
  xmlhttp=new XMLHttpRequest();
  }
else
  {// code for IE6, IE5
  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }





//初始化棋盘
function initBoard()
{
    for(var y=0;y<num;y++)
    {
         boolBoard[y]=new Array( );
        for(var x=0;x<num;x++)
        {
            document.write("<div class='elementbg' >");
            initelementbg(y,x);
            initelement(y,x);
            boolBoard[y][x]=0;
            document.write("</div>");
           
            
        }
    }
    
}


//初始化棋盘线
function initelementbg(y,x)
{
   document.write("<div class='line'>");

   if(y==0)
   { document.write("<p class='line11'></p>");}
   else
   {document.write("<p class='line1'></p>");}
   
   
   
   if(x==0)
   { document.write("<p class='line22'></p>");}
   else
   {document.write("<p class='line2'></p>");}
   
   
   document.write("<p class='line3'></p>");
   
   if(x==14)
   { document.write("<p class='line22'></p>");}
   else
   {document.write("<p class='line2'></p>");}
   
   if(y==14)
   { document.write("<p class='line11'></p>");}
   else
   {document.write("<p class='line1'></p>");}
   

   document.write("</div>");        
}


//初始化棋子
function initelement(y,x)
{
    document.write("<div class='element' id='y"+y+"x"+x+"'  onclick=\" clickgame(this , '"+y+"'  , '"+x+"')\">");


    
    document.write("</div>");

}


//初始化人机还是人人
function initptoporptob(to , doc)
{
    ptoporptob=to;
    wait=false;
    doc.parentNode.style.display="none";


}






//鼠标按下
function clickgame(doc,y,x)
{

    if(boolBoard[y][x]==0&& !wait && !finish)
    {

    
        switch(ptoporptob)
        {
        
            case "ptop": ptop(doc,y,x);  break;
            case "ptob": ptob(doc,y,x);break;
     
        
         }

           
       
    }

}


//人人对战
function ptop(doc,y,x)
{
     switch(whiteorblock)
     {
        case "block" :boolBoard[y][x]=1;break;
        case "white" :boolBoard[y][x]=2;break;
     }
    
     DrawRound(doc);

     iffinish(whiteorblock,y,x); 


}

//人机对战
function ptob(doc,y,x)
{
     wait=true;
      
     switch(whiteorblock)
     {
        case "block" :boolBoard[y][x]=1;break;
        case "white" :boolBoard[y][x]=2;break;
     }
     
     DrawRound(doc);

     iffinish(whiteorblock,y,x); 


     
      xmlhttp.onreadystatechange=function()
      {
          if (xmlhttp.readyState==4 && xmlhttp.status==200)
            {
               
               if(finish==false)
               {    
                     var docajaxxy=xmlhttp.responseText;
               
            
                     var xyarray= docajaxxy.split('y')[1].split('x');
         
                     switch(whiteorblock)
                     {
                        case "block" :boolBoard[xyarray[0]][xyarray[1]]=1;break;
                        case "white" :boolBoard[xyarray[0]][xyarray[1]]=2;break;
                     }

                    
                     DrawRound( document.getElementById(docajaxxy) );
                     
                     
                     iffinish(whiteorblock,xyarray[0],xyarray[1]); 
                     
                     

                     wait=false;
              }
                 
                 
            
            
            }
      }
    xmlhttp.open("GET","ptob.aspx?y="+y+"&x="+x,true);
    xmlhttp.send();



         
         
         
         

}




//画圆
function DrawRound(doc)
{
 
    var innerstr="";
    for(angle=Math.PI/2;angle<=Math.PI*1.5; angle=angle+precision)
    {
    
        if(myIE=="good")
        {innerstr += "<p class='pixel "+whiteorblock+"' style='width:"+   Math.abs( 2*r*(Math.cos(angle))  )+"px; height:"+  r* Math.abs(   Math.abs(Math.sin(angle-precision)) - Math.abs(Math.sin(angle))   ) +"px' ></p>";}
        else if(myIE="ie67")
        innerstr += "<p class='"+whiteorblock+"ie67'></p>";
    
    }
   
    doc.innerHTML=innerstr;

  
    
}




//判断结束
function iffinish(wholast,ylast,xlast)
{
    
    var who;

     switch(wholast)
     {
        case "block" :last=1;who="黑方获胜";break;
        case "white" :last=2;who="白方获胜";break;
     }

    
      var y=ylast;
      var x=xlast;
    


       //x轴判断
        var maxin=0;
        for(var x1=x; x1>=0&&x1>=x-4;x1--)
        {
       
            if(boolBoard[y][x1]==last)
            {
                maxin++;
            }
            else
            {
                break;
            }
            
        }
        for(var x1=x; x1<=14&&x1 <= x+4;x1++)
        {
            if(boolBoard[y][x1]==last)
            {
                maxin++;

            }
            else
            {
                break;
            }
        }
        if(maxin==6){ 

       wait=true;finish=true;  alert(who); return;}
        
        //y轴判断
        var maxin=0;
        for(var y1=y; y1>=0&&y1>=y-4;y1--)
        {
            if(boolBoard[y1][x]==last)
            {
                maxin++;
            }
            else
            {
                break;
            }
        }
        for(var y1=y; y1<=14&&y1<=y+4;y1++)
        {
            if(boolBoard[y1][x]==last)
            {
                maxin++;
            }
            else
            {
                break;
            }
        }
        if(maxin==6){ 

        wait=true;finish=true; alert(who); return;}
        
        
        
        //  \轴判断
        var maxin=0;
        for(var y1=y, x1=x; (y1>=0&&y1>=y-4)&&( x1>=0&&x1>=x-4);y1--,x1--)
        {
      
                if(boolBoard[y1][x1]==last)
                {
                    maxin++;
                }
                else
                {
                    break;
                }
           
        }
        for(var y1=y , x1=x; (y1<=14&&y1<=y+4)&&( x1<=14&&x1<=x+4);y1++,x1++)
        {
        
                if(boolBoard[y1][x1]==last)
                {
                    maxin++;
                }
                else
                {
                    break;
                }
            
        }
        if(maxin==6){ 

        wait=true;finish=true; alert(who); return;}
        
        
        //  /轴判断
        var maxin=0;
        for(var y1=y, x1=x; (y1>=0&&y1>=y-4)&&( x1<=14&&x1<=x+4);y1--,x1++)
        {
      
                if(boolBoard[y1][x1]==last)
                {
                    maxin++;
                }
                else
                {
                    break;
                }
           
        }
        for(var y1=y , x1=x; (y1<=14&&y1<=y+4)&&( x1>=0&&x1>=x-4);y1++,x1--)
        {
        
                if(boolBoard[y1][x1]==last)
                {
                    maxin++;
                }
                else
                {
                    break;
                }
            
        }
        
        if(maxin==6){ 

        wait=true;finish=true; alert(who); return;}

            
       whiteorblock = whiteorblock=="block"?"white":"block";  
         
}


function myBrowser(){
var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
var isOpera = userAgent.indexOf("Opera") > -1; //判断是否Opera浏览器
var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera ; //判断是否IE浏览器
var isFF = userAgent.indexOf("Firefox") > -1 ; //判断是否Firefox浏览器
var isSafari = userAgent.indexOf("Safari") > -1 ; //判断是否Safari浏览器
 
 
if(isIE){
   var IE5 = IE55 = IE6 = IE7 = IE8 = false;
   var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
   reIE.test(userAgent);
   var fIEVersion = parseFloat(RegExp["$1"]);
 

   IE6 = fIEVersion == 6.0 ;
   IE7 = fIEVersion == 7.0 ;


   if(IE6){ return "shit"; }
   else if(IE7){ return "shit"; }
   else return "good";

}//isIE end

 
}//myBrowser() end