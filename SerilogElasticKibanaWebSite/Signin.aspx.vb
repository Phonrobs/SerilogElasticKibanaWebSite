
Partial Class Signin
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtUsername.Text = "admin" And txtPassword.Text = "admin" Then
            Session("Authenticated") = True
            Session("Username") = txtUsername.Text
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class
