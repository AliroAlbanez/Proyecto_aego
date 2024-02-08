Imports System.IO
Imports AForge.Video.DirectShow
Imports AForge.Video
Public Class MainForm
    Dim FUENTES As FilterInfoCollection 'CAMARAS DISPONIBLES
    Dim WithEvents FUENTE1 As VideoCaptureDevice 'CAMARA 1 
    Dim foto2 As String
    'boton encender camara

    'boton capturar
    Private Sub cmdCapturar_Click(sender As Object, e As EventArgs) Handles cmdCapturar.Click
        camaraCodigo.CapturarCliente()
        System.Threading.Thread.Sleep(2000)
        FUENTE1.Stop()
    End Sub


    'boton borrar foto tomada
    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click

        cargarCamara()

    End Sub


    'boton guardar foto
    Private Sub btnGuardarFotoArchivo_Click(sender As Object, e As EventArgs) Handles btnGuardarFotoArchivo.Click


        Try
            'Crea carpeta en este caso le puse en usuarios publicos para evitar problemas al cambiar de pc y se crea la carpeta con el nombre del paciente
            Try
                My.Computer.FileSystem.CreateDirectory("\\DESKTOP-RIHORNI\Users\Public\aego\pacientes\" & Form1.TextBox1.Text)
            Catch ex As Exception

            End Try

            Dim sFD As New SaveFileDialog
            'Parameros del cuadro de guardar, la primera linea indica que se abra en la carpeta del paciente
            sFD.InitialDirectory = "\\DESKTOP-RIHORNI\Users\Public\aego\pacientes\" & Form1.TextBox1.Text
            sFD.Title = "Guardar Imagen"
            sFD.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp"
            sFD.FileName = Form1.TextBox1.Text
            If sFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.PicFoto.Image.Save(System.IO.Path.GetFullPath(sFD.FileName))
                foto2 = System.IO.Path.GetFullPath(sFD.FileName) 'direccion de guardado para la DB
                Form1.PictureBox1.BackgroundImage = Image.FromFile(foto2)

                Guardados.foto = foto2.Replace("\", "|")


                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CARGA LAS CAMARAS DISPONIBLES EN LOS 2 COMBOBOX
        FUENTES = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        If FUENTES.Count > 0 Then
            For i As Integer = 0 To FUENTES.Count - 1
                ComboBox1.Items.Add(FUENTES(i).Name.ToString())
            Next
            FUENTE1 = New VideoCaptureDevice(FUENTES(0).MonikerString)
            AddHandler FUENTE1.NewFrame, New NewFrameEventHandler(AddressOf video_NuevoFrame1)
        Else
            MsgBox("NO HAY CAMARAS DISPONIBLES")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cargarCamara()

    End Sub

    Private Sub video_NuevoFrame1(sender As Object, eventArgs As NewFrameEventArgs)
        'PRESENTA LAS IMAGENES EN EL PICTUREBOX1
        Dim IMAGEN As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        PicFoto.Image = IMAGEN
    End Sub

    Private Sub cargarCamara()
        PicFoto.Image = Nothing
        FUENTE1.Stop()
        'INICIA LA CAMARA 1
        FUENTE1 = New VideoCaptureDevice(FUENTES(ComboBox1.SelectedIndex).MonikerString)
        AddHandler FUENTE1.NewFrame, New NewFrameEventHandler(AddressOf video_NuevoFrame1)
        FUENTE1.Start()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FUENTE1.Stop()
    End Sub
End Class
