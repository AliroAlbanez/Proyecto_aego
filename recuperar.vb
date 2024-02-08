Module recuperar
    Public controlesFechas(0, 0) As String
    Public detalle(0, 0) As String
    Public examenesDeControl(4, 0) As String
    Public fechaeco22_24(0, 0) As String
    Public fechaeco11_14(0, 0) As String
    Dim sql As String

    Private Sub buscarPareja(ByVal rutPareja)
        Dim parejaAsociada(0, 0) As String

        sql = "SELECT * FROM pareja WHERE rut_p='" & rutPareja & "';"
        ReDim general.consultaVector(9)
        general.consultaVector(0) = "nombre_p"
        general.consultaVector(1) = "celular2_p"
        general.consultaVector(2) = "celular1_p"
        general.consultaVector(3) = "domicilio_p"
        general.consultaVector(4) = "ciudad_p"
        general.consultaVector(5) = "nacimiento_p"
        general.consultaVector(6) = "edad_p"
        general.consultaVector(7) = "actividad"
        general.consultaVector(8) = "civil"
        general.consultaVector(9) = "prevision_p"


        parejaAsociada = general.recuperar(sql)

        Form1.TextBox24.Text = rutPareja
        Form1.TextBox27.Text = parejaAsociada(0, 0)
        Form1.MaskedTextBox3.Text = parejaAsociada(1, 0)
        Form1.MaskedTextBox2.Text = parejaAsociada(2, 0)
        Form1.TextBox25.Text = parejaAsociada(3, 0)
        Form1.DateTimePicker3.Text = general.fechasVoltear(parejaAsociada(5, 0))
        Form1.MaskedTextBox1.Text = parejaAsociada(6, 0)
        Form1.TextBox32.Text = parejaAsociada(7, 0)
        Form1.ComboBox2.SelectedIndex = CInt(parejaAsociada(8, 0))
        Form1.ComboBox5.SelectedIndex = CInt(parejaAsociada(9, 0) - 1)

        For i = 0 To cargasCombobox.Mregiones.GetUpperBound(1)
            If parejaAsociada(4, 0).Substring(0, 2) = cargasCombobox.Mregiones(0, i) Then
                Form1.ComboBox7.SelectedIndex = i
            End If
        Next
        For i = 0 To cargasCombobox.Mcomunas.GetUpperBound(1)
            If parejaAsociada(4, 0) = cargasCombobox.Mcomunas2(0, i) Then
                Form1.ComboBox6.SelectedIndex = i
            End If
        Next
    End Sub

    Public Sub fechaControles(ByVal rutPaciente)
        Form1.DataGridView1.RowCount = 0

        sql = "SELECT id_control, fecha_control FROM controles WHERE rut_paciente='" & rutPaciente & "';"
        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_control"
        general.consultaVector(1) = "fecha_control"

        controlesFechas = general.recuperar(sql)

        If controlesFechas(0, 0) <> "" Then
            For i = 0 To controlesFechas.GetUpperBound(1)
                Form1.DataGridView1.RowCount = i + 1
                Form1.DataGridView1(0, i).Value = controlesFechas(1, i)
                Form1.DataGridView1.RowHeadersVisible = False
            Next
        End If
    End Sub




    Public Sub fecha11_14(ByVal rut11)

        ecoDoppler11y14.DataGridView1.RowCount = 0
        sql = "SELECT id, fecha FROM `eco_doopler11_14` WHERE rut_paciente='" & rut11 & "';"
        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id"
        general.consultaVector(1) = "fecha"

        fechaeco11_14 = general.recuperar(sql)

        If fechaeco11_14(0, 0) <> "" Then
            For i = 0 To fechaeco11_14.GetUpperBound(1)
                ecoDoppler11y14.DataGridView1.RowCount = i + 1
                ecoDoppler11y14.DataGridView1(0, i).Value = fechaeco11_14(1, i)
                ecoDoppler11y14.DataGridView1.RowHeadersVisible = False
            Next

        End If
    End Sub


    Public Sub referenciasNombres()
        Dim nombres(0, 0) As String
        Try
            sql = "SELECT nombre FROM paciente;"
            ReDim general.consultaVector(0)
            general.consultaVector(0) = "nombre"

            nombres = general.recuperar(sql)

            Form1.Text.AutoCompleteCustomSource.Clear()

            If nombres(0, 0) <> "" Then
                For i = 0 To nombres.GetUpperBound(1)
                    Form1.Text.AutoCompleteCustomSource.Add(nombres(0, i))


                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub buscarPaciente(ByVal dato)
        Dim paciente(26, 0) As String
        sql = "SELECT * FROM paciente WHERE rut='" & Form1.Text.Text & "' OR nombre='" & Form1.Text.Text & "';"
        ReDim general.consultaVector(26)
        general.consultaVector(0) = "rut"
        general.consultaVector(1) = "pareja"
        general.consultaVector(2) = "nombre"
        general.consultaVector(3) = "celular2"
        general.consultaVector(4) = "celular1"
        general.consultaVector(5) = "domicilio"
        general.consultaVector(6) = "ciudad"
        general.consultaVector(7) = "fecha_n"
        general.consultaVector(8) = "edad"
        general.consultaVector(9) = "prevision"
        general.consultaVector(10) = "motivo_c"
        general.consultaVector(11) = "epi"
        general.consultaVector(12) = "medicamento"
        general.consultaVector(13) = "riesgo"
        general.consultaVector(14) = "alergia"
        general.consultaVector(15) = "o_gine"
        general.consultaVector(16) = "o_no_gine"
        general.consultaVector(17) = "embarazo"
        general.consultaVector(18) = "partos"
        general.consultaVector(19) = "perdidas"
        general.consultaVector(20) = "PAP"
        general.consultaVector(21) = "FUR"
        general.consultaVector(22) = "regular"
        general.consultaVector(23) = "duracion"
        general.consultaVector(24) = "fecha_consulta"
        general.consultaVector(25) = "actividad"
        general.consultaVector(26) = "foto"

        paciente = general.recuperar(sql)

        If paciente(0, 0) <> "" Then
            Form1.TextBox4.Text = paciente(0, 0)
            Form1.TextBox1.Text = paciente(2, 0)
            Form1.Label13.Text = Form1.TextBox1.Text

            Form1.MaskedTextBox5.Text = paciente(3, 0)
            Form1.MaskedTextBox4.Text = paciente(4, 0)
            Form1.TextBox3.Text = paciente(5, 0)
            Form1.DateTimePicker2.Text = general.fechasVoltear(paciente(7, 0))
            Form1.MaskedTextBox6.Text = paciente(8, 0)
            Form1.ComboBox4.SelectedIndex = CInt(paciente(9, 0)) - 1
            Form1.TextBox9.Text = paciente(10, 0)
            Form1.TextBox10.Text = paciente(11, 0)
            Form1.TextBox11.Text = paciente(12, 0)
            Form1.TextBox12.Text = paciente(13, 0)
            Form1.TextBox13.Text = paciente(14, 0)
            Form1.TextBox14.Text = paciente(15, 0)
            Form1.TextBox15.Text = paciente(16, 0)
            Form1.MaskedTextBox8.Text = paciente(17, 0)
            Form1.MaskedTextBox9.Text = paciente(18, 0)
            Form1.MaskedTextBox10.Text = paciente(19, 0)
            Form1.DateTimePicker4.Text = general.fechasVoltear(paciente(20, 0))
            Form1.DateTimePicker6.Text = general.fechasVoltear(paciente(21, 0))
            Form1.MaskedTextBox7.Text = paciente(23, 0)
            Form1.DateTimePicker1.Text = general.fechasVoltear(paciente(24, 0))
            Form1.TextBox2.Text = paciente(25, 0)
            If paciente(22, 0) = "True" Then
                Form1.CheckBox1.Checked = True
                Form1.CheckBox2.Checked = False
            Else
                Form1.CheckBox2.Checked = True
                Form1.CheckBox1.Checked = False
            End If

            If Form1.TextBox14.Text = "" And Form1.TextBox15.Text = "" Then
                Form1.CheckBox3.Checked = True
                Form1.CheckBox4.Checked = False
                Form1.TextBox14.Enabled = False
                Form1.TextBox15.Enabled = False
            Else
                Form1.CheckBox4.Checked = True
                Form1.CheckBox3.Checked = False
                Form1.TextBox14.Enabled = True
                Form1.TextBox15.Enabled = True
            End If

            For i = 0 To cargasCombobox.Mregiones.GetUpperBound(1)
                If paciente(6, 0).Substring(0, 2) = cargasCombobox.Mregiones(0, i) Then
                    Form1.ComboBox1.SelectedIndex = i
                End If
            Next
            For i = 0 To cargasCombobox.Mcomunas.GetUpperBound(1)
                If paciente(6, 0) = cargasCombobox.Mcomunas(0, i) Then
                    Form1.ComboBox3.SelectedIndex = i
                End If
            Next
            If paciente(1, 0) <> "00000000-0" Then
                buscarPareja(paciente(1, 0))
            Else
                Form1.TextBox24.Text = ""
                Form1.TextBox27.Text = ""
                Form1.MaskedTextBox3.Text = ""
                Form1.MaskedTextBox2.Text = ""
                Form1.TextBox25.Text = ""
                Form1.DateTimePicker3.Text = Now
                Form1.MaskedTextBox1.Text = ""
                Form1.TextBox32.Text = ""
                Form1.ComboBox2.SelectedIndex = 0
                Form1.ComboBox5.SelectedIndex = 0
                Form1.ComboBox7.SelectedIndex = 3
                Form1.ComboBox6.SelectedIndex = 0


            End If
            If paciente(26, 0) <> "" Then
                Form1.PictureBox1.BackgroundImage = Image.FromFile(paciente(26, 0).Replace("|", "\"))
            End If
            fechaControles(paciente(0, 0))
            recuperarExamenesPedidos(paciente(0, 0), "LIKE '%%';")


            Form1.DataGridView4.Rows.Clear()
            Form1.DataGridView3.Rows.Clear()
            If examenesDeControl(0, 0) <> "" Then
                For i = 0 To examenesDeControl.GetUpperBound(1)
                    If examenesDeControl(5, i) <> "0" Then
                        Dim b As Integer = Form1.DataGridView4.RowCount
                        Form1.DataGridView4.RowCount = Form1.DataGridView4.RowCount + 1
                        Form1.DataGridView4(0, b).Value = examenesDeControl(0, i)
                        Form1.DataGridView4(1, b).Value = examenesDeControl(1, i)
                        Form1.DataGridView4(2, b).Value = examenesDeControl(4, i)
                        Form1.DataGridView4(3, b).Value = examenesDeControl(3, i)
                        Form1.DataGridView4(4, b).Value = examenesDeControl(2, i)
                    Else
                        Dim b As Integer = Form1.DataGridView3.RowCount
                        Form1.DataGridView3.RowCount = Form1.DataGridView3.RowCount + 1
                        Form1.DataGridView3(1, b).Value = examenesDeControl(0, i)
                        Form1.DataGridView3(2, b).Value = examenesDeControl(3, i)
                        Form1.DataGridView3(3, b).Value = examenesDeControl(2, i)
                    End If



                Next
            End If
        End If
    End Sub

    Public Sub Buscareco11_14(ByVal numeroe)
        Dim eco11_14(0, 0) As String
        Dim id As String
        sql = "SELECT *  FROM `eco_doopler11_14` WHERE id='" & numeroe & "';"
        ReDim general.consultaVector(23)
        general.consultaVector(0) = "rut_paciente"
        general.consultaVector(1) = "fecha"
        general.consultaVector(2) = "sra_nombre"
        general.consultaVector(3) = "presentacion"
        general.consultaVector(4) = "descripcion"
        general.consultaVector(5) = "diametro_biparental"
        general.consultaVector(6) = "perimetro_cefalico"
        general.consultaVector(7) = "perimetro_abdominal"
        general.consultaVector(8) = "femur"
        general.consultaVector(9) = "epf"
        general.consultaVector(10) = "tn"
        general.consultaVector(11) = "huesonasal"
        general.consultaVector(12) = "columna"
        general.consultaVector(13) = "craneo"
        general.consultaVector(14) = "cara"
        general.consultaVector(15) = "torax"
        general.consultaVector(16) = "abdomen"
        general.consultaVector(17) = "extremidades"
        general.consultaVector(18) = "fetalductus_venoso"
        general.consultaVector(19) = "maternoart_uderecha"
        general.consultaVector(20) = "maternoart_uizquierda"
        general.consultaVector(21) = "promedio"
        general.consultaVector(22) = "id"

        eco11_14 = general.recuperar(sql)

        ecoDoppler11y14.Label16.Text = eco11_14(2, 0)
        ecoDoppler11y14.presentacion.Text = eco11_14(3, 0)
        ecoDoppler11y14.TextBox1.Text = eco11_14(4, 0)
        ecoDoppler11y14.TextBox22.Text = eco11_14(5, 0)
        ecoDoppler11y14.TextBox28.Text = eco11_14(6, 0)
        ecoDoppler11y14.TextBox29.Text = eco11_14(7, 0)
        ecoDoppler11y14.TextBox30.Text = eco11_14(8, 0)
        ecoDoppler11y14.TextBox34.Text = eco11_14(9, 0)
        ecoDoppler11y14.TextBox35.Text = eco11_14(10, 0)
        ecoDoppler11y14.TextBox23.Text = eco11_14(11, 0)
        ecoDoppler11y14.TextBox5.Text = eco11_14(12, 0)
        ecoDoppler11y14.TextBox4.Text = eco11_14(13, 0)
        ecoDoppler11y14.TextBox3.Text = eco11_14(14, 0)
        ecoDoppler11y14.TextBox2.Text = eco11_14(15, 0)
        ecoDoppler11y14.TextBox18.Text = eco11_14(16, 0)
        ecoDoppler11y14.TextBox17.Text = eco11_14(17, 0)

        ecoDoppler11y14.TextBox7.Text = eco11_14(18, 0)
        ecoDoppler11y14.TextBox8.Text = eco11_14(19, 0)
        ecoDoppler11y14.TextBox9.Text = eco11_14(20, 0)
        ecoDoppler11y14.Label32.Text = eco11_14(21, 0)

        id = eco11_14(22, 0)

    End Sub

    Public Sub buscarControl(ByVal numero)
        Dim controlEncontrado(0, 0) As String
        sql = "SELECT c.*, m.nombre_motivo as n_motivo FROM controles c INNER JOIN motivo m ON c.nombre_motivo=m.id_motivo WHERE id_control='" & numero & "'"
        ReDim general.consultaVector(7)
        general.consultaVector(0) = "fecha_control"
        general.consultaVector(1) = "n_motivo"
        general.consultaVector(2) = "peso"
        general.consultaVector(3) = "presion_arterial"
        general.consultaVector(4) = "observaciones"
        general.consultaVector(5) = "solicitud_examenes"
        general.consultaVector(6) = "fecha_modificacion"
        general.consultaVector(7) = "descripcion_mod"



        controlEncontrado = general.recuperar(sql)

        Form1.DateTimePicker12.Text = fechasVoltear(controlEncontrado(0, 0))
        Form1.TextBox23.Text = controlEncontrado(1, 0)
        Form1.TextBox30.Text = controlEncontrado(2, 0)
        Form1.TextBox29.Text = controlEncontrado(3, 0)
        Form1.TextBox28.Text = controlEncontrado(4, 0)
        Form1.DateTimePicker11.Text = fechasVoltear(controlEncontrado(6, 0))
        Form1.TextBox2.Text = controlEncontrado(7, 0)


        If controlEncontrado(5, 0) = "True" Then
            Form1.CheckBox7.Checked = True
            Form1.CheckBox8.Checked = False
        Else
            Form1.CheckBox8.Checked = False
            Form1.CheckBox7.Checked = True
        End If

        recuperarExamenesPedidos(Form1.TextBox4.Text, "='" & numero & "';")
        Form1.DataGridView5.Rows.Clear()

        If examenesDeControl(0, 0) <> "" Then
            For i = 0 To examenesDeControl.GetUpperBound(1)
                Form1.DataGridView5.RowCount = Form1.DataGridView5.RowCount + 1
                Form1.DataGridView5(0, i).Value = examenesDeControl(0, i)
            Next
        End If

    End Sub

    Public Sub buscarPartos(ByVal rut)
        sql = "SELECT * FROM `embarazos` WHERE rut_paciente='" & rut & "';"
        ReDim general.consultaVector(1)
        general.consultaVector(0) = "n_parto"
        general.consultaVector(1) = "estado_p"
        Guardados.partos = general.recuperar(sql)
    End Sub

    Public Sub recuperarPrenatal()
        Dim prenatal(0, 0) As String

        sql = "SELECT * FROM `control_prenatal` WHERE rut_paciente='" & Form1.TextBox4.Text & "';"
        ReDim general.consultaVector(12)
        general.consultaVector(0) = "fecha"
        general.consultaVector(1) = "peso"
        general.consultaVector(2) = "pa"
        general.consultaVector(3) = "lcf"
        general.consultaVector(4) = "altut"
        general.consultaVector(5) = "present"
        general.consultaVector(6) = "patologias"
        general.consultaVector(7) = "indicaciones"
        general.consultaVector(8) = "ed_gestacional"
        general.consultaVector(9) = "control"
        general.consultaVector(10) = "fur"
        general.consultaVector(11) = "fur_operacional"
        general.consultaVector(12) = "fpp"

        prenatal = general.recuperar(sql)

        If prenatal(0, 0) <> "" Then
            Form1.DataGridView6.RowCount = 0
            For i = 0 To prenatal.GetUpperBound(1)
                Form1.DataGridView6.RowCount = i + 1
                For j = 0 To 12
                    Form1.DataGridView6(j, i).Value = prenatal(j, i)
                Next
            Next
        End If
    End Sub

    Public Sub recuperarExamenesPedidos(ByVal rut, ByVal control)
        sql = "SELECT * FROM `examensol` WHERE rut ='" & rut & "' AND id_control " & control
        ReDim general.consultaVector(5)
        general.consultaVector(0) = "nombre"
        general.consultaVector(1) = "detalles"
        general.consultaVector(2) = "id_control"
        general.consultaVector(3) = "fecha_sol"
        general.consultaVector(4) = "fecha_entre"
        general.consultaVector(5) = "entrega"
        ReDim examenesDeControl(5, 0)
        examenesDeControl = general.recuperar(sql)
    End Sub
    Public Sub fecha22_24(ByVal rut)

        ecoDoppler24.DataGridView1.RowCount = 0
        sql = "SELECT id, fecha FROM `eco_doopler22_24` WHERE rut_paciente='" & rut & "';"
        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id"
        general.consultaVector(1) = "fecha"

        fechaeco22_24 = general.recuperar(sql)

        If fechaeco22_24(0, 0) <> "" Then
            For i = 0 To fechaeco22_24.GetUpperBound(1)
                ecoDoppler24.DataGridView1.RowCount = i + 1
                ecoDoppler24.DataGridView1(0, i).Value = fechaeco22_24(1, i)
                ecoDoppler24.DataGridView1.RowHeadersVisible = False
            Next

        End If
    End Sub
    Public Sub Buscareco22_24(ByVal numeroo)
        Dim eco22_24(0, 0) As String

        sql = "SELECT *  FROM `eco_doopler22_24` WHERE id='" & numeroo & "';"
        ReDim general.consultaVector(27)
        general.consultaVector(0) = "rut_paciente"
        general.consultaVector(1) = "fecha"
        general.consultaVector(2) = "sra_nombre"
        general.consultaVector(3) = "presentacion"
        general.consultaVector(4) = "descripcion"
        general.consultaVector(5) = "diametro_biparental"
        general.consultaVector(6) = "perimetro_cefalico"
        general.consultaVector(7) = "perimetro_abdominal"
        general.consultaVector(8) = "femur"
        general.consultaVector(9) = "cerebelo"
        general.consultaVector(10) = "cisterna_magna"
        general.consultaVector(11) = "ventriculo_lateral"
        general.consultaVector(12) = "epf"
        general.consultaVector(13) = "columna"
        general.consultaVector(14) = "craneo"
        general.consultaVector(15) = "cara"
        general.consultaVector(16) = "torax"
        general.consultaVector(17) = "abdomen"
        general.consultaVector(18) = "extremidades"
        general.consultaVector(19) = "fetalductus_venoso"
        general.consultaVector(20) = "maternoart_uderecha"
        general.consultaVector(21) = "maternoart_uizquierda"
        general.consultaVector(22) = "promedio"
        general.consultaVector(23) = "arteria_cerebral_media"
        general.consultaVector(24) = "arteria_umbilical"
        general.consultaVector(25) = "indicecerebro_placentario"
        general.consultaVector(26) = "id"


        eco22_24 = general.recuperar(sql)

        ecoDoppler24.Label16.Text = eco22_24(2, 0)
        ecoDoppler24.ComboBox11.Text = eco22_24(3, 0)
        ecoDoppler24.TextBox1.Text = eco22_24(4, 0)
        ecoDoppler24.TextBox22.Text = eco22_24(5, 0)
        ecoDoppler24.TextBox28.Text = eco22_24(6, 0)
        ecoDoppler24.TextBox29.Text = eco22_24(7, 0)
        ecoDoppler24.TextBox30.Text = eco22_24(8, 0)
        ecoDoppler24.TextBox34.Text = eco22_24(9, 0)
        ecoDoppler24.TextBox35.Text = eco22_24(10, 0)
        ecoDoppler24.TextBox23.Text = eco22_24(11, 0)
        ecoDoppler24.TextBox36.Text = eco22_24(12, 0)
        ecoDoppler24.TextBox5.Text = eco22_24(13, 0)
        ecoDoppler24.TextBox4.Text = eco22_24(14, 0)
        ecoDoppler24.TextBox3.Text = eco22_24(15, 0)
        ecoDoppler24.TextBox2.Text = eco22_24(16, 0)
        ecoDoppler24.TextBox18.Text = eco22_24(17, 0)
        ecoDoppler24.TextBox17.Text = eco22_24(18, 0)
        ecoDoppler24.TextBox7.Text = eco22_24(19, 0)
        ecoDoppler24.TextBox8.Text = eco22_24(20, 0)
        ecoDoppler24.TextBox9.Text = eco22_24(21, 0)
        ecoDoppler24.Label32.Text = eco22_24(22, 0)
        ecoDoppler24.TextBox11.Text = eco22_24(23, 0)
        ecoDoppler24.TextBox12.Text = eco22_24(24, 0)
        ecoDoppler24.Label35.Text = eco22_24(25, 0)



    End Sub
End Module
