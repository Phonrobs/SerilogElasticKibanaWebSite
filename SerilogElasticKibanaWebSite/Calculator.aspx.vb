
Partial Class Calculator
    Inherits System.Web.UI.Page

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)
        Dim num1 = Double.Parse(txtNum1.Text)
        Dim num2 = Double.Parse(txtNum2.Text)

        txtResult.Text = num1 / num2
    End Sub
End Class
