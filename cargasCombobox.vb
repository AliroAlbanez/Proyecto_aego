Module cargasCombobox
    Public Mregiones(0, 0) As String
    Public Mcomunas(0, 0) As String
    Public Mcomunas2(0, 0) As String
    Public Mprevision(0, 0) As String
    Public motivo(0, 0) As String
    Public familia(0, 0) As String
    Public examen(0, 0) As String
    Public llenar(0, 0) As String

    Dim sql As String
    Public Sub regiones()
        sql = "SELECT * FROM regiones;"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_region"
        general.consultaVector(1) = "nombre_region"

        ReDim Mregiones(0, 0)

        Mregiones = general.recuperar(sql)

        Form1.ComboBox1.Items.Clear()
        Form1.ComboBox7.Items.Clear()
        For i = 0 To Mregiones.GetUpperBound(1)
            Form1.ComboBox1.Items.Add(Mregiones(1, i))
            Form1.ComboBox7.Items.Add(Mregiones(1, i))
        Next

        Form1.ComboBox1.SelectedIndex = 3
        Form1.ComboBox7.SelectedIndex = 3
    End Sub

    Public Sub comunas()
        sql = "SELECT id_comuna, nombre_comuna FROM comunas WHERE id_comuna LIKE '" & Mregiones(0, Form1.ComboBox1.SelectedIndex) & "%';"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_comuna"
        general.consultaVector(1) = "nombre_comuna"

        ReDim Mcomunas(0, 0)

        Mcomunas = general.recuperar(sql)

        Form1.ComboBox3.Items.Clear()

        For i = 0 To Mcomunas.GetUpperBound(1)
            Form1.ComboBox3.Items.Add(Mcomunas(1, i))
        Next

        Form1.ComboBox3.SelectedIndex = 0
    End Sub

    Public Sub comunas2()
        sql = "SELECT id_comuna, nombre_comuna FROM comunas WHERE id_comuna LIKE '" & Mregiones(0, Form1.ComboBox7.SelectedIndex) & "%';"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_comuna"
        general.consultaVector(1) = "nombre_comuna"

        ReDim Mcomunas2(0, 0)

        Mcomunas2 = general.recuperar(sql)

        Form1.ComboBox6.Items.Clear()

        For i = 0 To Mcomunas2.GetUpperBound(1)
            Form1.ComboBox6.Items.Add(Mcomunas2(1, i))
        Next

        Form1.ComboBox6.SelectedIndex = 0
    End Sub

    Public Sub previsiones()
        sql = "SELECT * FROM prevision;"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_prev"
        general.consultaVector(1) = "nombre_prev"

        ReDim Mprevision(0, 0)

        Mprevision = general.recuperar(sql)

        Form1.ComboBox4.Items.Clear()
        Form1.ComboBox5.Items.Clear()

        If Mprevision(0, 0) <> "" Then
            For i = 0 To Mprevision.GetUpperBound(1)
                Form1.ComboBox4.Items.Add(Mprevision(1, i))
                Form1.ComboBox5.Items.Add(Mprevision(1, i))
            Next

            Form1.ComboBox4.SelectedIndex = 0
            Form1.ComboBox5.SelectedIndex = 0
        End If
    End Sub


    Public Sub Motivos()

        sql = "SELECT * FROM motivo;"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id_motivo"
        general.consultaVector(1) = "nombre_motivo"

        ReDim motivo(0, 0)

        motivo = general.recuperar(sql)

        Form1.ComboBox8.Items.Clear()

        For i = 0 To motivo.GetUpperBound(1)
            Form1.ComboBox8.Items.Add(motivo(1, i))
        Next
        Form1.ComboBox8.SelectedIndex = 0

    End Sub

    Public Sub examenescombo()
        sql = "SELECT id_examen, nombre, id_familia FROM examenes WHERE id_familia = '" & familia(0, Form1.ComboBox9.SelectedIndex) & "';"

        ReDim general.consultaVector(2)
        general.consultaVector(0) = "id_examen"
        general.consultaVector(1) = "nombre"
        general.consultaVector(2) = "id_familia"

        ReDim examen(0, 0)

        examen = general.recuperar(sql)

        Form1.DataGridView2.RowCount = 0

        For i = 0 To examen.GetUpperBound(1)
            Form1.DataGridView2.RowCount = i + 1
            Form1.DataGridView2(1, i).Value = examen(1, i)
        Next

    End Sub
    Public Sub familiaexamenes()

        sql = "SELECT * FROM familiasexamenes;"

        ReDim general.consultaVector(1)
        general.consultaVector(0) = "id"
        general.consultaVector(1) = "nombre_grupo"

        ReDim familia(0, 0)

        familia = general.recuperar(sql)

        Form1.ComboBox9.Items.Clear()

        For i = 0 To familia.GetUpperBound(1)
            Form1.ComboBox9.Items.Add(familia(1, i))
        Next



    End Sub

    Public Sub presente()


        ecoDoppler11y14.presentacion.Items.Add("Podalica")
        ecoDoppler11y14.presentacion.Items.Add("Cefalica")
        ecoDoppler11y14.presentacion.Items.Add("Transversa")
        ecoDoppler11y14.presentacion.SelectedIndex = 0
        Form1.ComboBox11.Items.Add("Podalica")
        Form1.ComboBox11.Items.Add("Cefalica")
        Form1.ComboBox11.Items.Add("Transversa")
        Form1.ComboBox11.SelectedIndex = 0
        ecoDoppler24.ComboBox11.Items.Add("Podalica")
        ecoDoppler24.ComboBox11.Items.Add("Cefalica")
        ecoDoppler24.ComboBox11.Items.Add("Transversa")
        ecoDoppler24.ComboBox11.SelectedIndex = 0



    End Sub

End Module
