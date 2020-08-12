'****************************************************************************************************************************
'Visual Personal Banking System v2013
'Copyright Jack Gibbons 1980-2017
'
'Add/Change/Delete Dirpbs account
'****************************************************************************************************************************
'
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'12/11/15   jpg     Created from Vpbs78
'                   Added datasources, datagrid, New/Change/Delete
'25/11/15   jpg     Completed
'17/01/16   jpg     Added Archive dataset...
'****************************************************************************************************************************
Public Class frmAddChgAcc

    Dim miUpdate As Integer = Nothing

    Private Sub frmAddChgAcc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VpbsArchiveDataSet.dirpbs' table. You can move, or remove it, as needed.
        Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
        'TODO: This line of code loads data into the 'VpbsDataSet.dirpbs' table. You can move, or remove it, as needed.
        'Me.DirpbsTableAdapter1.Fill(Me.VpbsDataSet.dirpbs)

        If gsDBName = "Live" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBS.MDB"

            'TODO: This line of code loads data into the 'VPBSDataSet.dirpbs' table. You can move, or remove it, as needed.
            Me.DirpbsTableAdapterLive.Fill(Me.VpbsDataSet.dirpbs)

            DirpbsBindingSource.DataSource = VpbsDataSet


        ElseIf gsDBName = "Archive" Then

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSArchive.MDB"

            'TODO: This line of code loads data into the 'VPBSDataSet.dirpbs' table. You can move, or remove it, as needed.
            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)

            DirpbsBindingSource.DataSource = VpbsArchiveDataSet

        Else 'Test

            gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\VPBSTest.MDB"

            'TODO: This line of code loads data into the 'VPBSTestDataSet.dirpbs' table. You can move, or remove it, as needed.
            Me.DirpbsTableAdapterTest.Fill(Me.VpbsTestDataSet.dirpbs)

            DirpbsBindingSource.DataSource = VpbsTestDataSet

        End If

        If giUserLevel = 1 Then
            DirpbsBindingSource.Filter = ""
        Else
            DirpbsBindingSource.Filter = "Username = '" + gsUserName + "'"  'Select'
        End If

        DirpbsBindingSource.Sort = "[Currency], AccountNo" 'Order By'

        DataGridDirPbs.DataSource = DirpbsBindingSource
        DataGridDirPbs.TopLeftHeaderCell.Value = gsDBName '"------"
        DataGridDirPbs.Visible = True

        'GroupBox2.Visible = False 'Add/Change/Delete

        Call FillAccountNameCBO()
        Call FillBankNameCBO()
        Call FillCcyCBO()
        Call FillAccountNoCBO()
        Call FillGroupNoCBO()
        Call FillUserNameCBO()

        Call NullFields()
        Call DisableFields()

        If giDirpbsNew = True Then
            GroupBox2.Text = "New Account Details"
            cboAccountNo.Enabled = False
            cmdSelect.Visible = False
            cmdNew.Visible = True
            cmdChange.Visible = False
            cmdDelete.Visible = False
        Else
            GroupBox2.Text = "Change Account Details"
            cboAccountNo.Enabled = False
            cmdSelect.Visible = True
            cmdNew.Visible = False
            cmdChange.Visible = True
            cmdDelete.Visible = True
            If AccountsExist() Then
                cmdChange.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdChange.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

    End Sub

    Private Sub DataGridDirPbs_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridDirPbs.CellContentClick

        Call cmdChange_Click(AcceptButton, e)

    End Sub

    Private Sub FillAccountNameCBO()

        Dim sSql As String
        Dim nCount As Long

        cboAccountName.Items.Clear()

        'Select
        sSql = "Select Distinct AccountName from dirpbs "
        sSql = sSql + " Order by AccountName"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboAccountName.Items.Add(ds.Rows.Item(nCount)("AccountName")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub FillBankNameCBO()

        Dim sSql As String
        Dim nCount As Long

        cboBankName.Items.Clear()

        'Select
        sSql = "Select Distinct BankName from dirpbs "
        sSql = sSql + " Order by BankName"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboBankName.Items.Add(ds.Rows.Item(nCount)("BankName")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub FillCcyCBO()

        Dim sSql As String
        Dim sCcy As String
        Dim nCount As Long

        cboCcy.Items.Clear()

        'Select
        sSql = "Select Distinct Code, Description from Currencies "
        sSql = sSql + " Order by Code"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                sCcy = (ds.Rows.Item(nCount)("Code")).ToString() + " - " + (ds.Rows.Item(nCount)("Description")).ToString()
                cboCcy.Items.Add(sCcy) 'ds.Rows.Item(nCount)("Code")).ToString() + " - " + ds.Rows.Item(nCount)("Description")).ToString())

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub FillAccountNoCBO()

        Dim sSql As String
        Dim nCount As Long

        cboAccountNo.Items.Clear()

        'Select
        sSql = "Select Distinct AccountNo from dirpbs "
        sSql = sSql + " Order by AccountNo"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboAccountNo.Items.Add(ds.Rows.Item(nCount)("AccountNo")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub FillGroupNoCBO()

        Dim sSql As String
        Dim nCount As Long

        cboGroupNo.Items.Clear()

        'Select
        sSql = "Select Distinct BudgetNo from dirpbs "
        sSql = sSql + " Order by BudgetNo"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboGroupNo.Items.Add(ds.Rows.Item(nCount)("BudgetNo")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub FillUserNameCBO()

        Dim sSql As String
        Dim nCount As Long

        cboUserName.Items.Clear()

        'Select
        sSql = "Select Distinct UserName from Users "
        sSql = sSql + " Order by UserName"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        Call SetHourGlassWait()

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                cboUserName.Items.Add(ds.Rows.Item(nCount)("UserName")).ToString()

                nCount = nCount + 1
            Loop

        End If

        ds.Dispose()

        Call SetHourGlassDefault()

    End Sub

    Private Sub AddDirpbsRecord()

        Dim sSql As String = Nothing
        Dim bOk As Boolean

        '
        'Add Record to Dirpbs
        '
        sSql = "Insert into Dirpbs"
        sSql = sSql + " (AccountNo, AccountName, AccountDesc, BankName, BankBranch, BankCode, "
        sSql = sSql + " [Currency], Balance, BalanceDate, BalanceEquivalent, BalanceStatus, "
        sSql = sSql + " odLimit, UserName, BudgetNo"
        sSql = sSql + " )"
        sSql = sSql + " Values ("
        sSql = sSql + "  " + qte(cboAccountNo.Text)
        sSql = sSql + ", " + qte(cboAccountName.Text)
        sSql = sSql + ", " + qte(txtAccountDesc.Text)
        sSql = sSql + ", " + qte(cboBankName.Text)
        sSql = sSql + ", " + qte(txtBankBranch.Text)
        sSql = sSql + ", " + qte(txtBankCode.Text)
        sSql = sSql + ", " + qte(Mid(cboCcy.Text, 1, 3))
        sSql = sSql + ", 0"
        sSql = sSql + ", " + AccessDate(Date.Parse(Today))
        sSql = sSql + ", 0"
        sSql = sSql + ", 0"
        sSql = sSql + ", " + qte(txtOdLimit.Text)
        sSql = sSql + ", " + qte(cboUserName.Text)
        sSql = sSql + ", " + qte(cboGroupNo.Text)
        sSql = sSql + ")"

        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

    End Sub

    Private Sub EditDirpbsRecord()

        Dim sSql As String = Nothing
        Dim bOk As Boolean

        '
        'Edit Record in Dirpbs
        '
        sSql = "Update Dirpbs"
        sSql = sSql + " Set AccountName = " + qte(cboAccountName.Text)
        sSql = sSql + ", AccountDesc = " + qte(txtAccountDesc.Text)
        sSql = sSql + ", BankName = " + qte(cboBankName.Text)
        sSql = sSql + ", BankBranch = " + qte(txtBankBranch.Text)
        sSql = sSql + ", BankCode = " + qte(txtBankCode.Text)
        sSql = sSql + ", [Currency] = " + qte(Mid(cboCcy.Text, 1, 3))
        sSql = sSql + ", odLimit = " + qte(txtOdLimit.Text)
        sSql = sSql + ", UserName = " + qte(cboUserName.Text)
        sSql = sSql + ", BudgetNo = " + qte(cboGroupNo.Text)
        sSql = sSql + " Where AccountNo = " + qte(cboAccountNo.Text)

        '
        'ok, let's do it
        '
        bOk = DoSql(sSql, 1)

    End Sub

    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click

        DataGridDirPbs.Focus()

    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

        Call EnableFields()
        Call NullFields()

        miUpdate = giADD

        If giDirpbsNew = True Then
            cboAccountNo.Enabled = True
        Else
            cboAccountNo.Enabled = False
        End If

        cmdSelect.Enabled = False
        cmdNew.Enabled = False
        cmdChange.Enabled = False
        cmdDelete.Enabled = False
        cmdOk.Enabled = True
        cmdCancel.Enabled = True
        cmdClose.Enabled = False

        cboAccountName.Focus()

    End Sub

    Private Sub cmdChange_Click(sender As Object, e As EventArgs) Handles cmdChange.Click

        Call GetDataFromDirPbsGrid()

        Call EnableFields()

        miUpdate = giCHANGE

        If giDirpbsNew = True Then
            cboAccountNo.Enabled = True
        Else
            cboAccountNo.Enabled = False
        End If

        cmdSelect.Enabled = False
        cmdNew.Enabled = False
        cmdChange.Enabled = False
        cmdDelete.Enabled = False
        cmdOk.Enabled = True
        cmdCancel.Enabled = True
        cmdClose.Enabled = False

        cboAccountName.Focus()

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        Dim sSql As String
        Dim bRecordsExist As Integer
        Dim Style As Short
        Dim Msg As String
        Dim Response As Boolean
        Dim Title As String
        Dim bOk As Boolean

        cmdSelect.Enabled = False
        cmdNew.Enabled = False
        cmdChange.Enabled = False
        cmdDelete.Enabled = False
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = False

        Call SetHourGlassWait()

        Call GetDataFromDirPbsGrid()

        bRecordsExist = RecordsExist(cboAccountNo.Text)

        Call SetHourGlassDefault()

        Msg = " Confirm deletion of Account "
        If bRecordsExist Then Msg = Msg & " AND all transactions"
        Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2 ' Describe dialog.
        Title = "Delete Account " + cboAccountNo.Text
        If bRecordsExist Then Title = Title & " AND all transactions"
        Response = MsgBox(Msg, Style, Title)

        If Response = MsgBoxResult.Yes Then
            If bRecordsExist Then
                'just check to make sure that this is what you want to do
                Msg = " Do you really want to delete Account AND all transactions"
                Style = vbYesNo + vbExclamation + vbDefaultButton2 ' Describe dialog.
                Title = "Delete Account AND all transactions"
                Response = MsgBox(Msg, Style, Title)
                If Response = MsgBoxResult.Yes Then
                    Call SetHourGlassWait()
                    'now delete all transactions in PbsTrans
                    sSql = "Delete From pbstrans Where AccountNo = " & qte(CStr(cboAccountNo.Text))
                    bOk = DoSql(sSql, 1)
                    'If gsAccountNo = cboAccountNo.Text Then
                    'frmTrans!dataTrans.Refresh()
                    'End If
                    'now delete all transactions in SOTrans
                    sSql = "Delete From SOtrans Where AccountNo = " & qte(CStr(cboAccountNo.Text))
                    bOk = DoSql(sSql, 1)
                    'now delete all transactions in dirpbs
                    sSql = "Delete From dirpbs Where AccountNo = " & qte(CStr(cboAccountNo.Text))
                    bOk = DoSql(sSql, 1)
                    Msg = "Currently selected account and transactions deleted"
                    MsgBox(Msg, vbExclamation, Title)
                Else
                    Msg = "Currently selected account and transactions NOT deleted"
                    MsgBox(Msg, vbExclamation, Title)
                End If
            Else
                'no transactions, so go ahead
                sSql = "Delete From dirpbs Where AccountNo = " & qte(CStr(cboAccountNo.Text))
                bOk = DoSql(sSql, 1)
                Msg = "Currently selected account deleted"
                MsgBox(Msg, vbExclamation, Title)
            End If
        Else
            Msg = "Currently selected account NOT deleted"
            MsgBox(Msg, vbExclamation, Title)
        End If

        Call RefreshDetails()

        Call NullFields()
        Call DisableFields()

        Call SetHourGlassDefault()

        If giDirpbsNew = True Then
            cmdSelect.Enabled = False
            cmdNew.Enabled = True
            cmdChange.Enabled = False
            cmdDelete.Enabled = False
        Else
            cmdNew.Enabled = False
            If AccountExist(cboAccountNo.Text) Then
                cmdSelect.Enabled = True
                cmdChange.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdSelect.Enabled = False
                cmdChange.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

        miUpdate = False
        giAccountsExist = AccountsExist()

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        If Trim(cboAccountNo.Text) = "" Then
            MessageBox.Show("Account No. cannot be blank")
            cboAccountNo.Focus()
            Exit Sub
        End If

        If Trim(cboGroupNo.Text) = "" Then
            MessageBox.Show("Budget No. cannot be blank - set default to Account No.")
            cboGroupNo.Text = cboAccountNo.Text
            cboGroupNo.Focus()
            Exit Sub
        End If

        If Trim(cboCcy.Text) = "" Then
            MessageBox.Show("Currency cannot be blank")
            cboCcy.Focus()
            Exit Sub
        End If

        Select Case miUpdate

            Case giADD
                If AccountExist(cboAccountNo.Text) Then
                    Call MessageBox.Show("This account number has already been set up")
                Else
                    Call AddDirpbsRecord()
                    gsAccountNo = cboAccountNo.Text
                End If

            Case giCHANGE
                Call EditDirpbsRecord()

        End Select

        'reload data from DB
        Call RefreshDetails()

        If giDirpbsNew = True Then
            cmdSelect.Enabled = False
            cmdNew.Enabled = True
            cmdChange.Enabled = False
            cmdDelete.Enabled = False
        Else
            cmdNew.Enabled = False
            If AccountExist(cboAccountNo.Text) Then
                cmdSelect.Enabled = True
                cmdChange.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdSelect.Enabled = False
                cmdChange.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

        Call NullFields()
        Call DisableFields()

        miUpdate = False

        giAccountsExist = AccountsExist()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        If giDirpbsNew = True Then
            cmdSelect.Enabled = False
            cmdNew.Enabled = True
            cmdChange.Enabled = False
            cmdDelete.Enabled = False
        Else
            cmdNew.Enabled = False
            If AccountExist(cboAccountNo.Text) Then
                cmdSelect.Enabled = True
                cmdChange.Enabled = True
                cmdDelete.Enabled = True
            Else
                cmdSelect.Enabled = False
                cmdChange.Enabled = False
                cmdDelete.Enabled = False
            End If
        End If
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

    Private Sub GetDataFromDirPbsGrid()

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
                        cboAccountNo.Text = value
                    Case "BudgetNo"
                        cboGroupNo.Text = value
                    Case "AccountName"
                        cboAccountName.Text = value
                    Case "AccountDesc"
                        txtAccountDesc.Text = value
                    Case "BankName"
                        cboBankName.Text = value
                    Case "BankBranch"
                        txtBankBranch.Text = value
                    Case "BankCode"
                        txtBankCode.Text = value
                    Case "Ccy" '"Currency"
                        cboCcy.Text = value
                    Case "odLimit"
                        txtOdLimit.Text = value
                    Case "UserName"
                        cboUserName.Text = value
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
                        'sBalanceDate = dvalue

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

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean

        If gsDBName = "Live" Then
            DirpbsBindingSource.DataSource = VpbsDataSet.dirpbs
            bOk = DirpbsTableAdapterLive.ClearBeforeFill
            Me.DirpbsTableAdapterLive.Fill(Me.VpbsDataSet.dirpbs)
        ElseIf gsDBName = "Archive" Then
            DirpbsBindingSource.DataSource = VpbsArchiveDataSet.dirpbs
            bOk = DirpbsTableAdapterArc.ClearBeforeFill
            Me.DirpbsTableAdapterArc.Fill(Me.VpbsArchiveDataSet.dirpbs)
        ElseIf gsDBName = "Test" Then
            DirpbsBindingSource.DataSource = VpbsTestDataSet.dirpbs
            bOk = DirpbsTableAdapterTest.ClearBeforeFill
            Me.DirpbsTableAdapterTest.Fill(Me.VpbsTestDataSet.dirpbs)
        End If

    End Sub

    Private Sub NullFields()

        cboAccountName.Text = ""
        txtAccountDesc.Text = ""
        cboBankName.Text = ""
        txtBankBranch.Text = ""
        txtBankCode.Text = ""
        cboAccountNo.Text = ""
        cboGroupNo.Text = ""
        cboCcy.Text = ""
        txtOdLimit.Text = ""
        cboUserName.Text = ""

    End Sub

    Private Sub DisableFields()

        cboAccountName.Enabled = False
        txtAccountDesc.Enabled = False
        cboBankName.Enabled = False
        txtBankBranch.Enabled = False
        txtBankCode.Enabled = False
        cboAccountNo.Enabled = False
        cboGroupNo.Enabled = False
        cboCcy.Enabled = False
        txtOdLimit.Enabled = False
        cboUserName.Enabled = False

    End Sub

    Private Sub EnableFields()

        cboAccountName.Enabled = True
        txtAccountDesc.Enabled = True
        cboBankName.Enabled = True
        txtBankBranch.Enabled = True
        txtBankCode.Enabled = True
        cboAccountNo.Enabled = True
        cboGroupNo.Enabled = True
        cboCcy.Enabled = True
        txtOdLimit.Enabled = True
        cboUserName.Enabled = True

    End Sub

    Private Sub txtOdLimit_TextChanged(sender As Object, e As EventArgs) Handles txtOdLimit.TextChanged

        If txtOdLimit.Text = "" Then txtOdLimit.Text = "0"

    End Sub

End Class