Module Guardados
    Dim sql As String
    Dim rutPareja As String = ""
    Dim ultimoControl As String
    Public foto As String = ""
    Public partos(1, 0) As String
    Private Sub pareja()
        Try
            If Form1.TextBox24.Text.Length = 9 And Form1.TextBox24.Text.Substring(7, 1) = "-" Then
                Try
                    sql = "INSERT INTO `pareja`(`rut_p`, `nombre_p`, `celular2_p`, `celular1_p`, `domicilio_p`, `ciudad_p`, `nacimiento_p`, `edad_p`, `actividad`, `civil`, `prevision_p`) VALUES ('" & Form1.TextBox24.Text & "','" & Form1.TextBox27.Text & "','" & Form1.MaskedTextBox3.Text & "','" & Form1.MaskedTextBox2.Text & "','" & Form1.TextBox25.Text & "','" & cargasCombobox.Mcomunas2(0, Form1.ComboBox6.SelectedIndex) & "','" & general.fechasVoltear(Form1.DateTimePicker3.Text) & "','" & Form1.MaskedTextBox1.Text & "','" & Form1.TextBox32.Text & "','" & Form1.ComboBox2.SelectedIndex & "','" & cargasCombobox.Mprevision(0, Form1.ComboBox5.SelectedIndex) & "');"
                    general.IngresarDatos(sql)
                Catch ex As Exception
                    sql = "UPDATE `pareja` SET `nombre_p`='" & Form1.TextBox27.Text & "',`celular2_p`='" & Form1.MaskedTextBox3.Text & "',`celular1_p`='" & Form1.MaskedTextBox2.Text & "',`domicilio_p`='" & Form1.TextBox25.Text & "',`ciudad_p`='" & cargasCombobox.Mcomunas2(0, Form1.ComboBox6.SelectedIndex) & "',`nacimiento_p`='" & general.fechasVoltear(Form1.DateTimePicker3.Text) & "',`edad_p`='" & Form1.MaskedTextBox1.Text & "',`actividad`='" & Form1.TextBox32.Text & "',`civil`='" & Form1.ComboBox2.SelectedIndex & "',`prevision_p`='" & cargasCombobox.Mprevision(0, Form1.ComboBox5.SelectedIndex) & "' WHERE `rut_p`='" & Form1.TextBox24.Text & "';"
                    general.IngresarDatos(sql)
                End Try
            ElseIf Form1.TextBox24.Text.Length = 10 And Form1.TextBox24.Text.Substring(8, 1) = "-" Then
                Try
                    sql = "INSERT INTO `pareja`(`rut_p`, `nombre_p`, `celular2_p`, `celular1_p`, `domicilio_p`, `ciudad_p`, `nacimiento_p`, `edad_p`, `actividad`, `civil`, `prevision_p`) VALUES ('" & Form1.TextBox24.Text & "','" & Form1.TextBox27.Text & "','" & Form1.MaskedTextBox3.Text & "','" & Form1.MaskedTextBox2.Text & "','" & Form1.TextBox25.Text & "','" & cargasCombobox.Mcomunas2(0, Form1.ComboBox6.SelectedIndex) & "','" & general.fechasVoltear(Form1.DateTimePicker3.Text) & "','" & Form1.MaskedTextBox1.Text & "','" & Form1.TextBox32.Text & "','" & Form1.ComboBox2.SelectedIndex & "','" & cargasCombobox.Mprevision(0, Form1.ComboBox5.SelectedIndex) & "');"
                    general.IngresarDatos(sql)
                Catch ex As Exception
                    sql = "UPDATE `pareja` SET `nombre_p`='" & Form1.TextBox27.Text & "',`celular2_p`='" & Form1.MaskedTextBox3.Text & "',`celular1_p`='" & Form1.MaskedTextBox2.Text & "',`domicilio_p`='" & Form1.TextBox25.Text & "',`ciudad_p`='" & cargasCombobox.Mcomunas2(0, Form1.ComboBox6.SelectedIndex) & "',`nacimiento_p`='" & general.fechasVoltear(Form1.DateTimePicker3.Text) & "',`edad_p`='" & Form1.MaskedTextBox1.Text & "',`actividad`='" & Form1.TextBox32.Text & "',`civil`='" & Form1.ComboBox2.SelectedIndex & "',`prevision_p`='" & cargasCombobox.Mprevision(0, Form1.ComboBox5.SelectedIndex) & "' WHERE `rut_p`='" & Form1.TextBox24.Text & "';"
                    general.IngresarDatos(sql)
                End Try
            Else
                MessageBox.Show("Rut de pareja no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Rut de pareja no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ficha()
        Try
            If Form1.TextBox4.Text.Length = 9 And Form1.TextBox4.Text.Substring(7, 1) = "-" Then
                Try
                    sql = "INSERT INTO `paciente`(`rut`, `pareja`, `nombre`, `celular2`, `celular1`, `domicilio`, `ciudad`, `fecha_n`, `edad`, `prevision`, `motivo_c`, `epi`, `medicamento`, `riesgo`, `alergia`, `o_gine`, `o_no_gine`, `embarazo`, `partos`, `perdidas`, `PAP`, `FUR`, `regular`, `duracion`, `fecha_consulta`, `actividad`, `foto`) VALUES ('" & Form1.TextBox4.Text & "','" & rutPareja & "','" & Form1.TextBox1.Text & "','" & Form1.MaskedTextBox5.Text & "','" & Form1.MaskedTextBox4.Text & "','" & Form1.TextBox3.Text & "','" & cargasCombobox.Mcomunas(0, Form1.ComboBox3.SelectedIndex) & "','" & general.fechasVoltear(Form1.DateTimePicker2.Text) & "','" & Form1.MaskedTextBox6.Text & "','" & cargasCombobox.Mprevision(0, Form1.ComboBox4.SelectedIndex) & "','" & Form1.TextBox9.Text & "','" & Form1.TextBox10.Text & "','" & Form1.TextBox11.Text & "','" & Form1.TextBox12.Text & "','" & Form1.TextBox13.Text & "','" & Form1.TextBox14.Text & "','" & Form1.TextBox15.Text & "','" & Form1.MaskedTextBox8.Text & "','" & Form1.MaskedTextBox9.Text & "','" & Form1.MaskedTextBox10.Text & "','" & general.fechasVoltear(Form1.DateTimePicker4.Text) & "','" & general.fechasVoltear(Form1.DateTimePicker6.Text) & "','" & Form1.regla & "','" & Form1.MaskedTextBox7.Text & "','" & general.fechasVoltear(Form1.DateTimePicker1.Text) & "' , '" & Form1.TextBox2.Text & "', '" & foto & "');"
                    general.IngresarDatos(sql)
                Catch ex As Exception
                    sql = "UPDATE `paciente` SET `pareja`='" & rutPareja & "',`nombre`='" & Form1.TextBox1.Text & "',`celular2`='" & Form1.MaskedTextBox5.Text & "',`celular1`='" & Form1.MaskedTextBox4.Text & "',`domicilio`='" & Form1.TextBox3.Text & "',`ciudad`='" & cargasCombobox.Mcomunas(0, Form1.ComboBox3.SelectedIndex) & "',`fecha_n`='" & general.fechasVoltear(Form1.DateTimePicker2.Text) & "',`edad`='" & Form1.MaskedTextBox6.Text & "',`prevision`='" & cargasCombobox.Mprevision(0, Form1.ComboBox4.SelectedIndex) & "',`motivo_c`='" & Form1.TextBox9.Text & "',`epi`='" & Form1.TextBox10.Text & "',`medicamento`='" & Form1.TextBox11.Text & "',`riesgo`='" & Form1.TextBox12.Text & "',`alergia`='" & Form1.TextBox13.Text & "',`o_gine`='" & Form1.TextBox14.Text & "',`o_no_gine`='" & Form1.TextBox15.Text & "',`embarazo`='" & Form1.MaskedTextBox8.Text & "',`partos`='" & Form1.MaskedTextBox9.Text & "',`perdidas`='" & Form1.MaskedTextBox10.Text & "',`PAP`='" & general.fechasVoltear(Form1.DateTimePicker4.Text) & "',`FUR`='" & general.fechasVoltear(Form1.DateTimePicker6.Text) & "',`regular`='" & Form1.regla & "',`duracion`='" & Form1.MaskedTextBox7.Text & "',`fecha_consulta`='" & general.fechasVoltear(Form1.DateTimePicker1.Text) & "' ,`actividad`='" & Form1.TextBox2.Text & "' ,`foto`='" & foto & "' WHERE `rut`='" & Form1.TextBox4.Text & "';"
                    general.IngresarDatos(sql)
                End Try
                Guardados.guardarPartos()
            ElseIf Form1.TextBox4.Text.Length = 10 And Form1.TextBox4.Text.Substring(8, 1) = "-" Then
                Try
                    sql = "INSERT INTO `paciente`(`rut`, `pareja`, `nombre`, `celular2`, `celular1`, `domicilio`, `ciudad`, `fecha_n`, `edad`, `prevision`, `motivo_c`, `epi`, `medicamento`, `riesgo`, `alergia`, `o_gine`, `o_no_gine`, `embarazo`, `partos`, `perdidas`, `PAP`, `FUR`, `regular`, `duracion`, `fecha_consulta`, `actividad`, `foto`) VALUES ('" & Form1.TextBox4.Text & "','" & rutPareja & "','" & Form1.TextBox1.Text & "','" & Form1.MaskedTextBox5.Text & "','" & Form1.MaskedTextBox4.Text & "','" & Form1.TextBox3.Text & "','" & cargasCombobox.Mcomunas(0, Form1.ComboBox3.SelectedIndex) & "','" & general.fechasVoltear(Form1.DateTimePicker2.Text) & "','" & Form1.MaskedTextBox6.Text & "','" & cargasCombobox.Mprevision(0, Form1.ComboBox4.SelectedIndex) & "','" & Form1.TextBox9.Text & "','" & Form1.TextBox10.Text & "','" & Form1.TextBox11.Text & "','" & Form1.TextBox12.Text & "','" & Form1.TextBox13.Text & "','" & Form1.TextBox14.Text & "','" & Form1.TextBox15.Text & "','" & Form1.MaskedTextBox8.Text & "','" & Form1.MaskedTextBox9.Text & "','" & Form1.MaskedTextBox10.Text & "','" & general.fechasVoltear(Form1.DateTimePicker4.Text) & "','" & general.fechasVoltear(Form1.DateTimePicker6.Text) & "','" & Form1.regla & "','" & Form1.MaskedTextBox7.Text & "','" & general.fechasVoltear(Form1.DateTimePicker1.Text) & "' , '" & Form1.TextBox2.Text & "', '" & foto & "');"
                    general.IngresarDatos(sql)
                Catch ex As Exception
                    sql = "UPDATE `paciente` Set `pareja`='" & rutPareja & "',`nombre`='" & Form1.TextBox1.Text & "',`celular2`='" & Form1.MaskedTextBox5.Text & "',`celular1`='" & Form1.MaskedTextBox4.Text & "',`domicilio`='" & Form1.TextBox3.Text & "',`ciudad`='" & cargasCombobox.Mcomunas(0, Form1.ComboBox3.SelectedIndex) & "',`fecha_n`='" & general.fechasVoltear(Form1.DateTimePicker2.Text) & "',`edad`='" & Form1.MaskedTextBox6.Text & "',`prevision`='" & cargasCombobox.Mprevision(0, Form1.ComboBox4.SelectedIndex) & "',`motivo_c`='" & Form1.TextBox9.Text & "',`epi`='" & Form1.TextBox10.Text & "',`medicamento`='" & Form1.TextBox11.Text & "',`riesgo`='" & Form1.TextBox12.Text & "',`alergia`='" & Form1.TextBox13.Text & "',`o_gine`='" & Form1.TextBox14.Text & "',`o_no_gine`='" & Form1.TextBox15.Text & "',`embarazo`='" & Form1.MaskedTextBox8.Text & "',`partos`='" & Form1.MaskedTextBox9.Text & "',`perdidas`='" & Form1.MaskedTextBox10.Text & "',`PAP`='" & general.fechasVoltear(Form1.DateTimePicker4.Text) & "',`FUR`='" & general.fechasVoltear(Form1.DateTimePicker6.Text) & "',`regular`='" & Form1.regla & "',`duracion`='" & Form1.MaskedTextBox7.Text & "',`fecha_consulta`='" & general.fechasVoltear(Form1.DateTimePicker1.Text) & "',`actividad`='" & Form1.TextBox2.Text & "' ,`foto`='" & foto & "' WHERE `rut`='" & Form1.TextBox4.Text & "';"
                    general.IngresarDatos(sql)
                End Try
                Guardados.guardarPartos()
            Else
                MessageBox.Show("Rut de paciente no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Rut de paciente no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GuardarFichaTecnica()


        If Form1.TextBox24.Text <> "" Then 'comprobación rut pareja

            Try
                If CInt(Form1.TextBox24.Text.Substring(0, 8)) >= 0 Then
                    pareja()
                    rutPareja = Form1.TextBox24.Text
                End If
            Catch ex As Exception
                Try
                    If CInt(Form1.TextBox24.Text.Substring(0, 7)) >= 0 Then
                        pareja()
                        rutPareja = Form1.TextBox24.Text
                    End If
                Catch ex2 As Exception

                    MessageBox.Show("Rut de pareja no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End Try
        Else
            rutPareja = "00000000-0"
        End If

        If rutPareja <> "" And Form1.TextBox4.Text <> "" And Form1.TextBox1.Text <> "" Then 'comprobación rut pareja y persona 

            Try
                If CInt(Form1.TextBox4.Text.Substring(0, 8)) >= 0 Then
                    ficha()
                    MessageBox.Show("Guardado de Ficha exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.None)
                    Form1.Text.Text = ""
                    Form1.TextBox1.Text = ""
                    Form1.TextBox4.Text = ""
                    Form1.MaskedTextBox6.Text = ""
                    Form1.TextBox3.Text = ""
                    Form1.TextBox2.Text = ""
                    Form1.MaskedTextBox4.Text = ""
                    Form1.MaskedTextBox5.Text = ""
                    Form1.MaskedTextBox1.Text = ""
                    Form1.MaskedTextBox2.Text = ""
                    Form1.MaskedTextBox3.Text = ""
                    Form1.TextBox9.Text = ""
                    Form1.TextBox10.Text = ""
                    Form1.TextBox11.Text = ""
                    Form1.TextBox12.Text = ""
                    Form1.TextBox13.Text = ""
                    Form1.TextBox14.Text = ""
                    Form1.TextBox15.Text = ""
                    Form1.MaskedTextBox8.Text = ""
                    Form1.MaskedTextBox9.Text = ""
                    Form1.MaskedTextBox10.Text = ""
                    Form1.MaskedTextBox7.Text = ""
                    Form1.TextBox27.Text = ""
                    Form1.TextBox24.Text = ""
                    Form1.TextBox25.Text = ""
                    Form1.TextBox32.Text = ""
                    Form1.Label13.Text = ""
                    recuperar.referenciasNombres()


                End If
            Catch ex As Exception
                Try
                    If CInt(Form1.TextBox4.Text.Substring(0, 7)) >= 0 Then
                        ficha()
                        MessageBox.Show("Guardado de Ficha exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.None)
                        Form1.Text.Text = ""
                        Form1.TextBox1.Text = ""
                        Form1.TextBox4.Text = ""
                        Form1.MaskedTextBox6.Text = ""
                        Form1.TextBox3.Text = ""
                        Form1.TextBox2.Text = ""
                        Form1.MaskedTextBox4.Text = ""
                        Form1.MaskedTextBox5.Text = ""
                        Form1.MaskedTextBox1.Text = ""
                        Form1.MaskedTextBox2.Text = ""
                        Form1.MaskedTextBox3.Text = ""
                        Form1.TextBox9.Text = ""
                        Form1.TextBox10.Text = ""
                        Form1.TextBox11.Text = ""
                        Form1.TextBox12.Text = ""
                        Form1.TextBox13.Text = ""
                        Form1.TextBox14.Text = ""
                        Form1.TextBox15.Text = ""
                        Form1.MaskedTextBox8.Text = ""
                        Form1.MaskedTextBox9.Text = ""
                        Form1.MaskedTextBox10.Text = ""
                        Form1.MaskedTextBox7.Text = ""
                        Form1.TextBox27.Text = ""
                        Form1.TextBox24.Text = ""
                        Form1.TextBox25.Text = ""
                        Form1.TextBox32.Text = ""
                        Form1.Label13.Text = ""
                        recuperar.referenciasNombres()
                    End If
                Catch ex2 As Exception

                    MessageBox.Show("Rut de paciente no válido, mantenga el formato 00000000-0", "Error de Rut", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End Try

        Else
            MessageBox.Show("Error de datos por favor revice los campos", "ERROR DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.None)
        End If

    End Sub
    Public Sub GuardarecoDopler22_24()

        sql = "INSERT INTO `eco_doopler22_24` (`rut_paciente`, `sra_nombre`, `presentacion`, `descripcion`, `diametro_biparental`, `perimetro_cefalico`, `perimetro_abdominal`, `femur`, `cerebelo`, `cisterna_magna`, `ventriculo_lateral`, `epf`, `columna`, `craneo`, `cara`, `torax`, `abdomen`, `extremidades`, `fetalductus_venoso`, `maternoart_uderecha`, `maternoart_uizquierda`, `promedio`, `arteria_cerebral_media`, `arteria_umbilical`, `indicecerebro_placentario`) VALUES ('" & Form1.TextBox4.Text & "','" & ecoDoppler24.Label16.Text & "', '" & ecoDoppler24.ComboBox11.Text & "', '" & ecoDoppler24.TextBox1.Text & "', '" & ecoDoppler24.TextBox22.Text & "',  '" & ecoDoppler24.TextBox28.Text & "', '" & ecoDoppler24.TextBox29.Text & "', '" & ecoDoppler24.TextBox30.Text & "', '" & ecoDoppler24.TextBox34.Text & "', '" & ecoDoppler24.TextBox35.Text & "', '" & ecoDoppler24.TextBox23.Text & "', '" & ecoDoppler24.TextBox36.Text & "', '" & ecoDoppler24.TextBox5.Text & "', '" & ecoDoppler24.TextBox4.Text & "', '" & ecoDoppler24.TextBox3.Text & "', '" & ecoDoppler24.TextBox2.Text & "', '" & ecoDoppler24.TextBox18.Text & "', '" & ecoDoppler24.TextBox17.Text & "', '" & ecoDoppler24.TextBox7.Text & "', '" & ecoDoppler24.TextBox8.Text & "','" & ecoDoppler24.TextBox9.Text & "', '" & ecoDoppler24.Label32.Text & "', '" & ecoDoppler24.TextBox11.Text & "', '" & ecoDoppler24.TextBox12.Text & "', '" & ecoDoppler24.Label35.Text & "');"
        general.IngresarDatos(sql)


    End Sub
    Public Sub GuardarecoDopler11_14()


        sql = "INSERT INTO `eco_doopler11_14` (`rut_paciente`, `sra_nombre`, `presentacion`, `descripcion`, `diametro_biparental`, `perimetro_cefalico`, `perimetro_abdominal`, `femur`, `epf`, `tn`, `huesonasal`, `columna`, `craneo`, `cara`, `torax`, `abdomen`, `extremidades`, `fetalductus_venoso`, `maternoart_uderecha`, `maternoart_uizquierda`, `promedio`) VALUES ('" & Form1.TextBox4.Text & "','" & ecoDoppler11y14.Label16.Text & "', '" & ecoDoppler11y14.presentacion.Text & "', '" & ecoDoppler11y14.TextBox1.Text & "', '" & ecoDoppler11y14.TextBox22.Text & "',  '" & ecoDoppler11y14.TextBox28.Text & "', '" & ecoDoppler11y14.TextBox29.Text & "', '" & ecoDoppler11y14.TextBox30.Text & "', '" & ecoDoppler11y14.TextBox34.Text & "', '" & ecoDoppler11y14.TextBox35.Text & "', '" & ecoDoppler11y14.TextBox23.Text & "', '" & ecoDoppler11y14.TextBox5.Text & "', '" & ecoDoppler11y14.TextBox4.Text & "', '" & ecoDoppler11y14.TextBox3.Text & "', '" & ecoDoppler11y14.TextBox2.Text & "', '" & ecoDoppler11y14.TextBox18.Text & "', '" & ecoDoppler11y14.TextBox17.Text & "',  '" & ecoDoppler11y14.TextBox7.Text & "', '" & ecoDoppler11y14.TextBox8.Text & "', '" & ecoDoppler11y14.TextBox9.Text & "','" & ecoDoppler11y14.Label32.Text & "';"
        general.IngresarDatos(sql)


    End Sub
    Public Sub guradarControl()
        Dim controlesrecuperados(0, 0) As String
        sql = "INSERT INTO controles (rut_paciente, fecha_control, nombre_motivo, peso, presion_arterial, observaciones, solicitud_examenes) VALUES ('" & Form1.TextBox4.Text & "','" & general.fechasVoltear(Form1.DateTimePicker5.Text) & "','" & cargasCombobox.motivo(0, Form1.ComboBox8.SelectedIndex) & "','" & Form1.TextBox31.Text & "','" & Form1.TextBox26.Text & "','" & Form1.TextBox5.Text & "','" & Form1.examenes & "');"
        general.IngresarDatos(sql)

        sql = "SELECT * FROM controles WHERE rut_paciente='" & Form1.TextBox4.Text & "'"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "id_control"
        controlesrecuperados = general.recuperar(sql)

        ultimoControl = controlesrecuperados(0, controlesrecuperados.GetUpperBound(1))

        GuardarExamenesSollicitados(Form1.TextBox4.Text, ultimoControl)

    End Sub
    Public Sub guradarModControl()
        sql = "UPDATE `controles` SET fecha_modificacion = '" & general.fechasVoltear(Form1.DateTimePicker11.Text) & "', descripcion_mod = '" & Form1.TextBox22.Text & "' WHERE id_control  = '" & recuperar.controlesFechas(0, Form1.DataGridView1.CurrentRow.Index) & "';"
        general.IngresarDatos(sql)


    End Sub
    Public Sub guardarPartos()
        Try
            sql = "DELETE FROM `embarazos` WHERE rut_paciente='" & Form1.TextBox4.Text & "';"
            general.IngresarDatos(sql)
            If Form1.filasPartos > 0 Then

                For i = 0 To Form1.filasPartos - 1
                    sql = "INSERT INTO `embarazos`(`rut_paciente`, `n_parto`, `estado_p`) VALUES ('" & Form1.TextBox4.Text & "','" & partos(0, i) & "','" & partos(1, i) & "'); "
                    general.IngresarDatos(sql)
                Next

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub GuardarCarnetEmbarazo()
        Try
            sql = "INSERT INTO `control_prenatal`(`fecha`, `peso`, `pa`, `lcf`, `altut`, `present`, `patologias`, `indicaciones`, `ed_gestacional`, `control`, `fur`, `fur_operacional`, `fpp`, `rut_paciente`) VALUES ('" & general.fechasVoltear(Form1.DateTimePicker7.Text) & "','" & Form1.TextBox6.Text & "','" & Form1.TextBox7.Text & "','" & Form1.TextBox8.Text & "','" & Form1.TextBox16.Text & "','" & Form1.ComboBox11.Text & "','" & Form1.TextBox17.Text & "','" & Form1.TextBox18.Text & "','" & Form1.TextBox19.Text & "','" & Form1.TextBox21.Text & "','" & general.fechasVoltear(Form1.DateTimePicker8.Text) & "','" & general.fechasVoltear(Form1.DateTimePicker9.Text) & "','" & general.fechasVoltear(Form1.DateTimePicker10.Text) & "','" & Form1.TextBox4.Text & "');"
            general.IngresarDatos(sql)
        Catch ex As Exception
            MsgBox("La ficha del paciente aun no a sido guardada. Guarde la ficha principal antes de guardar el registro")
        End Try

    End Sub

    Public Sub GuardarExamenesSollicitados(ByVal rut, ByVal id_control)
        sql = "DELETE FROM `examensol` WHERE rut='" & rut & "';"
        general.IngresarDatos(sql)

        If Form1.DataGridView3.RowCount > 0 Then


            For i = 0 To Form1.DataGridView3.RowCount - 1
                Dim control As String = ""
                If Form1.DataGridView3(3, i).Value <> "Actual" Then
                    control = Form1.DataGridView3(3, i).Value
                Else
                    control = id_control
                End If

                sql = "INSERT INTO `examensol`(`nombre`, `detalles`, `id_control`, `fecha_sol`, `rut`) VALUES ('" & Form1.DataGridView3(1, i).Value & "','','" & control & "','" & general.fechasVoltear(Form1.DataGridView3(2, i).Value) & "','" & rut & "');"

                general.IngresarDatos(sql)

            Next
        End If

        If Form1.DataGridView4.RowCount > 0 Then


            For i = 0 To Form1.DataGridView3.RowCount - 1
                Dim control As String = ""
                If Form1.DataGridView4(4, i).Value <> "Actual" Then
                    control = Form1.DataGridView4(4, i).Value
                Else
                    control = id_control
                End If

                sql = "INSERT INTO `examensol`(`nombre`, `detalles`, `id_control`, `fecha_sol`, `fecha_entre`, `rut`) VALUES ('" & Form1.DataGridView4(0, i).Value & "','" & Form1.DataGridView4(1, i).Value & "','" & control & "','" & general.fechasVoltear(Form1.DataGridView4(3, i).Value) & "','" & general.fechasVoltear(Form1.DataGridView4(2, i).Value) & "','" & rut & "');"
                general.IngresarDatos(sql)

            Next
        End If
    End Sub

End Module
