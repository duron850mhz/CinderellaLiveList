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
             "drop table if exists 声優テーブル;" &
             "drop table if exists 出演者テーブル;" &
             "drop table if exists 出演者詳細テーブル;" &
             "CREATE TABLE [ライブテーブル] (" &
                "[ライブid] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[ライブ名] TEXT," &
                "[ライブ日付] TEXT," &
                "[ライブデータ] TEXT);" &
             "CREATE TABLE [楽曲テーブル] (" &
                "[楽曲id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[楽曲名] TEXT," &
                "[楽曲備考] TEXT);" &
             "CREATE TABLE [声優テーブル] (" &
                "[声優id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[声優名] TEXT," &
                "[声優カナ名] TEXT," &
                "[声優役名] TEXT);" &
             "CREATE TABLE [出演者テーブル] (" &
                "[出演者id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[声優id] INTEGER REFERENCES [声優テーブル]([声優id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[ライブid] INTEGER REFERENCES [ライブテーブル]([ライブid]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[ゲスト] BOOLEAN);" &
             "CREATE TABLE [歌唱テーブル] (" &
                "[歌唱id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[ライブid] INTEGER REFERENCES [ライブテーブル]([ライブid]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[曲順] INTEGER," &
                "[楽曲id] INTEGER REFERENCES [楽曲テーブル]([楽曲id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[歌唱備考] TEXT);" &
             "CREATE TABLE [歌唱者テーブル] (" &
                "[歌唱者id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[歌唱id] INTEGER REFERENCES [歌唱テーブル]([歌唱id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[声優id] INTEGER REFERENCES [声優テーブル]([声優id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[歌唱者フラグ] INTEGER);"
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Module