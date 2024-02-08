
Public Class login
        Dim sql As String 'variable para el sql 

        Private Sub BotonIniciar_Click(sender As Object, e As EventArgs) Handles BotonIniciar.Click
        'preparar el sql que utilizaremos para consultar y hacer la verificacion del usuario
        sql = "SELECT * from usuario WHERE usuario.user='" & textusuario.Text & "' AND usuario.clave='" & Textclave.Text & "';"
        'redimension consultaVector a la cantidad de datos que se necesita
        ReDim general.consultaVector(1)
        general.consultaVector(0) = "user"
        general.consultaVector(1) = "clave"
            'Igualamos la matriz donde se quieren guardar los datos  con la funcion General.recuperar(sql)
            general.usuario = general.recuperar(sql)

            'si el usuario y contraseña coinciden ingresa al sistema y muestra la ventana del menu
            If general.usuario(0, 0) <> "" Then
            sql = "UPDATE usuario SET intentos = 0 WHERE usuario.user= '" & textusuario.Text & "';"
            Me.Visible = False
            Form1.Show()

            'si no se logra ingresar al sistema alteramos la tabla usuarios el campo de intentos +1
            'esto para controlar que solo puedan equivocarce 5 veces
        Else

                MessageBox.Show("Usuario o Contraseña incorrectos.", " Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Textclave.Text = ""
        End If
        End Sub


End Class

