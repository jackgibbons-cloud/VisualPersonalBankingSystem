'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2018
'
'Bank Reconciliation, incorporating Bank Rec Summary, Report
'****************************************************************************************************************************
'
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'07/11/15   jpg     Created from Vpbs78
'                   Added datasources, datagrid
'10/11/15   jpg     Added report
'11/11/15   jpg     Completed
'17/01/16   jpg     Added Archive dataset...
'18/01/16   jpg     Moved GetAdjBalance() to before formatting txtCurrentBankBal.Text to 2 Dec places
'                   May have problem in changing Rec status from n to Y on some records...
'21/02/16   jpg     Store unformatted balance in txtCurrentBankBal.Tag for use in CmdReport
'03/11/16   jpg     Changed MoveLast to MoveFirst on form load
'17/01/17   jpg     Recreated PbsRecB.rpt from PbsRecA.rpt, but modified to read from Archive DB - Ok
'12/11/17   jpg     Modified to import Bank Statement text file into RecTrans table to enabled on screen reconciation.
'22/11/17   jpg     Recreated Datasets to include new RecTrans table and populate RecTrans grid. 
'                   Get Bank balance, display on screen
'24/11/17   jpg     Added AutoRec feature to find single matches, mark onscreen and update DB as Reconciled = 'n'
'                   'Modified CmdOk to update Rectrans and set 'n' to 'Y'
'18/12/17   jpg     CmdAccept and CmdAutoRec now working! Edit Pbs Amount todo.
'20/12/17   jpg     Now handles Edit Pbs amounts, updates balances on main screen.
'05/08/18   jpg     CmdAutoRec_Click: added sRecFlag to test that selected Rectrans matching record is in fact not reconciled already!
'25/10/18   jpg     CmdAutoRec_Click: added write to DataTable ds1 (Rectrans) to keep in step with updated Rectrans to avoid Rec in error
'
'12/03/20   JPG     CmdOk_Click: changed Timekey declaration from DateTime to Date to store fractions of seconds
'13/03/20   jpg     Need to call frmPbsTrans.RefreshDetails from CmdOk to refresh screen to show Rec changes
'****************************************************************************************************************************
Public Class frmBankRec

    Dim nAccountNo As Integer
    Dim RecBalance As Double
    Dim RecTransBalance As Double
    Dim RecTransDate As Date
    Dim nRecTransCount As Integer
    Dim cmdAcceptflag As Boolean = False


    Private Sub frmBankRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            Me.PbstransTableAdapterLive.Fill(Me.VpbsDataSet.pbstrans)
            Me.RecTransTableAdapterLive.Fill(Me.VPBSDataSet9.RecTrans)
            PbstransBindingSource.DataSource = VpbsDataSet
            RecTransBindingSource.DataSource = VPBSDataSet9

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            Me.RecTransTableAdapterArc.Fill(Me.VpbsArchiveDataSet4.RecTrans)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet
            RecTransBindingSource.DataSource = VpbsArchiveDataSet4

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            Me.RecTransTableAdapterTest.Fill(Me.VpbsTestDataSet1.RecTrans)
            PbstransBindingSource.DataSource = VpbsTestDataSet
            RecTransBindingSource.DataSource = VpbsTestDataSet1

        End If

        PbstransBindingSource.Filter = "AccountNo = " + qte(gsAccountNo) + " AND Reconciled = 'N' " 'Select'
        PbstransBindingSource.Sort = "Date, TimeKey" 'Order By'
        PbstransBindingSource.MoveFirst() '03/11/16

        DataGridPbsTrans.DataSource = PbstransBindingSource
        DataGridPbsTrans.TopLeftHeaderCell.Value = gsDBName '"------"

        DataGridBankTrans.DataSource = RecTransBindingSource
        DataGridBankTrans.Enabled = True

        lblAccountHeader.Text = CStr(frmPbsTrans.lblAccountHeader.Text)
        txtCurrentPBSBal.Text = CStr(FormatNumber(gcBalance, 2))

        Call GetRecTransBalance() 'from dirpbs (txtCurrentBankBal)

        Call GetAdjBalance()

        'txtCurrentBankBal.Tag = Val(txtCurrentBankBal.Text)                    'store unformatted balance in .Tag 21/02/16
        txtCurrentBankBal.Text = FormatNumber(Val(txtCurrentBankBal.Tag), 2)    'format .Text for display
        lblCurrentPBSBal.Text = FormatNumber(gcBalance, 2)                      'CStr(Format(gcBalance, "n"))

        'have any RecTrans records been imported for this account?
        nRecTransCount = 0
        nRecTransCount = DataGridBankTrans.RowCount - 1

        If nRecTransCount > 0 Then
            giAutoRec = True
            CmdAutoRec.Enabled = True
        Else
            giAutoRec = False
            CmdAutoRec.Enabled = False
        End If

        GroupBox4.Visible = False
        'GroupBox3.Visible = False
        'GroupBox5.Visible = False

    End Sub

    Private Sub CmdAccept_Click(sender As Object, e As EventArgs) Handles CmdAccept.Click

        'check Selected Pbs and imported Bank records match
        Dim dDateKey As Date
        Dim dTimeKey As DateTime
        Dim sPbsCustomer As String = ""
        Dim sRecCustomer As String = ""
        Dim nPbsDebitAmount As Double
        Dim nPbsCreditAmount As Double
        Dim nRecDebitAmount As Double
        Dim nRecCreditAmount As Double
        Dim sPayReceipt As String = ""
        Dim nSortNo As Integer
        Dim Msg As String
        Dim Title As String
        Dim bMatch As Boolean = False

        'only if Bank Rec file imported
        If giAutoRec = True Then

            cmdAcceptflag = True

            'get values for selected matching records
            Call GetPbsRecValues(sPbsCustomer, nPbsDebitAmount, nPbsCreditAmount, sPayReceipt, dDateKey, dTimeKey)
            Call GetBankRecValues(sRecCustomer, nRecDebitAmount, nRecCreditAmount, nSortNo)

            Select Case sPayReceipt

                Case "Payment"

                    'test first word only!
                    sPbsCustomer = UCase(sPbsCustomer) & " "                                        'compare in uppercase
                    sPbsCustomer = Mid(sPbsCustomer, 1, InStr(sPbsCustomer, " ") - 1)
                    sRecCustomer = UCase(sRecCustomer) & " "                                        'compare in uppercase
                    sRecCustomer = Mid(sRecCustomer, 1, InStr(sRecCustomer, " ") - 1)

                    'If match...then nMatchCount = nMatchCount + 1
                    If nPbsDebitAmount = nRecDebitAmount Then 'And sPbsCustomer = InStr(sRecCustomer, sPbsCustomer) Then
                        bMatch = True
                    End If

                Case "Receipt"

                    'test first word only!
                    sPbsCustomer = UCase(sPbsCustomer) & " "                                        'compare in uppercase
                    sPbsCustomer = Mid(sPbsCustomer, 1, InStr(sPbsCustomer, " ") - 1)
                    sRecCustomer = UCase(sRecCustomer) & " "                                        'compare in uppercase
                    sRecCustomer = Mid(sRecCustomer, 1, InStr(sRecCustomer, " ") - 1)

                    'If match...then nMatchCount = nMatchCount + 1
                    If nPbsCreditAmount = nRecCreditAmount Then 'And sPbsCustomer = sRecCustomer Then
                        bMatch = True
                    End If

                Case Else

            End Select

            'If values match then write to Pbs & Rec DataGrids
            If bMatch = True Then

                'Dim IDbTransaction As System.Data.IDbTransaction
                'IDbTransaction = Nothing

                'IDbTransaction = gsVpbsConnection

                Call PutPbsRecValue("n")
                PbstransBindingSource.EndEdit()

                Call PutBankRecValue("n")
                RecTransBindingSource.EndEdit()

                'If Not error Then
                'IDbTransaction.Commit()
                'Else
                'IDbTransaction.Rollback()
                'End If

                Msg = " Matching transactions Reconciled"
                Title = "Reconciliation"
                MsgBox(Msg, vbExclamation, Title)

            Else

                Msg = " Selected transactions do NOT match!"
                Title = "Reconciliation"
                MsgBox(Msg, vbExclamation, Title)

            End If

        Else
            'if manual Reconciliation being used only
            Call PutPbsRecValue("n")
            PbstransBindingSource.EndEdit()

        End If

        cmdAcceptflag = False
        'CmdAccept.Enabled = False
        CmdUndo.Enabled = True

    End Sub

    Private Sub CmdNext_Click(sender As Object, e As EventArgs) Handles CmdNext.Click

        CmdPrevious.Enabled = True

        PbstransBindingSource.MoveNext()
        DataGridPbsTrans.Focus()

    End Sub

    Private Sub CmdPrevious_Click(sender As Object, e As EventArgs) Handles CmdPrevious.Click

        CmdNext.Enabled = True

        PbstransBindingSource.MovePrevious()
        DataGridPbsTrans.Focus()

    End Sub

    Private Sub CmdUndo_Click(sender As Object, e As EventArgs) Handles CmdUndo.Click

        Call PutPbsRecValue("N")
        PbstransBindingSource.EndEdit()
        CmdAccept.Enabled = True
        'CmdUndo.Enabled = False

    End Sub

    Private Sub CmdAutoRec_Click(sender As Object, e As EventArgs) Handles CmdAutoRec.Click

        Dim sSql As String
        Dim nCount As Integer
        Dim nRecCount As Integer
        Dim nMatchCount As Integer
        Dim nPbsDebitAmount As Double
        Dim nPbsCreditAmount As Double
        Dim nRecDebitAmount As Double
        Dim nRecCreditAmount As Double
        Dim sDebitCredit As String
        Dim sCustomer As String
        Dim sDescription As String
        Dim sCustomerMatch As String
        Dim sDescriptionMatch As String
        Dim dPbsdate As Date
        Dim dPbstimekey As DateTime
        Dim dRecTransdate As Date
        Dim nSortNo As Integer
        Dim nSaveSortNo As String = ""
        Dim sRecFlag As String = "" 'rec marker added 05/08/18
        Dim sSaveRecFlag As String = "" 'rec marker added 05/08/18
        Dim nSaveRecCount As Integer

        sDescription = ""

        Call SetHourGlassWait()

        sSql = "SELECT * FROM pbstrans"
        sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
        sSql = sSql & " AND pbstrans.Reconciled = 'N' "

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        'We have a Pbstrans record,
        'Now look in Rectrans for a match

        sSql = "SELECT * FROM rectrans"
        'sSql = sSql & " WHERE rectrans.Balance = 0 " 'N'
        sSql = sSql & " WHERE [Sort Code] = 'N'"    'RecFlag check added 25/10/18 to avoid rec with same item on a second pass
        sSql = sSql & " ORDER BY [Balance]"         'order added 25/10/18

        Dim adapter1 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds1 As New DataTable
        adapter1.Fill(ds1)

        If ds.Rows.Count > 0 Then

            nCount = 0

            'look through unreconciled Pbstrans records
            Do While nCount <= ds.Rows.Count - 1

                sDebitCredit = ds.Rows.Item(nCount)("DebitCredit")
                sCustomer = UCase(ds.Rows.Item(nCount)("Customer"))     'compare in uppercase
                dPbsdate = UCase(ds.Rows.Item(nCount)("Date"))
                dPbstimekey = UCase(ds.Rows.Item(nCount)("TimeKey"))

                If sDebitCredit = "Payment" Then
                    nPbsDebitAmount = ds.Rows.Item(nCount)("Payment")       'no sign
                Else
                    nPbsCreditAmount = ds.Rows.Item(nCount)("Receipt")      'no sign
                End If

                nRecCount = 0
                nMatchCount = 0

                'look for a match in RecTrans records
                If ds1.Rows.Count > 0 Then

                    'look through unreconciled Rectrans records
                    Do While nRecCount <= ds1.Rows.Count - 1

                        sRecFlag = ds1.Rows.Item(nRecCount)("Sort Code") 'added 05/08/18 moved here 25/11/18

                        Select Case sDebitCredit

                            Case "Payment"

                                If Not IsDBNull(ds1.Rows.Item(nRecCount)("Debit Amount")) Then

                                    dRecTransdate = UCase(ds1.Rows.Item(nRecCount)("Transaction Date"))
                                    sDescription = UCase(ds1.Rows.Item(nRecCount)("Transaction Description"))     'compare in uppercase
                                    nRecDebitAmount = ds1.Rows.Item(nRecCount)("Debit Amount")                    'no sign
                                    nSortNo = ds1.Rows.Item(nRecCount)("Balance") '("Sort Code")
                                    'sRecFlag = ds1.Rows.Item(nRecCount)("Sort Code") 'added 05/08/18

                                    'test first word only!
                                    sCustomer = sCustomer & " "
                                    sDescription = sDescription & " "
                                    sCustomerMatch = Mid(sCustomer, 1, InStr(sCustomer, " ") - 1)
                                    sDescriptionMatch = Mid(sDescription, 1, InStr(sDescription, " ") - 1)

                                    'If match...then nMatchCount = nMatchCount + 1
                                    If nPbsDebitAmount = nRecDebitAmount And sCustomerMatch = sDescriptionMatch And sRecFlag = "N" Then
                                        nMatchCount = nMatchCount + 1
                                        nSaveSortNo = nSortNo
                                        sSaveRecFlag = sRecFlag
                                        nSaveRecCount = nRecCount
                                    End If
                                End If

                            Case "Receipt"

                                If Not IsDBNull(ds1.Rows.Item(nRecCount)("Credit Amount")) Then

                                    dRecTransdate = UCase(ds1.Rows.Item(nRecCount)("Transaction Date"))
                                    sDescription = UCase(ds1.Rows.Item(nRecCount)("Transaction Description"))     'compare in uppercase
                                    nRecCreditAmount = ds1.Rows.Item(nRecCount)("Credit Amount")                  'no sign
                                    nSortNo = ds1.Rows.Item(nRecCount)("Balance") '("Sort Code")
                                    'sRecFlag = ds1.Rows.Item(nRecCount)("Sort Code") 'added 05/08/18

                                    'test first word only!
                                    sCustomer = sCustomer & " "
                                    sDescription = sDescription & " "
                                    sCustomerMatch = Mid(sCustomer, 1, InStr(sCustomer, " ") - 1)
                                    sDescriptionMatch = Mid(sDescription, 1, InStr(sDescription, " ") - 1)

                                    'If match...then nMatchCount = nMatchCount + 1
                                    If nPbsCreditAmount = nRecCreditAmount And sCustomerMatch = sDescriptionMatch And sRecFlag = "N" Then
                                        nMatchCount = nMatchCount + 1
                                        nSaveSortNo = nSortNo
                                        sSaveRecFlag = sRecFlag
                                        nSaveRecCount = nRecCount
                                    End If

                                End If

                            Case Else

                        End Select

                        nRecCount = nRecCount + 1

                    Loop

                    If nMatchCount = 1 And sSaveRecFlag = "N" Then 'only ' add test for non-rec items 05/08/18" 
                        'post both trans as temp reconciled
                        Call UpdateReconciledPBSRecord(dPbsdate, dPbstimekey, "n") 'write to DB

                        Call UpdateReconciledRecTransRecord(nSaveSortNo, "n")   'write to DB
                        ds1.Rows.Item(nSaveRecCount)("Sort Code") = "n"         'Need to update recordset 25/10/2018

                    Else
                        'skip to next pbs record
                    End If

                End If

                nCount = nCount + 1
            Loop

        End If

        Call RefreshDetails()

        ds.Dispose()
        ds1.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click

        'GroupBox2.Visible = False
        GroupBox3.Visible = True
        GroupBox4.Visible = True
        'GroupBox5.Visible = False

        Call CboGroupsFill()
        CmdOkReport.Visible = True
        CmdOk.Visible = False

    End Sub

    Private Sub CmdOkReport_Click(sender As Object, e As EventArgs) Handles CmdOkReport.Click

        Dim sSql As String
        Dim Msg As String
        Dim Title As String
        Dim sFields As String
        Dim nRetryCount As Integer = 0
        Dim stxtGroup As String = "0"
        Dim HeaderIndex As Integer = 0
        Dim X As Integer

        If Not IsNumeric(txtCurrentBankBal.Text) Then
            Msg = " Please enter your Bank Statement balance"
            Title = "Print Reconciliation Statement"
            MsgBox(Msg, vbExclamation, Title)
            txtCurrentPBSBal.Focus()
            Exit Sub
        End If

        'GroupBox2.Visible = False
        'GroupBox3.Visible = False
        'GroupBox4.Visible = True
        'GroupBox5.Visible = False

        If cboGroup1.Text = "" Then cboGroup1.SelectedIndex = 1
        If cboGroup2.Text = "" Then cboGroup2.SelectedIndex = 1
        If cboGroup3.Text = "" Then cboGroup3.SelectedIndex = 1
        If cboGroup4.Text = "" Then cboGroup4.SelectedIndex = 1

        'For X = 1 To 4
        txtGroup1.Text = cboGroup1.SelectedIndex + 1
        txtGroup2.Text = cboGroup2.SelectedIndex + 1
        txtGroup3.Text = cboGroup3.SelectedIndex + 1
        txtGroup4.Text = cboGroup4.SelectedIndex + 1
        'Next X

        Call SetHourGlassWait()

        'On Error GoTo CmdOkReport_Click_Error

        If txtGroup1.Text <> "txtGroup" Then

            Call DropTable("RecTransTemp")

            sFields = "2 as Type, dirpbs.BudgetNo, pbstrans.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
            sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
            sFields = sFields & ", pbstrans.Date, pbstrans.TimeKey, pbstrans.Transfer"
            sFields = sFields & ", pbstrans.Amount, pbstrans.VAT, pbstrans.DebitCredit, pbstrans.Balance" 'use Amount or Pay / Rec?

            For X = 1 To 4

                Select Case X

                    Case 1
                        HeaderIndex = Val(txtGroup1.Text)
                        stxtGroup = txtGroup1.Text
                    Case 2
                        HeaderIndex = Val(txtGroup2.Text)
                        stxtGroup = txtGroup2.Text
                    Case 3
                        HeaderIndex = Val(txtGroup3.Text)
                        stxtGroup = txtGroup3.Text
                    Case 4
                        HeaderIndex = Val(txtGroup4.Text)
                        stxtGroup = txtGroup4.Text
                End Select

                'fix to allow for deleted CustomerCode item from onscreen cbo selection
                'as CustomerCode included in Rpt format Heading formula
                'If HeaderIndex > 2 Then HeaderIndex = HeaderIndex + 1

                'sFields = sFields & ", " & CStr(HeaderIndex) & " as txtGroup" & CStr(X)
                sFields = sFields & ", " & stxtGroup & " as txtGroup" & CStr(X)

                Select Case stxtGroup

                    Case "1"
                        sFields = sFields & ", pbstrans.Customer as Group" & CStr(X)
                    Case "2"
                        sFields = sFields & ", pbstrans.Analysis as Group" & CStr(X)
                    Case "3"
                        sFields = sFields & ", pbstrans.Account as Group" & CStr(X)
                    Case "4"
                        sFields = sFields & ", pbstrans.GLcode as Group" & CStr(X)
                    Case "5"
                        sFields = sFields & ", pbstrans.Reference as Group" & CStr(X)
                    Case "6"
                        sFields = sFields & ", pbstrans.Details as Group" & CStr(X)
                    Case "7"
                        sFields = sFields & ", pbstrans.Transfer as Group" & CStr(X)
                    Case Else
                        'sFields = sFields & ", '' as Group" & CStr(X)
                End Select
            Next X

            sSql = "SELECT " & sFields & " INTO RecTransTemp"
            sSql = sSql & " FROM dirpbs, pbstrans, "
            sSql = sSql & " pbstrans LEFT JOIN dirpbs"
            sSql = sSql & " ON pbstrans.AccountNo = dirpbs.AccountNo"
            sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
            sSql = sSql & " AND (pbstrans.Reconciled <> 'Y' OR pbstrans.Reconciled = null)"  'Not Reconciled
            sSql = sSql & " AND Date <= " & AccessDate(gvBalanceDate)
            sSql = sSql & " ORDER BY Date, Timekey"

            If DoSql(sSql, 1) Then

                'Debug.Print sSql
                sFields = "1 as Type, dirpbs.BudgetNo, dirpbs.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
                sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
                sFields = sFields & ", 0 as TimeKey, '' as DebitCredit"
                sFields = sFields & ", " & CStr(txtGroup1.Text) & " as txtGroup1"
                sFields = sFields & ", '' as Group1"
                sFields = sFields & ", " & CStr(txtGroup2.Text) & " as txtGroup2"
                sFields = sFields & ", '' as Group2"
                sFields = sFields & ", " & CStr(txtGroup3.Text) & " as txtGroup3"
                sFields = sFields & ", '' as Group3"
                sFields = sFields & ", " & CStr(txtGroup4.Text) & " as txtGroup4"
                sFields = sFields & ", '' as Group4"
                sFields = sFields & ", " & AccessDate(gvBalanceDate) & " as Transfer"    'Date"
                'sFields = sFields & ", " & Format$(Val(txtStateBalance), gsTranCCYFmt) & " as Balance"
                sFields = sFields & ", " & CStr(Val(txtCurrentBankBal.Tag)) & " as Balance"     'changed from .Text 21/02/16
                sSql = "INSERT INTO RecTransTemp"
                sSql = sSql & " SELECT " & sFields & " FROM dirpbs"
                sSql = sSql & " WHERE dirpbs.AccountNo = " & qte(gsAccountNo)

                If DoSql(sSql, 1) Then

                    'Debug.Print sSql
                    sFields = "3 as Type, dirpbs.BudgetNo, dirpbs.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
                    sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
                    sFields = sFields & ", 0 as TimeKey, '' as DebitCredit"
                    sFields = sFields & ", " & CStr(txtGroup1.Text) & " as txtGroup1"
                    sFields = sFields & ", '' as Group1"
                    sFields = sFields & ", " & CStr(txtGroup2.Text) & " as txtGroup2"
                    sFields = sFields & ", '' as Group2"
                    sFields = sFields & ", " & CStr(txtGroup3.Text) & " as txtGroup3"
                    sFields = sFields & ", '' as Group3"
                    sFields = sFields & ", " & CStr(txtGroup4.Text) & " as txtGroup4"
                    sFields = sFields & ", '' as Group4"
                    sFields = sFields & ", " & AccessDate(gvBalanceDate) & " as Transfer" 'Date"
                    sFields = sFields & ", " & CStr(gcBalance) & " as Balance"
                    sSql = "INSERT INTO RecTransTemp"
                    sSql = sSql & " SELECT " & sFields & " FROM dirpbs"
                    sSql = sSql & " WHERE dirpbs.AccountNo = " & qte(gsAccountNo)

                    If DoSql(sSql, 1) Then
                        'Debug.Print sSql

                        'Report1.DataFiles(0) = gsDBFileName

                        If gsDBName = "Live" Then
                            AxCrystalReport1.ReportFileName = gsReportDir & "\pbsRecA.rpt"
                        Else
                            AxCrystalReport1.ReportFileName = gsReportDir & "\pbsRecB.rpt"
                        End If

                        AxCrystalReport1.ReportSource = 0            'use rpt format
                        AxCrystalReport1.Destination = 0             'Screen
                        'Call SetPrinterOrient(PORTRAIT)
                        '                    On Error GoTo Retry
                        AxCrystalReport1.Action = 1                  'Do it
                        '                    On Error GoTo 0
                        'Call ReSetPrinterOrient()
                    End If
                End If
            End If
        Else
            Msg = " No records selected"
            Title = "Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
        End If

        Call SetHourGlassDefault()

        Exit Sub

Retry:

        nRetryCount = nRetryCount + 1
        If nRetryCount < 3 Then
            Resume
        Else
            'Call ErrorMessage("Print Report", Err, Error$, "")
            On Error GoTo 0

            Call SetHourGlassDefault()
        End If

        Exit Sub

CmdOkReport_Click_Error:

        'Call ErrorMessage("Print Report", Err, Error$, "")
        On Error GoTo 0

        Call SetHourGlassDefault()

        Exit Sub

        'GroupBox4.Visible = False
        'GroupBox5.Visible = True
        CmdOkReport.Visible = False

    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        Dim EditDate As Date
        'Dim EditTime As DateTime
        Dim EditTime As Date 'changed 12/03/20
        Dim nSortNo As Integer
        Dim nCounter As Integer

        'Update DB

        Call SetHourGlassWait()

        PbstransBindingSource.MoveFirst()

        'Iterate through the rows
        For nCounter = 0 To (PbstransBindingSource.Count - 1)

            If PbstransBindingSource.Item(nCounter)("Reconciled") = "n" Then 'pending reconciliation

                EditDate = PbstransBindingSource.Item(nCounter)("Date")
                EditTime = PbstransBindingSource.Item(nCounter)("TimeKey")

                Call UpdateReconciledPBSRecord(EditDate, EditTime, "Y") 'now reconciled

            End If

        Next

        PbstransBindingSource.EndEdit()

        RecTransBindingSource.MoveFirst()

        'Iterate through the rows - note that Balance field used for nSortNo, Sort Code for Rec code
        For nCounter = 0 To (RecTransBindingSource.Count - 1)

            If RecTransBindingSource.Item(nCounter)("Sort Code") = "n" Then 'pending reconciliation - Rec codes (N,n,Y)

                nSortNo = RecTransBindingSource.Item(nCounter)("Balance")

                Call UpdateReconciledRecTransRecord(nSortNo, "Y") 'now reconciled 

            End If

        Next

        RecTransBindingSource.EndEdit()

        Call RefreshDetails()
        Call frmPbsTrans.RefreshDetails() 'added 13/03/2020 to update Rec field display

        Call GetAdjBalance()

        'txtCurrentBankBal.Tag = Val(txtCurrentBankBal.Text)                    'store unformatted balance in .Tag 21/02/16
        txtCurrentBankBal.Text = FormatNumber(Val(txtCurrentBankBal.Tag), 2)    'format .Text for display
        lblCurrentPBSBal.Text = FormatNumber(gcBalance, 2)                      'CStr(Format(gcBalance, "n"))

        Call SetHourGlassDefault()

        'GroupBox4.Visible = False
        'GroupBox5.Visible = True

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click

        GroupBox4.Visible = False
        'GroupBox5.Visible = True
        CmdOkReport.Visible = False
        CmdOk.Visible = True

    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click

        Me.Close()

    End Sub

    Private Sub UpdateReconciledPBSRecord(sRecDate As Date, sRecTimeKey As Date, sFlag As String)

        Dim sSql As String
        Dim bOk As Boolean

        Call SetHourGlassWait()

        If gsAccountNo <> "None selected   " Then

            sSql = "UPDATE pbstrans"
            sSql = sSql & " SET pbstrans.Reconciled = " & qte(sFlag)    'store Reconciliation id for  N, n, Y'
            sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
            sSql = sSql & " AND pbstrans.Date = " & AccessDate(sRecDate)
            sSql = sSql & " AND pbstrans.Timekey = " & AccessTime(sRecTimeKey)
            'sSql = sSql & " AND pbstrans.Reconciled <> 'Y'"""           '23/07/2018

            bOk = DoSql(sSql, 1)
            bOk = DoSql2(sSql, 1)
            bOk = DoSql3(sSql, 1)

        End If

        Call SetHourGlassDefault()

    End Sub

    Private Sub UpdateReconciledRecTransRecord(nSortNo As Integer, sFlag As String)

        Dim sSql As String
        Dim bOk As Boolean

        Call SetHourGlassWait()

        If gsAccountNo <> "None selected   " Then

            sSql = "UPDATE Rectrans"
            sSql = sSql & " SET [Sort Code] = " & qte(sFlag)            'store Reconciliation id for N, n, Y'
            sSql = sSql & " WHERE Rectrans.Balance = " & (nSortNo)      'Balance used for unique Sort field

            bOk = DoSql(sSql, 1)
            bOk = DoSql2(sSql, 1)
            bOk = DoSql3(sSql, 1)

        End If

        Call SetHourGlassDefault()

    End Sub

    Private Sub PutPbsRecValue(sRecStatus As String)

        'PbsTrans
        Dim sName As String
        Dim dAmount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridPbsTrans.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridPbsTrans.Columns(counter).HeaderText.ToString

            'If DataGridPbsTrans.SelectedCells(counter).FormattedValueType Is _
            'Type.GetType("DateTime") Then 'Type.GetType("System.date") The
            If sName = "Date" Then
                'Dim value As Date = Nothing

                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                     .EditedFormattedValue
                Else

                    DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                        .FormattedValue
                End If

                Select Case sName

                    Case "Date"
                        'txtDate.Text = DateTimePickerAccessibleObject.ToString
                        'mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

                    Case Else

                End Select

            End If

            If sName = "TimeKey" Then
                Dim value As Date = Nothing

                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.EditedFormattedValue()
                    value = DataGridPbsTrans.SelectedCells(counter).Value.ToString
                Else

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.FormattedValue()
                    value = DataGridPbsTrans.SelectedCells(counter).Value.ToString
                End If

                Select Case sName

                    Case "TimeKey"
                        'txtTimeKey.Text = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        'txtTimeKey.Tag = txtTimeKey.Text
                    Case Else

                End Select

            End If

            If DataGridPbsTrans.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    value = DataGridPbsTrans.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridPbsTrans.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName

                    Case "Reference"
                        'cboReference.Text = value
                    Case "Analysis"
                        'cboAnalysis.Text = value
                    Case "Glcode"
                        'cboGLcode.Text = value
                    Case "Customer"
                        'cboCustomer.Text = value
                    Case "Details"
                        'txtDetails.Text = value
                    Case "DebitCredit"
                        'cboPayReceipt.Text = value
                    Case "Amount"
                        'dAmount = value
                    Case "VAT"
                        'txtEquiv.Text = CStr(value)
                    Case "Reconciled"
                        DataGridPbsTrans.SelectedCells(counter).Value = sRecStatus '"n" = Provisionally Reconciled!
                        'txtRec.Text = value
                    Case "Transfer"
                        'cboTransfer.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetPbsRecValues(ByRef sPbsCustomer As String, ByRef nPbsDebitAmount As Double, ByRef nPbsCreditAmount As Double, ByRef sPayReceipt As String, ByRef dDateKey As Date, ByRef dTimeKey As DateTime)

        'PbsTrans record for selected grid row
        Dim sName As String
        Dim DateTimePickerAccessibleObject As Object = 0
        Dim counter As Integer

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridPbsTrans.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridPbsTrans.Columns(counter).HeaderText.ToString

            'If DataGridPbsTrans.SelectedCells(counter).FormattedValueType Is _
            'Type.GetType("DateTime") Then 'Type.GetType("System.date") The
            If sName = "Date" Then

                Dim value As Date = Nothing

                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                     .EditedFormattedValue
                Else

                    DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                        .FormattedValue
                End If

                Select Case sName

                    Case "Date"
                        dDateKey = DateTimePickerAccessibleObject.ToString
                        'mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

                    Case Else

                End Select

            End If

            If sName = "TimeKey" Then

                Dim value As Date = Nothing

                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.EditedFormattedValue()
                    value = DataGridPbsTrans.SelectedCells(counter).Value.ToString
                Else

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.FormattedValue()
                    value = DataGridPbsTrans.SelectedCells(counter).Value.ToString
                End If

                Select Case sName

                    Case "TimeKey"
                        dTimeKey = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        'txtTimeKey.Tag = txtTimeKey.Text
                    Case Else

                End Select

            End If

            If DataGridPbsTrans.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridPbsTrans.IsCurrentCellDirty = True) Then

                    value = DataGridPbsTrans.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridPbsTrans.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName

                    Case "Reference"
                        'cboReference.Text = value
                    Case "Analysis"
                        'cboAnalysis.Text = value
                    Case "Glcode"
                        'cboGLcode.Text = value
                    Case "Customer"
                        sPbsCustomer = value
                    Case "Details"
                        'txtDetails.Text = value
                    Case "DebitCredit"
                        sPayReceipt = value
                    Case "Payment"
                        If value <> "" Then
                            nPbsDebitAmount = value
                        End If
                    Case "Receipt"
                        If value <> "" Then
                            nPbsCreditAmount = value
                        End If
                    Case "Reconciled"
                        'DataGridPbsTrans.SelectedCells(counter).Value = sRecStatus '"n" = Provisionally Reconciled!
                        'txtRec.Text = value
                    Case "Transfer"
                        'cboTransfer.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub PutBankRecValue(sRecStatus As String)

        'RecTrans

        Dim sName As String
        Dim dAmount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridBankTrans.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridBankTrans.Columns(counter).HeaderText.ToString

            'If DataGridBankTrans.SelectedCells(counter).FormattedValueType Is _
            'Type.GetType("DateTime") Then 'Type.GetType("System.date") The
            If sName = "Date" Then
                'Dim value As Date = Nothing

                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                     .EditedFormattedValue
                Else

                    DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                        .FormattedValue
                End If

                Select Case sName

                    Case "Date"
                        'txtDate.Text = DateTimePickerAccessibleObject.ToString
                        'mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

                    Case Else

                End Select

            End If

            If sName = "TimeKey" Then
                Dim value As Date = Nothing

                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    'DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                    '.EditedFormattedValue()
                    'value = DataGridBankTrans.SelectedCells(counter).Value.ToString
                Else

                    'DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                    '.FormattedValue()
                    'value = DataGridBankTrans.SelectedCells(counter).Value.ToString
                End If

                Select Case sName

                    Case "TimeKey"
                        'txtTimeKey.Text = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        'txtTimeKey.Tag = txtTimeKey.Text
                    Case Else

                End Select

            End If

            If DataGridBankTrans.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    value = DataGridBankTrans.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridBankTrans.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName

                    Case "Reference"
                        'cboReference.Text = value
                    Case "Analysis"
                        'cboAnalysis.Text = value
                    Case "Glcode"
                        'cboGLcode.Text = value
                    Case "Customer"
                        'sCustomer.Text = value
                    Case "Details"
                        'txtDetails.Text = value
                    Case "DebitCredit"
                        'sPayReceipt.Text = value
                    Case "Amount"
                        'dAmount = value
                    Case "VAT"
                        'txtEquiv.Text = CStr(value)
                    Case "Reconciled"
                        DataGridBankTrans.SelectedCells(counter).Value = sRecStatus '"n" = Provisionally Reconciled!
                        'txtRec.Text = value
                    Case "Transfer"
                        'cboTransfer.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetBankRecValues(ByRef sCustomer As String, ByRef nRecDebitAmount As Double, ByRef nRecCreditAmount As Double, ByRef nSortNo As String)

        'RecTrans  record for selected grid row
        Dim sName As String
        Dim DateTimePickerAccessibleObject As Object = 0

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridBankTrans.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridBankTrans.Columns(counter).HeaderText.ToString

            'If DataGridBankTrans.SelectedCells(counter).FormattedValueType Is _
            'Type.GetType("DateTime") Then 'Type.GetType("System.date") The
            If sName = "Date" Then
                'Dim value As Date = Nothing

                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                     .EditedFormattedValue
                Else

                    DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                        .FormattedValue
                End If

                Select Case sName

                    Case "Date"
                        'txtDate.Text = DateTimePickerAccessibleObject.ToString
                        'mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

                    Case Else

                End Select

            End If

            If sName = "TimeKey" Then
                Dim value As Date = Nothing

                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    'DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                    '.EditedFormattedValue()
                    'value = DataGridBankTrans.SelectedCells(counter).Value.ToString
                Else

                    'DateTimePickerAccessibleObject = DataGridBankTrans.SelectedCells(counter) _
                    '.FormattedValue()
                    'value = DataGridBankTrans.SelectedCells(counter).Value.ToString
                End If

                Select Case sName

                    Case "TimeKey"
                        'txtTimeKey.Text = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        'txtTimeKey.Tag = txtTimeKey.Text
                    Case Else

                End Select

            End If

            If DataGridBankTrans.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridBankTrans.IsCurrentCellDirty = True) Then

                    value = DataGridBankTrans.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridBankTrans.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName

                    Case "Reference"
                        'cboReference.Text = value
                    Case "Analysis"
                        'cboAnalysis.Text = value
                    Case "Glcode"
                        'cboGLcode.Text = value
                    Case "Customer"
                        sCustomer = value
                    Case "Details"
                        'txtDetails.Text = value
                    Case "DebitCredit"
                        'cboPayReceipt.Text = value
                    Case "Payment"
                        If value <> "" Then
                            nRecDebitAmount = value
                        End If
                    Case "Receipt"
                        If value <> "" Then
                            nRecCreditAmount = value
                        End If
                    Case "Sort Code"
                        'nSortNo stored in Balance field
                        nSortNo = value
                    Case "Transfer"
                        'cboTransfer.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            bOk = PbstransTableAdapterLive.ClearBeforeFill
            bOk = RecTransTableAdapterLive.ClearBeforeFill
            Me.PbstransTableAdapterLive.Fill(Me.VpbsDataSet.pbstrans)
            Me.RecTransTableAdapterLive.Fill(Me.VPBSDataSet9.RecTrans)
            PbstransBindingSource.DataSource = VpbsDataSet.pbstrans
            RecTransBindingSource.DataSource = VPBSDataSet9.RecTrans
        ElseIf gsDBName = "Archive" Then                                'todo
            bOk = PbstransTableAdapterArc.ClearBeforeFill
            bOk = RecTransTableAdapterLive.ClearBeforeFill
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            Me.RecTransTableAdapterArc.Fill(Me.VpbsArchiveDataSet4.RecTrans)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet.pbstrans
            RecTransBindingSource.DataSource = VpbsArchiveDataSet4.RecTrans
        ElseIf gsDBName = "Test" Then                                   'todo
            bOk = PbstransTableAdapterTest.ClearBeforeFill
            bOk = RecTransTableAdapterTest.ClearBeforeFill
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            Me.RecTransTableAdapterTest.Fill(Me.VpbsTestDataSet1.RecTrans)
            PbstransBindingSource.DataSource = VpbsTestDataSet.pbstrans
            RecTransBindingSource.DataSource = VpbsTestDataSet1.RecTrans
        End If

    End Sub

    Private Sub GetAdjBalance()

        Call GetRecBalance()
        lblAdjBankBal.Text = CStr(Format(RecBalance, "n"))

    End Sub

    Private Sub GetRecBalance()

        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()

        sSql = "SELECT sum(Amount) as UnRecTotal FROM pbstrans"
        sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
        sSql = sSql & " AND pbstrans.Reconciled = 'N' "

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                If Not IsDBNull(ds.Rows.Item(nCount)("UnRecTotal")) Then
                    RecBalance = ds.Rows.Item(nCount)("UnRecTotal") + Val(txtCurrentBankBal.Tag) '.Text)
                Else
                    RecBalance = Val(txtCurrentBankBal.Tag) '.Text)
                End If

                nCount = nCount + 1

            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub GetRecTransBalance()

        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()

        sSql = "Select BalanceEquivalent from dirpbs"
        sSql = sSql & " Where AccountNo = " & qte(gsAccountNo)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0 'get first record = latest date
            RecTransBalance = ds.Rows.Item(nCount)("BalanceEquivalent")

        Else

            RecTransBalance = 0

        End If

        ds.Dispose()

        txtCurrentBankBal.Tag = CStr(RecTransBalance)
        txtCurrentBankBal.Text = CStr(FormatNumber(RecTransBalance, 2))

        Call SetHourGlassDefault()

    End Sub

    Private Sub txtCurrentBankBal_LostFocus(sender As Object, e As EventArgs) Handles txtCurrentPBSBal.LostFocus

        txtCurrentBankBal.Tag = Val(txtCurrentBankBal.Text)     'store unformatted balance in .Tag 23/11/17

    End Sub

    Private Sub CboGroupsFill()

        cboGroup1.Items.Clear()
        cboGroup1.Items.Add("Customer")
        cboGroup1.Items.Add("Analysis code")
        cboGroup1.Items.Add("Account code")
        cboGroup1.Items.Add("GL code")
        cboGroup1.Items.Add("Reference")
        cboGroup1.Items.Add("Details")
        cboGroup1.Items.Add("Transfer")

        cboGroup2.Items.Clear()
        cboGroup2.Items.Add("Customer")
        cboGroup2.Items.Add("Analysis code")
        cboGroup2.Items.Add("Account code")
        cboGroup2.Items.Add("GL code")
        cboGroup2.Items.Add("Reference")
        cboGroup2.Items.Add("Details")
        cboGroup2.Items.Add("Transfer")

        cboGroup3.Items.Clear()
        cboGroup3.Items.Add("Customer")
        cboGroup3.Items.Add("Analysis code")
        cboGroup3.Items.Add("Account code")
        cboGroup3.Items.Add("GL code")
        cboGroup3.Items.Add("Reference")
        cboGroup3.Items.Add("Details")
        cboGroup3.Items.Add("Transfer")

        cboGroup4.Items.Clear()
        cboGroup4.Items.Add("Customer")
        cboGroup4.Items.Add("Analysis code")
        cboGroup4.Items.Add("Account code")
        cboGroup4.Items.Add("GL code")
        cboGroup4.Items.Add("Reference")
        cboGroup4.Items.Add("Details")
        cboGroup4.Items.Add("Transfer")

        'set defaults
        cboGroup1.SelectedIndex = 4 '3   'Reference
        cboGroup2.SelectedIndex = 0   'Customer
        cboGroup3.SelectedIndex = 5 '4   'Details
        cboGroup4.SelectedIndex = 1   'Analysis

    End Sub

    Private Sub DataGridPbsTrans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPbsTrans.CellContentClick

        Dim dDateKey As Date
        Dim dTimeKey As DateTime
        Dim sPbsCustomer As String = ""
        Dim nPbsDebitAmount As Double
        Dim nPbsCreditAmount As Double
        Dim sPayReceipt As String = ""

        Call GetPbsRecValues(sPbsCustomer, nPbsDebitAmount, nPbsCreditAmount, sPayReceipt, dDateKey, dTimeKey)

        'copy values to tagfields
        txtdDateKey.Text = dDateKey
        txtdTimeKey.Text = dTimeKey
        txtsPbsCustomer.Text = sPbsCustomer
        txtPayReceipt.Text = sPayReceipt
        txtnPbsDebitAmount.Text = nPbsDebitAmount
        txtnPbsCreditAmount.Text = nPbsCreditAmount
        txtPayReceipt.Tag = txtPayReceipt.Text
        txtnPbsDebitAmount.Tag = txtnPbsDebitAmount.Text
        txtnPbsCreditAmount.Tag = txtnPbsCreditAmount.Text

    End Sub

    Private Sub DataGridPbsTrans_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPbsTrans.CellValueChanged

        Dim dDateKey As Date
        Dim dTimeKey As Date
        Dim sAccountNo As String
        Dim sPbsCustomer As String = ""
        Dim nPbsDebitAmount As Double
        Dim nPbsCreditAmount As Double
        Dim sPayReceipt As String = ""
        Dim sSql As String
        Dim Title As String
        Dim Msg As String
        Dim Amount As Double = 0
        Dim bOk As Integer 'Boolean

        If txtPayReceipt.Text <> "" And cmdAcceptflag = False Then 'avoid call from form.load

            'get any changed values?
            Call GetPbsRecValues(sPbsCustomer, nPbsDebitAmount, nPbsCreditAmount, sPayReceipt, dDateKey, dTimeKey)

            If txtPayReceipt.Text <> sPayReceipt Or txtnPbsDebitAmount.Tag <> nPbsDebitAmount Or txtnPbsCreditAmount.Tag <> nPbsCreditAmount Then

                Title = "VPBS Changes made! "
                Msg = "Click on 'Ok' to accept changes, or 'Cancel'"
                bOk = MsgBox(Msg, MsgBoxStyle.OkCancel, Title)

                If bOk = vbOK Then

                    '
                    'Update transaction in PbsTrans
                    '
                    sSql = "Update pbstrans"
                    sSql = sSql + " Set"

                    If sPayReceipt = "Payment" Then
                        Amount = CDec(Val(nPbsDebitAmount))
                        sSql = sSql + " Payment = " + qte(Amount)               'Payment
                        sSql = sSql + ", Receipt = null"                        'Receipt
                        sSql = sSql + ", Amount = " + qte(Amount * -1)          'Amount Swap sign
                    Else
                        Amount = CDec(Val(nPbsCreditAmount))
                        sSql = sSql + "  Payment = null"                        'Payment
                        sSql = sSql + ", Receipt = " + qte(Amount)              'Receipt
                        sSql = sSql + ", Amount = " + qte(Amount)               'Amount
                    End If

                    sSql = sSql + " Where Date = " + AccessDate(dDateKey)
                    sSql = sSql + " And Timekey = " + AccessTime(dTimeKey)
                    sSql = sSql + " And AccountNo = " + qte(gsAccountNo)
                    '
                    'ok, let's do it
                    '
                    If DoSql(sSql, 1) Then

                        'update balances
                        sAccountNo = gsAccountNo
                        gvPreviousPostDate = dDateKey
                        gvPreviousPostTimeKey = AccessTime(dTimeKey)

                        Call UpdateBalancesDBRec(sAccountNo)

                    End If

                Else   'vbCancel

                    'reinstate original values?

                End If

                'refresh screen
                Call RefreshDetails()

            End If

        End If

    End Sub

    Private Sub UpdateBalancesDBRec(sAccountNo As String)

        Dim sSql As String
        Dim PreviousPostDate As Date
        Dim PreviousPostTimeKey As Date
        Dim EditDate As Date
        Dim EditTime As DateTime
        Dim newBalance As Double
        Dim oldBalance As Double
        Dim nCount As Integer
        Dim bof As Boolean = False

        Call SetHourGlassWait()

        '
        'get PreviousPostDate by selecting all records prior to last one changed - use Sum?
        '
        sSql = "SELECT * FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(sAccountNo) 'gsAccountNo)
        sSql = sSql & " AND Date < " & AccessDate(gvPreviousPostDate) 'get previous DateTime?
        'sSql = sSql & " AND TimeKey < " & AccessTime(gvPreviousPostTimeKey) 'was AccessDate
        sSql = sSql & " ORDER BY [Date],[Timekey]"

        Dim Prevadapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim pds As New DataTable
        Prevadapter.Fill(pds)

        '
        'get oldBalance and PreviousPostDate from last record of DataTable
        '
        If pds.Rows.Count > 0 Then
            bof = False
            nCount = pds.Rows.Count - 1 'look at last record before 'new' transaction
            oldBalance = pds.Rows.Item(nCount)("Balance")
            PreviousPostDate = pds.Rows.Item(nCount)("Date") 'Date of Transaction before gvPreviousPostDate
            PreviousPostTimeKey = AccessTime(pds.Rows.Item(nCount)("TimeKey")) '20/12/17
        Else
            bof = True
            oldBalance = 0
            'gvPreviousPostDate unchanged
            PreviousPostDate = gvPreviousPostDate
            PreviousPostTimeKey = AccessTime(gvPreviousPostTimeKey)
        End If

        pds.Dispose()

        '
        'create new DataTable of transactions for selected account number'
        'accumulate balance and write each balance to DB
        '
        sSql = "SELECT * FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(sAccountNo) ' gsAccountNo)
        If bof = False Then
            sSql = sSql & " AND Date > " & AccessDate(PreviousPostDate) 'Date of Transaction before gvPreviousPostDate - removed '=' added '='
            'sSql = sSql & " AND TimeKey >= " & AccessTime(PreviousPostTimeKey) 'was AccessDate ????
        End If
        sSql = sSql & " ORDER BY [Date],[Timekey]"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        newBalance = 0

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                EditDate = ds.Rows.Item(nCount)("Date")
                EditTime = AccessTime(ds.Rows.Item(nCount)("TimeKey"))

                'accumulate Balance for each record
                If ds.Rows.Item(nCount)("DebitCredit") = "Payment" Then
                    newBalance = oldBalance - Val(ds.Rows.Item(nCount)("Payment")).ToString
                Else
                    newBalance = oldBalance + Val(ds.Rows.Item(nCount)("Receipt")).ToString
                End If

                Call frmPbsTrans.UpdateBalanceDB(sAccountNo, EditDate, EditTime, newBalance) 'Write Balance to DB

                oldBalance = newBalance

                nCount = nCount + 1

            Loop

        Else

            EditDate = PreviousPostDate                             'default 21/02/16
            newBalance = oldBalance '= 0                            'default to oldBalance 21/02/16

        End If

        ds.Dispose()

        If giProjSO = False Then
            Call frmPbsTrans.UpdateDirBalanceDB(sAccountNo, EditDate, newBalance)
        Else
            frmPbsTrans.txtProjBalance.Text = CStr(FormatNumber(newBalance, 2))
        End If

        Call frmPbsTrans.DisplayHeader() 'added 20/11/17
        Call frmPbsTrans.DisplayDetails() 'added 20/11/17

        Call SetHourGlassDefault()

    End Sub


    Private Sub txtGroup1_TextChanged(sender As Object, e As EventArgs) Handles txtGroup1.TextChanged

    End Sub
End Class