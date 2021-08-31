Imports System.Reflection
Imports System.Data.SQLite

Public Class frmLive
    Private Sub frmLive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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