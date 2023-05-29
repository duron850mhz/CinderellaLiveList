Imports System.Reflection
Imports System.Data.SQLite

Public Class frmMain
    ''' <summary>
    ''' 初期化
    ''' </summary>
    Private Sub I_Init()
        'DGV高速化
        dgv.GetType().InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic Or
            BindingFlags.Instance Or
            BindingFlags.SetProperty,
            Nothing,
            dgv,
            New Object() {True})

        C_SQLiteInitialize()

        'ライブCombo
        Using cn As New SQLiteConnection(DB_CS_SQLite)
            Using cmd As New SQLiteCommand
                cmd.Connection = cn
                cmd.CommandText = "select * from ライブテーブル" &
                                  " order by ライブ日付"
                Using da As New SQLite.SQLiteDataAdapter
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    cmbLive.DisplayMember = "ライブ名"
                    cmbLive.ValueMember = "ライブid"
                    cmbLive.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' 読み書き
    ''' </summary>
    Private Sub I_DataSet()
        dgv.SuspendLayout()
        dgv.Rows.Clear()

        If cmbLive.SelectedIndex >= 0 Then
            Try
                Using cn As New SQLiteConnection(DB_CS_SQLite)
                    cn.Open()
                    Using cmd As New SQLite.SQLiteCommand
                        cmd.Connection = cn
                        cmd.CommandText = "select * from 歌唱テーブル,楽曲テーブル" &
                                          " where 歌唱テーブル.楽曲id = 楽曲テーブル.楽曲id" &
                                          " and ライブid = " & cmbLive.SelectedValue.ToString &
                                          " order by 曲順"
                        Dim reader As SQLiteDataReader = cmd.ExecuteReader
                        Do While reader.Read
                            Dim iRow As Integer = dgv.RowCount
                            dgv.Rows.Add()
                            dgv.Rows(iRow).Cells(col_楽曲名.Index).Value = reader("楽曲名")
                            dgv.Rows(iRow).Cells(col_楽曲id.Index).Value = reader("楽曲id")
                        Loop
                        reader.Close()

                        dgv.ColumnCount = 1
                        cmd.CommandText = "select * from 出演者テーブル,声優テーブル" &
                                          " where 出演者テーブル.声優id = 声優テーブル.声優id" &
                                          " and ライブid = " & cmbLive.SelectedValue.ToString &
                                          " order by 声優カナ名"
                        reader = cmd.ExecuteReader
                        Do While reader.Read
                            Dim c As New DataGridViewTextBoxColumn
                            c.HeaderText = reader("声優名")
                            c.Name = reader("声優id")
                            c.Width = 20
                            dgv.Columns.Add(c)
                        Loop
                        reader.Close()

                        cmd.CommandText = "select * from 歌唱テーブル,歌唱者テーブル" &
                                          " where 歌唱テーブル.歌唱id = 歌唱者テーブル.歌唱id" &
                                          " and ライブid = " & cmbLive.SelectedValue.ToString
                        reader = cmd.ExecuteReader
                        Do While reader.Read
                            For iCol = 1 To dgv.ColumnCount - 1
                                If reader("声優id") = dgv.Columns(iCol).Name Then
                                    For iRow = 0 To dgv.RowCount - 1
                                        If reader("楽曲id") = dgv.Rows(iRow).Cells(col_楽曲id.Index).Value Then
                                            dgv.Rows(iRow).Cells(iCol).Value = "◯"
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                End If
                            Next
                        Loop
                        reader.Close()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        dgv.ResumeLayout()
    End Sub

    ''' <summary>
    ''' ライブ登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLive_Click(sender As Object, e As EventArgs) Handles btnLive.Click
        Using _frm As New frmLive
            _frm.ShowDialog()
            _frm.Dispose()
        End Using
    End Sub

    ''' <summary>
    ''' 出演者登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPerson_Click(sender As Object, e As EventArgs) Handles btnPerson.Click
        Using _frm As New frmPerson
            _frm.ShowDialog()
            _frm.Dispose()
        End Using
    End Sub

    ''' <summary>
    ''' 楽曲登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnMusic_Click(sender As Object, e As EventArgs) Handles btnMusic.Click
        Using _frm As New frmMusic
            _frm.ShowDialog()
            _frm.Dispose()
        End Using
    End Sub

    ''' <summary>
    ''' 出演者登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPerformer_Click(sender As Object, e As EventArgs) Handles btnPerformer.Click
        Using _frm As New frmPerformer
            _frm.ShowDialog()
            _frm.Dispose()
        End Using
    End Sub

    ''' <summary>
    ''' Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call I_Init()
    End Sub

    Private Sub cmbLive_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbLive.SelectionChangeCommitted
        Call I_DataSet()
    End Sub

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex > 0 Then
            e.Handled = True
            e.PaintBackground(e.ClipBounds, False)
            Dim g = e.Graphics()
            Dim sf As New StringFormat()
            'Dim fnt = New Font("@ＭＳ ゴシック", 10, FontStyle.Regular)
            Dim fnt = dgv.ColumnHeadersDefaultCellStyle.Font
            sf.FormatFlags = StringFormatFlags.DirectionVertical Or StringFormatFlags.NoWrap
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center
            g.DrawString(dgv.Columns(e.ColumnIndex).HeaderText, fnt, Brushes.Black, e.CellBounds, sf)
        End If
    End Sub
End Class
