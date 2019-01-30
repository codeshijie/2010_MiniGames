<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="五子棋._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel="Stylesheet" href="Stylesheet1.css" />

<script type="text/javascript" src="JScript1.js"> </script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <div class="board">

        <script type="text/javascript">
                initBoard();
                
        </script>

    </div>
    
  
        <ul class="init" >
            <li onclick="initptoporptob('ptop', this)">人对人</li>
            <li onclick="initptoporptob('ptob', this)">人对机</li>
        </ul>
    
</body>
</html>
