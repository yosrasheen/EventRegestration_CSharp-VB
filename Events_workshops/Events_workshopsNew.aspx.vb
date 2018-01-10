Imports System.Web.Configuration
Imports System.Data.SqlClient

Partial Class Admincp_Events_workshops_Events_workshopsNew
    Inherits System.Web.UI.Page
    Public Shared ConnectionString As String = WebConfigurationManager.ConnectionStrings("EventRegConnectionString").ConnectionString
    Public Quizconection As New SqlConnection(ConnectionString)
    

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Events_workshops
        obj.Event_Id = ddlEventId.SelectedValue
        obj.Workshop_Name = txtWorkshop_Name.Text
        obj.IsDelete = False



        obj.InsertEvents_workshops(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)
        clear()
        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub clear()
        txtWorkshop_Name.Text = ""
        ddlEventId.SelectedValue = 0

    End Sub
End Class
