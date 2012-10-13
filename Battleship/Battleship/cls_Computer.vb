Public Class cls_Computer

    Private pSpielfeld(,) As Integer
    Private pAttackMode As Boolean
    Private pAttackSuccess As Boolean
    Private pAttackCount As Integer
    Private pAttackDirection As Integer
    Private pAttackYX(2) As Integer
    Private pAttackFirstHitYX(2) As Integer
    Private pAttackHitYX(2) As Integer
    Private pAttackMiss As Integer
    Private pAttackBreak As Integer
    Private pAttackHorizontal As Boolean
    Private pAttackVertikal As Boolean
    Private pAttackRandom As Boolean

    Public Treffer As Integer
    Public TrefferResult As Integer

#Region "init Computer"

    ' Computer internes Spielfeld neu initialisieren
    Public Sub InitComputer()

        pSpielfeld = New Integer(SpielfeldHoehe, SpielfeldBreite) {}

        If SpielLevel = enumSchwierigkeit.Hardcore Then
            pAttackHorizontal = True
            pAttackVertikal = True
            pAttackRandom = False
        End If


        For i As Integer = 0 To SpielfeldHoehe - 1
            For j As Integer = 0 To SpielfeldBreite - 1
                pSpielfeld(i, j) = enumSpielfeld.BOARD_STATE_BLANK
            Next
        Next
    End Sub

#End Region

#Region "Private Methoden"

    ' Prüfen ob der Computer über Rand schiessen will
    Private Function SchussBoard(ByVal X As Integer, ByVal Y As Integer) As Boolean

        If Y > SpielfeldHoehe Or Y < 0 Then
            Return False
        ElseIf X > SpielfeldBreite Or X < 0 Then
            Return False
        End If

        Return True

    End Function

    ' Prüfen ob schon auf dem Feld gefeuert wurde
    Private Function NochtNicht(ByVal X As Integer, ByVal Y As Integer, ByVal DatenObject As cls_Daten) As Boolean

        If (pSpielfeld(Y, X) = enumSpielfeld.BOARD_STATE_BLANK _
            Or DatenObject.getBoardValue(Y, X) = enumSpielfeld.BOARD_STATE_MINE) _
            And DatenObject.getBoardValue(Y, X) <> enumSpielfeld.BOARD_STATE_HIT Then

            Return True

        Else
            Return False
        End If

    End Function

#End Region

#Region "Public Schiess Methode"

    Public Sub Schiessen(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten)
        If SpielLevel = enumSchwierigkeit.Leicht Then
            SchiessenEasy(DGV, DatenObjekt)

        ElseIf SpielLevel = enumSchwierigkeit.Medium Then
            SchiessenMedium(DGV, DatenObjekt)

        ElseIf SpielLevel = enumSchwierigkeit.Hardcore Then
            SchiessenHardcore(DGV, DatenObjekt)

        End If
    End Sub

#End Region

#Region "Computer Easy"

    ' Auf ein Schiff schiessen
    Private Sub SchiessenEasy(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten)
        Dim Board As New cls_Board

        Dim SchiessX As Integer = 0
        Dim SchiessY As Integer = 0
        Dim pNochNicht As Boolean = True

        Treffer = 0
        TrefferResult = 0

        While pNochNicht

            SchiessX = Int(SpielfeldBreite * Rnd())
            SchiessY = Int(SpielfeldHoehe * Rnd())

            If NochtNicht(SchiessX, SchiessY, DatenObjekt) = True Then
                TrefferResult = Board.FeuerSchiff(DGV, DatenObjekt, SchiessY, SchiessX)

                If TrefferResult = enumSpielfeld.BOARD_STATE_HIT Then
                    Treffer += 1
                    pNochNicht = True

                Else
                    pNochNicht = False
                End If

            End If

        End While

        Board = Nothing

    End Sub

#End Region

#Region "Computer Medium"

    ' ############
    ' ## Medium ##
    ' ############
    Private Sub SchiessenMediumTreffen(ByVal DatenObject As cls_Daten)

        Dim VersuchY As Integer = pAttackYX(0)
        Dim VersuchX As Integer = pAttackYX(1)
        Dim AngriffRichtung As Integer
        Dim SchiessenVersuch As Boolean = True
        Dim VersuchCounter As Integer = 0

        While SchiessenVersuch

            If pAttackDirection = 0 Then
                AngriffRichtung = Int(4 * Rnd())
            Else
                AngriffRichtung = pAttackDirection
            End If

            If pAttackYX(0) <> pAttackHitYX(0) AndAlso pAttackSuccess = 0 Then
                VersuchY = pAttackHitYX(0)
            End If

            If pAttackYX(1) <> pAttackHitYX(1) AndAlso pAttackSuccess = 0 Then
                VersuchX = pAttackHitYX(1)
            End If

            If AngriffRichtung = enumAngriffRichtung.YPlusEins Then

                If SchussBoard(VersuchY + 1, VersuchX) = True Then
                    If NochtNicht(VersuchX, VersuchY + 1, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY + 1
                        pAttackYX(1) = VersuchX
                        pAttackDirection = enumAngriffRichtung.YPlusEins
                    End If
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.XPlusEins Then

                If SchussBoard(VersuchY, VersuchX + 1) = True Then
                    If NochtNicht(VersuchX + 1, VersuchY, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY
                        pAttackYX(1) = VersuchX + 1
                        pAttackDirection = enumAngriffRichtung.XPlusEins
                    End If
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.YMinusEins Then

                If SchussBoard(VersuchY - 1, VersuchX) = True Then
                    If NochtNicht(VersuchX, VersuchY - 1, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY - 1
                        pAttackYX(1) = VersuchX
                        pAttackDirection = enumAngriffRichtung.YMinusEins
                    End If
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.XMinusEins Then

                If SchussBoard(VersuchY, VersuchX - 1) = True Then
                    If NochtNicht(VersuchX - 1, VersuchY, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY
                        pAttackYX(1) = VersuchX - 1
                        pAttackDirection = enumAngriffRichtung.XMinusEins
                    End If
                End If

            End If

            If VersuchCounter = 20 Then
                SchiessenVersuch = False
                pAttackMode = False
            ElseIf VersuchCounter = 10 Then
                pAttackDirection = 0
                VersuchCounter += 1
            Else
                VersuchCounter += 1
            End If

        End While

    End Sub


    Private Sub SchiessenMedium(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten)

        Dim Board As New cls_Board

        Dim SchiessX As Integer = 0
        Dim SchiessY As Integer = 0
        Dim pNochNicht As Boolean = True


        Treffer = 0
        TrefferResult = 0

        While pNochNicht

            If pAttackMode = False Then
                pAttackCount = 0
                pAttackSuccess = 0
                pAttackDirection = 0

                SchiessY = Int(SpielfeldHoehe * Rnd())
                SchiessX = Int(SpielfeldBreite * Rnd())

            Else
                SchiessenMediumTreffen(DatenObjekt)
                SchiessY = pAttackYX(0)
                SchiessX = pAttackYX(1)

            End If


            If NochtNicht(SchiessX, SchiessY, DatenObjekt) = True Then
                TrefferResult = Board.FeuerSchiff(DGV, DatenObjekt, SchiessY, SchiessX)

                If TrefferResult = enumSpielfeld.BOARD_STATE_HIT Then
                    Treffer += 1
                    If pAttackMode = True Then
                        pAttackSuccess += 1
                    End If
                    pAttackMode = True
                    pAttackCount += 1
                    pAttackYX(0) = SchiessY
                    pAttackYX(1) = SchiessX
                    pAttackHitYX(0) = SchiessY
                    pAttackHitYX(1) = SchiessX

                    pSpielfeld(SchiessY, SchiessX) = enumSpielfeld.BOARD_STATE_HIT
                    pNochNicht = True

                Else
                    pAttackDirection = 0
                    If pAttackSuccess = 0 Then
                        pAttackYX(0) = pAttackHitYX(0)
                    End If

                    pSpielfeld(SchiessY, SchiessX) = enumSpielfeld.BOARD_STATE_MISS
                    pAttackCount += 1
                    pNochNicht = False
                End If

            End If

        End While


        If pAttackCount > AngriffAnzahlMedium Then
            pAttackMode = False
        End If

        Board = Nothing

    End Sub

#End Region

#Region "Computer Hardcore"

    Private Sub HardcoreSchiessenRaster(ByVal DatenObjekt As cls_Daten)

        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim CheckBoard As Boolean = True
        Dim SelectField As Boolean
        Dim Counter As Integer = 0
        Dim BreakCounter As Integer = SpielfeldBreite * SpielfeldHoehe / 9

        While CheckBoard

            SelectField = True

            Y = Int(SpielfeldHoehe * Rnd())
            X = Int(SpielfeldBreite * Rnd())

            For i As Integer = X - 1 To X + 1
                For j As Integer = Y - 1 To Y + 1

                    If SchussBoard(i, j) = True AndAlso NochtNicht(i, j, DatenObjekt) = True Then

                        If pSpielfeld(j, i) = enumSpielfeld.BOARD_STATE_HIT Then
                            SelectField = False

                        ElseIf pSpielfeld(j, i) = enumSpielfeld.BOARD_STATE_MISS Then
                            SelectField = False

                        End If

                        'Else
                        '    SelectField = False

                    End If

                Next
            Next

            If SelectField = True AndAlso SchussBoard(X, Y) = True Then
                CheckBoard = False
                pAttackYX(0) = Y
                pAttackYX(1) = X
            Else
                Counter += 1
            End If

            If BreakCounter < Counter Then
                CheckBoard = False
            End If

        End While

        If BreakCounter < Counter And SelectField = False Then
            SchiessenHardcoreFeiner(DatenObjekt)
        End If

    End Sub


    Private Sub SchiessenHardcoreFeiner(ByVal DatenObjekt As cls_Daten)

        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim LoopConter As Integer = 0
        Dim SelectField As Boolean
        Dim CheckBoard As Boolean = True
        Dim Vertikal As Boolean = True
        Dim Horizontal As Boolean = True
        Dim RandomSchuss As Boolean = False

        If pAttackHorizontal = False Then
            Horizontal = False
        End If

        If pAttackVertikal = False Then
            Vertikal = False
        End If

        If pAttackHorizontal = False AndAlso pAttackVertikal = False Then
            RandomSchuss = True
        End If


        While CheckBoard

            While Horizontal

                SelectField = True
                X = Int(SpielfeldHoehe * Rnd())
                Y = Int(SpielfeldBreite * Rnd())

                For i As Integer = X - 1 To X + 1
                    If SchussBoard(i, Y) AndAlso NochtNicht(i, Y, DatenObjekt) = True Then
                        If pSpielfeld(Y, i) = enumSpielfeld.BOARD_STATE_HIT Then
                            SelectField = False
                        ElseIf pSpielfeld(Y, i) = enumSpielfeld.BOARD_STATE_MISS Then
                            SelectField = False
                        End If
                    End If
                Next

                If SelectField = True AndAlso SchussBoard(X, Y) = True Then
                    Vertikal = False
                    Horizontal = False
                    CheckBoard = False
                    pAttackYX(0) = Y
                    pAttackYX(1) = X

                Else

                    If LoopConter = 15 Then
                        Horizontal = False
                        pAttackHorizontal = False
                    Else
                        LoopConter += 1
                    End If

                End If

            End While

            LoopConter = 0

            While Vertikal

                SelectField = True
                X = Int(SpielfeldHoehe * Rnd())
                Y = Int(SpielfeldBreite * Rnd())

                For i As Integer = X - 1 To X + 1
                    If SchussBoard(i, Y) = True AndAlso NochtNicht(i, Y, DatenObjekt) Then
                        If pSpielfeld(Y, i) = enumSpielfeld.BOARD_STATE_HIT Then
                            SelectField = False
                        ElseIf pSpielfeld(Y, i) = enumSpielfeld.BOARD_STATE_MISS Then
                            SelectField = False
                        End If
                    End If
                Next

                If SelectField = True AndAlso SchussBoard(X, Y) = True Then
                    Vertikal = False
                    CheckBoard = False
                    pAttackYX(0) = Y
                    pAttackYX(1) = X

                Else

                    If LoopConter = 25 Then
                        Vertikal = False
                        pAttackVertikal = False
                        pAttackRandom = True
                        CheckBoard = False
                    Else
                        LoopConter += 1
                    End If

                End If

            End While

            LoopConter = 0

            While RandomSchuss

                SelectField = True
                X = Int(SpielfeldHoehe * Rnd())
                Y = Int(SpielfeldBreite * Rnd())

                If SchussBoard(X, Y) = True AndAlso NochtNicht(X, Y, DatenObjekt) Then
                    If pSpielfeld(Y, X) = enumSpielfeld.BOARD_STATE_HIT Then
                        SelectField = False
                    ElseIf pSpielfeld(Y, X) = enumSpielfeld.BOARD_STATE_MISS Then
                        SelectField = False
                    End If
                End If

                If SelectField = True AndAlso SchussBoard(X, Y) = True Then
                    CheckBoard = False
                    RandomSchuss = False
                    pAttackYX(0) = Y
                    pAttackYX(1) = X
                End If

            End While


        End While

    End Sub


    Private Sub SchiessenHardcoreTreffen(ByVal DatenObject As cls_Daten)

        Dim VersuchY As Integer = pAttackYX(0)
        Dim VersuchX As Integer = pAttackYX(1)
        Dim AngriffRichtung As Integer
        Dim SchiessenVersuch As Boolean = True
        Dim AnderesZiel As Boolean = False


        While SchiessenVersuch

            If pAttackDirection = enumAngriffRichtung.AnderesZiel _
            Or AnderesZiel = True Then
                AngriffRichtung = Int(4 * Rnd())
                pAttackMiss = 0
            Else
                AngriffRichtung = pAttackDirection
            End If

            If pAttackDirection = enumAngriffRichtung.AnderesZiel _
            AndAlso pAttackYX(0) <> pAttackHitYX(0) Then
                VersuchY = pAttackHitYX(0)
            End If

            If pAttackDirection = enumAngriffRichtung.AnderesZiel _
            AndAlso pAttackYX(1) <> pAttackHitYX(1) Then
                VersuchX = pAttackHitYX(1)
            End If

            If AnderesZiel = True Or pAttackMiss > 0 Then
                VersuchY = pAttackFirstHitYX(0)
                VersuchX = pAttackFirstHitYX(1)
            End If

            If pAttackMiss >= 1 And pAttackSuccess <= 1 And pAttackMode = True Then
                VersuchY = pAttackFirstHitYX(0)
                VersuchX = pAttackFirstHitYX(1)

                If AngriffRichtung = enumAngriffRichtung.XMinusEins Then
                    AngriffRichtung = enumAngriffRichtung.XPlusEins
                ElseIf AngriffRichtung = enumAngriffRichtung.XPlusEins Then
                    AngriffRichtung = enumAngriffRichtung.XMinusEins
                ElseIf AngriffRichtung = enumAngriffRichtung.YMinusEins Then
                    AngriffRichtung = enumAngriffRichtung.YPlusEins
                ElseIf AngriffRichtung = enumAngriffRichtung.YPlusEins Then
                    AngriffRichtung = enumAngriffRichtung.YMinusEins
                End If

                If pAttackCount >= 5 And pAttackMiss >= 4 Then
                    pAttackMode = False
                End If

            End If


            If AngriffRichtung = enumAngriffRichtung.YPlusEins Then
                If SchussBoard(VersuchY + 1, VersuchX) = True Then
                    If NochtNicht(VersuchX, VersuchY + 1, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY + 1
                        pAttackYX(1) = VersuchX
                        pAttackDirection = enumAngriffRichtung.YPlusEins
                    Else
                        pAttackDirection = enumAngriffRichtung.AnderesZiel
                    End If
                Else
                    AnderesZiel = True
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.XPlusEins Then

                If SchussBoard(VersuchY, VersuchX + 1) = True Then
                    If NochtNicht(VersuchX + 1, VersuchY, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY
                        pAttackYX(1) = VersuchX + 1
                        pAttackDirection = enumAngriffRichtung.XPlusEins
                    Else
                        pAttackDirection = enumAngriffRichtung.AnderesZiel
                    End If
                Else
                    AnderesZiel = True
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.YMinusEins Then

                If SchussBoard(VersuchY - 1, VersuchX) = True Then
                    If NochtNicht(VersuchX, VersuchY - 1, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY - 1
                        pAttackYX(1) = VersuchX
                        pAttackDirection = enumAngriffRichtung.YMinusEins
                    Else
                        pAttackDirection = enumAngriffRichtung.AnderesZiel
                    End If
                Else
                    AnderesZiel = True
                End If

            ElseIf AngriffRichtung = enumAngriffRichtung.XMinusEins Then

                If SchussBoard(VersuchY, VersuchX - 1) = True Then
                    If NochtNicht(VersuchX - 1, VersuchY, DatenObject) = True Then
                        SchiessenVersuch = False
                        pAttackYX(0) = VersuchY
                        pAttackYX(1) = VersuchX - 1
                        pAttackDirection = enumAngriffRichtung.XMinusEins
                    Else
                        pAttackDirection = enumAngriffRichtung.AnderesZiel
                    End If
                Else
                    AnderesZiel = True
                End If

            End If

            pAttackBreak += 1

            If pAttackBreak = 10 Then
                pAttackMode = False
                SchiessenVersuch = False
            End If


        End While

    End Sub


    Private Sub SchiessenHardcore(ByVal DGV As DataGridView, ByVal DatenObjekt As cls_Daten)

        Dim Board As New cls_Board

        Dim SchiessX As Integer = 0
        Dim SchiessY As Integer = 0
        Dim pNochNicht As Boolean = True


        Treffer = 0
        TrefferResult = 0

        While pNochNicht

            If pAttackMode = False Then
                pAttackCount = 0
                pAttackSuccess = 0
                pAttackDirection = 0

                If pAttackRandom = False Then
                    HardcoreSchiessenRaster(DatenObjekt)
                End If

                If pAttackRandom = True Then
                    SchiessenHardcoreFeiner(DatenObjekt)
                End If

                SchiessY = pAttackYX(0)
                SchiessX = pAttackYX(1)

            Else
                SchiessenHardcoreTreffen(DatenObjekt)
                SchiessY = pAttackYX(0)
                SchiessX = pAttackYX(1)

            End If


            If NochtNicht(SchiessX, SchiessY, DatenObjekt) = True Then
                TrefferResult = Board.FeuerSchiff(DGV, DatenObjekt, SchiessY, SchiessX)

                If TrefferResult = enumSpielfeld.BOARD_STATE_HIT Then
                    Treffer += 1

                    If pAttackMode = False Then
                        pAttackFirstHitYX(0) = SchiessY
                        pAttackFirstHitYX(1) = SchiessX
                    End If

                    pAttackMode = True
                    pAttackCount += 1
                    pAttackYX(0) = SchiessY
                    pAttackYX(1) = SchiessX
                    pAttackHitYX(0) = SchiessY
                    pAttackHitYX(1) = SchiessX

                    pSpielfeld(SchiessY, SchiessX) = enumSpielfeld.BOARD_STATE_HIT
                    pNochNicht = True

                Else
                    If pAttackMode = True Then
                        pAttackMiss += 1
                    End If

                    pSpielfeld(SchiessY, SchiessX) = enumSpielfeld.BOARD_STATE_MISS

                    pNochNicht = False
                End If

                pAttackBreak = 0
            End If

        End While

        Board = Nothing

    End Sub

#End Region

End Class
