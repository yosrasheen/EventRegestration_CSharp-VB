Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class Admincp_Events_EventsEdit
    Inherits System.Web.UI.Page
    Public Shared ConnectionString As String = WebConfigurationManager.ConnectionStrings("EventRegConnectionString").ConnectionString
    Public Quizconection As New SqlConnection(ConnectionString)
    Function geteventlogo() As String
        Return ""
    End Function

    Sub getData()

        'هذا الاجراء لاستدعاء بيانات السجل للصف المدرسي وذلك بدلالة رقم الصف  
        Dim obj As New Events
        obj.Event_Id = Request("FILEID")
        If obj.GetAllEvents() = True Then
            txtEvent_Brief.Text = obj.Event_Brief
            txtEvent_Detailes.Text = obj.Event_Detailes
            txtEvent_End.Text = obj.Event_End
            txtEvent_Name.Text = obj.Event_Name
            txtEvent_Open.Text = obj.Event_Open
            ddlEvent_Type_Id.SelectedValue = obj.Event_Type_Id
            ddlholder_Id.SelectedValue = obj.holder_Id
            ddlplaceid.SelectedValue = obj.PLace_Id
            chkIsOpen.Checked = obj.IsOpen


        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getData()
        End If
    End Sub

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Events
        obj.Event_Id = Request("FILEID")
        obj.Event_Brief = txtEvent_Brief.Text
        obj.Event_Detailes = txtEvent_Detailes.Text
        obj.Event_End = txtEvent_End.Text
        obj.Event_Logo = geteventlogo()
        obj.Event_Name = txtEvent_Name.Text
        obj.Event_Open = txtEvent_Open.Text
        obj.Event_Type_Id = ddlEvent_Type_Id.SelectedValue
        obj.holder_Id = ddlholder_Id.SelectedValue
        obj.IsDelete = False
        obj.IsOpen = chkIsOpen.Checked
        obj.PLace_Id = ddlplaceid.SelectedValue
        obj.IsDelete = False



        obj.UpdateEvents(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)

        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
End Class
