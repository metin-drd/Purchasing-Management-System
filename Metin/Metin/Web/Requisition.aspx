<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="Requisition.aspx.cs" Inherits="Metin.Web.Requisition" %>

<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register Src="~/Web/UserControls/ucFile.ascx" TagPrefix="uc1" TagName="ucFile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function CalculateItemTotalPrice(txtUnitPrice, txtQuantity, txtItemTotalPrice) {

            document.getElementById(txtItemTotalPrice).value = (parseFloat(nanCheck(document.getElementById(txtUnitPrice).value.replace(",", "."))) * parseFloat(nanCheck(document.getElementById(txtQuantity).value.replace(",", ".")))).toFixed(2);
        }

        function nanCheck(val) {
            return (isNaN(val) || val == '') ? 0 : val;
        }
    </script>

    <script type="text/javascript">
        function isFloatNumber(e, t) {
            var n;
            var r;
            if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {
                n = t.keyCode;
                r = 1;
                if (navigator.appName == "Netscape") {
                    n = t.charCode;
                    r = 0
                }
            } else {
                n = t.charCode;
                r = 0
            }
            if (r == 1) {
                if (!(n >= 48 && n <= 57 || n == 46)) {
                    t.returnValue = false
                }
            } else {
                if (!(n >= 48 && n <= 57 || n == 0 || n == 46)) {
                    t.preventDefault()
                }
            }
        }
        
   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">Requisition</h1>

    </div>


    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="baslik"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel1" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" ExternalResourcePath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                UseExternalResource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Requisition">
                <table cellspacing="0" cellpadding="0" width="800" border="0">
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label8" runat="server" CssClass="baslik">Request Personnel</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:Label ID="lblPersonnelName" runat="server" CssClass="icerik"></asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label1" runat="server" CssClass="baslik">Status</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:Label ID="lblStatusName" runat="server" CssClass="icerik"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px"></td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label0" runat="server" CssClass="baslik">Request Date</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <ew:CalendarPopup ID="dpRequestDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
                                <TextBoxLabelStyle CssClass="dpTextBoxLabel" />
                                <WeekdayStyle CssClass="dpWeekday" />
                                <MonthHeaderStyle CssClass="dpMonthHeader" />
                                <OffMonthStyle CssClass="dpOffMonth" />
                                <ButtonStyle CssClass="dpButton" />
                                <GoToTodayStyle CssClass="dpGoToday" />
                                <TodayDayStyle CssClass="dpToday" />
                                <DayHeaderStyle CssClass="dpDayHeader" />
                                <WeekendStyle CssClass="dpWeekend" />
                                <SelectedDateStyle CssClass="dpSelectedDate" />
                                <ClearDateStyle CssClass="dpClearDate" />
                                <HolidayStyle CssClass="dpHoliday" />
                            </ew:CalendarPopup>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label6" runat="server" CssClass="baslik">Purchased Date</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <ew:CalendarPopup ID="dpPurchasedDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
                                <TextBoxLabelStyle CssClass="dpTextBoxLabel" />
                                <WeekdayStyle CssClass="dpWeekday" />
                                <MonthHeaderStyle CssClass="dpMonthHeader" />
                                <OffMonthStyle CssClass="dpOffMonth" />
                                <ButtonStyle CssClass="dpButton" />
                                <GoToTodayStyle CssClass="dpGoToday" />
                                <TodayDayStyle CssClass="dpToday" />
                                <DayHeaderStyle CssClass="dpDayHeader" />
                                <WeekendStyle CssClass="dpWeekend" />
                                <SelectedDateStyle CssClass="dpSelectedDate" />
                                <ClearDateStyle CssClass="dpClearDate" />
                                <HolidayStyle CssClass="dpHoliday" />
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label9" runat="server" CssClass="baslik">Responsible Dept</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:DropDownList ID="ddlResponsibleDepartment" CssClass="dropdown" runat="server" Width="152px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="ddlResponsibleDepartment" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0">*</asp:CompareValidator>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label10" runat="server" CssClass="baslik">Total Price</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px;" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px"></td>
                        <td align="left" valign="top" style="height: 25px; width: 150px">
                            <asp:Label ID="Label7" runat="server" CssClass="baslik">Comment</asp:Label>
                        </td>
                        <td align="left" valign="middle" colspan="3">
                            <asp:TextBox ID="txtComment" runat="server" CssClass="textbox" Width="540px" Height="54px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel2" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" ExternalResourcePath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                UseExternalResource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Items">
                <table cellspacing="0" cellpadding="0" width="800" border="0">
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label11" runat="server" CssClass="baslik">Stock Category</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:DropDownList ID="ddlStockCategory" CssClass="dropdown" runat="server" Width="165px" OnSelectedIndexChanged="ddlStockCategory_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator0" runat="server" ControlToValidate="ddlStockCategory" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0" ValidationGroup="item">*</asp:CompareValidator>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label13" runat="server" CssClass="baslik">Stock</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:DropDownList ID="ddlStock" CssClass="dropdown" runat="server" Width="165px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlStock" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0" ValidationGroup="item">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label12" runat="server" CssClass="baslik">Unit Price</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:TextBox ID="txtUnitPrice" runat="server" onkeypress="return isFloatNumber(this,event);" CssClass="textbox" Width="80px"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label14" runat="server" CssClass="baslik">Quantity</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:TextBox ID="txtQuantity" runat="server" onkeypress="return isFloatNumber(this,event);" CssClass="textbox" Width="80px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">
                            <asp:Label ID="Label16" runat="server" CssClass="baslik">Total Price</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:TextBox ID="txtItemTotalPrice" runat="server" CssClass="textbox" Width="80px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">
                            <asp:Button ID="imbItemSave" runat="server" class="btn btn-primary" OnClick="imbItemSave_Click" Text="Save" ValidationGroup="item" />
                            &nbsp;<asp:Button ID="imbItemCancel" runat="server" class="btn btn-primary" OnClick="imbItemCancel_Click" Text="Cancel" CausesValidation="False" />
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 240px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px;" colspan="4">
                            <asp:GridView ID="tgRequisitionItem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" Width="741px" OnSelectedIndexChanged="tgRequisitionItem_SelectedIndexChanged" OnRowCommand="tgRequisitionItem_RowCommand">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="requisition_item_id" HeaderText="RequisitionItemID" Visible="False" />
                                    <asp:BoundField DataField="stock_name" HeaderText="Stock Name" />
                                    <asp:BoundField DataField="unit_price" HeaderText="Unit Price" />
                                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                                    <asp:ButtonField ButtonType="Button" CommandName="btnDelete" Text="Delete" ControlStyle-CssClass="btn btn-danger btn-sm">
                                        <HeaderStyle Width="50px" />
                                    </asp:ButtonField>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary btn-sm">
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
                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>



        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel3" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" ExternalResourcePath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                UseExternalResource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Files">
                <table cellspacing="0" cellpadding="0" width="800" border="0">
                    <tr>
                        <td>
                            <uc1:ucFile ID="ucFile1" runat="server" />
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>


        <tr>
            <td height="25" style="height: 25px">&nbsp;
            </td>
        </tr>

        <tr>
            <td align="center" height="25" style="height: 25px" valign="middle">
                <asp:Button ID="imbPurchase" runat="server" Text="Purchase" OnClick="imbPurchase_Click" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbApprove" runat="server" Text="Approve" OnClick="imbApprove_Click" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbReject" runat="server" Text="Reject" OnClick="imbReject_Click" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbSave" runat="server" OnClick="imbSave_Click" Text="Save" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbSaveAndExit" runat="server" OnClick="imbSaveAndExit_Click" Text="Save &amp; Exit" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" OnClick="imbCancel_Click" Text="Cancel" CausesValidation="False" class="btn btn-primary" />
                &nbsp;<asp:Button ID="imbDeleteAndExit" runat="server" OnClick="imbDeleteAndExit_Click" Text="Delete &amp; Exit" CausesValidation="False" class="btn btn-danger" />
            </td>

        </tr>
    </table>
</asp:Content>
