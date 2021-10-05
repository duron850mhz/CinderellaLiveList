<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnLive = New System.Windows.Forms.Button()
        Me.btnPerson = New System.Windows.Forms.Button()
        Me.btnPerformer = New System.Windows.Forms.Button()
        Me.btnMusic = New System.Windows.Forms.Button()
        Me.cmbLive = New System.Windows.Forms.ComboBox()
        Me.col_楽曲名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_楽曲id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_楽曲名, Me.col_楽曲id})
        Me.dgv.Location = New System.Drawing.Point(12, 38)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 21
        Me.dgv.Size = New System.Drawing.Size(776, 371)
        Me.dgv.TabIndex = 1
        '
        'btnLive
        '
        Me.btnLive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLive.Location = New System.Drawing.Point(93, 415)
        Me.btnLive.Name = "btnLive"
        Me.btnLive.Size = New System.Drawing.Size(75, 23)
        Me.btnLive.TabIndex = 2
        Me.btnLive.Text = "ライブ"
        Me.btnLive.UseVisualStyleBackColor = True
        '
        'btnPerson
        '
        Me.btnPerson.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPerson.Location = New System.Drawing.Point(12, 415)
        Me.btnPerson.Name = "btnPerson"
        Me.btnPerson.Size = New System.Drawing.Size(75, 23)
        Me.btnPerson.TabIndex = 3
        Me.btnPerson.Text = "声優"
        Me.btnPerson.UseVisualStyleBackColor = True
        '
        'btnPerformer
        '
        Me.btnPerformer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPerformer.Location = New System.Drawing.Point(255, 415)
        Me.btnPerformer.Name = "btnPerformer"
        Me.btnPerformer.Size = New System.Drawing.Size(75, 23)
        Me.btnPerformer.TabIndex = 5
        Me.btnPerformer.Text = "出演者"
        Me.btnPerformer.UseVisualStyleBackColor = True
        '
        'btnMusic
        '
        Me.btnMusic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMusic.Location = New System.Drawing.Point(174, 415)
        Me.btnMusic.Name = "btnMusic"
        Me.btnMusic.Size = New System.Drawing.Size(75, 23)
        Me.btnMusic.TabIndex = 6
        Me.btnMusic.Text = "楽曲"
        Me.btnMusic.UseVisualStyleBackColor = True
        '
        'cmbLive
        '
        Me.cmbLive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLive.FormattingEnabled = True
        Me.cmbLive.Location = New System.Drawing.Point(12, 12)
        Me.cmbLive.Name = "cmbLive"
        Me.cmbLive.Size = New System.Drawing.Size(445, 20)
        Me.cmbLive.TabIndex = 7
        '
        'col_楽曲名
        '
        Me.col_楽曲名.HeaderText = "楽曲名"
        Me.col_楽曲名.Name = "col_楽曲名"
        Me.col_楽曲名.ReadOnly = True
        '
        'col_楽曲id
        '
        Me.col_楽曲id.HeaderText = "楽曲id"
        Me.col_楽曲id.Name = "col_楽曲id"
        Me.col_楽曲id.ReadOnly = True
        Me.col_楽曲id.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmbLive)
        Me.Controls.Add(Me.btnMusic)
        Me.Controls.Add(Me.btnPerformer)
        Me.Controls.Add(Me.btnPerson)
        Me.Controls.Add(Me.btnLive)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "メイン"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnLive As Button
    Friend WithEvents btnPerson As Button
    Friend WithEvents btnPerformer As Button
    Friend WithEvents btnMusic As Button
    Friend WithEvents cmbLive As ComboBox
    Friend WithEvents col_楽曲名 As DataGridViewTextBoxColumn
    Friend WithEvents col_楽曲id As DataGridViewTextBoxColumn
End Class
