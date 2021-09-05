Imports System.Reflection
Imports System.Data.SQLite

Public Class frmMain

    Private Sub I_DataSet()
        Using cn As New SQLiteConnection(DB_CS_SQLite)
            cn.Open()
            Using cmd As New SQLite.SQLiteCommand
                cmd.Connection = cn
            End Using
        End Using
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

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgv.GetType().InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic Or
            BindingFlags.Instance Or
            BindingFlags.SetProperty,
            Nothing,
            dgv,
            New Object() {True})

        C_SQLiteInitialize()
    End Sub
End Class
