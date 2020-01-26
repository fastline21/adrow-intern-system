<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbFullname = New System.Windows.Forms.ComboBox()
        Me.lblDateAndTime = New System.Windows.Forms.Label()
        Me.tmrDateAndTime = New System.Windows.Forms.Timer(Me.components)
        Me.btnLog = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fullname:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date and Time"
        '
        'cbFullname
        '
        Me.cbFullname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFullname.FormattingEnabled = True
        Me.cbFullname.Location = New System.Drawing.Point(204, 78)
        Me.cbFullname.Name = "cbFullname"
        Me.cbFullname.Size = New System.Drawing.Size(320, 21)
        Me.cbFullname.TabIndex = 2
        '
        'lblDateAndTime
        '
        Me.lblDateAndTime.AutoSize = True
        Me.lblDateAndTime.Location = New System.Drawing.Point(201, 43)
        Me.lblDateAndTime.Name = "lblDateAndTime"
        Me.lblDateAndTime.Size = New System.Drawing.Size(77, 13)
        Me.lblDateAndTime.TabIndex = 3
        Me.lblDateAndTime.Text = "Date and Time"
        '
        'tmrDateAndTime
        '
        '
        'btnLog
        '
        Me.btnLog.Location = New System.Drawing.Point(272, 126)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(75, 23)
        Me.btnLog.TabIndex = 4
        Me.btnLog.Text = "Login"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'btnAdmin
        '
        Me.btnAdmin.Location = New System.Drawing.Point(537, 406)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(75, 23)
        Me.btnAdmin.TabIndex = 5
        Me.btnAdmin.Text = "Admin"
        Me.btnAdmin.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 161)
        Me.Controls.Add(Me.btnAdmin)
        Me.Controls.Add(Me.btnLog)
        Me.Controls.Add(Me.lblDateAndTime)
        Me.Controls.Add(Me.cbFullname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbFullname As ComboBox
    Friend WithEvents lblDateAndTime As Label
    Friend WithEvents tmrDateAndTime As Timer
    Friend WithEvents btnLog As Button
    Friend WithEvents btnAdmin As Button
End Class
