Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Configuration

Public Class MainClass
    Public Shared ConnectionString As String = WebConfigurationManager.ConnectionStrings("EventRegConnectionString").ConnectionString
    Public Quizconection As New SqlConnection(ConnectionString)
    Dim com As New SqlCommand
    Dim mytrans As SqlTransaction
    Sub begintrans()
        com.Connection = Quizconection
        Quizconection.Open()
        mytrans = Quizconection.BeginTransaction
        com.Transaction = mytrans
    End Sub
    Sub comitttrans()
        mytrans.Commit()
        Quizconection.Close()
    End Sub
    Sub rollbacktrans()
        If Quizconection.State = ConnectionState.Open Then
            mytrans.Rollback()
            Quizconection.Close()
        End If
    End Sub
    Sub Bind(ByVal listControl As ListControl, ByVal tableIndex As String, Optional ByVal header As String = "0")
        Try
            com.CommandText = "select * from " & tableIndex
            Dim myreader As SqlDataReader = com.ExecuteReader
            Dim dt As New DataTable
            dt.Load(myreader)
            listControl.DataValueField = dt.Columns(0).ToString()
            listControl.DataTextField = dt.Columns(1).ToString()
            listControl.DataSource = dt
            listControl.DataBind()
            If header.Length > 1 Then
                listControl.Items.Insert(0, New ListItem(header, "0"))
            End If
        Catch ex As Exception

        Finally
        End Try
    End Sub
End Class
