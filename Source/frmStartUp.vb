'****************************************************************************************************************************
'Visual Personal Data System v2013/2019
'Copyright Jack Gibbons 1980-2020
'
'incorporating  Personal Banking System, Personal Accounting System, 
'               Finances Spreadsheet, Addresses, Books, Music (iTunes) & Videos
'****************************************************************************************************************************
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'22/03/15   jpg     Copied from Vpbs78
'30/12/15   jpg     modified to use Live db for all Logins and Parameter access
'06/01/16   jpg     Completed
'13/03/17   jpg     Added gsAuxDBName for all Aux DB's only, as VPBS DB gsDBName value corrupted
'04/03/20   jpg     Now running on Win10 Pro VB19. No changes made to code apart from a Cystal Report properties!
'****************************************************************************************************************************
Public Class frmStartUp

    Dim gsPostAllSOs As String = "N"
    Dim iForColorLoggedOut As System.Drawing.Color

    Private Sub frmStartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VPBSDataSet.Users' table. You can move, or remove it, as needed.

        '
        'always use Live db for all Logins and Parameter access on this form and Setup Users/Password only!
        '
        gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
        gsVpbsStartUpConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
        Me.UsersLiveTableAdapter.Fill(Me.VPBSDataSet.Users)
        cboUserName.DataSource = UsersLiveBindingSource

        Call UpdateControls()

        lblSelectOption.Text = "Logged Out: Log in to Select an Option"
        iForColorLoggedOut = lblLogInOut.ForeColor

        giLoginAttempts = 1

    End Sub

    Private Sub CmdLogin_Click(sender As Object, e As EventArgs) Handles CmdLogin.Click

        gsUserName = cboUserName.text
        gsPassword = txtPassword.Text

        If AppLogin() Then
            Me.Text = "Personal Data System [" + gsDBName + " Data] - Logged in as " + gsUserName
            'show Startup Panel to enable entry
            StartUpPanel.Enabled = True
            giLoginAttempts = 1
            lblLogInOut.Text = "Logged In"
            lblLogInOut.ForeColor = Me.BackColor
            'lblSelectOptionold.Visible = True
            lblSelectOption.Text = "Logged In: Select an Option"

        Else
            lblLogInOut.Text = "Logged Out"
            lblLogInOut.ForeColor = iForColorLoggedOut
            'lblSelectOptionold.Visible = False
            lblSelectOption.Text = "Logged Out: Log in to Select an Option"

        End If

        'StartUpPanel.Enabled = False

        gsPassword = ""
        txtPassword.Text = ""

    End Sub

    Private Sub CmdLogout_Click(sender As Object, e As EventArgs) Handles CmdLogout.Click

        If giSecurity Then
            Me.Text = "Personal Data System [" + gsDBName + " Data] - Logged out, Enter Name and Password, Click Login"
        Else
            Me.Text = "Personal Data System [" + gsDBName + " Data] - Logged out, Enter Name and Click Login"
        End If

        lblLogInOut.Text = "Logged Out"
        lblLogInOut.ForeColor = iForColorLoggedOut
        'lblSelectOptionold.Visible = False
        lblSelectOption.Text = "Logged Out: Log in to Select an Option"

        'change Startup Panel to disable entry
        StartUpPanel.Enabled = False

        gsAccountNo = "None selected   "
        gsPassword = ""
        txtPassword.Text = ""

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click

        Me.Close()

    End Sub

    Private Function GetSecurity() As String
        '***************************************************************
        ' Purpose:    Retrieves the flag from the parameter file
        '             to determine whether security is switched on
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        '          jpg Created
        '***************************************************************

        Dim sGetSecurity As String = Nothing

        Call GetParameter("Password", sGetSecurity)

        If sGetSecurity = "" Then
            GetSecurity = ""
            Exit Function
        End If

        GetSecurity = DeCrypt(sGetSecurity) ' YY or NN

    End Function

    Private Function AppLogin() As Integer
        '***************************************************************
        ' Purpose:    Logs into application
        '
        ' Parameters: None
        '
        ' Result:     True if completely successful, false if
        '             3 unsuccessful attempts or user quits
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        '***************************************************************
        Dim iGetLevel As Integer
        Dim iResp As Integer = 0

        On Error GoTo ERH_AppLogin

        Call SetHourGlassDefault()

        AppLogin = False
        'giLoginAttempts = 1 

        ' Loop for up to n attempts
        Do While giLoginAttempts <= giMAX_LOGINS 'change to Do Until giLoginAttempts >= giMAX_LOGINS

            ' Get Username & password
            iResp = GetUserInfo(iGetLevel)

            Select Case iResp

                Case vbOK
                    ' Store UserLevel
                    giUserLevel = iGetLevel
                    AppLogin = True : Exit Do

                Case vbRetry
                    giLoginAttempts = giLoginAttempts + 1
                    AppLogin = False : Exit Do

                Case vbCancel
                    giLoginAttempts = giMAX_LOGINS
                    AppLogin = False : Exit Do

            End Select

        Loop

        If AppLogin = True Then
            Return True
        Else
            Return False
        End If

        Exit Function

ERH_AppLogin:

        'Select Case DefaultErrorHandler(Err, "AppLogin")
        'Case giERROR_TYPE_RESUME
        'Resume
        'Case giERROR_TYPE_RESUMENEXT
        'Resume Next
        'case giERROR_TYPE_UNRECOVERABLE
        'AppLogin = False
        'Exit Function
        'End Select

    End Function

    Private Function GetUserInfo(ByRef rsSecLevel As Integer) As Integer
        '***************************************************************
        '
        ' Purpose:    Validates the user on the UserId table
        '             and obtains user level indicator
        '
        ' Parameters: rsSecLevel - (by ref) used only to return the security level
        '
        ' Result:     giACTION_OK    - user validated, and Security level
        '                           returned (non zero)
        '             giACTION_RETRY - either a run-time error occurred OR
        '                           validation failed, and user selected RETRY
        '
        '             giERROR_TYPE_UNRECOVERABLE  - either a run-time error occurred OR
        '                           validation failed, and user selected CANCEL
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        '***************************************************************
        Dim sSql As String = Nothing
        Dim sUserPassword As String = Nothing
        Dim iResp As Integer = 0
        Dim nCount As Integer = 0
        'Dim ds1 As New DataTable

        'On Error GoTo ERR_GetUserInfo

        Call SetHourGlassWait()
        rsSecLevel = 0

        'Get User Date from Live db!
        sSql = "SELECT UserName, UserLevel, Password "
        sSql = sSql & "FROM Users WHERE UserName = " & qte(gsUserName)
        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsStartUpConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        nCount = 0
        If ds.Rows.Count = 0 Then
            ' Username not found
            iResp = MsgBox("Invalid User name", vbRetryCancel + vbExclamation, "User Validation")
            rsSecLevel = 0
            If iResp = vbRetry Then
                GetUserInfo = vbRetry
            Else
                GetUserInfo = vbCancel
            End If
            ds.Dispose()
            Call SetHourGlassDefault()
            Exit Function
        Else
            ' UserName found
        End If

        ' Check stored password against user-entered password
        sUserPassword = UCase(DeCrypt(ds.Rows.Item(nCount)("Password")))
        If sUserPassword = UCase(gsPassword) Or giSecurity = False Then
            ' Password OK - now check user level
            rsSecLevel = ds.Rows.Item(nCount)("UserLevel")
            If rsSecLevel > 0 Then
                GetUserInfo = vbOK 'return UserLevel back to calling routine
            Else
                iResp = MsgBox("Security level returned 0", vbRetryCancel + vbExclamation, "User Validation")
                rsSecLevel = 0
                ' Pass return code back to calling function
                If iResp = vbRetry Then
                    GetUserInfo = vbRetry
                Else
                    GetUserInfo = vbCancel
                End If
            End If
        Else
            iResp = MsgBox("Incorrect Password", vbRetryCancel + vbExclamation, "User Validation")
            rsSecLevel = 0
            ' Pass return code back to calling function
            If iResp = vbRetry Then
                GetUserInfo = vbRetry
            Else
                GetUserInfo = vbCancel
            End If
        End If

        ds.Dispose()

        Call SetHourGlassDefault()

        Exit Function

ERR_GetUserInfo:

        'Select DefaultErrorHandler(Err, "GetUserInfo")
        'Case vbRESUME
        'GetUserInfo = giACTION_RETRY
        'Exit Function
        'Case giERROR_TYPE_RESUMENEXT, giERROR_TYPE_UNRECOVERABLE
        GetUserInfo = vbCancel
        Exit Function
        'End Select

    End Function

    Private Sub CmdPBS_Click(sender As Object, e As EventArgs) Handles CmdPBS.Click

        Dim bok As Boolean

        bok = True

        gsAccountNo = "None selected   "

        If bok Then frmPbsTrans.Show()

    End Sub

    Private Sub PrinterSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrinterSetupToolStripMenuItem.Click

        PrintDialog1.ShowDialog()
        'PrintDialog1.PrinterSettings.GetHdevmode().

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Dispose()

    End Sub

    Private Sub PersonalDataSystemToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'About

    End Sub

    Private Sub PersonalBankingSystemToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'About

    End Sub

    Private Sub ArchiveDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveDataToolStripMenuItem.Click

        Dim sSql As String = Nothing
        Dim bOk As Boolean = False

        'set dbLive to False
        If ArchiveDataToolStripMenuItem.Checked = False Then
            ArchiveDataToolStripMenuItem.Checked = True
            LiveDataToolStripMenuItem.Checked = False
            TestDataToolStripMenuItem.Checked = False
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = 'False'"
            sSql = sSql + " Where Parameter = 'Live'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        End If

        gsDBName = "Archive"

        Call UpdateControls()

    End Sub

    Private Sub LiveDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiveDataToolStripMenuItem.Click

        Dim sSql As String = Nothing
        Dim bOk As Boolean = False

        'set dbLive to True
        If LiveDataToolStripMenuItem.Checked = False Then
            LiveDataToolStripMenuItem.Checked = True
            ArchiveDataToolStripMenuItem.Checked = False
            TestDataToolStripMenuItem.Checked = False
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = 'True'"
            sSql = sSql + " Where Parameter = 'Live'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        End If

        gsDBName = "Live"

        Call UpdateControls()

    End Sub

    Private Sub TestDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestDataToolStripMenuItem.Click

        Dim sSql As String = Nothing
        Dim bOk As Boolean = False

        'set dbLive to True
        If TestDataToolStripMenuItem.Checked = False Then
            TestDataToolStripMenuItem.Checked = True
            ArchiveDataToolStripMenuItem.Checked = False
            LiveDataToolStripMenuItem.Checked = False
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = 'Test'"
            sSql = sSql + " Where Parameter = 'Live'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        End If

        gsDBName = "Test"

        Call UpdateControls()

    End Sub

    Private Sub PostSOsOnAllActsConcurrentlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostSOsOnAllActsConcurrentlyToolStripMenuItem.Click

        Dim sSql As String = Nothing
        Dim bOk As Boolean = False

        'If giUserLevel = 1 Then 'Master User only

        'Concurrent SO's on/off?
        If PostSOsOnAllActsConcurrentlyToolStripMenuItem.Checked = False Then
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Checked = True
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Text = "&Post SO's on ALL a/c's concurrently?"
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = 'Y'" '& qte(Encrypt("YY"))
            sSql = sSql + " Where Parameter = 'PostAllSOs'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        Else
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Checked = False
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Text = "&Post SO's on ALL a/c's concurrently?"
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = 'N'" '& qte(Encrypt("NN"))
            sSql = sSql + " Where Parameter = 'PostAllSOs'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        End If

        Call UpdateControls()

        'End If

    End Sub

    Private Sub PasswordsOnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsOnToolStripMenuItem.Click

        Dim sSql As String = Nothing
        Dim bOk As Boolean = False

        'If giUserLevel = 1 Then 'Master User only

        'passwords on/off?
        If PasswordsOnToolStripMenuItem.Checked = False Then
            PasswordsOnToolStripMenuItem.Checked = True
            PasswordsOnToolStripMenuItem.Text = "&Passwords On/Off"
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = " & qte(Encrypt("YY"))
            sSql = sSql + " Where Parameter = 'Password'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        Else
            PasswordsOnToolStripMenuItem.Checked = False
            PasswordsOnToolStripMenuItem.Text = "&Passwords On/Off"
            sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
            sSql = sSql + " Set ParameterData = " & qte(Encrypt("NN"))
            sSql = sSql + " Where Parameter = 'Password'" & ";"
            bOk = DoStartUpSql(sSql, 1)
        End If

        Call UpdateControls()

        'End if

    End Sub

    Private Sub UpdateControls()

        Dim sDBName As String = Nothing

        '
        'Get Parameters from Live DB only!
        '

        'GetPostAllSO's flag
        Call GetParameter("PostAllSOs", gsPostAllSOs)
        If gsPostAllSOs = "Y" Then
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Checked = True
            giPostAllSOs = True
        Else
            PostSOsOnAllActsConcurrentlyToolStripMenuItem.Checked = False
            giPostAllSOs = False
        End If

        'Get DbName
        Call GetParameter("Live", sDBName)
        If sDBName = "True" Then
            LiveDataToolStripMenuItem.Checked = True
            ArchiveDataToolStripMenuItem.Checked = False
            TestDataToolStripMenuItem.Checked = False
            gsDBName = "Live"

        ElseIf sDBName = "False" Then
            LiveDataToolStripMenuItem.Checked = False
            ArchiveDataToolStripMenuItem.Checked = True
            TestDataToolStripMenuItem.Checked = False
            gsDBName = "Archive"

            'Else
            'LiveDataToolStripMenuItem.Checked = False
            'ArchiveDataToolStripMenuItem.Checked = False
            'TestDataToolStripMenuItem.Checked = True
            'gsDBName = "Test"

        End If

        'Get Passwords On/Off flag
        If GetSecurity() <> "NN" Then
            giSecurity = True
            PasswordsOnToolStripMenuItem.Checked = True
        Else
            giSecurity = False
            PasswordsOnToolStripMenuItem.Checked = False
        End If

        If giSecurity Then
            Me.Text = "Personal Data System [" + gsDBName + " Data] - Enter Name and Password, Click Login"
            lblPassword.Visible = True
            txtPassword.Visible = True
        Else
            Me.Text = "Personal Data System [" + gsDBName + " Data] - Enter Name and Click Login"
            lblPassword.Visible = False
            txtPassword.Visible = False
        End If

    End Sub

    Private Sub CmdFinance_Click(sender As Object, e As EventArgs) Handles CmdFinance.Click

        Dim bok As Long

        On Error Resume Next

        'bok = Shell("C:\Program Files (x86)\Microsoft Office\Office14\Excel.exe C:\Vpbs\Finances2017.xls", 1)
        bok = Shell("C:\Program Files\LibreOffice\program\soffice.exe C:\Vpbs\Finances2020.xls", 1)

    End Sub

    Private Sub CmdAddresses_Click(sender As Object, e As EventArgs) Handles CmdAddresses.Click

        gsAuxDBName = "LifeLine.mdb"
        frmAux.Show()

    End Sub

    Private Sub CmdBooks_Click(sender As Object, e As EventArgs) Handles CmdBooks.Click

        gsAuxDBName = "Books.mdb"
        frmAux.Show()

    End Sub

    Private Sub CmdMusic_Click(sender As Object, e As EventArgs) Handles CmdMusic.Click

        Dim bok As Long

        'On Error Resume Next
        '    bOk = Shell("C:\Progra~1\Access2\MsAccess.exe C:\Data\AccessDB\music.mdb", 1)
        'bok = Shell("C:\Progra~2\iTunes\iTunes.exe", 1)
        bok = Shell("C:\Progra~1\iTunes\iTunes.exe", 1)
        'Form1.Show

    End Sub

    Private Sub CmdVideos_Click(sender As Object, e As EventArgs) Handles CmdVideos.Click

        gsAuxDBName = "Video.mdb"
        frmAux.Show()

    End Sub

    Private Sub PersonalDataSystemToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PersonalDataSystemToolStripMenuItem2.Click

        AboutBoxVPBS.Show()

    End Sub

    Function FileNameLessPath(sFileName As String) As String

        Dim iLastBackSlash As Integer

        For iLastBackSlash = Len(sFileName) To 1 Step -1
            If Mid(sFileName, iLastBackSlash, 1) = "\" Then Exit For
        Next

        FileNameLessPath = Mid(sFileName, iLastBackSlash + 1, Len(sFileName))

    End Function

    Function PathLessFileName(sFileName As String) As String

        Dim iLastBackSlash As Integer

        For iLastBackSlash = Len(sFileName) To 1 Step -1
            If Mid(sFileName, iLastBackSlash, 1) = "\" Then Exit For
        Next

        PathLessFileName = Mid(sFileName, 1, iLastBackSlash - 1)

    End Function

    Private Sub InTheSummerOf1980ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InTheSummerOf1980ToolStripMenuItem.Click

        Dim bok As Long

        On Error Resume Next

        'bok = Shell("C:\Program Files (x86)\Microsoft Office\Office14\Excel.exe C:\Vpbs\Finances2017.xls", 1)
        bok = Shell("C:\Program Files\LibreOffice\program\soffice.exe C:\Vpbs\Inthesummerof1980.doc", 1)

    End Sub

    Private Sub PersonalBankingSystemVersonsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonalBankingSystemVersonsToolStripMenuItem.Click

        Dim bok As Long

        On Error Resume Next

        'bok = Shell("C:\Program Files (x86)\Microsoft Office\Office14\Excel.exe C:\Vpbs\Finances2017.xls", 1)
        bok = Shell("C:\Program Files\LibreOffice\program\soffice.exe C:\Vpbs\VPBSVersions19new.xlsx", 1)

    End Sub

    Private Sub ComputerHardwareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComputerHardwareToolStripMenuItem.Click

        Dim bok As Long

        On Error Resume Next

        'bok = Shell("C:\Program Files (x86)\Microsoft Office\Office14\Excel.exe C:\Vpbs\Finances2017.xls", 1)
        bok = Shell("C:\Program Files\LibreOffice\program\soffice.exe C:\Vpbs\ComputerHardwareNew19.xlsx", 1)

    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click

    End Sub
End Class