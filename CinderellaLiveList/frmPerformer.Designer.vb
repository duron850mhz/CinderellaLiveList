<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerformer
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerformer))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.col_出演者名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_出演 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_出演者id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(12, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(713, 415)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "登録"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_出演者名, Me.col_出演, Me.col_出演者id, Me.col_Flag})
        Me.dgv.Location = New System.Drawing.Point(12, 38)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 21
        Me.dgv.Size = New System.Drawing.Size(776, 371)
        Me.dgv.TabIndex = 3
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(445, 20)
        Me.ComboBox1.TabIndex = 6
        '
        'col_出演者名
        '
        Me.col_出演者名.HeaderText = "出演者名"
        Me.col_出演者名.Name = "col_出演者名"
        Me.col_出演者名.Width = 200
        '
        'col_出演
        '
        Me.col_出演.HeaderText = "出演"
        Me.col_出演.Name = "col_出演"
        Me.col_出演.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_出演.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_出演.Width = 60
        '
        'col_出演者id
        '
        Me.col_出演者id.HeaderText = "出演者id"
        Me.col_出演者id.Name = "col_出演者id"
        Me.col_出演者id.ReadOnly = True
        Me.col_出演者id.Visible = False
        '
        'col_Flag
        '
        Me.col_Flag.HeaderText = "Flag"
        Me.col_Flag.Name = "col_Flag"
        Me.col_Flag.ReadOnly = True
        Me.col_Flag.Visible = False
        '
        'frmPerformer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerformer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "出演者"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents col_出演者名 As DataGridViewTextBoxColumn
    Friend WithEvents col_出演 As DataGridViewCheckBoxColumn
    Friend WithEvents col_出演者id As DataGridViewTextBoxColumn
    Friend WithEvents col_Flag As DataGridViewTextBoxColumn
End Class
