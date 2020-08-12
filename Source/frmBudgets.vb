'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2017
'
'Budget Maintenance, Actual v Budget,incorporating DirBud Selection. Report
'****************************************************************************************************************************
'
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'31/10/15   jpg     Created from Vpbs78
'                   Added datasources, datagrid
'05/11/15   jpg     Completed
'29/11/15   jpg     Added Actual v Budget and report
'05/12/15   jpg     Had to re-Verify Database in Crystal Reports
'                   Completed.
'17/01/16   jpg     Added Archive dataset...
'16/04/16   jpg     Form Load - removed trailing space from "Income"
'17/01/17   jpg     Modified pbsBudA.rpt and modified to read from Live DB - Ok
'17/01/17   jpg     Recreated pbsBudB.rpt from pbsBudA.rpt, but modified to read from Archive DB - Ok
'17/01/17   jpg     RefreshBudgetDetails(): updated for Archive DB
'****************************************************************************************************************************
Public Class frmBudgets

    Const MaxRow = 3
    Const MaxCol = 38

    Dim budRecordCount As Integer
    Dim pActiveTxtBox As Integer
    Dim ValueToCopy As Double
    Dim nBudgetTotals(0 To MaxRow, 0 To MaxCol + 2) As Double
    Dim msColumnName(36) As String

    Private Sub frmBudgets_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim sSql As String

        'TODO: This line of code loads data into the 'VPBSDataSet.Budget' table. You can move, or remove it, as needed.

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            Me.DirbudTableAdapterLive.Fill(Me.VPBSDataSet.dirbud)
            Me.BudgetTableAdapterLive.Fill(Me.VPBSDataSet.Budget)

            Me.DirbudBindingSource.DataSource = VPBSDataSet
            Me.BudgetBindingSource.DataSource = VPBSDataSet
            Me.TotalsBindingSource.DataSource = VPBSDataSet

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"
            Me.DirbudTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirbud)
            Me.BudgetTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Budget)

            Me.DirbudBindingSource.DataSource = VpbsArchiveDataSet
            Me.BudgetBindingSource.DataSource = VpbsArchiveDataSet
            Me.TotalsBindingSource.DataSource = VpbsArchiveDataSet

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"
            Me.DirbudTableAdapterTest.Fill(VPBSTestDataSet.dirbud)
            Me.BudgetTableAdapterTest.Fill(Me.VPBSTestDataSet.Budget)

            Me.DirbudBindingSource.DataSource = VPBSTestDataSet
            Me.BudgetBindingSource.DataSource = VPBSTestDataSet
            Me.TotalsBindingSource.DataSource = VPBSTestDataSet

        End If

        DirbudBindingSource.Filter = "BudgetNo = " + qte(gsBudgetNo) 'Select'
        DirbudBindingSource.Sort = "BudgetType, PeriodFrom" 'Order By'

        'TotalsBindingSource.Filter = "BudgetNo = " + "99999999" '+ " BudgetType IN ('1','2','3')" + " PeriodFrom = " & AccessDate("01/01/1999") 'Select'
        'TotalsBindingSource.Sort = "BudgetType"

        'DataGridDirBudget.DataSource = DirbudBindingSource
        DataGridDirBudget.TopLeftHeaderCell.Value = gsDBName '"------"
        DataGridBudget.TopLeftHeaderCell.Value = gsDBName '"------"
        DataGridActuals.TopLeftHeaderCell.Value = gsDBName '"------"

        DataGridDirBudget.Visible = True
        DataGridBudget.Visible = False
        DataGridActuals.Visible = False
        'DataGridTotals.Visible = True

        For X = 5 To DataGridBudget.Columns.Count - 1

            '"Budget1", "Budget2", "Budget3", "Budget4", "Budget5", "Budget6", "Budget7", "Budget8", "Budget9", "Budget10", "Budget11", "Budget12"

            DataGridBudget.Columns.Item(X).DefaultCellStyle.Format = "N2" 'gsTranCCYFmt
            DataGridBudget.Columns.Item(X).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Next X

        For X = 5 To DataGridActuals.Columns.Count - 1

            '"Budget1", "Budget2", "Budget3", "Budget4", "Budget5", "Budget6", "Budget7", "Budget8", "Budget9", "Budget10", "Budget11", "Budget12"

            DataGridActuals.Columns.Item(X).DefaultCellStyle.Format = "N2" 'gsTranCCYFmt
            DataGridActuals.Columns.Item(X).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridTotals.Columns.Item(X).DefaultCellStyle.Format = "N2" 'gsTranCCYFmt
            DataGridTotals.Columns.Item(X).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Next X

        'Budget or Actuals v Budget?
        If giActual = False Then
            Me.Text = "VPBS - Budgets"
            lblHeader1.Visible = False
            lblHeader2.Visible = False
            lblHeader3.Visible = False
            lblHeader4.Visible = False
            lblTotal2.Visible = False
            DataGridTotals.Visible = False
            GroupBox2.Visible = False
            cmdReport.Visible = False
            cmdRptOk.Visible = False
        Else
            Me.Text = "VPBS - Actuals v Budgets"
            'lblHeader1.Visible = True
            'lblHeader2.Visible = True
            'lblHeader3.Visible = True
            'lblHeader4.Visible = True
            'lblTotal.Visible = True
            'DataGridTotals.Visible = True
            rdo2Option0.Checked = True
            GroupBox2.Visible = True
            CmdChange.Visible = False
            CmdRepeat.Visible = False
            CmdDelete.Visible = False
            CmdOk.Visible = False
        End If

        Call SetHourGlassWait()

        'have any budgets been set up for this account?
        sSql = "SELECT Count(*) as budRecordCount"
        sSql = sSql & " FROM dirBud "
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        budRecordCount = ds.Rows.Item(0)("budRecordCount").ToString()
        adapter.Dispose()

        cboIncExp.Items.Add("Income") 'removed trailing space 16/04/2016
        cboIncExp.Items.Add("Expense")

        Call SetHourGlassDefault()

    End Sub

    Private Sub CmdSelect_Click(sender As Object, e As EventArgs) Handles CmdSelect.Click

        DataGridDirBudget.Visible = True
        DataGridBudget.Visible = False
        DataGridActuals.Visible = False
        DataGridTotals.Visible = False
        lblHeader1.Visible = False
        lblHeader2.Visible = False
        lblHeader3.Visible = False
        lblHeader4.Visible = False
        lblTotal1.Visible = False
        lblTotal2.Visible = False

    End Sub

    Private Sub InsertCodes()

        Dim sSql As String = ""
        Dim sMsg As String
        Dim X As Integer
        Dim nCount As Integer

        On Error GoTo InsertCodesError

        If gsAccountNo <> "None selected   " Then

            Call SetHourGlassWait()

            If gsBudgetType <> "" Then

                'Select Codes from BudgetType Code table (Analysis, Account or GLCode)
                'that have not been set up in the Budget table for this Budget
                sSql = sSql & " SELECT C.Code FROM " & gsBudgetType & " C"
                sSql = sSql & " WHERE C.Code NOT IN"
                sSql = sSql & " (SELECT B.Code From Budget B"
                sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
                sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
                sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom) & ")"

                Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
                Dim ds As New DataTable
                adapter.Fill(ds)

                If ds.Rows.Count > 0 Then

                    nCount = 0

                    Do While nCount <= ds.Rows.Count - 1

                        'Insert missing code records into Budget table

                        sSql = "INSERT INTO Budget"
                        sSql = sSql & " (BudgetNo, BudgetType, PeriodFrom, Code, IncomeExp, "
                        For X = 1 To 12
                            If X > 1 Then sSql = sSql & ", "
                            sSql = sSql & "Budget" & CStr(X)
                        Next X
                        sSql = sSql & ")"
                        sSql = sSql & " VALUES("
                        sSql = sSql & qte(gsBudgetNo) & ", " & qte(gsBudgetType) & ", "
                        sSql = sSql & qte(gvPeriodFrom) & ", " & qte(ds.Rows.Item(nCount)("Code")).ToString() & ", "
                        sSql = sSql & "'Expense', "
                        For X = 1 To 12
                            If X > 1 Then sSql = sSql & ", "
                            sSql = sSql & CStr(0)
                        Next X
                        sSql = sSql & ")"

                        If DoSql(sSql, 1) Then
                        End If

                        nCount = nCount + 1
                    Loop

                End If 'ds.Rows.Count > 0

                ds.Dispose()

            End If 'gsBudgetType <> ""

        End If 'gsAccountNo <> 

        Call SetHourGlassDefault()

        CmdSelect.Enabled = True
        CmdChange.Enabled = False
        CmdRepeat.Enabled = False
        CmdOk.Enabled = False
        CmdCancel.Enabled = False
        CmdClose.Enabled = True

        Exit Sub

InsertCodesError:

        Call SetHourGlassDefault()
        sMsg = "Error in selecting Budget records." & Chr(10)
        sMsg = sMsg & "Last sql statement: " & sSql
        MsgBox(sMsg)

        CmdSelect.Enabled = True
        CmdChange.Enabled = False
        CmdRepeat.Enabled = False
        CmdOk.Enabled = False
        CmdCancel.Enabled = False
        CmdClose.Enabled = True

        Exit Sub

    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click

        Me.Close()

    End Sub

    Private Sub DataGridDirBudget_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridDirBudget.CellContentClick

        'DirBudget
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridDirBudget.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirBudget.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridDirBudget.Columns(counter).HeaderText.ToString

            If DataGridDirBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridDirBudget.IsCurrentCellDirty = True) Then

                    value = DataGridDirBudget.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridDirBudget.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName
                    Case "BudgetNo"
                        gsBudgetNo = value
                    Case "BudgetType"
                        gsBudgetType = value
                    Case "StartMonth"
                        gsStartMonth = value
                    Case "PeriodFrom"
                        gvPeriodFrom = value
                    Case "PeriodTo"
                        gvPeriodTo = value
                    Case Else

                End Select

            End If

            If DataGridDirBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.date") Then

                Dim dvalue As Date = Nothing

                If (DataGridDirBudget.IsCurrentCellDirty = True) Then

                    dvalue = DataGridDirBudget.SelectedCells(counter) _
                        .EditedFormattedValue.
                Else

                    dvalue = DataGridDirBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "PeriodFrom"
                        'gvPeriodFrom = dvalue
                    Case "PeriodTo"
                        'gvPeriodTo = dvalue
                    Case Else

                End Select

            End If

            If DataGridDirBudget.SelectedCells(counter).FormattedValueType Is _
             Type.GetType("System.Number") Then

                Dim nvalue As Double = 0

                If (DataGridDirBudget.IsCurrentCellDirty = True) Then

                    nvalue = DataGridDirBudget.SelectedCells(counter) _
                        .EditedFormattedValue
                Else

                    nvalue = DataGridDirBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "Balance"
                        'nBalance = nvalue

                    Case Else

                End Select

            End If
        Next

        DataGridDirBudget.Visible = False
        If giActual = False Then
            Me.Text = "VPBS - Budgets"
            DataGridBudget.Visible = True
            DataGridActuals.Visible = False
            DataGridTotals.Visible = False
            lblHeader1.Visible = False
            lblHeader2.Visible = False
            lblHeader3.Visible = False
            lblHeader4.Visible = False
            lblTotal1.Visible = False
            lblTotal2.Visible = False
        Else
            Me.Text = "VPBS - Actuals v Budgets"
            DataGridBudget.Visible = False
            DataGridActuals.Visible = True
            DataGridTotals.Visible = True
            DataGridTotals.Columns(0).Visible = False 'fix to stop column 0 being changed to Visible for no apparent reason!
            lblHeader1.Visible = True
            lblHeader2.Visible = True
            lblHeader3.Visible = True
            lblHeader4.Visible = True
            lblTotal1.Visible = True
            lblTotal2.Visible = True
        End If

        ' Insert missing Codes in Budget from gsBudgetType Code Table
        Call InsertCodes()

        If giActual = True Then
            'do the actuals need updating?
            Call RefreshActuals()
            'calculate the Variance per month
            Call RefreshVariance()
            'Re-calculate the Totals
            Call RefreshTotals2()
            Call RefreshBudgetDetails()
        End If

        GroupBox3.Visible = False

        'open database and populate Grid

        BudgetBindingSource.Filter = "BudgetNo = " + qte(gsBudgetNo) + " And BudgetType = " & qte(gsBudgetType) + " And PeriodFrom = " & qte(gvPeriodFrom) 'Select'
        BudgetBindingSource.Sort = "IncomeExp Desc, Code Asc" 'Order By', IncomeExp

        Call DisplayHeader()
        'Call DisplayDetails()

        Call BudgetHeadings(GetMonthAsNumber(gsStartMonth))
        'need to add Call "Actual v Budget" headings
        Call ActualHeadings(0)

        CmdSelect.Enabled = True
        CmdRepeat.Enabled = True
        CmdChange.Enabled = True
        CmdRepeat.Enabled = True
        CmdDelete.Enabled = True
        CmdOk.Enabled = False
        CmdCancel.Enabled = False

    End Sub

    Private Sub DataGridBudget_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridDirBudget.CellContentClick

        'Budget
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridBudget.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirBudget.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridBudget.Columns(counter).DataPropertyName.ToString 'HeaderText.ToString NB!

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    value = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName
                    Case "Code" '"Heading"
                        txtHeading.Text = value
                    Case "Description"
                        txtDescription.Text = value
                    Case "IncomeExp"
                        'txtIncExp.Text = value
                        cboIncExp.Text = value
                    Case "Budget1"
                        txtAmount1.Text = value
                    Case "Budget2"
                        txtAmount2.Text = value
                    Case "Budget3"
                        txtAmount3.Text = value
                    Case "Budget4"
                        txtAmount4.Text = value
                    Case "Budget5"
                        txtAmount5.Text = value
                    Case "Budget6"
                        txtAmount6.Text = value
                    Case "Budget7"
                        txtAmount7.Text = value
                    Case "Budget8"
                        txtAmount8.Text = value
                    Case "Budget9"
                        txtAmount9.Text = value
                    Case "Budget10"
                        txtAmount10.Text = value
                    Case "Budget11"
                        txtAmount11.Text = value
                    Case "Budget12"
                        txtAmount12.Text = value
                    Case Else

                End Select

            End If

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.date") Then

                Dim dvalue As Date = Nothing

                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    dvalue = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue.
                Else

                    dvalue = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "PeriodFrom"
                        'gvPeriodFrom = dvalue
                    Case "PeriodTo"
                        'gvPeriodTo = dvalue
                    Case Else

                End Select

            End If

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
             Type.GetType("System.Number") Then

                Dim nvalue As Double = 0

                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    nvalue = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue
                Else

                    nvalue = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "Balance"
                        'nBalance = nvalue

                    Case Else

                End Select

            End If
        Next

        CmdSelect.Enabled = True
        CmdChange.Enabled = True
        CmdDelete.Enabled = True
        CmdOk.Enabled = False
        CmdCancel.Enabled = False

    End Sub

    Private Sub ActualHeadings(ActualMonthCounter As Integer)

        Dim ActualMonth As Integer

        'Populate actual headings

        ActualMonth = GetMonthAsNumber(gsStartMonth) + ActualMonthCounter '(0 to 11)
        If ActualMonth > 12 Then ActualMonth = ActualMonth - 12
        lblHeader2.Text = "<<=====     === " + GetMonthAsString(ActualMonth) + "===    =====>>"
        lblHeader3.Text = "<<=====     === " + GetMonthAsString(ActualMonth + 1) + "===    =====>>"

    End Sub

    Private Sub ActualHeadingsReport(BudgetStartMonth As Integer)

        Dim X As Integer
        Dim BudgetMonth As Integer

        'Populate actual/budget/variance headings
        For X = 0 To 11
            BudgetMonth = BudgetStartMonth + X
            If BudgetMonth > 12 Then BudgetMonth = BudgetMonth - 12
            msColumnName(1 + (3 * X)) = "<======="
            msColumnName(2 + (3 * X)) = GetMonthAsString(BudgetMonth)
            msColumnName(3 + (3 * X)) = "=======>"
        Next X

    End Sub

    Private Sub BudgetHeadings(BudgetStartMonth As Integer)

        Dim X As Integer
        Dim BudgetMonth As Integer

        'Populate budget headings
        For X = 0 To 11
            BudgetMonth = BudgetStartMonth + X
            If BudgetMonth > 12 Then BudgetMonth = BudgetMonth - 12
            Select Case X
                Case 0
                    lblAmt1.Text = GetMonthAsString(BudgetMonth)
                Case 1
                    lblAmt2.Text = GetMonthAsString(BudgetMonth)
                Case 2
                    lblAmt3.Text = GetMonthAsString(BudgetMonth)
                Case 3
                    lblAmt4.Text = GetMonthAsString(BudgetMonth)
                Case 4
                    lblAmt5.Text = GetMonthAsString(BudgetMonth)
                Case 5
                    lblAmt6.Text = GetMonthAsString(BudgetMonth)
                Case 6
                    lblAmt7.Text = GetMonthAsString(BudgetMonth)
                Case 7
                    lblAmt8.Text = GetMonthAsString(BudgetMonth)
                Case 8
                    lblAmt9.Text = GetMonthAsString(BudgetMonth)
                Case 9
                    lblAmt10.Text = GetMonthAsString(BudgetMonth)
                Case 10
                    lblAmt11.Text = GetMonthAsString(BudgetMonth)
                Case 11
                    lblAmt12.Text = GetMonthAsString(BudgetMonth)
                Case Else
            End Select           
            DataGridBudget.Columns.Item(X + 5).HeaderText = GetMonthAsString(BudgetMonth) 'allow for invisible columns etc
        Next X

    End Sub

    Private Sub GetDescription()

        Dim Sql As String

        Sql = " SELECT Description"
        Sql = Sql & " FROM " & gsBudgetType
        Sql = Sql & " WHERE Code = " & qte(txtHeading.Text)

        Dim sSql As String = Sql

        Using connection As New OleDb.OleDbConnection(gsVpbsConnection)

            Dim command As New OleDb.OleDbCommand(sSql, connection)

            Try
                connection.Open()
            Catch oledbexceptionerr As OleDb.OleDbException
                MessageBox.Show(oledbexceptionerr.Message, "Access Error")
            Catch InvalidOperationExceptionerr As InvalidOperationException
                MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
            End Try

            If connection.State <> ConnectionState.Open Then
                MessageBox.Show("Database connection Failed")
            End If

            Dim reader As OleDb.OleDbDataReader = command.ExecuteReader()

            While reader.Read()

                txtDescription.Text = reader.GetString(0)

            End While

            ' always call Close when done reading.
            reader.Close()
            connection.Close()
            connection.Dispose()

        End Using

    End Sub

    Private Sub CmdChange_Click(sender As Object, e As EventArgs) Handles CmdChange.Click

        'Budget
        Dim sName As String

        GroupBox3.Visible = True

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridBudget.SelectedCells.Count - 1)

            'Debug.Print(DataGridDirBudget.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

            sName = DataGridBudget.Columns(counter).DataPropertyName.ToString 'HeaderText.ToString

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been committed,
                ' use the modified value.
                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    value = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                Select Case sName
                    Case "Code" '"Heading"
                        txtHeading.Text = value
                    Case "Description"
                        txtDescription.Text = value
                    Case "IncomeExp"
                        cboIncExp.Text = value
                    Case "Budget1"
                        txtAmount1.Text = value
                    Case "Budget2"
                        txtAmount2.Text = value
                    Case "Budget3"
                        txtAmount3.Text = value
                    Case "Budget4"
                        txtAmount4.Text = value
                    Case "Budget5"
                        txtAmount5.Text = value
                    Case "Budget6"
                        txtAmount6.Text = value
                    Case "Budget7"
                        txtAmount7.Text = value
                    Case "Budget8"
                        txtAmount8.Text = value
                    Case "Budget9"
                        txtAmount9.Text = value
                    Case "Budget10"
                        txtAmount10.Text = value
                    Case "Budget11"
                        txtAmount11.Text = value
                    Case "Budget12"
                        txtAmount12.Text = value
                    Case Else

                End Select

            End If

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.date") Then

                Dim dvalue As Date = Nothing

                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    dvalue = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue.
                Else

                    dvalue = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "PeriodFrom"
                        'gvPeriodFrom = dvalue
                    Case "PeriodTo"
                        'gvPeriodTo = dvalue
                    Case Else

                End Select

            End If

            If DataGridBudget.SelectedCells(counter).FormattedValueType Is _
             Type.GetType("System.Number") Then

                Dim nvalue As Double = 0

                If (DataGridBudget.IsCurrentCellDirty = True) Then

                    nvalue = DataGridBudget.SelectedCells(counter) _
                        .EditedFormattedValue
                Else

                    nvalue = DataGridBudget.SelectedCells(counter) _
                        .FormattedValue

                End If

                Select Case sName

                    Case "Balance"
                        'nBalance = nvalue

                    Case Else

                End Select

            End If
        Next

        For X = 5 To DataGridBudget.Columns.Count - 1

            '"Budget1", "Budget2", "Budget3", "Budget4", "Budget5", "Budget6", "Budget7", "Budget8", "Budget9", "Budget10", "Budget11", "Budget12"

            DataGridBudget.Columns.Item(X).DefaultCellStyle.Format = "N2" 'gsTranCCYFmt
            'DataGridBudget.Columns.Item(X).DefaultCellStyle.Alignment = "MiddleRight"

        Next X

        Call GetDescription()

        DataGridDirBudget.Visible = False
        DataGridBudget.Visible = True

        CmdSelect.Enabled = True
        CmdChange.Enabled = True
        CmdDelete.Enabled = True
        CmdOk.Enabled = True
        CmdCancel.Enabled = True

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click

        GroupBox2.Visible = False
        GroupBox3.Visible = False

    End Sub

    Private Sub DisplayHeader()

        If giActual = False Then
            lblBudgetHeader.Text = "Budget for A/C: " + gsAccountNo + " " + gsAccountName + " by " + gsBudgetType + " for period: " & gvPeriodFrom & " to " & gvPeriodTo
        Else
            lblBudgetHeader.Text = "Actual v Budget for A/C: " + gsAccountNo + " " + gsAccountName + " by " + gsBudgetType + " for period: " & gvPeriodFrom & " to " & gvPeriodTo
        End If
 
    End Sub

    Private Sub DisplayDetails()

        Dim bOk As Boolean

        'Update screen
        '
        'reload data from DB

        If gsDBName = "Live" Then
            bOk = Me.BudgetTableAdapterLive.ClearBeforeFill
            Me.BudgetTableAdapterLive.Fill(Me.VPBSDataSet.Budget)
            Me.BudgetBindingSource.DataSource = VPBSDataSet
        ElseIf gsDBName = "Archive" Then
            bOk = Me.BudgetTableAdapterArc.ClearBeforeFill
            Me.BudgetTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Budget)
            Me.BudgetBindingSource.DataSource = VpbsArchiveDataSet
        Else
            bOk = Me.BudgetTableAdapterTest.ClearBeforeFill
            Me.BudgetTableAdapterTest.Fill(Me.VPBSTestDataSet.Budget)
            Me.BudgetBindingSource.DataSource = VPBSTestDataSet
        End If

    End Sub

    Private Sub CmdRepeat_Click(sender As Object, e As EventArgs) Handles CmdRepeat.Click

        Dim X As Integer

        'Autofills textboxes using the last input
        For X = pActiveTxtBox + 1 To 12

            Select Case X
                Case 1
                    txtAmount1.Text = ValueToCopy
                Case 2
                    txtAmount2.Text = ValueToCopy
                Case 3
                    txtAmount3.Text = ValueToCopy
                Case 4
                    txtAmount4.Text = ValueToCopy
                Case 5
                    txtAmount5.Text = ValueToCopy
                Case 6
                    txtAmount6.Text = ValueToCopy
                Case 7
                    txtAmount7.Text = ValueToCopy
                Case 8
                    txtAmount8.Text = ValueToCopy
                Case 9
                    txtAmount9.Text = ValueToCopy
                Case 10
                    txtAmount10.Text = ValueToCopy
                Case 11
                    txtAmount11.Text = ValueToCopy
                Case 12
                    txtAmount12.Text = ValueToCopy
            End Select
        Next X

    End Sub

    Private Sub txtAmount1_TextChanged(sender As Object, e As EventArgs) Handles txtAmount1.TextChanged

        pActiveTxtBox = 1
        ValueToCopy = Val(txtAmount1.Text)

    End Sub

    Private Sub txtAmount2_TextChanged(sender As Object, e As EventArgs) Handles txtAmount2.TextChanged

        pActiveTxtBox = 2
        ValueToCopy = Val(txtAmount2.Text)

    End Sub

    Private Sub txtAmount3_TextChanged(sender As Object, e As EventArgs) Handles txtAmount3.TextChanged

        pActiveTxtBox = 3
        ValueToCopy = Val(txtAmount3.Text)

    End Sub

    Private Sub txtAmount4_TextChanged(sender As Object, e As EventArgs) Handles txtAmount4.TextChanged

        pActiveTxtBox = 4
        ValueToCopy = Val(txtAmount4.Text)

    End Sub

    Private Sub txtAmount5_TextChanged(sender As Object, e As EventArgs) Handles txtAmount5.TextChanged

        pActiveTxtBox = 5
        ValueToCopy = Val(txtAmount5.Text)

    End Sub

    Private Sub txtAmount6_TextChanged(sender As Object, e As EventArgs) Handles txtAmount6.TextChanged

        pActiveTxtBox = 6
        ValueToCopy = Val(txtAmount6.Text)

    End Sub

    Private Sub txtAmount7_TextChanged(sender As Object, e As EventArgs) Handles txtAmount7.TextChanged

        pActiveTxtBox = 7
        ValueToCopy = Val(txtAmount7.Text)

    End Sub

    Private Sub txtAmount8_TextChanged(sender As Object, e As EventArgs) Handles txtAmount8.TextChanged

        pActiveTxtBox = 8
        ValueToCopy = Val(txtAmount8.Text)

    End Sub

    Private Sub txtAmount9_TextChanged(sender As Object, e As EventArgs) Handles txtAmount9.TextChanged

        pActiveTxtBox = 9
        ValueToCopy = Val(txtAmount9.Text)

    End Sub

    Private Sub txtAmount10_TextChanged(sender As Object, e As EventArgs) Handles txtAmount10.TextChanged

        pActiveTxtBox = 10
        ValueToCopy = Val(txtAmount10.Text)

    End Sub

    Private Sub txtAmount11_TextChanged(sender As Object, e As EventArgs) Handles txtAmount11.TextChanged

        pActiveTxtBox = 11
        ValueToCopy = Val(txtAmount11.Text)

    End Sub

    Private Sub txtAmount12_TextChanged(sender As Object, e As EventArgs) Handles txtAmount12.TextChanged

        ValueToCopy = Val(txtAmount12.Text)

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click

        Dim sSql As String
        Dim Style As Short
        Dim Msg As String
        Dim Response As Short
        Dim Title As String
        Dim bOk As Boolean

        If giUserLevel <> 2 Then

            'Delete From Budget table
            Msg = " Confirm deletion of Budget record "
            Style = vbYesNo + vbExclamation + vbDefaultButton2 ' Describe dialog.
            Title = "Delete Budget Record " & txtHeading.Text
            Response = MsgBox(Msg, Style, Title)

            If Response = MsgBoxResult.Yes Then
                'now delete Budget record in Budget table
                sSql = "Delete From Budget"
                sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
                sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
                sSql = sSql & " AND Code = " & qte(txtHeading.Text)
                bOk = DoSql(sSql, 1)
            End If

            Call DisplayDetails()

        End If

    End Sub

    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click

        Dim sSql As String
        Dim Msg As String
        Dim Title As String
        Dim X As Integer
        Dim bOk As Boolean

        For X = 1 To 12
            Select Case X
                Case 1
                    If Not IsNumeric(txtAmount1.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount1.Focus()
                        Exit Sub
                    End If
                Case 2
                    If Not IsNumeric(txtAmount2.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount2.Focus()
                        Exit Sub
                    End If
                Case 3
                    If Not IsNumeric(txtAmount3.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount3.Focus()
                        Exit Sub
                    End If
                Case 4
                    If Not IsNumeric(txtAmount4.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount4.Focus()
                        Exit Sub
                    End If
                Case 5
                    If Not IsNumeric(txtAmount5.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount5.Focus()
                        Exit Sub
                    End If
                Case 6
                    If Not IsNumeric(txtAmount6.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount6.Focus()
                        Exit Sub
                    End If
                Case 7
                    If Not IsNumeric(txtAmount7.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount8.Focus()
                        Exit Sub
                    End If
                Case 8
                    If Not IsNumeric(txtAmount8.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount8.Focus()
                        Exit Sub
                    End If
                Case 9
                    If Not IsNumeric(txtAmount9.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount9.Focus()
                        Exit Sub
                    End If
                Case 10
                    If Not IsNumeric(txtAmount10.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount10.Focus()
                        Exit Sub
                    End If
                Case 11
                    If Not IsNumeric(txtAmount11.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount11.Focus()
                        Exit Sub
                    End If
                Case 12
                    If Not IsNumeric(txtAmount12.Text) Then
                        Msg = "Invalid or no amount entered - please rectify"
                        Title = "Enter amount"
                        MsgBox(Msg, vbExclamation, Title)
                        txtAmount12.Focus()
                        Exit Sub
                    End If
            End Select

        Next X

        Call SetHourGlassWait()

        'Update Budget
        sSql = "Update Budget "
        sSql = sSql & "Set IncomeExp = " & qte(cboIncExp.Text)
        sSql = sSql & ", Budget1 = " & qte(txtAmount1.Text)
        sSql = sSql & ", Budget2 = " & qte(txtAmount2.Text)
        sSql = sSql & ", Budget3 = " & qte(txtAmount3.Text)
        sSql = sSql & ", Budget4 = " & qte(txtAmount4.Text)
        sSql = sSql & ", Budget5 = " & qte(txtAmount5.Text)
        sSql = sSql & ", Budget6 = " & qte(txtAmount6.Text)
        sSql = sSql & ", Budget7 = " & qte(txtAmount7.Text)
        sSql = sSql & ", Budget8 = " & qte(txtAmount8.Text)
        sSql = sSql & ", Budget9 = " & qte(txtAmount9.Text)
        sSql = sSql & ", Budget10 = " & qte(txtAmount10.Text)
        sSql = sSql & ", Budget11 = " & qte(txtAmount11.Text)
        sSql = sSql & ", Budget12 = " & qte(txtAmount12.Text)
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND Code = " & qte(txtHeading.Text)

        bOk = DoSql(sSql, 1)

        DisplayDetails()

        Call SetHourGlassDefault()

        If budRecordCount > 0 Then
            CmdSelect.Enabled = True
        Else
            CmdSelect.Enabled = False
        End If
        CmdChange.Enabled = True
        CmdRepeat.Enabled = False
        CmdOk.Enabled = False
        CmdCancel.Enabled = False
        CmdClose.Enabled = True

    End Sub

    Private Sub cmdScrollLft_Click(sender As Object, e As EventArgs) Handles cmdScrollLft.Click

        Dim Index As Integer = 0

        If giActual = False Then
            Call CmdScroll_Click(Index)
        Else
            Call CmdScrollActuals_Click(Index)
        End If

    End Sub

    Private Sub cmdScrollRgt_Click(sender As Object, e As EventArgs) Handles cmdScrollRgt.Click

        Dim Index As Integer = 1

        If giActual = False Then
            Call CmdScroll_Click(Index)
        Else
            Call CmdScrollActuals_Click(Index)
        End If

    End Sub

    Private Sub CmdScroll_Click(Index As Integer)

        DataGridBudget.Columns(0).Visible = False
        DataGridBudget.Columns(1).Visible = False
        DataGridBudget.Columns(2).Visible = False
        DataGridBudget.Columns(3).Visible = True
        DataGridBudget.Columns(4).Visible = True

        Select Case Index

            Case 0          'scroll left

                If DataGridBudget.Columns(11 + 3).Visible = False Then
                    DataGridBudget.Columns(11 + 3).Visible = True
                    DataGridBudget.Columns(12 + 3).Visible = True
                    DataGridBudget.Columns(13 + 3).Visible = True
                    'DataGridBudget.LefCol = 0 '11
                ElseIf DataGridBudget.Columns(8 + 3).Visible = False Then
                    DataGridBudget.Columns(8 + 3).Visible = True
                    DataGridBudget.Columns(9 + 3).Visible = True
                    DataGridBudget.Columns(10 + 3).Visible = True
                    'DataGridBudget.LeftCol = 0 '8
                ElseIf DataGridBudget.Columns(5 + 3).Visible = False Then
                    DataGridBudget.Columns(5 + 3).Visible = True
                    DataGridBudget.Columns(6 + 3).Visible = True
                    DataGridBudget.Columns(7 + 3).Visible = True
                    'DataGridBudget.LeftCol = 0 '5
                ElseIf DataGridBudget.Columns(2 + 3).Visible = False Then
                    DataGridBudget.Columns(2 + 3).Visible = True
                    DataGridBudget.Columns(3 + 3).Visible = True
                    DataGridBudget.Columns(4 + 3).Visible = True
                    'DataGridBudget.LeftCol = 0 '2
                End If

            Case 1  'scroll right

                If DataGridBudget.Columns(2 + 3).Visible = True Then
                    DataGridBudget.Columns(2 + 3).Visible = False
                    DataGridBudget.Columns(3 + 3).Visible = False
                    DataGridBudget.Columns(4 + 3).Visible = False
                    'DataGridBudget.LeftCol = 5
                ElseIf DataGridBudget.Columns(5 + 3).Visible = True Then
                    DataGridBudget.Columns(5 + 3).Visible = False
                    DataGridBudget.Columns(6 + 3).Visible = False
                    DataGridBudget.Columns(7 + 3).Visible = False
                    'DataGridBudget.LeftCol = 8

                End If

        End Select

    End Sub

    Private Sub CmdScrollActuals_Click(Index As Integer)

        DataGridActuals.Columns(0).Visible = False
        DataGridActuals.Columns(1).Visible = False
        DataGridActuals.Columns(2).Visible = False
        DataGridActuals.Columns(3).Visible = True
        DataGridActuals.Columns(4).Visible = True

        Select Case Index

            Case 0          'scroll left

                If DataGridActuals.Columns(29 + 3).Visible = False Then
                    Call ActualHeadings(9)
                    DataGridActuals.Columns(29 + 3).Visible = True
                    DataGridActuals.Columns(30 + 3).Visible = True
                    DataGridActuals.Columns(31 + 3).Visible = True
                    'DataGridActuals.Left = 0 '29 changed for VB6 'no TDBG'
                    DataGridTotals.Columns(29 + 3).Visible = True
                    DataGridTotals.Columns(30 + 3).Visible = True
                    DataGridTotals.Columns(31 + 3).Visible = True
                    'DataGridActuals.Left = 0 '29 'vb08
                ElseIf DataGridActuals.Columns(26 + 3).Visible = False Then
                    Call ActualHeadings(8)
                    DataGridActuals.Columns(26 + 3).Visible = True
                    DataGridActuals.Columns(27 + 3).Visible = True
                    DataGridActuals.Columns(28 + 3).Visible = True
                    'DataGridActuals.Left = 0 '26
                    DataGridTotals.Columns(26 + 3).Visible = True
                    DataGridTotals.Columns(27 + 3).Visible = True
                    DataGridTotals.Columns(28 + 3).Visible = True
                    'DataGridActuals.Left = 0 '26 'vb08
                ElseIf DataGridActuals.Columns(23 + 3).Visible = False Then
                    Call ActualHeadings(7)
                    DataGridActuals.Columns(23 + 3).Visible = True
                    DataGridActuals.Columns(24 + 3).Visible = True
                    DataGridActuals.Columns(25 + 3).Visible = True
                    'DataGridActuals.Left = 0 '23
                    DataGridTotals.Columns(23 + 3).Visible = True
                    DataGridTotals.Columns(24 + 3).Visible = True
                    DataGridTotals.Columns(25 + 3).Visible = True
                    'DataGridActuals.Left = 0 '23 'vb08
                ElseIf DataGridActuals.Columns(20 + 3).Visible = False Then
                    Call ActualHeadings(6)
                    DataGridActuals.Columns(20 + 3).Visible = True
                    DataGridActuals.Columns(21 + 3).Visible = True
                    DataGridActuals.Columns(22 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '20
                    DataGridTotals.Columns(20 + 3).Visible = True
                    DataGridTotals.Columns(21 + 3).Visible = True
                    DataGridTotals.Columns(22 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '20 'vb08
                ElseIf DataGridActuals.Columns(17 + 3).Visible = False Then
                    Call ActualHeadings(5)
                    DataGridActuals.Columns(17 + 3).Visible = True
                    DataGridActuals.Columns(18 + 3).Visible = True
                    DataGridActuals.Columns(19 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '17
                    DataGridTotals.Columns(17 + 3).Visible = True
                    DataGridTotals.Columns(18 + 3).Visible = True
                    DataGridTotals.Columns(19 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '17 'vb08
                ElseIf DataGridActuals.Columns(14 + 3).Visible = False Then
                    Call ActualHeadings(4)
                    DataGridActuals.Columns(14 + 3).Visible = True
                    DataGridActuals.Columns(15 + 3).Visible = True
                    DataGridActuals.Columns(16 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '14
                    DataGridTotals.Columns(14 + 3).Visible = True
                    DataGridTotals.Columns(15 + 3).Visible = True
                    DataGridTotals.Columns(16 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '14 'vb08
                ElseIf DataGridActuals.Columns(11 + 3).Visible = False Then
                    Call ActualHeadings(3)
                    DataGridActuals.Columns(11 + 3).Visible = True
                    DataGridActuals.Columns(12 + 3).Visible = True
                    DataGridActuals.Columns(13 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '11
                    DataGridTotals.Columns(11 + 3).Visible = True
                    DataGridTotals.Columns(12 + 3).Visible = True
                    DataGridTotals.Columns(13 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '11 'vb08
                ElseIf DataGridActuals.Columns(8 + 3).Visible = False Then
                    Call ActualHeadings(2)
                    DataGridActuals.Columns(8 + 3).Visible = True
                    DataGridActuals.Columns(9 + 3).Visible = True
                    DataGridActuals.Columns(10 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '8
                    DataGridTotals.Columns(8 + 3).Visible = True
                    DataGridTotals.Columns(9 + 3).Visible = True
                    DataGridTotals.Columns(10 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '8 'vb08
                ElseIf DataGridActuals.Columns(5 + 3).Visible = False Then
                    Call ActualHeadings(1)
                    DataGridActuals.Columns(5 + 3).Visible = True
                    DataGridActuals.Columns(6 + 3).Visible = True
                    DataGridActuals.Columns(7 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '5
                    DataGridTotals.Columns(5 + 3).Visible = True
                    DataGridTotals.Columns(6 + 3).Visible = True
                    DataGridTotals.Columns(7 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '5 'vb08
                ElseIf DataGridActuals.Columns(2 + 3).Visible = False Then
                    Call ActualHeadings(0)
                    DataGridActuals.Columns(2 + 3).Visible = True
                    DataGridActuals.Columns(3 + 3).Visible = True
                    DataGridActuals.Columns(4 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '2
                    DataGridTotals.Columns(2 + 3).Visible = True
                    DataGridTotals.Columns(3 + 3).Visible = True
                    DataGridTotals.Columns(4 + 3).Visible = True
                    'DataGridActuals.LeftCol = 0 '2 'vb08
                End If

            Case 1  'scroll right

                If DataGridActuals.Columns(2 + 3).Visible = True Then
                    Call ActualHeadings(1)
                    DataGridActuals.Columns(2 + 3).Visible = False
                    DataGridActuals.Columns(3 + 3).Visible = False
                    DataGridActuals.Columns(4 + 3).Visible = False
                    'DataGridActuals.LeftCol = 5
                    DataGridTotals.Columns(2 + 3).Visible = False
                    DataGridTotals.Columns(3 + 3).Visible = False
                    DataGridTotals.Columns(4 + 3).Visible = False
                    'DataGridActuals.LeftCol = 5
                ElseIf DataGridActuals.Columns(5 + 3).Visible = True Then
                    Call ActualHeadings(2)
                    DataGridActuals.Columns(5 + 3).Visible = False
                    DataGridActuals.Columns(6 + 3).Visible = False
                    DataGridActuals.Columns(7 + 3).Visible = False
                    'DataGridActuals.LeftCol = 8
                    DataGridTotals.Columns(5 + 3).Visible = False
                    DataGridTotals.Columns(6 + 3).Visible = False
                    DataGridTotals.Columns(7 + 3).Visible = False
                    'DataGridActuals.LeftCol = 8
                ElseIf DataGridActuals.Columns(8 + 3).Visible = True Then
                    Call ActualHeadings(3)
                    DataGridActuals.Columns(8 + 3).Visible = False
                    DataGridActuals.Columns(9 + 3).Visible = False
                    DataGridActuals.Columns(10 + 3).Visible = False
                    'DataGridActuals.LeftCol = 11
                    DataGridTotals.Columns(8 + 3).Visible = False
                    DataGridTotals.Columns(9 + 3).Visible = False
                    DataGridTotals.Columns(10 + 3).Visible = False
                    'DataGridActuals.LeftCol = 11
                ElseIf DataGridActuals.Columns(11 + 3).Visible = True Then
                    Call ActualHeadings(4)
                    DataGridActuals.Columns(11 + 3).Visible = False
                    DataGridActuals.Columns(12 + 3).Visible = False
                    DataGridActuals.Columns(13 + 3).Visible = False
                    'DataGridActuals.LeftCol = 14
                    DataGridTotals.Columns(11 + 3).Visible = False
                    DataGridTotals.Columns(12 + 3).Visible = False
                    DataGridTotals.Columns(13 + 3).Visible = False
                    'DataGridActuals.Splits(1).LeftCol = 14
                ElseIf DataGridActuals.Columns(14 + 3).Visible = True Then
                    Call ActualHeadings(5)
                    DataGridActuals.Columns(14 + 3).Visible = False
                    DataGridActuals.Columns(15 + 3).Visible = False
                    DataGridActuals.Columns(16 + 3).Visible = False
                    'DataGridActuals.LeftCol = 17
                    DataGridTotals.Columns(14 + 3).Visible = False
                    DataGridTotals.Columns(15 + 3).Visible = False
                    DataGridTotals.Columns(16 + 3).Visible = False
                    'DataGridActuals.LeftCol = 17
                ElseIf DataGridActuals.Columns(17 + 3).Visible = True Then
                    Call ActualHeadings(6)
                    DataGridActuals.Columns(17 + 3).Visible = False
                    DataGridActuals.Columns(18 + 3).Visible = False
                    DataGridActuals.Columns(19 + 3).Visible = False
                    'DataGridActuals.LeftCol = 20
                    DataGridTotals.Columns(17 + 3).Visible = False
                    DataGridTotals.Columns(18 + 3).Visible = False
                    DataGridTotals.Columns(19 + 3).Visible = False
                    'DataGridActuals.Splits(1).LeftCol = 20
                ElseIf DataGridActuals.Columns(20 + 3).Visible = True Then
                    Call ActualHeadings(7)
                    DataGridActuals.Columns(20 + 3).Visible = False
                    DataGridActuals.Columns(21 + 3).Visible = False
                    DataGridActuals.Columns(22 + 3).Visible = False
                    'DataGridActuals.LeftCol = 23
                    DataGridTotals.Columns(20 + 3).Visible = False
                    DataGridTotals.Columns(21 + 3).Visible = False
                    DataGridTotals.Columns(22 + 3).Visible = False
                    'DataGridActuals.LeftCol = 23
                ElseIf DataGridActuals.Columns(23 + 3).Visible = True Then
                    Call ActualHeadings(8)
                    DataGridActuals.Columns(23 + 3).Visible = False
                    DataGridActuals.Columns(24 + 3).Visible = False
                    DataGridActuals.Columns(25 + 3).Visible = False
                    'DataGridActuals.LeftCol = 26
                    DataGridTotals.Columns(23 + 3).Visible = False
                    DataGridTotals.Columns(24 + 3).Visible = False
                    DataGridTotals.Columns(25 + 3).Visible = False
                    'DataGridActuals.LeftCol = 26
                ElseIf DataGridActuals.Columns(26 + 3).Visible = True Then
                    Call ActualHeadings(9)
                    DataGridActuals.Columns(26 + 3).Visible = False
                    DataGridActuals.Columns(27 + 3).Visible = False
                    DataGridActuals.Columns(28 + 3).Visible = False
                    'DataGridActuals.LeftCol = 29
                    DataGridTotals.Columns(26 + 3).Visible = False
                    DataGridTotals.Columns(27 + 3).Visible = False
                    DataGridTotals.Columns(28 + 3).Visible = False
                    'DataGridActuals.LeftCol = 29
                ElseIf DataGridActuals.Columns(29 + 3).Visible = True Then
                    Call ActualHeadings(10)
                    DataGridActuals.Columns(29 + 3).Visible = False
                    DataGridActuals.Columns(30 + 3).Visible = False
                    DataGridActuals.Columns(31 + 3).Visible = False
                    'DataGridActuals.LeftCol = 32
                    DataGridTotals.Columns(29 + 3).Visible = False
                    DataGridTotals.Columns(30 + 3).Visible = False
                    DataGridTotals.Columns(31 + 3).Visible = False
                    'DataGridActuals.LeftCol = 32
                End If

        End Select

    End Sub

    Private Sub RefreshActuals()

        'Dim ssActuals As Recordset
        Dim sSql As String
        Dim sWhere As String
        Dim StartDate As Object
        Dim EndDate As Object
        Dim sBudgetCode As String
        Dim sLastBudgetCode As String = ""
        Dim sBudgetCurrency As String = ""
        Dim nActual As Double
        Dim nCount As Integer
        Dim X As Integer

        On Error GoTo ErrorRefreshActuals

        ' please wait...
        Call SetHourGlassWait()

        'First check RefreshReqd flag in dirbud
        sSql = " SELECT RefreshReqd, Currency FROM dirbud, dirpbs"
        sSql = sSql & " WHERE dirbud.BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND dirbud.BudgetNo = dirpbs.BudgetNo"
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            nCount = 0
            If ds.Rows.Item(nCount)("RefreshReqd") = "No" Then
                'Actuals do not need refreshing so get out of here
                ds.Dispose()
                Call SetHourGlassDefault()
                Exit Sub
            Else
                sBudgetCurrency = ds.Rows.Item(nCount)("Currency")
            End If
        Else
            ds.Dispose()
            Call SetHourGlassDefault()
            Exit Sub
        End If

        ds.Dispose()

        StartDate = gvPeriodFrom

        For X = 1 To 12

            EndDate = DateAdd("m", 1, StartDate)

            'Sum Actual transactions by Budget code for Budget no. and specified period
            sSql = "SELECT " & gsBudgetType & " AS BudgetCode, Sum(Amount) AS Actual, Currency"
            sSql = sSql & " FROM pbsTrans, dirpbs"
            sSql = sSql & " WHERE dirpbs.BudgetNo = " & qte(gsBudgetNo)
            sSql = sSql & " AND dirpbs.AccountNo = pbsTrans.AccountNo"
            sSql = sSql & " AND pbsTrans.Date >= " & AccessDate(StartDate)
            sSql = sSql & " AND pbsTrans.Date < " & AccessDate(EndDate)
            sSql = sSql & " AND pbsTrans." & gsBudgetType & " <> ''"
            sSql = sSql & " GROUP BY " & gsBudgetType & ", Currency"           'Code stored in Analysis, Account or GLCode field

            Dim adapter1 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
            Dim ds1 As New DataTable
            adapter1.Fill(ds1)

            nCount = 0
            If ds1.Rows.Count > 0 Then

                Do While nCount < ds1.Rows.Count '- 1

                    sBudgetCode = ds1.Rows.Item(nCount)("BudgetCode")
                    If sBudgetCurrency = ds1.Rows.Item(nCount)("Currency") Then
                        'already in budget ccy
                        nActual = ds1.Rows.Item(nCount)("Actual")
                    Else
                        'convert to budget ccy
                        nActual = ConvertAmount(ds1.Rows.Item(nCount)("Actual"), ds1.Rows.Item(nCount)("Currency"), sBudgetCurrency)
                    End If

                    sWhere = " BudgetNo = " & qte(gsBudgetNo)
                    sWhere = sWhere & " AND BudgetType = " & qte(gsBudgetType)
                    sWhere = sWhere & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
                    sWhere = sWhere & " AND Code = " & qte(sBudgetCode)

                    'Debug.Print sBudgetCode, nActual, ssActuals("Currency")
                    'accumulate actuals when more than one update per month (when more than one ccy per Budget Code)
                    sSql = "UPDATE Budget"
                    If sBudgetCode = sLastBudgetCode Then
                        sSql = sSql & " SET Actual" & CStr(X) & " = Actual" & CStr(X) & " + " & CStr(nActual)
                    Else
                        sSql = sSql & " SET Actual" & CStr(X) & " = " & CStr(nActual)
                    End If
                    sSql = sSql & " WHERE " & sWhere

                    If Trim(sBudgetCode) <> "" Then
                        If DoSql(sSql, 1) Then
                        End If
                    End If

                    sLastBudgetCode = sBudgetCode

                    nCount = nCount + 1

                Loop

            End If

            ds1.Dispose()

            StartDate = EndDate

        Next X

        'Swap signs on expense Actuals
        sSql = "UPDATE Budget"
        sSql = sSql & " SET Actual1 = Actual1* -1"
        sSql = sSql & " , Actual2 = Actual2 * -1"
        sSql = sSql & " , Actual3 = Actual3 * -1"
        sSql = sSql & " , Actual4 = Actual4 * -1"
        sSql = sSql & " , Actual5 = Actual5 * -1"
        sSql = sSql & " , Actual6 = Actual6 * -1"
        sSql = sSql & " , Actual7 = Actual7 * -1"
        sSql = sSql & " , Actual8 = Actual8 * -1"
        sSql = sSql & " , Actual9 = Actual9 * -1"
        sSql = sSql & " , Actual10 = Actual10 * -1"
        sSql = sSql & " , Actual11 = Actual11 * -1"
        sSql = sSql & " , Actual12 = Actual12 * -1"
        sSql = sSql & " WHERE " & " BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND IncomeExp = 'Expense'"
        If DoSql(sSql, 1) Then
        End If

        'Now reset RefreshReqd flag in dirbud
        sSql = "UPDATE dirbud"
        sSql = sSql & " SET RefreshReqd = 'No'"
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)

        If DoSql(sSql, 1) Then
        End If

        Call SetHourGlassDefault()

        Exit Sub

ErrorRefreshActuals:

        ds.Dispose()
        Call SetHourGlassDefault()

        Exit Sub

    End Sub

    Private Sub RefreshVariance()

        Dim sSql As String
        Dim X As Integer

        On Error GoTo ErrorRefreshVariance

        ' please wait...
        Call SetHourGlassWait()

        'replace null Budget values with zero
        For X = 1 To 12
            sSql = "UPDATE Budget"
            sSql = sSql & " SET Budget" & CStr(X) & " =  0"
            sSql = sSql & " WHERE Budget" & CStr(X) & " =  null"
            If DoSql(sSql, 1) Then
            End If
        Next X

        'get variance for Income
        sSql = "UPDATE Budget"
        sSql = sSql & " SET Variance1 = Actual1 - Budget1"
        sSql = sSql & " , Variance2 = Actual2 - Budget2"
        sSql = sSql & " , Variance3 = Actual3 - Budget3"
        sSql = sSql & " , Variance4 = Actual4 - Budget4"
        sSql = sSql & " , Variance5 = Actual5 - Budget5"
        sSql = sSql & " , Variance6 = Actual6 - Budget6"
        sSql = sSql & " , Variance7 = Actual7 - Budget7"
        sSql = sSql & " , Variance8 = Actual8 - Budget8"
        sSql = sSql & " , Variance9 = Actual9 - Budget9"
        sSql = sSql & " , Variance10 = Actual10 - Budget10"
        sSql = sSql & " , Variance11 = Actual11 - Budget11"
        sSql = sSql & " , Variance12 = Actual12 - Budget12"
        sSql = sSql & " WHERE " & " BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND IncomeExp = 'Income'"
        If DoSql(sSql, 1) Then
        End If

        'get variance for Expense
        sSql = "UPDATE Budget"
        sSql = sSql & " SET Variance1 = Budget1 -Actual1"
        sSql = sSql & " , Variance2 = Budget2 -Actual2"
        sSql = sSql & " , Variance3 = Budget3 -Actual3"
        sSql = sSql & " , Variance4 = Budget4 -Actual4"
        sSql = sSql & " , Variance5= Budget5 -Actual5"
        sSql = sSql & " , Variance6 = Budget6 -Actual6"
        sSql = sSql & " , Variance7 = Budget7 -Actual7"
        sSql = sSql & " , Variance8 = Budget8 -Actual8"
        sSql = sSql & " , Variance9 = Budget9 -Actual9"
        sSql = sSql & " , Variance10 = Budget10 -Actual10"
        sSql = sSql & " , Variance11 = Budget11 -Actual11"
        sSql = sSql & " , Variance12 = Budget12 -Actual12"
        sSql = sSql & " WHERE " & " BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND IncomeExp = 'Expense'"
        If DoSql(sSql, 1) Then
        End If

        Call SetHourGlassDefault()

        Exit Sub

ErrorRefreshVariance:

        Call SetHourGlassDefault()
        Exit Sub

    End Sub

    Private Sub RefreshTotalsxxx()

        'replaced by faster version RefreshTotals2()

        Dim sSql As String = ""
        Dim X As Integer = 0
        Dim y As Integer = 0
        Dim nRecord As Integer
        Dim Actual As Double
        Dim Budget As Double
        Dim Variance As Double
        Dim nCount As Integer = 0
        Dim budgettotals1 As Double = 0
        Dim budgettotals2 As Double = 0
        Dim budgettotals3 As Double = 0

        ' please wait...
        Call SetHourGlassWait()

        'Income
        sSql = ""
        For X = 1 To 12
            sSql = sSql & ", Sum(Actual" & CStr(X) & ") as TotalActual" & CStr(X)
            sSql = sSql & ", Sum(Budget" & CStr(X) & ") as TotalBudget" & CStr(X)
        Next X
        sSql = Mid(sSql, 2, Len(sSql))
        sSql = "SELECT " + sSql
        sSql = sSql & " FROM Budget "
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND IncomeExp = 'Income'"

        Dim adapter1 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds1 As New DataTable
        adapter1.Fill(ds1)

        If ds1.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds1.Rows.Count - 1

                Actual = 0
                Budget = 0
                Variance = 0

                'income
                nRecord = 1
                For X = 1 To 36 Step 3
                    If rdo2Option0.Checked Then 'SSOption2(0).Value Then
                        'budgettotals1 = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))
                        nBudgetTotals(1, X) = IIf(IsDBNull(ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))), 0, (ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))))     'Actual
                        'nBudgetTotals(1, X) = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))      'Actual
                        nBudgetTotals(1, X + 1) = IIf(IsDBNull(ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))), 0, (ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord)))) 'Budget
                        nBudgetTotals(1, X + 2) = nBudgetTotals(1, X) - nBudgetTotals(1, X + 1)         'Actual - Budget
                    ElseIf rdo2Option1.Checked Then 'SSOption2(1).Value Then
                        nBudgetTotals(1, X) = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))      'Actual
                        nBudgetTotals(1, X + 1) = ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))  'Budget
                        Variance = Variance + (nBudgetTotals(1, X) - nBudgetTotals(1, X + 1))           'Actual - Budget    (Accumulate)
                        nBudgetTotals(1, X + 2) = Variance
                    Else
                        Actual = Actual + ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))          'Actual (Accumulate)
                        nBudgetTotals(1, X) = Actual
                        Budget = Budget + ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))          'Budget (Accumulate)
                        nBudgetTotals(1, X + 1) = Budget
                        nBudgetTotals(1, X + 2) = (nBudgetTotals(1, X) - nBudgetTotals(1, X + 1))       'Actual - Budget    (Accumulate)
                    End If
                    nRecord = nRecord + 1
                Next X
                'End If

                nCount = nCount + 1

            Loop

        End If

        ds1.Dispose()

        'Expense
        sSql = ""
        For X = 1 To 12
            sSql = sSql & ", Sum(Actual" & CStr(X) & ") as TotalActual" & CStr(X)
            sSql = sSql & ", Sum(Budget" & CStr(X) & ") as TotalBudget" & CStr(X)
        Next X
        sSql = Mid(sSql, 2, Len(sSql))
        sSql = "SELECT " + sSql
        sSql = sSql & " FROM Budget "
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND IncomeExp = 'Expense'"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                Actual = 0
                Budget = 0
                Variance = 0

                'expense
                nRecord = 1
                For X = 1 To 36 Step 3
                    If rdo2Option0.Checked Then ' thenSSOption2(0).Value Then
                        'nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1  'swap signs
                        nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord))      'Actual
                        'budgettotals2 = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord))
                        nBudgetTotals(2, X + 1) = ds.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))   'Budget
                        nBudgetTotals(2, X + 2) = nBudgetTotals(2, X + 1) - nBudgetTotals(2, X)         'Budget - Actual
                    ElseIf rdo2Option1.Checked Then 'SSOption2(1).Value Then
                        'nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1 'swap signs
                        nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord))       'Actual
                        nBudgetTotals(2, X + 1) = ds.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))   'Budget
                        Variance = Variance + (nBudgetTotals(2, X + 1) - nBudgetTotals(2, X))           'Budget - Actual    (Accumulate)
                        nBudgetTotals(2, X + 2) = Variance
                    Else
                        'Actual = Actual + (ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1)   'swap signs         (Accumulate)
                        Actual = Actual + ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord))           'Actual             (Accumulate)
                        nBudgetTotals(2, X) = Actual
                        Budget = Budget + ds.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))           'Budget             (Accumulate)
                        nBudgetTotals(2, X + 1) = Budget
                        nBudgetTotals(2, X + 2) = (nBudgetTotals(2, X + 1) - nBudgetTotals(2, X))       'Budget - Actual    (Accumulate)
                    End If
                    nRecord = nRecord + 1
                Next X
                nCount = nCount + 1

            Loop

        End If

        ds.Dispose()

        'Totals
        For X = 1 To 36 Step 3
            nBudgetTotals(3, X) = nBudgetTotals(1, X) - nBudgetTotals(2, X)             'Actual
            budgettotals1 = nBudgetTotals(1, X)
            nBudgetTotals(3, X + 1) = nBudgetTotals(1, X + 1) - nBudgetTotals(2, X + 1) 'Budget
            budgettotals2 = nBudgetTotals(2, X + 1)
            nBudgetTotals(3, X + 2) = nBudgetTotals(1, X + 2) + nBudgetTotals(2, X + 2) 'sum variance
            budgettotals3 = nBudgetTotals(3, X + 2)
            'Debug.Print nBudgetTotals(3, X); " ";
        Next X

        'update database with Totals

        '"Totals Income:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(1, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(1, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(1, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '1'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        '"Total Expense:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(2, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(2, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(2, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '2'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        '"Net Total:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(3, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(3, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(3, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '3'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        Call SetHourGlassDefault()

    End Sub

    Private Sub RefreshTotals2()

        Dim sSql As String = ""
        Dim sIncomeExp As String = ""
        Dim X As Integer = 0
        Dim y As Integer = 0
        Dim nRecord As Integer
        Dim Actual As Double
        Dim Budget As Double
        Dim Variance As Double
        Dim nCount As Integer = 0
        Dim budgettotals1 As Double = 0
        Dim budgettotals2 As Double = 0
        Dim budgettotals3 As Double = 0

        ' please wait...
        Call SetHourGlassWait()

        sSql = "SELECT IncomeExp "
        For X = 1 To 12
            sSql = sSql & ", Sum(Actual" & CStr(X) & ") as TotalActual" & CStr(X)
            sSql = sSql & ", Sum(Budget" & CStr(X) & ") as TotalBudget" & CStr(X)
        Next X
        sSql = sSql & " FROM Budget "
        sSql = sSql & " WHERE BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND PeriodFrom = " & AccessDate(gvPeriodFrom)
        'sSql = sSql & " ORDER BY IncomeExp Desc, Code Asc"
        sSql = sSql & " GROUP BY IncomeExp"

        Dim adapter1 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds1 As New DataTable
        adapter1.Fill(ds1)

        If ds1.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds1.Rows.Count - 1

                Actual = 0
                Budget = 0
                Variance = 0

                If ds1.Rows.Item(nCount)("IncomeExp") = "Income" Then

                    'income
                    nRecord = 1
                    For X = 1 To 36 Step 3
                        If rdo2Option0.Checked Then 'SSOption2(0).Value Then
                            nBudgetTotals(1, X) = IIf(IsDBNull(ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))), 0, (ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))))     'Actual
                            nBudgetTotals(1, X + 1) = IIf(IsDBNull(ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))), 0, (ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord)))) 'Budget
                            nBudgetTotals(1, X + 2) = nBudgetTotals(1, X) - nBudgetTotals(1, X + 1)         'Actual - Budget
                        ElseIf rdo2Option1.Checked Then 'SSOption2(1).Value Then
                            nBudgetTotals(1, X) = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))      'Actual
                            nBudgetTotals(1, X + 1) = ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))  'Budget
                            Variance = Variance + (nBudgetTotals(1, X) - nBudgetTotals(1, X + 1))           'Actual - Budget    (Accumulate)
                            nBudgetTotals(1, X + 2) = Variance
                        Else
                            Actual = Actual + ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))          'Actual (Accumulate)
                            nBudgetTotals(1, X) = Actual
                            Budget = Budget + ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))          'Budget (Accumulate)
                            nBudgetTotals(1, X + 1) = Budget
                            nBudgetTotals(1, X + 2) = (nBudgetTotals(1, X) - nBudgetTotals(1, X + 1))       'Actual - Budget    (Accumulate)
                        End If
                        nRecord = nRecord + 1
                    Next X
                Else
                    'expense
                    nRecord = 1
                    For X = 1 To 36 Step 3
                        If rdo2Option0.Checked Then ' thenSSOption2(0).Value Then
                            'nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1  'swap signs
                            nBudgetTotals(2, X) = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))      'Actual
                            nBudgetTotals(2, X + 1) = ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))   'Budget
                            nBudgetTotals(2, X + 2) = nBudgetTotals(2, X + 1) - nBudgetTotals(2, X)         'Budget - Actual
                        ElseIf rdo2Option1.Checked Then 'SSOption2(1).Value Then
                            'nBudgetTotals(2, X) = ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1 'swap signs
                            nBudgetTotals(2, X) = ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))       'Actual
                            nBudgetTotals(2, X + 1) = ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))   'Budget
                            Variance = Variance + (nBudgetTotals(2, X + 1) - nBudgetTotals(2, X))           'Budget - Actual    (Accumulate)
                            nBudgetTotals(2, X + 2) = Variance
                        Else
                            'Actual = Actual + (ds.Rows.Item(nCount)("TotalActual" & CStr(nRecord)) * -1)   'swap signs         (Accumulate)
                            Actual = Actual + ds1.Rows.Item(nCount)("TotalActual" & CStr(nRecord))           'Actual             (Accumulate)
                            nBudgetTotals(2, X) = Actual
                            Budget = Budget + ds1.Rows.Item(nCount)("TotalBudget" & CStr(nRecord))           'Budget             (Accumulate)
                            nBudgetTotals(2, X + 1) = Budget
                            nBudgetTotals(2, X + 2) = (nBudgetTotals(2, X + 1) - nBudgetTotals(2, X))       'Budget - Actual    (Accumulate)
                        End If
                        nRecord = nRecord + 1
                    Next X
                End If
                nCount = nCount + 1
            Loop

        End If

        ds1.Dispose()

        'Totals
        For X = 1 To 36 Step 3
            nBudgetTotals(3, X) = nBudgetTotals(1, X) - nBudgetTotals(2, X)             'Actual
            budgettotals1 = nBudgetTotals(1, X)
            nBudgetTotals(3, X + 1) = nBudgetTotals(1, X + 1) - nBudgetTotals(2, X + 1) 'Budget
            budgettotals2 = nBudgetTotals(2, X + 1)
            nBudgetTotals(3, X + 2) = nBudgetTotals(1, X + 2) + nBudgetTotals(2, X + 2) 'sum variance
            budgettotals3 = nBudgetTotals(3, X + 2)
            'Debug.Print nBudgetTotals(3, X); " ";
        Next X

        'update database with Totals

        '"Totals Income:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(1, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(1, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(1, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '1'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        '"Total Expense:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(2, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(2, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(2, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '2'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        '"Net Total:"
        y = 1
        sSql = "UPDATE Budget SET"
        For X = 1 To 12 'Step 3
            sSql = sSql & "  Actual" & CStr(X) & " = " & CStr(nBudgetTotals(3, y)) & ","
            sSql = sSql & "  Budget" & CStr(X) & " = " & CStr(nBudgetTotals(3, y + 1)) & ","
            sSql = sSql & " Variance" & CStr(X) & " = " & CStr(nBudgetTotals(3, y + 2)) & ","
            y = y + 3
        Next X
        sSql = Mid(sSql, 1, (Len(sSql) - 1))
        sSql = sSql & " WHERE BudgetNo = " & qte("99999999")
        sSql = sSql & " AND BudgetType  = '3'"
        sSql = sSql & " AND PeriodFrom = " & AccessDate("01/01/1999")
        'Debug.Print sSql

        If DoSql(sSql, 1) Then
        End If

        Call SetHourGlassDefault()

    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

        GroupBox2.Visible = True

        rdo3Option0.Checked = False
        rdo3Option0.Enabled = False

        rdo3Option1.Enabled = True
        rdo3Option1.Checked = True

        rdo3Option2.Enabled = True
        rdo3Option2.Checked = False

        cmdRptOk.Visible = True

    End Sub

    Private Sub RefreshBudgetDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            BudgetBindingSource.DataSource = VPBSDataSet.Budget
            bOk = BudgetTableAdapterLive.ClearBeforeFill
            Me.BudgetTableAdapterLive.Fill(Me.VPBSDataSet.Budget)
        ElseIf gsDBName = "Archive" Then
            'added 17/01/17
            BudgetBindingSource.DataSource = VpbsArchiveDataSet.Budget
            bOk = BudgetTableAdapterArc.ClearBeforeFill
            Me.BudgetTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Budget)
        ElseIf gsDBName = "Test" Then
            BudgetBindingSource.DataSource = VPBSTestDataSet.Budget
            bOk = BudgetTableAdapterTest.ClearBeforeFill
            Me.BudgetTableAdapterTest.Fill(Me.VPBSTestDataSet.Budget)
        End If

    End Sub

    Private Sub rdo2Option0_CheckedChanged(sender As Object, e As EventArgs) Handles rdo2Option0.CheckedChanged

        Call RefreshTotals2()
        Call RefreshBudgetDetails()

    End Sub

    Private Sub rdo2Option1_CheckedChanged(sender As Object, e As EventArgs) Handles rdo2Option1.CheckedChanged

        Call RefreshTotals2()
        Call RefreshBudgetDetails()

    End Sub

    Private Sub rdo2Option2_CheckedChanged(sender As Object, e As EventArgs) Handles rdo2Option2.CheckedChanged

        Call RefreshTotals2()
        Call RefreshBudgetDetails()

    End Sub

    Private Sub cmdRptOk_Click(sender As Object, e As EventArgs) Handles cmdRptOk.Click

        Dim sSql As String
        Dim sWhere As String
        Dim sOrderBy As String
        Dim Msg As String
        Dim Title As String
        Dim sFields As String
        Dim iAccumulateType As Integer
        Dim iSemiAnnual As Integer
        Dim nFormula As Integer
        Dim nRetryCount As Integer
        Dim nNumRecords As Integer
        Dim X As Integer

        If gsReportDir = "" Then Exit Sub

        Call SetHourGlassWait()

        On Error GoTo Cmd3DOK_Click_Error

        Call ActualHeadingsReport(GetMonthAsNumber(gsStartMonth))

        If rdo2Option0.Checked = True Then
            iAccumulateType = 0
        ElseIf rdo2Option1.Checked = True Then
            iAccumulateType = 0
        ElseIf rdo2Option2.Checked = True Then
            iAccumulateType = 1
        End If

        If rdo3Option1.Checked = True Then
            iSemiAnnual = 0
        ElseIf rdo3Option2.Checked = True Then
            iSemiAnnual = 1
        End If

        sFields = "Budget.BudgetNo, Budget.BudgetType, Budget.PeriodFrom, Budget.IncomeExp, Budget.Code, "
        sFields = sFields & "DirBud.Description, DirBud.PeriodTo, DirBud.StartMonth, DirPbs.Currency, "
        sFields = sFields & CStr(iAccumulateType) & " as AccumulateType, " & CStr(iSemiAnnual) & " as SemiAnnual, "

        For X = 1 To 12
            If X > 1 Then sFields = sFields & ", "
            sFields = sFields & "Budget.Budget" & CStr(X) & ", "
            sFields = sFields & "Budget.Actual" & CStr(X)
        Next X

        Call DropTable("BudTransTemp")

        sSql = "SELECT " & sFields & " INTO BudTransTemp"
        sSql = sSql & " FROM Budget, DirBud, DirPbs,"
        sSql = sSql & " Budget LEFT JOIN DirBud"
        sSql = sSql & " ON DirBud.BudgetNo = Budget.BudgetNo"
        sSql = sSql & " AND DirBud.BudgetType = Budget.BudgetType"
        sSql = sSql & " AND DirBud.PeriodFrom = Budget.PeriodFrom,"
        sSql = sSql & " DirBud LEFT JOIN DirPbs"
        sSql = sSql & " ON DirBud.BudgetNo = DirPbs.AccountNo"              'get currency from parent account
        sSql = sSql & " WHERE Budget.BudgetNo = " & qte(gsBudgetNo)
        sSql = sSql & " AND Budget.BudgetType = " & qte(gsBudgetType)
        sSql = sSql & " AND Budget.PeriodFrom = " & AccessDate(gvPeriodFrom)
        sSql = sSql & " AND Budget.IncomeExp IN('Income',  'Expense')"
        sSql = sSql & " ORDER BY Budget.IncomeExp Desc, Budget.Code Asc"


        If DoSql(sSql, 1) Then
            'Debug.Print sSql
            'sSql = "SELECT Count(*) as NumRecords FROM BudTransTemp"
            'snBudget = gDBMain.OpenRecordset(sSql, dbOpenSnapshot)
            'nNumRecords = snBudget("NumRecords")
            'snBudget.Close()

            'If nNumRecords > 0 Then
            'signs removed from Expense records in RefreshActuals()
            '            'remove - signs from expense records
            '            sSql = "UPDATE BudTransTemp"
            '            sSql = sSql & " SET "
            '            For x = 1 To 12
            '                If x > 1 Then sSql = sSql & ", "
            '                sSql = sSql & "BudTransTemp.Actual" & CStr(x) & " = " & "BudTransTemp.Actual" & CStr(x) & " * -1"
            '            Next x
            '            sSql = sSql & " WHERE BudTransTemp.IncomeExp = 'Expense'"
            '            If DoSql(gDBMain, sSql, True) Then
            '            End If

            'Report1.DataFiles(0) = gsDBFileName

            'set up headings
            For nFormula = 0 To 17
                If iSemiAnnual = 0 Then     'first six months
                    AxCrystalReport2.set_Formulas(nFormula, "Heading" & Format(nFormula + 1, "0#") & " = '" & msColumnName(nFormula + 1) & "'")
                Else                                        'second six months
                    AxCrystalReport2.set_Formulas(nFormula, "Heading" & Format(nFormula + 1, "0#") & " = '" & msColumnName(nFormula + 19) & "'")
                End If
            Next nFormula

            If gsDBName = "Live" Then
                AxCrystalReport2.ReportFileName = gsReportDir & "\pbsBudA.rpt"
            Else
                AxCrystalReport2.ReportFileName = gsReportDir & "\pbsBudB.rpt"
            End If

            AxCrystalReport2.ReportSource = 0        'use rpt format
            AxCrystalReport2.Destination = 0            'Screen
            'Call SetPrinterOrient(LANDSCAPE)
            AxCrystalReport2.Action = 1                    'Do it
            'Call ReSetPrinterOrient()
            'Else
            'Msg = " No records selected"
            'Title = "Actual v Budget"
            'MsgBox(Msg, vbExclamation, Title)
            'End If

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

Cmd3DOK_Click_Error:

        Call MsgBox("Print Report", sSql)
        On Error GoTo 0
        Call SetHourGlassDefault()

        Exit Sub

    End Sub

End Class