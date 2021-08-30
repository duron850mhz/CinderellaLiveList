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
        Me.btnSelectLive = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnLive = New System.Windows.Forms.Button()
        Me.btnPerson = New System.Windows.Forms.Button()
        Me.col_Song = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblLive = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelectLive
        '
        Me.btnSelectLive.Location = New System.Drawing.Point(12, 12)
        Me.btnSelectLive.Name = "btnSelectLive"
        Me.btnSelectLive.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectLive.TabIndex = 0
        Me.btnSelectLive.Text = "ライブ選択"
        Me.btnSelectLive.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Song})
        Me.dgv.Location = New System.Drawing.Point(12, 41)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 21
        Me.dgv.Size = New System.Drawing.Size(776, 368)
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
        Me.btnPerson.Text = "出演者"
        Me.btnPerson.UseVisualStyleBackColor = True
        '
        'col_Song
        '
        Me.col_Song.HeaderText = "Song"
        Me.col_Song.Name = "col_Song"
        Me.col_Song.ReadOnly = True
        '
        'lblLive
        '
        Me.lblLive.AutoSize = True
        Me.lblLive.Location = New System.Drawing.Point(93, 17)
        Me.lblLive.Name = "lblLive"
        Me.lblLive.Size = New System.Drawing.Size(89, 12)
        Me.lblLive.TabIndex = 4
        Me.lblLive.Text = "選択中のライブ名"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblLive)
        Me.Controls.Add(Me.btnPerson)
        Me.Controls.Add(Me.btnLive)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnSelectLive)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "メイン"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelectLive As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnLive As Button
    Friend WithEvents btnPerson As Button
    Friend WithEvents col_Song As DataGridViewTextBoxColumn
    Friend WithEvents lblLive As Label
End Class
