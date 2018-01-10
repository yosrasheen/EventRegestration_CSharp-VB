
Partial Class Admincp_Holders_HoldersNew
    Inherits System.Web.UI.Page

    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Holders
        obj.Holder_Name = txtHolder_Name.Text
        obj.HolderDetailes = txtHolderDetailes.Text
        obj.Password = txtPassword.Text
        obj.User_Name = txtUser_Name.Text
        obj.IsDelete = False



        obj.InsertHolders(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)
        clear()
        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub clear()
        txtHolder_Name.Text = ""
        txtHolderDetailes.Text = ""
        txtPassword.Text = ""
        txtUser_Name.Text = ""

    End Sub
End Class
