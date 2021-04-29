<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.Master" AutoEventWireup="true" CodeBehind="Safety.aspx.cs" Inherits="Metin.Web.SafetyList" %>

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
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="800" border="0">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="baslik"></asp:Label>
            </td>
        </tr>


        <tr id="trGrid" runat="server">

            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel3" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Approved Vessels">
                <table cellspacing="0" cellpadding="0" width="800" border="0">

                    <tr>
                        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 250px">&nbsp;</td>

                        <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                        <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                    </tr>

                    <tr>
                        <td align="center" colspan="5" style="height: 25px;" valign="middle">
                            <asp:GridView ID="tgVesselApproval" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" Width="741px" OnSelectedIndexChanged="tgVesselApproval_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="vessel_approval_id" Visible="False" DataField="vessel_approval_id" />
                                    <asp:BoundField HeaderText="Vessel" DataField="vessel_name" />
                                    <asp:BoundField HeaderText="Comment" DataField="comment" />
                                    <asp:BoundField HeaderText="Closed Date" DataField="closed_date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                                        <HeaderStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="vessel_id" Visible="False" />
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
                    <tr id="trUnapprovedShips" runat="server">
                        <td align="center" colspan="5" style="height: 25px; padding-left: 15px; text-align: left;" valign="middle">
                            <asp:Label ID="lblUnapprovedShips" runat="server" CssClass="baslik"></asp:Label>
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






        <%-- ------------------------------------------------------------------ --%>


        <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel1" runat="server" Width="800px" Collapsed="False"
            TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
            useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
            TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
            ExpandText="Open" CollapseText="Close" TitleText="Best Practice">
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
                        <asp:Label ID="Label" runat="server" CssClass="baslik">No</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style7">
                        <asp:TextBox ID="txtSafetyNo" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSafetyNo" ErrorMessage="sdss" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>

                    <td align="left" valign="middle" class="auto-style6"></td>
                    <td align="left" valign="middle" class="auto-style8">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 130px">
                        <asp:Label ID="Label0" runat="server" CssClass="baslik">Issued Date</asp:Label>
                    </td>
                    <td align="left" valign="middle" style="height: 25px; width: 250px">
                        <ew:CalendarPopup ID="dpIssuedDate" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dpIssuedDate" ErrorMessage="sdss" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>

                    <td align="left" valign="middle" style="height: 25px; width: 130px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 270px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1"></td>
                    <td align="left" valign="middle" class="auto-style2">
                        <asp:Label ID="Label1" runat="server" CssClass="baslik">Vessel / Department</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style3" colspan="2">
                        <asp:RadioButton ID="rdoVessel" runat="server" AutoPostBack="True" GroupName="group1" OnCheckedChanged="rdoVessel_CheckedChanged" Text="Vessel" />
                        &nbsp;<asp:RadioButton ID="rdoDepartment" runat="server" AutoPostBack="True" GroupName="group1" OnCheckedChanged="rdoDepartment_CheckedChanged" Text="Department" />
                        &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlVesselDepartment" CssClass="dropdown" runat="server" Width="150px">
                </asp:DropDownList>
                        &nbsp;</td>

                    <td align="left" valign="middle" class="auto-style4"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1"></td>
                    <td align="left" valign="middle" class="auto-style2">
                        <asp:Label ID="Label4" runat="server" CssClass="baslik">Subject</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style3" colspan="2">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="340px"></asp:TextBox>
                    </td>

                    <td align="left" valign="middle" class="auto-style4"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
                    <td align="left" valign="middle" style="height: 25px; width: 130px">
                        <asp:Label ID="Label3" runat="server" CssClass="baslik">Comment</asp:Label>
                    </td>
                    <td align="left" valign="middle" style="height: 25px;" colspan="3">
                        <asp:TextBox ID="txtComment" runat="server" CssClass="textbox" Width="628px" TextMode="MultiLine"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1"></td>
                    <td align="left" valign="middle" class="auto-style2">
                        <asp:Label ID="Label5" runat="server" CssClass="baslik">Is Published</asp:Label>
                    </td>
                    <td align="left" valign="middle" class="auto-style9">
                        <asp:CheckBox ID="cbxIsPublished" runat="server" Text="Is Published ?" />
                    </td>

                    <td align="left" valign="middle" class="auto-style2"></td>
                    <td align="left" valign="middle" class="auto-style4"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle" class="auto-style1">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style9">&nbsp;</td>

                    <td align="left" valign="middle" class="auto-style2">&nbsp;</td>
                    <td align="left" valign="middle" class="auto-style4">&nbsp;</td>
                </tr>




            </table>
        </ew:CollapsablePanel>
        </td>



        <%--/* --------------------------------------------------------------------------------------------------*/--%>

        <tr>
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="CollapsablePanel2" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="File">
                <table cellspacing="0" cellpadding="0" width="800" border="0">

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
                            <uc1:ucFile runat="server" ID="ucFile1" />
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



        <%-- ------------------------------------------------------------------ --%>

        <tr id="trVesselApproval" runat="server">
            <td align="center">&nbsp;<ew:CollapsablePanel Style="border-color: #3366FF; border-style: solid; border-width: 1px; background-color: #eeeeee;" ID="cpVesselApproval" runat="server" Width="800px" Collapsed="False"
                TitleStyleContainerMode="EntirePanel" AllowTitleRowExpandCollapse="True" externalresourcepath="~/Web/js/eworld/eWorld_UI_CollapsablePanel.js"
                useexternalresource="True" ExpandImageUrl="~/Web/images/expand.gif" CollapseImageUrl="~/Web/images/collapse.gif"
                TitleStyle-CssClass="cpTitle" CollapsedTitleStyle-CssClass="cpTitleCollapsed"
                ExpandText="Open" CollapseText="Close" TitleText="Vessel Approve">
                <table cellspacing="0" cellpadding="0" width="800" border="0">

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label6" runat="server" CssClass="baslik">Vessel</asp:Label>
                        </td>
                        <td align="left" valign="middle" class="auto-style3">
                            <asp:Label ID="lblVesselName" runat="server" CssClass="icerik" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </td>

                        <td align="left" valign="middle" class="auto-style2"></td>
                        <td align="left" valign="middle" class="auto-style4"></td>
                    </tr>

                    <tr>
                        <td align="center" valign="middle" class="auto-style1"></td>
                        <td align="left" valign="middle" class="auto-style2">
                            <asp:Label ID="Label8" runat="server" CssClass="baslik">Closed Date</asp:Label>
                        </td>
                        <td align="left" colspan="3" valign="middle" class="auto-style5">
                            <ew:CalendarPopup ID="dpClosed_Date" runat="server" AllowArbitraryText="False" ClearDateText="Tarihi Sil" ControlDisplay="TextBoxImage" CssClass="dpStyle" DisableTextBoxEntry="False" DisplayOffsetY="-120" DisplayPrevNextYearSelection="True" ExternalResourcePath="~/js/eworld/eWorld_UI_CalendarPopup.js" GoToTodayText="Bugün" ImageUrl="Images/calendar.gif" MonthYearApplyText="Uygula" MonthYearCancelText="Vazgeç" Nullable="True" NullableLabelText="gg.aa.yyyy" ShowGoToToday="True" Text="..." UseExternalResource="True" Width="75px">
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="top">
                            <asp:Label ID="Label9" runat="server" CssClass="baslik">Comment</asp:Label>
                        </td>
                        <td align="left" style="height: 25px;" valign="middle" colspan="3">
                            <asp:TextBox ID="txtVAComment" runat="server" CssClass="textbox" TextMode="MultiLine" Width="628px" Height="50px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="center" style="height: 25px; width: 20px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 250px" valign="middle">
                            <asp:Button ID="imbVesselApprovalSave" runat="server" Text="Save" OnClick="imbVesselApprovalSave_Click" />
                        </td>
                        <td align="left" style="height: 25px; width: 130px" valign="middle">&nbsp;</td>
                        <td align="left" style="height: 25px; width: 270px" valign="middle">&nbsp;</td>
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



        </tr>

        <tr>
            <td align="center" valign="middle" style="height: 25px;">&nbsp;</td>
        </tr>

        <tr>
            <td align="center" valign="middle" style="height: 25px;">
                <asp:Button ID="imbSave" runat="server" Text="Save" OnClick="imbSave_Click" />
                &nbsp;<asp:Button ID="imbSaveandExit" runat="server" Text="Save &amp; Exit" OnClick="imbSaveandExit_Click" />
                &nbsp;<asp:Button ID="imbCancel" runat="server" Text="Cancel" CausesValidation="False" ValidateRequestMode="Disabled" OnClick="imbCancel_Click" />
                <asp:Button ID="imbDeleteandExit" runat="server" Text="Delete &amp; Exit" OnClick="imbDeleteandExit_Click" />
            </td>
        </tr>

        <tr>
            <td align="center" valign="middle" style="height: 25px;">&nbsp;</td>
        </tr>

    </table>


</asp:Content>
