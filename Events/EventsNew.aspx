<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="EventsNew.aspx.vb" Inherits="Admincp_Events_EventsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                جديد&nbsp; الحدث </td>
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
                            <asp:TextBox ID="txtEvent_Name" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="نوع الحدث" style="color: #CC3300" 
                                ControlToValidate="txtEvent_Name">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            نوع الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlEvent_Type_Id" runat="server" 
                                AppendDataBoundItems="True" DataSourceID="SqlDatatype" 
                                DataTextField="Event_Type" DataValueField="Event_Type_Id">
                                <asp:ListItem Value="0">اختر نوع الحدث</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="نوع الحدث" style="color: #CC3300" 
                                ControlToValidate="ddlEvent_Type_Id">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            الشعار</td>
                        <td>
                             <asp:FileUpload ID="flpEvent_Logo" runat="server" />
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            بداية الحدث</td>
                        <td>
                            <asp:TextBox ID="txtEvent_Open" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            مختصر الحدث</td>
                        <td>
                            <asp:TextBox ID="txtEvent_Brief" runat="server" Height="84px" 
                                TextMode="MultiLine" Width="320px"></asp:TextBox>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            تاريخ الانتهاء</td>
                        <td>
                            <asp:TextBox ID="txtEvent_End" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            تفاصيل الحدث</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtEvent_Detailes" runat="server" Height="134px" 
                                TextMode="MultiLine" Width="629px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            منظم&nbsp; الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlholder_Id" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="SqlDataholder" DataTextField="Holder_Name" 
                                DataValueField="Holder_Id">
                                <asp:ListItem Value="0">اختر منظم الحدث</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            مفتوح</td>
                        <td>
                            <asp:CheckBox ID="chkIsOpen" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            مكان الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlplaceid" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="SqlDataplace" DataTextField="Place" DataValueField="PLace_ID">
                                <asp:ListItem Value="0">اختر مكان الحدث</asp:ListItem>
                            </asp:DropDownList>
                        </td>
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
                <asp:SqlDataSource ID="SqlDatatype" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    SelectCommand="SELECT [Event_Type], [Event_Type_Id] FROM [Event_Type]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataholder" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    SelectCommand="SELECT Holder_Id, Holder_Name FROM Holders">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataplace" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    SelectCommand="SELECT PLace_ID, Place FROM PLace"></asp:SqlDataSource>
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

