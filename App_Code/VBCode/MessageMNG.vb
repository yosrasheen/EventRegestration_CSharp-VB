Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Caching
Imports System.Text

Public Class MessageMNG
    Public Enum msgType
        information
        success
        errorM
        attention
    End Enum
    Public Shared Function ShowMsg(ByVal MsgS As String, ByVal MsgType As msgType) As String
        Dim sb As New StringBuilder
        sb.Append("<div class='notification " + MsgType.ToString + " png_bg'>")
        sb.Append("<a href='#' class='close'><img src='../../images/cross_grey_small.png' title='اغلاق الرسالة' alt='اغلاق' border=0 /></a>")
        sb.Append("<div>")
        sb.Append(MsgS)
        sb.Append("</div>")
        sb.Append("</div>")
        Return sb.ToString
    End Function
    Sub SetFocus(ByVal control As Control)
        Dim sb As New StringBuilder()

        sb.Append(vbCr & vbLf & "<script language='JavaScript'>" & vbCr & vbLf)
        sb.Append("<!--" & vbCr & vbLf)
        sb.Append("function SetFocus()" & vbCr & vbLf)
        sb.Append("{" & vbCr & vbLf)
        sb.Append(vbTab & "document.")
        Dim p As Control = control.Parent
        While Not (TypeOf p Is System.Web.UI.HtmlControls.HtmlForm)
            p = p.Parent
        End While
        sb.Append(p.ClientID)
        sb.Append("['")
        sb.Append(control.UniqueID)
        sb.Append("'].focus();" & vbCr & vbLf)
        sb.Append("}" & vbCr & vbLf)
        sb.Append("window.onload = SetFocus;" & vbCr & vbLf)
        sb.Append("// -->" & vbCr & vbLf)
        sb.Append("</script>")
        control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString())
    End Sub
    Public Shared Function dateH(ByVal bdate As BasicFrame.WebControls.BasicDatePicker)
        Dim dt As DateTime
        Dim hijriCal As New System.Globalization.HijriCalendar
        bdate.SelectedDate = hijriCal.AddMonths(DateTime.Now, 0).Date
        dt = Convert.ToDateTime(bdate.SelectedDate)
        Dim ci As New System.Globalization.CultureInfo("ar-SA", False)
        ci.DateTimeFormat.Calendar = New System.Globalization.HijriCalendar()
        ci.DateTimeFormat.LongDatePattern = bdate.SelectedDate
    End Function
End Class


