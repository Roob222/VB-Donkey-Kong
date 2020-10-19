
Public Class Form1
    Public Declare Sub Play Lib "winmm.dll" Alias "mciExecute" (ByVal Command As String)

    Dim mspeed As Point
    Dim mfloattime As Integer = 21
    Dim ladders(5) As PictureBox
    Dim mpics(15) As Image
    Dim mariopics(15) As Image
    Dim luigipics(15) As Image
    Dim mpicnum As Integer
    Dim manimatecounter As Integer
    Dim manimatedelay As Integer = 3
    Dim mfacingleft As Boolean
    Dim mclimbing As Boolean
    Dim hpics(4) As Image
    Dim hammerdown As Boolean
    Dim lives As Integer = 2
    Dim leveltime As Integer


    Public Const numbarrels As Integer = 30
    Dim barrels(numbarrels) As PictureBox
    Dim bspeed(numbarrels) As Point
    Dim bfloattime(numbarrels) As Integer
    Dim bpics(3) As Image
    Dim bpicnum(numbarrels) As Integer
    Dim banimatedelay As Integer
    Dim bfacingleft As Boolean
    Dim banimatecounter As Integer = 3
    Dim numMovingBarrels As Integer
    Dim barrelcounter As Integer = -50
    Dim hashammer As Boolean
    Dim hammertime As Integer = 290


    Dim DKanimatecounter As Integer
    Dim DKanimatedelay As Integer = 5
    Dim DKpics(6) As Image
    Dim DKpicnum As Integer
    Dim DKanimatenum As Integer

    Dim invincible As Boolean = False
    Public maxbarrels As Integer = 3
    Public barrelspacing As Integer = 100
    Public invtimer As Integer





    Structure floor
        Dim topleft As Point
        Dim topright As Point
        Dim slope As Double
    End Structure
    Public Const numfloors As Integer = 6
    Dim floors(numfloors) As floor
    Public Sub Loadfloors()
        floors(0).topleft.X = 80
        floors(0).topleft.Y = 466
        floors(0).topright.X = 563
        floors(0).topright.Y = 465
        floors(0).slope = (floors(0).topleft.Y - floors(0).topright.Y) / (floors(0).topleft.X - floors(0).topright.X)
        floors(1).topleft.X = 80
        floors(1).topleft.Y = 367
        floors(1).topright.X = 518
        floors(1).topright.Y = 400
        floors(1).slope = (floors(1).topleft.Y - floors(1).topright.Y) / (floors(1).topleft.X - floors(1).topright.X)
        floors(2).topleft.X = 120
        floors(2).topleft.Y = 338
        floors(2).topright.X = 560
        floors(2).topright.Y = 306
        floors(2).slope = (floors(2).topleft.Y - floors(2).topright.Y) / (floors(2).topleft.X - floors(2).topright.X)
        floors(3).topleft.X = 80
        floors(3).topleft.Y = 215
        floors(3).topright.X = 515
        floors(3).topright.Y = 247
        floors(3).slope = (floors(3).topleft.Y - floors(3).topright.Y) / (floors(3).topleft.X - floors(3).topright.X)
        floors(4).topleft.X = 120
        floors(4).topleft.Y = 184
        floors(4).topright.X = 560
        floors(4).topright.Y = 153
        floors(4).slope = (floors(4).topleft.Y - floors(4).topright.Y) / (floors(4).topleft.X - floors(4).topright.X)
        floors(5).topleft.X = 80
        floors(5).topleft.Y = 92
        floors(5).topright.X = 506
        floors(5).topright.Y = 93
        floors(5).slope = (floors(5).topleft.Y - floors(5).topright.Y) / (floors(5).topleft.X - floors(5).topright.X)
        floors(6).topleft.X = 206
        floors(6).topleft.Y = 42
        floors(6).topright.X = 326
        floors(6).topright.Y = 42
        floors(6).slope = (floors(6).topleft.Y - floors(6).topright.Y) / (floors(6).topleft.X - floors(6).topright.X)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Right Then
            mspeed.X = 5
            mfacingleft = False
            mclimbing = False
        End If
        If e.KeyCode = Keys.Left Then
            mspeed.X = -5
            mfacingleft = True
            mclimbing = False
        End If
        If e.KeyCode = Keys.Up And mfloattime > 20 And Marioonladder() = False Then
            mfloattime = 0
            mclimbing = False
        End If
        If e.KeyCode = Keys.Down Then

        End If
        If Marioonladder() = True And e.KeyCode = Keys.Up And mfloattime > 20 Then
            Mario.Top -= 5
            mclimbing = True
            manimatecounter += 2
        End If
        If Marioonladder() = True And e.KeyCode = Keys.Down And mfloattime > 20 Then
            Mario.Top += 5

        End If
        If e.KeyCode = Keys.A Then
            DKanimatenum = 1
        End If
        If e.KeyCode = Keys.S Then
            DKanimatenum = 2
        End If
        If e.KeyCode = Keys.W Then
            DKanimatenum = 3
        End If
        If e.KeyCode = Keys.Tab Then
            Play("stop theme.mp3")
            Play("play epic.mp3")

        End If
        If e.KeyCode = Keys.Escape Then
            End
        End If
        If e.KeyCode = Keys.C Then
            Dim s As String
            Timer1.Stop()
            s = InputBox("You are a cheater")
            Timer1.Start()
            If s = "invincible" Then
                invincible = Not invincible
            Else
                If s = "win" Then
                    Mario.Left = 278
                    Mario.Top = 10
                Else
                    If s = "lose" Then
                        Mario.Location = Barrel1.Location
                    Else
                        If s = "slowmo" Then
                            Timer1.Interval = 75
                        Else
                            If s = "fast" Then
                                Timer1.Interval = 1
                            Else
                                If s = "normal" Then
                                    Timer1.Interval = 30
                                Else
                                    If s = "luigi" Then
                                        Call setluigi()
                                    Else
                                        If s = "mario" Then
                                            Call setmario()
                                        Else
                                            If s = "hammer" Then
                                                Hammer1.Location = Mario.Location
                                                hammertime = 99999999
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Left Then
            mspeed.X = 0
        End If
        If e.KeyCode = Keys.Right Then
            mspeed.X = 0
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Stop()
        StartScreen.ShowDialog()
        Timer1.Start()
        Play("play theme.mp3")
        Call loadpics()
        Call LoadLadders()
        Call Loadfloors()
        Call loadbarrels()
        hashammer = False

    End Sub
    Public Sub movebarrels(ByVal i As Integer)
        If floors(Barrelfloornum(i)).slope > 0 Then
            bspeed(i).X = 5
        Else
            bspeed(i).X = -5
        End If
        bfloattime(i) += 1
        If bfloattime(i) <= 10 Then
            bspeed(i).Y = -5
            bspeed(i).X = 0
        ElseIf bfloattime(i) <= 20 Then
            bspeed(i).Y = +5
            bspeed(i).X = 0
        Else
            bspeed(i).Y = 0
        End If
        If bfloattime(i) > 20 Then
            barrels(i).Top = floors(Barrelfloornum(i)).slope * barrels(i).Left + floors(Barrelfloornum(i)).topleft.Y - barrels(i).Height
            Call barrelsfalloffsides(i)
        End If
        barrels(i).Left += bspeed(i).X
        barrels(i).Top += bspeed(i).Y
        If barrels(i).Left < floors(0).topleft.X Then
            barrels(i).Left = floors(0).topleft.X
        End If
        If barrels(i).Right > floors(0).topright.X Then
            barrels(i).Left = floors(0).topright.X - barrels(i).Width

        End If
        If barrels(i).Left <= floors(0).topleft.X And
            Barrelfloornum(i) = 0 Then
            barrels(i).Left = 80
            barrels(i).Top = 72
            DKanimatenum = 3
            barrels(i).Visible = True
        End If
    End Sub
    Public Sub movemario()
        mfloattime += 1
        If mfloattime <= 10 Then
            mspeed.Y = -5
        ElseIf mfloattime <= 20 Then
            mspeed.Y = +5
        Else
            mspeed.Y = 0
        End If
        If Marioonladder() = False And mfloattime > 20 Then
            Mario.Top = floors(Mariofloornum).slope * Mario.Left + floors(Mariofloornum).topleft.Y - Mario.Height
            Call mariofalloffsides()
        End If
        Mario.Left += mspeed.X
        Mario.Top += mspeed.Y
        If Mario.Left < floors(0).topleft.X Then
            Mario.Left = floors(0).topleft.X
        End If
        If Mario.Right > floors(0).topright.X Then
            Mario.Left = floors(0).topright.X - Mario.Width
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        leveltime += 3
        gametime.Text = "Time: " + (leveltime * Timer1.Interval / 1000).ToString

        If invincible = False Then
            Call killmario()
        End If
        Call movemario()
        Call animatemario()
        Call animateDK()
        Call youwin()
        Mario.Image = mpics(mpicnum)

        barrelcounter += 1
        numMovingBarrels = Math.Min(numbarrels, barrelcounter / barrelspacing)
        numMovingBarrels = Math.Min(numMovingBarrels, maxbarrels)
        Dim i As Integer
        For i = 0 To numMovingBarrels
            Call movebarrels(i)
            Call animatebarrels(i)
        Next
        Call pickuphammer()
        If hashammer Then
            Call swinghammer()
            Call destroybarrel()
        End If
    End Sub

    Public Function Marioonladder()
        Dim i As Integer
        For i = 0 To 5
            If Mario.Left > ladders(i).Left - 10 Then
                If Mario.Right < ladders(i).Right + 10 Then
                    If Mario.Bottom < ladders(i).Bottom Then
                        If Mario.Bottom > ladders(i).Top Then
                            Return True
                        End If
                    End If
                End If
            End If
        Next
        Return False
    End Function
    Public Function Mariofloornum()
        If Mario.Bottom < floors(6).topleft.Y + 10 Then
            Return 6
        ElseIf Mario.Bottom < floors(5).topleft.Y + 10 Then
            Return 5
        ElseIf Mario.Bottom < floors(4).topleft.Y + 10 Then
            Return 4
        ElseIf Mario.Bottom < floors(3).topright.Y + 10 Then
            Return 3
        ElseIf Mario.Bottom < floors(2).topleft.Y Then
            Return 2
        ElseIf Mario.Bottom < floors(1).topright.Y + 10 Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Function Barrelfloornum(ByVal i As Integer)
        If barrels(i).Bottom < floors(6).topleft.Y + 10 Then
            Return 6
        ElseIf barrels(i).Bottom < floors(5).topleft.Y + 10 Then
            Return 5
        ElseIf barrels(i).Bottom < floors(4).topleft.Y + 10 Then
            Return 4
        ElseIf barrels(i).Bottom < floors(3).topright.Y + 10 Then
            Return 3
        ElseIf barrels(i).Bottom < floors(2).topleft.Y Then
            Return 2
        ElseIf barrels(i).Bottom < floors(1).topright.Y + 10 Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Private Sub LoadLadders()
        ladders(0) = Ladder0
        ladders(1) = Ladder1
        ladders(2) = Ladder2
        ladders(3) = Ladder3
        ladders(4) = Ladder4
        ladders(5) = Ladder5
    End Sub
    Public Sub mariofalloffsides()
        If Mariofloornum() = 6 And Mario.Right < floors(6).topleft.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 6 And Mario.Left > floors(6).topright.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 5 And Mario.Left > floors(5).topright.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 4 And Mario.Right < floors(4).topleft.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 3 And Mario.Left > floors(3).topright.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 2 And Mario.Right < floors(2).topleft.X And mfloattime > 20 Then
            mfloattime = 10
        End If
        If Mariofloornum() = 1 And Mario.Left > floors(1).topright.X And mfloattime > 20 Then
            mfloattime = 10
        End If
    End Sub
    Public Sub barrelsfalloffsides(ByVal i As Integer)
        If Barrelfloornum(i) = 6 And Mario.Right < floors(6).topleft.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 6 And barrels(i).Left > floors(6).topright.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 5 And barrels(i).Left > floors(5).topright.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 4 And barrels(i).Right < floors(4).topleft.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 3 And barrels(i).Left > floors(3).topright.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 2 And barrels(i).Right < floors(2).topleft.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
        If Barrelfloornum(i) = 1 And barrels(i).Left > floors(1).topright.X And bfloattime(i) > 20 Then
            bfloattime(i) = 10
        End If
    End Sub

    Public Sub loadpics()
        mpics(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove1.jpg")
        mpics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove2.jpg")
        mpics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove3.jpg")
        mpics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove1.jpg")
        mpics(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove2.jpg")
        mpics(5) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove3.jpg")
        mpics(6) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftFloat.jpg")
        mpics(7) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightFloat.jpg")
        mpics(8) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb1.jpg")
        mpics(9) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb2.jpg")
        mpics(10) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb3.jpg")
        mpics(11) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/MarioClimbTop1.jpg")
        mpics(12) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Marioleftsmasher1.jpg")
        mpics(13) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Marioleftsmasher2.jpg")
        mpics(14) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Mariorightsmasher1.jpg")
        mpics(15) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Mariorightsmasher2.jpg")
        mariopics(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove1.jpg")
        mariopics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove2.jpg")
        mariopics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightMove3.jpg")
        mariopics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove1.jpg")
        mariopics(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove2.jpg")
        mariopics(5) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftMove3.jpg")
        mariopics(6) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioLeftFloat.jpg")
        mariopics(7) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioRightFloat.jpg")
        mariopics(8) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb1.jpg")
        mariopics(9) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb2.jpg")
        mariopics(10) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimb3.jpg")
        mariopics(11) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/MarioClimbTop1.jpg")
        mariopics(12) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Marioleftsmasher1.jpg")
        mariopics(13) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Marioleftsmasher2.jpg")
        mariopics(14) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Mariorightsmasher1.jpg")
        mariopics(15) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/Mariorightsmasher2.jpg")
        luigipics(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiRightMove1.jpg")
        luigipics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiRightMove2.jpg")
        luigipics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiRightMove3.jpg")
        luigipics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiLeftMove1.jpg")
        luigipics(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiLeftMove2.jpg")
        luigipics(5) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiLeftMove3.jpg")
        luigipics(6) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiLeftFloat.jpg")
        luigipics(7) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiRightFloat.jpg")
        luigipics(8) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiClimb1.jpg")
        luigipics(9) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiClimb2.jpg")
        luigipics(10) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigiClimb3.jpg")
        luigipics(11) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/marioClimbTop1.jpg")
        luigipics(12) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigileftsmasher1.jpg")
        luigipics(13) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigileftsmasher2.jpg")
        luigipics(14) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigirightsmasher1.jpg")
        luigipics(15) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/luigirightsmasher2.jpg")
        bpics(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/barrel1.jpg")
        bpics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/barrel2.jpg")
        bpics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/barrel3.jpg")
        bpics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/barrel4.jpg")
        DKpics(0) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbDancing.jpg")
        DKpics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbDancing2.jpg")
        DKpics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbGettingBarrel.jpg")
        DKpics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbHoldingBarrel.jpg")
        DKpics(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbRollingBarrel.jpg")
        DKpics(5) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbSmiling.jpg")
        DKpics(6) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/BobbStanding.jpg")
        hpics(1) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/hammerleftsmasher1.jpg")
        hpics(2) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/hammerleftsmasher2.jpg")
        hpics(3) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/hammerrightsmasher1.jpg")
        hpics(4) = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "/pics/pics/hammerrightsmasher2.jpg")
    End Sub
    Public Sub animatemario()
        If mclimbing = False Then
            manimatecounter += 1
        End If
        If manimatecounter < manimatedelay Then
            Return
        End If
        manimatecounter = 0
        hammerdown = Not hammerdown
        mpicnum += 1
        If mclimbing = False Then
            If mspeed.X < 0 Then
                Call mcyclebtw(3, 5)
            End If
            If mspeed.X > 0 Then
                Call mcyclebtw(0, 2)
            End If
            If mspeed.X = 0 Then
                If mfacingleft = True Then
                    Call mcyclebtw(3, 3)
                Else
                    Call mcyclebtw(0, 0)
                End If
            End If
            If mfloattime < 20 Then
                If mfacingleft = True Then
                    Call mcyclebtw(6, 6)
                Else
                    Call mcyclebtw(7, 7)
                End If
            End If
        Else
            mcyclebtw(8, 10)
        End If
        Mario.Image = mpics(mpicnum)
    End Sub
    Public Sub animatebarrels(ByVal i As Integer)
        banimatecounter += 1
        If banimatecounter < banimatedelay Then
            Return
        End If
        banimatecounter = 0
        bpicnum(i) += 1

        Call bcyclebtw(i, 0, 3)

        barrels(i).Image = bpics(bpicnum(i))
    End Sub
    Public Sub animateDK()

        DKanimatecounter += 1
        If DKanimatecounter < DKanimatedelay Then
            Return
        End If
        DKanimatecounter = 0
        DKpicnum += 1
        If DKanimatenum = 0 Then
            Call DKcyclebtw(6, 6)
        End If
        If DKanimatenum = 1 Then
            Call DKcyclebtw(5, 5)
        End If

        If DKanimatenum = 2 Then
            Call DKcyclebtw(0, 1)
        End If
        If DKanimatenum = 3 Then
            Call DKcyclebtw(2, 4)

        End If
        DK.Image = DKpics(DKpicnum)
    End Sub

    Public Sub mcyclebtw(ByVal first As Integer, ByVal last As Integer)
        If mpicnum < first Or mpicnum > last Then
            mpicnum = first
        End If

    End Sub
    Public Sub bcyclebtw(ByVal i As Integer, ByVal first As Integer, ByVal last As Integer)
        If bpicnum(i) < first Or bpicnum(i) > last Then
            bpicnum(i) = first
        End If

    End Sub
    Public Sub DKcyclebtw(ByVal first As Integer, ByVal last As Integer)

        If DKpicnum = last Then
            DKanimatenum = 0
        End If
        If DKpicnum < first Or DKpicnum > last Then
            DKpicnum = first
        End If

    End Sub
    Public Sub loadbarrels()
        barrels(0) = Barrel0
        bfloattime(0) = 21
        barrels(1) = Barrel1
        bfloattime(1) = 21
        barrels(2) = Barrel2
        bfloattime(2) = 21
        barrels(3) = Barrel3
        bfloattime(3) = 21
        barrels(4) = Barrel4
        bfloattime(4) = 21
        barrels(5) = Barrel5
        bfloattime(5) = 21
        barrels(6) = Barrel6
        bfloattime(6) = 21
        barrels(7) = Barrel7
        bfloattime(7) = 21
        barrels(8) = Barrel8
        bfloattime(8) = 21
        barrels(9) = Barrel9
        bfloattime(9) = 21
        barrels(10) = Barrel10
        bfloattime(10) = 21
        barrels(11) = Barrel11
        bfloattime(11) = 21
        barrels(12) = Barrel12
        bfloattime(12) = 21
        barrels(13) = Barrel13
        bfloattime(13) = 21
        barrels(14) = Barrel14
        bfloattime(14) = 21
        barrels(15) = Barrel15
        bfloattime(15) = 21
        barrels(16) = barrel16
        bfloattime(16) = 21
        barrels(17) = barrel17
        bfloattime(17) = 21
        barrels(18) = barrel18
        bfloattime(18) = 21
        barrels(19) = barrel19
        bfloattime(19) = 21
        barrels(20) = barrel20
        bfloattime(20) = 21
        barrels(21) = barrel21
        bfloattime(21) = 21
        barrels(21) = barrel21
        bfloattime(21) = 21
        barrels(22) = barrel22
        bfloattime(22) = 21
        barrels(23) = barrel23
        bfloattime(23) = 21
        barrels(24) = barrel24
        bfloattime(24) = 21
        barrels(25) = barrel25
        bfloattime(25) = 21
        barrels(26) = barrel26
        bfloattime(26) = 21
        barrels(27) = barrel27
        bfloattime(27) = 21
        barrels(28) = barrel28
        bfloattime(28) = 21
        barrels(29) = barrel29
        bfloattime(29) = 21
        barrels(30) = barrel30
        bfloattime(30) = 21

    End Sub
    Public Function collision(ByVal b1 As PictureBox, ByVal b2 As PictureBox)
        If b1.Left < b2.Right Then
            If b1.Right > b2.Left Then
                If b1.Top < b2.Bottom Then
                    If b1.Bottom > b2.Top Then
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function

    Public Sub killmario()
        Dim i As Integer
        For i = 0 To numbarrels
            If collision(Mario, barrels(i)) And barrels(i).Visible = True Then
                Timer1.Stop()
                Play("stop theme.mp3")
                Play("play fatality.mp3")
                Youdieform.ShowDialog()
                Timer1.Start()
                Call resetbarrels()
                Call resetmario()
                Call resethammer()
            End If
        Next
    End Sub
    Public Sub resetbarrels()
        barrels(0).Left = 79
        barrels(0).Top = 446
        barrels(1).Left = 79
        barrels(1).Top = 446
        barrels(2).Left = 79
        barrels(2).Top = 446
        barrels(3).Left = 79
        barrels(3).Top = 446
        barrels(4).Left = 79
        barrels(4).Top = 446
        barrels(5).Left = 79
        barrels(5).Top = 446
        barrels(6).Left = 79
        barrels(6).Top = 446
        barrels(7).Left = 79
        barrels(7).Top = 446
        barrels(8).Left = 79
        barrels(8).Top = 446
        barrels(9).Left = 79
        barrels(9).Top = 446
        barrels(10).Left = 79
        barrels(10).Top = 446
        barrels(11).Left = 79
        barrels(11).Top = 446
        barrels(12).Left = 79
        barrels(12).Top = 446
        barrels(13).Left = 79
        barrels(13).Top = 446
        barrels(14).Left = 79
        barrels(14).Top = 446
        barrels(15).Left = 79
        barrels(15).Top = 446
        barrels(16).Left = 79
        barrels(16).Top = 446
        barrels(17).Left = 79
        barrels(17).Top = 446
        barrels(18).Left = 79
        barrels(18).Top = 446
        barrels(19).Left = 79
        barrels(19).Top = 446
        barrels(20).Left = 79
        barrels(20).Top = 446
        barrels(21).Left = 79
        barrels(21).Top = 446
        barrels(22).Left = 79
        barrels(22).Top = 446
        barrels(23).Left = 79
        barrels(23).Top = 446
        barrels(24).Left = 79
        barrels(24).Top = 446
        barrels(25).Left = 79
        barrels(25).Top = 446
        barrels(26).Left = 79
        barrels(26).Top = 446
        barrels(27).Left = 79
        barrels(27).Top = 446
        barrels(28).Left = 79
        barrels(28).Top = 446
        barrels(29).Left = 79
        barrels(29).Top = 446
        barrels(30).Left = 79
        barrels(30).Top = 446
     
        barrelcounter = 0
    End Sub
    Public Sub resetmario()
        Mario.Top = 432
        Mario.Left = 136
        mspeed.X = 0
        mspeed.Y = 0
        mfacingleft = False
        leveltime = 0
        Play("play theme.mp3")
      
    End Sub
    Public Sub youwin()
        If collision(Mario, princess) Then
            Timer1.Stop()
     
            WINform.ShowDialog()

            Timer1.Start()
            Call resetbarrels()
            Call resetmario()
        End If
    End Sub
    Public Sub pickuphammer()
        If collision(Mario, Hammer1) Then
            Hammer1.Visible = False
            Hammer.Visible = True
            hashammer = True
            hammertime = 290
        End If
        If hashammer = True Then
            hammertime -= 1
            If hammertime < 0 Then
                hashammer = False
                Hammer.Visible = False
                Hammer1.Location = l.Location
                Hammer.Location = Hammer1.Location
            End If
        End If
    End Sub
    Public Sub swinghammer()
       
        If hammerdown = True Then
            If mfacingleft = True Then
                Mario.Image = mpics(13)
                Hammer.Image = hpics(2)

                Hammer.Left = Mario.Left - Hammer.Width
                Hammer.Top = Mario.Bottom - Hammer.Height
            Else
                Mario.Image = mpics(15)
                Hammer.Image = hpics(4)
                Hammer.Top = Mario.Bottom - Hammer.Height
                Hammer.Left = Mario.Right
            End If
        Else
            If mfacingleft = True Then
                Mario.Image = mpics(12)
                Hammer.Image = hpics(1)
                Hammer.Top = Mario.Top - Hammer.Height
                Hammer.Left = Mario.Left
            Else
                Mario.Image = mpics(14)
                Hammer.Image = hpics(3)
                Hammer.Top = Mario.Top - Hammer.Height
                Hammer.Left = Mario.Left
            End If
        End If
    End Sub
    Public Sub resethammer()
        Hammer1.Visible = True
        Hammer.Visible = False
        hashammer = False
    End Sub
    Public Sub destroybarrel()
        Dim i As Integer
        For i = 0 To numbarrels
            If Collision(hammer, barrels(i)) And hammer.Visible = True Then
                barrels(i).Visible = False
            End If
        Next

    End Sub
    Public Sub setmario()
        For i As Integer = 0 To 15
            mpics(i) = mariopics(i)
        Next
    End Sub
    Public Sub setluigi()
        For i As Integer = 0 To 15
            mpics(i) = luigipics(i)
        Next
    End Sub

  
End Class




