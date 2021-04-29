<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="Metin.Web.DepartmentList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">Department Defination</h1>

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
                <asp:Label ID="Label" runat="server" CssClass="baslik">Department Name</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtName" runat="server" class="textbox" Width="250px"></asp:TextBox>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="sdss" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label0" runat="server" CssClass="baslik">Department Manager</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:DropDownList ID="ddlManagerPersonnel" CssClass="dropdown" runat="server" Width="250px">
                </asp:DropDownList>
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
            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:Button ID="imbSave" runat="server" Text="Add" OnClick="imbSave_Click"
                    CssClass="btn btn-primary" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" OnClick="imbCancel_Click" CssClass="btn btn-primary" CausesValidation="False" ValidateRequestMode="Disabled" />
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
                <asp:GridView ID="tgDepartment" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnSelectedIndexChanged="tgDepartment_SelectedIndexChanged" OnRowCommand="tgDepartment_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="department_id" HeaderText="Department ID" Visible="False" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="personnel_full_name" HeaderText="Manager" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="btnDelete" ControlStyle-CssClass="btn btn-danger btn-sm">
                            <ControlStyle CssClass="btn btn-danger btn-sm"></ControlStyle>

                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm ">
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
