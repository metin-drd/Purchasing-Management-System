<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFile.ascx.cs" Inherits="Metin.Web.UserControls.ucFile" %>

<table cellspacing="0" cellpadding="0" width="800" border="0">

    <tr>
        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
        <td align="left" valign="middle" style="height: 25px; width: 150px">
            <asp:Label ID="Label15" runat="server" CssClass="baslik">File</asp:Label>
        </td>
        <td align="left" valign="middle" style="height: 25px;" colspan="3"><input id="txtDocumentFileUpload" runat="server" name="txtDocumentFileUpload" type="file" />&nbsp;&nbsp; </td>
    </tr>
    <tr>
        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
        <td align="left" valign="top" style="height: 25px; width: 150px">
            <asp:Label ID="Label17" runat="server" CssClass="baslik">Comment</asp:Label>
        </td>
        <td align="left" valign="middle" style="height: 25px;" colspan="3">
            <asp:TextBox ID="txtDocumentComment" runat="server" CssClass="textbox" Width="450px" TextMode="MultiLine"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="ValDocumentComment" runat="server" ControlToValidate="txtDocumentComment" ForeColor="Red" ValidationGroup="aa">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="center" valign="middle" style="height: 25px; width: 20px">&nbsp;</td>
        <td align="left" valign="middle" style="height: 25px; width: 150px">&nbsp;</td>
        <td align="left" valign="middle" style="height: 25px; width: 240px">
            <asp:Button ID="imbDocumentFileSave" runat="server" OnClick="imbDocumentSave_Click" Text="Save" Height="25px" ValidationGroup="aa" />
        </td>
        <td align="left" valign="middle" style="height: 25px; width: 150px">
            &nbsp;</td>
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
            <asp:GridView ID="tgDocumentFile" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" ForeColor="Black" GridLines="Vertical" Height="16px" Width="741px" OnRowCommand="tgDocumentFile_RowCommand" style="margin-top: 1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="file_id" HeaderText="File Id" Visible="False" />
                    <asp:BoundField DataField="comment" HeaderText="File Comment" />
                    <asp:ButtonField ButtonType="Button" CommandName="btnFileDelete" Text="Delete" ControlStyle-CssClass="btn btn-danger btn-sm">
                        <HeaderStyle Width="50px" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" Text="Open File" CommandName="btnOpenFile" ControlStyle-CssClass="btn btn-primary btn-sm" >

                    <HeaderStyle Width="60px" />
                    </asp:ButtonField>

                    <asp:BoundField DataField="file_location" HeaderText="file_location" Visible="False" />

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

