Public Class frm_GameOver

    Private frmGame As New frm_Spiel
    Private pGewinnerName As String

#Region "Property"

    WriteOnly Property GewinnerName
        Set(ByVal value)
            pGewinnerName = value
        End Set
    End Property

#End Region

#Region "Formular Events"

    ' Formular Load
    Private Sub frm_GameOVer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lb_GewinnerAusgabe.Text = pGewinnerName & " hat Gewonnen"
        Me.lb_Shots.Text = ShotCounter
        Me.lb_SpielZeit.Text = DateDiff(DateInterval.Minute, SpielStartZeit, SpielEndZeit) & " Minuten"
        CenterToScreen()
    End Sub

    ' Formular Close
    Private Sub frm_GameOver_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmGame = Nothing
    End Sub

#End Region

#Region "Formular Buttons"

    ' Hauptmenü Button
    Private Sub Hauptmenu() Handles btn_Hauptmenu.Click
        frm_Spiel.NeuesSpiel = False
        Me.Close()
    End Sub

    ' Neues Spiel Button
    Private Sub NeuesSpiel() Handles btnNeuesSpiel.Click
        frm_Spiel.NeuesSpiel = True
        Me.Close()
    End Sub

#End Region

End Class