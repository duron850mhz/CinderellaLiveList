<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerson
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerson))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.col_声優名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_声優カナ名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_声優役名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_声優id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Flag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_声優名, Me.col_声優カナ名, Me.col_声優役名, Me.col_声優id, Me.col_Flag})
        Me.dgv.Location = New System.Drawing.Point(16, 12)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 21
        Me.dgv.Size = New System.Drawing.Size(772, 397)
        Me.dgv.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(713, 415)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "登録"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(12, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'col_声優名
        '
        Me.col_声優名.HeaderText = "声優名"
        Me.col_声優名.Name = "col_声優名"
        Me.col_声優名.Width = 200
        '
        'col_声優カナ名
        '
        Me.col_声優カナ名.HeaderText = "声優カナ名"
        Me.col_声優カナ名.Name = "col_声優カナ名"
        Me.col_声優カナ名.Width = 200
        '
        'col_声優役名
        '
        Me.col_声優役名.HeaderText = "声優役名"
        Me.col_声優役名.Name = "col_声優役名"
        Me.col_声優役名.Width = 200
        '
        'col_声優id
        '
        Me.col_声優id.HeaderText = "声優id"
        Me.col_声優id.Name = "col_声優id"
        Me.col_声優id.ReadOnly = True
        Me.col_声優id.Visible = False
        '
        'col_Flag
        '
        Me.col_Flag.HeaderText = "Flag"
        Me.col_Flag.Name = "col_Flag"
        Me.col_Flag.ReadOnly = True
        Me.col_Flag.Visible = False
        '
        'frmPerson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerson"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "声優"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents col_声優名 As DataGridViewTextBoxColumn
    Friend WithEvents col_声優カナ名 As DataGridViewTextBoxColumn
    Friend WithEvents col_声優役名 As DataGridViewTextBoxColumn
    Friend WithEvents col_声優id As DataGridViewTextBoxColumn
    Friend WithEvents col_Flag As DataGridViewTextBoxColumn
End Class
