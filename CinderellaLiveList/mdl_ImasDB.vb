Imports System.IO
Imports System.Net

Module mdl_ImasDB
    Private Class clsSong
        Public SongID As Integer
        Public Name As String
    End Class

    Private Class clsSing
        Public LiveID As Integer
        Public No As Integer
        Public SongID As Integer
        Public Memo As String
        Public guid As Guid
    End Class

    Private Class clsPerformer
        Public guid As Guid
        Public PerformerName As String
        Public Memo As String
        Public Flag As Integer
    End Class

    Dim LC_Song As New List(Of clsSong)
    Dim LC_Sing As New List(Of clsSing)
    Dim LC_Performer As New List(Of clsPerformer)

    ''' <summary>
    ''' テーブル初期化
    ''' </summary>
    Public Sub C_SQLiteInitTable_ImasDB()
        Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
            'ｵﾌﾟｰﾝ
            cn.Open()

            Dim cmd As New SQLite.SQLiteCommand()
            cmd.Connection = cn

            Dim strSQL As String = "insert into ライブテーブル" &
                " (ライブ名,ライブデータ)" &
                " values" &
                " ('「アイドルマスター シンデレラガールズ『デレラジ』」スペシャルステージ','https://imas-db.jp/song/event/wf2013w.html')," &
                " ('リスアニ！LIVE4 アイドルマスターシンデレラガールズ','https://imas-db.jp/song/event/lisani_live4.html')," &
                " ('WONDERFUL M@GIC!! Day1','https://imas-db.jp/song/event/cinderella1st0405.html')," &
                " ('WONDERFUL M@GIC!! Day2','https://imas-db.jp/song/event/cinderella1st0406.html')," &
                " ('PARTY M@GIC!!','https://imas-db.jp/song/event/cinderella2nd.html')," &
                " ('SUMMER FESTIV@L 2015 東京','https://imas-db.jp/song/event/cinderella_20150802.html')," &
                " ('SUMMER FESTIV@L 2015 大阪','https://imas-db.jp/song/event/cinderella_20150823.html')," &
                " ('シンデレラの舞踏会 -Power of Smile- Day1','https://imas-db.jp/song/event/cinderella3rd1128.html')," &
                " ('シンデレラの舞踏会 -Power of Smile- Day2','https://imas-db.jp/song/event/cinderella3rd1129.html')," &
                " ('TriCastle Story 神戸 Day1','https://imas-db.jp/song/event/cinderella4th0903.html')," &
                " ('TriCastle Story 神戸 Day2','https://imas-db.jp/song/event/cinderella4th0904.html')," &
                " ('TriCastle Story SSA Day1','https://imas-db.jp/song/event/cinderella4th1015.html')," &
                " ('TriCastle Story SSA Day2','https://imas-db.jp/song/event/cinderella4th1016.html')," &
                " ('Serendipity Parade!!! 宮城 Day1','https://imas-db.jp/song/event/cinderella5th0513.html')," &
                " ('Serendipity Parade!!! 宮城 Day2','https://imas-db.jp/song/event/cinderella5th0513.html')," &
                " ('Serendipity Parade!!! 石川 Day1','https://imas-db.jp/song/event/cinderella5th0527.html')," &
                " ('Serendipity Parade!!! 石川 Day2','https://imas-db.jp/song/event/cinderella5th0528.html')," &
                " ('Serendipity Parade!!! 大阪 Day1','https://imas-db.jp/song/event/cinderella5th0609.html')," &
                " ('Serendipity Parade!!! 大阪 Day2','https://imas-db.jp/song/event/cinderella5th0610.html')," &
                " ('Serendipity Parade!!! 静岡 Day1','https://imas-db.jp/song/event/cinderella5th0624.html')," &
                " ('Serendipity Parade!!! 静岡 Day2','https://imas-db.jp/song/event/cinderella5th0624.html')," &
                " ('Serendipity Parade!!! 幕張 Day1','https://imas-db.jp/song/event/cinderella5th0708.html')," &
                " ('Serendipity Parade!!! 幕張 Day2','https://imas-db.jp/song/event/cinderella5th0708.html')," &
                " ('Serendipity Parade!!! 福岡 Day1','https://imas-db.jp/song/event/cinderella5th0729.html')," &
                " ('Serendipity Parade!!! 福岡 Day2','https://imas-db.jp/song/event/cinderella5th0729.html')," &
                " ('Serendipity Parade!!! SSA Day1','https://imas-db.jp/song/event/cinderella5th0812.html')," &
                " ('Serendipity Parade!!! SSA Day2','https://imas-db.jp/song/event/cinderella5th0813.html')," &
                " ('すぷりんぐふぇすてぃばる2018 Day1','https://imas-db.jp/song/event/cingeki_20180303.html')," &
                " ('すぷりんぐふぇすてぃばる2018 Day2','https://imas-db.jp/song/event/cingeki_20180304.html')," &
                " ('Initial Mess@ge Day1','https://imas-db.jp/song/event/cinderella_tw0407.html')," &
                " ('Initial Mess@ge Day2','https://imas-db.jp/song/event/cinderella_tw0408.html')," &
                " ('SS3A Live Sound Booth♪ Day1','https://imas-db.jp/song/event/cinderella_ss3a_day1.html')," &
                " ('SS3A Live Sound Booth♪ Day2','https://imas-db.jp/song/event/cinderella_ss3a_day2.html')," &
                " ('MERRY-GO-ROUNDOME!!! メットライフドーム Day1','https://imas-db.jp/song/event/cinderella6th1110.html')," &
                " ('MERRY-GO-ROUNDOME!!! メットライフドーム Day2','https://imas-db.jp/song/event/cinderella6th1111.html')," &
                " ('MERRY-GO-ROUNDOME!!! ナゴヤドーム Day1','https://imas-db.jp/song/event/cinderella6th1201.html')," &
                " ('MERRY-GO-ROUNDOME!!! ナゴヤドーム Day2','https://imas-db.jp/song/event/cinderella6th1202.html')," &
                " ('プロデューサーさん感謝祭 in 新木場スタジオコースト','https://imas-db.jp/song/event/cinderella2019fes.html')," &
                " ('Special 3chord♪ Comical Pops! Day1','https://imas-db.jp/song/event/cinderella7th0903.html')," &
                " ('Special 3chord♪ Comical Pops! Day2','https://imas-db.jp/song/event/cinderella7th0904.html')," &
                " ('Special 3chord♪ Funky Dancing! Day1','https://imas-db.jp/song/event/cinderella7th1109.html')," &
                " ('Special 3chord♪ Funky Dancing! Day2','https://imas-db.jp/song/event/cinderella7th1110.html')," &
                " ('Special 3chord♪ Glowing Rock! Day1','https://imas-db.jp/song/event/cinderella7th0215.html')," &
                " ('Special 3chord♪ Glowing Rock! Day2','https://imas-db.jp/song/event/cinderella7th0216.html')," &
                " ('Broadcast & LIVE Happy New Yell !!! Day1','https://imas-db.jp/song/event/cinderella_hny0109.html')," &
                " ('Broadcast & LIVE Happy New Yell !!! Day2','https://imas-db.jp/song/event/cinderella_hny0110.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land Day1','https://imas-db.jp/song/event/cinderella10th_fukuoka_day1.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land Day2','https://imas-db.jp/song/event/cinderella10th_fukuoka_day2.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! Celebration Land Day1','https://imas-db.jp/song/event/cinderella10th_chiba_day1.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! Celebration Land Day2','https://imas-db.jp/song/event/cinderella10th_chiba_day2.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! CosmoStar Land Day1','https://imas-db.jp/song/event/cinderella10th_aichi_day1.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! CosmoStar Land Day2','https://imas-db.jp/song/event/cinderella10th_aichi_day2.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! Tropical Land Day1','https://imas-db.jp/song/event/cinderella10th_okinawa_day1.html')," &
                " ('M@GICAL WONDERLAND TOUR!!! Tropical Land Day2','https://imas-db.jp/song/event/cinderella10th_okinawa_day2.html')," &
                " ('M@GICAL WONDERLAND!!! Day1','https://imas-db.jp/song/event/cinderella10th_final_day1.html')," &
                " ('M@GICAL WONDERLAND!!! Day2','https://imas-db.jp/song/event/cinderella10th_final_day2.html')," &
                " ('LIKE4LIVE #cg_ootd Day1','https://imas-db.jp/song/event/cinderella_cg_like4live_ootd_day1.html')," &
                " ('LIKE4LIVE #cg_ootd Day2','https://imas-db.jp/song/event/cinderella_cg_like4live_ootd_day2.html')," &
                " ('Twinkle LIVE Constellation Gradation Day1','https://imas-db.jp/song/event/cinderella_cg_constellation_gradation_day1.html')," &
                " ('Twinkle LIVE Constellation Gradation Day2','https://imas-db.jp/song/event/cinderella_cg_constellation_gradation_day2.html')"
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        End Using

        I_GetDataFromImasDB()
    End Sub

    ''' <summary>
    ''' アイマスDBから情報を取得
    ''' </summary>
    ''' <returns></returns>
    Private Function I_GetDataFromImasDB() As Boolean
        Dim bRet As Boolean = True
        Dim strSQL As String = ""

        Try
            Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
                cn.Open()
                Using cmd As New SQLite.SQLiteCommand
                    cmd.Connection = cn
                    cmd.CommandText = "select * from ライブテーブル" &
                                      " order by ライブid"
                    Dim reader As SQLite.SQLiteDataReader = cmd.ExecuteReader
                    Do While reader.Read
                        Using wc As New WebClient
                            '指定したURLからデータを取得する
                            Using ws As Stream = wc.OpenRead(reader("ライブデータ"))
                                'エンコード指定で文字列を取得する
                                Using sr As New StreamReader(ws, System.Text.Encoding.UTF8)
                                    '分析
                                    Dim strLine As String = sr.ReadLine
                                    Do While strLine IsNot Nothing
                                        Select Case True
                                            Case strLine.StartsWith("<p>20")
                                                '多分日付
                                                Dim strTmp As String = strLine.Substring(3, 10)
                                                If IsDate(strTmp) Then
                                                    strSQL &= "update ライブテーブル" &
                                                              " set ライブ日付 = '" & CDate(strTmp).ToShortDateString & "'" &
                                                              " where ライブid = " & reader("ライブid").ToString & ";"
                                                End If
                                            Case strLine.StartsWith("<p>出演")
                                                '多分出演者
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<p>「アイドルマスターシンデレラガールズ」出演")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<span class=""idol_cute")
                                                '多分こっちも出演者
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<span class=""idol_cool")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<span class=""idol_passion")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<li class=""list-inline-item""><span class=""idol_cute")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<li class=""list-inline-item""><span class=""idol_cool")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<li class=""list-inline-item""><span class=""idol_passion")
                                                strSQL &= I_GetPerformer(strLine, reader("ライブid"))
                                            Case strLine.StartsWith("<thead> <tr> <th>No.</th> <th>楽曲</th> <th>演者</th> </tr> </thead>")
                                                Call I_GetSong(sr, reader("ライブid"))
                                        End Select
                                        strLine = sr.ReadLine
                                    Loop
                                End Using
                            End Using
                        End Using
                    Loop
                    reader.Close()


                    For ii = 0 To LC_Song.Count - 1
                        Console.WriteLine(LC_Song(ii).Name)
                        cmd.CommandText = "insert into 楽曲テーブル" &
                                          "(楽曲id, 楽曲名) values (" &
                                          LC_Song(ii).SongID.ToString & "," &
                                          "'" & LC_Song(ii).Name.Replace("'", "''") & "')"
                        cmd.ExecuteNonQuery()
                    Next

                    For ii = 0 To LC_Sing.Count - 1
                        Console.WriteLine(LC_Sing(ii).LiveID & ":" & LC_Sing(ii).No)
                        cmd.CommandText = "insert into 歌唱テーブル" &
                                          "(ライブid,曲順,楽曲id) values (" &
                                          LC_Sing(ii).LiveID.ToString & "," &
                                          LC_Sing(ii).No.ToString & "," &
                                          LC_Sing(ii).SongID & ")"
                        cmd.ExecuteNonQuery()
                    Next

                    Using sw As New StreamWriter("V:\PERFORMER.CSV", False, System.Text.Encoding.UTF8)
                        For ii = 0 To LC_Performer.Count - 1
                            sw.WriteLine(LC_Performer(ii).guid.ToString & "," &
                                         LC_Performer(ii).PerformerName)
                        Next
                        sw.Flush()
                        sw.Close()
                    End Using

                    If strSQL <> "" Then
                        cmd.CommandText = strSQL
                        cmd.ExecuteNonQuery()
                        Console.WriteLine(strSQL)
                    End If
                End Using
            End Using

        Catch ex As Exception
            bRet = False
            MessageBox.Show(ex.Message, "C_SQLiteExecuteScalar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRet
    End Function

    ''' <summary>
    ''' 出演者名取得
    ''' </summary>
    ''' <param name="strLine"></param>
    ''' <returns></returns>
    Private Function I_GetPerformer(ByVal strLine As String, ByVal iLiveID As Integer) As String
        Dim strSQL As String = ""

        Dim strTmp As String() = strLine.Split(",")
        For ii = 0 To strTmp.Count - 1
            '氏名切り出し
            strTmp(ii) = strTmp(ii).Replace("</span>", "").Replace("</p>", "").Replace("</li>", "")
            Dim iLoc As Integer = strTmp(ii).LastIndexOf(">")
            If iLoc >= 0 Then
                Dim strName As String = strTmp(ii).Substring(iLoc + 1)
                If strName.StartsWith("ルゥ") Then
                    strName = "ルゥ・ティン"
                End If
                If strName = "種崎敦美" Then
                    strName = "種﨑敦美"
                End If

                If strName.StartsWith("出演") Then
                    Return vbNullString
                End If

                'SQL追加
                strSQL &= "insert into 出演者テーブル" &
                      " (声優id, ライブid)" &
                      " values" &
                      "(" &
                       "(" &
                        "select 声優id from 声優テーブル" &
                        " where 声優名 = '" & strName & "'" &
                       "), " & iLiveID.ToString & ");"

            End If
        Next

        Return strSQL
    End Function

    ''' <summary>
    ''' 楽曲取得
    ''' </summary>
    ''' <param name="sr"></param>
    Private Sub I_GetSong(ByRef sr As StreamReader, ByVal iLiveID As Integer)
        Dim bEnd As Boolean = False

        Do
            Try
                Dim strLine As String = sr.ReadLine
                If strLine <> Nothing Then
                    If strLine.StartsWith("<tr> <td>") Or strLine.StartsWith("<tr class=""extra"">") Then
                        'たぶん歌唱データ行
                        strLine = strLine.Replace("<tr>", "").Replace("<tr class=""extra"">", "").Replace("<td>", "").Replace("</tr>", "").Replace("</td>", ",")
                        Dim strTmp As String() = strLine.Split(",")
                        '
                        If IsNumeric(strTmp(0)) Then
                            Dim song As New clsSong
                            Dim sing As New clsSing
                            Dim iSongID As Integer

                            strTmp(1) = strTmp(1).Replace("&#39;", "'")     'アポストロフィー
                            strTmp(1) = strTmp(1).Replace("&#9825;", "♥")   '白ハート
                            strTmp(1) = strTmp(1).Replace("&#216;", "Ø")    'Over!
                            strTmp(1) = strTmp(1).Replace("&hearts;", "♥")  '黒ハート
                            strTmp(1) = strTmp(1).Replace("&amp;", "&")
                            strTmp(1) = strTmp(1).Replace("〜", "～")
                            strTmp(1) = strTmp(1).Replace(" <small class=""notes"">(新曲)</small>", "")
                            strTmp(1) = strTmp(1).Replace(" Secret Day Break", " Secret Daybreak")
                            strTmp(1) = strTmp(1).Replace(" ドレミファクトリー♪", "ドレミファクトリー！")
                            strTmp(1) = strTmp(1).Replace("Halloween?Code", "Halloween♥Code")
                            strTmp(1) = strTmp(1).Replace(" <small class=""additional"">", "")
                            strTmp(1) = strTmp(1).Replace("</small>", "")

                            If strTmp(1).IndexOf(" <a href=") >= 0 Then
                                '楽曲データあり
                                Dim iLoc As Integer = strTmp(1).IndexOf(".html")
                                If iLoc >= 0 Then
                                    Dim strID As String = strTmp(1).Substring(strTmp(1).IndexOf(" <a href="))
                                    strID = strID.Replace(" <a href=""/song/detail/", "").Replace(" <a href=""../detail/", "")
                                    Dim iLoc2 As Integer = strID.IndexOf(".")
                                    iSongID = Val(strID.Substring(0, iLoc2))
                                    Dim results = LC_Song.Where(Function(s) s.SongID = iSongID)
                                    If results.Count = 0 Then
                                        'まだ未登録
                                        song.SongID = iSongID
                                        song.Name = strTmp(1).Substring(iLoc + 7, strTmp(1).Length - iLoc - 11).Trim
                                        LC_Song.Add(song)
                                    End If
                                Else
                                    Stop
                                End If
                            Else
                                '楽曲データなし
                                Dim strName As String = strTmp(1).Trim

                                strName = strName.Replace("志希とちとせの饗宴", "")
                                strName = strName.Replace("周子・夕美による", "")
                                strName = strName.Replace("凸と凹？が駆け抜ける", "")
                                strName = strName.Replace("なんぼでも笑える", "")
                                strName = strName.Replace("絆の", "")
                                strName = strName.Replace("夜20時すぎの", "")
                                strName = strName.Replace("友情で繋ぐ", "")
                                strName = strName.Replace("3 LAND MEDLEY", "")
                                strName = strName.Replace("(Instrumental)", "")
                                strName = strName.Trim

                                Dim results = LC_Song.Where(Function(s) s.Name = strName)
                                If results.Count = 0 Then
                                    'まだ未登録
                                    song.Name = strName
                                    song.SongID = LC_Song.Count + 10000
                                    LC_Song.Add(song)
                                    iSongID = song.SongID
                                Else
                                    'あった
                                    iSongID = results(0).SongID
                                End If
                            End If

                            '歌唱データ
                            sing.LiveID = iLiveID
                            sing.No = Val(strTmp(0))
                            sing.SongID = iSongID
                            sing.guid = Guid.NewGuid()
                            LC_Sing.Add(sing)

                            '歌唱者データ
                            Dim strMemo As String() = {"(一部)", "(ウサギ)", "(冒頭のみ)", "(王子役)", "(王子)", "(間奏でのセリフのみ)"}
                            For ii = 2 To strTmp.Count - 1
                                If strTmp(ii).Trim <> "" Then
                                    If strTmp(ii).IndexOf("3Dモデル") >= 0 Then
                                        Exit For
                                    End If

                                    Dim strName As String = strTmp(ii).Replace("</span>)", "").Replace("</span>", "").Replace("を含む)", "")
                                    Dim performer As New clsPerformer

                                    performer.Flag = 0
                                    For Each m In strMemo
                                        If strTmp(ii).IndexOf(m) >= 0 Then
                                            strName = strName.Replace(m, "")
                                            performer.Memo = m
                                            performer.Flag = 1
                                        End If
                                    Next

                                    If strTmp(ii).IndexOf("(バックダンサー:大橋/福原/原)") >= 0 Then

                                    End If
                                    'バックダンサー
                                    'セリフ参加

                                    strName = strName.Trim

                                    Dim iLoc As Integer = strName.LastIndexOf(">")
                                    strName = strName.Substring(iLoc + 1)
                                    performer.PerformerName = strName
                                    performer.guid = sing.guid
                                    LC_Performer.Add(performer)

                                    Console.WriteLine(iLiveID.ToString & "," & strName & "," & strTmp(ii))
                                End If
                            Next
                        End If
                    ElseIf strLine.StartsWith("</tbody>") Then
                        bEnd = True
                    End If
                End If
            Catch ex As Exception
                Stop
            End Try
        Loop While bEnd = False
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
