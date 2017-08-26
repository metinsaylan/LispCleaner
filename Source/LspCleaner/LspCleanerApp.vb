Public Module LspCleanerApp

    Public Sub Main()
        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        Dim auto As Boolean = False
        Dim verbose As Boolean = False
        Dim LspCleanerScreen As New LspCleaner

        For i As Integer = 0 To CommandLineArgs.Count - 1
            If CommandLineArgs(i) = "/auto" Then
                auto = True
            End If

            If CommandLineArgs(i) = "/v" Then
                verbose = True
            End If

            If CommandLineArgs(i) = "/nobackup" Then
                LspCleanerScreen.backupFiles = False
            End If
        Next

        If Not auto Then
            LspCleanerScreen.ShowDialog()
        Else
            LspCleanerScreen.AutoClear(verbose)
        End If

    End Sub
End Module
