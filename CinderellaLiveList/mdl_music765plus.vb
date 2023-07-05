Imports System.IO
Imports System.Net

Module mdl_music765plus
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
    Public Sub C_SQLiteInitTable_music765plus()
        Using cn As New SQLite.SQLiteConnection(DB_CS_SQLite)
            'ｵﾌﾟｰﾝ
            cn.Open()

            Dim cmd As New SQLite.SQLiteCommand()
            cmd.Connection = cn

            Dim strSQL As String = "insert into ライブテーブル" &
                " (ライブ日付,ライブデータ,ライブ名)" &
                " values" &
                " ('マチ★アソビ シンデレラガールズ記念トークショー','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.8')," &
                " ('デレラジ公開録音 in ナンジャタウン','https://music765plus.com/%E3%83%A9%E3%82%B8%E3%82%AA_%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8E%E3%83%87%E3%83%AC%E3%83%A9%E3%82%B8%E3%80%8F%E3%81%AE%E5%85%AC%E9%96%8B%E9%8C%B2%E9%9F%B3#2012-10-14')," &
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
    End Sub
End Module
