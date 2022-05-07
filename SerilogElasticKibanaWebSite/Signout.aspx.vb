
Partial Class Signout
    Inherits System.Web.UI.Page

    Private Sub Signout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Serilog.Log.Information("{Event}: User '{username}' is signing out", "SIGNOUT", Session("Username"))

        Session("Authenticated") = False
        Session("Username") = ""
    End Sub
End Class
