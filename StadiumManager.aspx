<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="M3gogo.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>Stadium Manager Page</h1>
    <br />
    <form id="form1" runat="server" enableviewstate="false">
        <div id="signup" runat="server">
            <br />
            Name
            <br />
            <asp:TextBox runat="server" id="name"></asp:TextBox>
                        <br />
            Stadium Name
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
            <asp:TextBox runat="server" id="TextBox7"></asp:TextBox>
                        <br />
            Password
            <br />
            <asp:TextBox runat="server" id="TextBox8"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="Button2" OnClick="loginF" Text="Login" />
        </div>
              <div id="others" runat="server">

            <h4>Stadium Info</h4>
    <asp:DataGrid id="itemsGrid" runat="server"></asp:DataGrid>
             <h4>All Requests</h4>
    <asp:DataGrid id="itemsGrid2" runat="server"></asp:DataGrid>

         <h4>Accept Request</h4>
                    HostClubName
            <br />

            <asp:TextBox runat="server" ID="textBox1"></asp:TextBox>
                    <br />
                    GuestClubName
            <br />
            <asp:TextBox runat="server" ID="textBox3"></asp:TextBox>
                    <br />
            StartTime
            <br />
            <asp:TextBox runat="server" ID="textBox4" TextMode="DateTimeLocal"></asp:TextBox>
                            <br />

            <asp:Button runat="server" ID="Button3" OnClick="acceptRequest" Text="Accept Request" />

                 <h4>Accept Request</h4>
                    HostClubName
            <br />

            <asp:TextBox runat="server" ID="textBox2"></asp:TextBox>
                    <br />
                    GuestClubName
            <br />
            <asp:TextBox runat="server" ID="textBox5"></asp:TextBox>
                    <br />
            StartTime
            <br />
            <asp:TextBox runat="server" ID="textBox6" TextMode="DateTimeLocal"></asp:TextBox>
                            <br />

            <asp:Button runat="server" ID="Button1" OnClick="rejectRequest" Text="Reject Request" />
           </div>
                  </form>
</body>
</html>


