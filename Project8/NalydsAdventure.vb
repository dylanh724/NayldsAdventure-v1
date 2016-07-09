Imports System.ComponentModel

'Program:       Nalyd`s Adventure v1.0 -- Text adventure game (Project 8)
'Programmer:    Dylan Hunt
'Date:          12/12/2011
'Class:         ITS128 - Paulding

Public Class NalydsAdventureForm

    'Public declarations for use within multiple functions/subs
    Dim RoomNameArray() As String = {"Damp Field", "River", "Outside Cavern", "Cavern Entrace", "Locked Room", "Mysterious Room"}
    Dim RoomDescriptionArray() As String =
        {
            "You find yourself in a damp patch of tall grass. The grainy texture of the field grass does not seem to bother you.",
            "You come across a rushing river. There is a sweet aroma within the mist of the humid air.",
            "You approach a rocky domain and immediately notice a narrow entrance to a cave. Something about this area feels vaguely familiar to you.",
            "You cautiously enter the cave. You hear the echoing creep of insects crawl along the outskirts of the walls. You come across a room still faintly lit from the outside and notice two doors, almost man-made."
        }
    Dim Room3TrapEnabledBoolean As Boolean
    Dim LookAroundArray() As String = {Room0(), Room1(), Room2(), Room3()}
    Dim InventoryArray() As String = {"(Slot 1 - Empty)", "(Slot 2 - Empty)", "(Slot 3 - Empty)", "(Slot 4 - Empty)", "(Slot 5 - Empty)"}
    Dim InventoryDescriptionArray() As String = {"", "", "", "", "", ""}
    Dim SkillsArray() As String = {"Detect Traps", "(Skill 2 - Empty)", "(Skill 3 - Empty)", "(Skill 4 - Empty)", "(Skill 5 - Empty)"}
    Dim SkillsDescriptionArray() As String = {" - A chance to detect/disarm traps.", "", "", "", ""}
    Dim CurrentRoomInteger As Integer
    Dim GoldenKeyEventBoolean As Boolean
    Dim Room3LeverEventBoolean As Boolean = True
    Dim PullLeverQuestionEventBoolean As Boolean
    Dim UsedGoldenKeyBoolean As Boolean
    Dim MapEventBoolean As Boolean = True
    Dim DroppedKeyBoolean As Boolean
    Dim HaveGoldenKeyInteger As Integer
    Dim UseGoldenKeyEastEventBoolean As Boolean
    Dim UseGoldenKeyNorthEventBoolean As Boolean
    Dim LockedDoorOpened As Boolean
    Dim AttemptInteger As Integer


    Private Sub GameNameForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Empty inventory
        For Each SingleInventoryString In InventoryArray
            InventoryListBox.Items.Add(SingleInventoryString)
        Next

        'Empty skills, except detect traps, set as default
        For Each SingleSkillString In SkillsArray
            SkillsListBox.Items.Add(SingleSkillString)
        Next
        SkillsListBox.SelectedIndex = 0

        'Intro text
        GameLogTextBox.Text = "Welcome to Nalyd`s Adventure v1.0!" + vbCrLf +
            "by Dylan Hunt (dylanh72@hawaii.edu)" + vbCrLf + vbCrLf +
            "HINT 1: Use <Look Around> (or type 'look') very often!" + vbCrLf +
            "HINT 2: You *must* use commands at some point!" + vbCrLf +
            "HINT 3: Click 'Help' on the right if stuck or for useful commands." + vbCrLf + vbCrLf +
            "*******************************************************************************" + vbCrLf

        'Display current room (0)
        CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)

        'Display current location text (0)
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You awaken in a damp patch of tall grass, muddled as to why you are here." + vbCrLf + "You feel dizzy." + vbCrLf

        'Focus
        SubmitTextBox.Focus()

    End Sub

    'Room 0 (START - Damp Field)
    Private Function Room0() As String
        Dim NewLookString As String
        NewLookString = "You faintly see a rock formation to the NORTH. The SOUTH and WEST are blocked off. To the EAST, you see a river."
        Return NewLookString

    End Function

    'Room 1 (River)
    Private Function Room1() As String
        Dim NewLookString As String
        NewLookString = "The intensity of the river blocks most of your paths to the NORTH and EAST. A formation of rock blocks the SOUTH." +
            "You see a tall, grassy field to the WEST." + vbCrLf +
            "You notice something with a reflective glare in the river at your feet."
        Return NewLookString

    End Function

    'Room 2 (Outside Cavern)
    Private Function Room2() As String
        Dim NewLookString As String
        NewLookString = "To the NORTH, a cave lies ahead, appearing dark and claustrophobic. A musty smell eminates from within. Rock formations block most directions. You see a tall, grassy field to the SOUTH." + vbCrLf +
            "Looking around further, you notice a rusty switch very high above you, but within reach."
        Return NewLookString

    End Function

    'Room 3 (Cave Entrance)
    Private Function Room3() As String
        Dim NewLookString As String
        NewLookString = "To the NORTH and EAST, you notice two doors. Upon further inspection, the NORTH door is actually a door that you can walk around. There appears to be no other side, however, the door is locked. A mysterious aura radiates from the lock." + vbCrLf +
            "The EAST door is "
        Return NewLookString

    End Function
    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        'Exit - Yes/No?
        Dim ResponseInteger As Integer
        ResponseInteger = MessageBox.Show("Are you sure you want to quit?" + vbCrLf +
                                          "All game data will be lost!",
                                          "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        If ResponseInteger = vbYes Then
            Me.Close()
        Else
            'Clear/focus
            SubmitTextBox.Clear()
            SubmitTextBox.Focus()
        End If

    End Sub

    Private Sub HelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpButton.Click
        'Display Help
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "************************************************************************" + vbCrLf + vbCrLf + "HELP:" + vbCrLf +
            "Click the directional buttons to navigate. Sometimes you won't be able to navigate certain directions" + vbCrLf +
            "Click 'Current Location' to state again where you are" + vbCrLf +
            "Click 'Look Around' to view detailed surounding information and possibly clues of where to go and where to look, or type 'look'" + vbCrLf +
            "Review your inventory - sometimes you may require an item to move forward" + vbCrLf +
            "Many commands are accepted:" + vbCrLf +
            "'u' up, 'd' down, 'n' north, 's' south, 'e' east, 'w' west," + vbCrLf +
            "'get/grab/take' (get key)," + vbCrLf +
            "'use' (use key)," + vbCrLf +
            "'inv' for detailed inventory list," + vbCrLf +
            "'Skills' for detailed skill list," + vbCrLf +
            "'inspect' (inspect writing [Coming Soon])," + vbCrLf +
            "'look' to look around," + vbCrLf +
            "'<skill name>' (detect traps)," + vbCrLf +
            "'map' to open/close map," + vbCrLf +
            "'loc' for current location," + vbCrLf +
            "'cls' clears the chat log" + vbCrLf +
            "'help' to call this window again" + vbCrLf +
            "Note: Commands are NOT case sensitive" + vbCrLf + vbCrLf +
            "************************************************************************" + vbCrLf

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub LookButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookAroundButton.Click
        'Look around - display #1
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You look around.."

        '**BROKEN - Why does it include the above look around statement in sleep? EVERYTHING sleeps, including code above..
        'Wait 0.5s 
        'Threading.Thread.Sleep(500)
        'Me.Update()

        'Look around - display #2
        Select Case CurrentRoomInteger
            'Key event - ensure different displays/activate event on look
            Case 2
                'If the lever has NOT been pulled
                If Room3LeverEventBoolean = True Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + vbCrLf

                Else
                    'If the lever HAS been pulled
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "To the NORTH, a cave lies ahead, appearing dark and claustrophobic." +
                        "A musty smell eminates from within. Rock formations block most directions. You see a tall, grassy field to the SOUTH." + vbCrLf +
                        "Above you, you see a lodged lever pulled down." + vbCrLf
                End If
            Case 3
                If DroppedKeyBoolean = True And MapEventBoolean = True And LockedDoorOpened = False Then
                    'Show map AND key on ground
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "locked with a basic locking mechanism." + vbCrLf +
                        "a golden KEY can be found on the ground beside you." + vbCrLf +
                        "You see a piece of paper on the ground. It appears to be a blood-stained MAP." + vbCrLf
                ElseIf DroppedKeyBoolean = False And MapEventBoolean = True And LockedDoorOpened = False Then
                    'Show ONLY map on ground
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "locked with a basic locking mechanism." + vbCrLf +
                    "You see a piece of paper on the ground. It appears to be a blood-stained MAP." + vbCrLf
                ElseIf DroppedKeyBoolean = True And MapEventBoolean = False And LockedDoorOpened = False Then
                    'Show ONLY key on ground
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "locked with a basic locking mechanism." + vbCrLf +
                        "a golden KEY can be found on the ground beside you." + vbCrLf
                ElseIf DroppedKeyBoolean = False And MapEventBoolean = False And LockedDoorOpened = False Then
                    'Show original script
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "locked with a basic locking mechanism." + vbCrLf

                    '*****************************
                    'If unlocked to east..
                ElseIf DroppedKeyBoolean = True And MapEventBoolean = True And LockedDoorOpened = True Then
                    'Show map AND key on ground + open door
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "UNLOCKED, with a golden key stuck inside a decorative lock." + vbCrLf +
                        "a golden KEY can be found on the ground beside you." + vbCrLf +
                        "You see a piece of paper on the ground. It appears to be a blood-stained MAP." + vbCrLf
                ElseIf DroppedKeyBoolean = False And MapEventBoolean = True And LockedDoorOpened = True Then
                    'Show ONLY map on ground + open door
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "UNLOCKED, with a golden key stuck inside a decorative lock.." + vbCrLf +
                    "You see a piece of paper on the ground. It appears to be a blood-stained MAP." + vbCrLf
                ElseIf DroppedKeyBoolean = True And MapEventBoolean = False And LockedDoorOpened = True Then
                    'Show ONLY key on ground + open door
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "UNLOCKED, with a golden key stuck inside a decorative lock.." + vbCrLf +
                        "a golden KEY can be found on the ground beside you." + vbCrLf
                ElseIf DroppedKeyBoolean = False And MapEventBoolean = False And LockedDoorOpened = True Then
                    'Show original script + open door
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + "UNLOCKED, with a golden key stuck inside a decorative lock.." + vbCrLf
                End If

            Case Else
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + LookAroundArray(CurrentRoomInteger) + vbCrLf
        End Select


        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub SubmitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
        Dim SuccessInteger As Integer
        Dim SubmitString As String = SubmitTextBox.Text
        Dim CounterInteger As Integer
        'Enable randomized numbers
        Randomize()

        '*COMMANDS*
        Select Case SubmitString.ToUpper
            Case "NORTH", "N"
                NorthButton.PerformClick()
            Case "SOUTH", "S"
                SouthButton.PerformClick()
            Case "EAST", "E"
                EastButton.PerformClick()
            Case "WEST", "W"
                WestButton.PerformClick()
            Case "UP", "U", "GO UP", "LOOK UP"
                UpButton.PerformClick()
            Case "DOWN", "D", "GO DOWN", "LOOK DOWN"
                DownButton.PerformClick()
            Case "HELP"
                HelpButton.PerformClick()
            Case "EXIT", "QUIT"
                ExitButton.PerformClick()
            Case "CLS", "CLEAR"
                GameLogTextBox.Clear()
            Case "INS", "INSPECT"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Inspect What..? [Coming Soon]"


            Case vbNull, ""
                '** BROKEN BELOW -- Why will this not bring up previous string when null/empty?
                '    'Bring up previous command when blank
                '    SubmitTextBox.Text = PreviousCommandString
                '    SubmitTextBox.Focus()
                '    SubmitTextBox.SelectAll()
                '    Exit Sub

            Case "USE KEY", "USE GOLDEN KEY", "UNLOCK DOOR"
                'Use key event (Room 3) for locked room (4) to the EAST
                If HaveGoldenKeyInteger = 1 And CurrentRoomInteger = 3 And UseGoldenKeyEastEventBoolean = True And UseGoldenKeyNorthEventBoolean = False Then
                    'If you have the key, you are in room 3, and you inspected the east door..
                    'Use key
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to use the golden KEY.." + vbCrLf +
                    "You insert the key into the rusted lock. You are required to use force to turn it.."

                    'GAME START (Code is on left/right case statements below)
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Which way should you force the key (Left/Right)?"

                    'Enable use of keys
                    AttemptInteger = 1

                ElseIf HaveGoldenKeyInteger = 1 And CurrentRoomInteger = 3 And UseGoldenKeyNorthEventBoolean = True And UseGoldenKeyEastEventBoolean = False Then
                    'Use key event (Room 3) for mysterious room (5) to the NORTH
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to use the golden KEY on the mysterious lock.." + vbCrLf +
                        "..." + vbCrLf +
                        "As you insert the key, the air fills with static as the door's lock begins to illuminate brightly. You snap your head back as you are KNOCKED BACK by a maelstrom of magical force!" + vbCrLf +
                        "You are knocked on the ground." + vbCrLf +
                        "You feel dizzy." + vbCrLf
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot do that." + vbCrLf
                End If

            Case "LEFT", "L"
                'Turn key event
                'If the event is active, you type in the correct answer for the 1st attempt..
                If UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 1 Then
                    'Success
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You turn the key to the left.."
                    'Go to attempt #2..
                    AttemptInteger = 2
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You hear a clicking sound. Which way should you force the key (Left/Right)?"
                ElseIf UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 2 Then
                    'Fail if triggered for attempt #2
                    'How do i make an if/else with and (and or)? Example: If boolean = true and room = 3 and (attempt = 2 or 3)
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to unlock the door." + vbCrLf
                    AttemptInteger = 0
                ElseIf UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 3 Then
                    'Fail if triggered for attempt #3
                    'How do i make an if/else with and (and or)? Example: If boolean = true and room = 3 and (attempt = 2 or 3)
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to unlock the door." + vbCrLf
                    AttemptInteger = 0
                ElseIf UseGoldenKeyEastEventBoolean = False Or Not CurrentRoomInteger = 3 Or AttemptInteger = 0 Then
                    'If used inproperly..
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot move left." + vbCrLf
                End If

            Case "RIGHT", "R"
                'Turn key event
                'If the event is active, you type in the correct answer for the 2nd attempt..
                If UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 2 Then
                    'Success
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You turn the key to the right.."
                    'Go to attempt #3 (final)..
                    AttemptInteger = 3
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You hear a satisfying clicking sound. Which way should you force the key (Left/Right)?"
                ElseIf UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 3 Then
                    'If the event is active, you type in the correct answer for the 3rd (final) attempt..
                    'SUCCESS - EVENT SUCCESS
                    'Unlock door
                    AttemptInteger = 0
                    UseGoldenKeyEastEventBoolean = False
                    LockedDoorOpened = True
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You have successfully unlocked the door!" + vbCrLf +
                        "The passage to the EAST is unlocked, but the key is stuck!" + vbCrLf +
                        "The golden KEY is removed from your inventory." + vbCrLf
                    'Remove key from inventory
                    InventoryArray(0) = "(Slot 1 - Empty)"
                    InventoryDescriptionArray(0) = ""
                    InventoryListBox.Items.Clear()
                    For Each SingleItemString In InventoryArray
                        InventoryListBox.Items.Add(SingleItemString)
                    Next
                    'Disable use item button if necessary
                    If InventoryArray(1) = "(Slot 2 - Empty)" Then
                        UseItemButton.Enabled = False
                    End If
                ElseIf UseGoldenKeyEastEventBoolean = True And CurrentRoomInteger = 3 And AttemptInteger = 1 Then
                    'Fail if attempt #1
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to unlock the door." + vbCrLf
                    AttemptInteger = 0
                ElseIf UseGoldenKeyEastEventBoolean = False Or Not CurrentRoomInteger = 3 Or AttemptInteger = 0 Then
                    'If used inproperly..
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot move right." + vbCrLf
                End If
            Case "INV", "INVENTORY"
                'Look at each item in inventory, list it, and list the description attached
                CounterInteger = 0
                For Each SingleItemString In InventoryArray
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + SingleItemString + InventoryDescriptionArray(CounterInteger)
                    CounterInteger += 1
                Next
                'Extra line after loop
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf
            Case "SKILL", "SKILLS", "SKILL LIST", "SKILLS LIST"
                'Look at each skill, list it, and list the description attached
                CounterInteger = 0
                For Each SingleSkillString In SkillsArray
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + SingleSkillString + SkillsDescriptionArray(CounterInteger)
                    CounterInteger += 1
                Next
                'Extra line after loop
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf
            Case "GET"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Get what..?" + vbCrLf
            Case "TAKE"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Take what..?" + vbCrLf
            Case "GRAB"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Grab what..?" + vbCrLf
            Case "DETECT TRAP", "DETECT TRAPS"
                SkillsListBox.SelectedIndex = 0
                UseItemButton.PerformClick()
            Case "USE", "USE ITEM"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Use what item..?" + vbCrLf
            Case "USE SKILL"
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "Use what skill..?" + vbCrLf
            Case "LOC", "LOCATION", "CURRENT LOCATION", "CURRENT LOC"
                CurrentLocationButton.PerformClick()
            Case "LOOK", "LOOK AROUND"
                LookAroundButton.PerformClick()
            Case "GET MAP", "GRAB MAP"
                If CurrentRoomInteger = 3 And MapEventBoolean = True Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You lean down and grab the blood-stained map, placing it in your inventory" + vbCrLf
                    'Add map to inventory
                    InventoryArray(1) = "Map"
                    InventoryDescriptionArray(1) = "A blood-stained map"
                    InventoryListBox.Items.Clear()
                    For Each SingleInventoryString In InventoryArray
                        InventoryListBox.Items.Add(SingleInventoryString)
                    Next
                    'Activate map button and disable further event
                    MapButton.Enabled = True
                    UseItemButton.Enabled = True
                    MapEventBoolean = False
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You see no map." + vbCrLf
                End If
            Case "MAP"
                If MapButton.Enabled = True Then
                    MapButton.PerformClick()
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You have no map.." + vbCrLf
                End If
            Case "CLOSE MAP"
                If MapButton.Enabled = True Then
                    If MapPictureBox.Visible = True Then
                        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You close your map." + vbCrLf
                        MapPictureBox.Visible = False
                    End If
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You have no map.." + vbCrLf
                End If
            Case "GET KEY", "GET GOLDEN KEY", "GRAB KEY", "GRAB GOLDEN KEY"
                'Room 1 (river) key event
                'If you do NOT have key, you have NOT received the key before, and your room is 1 (river)..
                If HaveGoldenKeyInteger = 0 And GoldenKeyEventBoolean = True And CurrentRoomInteger = 1 Then
                    'Attempt to pick up key (50% chance)
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to pick up the golden key.."
                    SuccessInteger = Int((2 * Rnd()) + 1)
                    'Did the player get it?
                    If SuccessInteger = 2 Then
                        'Success (2)
                        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You grasp the key firmly and place it in your inventory!" + vbCrLf

                        'Make sure you can't get key again
                        GoldenKeyEventBoolean = False
                        HaveGoldenKeyInteger = 1

                        'Add Golden Key to inventory
                        InventoryListBox.Items.Clear()
                        InventoryArray(0) = "Golden Key"
                        InventoryDescriptionArray(0) = " - A shiny, golden key."
                        For Each SingleInventoryString In InventoryArray
                            InventoryListBox.Items.Add(SingleInventoryString)
                        Next

                        'Enable the use of items
                        UseItemButton.Enabled = True

                    Else
                        'Failure (1)
                        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "The golden KEY slips through your fingers from the rushing water and splashes back into the river.." + vbCrLf +
                             "You see a golden KEY within reach." + vbCrLf
                    End If
                    '******************************
                    'Room 3 (Cave Entrance) key event
                    'If you DROPPED your key AND you are in room 3..

                ElseIf DroppedKeyBoolean = True And CurrentRoomInteger = 3 Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You pick up the golden KEY and place it in your inventory." + vbCrLf
                    'Make sure you can't get key again
                    DroppedKeyBoolean = False

                    'Add Golden Key to inventory
                    HaveGoldenKeyInteger = 1
                    InventoryListBox.Items.Clear()
                    InventoryArray(0) = "Golden Key"
                    InventoryDescriptionArray(0) = " - A shiny, golden key."
                    For Each SingleInventoryString In InventoryArray
                        InventoryListBox.Items.Add(SingleInventoryString)
                    Next

                    'Enable the use of items
                    UseItemButton.Enabled = True
                Else
                    'No key!
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You see no key." + vbCrLf
                End If
            Case "Y", "YES", "PULL LEVER", "PULL SWITCH", "PULL THE SWITCH", "PULL THE LEVER", "PULL IT DOWN", "PULL DOWN", "PULL IT", "PULL"
                If CurrentRoomInteger = 2 And Room3LeverEventBoolean = True And PullLeverQuestionEventBoolean = True Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You pull down on the lever. It barely moves. You put all your weight on pulling the lever down.. Success!" + vbCrLf +
                        "..." + vbCrLf +
                        "Nothing happens." + vbCrLf +
                        "You hear a faint noise of something tightening nearby.. It came from the cave." + vbCrLf
                    'Trap enabled
                    Room3TrapEnabledBoolean = True
                    'Disable the lever events
                    Room3LeverEventBoolean = False
                    'Disable the lever's yes/no event
                    PullLeverQuestionEventBoolean = False
                Else
                    'Huh?
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + SubmitString + ".." + vbCrLf +
                        "What do you mean by '" + SubmitString + "'?" + vbCrLf
                End If
            Case "NO"
                If CurrentRoomInteger = 2 And Room3LeverEventBoolean = True And PullLeverQuestionEventBoolean = True Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You do not pull the lever. You can always come back later." + vbCrLf
                    'Disable the lever's yes/no event
                    PullLeverQuestionEventBoolean = False
                Else
                    'Huh?
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + SubmitString + ".." + vbCrLf +
                        "What do you mean by '" + SubmitString + "'?" + vbCrLf
                End If
            Case Else
                'Display unrecognized command / highlight
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "'" + SubmitString + "'" + vbCrLf + "Unrecognized Command - Type HELP for assistance." + vbCrLf
                SubmitTextBox.Focus()
                SubmitTextBox.SelectAll()
        End Select

        'Save last command (Broken)
        'PreviousCommandString = SubmitTextBox.Text

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()



    End Sub

    Private Sub CurrentLocationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentLocationButton.Click
        'Display location
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You observe your surroundings.." + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub GameLogTextBox_focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameLogTextBox.GotFocus
        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub EastButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EastButton.Click
        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to go EAST.."

        Select Case CurrentRoomInteger
            Case 0
                'Room 0 >> Room 1
                CurrentRoomInteger = 1
                'Update the room name display
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf
            Case 3
                If LockedDoorOpened = False Then
                    'Room 0 >> BLOCKED (Locked Room)
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "A basic looking door is locked in this direction. You hear a distant growl in the halls beyond this door." + vbCrLf +
                        "You notice a golden emblem of a snake wrapped around a crescent moon surrounding the keyhole of the locked door." + vbCrLf
                    'Enable unlock if you use the key
                    UseGoldenKeyEastEventBoolean = True
                    UseGoldenKeyNorthEventBoolean = False
                Else
                    'Room 3 >> Room 4
                    CurrentRoomInteger = 4
                    'Update the room name display
                    CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)
                    'Show final end of demo box and exit
                    MessageBox.Show("Thank you for playing Nalyd's Adventure Demo v1.0!" + vbCrLf +
                                    "by Dylan Hunt (dylanh72@hawaii.edu)" + vbCrLf +
                                    "Look forward to future features, more rooms, better descriptions, and deeper gameplay in v2.0!" + vbCrLf +
                                    "Please press OK to exit the game and to automatically send all your credit card information to me to better fund my game.", "End of Demo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Case Else
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go EAST." + vbCrLf

        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub UpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpButton.Click
        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You look UP.."

        'Determine where you can go, depending on which room.
        Select Case CurrentRoomInteger
            Case 2
                'Room 2's trap lever (for room 3)
                If Room3LeverEventBoolean = True Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You are baffled as to why such a switch would be so high up, almost beyond reach. Who lives here..?" + vbCrLf +
                        "You reach the lever on your toes and grasp onto it. You are having second thoughts." + vbCrLf +
                        "Pull the lever (Yes/No)?"
                    PullLeverQuestionEventBoolean = True
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You see a lever pulled down. It will not budge." + vbCrLf
                End If

                'BLOCKED DIRECTION
            Case Else
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go UP. You see nothing." + vbCrLf
        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub WestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WestButton.Click
        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to go WEST.."

        'Determine where you can go, depending on which room.
        Select Case CurrentRoomInteger
            Case 1
                'Room 1 (River) >> Room 0 (START)
                CurrentRoomInteger = 0

                'Display current room (0)
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)

                'Display current location text (0)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf
            Case Else
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go WEST." + vbCrLf
        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub SouthButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SouthButton.Click
        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to go SOUTH.."

        'Determine where you can go, depending on which room.
        Select Case CurrentRoomInteger
            Case 2
                'Room 2 (outside cave) >> Room 0 (START)
                CurrentRoomInteger = 0

                'Display current room (0)
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)

                'Display current location text (0)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf
            Case 3
                'Room 3 (Cave Entrance) >> Room 2 (Outside Cave)
                CurrentRoomInteger = 2
                'Update the room name display
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf
            Case Else
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go SOUTH." + vbCrLf
        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub NorthButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorthButton.Click
        'Enable randomized numbers
        Dim SuccessInteger As Integer
        Randomize()

        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to go NORTH.."

        'Determine where you can go, depending on which room.
        Select Case CurrentRoomInteger
            Case 0
                'Room 1 >> Room 2 (Outside Cave)
                CurrentRoomInteger = 2
                'Update the room name display
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf

            Case 2
                'Room 2 >> Room 3
                CurrentRoomInteger = 3
                'Update the room name display
                CurrentRoomLabel.Text = RoomNameArray(CurrentRoomInteger)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + RoomDescriptionArray(CurrentRoomInteger) + vbCrLf

                'Was trap triggered?
                If Room3TrapEnabledBoolean = True Then
                    'Disable future traps
                    Room3TrapEnabledBoolean = False
                    'Trap trigger text
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "As you walk inside the room, you feel a fastened string crack against your shin.." + vbCrLf +
                        "You triggered a TRAP!" + vbCrLf +
                        "The rattle of a mechanical latch releasing snaps as an arrow roars directly at you!" + vbCrLf + "..."
                    'Chance to dodge - 50% chance, 1 = fail, 2 = success
                    SuccessInteger = Int((2 * Rnd()) + 1)
                    If SuccessInteger = 1 Then
                        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to dodge the arrow!" + vbCrLf +
                            "You writhe in pain as a small arrow pierces through your shoulder, clearing straight through." + vbCrLf +
                            "You are bleeding, but you feel okay." + vbCrLf
                        'If you have the golden key.. drop it
                        If HaveGoldenKeyInteger = 1 Then
                            DroppedKeyBoolean = True
                            HaveGoldenKeyInteger = 0
                            GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You dropped your golden KEY!" + vbCrLf
                            'Remove golden key from inventory and place on ground
                            InventoryArray(0) = "(Slot 1 - Empty)"
                            'If no items, disable button. In future, add a loop to check
                            If InventoryArray(1) = "(Slot 2 - Empty)" Then
                                UseItemButton.Enabled = False
                            End If
                            InventoryDescriptionArray(0) = ""
                            InventoryListBox.Items.Clear()
                            For Each SingleItem In InventoryArray
                                InventoryListBox.Items.Add(SingleItem)
                            Next
                        End If
                    Else
                        'Success!
                        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "The arrow whistles past you as you successfully dodge the arrow, your body hugging flat against the cave walls." + vbCrLf +
                        "You feel lucky, with the exception of several bugs now creeping up your body from romancing the wall." + vbCrLf
                    End If

                End If

            Case 3
                'Room 2 >> Blocked (mysterious room locked - not unlockable in v1.0)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go NORTH, as a mysterious door blocks your path to the NORTH. Although the door appears to not be attached to any wall, there is nothing behind the door but rock." + vbCrLf +
                        "A magical aura radiates from within the lock" + vbCrLf
                UseGoldenKeyNorthEventBoolean = True
                UseGoldenKeyEastEventBoolean = False
            Case Else
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go NORTH." + vbCrLf
        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub DownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownButton.Click
        'Initial text
        GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You look DOWN.."

        'Determine where you can go, depending on which room.
        Select Case CurrentRoomInteger
            Case 0
                'Disable user to get the golden key if user just left room 1 (river)
                GoldenKeyEventBoolean = False
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go DOWN." + vbCrLf
            Case 1
                'Should golden key event trigger?
                If HaveGoldenKeyInteger = 0 Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You look closer at the reflective glare.." + vbCrLf +
                        "You see a golden KEY within reach." + vbCrLf
                    'Enable user to get the golden key
                    GoldenKeyEventBoolean = True
                Else
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go DOWN. You see nothing."
                End If
            Case Else
                'BLOCKED DIRECTION
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You cannot go DOWN." + vbCrLf

        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub MapButton_Click(sender As System.Object, e As System.EventArgs) Handles MapButton.Click
        'Display map
        If MapPictureBox.Visible = False Then
            MapPictureBox.Visible = True
            MapButton.Text = "Close Map"
            GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You open your map from your inventory." + vbCrLf
        Else
            MapPictureBox.Visible = False
            MapButton.Text = "Map"
            GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You close your map." + vbCrLf
        End If

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()
    End Sub

    Private Sub UseSkillButton_Click(sender As System.Object, e As System.EventArgs) Handles UseSkillButton.Click
        Dim SuccessInteger As Integer
        'Enable randomized numbers
        Randomize()

        'Detect traps (50% chance, 1 = fail, 2 = success)
        SuccessInteger = Int((2 * Rnd()) + 1)
        If SkillsListBox.SelectedIndex = 0 Then
            GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You attempt to detect any traps in the room.."
            'ROOM 3 TRAP - Arrow (Disarm in Room 2)
            If CurrentRoomInteger = 2 And Room3TrapEnabledBoolean = True Then
                'Success
                If SuccessInteger = 2 Then
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You detected a trap!" + vbCrLf +
                        "You carefully remove the wire trap at your feet at the cave entrance." +
                        "You notice a dusty hole in the wall ahead of you with the tip of an arrow lodged securely." + vbCrLf
                    Room3TrapEnabledBoolean = False
                Else
                    'Fail
                    GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to detect any traps." + vbCrLf
                End If
            Else
                'No traps at all in this room (fail)
                GameLogTextBox.Text = GameLogTextBox.Text + vbCrLf + "You failed to detect any traps." + vbCrLf
            End If
        End If

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()

    End Sub

    Private Sub UseItemButton_Click(sender As System.Object, e As System.EventArgs) Handles UseItemButton.Click
        Select Case InventoryListBox.SelectedIndex
            'Golden Key
            Case 0
                SubmitTextBox.Text = "use key"
                SubmitButton.PerformClick()
            Case 1
                'Map
                MapButton.PerformClick()
        End Select

        'Scroll down
        GameLogTextBox.Focus()
        GameLogTextBox.ScrollToCaret()

        'Clear/focus
        SubmitTextBox.Clear()
        SubmitTextBox.Focus()
    End Sub
End Class
