Imports System.Threading
Imports System.IO.StreamWriter
Imports System.IO
Imports System.Text
Imports System.dll
Public Class Form1
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim i As Integer
        Dim path As String = "C:\Users\PC1\Desktop\Hilos.txt"
        Dim fs As FileStream = File.Create(path)
        For i = 1 To 2000
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.ReportProgress(i / 10)
            Dim aux As String = "Linea" + Str(i)

            Dim info As Byte() = New UTF8Encoding(True).GetBytes(aux + vbCrLf)
            fs.Write(info, 0, info.Length)
            Threading.Thread.Sleep(200)
        Next
        fs.Close()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BackgroundWorker1.RunWorkerAsync()
        Button2.Enabled = False
    End Sub
End Class
