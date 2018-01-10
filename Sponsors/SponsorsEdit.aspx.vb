
Partial Class Admincp_Sponsors_SponsorsEdit
    Inherits System.Web.UI.Page
    Function getSponsor_Logo() As String
        Return ""
    End Function


    Protected Sub Btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.ServerClick
        'Try

        Dim obj As New Sponsors
        obj.Sponsor_ID = Request("FILEID")
        obj.arrange = txtarrange.Text
        obj.Event_Id = ddlEventId.SelectedValue
        obj.Sponsor_Logo = getSponsor_Logo()
        obj.Sponsors_Name = txtSponsors_Name.Text
        obj.IsDelete = False



        obj.UpdateSponsors(obj)
        LabMsg.Text = MessageMNG.ShowMsg("تمت العملية بنجاح", MessageMNG.msgType.success)

        'Catch ex As Exception
        '    LabMsg.Text = MessageMNG.ShowMsg(Resources.BaseClasses.Err_CreateRecord, MessageMNG.msgType.errorM)
        'Finally
        '    Quizconection.Close()
        'End Try
    End Sub
    Sub getData()

        'هذا الاجراء لاستدعاء بيانات السجل للصف المدرسي وذلك بدلالة رقم الصف  
        Dim obj As New Sponsors
        obj.Sponsor_ID = Request("FILEID")
        If obj.GetAllSponsors() = True Then
            txtarrange.Text = obj.arrange
            txtSponsors_Name.Text = obj.Sponsors_Name
            ddlEventId.SelectedValue = obj.Event_Id



        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getData()
        End If
    End Sub
End Class
