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
    Public Const BildWasser As String = "Bilder\water.gif"
    Public Const BildDaneben As String = "Bilder\splash.gif"
    Public Const BildGetroffen As String = "Bilder\fire.gif"

    Public Const BildMine As String = "Bilder\minesweeper.png"

    Public Const BildSchiffPatrolHor As String = "Bilder\patrol.gif"
    Public Const BildSchiffPatrol As String = "Bilder\ShipPart\Patrol_"

    Public Const BildSchiffSubmarineHor As String = "Bilder\submarine.gif"
    Public Const BildSchiffSubmarine As String = "Bilder\ShipPart\Submarine_"

    Public Const BildSchiffBattleshipHor As String = "Bilder\battleship.gif"
    Public Const BildSchiffBattleship As String = "Bilder\ShipPart\Battleship_"

    Public Const BildSchiffCarrierHor As String = "Bilder\carrier.gif"
    Public Const BildSchiffCarrier As String = "Bilder\ShipPart\Carrier_"

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
