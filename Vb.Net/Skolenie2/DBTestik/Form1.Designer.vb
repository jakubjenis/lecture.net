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
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "NewDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1})
        Me.DataTable1.TableName = "Termin"
        '
        'DataColumn1
        '
        Me.DataColumn1.AllowDBNull = False
        Me.DataColumn1.AutoIncrement = True
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(Integer)
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID})
        Me.DataGridView1.DataSource = Me.DataSet1
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 391)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataSet1 As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
