<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiny
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
        Me.pnlMines = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.lblMinesLeft = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pnlMines
        '
        Me.pnlMines.Location = New System.Drawing.Point(3, 52)
        Me.pnlMines.Name = "pnlMines"
        Me.pnlMines.Size = New System.Drawing.Size(400, 400)
        Me.pnlMines.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(342, 9)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(61, 34)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'lblMinesLeft
        '
        Me.lblMinesLeft.AutoSize = True
        Me.lblMinesLeft.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinesLeft.Location = New System.Drawing.Point(12, 11)
        Me.lblMinesLeft.Name = "lblMinesLeft"
        Me.lblMinesLeft.Size = New System.Drawing.Size(45, 32)
        Me.lblMinesLeft.TabIndex = 2
        Me.lblMinesLeft.Text = "20"
        '
        'frmMiny
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 457)
        Me.Controls.Add(Me.lblMinesLeft)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.pnlMines)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmMiny"
        Me.Text = "Míny"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlMines As System.Windows.Forms.Panel
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblMinesLeft As System.Windows.Forms.Label

End Class
