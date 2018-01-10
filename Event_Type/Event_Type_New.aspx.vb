Imports System.Web.Configuration
Imports System.Data.SqlClient

Partial Class Admincp_Event_Type_Event_Type_New
    Inherits System.Web.UI.Page

    Public Shared ConnectionString As String = WebConfigurationManager.ConnectionStrings("EventRegConnectionString").ConnectionString
    Public Quizconection As New SqlConnection(ConnectionString)
    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Event_Type
        obj.EventType = txtEvent_Type.Text
        obj.IsDelete = False



        obj.InsertEvent_Type(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)
        clear()
        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub clear()
        txtEvent_Type.Text = ""
    End Sub
End Class
