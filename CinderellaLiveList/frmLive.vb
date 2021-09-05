Imports System.Reflection
Imports System.Data.SQLite

Public Class frmLive

    Dim LG_bSetbyProg As Boolean = False

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
    End Sub

    ''' <summary>
    ''' 読み書き
    ''' </summary>
    ''' <param name="iMode"></param>
    Private Sub I_DataSet(iMode As Integer)
        LG_bSetbyProg = True

        Select Case iMode
            Case 0
                '読み込み
                dgv.SuspendLayout()
                dgv.AllowUserToAddRows = False
                dgv.Rows.Clear()

                Try
                    Using cn As New SQLiteConnection(DB_CS_SQLite)
                        cn.Open()
                        Using cmd As New SQLite.SQLiteCommand
                            cmd.Connection = cn
                            cmd.CommandText = "select * from ライブテーブル" &
                                              " order by ライブ日付"
                            Dim reader As SQLite.SQLiteDataReader = cmd.ExecuteReader
                            Do While reader.Read
                                Dim iRow As Integer = dgv.RowCount
                                dgv.Rows.Add()
                                dgv.Rows(iRow).Cells(col_ライブ日付.Index).Value = CDate(reader("ライブ日付")).ToShortDateString
                                dgv.Rows(iRow).Cells(col_ライブ名.Index).Value = reader("ライブ名")
                                dgv.Rows(iRow).Cells(col_ライブid.Index).Value = reader("ライブid")
                                dgv.Rows(iRow).Cells(col_Flag.Index).Value = ""
                            Loop
                            reader.Close()
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

                dgv.AllowUserToAddRows = True
                dgv.ResumeLayout()

            Case 1
                '書き込み
                Try
                    Using cn As New SQLiteConnection(DB_CS_SQLite)
                        cn.Open()
                        Dim tran As SQLite.SQLiteTransaction = cn.BeginTransaction
                        Using cmd As New SQLite.SQLiteCommand
                            cmd.Connection = cn
                            For ii = 0 To dgv.RowCount - 1
                                If dgv.Rows(ii).Cells(col_Flag.Index).Value <> "" Then
                                    Dim htParm As New Hashtable
                                    Dim strRet As String = ""
                                    htParm("ライブ日付") = CDate(dgv.Rows(ii).Cells(col_ライブ日付.Index).Value).ToShortDateString
                                    htParm("ライブ名") = dgv.Rows(ii).Cells(col_ライブ名.Index).Value
                                    Dim iID As Integer = Val(dgv.Rows(ii).Cells(col_ライブid.Index).Value)

                                    If iID = 0 Then
                                        '---< 追加 >---
                                        If htParm("ライブ名") <> "" Then
                                            strRet = C_CommandInsert("ライブテーブル", htParm, cmd)
                                        End If
                                    Else
                                        If htParm("ライブ名") <> "" Then
                                            '---< 更新 >---
                                            strRet = C_CommandUpdate("ライブテーブル", htParm, cmd, " where ライブid = " & iID.ToString)
                                        Else
                                            '---< 削除 >---
                                            cmd.CommandText = "delete from ライブテーブル" &
                                                              " where ライブid = " & iID.ToString
                                            cmd.ExecuteNonQuery()
                                        End If
                                    End If

                                    If strRet <> "" Then
                                        Throw New Exception(strRet)
                                    End If
                                End If
                            Next

                            tran.Commit()
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
        End Select

        LG_bSetbyProg = False
    End Sub

    ''' <summary>
    ''' Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmLive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call I_Init()
        Call I_DataSet(0)
    End Sub

    ''' <summary>
    ''' Form Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmLive_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = DialogResult.OK Then
            Call I_DataSet(1)
        End If
    End Sub

    ''' <summary>
    ''' なんか変更した
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        If e.RowIndex <> -1 Then
            If LG_bSetbyProg = False Then
                dgv.Rows(e.RowIndex).Cells(col_Flag.Index).Value = "1"
            End If
        End If
    End Sub
End Class