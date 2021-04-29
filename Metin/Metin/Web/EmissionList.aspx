<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmissionList.aspx.cs" Inherits="Metin.Web.EmissionList" %>

<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register Src="~/Web/UserControls/ucFile.ascx" TagPrefix="uc1" TagName="ucFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="baslik"></asp:Label>
            </td>
        </tr>

        <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel1" runat="server" Width="800px" Collapsed="False"
            TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
            useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
            TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
            ExpandText="Open" CollapseText="Close" TitleText="Emission List">
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
                        <asp:DropDownList ID="ddlVessel" runat="server" CssClass="dropdown" Width="300px">
                        </asp:DropDownList>
                    </td>

                    <td align="left" valign="middle" class="auto-style6"></td>
                    <td align="left" valign="middle" class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 130px">
                        <asp:Label ID="Label0" runat="server" CssClass="baslik">Date Range</asp:Label>
                    </td>
                    <td align="left" valign="middle" style="height: 25px; width: 250px">
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

                    <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1"></td>
                    <td align="left" valign="middle" class="auto-style2">
                        <asp:Label ID="Label1" runat="server" CssClass="baslik">Country</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style3" colspan="2">
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox" Width="340px"></asp:TextBox>
                    </td>

                    <td align="left" valign="middle" class="auto-style4"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1"></td>
                    <td align="left" valign="middle" class="auto-style2">
                        <asp:Label ID="Label4" runat="server" CssClass="baslik">Port</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style3" colspan="2">
                        <asp:TextBox ID="txtPort" runat="server" CssClass="textbox" Width="340px"></asp:TextBox>
                    </td>

                    <td align="left" valign="middle" class="auto-style4"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px;" colspan="3">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center" class="auto-style1" valign="middle"></td>
                    <td align="left" class="auto-style2" valign="middle"></td>
                    <td align="left" class="auto-style3" valign="middle">
                        <asp:Button ID="imbSearch" runat="server" CausesValidation="False" OnClick="imbSearch_Click" Text="Search" ValidateRequestMode="Disabled" />
                        &nbsp;<asp:Button ID="imbClear" runat="server" CausesValidation="False" Text="Clear" ValidateRequestMode="Disabled" OnClick="imbClear_Click" />
                        &nbsp;<asp:Button ID="imbNew" runat="server" CausesValidation="False" Text="New" ValidateRequestMode="Disabled" OnClick="imbNew_Click" />
                        &nbsp;</td>
                    <td align="left" class="auto-style2" valign="middle">&nbsp;</td>
                    <td align="left" class="auto-style4" valign="middle">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style9">&nbsp;</td>

                    <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="5" style="height: 25px;" valign="middle">
                        <asp:GridView ID="tgEmission" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" Width="741px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="emission_id" Visible="False" DataField="emission_id" />
                                <asp:BoundField HeaderText="Report No" DataField="report_no" />
                                <asp:BoundField HeaderText="Vessel" DataField="vessel_name" />
                                <asp:BoundField HeaderText="Departure Date" DataField="departure_left_berth_date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                                    <HeaderStyle Width="50px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" Font-Bold="True" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="False" ForeColor="White" />
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
                    <td align="center" valign="middle" style="height: 25px;">&nbsp;</td>
                </tr>

            </table>
        </ew:CollapsablePanel>
        </td>
        </table>
</asp:Content>
