Module mod_GameEnum

    ' Linkes & Rechtes Spielfeld
    Public Enum enumSpieler
        ' Board Links
        PLAYER1 = 1
        ' Board Rechts
        PLAYER2 = 2
    End Enum

    ' Spielfeld Zustände
    Public Enum enumSpielfeld
        BOARD_STATE_BLANK = 10
        BOARD_STATE_SHIP = 11
        BOARD_STATE_MISS = 12
        BOARD_STATE_HIT = 13
        BOARD_STATE_MINE = 14
        BOARD_STATE_MINE_HIT = 15
    End Enum

    ' Schiffnummer und -größe
    Public Enum enumSchiffe
        SHIP_Patrol = 3
        SHIP_Patrol_Size = 2

        SHIP_Submarine = 2
        SHIP_Submarine_Size = 3

        SHIP_Battleship = 0
        SHIP_Battleship_Size = 4

        SHIP_Carrier = 1
        SHIP_Carrier_Size = 5
    End Enum

    ' Richtung
    Public Enum enumRichtung
        Horizontal = 0
        Vertikal = 1
    End Enum

    ' Computer Schwierigkeit
    Public Enum enumSchwierigkeit
        Leicht = 0
        Medium = 1
        Hardcore = 2
    End Enum

    ' Computer Angriffsrichtung
    Public Enum enumAngriffRichtung
        AnderesZiel = -1
        XPlusEins = 0
        XMinusEins = 1
        YPlusEins = 2
        YMinusEins = 3
    End Enum

    ' Zwei Spielmodis
    Public Enum enumSpielArt
        ComputerVSHuman = 0
        ComputerVSComputer = 1
    End Enum

End Module
