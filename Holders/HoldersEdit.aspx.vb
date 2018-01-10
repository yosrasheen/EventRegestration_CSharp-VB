
Partial Class Admincp_Holders_HoldersEdit
    Inherits System.Web.UI.Page

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Holders
        obj.Holder_Id = Request("FILEID")
        obj.Holder_Name = txtHolder_Name.Text
        obj.HolderDetailes = txtHolderDetailes.Text
        obj.Password = txtPassword.Text
        obj.User_Name = txtUser_Name.Text
        obj.IsDelete = False



        obj.UpdateHolders(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)

        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub getData()

        'هذا الاجراء لاستدعاء بيانات السجل للصف المدرسي وذلك بدلالة رقم الصف  
        Dim obj As New Holders
        obj.Holder_Id = Request("FILEID")
        If obj.GetAllHolders() = True Then
            txtHolder_Name.Text = obj.Holder_Name
            txtHolderDetailes.Text = obj.HolderDetailes
            txtPassword.Text = obj.Password
            txtUser_Name.Text = obj.User_Name


        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getData()
        End If
    End Sub
End Class
