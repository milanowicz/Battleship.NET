Module mod_Deklaration

    ' Start Formular angezeigte Spielwerte
    Public SpielfeldBreite As Integer = 30
    Public SpielfeldHoehe As Integer = 25
    Public SchiffAnzahl As Integer = 20
    Public SpielfeldMinen As Integer = 25
    Public SpielerName As String = "Spieler"
    Public SpielLevel As Integer = enumSchwierigkeit.Hardcore
    Public SpielDebugModus As Boolean

    ' Computer Delay
    Public Const KIvsKIDelay As Integer = 100

    ' Computer Namen
    Public Const ComputerName As String = "Computer"
    Public Const ComputerName1 As String = "1." & ComputerName
    Public Const ComputerName2 As String = "2." & ComputerName

    ' Computer Gegner Medium
    Public Const AngriffAnzahlMedium As Integer = 4


    ' Spiel Bilder
    Public Const SpielSchiffAnzahl As Integer = 4
    Public BildWasser = My.Resources.water
    Public BildDaneben = My.Resources.splash
    Public BildGetroffen = My.Resources.fire

    Public BildMine = My.Resources.minesweeper

    Public BildSchiffPatrolHor = My.Resources.patrol
    Public Const BildSchiffPatrol As String = "Patrol_"

    Public BildSchiffSubmarineHor = My.Resources.submarine
    Public Const BildSchiffSubmarine As String = "Submarine_"

    Public BildSchiffBattleshipHor = My.Resources.battleship
    Public Const BildSchiffBattleship As String = "Battleship_"

    Public BildSchiffCarrierHor = My.Resources.carrier
    Public Const BildSchiffCarrier As String = "Carrier_"

    ' Spielfeld Data Grid View Breite & Höhe
    Public Const SpaltenBreite As Integer = 30
    Public Const ZeilenHoehe As Integer = 30

    ' Spiel Stats
    Public ShotCounter As Integer

    ' Game Over Stats
    Public SpielArt As Integer
    Public SpielStartZeit As Date
    Public SpielEndZeit As Date
    Public SpielLaeuft As Boolean
    Public SpielVorbei As Boolean

End Module
