<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LspCleaner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.progress = New System.Windows.Forms.ProgressBar()
        Me.btnScanFolder = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScan.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScan.ForeColor = System.Drawing.Color.White
        Me.btnScan.Location = New System.Drawing.Point(659, 13)
        Me.btnScan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(123, 38)
        Me.btnScan.TabIndex = 0
        Me.btnScan.Text = "Auto Scan"
        Me.btnScan.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 484)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(183, 18)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LispCleaner by MetinSaylan"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'progress
        '
        Me.progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progress.Location = New System.Drawing.Point(11, 459)
        Me.progress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(771, 20)
        Me.progress.TabIndex = 3
        '
        'btnScanFolder
        '
        Me.btnScanFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScanFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnScanFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScanFolder.Location = New System.Drawing.Point(515, 13)
        Me.btnScanFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnScanFolder.Name = "btnScanFolder"
        Me.btnScanFolder.Size = New System.Drawing.Size(138, 38)
        Me.btnScanFolder.TabIndex = 4
        Me.btnScanFolder.Text = "Scan Folder"
        Me.btnScanFolder.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.DimGray
        Me.lblStatus.Location = New System.Drawing.Point(10, 23)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(174, 18)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Please choose an action.."
        '
        'lblAction
        '
        Me.lblAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAction.AutoSize = True
        Me.lblAction.Location = New System.Drawing.Point(10, 432)
        Me.lblAction.Margin = New System.Windows.Forms.Padding(0)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(59, 18)
        Me.lblAction.TabIndex = 6
        Me.lblAction.Text = "Ready.."
        '
        'chkBackup
        '
        Me.chkBackup.AutoSize = True
        Me.chkBackup.Checked = True
        Me.chkBackup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBackup.Location = New System.Drawing.Point(11, 55)
        Me.chkBackup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkBackup.Name = "chkBackup"
        Me.chkBackup.Size = New System.Drawing.Size(345, 22)
        Me.chkBackup.TabIndex = 8
        Me.chkBackup.Text = "Backup lisp files before cleaning (Recommended)"
        Me.chkBackup.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLog.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.GreenYellow
        Me.txtLog.Location = New System.Drawing.Point(11, 84)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(771, 336)
        Me.txtLog.TabIndex = 9
        '
        'LspCleaner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 509)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.chkBackup)
        Me.Controls.Add(Me.lblAction)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnScanFolder)
        Me.Controls.Add(Me.progress)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnScan)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "LspCleaner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisp Cleaner 1.2 - MetinSaylan.Com"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents progress As System.Windows.Forms.ProgressBar
    Friend WithEvents btnScanFolder As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblAction As System.Windows.Forms.Label
    Friend WithEvents chkBackup As System.Windows.Forms.CheckBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
End Class
