<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Event_Visitor.aspx.vb" Inherits="Admincp_Event_Visitor_Event_Visitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
               زوار الاحداث  </td>
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
                    
                    
                    
                    SelectCommand="SELECT Events.Event_Name, VR_Visitors.Visitor_Name, Event_Visitor.Event_ID, VR_Visitors.Country_Name, VR_Visitors.Side_Name, VR_Visitors.Job_Name, VR_Visitors.Created_Date, Event_Visitor.Event_Visitor_ID FROM VR_Visitors INNER JOIN Event_Visitor ON VR_Visitors.Visitor_ID = Event_Visitor.Visitor_ID INNER JOIN Events ON Event_Visitor.Event_ID = Events.Event_Id WHERE (Event_Visitor.Event_ID = @eventid)" 
                    DeleteCommand="DELETE FROM [Event_Visitor] WHERE [Event_Visitor_ID] = @Event_Visitor_ID" 
                    InsertCommand="INSERT INTO [Event_Visitor] ([Event_ID], [Visitor_ID], [Registration_Date], [USER_ID], [Created_Date], [Isdelete]) VALUES (@Event_ID, @Visitor_ID, @Registration_Date, @USER_ID, @Created_Date, @Isdelete)" 
                    
                    UpdateCommand="UPDATE [Event_Visitor] SET [Event_ID] = @Event_ID, [Visitor_ID] = @Visitor_ID, [Registration_Date] = @Registration_Date, [USER_ID] = @USER_ID, [Created_Date] = @Created_Date, [Isdelete] = @Isdelete WHERE [Event_Visitor_ID] = @Event_Visitor_ID">
                    <DeleteParameters>
                        <asp:Parameter Name="Event_Visitor_ID" Type="Int64" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Event_ID" Type="Int64" />
                        <asp:Parameter Name="Visitor_ID" Type="Int64" />
                        <asp:Parameter Name="Registration_Date" DbType="Date" />
                        <asp:Parameter Name="USER_ID" Type="Int32" />
                        <asp:Parameter Name="Created_Date" Type="DateTime" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEvent_Id" Name="eventid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Event_ID" Type="Int64" />
                        <asp:Parameter Name="Visitor_ID" Type="Int64" />
                        <asp:Parameter Name="Registration_Date" DbType="Date" />
                        <asp:Parameter Name="USER_ID" Type="Int32" />
                        <asp:Parameter Name="Created_Date" Type="DateTime" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Visitor_ID" Type="Int64" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataevents" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    SelectCommand="SELECT [Event_Name], [Event_Id] FROM [Events]">
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult"  >
               <Columns>
                   
                   <asp:BoundField DataField="Event_Visitor_ID" HeaderText="#" 
                       InsertVisible="False" ReadOnly="True" SortExpression="Event_Visitor_ID" />
                   <asp:BoundField DataField="Event_Name" HeaderText="اسم الحدث" 
                       SortExpression="Event_Name" />
                   <asp:BoundField DataField="Visitor_Name" HeaderText="اسم الزائر" 
                       SortExpression="Visitor_Name" />
                   <asp:BoundField DataField="Country_Name" HeaderText="البلد" 
                       SortExpression="Country_Name" />
                   <asp:BoundField DataField="Side_Name" HeaderText="الجهة" 
                       SortExpression="Side_Name" />
                   <asp:BoundField DataField="Job_Name" HeaderText="الوظيفة" 
                       SortExpression="Job_Name" />
                   <asp:BoundField DataField="Created_Date" HeaderText="التاريخ" 
                       SortExpression="Created_Date" />
                       <asp:CommandField ShowDeleteButton="True" DeleteText="حذف" 
                       HeaderText="حذف" />
                        
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

