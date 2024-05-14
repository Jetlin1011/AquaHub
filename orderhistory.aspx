<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderhistory.aspx.cs" Inherits="Aquahub.orderhistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h3          class="text-info text-center"> Your Orders</h3>
            <br />
            <br />
            <br />
            <br />
            <br />
                        <asp:Button CssClass="ml-5 btn btn-danger align-right" ID="Button2" runat="server" OnClick="Button1_Click" Text="Home" />

            <asp:GridView CssClass="table table-striped container" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="1258px">
                <Columns>
                    <asp:TemplateField HeaderText="No">
                        <ItemTemplate>
                <asp:Label ID="lblIndex" runat="server"></asp:Label>
            </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:BoundField DataField="order_id" HeaderText="Order No" />
                    <asp:BoundField DataField="p_name" HeaderText="Item" />
                    <asp:BoundField DataField="p_price" HeaderText="Price per unit" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="totalprice" HeaderText="Total Price" />
                </Columns>
            </asp:GridView>
        &nbsp;
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
