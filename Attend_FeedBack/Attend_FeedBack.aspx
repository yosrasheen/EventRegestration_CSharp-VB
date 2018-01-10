<%@ Page   Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Attend_FeedBack.aspx.vb" Inherits="Admincp_Attend_FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                التغذية الراجعة للاحداث </td>
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
                            اسم الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlEvent_Id" runat="server" DataSourceID="SqlDataevents" 
                                DataTextField="Event_Name" DataValueField="Event_Id">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;
                            <button id="BtnSearch" runat="server" type="button" validationgroup="new" class="btn_bg"
                                onmouseout="javascript:changeclass2(this.id)" onmouseover="javascript:changeclass(this.id)">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Icons/icon_view.gif" />
                                بحث
                            </button>
                        </td>
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
                <asp:SqlDataSource ID="SqlDataResult" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    
                    SelectCommand="SELECT Attend_FeedBack.Attend_feedBack_Id, Attend_FeedBack.Event_Id, Attend_FeedBack.title, Attend_FeedBack.details, Attend_FeedBack.FeedDate, Events.Event_Name FROM Events INNER JOIN Attend_FeedBack ON Events.Event_Id = Attend_FeedBack.Event_Id WHERE (Attend_FeedBack.Event_Id = @eventid )" 
                    DeleteCommand="DELETE FROM [Attend_FeedBack] WHERE [Attend_feedBack_Id] = @Attend_feedBack_Id" 
                    InsertCommand="INSERT INTO [Attend_FeedBack] ([Event_Id], [title], [details], [FeedDate]) VALUES (@Event_Id, @title, @details, @FeedDate)" 
                    UpdateCommand="UPDATE [Attend_FeedBack] SET [Event_Id] = @Event_Id, [title] = @title, [details] = @details, [FeedDate] = @FeedDate WHERE [Attend_feedBack_Id] = @Attend_feedBack_Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Attend_feedBack_Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Event_Id" Type="Int32" />
                        <asp:Parameter Name="title" Type="String" />
                        <asp:Parameter Name="details" Type="String" />
                        <asp:Parameter Name="FeedDate" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEvent_Id" Name="eventid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Event_Id" Type="Int32" />
                        <asp:Parameter Name="title" Type="String" />
                        <asp:Parameter Name="details" Type="String" />
                        <asp:Parameter Name="FeedDate" Type="String" />
                        <asp:Parameter Name="Attend_feedBack_Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataevents" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    SelectCommand="SELECT [Event_Name], [Event_Id] FROM [Events]">
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   DataKeyNames="Attend_feedBack_Id"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult"  >
                    <Columns>
                        <asp:BoundField DataField="Attend_feedBack_Id" HeaderText="#" ReadOnly="True" 
                            SortExpression="Attend_feedBack_Id" />
                        <asp:BoundField DataField="title" HeaderText="العنوان" 
                            SortExpression="title" />
                        <asp:BoundField DataField="details" HeaderText="التفاصيل" 
                            SortExpression="details" />
                         <asp:BoundField DataField="FeedDate" HeaderText="التاريخ" 
                             SortExpression="FeedDate" />
                        <asp:BoundField DataField="Event_Name" HeaderText="اسم الحدث" 
                            SortExpression="Event_Name" />
                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
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

