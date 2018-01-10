
Partial Class Admincp_Event_Type_Event_TypeEdit
    Inherits System.Web.UI.Page

   

    Sub getData()

        'هذا الاجراء لاستدعاء بيانات السجل للصف المدرسي وذلك بدلالة رقم الصف  
        Dim obj As New Event_Type
        obj.Event_Type_Id = Request("FILEID")
        If obj.GetAllEvent_Type() = True Then
        
            txtEvent_Type.Text = obj.EventType

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getData()
        End If
    End Sub

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Event_Type
        obj.EventType = txtEvent_Type.Text
        obj.IsDelete = False
        obj.Event_Type_Id = Request("FILEID")


        obj.UpdateEvent_Type(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)

        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
End Class
