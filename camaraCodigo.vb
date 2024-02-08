Imports System.Runtime.InteropServices
Module camaraCodigo


    ' Lo unico que hay que cambiar son los codigos del cuadro de imagen

    Dim DATOS As IDataObject
        Dim IMAGEN As Image
        Public Const WM_CAP As Short = &H400S
        Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
        Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
        Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
        Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
        Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
        Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
        Public Const WS_CHILD As Integer = &H40000000
        Public Const WS_VISIBLE As Integer = &H10000000
        Public Const SWP_NOMOVE As Short = &H2S
        Public Const SWP_NOZORDER As Short = &H4S
        Public Const HWND_BOTTOM As Short = 1


        Public iDevice As Integer = 0 ' Current device ID
        Public hHwnd As Integer ' Handle to preview window

        Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

        Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer,
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

        Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

        Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
        ByVal nHeight As Short, ByVal hWndParent As Integer,
        ByVal nID As Integer) As Integer


        'Open View

        Public Sub OpenPreviewWindowCliente()

            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 600,
           480, MainForm.PicFoto.Handle.ToInt32, 0)

            ' Connect to device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
            If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
                '
                'Set the preview scale

                SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

                'Set the preview rate in milliseconds
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

                'Start previewing the image from the camera
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

                ' Resize window to fit in picturebox
                '
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, MainForm.PicFoto.Width, MainForm.PicFoto.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)

            Else
                ' Error connecting to device close window
                ' 
                DestroyWindow(hHwnd)

            End If
        End Sub

        Public Sub CapturarCliente()
            ' Copy image to clipboard
            '
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

            ' Get image from clipboard and convert it to a bitmap
            '
            DATOS = Clipboard.GetDataObject()

            IMAGEN = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
            MainForm.PicFoto.Image = IMAGEN

        End Sub

    Public Sub ClosePreviewWindow()
        '
        ' Disconnect from device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)
        '
        ' close window
        '
        DestroyWindow(hHwnd)
    End Sub

End Module
