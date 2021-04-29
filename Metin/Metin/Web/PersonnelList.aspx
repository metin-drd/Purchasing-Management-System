<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonnelList.aspx.cs" Inherits="Metin.Web.PersonnelList" %>
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
        .auto-style5 {
            width: 20px;
            height: 24px;
        }
        .auto-style6 {
            width: 130px;
            height: 24px;
        }
        .auto-style7 {
            width: 250px;
            height: 24px;
        }
        .auto-style8 {
            width: 270px;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">Personnel List</h1>

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
                <asp:Label ID="Label0" runat="server" CssClass="baslik">Name</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label1" runat="server" CssClass="baslik">Surname</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                <asp:TextBox ID="txtSurname" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5"></td>
            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label" runat="server" CssClass="baslik">Department</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style7">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="dropdown" Width="200px">
                </asp:DropDownList>
                </td>

            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label2" runat="server" CssClass="baslik">Is Active</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style8">
                <asp:CheckBox ID="cbxIsActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style6">
                &nbsp;</td>
            <td align="left" valign="middle" class="auto-style7">
                &nbsp;</td>

            <td align="left" valign="middle" class="auto-style6">
                &nbsp;</td>
            <td align="left" valign="middle" class="auto-style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2">
                </td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:Button ID="imbSearch" runat="server" Text="Search" OnClick="imbSearch_Click" CausesValidation="False" ValidateRequestMode="Disabled" class="btn btn-primary"/>
            &nbsp;<asp:Button ID="imbClear" runat="server" Text="Clear" OnClick="imbClear_Click" CausesValidation="False" ValidateRequestMode="Disabled" class="btn btn-primary"/>
            &nbsp;<asp:Button ID="imbNew" runat="server" Text="New" OnClick="imbNew_Click" CausesValidation="False" ValidateRequestMode="Disabled" class="btn btn-primary"/>
            &nbsp;</td>

            <td align="left" valign="middle" class="auto-style2">
                &nbsp;</td>
            <td align="left" valign="middle" class="auto-style4">
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
                <asp:GridView ID="tgPersonnel" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnSelectedIndexChanged="tgPersonnel_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="personnel_id" HeaderText="PersonnelId" Visible="False" />
                        <asp:BoundField DataField="tc_no" HeaderText="Tc No" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="Surname" HeaderText="Surname" />
                        <asp:BoundField DataField="rank_name" HeaderText="Rank" />
                        <asp:BoundField DataField="department_name" HeaderText="Department" />
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
            <td align="left" valign="middle" style="height: 25px; " colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
