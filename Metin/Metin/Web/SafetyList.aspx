<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="SafetyList.aspx.cs" Inherits="Metin.Web.SafetyList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }

        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                <asp:Label ID="Label0" runat="server" CssClass="baslik">No</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtSafetyNo" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label1" runat="server" CssClass="baslik">Issued Date</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                <asp:TextBox ID="txtIssuedDate" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5"></td>
            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label" runat="server" CssClass="baslik">Vessel /Dep.</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style7" colspan="3">
                <asp:RadioButton ID="rdoVessel" runat="server" AutoPostBack="True" GroupName="VesselDep" OnCheckedChanged="rdoVessel_CheckedChanged" Text="Vessel" />
                &nbsp;
                <asp:RadioButton ID="rdoDepartment" runat="server" AutoPostBack="True" GroupName="VesselDep" OnCheckedChanged="rdoDepartment_CheckedChanged" Text="Department" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlVesselDepartment" runat="server" CssClass="dropdown" Width="200px">
                </asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style5">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style6">
                <asp:Label ID="Label2" runat="server" CssClass="baslik">Is Published</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style7" colspan="3">
                <asp:CheckBox ID="cbxIsPublished" runat="server" />
            </td>

        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style2" colspan="3"></td>

        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2"></td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:Button ID="imbSearch" runat="server" Text="Search" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="imbSearch_Click" />
                &nbsp;<asp:Button ID="imbClear" runat="server" Text="Clear" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="imbClear_Click" />
                &nbsp;<asp:Button ID="imbNew" runat="server" Text="New" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="imbNew_Click" />
                &nbsp;</td>

            <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
            <td align="left" valign="middle" class="auto-style4">
                <asp:Label ID="Label3" runat="server" CssClass="baslik">Adet = </asp:Label>
                &nbsp;<asp:Label ID="lblAdet" runat="server"></asp:Label>
            </td>
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
                <asp:GridView ID="tgSafety" runat="server" Width="741px" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" OnSelectedIndexChanged="tgSafety_SelectedIndexChanged" OnRowDataBound="tgSafety_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="safety_id" HeaderText="SafetyId" Visible="False" />
                        <asp:BoundField DataField="safety_no" HeaderText="No" />
                        <asp:BoundField DataField="issued_date" HeaderText="Issued Date" DataFormatString="{0:dd.MM.yyyy}" />
                        <asp:BoundField HeaderText="Vessel/Department" DataField="vessel_department" />
                        <asp:BoundField DataField="subject" HeaderText="Subject" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True">
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
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px;" colspan="4">
            <table width="350px">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblComment4" runat="server" CssClass="baslik" Font-Underline="True" Width="250px">Table of Color and Meanings</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 65%">
                        <asp:Label ID="lblComment1" runat="server" CssClass="baslik" ForeColor="Red">Unpublished</asp:Label>
                    </td>
                    <td style="width: 35%"></td>
                </tr>
            </table>

            &nbsp;</td>
        </tr>
    </table>


</asp:Content>
