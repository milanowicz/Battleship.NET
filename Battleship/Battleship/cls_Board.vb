Public Class cls_Board

#Region "Spielfeld erzeugen"

    ' Spielfeld erzeugen
    Public Sub ErzeugeSpielffeld(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, ByVal Player As Integer)

        Dim pSpielfeldGroesse As Integer = (SpaltenBreite * SpielfeldBreite) + 3

        ' DataGridView Optionen
        DGV.Columns.Clear()
        DGV.Rows.Clear()

        DGV.ColumnHeadersVisible = False
        DGV.RowHeadersVisible = False
        DGV.Width = pSpielfeldGroesse
        DGV.Height = (SpielfeldHoehe * ZeilenHoehe) + 3

        ' Zweites Board setzen
        If Player = enumSpieler.PLAYER1 Then
            DGV.Location = New Point(10, 1)
        ElseIf Player = enumSpieler.PLAYER2 Then
            DGV.Location = New Point(pSpielfeldGroesse + 50, 1)
        End If

        ' Wasser Bild laden
        Dim Bild As Image = BildWasser

        ' GridView Spalten initialisieren
        For i As Integer = 0 To SpielfeldBreite - 1
            DGV.Columns.Add(New DataGridViewImageColumn())
            DGV.Columns(i).Width = SpaltenBreite
            DGV.Columns(i).ValueType = GetType(Bitmap)
        Next

        ' GridView Zeilen initialisieren
        For i As Integer = 0 To SpielfeldHoehe - 1
            DGV.Rows.Add()
            DGV.Rows(i).Height = ZeilenHoehe
        Next

        ' GridView mit dem Wasserbild initialisieren
        For i As Integer = 0 To SpielfeldHoehe - 1
            For j As Integer = 0 To SpielfeldBreite - 1
                With DGV.Rows(i).Cells(j)
                    .Value = Bild
                    .Style.BackColor = Color.LightSkyBlue
                End With
            Next
        Next

        ' Nach allem Laden den Markier Cursor verschwinden lassen
        If DGV.RowCount > 0 And DGV.ColumnCount > 0 Then
            DGV.CurrentCell = DGV(0, 0)
            DGV.CurrentCell.Selected = False
        End If

        ' Datenfeld fürs Spielfeld
        DatenObjekt.initSpielfeld()

        Bild = Nothing

    End Sub

#End Region

#Region "Schiff setzen"

    ' Zufall Schiffe auf dem Spielfeld verteilen
    Public Sub SetzeZufallSchiffe(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, ByVal DebugModus As Boolean)

        Dim SetzSchiffX As Integer = 0
        Dim SetzSchiffY As Integer = 0
        Dim SchiffTyp As Integer = 0
        Dim SchiffRichtung As Integer = 0

        Dim i As Integer = 0

        While i < SchiffAnzahl

            SetzSchiffX = Int(SpielfeldBreite * Rnd())
            SetzSchiffY = Int(SpielfeldHoehe * Rnd())
            SchiffTyp = Int(4 * Rnd())
            SchiffRichtung = Int(2 * Rnd())

            If SetzSchiff(DGV, DatenObjekt, SetzSchiffX, SetzSchiffY, SchiffTyp, SchiffRichtung, DebugModus) = True Then
                i += 1
            End If

        End While

    End Sub


    ' Setzen eines Schiff auf das Spielfeld
    Public Function SetzSchiff(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, ByVal SetzSchiffX As Integer, ByVal SetzSchiffY As Integer, _
                               ByVal SchiffTyp As Integer, ByVal SchiffRichtung As Integer, ByVal DebugModus As Boolean) As Boolean


        Dim pSchiffGroesse As Integer = 0
        Dim pSchiffBild As String = String.Empty


        If SchiffTyp = enumSchiffe.SHIP_Patrol Then
            pSchiffGroesse = enumSchiffe.SHIP_Patrol_Size
            pSchiffBild = BildSchiffPatrol

        ElseIf SchiffTyp = enumSchiffe.SHIP_Submarine Then
            pSchiffGroesse = enumSchiffe.SHIP_Submarine_Size
            pSchiffBild = BildSchiffSubmarine

        ElseIf SchiffTyp = enumSchiffe.SHIP_Battleship Then
            pSchiffGroesse = enumSchiffe.SHIP_Battleship_Size
            pSchiffBild = BildSchiffBattleship
          
        ElseIf SchiffTyp = enumSchiffe.SHIP_Carrier Then
            pSchiffGroesse = enumSchiffe.SHIP_Carrier_Size
            pSchiffBild = BildSchiffCarrier
         
        End If


        If SetzSchiffX >= SpielfeldBreite Or SetzSchiffY >= SpielfeldHoehe Then
            Return False
        End If


        If SchiffRichtung = enumRichtung.Horizontal Then
            If SetzSchiffX + pSchiffGroesse > SpielfeldBreite Then
                Return False
            End If

        Else
            If SetzSchiffY + pSchiffGroesse > SpielfeldHoehe Then
                Return False
            End If
        End If

        Dim checkX As Integer = SetzSchiffX
        Dim checkY As Integer = SetzSchiffY

        If DatenObjekt.SchiffVorhanden(SetzSchiffY, SetzSchiffX, pSchiffGroesse, SchiffRichtung) = True Then
            Return False

        Else

            DatenObjekt.SchiffSetzen(SetzSchiffY, SetzSchiffX, pSchiffGroesse, SchiffRichtung)
        End If


        ' Schiff auf das GridView stellen
        For i As Integer = 0 To pSchiffGroesse - 1

            If DebugModus = True Then

                Dim tmpPic As Image = ErhalteSchiffPart(pSchiffBild, i + 1)

                If SchiffRichtung = enumRichtung.Vertikal Then
                    tmpPic.RotateFlip(RotateFlipType.Rotate90FlipNone)
                End If

                DGV.Rows(SetzSchiffY).Cells(SetzSchiffX).Value = tmpPic
                DGV.Rows(SetzSchiffY).Cells(SetzSchiffX).Style.BackColor = Color.LightSkyBlue

                tmpPic = Nothing

            End If

            If SchiffRichtung = enumRichtung.Horizontal Then
                SetzSchiffX += 1
            Else
                SetzSchiffY += 1
            End If



        Next

        Return True

    End Function

    ' Erhalte den Schiffteil
    Private Function ErhalteSchiffPart(ByVal ShipPartName As String, ByVal Number As Integer) As Image

        Dim pObject As Image = Nothing

        If ShipPartName = BildSchiffBattleship Then

            Select Case Number
                Case 1
                    pObject = My.Resources.Battleship_1
                Case 2
                    pObject = My.Resources.Battleship_2
                Case 3
                    pObject = My.Resources.Battleship_3
                Case 4
                    pObject = My.Resources.Battleship_4
            End Select

        ElseIf ShipPartName = BildSchiffCarrier Then

            Select Case Number
                Case 1
                    pObject = My.Resources.Carrier_1
                Case 2
                    pObject = My.Resources.Carrier_2
                Case 3
                    pObject = My.Resources.Carrier_3
                Case 4
                    pObject = My.Resources.Carrier_4
                Case 5
                    pObject = My.Resources.Carrier_5
            End Select

        ElseIf ShipPartName = BildSchiffPatrol Then

            Select Case Number
                Case 1
                    pObject = My.Resources.Patrol_1
                Case 2
                    pObject = My.Resources.Patrol_2
            End Select

        ElseIf ShipPartName = BildSchiffSubmarine Then

            Select Case Number
                Case 1
                    pObject = My.Resources.Submarine_1
                Case 2
                    pObject = My.Resources.Submarine_2
                Case 3
                    pObject = My.Resources.Submarine_3
            End Select

        End If

        ErhalteSchiffPart = pObject

    End Function

#End Region

#Region "Auf Schiff feuern"

    ' Auf ein Schiff feuern
    Public Function FeuerSchiff(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, _
                                ByVal Zeile As Integer, ByVal Spalte As Integer) As Integer

        FeuerSchiff = DatenObjekt.FeuerSchiff(Zeile, Spalte)

        With DGV.Rows(Zeile).Cells(Spalte)

            If FeuerSchiff = enumSpielfeld.BOARD_STATE_HIT Then

                Dim Bild As Image = BildGetroffen

                .Value = Nothing
                .Value = Bild

                Bild = Nothing

            ElseIf FeuerSchiff = enumSpielfeld.BOARD_STATE_MINE Then

                DatenObjekt.resetMinenTreffer()
                MinenTreffer(DGV, DatenObjekt, Zeile, Spalte)

                Dim Bild As Image = BildMine

                .Value = Nothing
                .Style.BackColor = Color.Navy
                .Value = Bild

                Bild = Nothing

            ElseIf FeuerSchiff = enumSpielfeld.BOARD_STATE_MISS Then

                Dim Bild As Image = BildDaneben

                .Value = Nothing
                .Style.BackColor = Color.Navy
                .Value = Bild

                Bild = Nothing

            End If

        End With

        If DGV.RowCount > 0 And DGV.ColumnCount > 0 Then
            DGV.CurrentCell = DGV(0, 0)
            DGV.CurrentCell.Selected = False
        End If

    End Function

#End Region

#Region "Minen Logik"

    ' Setze Zufallsminen auf Spielfeld
    Public Sub MineSetzen(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, ByVal ZeigMinen As Boolean)

        Dim pSetMine As Boolean = True
        Dim SetzMineY As Integer = 0
        Dim SetzMineX As Integer = 0
        Dim i As Integer = 0

        While i < SpielfeldMinen

            SetzMineX = Int(SpielfeldBreite * Rnd())
            SetzMineY = Int(SpielfeldHoehe * Rnd())

            If DatenObjekt.SetzeMine(SetzMineY, SetzMineX) = True Then

                If DatenObjekt.getBoardValue(SetzMineY, SetzMineX) = enumSpielfeld.BOARD_STATE_MINE_HIT Then
                    DGV.Rows(SetzMineY).Cells(SetzMineX).Value = BildMine
                    MinenTreffer(DGV, DatenObjekt, SetzMineY, SetzMineX)

                ElseIf SpielDebugModus = True Or ZeigMinen = True Then
                    DGV.Rows(SetzMineY).Cells(SetzMineX).Value = BildMine

                End If

                i += 1

            End If

        End While

    End Sub


    Public Sub MinenTreffer(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten, _
                            ByVal Zeile As Integer, ByVal Spalte As Integer)

        DatenObjekt.setMineGetroffen(Zeile, Spalte)

        Dim pResult As Integer = 0
        Dim pZeile As Integer = Zeile - 1
        Dim pSpalte As Integer = Spalte - 1

        For i As Integer = pZeile To Zeile + 1
            For j As Integer = pSpalte To pSpalte + 2
                If DatenObjekt.SchussBoard(j, i) = True Then

                    pResult = DatenObjekt.MineExplodieren(i, j)

                    If pResult = enumSpielfeld.BOARD_STATE_MISS Then
                        DGV.Rows(i).Cells(j).Value = BildGetroffen

                    ElseIf pResult = enumSpielfeld.BOARD_STATE_HIT Then
                        DGV.Rows(i).Cells(j).Value = BildGetroffen

                    ElseIf pResult = enumSpielfeld.BOARD_STATE_MINE_HIT Then
                        MinenTreffer(DGV, DatenObjekt, i, j)

                    End If

                End If
            Next
        Next

    End Sub

#End Region

End Class
