
Partial Class Admincp_Sponsors_SponsorsNew
    Inherits System.Web.UI.Page
    Function getSponsor_Logo() As String
        Return ""
    End Function


    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Sponsors
        obj.arrange = txtarrange.Text
        obj.Event_Id = ddlEventId.SelectedValue
        obj.Sponsor_Logo = getSponsor_Logo()
        obj.Sponsors_Name = txtSponsors_Name.Text
        obj.IsDelete = False



        obj.InsertSponsors(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)
        clear()
        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub clear()
        txtarrange.Text = ""
        ddlEventId.SelectedValue = 0

        txtSponsors_Name.Text = ""

    End Sub
End Class
