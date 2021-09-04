Imports System.Reflection
Imports System.Data.SQLite

Public Class frmPerformer

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
End Class