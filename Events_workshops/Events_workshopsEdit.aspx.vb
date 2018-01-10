
Partial Class Admincp_Events_workshops_Events_workshopsEdit
    Inherits System.Web.UI.Page
    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Events_workshops
        obj.Workshop_ID = Request("FILEID")
        obj.Event_Id = ddlEventId.SelectedValue
        obj.Workshop_Name = txtWorkshop_Name.Text
        obj.IsDelete = False



        obj.UpdateEvents_workshops(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)

        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub

    Sub getData()

        'هذا الاجراء لاستدعاء بيانات السجل للصف المدرسي وذلك بدلالة رقم الصف  
        Dim obj As New Events_workshops
        obj.Workshop_ID = Request("FILEID")
        If obj.GetAllEvents_workshops() = True Then
            txtWorkshop_Name.Text = obj.Workshop_Name
            ddlEventId.SelectedValue = obj.Event_Id


        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getData()
        End If
    End Sub
End Class
