Imports System.Reflection
Imports System.Data.SQLite

Public Class frmMusic
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
    End Sub

    ''' <summary>
    ''' 読み書き
    ''' </summary>
    Private Sub I_DataSet()
        LG_bSetbyProg = True

        dgv.SuspendLayout()
        dgv.AllowUserToAddRows = False
        dgv.Rows.Clear()

        Try
            Using cmd As New SQLiteCommand
                cmd.Connection = LG_cn
                cmd.CommandText = "select * from 楽曲テーブル" &
                                  " where ライブid = " & cmbLive.SelectedValue.ToString &
                                  " order by 曲順"
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                Do While reader.Read
                    Dim iRow As Integer = dgv.RowCount
                    dgv.Rows.Add()
                    dgv.Rows(iRow).Cells(col_曲順.Index).Value = reader("曲順")
                    dgv.Rows(iRow).Cells(col_楽曲名.Index).Value = reader("楽曲名")
                    dgv.Rows(iRow).Cells(col_楽曲id.Index).Value = reader("楽曲id")
                Loop
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        dgv.AllowUserToAddRows = True
        dgv.ResumeLayout()

        LG_bSetbyProg = False
    End Sub

    ''' <summary>
    ''' Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMusic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Dim iID As Integer = dgv.Rows(e.RowIndex).Cells(col_楽曲id.Index).Value
                Dim htParm As New Hashtable
                Dim strRet As String = ""
                htParm("ライブid") = cmbLive.SelectedValue
                htParm("曲順") = Val(dgv.Rows(e.RowIndex).Cells(col_曲順.Index).Value)
                htParm("楽曲名") = dgv.Rows(e.RowIndex).Cells(col_楽曲名.Index).Value

                If iID = 0 Then
                    '---< 追加 >---
                    If htParm("楽曲名") <> "" Then
                        strRet = C_CommandInsert("楽曲テーブル", htParm, cmd)
                    End If
                Else
                    If htParm("楽曲名") <> "" Then
                        '---< 更新 >---
                        strRet = C_CommandUpdate("楽曲テーブル", htParm, cmd, " where 楽曲id = " & iID.ToString)
                    End If
                End If

                If strRet <> "" Then
                    Throw New Exception(strRet)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' dgvに行追加した
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        dgv.Rows(e.RowIndex).Cells(col_曲順.Index).Value = (e.RowIndex + 1).ToString
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