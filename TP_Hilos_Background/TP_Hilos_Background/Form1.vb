Imports System.Threading
Imports System.IO.StreamWriter
Imports System.IO
Imports System.Text
Imports System.dll
Public Class Form1
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim i As Integer
        Dim maximo As Integer = Val(TextBox1.Text)
        For i = 1 To maximo
            'Dim info As Byte() = New UTF8Encoding(True).GetBytes("Linea " + Str(i) + vbCrLf)
            'fs.Write(info, 0, info.Length)
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\INFORME.TXT", "LINEA: " & i & vbCrLf, True)

            ' ACTUALIZA LA BARRA DE PROGRESO
            BackgroundWorker1.ReportProgress(CInt(100 * i / CInt(maximo)))
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If e.ProgressPercentage <= Val(TextBox1.Text) Then
            ProgressBar1.Value = e.ProgressPercentage
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Val(TextBox1.Text) > 0 Then
            Button2.Visible = False
            TextBox1.Enabled = False
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
End Class
