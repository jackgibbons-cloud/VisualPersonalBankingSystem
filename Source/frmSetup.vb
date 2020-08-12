'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2017
'
'Setup - Account, Bank, Customer, User Names, Analysis, GL codes, Budgets, Currencies
'****************************************************************************************************************************
'
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'24/12/15   jpg     Created from Vpbs78
'                   Added datasources, datagrid, New/Change/Delete
'31/12/15   jpg     Completed
'17/01/16   jpg     Added Archive dataset...
'****************************************************************************************************************************
Public Class frmSetup

    Dim miUpdate As Integer = Nothing
    Dim miChgPW As Boolean = False

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"
            Me.AccountNamesTableAdapterLive.Fill(Me.VPBSDataSet.AccountNames)
            Me.BankNamesTableAdapterLive.Fill(Me.VPBSDataSet.BankNames)
            Me.CustomersTableAdapterLive.Fill(Me.VPBSDataSet.Customers)
            Me.UsersTableAdapterLive.Fill(Me.VPBSDataSet.Users)

            Me.AnalysisTableAdapterLive.Fill(Me.VPBSDataSet.Analysis)
            Me.GLCodeTableAdapterLive.Fill(Me.VPBSDataSet.GLCode)
            Me.DirbudTableAdapterLive.Fill(Me.VPBSDataSet.dirbud)
            Me.CurrenciesTableAdapterLive.Fill(Me.VPBSDataSet.Currencies)

            AccountNamesBindingSource.DataSource = VPBSDataSet
            BankNamesBindingSource.DataSource = VPBSDataSet
            CustomersBindingSource.DataSource = VPBSDataSet
            UsersBindingSource.DataSource = VPBSDataSet

            AnalysisBindingSource.DataSource = VPBSDataSet
            GLCodeBindingSource.DataSource = VPBSDataSet
            DirbudBindingSource.DataSource = VPBSDataSet
            CurrenciesBindingSource.DataSource = VPBSDataSet

        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"
            Me.AccountNamesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.AccountNames)
            Me.BankNamesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.BankNames)
            Me.CustomersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Customers)
            Me.UsersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Users)

            Me.AnalysisTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Analysis)
            Me.GLCodeTableAdapterArc.Fill(Me.VpbsArchiveDataSet.GLCode)
            Me.DirbudTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirbud)
            Me.CurrenciesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Currencies)

            AccountNamesBindingSource.DataSource = VpbsArchiveDataSet
            BankNamesBindingSource.DataSource = VpbsArchiveDataSet
            CustomersBindingSource.DataSource = VpbsArchiveDataSet
            UsersBindingSource.DataSource = VpbsArchiveDataSet

            AnalysisBindingSource.DataSource = VpbsArchiveDataSet
            GLCodeBindingSource.DataSource = VpbsArchiveDataSet
            DirbudBindingSource.DataSource = VpbsArchiveDataSet
            CurrenciesBindingSource.DataSource = VpbsArchiveDataSet

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"
            Me.AccountNamesTestTableAdapter.Fill(Me.VPBSTestDataSet.AccountNames)
            Me.BankNamesTestTableAdapter.Fill(Me.VPBSTestDataSet.BankNames)
            Me.CustomersTestTableAdapter.Fill(Me.VPBSTestDataSet.Customers)
            Me.UsersTestTableAdapter.Fill(Me.VPBSTestDataSet.Users)

            Me.AnalysisTestTableAdapter.Fill(Me.VPBSTestDataSet.Analysis)
            Me.GLCodeTestTableAdapter.Fill(Me.VPBSTestDataSet.GLCode)
            Me.DirbudTestTableAdapter.Fill(Me.VPBSTestDataSet.dirbud)
            Me.CurrenciesTestTableAdapter.Fill(Me.VPBSTestDataSet.Currencies)

            AccountNamesBindingSource.DataSource = VPBSTestDataSet
            BankNamesBindingSource.DataSource = VPBSTestDataSet
            CustomersBindingSource.DataSource = VPBSTestDataSet
            UsersBindingSource.DataSource = VPBSTestDataSet

            AnalysisBindingSource.DataSource = VPBSTestDataSet
            GLCodeBindingSource.DataSource = VPBSTestDataSet
            DirbudBindingSource.DataSource = VPBSTestDataSet
            CurrenciesBindingSource.DataSource = VPBSTestDataSet

        End If

        cboBudgetType.Items.Clear()
        cboBudgetType.Items.Add("Analysis")
        cboBudgetType.Items.Add("GLCode")

        cboStartMonth.Items.Clear()
        For X = 0 To 11
            cboStartMonth.Items.Add(GetMonthAsString(X + 1))
        Next X

        cboRefresh.Items.Clear()
        cboRefresh.Items.Add("Yes")
        cboRefresh.Items.Add("No")

        cboActivate.Items.Clear()
        cboActivate.Items.Add("Yes")
        cboActivate.Items.Add("No")


        Call DisableFields()

        If gsTb = 8 Then
            'change Password
            gsTb = 3
            miChgPW = True
        End If

        ' select correct tab on Load
        If gsTb = 0 Then
            Call TabControl1_SelectedIndexChanged(AcceptButton, e)
        Else
            TabControl1.SelectedIndex = gsTb
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        '
        'assign correct Table name for selected Tab
        '
        Select Case TabControl1.SelectedIndex

            Case 0 '"AccountNames"
                'TabControl1.SelectTab(2)
                Me.Text = "VPBS - Setup Account Names"
                gsTb = "AccountNames"

            Case 1 '"BankNames"
                'TabControl1.SelectTab(3)
                Me.Text = "VPBS - Setup Bank Names"
                gsTb = "BankNames"

            Case 2 '"Customers"
                'TabControl1.SelectTab(9)
                Me.Text = "VPBS - Setup Customer Names"
                gsTb = "Customers"

            Case 3 '"Users"
                'TabControl1.SelectTab(4)
                If miChgPW = False Then
                    Me.Text = "VPBS - Setup User Names"
                    txtAddPassword.Visible = True
                    txtVerifyPassword.Visible = True
                    txtOldPassword.Visible = False
                    txtNewPassword.Visible = False
                    lblAddPassword.Visible = True
                    lblVerifyPassword.Visible = True
                    lblCurrentPassword.Visible = False
                    lblChangePassword.Visible = False
                Else
                    Me.Text = "VPBS - Change Password"
                    txtUserLevel.Enabled = False
                    txtAddPassword.Visible = False
                    txtVerifyPassword.Visible = False
                    txtOldPassword.Visible = True
                    txtNewPassword.Visible = True
                    lblAddPassword.Visible = False
                    lblVerifyPassword.Visible = False
                    lblCurrentPassword.Visible = True
                    lblChangePassword.Visible = True
                    txtUserLevel.Enabled = False
                    CmdNew.Enabled = False
                    CmdDelete.Enabled = False
                End If
                gsTb = "Users"

            Case 4 '"Analysis"
                'TabControl1.SelectTab(0)
                Me.Text = "VPBS - Setup Analysis Codes"
                gsTb = "Analysis"

            Case 5 '"GLCode"
                'TabControl1.SelectTab(1)
                Me.Text = "VPBS - Setup General Ledger Codes"
                gsTb = "GLCode"

            Case 6 '"Budget"
                'TabControl1.SelectTab(5)
                Me.Text = "VPBS - Setup Budgets"
                gsTb = "dirBud"

            Case 7 '"Currencies"
                'TabControl1.SelectTab(8)
                Me.Text = "VPBS - Setup Currencies"
                gsTb = "Currencies"

        End Select

    End Sub

    Private Sub cboStartMonth_LostFocus(sender As Object, e As EventArgs) Handles cboStartMonth.LostFocus

        Dim sMonth As String = Nothing
        Dim sYear As String = Nothing

        sMonth = "00" + CStr(GetMonthAsNumber(cboStartMonth.Text))
        sMonth = Mid(sMonth, Len(sMonth) - 1, 2)
        sYear = DatePart("yyyy", Today)
        txtPeriodFrom.Text = "01/" & sMonth & "/" & sYear

    End Sub

    Private Sub txtPeriodFrom_LostFocus(sender As Object, e As EventArgs) Handles txtPeriodFrom.LostFocus

        Dim Msg, Title
        Dim sEndDay As String = Nothing
        Dim sEndMonth As String = Nothing
        Dim EndYear As Integer
        Dim EndMonth As Integer
        Dim EndDay As Integer

        If cboStartMonth.Text = "" Then Exit Sub

        If Not (IsDate(txtPeriodFrom.Text)) Then
            Msg = " Date error - please rectify"
            Title = "Enter Period From date"
            MsgBox(Msg, vbExclamation, Title)
            txtPeriodFrom.Focus()
            Exit Sub
        End If

        'If Val(DatePart("dd", txtPeriodFrom.Text)) = 1 Then 'cannot use Day('Date') nor DatePart!
        If Val(Mid(txtPeriodFrom.Text, 1, 2)) = 1 Then
            EndYear = Year(txtPeriodFrom.Text)
            If Month(txtPeriodFrom.Text) > 1 Then EndYear = EndYear + 1
            EndMonth = Month(txtPeriodFrom.Text) + 11
            If EndMonth > 12 Then EndMonth = EndMonth - 12
            EndDay = Val(Mid$(gsDaysPerMonth, EndMonth * 2, 2))
        Else
            EndYear = Year(txtPeriodFrom.Text) + 1
            EndMonth = Month(txtPeriodFrom.Text) + 12
            If EndMonth > 12 Then EndMonth = EndMonth - 12
            'EndDay = Val(DatePart("dd", txtPeriodFrom.Text)) - 1 'cannot use Day('Date') nor DatePart!
            EndDay = Val(Mid(txtPeriodFrom.Text, 1, 2)) - 1
            If EndDay = 0 Then
                EndMonth = EndMonth - 1
                If EndMonth = 0 Then EndMonth = 12
                EndDay = Val(Mid$(gsDaysPerMonth, EndMonth * 2, 2))
            End If
        End If

        sEndMonth = "00" + CStr(EndMonth)
        sEndMonth = Mid(sEndMonth, Len(sEndMonth) - 1, 2)

        txtPeriodTo.Text = CStr(EndDay) & "/" & sEndMonth & "/" & CStr(EndYear)

    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click

        Call EnableFields()
        Call NullFields()

        Select Case gsTb

            Case "AccountNames"
                txtShortAccountName.Enabled = True
                txtShortAccountName.Focus()

            Case "BankNames"
                txtShortBankName.Enabled = True
                txtShortBankName.Focus()

            Case "Customers"
                txtShortCustName.Enabled = True
                txtShortCustName.Focus()

            Case "Users"
                txtUserName.Enabled = True
                txtUserName.Focus()
                txtAddPassword.Visible = True
                txtVerifyPassword.Visible = True
                txtAddPassword.Enabled = True
                txtVerifyPassword.Enabled = True

                txtOldPassword.Visible = False
                txtNewPassword.Visible = False
                lblAddPassword.Visible = True
                lblVerifyPassword.Visible = True
                lblCurrentPassword.Visible = False
                lblChangePassword.Visible = False

            Case "Analysis"
                txtAnalysisCode.Enabled = True
                txtAnalysisCode.Focus()

            Case "GLCode"
                txtGLCodeCode.Enabled = True
                txtGLCodeCode.Focus()

            Case "dirBud"
                txtBudgetNo.Enabled = True
                txtBudgetNo.Focus()

            Case "Currencies"
                txtCurrencyCode.Enabled = True
                txtCurrencyCode.Focus()

        End Select

        miUpdate = giADD

        CmdNew.Enabled = False
        cmdChange.Enabled = False
        CmdDelete.Enabled = False
        cmdOk.Enabled = True
        cmdCancel.Enabled = True
        cmdClose.Enabled = False

    End Sub

    Private Sub cmdChange_Click(sender As Object, e As EventArgs) Handles cmdChange.Click

        Call EnableFields()

        Select Case gsTb

            Case "AccountNames"
                Call GetDataFromDataGridViewAccountNames()
                txtShortAccountName.Enabled = False
                txtAccountName.Focus()

            Case "BankNames"
                Call GetDataFromDataGridViewBankNames()
                txtShortBankName.Enabled = False
                txtBankName.Focus()

            Case "Customers"
                Call GetDataFromDataGridViewCustomers()
                txtShortCustName.Enabled = False
                txtCustName.Focus()

            Case "Users"
                Call GetDataFromDataGridViewUsers()
                txtUserName.Enabled = False
                txtUserLevel.Focus()
                If miChgPW = True Then
                    txtUserLevel.Enabled = False
                Else
                    txtUserLevel.Focus()
                End If
                txtAddPassword.Visible = False
                txtVerifyPassword.Visible = False
                txtOldPassword.Visible = True
                txtNewPassword.Visible = True
                lblAddPassword.Visible = False
                lblVerifyPassword.Visible = False
                lblCurrentPassword.Visible = True
                lblChangePassword.Visible = True

            Case "Analysis"
                Call GetDataFromDataGridViewAnalysisCodes()
                txtAnalysisCode.Enabled = False
                txtAnalysisCode.Focus()

            Case "GLCode"
                Call GetDataFromDataGridViewGLCodes()
                txtGLCodeCode.Enabled = False
                txtGLCodeDesc.Focus()

            Case "dirBud"
                Call GetDataFromDataGridViewBudgets()
                txtBudgetNo.Enabled = False
                txtBudgetDesc.Focus()

            Case "Currencies"
                Call GetDataFromDataGridViewCurrencies()
                txtCurrencyCode.Enabled = False
                txtCurrencyDesc.Focus()

        End Select

        miUpdate = giCHANGE

        CmdNew.Enabled = False
        cmdChange.Enabled = False
        CmdDelete.Enabled = False
        cmdOk.Enabled = True
        cmdCancel.Enabled = True
        cmdClose.Enabled = False

    End Sub

    Private Sub GetDataFromDataGridViewAnalysisCodes()

        'Analysis Codes
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewAnalysisCodes.SelectedCells.Count - 1)

            sName = DataGridViewAnalysisCodes.Columns(counter).HeaderText.ToString

            If DataGridViewAnalysisCodes.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewAnalysisCodes.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "Code"
                        txtAnalysisCode.Text = value
                    Case "Description"
                        txtAnalysisDesc.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewGLCodes()

        'Analysis Codes
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewGLCodes.SelectedCells.Count - 1)

            sName = DataGridViewGLCodes.Columns(counter).HeaderText.ToString

            If DataGridViewGLCodes.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewGLCodes.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "Code"
                        txtGLCodeCode.Text = value
                    Case "Description"
                        txtGLCodeDesc.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewAccountNames()

        'AccountNames
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewAccountNames.SelectedCells.Count - 1)

            sName = DataGridViewAccountNames.Columns(counter).HeaderText.ToString

            If DataGridViewAccountNames.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewAccountNames.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "ShortName"
                        txtShortAccountName.Text = value
                    Case "Name"
                        txtAccountName.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewBankNames()

        'BankNames
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewBankNames.SelectedCells.Count - 1)

            sName = DataGridViewBankNames.Columns(counter).HeaderText.ToString

            If DataGridViewBankNames.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewBankNames.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "ShortName"
                        txtShortBankName.Text = value
                    Case "Name"
                        txtBankName.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewCustomers()

        'Customers
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewCustomers.SelectedCells.Count - 1)

            sName = DataGridViewCustomers.Columns(counter).HeaderText.ToString

            If DataGridViewCustomers.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewCustomers.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "ShortName"
                        txtShortCustName.Text = value
                    Case "Name"
                        txtCustName.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewUsers()

        'Users
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewUsers.SelectedCells.Count - 1)

            sName = DataGridViewUsers.Columns(counter).HeaderText.ToString

            If DataGridViewUsers.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewUsers.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "UserName"
                        txtUserName.Text = value
                    Case "UserLevel"
                        txtUserLevel.Text = value
                    Case "Password"
                        txtOldPassword.Text = DeCrypt(value)
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewBudgets()

        'DirBud
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewBudgets.SelectedCells.Count - 1)

            sName = DataGridViewBudgets.Columns(counter).HeaderText.ToString

            If DataGridViewBudgets.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewBudgets.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "BudgetNo"
                        txtBudgetNo.Text = value
                    Case "BudgetType"
                        cboBudgetType.Text = value
                    Case "Description"
                        txtBudgetDesc.Text = value
                    Case "PeriodFrom"
                        txtPeriodFrom.Text = value
                    Case "PeriodTo"
                        txtPeriodTo.Text = value
                    Case "StartMonth"
                        cboStartMonth.Text = value
                    Case "Status"
                        cboActivate.Text = value
                    Case "RefreshReqd"
                        cboRefresh.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub GetDataFromDataGridViewCurrencies()

        'Currencies
        Dim sName As String

        ' Iterate through the SelectedCells collection and extract the values.
        For counter = 0 To (DataGridViewCurrencies.SelectedCells.Count - 1)

            sName = DataGridViewCurrencies.Columns(counter).HeaderText.ToString

            If DataGridViewCurrencies.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                value = DataGridViewCurrencies.SelectedCells(counter) _
                    .FormattedValue.ToString()

                Select Case sName

                    Case "Code"
                        txtCurrencyCode.Text = value
                    Case "Description"
                        txtCurrencyDesc.Text = value
                    Case "Rate"
                        txtRate.Text = value
                        'Case "Date"
                        'txtDate.Text = value
                    Case "Type"
                        txtDorM.Text = value
                    Case "DecimalPlaces"
                        txtDecPlaces.Text = value
                    Case "BaseCCY"
                        txtBaseCCY.Text = value
                    Case Else

                End Select

            End If

        Next

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click

        Dim sSql As String
        Dim Style As Short
        Dim Msg As String
        Dim Response As Short
        Dim Title As String

        Call SetHourGlassWait()

        Select Case gsTb

            Case "AccountNames"

                Call GetDataFromDataGridViewAccountNames()

                Msg = " Confirm deletion of Account Name "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Account Name " + txtBankName.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected AccountName in AccountNames
                    sSql = "Delete From AccountNames Where ShortName = " & qte(CStr(txtShortAccountName.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected Account Name NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected Account Name NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "BankNames"

                Call GetDataFromDataGridViewBankNames()

                Msg = " Confirm deletion of Bank Name "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Bank Name " + txtBankName.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected BankName in BankNames
                    sSql = "Delete From BankNames Where ShortName = " & qte(CStr(txtShortBankName.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected BankName NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected BankName NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "Customers"

                Call GetDataFromDataGridViewCustomers()

                Msg = " Confirm deletion of Customer Name "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Customer Name " + txtCustName.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected CustomerName in Customers
                    sSql = "Delete From Customers Where ShortName = " & qte(CStr(txtShortCustName.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected Customer Name NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected Customer Name NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "Users"

                Call GetDataFromDataGridViewUsers()

                Msg = " Confirm deletion of User Name "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete User Name " + txtCustName.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected User Name in UserNames
                    sSql = "Delete From Users Where UserName = " & qte(CStr(txtUserName.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected User Name NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected User Name NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "Analysis"

                Call GetDataFromDataGridViewAnalysisCodes()

                Msg = " Confirm deletion of Analysis Code "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Analysis Code " + txtAnalysisCode.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected Analysis Code in Analysis
                    sSql = "Delete From Analysis Where Code = " & qte(CStr(txtAnalysisCode.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected Analysis Code NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected Analysis Code NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "GLCode"

                Call GetDataFromDataGridViewGLCodes()

                Msg = " Confirm deletion of GL Code "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete GL Code " + txtGLCodeCode.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected GL Code in GLCode
                    sSql = "Delete From GLCode Where Code = " & qte(CStr(txtGLCodeCode.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected GL Code NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected GL Code NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "dirBud"

                Call GetDataFromDataGridViewBudgets()

                Msg = " Confirm deletion of Budget "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Budget " + txtBudgetNo.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected Budget in dirBud
                    sSql = "Delete From dirBud"
                    sSql = sSql + " Where BudgetNo = " & qte(CStr(txtBudgetNo.Text))
                    sSql = sSql + " And BudgetType = " & qte(CStr(cboBudgetType.Text))
                    sSql = sSql + " And PeriodFrom = " & AccessDate(txtPeriodFrom.Text)
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected Budget NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected Budget NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

            Case "Currencies"

                Call GetDataFromDataGridViewCurrencies()

                Msg = " Confirm deletion of Currency "
                Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                Title = "Delete Currency " + txtCurrencyCode.Text
                Response = MsgBox(Msg, Style, Title)

                If Response = MsgBoxResult.Yes Then
                    'now delete selected Currency in Currencies
                    sSql = "Delete From Currencies Where Code = " & qte(CStr(txtCurrencyCode.Text))
                    If Not DoSql(sSql, 1) Then
                        Msg = "Currently selected Currency NOT deleted"
                        MsgBox(Msg, vbExclamation, Title)
                    End If
                Else
                    Msg = "Currently selected Currency NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If

        End Select

        Call RefreshDetails()

        Call NullFields()
        Call DisableFields()

        Call SetHourGlassDefault()

        CmdNew.Enabled = True
        cmdChange.Enabled = True
        CmdDelete.Enabled = True
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

        miUpdate = False

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        Dim sSql As String = Nothing
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        'Validate
        Select Case gsTb

            Case "AccountNames"
                If Trim(txtShortAccountName.Text) = "" Then
                    MessageBox.Show("Short Name cannot be blank")
                    txtShortAccountName.Focus()
                    Exit Sub
                End If

                If Trim(txtAccountName.Text) = "" Then
                    MessageBox.Show("Account Name cannot be blank")
                    txtAccountName.Focus()
                    Exit Sub
                End If

            Case "BankNames"
                If Trim(txtShortBankName.Text) = "" Then
                    MessageBox.Show("Short Name cannot be blank")
                    txtShortBankName.Focus()
                    Exit Sub
                End If

                If Trim(txtBankName.Text) = "" Then
                    MessageBox.Show("Bank Name cannot be blank")
                    txtBankName.Focus()
                    Exit Sub
                End If

            Case "Customers"
                If Trim(txtShortCustName.Text) = "" Then
                    MessageBox.Show("Short Name cannot be blank")
                    txtShortCustName.Focus()
                    Exit Sub
                End If

                If Trim(txtCustName.Text) = "" Then
                    MessageBox.Show("Customer Name cannot be blank")
                    txtCustName.Focus()
                    Exit Sub
                End If

            Case "Users"

                If Trim(txtUserName.Text) = "" Then
                    MessageBox.Show("User Name cannot be blank")
                    txtUserName.Focus()
                    Exit Sub
                End If

                If Trim(txtUserLevel.Text) = "" Then
                    MessageBox.Show("User Level cannot be blank")
                    txtUserLevel.Focus()
                    Exit Sub
                End If

                Select Case miUpdate

                    Case giADD

                        If txtAddPassword.Text = "" Or txtVerifyPassword.Text = "" Then
                            MessageBox.Show("You must enter and verify a password")
                            txtAddPassword.Focus()
                            Exit Sub
                        End If

                        'check new & verify passwords are the same
                        If txtAddPassword.Text <> txtVerifyPassword.Text Then
                            MessageBox.Show("New and Verify passwords don't match - please re-enter")
                            txtAddPassword.Focus()
                            Exit Sub
                        End If

                    Case giCHANGE

                        If txtOldPassword.Text = "" Or txtNewPassword.Text = "" Then
                            MessageBox.Show("One or more Passwords are blank - please re-enter")
                            txtOldPassword.Focus()
                            Exit Sub
                        End If

                    Case Else

                End Select

            Case "Analysis"
                If Trim(txtAnalysisCode.Text) = "" Then
                    MessageBox.Show("Analysis Code cannot be blank")
                    txtAnalysisCode.Focus()
                    Exit Sub
                End If

                If Trim(txtAnalysisDesc.Text) = "" Then
                    MessageBox.Show("Analysis Description cannot be blank")
                    txtAnalysisDesc.Focus()
                    Exit Sub
                End If

            Case "GLCode"
                If Trim(txtGLCodeCode.Text) = "" Then
                    MessageBox.Show("GL Code cannot be blank")
                    txtGLCodeCode.Focus()
                    Exit Sub
                End If

                If Trim(txtGLCodeDesc.Text) = "" Then
                    MessageBox.Show("GL Code Description cannot be blank")
                    txtGLCodeDesc.Focus()
                    Exit Sub
                End If

            Case "dirBud"

                If txtBudgetNo.Text = "" Then
                    Msg = " Budget number error - please rectify"
                    Title = "Enter Budget number"
                    MessageBox.Show(Msg)
                    txtBudgetNo.Focus()
                    Exit Sub
                End If

                If cboBudgetType.Text = "" Or InStr("Analysis.Account.GLCode", cboBudgetType.Text) = 0 Then
                    Msg = " Budget type error - please rectify"
                    Title = "Enter Budget type"
                    MessageBox.Show(Msg)
                    cboBudgetType.Focus()
                    Exit Sub
                End If

                If Not (IsDate(txtPeriodFrom.Text)) Then
                    Msg = " Date error - please rectify"
                    Title = "Enter Period from date"
                    MessageBox.Show(Msg)
                    txtPeriodFrom.Focus()
                    Exit Sub
                End If

                If Not (IsDate(txtPeriodTo.Text)) Then
                    Msg = " Date error - please rectify"
                    Title = "Enter Period to date"
                    MessageBox.Show(Msg)
                    txtPeriodTo.Focus()
                    Exit Sub
                End If

                If cboStartMonth.Text = "" Or Month(txtPeriodFrom.Text) <> GetMonthAsNumber(cboStartMonth.Text) Then
                    cboStartMonth.Text = GetMonthAsString(Month(txtPeriodFrom.Text))
                End If

                If cboActivate.Text <> "Yes" Then
                    cboActivate.Text = "No"
                End If

                If cboRefresh.Text <> "Yes" Then
                    cboRefresh.Text = "No"
                End If

            Case "Currencies"
                If txtCurrencyCode.Text = "" Then
                    Msg = " Currency code may not be blank - please rectify"
                    Title = "Enter Currency code"
                    MessageBox.Show(Msg)
                    txtCurrencyCode.Focus()
                    Exit Sub
                End If

                txtCurrencyCode.Text = UCase(txtCurrencyCode.Text)

                If txtCurrencyDesc.Text = "" Then
                    Msg = " Currency Description may not be blank - please rectify"
                    Title = "Enter Currency Description"
                    MessageBox.Show(Msg)
                    txtCurrencyDesc.Focus()
                    Exit Sub
                End If

                If txtRate.Text = "" Then
                    Msg = " Currency rate may not be blank - please rectify"
                    Title = "Enter Currency rate"
                    MessageBox.Show(Msg)
                    txtRate.Focus()
                    Exit Sub
                End If

                If txtDorM.Text = "" Then
                    txtDorM.Text = "D"
                Else
                    txtDorM.Text = UCase(txtDorM.Text)
                    If InStr("DM", txtDorM.Text) = 0 Then
                        txtDorM.Text = "D"
                    End If
                End If

                If txtDecPlaces.Text = "" Then
                    txtDecPlaces.Text = "2"
                Else
                    If Not IsNumeric(txtDecPlaces.Text) Then
                        txtDecPlaces.Text = "2"
                    End If
                End If

                If txtBaseCCY.Text = "" Then
                    txtBaseCCY.Text = "N"
                Else
                    txtBaseCCY.Text = UCase(txtBaseCCY.Text)
                    If InStr("YN", txtBaseCCY.Text) = 0 Then
                        txtBaseCCY.Text = "N"
                    End If
                End If

                'if this is now the base ccy then make sure there are no others
                If txtBaseCCY.Text = "Y" Then
                    sSql = "UPDATE Currencies"
                    sSql = sSql & " SET BaseCCY = 'N'"
                    sSql = sSql & " WHERE Code <> " & qte(txtCurrencyCode.Text)
                    If DoSql(sSql, 1) Then
                    End If
                    Call GetBaseCCY()
                End If

        End Select

        Select Case miUpdate
            Case giADD
                Call AddRecord()
            Case giCHANGE
                Call EditRecord()
        End Select

        'reload data from DB
        Call RefreshDetails()

        TabControl1.Enabled = True

        CmdNew.Enabled = True
        cmdChange.Enabled = True
        CmdDelete.Enabled = True
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

        Call NullFields()
        Call DisableFields()

        miUpdate = False

    End Sub

    Private Sub AddRecord()

        Dim sSql As String = Nothing
        Dim bOk As Boolean

        '
        'Add Record to db
        '
        Select Case gsTb

            Case "Analysis"
                sSql = "Insert into Analysis"
                sSql = sSql + " (Code, Description)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtAnalysisCode.Text)
                sSql = sSql + ", " + qte(txtAnalysisDesc.Text)
                sSql = sSql + ")"

            Case "GLCode"
                sSql = "Insert into GLCode"
                sSql = sSql + " (Code, Description)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtGLCodeCode.Text)
                sSql = sSql + ", " + qte(txtGLCodeDesc.Text)
                sSql = sSql + ")"

            Case "AccountNames"
                sSql = "Insert into AccountNames"
                sSql = sSql + " (ShortName, Name)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtShortAccountName.Text)
                sSql = sSql + ", " + qte(txtAccountName.Text)
                sSql = sSql + ")"

            Case "BankNames"
                sSql = "Insert into BankNames"
                sSql = sSql + " (ShortName, Name)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtShortBankName.Text)
                sSql = sSql + ", " + qte(txtBankName.Text)
                sSql = sSql + ")"

            Case "Customers"
                sSql = "Insert into Customers"
                sSql = sSql + " (ShortName, Name)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtShortCustName.Text)
                sSql = sSql + ", " + qte(txtCustName.Text)
                sSql = sSql + ")"

            Case "Users"
                sSql = "Insert into Users"
                sSql = sSql + " (UserName, UserLevel, Password)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtUserName.Text)
                sSql = sSql + ", " + qte(txtUserLevel.Text)
                sSql = sSql + ", " + qte(Encrypt(txtNewPassword.Text)) 'encrypt
                sSql = sSql + ")"

            Case "dirBud"
                sSql = "Insert into dirBud"
                sSql = sSql + " (BudgetNo, BudgetType, Description"
                sSql = sSql + ", PeriodFrom, PeriodTo, StartMonth"
                sSql = sSql + ", Status, RefreshReqd)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtBudgetNo.Text)
                sSql = sSql + ", " + qte(cboBudgetType.Text)
                sSql = sSql + ", " + qte(txtBudgetDesc.Text)
                sSql = sSql + ", " + AccessDate(txtPeriodFrom.Text)
                sSql = sSql + ", " + AccessDate(txtPeriodTo.Text)
                sSql = sSql + ", " + qte(cboStartMonth.Text)
                sSql = sSql + ", " + qte(cboActivate.Text)
                sSql = sSql + ", " + qte(cboRefresh.Text)
                sSql = sSql + ")"

            Case "Currencies"

                sSql = "Insert into Currencies"
                sSql = sSql + " (Code, Description"
                sSql = sSql + ", Rate, Date, Type"
                sSql = sSql + ", DecimalPlaces, BaseCCY)"
                sSql = sSql + " Values ("
                sSql = sSql + "  " + qte(txtCurrencyCode.Text)
                sSql = sSql + ", " + qte(txtCurrencyDesc.Text)
                sSql = sSql + ", " + qte(txtRate.Text)
                sSql = sSql + ", " + AccessDate(Date.Parse(Today))
                sSql = sSql + ", " + qte(txtDorM.Text)
                sSql = sSql + ", " + qte(txtDecPlaces.Text)
                sSql = sSql + ", " + qte(txtBaseCCY.Text)
                sSql = sSql + ")"

            Case Else

        End Select
        '
        'ok, let's do it
        '
        If gsTb = "Users" Then
            bOk = DoStartUpSql(sSql, 1)
        Else
            bOk = DoSql(sSql, 1)
        End If

    End Sub

    Private Sub EditRecord()

        Dim sSql As String = Nothing
        Dim bOk As Boolean

        '
        'Update Record in db
        '
        Select Case gsTb

            Case "AccountNames"
                sSql = "Update AccountNames"
                sSql = sSql + " Set Name = " + qte(txtAccountName.Text)
                sSql = sSql + " Where ShortName = " + qte(txtShortAccountName.Text)

            Case "BankNames"
                sSql = "Update BankNames"
                sSql = sSql + " Set Name = " + qte(txtBankName.Text)
                sSql = sSql + " Where ShortName = " + qte(txtShortBankName.Text)

            Case "Customers"
                sSql = "Update Customers"
                sSql = sSql + " Set Name = " + qte(txtCustName.Text)
                sSql = sSql + " Where ShortName = " + qte(txtShortCustName.Text)

            Case "Users"
                sSql = "Update Users"
                sSql = sSql + " Set UserLevel = " + qte(txtUserLevel.Text)
                sSql = sSql + ", Password = " + qte(Encrypt(txtNewPassword.Text)) 'encrypt
                sSql = sSql + " Where UserName = " + qte(txtUserName.Text)

            Case "Analysis"
                sSql = "Update Analysis"
                sSql = sSql + " Set Description = " + qte(txtAnalysisDesc.Text)
                sSql = sSql + " Where Code = " + qte(txtAnalysisCode.Text)

            Case "GLCode"
                sSql = "Update GLCode"
                sSql = sSql + " Set Description = " + qte(txtGLCodeDesc.Text)
                sSql = sSql + " Where Code = " + qte(txtGLCodeCode.Text)

            Case "dirBud"
                sSql = "Update dirBud"
                sSql = sSql + " Set Description = " + qte(txtBudgetDesc.Text)
                sSql = sSql + ", PeriodFrom = " + AccessDate(Date.Parse(txtPeriodFrom.Text))
                sSql = sSql + ", PeriodTo = " + AccessDate(Date.Parse(txtPeriodTo.Text))
                sSql = sSql + ", StartMonth = " + qte(cboStartMonth.Text)
                sSql = sSql + ", Status = " + qte(cboActivate.Text)
                sSql = sSql + ", RefreshReqd = " + qte(cboRefresh.Text)
                sSql = sSql + " Where BudgetNo = " + qte(txtBudgetNo.Text) 'BudgetNo;+BudgetType;+PeriodFrom
                sSql = sSql + " And BudgetType = " + qte(cboBudgetType.Text)
                sSql = sSql + " And PeriodFrom = " + AccessDate(txtPeriodFrom.Text) '???use tag?

            Case "Currencies"
                sSql = "Update Currencies"
                sSql = sSql + " Set Description = " + qte(txtCurrencyDesc.Text)
                sSql = sSql + ", Rate = " + qte(txtRate.Text)
                sSql = sSql + ", Date = " + AccessDate(Date.Parse(Today))
                sSql = sSql + ", Type = " + qte(txtDorM.Text)
                sSql = sSql + ", DecimalPlaces = " + qte(txtDecPlaces.Text)
                sSql = sSql + ", BaseCCY = " + qte(txtBaseCCY.Text)
                sSql = sSql + " Where Code = " + qte(txtCurrencyCode.Text)

        End Select

        '
        'ok, let's do it
        '
        If gsTb = "Users" Then
            bOk = DoStartUpSql(sSql, 1)
        Else
            bOk = DoSql(sSql, 1)
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        CmdNew.Enabled = True
        cmdChange.Enabled = True
        CmdDelete.Enabled = True
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

        Call NullFields()
        Call DisableFields()

        miUpdate = False

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub DataGridViewBankNames_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewBankNames.CellContentClick

        'Call cmdChange_Click(AcceptButton, e)

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            bOk = AccountNamesTableAdapterLive.ClearBeforeFill
            Me.AccountNamesTableAdapterLive.Fill(Me.VPBSDataSet.AccountNames)

            bOk = BankNamesTableAdapterLive.ClearBeforeFill
            Me.BankNamesTableAdapterLive.Fill(Me.VPBSDataSet.BankNames)

            bOk = CustomersTableAdapterLive.ClearBeforeFill
            Me.CustomersTableAdapterLive.Fill(Me.VPBSDataSet.Customers)

            bOk = UsersTableAdapterLive.ClearBeforeFill
            Me.UsersTableAdapterLive.Fill(Me.VPBSDataSet.Users)

            bOk = AnalysisTableAdapterLive.ClearBeforeFill
            Me.AnalysisTableAdapterLive.Fill(Me.VPBSDataSet.Analysis)

            bOk = GLCodeTableAdapterLive.ClearBeforeFill
            Me.GLCodeTableAdapterLive.Fill(Me.VPBSDataSet.GLCode)

            bOk = DirbudTableAdapterLive.ClearBeforeFill
            Me.DirbudTableAdapterLive.Fill(Me.VPBSDataSet.dirbud)

            bOk = CurrenciesTableAdapterLive.ClearBeforeFill
            Me.CurrenciesTableAdapterLive.Fill(Me.VPBSDataSet.Currencies)

        ElseIf gsDBName = "Archive" Then

            bOk = AccountNamesTableAdapterArc.ClearBeforeFill
            Me.AccountNamesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.AccountNames)

            bOk = BankNamesTableAdapterArc.ClearBeforeFill
            Me.BankNamesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.BankNames)

            bOk = CustomersTableAdapterArc.ClearBeforeFill
            Me.CustomersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Customers)

            bOk = UsersTableAdapterArc.ClearBeforeFill
            Me.UsersTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Users)

            bOk = AnalysisTableAdapterArc.ClearBeforeFill
            Me.AnalysisTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Analysis)

            bOk = GLCodeTableAdapterArc.ClearBeforeFill
            Me.GLCodeTableAdapterArc.Fill(Me.VpbsArchiveDataSet.GLCode)

            bOk = DirbudTableAdapterArc.ClearBeforeFill
            Me.DirbudTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirbud)

            bOk = CurrenciesTableAdapterArc.ClearBeforeFill
            Me.CurrenciesTableAdapterArc.Fill(Me.VpbsArchiveDataSet.Currencies)

        ElseIf gsDBName = "Test" Then

            bOk = AccountNamesTestTableAdapter.ClearBeforeFill
            Me.AccountNamesTestTableAdapter.Fill(Me.VPBSTestDataSet.AccountNames)

            bOk = BankNamesTestTableAdapter.ClearBeforeFill
            Me.BankNamesTestTableAdapter.Fill(Me.VPBSTestDataSet.BankNames)

            bOk = CustomersTestTableAdapter.ClearBeforeFill
            Me.CustomersTestTableAdapter.Fill(Me.VPBSTestDataSet.Customers)

            bOk = UsersTestTableAdapter.ClearBeforeFill
            Me.UsersTestTableAdapter.Fill(Me.VPBSTestDataSet.Users)

            bOk = AnalysisTestTableAdapter.ClearBeforeFill
            Me.AnalysisTestTableAdapter.Fill(Me.VPBSTestDataSet.Analysis)

            bOk = GLCodeTestTableAdapter.ClearBeforeFill
            Me.GLCodeTestTableAdapter.Fill(Me.VPBSTestDataSet.GLCode)

            bOk = DirbudTestTableAdapter.ClearBeforeFill
            Me.DirbudTestTableAdapter.Fill(Me.VPBSTestDataSet.dirbud)

            bOk = CurrenciesTestTableAdapter.ClearBeforeFill
            Me.CurrenciesTestTableAdapter.Fill(Me.VPBSTestDataSet.Currencies)

        End If

    End Sub

    Private Sub NullFields()

        txtShortAccountName.Text = ""
        txtAccountName.Text = ""
        txtShortBankName.Text = ""
        txtBankName.Text = ""
        txtShortCustName.Text = ""
        txtCustName.Text = ""
        txtUserName.Text = ""
        txtUserLevel.Text = ""
        txtOldPassword.Text = ""
        txtNewPassword.Text = ""
        txtAddPassword.Text = ""
        txtVerifyPassword.Text = ""

        txtAnalysisCode.Text = ""
        txtAnalysisDesc.Text = ""
        txtGLCodeCode.Text = ""
        txtGLCodeDesc.Text = ""
        txtBudgetNo.Text = ""
        txtBudgetDesc.Text = ""
        cboBudgetType.Text = ""
        txtPeriodFrom.Text = ""
        txtPeriodTo.Text = ""
        cboStartMonth.Text = ""
        cboRefresh.Text = ""
        cboActivate.Text = ""
        txtCurrencyCode.Text = ""
        txtCurrencyDesc.Text = ""
        txtRate.Text = ""
        txtDorM.Text = ""
        txtDecPlaces.Text = ""
        txtBaseCCY.Text = ""

    End Sub

    Private Sub DisableFields()

        txtShortAccountName.Enabled = False
        txtAccountName.Enabled = False
        txtShortBankName.Enabled = False
        txtBankName.Enabled = False
        txtShortCustName.Enabled = False
        txtCustName.Enabled = False
        txtUserName.Enabled = False
        txtUserLevel.Enabled = False
        txtOldPassword.Enabled = False
        txtNewPassword.Enabled = False
        txtAddPassword.Enabled = False
        txtVerifyPassword.Enabled = False

        txtAnalysisCode.Enabled = False
        txtAnalysisDesc.Enabled = False
        txtGLCodeCode.Enabled = False
        txtGLCodeDesc.Enabled = False
        txtBudgetNo.Enabled = False
        txtBudgetDesc.Enabled = False
        cboBudgetType.Enabled = False
        txtPeriodFrom.Enabled = False
        txtPeriodTo.Enabled = False
        cboStartMonth.Enabled = False
        cboRefresh.Enabled = False
        cboActivate.Enabled = False
        txtCurrencyCode.Enabled = False
        txtCurrencyDesc.Enabled = False
        txtRate.Enabled = False
        txtDorM.Enabled = False
        txtDecPlaces.Enabled = False
        txtBaseCCY.Enabled = False

    End Sub

    Private Sub EnableFields()

        txtShortAccountName.Enabled = True
        txtAccountName.Enabled = True
        txtShortBankName.Enabled = True
        txtBankName.Enabled = True
        txtShortCustName.Enabled = True
        txtCustName.Enabled = True
        txtUserName.Enabled = True
        txtUserLevel.Enabled = True
        txtOldPassword.Enabled = True
        txtNewPassword.Enabled = True

        txtAnalysisCode.Enabled = True
        txtAnalysisDesc.Enabled = True
        txtGLCodeCode.Enabled = True
        txtGLCodeDesc.Enabled = True
        txtBudgetNo.Enabled = True
        txtBudgetDesc.Enabled = True
        cboBudgetType.Enabled = True
        txtPeriodFrom.Enabled = True
        txtPeriodTo.Enabled = True
        cboStartMonth.Enabled = True
        cboRefresh.Enabled = True
        cboActivate.Enabled = True
        txtCurrencyCode.Enabled = True
        txtCurrencyDesc.Enabled = True
        txtRate.Enabled = True
        txtDorM.Enabled = True
        txtDecPlaces.Enabled = True
        txtBaseCCY.Enabled = True

    End Sub

    Private Sub TabControl1SelectedIndexChanged(iButtonControl As IButtonControl, e As EventArgs)
        Throw New NotImplementedException
        'not added by me!
    End Sub

End Class
