<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Events_workshops.aspx.vb" Inherits="Admincp_Events_workshops_Events_workshops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                ورش العمل  </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl" align="right">
              
                <asp:HyperLink ID="HyperLink113" runat="server" 
                    NavigateUrl="~/Admincp/Events_workshops/Events_workshopsNew.aspx">جديد</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td align="left">
                            نوع&nbsp; الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlEvent_type" runat="server" DataSourceID="SqlDataeventType" 
                                DataTextField="Event_Type" DataValueField="Event_Type_Id" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            الحدث</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEvent_Id" runat="server" DataSourceID="SqlDataevents" 
                                DataTextField="Event_Name" DataValueField="Event_Id">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: center">
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
            <td id="TebleSearch" class="style1">
                <asp:Literal ID="LabMsg" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td dir="rtl">
                <asp:SqlDataSource ID="SqlDataevents" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    
                    SelectCommand="SELECT Event_Id, Event_Name FROM Events WHERE (Event_Type_Id = @typeid)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEvent_type" Name="typeid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataResult" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    
                    SelectCommand="SELECT Events_workshops.Workshop_ID, Events_workshops.Workshop_Name, Events_workshops.Isdelete, Events_workshops.Event_Id, Events.Event_Name FROM Events_workshops INNER JOIN Events ON Events_workshops.Event_Id = Events.Event_Id WHERE (Events_workshops.Event_Id = @eventid)" 
                    DeleteCommand="DELETE FROM [Events_workshops] WHERE [Workshop_ID] = @Workshop_ID" 
                    InsertCommand="INSERT INTO [Events_workshops] ([Workshop_Name], [Isdelete], [Event_Id]) VALUES (@Workshop_Name, @Isdelete, @Event_Id)" 
                    
                    
                    
                    UpdateCommand="UPDATE [Events_workshops] SET [Workshop_Name] = @Workshop_Name, [Isdelete] = @Isdelete, [Event_Id] = @Event_Id WHERE [Workshop_ID] = @Workshop_ID">
                    <DeleteParameters>
                        <asp:Parameter Name="Workshop_ID" Type="Int64" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Workshop_Name" Type="String" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Id" Type="Int64" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEvent_Id" Name="eventid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Workshop_Name" Type="String" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Id" Type="Int64" />
                        <asp:Parameter Name="Workshop_ID" Type="Int64" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataeventType" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    SelectCommand="SELECT Event_Type, Event_Type_Id, IsDelete FROM Event_Type WHERE (IsDelete = 0)">
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult" 
                    DataKeyNames="Workshop_ID"  >
               <Columns>
                   
                 
                   
                   <asp:BoundField DataField="Workshop_ID" HeaderText="#" 
                       InsertVisible="False" ReadOnly="True" SortExpression="Workshop_ID" />
                   <asp:BoundField DataField="Event_Name" HeaderText="اسم الحدث " 
                       SortExpression="Event_Name" />
                   <asp:BoundField DataField="Workshop_Name" HeaderText="ورسة العمل" 
                       SortExpression="Workshop_Name" />

                         <asp:CommandField ShowDeleteButton="True" />
                          <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                   <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl='<%#"Events_workshopsEdit.aspx?FILEID=" & Eval("Workshop_ID") %>' Target="_blank">تعديل</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

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

