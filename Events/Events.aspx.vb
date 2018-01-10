
Partial Class Admincp_Events_Events
    Inherits System.Web.UI.Page
    Protected Sub BtnSearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.ServerClick
        ' استدعاء دالة البحث 


        GridViewResualt.DataBind()

    End Sub
End Class
