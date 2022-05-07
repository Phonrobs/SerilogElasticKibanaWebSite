
Partial Class Signin
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtUsername.Text = "admin" And txtPassword.Text = "admin" Then
            Session("Authenticated") = True
            Session("Username") = txtUsername.Text

            Serilog.Log.Information("{Event}: User '{username}' is signing in", "SIGNIN", txtUsername.Text)

            Response.Redirect("~/Default.aspx")
        Else
            lbError.Text = "Invalid username or password"
            Serilog.Log.Error("{Event}: Invalid username or password for user '{username}'", "SIGNIN_ERROR", txtUsername.Text)
        End If
    End Sub
End Class
