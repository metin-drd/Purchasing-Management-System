<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="Personnel.aspx.cs" Inherits="Metin.Web.Personnel" %>

<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

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
        <h1 class="h3 mb-4 text-gray-800">Personnel</h1>

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
            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">&nbsp;</td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
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
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label2" runat="server" CssClass="baslik">TC No</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtTcNo" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label3" runat="server" CssClass="baslik">Rank</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">
                <asp:DropDownList ID="ddlRank" CssClass="dropdown" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" class="auto-style1"></td>
            <td align="left" valign="middle" class="auto-style2">
                <asp:Label ID="Label4" runat="server" CssClass="baslik">Department</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style3">
                <asp:DropDownList ID="ddlDepartment" CssClass="dropdown" runat="server">
                </asp:DropDownList>
            </td>

            <td align="left" valign="middle" class="auto-style2">
                <asp:Label ID="Label5" runat="server" CssClass="baslik">Phone Number</asp:Label>
            </td>
            <td align="left" valign="middle" class="auto-style4">
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label6" runat="server" CssClass="baslik">Email</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            </td>

            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label7" runat="server" CssClass="baslik">Home Address</asp:Label>
            </td>
            <td rowspan="3" align="left" valign="middle" style="height: 25px; width: 270px">
                <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="textbox" Width="200px" Height="54px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label8" runat="server" CssClass="baslik">Firm Date</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                            <ew:CalendarPopup ID="dpFirmDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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

            <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
            <td align="left" valign="middle" style="height: 25px; width: 130px">
                <asp:Label ID="Label9" runat="server" CssClass="baslik">Quit Date</asp:Label>
            </td>
            <td align="left" valign="middle" style="height: 25px; width: 250px">
                            <ew:CalendarPopup ID="dpQuitDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
            <td align="center" valign="middle" style="height: 25px;" colspan="5">
                <asp:Button ID="imbSave" runat="server" OnClick="imbSave_Click" Text="Save" class="btn btn-primary" />
                &nbsp;
                <asp:Button ID="imbSaveAndExit" runat="server" class="btn btn-primary" OnClick="imbSaveAndExit_Click" Text="Save &amp; Exit" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" class="btn btn-primary" OnClick="imbCancel_Click" Text="Cancel" />
                &nbsp;<asp:Button ID="imbDeleteAndExit" class="btn btn-danger" runat="server" OnClick="imbDeleteAndExit_Click" Text="Delete &amp; Exit" />
            </td>
        </tr>
    </table>

</asp:Content>
