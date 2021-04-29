<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciRol.aspx.cs" Inherits="Metin.Web.KullaniciRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">User Rol Defination</h1>

    </div>

      <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:Label ID="lblMessage" runat="server" CssClass="baslik"></asp:Label>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label" runat="server" CssClass="baslik">User </asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:DropDownList ID="ddlKullanici" CssClass="dropdown" runat="server" Width="150px">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="ddlKullanici" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0">*</asp:CompareValidator>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label0" runat="server" CssClass="baslik">Role</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:DropDownList ID="ddlRol" CssClass="dropdown" runat="server" Width="150px">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator0" runat="server" ControlToValidate="ddlRol" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0">*</asp:CompareValidator>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                &nbsp;</td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:Button ID="imbSave" runat="server" Text="Add" OnClick="imbSave_Click" class="btn btn-primary" />              
            &nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="imbCancel_Click" />
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                &nbsp;</td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                &nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; " colspan="4">
                <asp:GridView ID="tgKullaniciRol" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnRowCommand="tgKullaniciRol_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="kullanici_rol_id" HeaderText="Kullanici Rol ID" Visible="False" />
                        <asp:BoundField DataField="personnel_full_name" HeaderText="User" />
                        <asp:BoundField DataField="rol_name" HeaderText="Role" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="btnDelete" ControlStyle-CssClass="btn btn-danger btn-sm">
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
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
            <td align="left" valign="middle" style="height: 25px; " colspan="4">
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
