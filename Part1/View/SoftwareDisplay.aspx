<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftwareDisplay.aspx.cs" Inherits="Part1.View.SoftwareDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="backBtn" runat="server" Text="<- Back" OnClick="backBtn_Click" /> <br/>

        <asp:DataList ID="musicDl" runat="server" CellPadding="4" ForeColor="#333333" RepeatDirection="Horizontal" RepeatColumns="5" HorizontalAlign="Left" OnItemCommand="DataList_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            
            <HeaderTemplate>
                Music Tracks
            </HeaderTemplate>

            <ItemTemplate>
                <div style="max-width: 10vw">
                    <b><%# DataBinder.Eval(Container.DataItem, "ArtistName") %> </b><br/>
                    <%# DataBinder.Eval(Container.DataItem, "Price") %><br />
                    <asp:Button runat="server" Text="More Info"></asp:Button>
                </div>
            </ItemTemplate>
            
            <SelectedItemTemplate>
                <div style="max-width: 25vw">
                    <div style="align-items: center"><b><%# DataBinder.Eval(Container.DataItem, "ArtistName") %> </b></div><br/><br/>
                    <b>Price: </b><%# DataBinder.Eval(Container.DataItem, "Price") %><br/><br/>
                    <b>Supported Devices: </b><%# DataBinder.Eval(Container.DataItem, "SupportedDevices") %><br /><br/>
                    <b>Description: </b><%# DataBinder.Eval(Container.DataItem, "Description") %><br /><br/>
                    <b>Genres: </b><%# DataBinder.Eval(Container.DataItem, "Genres") %><br /><br/>
                    <asp:Image runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ArtworkURL1") %>'/><br /><br/>
                    <asp:Image runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ArtworkURL2") %>'/><br />
                </div>
            </SelectedItemTemplate>

        </asp:DataList>
    </form>
</body>
</html>
