<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbInput = New System.Windows.Forms.GroupBox()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.dgData = New System.Windows.Forms.DataGridView()
        Me.txtRowPath = New System.Windows.Forms.TextBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.lblRowPath = New System.Windows.Forms.Label()
        Me.btnScrape = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbInput.SuspendLayout()
        Me.gbData.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbInput)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbData)
        Me.SplitContainer1.Size = New System.Drawing.Size(580, 426)
        Me.SplitContainer1.SplitterDistance = 247
        Me.SplitContainer1.TabIndex = 0
        '
        'gbInput
        '
        Me.gbInput.Controls.Add(Me.btnAddItem)
        Me.gbInput.Controls.Add(Me.btnScrape)
        Me.gbInput.Controls.Add(Me.lblRowPath)
        Me.gbInput.Controls.Add(Me.lblURL)
        Me.gbInput.Controls.Add(Me.txtURL)
        Me.gbInput.Controls.Add(Me.txtRowPath)
        Me.gbInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbInput.Location = New System.Drawing.Point(0, 0)
        Me.gbInput.Name = "gbInput"
        Me.gbInput.Size = New System.Drawing.Size(247, 426)
        Me.gbInput.TabIndex = 0
        Me.gbInput.TabStop = False
        Me.gbInput.Text = "Vstupné dáta"
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.dgData)
        Me.gbData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbData.Location = New System.Drawing.Point(0, 0)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(329, 426)
        Me.gbData.TabIndex = 0
        Me.gbData.TabStop = False
        Me.gbData.Text = "Získané dáta"
        '
        'dgData
        '
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgData.Location = New System.Drawing.Point(3, 16)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(323, 407)
        Me.dgData.TabIndex = 0
        '
        'txtRowPath
        '
        Me.txtRowPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRowPath.Location = New System.Drawing.Point(6, 81)
        Me.txtRowPath.Name = "txtRowPath"
        Me.txtRowPath.Size = New System.Drawing.Size(236, 20)
        Me.txtRowPath.TabIndex = 1
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURL.Location = New System.Drawing.Point(6, 39)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(236, 20)
        Me.txtURL.TabIndex = 0
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(7, 22)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(29, 13)
        Me.lblURL.TabIndex = 5
        Me.lblURL.Text = "URL"
        '
        'lblRowPath
        '
        Me.lblRowPath.AutoSize = True
        Me.lblRowPath.Location = New System.Drawing.Point(10, 64)
        Me.lblRowPath.Name = "lblRowPath"
        Me.lblRowPath.Size = New System.Drawing.Size(75, 13)
        Me.lblRowPath.TabIndex = 6
        Me.lblRowPath.Text = "Cesta k riadku"
        '
        'btnScrape
        '
        Me.btnScrape.Location = New System.Drawing.Point(6, 397)
        Me.btnScrape.Name = "btnScrape"
        Me.btnScrape.Size = New System.Drawing.Size(96, 23)
        Me.btnScrape.TabIndex = 7
        Me.btnScrape.Text = "Spustiť"
        Me.btnScrape.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Location = New System.Drawing.Point(6, 107)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(96, 23)
        Me.btnAddItem.TabIndex = 8
        Me.btnAddItem.Text = "Pridaj položku"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 426)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbInput.ResumeLayout(False)
        Me.gbInput.PerformLayout()
        Me.gbData.ResumeLayout(False)
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbInput As System.Windows.Forms.GroupBox
    Friend WithEvents gbData As System.Windows.Forms.GroupBox
    Friend WithEvents dgData As System.Windows.Forms.DataGridView
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents txtRowPath As System.Windows.Forms.TextBox
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents lblRowPath As System.Windows.Forms.Label
    Friend WithEvents btnAddItem As System.Windows.Forms.Button
    Friend WithEvents btnScrape As System.Windows.Forms.Button

End Class
