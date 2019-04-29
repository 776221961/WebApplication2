<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="~/themes/icon.css">
	<link rel="stylesheet" type="text/css" href="~/themes/demo.css">
  
    <script src="Scripts/jquery.easyui.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
  <script>
		function start(){
			var value =1
			if (value < 100){
				value += Math.floor(Math.random() * 10);
				$('#p').text = value.toString();
				setTimeout(arguments.callee, 200);
			}
		};
	</script>
</head>
<body>
	<h2>Basic ProgressBar</h2>
	<p>Click the button below to show progress information.</p>
	<div style="margin:20px 0;">
		<a href="#" class="easyui-linkbutton" onclick="start()">Start</a>
	</div>
	<div id="div1" class="easyui-progressbar" style="width:400px;">
      <asp:Label Text="tt" ID="p" runat="server"></asp:Label>
	</div>
	
</body>
</html>
