<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="RequisitionReport.aspx.cs" Inherits="Metin.Web.RequisitionReport" %>

<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-4 text-gray-800">Requisition Report</h1>

    </div>

    <table border="0" cellpadding="0" cellspacing="0" width="800">
        <tr>
            <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 250px" valign="middle">
                <asp:Label ID="lblMessage" runat="server" CssClass="baslik"></asp:Label>
            </td>
            <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="auto-style1" valign="middle"></td>
            <td align="left" class="auto-style1" valign="middle">
                <asp:Label ID="Label0" runat="server" CssClass="baslik">Request Date</asp:Label>
            </td>
            <td align="left" class="auto-style1" valign="middle">
                        <ew:CalendarPopup ID="dpStartDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                &nbsp;-
                        <ew:CalendarPopup ID="dpEndDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
            <td align="left" class="auto-style1" valign="middle"></td>
            <td align="left" class="auto-style1" valign="middle"></td>
        </tr>
        <tr>
            <td align="center" class="auto-style5" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style6" valign="middle">
                <asp:Label ID="Label1" runat="server" CssClass="baslik">Report Type</asp:Label>
            </td>
            <td align="left" class="auto-style7" valign="middle">
                <asp:DropDownList ID="ddlDepartmentCategory" runat="server" CssClass="dropdown" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="left" class="auto-style6" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style8" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="auto-style5" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style6" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style7" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style6" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style8" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="auto-style1" valign="middle"></td>
            <td align="left" class="auto-style2" valign="middle"></td>
            <td align="left" class="auto-style3" valign="middle">
                <asp:Button ID="imbReport" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="imbReport_Click" Text="Report" ValidateRequestMode="Disabled" />
                &nbsp;&nbsp;&nbsp;</td>
            <td align="left" class="auto-style2" valign="middle">&nbsp;</td>
            <td align="left" class="auto-style4" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 250px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
            <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
            <td align="left" colspan="4" style="height: 25px;" valign="middle">
                <asp:GridView ID="tgRequisitionReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" Width="741px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField HeaderText="Total Price" DataField="total_price" />
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
            <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
            <td align="left" colspan="4" style="height: 25px;" valign="middle">&nbsp;</td>
        </tr>
    </table>


</asp:Content>
