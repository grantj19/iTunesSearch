<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iTunesSearch.aspx.cs" Inherits="Part1.View.ITunesSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;Search:<br />
&nbsp;<asp:TextBox ID="searchTbx" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:DropDownList ID="searchDdl" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
            <br />
        </div>
    </form>
</body>
</html>
