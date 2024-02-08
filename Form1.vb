

Imports System.ComponentModel
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Public Class Form1
    Public regla As Integer = 1
    Public examenes As Integer = 0
    Dim respado As String = ""
    Dim pregunta As DialogResult
    Public filasPartos As Integer
    Dim sql As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargasCombobox.regiones()
        cargasCombobox.previsiones()
        cargasCombobox.Motivos()
        cargasCombobox.familiaexamenes()
        cargasCombobox.presente()
        recuperar.referenciasNombres()
        Label79.Text = DateTimePicker5.Text
        Panel2_examen.Visible = False
        DateTimePicker11.Enabled = False
        Button9.Enabled = False
        Panel7.Visible = False
        Panel6.Visible = False
        DateTimePicker1.Value = System.DateTime.Now
        DateTimePicker2.Value = System.DateTime.Now
        DateTimePicker3.Value = System.DateTime.Now

        TextBox6.Text = TextBox31.Text
        DateTimePicker5.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cargasCombobox.comunas()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        cargasCombobox.comunas2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If DataGridView1.RowCount > 0 Then
            recuperar.buscarControl(recuperar.controlesFechas(0, DataGridView1.CurrentRow.Index))

        End If


    End Sub


    Private Sub CheckBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox3.MouseClick
        If CheckBox3.Checked = False Then
            CheckBox4.Checked = True
            TextBox14.Enabled = True
            TextBox15.Enabled = True
        Else
            CheckBox4.Checked = False
            TextBox14.Enabled = False
            TextBox15.Enabled = False

        End If
    End Sub

    Private Sub CheckBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox4.MouseClick
        If CheckBox4.Checked = False Then
            CheckBox3.Checked = True
            TextBox14.Enabled = False
            TextBox15.Enabled = False

        Else
            CheckBox3.Checked = False
            TextBox14.Enabled = True
            TextBox15.Enabled = True
        End If
    End Sub

    Private Sub CheckBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox1.MouseClick
        If CheckBox1.Checked = False Then
            CheckBox2.Checked = True
            regla = 0
        Else
            CheckBox2.Checked = False
            regla = 1
        End If
    End Sub

    Private Sub CheckBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox2.MouseClick
        If CheckBox2.Checked = False Then
            CheckBox1.Checked = True
            regla = 1
        Else
            CheckBox1.Checked = False
            regla = 0
        End If
    End Sub

    Private Sub CheckBox6_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox6.MouseClick
        If CheckBox6.Checked = False Then

            Button9.Enabled = False
            ComboBox9.Enabled = False
            DataGridView2.Enabled = False
            examenes = 0
        Else


            ComboBox9.Enabled = True
            DataGridView2.Enabled = True
            Button9.Enabled = True

            examenes = 1
        End If
    End Sub


    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged
        Try
            If TextBox31.Text <> "" Then
                respado = CDec(TextBox31.Text)
            Else
                respado = ""
            End If
        Catch ex As Exception
            TextBox31.Text = respado
        End Try
    End Sub


    Private Sub botonBuscar_Click(sender As Object, e As EventArgs) Handles botonBuscar.Click
        recuperar.buscarPaciente(Text.Text)
        recuperar.buscarPartos(TextBox4.Text)
        recuperar.recuperarPrenatal()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If TextBox1.Text = "" Then
                MessageBox.Show("Por favor busque ficha clinica de la paciente", "busqueda ficha", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                pregunta = MessageBox.Show("¿Desea Guardar el control Actual?", "Guardar Control", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If pregunta = DialogResult.Yes Then

                    Guardados.guradarControl()
                    MessageBox.Show("Datos guardados con exito")
                    recuperar.fechaControles(TextBox4.Text)

                End If
            End If
        Catch

            MessageBox.Show("Error para guardar los datos asegurese de que este el rut de la paciente ")

        End Try
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        cargasCombobox.examenescombo()
    End Sub


    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click
        Try
            If filasPartos > 0 Then
                ReDim Preserve Guardados.partos(1, filasPartos)
                embarazos.DataGridView1.RowCount = filasPartos
                For i = 0 To filasPartos - 1
                    embarazos.DataGridView1(0, i).Value = i + 1
                Next
                embarazos.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub MaskedTextBox8_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBox8.TextChanged
        Try
            filasPartos = CInt(MaskedTextBox8.Text)
        Catch ex As Exception
            filasPartos = 0
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MainForm.Show()
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2_examen.Visible = True
        Panel6.Visible = False
        Panel7.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Panel2_examen.Visible = False
        Panel7.Visible = False
        Panel6.Visible = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel7.Visible = True
        Panel2_examen.Visible = False
        Panel6.Visible = False


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim pos As Integer
        For i = 0 To DataGridView2.RowCount - 1
            If DataGridView2(0, i).Value = True Then

                pos = DataGridView3.Rows.Count
                DataGridView3.Rows.Add()

                DataGridView3.Rows(pos).Cells(1).Value = DataGridView2(1, i).Value
                DataGridView3.Rows(pos).Cells(2).Value = DateTimePicker5.Text
                DataGridView3.Rows(pos).Cells(3).Value = "Actual"
            End If
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EliminarFIlasExamenes(0)
    End Sub

    Private Sub EliminarFIlasExamenes(ByVal a)
        If DataGridView3.RowCount > 0 Then
            Dim vector(0) As Integer
            Dim contador As Integer = 0
            Dim contador2 As Integer = 0
            For i = 0 To DataGridView3.RowCount - 1
                If DataGridView3(0, i).Value = True Then
                    contador = contador + 1
                    If a = 1 Then
                        Dim b As Integer = DataGridView4.RowCount
                        DataGridView4.RowCount = DataGridView4.RowCount + 1
                        DataGridView4(0, b).Value = DataGridView3(1, i).Value
                        DataGridView4(2, b).Value = DateTimePicker5.Text
                        DataGridView4(3, b).Value = DataGridView3(2, i).Value
                        DataGridView4(4, b).Value = DataGridView3(3, i).Value
                        sql = "UPDATE `examensol` SET `entrega`='1' WHERE `nombre`= '" & DataGridView3(1, i).Value & "' AND `id_control`= '" & DataGridView3(3, i).Value & "' AND `fecha_sol`= '" & general.fechasVoltear(DataGridView3(2, i).Value) & "';"
                        general.IngresarDatos(sql)
                    End If
                End If
            Next
            contador2 = contador - 1
            ReDim vector(contador)

            For i = 0 To DataGridView3.RowCount - 1
                If DataGridView3(0, i).Value = True Then
                    vector(contador2) = i
                    contador2 = contador2 - 1
                End If
            Next

            For i = 0 To contador - 1
                DataGridView3.Rows.RemoveAt(vector(i))
            Next
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        EliminarFIlasExamenes(1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If DataGridView4.RowCount > 0 Then
            Dim a As Integer = DataGridView4.CurrentRow.Index
            Dim b As Integer = DataGridView3.RowCount
            DataGridView3.RowCount = DataGridView3.RowCount + 1
            DataGridView3(1, b).Value = DataGridView4(0, a).Value
            DataGridView3(2, b).Value = DataGridView4(3, a).Value
            DataGridView3(3, b).Value = DataGridView4(4, a).Value
            sql = "UPDATE `examensol` SET `entrega`='0' WHERE `nombre`= '" & DataGridView4(0, a).Value & "' AND `id_control`= '" & DataGridView4(4, a).Value & "' AND `fecha_sol`= '" & general.fechasVoltear(DataGridView4(3, a).Value) & "';"
            general.IngresarDatos(sql)
            DataGridView4.Rows.RemoveAt(a)
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel6.Visible = True
        Panel2_examen.Visible = False

        Panel7.Visible = False
    End Sub




    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.RowCount > 0 Then
            recuperar.buscarControl(recuperar.controlesFechas(0, DataGridView1.CurrentRow.Index))

        End If

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing

        pregunta = MessageBox.Show("¿desea cerrar sesión?", "cerrar programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If pregunta = DialogResult.No Then

            e.Cancel = True

        Else

            e.Cancel = False

            login.Show()
            login.Textclave.Text = ""
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        pregunta = MessageBox.Show("¿Desea Guardar Ficha Clinica Actual?", "Guardar Ficha Técnica", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If pregunta = DialogResult.Yes Then


            Guardados.GuardarFichaTecnica()
        End If


    End Sub

    Private Sub Button9_MouseHover(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Cayuda(Button9, "Agregar examenes solicitados")
    End Sub
    'Mensaje de referencia sobre objeto
    Public Sub Cayuda(ByVal objeto As Object, ByVal mensaje As String)
        Ayuda.RemoveAll()
        Ayuda.SetToolTip(objeto, mensaje)
        Ayuda.InitialDelay = 100
        Ayuda.IsBalloon = False
    End Sub

    Private Sub CheckBox6_MouseHover(sender As Object, e As EventArgs) Handles CheckBox6.MouseHover
        Cayuda(CheckBox6, "Marcar la casilla solo si se solictan examenes")
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Cayuda(Button3, "Guardar ficha / cambios")
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        Cayuda(PictureBox1, "Agregar foto")
    End Sub

    Private Sub wordAbrir(ByVal plantilla, ByVal cliente)
        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        'Crea carpeta en este caso le puse en usuarios publicos para evitar problemas al cambiar de pc y se crea la carpeta con el nombre del paciente

        Try
            My.Computer.FileSystem.CreateDirectory("\\DESKTOP-RIHORNI\Users\Public\aego\Pacientes\" & cliente & "\ecos\" & plantilla)
        Catch ex As Exception
        End Try

        Try

            oWord = CreateObject("Word.Application")

            oDoc = oWord.Documents.Add("\\DESKTOP-RIHORNI\Users\Public\aego\plantillas word\" & plantilla & ".dotx")
            Dim fname As String = "\\DESKTOP-RIHORNI\Users\Public\aego\Pacientes\" & cliente & "\ecos\" & plantilla & "\ECO" & plantilla & general.fechasAcotar2(System.DateTime.Now.ToString) & ".docx"
            oDoc.SaveAs(fname)
            oWord.Quit()

            Process.Start(fname)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Por favor busque ficha clinica de la paciente", "busqueda ficha", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Else

            ecoDoppler11y14.Show()
        End If





    End Sub


    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click


        If TextBox1.Text = "" Then
            MessageBox.Show("Por favor busque ficha clinica de la paciente", "busqueda ficha", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Else

            ecoDoppler24.Show()
        End If

    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click


        If TextBox1.Text = "" Then
            MessageBox.Show("Por favor busque ficha clinica de la paciente", "busqueda ficha", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Else
            wordAbrir("ecogine", TextBox1.Text)
        End If


    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Por favor busque ficha clinica de la paciente", "busqueda ficha", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Else
            wordAbrir("endome", TextBox1.Text)
        End If


    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        Cayuda(PictureBox3, "Limpiar ficha")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Text.Text = ""
        TextBox1.Text = ""
        TextBox4.Text = ""
        MaskedTextBox6.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        MaskedTextBox4.Text = ""
        MaskedTextBox5.Text = ""
        MaskedTextBox1.Text = ""
        MaskedTextBox2.Text = ""
        MaskedTextBox3.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        MaskedTextBox8.Text = ""
        MaskedTextBox9.Text = ""
        MaskedTextBox10.Text = ""
        MaskedTextBox7.Text = ""
        TextBox27.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox32.Text = ""
        Label13.Text = ""

    End Sub

    Private Sub botonBuscar_MouseHover(sender As Object, e As EventArgs) Handles botonBuscar.MouseHover
        Cayuda(botonBuscar, "Buscar ficha paciente")
    End Sub

    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Cayuda(Button5, "Guardar Control")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        If pregunta = DialogResult.Yes Then

            Guardados.GuardarCarnetEmbarazo()
            recuperar.recuperarPrenatal()
        End If
    End Sub
End Class
