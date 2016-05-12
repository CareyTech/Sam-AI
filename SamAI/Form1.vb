Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Dim privid As String = ""
    Dim sentence As String
    Dim needs As Boolean = False
    Dim needsw As String = ""
    Dim renul As Boolean = False
    Public Shared ReadOnly Property MyDocuments As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        savestring(TextBox1.Text, privid)
        say("Thanks")
    End Sub
    Sub savestring(data As String, key As String)
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\AI\" + key + ".txt"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(data)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
    Sub savevocab(data As String, key As String)
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\AI\Vocabulary\" + key + ".txt"

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
            fileReader = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\AI\" + key + ".txt")
        Catch ex As Exception
            If renul = False Then
                fileReader = "I don't know what you mean. Teach me!"
            Else
                fileReader = ""
                renul = True
            End If

        End Try

        Return fileReader
    End Function
    Function readvocab(key As String)
        Dim fileReader As String
        Try
            fileReader = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\AI\Vocabulary\" + key + ".txt")
        Catch ex As Exception
            If renul = False Then
                fileReader = "I don't know what you mean. Teach me!"
            Else
                fileReader = ""
                renul = True
            End If
        End Try

        Return fileReader
    End Function
    Function checkifinvocab(key As String)
        Dim fileReader As String
        Dim checka As Boolean = True
        Try

            fileReader = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\AI\Vocabulary\" + key + ".txt")
        Catch ex As Exception
            If renul = False Then
                fileReader = "I don't know what you mean. Teach me!"
            Else
                fileReader = ""
                renul = True
            End If
            checka = False
        End Try

        Return checka
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If needs = False Then
            Dim numid As Integer = getnum()
            privid = numid
            say(readdata(numid.ToString))
        Else
            Randomize()
            ' Generate random value between 1 and 6. 
            Dim value As Integer = CInt(Int((6 * Rnd()) + 1))
            'Dim num As Integer
            needs = False
            If TextBox1.Text < 3 Then
                value = CInt(Int((14 * Rnd()) + 1))
            ElseIf TextBox1.Text < 5 Then
                value = CInt(Int((70 * Rnd()) + 14))
            ElseIf TextBox1.Text < 8 Then
                value = CInt(Int((120 * Rnd()) + 70))
            Else
                value = CInt(Int((500 * Rnd()) + 120))
            End If
            savevocab(value, needsw)
            renul = True
            say("Thanks, now I know what " + needsw + " means!")
        End If

    End Sub
    Function getnum()
        Dim hi As Integer = 0
        Dim words() As String

        Dim space() As Char = {" "c}

        words = TextBox1.Text.Split(space)

        Dim word As String

        For Each word In words
            If checkifinvocab(word) = True Then
                hi = hi + Int(readvocab(word))
            Else
                sentence = TextBox1.Text

                'savevocab(value, word)
                needs = True
                needsw = word
                say("I am not sure what the word " + word + " means. Can you please tell me it's relevence in a sentence with the numbers 1 - 10")
                Exit For
            End If


        Next



        Return hi
    End Function
    Sub Getwords()
        Dim words() As String

        Dim space() As Char = {" "c}

        words = TextBox1.Text.Split(space)

        Dim word As String

        For Each word In words

            say(word)

        Next

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub depricated()
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
        If TextBox1.Text.Contains("does") Then
            hi = hi + 37
        End If
        If TextBox1.Text.Contains("does") Then
            hi = hi + 37
        End If
    End Sub
    Sub say(imput As String)
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Speak(imput)
        ListBox1.Items.Add(imput)
    End Sub
End Class
