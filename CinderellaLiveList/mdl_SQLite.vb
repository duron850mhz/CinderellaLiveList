Module mdl_SQLite
    Public DB_CS_SQLite As String

    ''' <summary>
    ''' 接続文字列初期化
    ''' </summary>
    ''' <remarks>最初にこれを呼ばないと読み書きできないぜっ</remarks>
    Public Sub C_SQLiteInitialize()
        Dim strDBPath As String = System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, "db")
        DB_CS_SQLite = "Version=3;Data Source=" & strDBPath & ";New=False;Compress=True;"

        If System.IO.File.Exists(strDBPath) = False Then
            C_SQLiteInitTable()
        End If
    End Sub

    ''' <summary>
    ''' テーブル初期化
    ''' </summary>
    Public Sub C_SQLiteInitTable()
        Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
            'ｵﾌﾟｰﾝ
            cn.Open()

            'DB初期化
            Dim cmd As New SQLite.SQLiteCommand()
            cmd.Connection = cn

            Dim strSQL As String = "drop table if exists ライブテーブル;" &
             "drop table if exists 楽曲テーブル;" &
             "drop table if exists 出演者テーブル;" &
             "drop table if exists 出演者詳細テーブル;" &
             "CREATE TABLE [ライブテーブル] (" &
                "[ライブid] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[ライブ名] TEXT," &
                "[ライブ日付] TEXT;" &
             "CREATE TABLE [楽曲テーブル] (" &
                "[楽曲id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[ライブid] INTEGER REFERENCES [ライブテーブル]([ライブid]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[曲順] INTEGER," &
                "[楽曲名] TEXT);" &
             "CREATE TABLE [出演者テーブル] (" &
                "[出演者id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[出演者名] TEXT," &
                "[出演者カナ名] TEXT," &
                "[出演者役名] TEXT);" &
             "CREATE TABLE [出演者詳細テーブル] (" &
                "[出演者詳細id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[出演者id] INTEGER REFERENCES [出演者テーブル]([出演者id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[楽曲id] INTEGER REFERENCES [楽曲テーブル]([楽曲id]) ON DELETE CASCADE ON UPDATE CASCADE);"

            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>
    ''' SQLiteCommand.ExecuteScalarを実行する
    ''' 単一の答えを返すSQLじゃないと使えないと思うよ
    ''' </summary>
    ''' <param name="strSQL">SQL文</param>
    ''' <returns>実行結果</returns>
    ''' <remarks></remarks>
    Public Function C_SQLiteExecuteScalar(ByVal strSQL As String) As Object
        Try
            Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
                Dim cmd As New SQLite.SQLiteCommand(strSQL, cn)
                cn.Open()
                Return cmd.ExecuteScalar
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "C_SQLiteExecuteScalar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return vbNullChar
        End Try
    End Function

    ''' <summary>
    ''' SQLiteCommand.ExecuteNonQueryを実行する
    ''' 結果が必要ないSQL文(insertとかupdateとか)で使えるよ
    ''' </summary>
    ''' <param name="strSQL">SQL文</param>
    ''' <returns>成否</returns>
    ''' <remarks></remarks>
    Public Function C_SQLiteExecuteNonQuery(ByVal strSQL As String) As Boolean
        Try
            Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
                Dim cmd As New SQLite.SQLiteCommand(strSQL, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "C_SQLiteExecuteNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    Public Function C_CommandInsert(ByVal strTable As String,
                                    ByVal htParm As Hashtable,
                                    ByVal cmd As SQLite.SQLiteCommand) As String
        If (htParm.Count = 0) Then
            'スカかよ！
            Return "パラメータのハッシュテーブルが空白です"
        Else
            Try
                Dim strSQL As String = ""
                Dim strParm As String = ""
                Dim strValue As String = ""
                Dim iCnt As Integer = 0

                cmd.Parameters.Clear()

                strSQL = "insert into " & strTable & " ("
                For Each strKey As String In htParm.Keys
                    If (strParm <> "") Then
                        strParm &= ","
                        strValue &= ","
                    End If
                    strParm &= strKey
                    strValue &= "@p" & iCnt.ToString
                    cmd.Parameters.Add(New SQLite.SQLiteParameter("@p" & iCnt.ToString, htParm(strKey)))
                    iCnt += 1
                Next

                cmd.CommandText = strSQL & strParm & ") values (" & strValue & ")"
                cmd.ExecuteNonQuery()
                Return ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, Reflection.MethodBase.GetCurrentMethod.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return ex.Message
            End Try
        End If
    End Function

    Public Function C_CommandUpdate(ByVal strTable As String,
                                    ByVal htParm As Hashtable,
                                    ByVal cmd As SQLite.SQLiteCommand,
                                    ByVal strWhere As String) As String
        If (htParm.Count = 0) Then
            'スカかよ！
            Return "パラメータのハッシュテーブルが空白です。"
        Else
            Try
                Dim strSQL As String = "update " & strTable & " set "
                Dim strParm As String = ""
                Dim strValue As String = ""
                Dim iCnt As Integer = 0

                cmd.Parameters.Clear()
                For Each strKey As String In htParm.Keys
                    If (strParm <> "") Then
                        strParm &= ","
                    End If
                    strParm &= strKey & "=@p" & iCnt.ToString
                    cmd.Parameters.Add(New SQLite.SQLiteParameter("@p" & iCnt.ToString, htParm(strKey)))
                    iCnt += 1
                Next

                cmd.CommandText = strSQL & strParm & " " & strWhere
                cmd.ExecuteNonQuery()
                Return ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, Reflection.MethodBase.GetCurrentMethod.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return ex.Message
            End Try
        End If
    End Function

End Module
