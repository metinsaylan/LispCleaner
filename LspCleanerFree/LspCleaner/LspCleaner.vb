Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class LspCleaner

    Public _log As New List(Of String)
    Public Shared _cancel As Boolean
    Private autoScanComplete As Boolean
    Public backupFiles As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        autoScanComplete = False
        Me.backupFiles = True
    End Sub

    Public Sub Log(ByVal msg As String)
        _log.Add(msg)
        If Me.Visible Then
            txtLog.Text = String.Join(vbCrLf, _log.ToArray)

            txtLog.SelectionStart = txtLog.Text.Length
            txtLog.ScrollToCaret()
            Application.DoEvents()

        End If
    End Sub

    Public Sub Status(ByVal msg As String)
        lblStatus.Text = msg
        Me.Refresh()
    End Sub

    Public Sub Action(ByVal msg As String)
        lblAction.Text = msg
        Me.Refresh()
    End Sub

    Private Sub resetCancel()
        lblCancel.Visible = False
        _cancel = False
        Me.Refresh()
    End Sub

    Private Sub hideCancel()
        lblCancel.Visible = False
    End Sub

    Public Sub AutoClear(verboseFlag As Boolean)

        Dim folders As New List(Of String)
        Dim found As Boolean = False

        Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Status("Generating folder list")
        Action("Scanning Progam Files folders..")

        progress.Style = Windows.Forms.ProgressBarStyle.Marquee

        ' Programlar
        'Dim programsFolder As String
        'Dim progDir As DirectoryInfo
        'Dim autocadDirs As DirectoryInfo()
        'programsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        'progDir = New DirectoryInfo(programsFolder)
        'autocadDirs = progDir.GetDirectories("Auto*")
        'For Each autocadFolder In autocadDirs
        '    folders.Add(autocadFolder.FullName)
        'Next

        'Action("Adding special folders..")
        '' App data
        'folders.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
        '' Local App data 
        'folders.Add(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))

        ' Belgelerim
        'folders.Add(Environment.GetFolderPath(Environment.SpecialFolder.userprofile))
        folders.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))

        'Desktop
        folders.Add(desktop)

        Status("Generating lisp file list")

        Log("> Scanning lisp files..")
        Log("")

        resetCancel()
        ' Scan files
        Dim lspfiles As New List(Of String)
        For Each folder As String In folders

            If Not _cancel Then
                Dim folderInfo As New DirectoryInfo(folder)

                Log("> Scanning Folder : " & folder)
                Action("Scanning : " & folderInfo.Name)

                Dim fileList As New List(Of String)
                Dim mnlList As New List(Of String)
                Dim fasList As New List(Of String)
                fileList = FileHelper.GetFilesRecursive(folder, "*.lsp")
                mnlList = FileHelper.GetFilesRecursive(folder, "*.mnl")
                fasList = FileHelper.GetFilesRecursive(folder, "*.fas")

                For Each fileName As String In fileList
                    lspfiles.Add(fileName)
                    Log(fileName)
                Next

                For Each fileName As String In mnlList
                    lspfiles.Add(fileName)
                    Log(fileName)
                Next

                For Each fileName As String In fasList
                    lspfiles.Add(fileName)
                    Log(fileName)
                Next
            Else
                Exit Sub
            End If

        Next

        Status("Checking lisp file data")

        Log("")
        Log("> Clearing lisp files..")
        Log("")

        Dim cntr As Integer = 0
        found = ClearLispFiles(lspfiles, cntr, Me.backupFiles)

        hideCancel()

        If found Then
            Log(cntr & " virus cleared.")
        Else
            Log("No virus found.")
        End If

        Log("")
        Log("> LispCleaner Finished.")
        Log("")

        Action("")
        Status("Cleaner finished.")

        btnScan.Text = "ReScan"

        If Not Me.Visible And verboseFlag = True Then

            ' Save log on desktop
            Dim logData As String = String.Join(vbCrLf, _log.ToArray)
            FileIO.FileManager.StringToFile(logData, desktop & "\lspcleaner.txt")

            ' Action("Log saved to ""lspcleaner"" on your desktop.")
            ' btnScan.Text = "View Log.."

        End If

        autoScanComplete = True
    End Sub

    Public Function ClearLispFiles(ByVal filelist As List(Of String), ByRef virusCount As Integer, Optional ByVal backupFiles As Boolean = True)
        Dim found As Boolean = False

        If filelist.Count > 0 Then

            progress.Style = Windows.Forms.ProgressBarStyle.Blocks
            progress.Maximum = filelist.Count - 1

            Dim cntr As Integer = 0

            ' Clean files
            For Each filepath In filelist
                If Not _cancel Then
                    progress.Value = cntr
                    cntr = cntr + 1
                    If ClearFile(filepath, Me.backupFiles) = True Then
                        found = True
                        virusCount = virusCount + 1
                    End If
                Else
                    Return False
                    Exit Function
                End If
            Next

        End If

        Return found
    End Function

    ' Returns true if 
    Private Function ClearFile(filepath As String, backup As Boolean) As Boolean
        Dim found As Boolean
        Dim filename As String = Path.GetFileName(filepath)

        If filename = "acaddoc.lsp" Then

            found = True
            File.Delete(filepath)
            Log("  Deleting : " & filepath)

        ElseIf filename = "acad.fas" Then

            found = True
            File.Delete(filepath)
            Log("  Deleting : " & filepath)

        ElseIf filename = "acadapq.lsp" Then

            found = True
            File.Delete(filepath)
            Log("  Deleting : " & filepath)

        ElseIf filename = "textdit.lsp" Then

            found = True
            File.Delete(filepath)
            Log("  Deleting : " & filepath)

        Else

            Dim fi As New FileInfo(filepath)
            Dim filedata As String = FileIO.FileManager.FileToString(filepath)

            Action("Checking : " & fi.Name)

            Dim flagx As Boolean = CheckFlagX(filedata)
            Dim sstartup As Boolean = CheckSStartup(filedata)

            If flagx Or sstartup Then
                found = True
            End If

            If found Then

                Log("  Found virus -> " & filepath)

                If backupFiles Then
                    ' Backup file
                    Try
                        IO.File.Copy(filepath, filepath.Replace(".lsp", ".lsp.bak"))
                    Catch ex As IO.IOException
                        ' File backup already exists?
                        ' Keep silent.
                    End Try

                    Log("   Backup file : " & filepath & ".bak")
                End If

                FileIO.FileManager.StringToFile(filedata, filepath)
                Log("   Cleared file.")
            End If

        End If

        Return found
    End Function

    Function CheckFlagX(ByRef filedata As String) As Boolean
        Dim found As Boolean
        Dim fileparts As String()
        Dim pattern As String = "\(setq flagx t\)"

        fileparts = Regex.Split(filedata, pattern)

        If fileparts.Length > 1 Then
            found = True
            filedata = fileparts(0)
        End If

        Return found
    End Function

    Function CheckSStartup(ByRef filedata As String) As Boolean
        Dim found As Boolean
        Dim fileparts As String()
        Dim pattern As String = "(q\(defun-q s::startup)"

        fileparts = Regex.Split(filedata, pattern)

        If fileparts.Length > 1 Then
            found = True
            filedata = fileparts(0)
        End If

        Return found
    End Function




    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://metinsaylan.com/projects/lspcleaner/")
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click

        _log.Clear()
        txtLog.Text = ""

        AutoClear(True)

    End Sub

    Private Sub btnScanFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanFolder.Click

        MsgBox("ScanFolder feature is only available on paid version." & vbCrLf & "If you like this cleaner, please purchase full version", vbOKOnly + vbInformation)

    End Sub

    Private Sub lblCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCancel.Click
        _cancel = True
        lblCancel.Text = "Canceled"
    End Sub

    Private Sub chkBackup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackup.CheckedChanged
        Me.backupFiles = chkBackup.Checked
    End Sub

    Private Sub LspCleaner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "LispCleaner " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & " by MS (Free Version)"

        txtLog.Text = "" & _
        vbCrLf & "PLEASE NOTE : " & _
            "" & vbCrLf & _
            "This free version of the LispCleaner cleans Documents and Desktop folders only. Your Program files and Application Data folders won't be cleaned." & vbCrLf & _
            "If you like this software, please purchase full version. Thanks." & vbCrLf & _
             "" & vbCrLf & _
        vbCrLf & "WARNING :" & vbCrLf & _
            "LispCleaner (Free Version) v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & " is designed to clean all acaddoc.lsp, acad.fas, acadapq.lsp and textdit.lsp files from selected folders in order to get rid of ALS/Bursted.xx worm. Please be informed that your regular lisp files will also be cleaned by removing infected parts. Before running the cleaner, I recommend backing up your important lisp files. " ' & vbCrLf & vbCrLf & _
        ' vbCrLf & "DISCLAIMER :" & vbCrLf & _
        ' "" & vbCrLf & _
        ' "This SOFTWARE PRODUCT is provided by THE PROVIDER ""as is"" and ""with all faults."" THE PROVIDER makes no representations or warranties of any kind concerning the safety, suitability, lack of viruses, inaccuracies, typographical errors, or other harmful components of this SOFTWARE PRODUCT. There are inherent dangers in the use of any software, and you are solely responsible for determining whether this SOFTWARE PRODUCT is compatible with your equipment and other software installed on your equipment. You are also solely responsible for the protection of your equipment and backup of your data, and THE PROVIDER will not be liable for any damages you may suffer in connection with using, modifying, or distributing this SOFTWARE PRODUCT."





    End Sub
End Class