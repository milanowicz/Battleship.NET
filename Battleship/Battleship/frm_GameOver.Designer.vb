<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_GameOver
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_GameOver))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Hauptmenu = New System.Windows.Forms.Button()
        Me.lb_GewinnerAusgabe = New System.Windows.Forms.Label()
        Me.lbl111 = New System.Windows.Forms.Label()
        Me.lb_Shots = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_SpielZeit = New System.Windows.Forms.Label()
        Me.btnNeuesSpiel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(111, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 33)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Game Over"
        '
        'btn_Hauptmenu
        '
        Me.btn_Hauptmenu.Location = New System.Drawing.Point(263, 254)
        Me.btn_Hauptmenu.Name = "btn_Hauptmenu"
        Me.btn_Hauptmenu.Size = New System.Drawing.Size(126, 37)
        Me.btn_Hauptmenu.TabIndex = 2
        Me.btn_Hauptmenu.Text = "&Hauptmenü"
        Me.btn_Hauptmenu.UseVisualStyleBackColor = True
        '
        'lb_GewinnerAusgabe
        '
        Me.lb_GewinnerAusgabe.AutoSize = True
        Me.lb_GewinnerAusgabe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_GewinnerAusgabe.Location = New System.Drawing.Point(13, 97)
        Me.lb_GewinnerAusgabe.Name = "lb_GewinnerAusgabe"
        Me.lb_GewinnerAusgabe.Size = New System.Drawing.Size(0, 20)
        Me.lb_GewinnerAusgabe.TabIndex = 17
        '
        'lbl111
        '
        Me.lbl111.AutoSize = True
        Me.lbl111.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl111.Location = New System.Drawing.Point(13, 149)
        Me.lbl111.Name = "lbl111"
        Me.lbl111.Size = New System.Drawing.Size(148, 20)
        Me.lbl111.TabIndex = 18
        Me.lbl111.Text = "Anzahl Schüsse: "
        '
        'lb_Shots
        '
        Me.lb_Shots.AutoSize = True
        Me.lb_Shots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_Shots.Location = New System.Drawing.Point(153, 149)
        Me.lb_Shots.Name = "lb_Shots"
        Me.lb_Shots.Size = New System.Drawing.Size(0, 20)
        Me.lb_Shots.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(263, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 137)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Spiel Dauer: "
        '
        'lb_SpielZeit
        '
        Me.lb_SpielZeit.AutoSize = True
        Me.lb_SpielZeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_SpielZeit.Location = New System.Drawing.Point(119, 187)
        Me.lb_SpielZeit.Name = "lb_SpielZeit"
        Me.lb_SpielZeit.Size = New System.Drawing.Size(0, 20)
        Me.lb_SpielZeit.TabIndex = 22
        '
        'btnNeuesSpiel
        '
        Me.btnNeuesSpiel.Location = New System.Drawing.Point(17, 254)
        Me.btnNeuesSpiel.Name = "btnNeuesSpiel"
        Me.btnNeuesSpiel.Size = New System.Drawing.Size(126, 37)
        Me.btnNeuesSpiel.TabIndex = 1
        Me.btnNeuesSpiel.Text = "&Neues Spiel"
        Me.btnNeuesSpiel.UseVisualStyleBackColor = True
        '
        'frm_GameOver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNeuesSpiel)
        Me.Controls.Add(Me.lb_SpielZeit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lb_Shots)
        Me.Controls.Add(Me.lbl111)
        Me.Controls.Add(Me.lb_GewinnerAusgabe)
        Me.Controls.Add(Me.btn_Hauptmenu)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_GameOver"
        Me.Text = "Game Over"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_Hauptmenu As System.Windows.Forms.Button
    Friend WithEvents lb_GewinnerAusgabe As System.Windows.Forms.Label
    Friend WithEvents lbl111 As System.Windows.Forms.Label
    Friend WithEvents lb_Shots As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lb_SpielZeit As System.Windows.Forms.Label
    Friend WithEvents btnNeuesSpiel As System.Windows.Forms.Button
End Class
