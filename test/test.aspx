<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="test.test" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 56px;
        }
    </style>
    <script src="https://airisutech.net/wp-content/js/js-test/p5.js"></script>
    <script src="https://airisutech.net/wp-content/js/js-test/p5.sound.min.js"></script>
    <script src="https://airisutech.net/wp-content/js/js-test/sketch.js"></script>
            
</head>

<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"/>

        <p>
            CompanyID<input id="input_CompID" type="text" runat="server"/>MobileID<input id="input_CustID" type="text" runat="server"/><asp:Button ID="Button1" runat="server" OnClick="btn_search_CLick" Text="search" />
        </p>
        <p>
            <asp:ListBox ID="ListBox1" runat="server" Height="240px" Width="310px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <asp:Image ID="originalImg" runat="server" Height="240px" Width="320px" />
            <asp:Label ID="lab_Irise" runat="server" Text="Irise"></asp:Label>
        </p>
        <p>
                
       <!--Image inoutside-->
            <asp:Button ID="in_outsidecircle" runat="server" OnClick="in_outsidecircle_Click" Text="analysis"  />
            <asp:Label ID="lab_originalImg" runat="server" Text="image"></asp:Label>
            <asp:Button ID="btn_hsv" runat="server" OnClick="btn_hsv_Click" Text="hsv"  />
        </p>
        <p>
                
      <asp:Image runat="server" ID="ImgInsidecircle2" Width="320" Height="240" />
            <asp:Chart ID="Insidecircle2_ChartArea"  runat="server" Height="240px" Width="320px">
                <series>
                    <asp:Series Name="Series1" Legend="insidecircle"   >
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1"  >
                    </asp:ChartArea>
                </chartareas>

            </asp:Chart>
            <asp:ListBox ID="ListBox2" runat="server" Height="237px" Width="245px"></asp:ListBox>
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="205px">
            Mean:<asp:Label ID="lab_mean" runat="server" Text="Label"></asp:Label>
            <br />
            Var:<asp:Label ID="lab_var" runat="server" Text="Label"></asp:Label>
            <br />
            <span style="color: rgb(32, 33, 36); font-family: arial, sans-serif-light, sans-serif; font-size: 24px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Standard deviation</span>:<asp:Label ID="lab_StaDev" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </asp:Panel>

        <p>
                
      <asp:Image runat="server" ID="img1" Width="320" Height="240" />
                <!--Image  Area0-->
                hsv<asp:Image runat="server" ID="ImgArea0" Width="320" Height="240" />
                <!--Image  Area1-->
                &nbsp;
                
        </p>
        <p>
                
                <input type="range" min="0" max="255" step="1" value="50" id="input_hsvbar" formmethod="get" runat="server" onchange="updateCannyImg(this.value)" oninput =" updateTextInput(this.value)"  />
            <asp:Label ID="input_hsvbar_text" runat="server" Text="50"></asp:Label>
        </p>
        <p>
                
                <input type="range" min="0" max="255" step="1" value="50" id="input_hsvbar0" formmethod="get" runat="server"    />  
            <asp:Label ID="lab_hsv0" runat="server" Text="50"></asp:Label>
        </p>
        <p>
                
                <input type="range" min="0" max="255" step="1" value="50" id="input_hsvbar1" formmethod="get" runat="server"   />  
            <asp:Label ID="lab_hsv1" runat="server" Text="50"></asp:Label>
        </p>
        <p>
                
                <input type="range" min="0" max="255" step="1" value="50" id="input_hsvbar2" formmethod="get" runat="server"  />  
            <asp:Label ID="lab_hsv2" runat="server" Text="50"></asp:Label>
        </p>
        <p>
                
            &nbsp;</p>
        <p>
                
            <asp:Image runat="server" ID="ImgArea1" Width="320" Height="240" />
                <!--Image  Area2-->
                2<asp:Image runat="server" ID="ImgArea2" Width="320" Height="240" />
                <!--Image  Area3-->
                3<asp:Image runat="server" ID="ImgArea3" Width="320" Height="240" />
                <!--Image  Area4-->
                4<asp:Image runat="server" ID="ImgArea4" Width="320" Height="240" />
                <!--Image  Area5-->
                5<asp:Image runat="server" ID="ImgArea5" Width="320" Height="240" />
        </p>
                <p>
                <!--Image  Area6-->
                6<asp:Image runat="server" ID="ImgArea6" Width="320" Height="240" />
                <!--Image  Area7-->
                7<asp:Image runat="server" ID="ImgArea7" Width="320" Height="240" />
                <!--Image  Area8-->
                8<asp:Image runat="server" ID="ImgArea8" Width="320" Height="240" />
                <!--Image  Area9-->
                9<!--Image  Area10-->10<!--Image  Area11-->11<asp:Image runat="server" ID="ImgArea11" Width="320" Height="240" />
        </p>

    </form>
</body>
        <script src="https://airisutech.net/wp-content/js/dbconnect.js"></script>
            <script type="text/javascript">     
                function updateTextInput(val) {
                    document.getElementById('input_hsvbar_text').innerHTML = val;
                    
                }
                function updateCannyImg(val) {
                    
                    document.getElementById("btn_hsv").click();
                    
                }
                function hsvfocusout(val) {

                }
            </script> 

</html>


