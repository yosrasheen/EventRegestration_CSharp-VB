<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="SponsorsEdit.aspx.vb" Inherits="Admincp_Sponsors_SponsorsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                جديد&nbsp;رعاة الحدث </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl" align="right">
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td align="left">
                            اسم&nbsp; الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlEventId" runat="server" 
                                AppendDataBoundItems="True" DataSourceID="SqlDataevents" 
                                DataTextField="Event_Name" DataValueField="Event_Id">
                                <asp:ListItem Value="0">اختر   الحدث</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            اسم الراعي للحدث</td>
                        <td>
                            <asp:TextBox ID="txtSponsors_Name" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            الشعار</td>
                        <td>
                             <asp:FileUpload ID="flpSponsor_Logo" runat="server" />
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            الترتيب</td>
                        <td>
                            <asp:TextBox ID="txtarrange" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;
                               <button id="Btnsave" runat="server" type="button" validationgroup="new" class="btn_bg"
                                onmouseout="javascript:changeclass2(this.id)" 
                                            onmouseover="javascript:changeclass(this.id)"   >
                                <asp:Image ID="Image6" runat="server" ImageUrl="~/images/refresh_small.png" />
                             حفظ
                            </button>
                        </td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table></td>
        </tr>
        <tr>
            <td id="TebleSearch">
                <asp:Literal ID="LabMsg" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td dir="rtl">
                <asp:SqlDataSource ID="SqlDataevents" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    SelectCommand="SELECT Event_Id, Event_Name FROM Events"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

