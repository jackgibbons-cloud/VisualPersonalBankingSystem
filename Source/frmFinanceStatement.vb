'****************************************************************************************************************************
'Visual Personal Banking System v2013/2019
'Copyright Jack Gibbons 1980-2020
'
'FinanceStatement, incorporating Report
'
'Purpose: Obtains current balances of selected accounts 
'          and enables entry of money To Pay and To Come 
'          to produce a 'Monthly' Finance Statement report -
'          uses Crystal Report FinanceStatementRPT.rpt.
'****************************************************************************************************************************
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'07/12/15   jpg     Created from Vpbs78
'                   Added datasources, Crystal Report
'17/12/15           Completed
'18/01/16           Problem with ZeroPCEnd have a "" value. Changed FinanceTable to accept zero length string
'06/02/16           Problem with AccountNo & Name have a "" value. Changed FinanceTable to accept zero length string
'                   Added delete row option by accepting "x" in txtAcctNo (EditRec)
'19/02/16           Allow records with non-blank txtName to be written to DB (EditRec) e.g. To Pay/To Come
'                   Get sDueDate from DB for tabs 3 and 5 to populate DueDate fields on screen, report OK (GetFinanceDetails())
'27/04/16           Balances not being updated - Call UpdateFinanceBalances() added to Cmd_Ok
'27/04/16           DueDate value being overwritten - Changed txtDueDatexx.Text to use .Tag field in tab3 & tab4 in GetFinanceDetails()
'17/06/16           frmActuals_Load(): need to call cmdOk_Click() to update BalanceText values for report
'24/11/16           Added two new records to Mortgage Tab
'01/11/17           Added two new records to Mortgage Tab
'04/03/20           Win10 Pro/VB19 FinanceStatementRPT.rpt - keeps showing error message re IDAPI (Paradox!) when running report first
'                   time, Changed properties in CRW32.EXE File/Options/Reporting to uncheck (disable)
'                   'More Report Engine Error Messages'. Ok
'****************************************************************************************************************************
Public Class frmFinanceStatement

    Dim nTab As Integer = 0
    Dim miUpdate As Boolean

    Private Sub frmActuals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call UpdateFinanceBalances()
        Call GetFinanceDetails()

        'need to update BalanceText values for report - added 17/06/16
        miUpdate = True
        Call cmdOk_Click(AcceptButton, e)
        miUpdate = False

        Call SetControlsFalse()

        lblAccountHeader.Text = "Finance Statement for " + gsAccountName

    End Sub

    Private Sub UpdateFinanceBalances()

        Dim sSql As String

        sSql = "Update Finance,Dirpbs "
        sSql = sSql & " Set Finance.Balance = Dirpbs.Balance"
        'sSql = sSql & ", Finance.BalanceText = Dirpbs.Balance" 'added 17/06/16
        sSql = sSql & " Where Finance.AccountNo = Dirpbs.AccountNo"

        'Uses default gsVpbsConnection set in frmPbsTrans

        If DoSql(sSql, 1) Then
        End If

    End Sub

    Private Sub GetFinanceDetails()

        Dim sSql As String = Nothing
        Dim BankTotal As Double = 0
        Dim CreditCardTotal As Double = 0
        Dim MinPymtTotal As Double = 0
        Dim MortgageTotal As Double = 0
        Dim MthTotal As Double = 0
        Dim Index As Integer = 0
        Dim nCount As Integer = 0
        Dim sCurrency As String = Nothing
        Dim sAcctNo As String = Nothing
        Dim sName As String = Nothing
        Dim sBalance As String = Nothing
        Dim sMinPymt As String = Nothing
        Dim sDueDate As String = Nothing
        Dim sZeropcEnd As String = Nothing
        Dim sRate As String = Nothing

        sSql = "SELECT * FROM Finance"
        sSql = sSql & " ORDER BY Tab, AccountNo"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                Index = ds.Rows.Item(nCount)("Tab")

                'get the values
                sAcctNo = IIf(IsDBNull(ds.Rows.Item(nCount)("AccountNo")), "", ds.Rows.Item(nCount)("AccountNo"))
                sName = IIf(IsDBNull(ds.Rows.Item(nCount)("Name")), "", (ds.Rows.Item(nCount)("Name")))
                sBalance = IIf(IsDBNull(ds.Rows.Item(nCount)("Balance")), "", Format(ds.Rows.Item(nCount)("Balance"), "#####0.00")) 'gsTranCCYFmt))

                If Index >= 0 And Index < 8 Then 'tab 1, recs 0 to 7 only

                    BankTotal = BankTotal + Val(sBalance)

                ElseIf Index > 7 And Index < 16 Then 'tab 2, recs 8 to 15 only

                    sMinPymt = IIf(IsDBNull(ds.Rows.Item(nCount)("MinPymt")), "", Format(ds.Rows.Item(nCount)("MinPymt"), "#####0.00"))
                    sDueDate = IIf(IsDBNull(ds.Rows.Item(nCount)("DueDate")), "", ds.Rows.Item(nCount)("DueDate"))
                    sZeropcEnd = IIf(IsDBNull(ds.Rows.Item(nCount)("ZeropcEnd")), "0", ds.Rows.Item(nCount)("ZeropcEnd"))
                    sRate = IIf(IsDBNull(ds.Rows.Item(nCount)("Rate")), "", Format(ds.Rows.Item(nCount)("Rate"), "##0.00"))
                    CreditCardTotal = CreditCardTotal + Val(sBalance)
                    MinPymtTotal = MinPymtTotal + Val(sMinPymt)
                    If sZeropcEnd = "00:00:00" Or sZeropcEnd = "30/12/1899" Then sZeropcEnd = ""
                    If sDueDate = "00:00:00" Or sZeropcEnd = "30/12/1899" Then sDueDate = ""

                ElseIf Index > 15 And Index < 22 Then 'tab 3, recs 16 to 21 only

                    sDueDate = IIf(IsDBNull(ds.Rows.Item(nCount)("DueDate")), "", ds.Rows.Item(nCount)("DueDate")) 'added 19/04/16
                    If sDueDate = "00:00:00" Then sDueDate = ""

                ElseIf Index > 22 And Index < 29 Then 'tab 4, recs 23 to 28 only, no 22
                    'albatros

                ElseIf Index > 30 And Index <= 36 Then 'tab 5, recs 31 to 36 only, no 29 or 30
                    'aquavista
                    sDueDate = IIf(IsDBNull(ds.Rows.Item(nCount)("DueDate")), "", ds.Rows.Item(nCount)("DueDate")) 'added 19/04/16
                    If sDueDate = "00:00:00" Then sDueDate = ""

                ElseIf Index > 36 And Index <= 42 Then 'tab 6, recs 37 to 40 only 'added 2 more records 01/11/17

                    sMinPymt = IIf(IsDBNull(ds.Rows.Item(nCount)("MinPymt")), "", Format(ds.Rows.Item(nCount)("MinPymt"), "#####0.00"))
                    sDueDate = IIf(IsDBNull(ds.Rows.Item(nCount)("DueDate")), "", ds.Rows.Item(nCount)("DueDate"))
                    sZeropcEnd = IIf(IsDBNull(ds.Rows.Item(nCount)("ZeropcEnd")), "", ds.Rows.Item(nCount)("ZeropcEnd"))
                    sRate = IIf(IsDBNull(ds.Rows.Item(nCount)("Rate")), "", Format(ds.Rows.Item(nCount)("Rate"), "##0.00"))
                    MortgageTotal = MortgageTotal + sBalance
                    MthTotal = MthTotal + Val(sMinPymt)
                    If sZeropcEnd = "00:00:00" Or sZeropcEnd = "30/12/1899" Then sZeropcEnd = ""
                    If sDueDate = "00:00:00" Or sZeropcEnd = "30/12/1899" Then sDueDate = ""

                End If

                'populate the text fields
                Select Case Index

                    'Tab 0 Bank Accounts
                    Case 0
                        txtAcctNo1.Text = sAcctNo
                        txtName1.Text = sName
                        If txtName1.Text <> "" Then
                            txtBalance1.Text = sBalance
                        Else
                            txtBalance1.Text = ""
                        End If
                        sCurrency = ds.Rows.Item(nCount)("Currency")
                    Case 1
                        txtAcctNo2.Text = sAcctNo
                        txtName2.Text = sName
                        If txtName2.Text <> "" Then
                            txtBalance2.Text = sBalance
                        Else
                            txtBalance2.Text = ""
                        End If
                    Case 2
                        txtAcctNo3.Text = sAcctNo
                        txtName3.Text = sName
                        If txtName3.Text <> "" Then
                            txtBalance3.Text = sBalance
                        Else
                            txtBalance3.Text = ""
                        End If
                    Case 3
                        txtAcctNo4.Text = sAcctNo
                        txtName4.Text = sName
                        If txtName4.Text <> "" Then
                            txtBalance4.Text = sBalance
                        Else
                            txtBalance4.Text = ""
                        End If
                    Case 4
                        txtAcctNo5.Text = sAcctNo
                        txtName5.Text = sName
                        If txtName5.Text <> "" Then
                            txtBalance5.Text = sBalance
                        Else
                            txtBalance5.Text = ""
                        End If
                    Case 5
                        txtAcctNo6.Text = sAcctNo
                        txtName6.Text = sName
                        If txtName6.Text <> "" Then
                            txtBalance6.Text = sBalance
                        Else
                            txtBalance6.Text = ""
                        End If
                    Case 6
                        txtAcctNo7.Text = sAcctNo
                        txtName7.Text = sName
                        If txtName7.Text <> "" Then
                            txtBalance7.Text = sBalance
                        Else
                            txtBalance7.Text = ""
                        End If
                    Case 7
                        txtAcctNo8.Text = sAcctNo
                        txtName8.Text = sName
                        If txtName8.Text <> "" Then
                            txtBalance8.Text = sBalance
                        Else
                            txtBalance8.Text = " "
                        End If
                    Case 8

                        'Tab 2 Credit Cards
                        txtAcctNo9.Text = sAcctNo
                        txtName9.Text = sName
                        sCurrency = ds.Rows.Item(nCount)("Currency")
                        If txtName9.Text <> "" Then
                            txtBalance9.Text = sBalance
                            txtMinPymt9.Tag = sMinPymt
                            txtMinPymt9.Text = txtMinPymt9.Tag
                            txtDueDate9.Tag = sDueDate
                            txtDueDate9.Text = txtDueDate9.Tag
                            txtZeropcEnd9.Tag = sZeropcEnd
                            txtZeropcEnd9.Text = txtZeropcEnd9.Tag
                            txtRate9.Tag = sRate
                            txtRate9.Text = txtRate9.Tag
                        Else
                            txtBalance9.Text = ""
                            txtMinPymt9.Text = ""
                            txtDueDate9.Text = ""
                            txtZeropcEnd9.Text = ""
                            txtRate9.Text = ""
                        End If
                    Case 9
                        txtAcctNo10.Text = sAcctNo
                        txtName10.Text = sName
                        If txtName10.Text <> "" Then
                            txtBalance10.Text = sBalance
                            txtMinPymt10.Tag = sMinPymt
                            txtMinPymt10.Text = txtMinPymt10.Tag
                            txtDueDate10.Tag = sDueDate
                            txtDueDate10.Text = txtDueDate10.Tag
                            txtZeropcEnd10.Tag = sZeropcEnd
                            txtZeropcEnd10.Text = txtZeropcEnd10.Tag
                            txtRate10.Tag = sRate
                            txtRate10.Text = txtRate10.Tag
                        Else
                            txtBalance10.Text = ""
                            txtMinPymt10.Text = ""
                            txtDueDate10.Text = ""
                            txtZeropcEnd10.Text = ""
                            txtRate10.Text = ""
                        End If
                    Case 10
                        txtAcctNo11.Text = sAcctNo
                        txtName11.Text = sName
                        If txtName11.Text <> "" Then
                            txtBalance11.Text = sBalance
                            txtMinPymt11.Tag = sMinPymt
                            txtMinPymt11.Text = txtMinPymt11.Tag
                            txtDueDate11.Tag = sDueDate
                            txtDueDate11.Text = txtDueDate11.Tag
                            txtZeropcEnd11.Tag = sZeropcEnd
                            txtZeropcEnd11.Text = txtZeropcEnd11.Tag
                            txtRate11.Tag = sRate
                            txtRate11.Text = txtRate11.Tag
                        Else
                            txtBalance11.Text = ""
                            txtMinPymt11.Text = ""
                            txtDueDate11.Text = ""
                            txtZeropcEnd11.Text = ""
                            txtRate11.Text = ""
                        End If
                    Case 11
                        txtAcctNo12.Text = sAcctNo
                        txtName12.Text = sName
                        If txtName12.Text <> "" Then
                            txtBalance12.Text = sBalance
                            txtMinPymt12.Tag = sMinPymt
                            txtMinPymt12.Text = txtMinPymt12.Tag
                            txtDueDate12.Tag = sDueDate
                            txtDueDate12.Text = txtDueDate12.Tag
                            txtZeropcEnd12.Tag = sZeropcEnd
                            txtZeropcEnd12.Text = txtZeropcEnd12.Tag
                            txtRate12.Tag = sRate
                            txtRate12.Text = txtRate12.Tag
                        Else
                            txtBalance12.Text = ""
                            txtMinPymt12.Text = ""
                            txtDueDate12.Text = ""
                            txtZeropcEnd12.Text = ""
                            txtRate12.Text = ""
                        End If
                    Case 12
                        txtAcctNo13.Text = sAcctNo
                        txtName13.Text = sName
                        If txtName13.Text <> "" Then
                            txtBalance13.Text = sBalance
                            txtMinPymt13.Tag = sMinPymt
                            txtMinPymt13.Text = txtMinPymt13.Tag
                            txtDueDate13.Tag = sDueDate
                            txtDueDate13.Text = txtDueDate13.Tag
                            txtZeropcEnd13.Tag = sZeropcEnd
                            txtZeropcEnd13.Text = txtZeropcEnd13.Tag
                            txtRate13.Tag = sRate
                            txtRate13.Text = txtRate13.Tag
                        Else
                            txtBalance13.Text = ""
                            txtMinPymt13.Text = ""
                            txtDueDate13.Text = ""
                            txtZeropcEnd13.Text = ""
                            txtRate13.Text = ""
                        End If
                    Case 13
                        txtAcctNo14.Text = sAcctNo
                        txtName14.Text = sName
                        If txtName14.Text <> "" Then
                            txtBalance14.Text = sBalance
                            txtMinPymt14.Tag = sMinPymt
                            txtMinPymt14.Text = txtMinPymt14.Tag
                            txtDueDate14.Tag = sDueDate
                            txtDueDate14.Text = txtDueDate14.Tag
                            txtZeropcEnd14.Tag = sZeropcEnd
                            txtZeropcEnd14.Text = txtZeropcEnd14.Tag
                            txtRate14.Tag = sRate
                            txtRate14.Text = txtRate14.Tag
                        Else
                            txtBalance14.Text = ""
                            txtMinPymt14.Text = ""
                            txtDueDate14.Text = ""
                            txtZeropcEnd14.Text = ""
                            txtRate14.Text = ""
                        End If
                    Case 14
                        txtAcctNo15.Text = sAcctNo
                        txtName15.Text = sName
                        If txtName15.Text <> "" Then
                            txtBalance15.Text = sBalance
                            txtMinPymt15.Tag = sMinPymt
                            txtMinPymt15.Text = txtMinPymt15.Tag
                            txtDueDate15.Tag = sDueDate
                            txtDueDate15.Text = txtDueDate15.Tag
                            txtZeropcEnd15.Tag = sZeropcEnd
                            txtZeropcEnd15.Text = txtZeropcEnd15.Tag
                            txtRate15.Tag = sRate
                            txtRate15.Text = txtRate15.Tag
                        Else
                            txtBalance15.Text = ""
                            txtMinPymt15.Text = ""
                            txtDueDate15.Text = ""
                            txtZeropcEnd15.Text = ""
                            txtRate15.Text = ""
                        End If
                    Case 15
                        txtAcctNo16.Text = sAcctNo
                        txtName16.Text = sName
                        If txtName16.Text <> "" Then
                            txtBalance16.Text = sBalance
                            txtMinPymt16.Tag = sMinPymt
                            txtMinPymt16.Text = txtMinPymt16.Tag
                            txtDueDate16.Tag = sDueDate
                            txtDueDate16.Text = txtDueDate16.Tag
                            txtZeropcEnd16.Tag = sZeropcEnd
                            txtZeropcEnd16.Text = txtZeropcEnd16.Tag
                            txtRate16.Tag = sRate
                            txtRate16.Text = txtRate16.Tag
                        Else
                            txtBalance16.Text = ""
                            txtMinPymt16.Text = ""
                            txtDueDate16.Text = ""
                            txtZeropcEnd16.Text = ""
                            txtRate16.Text = ""
                        End If

                    Case 16
                        'tab 3 'To Pay/To Come
                        txtAcctNo17.Text = sAcctNo
                        txtName17.Text = sName
                        If txtName17.Text <> "" Then
                            txtBalance17.Text = sBalance
                            'txtDueDate17.Text = sDueDate
                            txtDueDate17.Tag = sDueDate 'changed 27/04/16
                            txtDueDate17.Text = txtDueDate17.Tag
                        Else
                            txtDueDate17.Text = ""
                        End If
                    Case 17
                        txtAcctNo18.Text = sAcctNo
                        txtName18.Text = sName
                        If txtName18.Text <> "" Then
                            txtBalance18.Text = sBalance
                            'txtDueDate18.Text = sDueDate
                            txtDueDate18.Tag = sDueDate 'changed 27/04/16
                            txtDueDate18.Text = txtDueDate18.Tag
                        Else
                            txtDueDate18.Text = ""
                        End If
                    Case 18
                        txtAcctNo19.Text = sAcctNo
                        txtName19.Text = sName
                        If txtName19.Text <> "" Then
                            txtBalance19.Text = sBalance
                            'txtDueDate19.Text = sDueDate
                            txtDueDate19.Tag = sDueDate 'changed 27/04/16
                            txtDueDate19.Text = txtDueDate19.Tag
                        Else
                            txtDueDate19.Text = ""
                        End If
                    Case 19
                        txtAcctNo20.Text = sAcctNo
                        txtName20.Text = sName
                        If txtName20.Text <> "" Then
                            txtBalance20.Text = sBalance
                            'txtDueDate20.Text = sDueDate
                            txtDueDate20.Tag = sDueDate 'changed 27/04/16
                            txtDueDate20.Text = txtDueDate20.Tag
                        End If
                    Case 20
                        txtAcctNo21.Text = sAcctNo
                        txtName21.Text = sName
                        If txtName21.Text <> "" Then
                            txtBalance21.Text = sBalance
                            'txtDueDate21.Text = sDueDate
                            txtDueDate21.Tag = sDueDate 'changed 27/04/16
                            txtDueDate21.Text = txtDueDate21.Tag
                        End If
                    Case 21
                        txtAcctNo22.Text = sAcctNo
                        txtName22.Text = sName
                        If txtName22.Text <> "" Then
                            txtBalance22.Text = sBalance
                            'txtDueDate22.Text = sDueDate
                            txtDueDate22.Tag = sDueDate 'changed 27/04/16
                            txtDueDate22.Text = txtDueDate22.Tag
                        End If

                    Case 22
                        'was Albatros

                    Case 29
                        'tab 4 Aquavista
                        txtAcctNo30.Text = sAcctNo
                        txtName30.Text = sName
                        sCurrency = ds.Rows.Item(nCount)("Currency")
                        If txtName30.Text <> "" Then
                            txtBalance30.Text = sBalance
                        End If
                    Case 30
                        txtAcctNo31.Text = sAcctNo
                        txtName31.Text = sName
                        sCurrency = ds.Rows.Item(nCount)("Currency")
                        If txtName31.Text <> "" Then
                            txtBalance31.Text = sBalance
                        End If
                    Case 31
                        txtAcctNo32.Text = sAcctNo
                        txtName32.Text = sName
                        If txtName32.Text <> "" Then
                            txtBalance32.Text = sBalance
                            'txtDueDate32.Text = sDueDate
                            txtDueDate32.Tag = sDueDate 'changed 27/04/16
                            txtDueDate32.Text = txtDueDate32.Tag
                        End If
                    Case 32
                        txtAcctNo33.Text = sAcctNo
                        txtName33.Text = sName
                        If txtName33.Text <> "" Then
                            txtBalance33.Text = sBalance
                            'txtDueDate33.Text = sDueDate
                            txtDueDate33.Tag = sDueDate 'changed 27/04/16
                            txtDueDate33.Text = txtDueDate33.Tag
                        End If
                    Case 33
                        txtAcctNo34.Text = sAcctNo
                        txtName34.Text = sName
                        If txtName34.Text <> "" Then
                            txtBalance34.Text = sBalance
                            'txtDueDate34.Text = sDueDate
                            txtDueDate34.Tag = sDueDate 'changed 27/04/16
                            txtDueDate34.Text = txtDueDate34.Tag
                        End If
                    Case 34
                        txtAcctNo35.Text = sAcctNo
                        txtName35.Text = sName
                        If txtName35.Text <> "" Then
                            txtBalance35.Text = sBalance
                            'txtDueDate35.Text = sDueDate
                            txtDueDate35.Tag = sDueDate 'changed 27/04/16
                            txtDueDate35.Text = txtDueDate35.Tag
                        End If
                    Case 35
                        txtAcctNo36.Text = sAcctNo
                        txtName36.Text = sName
                        If txtName36.Text <> "" Then
                            txtBalance36.Text = sBalance
                            'txtDueDate36.Text = sDueDate
                            txtDueDate36.Tag = sDueDate 'changed 27/04/16
                            txtDueDate36.Text = txtDueDate36.Tag
                        End If
                    Case 36
                        txtAcctNo37.Text = sAcctNo
                        txtName37.Text = sName
                        If txtName37.Text <> "" Then
                            txtBalance37.Text = sBalance
                            'txtDueDate37.Text = sDueDate
                            txtDueDate37.Tag = sDueDate 'changed 27/04/16
                            txtDueDate37.Text = txtDueDate37.Tag
                        End If

                    Case 37
                        'tab 5 Mortgages
                        txtAcctNo38.Text = sAcctNo
                        txtName38.Text = sName
                        If txtName38.Text <> "" Then
                            txtBalance38.Text = sBalance
                            txtMinPymt38.Tag = sMinPymt
                            txtMinPymt38.Text = txtMinPymt38.Tag
                            txtDueDate38.Tag = sDueDate
                            txtDueDate38.Text = txtDueDate38.Tag
                            txtZeropcEnd38.Tag = sZeropcEnd
                            txtZeropcEnd38.Text = txtZeropcEnd38.Tag
                            txtRate38.Tag = sRate
                            txtRate38.Text = txtRate38.Tag
                        Else
                            txtBalance38.Text = ""
                            txtMinPymt38.Text = ""
                            txtDueDate9.Text = ""
                            txtZeropcEnd9.Text = ""
                            txtRate38.Text = ""
                        End If
                    Case 38
                        txtAcctNo39.Text = sAcctNo
                        txtName39.Text = sName
                        If txtName39.Text <> "" Then
                            txtBalance39.Text = sBalance
                            txtMinPymt39.Tag = sMinPymt
                            txtMinPymt39.Text = txtMinPymt39.Tag
                            txtDueDate39.Tag = sDueDate
                            txtDueDate39.Text = txtDueDate39.Tag
                            txtZeropcEnd39.Tag = sZeropcEnd
                            txtZeropcEnd39.Text = txtZeropcEnd39.Tag
                            txtRate39.Tag = sRate
                            txtRate39.Text = txtRate39.Tag
                        Else
                            txtBalance39.Text = ""
                            txtMinPymt38.Text = ""
                            txtDueDate39.Text = ""
                            txtZeropcEnd39.Text = ""
                            txtRate39.Text = ""
                        End If
                    Case 39                         'added 24/11/16
                        txtAcctNo40.Text = sAcctNo
                        txtName40.Text = sName
                        If txtName40.Text <> "" Then
                            txtBalance40.Text = sBalance
                            txtMinPymt40.Tag = sMinPymt
                            txtMinPymt40.Text = txtMinPymt40.Tag
                            txtDueDate40.Tag = sDueDate
                            txtDueDate40.Text = txtDueDate40.Tag
                            txtZeropcEnd40.Tag = sZeropcEnd
                            txtZeropcEnd40.Text = txtZeropcEnd40.Tag
                            txtRate40.Tag = sRate
                            txtRate40.Text = txtRate40.Tag
                        Else
                            txtBalance40.Text = ""
                            txtMinPymt40.Text = ""
                            txtDueDate40.Text = ""
                            txtZeropcEnd40.Text = ""
                            txtRate40.Text = ""
                        End If
                    Case 40                         'added 28/11/16
                        txtAcctNo41.Text = sAcctNo
                        txtName41.Text = sName
                        If txtName41.Text <> "" Then
                            txtBalance41.Text = sBalance
                            txtMinPymt41.Tag = sMinPymt
                            txtMinPymt41.Text = txtMinPymt41.Tag
                            txtDueDate41.Tag = sDueDate
                            txtDueDate41.Text = txtDueDate41.Tag
                            txtZeropcEnd41.Tag = sZeropcEnd
                            txtZeropcEnd41.Text = txtZeropcEnd41.Tag
                            txtRate41.Tag = sRate
                            txtRate41.Text = txtRate41.Tag
                        Else
                            txtBalance41.Text = ""
                            txtMinPymt41.Text = ""
                            txtDueDate41.Text = ""
                            txtZeropcEnd41.Text = ""
                            txtRate41.Text = ""
                        End If

                    Case 41                         'added 01/11/17
                        txtAcctNo42.Text = sAcctNo
                        txtName42.Text = sName
                        If txtName42.Text <> "" Then
                            txtBalance42.Text = sBalance
                            txtMinPymt42.Tag = sMinPymt
                            txtMinPymt42.Text = txtMinPymt42.Tag
                            txtDueDate42.Tag = sDueDate
                            txtDueDate42.Text = txtDueDate42.Tag
                            txtZeropcEnd42.Tag = sZeropcEnd
                            txtZeropcEnd42.Text = txtZeropcEnd42.Tag
                            txtRate42.Tag = sRate
                            txtRate42.Text = txtRate42.Tag
                        Else
                            txtBalance42.Text = ""
                            txtMinPymt42.Text = ""
                            txtDueDate42.Text = ""
                            txtZeropcEnd42.Text = ""
                            txtRate42.Text = ""
                        End If

                    Case 42                         'added 01/11/17
                        txtAcctNo43.Text = sAcctNo
                        txtName43.Text = sName
                        If txtName43.Text <> "" Then
                            txtBalance43.Text = sBalance
                            txtMinPymt43.Tag = sMinPymt
                            txtMinPymt43.Text = txtMinPymt43.Tag
                            txtDueDate43.Tag = sDueDate
                            txtDueDate43.Text = txtDueDate43.Tag
                            txtZeropcEnd43.Tag = sZeropcEnd
                            txtZeropcEnd43.Text = txtZeropcEnd43.Tag
                            txtRate43.Tag = sRate
                            txtRate43.Text = txtRate43.Tag
                        Else
                            txtBalance43.Text = ""
                            txtMinPymt43.Text = ""
                            txtDueDate43.Text = ""
                            txtZeropcEnd43.Text = ""
                            txtRate43.Text = ""
                        End If

                End Select

                If Index = 0 Then     'Tab1
                    txtCcy0.Text = sCurrency
                ElseIf Index = 8 Then 'Tab2
                    txtCcy1.Text = sCurrency
                    'ElseIf Index = 16 Then 'Tab3
                    'txtCcy3.Text = sCurrency
                    'ElseIf Index = 22 Then 'Tab4
                    'txtCcy3.Text = sCurrency
                ElseIf Index = 29 Then 'Tab5
                    txtCcy3.Text = sCurrency
                ElseIf Index = 30 Then 'Tab5
                    txtCcy4.Text = sCurrency
                ElseIf Index = 37 Then 'Tab6
                    txtCcy5.Text = sCurrency
                End If

                'don't forget to move to the next record!
                nCount = nCount + 1

            Loop

        End If

        ds.Dispose()

        txtTotal0.Text = Format$(Val(BankTotal), "#####0.00")
        txtTotal1.Text = Format$(Val(CreditCardTotal), "#####0.00")
        txtTotal2.text = Format$(Val(MinPymtTotal), "#####0.00")
        txtTotal3.Text = Format$(Val(MortgageTotal), "#####0.00")
        txtTotal4.Text = Format$(Val(MthTotal), "#####0.00")

    End Sub

    Private Sub GetdirpbsNameandBalance(sAccountNo As String, ByRef sBankName As String, ByRef nBalance As Double)

        Dim sSql As String
        Dim nCount As Integer

        'check dirpbs
        sSql = "Select * FROM dirpbs"
        sSql = sSql & " Where AccountNo = " + qte(sAccountNo)
        If giUserLevel = 2 Then
            sSql = sSql & " And UserName = " & qte(gsUserName)
        End If

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then

            nCount = 0

            Do While nCount <= ds.Rows.Count - 1

                If Not IsDBNull(ds.Rows.Item(nCount)("BankName")) Then
                    If sBankName = "" Then
                        sBankName = ds.Rows.Item(nCount)("BankName")
                    End If
                Else
                    sBankName = ""
                End If

                If Not IsDBNull(ds.Rows.Item(nCount)("Balance")) Then
                    nBalance = ds.Rows.Item(nCount)("Balance") 'Format$(Val(ssC("Balance")), "#####0.00")
                Else
                    nBalance = 0
                End If

                nCount = nCount + 1

            Loop

        End If

        ds.Dispose()

    End Sub

    Private Sub EditRecord(rec As Integer)

        Dim sSql As String = Nothing

        Select Case rec
            Case 0 'tab1
                txtAcctNoX.Tag = txtAcctNo1.Text
                txtNameX.Tag = txtName1.Text
                txtBalanceX.Tag = txtBalance1.Text
            Case 1
                txtAcctNoX.Tag = txtAcctNo2.Text
                txtNameX.Tag = txtName2.Text
                txtBalanceX.Tag = txtBalance2.Text
            Case 2
                txtAcctNoX.Tag = txtAcctNo3.Text
                txtNameX.Tag = txtName3.Text
                txtBalanceX.Tag = txtBalance3.Text
            Case 3
                txtAcctNoX.Tag = txtAcctNo4.Text
                txtNameX.Tag = txtName4.Text
                txtBalanceX.Tag = txtBalance4.Text
            Case 4
                txtAcctNoX.Tag = txtAcctNo5.Text
                txtNameX.Tag = txtName5.Text
                txtBalanceX.Tag = txtBalance5.Text
            Case 5
                txtAcctNoX.Tag = txtAcctNo6.Text
                txtNameX.Tag = txtName6.Text
                txtBalanceX.Tag = txtBalance6.Text
            Case 6
                txtAcctNoX.Tag = txtAcctNo7.Text
                txtNameX.Tag = txtName7.Text
                txtBalanceX.Tag = txtBalance7.Text
            Case 7
                txtAcctNoX.Tag = txtAcctNo8.Text
                txtNameX.Tag = txtName8.Text
                txtBalanceX.Tag = txtBalance8.Text

            Case 8 'tab2
                txtAcctNoX.Tag = txtAcctNo9.Text
                txtNameX.Tag = txtName9.Text
                txtBalanceX.Tag = txtBalance9.Text
                txtMinPymtX.Tag = txtMinPymt9.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate9.Tag), "0", txtDueDate9.Text)
                txtDueDateX.Tag = IIf(txtDueDate9.Tag = "", "30/12/1899", txtDueDate9.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd9.Tag), "0", txtZeropcEnd9.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd9.Tag = "", "30/12/1899", txtZeropcEnd9.Tag)
                txtRateX.Tag = txtRate9.Text
            Case 9
                txtAcctNoX.Tag = txtAcctNo10.Text
                txtNameX.Tag = txtName10.Text
                txtBalanceX.Tag = txtBalance10.Text
                txtMinPymtX.Tag = txtMinPymt10.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate10.Text), "0", txtDueDate10.Text)
                txtDueDateX.Tag = IIf(txtDueDate10.Tag = "", "30/12/1899", txtDueDate10.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd10.Text), "0", txtZeropcEnd10.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd10.Tag = "", "30/12/1899", txtZeropcEnd10.Tag)
                txtRateX.Tag = txtRate10.Text
            Case 10
                txtAcctNoX.Tag = txtAcctNo11.Text
                txtNameX.Tag = txtName11.Text
                txtBalanceX.Tag = txtBalance11.Text
                txtMinPymtX.Tag = txtMinPymt11.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate11.Text), "0", txtDueDate11.Text)
                txtDueDateX.Tag = IIf(txtDueDate11.Tag = "", "30/12/1899", txtDueDate11.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd11.Text), "0", txtZeropcEnd11.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd11.Tag = "", "30/12/1899", txtZeropcEnd11.Tag)
                txtRateX.Tag = txtRate11.Text
            Case 11
                txtAcctNoX.Tag = txtAcctNo12.Text
                txtNameX.Tag = txtName12.Text
                txtBalanceX.Tag = txtBalance12.Text
                txtMinPymtX.Tag = txtMinPymt12.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate12.Text), "0", txtDueDate12.Text)
                txtDueDateX.Tag = IIf(txtDueDate12.Tag = "", "30/12/1899", txtDueDate12.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd12.Text), "0", txtZeropcEnd12.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd12.Tag = "", "30/12/1899", txtZeropcEnd12.Tag)
                txtRateX.Tag = txtRate12.Text
            Case 12
                txtAcctNoX.Tag = txtAcctNo13.Text
                txtNameX.Tag = txtName13.Text
                txtBalanceX.Tag = txtBalance13.Text
                txtMinPymtX.Tag = txtMinPymt13.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate13.Text), "0", txtDueDate13.Text)
                txtDueDateX.Tag = IIf(txtDueDate13.Tag = "", "30/12/1899", txtDueDate13.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd13.Text), "0", txtZeropcEnd13.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd13.Tag = "", "30/12/1899", txtZeropcEnd13.Tag)
                txtRateX.Tag = txtRate13.Text
            Case 13
                txtAcctNoX.Tag = txtAcctNo14.Text
                txtNameX.Tag = txtName14.Text
                txtBalanceX.Tag = txtBalance14.Text
                txtMinPymtX.Tag = txtMinPymt14.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate14.Text), "0", txtDueDate14.Text)
                txtDueDateX.Tag = IIf(txtDueDate14.Tag = "", "30/12/1899", txtDueDate14.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd14.Text), "0", txtZeropcEnd14.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd14.Tag = "", "30/12/1899", txtZeropcEnd14.Tag)
                txtRateX.Tag = txtRate14.Text
            Case 14
                txtAcctNoX.Tag = txtAcctNo15.Text
                txtNameX.Tag = txtName15.Text
                txtBalanceX.Tag = txtBalance15.Text
                txtMinPymtX.Tag = txtMinPymt15.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate15.Text), "0", txtDueDate15.Text)
                txtDueDateX.Tag = IIf(txtDueDate15.Tag = "", "30/12/1899", txtDueDate15.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd15.Text), "0", txtZeropcEnd15.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd15.Tag = "", "30/12/1899", txtZeropcEnd15.Tag)
                txtRateX.Tag = txtRate15.Text
            Case 15
                txtAcctNoX.Tag = txtAcctNo16.Text
                txtNameX.Tag = txtName16.Text
                txtBalanceX.Tag = txtBalance16.Text
                txtMinPymtX.Tag = txtMinPymt16.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate16.Text), "0", txtDueDate16.Text)
                txtDueDateX.Tag = IIf(txtDueDate16.Tag = "", "30/12/1899", txtDueDate16.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd16.Text), "0", txtZeropcEnd16.Text)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd16.Tag = "", "30/12/1899", txtZeropcEnd16.Tag)
                txtRateX.Tag = txtRate16.Text

            Case 16 'tab3
                txtAcctNoX.Tag = txtAcctNo17.Text
                txtNameX.Tag = txtName17.Text
                txtBalanceX.Tag = txtBalance17.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate17.Text), "0", txtDueDate17.Text)
                txtDueDateX.Tag = IIf(txtDueDate17.Tag = "", "30/12/1899", txtDueDate17.Tag)
            Case 17
                txtAcctNoX.Tag = txtAcctNo18.Text
                txtNameX.Tag = txtName18.Text
                txtBalanceX.Tag = txtBalance18.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate18.Text), "0", txtDueDate18.Text)
                txtDueDateX.Tag = IIf(txtDueDate18.Tag = "", "30/12/1899", txtDueDate18.Tag)
            Case 18
                txtAcctNoX.Tag = txtAcctNo19.Text
                txtNameX.Tag = txtName19.Text
                txtBalanceX.Tag = txtBalance19.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate19.Text), "0", txtDueDate19.Text)
                txtDueDateX.Tag = IIf(txtDueDate19.Tag = "", "30/12/1899", txtDueDate19.Tag)
            Case 19
                txtAcctNoX.Tag = txtAcctNo20.Text
                txtNameX.Tag = txtName20.Text
                txtBalanceX.Tag = txtBalance20.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate20.Text), "0", txtDueDate20.Text)
                txtDueDateX.Tag = IIf(txtDueDate20.Tag = "", "30/12/1899", txtDueDate20.Tag)
            Case 20
                txtAcctNoX.Tag = txtAcctNo21.Text
                txtNameX.Tag = txtName21.Text
                txtBalanceX.Tag = txtBalance21.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate21.Text), "0", txtDueDate21.Text)
                txtDueDateX.Tag = IIf(txtDueDate21.Tag = "", "30/12/1899", txtDueDate21.Tag)
            Case 21
                txtAcctNoX.Tag = txtAcctNo22.Text
                txtNameX.Tag = txtName22.Text
                txtBalanceX.Tag = txtBalance22.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate22.Text), "0", txtDueDate22.Text)
                txtDueDateX.Tag = IIf(txtDueDate22.Tag = "", "30/12/1899", txtDueDate22.Tag)

            Case 29 'tab5
                txtAcctNoX.Tag = txtAcctNo30.Text
                txtNameX.Tag = txtName30.Text
                txtBalanceX.Tag = txtBalance30.Text
            Case 30
                txtAcctNoX.Tag = txtAcctNo31.Text
                txtNameX.Tag = txtName31.Text
                txtBalanceX.Tag = txtBalance31.Text

            Case 31
                txtAcctNoX.Tag = txtAcctNo32.Text
                txtNameX.Tag = txtName32.Text
                txtBalanceX.Tag = txtBalance32.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate32.Text), "0", txtDueDate32.Text) 'tag?
                txtDueDateX.Tag = IIf(txtDueDate32.Tag = "", "30/12/1899", txtDueDate32.Tag)
            Case 32
                txtAcctNoX.Tag = txtAcctNo33.Text
                txtNameX.Tag = txtName33.Text
                txtBalanceX.Tag = txtBalance33.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate33.Text), "0", txtDueDate33.Text)
                txtDueDateX.Tag = IIf(txtDueDate33.Tag = "", "30/12/1899", txtDueDate33.Tag)
            Case 33
                txtAcctNoX.Tag = txtAcctNo34.Text
                txtNameX.Tag = txtName34.Text
                txtBalanceX.Tag = txtBalance34.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate34.Text), "0", txtDueDate34.Text)
                txtDueDateX.Tag = IIf(txtDueDate34.Tag = "", "30/12/1899", txtDueDate34.Tag)
            Case 34
                txtAcctNoX.Tag = txtAcctNo35.Text
                txtNameX.Tag = txtName35.Text
                txtBalanceX.Tag = txtBalance35.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate35.Text), "0", txtDueDate35.Text)
                txtDueDateX.Tag = IIf(txtDueDate35.Tag = "", "30/12/1899", txtDueDate35.Tag)
            Case 35
                txtAcctNoX.Tag = txtAcctNo36.Text
                txtNameX.Tag = txtName36.Text
                txtBalanceX.Tag = txtBalance36.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate36.Text), "0", txtDueDate36.Text)
                txtDueDateX.Tag = IIf(txtDueDate36.Tag = "", "30/12/1899", txtDueDate36.Tag)
            Case 36
                txtAcctNoX.Tag = txtAcctNo37.Text
                txtNameX.Tag = txtName37.Text
                txtBalanceX.Tag = txtBalance37.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate37.Text), "0", txtDueDate37.Text)
                txtDueDateX.Tag = IIf(txtDueDate37.Tag = "", "30/12/1899", txtDueDate37.Tag)

            Case 37 'tab6
                txtAcctNoX.Tag = txtAcctNo38.Text
                txtNameX.Tag = txtName38.Text
                txtBalanceX.Tag = txtBalance38.Text
                txtMinPymtX.Tag = txtMinPymt38.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate38.Text), "0", txtDueDate38.Text)
                txtDueDateX.Tag = IIf(txtDueDate38.Tag = "", "30/12/1899", txtDueDate38.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd38.Text), "", txtZeropcEnd38.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd38.Tag = "", "30/12/1899", txtZeropcEnd38.Tag)
                txtRateX.Tag = txtRate38.Text
            Case 38
                txtAcctNoX.Tag = txtAcctNo39.Text
                txtNameX.Tag = txtName39.Text
                txtBalanceX.Tag = txtBalance39.Text
                txtMinPymtX.Tag = txtMinPymt39.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate39.Text), "0", txtDueDate39.Text)
                txtDueDateX.Tag = IIf(txtDueDate39.Tag = "", "30/12/1899", txtDueDate39.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd39.Text), "0", txtZeropcEnd39.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd39.Tag = "", "30/12/1899", txtZeropcEnd39.Tag)
                txtRateX.Tag = txtRate39.Text
            Case 39                                 'added 24/11/16
                txtAcctNoX.Tag = txtAcctNo40.Text
                txtNameX.Tag = txtName40.Text
                txtBalanceX.Tag = txtBalance40.Text
                txtMinPymtX.Tag = txtMinPymt40.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate40.Text), "0", txtDueDate40.Text)
                txtDueDateX.Tag = IIf(txtDueDate40.Tag = "", "30/12/1899", txtDueDate40.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd40.Text), "0", txtZeropcEnd40.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd40.Tag = "", "30/12/1899", txtZeropcEnd40.Tag)
                txtRateX.Tag = txtRate40.Text
            Case 40                                 'added 28/11/16
                txtAcctNoX.Tag = txtAcctNo41.Text
                txtNameX.Tag = txtName41.Text
                txtBalanceX.Tag = txtBalance41.Text
                txtMinPymtX.Tag = txtMinPymt41.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate41.Text), "0", txtDueDate41.Text)
                txtDueDateX.Tag = IIf(txtDueDate41.Tag = "", "30/12/1899", txtDueDate41.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd41.Text), "0", txtZeropcEnd41.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd41.Tag = "", "30/12/1899", txtZeropcEnd41.Tag)
                txtRateX.Tag = txtRate41.Text
            Case 41                                 'added 01/11/17
                txtAcctNoX.Tag = txtAcctNo42.Text
                txtNameX.Tag = txtName42.Text
                txtBalanceX.Tag = txtBalance42.Text
                txtMinPymtX.Tag = txtMinPymt42.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate42.Text), "0", txtDueDate42.Text)
                txtDueDateX.Tag = IIf(txtDueDate42.Tag = "", "30/12/1899", txtDueDate42.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd42.Text), "0", txtZeropcEnd42.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd42.Tag = "", "30/12/1899", txtZeropcEnd42.Tag)
                txtRateX.Tag = txtRate42.Text
            Case 42                                 'added 01/11/17
                txtAcctNoX.Tag = txtAcctNo43.Text
                txtNameX.Tag = txtName43.Text
                txtBalanceX.Tag = txtBalance43.Text
                txtMinPymtX.Tag = txtMinPymt43.Text
                txtDueDateX.Tag = IIf(IsDBNull(txtDueDate43.Text), "0", txtDueDate43.Text)
                txtDueDateX.Tag = IIf(txtDueDate43.Tag = "", "30/12/1899", txtDueDate43.Tag)
                txtZeropcEndX.Tag = IIf(IsDBNull(txtZeropcEnd43.Text), "0", txtZeropcEnd43.Tag)
                txtZeropcEndX.Tag = IIf(txtZeropcEnd43.Tag = "", "30/12/1899", txtZeropcEnd43.Tag)
                txtRateX.Tag = txtRate43.Text
        End Select

        If txtAcctNoX.Tag <> "" Or UCase(txtAcctNoX.Tag) = UCase("x") _
            Or txtNameX.Tag <> "" Or UCase(txtNameX.Tag) = UCase("x") Then 'Added Delete row option 06/02/16. Allow non-blank txtName 19/04/16

            'Delete values in this row and update db - Added 06/02/16
            If UCase(txtAcctNoX.Tag) = UCase("x") Or UCase(txtNameX.Tag) = UCase("x") Then
                txtAcctNoX.Text = ""
                txtAcctNoX.Tag = ""
                txtNameX.Text = ""
                txtNameX.Tag = ""
                txtBalanceX.Tag = ""
            End If

            'Update values in Finance table
            sSql = " Update Finance"
            sSql = sSql + " Set AccountNo = " + qte(txtAcctNoX.Tag)
            sSql = sSql + ", Name = " + qte(txtNameX.Tag)
            sSql = sSql + ", Balance = " + qte(Format(Val(txtBalanceX.Tag), "#####0.00"))
            If txtNameX.Tag <> "" Then 'update display values for report
                sSql = sSql + ", BalanceText = " + qte(Format(Val(txtBalanceX.Tag), "#####0.00"))
            Else
                sSql = sSql + ", BalanceText = ' '"
            End If

            If rec > 7 And rec < 16 Then 'tab 2, recs 8 to 15 only
                sSql = sSql + ", MinPymt = " + qte(Format(Val(txtMinPymtX.Tag), "#####0.00"))
                sSql = sSql + ", DueDate = " + AccessDate(Date.Parse(txtDueDateX.Tag)) ' NullToZero
                sSql = sSql + ", ZeropcEnd = " + AccessDate(Date.Parse(txtZeropcEndX.Tag)) 'NullToZero
                If txtNameX.Tag <> "" Then 'update display values for report
                    If txtDueDateX.Tag = "00:00:00" Or txtDueDateX.Tag = "30/12/1899" Then
                        sSql = sSql + ", DueDateText = ''"
                    Else
                        sSql = sSql + ", DueDateText = " + AccessDate(Date.Parse(txtDueDateX.Tag))
                    End If
                    If txtZeropcEndX.Tag = "00:00:00" Or txtZeropcEndX.Tag = "30/12/1899" Then
                        sSql = sSql + ", ZeropcEndText  = ''"
                    Else
                        sSql = sSql + ", ZeropcEndText = " + AccessDate(Date.Parse(txtZeropcEndX.Tag))
                    End If
                Else
                    sSql = sSql + ", DueDateText = ''"
                    sSql = sSql + ", ZeropcEndText = ''"
                End If
                sSql = sSql + ", Rate = " + qte(Format(Val(txtRateX.Tag), "##0.00"))
            End If

            If rec > 15 And rec < 22 Then 'tab 3, recs 16 to 21 only
                sSql = sSql + ", DueDate = " + AccessDate(Date.Parse(txtDueDateX.Tag)) ' NullToZero
                If txtNameX.Tag <> "" Then 'update display values for report
                    If txtDueDateX.Tag = "00:00:00" Or txtDueDateX.Tag = "30/12/1899" Then
                        sSql = sSql + ", DueDateText = ''"
                    Else
                        sSql = sSql + ", DueDateText = " + AccessDate(Date.Parse(txtDueDateX.Tag))
                    End If
                Else
                    sSql = sSql + ", DueDateText = ''"
                End If
            End If

            'If rec > 22 And rec < 29 Then 'tab 4, recs 23 to 28 only, no 22 - Was Albatros
            'End If

            If rec > 30 And rec <= 36 Then 'tab 5, recs 31 to 36 only, no 29 or 30
                sSql = sSql + ", DueDate = " + AccessDate(Date.Parse(txtDueDateX.Tag)) 'NullToZero?
                If txtNameX.Tag <> "" Then 'update display values for report
                    If txtDueDateX.Tag = "00:00:00" Or txtDueDateX.Tag = "30/12/1899" Then
                        sSql = sSql + ", DueDateText = ''"
                    Else
                        sSql = sSql + ", DueDateText = " + AccessDate(Date.Parse(txtDueDateX.Tag))
                    End If
                Else
                    sSql = sSql + ", DueDateText = ''"
                End If
            End If

            If rec > 36 And rec <= 42 Then 'tab 6, recs 37 to 40 only, no 29 or 30 added 2 more records 01/11/17
                sSql = sSql + ", MinPymt = " + qte(Format(Val(txtMinPymtX.Tag), "#####0.00"))
                sSql = sSql + ", DueDate = " + AccessDate(Date.Parse(txtDueDateX.Tag)) 'NullToZero
                sSql = sSql + ", ZeropcEnd = " + AccessDate(Date.Parse(txtZeropcEndX.Tag)) 'NullToZero
                If txtNameX.Tag <> "" Then 'update display values for report
                    If txtDueDateX.Tag = "00:00:00" Or txtDueDateX.Tag = "30/12/1899" Then
                        sSql = sSql + ", DueDateText = ''"
                    Else
                        sSql = sSql + ", DueDateText = " + AccessDate(Date.Parse(txtDueDateX.Tag))
                    End If
                    If txtZeropcEndX.Tag = "00:00:00" Or txtZeropcEndX.Tag = "30/12/1899" Then
                        sSql = sSql + ", ZeropcEndText  = ''"
                    Else
                        sSql = sSql + ", ZeropcEndText = " + AccessDate(Date.Parse(txtZeropcEndX.Tag))
                    End If
                Else
                    sSql = sSql + ", DueDateText = ''"
                    sSql = sSql + ", ZeropcEndText = ''"
                End If
                sSql = sSql + ", Rate = " + qte(Format(Val(txtRateX.Tag), "##0.00"))

            End If

            If rec = 0 Then     'Tab1
                sSql = sSql + ", [Currency] = " + qte(txtCcy0.Text)
            ElseIf rec = 8 Then 'Tab2
                sSql = sSql + ", [Currency] = " + qte(txtCcy1.Text)
            ElseIf rec = 16 Then 'Tab3
            ElseIf rec = 22 Then 'Tab4 - Was Albatros
            ElseIf rec = 29 Then 'Tab5
                sSql = sSql + ", [Currency] = " + qte(txtCcy3.Text)
            ElseIf rec = 30 Then 'Tab5
                sSql = sSql + ", [Currency] = " + qte(txtCcy4.Text)
            ElseIf rec = 37 Then 'Tab6
                sSql = sSql + ", [Currency] = " + qte(txtCcy5.Text)
            End If

            sSql = sSql + " Where Tab = " + CStr(rec)

            'On Error Resume Next

            If DoSql(sSql, 1) Then
            End If

            'On Error GoTo 0
        End If

    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click

        miUpdate = True
        Call SetControlsTrue()
        lblDeleteRow.Visible = True '06/02/16

    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

        Call SetHourGlassWait()

        'On Error GoTo Cmd3DOK_Click_Error

        'Report1.DataFiles(0) = gsDBFileName
        AxCrystalReport2.ReportFileName = gsReportDir & "\FinanceStatementRPT.rpt"
        AxCrystalReport2.ReportSource = 0            'use rpt format
        AxCrystalReport2.Destination = 0             'Screen
        'Call SetPrinterOrient(PORTRAIT)
        '   On Error GoTo Retry
        '   Result = Report1.PrintReport
        AxCrystalReport2.Action = 1                  'Do it
        '   On Error GoTo 0
        'Call ReSetPrinterOrient()

        Call SetHourGlassDefault()

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        Dim rec As Integer

        For rec = 0 To 42 'was 40, was 39 'was 38 '39 'was 36 01/11/17

            'are we in add mode?
            If Not miUpdate Then
                'Call AddNewRecord(rec)
            Else
                Call EditRecord(rec)
            End If

        Next rec

        Call UpdateFinanceBalances() 'added 27/04/16
        Call GetFinanceDetails() 'refresh data
        Call SetControlsFalse()

        lblDeleteRow.Visible = False
        miUpdate = True

        cmdEdit.Enabled = True
        cmdReport.Enabled = True
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Call GetFinanceDetails() 'reset data
        Call SetControlsFalse()

        lblDeleteRow.Visible = False '06/02/16

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub SetControlsFalse()

        grpBankAccounts.Enabled = False
        grpCreditCards.Enabled = False
        grpToPayToCome.Enabled = False
        grpAquavista.Enabled = False
        grpMortgages.Enabled = False

        cmdAdd.Visible = False
        cmdEdit.Enabled = True
        cmdReport.Enabled = True
        cmdOk.Enabled = False
        cmdCancel.Enabled = False
        cmdClose.Enabled = True

    End Sub

    Private Sub SetControlsTrue()

        Dim rec As Integer

        grpBankAccounts.Enabled = True
        grpCreditCards.Enabled = True
        grpToPayToCome.Enabled = True
        grpAquavista.Enabled = True
        grpMortgages.Enabled = True

        For rec = 0 To 39

            If rec >= 0 And rec < 8 Then 'tab 1, recs 0 to 7 only
                txtAcctNo1.Enabled = True
                txtName1.Enabled = True
                txtAcctNo2.Enabled = True
                txtName2.Enabled = True
                txtAcctNo3.Enabled = True
                txtName3.Enabled = True
                txtAcctNo4.Enabled = True
                txtName4.Enabled = True
                txtAcctNo5.Enabled = True
                txtName5.Enabled = True
                txtAcctNo6.Enabled = True
                txtName6.Enabled = True
                txtAcctNo7.Enabled = True
                txtName7.Enabled = True
                txtAcctNo8.Enabled = True
                txtName8.Enabled = True
            End If

            If rec > 7 And rec < 16 Then 'tab 2, recs 8 to 15 only
                txtAcctNo9.Enabled = True
                txtName9.Enabled = True
                txtMinPymt9.Enabled = True
                txtDueDate9.Enabled = True
                txtZeropcEnd9.Enabled = True
                txtRate9.Enabled = True
                txtAcctNo10.Enabled = True
                txtName10.Enabled = True
                txtMinPymt10.Enabled = True
                txtDueDate10.Enabled = True
                txtZeropcEnd10.Enabled = True
                txtRate10.Enabled = True
                txtAcctNo11.Enabled = True
                txtName11.Enabled = True
                txtMinPymt11.Enabled = True
                txtDueDate11.Enabled = True
                txtZeropcEnd11.Enabled = True
                txtRate11.Enabled = True
                txtAcctNo12.Enabled = True
                txtName12.Enabled = True
                txtMinPymt12.Enabled = True
                txtDueDate12.Enabled = True
                txtZeropcEnd12.Enabled = True
                txtRate12.Enabled = True
                txtAcctNo13.Enabled = True
                txtName13.Enabled = True
                txtMinPymt13.Enabled = True
                txtDueDate13.Enabled = True
                txtZeropcEnd13.Enabled = True
                txtRate13.Enabled = True
                txtAcctNo14.Enabled = True
                txtName14.Enabled = True
                txtMinPymt14.Enabled = True
                txtDueDate14.Enabled = True
                txtZeropcEnd14.Enabled = True
                txtRate14.Enabled = True
                txtAcctNo15.Enabled = True
                txtName15.Enabled = True
                txtMinPymt15.Enabled = True
                txtDueDate15.Enabled = True
                txtZeropcEnd15.Enabled = True
                txtRate15.Enabled = True
                txtAcctNo16.Enabled = True
                txtName16.Enabled = True
                txtMinPymt16.Enabled = True
                txtDueDate16.Enabled = True
                txtZeropcEnd16.Enabled = True
                txtRate16.Enabled = True
            End If

            If rec > 15 And rec < 22 Then 'tab 3, recs 16 to 21 
                txtName17.Enabled = True
                txtBalance17.Enabled = True
                txtDueDate17.Enabled = True
                txtName18.Enabled = True
                txtBalance18.Enabled = True
                txtDueDate18.Enabled = True
                txtName19.Enabled = True
                txtBalance19.Enabled = True
                txtDueDate19.Enabled = True
                txtName20.Enabled = True
                txtBalance20.Enabled = True
                txtDueDate20.Enabled = True
                txtName21.Enabled = True
                txtBalance21.Enabled = True
                txtDueDate21.Enabled = True
                txtName22.Enabled = True
                txtBalance22.Enabled = True
                txtDueDate22.Enabled = True

            End If

            If rec > 22 And rec < 29 Then 'tab 4, recs 23 to 28 only, no 22 ' Albatros
            End If

            If rec > 28 And rec < 37 Then 'tab 5, recs 29 to 36 only
                txtAcctNo30.Enabled = True
                txtName30.Enabled = True
                txtAcctNo31.Enabled = True
                txtName31.Enabled = True
                '
                txtName32.Enabled = True
                txtBalance32.Enabled = True
                txtDueDate32.Enabled = True
                txtName33.Enabled = True
                txtBalance33.Enabled = True
                txtDueDate33.Enabled = True
                txtName34.Enabled = True
                txtBalance34.Enabled = True
                txtDueDate34.Enabled = True
                txtName35.Enabled = True
                txtBalance35.Enabled = True
                txtDueDate35.Enabled = True
                txtName36.Enabled = True
                txtBalance36.Enabled = True
                txtDueDate36.Enabled = True
                txtName37.Enabled = True
                txtBalance37.Enabled = True
                txtDueDate37.Enabled = True
            End If

            If rec > 36 And rec <= 39 Then 'tab 6, recs 37 to 39 only

                txtAcctNo38.Enabled = True
                txtName38.Enabled = True
                txtMinPymt38.Visible = True
                txtDueDate38.Visible = True
                txtZeropcEnd38.Visible = True
                txtRate38.Enabled = True
                txtAcctNo39.Enabled = True
                txtName39.Enabled = True
                txtMinPymt39.Enabled = True
                txtDueDate39.Enabled = True
                txtZeropcEnd39.Enabled = True
                'added 24/11/16
                txtRate40.Enabled = True
                txtAcctNo40.Enabled = True
                txtName40.Enabled = True
                txtMinPymt40.Enabled = True
                txtDueDate40.Enabled = True
                txtZeropcEnd40.Enabled = True
                txtRate40.Enabled = True
                'added 28/11/16
                txtRate41.Enabled = True
                txtAcctNo41.Enabled = True
                txtName41.Enabled = True
                txtMinPymt41.Enabled = True
                txtDueDate41.Enabled = True
                txtZeropcEnd41.Enabled = True
                txtRate41.Enabled = True
                'added 01/11/17
                txtRate42.Enabled = True
                txtAcctNo42.Enabled = True
                txtName42.Enabled = True
                txtMinPymt42.Enabled = True
                txtDueDate42.Enabled = True
                txtZeropcEnd42.Enabled = True
                txtRate42.Enabled = True
                'added 01/11/17
                txtRate43.Enabled = True
                txtAcctNo43.Enabled = True
                txtName43.Enabled = True
                txtMinPymt43.Enabled = True
                txtDueDate43.Enabled = True
                txtZeropcEnd43.Enabled = True
                txtRate43.Enabled = True
            End If
        Next rec

        cmdAdd.Visible = False
        cmdEdit.Enabled = False
        cmdReport.Enabled = False
        cmdOk.Enabled = True
        cmdCancel.Enabled = True
        'cmdClose.Enabled = False

    End Sub

    Private Sub txtAcctNo1_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo1.LostFocus
        'tab 1
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo1.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName1.Text = sBankName
        txtBalance1.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo2_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo2.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo2.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName2.Text = sBankName
        txtBalance2.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo3_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo3.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo3.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName3.Text = sBankName
        txtBalance3.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo4_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo4.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo4.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName4.Text = sBankName
        txtBalance4.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo5_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo5.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo5.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName5.Text = sBankName
        txtBalance5.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo6_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo6.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo6.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName6.Text = sBankName
        txtBalance6.Text = Format(nBalance, "#####0.00")

        nTab = 6

    End Sub

    Private Sub txtAcctNo7_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo7.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo7.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName7.Text = sBankName
        txtBalance7.Text = Format(nBalance, "#####0.00")

        nTab = 6

    End Sub

    Private Sub txtAcctNo8_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo8.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo8.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName8.Text = sBankName
        txtBalance8.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo9_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo9.LostFocus
        'tab2
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo9.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName9.Text = sBankName
        txtBalance9.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo10_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo10.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo10.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName10.Text = sBankName
        txtBalance10.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo11_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo11.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo11.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName11.Text = sBankName
        txtBalance11.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo12_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo12.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo12.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName12.Text = sBankName
        txtBalance12.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo13_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo3.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo13.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName13.Text = sBankName
        txtBalance13.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo14_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo14.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo14.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName14.Text = sBankName
        txtBalance14.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo15_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo15.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo15.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName15.Text = sBankName
        txtBalance15.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo16_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo16.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo16.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName16.Text = sBankName
        txtBalance16.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo30_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo30.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo30.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName30.Text = sBankName
        txtBalance30.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo31_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo31.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo31.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName31.Text = sBankName
        txtBalance31.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo38_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo38.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo38.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName38.Text = sBankName
        txtBalance38.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo39_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo39.LostFocus

        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo39.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName39.Text = sBankName
        txtBalance39.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo40_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo40.LostFocus
        'added 24/11/16
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo40.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName40.Text = sBankName
        txtBalance40.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo41_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo41.LostFocus
        'added 28/11/16
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo41.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName41.Text = sBankName
        txtBalance41.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo42_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo42.LostFocus
        'added 01/11/17
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo42.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName42.Text = sBankName
        txtBalance42.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtAcctNo43_LostFocus(sender As Object, e As EventArgs) Handles txtAcctNo41.LostFocus
        'added 01/11/17
        Dim sAccountno As String = Nothing
        Dim sBankName As String = Nothing
        Dim nBalance As Double = 0

        sAccountno = txtAcctNo43.Text
        Call GetdirpbsNameandBalance(sAccountno, sBankName, nBalance)

        txtName43.Text = sBankName
        txtBalance43.Text = Format(nBalance, "#####0.00")

    End Sub

    Private Sub txtDueDate9_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate9.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate9.Text = "" Or txtDueDate9.Text = " " Then
            txtDueDate9.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate9.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd9.Focus()
                Exit Sub
            End If
        End If

        txtDueDate9.Tag = FormatDateTime(txtDueDate9.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate9.Text = "30/12/1899" Then
            txtDueDate9.Text = ""
        End If

    End Sub

    Private Sub txtDueDate10_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate10.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate10.Text = "" Or txtDueDate10.Text = " " Then
            txtDueDate10.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate9.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd10.Focus()
                Exit Sub
            End If
        End If

        txtDueDate10.Tag = FormatDateTime(txtDueDate10.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate10.Text = "30/12/1899" Then
            txtDueDate10.Text = ""
        End If

    End Sub

    Private Sub txtDueDate11_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate11.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate11.Text = "" Or txtDueDate11.Text = " " Then
            txtDueDate11.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate11.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd11.Focus()
                Exit Sub
            End If
        End If

        txtDueDate11.Tag = FormatDateTime(txtDueDate11.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate11.Text = "30/12/1899" Then
            txtDueDate11.Text = ""
        End If

    End Sub

    Private Sub txtDueDate12_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate12.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate12.Text = "" Or txtDueDate12.Text = " " Then
            txtDueDate9.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate12.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd12.Focus()
                Exit Sub
            End If
        End If

        txtDueDate12.Tag = FormatDateTime(txtDueDate12.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate12.Text = "30/12/1899" Then
            txtDueDate12.Text = ""
        End If

    End Sub

    Private Sub txtDueDate13_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate13.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate13.Text = "" Or txtDueDate13.Text = " " Then
            txtDueDate9.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate13.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd13.Focus()
                Exit Sub
            End If
        End If

        txtDueDate13.Tag = FormatDateTime(txtDueDate13.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate13.Text = "30/12/1899" Then
            txtDueDate13.Text = ""
        End If

    End Sub

    Private Sub txtDueDate14_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate14.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate14.Text = "" Or txtDueDate14.Text = " " Then
            txtDueDate14.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate14.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd14.Focus()
                Exit Sub
            End If
        End If

        txtDueDate14.Tag = FormatDateTime(txtDueDate14.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate14.Text = "30/12/1899" Then
            txtDueDate14.Text = ""
        End If

    End Sub

    Private Sub txtDueDate15_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate15.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate15.Text = "" Or txtDueDate15.Text = " " Then
            txtDueDate15.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate15.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd15.Focus()
                Exit Sub
            End If
        End If

        txtDueDate15.Tag = FormatDateTime(txtDueDate15.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate15.Text = "30/12/1899" Then
            txtDueDate15.Text = ""
        End If

    End Sub

    Private Sub txtDueDate16_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate16.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate16.Text = "" Or txtDueDate16.Text = " " Then
            txtDueDate16.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate16.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd16.Focus()
                Exit Sub
            End If
        End If

        txtDueDate16.Tag = FormatDateTime(txtDueDate16.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate16.Text = "30/12/1899" Then
            txtDueDate16.Text = ""
        End If

    End Sub

    Private Sub txtDueDate17_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate17.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate17.Text = "" Or txtDueDate17.Text = " " Then
            txtDueDate17.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate17.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate17.Focus()
                Exit Sub
            End If
        End If

        txtDueDate17.Tag = FormatDateTime(txtDueDate17.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate17.Text = "30/12/1899" Then
            txtDueDate17.Text = ""
        End If

    End Sub

    Private Sub txtDueDate18_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate18.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate18.Text = "" Or txtDueDate18.Text = " " Then
            txtDueDate18.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate18.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate18.Focus()
                Exit Sub
            End If
        End If

        txtDueDate18.Tag = FormatDateTime(txtDueDate18.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate18.Text = "30/12/1899" Then
            txtDueDate18.Text = ""
        End If

    End Sub

    Private Sub txtDueDate19_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate19.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate19.Text = "" Or txtDueDate19.Text = " " Then
            txtDueDate19.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate19.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate19.Focus()
                Exit Sub
            End If
        End If

        txtDueDate19.Tag = FormatDateTime(txtDueDate19.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate19.Text = "30/12/1899" Then
            txtDueDate19.Text = ""
        End If

    End Sub

    Private Sub txtDueDate20_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate20.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate20.Text = "" Or txtDueDate20.Text = " " Then
            txtDueDate20.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate20.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate20.Focus()
                Exit Sub
            End If
        End If

        txtDueDate20.Tag = FormatDateTime(txtDueDate20.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate20.Text = "30/12/1899" Then
            txtDueDate20.Text = ""
        End If

    End Sub

    Private Sub txtDueDate21_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate21.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate21.Text = "" Or txtDueDate21.Text = " " Then
            txtDueDate21.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate21.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate21.Focus()
                Exit Sub
            End If
        End If

        txtDueDate21.Tag = FormatDateTime(txtDueDate21.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate21.Text = "30/12/1899" Then
            txtDueDate21.Text = ""
        End If

    End Sub

    Private Sub txtDueDate22_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate22.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate22.Text = "" Or txtDueDate22.Text = " " Then
            txtDueDate22.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate22.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate22.Focus()
                Exit Sub
            End If
        End If

        txtDueDate22.Tag = FormatDateTime(txtDueDate22.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate22.Text = "30/12/1899" Then
            txtDueDate22.Text = ""
        End If

    End Sub

    Private Sub txtDueDate32_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate32.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate32.Text = "" Or txtDueDate32.Text = " " Then
            txtDueDate32.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate32.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate32.Focus()
                Exit Sub
            End If
        End If

        txtDueDate32.Tag = FormatDateTime(txtDueDate32.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate32.Text = "30/12/1899" Then
            txtDueDate32.Text = ""
        End If

    End Sub

    Private Sub txtDueDate33_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate33.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate33.Text = "" Or txtDueDate33.Text = " " Then
            txtDueDate33.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate33.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate33.Focus()
                Exit Sub
            End If
        End If

        txtDueDate33.Tag = FormatDateTime(txtDueDate33.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate33.Text = "30/12/1899" Then
            txtDueDate33.Text = ""
        End If

    End Sub

    Private Sub txtDueDate34_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate34.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate34.Text = "" Or txtDueDate34.Text = " " Then
            txtDueDate34.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate34.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate34.Focus()
                Exit Sub
            End If
        End If

        txtDueDate34.Tag = FormatDateTime(txtDueDate34.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate34.Text = "30/12/1899" Then
            txtDueDate34.Text = ""
        End If

    End Sub

    Private Sub txtDueDate35_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate35.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate35.Text = "" Or txtDueDate35.Text = " " Then
            txtDueDate35.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate35.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate35.Focus()
                Exit Sub
            End If
        End If

        txtDueDate35.Tag = FormatDateTime(txtDueDate35.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate35.Text = "30/12/1899" Then
            txtDueDate35.Text = ""
        End If

    End Sub

    Private Sub txtDueDate36_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate36.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate36.Text = "" Or txtDueDate36.Text = " " Then
            txtDueDate36.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate36.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate36.Focus()
                Exit Sub
            End If
        End If

        txtDueDate36.Tag = FormatDateTime(txtDueDate36.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate36.Text = "30/12/1899" Then
            txtDueDate36.Text = ""
        End If

    End Sub

    Private Sub txtDueDate37_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate37.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate37.Text = "" Or txtDueDate37.Text = " " Then
            txtDueDate37.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate37.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate37.Focus()
                Exit Sub
            End If
        End If

        txtDueDate37.Tag = FormatDateTime(txtDueDate37.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate37.Text = "30/12/1899" Then
            txtDueDate37.Text = ""
        End If

    End Sub

    Private Sub txtDueDate38_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate38.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate38.Text = "" Or txtDueDate38.Text = " " Then
            txtDueDate38.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate38.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate38.Focus()
                Exit Sub
            End If
        End If

        txtDueDate38.Tag = FormatDateTime(txtDueDate38.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate38.Text = "30/12/1899" Then
            txtDueDate38.Text = ""
        End If

    End Sub

    Private Sub txtDueDate39_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate39.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate39.Text = "" Or txtDueDate39.Text = " " Then
            txtDueDate39.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate39.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate39.Focus()
                Exit Sub
            End If
        End If

        txtDueDate39.Tag = FormatDateTime(txtDueDate39.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate39.Text = "30/12/1899" Then
            txtDueDate39.Text = ""
        End If

    End Sub

    Private Sub txtDueDate40_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate40.LostFocus
        'added 24/11/16
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate40.Text = "" Or txtDueDate40.Text = " " Then
            txtDueDate40.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate40.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate40.Focus()
                Exit Sub
            End If
        End If

        txtDueDate40.Tag = FormatDateTime(txtDueDate40.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate40.Text = "30/12/1899" Then
            txtDueDate40.Text = ""
        End If

    End Sub

    Private Sub txtDueDate41_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate41.LostFocus
        'added 28/11/16
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate41.Text = "" Or txtDueDate41.Text = " " Then
            txtDueDate41.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate41.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate41.Focus()
                Exit Sub
            End If
        End If

        txtDueDate41.Tag = FormatDateTime(txtDueDate41.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate41.Text = "30/12/1899" Then
            txtDueDate41.Text = ""
        End If

    End Sub

    Private Sub txtDueDate42_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate42.LostFocus
        'added 01/11/17
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate42.Text = "" Or txtDueDate42.Text = " " Then
            txtDueDate42.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate42.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate42.Focus()
                Exit Sub
            End If
        End If

        txtDueDate42.Tag = FormatDateTime(txtDueDate42.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate42.Text = "30/12/1899" Then
            txtDueDate42.Text = ""
        End If

    End Sub

    Private Sub txtDueDate43_LostFocus(sender As Object, e As EventArgs) Handles txtDueDate43.LostFocus
        'added 01/11/17
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtDueDate43.Text = "" Or txtDueDate43.Text = " " Then
            txtDueDate43.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtDueDate43.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtDueDate43.Focus()
                Exit Sub
            End If
        End If

        txtDueDate43.Tag = FormatDateTime(txtDueDate43.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtDueDate43.Text = "30/12/1899" Then
            txtDueDate43.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd9_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd9.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd9.Text = "" Or txtZeropcEnd9.Text = " " Then
            txtZeropcEnd9.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd9.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd9.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd9.Tag = FormatDateTime(txtZeropcEnd9.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd9.Text = "30/12/1899" Then
            txtZeropcEnd9.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd10_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd10.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd10.Text = "" Or txtZeropcEnd10.Text = " " Then
            txtZeropcEnd10.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd10.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd10.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd10.Tag = FormatDateTime(txtZeropcEnd10.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd10.Text = "30/12/1899" Then
            txtZeropcEnd10.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd11_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd11.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd11.Text = "" Or txtZeropcEnd11.Text = " " Then
            txtZeropcEnd11.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd11.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd11.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd11.Tag = FormatDateTime(txtZeropcEnd11.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd11.Text = "30/12/1899" Then
            txtZeropcEnd11.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd12_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd12.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd12.Text = "" Or txtZeropcEnd12.Text = " " Then
            txtZeropcEnd12.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd12.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd12.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd12.Tag = FormatDateTime(txtZeropcEnd12.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd12.Text = "30/12/1899" Then
            txtZeropcEnd12.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd13_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd13.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd13.Text = "" Or txtZeropcEnd13.Text = " " Then
            txtZeropcEnd13.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd13.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd13.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd13.Tag = FormatDateTime(txtZeropcEnd13.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd13.Text = "30/12/1899" Then
            txtZeropcEnd13.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd14_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd14.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd14.Text = "" Or txtZeropcEnd14.Text = " " Then
            txtZeropcEnd14.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd14.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd14.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd14.Tag = FormatDateTime(txtZeropcEnd14.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd14.Text = "30/12/1899" Then
            txtZeropcEnd14.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd15_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd15.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd15.Text = "" Or txtZeropcEnd15.Text = " " Then
            txtZeropcEnd15.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd15.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd15.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd15.Tag = FormatDateTime(txtZeropcEnd15.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd15.Text = "30/12/1899" Then
            txtZeropcEnd15.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd16_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd16.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd16.Text = "" Or txtZeropcEnd16.Text = " " Then
            txtZeropcEnd16.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd16.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd16.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd16.Tag = FormatDateTime(txtZeropcEnd16.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd16.Text = "30/12/1899" Then
            txtZeropcEnd16.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd38_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd38.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd38.Text = "" Or txtZeropcEnd38.Text = " " Then
            txtZeropcEnd38.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd38.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd38.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd38.Tag = FormatDateTime(txtZeropcEnd38.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd38.Text = "30/12/1899" Then
            txtZeropcEnd38.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd39_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd39.LostFocus

        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd39.Text = "" Or txtZeropcEnd39.Text = " " Then
            txtZeropcEnd39.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd39.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd39.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd39.Tag = FormatDateTime(txtZeropcEnd39.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd39.Text = "30/12/1899" Then
            txtZeropcEnd39.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd40_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd40.LostFocus
        'added 24/11/16
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd40.Text = "" Or txtZeropcEnd40.Text = " " Then
            txtZeropcEnd40.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd40.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd40.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd40.Tag = FormatDateTime(txtZeropcEnd40.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd40.Text = "30/12/1899" Then
            txtZeropcEnd40.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd41_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd41.LostFocus
        'added 28/11/16
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd41.Text = "" Or txtZeropcEnd41.Text = " " Then
            txtZeropcEnd41.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd41.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd41.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd41.Tag = FormatDateTime(txtZeropcEnd41.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd41.Text = "30/12/1899" Then
            txtZeropcEnd41.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd42_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd42.LostFocus
        'added 01/11/17
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd42.Text = "" Or txtZeropcEnd42.Text = " " Then
            txtZeropcEnd42.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd42.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd42.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd42.Tag = FormatDateTime(txtZeropcEnd42.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd42.Text = "30/12/1899" Then
            txtZeropcEnd42.Text = ""
        End If

    End Sub

    Private Sub txtZeropcEnd43_LostFocus(sender As Object, e As EventArgs) Handles txtZeropcEnd43.LostFocus
        'added 01/11/17
        Dim msg As String = Nothing
        Dim Title As String = Nothing

        If txtZeropcEnd43.Text = "" Or txtZeropcEnd43.Text = " " Then
            txtZeropcEnd43.Text = FormatDateTime("30/12/1899", DateFormat.ShortDate)
        Else
            If Not IsDate(txtZeropcEnd43.Text) Then
                msg = " Date error - please rectify"
                Title = "Enter date"
                MsgBox(msg, vbExclamation, Title)
                txtZeropcEnd43.Focus()
                Exit Sub
            End If
        End If

        txtZeropcEnd43.Tag = FormatDateTime(txtZeropcEnd43.Text, DateFormat.ShortDate) '"dd/mm/yyyy")

        If txtZeropcEnd43.Text = "30/12/1899" Then
            txtZeropcEnd43.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt10_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt10.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt10.Text = "" Or txtMinPymt10.Text = " " Then
            txtMinPymt10.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt10.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt10.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt10.Tag = Format$(txtMinPymt10.Text, "#####0.00")

        If txtMinPymt10.Text = " " Then
            txtMinPymt10.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt11_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt11.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt11.Text = "" Or txtMinPymt11.Text = " " Then
            txtMinPymt11.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt11.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt11.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt11.Tag = Format$(txtMinPymt11.Text, "#####0.00")

        If txtMinPymt11.Text = " " Then
            txtMinPymt11.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt12_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt12.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt12.Text = "" Or txtMinPymt12.Text = " " Then
            txtMinPymt12.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt12.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt12.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt12.Tag = Format$(txtMinPymt12.Text, "#####0.00")

        If txtMinPymt12.Text = " " Then
            txtMinPymt12.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt13_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt13.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt13.Text = "" Or txtMinPymt13.Text = " " Then
            txtMinPymt13.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt13.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt13.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt13.Tag = Format$(txtMinPymt13.Text, "#####0.00")

        If txtMinPymt13.Text = " " Then
            txtMinPymt13.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt14_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt14.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt14.Text = "" Or txtMinPymt14.Text = " " Then
            txtMinPymt14.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt14.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt14.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt14.Tag = Format$(txtMinPymt14.Text, "#####0.00")

        If txtMinPymt14.Text = " " Then
            txtMinPymt14.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt15_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt15.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt15.Text = "" Or txtMinPymt15.Text = " " Then
            txtMinPymt15.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt15.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt15.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt15.Tag = Format$(txtMinPymt15.Text, "#####0.00")

        If txtMinPymt15.Text = " " Then
            txtMinPymt15.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt16_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt16.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt16.Text = "" Or txtMinPymt16.Text = " " Then
            txtMinPymt16.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt16.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt16.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt16.Tag = Format$(txtMinPymt16.Text, "#####0.00")

        If txtMinPymt16.Text = " " Then
            txtMinPymt16.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt38_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt38.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt38.Text = "" Or txtMinPymt38.Text = " " Then
            txtMinPymt38.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt38.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt38.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt38.Tag = Format$(txtMinPymt38.Text, "#####0.00")

        If txtMinPymt38.Text = " " Then
            txtMinPymt38.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt39_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt39.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt39.Text = "" Or txtMinPymt39.Text = " " Then
            txtMinPymt39.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt39.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt39.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt39.Tag = Format$(txtMinPymt39.Text, "#####0.00")

        If txtMinPymt39.Text = " " Then
            txtMinPymt39.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt40_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt40.LostFocus
        'added 24/11/16
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt40.Text = "" Or txtMinPymt40.Text = " " Then
            txtMinPymt40.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt40.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt40.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt40.Tag = Format$(txtMinPymt40.Text, "#####0.00")

        If txtMinPymt40.Text = " " Then
            txtMinPymt40.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt41_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt41.LostFocus
        'added 28/11/16
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt41.Text = "" Or txtMinPymt41.Text = " " Then
            txtMinPymt41.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt41.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt41.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt41.Tag = Format$(txtMinPymt41.Text, "#####0.00")

        If txtMinPymt41.Text = " " Then
            txtMinPymt41.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt42_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt42.LostFocus
        'added 01/11/17
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt42.Text = "" Or txtMinPymt42.Text = " " Then
            txtMinPymt42.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt42.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt42.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt42.Tag = Format$(txtMinPymt42.Text, "#####0.00")

        If txtMinPymt42.Text = " " Then
            txtMinPymt42.Text = ""
        End If

    End Sub

    Private Sub txtMinPymt43_LostFocus(sender As Object, e As EventArgs) Handles txtMinPymt43.LostFocus
        'added 01/11/17
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtMinPymt43.Text = "" Or txtMinPymt43.Text = " " Then
            txtMinPymt43.Text = Format(0, "#####0.00")
        Else
            If Not IsNumeric(txtMinPymt43.Text) Then
                Msg = " Amount error - please rectify"
                Title = "Enter amount"
                MsgBox(Msg, vbExclamation, Title)
                txtMinPymt43.Focus()
                Exit Sub
            End If
        End If

        txtMinPymt43.Tag = Format$(txtMinPymt43.Text, "#####0.00")

        If txtMinPymt43.Text = " " Then
            txtMinPymt43.Text = ""
        End If

    End Sub

    Private Sub txtRate9_LostFocus(sender As Object, e As EventArgs) Handles txtRate9.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate9.Text = "" Or txtRate9.Text = " " Then
            txtRate9.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate9.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate9.Focus()
                Exit Sub
            End If
        End If

        txtRate9.Tag = Format$(txtRate9.Text, "#####0.00")

        If txtRate9.Text = " " Then
            txtRate9.Text = ""
        End If

    End Sub

    Private Sub txtRate10_LostFocus(sender As Object, e As EventArgs) Handles txtRate10.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate10.Text = "" Or txtRate10.Text = " " Then
            txtRate10.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate10.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate10.Focus()
                Exit Sub
            End If
        End If

        txtRate10.Tag = Format$(txtRate10.Text, "#####0.00")

        If txtRate10.Text = " " Then
            txtRate10.Text = ""
        End If

    End Sub

    Private Sub txtRate11_LostFocus(sender As Object, e As EventArgs) Handles txtRate11.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate11.Text = "" Or txtRate11.Text = " " Then
            txtRate11.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate11.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate11.Focus()
                Exit Sub
            End If
        End If

        txtRate11.Tag = Format$(txtRate11.Text, "#####0.00")

        If txtRate11.Text = " " Then
            txtRate11.Text = ""
        End If

    End Sub

    Private Sub txtRate12_LostFocus(sender As Object, e As EventArgs) Handles txtRate12.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate12.Text = "" Or txtRate12.Text = " " Then
            txtRate12.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate12.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate12.Focus()
                Exit Sub
            End If
        End If

        txtRate12.Tag = Format$(txtRate12.Text, "#####0.00")

        If txtRate12.Text = " " Then
            txtRate12.Text = ""
        End If

    End Sub

    Private Sub txtRate13_LostFocus(sender As Object, e As EventArgs) Handles txtRate13.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate13.Text = "" Or txtRate13.Text = " " Then
            txtRate13.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate13.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate13.Focus()
                Exit Sub
            End If
        End If

        txtRate13.Tag = Format$(txtRate13.Text, "#####0.00")

        If txtRate13.Text = " " Then
            txtRate13.Text = ""
        End If

    End Sub

    Private Sub txtRate14_LostFocus(sender As Object, e As EventArgs) Handles txtRate14.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate14.Text = "" Or txtRate14.Text = " " Then
            txtRate14.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate14.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate14.Focus()
                Exit Sub
            End If
        End If

        txtRate14.Tag = Format$(txtRate14.Text, "#####0.00")

        If txtRate14.Text = " " Then
            txtRate14.Text = ""
        End If

    End Sub

    Private Sub txtRate15_LostFocus(sender As Object, e As EventArgs) Handles txtRate15.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate15.Text = "" Or txtRate15.Text = " " Then
            txtRate15.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate15.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate15.Focus()
                Exit Sub
            End If
        End If

        txtRate15.Tag = Format$(txtRate15.Text, "#####0.00")

        If txtRate15.Text = " " Then
            txtRate15.Text = ""
        End If

    End Sub

    Private Sub txtRate16_LostFocus(sender As Object, e As EventArgs) Handles txtRate16.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate16.Text = "" Or txtRate16.Text = " " Then
            txtRate16.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate16.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate16.Focus()
                Exit Sub
            End If
        End If

        txtRate16.Tag = Format$(txtRate16.Text, "#####0.00")

        If txtRate16.Text = " " Then
            txtRate16.Text = ""
        End If

    End Sub

    Private Sub txtRate38_LostFocus(sender As Object, e As EventArgs) Handles txtRate38.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate38.Text = "" Or txtRate38.Text = " " Then
            txtRate38.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate38.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate38.Focus()
                Exit Sub
            End If
        End If

        txtRate38.Tag = Format$(txtRate38.Text, "#####0.00")

        If txtRate38.Text = " " Then
            txtRate38.Text = ""
        End If

    End Sub

    Private Sub txtRate39_LostFocus(sender As Object, e As EventArgs) Handles txtRate39.LostFocus

        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate39.Text = "" Or txtRate39.Text = " " Then
            txtRate39.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate39.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate39.Focus()
                Exit Sub
            End If
        End If

        txtRate39.Tag = Format$(txtRate39.Text, "#####0.00")

        If txtRate39.Text = " " Then
            txtRate39.Text = ""
        End If

    End Sub

    Private Sub txtRate40_LostFocus(sender As Object, e As EventArgs) Handles txtRate40.LostFocus
        'added 24/11/16
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate40.Text = "" Or txtRate40.Text = " " Then
            txtRate40.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate40.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate40.Focus()
                Exit Sub
            End If
        End If

        txtRate40.Tag = Format$(txtRate40.Text, "#####0.00")

        If txtRate40.Text = " " Then
            txtRate40.Text = ""
        End If

    End Sub

    Private Sub txtRate41_LostFocus(sender As Object, e As EventArgs) Handles txtRate41.LostFocus
        'added 28/11/16
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate41.Text = "" Or txtRate41.Text = " " Then
            txtRate41.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate41.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate41.Focus()
                Exit Sub
            End If
        End If

        txtRate41.Tag = Format$(txtRate41.Text, "#####0.00")

        If txtRate41.Text = " " Then
            txtRate41.Text = ""
        End If

    End Sub

    Private Sub txtRate42_LostFocus(sender As Object, e As EventArgs) Handles txtRate42.LostFocus
        'added 01/11/17
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate42.Text = "" Or txtRate42.Text = " " Then
            txtRate41.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate42.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate42.Focus()
                Exit Sub
            End If
        End If

        txtRate42.Tag = Format$(txtRate42.Text, "#####0.00")

        If txtRate42.Text = " " Then
            txtRate42.Text = ""
        End If

    End Sub

    Private Sub txtRate43_LostFocus(sender As Object, e As EventArgs) Handles txtRate43.LostFocus
        'added 01/11/17
        Dim Msg As String = Nothing
        Dim Title As String = Nothing

        If txtRate42.Text = "" Or txtRate42.Text = " " Then
            txtRate41.Text = Format$(0, "#####0.00")
        Else
            If Not IsNumeric(txtRate42.Text) Then
                Msg = " Rate error - please rectify"
                Title = "Enter rate"
                MsgBox(Msg, vbExclamation, Title)
                txtRate42.Focus()
                Exit Sub
            End If
        End If

        txtRate42.Tag = Format$(txtRate42.Text, "#####0.00")

        If txtRate42.Text = " " Then
            txtRate42.Text = ""
        End If

    End Sub

    Private Sub CmdOkReport_Click(sender As Object, e As EventArgs)

        Call SetHourGlassWait()

        'On Error GoTo Cmd3DOK_Click_Error

        'Report1.DataFiles(0) = gsDBFileName
        'AxCrystalReport1.ReportFileName = gsReportDir & "\FinanceStatementRPT.rpt"
        'AxCrystalReport1.ReportSource = 0            'use rpt format
        'AxCrystalReport1.Destination = 0             'Screen
        'Call SetPrinterOrient(PORTRAIT)
        '   On Error GoTo Retry
        '   Result = Report1.PrintReport
        'AxCrystalReport2.Action = 1                  'Do it
        '   On Error GoTo 0
        'Call ReSetPrinterOrient()

        Call SetHourGlassDefault()

    End Sub
End Class