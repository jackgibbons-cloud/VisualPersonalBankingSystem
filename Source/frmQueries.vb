'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2017
'
'Queries, incorporating Report
'
'Purpose:  Displays single or multiple Queries
'          by currently selected account or budget group of accounts
'          uses Crystal Reports PbsQryA.rpt, PbsQryB.rpt (Live DB), PbsQryBA.rpt, PbsQryBB.rpt (Archive DB).
'
'****************************************************************************************************************************
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'17/12/15   jpg     Created from Vpbs78
'                   Added datasources, Crystal Report
'22/12/15           Completed
'17/01/16   jpg     Added Archive dataset...
'22/04/16   jpg     Added additional dataset for Live DB (VpbsDataSet1) for Budget data (DataGridQueriesB)
'                   to read table TransQueryB. Modified RefreshDetails.
'18/01/17   jpg     Added additional dataset for Archive DB (VpbsArchiveDataSet3) for Budget data (DataGridQueriesB)
'                   to read table TransQueryB. Modified RefreshDetails.
'                   Modified VpbsArchiveConnectionString in Vpbs:Settings to point to c:vpbs 
'20/01/17   jpg     Modified RefreshDetails.
'20/01/17   jpg     Recreated PbsQryB.rpt from PbsQryA.rpt, but modified to read from Archive DB - Ok
'20/01/17   jpg     Recreated PbsQryBB.rpt from PbsQryB.rpt, but modified to read from Archive DB - Ok
'20/01/17   jpg     Modified DataGridQueriesB columns
'01/01/19   jpg     Getselections : added 'AND' to precede Amount clause
'****************************************************************************************************************************

Public Class frmQueries

    Dim msSelection As String
    Dim miAdd As Integer

    Private Sub frmQueries_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'VpbsDataSet.TransQueryA' table. You can move, or remove it, as needed.
        'Me.TransQueryATableAdapterLive.Fill(Me.VpbsDataSet.TransQueryA) 'Used for rpt

        'TODO: This line of code loads data into the 'VpbsArchiveDataSet.TransQueryA' table. You can move, or remove it, as needed.
        'Me.TransQueryATableAdapterArc.Fill(Me.VpbsArchiveDataSet.TransQueryA) 'Used for rpt

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            Me.PbstransTableAdapterLive.Fill(Me.VpbsDataSet.pbstrans)
            Me.AnalysisTableAdapterLive.Fill(Me.VpbsDataSet.Analysis)
            Me.GLCodeTableAdapterLive.Fill(Me.VpbsDataSet.GLCode)
            Me.CustomersTableAdapterLive.Fill(Me.VpbsDataSet.Customers)
            PbstransBindingSource.DataSource = VpbsDataSet
            AnalysisBindingSource.DataSource = VpbsDataSet
            GLCodeBindingSource.DataSource = VpbsDataSet
            CustomersBindingSource.DataSource = VpbsDataSet

            'Moved to RefreshDetails()
            'Me.TransQueryBTableAdapterLive.Fill(Me.VPBSDataSet1.TransQueryB)
            'DataGridQueriesB.DataSource = TransQueryBBindingSourceLive 'added 18/01/2017

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            Me.AnalysisTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Analysis)
            Me.GLCodeTableAdapterArc.Fill(Me.VpbsArchiveDataSet.GLCode)
            Me.CustomersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Customers)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet
            AnalysisBindingSource.DataSource = VpbsArchiveDataSet
            GLCodeBindingSource.DataSource = VpbsArchiveDataSet
            CustomersBindingSource.DataSource = VpbsArchiveDataSet

            'Moved to RefreshDetails()
            'Me.TransQueryBTableAdapterArc.Fill(Me.VpbsArchiveDataSet3.TransQueryB)
            'DataGridQueriesB.DataSource = TransQueryBBindingSourceArc 'added 18/01/2017

        Else

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            Me.AnalysisTableAdapterTest.Fill(Me.VpbsTestDataSet.Analysis)
            Me.GLCodeTableAdapterTest.Fill(Me.VpbsTestDataSet.GLCode)
            Me.CustomersTableAdapterTest.Fill(Me.VpbsTestDataSet.Customers)
            PbstransBindingSource.DataSource = VpbsTestDataSet
            AnalysisBindingSource.DataSource = VpbsTestDataSet
            GLCodeBindingSource.DataSource = VpbsTestDataSet
            CustomersBindingSource.DataSource = VpbsTestDataSet

        End If

        'PbstransBindingSource.Filter = "" 'None selected"
        DataGridQueries.TopLeftHeaderCell.Value = gsDBName '"------"

        Select Case gsQueryType
            Case "Da"
                TabControl1.SelectTab(0)
                'For X = 0 To 7
                'If X = 0 Then
                '       TabControl1. = True
                'Else
                'TabControl1.TabEnabled(X) = False
                'End If
                'Next X
            Case "Re"
                TabControl1.SelectTab(1)
                'For X = 0 To 7
                'If X = 1 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "Cu"
                TabControl1.SelectTab(2)
                'For X = 0 To 7
                'If X = 2 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "An"
                TabControl1.SelectTab(3)
                'For X = 0 To 7
                'If X = 3 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "Gl"
                TabControl1.SelectTab(4)
                'For X = 0 To 7
                'If X = 4 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "Am"
                TabControl1.SelectTab(5)
                'For X = 0 To 7
                'If X = 5 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "RG"
                TabControl1.SelectTab(6)
                'For X = 0 To 7
                ' If X = 6 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "RD"
                TabControl1.SelectTab(7)
                'For X = 0 To 7
                'If X = 7 Then
                'VSIndexTab1.TabEnabled(X) = True
                'Else
                'VSIndexTab1.TabEnabled(X) = False
                'End If
                'Next X
            Case "M"                                    'Multiple selection
                'VSIndexTab1.Tab = 0
                'For X = 0 To 7
                'VSIndexTab1.TabEnabled(X) = True
                'Next X

        End Select

        Call CboGroupsFill()
        DisplayHeader()

    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        Dim sSql As String = Nothing
        Dim sFields As String = Nothing
        Dim nSumAmount As Double = 0
        Dim nSumVAT As Double = 0
        Dim nCount As Integer = 0

        On Error GoTo Error_cmdOk_Click

        msSelection = GetSelections()
        lblAccountHeader.Text = lblAccountHeader.Tag + " " + msSelection

        Call DeleteTotals()

        If msSelection <> "" Then

            Call SetHourGlassWait()

            If rdoOptSelect0.Checked Then

                'get totals
                sSql = "SELECT SUM(Amount) AS SumAmount"
                sSql = sSql & ", SUM(Vat) AS SumVat"
                sSql = sSql & " FROM pbsTrans"
                sSql = sSql & " WHERE AccountNo = " & qte(gsAccountNo)
                sSql = sSql & " AND " & msSelection

                Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
                Dim ds As New DataTable
                adapter.Fill(ds)

                Call SetHourGlassWait()

                If ds.Rows.Count > 0 Then

                    nCount = 0

                    Do While nCount <= ds.Rows.Count - 1

                        nSumAmount = IIf(IsDBNull(ds.Rows.Item(nCount)("SumAmount")), 0, ds.Rows.Item(nCount)("SumAmount"))
                        nSumVAT = IIf(IsDBNull(ds.Rows.Item(nCount)("SumVAT")), 0, ds.Rows.Item(nCount)("SumVAT"))

                        nCount = nCount + 1
                    Loop

                End If

                ds.Dispose()

                'write totals
                sSql = " INSERT INTO pbsTrans"
                sSql = sSql & " ([Date], Timekey, AccountNo, Reference, Amount, Vat)"
                sSql = sSql & " VALUES (" & AccessDate(Now)
                sSql = sSql & ", " & AccessTime(TimeOfDay)
                sSql = sSql & ", '999999'"
                sSql = sSql & ", 'Totals:'"
                sSql = sSql & ", " & CStr(IIf(IsDBNull(nSumAmount), 0, nSumAmount))
                sSql = sSql & ", " & CStr(IIf(IsDBNull(nSumVAT), 0, nSumVAT))
                sSql = sSql & ")"

                If DoSql(sSql, 1) Then
                End If

                'now get the records - modified for PbstransBindingSource.Filter)               
                sSql = " AccountNo = '999999' "
                sSql = sSql & " OR (AccountNo = " & qte(gsAccountNo)
                sSql = sSql & " AND " & msSelection + ")"

                Call RefreshDetails()

                DataGridQueries.DataSource = PbstransBindingSource
                PbstransBindingSource.Filter = sSql

            Else
                'get totals
                sSql = " SELECT SUM(P.Amount) AS SumAmount"
                sSql = sSql & ", SUM(P.Vat) AS SumVat"
                sSql = sSql & " FROM pbsTrans P, dirpbs D"
                sSql = sSql & " WHERE D.BudgetNo = " & qte(gsBudgetNo)
                sSql = sSql & " AND P.AccountNo = D.AccountNo"
                sSql = sSql & " AND " & msSelection

                Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
                Dim ds As New DataTable
                adapter.Fill(ds)

                Call SetHourGlassWait()

                If ds.Rows.Count > 0 Then

                    nCount = 0

                    Do While nCount <= ds.Rows.Count - 1

                        nSumAmount = IIf(IsDBNull(ds.Rows.Item(nCount)("SumAmount")), 0, ds.Rows.Item(nCount)("SumAmount"))
                        nSumVAT = IIf(IsDBNull(ds.Rows.Item(nCount)("SumVAT")), 0, ds.Rows.Item(nCount)("SumVAT"))

                        nCount = nCount + 1
                    Loop

                End If

                ds.Dispose()

                'write totals
                sSql = " INSERT INTO pbsTrans"
                sSql = sSql & " ([Date], Timekey, AccountNo, Reference, Amount, Vat)"
                sSql = sSql & " VALUES (" & AccessDate(Now)
                sSql = sSql & ", " & AccessTime(TimeOfDay)
                sSql = sSql & ", '999999'"
                sSql = sSql & ", 'Totals:'"
                sSql = sSql & ", " & CStr(IIf(IsDBNull(nSumAmount), 0, nSumAmount))
                sSql = sSql & ", " & CStr(IIf(IsDBNull(nSumVAT), 0, nSumVAT))
                sSql = sSql & ")"

                If DoSql(sSql, 1) Then
                End If

                Call DropTable("TransQueryB")

                'write selected records to temp file TransQueryB
                sFields = "Date, Reference, Customer"
                sFields = sFields & ", Analysis, Account, GlCode"
                sFields = sFields & ", Folio, Reconciled, VAT"
                sFields = sFields & ", Amount, Balance, Details"
                sFields = sFields & ", DebitCredit, TimeKey, AccountNo"
                sFields = sFields & ", Transfer, TransferID"
                sFields = sFields & ", Payment, Receipt"
                sSql = " SELECT " & sFields & " INTO TransQueryB"
                sSql = sSql & " FROM pbstrans"
                sSql = sSql & " Where  AccountNo = '999999'"
                sSql = sSql & " or (" + msSelection + " And AccountNo In"
                sSql = sSql & " (Select AccountNo From dirpbs"
                sSql = sSql & " Where dirpbs.BudgetNo = " & qte(gsBudgetNo) + "))"

                If DoSql(sSql, 1) Then
                End If

                'now get the records - modified for TransQueryBBindingSource

                Call RefreshDetails()

                'DataGridQueriesB.DataSource = TransQueryBBindingSourceLive 'Removed as already in RefreshDetails() 18/01/17

            End If

            Call SetHourGlassDefault()
        Else
            MsgBox(" No records selected", vbExclamation, "Queries")
        End If

        Exit Sub

Error_cmdOk_Click:

        On Error GoTo 0
        Call DeleteTotals()
        Call SetHourGlassDefault()

        Exit Sub

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            bOk = PbstransTableAdapterLive.ClearBeforeFill
            Me.PbstransTableAdapterLive.Fill(Me.VpbsDataSet.pbstrans)
            PbstransBindingSource.DataSource = VpbsDataSet.pbstrans
            'added 22/04/16
            'On Error Resume Next
            bOk = TransQueryATableAdapterLive.ClearBeforeFill
            Me.TransQueryATableAdapterLive.Fill(Me.VpbsDataSet.TransQueryA) 'Used for rpt
            bOk = TransQueryBTableAdapterLive.ClearBeforeFill
            Me.TransQueryBTableAdapterLive.Fill(Me.VPBSDataSet1.TransQueryB)
            TransQueryBBindingSourceLive.DataSource = VPBSDataSet1.TransQueryB
            DataGridQueriesB.DataSource = TransQueryBBindingSourceLive 'added 20/01/2017
            'On Error GoTo 0
        ElseIf gsDBName = "Archive" Then
            bOk = PbstransTableAdapterArc.ClearBeforeFill
            Me.PbstransTableAdapterArc.Fill(Me.VpbsArchiveDataSet.pbstrans)
            PbstransBindingSource.DataSource = VpbsArchiveDataSet.pbstrans
            'On Error Resume Next
            bOk = TransQueryATableAdapterArc.ClearBeforeFill
            Me.TransQueryATableAdapterArc.Fill(Me.VpbsArchiveDataSet.TransQueryA) 'Used for rpt
            bOk = TransQueryBTableAdapterArc.ClearBeforeFill
            Me.TransQueryBTableAdapterArc.Fill(Me.VpbsArchiveDataSet3.TransQueryB)
            TransQueryBBindingSourceArc.DataSource = VpbsArchiveDataSet3.TransQueryB
            DataGridQueriesB.DataSource = TransQueryBBindingSourceArc 'added 20/01/2017
            'On Error GoTo 0
        ElseIf gsDBName = "Test" Then
            bOk = PbstransTableAdapterTest.ClearBeforeFill
            Me.PbstransTableAdapterTest.Fill(Me.VpbsTestDataSet.pbstrans)
            PbstransBindingSource.DataSource = VpbsTestDataSet.pbstrans
            'On Error Resume Next
            bOk = TransQueryATableAdapterTest.ClearBeforeFill
            Me.TransQueryATableAdapterTest.Fill(Me.VpbsTestDataSet.TransQueryA) 'Used for rpt
            bOk = TransQueryBTableAdapterTest.ClearBeforeFill
            Me.TransQueryBTableAdapterTest.Fill(Me.VpbsTestDataSet.TransQueryB)
            TransQueryBBindingSourceLive.DataSource = VpbsTestDataSet.TransQueryB
            DataGridQueriesB.DataSource = TransQueryBBindingSourceLive 'added 20/01/2017
            'On Error GoTo 0
        End If

    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click

        Me.Close()

    End Sub

    Private Function GetSelections() As String

        Dim sSql As String
        Dim sOperator As String
        Dim Msg As String
        Dim Title As String

        sSql = ""

        If DateTimePicker0.Text <> "__/__/____" And (rdoDate0.Checked Or rdoDate1.Checked Or rdoDate2.Checked) Then
            If Not IsDate(DateTimePicker0.Text) Then
                Msg = " Date error - please rectify"
                Title = "Enter transaction date"
                MsgBox(Msg, vbExclamation, Title)
                DateTimePicker0.Focus()
                GetSelections = False
                Exit Function
            Else
                If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Date "
                If rdoDate0.Checked Then
                    sOperator = " > "
                ElseIf rdoDate1.Checked Then
                    sOperator = " >= "
                Else
                    sOperator = " = "
                End If
                sSql = sSql & sOperator & AccessDate(DateTimePicker0.Text)
            End If
        End If

        If DateTimePicker1.Text <> "__/__/____" And (rdoDate3.Checked Or rdoDate4.Checked Or rdoDate5.Checked) Then
            If Not IsDate(DateTimePicker1.Text) Then
                Msg = " Date error - please rectify"
                Title = "Enter transaction date"
                MsgBox(Msg, vbExclamation, Title)
                DateTimePicker1.Focus()
                GetSelections = False
                Exit Function
            Else
                If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Date "
                If rdoDate3.Checked Then
                    sOperator = " < "
                ElseIf rdoDate4.Checked Then
                    sOperator = " <= "
                Else
                    sOperator = " <> "
                End If
                sSql = sSql & sOperator & AccessDate(DateTimePicker1.Text)
            End If
        End If

        If Trim(txtRef0.Text) <> "" And (rdoRef0.Checked Or rdoRef1.Checked Or rdoRef2.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Reference "
            If rdoRef0.Checked Then
                sOperator = " > "
            ElseIf rdoRef1.Checked Then
                sOperator = " >= "
            Else
                sOperator = " = "
            End If
            sSql = sSql & sOperator & qte(txtRef0.Text)
        End If

        If Trim(txtRef1.Text) <> "" And (rdoRef3.Checked Or rdoRef4.Checked Or rdoRef5.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Reference "
            If rdoRef3.Checked Then
                sOperator = " < "
            ElseIf rdoRef4.Checked Then
                sOperator = " <= "
            Else
                sOperator = " <> "
            End If
            sSql = sSql & sOperator & qte(txtRef1.Text)
        End If

        If Trim(cboCust0.Text) <> "" And (rdoCust0.Checked Or rdoCust1.Checked Or rdoCust2.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Customer "
            If rdoCust0.Checked Then
                sOperator = " > "
            ElseIf rdoCust1.Checked Then
                sOperator = " >= "
            Else
                sOperator = " = "
            End If
            sSql = sSql & sOperator & qte(cboCust0.Text)
        End If

        If Trim(cboCust1.Text) <> "" And (rdoCust3.Checked Or rdoCust4.Checked Or rdoCust5.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Customer "
            If rdoCust3.Checked Then
                sOperator = " < "
            ElseIf rdoCust4.Checked Then
                sOperator = " <= "
            Else
                sOperator = " <> "
            End If
            sSql = sSql & sOperator & qte(cboCust1.Text)
        End If

        If Trim(cboAnalysis0.Text) <> "" And (rdoAnal0.Checked Or rdoAnal1.Checked Or rdoAnal2.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Analysis "
            If rdoAnal0.Checked Then
                sOperator = " > "
            ElseIf rdoAnal1.Checked Then
                sOperator = " >= "
            Else
                sOperator = " = "
            End If
            sSql = sSql & sOperator & qte(cboAnalysis0.Text)
        End If

        If Trim(cboAnalysis1.Text) <> "" And (rdoAnal3.Checked Or rdoAnal4.Checked Or rdoAnal4.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " Analysis "
            If rdoAnal3.Checked Then
                sOperator = " < "
            ElseIf rdoAnal4.Checked Then
                sOperator = " <= "
            Else
                sOperator = " <> "
            End If
            sSql = sSql & sOperator & qte(cboAnalysis1.Text)
        End If

        If Trim(cboGLCode0.Text) <> "" And (rdoGL0.Checked Or rdoGL1.Checked Or rdoGL2.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " GLCode "
            If rdoGL0.Checked Then
                sOperator = " > "
            ElseIf rdoGL1.Checked Then
                sOperator = " >= "
            Else
                sOperator = " = "
            End If
            sSql = sSql & sOperator & qte(cboGLCode0.Text)
        End If

        If Trim(cboGLCode1.Text) <> "" And (rdoGL3.Checked Or rdoGL4.Checked Or rdoGL5.Checked) Then
            If sSql <> "" Then sSql = sSql & " AND "
            sSql = sSql & " GLCode "
            If rdoGL3.Checked Then
                sOperator = " < "
            ElseIf rdoGL4.Checked Then
                sOperator = " <= "
            Else
                sOperator = " <> "
            End If
            sSql = sSql & sOperator & qte(cboGLCode1.Text)
        End If

        If Trim(txtAmount0.Text) <> "" And (rdoAmt0.Checked Or rdoAmt1.Checked Or rdoAmt2.Checked) Then
            If Not IsNumeric(txtAmount0.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtAmount0.Focus()
                GetSelections = False
                Exit Function
            Else
                If sSql <> "" Then sSql = sSql & " AND " 'added 01/01/19
                sSql = sSql & " Amount "
                If rdoAmt0.Checked Then
                    sOperator = " > "
                ElseIf rdoAmt1.Checked Then
                    sOperator = " >= "
                Else
                    sOperator = " = "
                End If
                sSql = sSql & sOperator & CStr(txtAmount0.Text)
            End If
        End If

        If Trim(txtAmount1.Text) <> "" And (rdoAmt3.Checked Or rdoAmt4.Checked Or rdoAmt5.Checked) Then
            If Not IsNumeric(txtAmount1.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtAmount1.Focus()
                GetSelections = False
                Exit Function
            Else
                If sSql <> "" Then sSql = sSql & " AND "
                sSql = sSql & " Amount "
                If rdoAmt3.Checked Then
                    sOperator = " < "
                ElseIf rdoAmt4.Checked Then
                    sOperator = " <= "
                Else
                    sOperator = " <> "
                End If
                sSql = sSql & sOperator & CStr(txtAmount1.Text)
            End If
        End If

        GetSelections = sSql

    End Function

    Private Sub DeleteTotals()

        Dim sSql As String

        sSql = "DELETE * FROM pbsTrans WHERE AccountNo = '999999'"
        If DoSql(sSql, 1) Then
        End If

        sSql = "DELETE * FROM dirpbs WHERE AccountNo = '999999'"
        If DoSql(sSql, 1) Then
        End If

    End Sub

    Private Sub CboGroupsFill()

        cboReportGroup0.Items.Clear()
        cboReportGroup0.Items.Add("None")
        cboReportGroup0.Items.Add("Customer")
        cboReportGroup0.Items.Add("Analysis code")
        cboReportGroup0.Items.Add("GL code")

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

        cboGroup4.Items.Clear()
        cboGroup4.Items.Add("Customer")
        cboGroup4.Items.Add("Analysis code")
        cboGroup4.Items.Add("GL code")
        cboGroup4.Items.Add("Reference")
        cboGroup4.Items.Add("Details")
        cboGroup4.Items.Add("Transfer")

        'set defaults
        cboReportGroup0.SelectedIndex = 2   'Group by Analysis
        cboGroup1.SelectedIndex = 3     'Reference
        cboGroup2.SelectedIndex = 0     'Customer
        cboGroup3.SelectedIndex = 4     'Details
        cboGroup4.SelectedIndex = 1     'Analysis

    End Sub

    Private Sub CmdReport_Click(sender As Object, e As EventArgs) Handles CmdReport.Click

        TabControl1.SelectTab(6)

        If cboReportGroup0.Text = "" Then cboReportGroup0.SelectedIndex = 0
        If cboGroup1.Text = "" Then cboGroup1.SelectedIndex = 0
        If cboGroup2.Text = "" Then cboGroup2.SelectedIndex = 0
        If cboGroup3.Text = "" Then cboGroup3.SelectedIndex = 0
        If cboGroup4.Text = "" Then cboGroup4.SelectedIndex = 0

        txtReportGroup0.Text = cboReportGroup0.SelectedIndex
        txtGroup1.Text = cboGroup1.SelectedIndex + 1
        txtGroup2.Text = cboGroup2.SelectedIndex + 1
        txtGroup3.Text = cboGroup3.SelectedIndex + 1
        txtGroup4.Text = cboGroup4.SelectedIndex + 1

        cmdOkRpt.Visible = True

    End Sub

    Private Sub cmdOkRpt_Click(sender As Object, e As EventArgs) Handles cmdOkRpt.Click

        Dim sSql As String
        Dim sFields As String
        Dim stxtGroup As String = Nothing
        Dim HeaderIndex As Integer = 0
        Dim X As Integer

        If gsReportDir = "" Then Exit Sub

        msSelection = GetSelections()
        If msSelection = "" Then Exit Sub

        Call SetHourGlassWait()

        'On Error GoTo CmdReport_Click_Error

        Call DeleteTotals()

        If msSelection <> "" And cboGroup2.Text <> "txtGroup" Then

            Call DropTable("TransQueryA")

            sFields = "dirpbs.BudgetNo, pbstrans.AccountNo, dirpbs.AccountName, dirpbs.AccountDesc"
            sFields = sFields & ", dirpbs.BankName, dirpbs.BankBranch, dirpbs.BankCode, dirpbs.Currency, dirpbs.odLimit"
            sFields = sFields & ", pbstrans.Date, pbstrans.TimeKey"
            sFields = sFields & ", pbstrans.Amount, pbstrans.VAT, pbstrans.DebitCredit"
            sFields = sFields & ", Customers.Name as CustDesc"
            sFields = sFields & ", Analysis.Description as AnlysDesc"
            sFields = sFields & ", Account.Description as AccDesc"
            sFields = sFields & ", GLcode.Description as GLDesc"

            For X = 0 To 4

                Select Case X

                    Case 0
                        HeaderIndex = Val(txtReportGroup0.Text)
                        stxtGroup = txtReportGroup0.Text
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
                If HeaderIndex > 2 Then HeaderIndex = HeaderIndex + 1
                sFields = sFields & ", " & CStr(HeaderIndex) & " as txtGroup" & CStr(X)

                Select Case stxtGroup

                    Case "1"
                        sFields = sFields & ", pbstrans.Customer as Group" & CStr(X)
                    Case "2"
                        sFields = sFields & ", pbstrans.Analysis as Group" & CStr(X)
                        'Case "3"
                        'sFields = sFields & ", pbstrans.Account as Group" & CStr(X)
                    Case "3"
                        sFields = sFields & ", pbstrans.GLcode as Group" & CStr(X)
                    Case "4"
                        sFields = sFields & ", pbstrans.Reference as Group" & CStr(X)
                    Case "5"
                        sFields = sFields & ", pbstrans.Details as Group" & CStr(X)
                    Case "6"
                        sFields = sFields & ", pbstrans.Folio as Group" & CStr(X)
                    Case "7"
                        sFields = sFields & ", pbstrans.Reconciled as Group" & CStr(X)
                    Case "8"
                        sFields = sFields & ", pbstrans.AccountNo as Group" & CStr(X)
                    Case Else
                        sFields = sFields & ", '' as Group" & CStr(X)
                End Select

            Next X

            sSql = "SELECT " & sFields & " INTO TransQueryA"
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

            If rdoOptSelect0.Checked Then           'Account level
                sSql = sSql & " WHERE pbstrans.AccountNo = " & qte(gsAccountNo)
                sSql = sSql & " AND " & msSelection
                If gsDBName = "Live" Then
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsQryA.rpt"
                Else 'Archive
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsQryB.rpt"
                End If
            Else                                    'Budget level
                sSql = sSql & " WHERE dirpbs.BudgetNo = " & qte(gsBudgetNo)
                sSql = sSql & " AND " & msSelection
                If gsDBName = "Live" Then
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsQryBA.rpt"
                Else 'Archive
                    AxCrystalReport1.ReportFileName = gsReportDir & "\pbsQryBB.rpt"
                End If
            End If

            If DoSql(sSql, 1) Then
                'Debug.Print sSql
                'Report1.DataFiles(0) = gsDBFileName
                AxCrystalReport1.ReportSource = 0      'use rpt format
                AxCrystalReport1.Destination = 0          'Screen
                'Call SetPrinterOrient(PORTRAIT)
                AxCrystalReport1.Action = 1                  'Do it
                'Call ReSetPrinterOrient()
            End If
        Else
            MsgBox(" No records selected", vbExclamation, "Queries")
        End If

        Call SetHourGlassDefault()

        Exit Sub

CmdReport_Click_Error:

        Call MsgBox("Print Report - " + sSql, vbExclamation, "Queries")
        On Error GoTo 0

        Call SetHourGlassDefault()

        Exit Sub

    End Sub

    Private Sub DisplayHeader()

        lblAccountHeader.Text = "A/C: " & gsAccountName + " " + gsAccountDesc + " " + gsAccountNo ' + " with " + gsBankName + " " + gsBankBranch '+ " " + CStr(sBalance) + " " + CStr(sBalanceDate)
        'gvBalanceDate = sBalanceDate
        lblAccountHeader.Tag = lblAccountHeader.Text

    End Sub

    Private Sub rdoOptSelect0_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOptSelect0.CheckedChanged

        If rdoOptSelect0.Checked = True Then
            lblAccountHeader.Text = lblAccountHeader.Tag
            DataGridQueries.Visible = True
            DataGridQueriesB.Visible = False
        Else
            lblAccountHeader.Text = "Budget Group for Account: " & gsBudgetNo
            DataGridQueries.Visible = False
            DataGridQueriesB.Visible = True
        End If

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click

        cmdOkRpt.Visible = False

    End Sub

    Private Sub CmdFilter_Click(sender As Object, e As EventArgs) Handles CmdFilter.Click

    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

    End Sub

End Class