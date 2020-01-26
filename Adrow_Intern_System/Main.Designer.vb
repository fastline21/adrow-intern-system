<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnAddIntern = New System.Windows.Forms.Button()
        Me.lvIntern = New System.Windows.Forms.ListView()
        Me.btnEditIntern = New System.Windows.Forms.Button()
        Me.tmrIntern = New System.Windows.Forms.Timer(Me.components)
        Me.btnDeleteIntern = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddIntern
        '
        Me.btnAddIntern.Location = New System.Drawing.Point(12, 12)
        Me.btnAddIntern.Name = "btnAddIntern"
        Me.btnAddIntern.Size = New System.Drawing.Size(75, 23)
        Me.btnAddIntern.TabIndex = 0
        Me.btnAddIntern.Text = "Add Intern"
        Me.btnAddIntern.UseVisualStyleBackColor = True
        '
        'lvIntern
        '
        Me.lvIntern.FullRowSelect = True
        Me.lvIntern.HideSelection = False
        Me.lvIntern.Location = New System.Drawing.Point(123, 12)
        Me.lvIntern.MultiSelect = False
        Me.lvIntern.Name = "lvIntern"
        Me.lvIntern.Size = New System.Drawing.Size(489, 127)
        Me.lvIntern.TabIndex = 1
        Me.lvIntern.UseCompatibleStateImageBehavior = False
        Me.lvIntern.View = System.Windows.Forms.View.Details
        '
        'btnEditIntern
        '
        Me.btnEditIntern.Location = New System.Drawing.Point(12, 63)
        Me.btnEditIntern.Name = "btnEditIntern"
        Me.btnEditIntern.Size = New System.Drawing.Size(75, 23)
        Me.btnEditIntern.TabIndex = 2
        Me.btnEditIntern.Text = "Edit Intern"
        Me.btnEditIntern.UseVisualStyleBackColor = True
        '
        'tmrIntern
        '
        Me.tmrIntern.Interval = 10000
        '
        'btnDeleteIntern
        '
        Me.btnDeleteIntern.Location = New System.Drawing.Point(12, 116)
        Me.btnDeleteIntern.Name = "btnDeleteIntern"
        Me.btnDeleteIntern.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteIntern.TabIndex = 3
        Me.btnDeleteIntern.Text = "Delete Intern"
        Me.btnDeleteIntern.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 161)
        Me.Controls.Add(Me.btnDeleteIntern)
        Me.Controls.Add(Me.btnEditIntern)
        Me.Controls.Add(Me.lvIntern)
        Me.Controls.Add(Me.btnAddIntern)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddIntern As Button
    Friend WithEvents lvIntern As ListView
    Friend WithEvents btnEditIntern As Button
    Friend WithEvents tmrIntern As Timer
    Friend WithEvents btnDeleteIntern As Button
End Class
