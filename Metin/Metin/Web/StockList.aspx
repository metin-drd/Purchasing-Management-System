<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="StockList.aspx.cs" Inherits="Metin.Web.StockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 20px;
            height: 25px;
        }

        .auto-style2 {
            width: 130px;
            height: 25px;
        }

        .auto-style3 {
            width: 250px;
            height: 25px;
        }

        .auto-style4 {
            width: 270px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">Stock Definition</h1>

    </div>

    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:Label ID="lblMessage" runat="server" CssClass="baslik"></asp:Label>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label" runat="server" CssClass="baslik">Stock Name</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtStockName" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStockName" ErrorMessage="sdss" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label0" runat="server" CssClass="baslik">Stock Category</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:DropDownList ID="ddlStockCategory" CssClass="dropdown" runat="server" Width="200px">
                </asp:DropDownList>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style3"></td>

            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style4"></td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:Button ID="imbSave" runat="server" Text="Add" OnClick="imbSave_Click" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" CausesValidation="False" class="btn btn-primary" ValidateRequestMode="Disabled" OnClick="imbCancel_Click" />
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">&nbsp;</td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px;" colspan="4">
                <asp:GridView ID="tgStock" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnSelectedIndexChanged="tgStock_SelectedIndexChanged" OnRowCommand="tgStock_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="stock_id" HeaderText="Stock ID" Visible="False" />
                        <asp:BoundField DataField="stock_name" HeaderText="Name" />
                        <asp:BoundField DataField="categoryname" HeaderText="Stock Category Name" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="btnDelete" ControlStyle-CssClass="btn btn-danger btn-sm">
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm">
                            <HeaderStyle Width="50px" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px;" colspan="4">&nbsp;</td>
        </tr>
    </table>

</asp:Content>
