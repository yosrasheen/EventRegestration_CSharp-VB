Imports System.Web.Configuration
Imports System.Data.SqlClient

Partial Class Admincp_Events_EventsNew
    Inherits System.Web.UI.Page
    Public Shared ConnectionString As String = WebConfigurationManager.ConnectionStrings("EventRegConnectionString").ConnectionString
    Public Quizconection As New SqlConnection(ConnectionString)
    Function geteventlogo() As String
        Return ""
    End Function

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Events
        obj.Event_Brief = txtEvent_Brief.Text
        obj.Event_Detailes = txtEvent_Detailes.Text
        obj.Event_End = txtEvent_End.Text
        obj.Event_Logo = geteventlogo
        obj.Event_Name = txtEvent_Name.Text
        obj.Event_Open = txtEvent_Open.Text
        obj.Event_Type_Id = ddlEvent_Type_Id.SelectedValue
        obj.holder_Id = ddlholder_Id.SelectedValue
        obj.IsDelete = False
        obj.IsOpen = chkIsOpen.Checked
        obj.PLace_Id = ddlplaceid.SelectedValue
        obj.IsDelete = False



        obj.InsertEvents(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)
        clear()
        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub clear()
        txtEvent_Brief.Text = ""
        txtEvent_Detailes.Text = ""
        txtEvent_End.Text = ""

        txtEvent_Name.Text = ""
        txtEvent_Open.Text = ""
        ddlEvent_Type_Id.SelectedValue = 0
        ddlholder_Id.SelectedValue = 0

        chkIsOpen.Checked = False
        ddlplaceid.SelectedValue = 0

    End Sub
End Class
