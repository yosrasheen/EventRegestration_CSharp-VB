<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Events.aspx.vb" Inherits="Admincp_Events_Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                الاحداث  </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl" align="right">
              
                <asp:HyperLink ID="HyperLink113" runat="server" 
                    NavigateUrl="~/Admincp/Events/EventsNew.aspx">جديد</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td align="left">
                            نوع&nbsp; الحدث</td>
                        <td>
                            <asp:DropDownList ID="ddlEvent_Id" runat="server" DataSourceID="SqlDataeventType" 
                                DataTextField="Event_Type" DataValueField="Event_Type_Id">
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
                    
                    
                    
                    SelectCommand="SELECT Events.Event_Id, Events.Event_Name, Event_Type.Event_Type, Holders.Holder_Name, PLace.Place, Events.Event_Type_Id FROM Events INNER JOIN Holders ON Events.holder_Id = Holders.Holder_Id INNER JOIN PLace ON Events.PLace_Id = PLace.PLace_ID INNER JOIN Event_Type ON Events.Event_Type_Id = Event_Type.Event_Type_Id WHERE (Events.Event_Type_Id = @typeid)" 
                    DeleteCommand="DELETE FROM [Events] WHERE [Event_Id] = @Event_Id" 
                    InsertCommand="INSERT INTO [Events] ([Event_Name], [Event_Type_Id], [Event_Logo], [Event_Brief], [Event_Open], [Event_End], [IsDelete], [Event_Detailes], [holder_Id], [IsOpen], [PLace_Id]) VALUES (@Event_Name, @Event_Type_Id, @Event_Logo, @Event_Brief, @Event_Open, @Event_End, @IsDelete, @Event_Detailes, @holder_Id, @IsOpen, @PLace_Id)" 
                    
                    
                    UpdateCommand="UPDATE [Events] SET [Event_Name] = @Event_Name, [Event_Type_Id] = @Event_Type_Id, [Event_Logo] = @Event_Logo, [Event_Brief] = @Event_Brief, [Event_Open] = @Event_Open, [Event_End] = @Event_End, [IsDelete] = @IsDelete, [Event_Detailes] = @Event_Detailes, [holder_Id] = @holder_Id, [IsOpen] = @IsOpen, [PLace_Id] = @PLace_Id WHERE [Event_Id] = @Event_Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Event_Id" Type="Int64" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Event_Name" Type="String" />
                        <asp:Parameter Name="Event_Type_Id" Type="String" />
                        <asp:Parameter Name="Event_Logo" Type="String" />
                        <asp:Parameter Name="Event_Brief" Type="String" />
                        <asp:Parameter Name="Event_Open" Type="String" />
                        <asp:Parameter Name="Event_End" Type="String" />
                        <asp:Parameter Name="IsDelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Detailes" Type="String" />
                        <asp:Parameter Name="holder_Id" Type="Int32" />
                        <asp:Parameter Name="IsOpen" Type="Boolean" />
                        <asp:Parameter Name="PLace_Id" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEvent_Id" Name="typeid" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Event_Name" Type="String" />
                        <asp:Parameter Name="Event_Type_Id" Type="String" />
                        <asp:Parameter Name="Event_Logo" Type="String" />
                        <asp:Parameter Name="Event_Brief" Type="String" />
                        <asp:Parameter Name="Event_Open" Type="String" />
                        <asp:Parameter Name="Event_End" Type="String" />
                        <asp:Parameter Name="IsDelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Detailes" Type="String" />
                        <asp:Parameter Name="holder_Id" Type="Int32" />
                        <asp:Parameter Name="IsOpen" Type="Boolean" />
                        <asp:Parameter Name="PLace_Id" Type="Int32" />
                        <asp:Parameter Name="Event_Id" Type="Int64" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataeventType" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    SelectCommand="SELECT Event_Type, Event_Type_Id, IsDelete FROM Event_Type WHERE (IsDelete = 0)">
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult" 
                    DataKeyNames="Event_Id"  >
               <Columns>
                   
                 
                   
                   <asp:BoundField DataField="Event_Id" HeaderText="#" 
                       InsertVisible="False" ReadOnly="True" SortExpression="Event_Id" />
                   <asp:BoundField DataField="Event_Name" HeaderText="اسم الحدث" 
                       SortExpression="Event_Name" />
                   <asp:BoundField DataField="Event_Type" HeaderText="نوع الحدث" 
                       SortExpression="Event_Type" />
                   <asp:BoundField DataField="Holder_Name" HeaderText="صاحب الحدث" 
                       SortExpression="Holder_Name" />
                   <asp:BoundField DataField="Place" HeaderText="مكان الحدث" 
                       SortExpression="Place" />
                         <asp:CommandField ShowDeleteButton="True" />
                          <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                   <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl='<%#"EventsEdit.aspx?FILEID=" & Eval("Event_Id") %>' Target="_blank">تعديل</asp:HyperLink>
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

