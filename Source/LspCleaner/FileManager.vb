Imports System.Xml
Imports System.IO
Namespace FileIO
    Public Class FileManager

        Public Shared Function FileToString(ByVal filename As String) As String
            Dim _content As String

            Try
                Dim oFile As FileStream = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim oReader As StreamReader = New StreamReader(oFile)
                _content = oReader.ReadToEnd

                oReader.Close()
                oFile.Close()

                Return _content
            Catch
                Return "Unable to open file."
            End Try

        End Function

        Public Shared Function FileToList(ByVal filename As String) As List(Of String)
            Dim _content As New List(Of String)

            Dim tmp As String
            Using reader As StreamReader = New StreamReader(filename)
                tmp = reader.ReadLine
                Do While (Not tmp Is Nothing)
                    _content.Add(tmp)
                    tmp = reader.ReadLine
                Loop
            End Using

            Return _content
        End Function

        Public Shared Function StringToFile(ByVal value As String, ByVal filepath As String) As Boolean

            Try
                Using outfile As New StreamWriter(filepath)
                    outfile.Write(value)
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Warning")
            End Try

            Return True
        End Function

    End Class
End Namespace