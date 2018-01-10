<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Event_Type.aspx.vb" Inherits="Admincp_Event_Type_Event_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                انواع الاحداث </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl" align="right">
              
                <asp:HyperLink ID="HyperLink113" runat="server" 
                    NavigateUrl="~/Admincp/Event_Type/Event_Type_New.aspx">جديد</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td  id='TebleSearch' dir="rtl">
                &nbsp;</td>
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
                    
                    
                    
                    SelectCommand="SELECT * FROM [Event_Type]" 
                    DeleteCommand="DELETE FROM [Event_Type] WHERE [Event_Type_Id] = @Event_Type_Id" 
                    InsertCommand="INSERT INTO [Event_Type] ([Event_Type_Id], [Event_Type], [IsDelete]) VALUES (@Event_Type_Id, @Event_Type, @IsDelete)" 
                    
                    UpdateCommand="UPDATE [Event_Type] SET [Event_Type] = @Event_Type, [IsDelete] = @IsDelete WHERE [Event_Type_Id] = @Event_Type_Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Event_Type_Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Event_Type_Id" Type="Int32" />
                        <asp:Parameter Name="Event_Type" Type="String" />
                        <asp:Parameter Name="IsDelete" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Event_Type" Type="String" />
                        <asp:Parameter Name="IsDelete" Type="Boolean" />
                        <asp:Parameter Name="Event_Type_Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   DataKeyNames="Event_Type_Id"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult"  >
                    <Columns>
                        <asp:BoundField DataField="Event_Type_Id" HeaderText="#" ReadOnly="True" 
                            SortExpression="Event_Type_Id" />
                        <asp:BoundField DataField="Event_Type" HeaderText="نوع الحدث" 
                            SortExpression="Event_Type" />
                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
                      <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                   <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl='<%#"Event_TypeEdit.aspx?FILEID=" & Eval("Event_Type_Id") %>' Target="_blank">تعديل</asp:HyperLink>
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

