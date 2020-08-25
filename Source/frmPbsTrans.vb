'****************************************************************************************************************************
'Visual Personal Banking System v2013/2019
'Copyright Jack Gibbons 1980-2020
'
'Bank Statements View/Edit, incorporating DirPbs Selection, Find, Forward Projections - Added Report option
'****************************************************************************************************************************
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'22/03/15   jpg     Copied from Vpbs78
'29/03/15   jpg     Add and SO's now working
'30/03/15   jpg     Changed Edit to use Sql update, using DoSql()
'09/04/15   jpg     Add and Edit now working, Delete added
'20/08/15   jpg     Find added
'31/08/15   jpg     Find UpdateBalances() fixed
'02/09/15   jpg     Added new UpdateBalancesDB() for Add/Change/Delete
'                   Recalculates balances for affected records only
'                   Writes balances to DB using DoSql()
'                   Add/Change/Delete now working again
'                   Add/Change/Delete written to DB using Sql only, grids are display only
'13/09/15   jpg     Fixed problem with UpdateBalancesDB(): select records for recalculating
'                   balances > PreviousPostDate (instead of >= PreviousPostDate)
'                   Added UpdateDirBalanceDB() for Add/Change/Delete: now working correctly
'26/09/15   jpg     Forward Projections added 
'to                 Problem adding Proj records due to duplicate keys, Date and TimeKey: too many
'27/09/15           records being added in one second. Added counter to increment seconds between records
'                   being written.
'                   Updated balances not working on new records.
'                   Changed to use UpdatedBalancesDB, but don't write to dirpbs.
'31/10/15   jpg     Changed to use one BindingSource for all DB's
'06/12/15   jpg     Added Bank Statement report, Crystal report
'                   Added Post Transfer, Edit Transfer, Delete Transfer
'06/01/16   jpg     Change GetTransferID & SaveTransferID to use GetParameter & SaveParameter with 
'                   Live DB only (as per VB6 version)
'                   Moved 'Concurrent SO's on/off?' & 'Passwords On/Off' menu items to StartUp form 
'09/01/16   jpg     Modified Post Transfer, Edit Transfer, Delete Transfer, Currency Transfer & SO Transfer to work
'10/01/16   jpg     After copying Live to Test DB for Test Run, had to edit sotrans to replace null data with zero
'16/01/16   jpg     Added Archive dataset...
'03/02/16   jpg     Added DirpbsTableAdapterx.Fill to DisplayDetails/RefreshDetails
'04/02/16   jpg     gcBalance & gcBalanceDate not updated in UpdateDirBalanceDB. Also Modified DisplayHeader.
'05/02/16   jpg     Re-instated sTransfer = dso.Rows.... in Poststandingorder
'15/02/16   jpg     Added cboTransfer.Items.Clear() to CboTransferFill()
'16/02/16   jpg     Fixed errors in PostStandingOrder re PayReceipt(DebitCredit)
'18/02/16   jpg     Fixed errors in EditTransaction re TransferID
'19/02/16   jpg     Modified PostTransfer, EditTransfer, DeleteTransfer, PostSOTransfer re UpdateBalancesDB for
'                   all affected accounts
'21/02/16   jpg     Modified UpdateBalancesDB to default EditDate to PreviousPostDate and newBalance to oldBalance 
'                   when transaction is last entry in dataset         
'25/03/16   jpg     Problem with changing an amount from Payment to Receipt as Amount appears on screen in two columns!
'                   Modified EditTransaction - Update Payment/Receipt with null for 'non used' field.
'28/04/16   jpg     Modified cboPayReceipt_LostFocus and cmd_ok to default to 'Payment'
'01/05/16   jpg     Removed cboPayReceipt.Text = "Payment" from EditTransaction & CmdAdd_Click
'29/05/16   jpg     CmdChange_Click: "Equiv." added to copy Equiv value to Edit panel
'                   EditTransfer: do not change Reconciled field in DB. Code disabled.
'30/06/16   jpg     Added UpdateBalancesTfrDB() to fix problems with updating balances re Transfers
'                   Affects PostTransfer (done), EditTransfer (done 26/11/16) & DeleteTransfer (done 26/11/16)
'03/11/16   jpg     Set CmdOk to Bring to front
'26/11/16   jpg     Fixed Next Chq/Next Pay-in feature
'01/01/17   jpg     Removed unused icons (Project/Properties/References)
'           jpg     Removed symbols (Debug/Options and Settings) from project
'           jpg     Removed VPBS130105 Connection string from VPBS13.My.MySettings as no longer used
'15/01/17   jpg     RefreshDetails: added giUserLevel check 
'                   otherwise dirpbs records not selected on re - Select a/c when userlevel = 1
'16/01/17   jpg     Recreated PbsTrnB.rpt from PbsTrnA.rpt, but modified to read from Archive DB - Ok
'27/01/17   jpg     CmdAdd(Click) added cboPayReceipt.Text = "Payment" as default
'19/09/17   jpg     PostTransaction(), EditTransaction(): added error handler
'03/12/17   jpg     DoSql2 and gsVpbsConnection2 to import file to dev DB
'28/06/18   jpg     Added GetDirPbsAccountNo to check Account No of Imported file exists in DirPbs
'                   and add any leading zeros, otherwise abort Import.
'
'04/03/20   jpg     Now running on Win10 Pro VB19. No changes made to code apart from a Cystal Report property!
'13/03/20   jpg     Changed VPBS Settings to use Local DB (C:\VPBS\) instead of |Data Directory|\DB
'13/03/20   jpg     RefreshDetails - Need Movelast after being called from frmBankRec
'11/08/20   jpg     If Archive DB selected switch off Rec menu items as not needed 
'                   (also problem accessing RecData table - may not be in Archive DB!)

'Builds
'
'02/01/17   jpg     Build and Publish v13.0.0.10
'12/08/20   jpg     Build and Publish v19.0.0.05
'****************************************************************************************************************************
Public Class frmPbsTrans

    Public Property TopLeftHeaderCell As DataGridViewHeaderCell

    Dim msAccountNo As String = Nothing
    Dim sAccountName As String = Nothing
    Dim sAccountDesc As String = Nothing
    Dim sBankName As String = Nothing
    Dim sBankBranch As String = Nothing
    Dim sBalanceDate As Date = Nothing
    Dim sBalance As Double = Nothing
    Dim mvLastDate As Date = Nothing
    Dim miUpdate As Integer = Nothing
    Dim miTransfer As Short = Nothing
    Dim miTfrUpdate As Integer = Nothing
    Dim msSelection As String = Nothing
    'Dim sDirpbsAccountNo As String = ""
    Dim sRecTransAccountNo As String = Nothing 'added 30/06/18
    'Private status As New StatusBar()

    Private Sub frmPbsTrans_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VpbsDataSet.Customers' table. You can move, or remove it, as needed.

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            'gsVpbsConnection2 & gsVpbsConnection3 no longer required but referenced in DoSql2 & 3 jpg 25/08/20
            gsVpbsConnection2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB" 'C:\USERS\JACK\DEVELOP\VPBS13\bin\Release\VPBS.MDB" 'added 3/12/17 for file import
            gsVpbsConnection3 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB" 'C:\USERS\JACK\DEVELOP\VPBS13\VPBS.MDB" 'added 13/12/17 for file import

            'TODO: This line of code loads data into the 'VPBSDataSet.dirpbs' table. You can move, or remove it, as needed.
            Me.DirpbsTableAdapterLive.Fill(Me.VPBSDataSet.dirpbs)
            Me.PbstransTableAdapterLive.Fill(Me.VPBSDataSet.pbstrans)
            Me.AnalysisTableAdapter.Fill(Me.VPBSDataSet.Analysis)
            Me.GLCodeTableAdapter.Fill(Me.VPBSDataSet.GLCode)
            Me.CustomersTableAdapter.Fill(Me.VPBSDataSet.Customers)

            DirpbsBindingSource.DataSource = VPBSDataSet
            PbstransBindingSource.DataSource = VPBSDataSet
            AnalysisBindingSource.DataSource = VPBSDataSet
            GLCodeBindingSource.DataSource = VPBSDataSet
            CustomersBindingSource.DataSource = VPBSDataSet

            'Else

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"

            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            Me.AnalysisTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Analysis)
            Me.GLCodeTableAdapterArc.Fill(Me.VpbsArchiveDataSet.GLCode)
            Me.CustomersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Customers)

            DirpbsBindingSource.DataSource = VpbsArchiveDataSet
            PbstransBindingSource.DataSource = VpbsArchiveDataSet
            AnalysisBindingSource.DataSource = VpbsArchiveDataSet
            GLCodeBindingSource.DataSource = VpbsArchiveDataSet
            CustomersBindingSource.DataSource = VpbsArchiveDataSet

            'switch off Rec menu items for Archive DB 11/08/20
            ImportBankStatementToolStripMenuItem.Visible = False
            ReconciliationToolStripMenuItem.Visible = False
            ReconciliationToolStripMenuItem1.Visible = False
            ReconciiationStatementToolStripMenuItem.Visible = False

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"

            Me.DirpbsTableAdapterTest.Fill(Me.VpbsTestDataSet.dirpbs)
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            Me.AnalysisTableAdapterTest.Fill(Me.VpbsTestDataSet.Analysis)
            Me.GLCodeTableAdapterTest.Fill(Me.VpbsTestDataSet.GLCode)
            Me.CustomersTableAdapterTest.Fill(Me.VpbsTestDataSet.Customers)

            DirpbsBindingSource.DataSource = VpbsTestDataSet
            PbstransBindingSource.DataSource = VpbsTestDataSet
            AnalysisBindingSource.DataSource = VpbsTestDataSet
            GLCodeBindingSource.DataSource = VpbsTestDataSet
            CustomersBindingSource.DataSource = VpbsTestDataSet

        End If

        If giUserLevel = 1 Then
            DirpbsBindingSource.Filter = ""
        Else
            DirpbsBindingSource.Filter = "Username = '" + gsUserName + "'"  'Select'
        End If

        DirpbsBindingSource.Sort = "Currency, AccountNo" 'Order By'
        PbstransBindingSource.Filter = "AccountNo = '" + gsAccountNo + "'" 'Select'
        PbstransBindingSource.Sort = "Date, TimeKey" 'Order By'
        PbstransBindingSource.MoveLast()
        AnalysisBindingSource.Sort = "Code"
        GLCodeBindingSource.Sort = "Code"
        CustomersBindingSource.Sort = "ShortName"

        DataGridDirPbs.DataSource = DirpbsBindingSource
        DataGridPbsTrans.DataSource = PbstransBindingSource
        DataGridDirPbs.TopLeftHeaderCell.Value = gsDBName '"------"
        DataGridPbsTrans.TopLeftHeaderCell.Value = gsDBName '"------"
        DataGridDirPbs.Visible = True
        DataGridPbsTrans.Visible = False

        GroupBox2.Visible = False 'Add/Change/Delete

        Me.Icon = frmStartUp.Icon
        Me.Text = "Personal Banking System [" + gsDBName + " Data] - Logged in as " + gsUserName

        gsDaysPerMonth = ".312831303130313130313031"
        mvLastDate = Now
        gsAccountNo = "None selected" '01092174"
        gsTranCCYFmt = "###,##0.00"
        giAutoRec = False

        CmdSelect.Enabled = True
        CmdFind.Enabled = False
        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdOk.Enabled = False
        CmdCancel.Enabled = False

        EditToolStripMenuItem.Enabled = False
        FindToolStripMenuItem.Enabled = False
        ViewToolStripMenuItem.Enabled = False
        QueryToolStripMenuItem.Enabled = False
        ReportToolStripMenuItem.Enabled = False
        BudgetsToolStripMenuItem1.Enabled = False

        Call CboReferenceFill()
        Call UpdateCBO()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridDirPbs.CellContentClick

        'DirPbs
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridDirPbs.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridDirPbs.Columns(counter).HeaderText.ToString

            If DataGridDirPbs.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridDirPbs.IsCurrentCellDirty = True) Then

                    value = DataGridDirPbs.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridDirPbs.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName
                    Case "AccountNo"
                        msAccountNo = value
                        gsAccountNo = msAccountNo
                        gsBudgetNo = gsAccountNo
                    Case "AccountName"
                        sAccountName = value
                        gsAccountName = sAccountName
                    Case "AccountDesc"
                        sAccountDesc = value
                    Case "BankName"
                        sBankName = value
                    Case "BankBranch"
                        sBankBranch = value
                    Case "Balance"
                        sBalance = value
                    Case "BalanceDate"
                        sBalanceDate = value
                    Case Else

                End Select

            End If

            If DataGridDirPbs.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.date") Then

                Dim dvalue As Date = Nothing

                If (DataGridDirPbs.IsCurrentCellDirty = True) Then

                    dvalue = DataGridDirPbs.SelectedCells(counter) _
                        .EditedFormattedValue.
                Else

                    dvalue = DataGridDirPbs.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "BalanceDate"
                        sBalanceDate = dvalue

                    Case Else

                End Select

            End If

            If DataGridDirPbs.SelectedCells(counter).FormattedValueType Is _
             Type.GetType("System.Number") Then

                Dim nvalue As Double = 0

                If (DataGridDirPbs.IsCurrentCellDirty = True) Then

                    nvalue = DataGridDirPbs.SelectedCells(counter) _
                        .EditedFormattedValue
                Else

                    nvalue = DataGridDirPbs.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "Balance"
                        'nBalance = nvalue

                    Case Else

                End Select

            End If
        Next

        'get currency info - transaction ccy
        Call GetTranCCY(gsAccountNo, gsTranCCY)
        Call GetTranCCYFmt()
        'get currency info - base ccy
        Call GetBaseCCY()

        gcBalance = sBalance
        gvBalanceDate = sBalanceDate

        Call DisplayHeader()
        Call DisplayDetails()

        DataGridDirPbs.Visible = False
        DataGridPbsTrans.Visible = True

        CmdSelect.Enabled = True
        CmdFind.Enabled = True
        CmdAdd.Enabled = True
        CmdChange.Enabled = True
        CmdDelete.Enabled = True
        CmdOk.Enabled = False
        CmdCancel.Enabled = False

        If gsAccountNo <> "None selected" Then
            EditToolStripMenuItem.Enabled = True
            FindToolStripMenuItem.Enabled = True
            ViewToolStripMenuItem.Enabled = True
            QueryToolStripMenuItem.Enabled = True
            ReportToolStripMenuItem.Enabled = True
            BudgetsToolStripMenuItem1.Enabled = True
        End If

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Public Sub DisplayDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            bOk = DirpbsTableAdapterLive.ClearBeforeFill
            Me.DirpbsTableAdapterLive.Fill(Me.VPBSDataSet.dirpbs)
            PbstransBindingSource.DataSource = VPBSDataSet.pbstrans
            bOk = PbstransTableAdapterLive.ClearBeforeFill
            Me.PbstransTableAdapterLive.Fill(Me.VPBSDataSet.pbstrans)
            PbstransBindingSource.Filter = "AccountNo =  " & qte(msAccountNo)
            PbstransBindingSource.MoveLast()
            Call CboTransferFill()
        ElseIf gsDBName = "Archive" Then
            bOk = DirpbsTableAdapterArc.ClearBeforeFill
            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet.pbstrans
            bOk = PbstransTableAdapterArc.ClearBeforeFill
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            PbstransBindingSource.Filter = "AccountNo =  " & qte(msAccountNo)
            PbstransBindingSource.MoveLast()
            Call CboTransferFill()
        ElseIf gsDBName = "Test" Then
            bOk = DirpbsTableAdapterTest.ClearBeforeFill
            Me.DirpbsTableAdapterTest.Fill(Me.VpbsTestDataSet.dirpbs)
            PbstransBindingSource.DataSource = VpbsTestDataSet.pbstrans
            bOk = PbstransTableAdapterTest.ClearBeforeFill
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            PbstransBindingSource.Filter = "AccountNo = " & qte(msAccountNo)
            PbstransBindingSource.MoveLast()
            Call CboTransferFill()
        End If

    End Sub

    Public Sub RefreshDetails() 'changed from Private

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            bOk = DirpbsTableAdapterLive.ClearBeforeFill
            Me.DirpbsTableAdapterLive.Fill(Me.VPBSDataSet.dirpbs)
            PbstransBindingSource.DataSource = VPBSDataSet.pbstrans
            bOk = PbstransTableAdapterLive.ClearBeforeFill
            Me.PbstransTableAdapterLive.Fill(Me.VPBSDataSet.pbstrans)
            PbstransBindingSource.MoveLast() 'added 13/03/2020
        ElseIf gsDBName = "Archive" Then
            bOk = DirpbsTableAdapterArc.ClearBeforeFill
            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet.pbstrans
            bOk = PbstransTableAdapterArc.ClearBeforeFill
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            PbstransBindingSource.MoveLast() 'added 13/03/2020
        ElseIf gsDBName = "Test" Then
            bOk = DirpbsTableAdapterTest.ClearBeforeFill
            Me.DirpbsTableAdapterTest.Fill(Me.VpbsTestDataSet.dirpbs)
            PbstransBindingSource.DataSource = VpbsTestDataSet.pbstrans
            bOk = PbstransTableAdapterTest.ClearBeforeFill
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            PbstransBindingSource.MoveLast() 'added 13/03/2020
        End If

        If giUserLevel = 1 Then 'added 15/01/17
            DirpbsBindingSource.Filter = ""
        Else
            DirpbsBindingSource.Filter = "Username = '" + gsUserName + "'"  'Select'
        End If

    End Sub

    Private Sub CboTransferFill()

        Dim AccountNo As String = Nothing
        Dim BankName As String = Nothing
        Dim BankBranch As String = Nothing
        Dim nCount As Integer = 0
        Dim nCounter As Integer = 0

        DirpbsBindingSource.Filter = "Username = " + qte(gsUserName) '+ "'"
        DirpbsBindingSource.Sort = "Currency, AccountNo"

        DirpbsBindingSource.MoveFirst()
        nCount = DirpbsBindingSource.Count

        cboTransfer.Items.Clear() 'added 15/02/16

        cboTransfer.AutoCompleteMode = AutoCompleteMode.Append

        Do While nCounter < nCount

            AccountNo = DirpbsBindingSource.Item(nCounter)("AccountNo").ToString
            BankName = DirpbsBindingSource.Item(nCounter)("BankName").ToString
            BankBranch = DirpbsBindingSource.Item(nCounter)("BankBranch").ToString

            If Val(AccountNo) <> Val(gsAccountNo) Then
                cboTransfer.Items.Add(AccountNo + " - " & BankName & " - " & BankBranch)
            End If

            DirpbsBindingSource.MoveNext()
            nCounter = nCounter + 1

        Loop

    End Sub

    Private Sub CboReferenceFill()

        Dim sSql As String
        Dim nCount As Long

        cboReference.Items.Clear()

        'Select Manual Standing Orders etc
        sSql = "Select * from soTrans Where NumPayments = -1"
        sSql = sSql + " Order by Reference"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboReference.Items.Add(ds.Rows.Item(nCount)("Reference")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub DataGridPbsTrans_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Call CmdChange_Click(AcceptButton, e)

    End Sub

    Private Sub ClearFields()

        txtTimeKey.Text = ""
        cboTransfer.Text = ""
        cboReference.Text = ""
        cboAnalysis.Text = ""
        cboGLcode.Text = ""
        cboCustomer.Text = ""
        cboPayReceipt.Text = ""
        txtDetails.Text = ""
        txtRec.Text = ""
        txtEquiv.Text = ""
        txtAmount.Text = ""
        cboTransfer.Tag = ""
        'cboReference.Tag = ""

        'txtDate.Focus()

    End Sub

    Public Sub PostTransaction()

        Dim TransferID As Integer
        Dim nCount As Integer = 0
        Dim currentTime As Date
        Dim sSql As String = Nothing
        Dim sPayReceipt As String = Nothing
        Dim bOk As Boolean
        Dim Amount As Double

        currentTime = TimeOfDay
        TransferID = 0

        'Process Transfer?
        If miTransfer Then
            miTfrUpdate = giADD
            Call GetTransferID(TransferID)
            TransferID = TransferID + 1
            Call SaveTransferID(Str(TransferID))
        End If

        'strip bank & branch
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1)
        End If

        sPayReceipt = cboPayReceipt.Text                            'added 16/02/16

        '
        'create transaction in PbsTrans
        '
        sSql = "Insert into pbstrans"
        sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
        'If cboPayReceipt.Text = "Payment" Then
        If sPayReceipt = "Payment" Then                             'changed 16/02/16
            sSql = sSql + " Folio, Reconciled, DebitCredit, Payment, Amount, VAT, Transfer, TransferID)"
        Else
            sSql = sSql + " Folio, Reconciled, DebitCredit, Receipt, Amount, VAT, Transfer, TransferID)"
        End If
        sSql = sSql + " Values ("
        sSql = sSql + "  " + qte(msAccountNo)
        sSql = sSql + ", " + AccessDate(Date.Parse(txtDate.Text))   'formatted in 'AccessDate'
        sSql = sSql + ", " + (AccessTime(currentTime))
        sSql = sSql + ", " + qte(cboReference.Text + " ")
        sSql = sSql + ", " + qte(cboAnalysis.Text + " ")
        sSql = sSql + ", ' '" '+ qte()                              'AccountCode
        sSql = sSql + ", " + qte(cboGLcode.Text + " ")
        sSql = sSql + ", " + qte(txtDetails.Text + " ")
        sSql = sSql + ", " + qte(cboCustomer.Text + " ")
        sSql = sSql + ", ' '" '+ qte()                              'Folio
        If UCase(txtRec.Text) = "Y" Then
            sSql = sSql + ", " + qte(UCase(txtRec.Text + " "))
        Else
            sSql = sSql + ", " + qte("N")
        End If
        sSql = sSql + ", " + qte(sPayReceipt)                       'cboPayReceipt.Text
        'If cboPayReceipt.Text = "Payment" Then
        If sPayReceipt = "Payment" Then                             'changed 16/02/16
            Amount = CDec(Val(txtAmount.Text))
            sSql = sSql + ", " + qte(Amount)                        'Payment
            'sSql = sSql + ", ''"                                   'Receipt
            sSql = sSql + ", " + qte(Amount * -1)                   'Amount Swap sign
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Amount) ' * -1)                'Equiv
        Else
            Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", ''"                                   'Payment
            sSql = sSql + ", " + qte(Amount)                        'Receipt
            sSql = sSql + ", " + qte(Amount)                        'Amount
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Amount)                        'Equiv
        End If
        sSql = sSql + ", " + qte(cboTransfer.Text + " ")
        sSql = sSql + ", " + qte(CStr(TransferID))
        sSql = sSql + ")"

        '
        'ok, let's do it
        '
        On Error GoTo DoSqlError 'added 19/09/2017

        bOk = DoSql(sSql, 1)

        gvPostDate = FormatDateTime(txtDate.Text, DateFormat.LongDate)
        mvLastDate = gvPostDate

        'Check for Transfer transaction
        If TransferID > 0 Then
            Call PostTransfer(TransferID)
        End If

        If gvPostDate > gvBalanceDate Then
            'forward value
            gvPreviousPostDate = gvBalanceDate
        Else
            'same or back value
            gvPreviousPostDate = gvPostDate
            'gvPreviousTimeKey = gvPostDate
        End If

        On Error GoTo 0

        Exit Sub

DoSqlError:

        ' error message wanted?
        'If bShowError Then
        Call MessageBox.Show("DoSQL", "Last SQL: " & sSql)
        'End If

        On Error GoTo 0

        Exit Sub

RetryAdd:

        'currentTime = TimeOfDay
        'DataGridPbsTrans.Rows(nCount).Cells("TimeKey").Value = currentTime 'TimeString
        'Resume

    End Sub

    Public Sub EditTransaction()

        Dim TransferID As Integer
        Dim currentTime As Date
        Dim dAmount As Double = 0
        Dim Amount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0
        Dim TimekeyCounter As Short = 0
        Dim sSql As String
        Dim bOk As Boolean

        GroupBox2.Text = "Changing Current Transaction"
        GroupBox2.Visible = True
        'cboPayReceipt.Text = "Payment" 'removed 01/05/16

        currentTime = TimeOfDay
        TransferID = 0

        'Process TransferID?
        If miTransfer = True Then
            'Changed cboTransfer from "" to a/c no?
            If Trim(cboTransfer.Tag) = "" Then                  'Add
                GroupBox2.Text = "Adding new transaction"
                miTfrUpdate = giADD
                Call GetTransferID(TransferID) 'jpg ***
                TransferID = TransferID + 1
                Call SaveTransferID(Str(TransferID))            'added Str 18/02/16
            Else                                                'Change
                miTfrUpdate = giCHANGE
                'No change to TransferID
                'Call GetTransferID(TransferID)                 'so get it from Parameters - Error!
                TransferID = Val(txtTransferID.Text)            'get TransferID from current record 18/02/16
            End If
        End If

        'strip bank & branch
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1)
        End If

        '
        'Update transaction in PbsTrans
        '
        sSql = "Update pbstrans"
        sSql = sSql + " Set"
        sSql = sSql + "  [Date] = " + AccessDate(txtDate.Text)
        'sSql = sSql + " , Timekey = " + (AccessTime(currentTime))   'keep existing time 19/02/2016
        sSql = sSql + " , Reference = " + qte(cboReference.Text + " ")
        sSql = sSql + " , Analysis = " + qte(cboAnalysis.Text + " ")
        'sSql = sSql + " , AccountCode = " + qte()
        sSql = sSql + " , GLcode = " + qte(cboGLcode.Text + " ")
        sSql = sSql + " , Details = " + qte(txtDetails.Text + " ")
        sSql = sSql + " , Customer = " + qte(cboCustomer.Text + " ")
        'sSql = sSql + " , Folio = " + 
        If UCase(txtRec.Text) = "Y" Then
            sSql = sSql + ", Reconciled = " + qte(UCase(txtRec.Text + " "))
        Else
            sSql = sSql + ", Reconciled = " + qte("N")
        End If
        sSql = sSql + " , DebitCredit = " + qte(cboPayReceipt.Text)
        If cboPayReceipt.Text = "Payment" Then
            Amount = CDec(Val(txtAmount.Text))
            sSql = sSql + ", Payment = " + qte(Amount)              'Payment
            sSql = sSql + ", Receipt = null"                         'Receipt reinstated 25/03/16
            sSql = sSql + ", Amount = " + qte(Amount * -1)          'Amount Swap sign
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Amount) ' * -1)          'Equiv
        Else
            Amount = CDec(Val(txtAmount.Text))
            sSql = sSql + ", Payment = null"                         'Payment reinstated 25/03/16
            sSql = sSql + ", Receipt = " + qte(Amount)              'Receipt
            sSql = sSql + ", Amount = " + qte(Amount)               'Amount
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Amount)                  'Equiv
        End If
        sSql = sSql + " , Transfer = " + qte(cboTransfer.Text)
        sSql = sSql + " , TransferID = " + qte(CStr(TransferID))
        sSql = sSql + " Where Date = " + AccessDate(gvdTxtDateTag)  'Previous Date to Edit
        sSql = sSql + " And Timekey = " + AccessTime(txtTimeKey.Tag) 'Previous Time to Edit
        sSql = sSql + " And AccountNo = " + qte(gsAccountNo)
        '
        'ok, let's do it
        '
        On Error GoTo DoSqlError 'added 19/09/2017

        bOk = DoSql(sSql, 1)

        gvPostDate = txtDate.Text
        mvLastDate = gvPostDate

        'Has original cboTransfer account no. been deleted? (TransferID = 0)
        'Changed cboTransfer from a/c no to ""?
        If Trim(cboTransfer.Tag) <> "" And Trim(cboTransfer.Text) = "" Then
            'Delete matching Transfer record
            Call DeleteTransfer(TransferID)
        End If

        'Check for Transfer transaction
        If TransferID > 0 Then
            If miTfrUpdate = giADD Then
                Call PostTransfer(TransferID)
            Else
                Call EditTransfer(TransferID)
            End If
        End If

        If gvPostDate > gvdTxtDateTag Then
            'moved existing date forward - use original date
            gvPreviousPostDate = gvdTxtDateTag
        Else
            'same or moved existing date backward - use new date
            gvPreviousPostDate = gvPostDate
        End If

        On Error GoTo 0

        Exit Sub

DoSqlError:

        ' error message wanted?
        'If bShowError Then
        Call MessageBox.Show("DoSQL", "Last SQL: " & sSql)
        'End If

        On Error GoTo 0

        Exit Sub

EditRetry:

        'just to avoid duplicate date/time
        'DataGridPbsTrans.SelectedCells(TimekeyCounter).Value = txtTimeKey.Text 
        'Resume

    End Sub

    Public Sub UpdateBalances(ByVal sSql As String)

        'Update balances for the currently selected Account and Find selection criteria.
        Dim ncounter As Integer
        Dim nBalance As Double
        Dim nDeposit As Double
        Dim nWithdrawal As Double

        Call SetHourGlassWait()

        PbstransBindingSource.Filter = sSql

        PbstransBindingSource.MoveFirst()

        'Iterate through the rows
        For ncounter = 0 To (PbstransBindingSource.Count - 1) 'changed from 1

            nDeposit = 0
            nWithdrawal = 0

            If ncounter = 0 Then
                nBalance = 0
            Else
                'If ncounter = 0 Then ncounter = ncounter + 1
                nBalance = (PbstransBindingSource.Item(ncounter - 1)("Balance").ToString)
            End If


            If Not PbstransBindingSource.Item(ncounter)("Receipt") Is Nothing Then
                ' Verify that the cell value is not an empty string.
                If Not PbstransBindingSource.Item(ncounter)("Receipt").ToString().Length = 0 Then
                    nDeposit = (PbstransBindingSource.Item(ncounter)("Receipt"))
                End If
            End If

            If Not PbstransBindingSource.Item(ncounter)("Payment") Is Nothing Then
                ' Verify that the cell value is not an empty string.
                If Not PbstransBindingSource.Item(ncounter)("Payment").ToString().Length = 0 Then
                    nWithdrawal = (PbstransBindingSource.Item(ncounter)("Payment"))
                End If
            End If

            PbstransBindingSource.Item(ncounter)("Balance") = _
                (nBalance + nDeposit - nWithdrawal).ToString

        Next

        PbstransBindingSource.EndEdit()
        VPBSDataSet.AcceptChanges()

        Call SetHourGlassDefault()

    End Sub

    Public Sub UpdateBalancesDB(sAccountNo As String)

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
        sSql = sSql & " AND TimeKey < " & AccessDate(gvPreviousPostTimeKey)
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
            PreviousPostTimeKey = pds.Rows.Item(nCount)("TimeKey")
        Else
            bof = True
            oldBalance = 0
            'gvPreviousPostDate unchanged
            PreviousPostDate = gvPreviousPostDate
            PreviousPostTimeKey = gvPreviousPostTimeKey
        End If

        pds.Dispose()

        '
        'create new DataTable of transactions for selected account number'
        'accumulate balance and write each balance to DB
        '
        sSql = "SELECT * FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(sAccountNo) ' gsAccountNo)
        If bof = False Then
            sSql = sSql & " AND Date > " & AccessDate(PreviousPostDate) 'Date of Transaction before gvPreviousPostDate - removed '='
            sSql = sSql & " AND TimeKey > " & AccessDate(PreviousPostTimeKey) 'AccessTime ????
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
                EditTime = ds.Rows.Item(nCount)("TimeKey")

                'accumulate Balance for each record
                If ds.Rows.Item(nCount)("DebitCredit") = "Payment" Then
                    newBalance = oldBalance - Val(ds.Rows.Item(nCount)("Payment")).ToString
                Else
                    newBalance = oldBalance + Val(ds.Rows.Item(nCount)("Receipt")).ToString
                End If

                Call UpdateBalanceDB(sAccountNo, EditDate, EditTime, newBalance) 'Write Balance to DB

                oldBalance = newBalance

                nCount = nCount + 1

            Loop

        Else

            EditDate = PreviousPostDate                             'default 21/02/16
            newBalance = oldBalance '= 0                            'default to oldBalance 21/02/16

        End If

        ds.Dispose()

        If giProjSO = False Then
            Call UpdateDirBalanceDB(sAccountNo, EditDate, newBalance)
        Else
            txtProjBalance.Text = CStr(FormatNumber(newBalance, 2))
        End If

        Call SetHourGlassDefault()

    End Sub

    Public Sub UpdateBalancesTfrDB(sAccountNo As String, currentPostDate As Date, currentPostTime As Date)

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
        sSql = sSql & " AND Date < " & AccessDate(currentPostDate) 'gvPreviousPostDate) 'get previous DateTime?
        sSql = sSql & " AND TimeKey < " & AccessDate(currentPostTime) 'gvPreviousPostTimeKey)
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
            PreviousPostTimeKey = pds.Rows.Item(nCount)("TimeKey")
        Else
            bof = True
            oldBalance = 0
            'gvPreviousPostDate unchanged
            PreviousPostDate = gvPreviousPostDate
            PreviousPostTimeKey = gvPreviousPostTimeKey
        End If

        pds.Dispose()

        '
        'create new DataTable of transactions for selected account number'
        'accumulate balance and write each balance to DB
        '
        sSql = "SELECT * FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(sAccountNo) ' gsAccountNo)
        If bof = False Then
            sSql = sSql & " AND Date > " & AccessDate(PreviousPostDate) 'Date of Transaction before gvPreviousPostDate - removed '='
            sSql = sSql & " AND TimeKey > " & AccessDate(PreviousPostTimeKey) 'AccessTime ????
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
                EditTime = ds.Rows.Item(nCount)("TimeKey")

                'accumulate Balance for each record
                If ds.Rows.Item(nCount)("DebitCredit") = "Payment" Then
                    newBalance = oldBalance - Val(ds.Rows.Item(nCount)("Payment")).ToString
                Else
                    newBalance = oldBalance + Val(ds.Rows.Item(nCount)("Receipt")).ToString
                End If

                Call UpdateBalanceDB(sAccountNo, EditDate, EditTime, newBalance) 'Write Balance to DB

                oldBalance = newBalance

                nCount = nCount + 1

            Loop

        Else

            EditDate = PreviousPostDate                             'default 21/02/16
            newBalance = oldBalance '= 0                            'default to oldBalance 21/02/16

        End If

        ds.Dispose()

        If giProjSO = False Then
            Call UpdateDirBalanceDB(sAccountNo, EditDate, newBalance)
        Else
            txtProjBalance.Text = CStr(FormatNumber(newBalance, 2))
        End If

        Call SetHourGlassDefault()

    End Sub

    Public Sub UpdateBalanceDB(sAccountNo As String, EditDate As Date, EditTime As DateTime, newBalance As Double)

        Dim sSql As String
        Dim bOk As Boolean

        sSql = "Update pbstrans"
        sSql = sSql & " Set Balance = " & newBalance
        sSql = sSql + " Where Date = " & AccessDate(EditDate)     'Date to Edit
        sSql = sSql + " And Timekey = " & AccessTime(EditTime)    'Time to Edit
        sSql = sSql + " And AccountNo = " & qte(sAccountNo) 'gsAccountNo)

        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

    End Sub

    Public Sub UpdateDirBalanceDB(sAccountNo As String, EditDate As Date, newBalance As Double)

        Dim sSql As String
        Dim bOk As Boolean

        sSql = "Update dirpbs"
        sSql = sSql & " Set Balance = " & newBalance
        sSql = sSql + " , BalanceDate = " & AccessDate(EditDate)
        sSql = sSql + " Where AccountNo = " & qte(sAccountNo)

        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

        gcBalance = newBalance
        gvBalanceDate = EditDate

    End Sub

    Public Sub CheckStandingOrders()

        Dim sSql As String
        'Dim iResponse As Boolean
        Dim nCount As Integer

        Call SetHourGlassWait()
        '
        'create new DataTable of standing orders for selected account number
        '
        sSql = "SELECT * FROM sotrans"
        If Not giPostAllSOs Then
            sSql = sSql & " WHERE sotrans.AccountNo = " & qte(gsAccountNo) & " AND sotrans.NumPayments > 0"
        End If
        sSql = sSql & " ORDER BY [Date],[Timekey]"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim dso As New DataTable
        adapter.Fill(dso)

        If dso.Rows.Count > 0 Then

            nCount = 0

            Do While nCount < dso.Rows.Count  'Not dso.EOF

                'check to see if standing order is due
                If dso.Rows(nCount)("Date") <= gvPostDate Then

                    'iResponse = CheckFinalChanged(gsAccountNo, Format$(dso("Date"), "dd/mm/yyyy"))
                    'Select Case iResponse
                    '    Case 2  'Abort
                    'Exit Do
                    '    Case Else
                    'End Select

                    Call PostStandingOrder(dso, nCount)

                    adapter.Update(dso)                         'does this work???

                    nCount = 0                                  'loop to beginning for another pass - added 29/09/2015
                    'nCount = nCount + 1
                Else
                    nCount = nCount + 1                         'skip to next record if SO not due
                End If

            Loop

        End If

        dso.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Public Sub PostStandingOrder(ByVal dso As DataTable, ByVal nSoCount As Integer)

        Dim DueDate As Object
        Dim DueDay As Integer
        Dim DueMonth As Integer
        Dim DueYear As Integer
        Dim LastDayMonth As Integer
        Dim nNumPayments As Integer
        Dim nDaily As Integer = 0
        Dim TransferID As Integer
        Dim sTransfer As String = ""
        Dim sAccountNo As String
        Dim sField As String
        Dim sPayReceipt As String = Nothing
        Dim DateDue As Date
        Dim Timekey As DateTime
        Dim CurrentTime As DateTime
        Dim Amount As Double
        Dim sSql As String = Nothing
        Dim nPbsCount As Integer = 0
        Dim bOk As Boolean

        If dso.Rows.Item(nSoCount)("NumPayments") > 0 Then 'added 08/10/2015

            CurrentTime = TimeOfDay
            CurrentTime = DateAdd("s", nSoCount + 1, CurrentTime)
            TransferID = 0

            Call SetHourGlassWait()

            'Process Transfer SO? 
            sTransfer = IIf(IsDBNull(dso.Rows.Item(nSoCount)("Transfer")), "", (dso.Rows.Item(nSoCount)("Transfer")))
            'strip bank & branch
            If InStr(sTransfer, "-") Then
                sTransfer = Mid(sTransfer, 1, InStr(sTransfer, "-") - 1)
            End If

            If Trim(sTransfer) <> "" Then                           'added Trim 18/02/16
                miTfrUpdate = giADD
                Call GetTransferID(TransferID)
                TransferID = TransferID + 1
                Call SaveTransferID(Str(TransferID))
            End If

            sPayReceipt = dso.Rows.Item(nSoCount)("DebitCredit")    'added 16/02/16

            '
            'create transaction in PbsTrans
            '
            sSql = "Insert into pbstrans"
            sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
            'If dso.Rows.Item(nSoCount)("DebitCredit") = "Payment" Then
            If sPayReceipt = "Payment" Then                         'changed 16/02/16
                sSql = sSql + " Folio, Reconciled, DebitCredit, Payment, Amount, VAT, Transfer, TransferID)"
            Else
                sSql = sSql + " Folio, Reconciled, DebitCredit, Receipt, Amount, VAT, Transfer, TransferID)"
            End If
            sSql = sSql + " Values ("
            sSql = sSql + "  " + qte(Trim(dso.Rows.Item(nSoCount)("AccountNo")))
            sSql = sSql + ", " + (AccessDate(dso.Rows.Item(nSoCount)("Date")))
            sSql = sSql + ", " + (AccessTime(CurrentTime))
            sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Reference") + " ")
            sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Analysis") + " ")
            sSql = sSql + ", ' '" '+ qte()                          'AccountCode
            sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("GLCode") + " ")
            sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Details") + " ")
            sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Customer") + " ")
            'Used by Forward Projections
            sField = IIf(IsDBNull(dso.Rows.Item(nSoCount)("Folio")), "", (dso.Rows.Item(nSoCount)("Folio")))
            sSql = sSql + ", " + qte(sField)
            sSql = sSql + ", " + qte("N")
            sSql = sSql + ", " + qte(sPayReceipt)                   'dso.Rows.Item(nSoCount)("DebitCredit") 18/02/16
            'If cboPayReceipt.Text = "Payment" Then                 'error!
            If sPayReceipt = "Payment" Then                         'changed 16/02/16
                Amount = CDec(Val(dso.Rows.Item(nSoCount)("Amount")))
                sSql = sSql + ", " + qte(Amount)                    'Payment
                'sSql = sSql + ", ''"                               'Receipt
                sSql = sSql + ", " + qte(Amount * -1)               'Amount Swap sign
                Amount = CDec(Val((dso.Rows.Item(nSoCount)("VAT"))))
                sSql = sSql + ", " + qte(Amount) ' * -1)            'Equiv
            Else
                Amount = CDec(Val(dso.Rows.Item(nSoCount)("Amount")))
                'sSql = sSql + ", ''"                               'Payment
                sSql = sSql + ", " + qte(Amount)                    'Receipt
                sSql = sSql + ", " + qte(Amount)                    'Amount
                Amount = CDec(Val((dso.Rows.Item(nSoCount)("VAT"))))
                sSql = sSql + ", " + qte(Amount)                    'Equiv
            End If
            sSql = sSql + ", " + qte(sTransfer) ' + " ")
            sSql = sSql + ", " + qte(CStr(TransferID))
            sSql = sSql + ")"

            'ok, let's do it
            bOk = DoSql(sSql, 1)

            On Error GoTo 0

            If dso.Rows.Item(nSoCount)("Date") < gvPreviousPostDate Then
                gvPreviousPostDate = dso.Rows.Item(nSoCount)("Date")
                gvPreviousPostTimeKey = dso.Rows.Item(nSoCount)("TimeKey")
            End If

            'Check for Transfer transaction
            If TransferID > 0 Then
                Call PostSOTransfer(dso, nSoCount, TransferID)
            End If

            '
            'update standing order
            '
            DateDue = dso.Rows.Item(nSoCount)("Date")
            Timekey = dso.Rows.Item(nSoCount)("Timekey")

            'update next payment date using frequency counter (daily or monthly)

            If dso.Rows.Item(nSoCount)("Daily") Is Nothing Then
                dso.Rows.Item(nSoCount)("Daily") = "0"
            ElseIf dso.Rows.Item(nSoCount)("Daily").ToString().Length = 0 Then
                dso.Rows.Item(nSoCount)("Daily") = "0"
            End If

            If dso.Rows.Item(nSoCount)("Monthly") Is Nothing Then
                dso.Rows.Item(nSoCount)("Monthly") = "0"
            ElseIf dso.Rows.Item(nSoCount)("Monthly").ToString().Length = 0 Then
                dso.Rows.Item(nSoCount)("Monthly") = "0"
            End If

            If Val(dso.Rows.Item(nSoCount)("Daily")) > 0 Then 'set flag?
                dso.Rows.Item(nSoCount)("Date") = DateAdd("d", dso.Rows.Item(nSoCount)("Daily"), dso.Rows.Item(nSoCount)("Date"))
                DueDate = dso.Rows.Item(nSoCount)("Date")
            Else
                DueDate = DateAdd("m", dso.Rows.Item(nSoCount)("Monthly"), dso.Rows.Item(nSoCount)("Date"))
                'keep due day in line with DayDue from SO record
                DueDay = DatePart("d", DueDate)
                If DueDay < dso.Rows.Item(nSoCount)("DayDue") Then
                    DueDay = dso.Rows.Item(nSoCount)("DayDue")                  'normal day due
                    DueMonth = DatePart("m", DueDate)
                    DueYear = DatePart("yyyy", DueDate)
                    LastDayMonth = Val(Mid$(gsDaysPerMonth, DueMonth * 2, 2))
                    'adjust for 28th Feb
                    If LastDayMonth = 28 Then
                        'test for leap year
                        If Int(DueYear / 4) = DueYear / 4 Then
                            LastDayMonth = 29
                            'test for leap century
                            If Int(DueYear / 100) = DueYear / 100 Then
                                If Int(DueYear / 400) <> DueYear / 400 Then
                                    LastDayMonth = 28
                                Else
                                    LastDayMonth = 29
                                End If
                            End If
                        End If
                    End If
                    If DueDay > LastDayMonth Then DueDay = LastDayMonth
                    DueDate = DateSerial(DueYear, DueMonth, DueDay)
                End If
                dso.Rows.Item(nSoCount)("Date") = DueDate
            End If

            'decrement number of payments
            dso.Rows.Item(nSoCount)("NumPayments") = dso.Rows.Item(nSoCount)("NumPayments") - 1
            nNumPayments = dso.Rows.Item(nSoCount)("NumPayments")

            dso.AcceptChanges()

            'On Error GoTo RetryUpdate

            sSql = "Update sotrans"
            sSql = sSql + " Set [Date] = " + AccessDate(DueDate)
            sSql = sSql + " , NumPayments = " + qte(nNumPayments)
            sSql = sSql + " Where Date = " + AccessDate(DateDue)
            sSql = sSql + " And Timekey = " + AccessTime(Timekey)
            sSql = sSql + " And AccountNo = " + qte(gsAccountNo)

            bOk = DoSql(sSql, 1)

            'On Error GoTo 0

        End If

        Exit Sub

RetryAdd:

        'currentTime = TimeOfDay
        'PbstransBindingSource("TimeKey") = currentTime
        Resume

RetryUpdate:

        'currentTime = TimeOfDay
        'dso.Rows.Item(nSoCount)("TimeKey") = currentTime
        Resume

    End Sub

    Public Sub DisplayHeader()

        lblAccountHeader.Text = "A/C: " & sAccountName + " " + sAccountDesc + " " + msAccountNo + " with " + sBankName + " " + sBankBranch ' + " " + CStr(gcBalance) + " " + CStr(gvBalanceDate)

    End Sub

    Private Sub cboReference_LostFocus(sender As Object, e As EventArgs) Handles cboReference.LostFocus

        If miUpdate = giADD Then
            Call GetReference()
            txtDate.Focus()
        End If

    End Sub

    Private Sub GetReference()

        Dim dSO As New DataTable

        If cboReference.Text = "Next cheque number " Then
            If GetNextChqNo(cboReference.Text, dSO) = True Then
                cboReference.Text = CStr(Val(dSO.Rows.Item(0)("MaxRefNo")))
                cboTransfer.Text = ""
                cboAnalysis.Text = ""
                'cboAccount = ""
                cboGLcode.Text = ""
                cboCustomer.Text = ""
                cboPayReceipt.Text = "Payment"
                txtAmount.Text = ""
                txtEquiv.Text = ""
                txtDetails.Text = ""
                'txtFolio = ""
            End If
        ElseIf cboReference.Text = "Next pay-in number " Then
            If GetNextPayNo(cboReference.Text, dSO) = True Then
                cboReference.Text = CStr(Val(dSO.Rows.Item(0)("MaxRefNo") + " "))
                cboTransfer.Text = ""
                cboAnalysis.Text = ""
                'cboAccount = ""
                cboGLcode.Text = ""
                cboCustomer.Text = ""
                cboPayReceipt.Text = "Receipt"
                txtAmount.Text = ""
                txtEquiv.Text = ""
                txtDetails.Text = ""
                'txtFolio = ""
            Else 'added 26/11/16
                cboReference.Text = ""
                cboTransfer.Text = ""
                cboAnalysis.Text = ""
                'cboAccount = ""
                cboGLcode.Text = ""
                cboCustomer.Text = ""
                cboPayReceipt.Text = "Receipt"
                txtAmount.Text = ""
                txtEquiv.Text = ""
                txtDetails.Text = ""
                'txtFolio = ""
            End If
        ElseIf Trim(cboReference.Text) = "Repeat last entry" Then
            cboReference.Text = " "
            cboReference.Text = cboReference.Tag
            cboTransfer.Text = cboTransfer.Tag
            cboAnalysis.Text = cboAnalysis.Tag
            'cboAccount = cboAccount.Tag
            cboGLcode.Text = cboGLcode.Tag
            cboCustomer.Text = cboCustomer.Tag
            cboPayReceipt.Text = cboPayReceipt.Tag
            txtAmount.Text = txtAmount.Tag
            txtEquiv.Text = txtEquiv.Tag
            txtDetails.Text = txtDetails.Tag
            'txtFolio = txtFolio.Tag
            If giADD Then cboReference.Enabled = False
        ElseIf cboReference.Text <> "" Then 'get Manual S/O
            If GetManualSO(cboReference.Text, dSO) = True Then
                cboTransfer.Text = CStr((dSO.Rows.Item(0)("Transfer")) + " ")
                cboAnalysis.Text = CStr((dSO.Rows.Item(0)("Analysis")))
                'cboAccount.text = CStr((dSO.Rows.Item(0)("Account"))) 
                cboGLcode.Text = CStr((dSO.Rows.Item(0)("GLCode")) + " ")
                cboCustomer.Text = CStr((dSO.Rows.Item(0)("Customer")) + " ")
                cboPayReceipt.Text = CStr((dSO.Rows.Item(0)("DebitCredit")))
                txtAmount.Text = CStr(Val(dSO.Rows.Item(0)("Amount")))
                txtEquiv.Text = CStr(Val(dSO.Rows.Item(0)("VAT")))
                txtDetails.Text = CStr((dSO.Rows.Item(0)("Details")) + " ")
                'txtFolio = CStr((dSO.Rows.Item(0)("Folio")))
            End If
        End If

    End Sub

    Private Function GetNextChqNo(sReference As String, dSO As DataTable) As Integer

        Dim sSql As String
        'Dim x As String

        On Error GoTo GetNextChqNoError

        sSql = "SELECT max(Reference) + 1 as MaxRefNo FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(gsAccountNo)
        sSql = sSql & " AND DebitCredit = 'Payment' "
        sSql = sSql & " AND MID(Reference,1,1) < 'A'  "
        sSql = sSql & " AND MID(reference,1,1) > ' '"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)

        adapter.Fill(dSO)

        If dSO.Rows.Count > 0 Then
            GetNextChqNo = True
        Else
            GetNextChqNo = False
        End If

        Exit Function

GetNextChqNoError:

        GetNextChqNo = False

    End Function

    Private Function GetNextPayNo(sReference As String, dSO As DataTable) As Integer

        Dim sSql As String

        On Error GoTo GetNextPayNoError

        sSql = "SELECT max(Reference) + 1 as MaxRefNo FROM pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(gsAccountNo)
        sSql = sSql & " AND DebitCredit = 'Receipt' "
        sSql = sSql & " AND MID(Reference,1,1) < 'A'  "
        sSql = sSql & " AND MID(reference,1,1) > ' '"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)

        adapter.Fill(dSO)

        If dSO.Rows.Count > 0 Then
            GetNextPayNo = True
        Else
            GetNextPayNo = False
        End If

        Exit Function

GetNextPayNoError:

        GetNextPayNo = False

    End Function

    Private Function GetManualSO(sReference As String, dSO As DataTable) As Integer

        Dim sSql As String

        On Error GoTo GetManualSOError

        sSql = "SELECT * FROM sotrans"
        sSql = sSql & " WHERE AccountNo = " & qte(gsAccountNo)
        sSql = sSql & " AND Reference = " & qte(sReference)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)

        adapter.Fill(dSO)

        If dSO.Rows.Count > 0 Then
            GetManualSO = True
        Else
            GetManualSO = False
        End If

        Exit Function

GetManualSOError:

        GetManualSO = False

    End Function

    Private Sub CmdFind_Click(sender As Object, e As EventArgs)

        'pbstrans
        GroupBox2.Text = "Find transaction(s)"
        GroupBox2.Visible = True

        Call ClearFields()

        txtDate.Visible = False
        txtDateFind.Visible = True
        txtDateFind.Text = ""
        txtDateFind.Focus()

        'txtTimeKey.Text = "" 'TimeOfDay ' added later ??
        msAccountNo = gsAccountNo

        CmdSelect.Enabled = False
        CmdFind.Enabled = False
        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdOk.Visible = False 'True
        CmdOkFind.Visible = True
        CmdOkFind.Enabled = True
        CmdCancel.Enabled = True


    End Sub

    Private Sub CmdOkFind_Click(sender As Object, e As EventArgs) Handles CmdOkFind.Click

        Dim sSql As String
        Dim Msg As String
        Dim Title As String
        Dim sAmountPrefix As String = ""

        sSql = ""

        If txtDateFind.Text <> "" Then   '__/__/____" Then
            If Not IsDate(txtDateFind) Then
                Msg = " Date error - please rectify"
                Title = "Enter transaction date"
                MsgBox(Msg, vbExclamation, Title)
                txtDateFind.Focus()
                Exit Sub
            Else
                sSql = sSql & " Date Like "
                sSql = sSql & "#" & Format(txtDateFind, "dd-mmm-yyyy") & "#"
            End If
        End If

        If Trim(cboReference.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Reference Like "
            sSql = sSql & qte(cboReference.Text)
        End If

        If Trim(cboTransfer.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Transfer = "
            sSql = sSql & qte(cboTransfer.Text)
        End If

        If Trim(cboAnalysis.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Analysis = "
            sSql = sSql & qte(cboAnalysis.Text)
        End If

        'If Trim(cboAccount.text) <> "" Then
        'If sSql <> "" Then sSql = sSql & " AND "
        'sSql = sSql & " Account = "
        'sSql = sSql & qte(cboAccount.text)
        'End If

        If Trim(cboGLcode.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " GLCode = "
            sSql = sSql & qte(cboGLcode.Text)
        End If

        If Trim(cboCustomer.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Customer Like "
            sSql = sSql & qte(cboCustomer.Text & "*")
        End If

        If Trim(cboPayReceipt.Text) <> "" Then
            If cboPayReceipt.Text = "Payment" Then
                sAmountPrefix = "-"
            Else
                sAmountPrefix = ""
            End If
        End If

        If Trim(txtAmount.Text) <> "" Then
            If Not IsNumeric(txtAmount.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtAmount.Focus()
                Exit Sub
            Else
                If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Amount = "
                sSql = sSql & sAmountPrefix & txtAmount.Text
            End If
        End If

        If Trim(txtDetails.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Details Like "
            sSql = sSql & qte(txtDetails.Text & "*")
        End If

        'If Trim(txtFolio) <> "" Then
        'If sSql <> "" Then sSql = sSql & " AND "
        'sSql = sSql & " Folio = "
        'sSql = sSql & qte(txtFolio)
        'End If

        If Trim(txtRec.Text) <> "" Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Reconciled = "
            sSql = sSql & qte(txtRec.Text)
        End If

        If sSql <> "" Then
            sSql = sSql & " AND "
            sSql = sSql & "AccountNo = " + qte(gsAccountNo)
        End If

        PbstransBindingSource.Filter = sSql

        Call DisplayDetails()
        Call UpdateBalances(sSql)

        CmdOk.Visible = True
        CmdOkFind.Visible = False

    End Sub

    Private Sub CreatePhantomSOs()

        Dim sSql As String
        Dim sField As String
        Dim nField As Double = 0
        Dim CurrentTime As DateTime
        Dim Amount As Double = 0
        Dim bOk As Integer = 0
        Dim iCount As Integer = 0
        Dim nCount As Integer = 0

        nCount = 0
        CurrentTime = TimeOfDay

        'use Select Into Temp Table....?
        'sSql = "SELECT " & sFields & " INTO SOTransProjTemp"
        'sSql = sSql & " FROM sotrans"

        'create DataTable of standing orders for selected account number
        sSql = "SELECT * FROM sotrans"
        sSql = sSql & " WHERE sotrans.AccountNo = " & qte(gsAccountNo) & " AND sotrans.NumPayments > 0"
        sSql = sSql & " ORDER BY [Date],[Timekey]"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim dso As New DataTable
        adapter.Fill(dso)

        Call SetHourGlassWait()

        If dso.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= dso.Rows.Count - 1

                iCount = iCount + 2
                CurrentTime = DateAdd("s", iCount, CurrentTime)

                '
                'create Phantom SO record in SOTrans for each existing SO record, for selected account number
                '
                sSql = "Insert into sotrans"
                sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
                sSql = sSql + " Folio, Reconciled, DebitCredit, Amount, VAT, Transfer," 'no Payment/Receipt or TransferID fields in soTrans
                sSql = sSql + " Daily, Monthly, DayDue, NumPayments)"

                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(gsAccountNo)
                sSql = sSql + ", " + AccessDate(dso.Rows.Item(nCount)("Date"))  'formatted in 'AccessDate'
                sSql = sSql + ", " + AccessTime(CurrentTime)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Reference")), "", (dso.Rows.Item(nCount)("Reference")))
                sSql = sSql + ", " + qte(sField)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Analysis")), "", (dso.Rows.Item(nCount)("Analysis")))
                sSql = sSql + ", " + qte(sField)
                sSql = sSql + ", ' '" '+ qte()                                  'AccountCode
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("GLCode")), "", (dso.Rows.Item(nCount)("GLCode")))
                sSql = sSql + ", " + qte(sField)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Details")), "", (dso.Rows.Item(nCount)("Details")))
                sSql = sSql + ", " + qte(sField)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Customer")), "", (dso.Rows.Item(nCount)("Customer")))
                sSql = sSql + ", " + qte(sField)
                sSql = sSql + ", 'Projection'"                                  'Folio - ID to aid selection for deletion
                sSql = sSql + ", " + qte("N")                                   'Reconciled
                sSql = sSql + ", " + qte(dso.Rows.Item(nCount)("DebitCredit"))
                sSql = sSql + ", " + qte(dso.Rows.Item(nCount)("Amount"))       'Amoumt
                'nField = CDec(Val((dso.Rows.Item(nCount)("Amount"))))
                'sSql = sSql + ", " + qte(CStr(nField))
                sSql = sSql + ", " + qte((dso.Rows.Item(nCount)("VAT")))        'Equiv
                'sField = IIf(IsDBNull(dso.Rows.Item(nCount)("VAT")), "0", (dso.Rows.Item(nCount)("VAT")))
                'nField = CDec(Val((dso.Rows.Item(nCount)("VAT"))))
                'sSql = sSql + ", " + qte(CStr(nField))
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Transfer")), "", (dso.Rows.Item(nCount)("Transfer")))
                sSql = sSql + ", " + qte(sField)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Daily")), "", (dso.Rows.Item(nCount)("Daily")))
                sSql = sSql + ", " + qte(sField)
                sField = IIf(IsDBNull(dso.Rows.Item(nCount)("Monthly")), "", (dso.Rows.Item(nCount)("Monthly")))
                sSql = sSql + ", " + qte(sField)
                sSql = sSql + ", " + qte(dso.Rows.Item(nCount)("DayDue"))
                sSql = sSql + ", " + qte(dso.Rows.Item(nCount)("NumPayments"))
                sSql = sSql + ")"

                '
                'ok, let's do it
                '
                'On Error GoTo tbsoRetry
                bOk = DoSql(sSql, 1)
                On Error GoTo 0

                nCount = nCount + 1

            Loop

        End If

        dso.Dispose()

        Call SetHourGlassDefault()

        Exit Sub

tbsoRetry:

        iCount = iCount + 2
        CurrentTime = DateAdd("s", iCount, CurrentTime)
        Resume

    End Sub

    Private Sub CheckProjections()

        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()
        '
        'create new DataTable of Phantom standing orders for selected account number
        '
        'sSql = "SELECT * FROM sotransProjTemp"

        sSql = "SELECT * FROM sotrans"
        sSql = sSql & " WHERE sotrans.AccountNo = " & qte(gsAccountNo) & " AND sotrans.NumPayments > 0"
        sSql = sSql & " AND sotrans.Folio = 'Projection'"
        sSql = sSql & " ORDER BY [Date],[Timekey]"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim dso As New DataTable
        adapter.Fill(dso)

        'For Each row As DataRow In dso.Rows
        'Console.WriteLine(row("Customer").ToString)
        'Next

        If dso.Rows.Count > 0 Then

            nCount = 0

            Do While nCount < dso.Rows.Count  'Not dso.EOF

                'check to see if standing order is due
                If dso.Rows(nCount)("Date") <= gvPostDate Then

                    Call PostStandingOrder(dso, nCount)

                    adapter.Update(dso)

                    nCount = 0                                  'loop to beginning for another pass - added 29/09/2015
                Else
                    nCount = nCount + 1                         'skip to next record if SO not due
                End If

            Loop

        End If

        dso.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub DeletePhantomSOs()

        Dim sSql As String

        sSql = "DELETE FROM sotrans"
        sSql = sSql & " WHERE sotrans.Folio = 'Projection'"

        If Not DoSql(sSql, True) Then
        End If

    End Sub

    Private Sub DeleteProjections()

        Dim sSql As String

        sSql = "DELETE FROM pbstrans"
        sSql = sSql & " WHERE pbstrans.Folio = 'Projection'"

        If Not DoSql(sSql, True) Then
        End If

    End Sub

    Private Sub SelectAcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAcToolStripMenuItem.Click

        'Select A/C
        Call CmdSelect_Click(AcceptButton, e)

    End Sub

    Private Sub NewAccountDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewAccountDetailsToolStripMenuItem.Click

        giDirpbsNew = True
        frmAddChgAcc.Show() '(Modal)
        'Call RefreshDetails()

    End Sub

    Private Sub ChangeAccountDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeAccountDetailsToolStripMenuItem.Click

        giDirpbsNew = False
        frmAddChgAcc.Show() '(Modal)
        'Call RefreshDetails()

    End Sub

    Private Sub ImportBankStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportBankStatementToolStripMenuItem.Click

        Dim sConnect As String
        Dim sRecTrans As String
        Dim sSql As String
        Dim sFileName As String
        Dim Msg As String
        Dim Title As String
        'Dim sDirpbsAccountNo As String = ""
        'Dim sRecTransAccountNo As String
        Dim RecTransDate As DateTime
        Dim RecTransDesc As String
        Dim RecTransBalance As Double
        Dim rCount As Integer
        Dim nCount As Integer
        'Dim rCount2 As Integer
        'Dim nCount2 As Integer

        sRecTrans = "RecTrans"
        sFileName = ""

        OpenFileDialog1.ShowDialog()
        sFileName = OpenFileDialog1.FileName

        If sFileName = "" Then Exit Sub

        Call DropTable(sRecTrans) 'in local DB!

        'gImpDB = gwsMainWS.OpenDatabase(gsFileName, 0, 0, gsEXCEL50)
        'sConnect = "" '[Excel 5.0;database=" & gImpDB.Name & "]."

        'Halifax format - This works!!
        'sSql = "select * into " & "RecTrans" & " from " & "[Text;database=C:\VPBS]." & "0109.txt"
        sConnect = "[Text;database=" & PathLessFileName(sFileName) & "]."
        sSql = "select * into " & sRecTrans & " from " & sConnect & FileNameLessPath(sFileName)

        If DoSql(sSql, 1) = True Then 'import into local DB!
            Msg = " Bank records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = True

            'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent
            'Call GetPutBankTransBalance()

            sSql = "SELECT * FROM RecTrans"

            Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
            Dim ds As New DataTable
            adapter.Fill(ds)

            If ds.Rows.Count > 0 Then

                nCount = ds.Rows.Count - 1
                rCount = 0

                'need to get RecTransAccountNo from RecTrans
                'sRecTransAccountNo = Str(ds.Rows.Item(rCount)("Account Number")) 'added 27/06/18
                sRecTransAccountNo = ds.Rows.Item(rCount)("Account Number") 'added 27/06/18

                'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent
                Call GetDirPbsAccountNo()                     'added 27/06/18

                If giAutoRec = True Then

                    'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent
                    Call GetPutBankTransBalance1()             'added sRecTransAccountNo 27/06/18

                    Do While rCount <= ds.Rows.Count - 1

                        RecTransDate = ds.Rows.Item(rCount)("Transaction Date")
                        RecTransDesc = ds.Rows.Item(rCount)("Transaction Description")
                        RecTransBalance = ds.Rows.Item(rCount)("Balance")

                        'write to DB - extra Where conditions in case of two or more SAME Transaction Dates
                        sSql = "Update Rectrans"
                        sSql = sSql & " Set Balance = " & qte(nCount)           ' use Balance to set index
                        sSql = sSql & ",  [Sort Code] = 'N'"                    ' use [Sort Code] for Rec code - N, n, Y
                        sSql = sSql & " Where [Transaction Date] = " & AccessDate(RecTransDate)
                        sSql = sSql & " And [Transaction Description] = " & qte(RecTransDesc)
                        sSql = sSql & " And RecTrans.Balance = " & (RecTransBalance)

                        If DoSql(sSql, 1) Then
                        End If

                        nCount = nCount - 1
                        rCount = rCount + 1

                    Loop

                Else
                    Call DropTable(sRecTrans) 'in local DB!
                End If

            End If

            ds.Dispose()

        Else
            Msg = " NO Bank records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = False
        End If

    End Sub

    Private Sub GetDirPbsAccountNo()

        'added 28/06/18
        Dim sDirpbsAccountNo As String = ""
        Dim sSql As String
        Dim nCount As Integer
        Dim Msg As String
        Dim Title As String

        sSql = "SELECT AccountNo FROM dirpbs"
        sSql = sSql + " Where UserName = " + qte(gsUserName)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        'look for a matching AccountNo in dirpbs
        If ds.Rows.Count > 0 Then

            nCount = 0 'ds.Rows.Count - 1

            Do While nCount <= ds.Rows.Count - 1
                'sDirpbsAccountNo = Str(ds.Rows.Item(nCount)("AccountNo"))
                sDirpbsAccountNo = ds.Rows.Item(nCount)("AccountNo")
                'sRecTransAccountNo may be missing leading zeros
                If InStr(sDirpbsAccountNo, sRecTransAccountNo) Then
                    'found a match in dirpbs
                    sRecTransAccountNo = sDirpbsAccountNo 'copy from DirPbsAccountNo to pick up any leading zeros
                    nCount = ds.Rows.Count
                End If

                nCount = nCount + 1
            Loop

            If sRecTransAccountNo <> sDirpbsAccountNo Then
                'error
                Msg = " Bank Account No. does not exist in VPBS - Imported Bank records deleted"
                Title = "Bank Reconciliation"
                MsgBox(Msg, vbExclamation, Title)
                giAutoRec = False
            End If

        End If

        ds.Dispose()

    End Sub

    Private Sub ImportBankStatementDevToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportBankStatementDevToolStripMenuItem.Click

        Dim sConnect As String
        Dim sRecTrans As String
        Dim sSql As String
        Dim sImportSql As String
        Dim sFileName As String
        Dim Msg As String
        Dim Title As String
        'Dim sRecTransAccountNo As String
        Dim RecTransDate As DateTime
        'Dim NewRecTransDate As DateTime
        Dim RecTransDesc As String
        Dim RecTransBalance As Double
        Dim rCount As Integer
        Dim nCount As Integer
        'Dim sCount As String

        sRecTrans = "RecTrans"
        sFileName = ""

        'CurrentTime = TimeOfDay
        'CurrentTime = DateAdd("s", nCount + 1, CurrentTime)

        OpenFileDialog1.ShowDialog()
        sFileName = OpenFileDialog1.FileName

        If sFileName = "" Then Exit Sub

        Call DropTable2(sRecTrans) 'in Dev DB!

        'gImpDB = gwsMainWS.OpenDatabase(gsFileName, 0, 0, gsEXCEL50)
        'sConnect = "" '[Excel 5.0;database=" & gImpDB.Name & "]."

        'Halifax format - This works!!
        'sSql = "select * into " & "RecTrans" & " from " & "[Text;database=C:\VPBS]." & "0109.txt"
        sConnect = "[Text;database=" & PathLessFileName(sFileName) & "]."
        sSql = "select * into " & sRecTrans & " from " & sConnect & FileNameLessPath(sFileName)
        sImportSql = sSql

        If DoSql2(sSql, 1) = True Then 'import into Dev DB!
            Msg = " Bank2 records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = True

            'GetPutBankTransBalance and store it in dirpbs.BalanceEquivalent
            'Call GetPutBankTransBalanceDev()

            sSql = "SELECT * FROM RecTrans"
            'sSql = sSql & " ORDER BY [Transaction Date] Desc"

            Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection2)
            Dim ds As New DataTable
            adapter.Fill(ds)

            If ds.Rows.Count > 0 Then

                nCount = ds.Rows.Count - 1
                rCount = 0

                'need to get RecTransAccountNo from RecTrans
                'sRecTransAccountNo = Str(ds.Rows.Item(rCount)("Account Number"))   'added 27/06/18
                'get sRecTransAccountNo from Import 1 and store                     'added 30/06/18
                'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent
                Call GetPutBankTransBalanceDev2()

                Do While rCount <= ds.Rows.Count - 1

                    'CurrentTime = DateAdd("s", nCount + 5, CurrentTime)
                    'nCurrentTime = (CurrentTime.ToString)

                    RecTransDate = ds.Rows.Item(rCount)("Transaction Date")
                    'NewRecTransDate = DateAdd("s", rCount + 1, RecTransDate)
                    RecTransDesc = ds.Rows.Item(rCount)("Transaction Description")
                    RecTransBalance = ds.Rows.Item(rCount)("Balance")

                    'sCount = Str(nCount)
                    'sCount = Mid(sCount, 2, Len(sCount)) 'drop leading space
                    'If Len(sCount) < 2 Then sCount = "0" + sCount

                    'write to DB - extra Where conditions in case of two or more SAME Transaction Dates
                    sSql = "Update Rectrans"
                    'sSql = sSql & " Set [Transaction Date] = " & AccessDate(NewRecTransDate) 'now Date and Time?
                    'sSql = sSql & " Set [Sort Code] = " & qte(sCount) 'set index
                    'sSql = sSql & ", Balance = 0"       'Balance now used for Rec code - initialise 0 = N, 1 = n, 2 = Y
                    sSql = sSql & " Set Balance = " & qte(nCount)           ' use Balance to set index
                    sSql = sSql & ",  [Sort Code] = 'N'"                    ' use [Sort Code] for Rec code - N, n, Y
                    sSql = sSql & " Where [Transaction Date] = " & AccessDate(RecTransDate)
                    sSql = sSql & " And [Transaction Description] = " & qte(RecTransDesc)
                    sSql = sSql & " And RecTrans.Balance = " & (RecTransBalance)

                    If DoSql2(sSql, 1) Then
                    End If

                    nCount = nCount - 1
                    rCount = rCount + 1

                Loop

            End If

            ds.Dispose()

        Else
            Msg = " NO Bank2 records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = False
        End If

        Call ImportBankStatementDev3(sImportSql)

    End Sub

    Private Sub ImportBankStatementDev3(sSql As String)

        'Dim sConnect As String
        Dim sRecTrans As String
        'Dim sSql As String
        'Dim sFileName As String
        Dim Msg As String
        Dim Title As String
        'Dim sRecTransAccountNo As String
        Dim RecTransDate As DateTime
        Dim RecTransDesc As String
        Dim RecTransBalance As Double
        Dim rCount As Integer
        Dim nCount As Integer

        sRecTrans = "RecTrans"
        'sFileName = ""

        'OpenFileDialog1.ShowDialog()
        'sFileName = OpenFileDialog1.FileName

        'If sFileName = "" Then Exit Sub

        Call DropTable3(sRecTrans) 'in local DB!

        'gImpDB = gwsMainWS.OpenDatabase(gsFileName, 0, 0, gsEXCEL50)
        'sConnect = "" '[Excel 5.0;database=" & gImpDB.Name & "]."

        'Halifax format - This works!!
        'sSql = "select * into " & "RecTrans" & " from " & "[Text;database=C:\VPBS]." & "0109.txt"
        'sConnect = "[Text;database=" & PathLessFileName(sFileName) & "]."
        'sSql = "select * into " & sRecTrans & " from " & sConnect & FileNameLessPath(sFileName)

        If DoSql3(sSql, 1) = True Then 'import into Dev DB!

            Msg = " Bank3 records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = True

            'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent
            'Call GetPutBankTransBalance()

            sSql = "SELECT * FROM RecTrans"

            Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection3)
            Dim ds As New DataTable
            adapter.Fill(ds)

            If ds.Rows.Count > 0 Then

                nCount = ds.Rows.Count - 1
                rCount = 0

                'need to get RecTransAccountNo from RecTrans
                'sRecTransAccountNo = Str(ds.Rows.Item(rCount)("Account Number")) 'added 27/06/18
                'Get BankTrans Balance and store it in dirpbs.BalanceEquivalent

                Call GetPutBankTransBalanceDev3()             'added ...Dev3 30/06/18

                Do While rCount <= ds.Rows.Count - 1

                    RecTransDate = ds.Rows.Item(rCount)("Transaction Date")
                    RecTransDesc = ds.Rows.Item(rCount)("Transaction Description")
                    RecTransBalance = ds.Rows.Item(rCount)("Balance")

                    'write to DB - extra Where conditions in case of two or more SAME Transaction Dates
                    sSql = "Update Rectrans"
                    sSql = sSql & " Set Balance = " & qte(nCount)           ' use Balance to set index
                    sSql = sSql & ",  [Sort Code] = 'N'"                    ' use [Sort Code] for Rec code - N, n, Y
                    sSql = sSql & " Where [Transaction Date] = " & AccessDate(RecTransDate)
                    sSql = sSql & " And [Transaction Description] = " & qte(RecTransDesc)
                    sSql = sSql & " And RecTrans.Balance = " & (RecTransBalance)

                    If DoSql3(sSql, 1) Then
                    End If

                    nCount = nCount - 1
                    rCount = rCount + 1

                Loop

            End If

            ds.Dispose()

        Else
            Msg = " NO Bank3 records imported"
            Title = "Bank Reconciliation"
            MsgBox(Msg, vbExclamation, Title)
            giAutoRec = False
        End If

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

    Private Sub GetPutBankTransBalance1()

        Dim RecTransBalance As Double
        Dim RecTransDate As Date
        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()

        sSql = "SELECT Balance, [Transaction Date] FROM RecTrans"
        'sSql = sSql & " ORDER BY [Transaction Date] Desc"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0 'get first record = latest date

            'only need first row
            'If Not IsDBNull(ds.Rows.Item(nCount)("Balance")) Then
            RecTransDate = ds.Rows.Item(nCount)("Transaction Date")
            RecTransBalance = ds.Rows.Item(nCount)("Balance")

        Else

            RecTransBalance = 0

        End If

        sSql = "Update dirpbs Set BalanceEquivalent = " & qte(RecTransBalance)
        sSql = sSql & " Where AccountNo = " & qte(sRecTransAccountNo) 'qte(gsAccountNo) changed 27/06/18

        If DoSql(sSql, 1) Then
        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub GetPutBankTransBalanceDev2()

        Dim RecTransBalance As Double
        Dim RecTransDate As Date
        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()

        sSql = "SELECT Balance, [Transaction Date] FROM RecTrans"
        'sSql = sSql & " ORDER BY [Transaction Date] Desc"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection2)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0 'get first record = latest date

            'only need first row
            'If Not IsDBNull(ds.Rows.Item(nCount)("Balance")) Then
            RecTransDate = ds.Rows.Item(nCount)("Transaction Date")
            RecTransBalance = ds.Rows.Item(nCount)("Balance")

        Else

            RecTransBalance = 0

        End If

        sSql = "Update dirpbs Set BalanceEquivalent = " & qte(RecTransBalance)
        sSql = sSql & " Where AccountNo = " & qte(sRecTransAccountNo) 'qte(gsAccountNo) changed 27/06/18

        If DoSql2(sSql, 1) Then
        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub GetPutBankTransBalanceDev3()

        Dim RecTransBalance As Double
        Dim RecTransDate As Date
        Dim sSql As String
        Dim nCount As Integer

        Call SetHourGlassWait()

        sSql = "SELECT Balance, [Transaction Date] FROM RecTrans"
        'sSql = sSql & " ORDER BY [Transaction Date] Desc"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection3)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0 'get first record = latest date

            'only need first row
            'If Not IsDBNull(ds.Rows.Item(nCount)("Balance")) Then
            RecTransDate = ds.Rows.Item(nCount)("Transaction Date")
            RecTransBalance = ds.Rows.Item(nCount)("Balance")

        Else

            RecTransBalance = 0

        End If

        sSql = "Update dirpbs Set BalanceEquivalent = " & qte(RecTransBalance)
        sSql = sSql & " Where AccountNo = " & qte(sRecTransAccountNo) 'qte(gsAccountNo) changed 27/06/18

        If DoSql3(sSql, 1) Then
        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub PrinterSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrinterSetupToolStripMenuItem.Click

        PrintDialog1.ShowDialog()
        'PrintDialog1.PrinterSettings.GetHdevmode().

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Dispose()

    End Sub

    Private Sub ForwardProjectionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForwardProjectionsToolStripMenuItem.Click

        giProjSO = True
        GroupBox2.Visible = False
        GroupBox4.Visible = True
        CmdOkProj.Visible = True
        CmdOkProj.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub FindToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem1.Click

        Call CmdFind_Click(AcceptButton, e)

    End Sub

    Private Sub FirstTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirstTransactionToolStripMenuItem.Click

        PbstransBindingSource.MoveFirst()

    End Sub

    Private Sub LastTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastTransactionToolStripMenuItem.Click

        PbstransBindingSource.MoveLast()

    End Sub

    Private Sub AutoStandingOrdersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutoStandingOrdersToolStripMenuItem1.Click

        AutoStandingOrdersToolStripMenuItem_Click(AcceptButton, e)

    End Sub

    Private Sub AutoStandingOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoStandingOrdersToolStripMenuItem.Click

        giAutoSO = True
        frmSOTrans.Show()

    End Sub

    Private Sub ManualStandingOrdersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManualStandingOrdersToolStripMenuItem1.Click

        Call ManualStandingOrdersToolStripMenuItem_Click(AcceptButton, e)

    End Sub

    Private Sub ManualStandingOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualStandingOrdersToolStripMenuItem.Click

        giAutoSO = False
        frmSOTrans.Show()

    End Sub

    Private Sub StandingOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandingOrdersToolStripMenuItem.Click

        'Report
        giAutoSO = True
        frmSOTrans.Show()

    End Sub

    Private Sub BudgetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BudgetsToolStripMenuItem.Click

        giActual = False
        frmBudgets.Show()

    End Sub

    Private Sub ReconciliationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReconciliationToolStripMenuItem.Click

        gsRec = "Edit"
        frmBankRec.Show()
        'Call DisplayDetails() 'added 19/11/17

    End Sub

    Private Sub ReconciliationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReconciliationToolStripMenuItem1.Click

        gsRec = "View"
        frmBankRec.Show()

    End Sub

    Private Sub ReconciiationStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReconciiationStatementToolStripMenuItem.Click

        gsRec = "Report"
        frmBankRec.Show()

    End Sub

    Private Sub ActualsVBudgetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualsVBudgetsToolStripMenuItem.Click

        'View
        giActual = True
        frmBudgets.Show()

    End Sub

    Private Sub ActualsVBudgetsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActualsVBudgetsToolStripMenuItem1.Click

        'Report
        giActual = True
        frmBudgets.Show()

    End Sub

    Private Sub BankStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankStatementToolStripMenuItem.Click

        Call CmdReport_Click(AcceptButton, e)

    End Sub

    Private Function GetDates() As String

        Dim sSql As String
        Dim sOperator As String
        Dim Msg As String
        Dim Title As String

        sSql = ""

        If DateTimePicker1.Text <> "__/__/____" And (rdoOption1.Checked Or rdoOption2.Checked Or rdoOption3.Checked) Then
            If Not IsDate(DateTimePicker1.Text) Then
                Msg = " Date error - please rectify"
                Title = "Enter transaction date"
                MsgBox(Msg, vbExclamation, Title)
                DateTimePicker1.Focus()
                GetDates = ""
                Exit Function
            Else
                ''If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Date "
                If rdoOption1.Checked Then
                    sOperator = " > "
                ElseIf rdoOption2.Checked Then 'rdoOption7.Checked Then
                    sOperator = " >= "
                Else
                    sOperator = " = "
                End If
                sSql = sSql & sOperator & "#" & DateTimePicker1.Text & "#" 'Format(txtDate(0), "dd-mmm-yyyy") & "#"
            End If
        End If

        If DateTimePicker2.Text <> "__/__/____" And (rdoOption9.Checked Or rdoOption10.Checked Or rdoOption11.Checked) Then
            If Not IsDate(DateTimePicker2.Text) Then
                Msg = " Date error - please rectify"
                Title = "Enter transaction date"
                MsgBox(Msg, vbExclamation, Title)
                DateTimePicker2.Focus()
                GetDates = ""
                Exit Function
            Else
                If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Date "
                If rdoOption9.Checked Then
                    sOperator = " < "
                ElseIf rdoOption10.Checked Then
                    sOperator = " <= "
                Else
                    sOperator = " <> "
                End If
                ' changed from DateTimePicker1.Text 14/03/16
                sSql = sSql & sOperator & "#" & DateTimePicker2.Text & "#"  'Format(txtDate1.text, "dd-mmm-yyyy") & "#"
            End If
        End If

        GetDates = sSql

    End Function

    Private Sub UpdateCBO()

        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""

        cboGroup1.Items.Clear()
        cboGroup1.Items.Add("Customer")
        cboGroup1.Items.Add("Analysis code")
        cboGroup1.Items.Add("Account code")
        cboGroup1.Items.Add("GL code")
        cboGroup1.Items.Add("Reference")
        cboGroup1.Items.Add("Details")
        cboGroup1.Items.Add("Folio")
        cboGroup1.Items.Add("Reconciled")

        cboGroup2.Items.Clear()
        cboGroup2.Items.Add("Customer")
        cboGroup2.Items.Add("Analysis code")
        cboGroup2.Items.Add("Account code")
        cboGroup2.Items.Add("GL code")
        cboGroup2.Items.Add("Reference")
        cboGroup2.Items.Add("Details")
        cboGroup2.Items.Add("Folio")
        cboGroup2.Items.Add("Reconciled")

        cboGroup3.Items.Clear()
        cboGroup3.Items.Add("Customer")
        cboGroup3.Items.Add("Analysis code")
        cboGroup3.Items.Add("Account code")
        cboGroup3.Items.Add("GL code")
        cboGroup3.Items.Add("Reference")
        cboGroup3.Items.Add("Details")
        cboGroup3.Items.Add("Folio")
        cboGroup3.Items.Add("Reconciled")

        'set defaults
        cboGroup1.SelectedIndex = 4   'Reference
        cboGroup2.SelectedIndex = 0   'Customer
        cboGroup3.SelectedIndex = 5   'Details

    End Sub

    Private Sub CmdSelect_Click(sender As Object, e As EventArgs) Handles CmdSelect.Click

        Call RefreshDetails() 'added 29/11/16

        DataGridPbsTrans.Visible = False
        DataGridDirPbs.Visible = True
        DirpbsBindingSource.MoveFirst()

    End Sub

    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click

        TabControl1.Visible = True
        CmdOk.Visible = False
        CmdOkReport.Visible = True
        CmdOkReport.Enabled = True
        CmdCancel.Visible = True
        CmdCancel.Enabled = True
        rdoOption2.Checked = True

    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click

        'pbstrans
        GroupBox2.Text = "Adding new transaction"
        GroupBox2.Visible = True
        'cboPayReceipt.Text = "Payment" 'removed 01/05/16

        miUpdate = giADD

        'turn off grid
        DataGridPbsTrans.Enabled = False

        Call ClearFields()
        txtDate.Visible = True
        txtDate.Text = mvLastDate
        txtDate.Focus()
        txtTimeKey.Text = TimeOfDay ' added later ??
        cboPayReceipt.Text = "Payment" 'added 27/06/2017
        msAccountNo = gsAccountNo

        CmdSelect.Enabled = False
        CmdFind.Enabled = False
        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdOk.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub CmdChange_Click(sender As Object, e As EventArgs) Handles CmdChange.Click

        'PbsTrans
        Dim sName As String
        Dim sTransferAC As String = Nothing
        Dim dAmount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0
        Dim nCount As Short = 0

        GroupBox2.Text = "Changing Current Transaction"
        GroupBox2.Visible = True
        txtDate.Visible = True

        miUpdate = giCHANGE

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
                        txtDate.Text = DateTimePickerAccessibleObject.ToString
                        mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

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
                        txtTimeKey.Text = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        txtTimeKey.Tag = txtTimeKey.Text
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
                        cboReference.Text = value
                    Case "Analysis"
                        cboAnalysis.Text = value
                    Case "Glcode"
                        cboGLcode.Text = value
                    Case "Customer"
                        cboCustomer.Text = value
                    Case "Details"
                        txtDetails.Text = value
                    Case "DebitCredit"
                        cboPayReceipt.Text = value
                    Case "Amount"
                        dAmount = value
                    Case "VAT", "Equiv." 'Equiv. added 29/05/16
                        txtEquiv.Text = CStr(value)
                    Case "Reconciled"
                        txtRec.Text = value
                    Case "Transfer"
                        cboTransfer.Text = value
                        Do While nCount < cboTransfer.Items.Count
                            sTransferAC = Mid(cboTransfer.Items(nCount).ToString, 1, InStr(cboTransfer.Items(nCount).ToString, "-") - 2)
                            If Trim(cboTransfer.Text) = Trim(sTransferAC) Then
                                cboTransfer.Text = cboTransfer.Items(nCount).ToString
                            End If
                            nCount = nCount + 1
                        Loop

                    Case "TransferID"
                        txtTransferID.Text = value
                    Case Else

                End Select

            End If

        Next

        'If cboPayReceipt.Text = "Payment" Then dAmount = dAmount * -1
        If dAmount < 0 Then dAmount = dAmount * -1
        txtAmount.Text = CStr(dAmount)

        txtDate.Tag = txtDate.Text
        gvdTxtDateTag = txtDate.Tag
        cboReference.Tag = cboReference.Text
        cboAnalysis.Tag = cboAnalysis.Text
        'cboAccount.Tag = cboAccount.Text
        cboGLcode.Tag = cboGLcode.Text
        cboCustomer.Tag = cboCustomer.Text
        txtDetails.Tag = txtDetails.Text
        cboPayReceipt.Tag = cboPayReceipt.Text
        txtAmount.Tag = txtAmount.Text
        txtEquiv.Tag = txtEquiv.Text
        'txtFolio.Tag = txtFolio.Text
        cboTransfer.Tag = cboTransfer.Text

        CmdSelect.Enabled = False
        CmdFind.Enabled = False
        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdOk.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click

        'Dim sAccountNo As String
        Dim sSql As String
        Dim Msg As String
        Dim Style As Short
        Dim Title As String = Nothing
        Dim iResponse As Short
        Dim bok As Boolean

        'get values from currently selected record
        CmdChange_Click(AcceptButton, e)
        GroupBox2.Text = "Delete Current Transaction"

        Msg = " Confirm deletion of current transaction "
        Title = "Delete Transaction"
        Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
        iResponse = MsgBox(Msg, Style, Title)

        'On Error GoTo ErrorDeleteTransaction

        If iResponse = MsgBoxResult.Yes Then

            Call SetHourGlassWait()

            miUpdate = giDELETE

            'turn off grid
            DataGridPbsTrans.Enabled = False

            'store date from which to update balances
            gvPreviousPostDate = mvLastDate
            gvPreviousPostTimeKey = txtTimeKey.Text

            '
            'will this affect the Final Accounts?  May need to set RefreshReqd
            '
            'iResponse = CheckFinalChanged(gsAccountNo, gvPreviousPostDate)
            'Select Case iResponse
            '    Case 2  'Abort
            'txtDate.SetFocus()
            'Exit Sub
            '    Case Else
            'End Select

            'is there a transfer record to delete?
            If txtTransferID.Text > 0 Then
                'sAccountNo = NullToStr(dataTrans.Recordset("Transfer"))
                ''iResponse = CheckFinalChanged(sAccountNo, Str(gvPreviousPostDate))'changed 04/02/2007
                'iResponse = CheckFinalChanged(sAccountNo, gvPreviousPostDate)
                'Select Case iResponse
                'Case 2  'Abort
                'txtDate.Focus()
                'Exit Sub
                'Case Else
                'End Select

                'Delete matching Transfer record?
                Call DeleteTransfer(txtTransferID.Text)
            End If

            'Delete target record
            sSql = "Delete From pbstrans"
            sSql = sSql + " Where AccountNo = " + qte(gsAccountNo)
            sSql = sSql + " And [Date] = " + AccessDate(mvLastDate)
            sSql = sSql + " And Timekey = " + AccessTime(txtTimeKey.Text)

            bok = DoSql(sSql, 1)

            '
            'Update screen and DB
            '

            Call UpdateBalancesDB(gsAccountNo)

            'reload data from DB
            Call RefreshDetails()

            PbstransBindingSource.MoveLast()

            DataGridPbsTrans.Enabled = True

            'txtDate.Tag = txtDate.Text
            'gvdTxtDateTag = txtDate.Text
            'txtTimeKey.Tag = txtTimeKey.Text
            'cboTransfer.Tag = cboTransfer.Text
            'cboPayReceipt.Tag = cboPayReceipt.Text
            'txtAmount.Tag = txtAmount.Text
            'txtEquiv.Tag = txtEquiv.Text
            'txtFolio.Tag = txtFolio.Text
            'cboReference.Tag = cboReference.Text
            'cboAnalysis.Tag = cboAnalysis.Text
            'cboAccount.Tag = cboAccount.Text
            'cboGLcode.Tag = cboGLcode.Text
            'cboCustomer.Tag = cboCustomer.Text
            'txtDetails.Tag = txtDetails.Text

            If PbstransBindingSource.Count > 0 Then
                CmdSelect.Enabled = True 'Cmd3DOpenAC.Enabled = False
                CmdAdd.Enabled = True
                CmdChange.Enabled = True
                CmdDelete.Enabled = True
                CmdFind.Enabled = True
                CmdOk.Enabled = False
                CmdCancel.Enabled = False
            Else
                CmdSelect.Enabled = True
                CmdAdd.Enabled = True
                CmdChange.Enabled = False
                CmdDelete.Enabled = False
                CmdOk.Enabled = False
                CmdCancel.Enabled = False
            End If

            GroupBox2.Text = "Add/Change"
            GroupBox2.Visible = False
            miUpdate = False

            Call DisplayHeader()

            Call SetHourGlassDefault()

            Msg = "Current transaction deleted"
            MsgBox(Msg, vbExclamation, Title)

            'Set Budget RefreshReqd to 'Yes' as the transaction file has changed
            Call SetRefreshReqd()
            'Set Final RefreshReqd to 'Yes' if the transaction file has changed?
            'bOk = CheckFinalChanged(CStr(gvPreviousPostDate))

        Else
            Msg = "Current transaction NOT deleted"
            MsgBox(Msg, vbExclamation, Title)
        End If

        GroupBox2.Visible = False

        Exit Sub

ErrorDeleteTransaction:

        On Error GoTo 0
        Msg = "Error in Deleting Transaction"
        iResponse = MsgBox(Msg, Style, Title)
        Exit Sub

    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        'Dim clsStandingOrder As New clsStandingOrders
        Dim nDate As Date = Now
        Dim tDate As Date
        Dim vDate As Date
        Dim dateCheck As Boolean
        Dim sAccountNo As String = Nothing
        Dim Msg As String
        Dim Style As Short
        Dim Title As String = Nothing
        Dim iResponse As Short

        miTransfer = False

        tDate = Date.Parse(txtDate.Text)

        dateCheck = IsDate(tDate)
        If Not dateCheck Then
            Msg = " Date error - please rectify"
            Title = "Enter transaction date"
            MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
            txtDate.Focus()
            Exit Sub
        End If

        nDate = Now 'FormatDateTime(Now, DateFormat.LongDate)
        vDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, nDate)

        If tDate > vDate Then
            Msg = "Date entered is more than two months in the future - is this correct?"
            Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
            iResponse = MsgBox(Msg, Style, Title)
            If iResponse = MsgBoxResult.No Then
                txtDate.Focus()
                Exit Sub
            End If
        End If

        If cboPayReceipt.Text = "" Then
            cboPayReceipt.Text = "Payment"
        Else
            If Mid(cboPayReceipt.Text, 1, 1) = "R" Then
                cboPayReceipt.Text = "Receipt"
            Else
                cboPayReceipt.Text = "Payment"
            End If
        End If

        'If Trim(cboPayReceipt.Text) <> "Receipt" Then 'changed 28/04/16
        'cboPayReceipt.Text = "Payment"
        'End If

        'Has Transfer transaction account no. been entered?
        If Trim(cboTransfer.Text) <> "" Then
            'Validate - Compare a/c no only
            For X = 0 To cboTransfer.Items.Count - 1
                If Trim(cboTransfer.Text) = Trim(cboTransfer.Items.Item(X)) Then miTransfer = True : Exit For
            Next X
            If miTransfer = False Then
                Msg = " Transfer account number error - please rectify"
                Title = "Enter transfer account number"
                MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                cboTransfer.Focus()
                Exit Sub
            End If
        End If

        '
        'will this affect the Final Accounts?  May need to set RefreshReqd
        'iResponse = CheckFinalChanged(gsAccountNo.Value, txtDate.Text)
        'Select Case iResponse
        '    Case 2 'Abort
        'txtDate.Focus()
        'Exit Sub
        '    Case Else
        'End Select

        'has the transaction date changed and txtDate.tag not blank? added 24/04/05
        'If txtDate.Tag <> txtDate.Text And txtDate.Tag <> "" Then '!!
        'iResponse = CheckFinalChanged(gsAccountNo.Value, CStr(txtDate.Tag))
        'Select Case iResponse
        '   Case 2 'Abort
        'txtDate.Focus()
        'Exit Sub
        '   Case Else
        'End Select
        'End If

        'is there a transfer transaction?
        If miTransfer = True Then
            If InStr(cboTransfer.Text, "-") Then
                'Left(String)...doesn't work!
                cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1) 'jpg strip bank & branch
            End If

            'iResponse = CheckFinalChanged(CStr(cboTransfer.Text), CStr(txtDate.Text))
            'Select Case iResponse
            '    Case 2 'Abort
            'txtDate.Focus()
            'Exit Sub
            '    Case Else
            'End Select

            'has the transaction date changed and txtDate.tag not blank? added 24/04/05
            'If FormatDateTime(txtDate.Tag, "dd/mmm/yyyy") <> FormatDateTime(txtDate.Text, "dd/mmm/yyyy") And txtDate.Tag <> "" Then
            'iResponse = CheckFinalChanged(CStr(cboTransfer.Text), CStr(txtDate.Tag))
            'Select Case iResponse
            '    Case 2 'Abort
            'txtDate.Focus()
            'Exit Sub
            '    Case Else
            'End Select
            'End If
        End If

        'OK. Let's do it
        Call SetHourGlassWait()

        Select Case miUpdate
            Case giADD
                Call PostTransaction()
            Case giCHANGE
                Call EditTransaction()
            Case Else
        End Select

        'Check for Standing Order transactions?
        If gvPostDate > gvBalanceDate Then
            Call CheckStandingOrders()
            'clsStandingOrder.Check
        End If

        '
        'Update screen and DB
        '

        Call UpdateBalancesDB(gsAccountNo)

        Call DisplayHeader()

        'reload data from DB
        Call RefreshDetails()

        PbstransBindingSource.MoveLast()

        DataGridPbsTrans.Enabled = True

        'Set Budget RefreshReqd to 'Yes' as the transaction file has changed
        Call SetRefreshReqd()

        txtDate.Tag = txtDate.Text
        gvdTxtDateTag = txtDate.Text
        txtTimeKey.Tag = txtTimeKey.Text
        cboTransfer.Tag = cboTransfer.Text
        cboPayReceipt.Tag = cboPayReceipt.Text
        txtAmount.Tag = txtAmount.Text
        txtEquiv.Tag = txtEquiv.Text
        'txtFolio.Tag = txtFolio.Text
        cboReference.Tag = cboReference.Text
        cboAnalysis.Tag = cboAnalysis.Text
        'cboAccount.Tag = cboAccount.Text
        cboGLcode.Tag = cboGLcode.Text
        cboCustomer.Tag = cboCustomer.Text
        txtDetails.Tag = txtDetails.Text

        If PbstransBindingSource.Count > 0 Then
            CmdSelect.Enabled = True
            CmdAdd.Enabled = True
            CmdChange.Enabled = True
            CmdDelete.Enabled = True
            CmdFind.Enabled = True
            CmdOk.Enabled = False
        Else
            CmdSelect.Enabled = True
            CmdAdd.Enabled = True
            CmdChange.Enabled = False
            CmdDelete.Enabled = False
            CmdOk.Enabled = False
        End If

        cboReference.Enabled = True

        Call DisplayHeader()

        GroupBox2.Text = "Add/Change"
        GroupBox2.Visible = False
        miUpdate = False
        giProjSO = False
        GroupBox4.Visible = False

        Call SetHourGlassDefault()

        Exit Sub

    End Sub

    Private Sub CmdOkProj_Click(sender As Object, e As EventArgs) Handles CmdOkProj.Click

        Dim Msg, Title

        If Not IsDate(ProjDateTimePicker1.Text) Then
            Msg = " Date error - please rectify"
            Title = "Enter projected date"
            MsgBox(Msg, vbExclamation, Title)
            ProjDateTimePicker1.Focus()
            Exit Sub
        End If

        'advance posting date to projected date
        gvPostDate = ProjDateTimePicker1.Text

        CmdSelect.Enabled = False
        CmdFind.Enabled = False
        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdOk.Enabled = False
        CmdOkFind.Enabled = False
        CmdOkProj.Enabled = False
        CmdExit.Enabled = False

        If gvPostDate > gvBalanceDate Then

            Call SetHourGlassWait()

            gvPreviousPostDate = gvBalanceDate

            Call CreatePhantomSOs()
            Call CheckProjections()
            Call UpdateBalancesDB(gsAccountNo)

            Call SetHourGlassDefault()

            Call DisplayDetails()

        End If

        CmdSelect.Enabled = True
        CmdFind.Enabled = True
        CmdAdd.Enabled = True
        CmdChange.Enabled = True
        CmdDelete.Enabled = True
        CmdOk.Enabled = False
        CmdOkFind.Enabled = False
        CmdOkProj.Enabled = False
        CmdCancel.Enabled = True
        CmdExit.Enabled = True

        'giProjSO = False
        'GroupBox2.Visible = True
        'GroupBox4.Visible = False

    End Sub

    Private Sub CmdOkReport_Click(sender As Object, e As EventArgs) Handles CmdOkReport.Click

        Dim sSql As String
        Dim Msg As String
        Dim Title As String
        Dim sFields As String
        Dim stxtGroup As String = "0"
        Dim X As Integer
        Dim nRetryCount As Integer
        Dim Result As Integer

        If cboGroup1.Text = "" Then cboGroup1.SelectedIndex = 1

        txtGroup1.Text = cboGroup1.SelectedIndex + 1
        txtGroup2.Text = cboGroup2.SelectedIndex + 1
        txtGroup3.Text = cboGroup3.SelectedIndex + 1

        msSelection = GetDates()
        If msSelection = "" Then Exit Sub

        Call SetHourGlassWait()

        On Error GoTo CmdOKRpt_Click_Error

        If msSelection <> "" And txtGroup1.Text <> "txtGroup" Then

            sFields = "dirpbs.BudgetNo, pbstrans.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
            sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
            sFields = sFields & ", pbstrans.Date, pbstrans.TimeKey"
            sFields = sFields & ", pbstrans.Amount, pbstrans.VAT, pbstrans.DebitCredit, pbstrans.Balance"
            sFields = sFields & ", Customers.Name as CustDesc"
            sFields = sFields & ", Analysis.Description as AnlysDesc"
            sFields = sFields & ", Account.Description as AccDesc"
            sFields = sFields & ", GLcode.Description as GLDesc"

            For X = 1 To 3

                Select Case X

                    Case 1
                        stxtGroup = txtGroup1.Text
                    Case 2
                        stxtGroup = txtGroup2.Text
                    Case 3
                        stxtGroup = txtGroup3.Text

                End Select

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
                        sFields = sFields & ", pbstrans.Folio as Group" & CStr(X)
                    Case "8"
                        sFields = sFields & ", pbstrans.Reconciled as Group" & CStr(X)
                    Case Else
                        sFields = sFields & ", '' as Group" & CStr(X)
                End Select
            Next X

            Call DropTable("TransTempA")

            sSql = "SELECT " & sFields & " INTO TransTempA"
            sSql = sSql & " FROM dirpbs, pbstrans, Customers, Analysis, Account, GLcode,"
            sSql = sSql & " pbstrans LEFT JOIN dirpbs"
            sSql = sSql & " ON pbstrans.AccountNo = dirpbs.AccountNo,"
            sSql = sSql & " pbstrans LEFT JOIN Customers"
            sSql = sSql & " ON pbstrans.Customer = Customers.ShortName,"
            sSql = sSql & " pbstrans LEFT JOIN Analysis"
            sSql = sSql & " ON pbstrans.Analysis = Analysis.Code,"
            sSql = sSql & " pbstrans LEFT JOIN Account"
            sSql = sSql & " ON pbstrans.Account = Account.Code,"
            sSql = sSql & " pbstrans LEFT JOIN GLcode"
            sSql = sSql & " ON pbstrans.GLcode = GLcode.Code"
            sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
            sSql = sSql & " AND " & msSelection
            sSql = sSql & " ORDER BY Date, Timekey"

            If DoSql(sSql, 1) Then
                'Debug.Print sSql
                'AxCrystalReport1.DataFiles(0) = gsDBFileName
                If gsDBName = "Live" Then
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsTrnA.rpt"
                Else
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsTrnB.rpt"
                End If
                AxCrystalReport1.ReportSource = 0            'use rpt format
                AxCrystalReport1.Destination = 0             'Screen
                'Call SetPrinterOrient(PORTRAIT)
                'On Error GoTo Retry
                'Result = AxCrystalReport1.PrintReport       'Do it
                AxCrystalReport1.Action = 1                'Do it
                'On Error GoTo 0
                'Call ReSetPrinterOrient()
            End If
            Else
                Msg = " No records selected"
                Title = "Statement"
                MsgBox(Msg, vbExclamation, Title)
            End If

            Call SetHourGlassDefault()

            Exit Sub

Retry:

            nRetryCount = nRetryCount + 1
            If nRetryCount < 3 Then
                Resume
            Else
                Call MsgBox("Print Report", sSql)
                On Error GoTo 0
                Call SetHourGlassDefault()
            End If

            Exit Sub

CmdOKRpt_Click_Error:

            Call MsgBox("Print Report", sSql)
            On Error GoTo 0
            Call SetHourGlassDefault()

            Exit Sub

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click

        Call ClearFields()

        GroupBox2.Visible = False
        GroupBox2.Text = "Add/Change"
        GroupBox4.Visible = False
        TabControl1.Visible = False

        giProjSO = False '?????

        If giProjSO = False Then
            Call DeletePhantomSOs()
            Call DeleteProjections()
        End If

        Call DisplayDetails()

        'turn on grid
        DataGridPbsTrans.Enabled = Enabled

        'Refresh Controls
        If PbstransBindingSource.Count > 0 Then
            CmdSelect.Enabled = True
            CmdAdd.Enabled = True
            CmdChange.Enabled = True
            CmdDelete.Enabled = True
            CmdFind.Enabled = True
            CmdOk.Enabled = False
        Else
            CmdSelect.Enabled = True
            CmdAdd.Enabled = True
            CmdChange.Enabled = False
            CmdDelete.Enabled = False
            CmdOk.Enabled = False
        End If

        cboReference.Enabled = True

        CmdOk.Visible = True
        CmdOkFind.Visible = False
        CmdOkProj.Visible = False
        txtDateFind.Visible = False
        TabControl1.Visible = False

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click

        Me.Dispose()

    End Sub

    Private Sub PostTransfer(TransferID As Integer)

        Dim sAccountNo As String
        Dim currentPostDate As Date
        Dim currentPostTime As Date
        Dim Amount As Double
        Dim Equiv As Double
        Dim sFromCCY As String = Nothing
        Dim sToCCY As String = Nothing
        Dim sSql As String = Nothing
        Dim sPayReceipt As String = Nothing

        currentPostDate = Date.Parse(txtDate.Text)
        currentPostTime = TimeOfDay
        currentPostTime = DateAdd("s", 1, currentPostTime)              'avoid duplicate key!

        'strip bank & branch
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1)
        End If

        'switch from debit to credit or vice versa
        sPayReceipt = cboPayReceipt.Text
        If sPayReceipt = "Payment" Then
            sPayReceipt = "Receipt"
        Else
            sPayReceipt = "Payment"
        End If

        '
        'create transaction in PbsTrans
        '
        sSql = "Insert into pbstrans"
        sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
        If sPayReceipt = "Payment" Then
            sSql = sSql + " Folio, Reconciled, DebitCredit, Payment, Amount, VAT, Transfer, TransferID)"
        Else
            sSql = sSql + " Folio, Reconciled, DebitCredit, Receipt, Amount, VAT, Transfer, TransferID)"
        End If
        sSql = sSql + " Values ("
        sSql = sSql + "  " + qte(cboTransfer.Text)          'qte(msAccountNo)
        sSql = sSql + ", " + AccessDate(currentPostDate) 'Date.Parse(txtDate.Text))
        sSql = sSql + ", " + (AccessTime(currentPostTime))
        sSql = sSql + ", " + qte(cboReference.Text + " ")
        sSql = sSql + ", " + qte(cboAnalysis.Text + " ")
        sSql = sSql + ", ' '"                               'AccountCode
        sSql = sSql + ", " + qte(cboGLcode.Text + " ")
        sSql = sSql + ", " + qte(txtDetails.Text + " ")
        sSql = sSql + ", " + qte(cboCustomer.Text + " ")
        sSql = sSql + ", ' '"                               'Folio
        If UCase(txtRec.Text) = "Y" Then
            sSql = sSql + ", " + qte(UCase(txtRec.Text + " "))
        Else
            sSql = sSql + ", " + qte("N")
        End If
        sSql = sSql + ", " + qte(sPayReceipt)
        'cater for foreign currency transfer?
        If Val(txtEquiv.Text) <> 0 Then 'jpg
            Amount = CDec(Val(txtEquiv.Text))               'jpg now used for storing optional equiv ccy amount
            Equiv = CDec(Val(txtAmount.Text))
        Else
            sFromCCY = gsTranCCY
            Call GetTranCCY(CStr(cboTransfer.Text), sToCCY)
            Amount = CDec(ConvertAmount(Val(txtAmount.Text), sFromCCY, sToCCY))
            Equiv = 0                                       'ConvertAmount(Val(txtVAT), sFromCCY, sToCCY)
        End If
        'adjust for signs
        If sPayReceipt = "Payment" Then                     'cboPayReceipt.Text = "Payment"
            'Amount = CDec(Val(txtAmount.Text))
            sSql = sSql + ", " + qte(Amount) ' * -1)        'Payment 
            'sSql = sSql + ", ''"                           'Receipt
            sSql = sSql + ", " + qte(Amount * -1)           'Amount Swap signs
            'Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Equiv) ' * -1)         'Equiv 
        Else
            'Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", ''"                           'Payment
            sSql = sSql + ", " + qte(Amount)                'Receipt
            sSql = sSql + ", " + qte(Amount)                'Amount
            'Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Equiv)                 'Equiv
        End If

        sSql = sSql + ", " + qte(msAccountNo)               'qte(cboTransfer.Text + " ")
        sSql = sSql + ", " + CStr(TransferID)
        sSql = sSql + ")"

        '
        'ok, let's do it
        '
        On Error GoTo DoSqlError 'added 19/09/2017

        If DoSql(sSql, 1) = True Then
            sAccountNo = cboTransfer.Text
            'always update balances...                      '19/02/16
            'Call UpdateBalancesDB(sAccountNo)               'update balances for current value of cboTransfer 19/02/16
            Call UpdateBalancesTfrDB(sAccountNo, currentPostDate, currentPostTime)
        Else

        End If

        On Error GoTo 0

        Exit Sub

DoSqlError:

        ' error message wanted?
        'If bShowError Then
        Call MessageBox.Show("DoSQL", "Last SQL: " & sSql)
        'End If

        On Error GoTo 0

        Exit Sub

RetryPostTransfer:

        Resume

    End Sub

    Public Sub EditTransfer(TransferID As Integer)

        Dim Amount As Double = 0
        Dim currentPostDate As Date
        Dim currentPostTime As Date
        Dim Equiv As Double
        Dim sFromCCY As String = Nothing
        Dim sToCCY As String = Nothing
        Dim DateTimePickerAccessibleObject As Object = 0
        'Dim currentTime As Date
        Dim TimekeyCounter As Short = 0
        Dim sSql As String = Nothing
        Dim pUpdate As Integer
        Dim sPayReceipt As String = Nothing
        Dim sAccountNo As String = Nothing

        'currentTime = TimeOfDay
        'currentTime = DateAdd("s", 1, currentTime) 'avoid duplicate key!
        If txtDate.Text < txtDate.Tag Then
            'backdated
            currentPostDate = Date.Parse(txtDate.Text)
            currentPostTime = txtTimeKey.Text
        Else
            currentPostDate = Date.Parse(txtDate.Tag)
            currentPostTime = txtTimeKey.Tag
        End If
        pUpdate = False

        'strip bank & branch
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1)
        End If
        'strip bank & branch
        If InStr(cboTransfer.Tag, "-") Then
            cboTransfer.Tag = Mid(cboTransfer.Tag, 1, InStr(cboTransfer.Tag, "-") - 1)
        End If

        'only update Transfer record if one or more of these data fields have changed
        If txtDate.Tag <> txtDate.Text Then pUpdate = True
        If cboTransfer.Tag <> cboTransfer.Text Then pUpdate = True
        If cboPayReceipt.Tag <> cboPayReceipt.Text Then pUpdate = True
        If txtAmount.Tag <> txtAmount.Text Then pUpdate = True
        If txtEquiv.Tag <> txtEquiv.Text Then pUpdate = True

        If pUpdate = False Then Exit Sub 'No need to change matching Transfer transaction, so exit

        'switch from debit to credit or vice versa
        sPayReceipt = cboPayReceipt.Text
        If sPayReceipt = "Payment" Then
            sPayReceipt = "Receipt"
        Else
            sPayReceipt = "Payment"
        End If

        '
        'Update transaction in PbsTrans
        '
        sSql = "Update pbstrans"
        sSql = sSql + " Set"
        sSql = sSql + "  [Date] = " + AccessDate(txtDate.Text)
        'sSql = sSql + " , Timekey = " + (AccessTime(currentTime))  'keep existing time 19/02/16
        'has cboTransfer changed?                                   '19/02/16
        If cboTransfer.Tag <> cboTransfer.Text Then
            sSql = sSql + " , AccountNo = " + qte(cboTransfer.Text) 'update with new value 19/02/16
        End If
        sSql = sSql + " , Reference = " + qte(cboReference.Text + " ")
        sSql = sSql + " , Analysis = " + qte(cboAnalysis.Text + " ")
        'sSql = sSql + " , AccountCode = " 
        sSql = sSql + " , GLcode = " + qte(cboGLcode.Text + " ")
        sSql = sSql + " , Details = " + qte(txtDetails.Text + " ")
        sSql = sSql + " , Customer = " + qte(cboCustomer.Text + " ")
        'sSql = sSql + " , Folio = " 
        'If UCase(txtRec.Text) = "Y" Then 'removed 29/05/16
        'sSql = sSql + ", Reconciled = " + qte(UCase(txtRec.Text + " "))
        'Else
        'sSql = sSql + ", Reconciled = " + qte("N")
        'End If
        sSql = sSql + ", DebitCredit = " + qte(sPayReceipt)         '20/02/16
        'cater for foreign currency transfer?
        If (Val(txtEquiv.Text)) <> 0 Then 'jpg
            Amount = CDec(Val(txtEquiv.Text))                       'now used for storing optional equiv ccy amount
            Equiv = CDec(Val(txtAmount.Text))
        Else
            sFromCCY = gsTranCCY
            Call GetTranCCY(CStr(cboTransfer.Text), sToCCY)
            Amount = CDec(ConvertAmount(Val(txtAmount.Text), sFromCCY, sToCCY))
            Equiv = 0                                               'ConvertAmount(Val(txtVAT), sFromCCY, sToCCY)
        End If
        'adjust for signs
        If sPayReceipt = "Payment" Then
            'Amount = CDec(Val(txtAmount.Text))
            sSql = sSql + ", Payment = " + qte(Amount)              'Payment
            'sSql = sSql + ", Receipt = ''"                         'Receipt
            sSql = sSql + ", Amount = " + qte(Amount * -1)          'Amount Swap sign
            'Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Equiv) ' * -1)           'Equiv
        Else
            'Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", Payment = ''"                         'Payment
            sSql = sSql + ", Receipt = " + qte(Amount)              'Receipt
            sSql = sSql + ", Amount = " + qte(Amount)               'Amount
            'Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Equiv)                   'Equiv
        End If
        sSql = sSql + " , Transfer = " + qte(msAccountNo)           'cboTransfer.Text

        sSql = sSql + " Where Date = " + AccessDate(gvdTxtDateTag)  'Previous Date to Edit
        'sSql = sSql + " And Timekey = " + AccessTime(txtTimeKey.Tag)'Previous Time to Edit - not needed 19/02/16
        'sSql = sSql + " And AccountNo <> " + qte(gsAccountNo)
        sSql = sSql + " And AccountNo = " + qte(CStr(cboTransfer.Tag)) 'Previous value of cboTransfer 19/02/16
        sSql = sSql + " And TransferID = " + CStr(TransferID)

        '
        'ok, let's do it
        '
        If DoSql(sSql, 1) Then
            'has cboTransfer changed?                               '19/02/16
            If cboTransfer.Tag <> cboTransfer.Text Then
                sAccountNo = cboTransfer.Tag
                'Call UpdateBalancesDB(CStr(cboTransfer.Tag))        'update balances for previous value of cboTransfer
                Call UpdateBalancesTfrDB(sAccountNo, currentPostDate, currentPostTime)
            End If
            'always update balances...                              '19/02/16
            sAccountNo = cboTransfer.Text
            'Call UpdateBalancesDB(sAccountNo)                       'update balances for current value of cboTransfer
            Call UpdateBalancesTfrDB(sAccountNo, currentPostDate, currentPostTime)
        End If

    End Sub

    Public Sub DeleteTransfer(TransferID As Integer)

        Dim sSql As String = Nothing
        Dim sAccountNo As String = Nothing
        Dim currentPostDate As Date
        Dim currentPostTime As Date
        Dim Title As String
        Dim Msg As String
        Dim style As Short
        Dim iResponse As Short

        currentPostDate = Date.Parse(txtDate.Text)
        currentPostTime = txtTimeKey.Text

        Msg = " Confirm deletion of matching Transfer transaction "
        Title = "Delete Matching Transfer Transaction"
        'Dialog = vbYesNo + vbExclamation + vbDefaultButton2 ' Describe dialog.
        style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2

        iResponse = MsgBox(Msg, style, Title)

        If iResponse = MsgBoxResult.Yes Then

            'strip bank & branch
            If InStr(cboTransfer.Text, "-") Then
                cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1)
            End If

            sSql = "Delete From pbstrans"
            'sSql = sSql + " Where AccountNo <> " + qte(gsAccountNo) 
            sSql = sSql + " Where AccountNo = " + qte(cboTransfer.Text) '19/02/16
            sSql = sSql + " And TransferID = " + CStr(TransferID)

            If DoSql(sSql, 1) Then
                Msg = "Matching Transfer transaction deleted"
                MsgBox(Msg, vbExclamation, Title)
                'always update balances...                              '19/02/16
                sAccountNo = cboTransfer.Text
                'Call UpdateBalancesDB(sAccountNo)                       'update balances for current value of cboTransfer
                Call UpdateBalancesTfrDB(sAccountNo, currentPostDate, currentPostTime) '27/11/16
            Else
                Msg = "Matching Transfer transaction NOT found"
                MsgBox(Msg, vbExclamation, Title)
            End If

        Else
            Msg = "Matching Transfer transaction NOT deleted"
            MsgBox(Msg, vbExclamation, Title)
        End If

    End Sub

    Public Sub PostSOTransfer(ByVal dso As DataTable, ByVal nSoCount As Integer, ByVal TransferID As Integer)

        Dim sTransfer As String = ""
        Dim sAccountNo As String
        Dim sField As String
        Dim sPayReceipt As String = Nothing
        Dim DateDue As Date
        Dim Timekey As DateTime
        Dim CurrentTime As DateTime
        Dim Amount As Double
        Dim Equiv As Double
        Dim sFromCCY As String = Nothing
        Dim sToCCY As String = Nothing
        Dim sSql As String = Nothing
        Dim bOk As Boolean

        CurrentTime = TimeOfDay
        CurrentTime = DateAdd("s", nSoCount + 30, CurrentTime)

        Call SetHourGlassWait()

        sTransfer = IIf(IsDBNull(dso.Rows.Item(nSoCount)("Transfer")), "", (dso.Rows.Item(nSoCount)("Transfer")))
        'strip bank & branch
        If InStr(sTransfer, "-") Then
            sTransfer = Mid(sTransfer, 1, InStr(sTransfer, "-") - 1)
        End If

        'switch from debit to credit or vice versa
        sPayReceipt = dso.Rows.Item(nSoCount)("DebitCredit")    'cboPayReceipt.Text
        If sPayReceipt = "Payment" Then
            sPayReceipt = "Receipt"
        Else
            sPayReceipt = "Payment"
        End If

        '
        'create transaction in PbsTrans
        '
        sSql = "Insert into pbstrans"
        sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
        If sPayReceipt = "Payment" Then
            sSql = sSql + " Folio, Reconciled, DebitCredit, Payment, Amount, VAT, Transfer, TransferID)"
        Else
            sSql = sSql + " Folio, Reconciled, DebitCredit, Receipt, Amount, VAT, Transfer, TransferID)"
        End If
        sSql = sSql + " Values ("
        sSql = sSql + "  " + qte(Trim(sTransfer))               'qte(Trim(dso.Rows.Item(nSoCount)("AccountNo")))
        sSql = sSql + ", " + (AccessDate(dso.Rows.Item(nSoCount)("Date")))
        sSql = sSql + ", " + (AccessTime(CurrentTime))
        sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Reference") + " ")
        sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Analysis") + " ")
        sSql = sSql + ", ' '" '+ qte()                          'AccountCode
        sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("GLCode") + " ")
        sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Details") + " ")
        sSql = sSql + ", " + qte(dso.Rows.Item(nSoCount)("Customer") + " ")
        sField = IIf(IsDBNull(dso.Rows.Item(nSoCount)("Folio")), "", (dso.Rows.Item(nSoCount)("Folio"))) 'Used by Forward Projections
        sSql = sSql + ", " + qte(sField)
        sSql = sSql + ", " + qte("N")
        sSql = sSql + ", " + qte(sPayReceipt)
        'cater for foreign currency transfer?
        Equiv = Val(dso.Rows.Item(nSoCount)("VAT"))
        If Val(Equiv) <> 0 Then
            Amount = CDec(Equiv)                                'now used for storing optional equiv ccy amount
            Equiv = CDec(Val(dso.Rows.Item(nSoCount)("Amount")))
        Else
            sFromCCY = gsTranCCY
            Call GetTranCCY(sTransfer, sToCCY)
            Amount = CDec(ConvertAmount(Val(CStr(dso.Rows.Item(nSoCount)("Amount"))), sFromCCY, sToCCY))
            Equiv = 0 'ConvertAmount(Val(txtVAT), sFromCCY, sToCCY)
        End If
        If sPayReceipt = "Payment" Then
            'Amount = CDec(Val(dso.Rows.Item(nSoCount)("Amount")))
            sSql = sSql + ", " + qte(Amount)                    'Payment
            'sSql = sSql + ", ''"                               'Receipt
            sSql = sSql + ", " + qte(Amount * -1)               'Amount Swap sign
            'Equiv = CDec(Val((dso.Rows.Item(nSoCount)("VAT"))))
            sSql = sSql + ", " + qte(Equiv) ' * -1)             'Equiv 
        Else
            'Amount = CDec(Val(dso.Rows.Item(nSoCount)("Amount")))
            'sSql = sSql + ", ''"                               'Payment
            sSql = sSql + ", " + qte(Amount)                    'Receipt
            sSql = sSql + ", " + qte(Amount)                    'Amount
            'Equiv = CDec(Val((dso.Rows.Item(nSoCount)("VAT"))))
            sSql = sSql + ", " + qte(Equiv)                     'Equiv
        End If
        sSql = sSql + ", " + qte(Trim(dso.Rows.Item(nSoCount)("AccountNo"))) 'qte(sTransfer) ' + " ")
        sSql = sSql + ", " + qte(CStr(TransferID))
        sSql = sSql + ")"

        'ok, let's do it
        bOk = DoSql(sSql, 1)

        Call UpdateBalancesDB(Trim(sTransfer))

        On Error GoTo 0

        Exit Sub

RetryAdd:

        'currentTime = TimeOfDay
        'PbstransBindingSource("TimeKey") = currentTime
        Resume

RetryUpdate:

        'currentTime = TimeOfDay
        'dso.Rows.Item(nSoCount)("TimeKey") = currentTime
        Resume


    End Sub

    Private Sub FinanceStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinanceStatementToolStripMenuItem.Click

        'View/Report
        frmFinanceStatement.Show()

    End Sub


    Private Sub FinanceStatementToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FinanceStatementToolStripMenuItem1.Click

        'Report/View
        frmFinanceStatement.Show()

    End Sub

    Private Sub MultipleEnquiryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultipleEnquiryToolStripMenuItem.Click

        frmQueries.Show()

    End Sub

    Private Sub DateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "Da"
        frmQueries.Show()

    End Sub

    Private Sub ReferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReferenceToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "Re"
        frmQueries.Show()

    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "Cu"
        frmQueries.Show()

    End Sub

    Private Sub AnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalysisToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "An"
        frmQueries.Show()

    End Sub

    Private Sub GLcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GLcodeToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "GL"
        frmQueries.Show()

    End Sub

    Private Sub AmountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmountToolStripMenuItem.Click

        Call SetHourGlassWait()
        gsQueryType = "Am"
        frmQueries.Show()

    End Sub

    Private Sub AccountNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountNameToolStripMenuItem.Click

        gsTb = "0" '"AccountNames"
        frmSetup.Show()

    End Sub

    Private Sub BankNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankNameToolStripMenuItem.Click

        gsTb = "1" '"BankNames"
        frmSetup.Show()

    End Sub

    Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click

        gsTb = "2" '"Customers"
        frmSetup.Show()

    End Sub

    Private Sub UserNamesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserNamesToolStripMenuItem.Click

        gsTb = "3" '"Users"
        frmSetup.Show()

    End Sub

    Private Sub AnalysisCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalysisCodesToolStripMenuItem.Click

        gsTb = "4" '"Analysis"
        frmSetup.Show()
        'Call UpdatefrmCBO(Me, "Analysis")

    End Sub

    Private Sub GLCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GLCodesToolStripMenuItem.Click

        gsTb = "5" '"GLCode"
        frmSetup.Show()

    End Sub

    Private Sub BudgetsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BudgetsToolStripMenuItem1.Click

        gsTb = "6" '"Budget"
        frmSetup.Show()

    End Sub

    Private Sub CurrenciesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrenciesToolStripMenuItem.Click

        gsTb = "7" '"Currencies"
        frmSetup.Show()

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click

        gsTb = "8" '"Password"
        frmSetup.Show()

    End Sub

    Private Sub ConcurrentSosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConcurrentSOsToolStripMenuItem.Click

        'Moved to frmStartup

        'Dim sSql As String = Nothing
        'Dim bOk As Boolean = False

        'If giUserLevel = 1 Then

        'Concurrent SO's on/off?
        'If ConcurrentSOsToolStripMenuItem.Checked = False Then
        'ConcurrentSOsToolStripMenuItem.Checked = True
        'ConcurrentSOsToolStripMenuItem.Text = "&PostAllSOs Y/N?"
        'sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
        'sSql = sSql + " Set ParameterData = 'Y'" '& qte(Encrypt("YY"))
        'sSql = sSql + " Where Parameter = 'PostAllSOs'" & ";"
        'bOk = DoSql(sSql, 1)
        'Else
        'ConcurrentSOsToolStripMenuItem.Checked = False
        ''ConcurrentSOsToolStripMenuItem.Text = "&PostAllSOs Y/N?"
        'sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
        'sSql = sSql + " Set ParameterData = 'N'" '& qte(Encrypt("NN"))
        'sSql = sSql + " Where Parameter = 'PostAllSOs'" & ";"
        'bOk = DoSql(sSql, 1)
        'End If

        'End If

    End Sub

    Private Sub PasswordsOnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordsOnToolStripMenuItem.Click

        'Moved to frmStartup

        'Dim sSql As String = Nothing
        'Dim bOk As Boolean = False

        'If giUserLevel = 1 Then

        'passwords on/off?
        'If PasswordsOnToolStripMenuItem.Checked = False Then
        'PasswordsOnToolStripMenuItem.Checked = True
        'PasswordsOnToolStripMenuItem.Text = "&Passwords On"
        'sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
        'sSql = sSql + " Set ParameterData = " & qte(Encrypt("YY"))
        'sSql = sSql + " Where Parameter = 'Password'" & ";"
        'bOk = DoSql(sSql, 1)
        'Else
        'PasswordsOnToolStripMenuItem.Checked = False
        'PasswordsOnToolStripMenuItem.Text = "&Passwords Off"
        'sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
        'sSql = sSql + " Set ParameterData = " & qte(Encrypt("NN"))
        'sSql = sSql + " Where Parameter = 'Password'" & ";"
        'bOk = DoSql(sSql, 1)
        'End If

        'End if

    End Sub

    Private Sub AboutVisualPBSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutVisualPBSToolStripMenuItem.Click

        AboutBoxVPBS.Show()

    End Sub

    Private Sub cboPayReceipt_LostFocus(sender As Object, e As EventArgs) Handles cboPayReceipt.LostFocus

        If cboPayReceipt.Text = "" Then
            cboPayReceipt.Text = "Payment"
        End If

        'If Trim(cboPayReceipt.Text) <> "Receipt" Then 'changed 28/04/16
        'cboPayReceipt.Text = "Payment"
        'End If

    End Sub

    Private Sub RefreshBalancesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshBalancesToolStripMenuItem.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class