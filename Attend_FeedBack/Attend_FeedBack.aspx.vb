Imports MessageMNG
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class Admincp_Attend_FeedBack
    Inherits System.Web.UI.Page

    Dim obj As New Attend_FeedBack
    Protected Sub BtnSearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.ServerClick
        ' استدعاء دالة البحث 


        GridViewResualt.DataBind()

    End Sub






 

    Protected Sub GridViewResualt_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewResualt.PageIndexChanging
        'هذه الدالة لتجنب مشكلة الاندكس عند الانتقال من صفحة الى اخرى في الجريدفيو 
        GridViewResualt.PageIndex = e.NewPageIndex

    End Sub
End Class


