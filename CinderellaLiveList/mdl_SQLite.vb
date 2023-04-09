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
                "[ライブ日付] TEXT);" &
             "CREATE TABLE [楽曲テーブル] (" &
                "[楽曲id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[ライブid] INTEGER REFERENCES [ライブテーブル]([ライブid]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[曲順] INTEGER," &
                "[楽曲名] TEXT);" &
             "CREATE TABLE [声優テーブル] (" &
                "[声優id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[声優名] TEXT," &
                "[声優カナ名] TEXT," &
                "[声優役名] TEXT);" &
             "CREATE TABLE [出演者テーブル] (" &
                "[出演者id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[声優id] INTEGER REFERENCES [声優テーブル]([声優id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[ライブid] INTEGER REFERENCES [ライブテーブル]([ライブid]) ON DELETE CASCADE ON UPDATE CASCADE);" &
             "CREATE TABLE [歌唱テーブル] (" &
                "[歌唱id] INTEGER PRIMARY KEY AUTOINCREMENT," &
                "[声優id] INTEGER REFERENCES [声優テーブル]([声優id]) ON DELETE CASCADE ON UPDATE CASCADE," &
                "[楽曲id] INTEGER REFERENCES [楽曲テーブル]([楽曲id]) ON DELETE CASCADE ON UPDATE CASCADE);"
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()

            strSQL = "insert into ライブテーブル" &
                " (ライブ名,ライブ日付)" &
                " values" &
                " ('WONDERFUL M@GIC!! Day1','2014/04/05')," &
                " ('WONDERFUL M@GIC!! Day2','2014/04/06')," &
                " ('PARTY M@GIC!!','2014/11/30')," &
                " ('SUMMER FESTIV@L 2015 東京','2015/08/02')," &
                " ('SUMMER FESTIV@L 2015 大阪','2015/08/23')," &
                " ('シンデレラの舞踏会 -Power of Smile- Day1','2015/11/28')," &
                " ('シンデレラの舞踏会 -Power of Smile- Day2','2015/11/29')," &
                " ('TriCastle Story 神戸 Day1','2016/09/03')," &
                " ('TriCastle Story 神戸 Day2','2016/09/04')," &
                " ('TriCastle Story SSA Day1','2016/10/15')," &
                " ('TriCastle Story SSA Day2','2016/10/16')," &
                " ('Serendipity Parade!!! 宮城 Day1','2017/05/13')," &
                " ('Serendipity Parade!!! 宮城 Day2','2017/05/14')," &
                " ('Serendipity Parade!!! 石川 Day1','2017/05/27')," &
                " ('Serendipity Parade!!! 石川 Day2','2017/05/28')," &
                " ('Serendipity Parade!!! 大阪 Day1','2017/06/09')," &
                " ('Serendipity Parade!!! 大阪 Day2','2017/06/10')," &
                " ('Serendipity Parade!!! 静岡 Day1','2017/06/24')," &
                " ('Serendipity Parade!!! 静岡 Day2','2017/06/25')," &
                " ('Serendipity Parade!!! 幕張 Day1','2017/07/08')," &
                " ('Serendipity Parade!!! 幕張 Day2','2017/07/09')," &
                " ('Serendipity Parade!!! 福岡 Day1','2017/07/29')," &
                " ('Serendipity Parade!!! 福岡 Day2','2017/07/30')," &
                " ('Serendipity Parade!!! SSA Day1','2017/08/12')," &
                " ('Serendipity Parade!!! SSA Day2','2017/08/13')," &
                " ('すぷりんぐふぇすてぃばる2018 Day1','2018/03/03')," &
                " ('すぷりんぐふぇすてぃばる2018 Day2','2018/03/04')," &
                " ('Initial Mess@ge Day1','2018/04/07')," &
                " ('Initial Mess@ge Day2','2018/04/08')," &
                " ('SS3A Live Sound Booth♪ Day1','2018/09/08')," &
                " ('SS3A Live Sound Booth♪ Day2','2018/09/09')," &
                " ('MERRY-GO-ROUNDOME!!! メットライフドーム Day1','2018/11/10')," &
                " ('MERRY-GO-ROUNDOME!!! メットライフドーム Day2','2018/11/11')," &
                " ('MERRY-GO-ROUNDOME!!! ナゴヤドーム Day1','2018/12/01')," &
                " ('MERRY-GO-ROUNDOME!!! ナゴヤドーム Day2','2018/12/02')," &
                " ('プロデューサーさん感謝祭 in 新木場スタジオコースト','2019/06/16')," &
                " ('Special 3chord♪ Comical Pops! Day1','2019/09/03')," &
                " ('Special 3chord♪ Comical Pops! Day2','2019/09/04')," &
                " ('Special 3chord♪ Funky Dancing! Day1','2019/11/09')," &
                " ('Special 3chord♪ Funky Dancing! Day2','2019/11/10')," &
                " ('Special 3chord♪ Glowing Rock! Day1','2020/02/15')," &
                " ('Special 3chord♪ Glowing Rock! Day2','2020/02/16')," &
                " ('Live Broadcast 24magic ～シンデレラたちの24時間生放送！～','2020/09/05')," &
                " ('Broadcast & LIVE Happy New Yell !!! Day1','2021/01/09')," &
                " ('Broadcast & LIVE Happy New Yell !!! Day2','2021/01/10')," &
                " ('M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land Day1','2021/10/02')," &
                " ('M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land Day2','2021/10/03')" &
                " ('M@GICAL WONDERLAND TOUR!!! Celebration Land Day1','2021/11/27')" &
                " ('M@GICAL WONDERLAND TOUR!!! Celebration Land Day2','2021/11/28')" &
                " ('M@GICAL WONDERLAND TOUR!!! CosmoStar Land Day1','2021/12/25')," &
                " ('M@GICAL WONDERLAND TOUR!!! CosmoStar Land Day2','2021/12/26')" &
                " ('M@GICAL WONDERLAND TOUR!!! Tropical Land Day1','2022/01/29')" &
                " ('M@GICAL WONDERLAND TOUR!!! Tropical Land Day2','2022/01/30')" &
                " ('M@GICAL WONDERLAND!!! Day1','2022/04/02')" &
                " ('M@GICAL WONDERLAND!!! Day2','2022/04/03')" &
                " ('LIKE4LIVE #cg_ootd Day1','2022/09/03')" &
                " ('LIKE4LIVE #cg_ootd Day2','2022/09/04')" &
                " ('Twinkle LIVE Constellation Gradation Day1','2022/11/26')" &
                " ('Twinkle LIVE Constellation Gradation Day2','2022/11/27')"
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()

            strSQL = "insert into 声優テーブル" &
                " (声優名,声優カナ名,声優役名)" &
                " values" &
                " ('会沢紗弥','あいざわさや','関裕美')," &
                " ('藍原ことみ','あいはらことみ','一ノ瀬志希')," &
                " ('青木志貴','あおきしき','二宮飛鳥')," &
                " ('青木瑠璃子','あおきるりこ','多田李衣菜')," &
                " ('赤﨑千夏','あかさきちなつ','日野茜')," &
                " ('朝井彩加','あさいあやか','早坂美玲')," &
                " ('天野聡美','あまのさとみ','白菊ほたる')," &
                " ('飯田友子','いいだゆうこ','速水奏')," &
                " ('五十嵐裕美','いがらしひろみ','双葉杏')," &
                " ('生田輝','いくたてる','ナターリア')," &
                " ('井上ほの花','いのうえほのか','浅利七海')," &
                " ('今井麻夏','いまいあさか','佐々木千枝')," &
                " ('上坂すみれ','うえさかすみれ','アナスタシア')," &
                " ('内田真礼','うちだまあや','神崎蘭子')," &
                " ('梅澤めぐ','うめざわめぐ','辻野あかり')," &
                " ('桜咲千依','おうさきちよ','白坂小梅')," &
                " ('大空直美','おおぞらなおみ','緒方智絵里')," &
                " ('大坪由佳','おおつぼゆか','三村かな子')," &
                " ('大橋彩香','おおはしあやか','島村卯月')," &
                " ('金子真由美','かねこまゆみ','藤本里奈')," &
                " ('金子有希','かねこゆうき','高森藍子')," &
                " ('神谷早矢佳','かみたにさやか','南条光')," &
                " ('嘉山未紗','かやまみさ','脇山珠美')," &
                " ('河瀬茉希','かわせまき','桐生つかさ')," &
                " ('木村珠莉','きむらじゅり','相葉夕美')," &
                " ('久野美咲','くのみさき','市原仁奈')," &
                " ('黒沢ともよ','くろさわともよ','赤城みりあ')," &
                " ('小市眞琴','こいちまこと','結城晴')," &
                " ('佐倉薫','さくらかおる','黒埼ちとせ')," &
                " ('佐藤亜美菜','さとうあみな','橘ありす')," &
                " ('下地紫野','しもじしの','中野有香')," &
                " ('洲崎綾','すざきあや','新田美波')," &
                " ('鈴木絵理','すずきえり','堀裕子')," &
                " ('鈴木みのり','すずきみのり','藤原肇')," &
                " ('関口理咲','せきぐちりさ','白雪千夜')," &
                " ('高田憂希','たかだゆうき','依田芳乃')," &
                " ('髙野麻美','たかのあさみ','宮本フレデリカ')," &
                " ('高橋花林','たかはしかりん','森久保乃々')," &
                " ('高森奈津美','たかもりなつみ','前川みく')," &
                " ('竹達彩奈','たけたつあやな','輿水幸子')," &
                " ('武田羅梨沙多胡','たけだらりさたご','喜多見柚')," &
                " ('田澤茉純','たざわますみ','浜口あやめ')," &
                " ('立花日菜','たちばなひな','久川凪')," &
                " ('立花理香','たちばなりか','小早川紗枝')," &
                " ('田辺留依','たなべるい','荒木比奈')," &
                " ('種﨑敦美','たねざきあつみ','五十嵐響子')," &
                " ('集貝はな','ためがいはな','的場梨沙')," &
                " ('伊達朱里紗','だてありさ','難波笑美')," &
                " ('千菅春香','ちすがはるか','松永涼')," &
                " ('津田美波','つだみなみ','小日向美穂')," &
                " ('照井春佳','てるいはるか','櫻井桃華')," &
                " ('東山奈央','とうやまなお','川島瑞樹')," &
                " ('都丸ちよ','とまるちよ','椎名法子')," &
                " ('富田美憂','とみたみゆ','砂塚あきら')," &
                " ('中澤ミナ','なかざわみな','佐城雪美')," &
                " ('中島由貴','なかしまゆき','乙倉悠貴')," &
                " ('長江里加','ながえりか','久川颯')," &
                " ('長島光那','ながしまみな','上条春菜')," &
                " ('長野佑紀','ながのゆき','小関麗奈')," &
                " ('新田ひより','にったひより','道明寺歌鈴')," &
                " ('二ノ宮ゆい','にのみやゆい','八神マキノ')," &
                " ('のぐちゆり','のぐちゆり','及川雫')," &
                " ('花井美春','はないみはる','村上巴')," &
                " ('花谷麻妃','はなたにまき','遊佐こずえ')," &
                " ('花守ゆみり','はなもりゆみり','佐藤心')," &
                " ('早見沙織','はやみさおり','高垣楓')," &
                " ('原紗友里','はらさゆり','本田未央')," &
                " ('原涼子','はらすずこ','望月聖')" &
                " ('原田彩楓','はらださやか','三船美優')," &
                " ('原田ひとみ','はらだひとみ','十時愛梨')," &
                " ('原優子','はらゆうこ','向井拓海')," &
                " ('春瀬なつみ','はるせなつみ','龍崎薫')," &
                " ('春野ななみ','はるのななみ','上田鈴帆')," &
                " ('深川芹亜','ふかがわせりあ','喜多日菜子')," &
                " ('福原綾香','ふくはらあやか','渋谷凛')," &
                " ('藤田茜','ふじたあかね','水本ゆかり')," &
                " ('藤本彩花','ふじもとあやか','棟方愛海')," &
                " ('渕上舞','ふちがみまい','北条加蓮')," &
                " ('星希成奏','ほしきせえな','夢見りあむ')," &
                " ('M・A・O','まお','鷺沢文香')," &
                " ('牧野由依','まきのゆい','佐久間まゆ')," &
                " ('松井恵理子','まついえりこ','神谷奈緒')," &
                " ('松嵜麗','まつざきれい','諸星きらり')," &
                " ('松田颯水','まつださつみ','星輝子')," &
                " ('三宅麻理恵','みやけまりえ','安部菜々')," &
                " ('村中知','むらなかとも','大和亜季')," &
                " ('森下来奈','もりしたらな','鷹富士茄子')," &
                " ('杜野まこ','もりのまこ','姫川友紀')," &
                " ('安野希世乃','やすのきよの','木村夏樹')," &
                " ('山下七海','やましたななみ','大槻唯')," &
                " ('山本希望','やまもとのぞみ','城ヶ崎莉嘉')," &
                " ('佳村はるか','よしむらはるか','城ヶ崎美嘉')," &
                " ('ルゥ・ティン','るぅてぃん','塩見周子')," &
                " ('和氣あず未','わきあずみ','片桐早苗')"
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
