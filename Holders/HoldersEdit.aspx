<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="HoldersEdit.aspx.vb" Inherits="Admincp_Holders_HoldersEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                جديد&nbsp;ورش العمل </td>
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
                            اسم&nbsp; المنظم</td>
                        <td>
                            <asp:TextBox ID="txtHolder_Name" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            اسم المستخدم</td>
                        <td>
                            <asp:TextBox ID="txtUser_Name" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            كلمة المرور</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            تفاصيل اخرى</td>
                        <td>
                            <asp:TextBox ID="txtHolderDetailes" runat="server" Width="200px" Height="98px" 
                                TextMode="MultiLine"></asp:TextBox>
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

