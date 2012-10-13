Public Class cls_Daten

    Private pSpielfeld(,) As Integer
    Private pSchifffeld(,) As Integer
    Private pMinenTreffer As Integer
    Private pSchiffAnzahl As Integer
    Private pSchiffAnzahlTyp() As Integer


#Region "Daten Initialisierung"

    Public Sub initSpielfeld()
        pMinenTreffer = 0
        pSchiffAnzahl = 0
        pSpielfeld = New Integer(SpielfeldHoehe, SpielfeldBreite) {}
        pSchifffeld = New Integer(SpielfeldHoehe, SpielfeldBreite) {}
        pSchiffAnzahlTyp = New Integer(SpielSchiffAnzahl) {}

        For i As Integer = 0 To SpielfeldHoehe - 1
            For j As Integer = 0 To SpielfeldBreite - 1
                pSpielfeld(i, j) = enumSpielfeld.BOARD_STATE_BLANK
                pSchifffeld(i, j) = enumSpielfeld.BOARD_STATE_BLANK
            Next
        Next

        For i As Integer = 0 To SpielSchiffAnzahl
            pSchiffAnzahlTyp(i) = 0
        Next

    End Sub

    Public Sub resetMinenTreffer()
        pMinenTreffer = 0
    End Sub

#End Region

#Region "Public Methoden als Rückgabewert Integer"

    Public Function getBoardValue(ByVal Y As Integer, ByVal X As Integer) As Integer
        Return pSpielfeld(Y, X)
    End Function


    Public Function getSchiffAnzahl() As Integer
        Return pSchiffAnzahl
    End Function


    Public Function getMinenTreffer() As Integer
        Return pMinenTreffer
    End Function


    ' Prüfen ob ein Schiff versenkt wurde
    Public Function getSchiffVersenkt() As List(Of Integer)

        Dim pSchiffArten(SpielSchiffAnzahl) As Integer
        Dim listSchiff As New List(Of Integer)

        ' Vorhandene Schiffe ermitteln
        For i As Integer = 0 To SpielfeldHoehe - 1
            For j As Integer = 0 To SpielfeldBreite - 1

                If pSpielfeld(i, j) = enumSpielfeld.BOARD_STATE_SHIP And
                    pSchifffeld(i, j) <> enumSpielfeld.BOARD_STATE_BLANK Then

                    If pSchifffeld(i, j) = enumSchiffe.SHIP_Battleship Then
                        pSchiffArten(enumSchiffe.SHIP_Battleship) += 1
                    ElseIf pSchifffeld(i, j) = enumSchiffe.SHIP_Carrier Then
                        pSchiffArten(enumSchiffe.SHIP_Carrier) += 1
                    ElseIf pSchifffeld(i, j) = enumSchiffe.SHIP_Patrol Then
                        pSchiffArten(enumSchiffe.SHIP_Patrol) += 1
                    ElseIf pSchifffeld(i, j) = enumSchiffe.SHIP_Submarine Then
                        pSchiffArten(enumSchiffe.SHIP_Submarine) += 1
                    End If

                End If

            Next
        Next


        ' Auswertung
        If pSchiffAnzahlTyp(enumSchiffe.SHIP_Battleship) > 0 _
        AndAlso (pSchiffArten(enumSchiffe.SHIP_Battleship) / enumSchiffe.SHIP_Battleship_Size) _
                <= pSchiffAnzahlTyp(enumSchiffe.SHIP_Battleship) - 1 Then

            listSchiff.Add(enumSchiffe.SHIP_Battleship)
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Battleship) -= 1

        End If

        If pSchiffAnzahlTyp(enumSchiffe.SHIP_Carrier) > 0 _
        AndAlso (pSchiffArten(enumSchiffe.SHIP_Carrier) / enumSchiffe.SHIP_Carrier_Size) _
                <= pSchiffAnzahlTyp(enumSchiffe.SHIP_Carrier) - 1 Then

            listSchiff.Add(enumSchiffe.SHIP_Carrier)
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Carrier) -= 1

        End If

        If pSchiffAnzahlTyp(enumSchiffe.SHIP_Patrol) > 0 _
        AndAlso (pSchiffArten(enumSchiffe.SHIP_Patrol) / enumSchiffe.SHIP_Patrol_Size) _
                <= pSchiffAnzahlTyp(enumSchiffe.SHIP_Patrol) - 1 Then

            listSchiff.Add(enumSchiffe.SHIP_Patrol)
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Patrol) -= 1

        End If

        If pSchiffAnzahlTyp(enumSchiffe.SHIP_Submarine) > 0 _
        AndAlso (pSchiffArten(enumSchiffe.SHIP_Submarine) / enumSchiffe.SHIP_Submarine_Size) _
                <= pSchiffAnzahlTyp(enumSchiffe.SHIP_Submarine) - 1 Then

            listSchiff.Add(enumSchiffe.SHIP_Submarine)
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Submarine) -= 1

        End If


        getSchiffVersenkt = listSchiff
        listSchiff = Nothing
        pSchiffArten = Nothing

    End Function

#End Region

#Region "Public Methoden als Rückgabewert Boolean"

    ' Prüfen ob über Rand schiessen
    Public Function SchussBoard(ByVal X As Integer, ByVal Y As Integer) As Boolean

        If Y >= SpielfeldHoehe Or Y < 0 Then
            Return False
        ElseIf X >= SpielfeldBreite Or X < 0 Then
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Schiff Logik"

    ' Prüfen ob ein Schiff auf den Daten Spielfeld vorhanden ist
    Public Function SchiffVorhanden(ByVal SetzSchiffY As Integer, ByVal SetzSchiffX As Integer, _
                                   ByVal SchiffGroesse As Integer, ByVal SchiffRichtung As Integer) As Boolean

        Dim pX As Integer = SetzSchiffX
        Dim pY As Integer = SetzSchiffY


        If SchiffRichtung = enumRichtung.Horizontal Then
            pX -= 1
            pY = SetzSchiffY - 1
        Else
            pX = SetzSchiffX - 1
            pY -= 1
        End If


        ' Nachbar Schiff Prüfung
        For j As Integer = 0 To 3

            ' Prüfen ob Schiff auf den GridView ist
            For i As Integer = 0 To SchiffGroesse + 1

                If SchussBoard(pX, pY) = True Then
                    If pSpielfeld(pY, pX) = enumSpielfeld.BOARD_STATE_SHIP Then
                        Return True
                    End If
                End If

                If SchiffRichtung = enumRichtung.Horizontal Then
                    pX += 1
                Else
                    pY += 1
                End If

            Next

            If SchiffRichtung = enumRichtung.Horizontal Then
                pX = SetzSchiffX - 1
                pY += 1
            Else
                pX += 1
                pY = SetzSchiffY - 1

            End If

        Next

        Return False

    End Function


    ' Schiff auf Daten Spielfeld setzen
    Public Sub SchiffSetzen(ByVal SetzSchiffY As Integer, ByVal SetzSchiffX As Integer, _
                            ByVal SchiffGroesse As Integer, ByVal SchiffRichtung As Integer)

        ' Schiff auf das GridView stellen
        For i As Integer = 0 To SchiffGroesse - 1

            pSpielfeld(SetzSchiffY, SetzSchiffX) = enumSpielfeld.BOARD_STATE_SHIP

            If SchiffGroesse = enumSchiffe.SHIP_Battleship_Size Then
                pSchifffeld(SetzSchiffY, SetzSchiffX) = enumSchiffe.SHIP_Battleship
            ElseIf SchiffGroesse = enumSchiffe.SHIP_Carrier_Size Then
                pSchifffeld(SetzSchiffY, SetzSchiffX) = enumSchiffe.SHIP_Carrier
            ElseIf SchiffGroesse = enumSchiffe.SHIP_Patrol_Size Then
                pSchifffeld(SetzSchiffY, SetzSchiffX) = enumSchiffe.SHIP_Patrol
            ElseIf SchiffGroesse = enumSchiffe.SHIP_Submarine_Size Then
                pSchifffeld(SetzSchiffY, SetzSchiffX) = enumSchiffe.SHIP_Submarine
            End If

            If SchiffRichtung = enumRichtung.Horizontal Then
                SetzSchiffX += 1
            Else
                SetzSchiffY += 1
            End If

        Next

        If SchiffGroesse = enumSchiffe.SHIP_Battleship_Size Then
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Battleship) += 1
        ElseIf SchiffGroesse = enumSchiffe.SHIP_Carrier_Size Then
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Carrier) += 1
        ElseIf SchiffGroesse = enumSchiffe.SHIP_Patrol_Size Then
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Patrol) += 1
        ElseIf SchiffGroesse = enumSchiffe.SHIP_Submarine_Size Then
            pSchiffAnzahlTyp(enumSchiffe.SHIP_Submarine) += 1
        End If

        pSchiffAnzahl += 1

    End Sub


    ' Prüfen ob noch ein Schiff zum beschiessen vorhanden ist
    Public Function NochSchiffeVorhaden() As Boolean
        NochSchiffeVorhaden = False
        For i As Integer = 0 To SpielfeldHoehe - 1
            For j As Integer = 0 To SpielfeldBreite - 1
                If pSpielfeld(i, j) = enumSpielfeld.BOARD_STATE_SHIP Then
                    NochSchiffeVorhaden = True
                End If
            Next
        Next
    End Function


    ' Auf ein Schiff feuern
    Public Function FeuerSchiff(ByVal Zeile As Integer, ByVal Spalte As Integer) As Integer

        FeuerSchiff = -2

        If pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE Then

            pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE
            FeuerSchiff = enumSpielfeld.BOARD_STATE_MINE

        ElseIf pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_SHIP Then

            pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_HIT
            FeuerSchiff = enumSpielfeld.BOARD_STATE_HIT

        ElseIf pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_BLANK Then

            pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MISS
            FeuerSchiff = enumSpielfeld.BOARD_STATE_MISS

        End If

    End Function

#End Region

#Region "Minen Logik"

    ' Mine auf dem Daten Spielfeld setzen
    Public Function SetzeMine(ByVal Zeile As Integer, ByVal Spalte As Integer) As Boolean

        If pSpielfeld(Zeile, Spalte) <> enumSpielfeld.BOARD_STATE_MINE _
            And pSpielfeld(Zeile, Spalte) <> enumSpielfeld.BOARD_STATE_MINE_HIT _
            And pSpielfeld(Zeile, Spalte) <> enumSpielfeld.BOARD_STATE_HIT Then

            If pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_SHIP Then

                pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE_HIT
                pMinenTreffer += 1

            Else
                pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE

            End If

            SetzeMine = True

        Else
            SetzeMine = False
        End If

    End Function


    Public Sub setMineGetroffen(ByVal Zeile As Integer, ByVal Spalte As Integer)
        pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE_HIT
    End Sub


    Public Function MineExplodieren(ByVal Zeile As Integer, ByVal Spalte As Integer) As Integer

        If pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_SHIP Then
            pMinenTreffer += 1
            pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_HIT
            MineExplodieren = enumSpielfeld.BOARD_STATE_HIT

        ElseIf pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_MINE Then
            MineExplodieren = enumSpielfeld.BOARD_STATE_MINE_HIT

        Else
            pSpielfeld(Zeile, Spalte) = enumSpielfeld.BOARD_STATE_HIT
            MineExplodieren = enumSpielfeld.BOARD_STATE_MISS
        End If

    End Function

#End Region

End Class
