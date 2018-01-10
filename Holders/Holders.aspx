<%@ Page Title="" Language="VB" MasterPageFile="~/Admincp/MasterPage.master" AutoEventWireup="false" CodeFile="Holders.aspx.vb" Inherits="Admincp_Holders_Holders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="bgHeadTitle">
                منظموا الاحداث  </td>
        </tr>
        <tr>
            <td dir="rtl" id="TebleSearch" style="text-align: right">
              
                <asp:HyperLink ID="HyperLink113" runat="server" 
                    NavigateUrl="~/Admincp/Holders/HoldersNew.aspx">جديد</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td dir="rtl">
                <asp:SqlDataSource ID="SqlDataResult" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EventRegConnectionString %>" 
                    
                    
                    
                    SelectCommand="SELECT * FROM [Holders]" 
                    DeleteCommand="DELETE FROM [Holders] WHERE [Holder_Id] = @Holder_Id" 
                    InsertCommand="INSERT INTO [Holders] ([Holder_Name], [User_Name], [Password], [HolderDetailes], [Isdelete]) VALUES (@Holder_Name, @User_Name, @Password, @HolderDetailes, @Isdelete)" 
                    
                    
                    
                    
                    UpdateCommand="UPDATE [Holders] SET [Holder_Name] = @Holder_Name, [User_Name] = @User_Name, [Password] = @Password, [HolderDetailes] = @HolderDetailes, [Isdelete] = @Isdelete WHERE [Holder_Id] = @Holder_Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Holder_Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Holder_Name" Type="String" />
                        <asp:Parameter Name="User_Name" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="HolderDetailes" Type="String" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Holder_Name" Type="String" />
                        <asp:Parameter Name="User_Name" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="HolderDetailes" Type="String" />
                        <asp:Parameter Name="Isdelete" Type="Boolean" />
                        <asp:Parameter Name="Holder_Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
           <asp:GridView ID="GridViewResualt" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" 
                    SkinID="GridViewResualt" DataSourceID="SqlDataResult" 
                    DataKeyNames="Holder_Id"  >
               <Columns>
                   
                 
                   
                   <asp:BoundField DataField="Holder_Id" HeaderText="#" 
                       InsertVisible="False" ReadOnly="True" SortExpression="Holder_Id" />
                   <asp:BoundField DataField="Holder_Name" HeaderText="اسم المنظم" 
                       SortExpression="Holder_Name" />
                   <asp:BoundField DataField="HolderDetailes" HeaderText="التفاصيل" 
                       SortExpression="HolderDetailes" />

                         <asp:CommandField DeleteText="حذف" HeaderText="حذف" 
                       ShowDeleteButton="True" />
                             <asp:TemplateField HeaderText="تعديل">
                            <ItemTemplate>
                                   <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl='<%#"HoldersEdit.aspx?FILEID=" & Eval("Holder_Id") %>' Target="_blank">تعديل</asp:HyperLink>
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

