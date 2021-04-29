<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciList.aspx.cs" Inherits="Metin.Web.KullaniciList" %>

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
        <h1 class="h3 mb-4 text-gray-800">User Definition</h1>

    </div>

    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:Label ID="lblMessage" runat="server" CssClass="baslik"></asp:Label>
            </td>

            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style4"></td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style2">
                <asp:Label ID="Label1" runat="server" CssClass="baslik">Personnel</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:DropDownList ID="ddlPersonnel" runat="server" Width="200px" CssClass="dropdown">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="ddlPersonnel" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0">*</asp:CompareValidator>
            </td>

            <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2">
                <asp:Label ID="Label0" runat="server" CssClass="baslik">User Name</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:TextBox ID="txtKullaniciKodu" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKullaniciKodu" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>

            <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5"></td>
            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label" runat="server" CssClass="baslik">Password</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style7">
                <asp:TextBox ID="txtSifre" runat="server" CssClass="textbox" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSifre" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>

            <td align="left" valign="middle" class="auto-style6">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label2" runat="server" CssClass="baslik">Password Control</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style7">
                <asp:TextBox ID="txtSifreTekrar" runat="server" CssClass="textbox" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSifreTekrar" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>

            <td align="left" valign="middle" class="auto-style6">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style6">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style7">&nbsp;</td>

            <td align="left" valign="middle" class="auto-style6">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style3">&nbsp;<asp:Button ID="imbSave" runat="server" Text="Save" ValidateRequestMode="Disabled" OnClick="imbSave_Click" CssClass="btn btn-primary" />
                &nbsp;&nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="imbCancel_Click" CssClass="btn btn-primary" />
            </td>

            <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style4">&nbsp;</td>
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
                <asp:GridView ID="tgKullanici" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnRowCommand="tgKullanici_RowCommand" OnSelectedIndexChanged="tgKullanici_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="department_id" HeaderText="Kullanici ID" Visible="False" />
                        <asp:BoundField DataField="personnel_full_name" HeaderText="Personnel Name" />
                        <asp:BoundField HeaderText="User Name" DataField="kullanici_kodu" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="btnDelete">
                            <ControlStyle CssClass="btn btn-danger btn-sm"></ControlStyle>
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                            <ControlStyle CssClass="btn btn-primary btn-sm"></ControlStyle>
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
