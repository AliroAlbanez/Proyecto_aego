Imports System.ComponentModel
Imports Microsoft.Office.Interop.Word
Imports System.Diagnostics
Imports Microsoft.Office.Interop

Public Class ecoDoppler24

    Dim pregunta As DialogResult
    Dim Application As Application
    Dim Documento As Word.Document

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        recuperar.fecha22_24(Form1.TextBox4.Text)
        Label16.Text = Form1.TextBox1.Text
    End Sub




    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.RowCount > 0 Then
            recuperar.Buscareco22_24(recuperar.fechaeco22_24(0, DataGridView1.CurrentRow.Index))

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ard, ari, promedio As Double
        ard = TextBox8.Text
        ari = TextBox9.Text
        promedio = (ard + ari) / 2
        Label32.Text = promedio
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ard, ari, promedio As Double
        ard = TextBox11.Text
        ari = TextBox12.Text
        promedio = (ard + ari) / 2
        Label35.Text = promedio
    End Sub

    Private Sub ecoDoppler22y24_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing



        pregunta = MessageBox.Show("esta seguro que desea cerrar esta ventana", "cerrar ventana", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If pregunta = DialogResult.No Then

            e.Cancel = True

        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        pregunta = MessageBox.Show("¿Desea Guardar la ecotomografia Actual?", "Guardar ecoDoppler22/24", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If pregunta = DialogResult.Yes Then

            Guardados.GuardarecoDopler22_24()
            recuperar.fecha22_24(Form1.TextBox4.Text)
            MessageBox.Show("datos guardados con exito")

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim MSWord As New Word.Application
        Documento = MSWord.Documents.Open("\\DESKTOP-RIHORNI\Users\Public\aego\plantillas word\24smn.dotx")
        MSWord.Visible = True
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = Label15.Text

        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=Label16.Text)


        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "presentación "
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=ComboBox11.Text)
        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Diámetro biparietal			:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox22.Text)
        End If


        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Perímetro Cefálico			:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox28.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Perímetro Abdominal		:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox29.Text)
        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Fémur					:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox30.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Cerebelo				:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox34.Text)
        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Cisterna Magna			:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox35.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Ventrículo lateral cuerno posterior:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox23.Text)


        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "EPF					:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox36.Text)

        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Columna:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox5.Text)

        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Cráneo:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox4.Text)

        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Cara:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox3.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Tórax:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox2.Text)

        End If

        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Abdomen:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox18.Text)

        End If


        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Extremidades:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=1)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox17.Text)

        End If



        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Ductus Venoso"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=2)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox7.Text)

        End If


        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Arteria Uterina Derecha"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=2)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox8.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Arteria Uterina   Izquierda"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=2)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=TextBox9.Text)

        End If
        'BUSCAMOS EL TEXTO
        Documento.ActiveWindow.Selection.Find.Text = "Promedio:"
        Documento.ActiveWindow.Selection.Find.Forward = True
        Documento.ActiveWindow.Selection.Find.MatchCase = False

        'SI SI SE ENCONTRO EL TEXTO
        If Documento.ActiveWindow.Selection.Find.Execute() Then
            'NOS MOVEMO S UNA LINEA ADELANTE
            Documento.ActiveWindow.Selection.MoveRight(Unit:=WdUnits.wdCharacter, Count:=2)
            'ESCRIBIMOS
            Documento.ActiveWindow.Selection.TypeText(Text:=Label32.Text)

        End If

    End Sub

End Class
