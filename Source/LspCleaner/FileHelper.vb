Imports System.IO

''' <summary>
''' This class contains directory helper method(s).
''' </summary>
Public Class FileHelper

    Public Delegate Sub UpdateStatus(msg As String)

    ''' <summary>
    ''' This method starts at the specified directory, and traverses all subdirectories.
    ''' It returns a List of those directories.
    ''' </summary>
    Public Shared Function GetFilesRecursive(ByVal initial As String, Optional ByVal pattern As String = "*.*", Optional updater As UpdateStatus = Nothing, Optional ByRef _cancel As Boolean = False) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)

            If _cancel Then
                Return New List(Of String)
            End If

            ' Get top directory string
            Dim dir As String = stack.Pop

            Try

                If result.Count > 200 Then
                    Dim rslt As Windows.Forms.DialogResult = MsgBox("Directory count exceeded 1500 directories, do you want to continue?", MsgBoxStyle.YesNo, "Do you want to continue..")
                    If rslt = Windows.Forms.DialogResult.No Then
                        Return result
                    End If
                End If


                updater.Invoke("Scanning: " & LTrim(dir))

                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, pattern))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
                ' hmm
            End Try
        Loop

        ' Return the list
        Return result
    End Function

End Class