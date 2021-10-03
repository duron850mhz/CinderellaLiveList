Imports System.Reflection
Imports System.Data.SQLite

Public Class frmPerformer

    Dim LG_bSetbyProg As Boolean = False

    Dim LG_cn As New SQLiteConnection(DB_CS_SQLite)
    Dim LG_tran As SQLiteTransaction

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

        'SQLite初期化
        C_SQLiteInitialize()

        'SQLite おぷーん
        LG_cn.Open()
        LG_tran = LG_cn.BeginTransaction

        'ライブCombo
        Using cmd As New SQLiteCommand
            cmd.Connection = LG_cn
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

        '声優一覧
        Using cmd As New SQLiteCommand
            cmd.Connection = LG_cn
            cmd.CommandText = "select * from 声優テーブル" &
                              " order by 声優カナ名"
            Dim reader As SQLite.SQLiteDataReader = cmd.ExecuteReader
            Do While reader.Read
                Dim iRow As Integer = dgv.RowCount
                dgv.Rows.Add()
                dgv.Rows(iRow).Cells(col_声優名.Index).Value = reader("声優名")
                dgv.Rows(iRow).Cells(col_声優id.Index).Value = reader("声優id")
            Loop
            reader.Close()
        End Using
    End Sub

    ''' <summary>
    ''' 読み書き
    ''' </summary>
    Private Sub I_DataSet()
        dgv.SuspendLayout()
        For ii = 0 To dgv.RowCount - 1
            If dgv.Rows(ii).Cells(col_出演.Index).Value = True Then
                dgv.Rows(ii).Cells(col_出演.Index).Value = False
            End If
        Next

        Using cmd As New SQLiteCommand
            cmd.Connection = LG_cn
            cmd.CommandText = "select * from 出演者テーブル" &
                              " where ライブid = " & cmbLive.SelectedValue.ToString &
                              " order by 声優id"
            Dim reader As SQLiteDataReader = cmd.ExecuteReader
            Dim iRow As Integer = 0
            Do While reader.Read
                For ii = iRow To dgv.RowCount - 1
                    If dgv.Rows(ii).Cells(col_声優id.Index).Value = reader("声優id") Then
                        dgv.Rows(ii).Cells(col_出演.Index).Value = True
                        dgv.Rows(ii).Cells(col_出演者id.Index).Value = reader("出演者id")
                        iRow = ii
                        Exit For
                    End If
                Next
            Loop
            reader.Close()
        End Using

        dgv.ResumeLayout()
    End Sub

    ''' <summary>
    ''' Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmPerformer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call I_Init()
        Call I_DataSet()
    End Sub

    ''' <summary>
    ''' Form Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMusic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = DialogResult.OK Then
            If LG_cn.State = ConnectionState.Open Then
                LG_tran.Commit()
            End If
        Else
            If LG_cn.State = ConnectionState.Open Then
                LG_tran.Rollback()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 編集おわり
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        Try
            Using cmd As New SQLiteCommand
                cmd.Connection = LG_cn
                Dim iID As Integer = Val(dgv.Rows(e.RowIndex).Cells(col_出演者id.Index).Value)
                Dim htParm As New Hashtable
                Dim strRet As String = ""
                htParm("ライブid") = cmbLive.SelectedValue
                htParm("声優id") = Val(dgv.Rows(e.RowIndex).Cells(col_声優id.Index).Value)

                If iID = 0 Then
                    '---< 追加 >---
                    If dgv.Rows(e.RowIndex).Cells(col_出演.Index).Value = True Then
                        strRet = C_CommandInsert("出演者テーブル", htParm, cmd)
                        If strRet <> "" Then
                            Throw New Exception(strRet)
                        Else
                            cmd.CommandText = "select seq from sqlite_sequence where name='出演者テーブル'"
                            dgv.Rows(e.RowIndex).Cells(col_出演者id.Index).Value = cmd.ExecuteScalar
                        End If
                    End If
                Else
                    If dgv.Rows(e.RowIndex).Cells(col_出演.Index).Value = False Then
                        '---< 削除 >---
                        cmd.CommandText = "delete from 出演者テーブル" &
                                          " where 出演者id = " & iID.ToString
                        cmd.ExecuteNonQuery()
                        dgv.Rows(e.RowIndex).Cells(col_出演者id.Index).Value = ""
                    End If
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' ライブ選択した
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbLive_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbLive.SelectionChangeCommitted
        Call I_DataSet()
    End Sub
End Class