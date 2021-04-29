<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="Emission.aspx.cs" Inherits="Metin.Web.Emission" %>

<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register Src="~/Web/UserControls/ucFile.ascx" TagPrefix="uc1" TagName="ucFile" %>

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
            height: 26px;
        }

        .auto-style6 {
            height: 26px;
        }

        .auto-style7 {
            width: 250px;
            height: 26px;
        }

        .auto-style8 {
            width: 270px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel1" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Emission Report">
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
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label" runat="server" CssClass="baslik">Vessel</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:Label ID="lblVesselName" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </td>

                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label1" runat="server" CssClass="baslik">Report No</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="txtReportNo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">&nbsp;</td>

                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                    </tr>



                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel2" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Monitor On Per-Voyage Basis">
                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label18" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Departure</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label19" runat="server" CssClass="baslik">Port</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3">
                            <asp:TextBox ID="txtDeparturePort" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>



                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label20" runat="server" CssClass="baslik">ATD/Left Berth (UTC)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <ew:CalendarPopup ID="dpDepartureLeftBerthDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                            <ew:TimePicker ID="tpDepartureLeftBerthTime" runat="server" ClearTimeText="Zamanı Sil" ControlDisplay="TextBoxImage" CssClass="tpStyle" DisableTextBoxEntry="False" ExternalResourcePath="~/js/eworld/eWorld_UI_TimePicker.js" ImageUrl="Images/time.gif" NullableLabelText="Zaman Seçiniz" NumberOfColumns="4" PopupLocation="Bottom" PopupWidth="167px" RoundUpMinutes="False" Text="..." UseExternalResource="True" Width="46px">
                                <ButtonStyle CssClass="tpButton" />
                                <TextBoxLabelStyle CssClass="tpTextboxLabel" />
                                <ClearTimeStyle BackColor="White" CssClass="tpClearTime" />
                                <TimeStyle BackColor="White" CssClass="tpTime" />
                                <SelectedTimeStyle BackColor="White" CssClass="tpSelectedTime" />
                            </ew:TimePicker>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label21" runat="server" CssClass="baslik">HSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtDeparture_hsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label24" runat="server" CssClass="baslik">LSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtDeparture_lsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label22" runat="server" CssClass="baslik">ULSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtDeparture_ulsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label23" runat="server" CssClass="baslik">LSMGO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtDeparture_lsmgo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>



                </table>

                <br />

                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label2" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Arrival</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label5" runat="server" CssClass="baslik">Port</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3">
                            <asp:TextBox ID="txtArrivalPort" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>



                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label25" runat="server" CssClass="baslik">ATA / All Fast (UTC)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <ew:CalendarPopup ID="dpArrivalAllFastDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                            <ew:TimePicker ID="tpArrivalAllFastTime" runat="server" ClearTimeText="Zamanı Sil" ControlDisplay="TextBoxImage" CssClass="tpStyle" DisableTextBoxEntry="False" ExternalResourcePath="~/js/eworld/eWorld_UI_TimePicker.js" ImageUrl="Images/time.gif" NullableLabelText="Zaman Seçiniz" NumberOfColumns="4" PopupLocation="Bottom" PopupWidth="167px" RoundUpMinutes="False" Text="..." UseExternalResource="True" Width="46px">
                                <ButtonStyle CssClass="tpButton" />
                                <TextBoxLabelStyle CssClass="tpTextboxLabel" />
                                <ClearTimeStyle BackColor="White" CssClass="tpClearTime" />
                                <TimeStyle BackColor="White" CssClass="tpTime" />
                                <SelectedTimeStyle BackColor="White" CssClass="tpSelectedTime" />
                            </ew:TimePicker>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label26" runat="server" CssClass="baslik">HSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtArrival_hsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label27" runat="server" CssClass="baslik">LSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtArival_lsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label28" runat="server" CssClass="baslik">ULSFO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtArrival_ulsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label29" runat="server" CssClass="baslik">LSMGO(ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtArrival_lsmgo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>



                </table>

                <br />

                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label3" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Bunker Stemmed</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label31" runat="server" CssClass="baslik">HSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:TextBox ID="txtDepartureStemmed_hsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label32" runat="server" CssClass="baslik">LSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="txtDepartureStemmed_lsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label33" runat="server" CssClass="baslik">ULSFO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtDepartureStemmed_ulsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label34" runat="server" CssClass="baslik">LSMGO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtDepartureStemmed_lsmgo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>

                </table>
                <br />
                <table cellspacing="0" cellpadding="0" width="800">

                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label30" runat="server" CssClass="baslik">Total Time At Sea</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="Label44" runat="server" CssClass="baslik">(hrs)</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label35" runat="server" CssClass="baslik">Total Anchorage Time</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="Label43" runat="server" CssClass="baslik">(hrs)</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label36" runat="server" CssClass="baslik">Total Steaming Hours</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="Label45" runat="server" CssClass="baslik">(hrs)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label38" runat="server" CssClass="baslik">Dis. Berth To Berth</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtDistanceBerthtoBerth" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <asp:Label ID="Label46" runat="server" CssClass="baslik">(NM)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label42" runat="server" CssClass="baslik">Laden / Baliast</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:DropDownList ID="ddlLadenBallast" runat="server" CssClass="dropdown" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label39" runat="server" CssClass="baslik">Type Of Cargo</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtTypeOfCargo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label41" runat="server" CssClass="baslik">Total Cargo On Board </asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtTotalCargoOnBoard" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <asp:Label ID="Label47" runat="server" CssClass="baslik">(M.Ton)</asp:Label>
                        </td>
                    </tr>
                </table>

                <br />

                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label4" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Consumption</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label37" runat="server" CssClass="baslik">HSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label40" runat="server" CssClass="baslik">LSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="TextBox11" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label48" runat="server" CssClass="baslik">ULSFO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="TextBox12" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label49" runat="server" CssClass="baslik">LSMGO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="TextBox13" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel3" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Monitor Within Port">
               <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            &nbsp;</td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label7" runat="server" CssClass="baslik">ATD/Left Berth(UTC)</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <ew:CalendarPopup ID="dpArrivalAllFastDate0" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                            <ew:TimePicker ID="tpArrivalAllFastTime0" runat="server" ClearTimeText="Zamanı Sil" ControlDisplay="TextBoxImage" CssClass="tpStyle" DisableTextBoxEntry="False" ExternalResourcePath="~/js/eworld/eWorld_UI_TimePicker.js" ImageUrl="Images/time.gif" NullableLabelText="Zaman Seçiniz" NumberOfColumns="4" PopupLocation="Bottom" PopupWidth="167px" RoundUpMinutes="False" Text="..." UseExternalResource="True" Width="46px">
                                <ButtonStyle CssClass="tpButton" />
                                <TextBoxLabelStyle CssClass="tpTextboxLabel" />
                                <ClearTimeStyle BackColor="White" CssClass="tpClearTime" />
                                <TimeStyle BackColor="White" CssClass="tpTime" />
                                <SelectedTimeStyle BackColor="White" CssClass="tpSelectedTime" />
                            </ew:TimePicker>
                        </td>
                        <td align="left" valign="middle" class="auto-style6">
                            &nbsp;</td>
                        <td align="left" valign="middle" class="auto-style8">
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label9" runat="server" CssClass="baslik">HSFO (ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtTypeOfCargo0" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label50" runat="server" CssClass="baslik">LSFO (ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtTypeOfCargo2" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label51" runat="server" CssClass="baslik">ULSFO (ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="txtTypeOfCargo1" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label52" runat="server" CssClass="baslik">LSMGO (ROB)</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="txtTypeOfCargo3" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>

                </table>
                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label8" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Bunker Stemmed</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">
                            <asp:Label ID="Label54" runat="server" CssClass="baslik">HSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">
                            <asp:Label ID="Label55" runat="server" CssClass="baslik">LSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label56" runat="server" CssClass="baslik">ULSFO </asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label57" runat="server" CssClass="baslik">LSMGO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>

                </table>

                <table cellspacing="0" cellpadding="0" width="800" style="border: 1px solid black;">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label6" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black">Consumption</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3"></td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label53" runat="server" CssClass="baslik">HSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:TextBox ID="TextBox14" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label58" runat="server" CssClass="baslik">LSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="TextBox15" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label59" runat="server" CssClass="baslik">ULSFO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:TextBox ID="TextBox16" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">
                            <asp:Label ID="Label60" runat="server" CssClass="baslik">LSMGO</asp:Label>
                        </td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">
                            <asp:TextBox ID="TextBox17" runat="server" CssClass="textbox" Width="100px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                </table>

            </ew:CollapsablePanel>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel4" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Total Consumption">
                <table cellspacing="0" cellpadding="0" width="800" border="0">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label61" runat="server" CssClass="baslik">HSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3">
                            <asp:TextBox ID="TextBox18" runat="server" CssClass="textbox" Enabled="False" Width="100px"></asp:TextBox>
                        </td>

                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label63" runat="server" CssClass="baslik">HSFO Sulphur%</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style4">
                            <asp:TextBox ID="TextBox22" runat="server" CssClass="txtSulphur_hsfo" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label11" runat="server" CssClass="baslik">LSFO</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style7">
                            <asp:TextBox ID="TextBox19" runat="server" CssClass="textbox" Enabled="False" Width="100px"></asp:TextBox>
                        </td>

                        <td align="left" valign="middle" class="auto-style6">
                            <asp:Label ID="Label13" runat="server" CssClass="baslik">LSFO Sulphur %</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style8">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="txtSulphur_lsfo" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">
                            <asp:Label ID="Label62" runat="server" CssClass="baslik">Ulsfo</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">
                            <asp:TextBox ID="TextBox20" runat="server" CssClass="textbox" Enabled="False" Width="100px"></asp:TextBox>
                        </td>

                        <td align="left" valign="middle" style="height: 25px; width: 130px">
                            <asp:Label ID="Label64" runat="server" CssClass="baslik">ULSFO Sulphur %</asp:Label>
                        </td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">
                            <asp:TextBox ID="txtSulphur_ulsfo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>



                    <tr>
                        <td align="center" class="auto-style1" valign="middle"></td>
                        <td align="left" class="auto-style2" valign="middle">
                            <asp:Label ID="Label65" runat="server" CssClass="baslik">LSMGO</asp:Label>
                        </td>
                        <td align="left" class="auto-style3" valign="middle">
                            <asp:TextBox ID="TextBox25" runat="server" CssClass="textbox" Enabled="False" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" class="auto-style2" valign="middle">
                            <asp:Label ID="Label66" runat="server" CssClass="baslik">LSMGO Sulphur%</asp:Label>
                        </td>
                        <td align="left" class="auto-style4" valign="middle">
                            <asp:TextBox ID="txtSulphur_lsmgo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
                    </tr>



                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel5" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Emission Report">
                <table cellspacing="0" cellpadding="0" width="800" border="0">

                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">
                            <asp:Label ID="lblFileMessage" runat="server" CssClass="baslik"></asp:Label>
                        </td>

                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" class="auto-style5"></td>
                        <td align="left" valign="middle" class="auto-style6" colspan="4">
                            <uc1:ucFile runat="server" ID="ucFile" />
                            </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">&nbsp;</td>

                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                    </tr>



                </table>
            </ew:CollapsablePanel>
            </td>
        </tr>

         <table cellspacing="0" cellpadding="0" width="800" border="0">

                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; text-align: center;">
                <asp:Button ID="imbSave" runat="server" Text="Save" CausesValidation="False" ValidateRequestMode="Disabled" />
                &nbsp;<asp:Button ID="imbSaveAndExit" runat="server" Text="Save And Exit" CausesValidation="False" ValidateRequestMode="Disabled" />
                &nbsp;<asp:Button ID="imbDelete" runat="server" Text="Delete" CausesValidation="False" ValidateRequestMode="Disabled" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" CausesValidation="False" ValidateRequestMode="Disabled" />
                        </td>
                    </tr>
</table>

    </table>

</asp:Content>
