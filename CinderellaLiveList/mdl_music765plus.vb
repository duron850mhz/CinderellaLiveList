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

            Dim strSQL As String = ""

            cmd.CommandText = "delete from ライブテーブル"
            cmd.ExecuteNonQuery()

            strSQL = "insert into ライブテーブル" &
                " (ライブ日付,ライブデータ,ライブ名)" &
                " values" &
                " ('2012-05-04','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.8','マチ★アソビ シンデレラガールズ記念トークショー')," &
                " ('2012-10-14','https://music765plus.com/%E3%83%A9%E3%82%B8%E3%82%AA_%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8E%E3%83%87%E3%83%AC%E3%83%A9%E3%82%B8%E3%80%8F%E3%81%AE%E5%85%AC%E9%96%8B%E9%8C%B2%E9%9F%B3#2012-10-14','デレラジ公開録音 in ナンジャタウン')," &
                " ('2012-11-25','https://music765plus.com/%E3%80%8C%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8D%E3%81%8A%E6%B8%A1%E3%81%97%E4%BC%9A%26%E3%83%9F%E3%83%8B%E3%83%A9%E3%82%A4%E3%83%96','シンデレラガールズお渡し会＆ミニライブ')," &
                " ('2012-12-28','https://music765plus.com/%E3%83%AD%E3%83%BC%E3%82%BD%E3%83%B3%E3%82%B3%E3%83%A9%E3%83%9C%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%9A%E3%83%BC%E3%83%B3%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2012-12-28','シャイニーフェスタ＋シンデレラガールズSPパーティー')," &
                " ('2013-02-10','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2013-02-10','デレラジスペシャルステージ(ワンフェス冬)')," &
                " ('2013-04-10','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2013-04-10','お願い！シンデレラ発売記念')," &
                " ('2013-04-13','https://music765plus.com/%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%BF%E3%82%B8%E3%82%AA%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2013-04-13','春のP祭り～アイマスタジオの部～')," &
                " ('2013-04-13','https://music765plus.com/%E3%83%A9%E3%82%B8%E3%82%AA_%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8E%E3%83%87%E3%83%AC%E3%83%A9%E3%82%B8%E3%80%8F%E3%81%AE%E5%85%AC%E9%96%8B%E9%8C%B2%E9%9F%B3#2013-04-13','春のP祭り～デレラジの部～')," &
                " ('2013-05-04','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.10','マチ★アソビ デレラジ徳島出張版')," &
                " ('2013-06-22','https://music765plus.com/@JAM_2013_%E3%82%A2%E3%83%8B%E3%82%BD%E3%83%B3Day_supported_by_%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B!TV','＠JAM 2013 アニソンDay')," &
                " ('2013-07-07','https://music765plus.com/THE_IDOLM@STER_8th_ANNIVERSARY_HOP!STEP!!FESTIV@L!!!#2013-07-07','8th HOP!STEP!!FESTIV@L!!! @NAGOYA')," &
                " ('2013-07-20','https://music765plus.com/THE_IDOLM@STER_8th_ANNIVERSARY_HOP!STEP!!FESTIV@L!!!#2013-07-20','8th HOP!STEP!!FESTIV@L!!! @OSAKA0720')," &
                " ('2013-07-21','https://music765plus.com/THE_IDOLM@STER_8th_ANNIVERSARY_HOP!STEP!!FESTIV@L!!!#2013-07-21','8th HOP!STEP!!FESTIV@L!!! @OSAKA0721')," &
                " ('2013-07-28','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2013-07-28','デレラジスペシャルステージ(ワンフェス夏)')," &
                " ('2013-08-23','https://music765plus.com/Animelo_Summer_Live%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.82.A2.E3.83.8B.E3.82.B5.E3.83.9E2013','Animelo Summer Live 2013')," &
                " ('2013-09-21','https://music765plus.com/THE_IDOLM@STER_8th_ANNIVERSARY_HOP!STEP!!FESTIV@L!!!#2013-09-21.2622','8th HOP!STEP!!FESTIV＠L!!! @MAKUHARI')," &
                " ('2013-09-22','https://music765plus.com/THE_IDOLM@STER_8th_ANNIVERSARY_HOP!STEP!!FESTIV@L!!!#2013-09-21.2622','8th HOP!STEP!!FESTIV＠L!!! @MAKUHARI')," &
                " ('2013-10-12','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.11','マチ★アソビVol.11ステージ')," &
                " ('2013-11-28','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Anniversary_Party#2013-11-28','シンデレラガールズ2周年記念')," &
                " ('2014-01-25','https://music765plus.com/%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B%EF%BC%81LIVE%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.83.AA.E3.82.B9.E3.82.A2.E3.83.8B.EF.BC.81LIVE-4','リスアニ！LIVE4')," &
                " ('2014-02-10','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2014-02-10','デレラジスペシャルステージ(ワンフェス冬)')," &
                " ('2014-02-22','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!2014#2014-02-22','M@STERS OF IDOL WORLD!!2014')," &
                " ('2014-02-23','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!2014#2014-02-23','M@STERS OF IDOL WORLD!!2014')," &
                " ('2014-04-05','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_1stLIVE_WONDERFUL_M@GIC!!#2014-04-05','CINDERELLA GIRLS 1stLIVE WONDERFUL M@GIC!!')," &
                " ('2014-04-06','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_1stLIVE_WONDERFUL_M@GIC!!#2014-04-06','CINDERELLA GIRLS 1stLIVE WONDERFUL M@GIC!!')," &
                " ('2014-04-27','https://music765plus.com/%E3%83%8B%E3%82%B3%E3%83%8B%E3%82%B3%E8%B6%85%E4%BC%9A%E8%AD%B0%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2014-04-27','超音楽祭2014(ニコニコ超会議3)')," &
                " ('2014-05-04','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.12','シンデレラガールズトーク(マチ★アソビ)')," &
                " ('2014-05-31','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2014-05-31','CD出荷100万枚＆CM第6弾発売記念')," &
                " ('2014-06-29','https://music765plus.com/%E3%83%A9%E3%82%B8%E3%82%AA_%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8E%E3%83%87%E3%83%AC%E3%83%A9%E3%82%B8%E3%80%8F%E3%81%AE%E5%85%AC%E9%96%8B%E9%8C%B2%E9%9F%B3#2014-06-29','デレラジ公開録音 サマデレ2014')," &
                " ('2014-07-19','https://music765plus.com/%E3%80%8C%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E2%80%9CPassion%E2%80%9D%E3%82%BB%E3%83%AC%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E3%80%8D%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8','Passionセレクション(ニコニコ23時間テレビ)')," &
                " ('2014-07-27','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2014-07-27','キュートセレクション(ワンフェス夏)')," &
                " ('2014-07-30','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2014-07-30','We''re the friends!リリース記念')," &
                " ('2014-08-30','https://music765plus.com/Animelo_Summer_Live%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.82.A2.E3.83.8B.E3.82.B5.E3.83.9E2014','Animelo Summer Live 2014')," &
                " ('2014-09-06','https://music765plus.com/%E3%83%AD%E3%83%BC%E3%82%BD%E3%83%B3%E3%82%B3%E3%83%A9%E3%83%9C%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%9A%E3%83%BC%E3%83%B3%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2014-09-06','ローソン ワンフォーオールSP EVENT')," &
                " ('2014-09-21','https://music765plus.com/%E3%83%90%E3%83%B3%E3%83%80%E3%82%A4%E3%83%8A%E3%83%A0%E3%82%B3_%E3%82%A2%E3%83%8B%E3%83%A1%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%972014','バンダイナムコアニメキャンプ')," &
                " ('2014-10-11','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.13','マチ★アソビVol.13ステージ')," &
                " ('2014-11-30','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_2ndLIVE_PARTY_M@GIC!!','CINDERELLA GIRLS 2ndLIVE PARTY M@GIC!!')," &
                " ('2014-12-06','https://music765plus.com/Anime_Festival_Asia_2014%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88','Anime Festival Asia 2014ステージ')," &
                " ('2015-01-24','https://music765plus.com/%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B%EF%BC%81LIVE%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#2015-01-24','リスアニ！LIVE5')," &
                " ('2015-01-31','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2015-01-31','CINDERELLA REAL PARTY 01 あせかき')," &
                " ('2015-02-07','https://music765plus.com/C3%E6%97%A5%E6%9C%AC%E5%8B%95%E7%8E%A9%E5%8D%9A%E8%A6%BD%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#C3.E6.97.A5.E6.9C.AC.E5.8B.95.E7.8E.A9.E5.8D.9A.E8.A6.BD2015','C3日本動玩博覽2015')," &
                " ('2015-02-08','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2015-02-08','346プロ ワンフェスステージ')," &
                " ('2015-02-22','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-02-22','Star!!発売記念イベント')," &
                " ('2015-03-21','https://music765plus.com/AnimeJapan%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#AnimeJapan2015','AnimeJapan2015 シンデレラガールズステージ')," &
                " ('2015-03-29','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-03-29','ANIMATION PROJECT 02＆03発売記念')," &
                " ('2015-04-11','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-04-11','ANIMATION PROJECT 04＆05発売記念')," &
                " ('2015-04-25','https://music765plus.com/%E3%83%8B%E3%82%B3%E3%83%8B%E3%82%B3%E8%B6%85%E4%BC%9A%E8%AD%B0%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-04-25','超音楽祭2015(ニコニコ超会議2015)')," &
                " ('2015-04-26','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-04-26','ANIMATION PROJECT 06＆07発売記念イベント')," &
                " ('2015-05-05','https://music765plus.com/%E3%83%9E%E3%83%81%E2%98%85%E3%82%A2%E3%82%BD%E3%83%93%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#.E3.83.9E.E3.83.81.E2.98.85.E3.82.A2.E3.82.BD.E3.83.93vol.14','Star!! キラキラVer企画中です(マチ★アソビ)')," &
                " ('2015-05-17','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-05-17','GOIN''!!!発売記念イベント')," &
                " ('2015-05-31','https://music765plus.com/%E3%83%AD%E3%83%BC%E3%82%BD%E3%83%B3%E3%82%B3%E3%83%A9%E3%83%9C%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%9A%E3%83%BC%E3%83%B3%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2015-05-31','シンデレラガールズ×ローソンSP EVENT')," &
                " ('2015-06-13','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2015-06-13','CINDERELLA REAL PARTY 02 いかたこ')," &
                " ('2015-06-28','https://music765plus.com/%E3%83%A9%E3%82%B8%E3%82%AA_%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E3%80%8E%E3%83%87%E3%83%AC%E3%83%A9%E3%82%B8%E3%80%8F%E3%81%AE%E5%85%AC%E9%96%8B%E9%8C%B2%E9%9F%B3#2015-06-28','デレラジＡ公開録音〜デレソニ〜')," &
                " ('2015-07-18','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!2015#2015-07-18','M@STERS OF IDOL WORLD!!2015')," &
                " ('2015-07-19','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!2015#2015-07-19','M@STERS OF IDOL WORLD!!2015')," &
                " ('2015-07-26','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2015-07-26','346プロ ワンフェスサマーステージ')," &
                " ('2015-08-02','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_SUMMER_FESTIV@L_2015#2015-08-02','SUMMER FESTIV@L 2015 in 東京')," &
                " ('2015-08-23','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_SUMMER_FESTIV@L_2015#2015-08-23','SUMMER FESTIV@L 2015 in 大阪')," &
                " ('2015-08-29','https://music765plus.com/Animelo_Summer_Live%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.82.A2.E3.83.8B.E3.82.B5.E3.83.9E2015','Animelo Summer Live 2015')," &
                " ('2015-09-13','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2015-09-13','Shine!!発売記念イベント')," &
                " ('2015-09-19','https://music765plus.com/%E6%9D%B1%E4%BA%AC%E3%82%B2%E3%83%BC%E3%83%A0%E3%82%B7%E3%83%A7%E3%82%A6%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#TGS2015','マストソングス×スターライトステージ(TGS2015)')," &
                " ('2015-10-19','https://music765plus.com/%E6%AD%8C%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%83%86%E3%83%AC%E3%83%93%E5%87%BA%E6%BC%94#MUSIC_JAPAN','NHK『MUSIC JAPAN』')," &
                " ('2015-11-28','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_3rdLIVE_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%81%AE%E8%88%9E%E8%B8%8F%E4%BC%9A_-_Power_of_Smile_-#2015-11-28','CINDERELLA GIRLS 3rdLIVE シンデレラの舞踏会')," &
                " ('2015-11-29','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_3rdLIVE_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%81%AE%E8%88%9E%E8%B8%8F%E4%BC%9A_-_Power_of_Smile_-#2015-11-29','CINDERELLA GIRLS 3rdLIVE シンデレラの舞踏会')," &
                " ('2016-01-23','https://music765plus.com/%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B%EF%BC%81LIVE%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#2016-01-23','リスアニ！LIVE2016')," &
                " ('2016-02-06','https://music765plus.com/Nendoroid_10th_Anniversary_Live','Nendoroid 10th Anniversary Live')," &
                " ('2016-02-20','https://music765plus.com/C3%E6%97%A5%E6%9C%AC%E5%8B%95%E7%8E%A9%E5%8D%9A%E8%A6%BD%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#C3.E6.97.A5.E6.9C.AC.E5.8B.95.E7.8E.A9.E5.8D.9A.E8.A6.BD2016','765AS＆CINDERELLA GIRLS TALK＆LIVE STAGE（C3 Hong Kong）')," &
                " ('2016-02-28','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2016-02-28','CINDERELLA REAL PARTY 03 あすぱら')," &
                " ('2016-04-30','https://music765plus.com/%E3%83%8B%E3%82%B3%E3%83%8B%E3%82%B3%E8%B6%85%E4%BC%9A%E8%AD%B0%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2016-04-29','ニコニコ超会議2016のステージ＆ライブ')," &
                " ('2016-04-30','https://music765plus.com/MONACA%E3%83%95%E3%82%A7%E3%82%B92016','MONACAフェス2016')," &
                " ('2016-07-24','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2016-07-24','ワンフェスサマーステージ')," &
                " ('2016-07-30','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2016-07-30','累計出荷300万枚＆STARLIGHT MASTER発売記念 MEMORIAL PARADE')," &
                " ('2016-08-26','https://music765plus.com/Animelo_Summer_Live%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.82.A2.E3.83.8B.E3.82.B5.E3.83.9E2016','Animelo Summer Live 2016')," &
                " ('2016-09-03','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_4thLIVE_TriCastle_Story#2016-09-03','CINDERELLA GIRLS 4thLIVE TriCastle Story Starlight Castle')," &
                " ('2016-09-04','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_4thLIVE_TriCastle_Story#2016-09-04','CINDERELLA GIRLS 4thLIVE TriCastle Story Starlight Castle')," &
                " ('2016-10-15','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_4thLIVE_TriCastle_Story#2016-10-15','CINDERELLA GIRLS 4thLIVE TriCastle Story Brand new Castle')," &
                " ('2016-10-16','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_4thLIVE_TriCastle_Story#2016-10-16','CINDERELLA GIRLS 4thLIVE TriCastle Story 346 Castle')," &
                " ('2016-11-19','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Anniversary_Party#2016-11-19','5th Anniversary Party ニコ生SP')," &
                " ('2016-12-04','https://music765plus.com/%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B%EF%BC%81LIVE%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#.E3.83.AA.E3.82.B9.E3.82.A2.E3.83.8B.EF.BC.81LIVE_TAIWAN','リスアニ！LIVE TAIWAN')," &
                " ('2017-02-19','https://music765plus.com/%E3%83%AF%E3%83%B3%E3%83%80%E3%83%BC%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB%E5%86%85%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2017-02-19','ワンフェスWinterステージ')," &
                " ('2017-02-19','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2017-02-19','CINDERELLA REAL PARTY 04 わっしょい')," &
                " ('2017-03-19','https://music765plus.com/%E3%83%AD%E3%83%BC%E3%82%BD%E3%83%B3%E3%82%B3%E3%83%A9%E3%83%9C%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%9A%E3%83%BC%E3%83%B3%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2017-03-19','シンデレラガールズ プレミアムイベント')," &
                " ('2017-05-13','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#MIYAGI','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 宮城公演')," &
                " ('2017-05-14','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#MIYAGI','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 宮城公演')," &
                " ('2017-05-27','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#ISHIKAWA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 石川公演')," &
                " ('2017-05-28','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#ISHIKAWA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 石川公演')," &
                " ('2017-06-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#OSAKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 大阪公演')," &
                " ('2017-06-10','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#OSAKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 大阪公演')," &
                " ('2017-06-24','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#SHIZUOKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 静岡公演')," &
                " ('2017-06-25','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#SHIZUOKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 静岡公演')," &
                " ('2017-06-30','https://music765plus.com/Anisong_World_Matsuri_at_Anime_Expo#2017-06-30','ANISONG WORLD MATSURI 2017')," &
                " ('2017-07-08','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#MAKUHARI','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 幕張公演')," &
                " ('2017-07-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#MAKUHARI','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 幕張公演')," &
                " ('2017-07-29','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#FUKUOKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 福岡公演')," &
                " ('2017-07-30','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#FUKUOKA','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! 福岡公演')," &
                " ('2017-08-12','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#D2017-08-12','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! SSA公演')," &
                " ('2017-08-13','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5thLIVE_TOUR_Serendipity_Parade!!!#D2017-08-13','CINDERELLA GIRLS 5thLIVE Serendipity Parade!!! SSA公演')," &
                " ('2017-11-05','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2017-11-05','デレパ参周年記念祝賀会')," &
                " ('2017-11-19','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Anniversary_Party#2017-11-19','6th Anniversary Memorial Party')," &
                " ('2017-12-03','https://music765plus.com/%E3%83%AD%E3%83%BC%E3%82%BD%E3%83%B3%E3%82%B3%E3%83%A9%E3%83%9C%E3%82%AD%E3%83%A3%E3%83%B3%E3%83%9A%E3%83%BC%E3%83%B3%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2017-12-03','ローソンシンデレラガールズPREMIUM EVENT')," &
                " ('2017-12-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_5th_LIVE_TOUR_Serendipity_Parade!!!%E4%B8%8A%E6%B5%B7%E3%83%95%E3%82%A1%E3%83%B3%E3%83%9F%E3%83%BC%E3%83%86%E3%82%A3%E3%83%B3%E3%82%B0','Serendipity Parade!!!上海ファンミーティング')," &
                " ('2018-03-03','https://music765plus.com/%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E5%8A%87%E5%A0%B4_%E3%81%99%E3%81%B7%E3%82%8A%E3%82%93%E3%81%90%E3%81%B5%E3%81%87%E3%81%99%E3%81%A6%E3%81%83%E3%81%B0%E3%82%8B_2018#2018-03-03','シンデレラガールズ劇場 すぷりんぐふぇすてぃばる2018 DAY1')," &
                " ('2018-03-04','https://music765plus.com/%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E5%8A%87%E5%A0%B4_%E3%81%99%E3%81%B7%E3%82%8A%E3%82%93%E3%81%90%E3%81%B5%E3%81%87%E3%81%99%E3%81%A6%E3%81%83%E3%81%B0%E3%82%8B_2018#2018-03-04','シンデレラガールズ劇場 すぷりんぐふぇすてぃばる2018 DAY2')," &
                " ('2018-03-24','https://music765plus.com/AnimeJapan%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#AnimeJapan2018','アニカラ★JAPANステージ(AnimeJapan)')," &
                " ('2018-04-07','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Initial_Mess@ge#DAY1','CINDERELLA GIRLS Initial Mess@ge DAY1')," &
                " ('2018-04-08','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Initial_Mess@ge#DAY2','CINDERELLA GIRLS Initial Mess@ge DAY2')," &
                " ('2018-05-13','https://music765plus.com/%E3%82%A2%E3%83%8B%E3%83%A5%E3%83%BC%E3%82%BF%E3%83%A9%E3%82%A4%E3%83%962018%E3%80%8C%E3%81%82%E3%81%AB%E3%82%85%E3%83%91%EF%BC%81%EF%BC%81%E3%80%8D','アニュータライブ2018「あにゅパ！！」')," &
                " ('2018-07-07','https://music765plus.com/Anisong_World_Matsuri_at_Anime_Expo#2018-07-07','ANISONG WORLD MATSURI 2018')," &
                " ('2018-07-13','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_new_generations%E2%98%86Brilliant_Party%EF%BC%81','CINDERELLA GIRLS new generations☆Brilliant Party！(CG STAR LIVE)')," &
                " ('2018-07-21','https://music765plus.com/BiliBili%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2018-07-21C','BiliBili Macro Link -Star Phase × Anisong World Matsuri 2018')," &
                " ('2018-08-12','https://music765plus.com/MOTTO_ANISONG_FESTIVAL_2018','MOTTO ANISONG FESTIVAL 2018')," &
                " ('2018-08-19','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%EF%BC%88%E3%82%B3%E3%83%9F%E3%83%83%E3%82%AF%E3%82%B9%EF%BC%89%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2018-08-19','U149 3巻特別版発売記念イベント')," &
                " ('2018-09-08','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_SS3A_Live_Sound_Booth%E2%99%AA#DAY1','SS3A Live Sound Booth♪ DAY1')," &
                " ('2018-09-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_SS3A_Live_Sound_Booth%E2%99%AA#DAY2','SS3A Live Sound Booth♪ DAY2')," &
                " ('2018-10-04','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2018-10-04','TVアニメ「シンデレラガールズ劇場」エンディングテーマ発売記念ニコ生 CINGEKI NIGHT★')," &
                " ('2018-10-20','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2018-10-20','CINDERELLA REAL PARTY 05 こうよう')," &
                " ('2018-11-10','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_6thLIVE_MERRY-GO-ROUNDOME!!!#METLIFEDAY1','CINDERELLA GIRLS 6thLIVE MERRY-GO-ROUNDOME!!! メットライフドーム公演 DAY1')," &
                " ('2018-11-11','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_6thLIVE_MERRY-GO-ROUNDOME!!!#METLIFEDAY2','CINDERELLA GIRLS 6thLIVE MERRY-GO-ROUNDOME!!! メットライフドーム公演 DAY2')," &
                " ('2018-12-01','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_6thLIVE_MERRY-GO-ROUNDOME!!!#NAGOYADAY1','CINDERELLA GIRLS 6thLIVE MERRY-GO-ROUNDOME!!! ナゴヤドーム公演 DAY1')," &
                " ('2018-12-02','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_6thLIVE_MERRY-GO-ROUNDOME!!!#NAGOYADAY2','CINDERELLA GIRLS 6thLIVE MERRY-GO-ROUNDOME!!! ナゴヤドーム公演 DAY2')," &
                " ('2018-12-16','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Anniversary_Party#2018-12-16','シンデレラガールズ 7th Anniversary Memorial STAGE!!')," &
                " ('2019-01-06','https://music765plus.com/%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA_%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%A9%E3%82%A4%E3%83%88%E3%82%AF%E3%83%AB%E3%83%BC%E3%82%BA','シンデレラガールズ スターライトクルーズ')," &
                " ('2019-06-16','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2019-06-16IM','教えてIMAJOさん！ 青木瑠璃子のギターレッスン(プロデューサーさん感謝フェスin 秋葉原)')," &
                " ('2019-06-16','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2019-06-16','プロデューサーさん感謝祭 in 新木場スタジオコースト')," &
                " ('2019-07-13','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#2019-07-13','CINDERELLA REAL PARTY 06 ちえのわ')," &
                " ('2019-09-03','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#CDAY1','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Comical Pops! DAY1')," &
                " ('2019-09-04','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#CDAY2','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Comical Pops! DAY2')," &
                " ('2019-10-19','https://music765plus.com/%E3%83%90%E3%83%B3%E3%83%80%E3%82%A4%E3%83%8A%E3%83%A0%E3%82%B3%E3%82%A8%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%86%E3%82%A4%E3%83%B3%E3%83%A1%E3%83%B3%E3%83%88%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB#DAY1','バンダイナムコエンターテインメントフェスティバル DAY1')," &
                " ('2019-10-20','https://music765plus.com/%E3%83%90%E3%83%B3%E3%83%80%E3%82%A4%E3%83%8A%E3%83%A0%E3%82%B3%E3%82%A8%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%86%E3%82%A4%E3%83%B3%E3%83%A1%E3%83%B3%E3%83%88%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB#DAY2','バンダイナムコエンターテインメントフェスティバル DAY2')," &
                " ('2019-11-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#FDAY1','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Funky Dancing! DAY1')," &
                " ('2019-11-10','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#FDAY2','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Funky Dancing! DAY2')," &
                " ('2019-11-17','https://music765plus.com/%E6%AD%8C%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%83%86%E3%83%AC%E3%83%93%E5%87%BA%E6%BC%94#.E3.82.B7.E3.83.96.E3.83.A4.E3.83.8E.E3.82.AA.E3.83.88','NHK総合『シブヤノオト』(生放送)')," &
                " ('2020-02-15','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#RDAY1','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Glowing Rock! DAY1')," &
                " ('2020-02-16','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_7thLIVE_TOUR_Special_3chord%E2%99%AA#RDAY2','CINDERELLA GIRLS 7thLIVE TOUR Special 3chord♪ Glowing Rock! DAY2')," &
                " ('2020-03-03','https://music765plus.com/%E6%AD%8C%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%83%86%E3%83%AC%E3%83%93%E5%87%BA%E6%BC%94#.E3.81.93.E3.81.93.E3.82.8D.E3.81.AE.E6.AD.8C.E4.BA.BA.E3.81.9F.E3.81.A1','NHKプレミアム『こころの歌人たち 作曲家　弦哲也』')," &
                " ('2020-09-05','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Live_Broadcast_24magic_%E3%80%9C%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%81%9F%E3%81%A1%E3%81%AE24%E6%99%82%E9%96%93%E7%94%9F%E6%94%BE%E9%80%81%EF%BC%81%E3%80%9C','CINDERELLA GIRLS Live Broadcast 24magic 〜シンデレラたちの24時間生放送！〜')," &
                " ('2020-10-25','https://music765plus.com/%E6%AD%8C%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%83%86%E3%83%AC%E3%83%93%E5%87%BA%E6%BC%94#SONGS_OF_TOKYO_Fes2020','SONGS OF TOKYO Festival 2020 Part2')," &
                " ('2020-11-23','https://music765plus.com/%E4%BB%8A%E6%97%A5%E3%81%AF%E4%B8%80%E6%97%A5%E2%80%9C%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E2%80%9D%E4%B8%89%E6%98%A7','今日は一日アイマス三昧')," &
                " ('2020-11-28','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Anniversary_Party#9thAnnv','シンデレラガールズ 9th Anniversary Memorial Party')," &
                " ('2021-01-09','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Broadcast_%26_LIVE_Happy_New_Yell_!!!#DAY1','CINDERELLA GIRLS Broadcast &amp; LIVE Happy New Yell&#160;!!! DAY1')," &
                " ('2021-01-10','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Broadcast_%26_LIVE_Happy_New_Yell_!!!#DAY2','CINDERELLA GIRLS Broadcast &amp; LIVE Happy New Yell&#160;!!! DAY2')," &
                " ('2021-02-07','https://music765plus.com/%E3%80%8C%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%83%9D%E3%83%83%E3%83%97%E3%83%AA%E3%83%B3%E3%82%AF%E3%82%B9%E3%80%8D%E3%83%9D%E3%83%97%E3%83%9E%E3%82%B9%E7%94%9F%E9%85%8D%E4%BF%A1_%E7%89%B9%E5%88%A5%E7%89%88%EF%BC%81%E3%80%9C%E3%81%BF%E3%82%93%E3%81%AA%E3%81%A7POPLINKS_TUNE!!!!!_SP%E3%80%9C','ポプマス生配信 特別版！〜みんなでPOPLINKS TUNE!!!!! SP〜')," &
                " ('2021-02-27','https://music765plus.com/%E3%83%AA%E3%82%B9%E3%82%A2%E3%83%8B%EF%BC%81LIVE%EF%BC%88%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%81%AE%E3%81%BF%EF%BC%89#SATURDAY_STAGE_2021','リスアニ！LIVE 2021 [SATURDAY STAGE]')," &
                " ('2021-05-27','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_NEXT_LIVE%E7%99%BA%E8%A1%A8%E4%BC%9A_SPECIAL_STAGE_@_MIRAIKEN_studio','CINDERELLA GIRLS NEXT LIVE発表会 SPECIAL STAGE @ MIRAIKEN studio')," &
                " ('2021-07-11','https://music765plus.com/BiliBili%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%9E%E3%82%B9%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2021-07-11','Bilibili World2021 アイドルマスター特別ステージ')," &
                " ('2021-07-11','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2021-07-11','CINDERELLA REAL PARTY! 07')," &
                " ('2021-10-02','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#MerryMaerchenLand_DAY1','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land DAY1')," &
                " ('2021-10-03','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#MerryMaerchenLand_DAY2','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! MerryMaerchen Land DAY2')," &
                " ('2021-10-11','https://music765plus.com/%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%B9%E7%99%BA%E5%A3%B2%E7%9B%B4%E5%89%8D%EF%BC%81%E3%82%A2%E3%82%A4%E3%83%89%E3%83%AB%E3%83%9E%E3%82%B9%E3%82%BF%E3%83%BC_%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%AA%E3%83%83%E3%83%88%E3%82%B7%E3%83%BC%E3%82%BA%E3%83%B3_%E3%82%B9%E3%83%9A%E3%82%B7%E3%83%A3%E3%83%AB%E3%83%88%E3%83%BC%E3%82%AF%EF%BC%86%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8','スタマス発売直前！アイドルマスター スターリットシーズン　スペシャルトーク＆ステージ')," &
                " ('2021-11-27','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#Celebration_Land_DAY1','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! Celebration Land DAY1')," &
                " ('2021-11-28','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#Celebration_Land_DAY2','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! Celebration Land DAY2')," &
                " ('2021-12-25','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#CosmoStarLand_DAY1','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! CosmoStar Land DAY1')," &
                " ('2021-12-26','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#CosmoStarLand_DAY2','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! CosmoStar Land DAY2')," &
                " ('2022-01-29','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#TropicalLand_DAY1','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! Tropical Land DAY1')," &
                " ('2022-01-30','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#TropicalLand_DAY2','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND TOUR!!! Tropical Land DAY2')," &
                " ('2022-04-02','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#Final_DAY1','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND!!! DAY1')," &
                " ('2022-04-03','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_10th_ANNIVERSARY_M@GICAL_WONDERLAND_TOUR!!!#Final_DAY2','CINDERELLA GIRLS 10th ANNIVERSARY M@GICAL WONDERLAND!!! DAY2')," &
                " ('2022-05-14','https://music765plus.com/%E3%83%90%E3%83%B3%E3%83%80%E3%82%A4%E3%83%8A%E3%83%A0%E3%82%B3%E3%82%A8%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%86%E3%82%A4%E3%83%B3%E3%83%A1%E3%83%B3%E3%83%88%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB_2nd#DAY1','バンダイナムコエンターテインメントフェスティバル 2nd DAY1')," &
                " ('2022-05-15','https://music765plus.com/%E3%83%90%E3%83%B3%E3%83%80%E3%82%A4%E3%83%8A%E3%83%A0%E3%82%B3%E3%82%A8%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%86%E3%82%A4%E3%83%B3%E3%83%A1%E3%83%B3%E3%83%88%E3%83%95%E3%82%A7%E3%82%B9%E3%83%86%E3%82%A3%E3%83%90%E3%83%AB_2nd#DAY2','バンダイナムコエンターテインメントフェスティバル 2nd DAY2')," &
                " ('2022-06-25','https://music765plus.com/CINDERELLA_PARTY!%E3%81%AE%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#D2022-06-25','CINDERELLA REAL PARTY! 08 Panical Emotioful Land')," &
                " ('2022-07-03','https://music765plus.com/xR_ARTISTS_SUPER_FES#xR2022','xR ARTISTS SUPER FES 2022 DAY2')," &
                " ('2022-09-03','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_LIKE4LIVE_%EF%BC%83cg_ootd#DAY1','CINDERELLA GIRLS LIKE4LIVE #cg_ootd DAY1')," &
                " ('2022-09-04','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_LIKE4LIVE_%EF%BC%83cg_ootd#DAY2','CINDERELLA GIRLS LIKE4LIVE #cg_ootd DAY2')," &
                " ('2022-11-12','https://music765plus.com/THE_IDOLM@STER_ORCHESTRA_CONCERT_%E3%80%9CSYMPHONY_OF_FIVE_STARS!!!!!_%E3%80%9C#DAY1','ORCHESTRA CONCERT 〜SYMPHONY OF FIVE STARS!!!!! 〜 DAY1')," &
                " ('2022-11-13','https://music765plus.com/THE_IDOLM@STER_ORCHESTRA_CONCERT_%E3%80%9CSYMPHONY_OF_FIVE_STARS!!!!!_%E3%80%9C#DAY2','ORCHESTRA CONCERT 〜SYMPHONY OF FIVE STARS!!!!! 〜 DAY2')," &
                " ('2022-11-26','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Twinkle_LIVE_Constellation_Gradation#DAY1','CINDERELLA GIRLS Twinkle LIVE Constellation Gradation DAY1')," &
                " ('2022-11-27','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_Twinkle_LIVE_Constellation_Gradation#DAY2','CINDERELLA GIRLS Twinkle LIVE Constellation Gradation DAY2')," &
                " ('2022-12-31','https://music765plus.com/%E3%82%82%E3%82%82%E3%81%84%E3%82%8D%E6%AD%8C%E5%90%88%E6%88%A6#.E7.AC.AC6.E5.9B.9E','第6回 ももいろ歌合戦')," &
                " ('2023-02-11','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!!!!_2023#DAY1','M@STERS OF IDOL WORLD!!!!! 2023 DAY1')," &
                " ('2023-02-12','https://music765plus.com/THE_IDOLM@STER_M@STERS_OF_IDOL_WORLD!!!!!_2023#DAY2','M@STERS OF IDOL WORLD!!!!! 2023 DAY2')," &
                " ('2023-03-04','https://music765plus.com/AMUSE_VOICE_ACTORS_CHANNEL_FES#AF2023_DAY1','AMUSE VOICE ACTORS CHANNEL FES 2023 DAY1')," &
                " ('2023-06-10','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_%E7%87%BF%E5%9F%8E%E5%A4%9C%E7%A5%AD_-%E3%81%8B%E3%81%8C%E3%82%84%E3%81%8D%E3%82%88%E3%81%BE%E3%81%A4%E3%82%8A-#DAY1','CINDERELLA GIRLS 燿城夜祭 DAY1')," &
                " ('2023-06-11','https://music765plus.com/THE_IDOLM@STER_CINDERELLA_GIRLS_%E7%87%BF%E5%9F%8E%E5%A4%9C%E7%A5%AD_-%E3%81%8B%E3%81%8C%E3%82%84%E3%81%8D%E3%82%88%E3%81%BE%E3%81%A4%E3%82%8A-#DAY2','CINDERELLA GIRLS 燿城夜祭 DAY2')," &
                " ('2023-06-25','https://music765plus.com/%E3%82%B7%E3%83%B3%E3%83%87%E3%83%AC%E3%83%A9%E3%82%AC%E3%83%BC%E3%83%AB%E3%82%BA%E7%99%BA%E5%A3%B2%E8%A8%98%E5%BF%B5%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88#U149_ANIMATION_MASTER','U149 ANIMATION MASTER 発売記念イベント')"
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        End Using

        I_GetDataFrommusic765plus()
    End Sub

    ''' <summary>
    ''' アイドルマスター楽曲メモから情報を取得
    ''' </summary>
    ''' <returns></returns>
    Private Function I_GetDataFrommusic765plus() As Boolean
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

                                    'Ancher?
                                    Dim iLoc As Integer = reader("ライブデータ").ToString.IndexOf("#")
                                    If iLoc > 0 Then
                                        Dim strID As String = "id=""" & reader("ライブデータ").ToString.Substring(iLoc + 1)
                                        Do While strLine IsNot Nothing
                                            If strLine.IndexOf(strID) > 0 Then
                                                Exit Do
                                            End If
                                            strLine = sr.ReadLine
                                        Loop
                                    End If

                                    '探すぞう
                                    Do While strLine IsNot Nothing
                                        Select Case True
                                            Case strLine.StartsWith("<td><span class=""Pfont3"">")
                                                '多分楽曲
                                                Call I_GetSong(strLine, reader("ライブid"))
                                        End Select
                                        strLine = sr.ReadLine
                                    Loop
                                End Using
                            End Using
                        End Using
                    Loop
                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            bRet = False
            MessageBox.Show(ex.Message, "C_SQLiteExecuteScalar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return bRet
    End Function

    Private Sub I_GetSong(ByVal strLine As String, ByVal iLiveID As Integer)
        Dim iLoc As Integer = strLine.IndexOf("title=")
        If iLoc > 0 Then
            Dim iEnd As Integer = strLine.IndexOf(">", iLoc)
            Dim strName As String = strLine.Substring(iLoc + 7, iEnd - iLoc - 8)

            Dim iSongID As Integer
            Dim results = LC_Song.Where(Function(s) s.Name = strName)
            If results.Count = 0 Then
                'まだ未登録
                Dim song As New clsSong
                song.SongID = LC_Song.Count + 1
                song.Name = strName
                LC_Song.Add(song)
                iSongID = song.SongID
            Else
                'あった
                iSongID = results(0).SongID
            End If
        End If
    End Sub
End Module
