<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="M3gogo.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>Club Representative Page</h1>
    <br />
    <form id="form1" runat="server" enableviewstate="false">
        <div id="signup" runat="server">
            <br />
            Name
            <br />
            <asp:TextBox runat="server" id="name"></asp:TextBox>
                        <br />
            Club Name
            <br />
            <asp:TextBox runat="server" id="clubName"></asp:TextBox>
                        <br />
            Username
            <br />
            <asp:TextBox runat="server" id="username"></asp:TextBox>
                        <br />
            Password
            <br />
            <asp:TextBox runat="server" id="password"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="submit" OnClick="signUp" Text="Register!" />
        </div>
                <div id="login" runat="server">
            <br />
            Username
            <br />
            <asp:TextBox runat="server" id="TextBox6"></asp:TextBox>
                        <br />
            Password
            <br />
            <asp:TextBox runat="server" id="TextBox7"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="Button1" OnClick="loginF" Text="Login" />
        </div>

      <div id="others" runat="server">

    <h4>Club Info</h4>
    <asp:DataGrid id="itemsGrid" runat="server"></asp:DataGrid>
     <h4>Upcoming Matches</h4>
    <asp:DataGrid id="itemsGrid2" runat="server"></asp:DataGrid>

            <div id="stadiums" runat="server">
            <br />
            DateTime
            <br />
            <asp:TextBox runat="server" ID="textBox2" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="Button2" OnClick="getStadiums" Text="show stadiums" />
                    <asp:DataGrid EnableViewState="false" id="itemsGrid3" runat="server"></asp:DataGrid>
        </div>

    <h4>Make Host Request</h4>
                    <br />
            DateTime
            <br />
            <asp:TextBox runat="server" ID="textBox3" TextMode="DateTimeLocal"></asp:TextBox>
                            <br />
            StadiumName
            <br />
            <asp:TextBox runat="server" ID="textBox4"></asp:TextBox>
                    <br />
            <asp:Button runat="server" ID="Button3" OnClick="submitRequest" Text="Submit Request" />
          </div>
            </form>
</body>
</html>

