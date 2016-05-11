Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Dim privid As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        savestring(TextBox1.Text, privid)
        ListBox1.Items.Add("Thanks")
    End Sub
    Sub savestring(data As String, key As String)
        Dim path As String = "C:\Users\william.taylor\Documents\AI\" + key + ".txt"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(data)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
    Function readdata(key As String)
        Dim fileReader As String
        Try
            fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\william.taylor\Documents\AI\" + key + ".txt")
        Catch ex As Exception
            fileReader = "I don't know what you mean. Teach me!"
        End Try

        Return fileReader
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numid As Integer = getnum()
        privid = numid
        ListBox1.Items.Add(readdata(numid.ToString))
    End Sub
    Function getnum()
        Dim hi As Integer = 0
        If TextBox1.Text.Contains("hi") Then
            hi = hi + 42
        End If
        'hi
        If TextBox1.Text.Contains("hello") Then
            hi = hi + 42
        End If
        If TextBox1.Text.Contains("name") Then
            hi = hi + 78
        End If
        If TextBox1.Text.Contains("Will") Then
            hi = hi + 92
        End If
        If TextBox1.Text.Contains("time") Then
            hi = hi + 145
        End If
        Return hi
    End Function
End Class
