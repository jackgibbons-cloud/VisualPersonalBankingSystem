'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2017
'
'Standing Orders and Direct Debits View/Edit, incorporating DirBud Selection, Report
'****************************************************************************************************************************
'
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'17/09/15   jpg     Created from Vpbs78
'                   Added test datasources, datagrid
'19/09/15   jpg     Added Crystal.ocx to Ooject Reference
'                   Added Crystal.ocx to Toolbox Data
'                   Added Crystal Report Data Control to form
'                   Copied Execute Report code from VB6, modified it - report working
'22/09/15   jpg     Auto, Manual S/Os and S/O report now working
'                   Add, Change, Delete working
'                   Moved Next Chq, Next Pay No, Repeat last Entry to Manual S/Os table
'                   Added Live datasource
'                   Added fudge in S/O report sql: increment Header index by 1 when Header index >2 
'                   because Account Code now longer used but still in Crystal rpt formula
'31/10/15   jpg     Changed to use one BindingSource for all DB's
'17/01/16   jpg     Added Archive dataset...
'23/06/16   jpg     CmdChange_Click: replaced 'Case "Pay/Receipt" ' with 'Case "DebitCredit" '
'                   as Receipt SO's were being changed to Payment S/O's when making a change to the amount
'16/01/17   jpg     Recreated PbsSoB.rpt from PbsSoA.rpt, but modified to read from Archive DB - Ok
'****************************************************************************************************************************

Public Class frmSOTrans

    Dim miUpdate As Integer = Nothing
    Dim miTransfer As Short = Nothing
    Dim miTfrUpdate As Integer = Nothing

    Private Sub frmSOTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sSql As String

        If giAutoSO Then    'extract auto SO's
            sSql = " And NumPayments > -1"
        Else                'extract manual SO's
            sSql = " And NumPayments = -1"
        End If

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            Me.DirpbsTableAdapterLive.Fill(Me.VPBSDataSet.dirpbs)
            Me.SotransTableAdapterLive.Fill(Me.VPBSDataSet.sotrans)
            Me.AnalysisTableAdapterLive.Fill(Me.VPBSDataSet.Analysis)
            Me.GLCodeTableAdapterLive.Fill(Me.VPBSDataSet.GLCode)
            Me.CustomersTableAdapterLive.Fill(Me.VPBSDataSet.Customers)

            DirpbsBindingSource.DataSource = VPBSDataSet
            SotransBindingSource.DataSource = VPBSDataSet
            AnalysisBindingSource.DataSource = VPBSDataSet
            GLCodeBindingSource.DataSource = VPBSDataSet
            CustomersBindingSource.DataSource = VPBSDataSet

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"
            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
            Me.SotransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.sotrans)
            Me.AnalysisTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Analysis)
            Me.GLCodeTableAdapterArc.Fill(Me.VpbsArchiveDataSet.GLCode)
            Me.CustomersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Customers)

            DirpbsBindingSource.DataSource = VpbsArchiveDataSet
            SotransBindingSource.DataSource = VpbsArchiveDataSet
            AnalysisBindingSource.DataSource = VpbsArchiveDataSet
            GLCodeBindingSource.DataSource = VpbsArchiveDataSet
            CustomersBindingSource.DataSource = VpbsArchiveDataSet

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"
            Me.DirpbsTableAdapterTest.Fill(Me.VPBSTestDataSet.dirpbs)
            Me.SotransTableAdapterTest.Fill(Me.VPBSTestDataSet.sotrans)
            Me.AnalysisTableAdapterTest.Fill(Me.VPBSTestDataSet.Analysis)
            Me.GLCodeTableAdapterTest.Fill(Me.VPBSTestDataSet.GLCode)
            Me.CustomersTableAdapterTest.Fill(Me.VPBSTestDataSet.Customers)

            DirpbsBindingSource.DataSource = VPBSTestDataSet
            SotransBindingSource.DataSource = VPBSTestDataSet
            AnalysisBindingSource.DataSource = VPBSTestDataSet
            GLCodeBindingSource.DataSource = VPBSTestDataSet
            CustomersBindingSource.DataSource = VPBSTestDataSet

        End If

        SotransBindingSource.Filter = "AccountNo = " + qte(gsAccountNo) + sSql 'Select'
        SotransBindingSource.Sort = "Date, TimeKey" 'Order By'
        AnalysisBindingSource.Sort = "Code"
        GLCodeBindingSource.Sort = "Code"
        CustomersBindingSource.Sort = "ShortName"

        DataGridSOTrans.DataSource = SotransBindingSource
        DataGridSOTrans.TopLeftHeaderCell.Value = gsDBName '"------"
        lblAccountHeader.Text = CStr(frmPbsTrans.lblAccountHeader.Text)

        GroupBox2.Visible = False 'add/chg
        GroupBox4.Visible = False 'report

        Call CboGroupsFill()
        Call CboReferenceFill()
        Call CboTransferFill()

    End Sub

    Private Sub DisplayHeader()

        'lblAccountHeader.Text = "A/C: " & sAccountName + " " + sAccountDesc + " " + msAccountNo + " with " + sBankName + " " + sBankBranch + " " + CStr(sBalance) + " " + CStr(sBalanceDate)
        'gvBalanceDate = sBalanceDate

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean = False

        If gsDBName = "Live" Then
            bOk = SotransTableAdapterLive.ClearBeforeFill
            Me.SotransTableAdapterLive.Fill(Me.VPBSDataSet.sotrans)
        ElseIf gsDBName = "Archive" Then
            bOk = SotransTableAdapterArc.ClearBeforeFill
            Me.SotransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.sotrans)
        Else 'Test
            bOk = SotransTableAdapterTest.ClearBeforeFill
            SotransTableAdapterTest.Fill(Me.VPBSTestDataSet.sotrans)
        End If

    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click

        'sotrans
        GroupBox2.Text = "Adding new transaction"
        GroupBox2.Visible = True
        GroupBox4.Visible = False 'report

        miUpdate = giADD

        'turn off grid
        DataGridSOTrans.Enabled = False

        Call ClearFields()
        txtDate.Visible = True
        txtDate.Focus()
        txtTimeKey.Text = TimeOfDay ' added later ??

        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdReportOk.Enabled = False
        CmdOk.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub CmdChange_Click(sender As Object, e As EventArgs) Handles CmdChange.Click

        'soTrans
        Dim sName As String
        Dim dAmount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0

        GroupBox2.Text = "Changing Current Transaction"
        GroupBox2.Visible = True
        GroupBox4.Visible = False 'report

        txtDate.Visible = True

        miUpdate = giCHANGE

        'turn off grid
        DataGridSOTrans.Enabled = False

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridSOTrans.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridSOTrans.Columns(counter).HeaderText.ToString

            'If DataGridPbsTrans.SelectedCells(counter).FormattedValueType Is _
            'Type.GetType("DateTime") Then 'Type.GetType("System.date") The
            If sName = "Date" Then
                'Dim value As Date = Nothing

                If (DataGridSOTrans.IsCurrentCellDirty = True) Then

                    DateTimePickerAccessibleObject = DataGridSOTrans.SelectedCells(counter) _
                     .EditedFormattedValue
                Else

                    DateTimePickerAccessibleObject = DataGridSOTrans.SelectedCells(counter) _
                        .FormattedValue
                End If

                Select Case sName

                    Case "Date"
                        txtDate.Text = DateTimePickerAccessibleObject.ToString
                        'mvLastDate = FormatDateTime(txtDate.Text, DateFormat.LongDate) 'Date.Parse(txtDate.Text)) '??

                    Case Else

                End Select

            End If

            If sName = "TimeKey" Then
                Dim value As Date = Nothing

                If (DataGridSOTrans.IsCurrentCellDirty = True) Then

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.EditedFormattedValue()
                    value = DataGridSOTrans.SelectedCells(counter).Value.ToString
                Else

                    'DateTimePickerAccessibleObject = DataGridPbsTrans.SelectedCells(counter) _
                    '.FormattedValue()
                    value = DataGridSOTrans.SelectedCells(counter).Value.ToString
                End If

                Select Case sName

                    Case "TimeKey"
                        txtTimeKey.Text = value 'FormatDateTime(value, DateFormat.ShortTime) '& TimeKeyDataGridViewTxtBoxColumn1.ToString
                        txtTimeKey.Tag = txtTimeKey.Text
                    Case Else

                End Select

            End If

            If DataGridSOTrans.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridSOTrans.IsCurrentCellDirty = True) Then

                    value = DataGridSOTrans.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridSOTrans.SelectedCells(counter) _
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
                        'Case "Pay/Receipt" '"DebitCredit"
                    Case "DebitCredit" '"Pay/Receipt" 'changed 23/06/16
                        cboPayReceipt.Text = value
                    Case "Amount"
                        dAmount = value
                    Case "Equivalent" '"VAT"
                        txtEquiv.Text = CStr(value)
                    Case "Reconciled"
                        txtRec.Text = value
                    Case "Transfer"
                        cboTransfer.Text = value
                    Case "Daily"
                        txtDaily.Text = value
                    Case "Monthly"
                        txtMonthly.Text = value
                    Case "DayDue"
                        txtDayDue.Text = value
                    Case "NumPayments"
                        txtNumPayments.Text = value
                    Case Else

                End Select

            End If

        Next

        If dAmount < 0 Then dAmount = dAmount * -1
        txtAmount.Text = CStr(dAmount)

        txtDate.Tag = txtDate.Text
        gvdTxtDateTag = txtDate.Tag
        cboReference.Tag = cboReference.Text
        cboAnalysis.Tag = cboAnalysis.Text
        cboGLcode.Tag = cboGLcode.Text
        cboCustomer.Tag = cboCustomer.Text
        txtDetails.Tag = txtDetails.Text
        cboPayReceipt.Tag = cboPayReceipt.Text
        txtAmount.Tag = txtAmount.Text
        txtEquiv.Tag = txtEquiv.Text
        cboTransfer.Tag = cboTransfer.Text

        CmdAdd.Enabled = False
        CmdChange.Enabled = False
        CmdDelete.Enabled = False
        CmdReport.Enabled = True
        CmdReportOk.Visible = False
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

        'GroupBox2.Visible = True
        GroupBox4.Visible = False 'report

        'turn off grid
        DataGridSOTrans.Enabled = False

        Msg = " Confirm deletion of current transaction "
        Title = "Delete Transaction"
        Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
        iResponse = MsgBox(Msg, Style, Title)

        On Error GoTo ErrorDeleteTransaction

        If iResponse = MsgBoxResult.Yes Then

            Call SetHourGlassWait()

            miUpdate = giDELETE

            'turn off grid
            DataGridSOTrans.Enabled = False

            'get values from currently selected record
            CmdChange_Click(AcceptButton, e)

            'Delete target record
            sSql = "Delete From SOtrans"
            sSql = sSql + " Where AccountNo = " + qte(gsAccountNo)
            sSql = sSql + " And [Date] = " + AccessDate(txtDate.Text)
            sSql = sSql + " And Timekey = " + AccessTime(txtTimeKey.Text)

            bok = DoSql(sSql, 1)

            '
            'Update screen and DB

            'reload data from DB
            Call RefreshDetails()

            SotransBindingSource.MoveLast()
            DataGridSOTrans.Enabled = True

            miUpdate = False

            'Call DisplayHeader()

            Call SetHourGlassDefault()
            Msg = "Current transaction deleted"
            MsgBox(Msg, vbExclamation, Title)

        Else

            Call SetHourGlassDefault()
            Msg = "Current transaction NOT deleted"
            MsgBox(Msg, vbExclamation, Title)
        End If

        GroupBox2.Visible = False
        GroupBox2.Text = "Add/Change"

        'turn on grid
        DataGridSOTrans.Enabled = True

        If SotransBindingSource.Count > 0 Then
            CmdAdd.Enabled = True
            CmdChange.Enabled = True
            CmdDelete.Enabled = True
            'CmdReport.Enabled = False
            CmdReportOk.Enabled = True
            CmdOk.Enabled = False
            CmdCancel.Enabled = False
        Else
            CmdAdd.Enabled = True
            CmdChange.Enabled = False
            CmdDelete.Enabled = False
            CmdReport.Enabled = False
            CmdReportOk.Enabled = False
            CmdOk.Enabled = False
            CmdCancel.Enabled = False

        End If

        Exit Sub

ErrorDeleteTransaction:

        On Error GoTo 0
        Call SetHourGlassDefault()
        Msg = "Error in Deleting Transaction"
        iResponse = MsgBox(Msg, Style, Title)
        Exit Sub

    End Sub

    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click

        CmdReportOk.Visible = True

        GroupBox4.Visible = True

        If cboGroup1.Text = "" Then
            cboGroup1.SelectedIndex = 0
        End If

        If cboGroup2.Text = "" Then
            cboGroup2.SelectedIndex = 0
        End If

        If cboGroup3.Text = "" Then
            cboGroup3.SelectedIndex = 0
        End If

        txtGroup1.Text = cboGroup1.SelectedIndex + 1
        txtGroup2.Text = cboGroup2.SelectedIndex + 1
        txtGroup3.Text = cboGroup3.SelectedIndex + 1

        CmdReportOk.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        Dim nDate As Date = Now
        Dim tDate As Date
        Dim vDate As Date
        Dim dateCheck As Boolean
        Dim Msg As String
        Dim Style As Short
        Dim Title As String = Nothing
        Dim iResponse As Short
        'Dim bOk As Boolean

        miTransfer = False

        tDate = Date.Parse(txtDate.Text)

        dateCheck = IsDate(tDate)
        If Not dateCheck Then
            Msg = " Date error - please rectify"
            Title = "Enter due date"
            MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
            txtDate.Focus()
            Exit Sub
        End If

        If Format$(txtDate.Text, "yyyymmdd") < Format$(gvBalanceDate, "yyyymmdd") And giAutoSO Then
            Msg = " Start date is before current date and  " & Chr(10) & Chr(10)
            Msg = Msg & " SO's will post for this previous period " & Chr(10) & Chr(10)
            Msg = Msg & "                    Proceed?             "
            Title = "Enter SO start date"
            Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
            If iResponse = MsgBoxResult.No Then
                txtDate.Focus()
                Exit Sub
            End If
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

        If Not IsNumeric(txtAmount.Text) Then
            Msg = "Invalid or no amount entered - please rectify"
            Title = "Enter amount"
            MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
            txtAmount.Focus()
            Exit Sub
        End If

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

        'is there a transfer transaction?
        If miTransfer = True Then
            If InStr(cboTransfer.Text, "-") Then
                'Left(String)...doesn't work!
                cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1) 'jpg strip bank & branch
            End If
        End If

        'Validate frequency
        If giAutoSO Then
            If IsNumeric(txtDaily.Text) Then
                If Val(txtDaily.Text) < 0 Then '32bit
                    Msg = "Daily frequency must be greater than 0 - please rectify"
                    Title = "Enter Daily frequency"
                    MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                    txtDaily.Focus()
                    Exit Sub
                End If
            ElseIf IsNumeric(txtMonthly.Text) Then
                If Val(txtMonthly.Text) < 1 Or Val(txtMonthly.Text > 12) Then
                    Msg = "Monthly frequency must be in range of 1 to 12 - please rectify"
                    Title = "Enter Monthly frequency"
                    MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                    txtMonthly.Focus()
                    Exit Sub
                End If
                If Val(txtDayDue.Text) < 1 Or Val(txtMonthly.Text > 31) Then
                    Msg = "Day due must be in range of 1 to 31 - please rectify"
                    Title = "Enter day due"
                    MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                    txtDayDue.Focus()
                    Exit Sub
                End If
            Else    'error
                Msg = "Invalid or no frequency entered - please rectify"
                Title = "Enter frequency"
                MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                txtMonthly.Focus()
                Exit Sub
            End If
            If IsNumeric(txtNumPayments.Text) Then
                If Val(txtNumPayments.Text) < 0 Then
                    Msg = "Number of payments must be positive - please rectify"
                    Title = "Enter number of payments"
                    MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                    txtNumPayments.Focus()
                    Exit Sub
                End If
            Else    'error
                Msg = "Invalid number of payments entered - please rectify"
                Title = "Enter number of payments"
                MsgBox(Msg, MsgBoxStyle.Exclamation, Title)
                txtNumPayments.Focus()
                Exit Sub
            End If
        End If

        'OK. Let's do it
        Call SetHourGlassWait()

        Select Case miUpdate
            Case giADD
                Call PostSOTransaction()
            Case giCHANGE
                Call EditSOTransaction()
            Case Else
        End Select

        '
        'Update screen and DB
        'reload data from DB

        Call RefreshDetails()

        SotransBindingSource.MoveLast()
        DataGridSOTrans.Enabled = True

        txtDate.Tag = txtDate.Text
        gvdTxtDateTag = txtDate.Text
        txtTimeKey.Tag = txtTimeKey.Text
        cboTransfer.Tag = cboTransfer.Text
        cboPayReceipt.Tag = cboPayReceipt.Text
        txtAmount.Tag = txtAmount.Text
        txtEquiv.Tag = txtEquiv.Text
        cboReference.Tag = cboReference.Text
        cboAnalysis.Tag = cboAnalysis.Text
        cboGLcode.Tag = cboGLcode.Text
        cboCustomer.Tag = cboCustomer.Text
        txtDetails.Tag = txtDetails.Text

        If SotransBindingSource.Count > 0 Then
            CmdAdd.Enabled = True
            CmdChange.Enabled = True
            CmdDelete.Enabled = True
            CmdReport.Enabled = True
            CmdReportOk.Visible = False
            CmdOk.Enabled = False
            CmdOk.Visible = True
            CmdCancel.Enabled = False
            'mnuFind.Enabled = True
            'mnuView.Enabled = True
            'mnuQuery.Enabled = True
            'mnuReports.Enabled = True
        Else
            CmdAdd.Enabled = True
            CmdChange.Enabled = False
            CmdDelete.Enabled = False
            CmdReport.Enabled = False
            CmdReportOk.Visible = False
            CmdOk.Enabled = False
            CmdOk.Visible = False
            CmdCancel.Enabled = False
            'mnuFind.Enabled = False
            'mnuView.Enabled = False
            'mnuQuery.Enabled = False
            'mnuReports.Enabled = False
        End If

        'Call DisplayHeader()

        GroupBox2.Text = "Add/Change"
        GroupBox2.Visible = False
        miUpdate = False '??

        Call SetHourGlassDefault()

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click

        Call ClearFields()

        'CmdOk.Visible = False
        CmdReportOk.Visible = False

        GroupBox2.Visible = False
        GroupBox4.Visible = False

        'Call DisplayDetails()

        'turn on grid
        DataGridSOTrans.Enabled = Enabled
        GroupBox2.Text = "Add/Change"
        'GroupBox2.Visible = False

        'Refresh Controls
        If SotransBindingSource.Count > 0 Then
            CmdAdd.Enabled = True
            CmdChange.Enabled = True
            CmdDelete.Enabled = True
            CmdOk.Enabled = False
            CmdCancel.Enabled = False
        Else
            CmdAdd.Enabled = True
            CmdChange.Enabled = False
            CmdDelete.Enabled = False
            CmdOk.Enabled = False
            CmdCancel.Enabled = False
        End If

        'CmdOk.Visible = True
        txtDateFind.Visible = False

    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click

        Me.Close()

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
        txtDaily.Text = ""
        txtMonthly.Text = ""
        txtDayDue.Text = ""
        cboTransfer.Tag = ""
        'cboReference.Tag = ""

        txtDate.Focus()

    End Sub

    Public Sub PostSOTransaction()

        Dim TransferID As Integer = 0
        Dim nCount As Integer = 0
        Dim currentTime As Date
        Dim sSql As String = Nothing
        Dim bOk As Boolean
        Dim Amount As Double

        currentTime = TimeOfDay

        'Process Transfer?
        If miTransfer Then
            miTfrUpdate = giADD
            Call GetTransferID(TransferID)
            TransferID = TransferID + 1
            Call SaveTransferID(Str(TransferID))
        End If

        '
        'create transaction in SOTrans
        '
        sSql = "Insert into sotrans"
        sSql = sSql + " (AccountNo, [Date], TimeKey, Reference, Analysis, Account, GLCode, Details, Customer,"
        sSql = sSql + " Folio, Reconciled, DebitCredit, Amount, VAT, Transfer," 'no Payment/Receipt or TransferID fields in soTrans
        sSql = sSql + " Daily, Monthly, DayDue, NumPayments)"

        sSql = sSql + " Values ("

        sSql = sSql + "  " + qte(gsAccountNo) '(msAccountNo)
        sSql = sSql + ", " + AccessDate(Date.Parse(txtDate.Text)) 'formatted in 'AccessDate'
        sSql = sSql + ", " + AccessTime(currentTime)
        sSql = sSql + ", " + qte(cboReference.Text + " ")
        sSql = sSql + ", " + qte(cboAnalysis.Text + " ")
        sSql = sSql + ", ' '" '+ qte()                          'AccountCode
        sSql = sSql + ", " + qte(cboGLcode.Text + " ")
        sSql = sSql + ", " + qte(txtDetails.Text + " ")
        sSql = sSql + ", " + qte(cboCustomer.Text + " ")
        sSql = sSql + ", ' '" '+ qte()                          'Folio
        sSql = sSql + ", " + qte("N") 'always "N"               'Rec
        sSql = sSql + ", " + qte(cboPayReceipt.Text)
        If cboPayReceipt.Text = "Payment" Then
            Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", " + qte(Amount)                'Payment
            'sSql = sSql + ", ''"                           'Receipt
            sSql = sSql + ", " + qte(Amount) ' * -1)           'Amoumt
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Amount) ' * -1)           'Equiv
        Else
            Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", ''"                           'Payment
            'sSql = sSql + ", " + qte(Amount)                'Receipt
            sSql = sSql + ", " + qte(Amount)                'Amoumt
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", " + qte(Amount)                'Equiv
        End If
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1) 'jpg strip bank & branch
        End If
        sSql = sSql + ", " + qte(cboTransfer.Text + " ")
        'sSql = sSql + ", " + qte(CStr(TransferID))
        If giAutoSO = True Then
            sSql = sSql + ", " + qte(txtDaily.Text)
            sSql = sSql + ", " + qte(txtMonthly.Text)
            sSql = sSql + ", " + qte(txtDayDue.Text)
            sSql = sSql + ", " + qte(txtNumPayments.Text)
        Else 'Manual S/O
            sSql = sSql + ", 0 " '+ qte(txtDaily.Text)
            sSql = sSql + ", 0" '+ qte(txtMonthly.Text)
            sSql = sSql + ", 0" '+ qte(txtDayDue.Text)
            sSql = sSql + ", -1" '+ qte(txtNumPayments.Text)
        End If

        sSql = sSql + ")"

        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

        Exit Sub

RetryAdd:

        'currentTime = TimeOfDay
        'DataGridSOTrans.Rows(nCount).Cells("TimeKey").Value = currentTime 'TimeString
        'Resume

    End Sub

    Public Sub EditSOTransaction()

        Dim TransferID As Integer = 0
        Dim currentTime As Date
        Dim dAmount As Double = 0
        Dim Amount As Double = 0
        Dim DateTimePickerAccessibleObject As Object = 0
        Dim TimekeyCounter As Short = 0
        Dim sSql As String
        Dim bOk As Boolean

        GroupBox2.Text = "Changing Current Transaction"
        GroupBox2.Visible = True
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
                Call SaveTransferID(TransferID)
            Else                                                'Change
                miTfrUpdate = giCHANGE
                'No change to TransferID, so get it from dirpbs
                Call GetTransferID(TransferID)
            End If
        End If

        '
        'Update transaction in soTrans
        '
        sSql = "Update sotrans"
        sSql = sSql + " Set"
        sSql = sSql + "  [Date] = " + AccessDate(txtDate.Text)
        sSql = sSql + " , Timekey = " + AccessTime(currentTime)
        sSql = sSql + " , Reference = " + qte(cboReference.Text + " ")
        sSql = sSql + " , Analysis = " + qte(cboAnalysis.Text + " ")
        'sSql = sSql + " , AccountCode = " + qte()
        sSql = sSql + " , GLcode = " + qte(cboGLcode.Text + " ")
        sSql = sSql + " , Details = " + qte(txtDetails.Text + " ")
        sSql = sSql + " , Customer = " + qte(cboCustomer.Text + " ")
        'sSql = sSql + " , Folio = " 
        If UCase(txtRec.Text) = "Y" Then
            sSql = sSql + ", Reconciled = " + qte(UCase(txtRec.Text + " "))
        Else
            sSql = sSql + ", Reconciled = " + qte("N")
        End If
        sSql = sSql + " , DebitCredit = " + qte(cboPayReceipt.Text)
        If cboPayReceipt.Text = "Payment" Then
            Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", Payment = " + qte(Amount)              'Payment
            'sSql = sSql + ", Receipt = ''"                          'Receipt
            sSql = sSql + ", Amount = " + qte(Amount) ' * -1)        'Amount
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Amount) ' * -1)           'Equiv
        Else
            Amount = CDec(Val(txtAmount.Text))
            'sSql = sSql + ", Payment = ''"                         'Payment
            'sSql = sSql + ", Receipt = " + qte(Amount)             'Receipt
            sSql = sSql + ", Amount = " + qte(Amount)               'Amount
            Amount = CDec(Val(txtEquiv.Text))
            sSql = sSql + ", VAT = " + qte(Amount)                  'Equiv
        End If
        If InStr(cboTransfer.Text, "-") Then
            cboTransfer.Text = Mid(cboTransfer.Text, 1, InStr(cboTransfer.Text, "-") - 1) 'jpg strip bank & branch
        End If
        sSql = sSql + " , Transfer = " + qte(cboTransfer.Text)
        'sSql = sSql + " , TransferID = " + qte(CStr(TransferID))
        If giAutoSO = True Then
            sSql = sSql + " , Daily = " + qte(txtDaily.Text)
            sSql = sSql + " , Monthly = " + qte(txtMonthly.Text)
            sSql = sSql + " , DayDue = " + qte(txtDayDue.Text)
            sSql = sSql + " , NumPayments = " + qte(txtNumPayments.Text)
        Else
            sSql = sSql + " , Daily = 0 " '+ qte(txtDaily.Text)
            sSql = sSql + " , Monthly = 0" '+ qte(txtMonthly.Text)
            sSql = sSql + " , DayDue = 0" '+ qte(txtDayDue.Text)
            sSql = sSql + " , NumPayments = -1" '+ qte(txtNumPayments.Text)
        End If
        sSql = sSql + " Where Date = " + AccessDate(gvdTxtDateTag)      'Previous Date to Edit
        sSql = sSql + " And Timekey = " + AccessTime(txtTimeKey.Tag)    'Previous Time to Edit
        sSql = sSql + " And AccountNo = " + qte(gsAccountNo)
        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

        Exit Sub

EditRetry:

        'DataGridSOTrans.SelectedCells(TimekeyCounter).Value = txtTimeKey.Text '- just to avoid duplicate date/time
        Resume

    End Sub

    Private Sub CmdReportOk_Click(sender As Object, e As EventArgs) Handles CmdReportOk.Click

        Dim sSql As String
        Dim Msg As String
        Dim Title As String
        Dim sFields As String
        Dim stxtGroup As String = "0"
        Dim X As Integer
        Dim HeaderIndex As Integer = 0
        'Dim nRetryCount As Integer

        Call SetHourGlassWait()

        'On Error GoTo Cmd3DOK_Click_Error

        'refresh txtGroupx - added 31/10/2015
        txtGroup1.Text = cboGroup1.SelectedIndex + 1
        txtGroup2.Text = cboGroup2.SelectedIndex + 1
        txtGroup3.Text = cboGroup3.SelectedIndex + 1

        If txtGroup1.Text <> "txtGroup" Then

            sFields = "dirpbs.BudgetNo, sotrans.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
            sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
            sFields = sFields & ", sotrans.Date, sotrans.TimeKey"
            sFields = sFields & ", sotrans.Amount, sotrans.VAT, sotrans.DebitCredit, sotrans.Transfer"
            sFields = sFields & ", soTrans.Daily, soTrans.Monthly, soTrans.NumPayments, soTrans.DayDue"
            sFields = sFields & ", Customers.Name as CustDesc"
            sFields = sFields & ", Analysis.Description as AnlysDesc"
            sFields = sFields & ", Account.Description as AccDesc"
            sFields = sFields & ", GLcode.Description as GLDesc"

            For X = 1 To 3

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
                End Select

                'fix to allow for deleted CustomerCode item from onscreen cbo selection
                'as CustomerCode included in Rpt format Heading formula
                If HeaderIndex > 2 Then HeaderIndex = HeaderIndex + 1

                sFields = sFields & ", " & CStr(HeaderIndex) & " as txtGroup" & CStr(X)

                Select Case stxtGroup
                    Case "1"
                        sFields = sFields & ", sotrans.Customer as Group" & CStr(X)
                    Case "2"
                        sFields = sFields & ", sotrans.Analysis as Group" & CStr(X)
                        'Case "3"
                        'sFields = sFields & ", sotrans.Account as Group" & CStr(X)
                    Case "3"
                        sFields = sFields & ", sotrans.GLcode as Group" & CStr(X)
                    Case "4"
                        sFields = sFields & ", sotrans.Reference as Group" & CStr(X)
                    Case "5"
                        sFields = sFields & ", sotrans.Details as Group" & CStr(X)
                    Case "6"
                        sFields = sFields & ", sotrans.Transfer as Group" & CStr(X)
                        'Case "8"
                        '   sFields = sFields & ", sotrans.Reconciled as Group" & CStr(X)
                    Case Else
                        sFields = sFields & ", '' as Group" & CStr(X)
                End Select

            Next X

            Call DropTable("SOTransTemp")

            sSql = "SELECT " & sFields & " INTO SOTransTemp"
            sSql = sSql & " FROM dirpbs, sotrans, Customers, Analysis, Account, GLcode,"
            sSql = sSql & " sotrans LEFT JOIN dirpbs"
            sSql = sSql & " ON sotrans.AccountNo = dirpbs.AccountNo,"
            sSql = sSql & " sotrans LEFT JOIN Customers"
            sSql = sSql & " ON sotrans.Customer = Customers.ShortName,"
            sSql = sSql & " sotrans LEFT JOIN Analysis"
            sSql = sSql & " ON sotrans.Analysis = Analysis.Code,"
            sSql = sSql & " sotrans LEFT JOIN Account"
            sSql = sSql & " ON sotrans.Account = Account.Code,"
            sSql = sSql & " sotrans LEFT JOIN GLcode"
            sSql = sSql & " ON sotrans.GLcode = GLcode.Code"
            sSql = sSql & " WHERE sotrans.AccountNo = " & qte(gsAccountNo)
            sSql = sSql & " ORDER BY Date, Timekey"

            'Debug.Print sSql

            If DoSql(sSql, True) Then

                'AxCrystalReport1.DataFiles(0) = gsDBFileName

                If gsDBName = "Live" Then
                    'AxCrystalReport1.DataSource = gsDBLiveFileName
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsSOa.rpt"
                ElseIf gsDBName = "Archive" Then
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsSOb.rpt"
                Else 'test
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsSOa.rpt" 'use live for now!
                End If

                AxCrystalReport1.ReportSource = 0            'use rpt format
                AxCrystalReport1.Destination = 0             'Screen

                'Call SetPrinterOrient(PORTRAIT)            'TODO!

                'On Error GoTo Retry
                AxCrystalReport1.Action = 1                  'Do it
                'On Error GoTo 0

                'Call ReSetPrinterOrient()                  'TODO!

            Else
                Msg = " No records selected"
                Title = "Standing Orders"
                'MsgBox(Msg, vbExclamation, Title)
            End If
        End If

        Call SetHourGlassDefault()

        Exit Sub

Retry:

        'nRetryCount = nRetryCount + 1
        'If nRetryCount < 3 Then
        'DoEvents()
        'Resume
        'Else
        'Call ErrorMessage("Print Report", Err, Error$, "")
        'On Error GoTo 0
        'End If

        Exit Sub

    End Sub

    Private Sub CboGroupsFill()

        cboGroup1.Items.Clear()
        cboGroup1.Items.Add("Customer")
        cboGroup1.Items.Add("Analysis code")
        cboGroup1.Items.Add("GL code")
        cboGroup1.Items.Add("Reference")
        cboGroup1.Items.Add("Details")
        cboGroup1.Items.Add("Transfer")

        cboGroup2.Items.Clear()
        cboGroup2.Items.Add("Customer")
        cboGroup2.Items.Add("Analysis code")
        cboGroup2.Items.Add("GL code")
        cboGroup2.Items.Add("Reference")
        cboGroup2.Items.Add("Details")
        cboGroup2.Items.Add("Transfer")

        cboGroup3.Items.Clear()
        cboGroup3.Items.Add("Customer")
        cboGroup3.Items.Add("Analysis code")
        cboGroup3.Items.Add("GL code")
        cboGroup3.Items.Add("Reference")
        cboGroup3.Items.Add("Details")
        cboGroup3.Items.Add("Transfer")

        'set defaults
        cboGroup1.SelectedIndex = 3   'Reference
        cboGroup2.SelectedIndex = 0   'Customer
        cboGroup3.SelectedIndex = 4   'Details
        'cboAccountNo = gsAccountNo

    End Sub

    Private Sub CboTransferFill()

        Dim AccountNo As String = Nothing
        Dim BankName As String = Nothing
        Dim BankBranch As String = Nothing
        Dim nCount As Integer = 0
        Dim nCounter As Integer = 0

        DirpbsBindingSource.Filter = "Username = '" + gsUserName + "'"
        DirpbsBindingSource.Sort = "Currency, AccountNo"

        DirpbsBindingSource.MoveFirst()
        nCount = DirpbsBindingSource.Count

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

    Private Sub txtDaily_TextChanged(sender As Object, e As EventArgs) Handles txtDaily.TextChanged

    End Sub
End Class