Public Class frm_Spiel

    Dim Computer As New cls_Computer
    Dim Computer2 As New cls_Computer
    Dim Board As New cls_Board
    Dim BenutzerDaten As New cls_Daten
    Dim ComputerDaten As New cls_Daten
    Dim ComputerDaten2 As New cls_Daten


    Private pSchiffeSetzen As Boolean
    Private pSchiffTyp As Integer
    Private pStartFehler As String

    ' Property
    Private pNeuesSpiel As Boolean

#Region "Property"

    WriteOnly Property NeuesSpiel As Boolean
        Set(ByVal value As Boolean)
            pNeuesSpiel = value
        End Set
    End Property

#End Region

#Region "Private Methoden"

    Private Function SpielstartEingabePruefen() As Boolean

        pStartFehler = String.Empty

        Dim pSpielfeld As Double = SpielfeldBreite * SpielfeldHoehe
        Dim pDiffMinen As Double = pSpielfeld / (SchiffAnzahl + SpielfeldMinen)
        Dim pDiffSchiff As Double = pSpielfeld / (SchiffAnzahl + (SpielfeldMinen / 5))


        If SpielfeldBreite > 30 OrElse SpielfeldHoehe > 25 Then
            pStartFehler = "Spielfeld ist zu groß !!!"

        ElseIf pDiffSchiff < 25 Then
            pStartFehler = "Sie haben zu viele Schiffe auf dem Spielfeld eingegeben !!!"

        ElseIf pDiffMinen < 15 Then
            pStartFehler = "Es sind zu viele Minen für das Spielfeld !!!"
        End If


        If pStartFehler <> String.Empty Then
            SpielstartEingabePruefen = False
        Else
            SpielstartEingabePruefen = True
        End If

    End Function


    ' Setzen des Menu Fenster
    Private Sub SetzFensterMenu()
        Me.Width = 470
        Me.Height = 330
        CenterToScreen()
    End Sub

#End Region

#Region "Public Methoden"

    ' Spiel ergeinisse ausgeben
    Public Sub AusgabeSpiel(ByVal Ausgabe As String)
        AusgabeSpiel(Ausgabe, -1)
    End Sub
    Public Sub AusgabeSpiel(ByVal Ausgabe As String, ByVal SchiffList As List(Of Integer))
        If SchiffList.Count > 0 Then
            For Each Schiff As Integer In SchiffList
                AusgabeSpiel(Ausgabe, Schiff)
            Next
        End If
    End Sub
    Public Sub AusgabeSpiel(ByVal Ausgabe As String, ByVal TrefferEnum As Integer)

        With Me.dgv_SpielAusgabe.Rows

            If TrefferEnum = -1 Then
                .Add(Ausgabe)
            ElseIf TrefferEnum = enumSpielfeld.BOARD_STATE_HIT Then
                .Add(Ausgabe & " Treffer !!")
            ElseIf TrefferEnum = enumSpielfeld.BOARD_STATE_MISS Then
                .Add(Ausgabe & " vorbei")
            ElseIf TrefferEnum = enumSpielfeld.BOARD_STATE_MINE Then
                .Add(Ausgabe & " hat eine Mine getroffen !!!")
            ElseIf TrefferEnum = enumSchiffe.SHIP_Battleship Then
                .Add("Vom " & Ausgabe & " ist ein Battleship Schiff versenkt !")
            ElseIf TrefferEnum = enumSchiffe.SHIP_Carrier Then
                .Add("Vom " & Ausgabe & " ist ein Carrier Schiff versenkt !")
            ElseIf TrefferEnum = enumSchiffe.SHIP_Patrol Then
                .Add("Vom " & Ausgabe & " ist ein Patrol Schiff versenkt !")
            ElseIf TrefferEnum = enumSchiffe.SHIP_Submarine Then
                .Add("Vom " & Ausgabe & " ist ein Submarine Schiff versenkt !")
            End If

            If Not IsNothing(Me.dgv_SpielAusgabe.CurrentCell) Then
                Me.dgv_SpielAusgabe.CurrentCell = Me.dgv_SpielAusgabe.Item(0, Me.dgv_SpielAusgabe.Rows.Count - 1)
            End If

        End With

    End Sub

#End Region

#Region "Formular Events"

    ' Staren von Battleship
    Private Sub frm_Spiel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SpielStartFehler As Boolean = False

        If System.IO.Directory.Exists("Bilder") = False Then
            SpielStartFehler = True
        End If

        If System.IO.Directory.Exists("Bilder\ShipPart") = False Then
            SpielStartFehler = True
        End If


        If SpielStartFehler = False Then

            With Me.cmb_GameLevel.Items
                .Clear()

                .Add("Leicht")
                .Add("Medium")
                .Add("Hardcore")
            End With

            ' DEBUG
            Me.cb_Debug.Checked = True
            Me.cb_Computer.Checked = True

            SpielLaeuft = False
            Me.txt_SpielerName.Text = SpielerName
            Me.txt_SchiffAnzahl.Text = SchiffAnzahl
            Me.txt_SpielfeldHoehe.Text = SpielfeldHoehe
            Me.txt_SpielfeldBreite.Text = SpielfeldBreite
            Me.txt_MinenAnzahl.Text = SpielfeldMinen
            Me.cmb_GameLevel.SelectedIndex = SpielLevel
            SetzFensterMenu()

        Else

            MsgBox("Spiel konnte nicht geladen werden! Weil die Bilder zum Spiel fehlen !!!")

        End If
    End Sub


    ' Battleship wird geschlossen
    Private Sub frm_Spiel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SpielLaeuft = False
        ComputerDelay(250)

        Computer = Nothing
        Computer2 = Nothing
        Board = Nothing
        ComputerDaten = Nothing
        ComputerDaten2 = Nothing
        BenutzerDaten = Nothing
    End Sub


    ' Checkbox KI vs. KI
    Private Sub cb_Computer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Computer.CheckedChanged
        If sender.checked = True Then
            Me.txt_SpielerName.Enabled = False
            Me.cb_SchiffeSetzen.Enabled = False
        Else
            Me.txt_SpielerName.Enabled = True
            Me.cb_SchiffeSetzen.Enabled = True
        End If
    End Sub

#End Region

#Region "Spiel Events für Computer VS Computer"

    Private Sub ComputerSpielStarten()

        Dim pGameIsNotOver As Boolean = True
        Dim listResult As New List(Of Integer)
        Me.tsl_Status.Text = String.Empty

        ' Spielschleife
        While pGameIsNotOver

            ' Soll Spiel weiter laufen ?
            If SpielLaeuft = False Then
                Exit While
            End If


            ' 1.Computer 
            ' Schiessen
            Computer.Schiessen(Me.dgv_BoardRight, ComputerDaten2)
            ShotCounter += 1

            ' Noch Schiffe vorhanden
            If ComputerDaten2.NochSchiffeVorhaden() = False Then
                Exit While
            End If

            ' Ausgabe
            If Computer.Treffer > 0 Then
                AusgabeSpiel(ComputerName1 & "hat " & Computer.Treffer, enumSpielfeld.BOARD_STATE_HIT)
            Else
                AusgabeSpiel(ComputerName1, Computer.TrefferResult)
            End If

            ' Versunkene Schiffe anzeigen
            listResult.Clear()
            listResult = ComputerDaten2.getSchiffVersenkt()

            If Computer.Treffer > 0 Then
                AusgabeSpiel(ComputerName1, listResult)
            End If


            ComputerDelay()


            ' Soll Spiel weiter laufen ?
            If SpielLaeuft = False Then
                Exit While
            End If


            ' 2.Computer
            ' Schiessen
            Computer2.Schiessen(Me.dgv_BoardLeft, ComputerDaten)
            ShotCounter += 1

            ' Noch Schiffe vorhanden
            If ComputerDaten.NochSchiffeVorhaden() = False Then
                Exit While
            End If

            ' Ausgabe
            If Computer.Treffer > 0 Then
                AusgabeSpiel(ComputerName2 & " hat " & Computer.Treffer, enumSpielfeld.BOARD_STATE_HIT)
            Else
                AusgabeSpiel(ComputerName2, Computer.TrefferResult)
            End If

            ' Versunkene Schiffe anzeigen
            listResult.Clear()
            listResult = ComputerDaten.getSchiffVersenkt()

            If Computer.Treffer > 0 Then
                AusgabeSpiel(ComputerName2, listResult)
            End If


            ComputerDelay()

        End While

        ' Nach Zerstörung aller Schiffe
        ' GameOver anzeigen wenn das Spiel 
        ' nicht abgebrochen wurde
        If SpielLaeuft = True Then
            If ComputerDaten.NochSchiffeVorhaden() = False Then
                showGameOver("2.Computer")
            ElseIf ComputerDaten2.NochSchiffeVorhaden() = False Then
                showGameOver("1.Computer")
            End If
        End If

    End Sub


    ' Computer Verzögerung
    Private Sub ComputerDelay()
        ComputerDelay(KIvsKIDelay)
    End Sub
    Private Sub ComputerDelay(ByVal Sekunden As Integer)
        Application.DoEvents()
        System.Threading.Thread.Sleep(Sekunden)
        Application.DoEvents()
    End Sub

#End Region

#Region "Spiel Events für Computer VS Human"

    ' GameOver Formular anzeigen und danach ins Menü
    Private Sub showGameOver(ByVal Gewinner As String)

        SpielEndZeit = Now()

        Dim GameOver As New frm_GameOver
        GameOver.GewinnerName = Gewinner

        SpielVorbei = True
        SpielLaeuft = False

        GameOver.ShowDialog()
        GameOver = Nothing

        If pNeuesSpiel = True Then
            NeuesSpielStarten()

        Else

            Me.PanelGame.Visible = False
            Me.PanelMenu.Visible = True
            SetzFensterMenu()
            Me.tsl_Status.Text = Gewinner & " hat Gewonnnen !"

        End If

    End Sub


    ' Computer Spielfeld
    Private Sub dgv_BoardLeft_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
                Handles dgv_BoardLeft.CellClick

        Me.tsl_Status.Text = String.Empty
        Dim listResult As New List(Of Integer)

        If SpielVorbei = False And SpielArt = enumSpielArt.ComputerVSHuman Then


            Dim Result As Integer
            Me.tsl_Status.Text = String.Empty

            ' Mensch Zug
            Result = Board.FeuerSchiff(Me.dgv_BoardLeft, ComputerDaten, e.RowIndex, e.ColumnIndex)
            ShotCounter += 1
            AusgabeSpiel(SpielerName, Result)

            ' Minen Treffer Ausgabe
            If Result = enumSpielfeld.BOARD_STATE_MINE Then
                ErhalteneSchiffTreffer(SpielerName, ComputerDaten)
            End If

            ' Versenkte Schiffe ausgeben            
            listResult.Clear()
            listResult = ComputerDaten.getSchiffVersenkt()
            AusgabeSpiel(SpielerName, listResult)


            ' Prüfen auf GameOver
            If ComputerDaten.NochSchiffeVorhaden() = False Then
                showGameOver(SpielerName)
            End If


            ' Computer Zug
            If (Result = enumSpielfeld.BOARD_STATE_MISS OrElse Result = enumSpielfeld.BOARD_STATE_MINE) _
                And ComputerDaten.getMinenTreffer() = 0 Then

                Computer.Schiessen(Me.dgv_BoardRight, BenutzerDaten)

                ShotCounter += 1
                If Computer.Treffer > 0 Then
                    AusgabeSpiel(ComputerName & " hat " & Computer.Treffer, enumSpielfeld.BOARD_STATE_HIT)
                Else
                    AusgabeSpiel(ComputerName, Computer.TrefferResult)
                End If

                ' Versenkte Schiffe ausgeben
                listResult.Clear()
                listResult = BenutzerDaten.getSchiffVersenkt()
                If Computer.Treffer > 0 Then
                    AusgabeSpiel(SpielerName, listResult)
                End If


                ' Prüfen auf GameOver
                If BenutzerDaten.NochSchiffeVorhaden() = False Then
                    showGameOver(ComputerName)
                End If

            Else
                ComputerDaten.resetMinenTreffer()

            End If


            If ComputerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_HIT Then
                Me.tsl_Status.Text = "Treffer :D"
            ElseIf ComputerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_MISS Then
                Me.tsl_Status.Text = "Schade vorbei ;("
            ElseIf ComputerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_MINE Then
                Me.tsl_Status.Text = "Das ist eine Mine"
            ElseIf ComputerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_MINE_HIT Then
                Me.tsl_Status.Text = "Sie haben eine Mine getroffen !!!"
            End If

        End If


    End Sub


    ' Benutzer Spielfeld
    Private Sub dgv_BoardRight_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
                Handles dgv_BoardRight.CellClick

        If SpielLaeuft = True And enumSpielArt.ComputerVSHuman Then

            If BenutzerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_HIT Then
                Me.tsl_Status.Text = "Das ist ein Treffer :("
            ElseIf BenutzerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_MINE Then
                Me.tsl_Status.Text = "Das ist eine Mine"
            ElseIf BenutzerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_MISS Then
                Me.tsl_Status.Text = "Nicht getroffen :)"
            ElseIf BenutzerDaten.getBoardValue(e.RowIndex, e.ColumnIndex) = enumSpielfeld.BOARD_STATE_SHIP Then
                Me.tsl_Status.Text = "Das ist das Schiff vom " & SpielerName
            Else
                Me.tsl_Status.Text = "Das ist das eigene Feld"
            End If

        Else

            If Me.dgv_SchiffBilder.SelectedCells.Count > 0 Then

                If Me.cbHorizontal.Checked = True Or Me.cbVertikal.Checked = True Then

                    If BenutzerDaten.getSchiffAnzahl() <> SchiffAnzahl Then

                        Dim Schiffrichtung As Integer = 0

                        If Me.cbVertikal.Checked = True Then
                            Schiffrichtung = enumRichtung.Vertikal
                        ElseIf Me.cbHorizontal.Checked = True Then
                            Schiffrichtung = enumRichtung.Horizontal
                        End If

                        If Board.SetzSchiff(Me.dgv_BoardRight, BenutzerDaten, _
                                            e.ColumnIndex, e.RowIndex, _
                                            pSchiffTyp, Schiffrichtung, True) = True Then

                            Me.tsl_Status.Text = "Schiff Gesetzt !"

                        Else

                            Me.tsl_Status.Text = "Schiff konnte nicht Gesetzt werden !!!"
                        End If

                    Else
                        Me.tsl_Status.Text = "Es sind alle Schiffe Gesetzt! Sie können das Spiel starten"

                    End If
                Else

                    Me.tsl_Status.Text = "Bitte die Schiff Richtung auswählen !!!"

                End If

            ElseIf SpielArt = enumSpielArt.ComputerVSComputer Then

                Me.tsl_Status.Text = String.Empty

            Else

                Me.tsl_Status.Text = "Bitte wählen Sie ein Schiff aus !!!"

            End If
        End If

    End Sub


    ' Schiff Bilderfeld
    Private Sub dgv_SchiffBilder_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgv_SchiffBilder.CellClick

        If e.RowIndex = enumSchiffe.SHIP_Battleship Then

            Me.tsl_Status.Text = "Setzen Sie das Battleship auf einen Platz"
            pSchiffTyp = enumSchiffe.SHIP_Battleship

        ElseIf e.RowIndex = enumSchiffe.SHIP_Carrier Then

            Me.tsl_Status.Text = "Setzen Sie das Carrier Schiff auf einen Platz"
            pSchiffTyp = enumSchiffe.SHIP_Carrier

        ElseIf e.RowIndex = enumSchiffe.SHIP_Submarine Then

            Me.tsl_Status.Text = "Setzen Sie das Submarine Schiff auf einen Platz"
            pSchiffTyp = enumSchiffe.SHIP_Submarine

        ElseIf e.RowIndex = enumSchiffe.SHIP_Patrol Then

            Me.tsl_Status.Text = "Setzen Sie das Patrol Schiff auf einen Platz"
            pSchiffTyp = enumSchiffe.SHIP_Patrol

        End If

    End Sub


    ' Nach dem Schiffe setzen das Spiel starten
    Private Sub txt_SpielStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SpielStarten.Click

        If BenutzerDaten.getSchiffAnzahl() = SchiffAnzahl Then

            Dim listResult As New List(Of Integer)

            Me.PanelSchiffe.Visible = False
            Me.dgv_BoardLeft.Visible = True

            Board.MineSetzen(Me.dgv_BoardRight, BenutzerDaten, True)

            Me.tsl_Status.Text = "Spiel geladen !"

            SpielLaeuft = True
            SpielVorbei = False
            ShotCounter = 0

            ErhalteneMinenTreffer(ComputerName, ComputerDaten)
            ErhalteneMinenTreffer(SpielerName, BenutzerDaten)

            listResult.Clear()
            listResult = ComputerDaten.getSchiffVersenkt()
            AusgabeSpiel(ComputerName, listResult)

            listResult.Clear()
            listResult = BenutzerDaten.getSchiffVersenkt()
            AusgabeSpiel(SpielerName, listResult)


            SpielStartZeit = Now()

            listResult = Nothing

        Else

            Me.tsl_Status.Text = "Sie haben noch nicht alle Schiffe gesetzt !!!"

        End If

    End Sub


    ' Wenn Schiff doch nicht so gesetzt sein sollen,
    ' dann alle Schiffe vom Spielfeld löschen
    Private Sub btnSchiffeReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchiffeReset.Click
        Board.ErzeugeSpielffeld(Me.dgv_BoardRight, BenutzerDaten, enumSpieler.PLAYER2)
        BenutzerDaten.initSpielfeld()
        Me.tsl_Status.Text = "Spielfeld vom " & SpielerName & " zurückgesetzt"
    End Sub


    Private Sub ErhalteneMinenTreffer(ByVal Name As String, ByVal DatenObejekt As cls_Daten)

        Dim Treffer As Integer = DatenObejekt.getMinenTreffer

        If Treffer > 0 Then

            Dim Ausgabe As String = String.Empty
            If Treffer = 1 Then
                Ausgabe = Name & " hat " & Treffer & " Mine getroffen ;-("
            Else
                Ausgabe = Name & " hat " & Treffer & " Minen getroffen ;-("
            End If

            AusgabeSpiel(Ausgabe)
        End If

    End Sub


    Private Sub ErhalteneSchiffTreffer(ByVal Name As String, ByVal DatenObejekt As cls_Daten)
        Dim Treffer As Integer = DatenObejekt.getMinenTreffer()

        If Treffer = 1 Then
            AusgabeSpiel(Name & " hat mit der Mine einem Treffer erzielt !")
        ElseIf Treffer > 1 Then
            AusgabeSpiel(Name & " hat mit der Mine " & Treffer & " Schiffeteile getroffen ;-(")
        End If

    End Sub

#End Region

#Region "Spiel Menu"

    ' Neues Spiel starten
    Private Sub NeuesSpielStarten() Handles NeuesSpielToolStripMenuItem.Click

        Dim SpielStarten As Boolean = False
        Dim listResult As New List(Of Integer)

        ' Beim starten des Spiels prüfen ob das Spiel gerade läuft
        If SpielLaeuft = True Then

            If MsgBox("Das Spiel läuft gerade möchten Sie wirklich neustarten ?", MsgBoxStyle.YesNo, "Neues Spiel") = MsgBoxResult.Yes Then
                SpielLaeuft = False
                SpielStarten = True
            End If

        Else
            SpielStarten = True

        End If


        ' Battleship initialisieren und starten
        If SpielStarten = True Then

            Me.PanelMenu.Visible = False
            Me.PanelGame.Visible = True
            Me.PanelSchiffe.Visible = False
            Me.dgv_SpielAusgabe.Rows.Clear()

            ' Spiel Formular
            Me.Width = 2 * (SpaltenBreite * SpielfeldBreite) + 77
            Me.Height = ZeilenHoehe * SpielfeldHoehe + 200
            CenterToScreen()


            ' Spielausgabe initialisieren
            With Me.dgv_SpielAusgabe
                .Location = New Point(10, (SpielfeldHoehe * ZeilenHoehe) + 11)
                .Width = 2 * (SpaltenBreite * SpielfeldBreite) + 47
                .Height = 100
                .ColumnCount = 1
                .ColumnHeadersVisible = False
                .RowHeadersVisible = False
                .Columns(0).Width = 2 * (SpaltenBreite * SpielfeldBreite) + 75
            End With


            ' Prüfen ob der Haken bei KI vs. KI gesetzt ist
            If Me.cb_Computer.Checked = False Then

                SpielArt = enumSpielArt.ComputerVSHuman

                ' Computer initialisieren
                Computer.InitComputer()


                ' Spielfelder erzeugen
                Board.ErzeugeSpielffeld(Me.dgv_BoardLeft, ComputerDaten, enumSpieler.PLAYER1)
                Board.ErzeugeSpielffeld(Me.dgv_BoardRight, BenutzerDaten, enumSpieler.PLAYER2)


                ' Computer initialisieren
                Board.SetzeZufallSchiffe(Me.dgv_BoardLeft, ComputerDaten, SpielDebugModus)
                Board.MineSetzen(Me.dgv_BoardLeft, ComputerDaten, False)


                ' Pürfen ob das Benutzer seine Schiffe selber setzen möchte
                If Me.cb_SchiffeSetzen.Checked = True Then

                    Me.dgv_BoardLeft.Visible = False
                    Me.PanelSchiffe.Visible = True


                    Me.tsl_Status.Text = "Setzen Sie ihre Schiffe auf das Spielfeld"


                    ' DGV von den Schiffe formatieren und initialisieren
                    With Me.dgv_SchiffBilder

                        .Rows.Clear()
                        .Columns(0).Width = 220
                        .ColumnHeadersVisible = False
                        .RowHeadersVisible = False

                        .Rows.Add()
                        .Rows(0).Cells(0).Value = Image.FromFile(BildSchiffBattleshipHor)

                        .Rows.Add()
                        .Rows(1).Cells(0).Value = Image.FromFile(BildSchiffCarrierHor)

                        .Rows.Add()
                        .Rows(2).Cells(0).Value = Image.FromFile(BildSchiffSubmarineHor)

                        .Rows.Add()
                        .Rows(3).Cells(0).Value = Image.FromFile(BildSchiffPatrolHor)

                        .CurrentCell.Selected = False

                    End With

                    ' Panel postionieren
                    Me.PanelSchiffe.Location = New Point((SpielfeldBreite * SpaltenBreite) / 3, 50)


                Else
                    ' Schiff werden für den Benutzer per Zufall gesetzt

                    Me.PanelSchiffe.Visible = False
                    Me.dgv_BoardLeft.Visible = True
                    Board.SetzeZufallSchiffe(Me.dgv_BoardRight, BenutzerDaten, True)
                    Board.MineSetzen(Me.dgv_BoardRight, BenutzerDaten, True)

                    Me.tsl_Status.Text = "Spiel geladen !"
                    SpielLaeuft = True
                    SpielVorbei = False
                    ShotCounter = 0

                    ErhalteneMinenTreffer(ComputerName, ComputerDaten)
                    ErhalteneMinenTreffer(SpielerName, BenutzerDaten)

                    listResult.Clear()
                    listResult = ComputerDaten.getSchiffVersenkt()
                    AusgabeSpiel(ComputerName, listResult)


                    listResult.Clear()
                    listResult = BenutzerDaten.getSchiffVersenkt()
                    AusgabeSpiel(SpielerName, listResult)

                    Application.DoEvents()

                    listResult.Clear()

                    SpielStartZeit = Now()

                End If


            Else
                ' Computer vs. Computer

                SpielArt = enumSpielArt.ComputerVSComputer
                SpielLaeuft = True
                SpielVorbei = False
                ShotCounter = 0

                ' Computer initialisieren
                Computer.InitComputer()
                Computer2.InitComputer()


                ' Spielfelder erzeugen
                Board.ErzeugeSpielffeld(Me.dgv_BoardLeft, ComputerDaten, enumSpieler.PLAYER1)
                Board.ErzeugeSpielffeld(Me.dgv_BoardRight, ComputerDaten2, enumSpieler.PLAYER2)


                ' 1.Computer Daten initialisieren
                Board.SetzeZufallSchiffe(Me.dgv_BoardLeft, ComputerDaten, SpielDebugModus)
                Board.MineSetzen(Me.dgv_BoardLeft, ComputerDaten, False)

                listResult.Clear()
                listResult = ComputerDaten.getSchiffVersenkt()
                AusgabeSpiel(ComputerName1, listResult)



                ' 2.Computer Daten initialisieren
                Board.SetzeZufallSchiffe(Me.dgv_BoardRight, ComputerDaten2, SpielDebugModus)
                Board.MineSetzen(Me.dgv_BoardRight, ComputerDaten2, False)

                listResult.Clear()
                listResult = ComputerDaten2.getSchiffVersenkt()
                AusgabeSpiel(ComputerName2, listResult)



                Me.tsl_Status.Text = "Spiel geladen !"

                Application.DoEvents()

                SpielStartZeit = Now()
                ComputerSpielStarten()

            End If
        End If
    End Sub


    ' Spiel Partie Beenden
    Private Sub SpielBeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpielBeendenToolStripMenuItem.Click
        If SpielLaeuft = True Then
            Me.PanelGame.Visible = False
            Me.PanelMenu.Visible = True
            Me.tsl_Status.Text = "Spiel Partie beendet"
            SpielLaeuft = False
            SpielVorbei = True
            SetzFensterMenu()
        End If
    End Sub


    ' Battleship Beenden
    Private Sub SpielVerlassenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles SpielVerlassenToolStripMenuItem.Click, btn_Exit.Click
        SpielLaeuft = False
        Me.Close()
    End Sub

#End Region

#Region "Spiel Einstellungen speichern"

    Private Sub btn_Speichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Speichern.Click

        Dim Fehler As Boolean = False

        SpielerName = Me.txt_SpielerName.Text

        If IsNumeric(Me.txt_SpielfeldBreite.Text) AndAlso Me.txt_SpielfeldBreite.Text > 0 Then

            SpielfeldBreite = Me.txt_SpielfeldBreite.Text

        Else
            Me.tsl_Status.Text = "Spielfeld Breite ist keine Zahl !!!"
            Fehler = True
        End If

        If IsNumeric(Me.txt_SpielfeldHoehe.Text) AndAlso Me.txt_SpielfeldHoehe.Text > 0 Then
            SpielfeldHoehe = Me.txt_SpielfeldHoehe.Text

        Else
            Me.tsl_Status.Text = "Spielfeld Höhe ist keine Zahl !!!"
            Fehler = True
        End If

        If IsNumeric(Me.txt_SchiffAnzahl.Text) AndAlso Me.txt_SchiffAnzahl.Text > 0 Then
            SchiffAnzahl = Me.txt_SchiffAnzahl.Text

        Else
            Me.tsl_Status.Text = "Schiff Anzahl ist keine Zahl !!!"
            Fehler = True
        End If

        If IsNumeric(Me.txt_MinenAnzahl.Text) AndAlso Me.txt_MinenAnzahl.Text >= 0 Then
            SpielfeldMinen = Me.txt_MinenAnzahl.Text

        Else
            Me.tsl_Status.Text = "Minen Anzahl ist keine Zahl !!!"
            Fehler = True
        End If

        If Me.cb_Debug.Checked = True Then
            SpielDebugModus = True
        Else
            SpielDebugModus = False
        End If

        If Me.cb_SchiffeSetzen.Checked = True Then
            pSchiffeSetzen = True
        Else
            pSchiffeSetzen = False
        End If

        SpielLevel = Me.cmb_GameLevel.SelectedIndex


        If Fehler = False Then

            If SpielstartEingabePruefen() = True Then
                NeuesSpielStarten()
            Else
                Me.tsl_Status.Text = pStartFehler
            End If

        End If


    End Sub

#End Region

End Class
