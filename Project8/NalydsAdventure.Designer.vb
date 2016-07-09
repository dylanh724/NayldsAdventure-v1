<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NalydsAdventureForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NalydsAdventureForm))
        Me.Project8ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SubmitTextBox = New System.Windows.Forms.TextBox()
        Me.NorthButton = New System.Windows.Forms.Button()
        Me.SouthButton = New System.Windows.Forms.Button()
        Me.EastButton = New System.Windows.Forms.Button()
        Me.WestButton = New System.Windows.Forms.Button()
        Me.UpButton = New System.Windows.Forms.Button()
        Me.DownButton = New System.Windows.Forms.Button()
        Me.LookAroundButton = New System.Windows.Forms.Button()
        Me.HelpButton = New System.Windows.Forms.Button()
        Me.CurrentLocationButton = New System.Windows.Forms.Button()
        Me.GameLogTextBox = New System.Windows.Forms.TextBox()
        Me.MapButton = New System.Windows.Forms.Button()
        Me.UseItemButton = New System.Windows.Forms.Button()
        Me.UseSkillButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SubmitButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.InventoryListBox = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CurrentRoomLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MapPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SkillsListBox = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.MapPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SubmitTextBox
        '
        Me.SubmitTextBox.Location = New System.Drawing.Point(31, 436)
        Me.SubmitTextBox.Name = "SubmitTextBox"
        Me.SubmitTextBox.Size = New System.Drawing.Size(298, 20)
        Me.SubmitTextBox.TabIndex = 0
        Me.Project8ToolTip.SetToolTip(Me.SubmitTextBox, "Enter command or use the buttons to the right, including 'Help' for details on co" & _
        "mmands")
        '
        'NorthButton
        '
        Me.NorthButton.Location = New System.Drawing.Point(98, 47)
        Me.NorthButton.Name = "NorthButton"
        Me.NorthButton.Size = New System.Drawing.Size(37, 39)
        Me.NorthButton.TabIndex = 0
        Me.NorthButton.Text = "N"
        Me.Project8ToolTip.SetToolTip(Me.NorthButton, "Go North")
        Me.NorthButton.UseVisualStyleBackColor = True
        '
        'SouthButton
        '
        Me.SouthButton.Location = New System.Drawing.Point(98, 92)
        Me.SouthButton.Name = "SouthButton"
        Me.SouthButton.Size = New System.Drawing.Size(37, 39)
        Me.SouthButton.TabIndex = 1
        Me.SouthButton.Text = "S"
        Me.Project8ToolTip.SetToolTip(Me.SouthButton, "Go South")
        Me.SouthButton.UseVisualStyleBackColor = True
        '
        'EastButton
        '
        Me.EastButton.Location = New System.Drawing.Point(141, 70)
        Me.EastButton.Name = "EastButton"
        Me.EastButton.Size = New System.Drawing.Size(37, 39)
        Me.EastButton.TabIndex = 2
        Me.EastButton.Text = "E"
        Me.Project8ToolTip.SetToolTip(Me.EastButton, "Go East")
        Me.EastButton.UseVisualStyleBackColor = True
        '
        'WestButton
        '
        Me.WestButton.Location = New System.Drawing.Point(55, 70)
        Me.WestButton.Name = "WestButton"
        Me.WestButton.Size = New System.Drawing.Size(37, 39)
        Me.WestButton.TabIndex = 3
        Me.WestButton.Text = "W"
        Me.Project8ToolTip.SetToolTip(Me.WestButton, "Go West")
        Me.WestButton.UseVisualStyleBackColor = True
        '
        'UpButton
        '
        Me.UpButton.Location = New System.Drawing.Point(38, 21)
        Me.UpButton.Name = "UpButton"
        Me.UpButton.Size = New System.Drawing.Size(159, 22)
        Me.UpButton.TabIndex = 4
        Me.UpButton.Text = "Look Up / Go Up"
        Me.Project8ToolTip.SetToolTip(Me.UpButton, "Go Up")
        Me.UpButton.UseVisualStyleBackColor = True
        '
        'DownButton
        '
        Me.DownButton.Location = New System.Drawing.Point(38, 137)
        Me.DownButton.Name = "DownButton"
        Me.DownButton.Size = New System.Drawing.Size(159, 22)
        Me.DownButton.TabIndex = 5
        Me.DownButton.Text = "Look Down / Go Down"
        Me.Project8ToolTip.SetToolTip(Me.DownButton, "Go Down")
        Me.DownButton.UseVisualStyleBackColor = True
        '
        'LookAroundButton
        '
        Me.LookAroundButton.Location = New System.Drawing.Point(16, 68)
        Me.LookAroundButton.Name = "LookAroundButton"
        Me.LookAroundButton.Size = New System.Drawing.Size(85, 22)
        Me.LookAroundButton.TabIndex = 1
        Me.LookAroundButton.Text = "L&ook Around"
        Me.Project8ToolTip.SetToolTip(Me.LookAroundButton, "Look around the area for clues")
        Me.LookAroundButton.UseVisualStyleBackColor = True
        '
        'HelpButton
        '
        Me.HelpButton.Location = New System.Drawing.Point(16, 154)
        Me.HelpButton.Name = "HelpButton"
        Me.HelpButton.Size = New System.Drawing.Size(85, 20)
        Me.HelpButton.TabIndex = 3
        Me.HelpButton.Text = "Hel&p"
        Me.Project8ToolTip.SetToolTip(Me.HelpButton, "Need help with this game?")
        Me.HelpButton.UseVisualStyleBackColor = True
        '
        'CurrentLocationButton
        '
        Me.CurrentLocationButton.Location = New System.Drawing.Point(16, 25)
        Me.CurrentLocationButton.Name = "CurrentLocationButton"
        Me.CurrentLocationButton.Size = New System.Drawing.Size(85, 22)
        Me.CurrentLocationButton.TabIndex = 0
        Me.CurrentLocationButton.Text = "Loc&ation"
        Me.Project8ToolTip.SetToolTip(Me.CurrentLocationButton, "Where am I again?")
        Me.CurrentLocationButton.UseVisualStyleBackColor = True
        '
        'GameLogTextBox
        '
        Me.GameLogTextBox.Location = New System.Drawing.Point(31, 48)
        Me.GameLogTextBox.Multiline = True
        Me.GameLogTextBox.Name = "GameLogTextBox"
        Me.GameLogTextBox.ReadOnly = True
        Me.GameLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GameLogTextBox.Size = New System.Drawing.Size(387, 365)
        Me.GameLogTextBox.TabIndex = 20
        Me.Project8ToolTip.SetToolTip(Me.GameLogTextBox, "Click Here or below to type commands")
        '
        'MapButton
        '
        Me.MapButton.Enabled = False
        Me.MapButton.Location = New System.Drawing.Point(16, 111)
        Me.MapButton.Name = "MapButton"
        Me.MapButton.Size = New System.Drawing.Size(85, 22)
        Me.MapButton.TabIndex = 2
        Me.MapButton.Text = "&Map"
        Me.Project8ToolTip.SetToolTip(Me.MapButton, "Requires MAP item")
        Me.MapButton.UseVisualStyleBackColor = True
        '
        'UseItemButton
        '
        Me.UseItemButton.Enabled = False
        Me.UseItemButton.Location = New System.Drawing.Point(592, 317)
        Me.UseItemButton.Name = "UseItemButton"
        Me.UseItemButton.Size = New System.Drawing.Size(62, 21)
        Me.UseItemButton.TabIndex = 4
        Me.UseItemButton.Text = "Use I&tem"
        Me.Project8ToolTip.SetToolTip(Me.UseItemButton, "Requires MAP item")
        Me.UseItemButton.UseVisualStyleBackColor = True
        '
        'UseSkillButton
        '
        Me.UseSkillButton.Location = New System.Drawing.Point(592, 434)
        Me.UseSkillButton.Name = "UseSkillButton"
        Me.UseSkillButton.Size = New System.Drawing.Size(62, 22)
        Me.UseSkillButton.TabIndex = 24
        Me.UseSkillButton.Text = "Use S&kill"
        Me.Project8ToolTip.SetToolTip(Me.UseSkillButton, "Requires MAP item")
        Me.UseSkillButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Location = New System.Drawing.Point(16, 195)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(85, 20)
        Me.ExitButton.TabIndex = 14
        Me.ExitButton.Text = "E&xit (INVISIBLE)"
        Me.Project8ToolTip.SetToolTip(Me.ExitButton, "Exit Program (Game Data Will Be Lost!)")
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SubmitButton
        '
        Me.SubmitButton.Location = New System.Drawing.Point(343, 435)
        Me.SubmitButton.Name = "SubmitButton"
        Me.SubmitButton.Size = New System.Drawing.Size(75, 23)
        Me.SubmitButton.TabIndex = 1
        Me.SubmitButton.Text = "Su&bmit"
        Me.SubmitButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.UpButton)
        Me.GroupBox1.Controls.Add(Me.NorthButton)
        Me.GroupBox1.Controls.Add(Me.SouthButton)
        Me.GroupBox1.Controls.Add(Me.EastButton)
        Me.GroupBox1.Controls.Add(Me.DownButton)
        Me.GroupBox1.Controls.Add(Me.WestButton)
        Me.GroupBox1.Location = New System.Drawing.Point(442, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 181)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Directions"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.MapButton)
        Me.GroupBox2.Controls.Add(Me.CurrentLocationButton)
        Me.GroupBox2.Controls.Add(Me.LookAroundButton)
        Me.GroupBox2.Controls.Add(Me.HelpButton)
        Me.GroupBox2.Controls.Add(Me.ExitButton)
        Me.GroupBox2.Location = New System.Drawing.Point(442, 227)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(117, 229)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Commands"
        '
        'InventoryListBox
        '
        Me.InventoryListBox.FormattingEnabled = True
        Me.InventoryListBox.Location = New System.Drawing.Point(565, 243)
        Me.InventoryListBox.Name = "InventoryListBox"
        Me.InventoryListBox.Size = New System.Drawing.Size(117, 69)
        Me.InventoryListBox.TabIndex = 0
        Me.InventoryListBox.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Game Log:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(562, 227)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Inventory:"
        '
        'CurrentRoomLabel
        '
        Me.CurrentRoomLabel.AutoSize = True
        Me.CurrentRoomLabel.Location = New System.Drawing.Point(316, 27)
        Me.CurrentRoomLabel.Name = "CurrentRoomLabel"
        Me.CurrentRoomLabel.Size = New System.Drawing.Size(0, 13)
        Me.CurrentRoomLabel.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(222, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Current Room:"
        '
        'MapPictureBox
        '
        Me.MapPictureBox.Image = Global.Project8.My.Resources.Resources.map
        Me.MapPictureBox.Location = New System.Drawing.Point(31, 48)
        Me.MapPictureBox.Name = "MapPictureBox"
        Me.MapPictureBox.Size = New System.Drawing.Size(387, 365)
        Me.MapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MapPictureBox.TabIndex = 21
        Me.MapPictureBox.TabStop = False
        Me.MapPictureBox.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(562, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Skills:"
        '
        'SkillsListBox
        '
        Me.SkillsListBox.FormattingEnabled = True
        Me.SkillsListBox.Location = New System.Drawing.Point(565, 360)
        Me.SkillsListBox.Name = "SkillsListBox"
        Me.SkillsListBox.Size = New System.Drawing.Size(117, 69)
        Me.SkillsListBox.TabIndex = 22
        Me.SkillsListBox.TabStop = False
        '
        'NalydsAdventureForm
        '
        Me.AcceptButton = Me.SubmitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Project8.My.Resources.Resources.Fantasy_City_wallpaper1
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(704, 475)
        Me.ControlBox = False
        Me.Controls.Add(Me.UseSkillButton)
        Me.Controls.Add(Me.UseItemButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SkillsListBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CurrentRoomLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.InventoryListBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SubmitButton)
        Me.Controls.Add(Me.SubmitTextBox)
        Me.Controls.Add(Me.MapPictureBox)
        Me.Controls.Add(Me.GameLogTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NalydsAdventureForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nalyd`s Adventure v1.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.MapPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Project8ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents SubmitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SubmitButton As System.Windows.Forms.Button
    Friend WithEvents NorthButton As System.Windows.Forms.Button
    Friend WithEvents SouthButton As System.Windows.Forms.Button
    Friend WithEvents EastButton As System.Windows.Forms.Button
    Friend WithEvents WestButton As System.Windows.Forms.Button
    Friend WithEvents UpButton As System.Windows.Forms.Button
    Friend WithEvents DownButton As System.Windows.Forms.Button
    Friend WithEvents LookAroundButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents InventoryListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HelpButton As System.Windows.Forms.Button
    Friend WithEvents CurrentLocationButton As System.Windows.Forms.Button
    Friend WithEvents CurrentRoomLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GameLogTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MapButton As System.Windows.Forms.Button
    Friend WithEvents MapPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SkillsListBox As System.Windows.Forms.ListBox
    Friend WithEvents UseItemButton As System.Windows.Forms.Button
    Friend WithEvents UseSkillButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button

End Class
