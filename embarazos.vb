Public Class embarazos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.RowCount > 0 Then
            ReDim Guardados.partos(1, DataGridView1.RowCount - 1)
            For i = 0 To DataGridView1.RowCount - 1

                Guardados.partos(0, i) = DataGridView1(0, i).Value
                Guardados.partos(1, i) = DataGridView1(1, i).Value
            Next
            Try
                Guardados.guardarPartos()

            Catch ex As Exception

            End Try
            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub embarazos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Guardados.partos(0, 0) <> "" Then
            Try

                For i = 0 To DataGridView1.RowCount - 1

                    DataGridView1(1, i).Value = Guardados.partos(1, i)


                Next
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class