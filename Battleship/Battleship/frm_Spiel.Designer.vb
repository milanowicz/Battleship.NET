<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Spiel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Spiel))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.SpielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuesSpielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpielBeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpielVerlassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.cb_Computer = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_GameLevel = New System.Windows.Forms.ComboBox()
        Me.txt_MinenAnzahl = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cb_SchiffeSetzen = New System.Windows.Forms.CheckBox()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.cb_Debug = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_SchiffAnzahl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_SpielfeldHoehe = New System.Windows.Forms.TextBox()
        Me.txt_SpielfeldBreite = New System.Windows.Forms.TextBox()
        Me.txt_SpielerName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Speichern = New System.Windows.Forms.Button()
        Me.PanelGame = New System.Windows.Forms.Panel()
        Me.PanelSchiffe = New System.Windows.Forms.Panel()
        Me.btnSchiffeReset = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbVertikal = New System.Windows.Forms.RadioButton()
        Me.cbHorizontal = New System.Windows.Forms.RadioButton()
        Me.txt_SpielStarten = New System.Windows.Forms.Button()
        Me.dgv_SchiffBilder = New System.Windows.Forms.DataGridView()
        Me.SchiffBild = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgv_SpielAusgabe = New System.Windows.Forms.DataGridView()
        Me.dgv_BoardRight = New System.Windows.Forms.DataGridView()
        Me.dgv_BoardLeft = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        Me.PanelGame.SuspendLayout()
        Me.PanelSchiffe.SuspendLayout()
        CType(Me.dgv_SchiffBilder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_SpielAusgabe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_BoardRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_BoardLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsl_Status, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1043, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsl_Status
        '
        Me.tsl_Status.Name = "tsl_Status"
        Me.tsl_Status.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpielToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1043, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'SpielToolStripMenuItem
        '
        Me.SpielToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuesSpielToolStripMenuItem, Me.SpielBeendenToolStripMenuItem, Me.SpielVerlassenToolStripMenuItem})
        Me.SpielToolStripMenuItem.Name = "SpielToolStripMenuItem"
        Me.SpielToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.SpielToolStripMenuItem.Text = "&Spiel"
        '
        'NeuesSpielToolStripMenuItem
        '
        Me.NeuesSpielToolStripMenuItem.Name = "NeuesSpielToolStripMenuItem"
        Me.NeuesSpielToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.NeuesSpielToolStripMenuItem.Text = "&Neues Spiel"
        '
        'SpielBeendenToolStripMenuItem
        '
        Me.SpielBeendenToolStripMenuItem.Name = "SpielBeendenToolStripMenuItem"
        Me.SpielBeendenToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SpielBeendenToolStripMenuItem.Text = "Partie &Beenden"
        '
        'SpielVerlassenToolStripMenuItem
        '
        Me.SpielVerlassenToolStripMenuItem.Name = "SpielVerlassenToolStripMenuItem"
        Me.SpielVerlassenToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SpielVerlassenToolStripMenuItem.Text = "Spiel &Verlassen"
        '
        'PanelMenu
        '
        Me.PanelMenu.Controls.Add(Me.cb_Computer)
        Me.PanelMenu.Controls.Add(Me.Label13)
        Me.PanelMenu.Controls.Add(Me.Label12)
        Me.PanelMenu.Controls.Add(Me.cmb_GameLevel)
        Me.PanelMenu.Controls.Add(Me.txt_MinenAnzahl)
        Me.PanelMenu.Controls.Add(Me.Label10)
        Me.PanelMenu.Controls.Add(Me.Label8)
        Me.PanelMenu.Controls.Add(Me.cb_SchiffeSetzen)
        Me.PanelMenu.Controls.Add(Me.btn_Exit)
        Me.PanelMenu.Controls.Add(Me.cb_Debug)
        Me.PanelMenu.Controls.Add(Me.Label7)
        Me.PanelMenu.Controls.Add(Me.txt_SchiffAnzahl)
        Me.PanelMenu.Controls.Add(Me.Label5)
        Me.PanelMenu.Controls.Add(Me.txt_SpielfeldHoehe)
        Me.PanelMenu.Controls.Add(Me.txt_SpielfeldBreite)
        Me.PanelMenu.Controls.Add(Me.txt_SpielerName)
        Me.PanelMenu.Controls.Add(Me.Label4)
        Me.PanelMenu.Controls.Add(Me.Label3)
        Me.PanelMenu.Controls.Add(Me.Label6)
        Me.PanelMenu.Controls.Add(Me.Label2)
        Me.PanelMenu.Controls.Add(Me.Label1)
        Me.PanelMenu.Controls.Add(Me.btn_Speichern)
        Me.PanelMenu.Location = New System.Drawing.Point(12, 27)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(434, 237)
        Me.PanelMenu.TabIndex = 3
        '
        'cb_Computer
        '
        Me.cb_Computer.AutoSize = True
        Me.cb_Computer.Location = New System.Drawing.Point(195, 98)
        Me.cb_Computer.Name = "cb_Computer"
        Me.cb_Computer.Size = New System.Drawing.Size(15, 14)
        Me.cb_Computer.TabIndex = 4
        Me.cb_Computer.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(175, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "KI vs. KI"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(227, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 16)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Game Play"
        '
        'cmbGameLevel
        '
        Me.cmb_GameLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_GameLevel.Location = New System.Drawing.Point(215, 152)
        Me.cmb_GameLevel.Name = "cmbGameLevel"
        Me.cmb_GameLevel.Size = New System.Drawing.Size(103, 21)
        Me.cmb_GameLevel.TabIndex = 10
        '
        'txt_MinenAnzahl
        '
        Me.txt_MinenAnzahl.Location = New System.Drawing.Point(113, 152)
        Me.txt_MinenAnzahl.Name = "txt_MinenAnzahl"
        Me.txt_MinenAnzahl.Size = New System.Drawing.Size(83, 20)
        Me.txt_MinenAnzahl.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(110, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Minen Anzahl"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(233, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Schiffe setzen"
        '
        'cb_SchiffeSetzen
        '
        Me.cb_SchiffeSetzen.AutoSize = True
        Me.cb_SchiffeSetzen.Location = New System.Drawing.Point(260, 98)
        Me.cb_SchiffeSetzen.Name = "cb_SchiffeSetzen"
        Me.cb_SchiffeSetzen.Size = New System.Drawing.Size(15, 14)
        Me.cb_SchiffeSetzen.TabIndex = 5
        Me.cb_SchiffeSetzen.UseVisualStyleBackColor = True
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(300, 196)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(110, 31)
        Me.btn_Exit.TabIndex = 12
        Me.btn_Exit.Text = "&Beenden"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'cb_Debug
        '
        Me.cb_Debug.AutoSize = True
        Me.cb_Debug.Location = New System.Drawing.Point(134, 98)
        Me.cb_Debug.Name = "cb_Debug"
        Me.cb_Debug.Size = New System.Drawing.Size(15, 14)
        Me.cb_Debug.TabIndex = 3
        Me.cb_Debug.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(113, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Debug"
        '
        'txt_SchiffAnzahl
        '
        Me.txt_SchiffAnzahl.Location = New System.Drawing.Point(12, 152)
        Me.txt_SchiffAnzahl.Name = "txt_SchiffAnzahl"
        Me.txt_SchiffAnzahl.Size = New System.Drawing.Size(88, 20)
        Me.txt_SchiffAnzahl.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Schiff Anzahl"
        '
        'txt_SpielfeldHoehe
        '
        Me.txt_SpielfeldHoehe.Location = New System.Drawing.Point(330, 152)
        Me.txt_SpielfeldHoehe.Name = "txt_SpielfeldHoehe"
        Me.txt_SpielfeldHoehe.Size = New System.Drawing.Size(92, 20)
        Me.txt_SpielfeldHoehe.TabIndex = 7
        '
        'txt_SpielfeldBreite
        '
        Me.txt_SpielfeldBreite.Location = New System.Drawing.Point(330, 95)
        Me.txt_SpielfeldBreite.Name = "txt_SpielfeldBreite"
        Me.txt_SpielfeldBreite.Size = New System.Drawing.Size(92, 20)
        Me.txt_SpielfeldBreite.TabIndex = 6
        '
        'txt_SpielerName
        '
        Me.txt_SpielerName.Location = New System.Drawing.Point(12, 95)
        Me.txt_SpielerName.Name = "txt_SpielerName"
        Me.txt_SpielerName.Size = New System.Drawing.Size(88, 20)
        Me.txt_SpielerName.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(327, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Spielfeld Höhe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Spielfeld Breite"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(38, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(350, 33)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Battleship Einstellungen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 33)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Battleship Einstellungen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Spieler Name"
        '
        'btn_Speichern
        '
        Me.btn_Speichern.Location = New System.Drawing.Point(21, 196)
        Me.btn_Speichern.Name = "btn_Speichern"
        Me.btn_Speichern.Size = New System.Drawing.Size(272, 32)
        Me.btn_Speichern.TabIndex = 1
        Me.btn_Speichern.Text = "&Spiel starten mit den Einstellungen"
        Me.btn_Speichern.UseVisualStyleBackColor = True
        '
        'PanelGame
        '
        Me.PanelGame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelGame.Controls.Add(Me.PanelSchiffe)
        Me.PanelGame.Controls.Add(Me.dgv_SpielAusgabe)
        Me.PanelGame.Controls.Add(Me.dgv_BoardRight)
        Me.PanelGame.Controls.Add(Me.dgv_BoardLeft)
        Me.PanelGame.Location = New System.Drawing.Point(0, 27)
        Me.PanelGame.Name = "PanelGame"
        Me.PanelGame.Size = New System.Drawing.Size(1043, 530)
        Me.PanelGame.TabIndex = 4
        Me.PanelGame.Visible = False
        '
        'PanelSchiffe
        '
        Me.PanelSchiffe.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelSchiffe.Controls.Add(Me.btnSchiffeReset)
        Me.PanelSchiffe.Controls.Add(Me.Label11)
        Me.PanelSchiffe.Controls.Add(Me.cbVertikal)
        Me.PanelSchiffe.Controls.Add(Me.cbHorizontal)
        Me.PanelSchiffe.Controls.Add(Me.txt_SpielStarten)
        Me.PanelSchiffe.Controls.Add(Me.dgv_SchiffBilder)
        Me.PanelSchiffe.Controls.Add(Me.Label9)
        Me.PanelSchiffe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelSchiffe.Location = New System.Drawing.Point(141, 34)
        Me.PanelSchiffe.Name = "PanelSchiffe"
        Me.PanelSchiffe.Size = New System.Drawing.Size(250, 285)
        Me.PanelSchiffe.TabIndex = 3
        '
        'btnSchiffeReset
        '
        Me.btnSchiffeReset.Location = New System.Drawing.Point(160, 245)
        Me.btnSchiffeReset.Name = "btnSchiffeReset"
        Me.btnSchiffeReset.Size = New System.Drawing.Size(75, 23)
        Me.btnSchiffeReset.TabIndex = 34
        Me.btnSchiffeReset.Text = "&Reset"
        Me.btnSchiffeReset.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(49, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 20)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Schiff Richtung"
        '
        'cbVertikal
        '
        Me.cbVertikal.AutoSize = True
        Me.cbVertikal.Location = New System.Drawing.Point(138, 186)
        Me.cbVertikal.Name = "cbVertikal"
        Me.cbVertikal.Size = New System.Drawing.Size(60, 17)
        Me.cbVertikal.TabIndex = 32
        Me.cbVertikal.TabStop = True
        Me.cbVertikal.Text = "Vertikal"
        Me.cbVertikal.UseVisualStyleBackColor = True
        '
        'cbHorizontal
        '
        Me.cbHorizontal.AutoSize = True
        Me.cbHorizontal.Location = New System.Drawing.Point(41, 186)
        Me.cbHorizontal.Name = "cbHorizontal"
        Me.cbHorizontal.Size = New System.Drawing.Size(72, 17)
        Me.cbHorizontal.TabIndex = 31
        Me.cbHorizontal.TabStop = True
        Me.cbHorizontal.Text = "Horizontal"
        Me.cbHorizontal.UseVisualStyleBackColor = True
        '
        'txt_SpielStarten
        '
        Me.txt_SpielStarten.Location = New System.Drawing.Point(14, 245)
        Me.txt_SpielStarten.Name = "txt_SpielStarten"
        Me.txt_SpielStarten.Size = New System.Drawing.Size(139, 23)
        Me.txt_SpielStarten.TabIndex = 30
        Me.txt_SpielStarten.Text = "&Spiel starten"
        Me.txt_SpielStarten.UseVisualStyleBackColor = True
        '
        'dgv_SchiffBilder
        '
        Me.dgv_SchiffBilder.AllowUserToAddRows = False
        Me.dgv_SchiffBilder.AllowUserToDeleteRows = False
        Me.dgv_SchiffBilder.AllowUserToResizeColumns = False
        Me.dgv_SchiffBilder.AllowUserToResizeRows = False
        Me.dgv_SchiffBilder.BackgroundColor = System.Drawing.SystemColors.Highlight
        Me.dgv_SchiffBilder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_SchiffBilder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SchiffBilder.ColumnHeadersVisible = False
        Me.dgv_SchiffBilder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SchiffBild})
        Me.dgv_SchiffBilder.Location = New System.Drawing.Point(14, 46)
        Me.dgv_SchiffBilder.MultiSelect = False
        Me.dgv_SchiffBilder.Name = "dgv_SchiffBilder"
        Me.dgv_SchiffBilder.ReadOnly = True
        Me.dgv_SchiffBilder.RowHeadersVisible = False
        Me.dgv_SchiffBilder.RowHeadersWidth = 200
        Me.dgv_SchiffBilder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_SchiffBilder.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv_SchiffBilder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_SchiffBilder.Size = New System.Drawing.Size(221, 90)
        Me.dgv_SchiffBilder.TabIndex = 29
        '
        'SchiffBild
        '
        Me.SchiffBild.HeaderText = "Column1"
        Me.SchiffBild.Name = "SchiffBild"
        Me.SchiffBild.ReadOnly = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(87, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 20)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Schiffe"
        '
        'dgv_SpielAusgabe
        '
        Me.dgv_SpielAusgabe.AllowUserToAddRows = False
        Me.dgv_SpielAusgabe.AllowUserToDeleteRows = False
        Me.dgv_SpielAusgabe.AllowUserToResizeColumns = False
        Me.dgv_SpielAusgabe.AllowUserToResizeRows = False
        Me.dgv_SpielAusgabe.BackgroundColor = System.Drawing.Color.Gray
        Me.dgv_SpielAusgabe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_SpielAusgabe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SpielAusgabe.ColumnHeadersVisible = False
        Me.dgv_SpielAusgabe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgv_SpielAusgabe.Location = New System.Drawing.Point(12, 419)
        Me.dgv_SpielAusgabe.Margin = New System.Windows.Forms.Padding(5, 30, 5, 3)
        Me.dgv_SpielAusgabe.MultiSelect = False
        Me.dgv_SpielAusgabe.Name = "dgv_SpielAusgabe"
        Me.dgv_SpielAusgabe.ReadOnly = True
        Me.dgv_SpielAusgabe.RowHeadersVisible = False
        Me.dgv_SpielAusgabe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_SpielAusgabe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_SpielAusgabe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_SpielAusgabe.ShowCellToolTips = False
        Me.dgv_SpielAusgabe.Size = New System.Drawing.Size(1017, 111)
        Me.dgv_SpielAusgabe.TabIndex = 2
        '
        'dgv_BoardRight
        '
        Me.dgv_BoardRight.AllowDrop = True
        Me.dgv_BoardRight.AllowUserToAddRows = False
        Me.dgv_BoardRight.AllowUserToDeleteRows = False
        Me.dgv_BoardRight.AllowUserToResizeColumns = False
        Me.dgv_BoardRight.AllowUserToResizeRows = False
        Me.dgv_BoardRight.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_BoardRight.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dgv_BoardRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_BoardRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_BoardRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgv_BoardRight.Location = New System.Drawing.Point(537, 30)
        Me.dgv_BoardRight.MultiSelect = False
        Me.dgv_BoardRight.Name = "dgv_BoardRight"
        Me.dgv_BoardRight.ReadOnly = True
        Me.dgv_BoardRight.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv_BoardRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_BoardRight.ShowCellToolTips = False
        Me.dgv_BoardRight.ShowEditingIcon = False
        Me.dgv_BoardRight.Size = New System.Drawing.Size(492, 384)
        Me.dgv_BoardRight.TabIndex = 1
        '
        'dgv_BoardLeft
        '
        Me.dgv_BoardLeft.AllowUserToAddRows = False
        Me.dgv_BoardLeft.AllowUserToDeleteRows = False
        Me.dgv_BoardLeft.AllowUserToResizeColumns = False
        Me.dgv_BoardLeft.AllowUserToResizeRows = False
        Me.dgv_BoardLeft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_BoardLeft.BackgroundColor = System.Drawing.SystemColors.MenuBar
        Me.dgv_BoardLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_BoardLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_BoardLeft.Cursor = System.Windows.Forms.Cursors.Cross
        Me.dgv_BoardLeft.Location = New System.Drawing.Point(12, 30)
        Me.dgv_BoardLeft.MultiSelect = False
        Me.dgv_BoardLeft.Name = "dgv_BoardLeft"
        Me.dgv_BoardLeft.ReadOnly = True
        Me.dgv_BoardLeft.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv_BoardLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_BoardLeft.ShowCellToolTips = False
        Me.dgv_BoardLeft.ShowEditingIcon = False
        Me.dgv_BoardLeft.Size = New System.Drawing.Size(492, 384)
        Me.dgv_BoardLeft.TabIndex = 0
        '
        'frm_Spiel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1043, 582)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.PanelGame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "frm_Spiel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battleship"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenu.PerformLayout()
        Me.PanelGame.ResumeLayout(False)
        Me.PanelSchiffe.ResumeLayout(False)
        Me.PanelSchiffe.PerformLayout()
        CType(Me.dgv_SchiffBilder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_SpielAusgabe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_BoardRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_BoardLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents SpielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuesSpielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpielVerlassenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelMenu As System.Windows.Forms.Panel
    Friend WithEvents PanelGame As System.Windows.Forms.Panel
    Friend WithEvents dgv_BoardLeft As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_BoardRight As System.Windows.Forms.DataGridView
    Friend WithEvents txt_SchiffAnzahl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_SpielfeldHoehe As System.Windows.Forms.TextBox
    Friend WithEvents txt_SpielfeldBreite As System.Windows.Forms.TextBox
    Friend WithEvents txt_SpielerName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Speichern As System.Windows.Forms.Button
    Friend WithEvents SpielBeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgv_SpielAusgabe As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_Debug As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cb_SchiffeSetzen As System.Windows.Forms.CheckBox
    Friend WithEvents PanelSchiffe As System.Windows.Forms.Panel
    Friend WithEvents dgv_SchiffBilder As System.Windows.Forms.DataGridView
    Friend WithEvents SchiffBild As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_MinenAnzahl As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_SpielStarten As System.Windows.Forms.Button
    Friend WithEvents btnSchiffeReset As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbVertikal As System.Windows.Forms.RadioButton
    Friend WithEvents cbHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_GameLevel As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Computer As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

End Class
