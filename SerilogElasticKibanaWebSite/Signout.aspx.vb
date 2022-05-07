
Partial Class Signout
    Inherits System.Web.UI.Page

    Private Sub Signout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("Authenticated") = False
        Session("Username") = ""
    End Sub
End Class
