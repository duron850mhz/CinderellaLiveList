<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMusic
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMusic))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cmbLive = New System.Windows.Forms.ComboBox()
        Me.col_曲順 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_楽曲名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_楽曲id = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.btnCancel.TabIndex = 3
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
        Me.btnOK.TabIndex = 2
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_曲順, Me.col_楽曲名, Me.col_楽曲id})
        Me.dgv.Location = New System.Drawing.Point(12, 38)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 21
        Me.dgv.Size = New System.Drawing.Size(776, 371)
        Me.dgv.TabIndex = 1
        '
        'cmbLive
        '
        Me.cmbLive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLive.FormattingEnabled = True
        Me.cmbLive.Location = New System.Drawing.Point(12, 12)
        Me.cmbLive.Name = "cmbLive"
        Me.cmbLive.Size = New System.Drawing.Size(388, 20)
        Me.cmbLive.TabIndex = 0
        '
        'col_曲順
        '
        Me.col_曲順.HeaderText = "曲順"
        Me.col_曲順.Name = "col_曲順"
        Me.col_曲順.Width = 60
        '
        'col_楽曲名
        '
        Me.col_楽曲名.HeaderText = "楽曲名"
        Me.col_楽曲名.Name = "col_楽曲名"
        Me.col_楽曲名.Width = 400
        '
        'col_楽曲id
        '
        Me.col_楽曲id.HeaderText = "楽曲id"
        Me.col_楽曲id.Name = "col_楽曲id"
        Me.col_楽曲id.ReadOnly = True
        Me.col_楽曲id.Visible = False
        '
        'frmMusic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmbLive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMusic"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "楽曲"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents cmbLive As ComboBox
    Friend WithEvents col_曲順 As DataGridViewTextBoxColumn
    Friend WithEvents col_楽曲名 As DataGridViewTextBoxColumn
    Friend WithEvents col_楽曲id As DataGridViewTextBoxColumn
End Class
