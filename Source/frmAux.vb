'****************************************************************************************************************************
'Visual Personal Data System v2013
'Copyright Jack Gibbons 1980-2017
'
'incorporating  
'
'****************************************************************************************************************************
'Created by jpg   22/03/15
'        
'Amendments 
'
'Date       Who     Description
'22/03/15   jpg     Copied from Vpbs78
'30/12/15   jpg     modified to use three datagrids
'30/01/16   jpg     Dataviews and Reports working for all Aux tables
'                   Modified for Add, Change and Delete - Books DB only
'24/04/16           Added new records to Project Video DB using VisData
'24/04/16           Copied updated Project Video DB to VPBS dir to run report
'03/12/16           Video completed. Changed project to use VPBS dir. Modified Video DB to accept zero length data.
'                   Books completed. Books DB fields already set to accept zero length data
'04/12/16           Address (COI) completed. Changed project to use VPBS dir. Modified Address DB to accept zero length data.
'05/12/16           Sharp completed. Changed project to use VPBS dir. Added key. Modified Address DB to accept zero length data.
'09/12/16           Added [] to some Sharp fields so update to work
'09/12/16           Added FldList for Sharp Table. Amended to show Sharp records
'                   SaveQuery
'30/12/16           Add and EditVideoTransaction - removed '0'
'13/03/17   jpg     Added gsAuxDBName for all Aux DB's only as VPBS DB Live value corrupted
'****************************************************************************************************************************
Public Class frmAux

    Dim db As DataTableCollection
    Dim tbl As DataTable
    Dim sFilename As String
    Dim sTBName As String
    Dim sReportTitle As String
    'Dim sAuxConnection As String
    Dim miUpdate As Integer = Nothing

    Private Sub frmAux_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsVpbsConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\VPBS\" + gsAuxDBName

        Select Case gsAuxDBName

            Case "Books.mdb"

                Me.BooksTableAdapter.Fill(Me.BooksDataSet1.Books)
                Me.QryBooksTableAdapter.Fill(Me.BooksDataSet1.qryBooks)
                'Me.RptTempTableAdapter3.Fill(Me.BooksDataSet1.RptTemp)

                BooksDataGridView.Visible = True
                db = BooksDataSet1.Tables
                tbl = BooksDataSet1.Books
                txtQryName.DataBindings.Add("Text", BooksQryBindingSource, "qryName")
                txtSQL.DataBindings.Add("Text", BooksQryBindingSource, "txtSQL")
                QryList.DataSource = BooksQryBindingSource
                QryList.DisplayMember = "qryName"

                cboCategory.Items.Clear()
                cboCategory.Items.Add("Biog")
                cboCategory.Items.Add("Auto Biog")
                cboCategory.Items.Add("Fiction")
                cboCategory.Items.Add("Non-Fiction")

                cboMedia.Items.Clear()
                cboMedia.Items.Add("EB")
                cboMedia.Items.Add("HB")
                cboMedia.Items.Add("PB")

                cboLocation.Items.Clear()
                cboLocation.Items.Add("eBook")
                cboLocation.Items.Add("HW Library")
                cboLocation.Items.Add("HW Library 2")
                cboLocation.Items.Add("HW Library 3")

            Case "LifeLine.mdb"

                Me.Prospects___COITableAdapter.Fill(Me.LifeLineDataSet1._Prospects___COI)
                Me.Prospects___ex_HiltonTableAdapter.Fill(Me.LifeLineDataSet1._Prospects___ex_Hilton)
                Me.SharpTableAdapter.Fill(Me.LifeLineDataSet1.Sharp)
                Me.QryLifelineTableAdapter.Fill(Me.LifeLineDataSet1.qryLifeline)
                'Me.RptTempTableAdapter.Fill(Me.LifeLineDataSet1.RptTemp)

                AddressesDataGridView.Visible = True
                db = LifeLineDataSet1.Tables
                tbl = LifeLineDataSet1._Prospects___COI
                txtQryName.DataBindings.Add("Text", LifelineQryBindingSource, "qryName")
                txtSQL.DataBindings.Add("Text", LifelineQryBindingSource, "txtSQL")
                QryList.DataSource = LifelineQryBindingSource
                QryList.DisplayMember = "qryName"

            Case "Video.mdb"

                Me.VideoTableAdapter.Fill(Me.VideoDataSet1.VIDEO3)
                Me.QryVideoTableAdapter.Fill(Me.VideoDataSet1.qryVideo)
                'Me.RptTempTableAdapter.Fill(Me.VideoDataSet1.RptTemp)

                VideoDataGridView.Visible = True
                db = VideoDataSet1.Tables
                tbl = VideoDataSet1.VIDEO3
                txtQryName.DataBindings.Add("Text", VideoQryBindingSource, "qryName")
                txtSQL.DataBindings.Add("Text", VideoQryBindingSource, "txtSQL")
                QryList.DataSource = VideoQryBindingSource
                QryList.DisplayMember = "qryName"

                cboVideoCategory.Items.Clear()
                cboVideoCategory.Items.Add("Doc")
                cboVideoCategory.Items.Add("Misc")
                cboVideoCategory.Items.Add("Movie")
                cboVideoCategory.Items.Add("Music")
                cboVideoCategory.Items.Add("Series")
                cboVideoCategory.Items.Add("Sport")
                cboVideoCategory.Items.Add("TVSeries")

                cboVideoMedia.Items.Clear()
                cboVideoMedia.Items.Add("DVD")
                cboVideoMedia.Items.Add("DVDR")
                cboVideoMedia.Items.Add("DVDRE")
                cboVideoMedia.Items.Add("SKY+")

        End Select

        Me.Text = "Personal Data System - Database - " & gsAuxDBName
        If txtSQL.Text = "" Then cmdReport.Enabled = False

        Call GetTblQryLists()

        Call TblList_SelectedIndexChanged(AcceptButton, e)

        'CmdSaveQuery.Enabled = False
        cmdReport.Enabled = False

    End Sub

    Private Sub GetTblQryLists() 'db As DataTableCollection)

        'db =BooksDataSet.Tables
        PrintDataTableCollectionInfo()

        'tbl = BooksDataSet.Books
        PrintDataTableColumnInfo()

    End Sub

    Private Sub PrintDataTableCollectionInfo()

        ' Use a DataTable object's DataTableCollection.
        Dim Table As DataTableCollection = db '.Tables
        Dim sData As String = Nothing
        Dim x As Short = 0

        ' Print the ColumnName and DataType for each column.
        '
        For Each Item In Table 'DataTableCollection

            sData = Item.ToString

            'only want to see these tables, no queries
            x = InStr("Prospects - COIProspects - ex HiltonSharpVIDEO3BooksRptTemp", sData)
            If x > 0 Then
                TblList.Items.Add(Item.ToString())
            End If
        Next

    End Sub

    Private Sub PrintDataTableColumnInfo()

        ' Use a DataTable object's DataColumnCollection.
        Dim columns As DataColumnCollection = tbl.Columns
        Dim sData As String = Nothing

        FldList.Items.Clear()
        ' Print the ColumnName and DataType for each column.
        Dim column As DataColumn
        For Each column In columns

            If InStr("FirstName,LastName,Campaign", column.ColumnName) > 0 Then 'fix for fields that don't behave
                sData = Trim(column.ColumnName) + ControlChars.Tab + ControlChars.Tab + column.DataType.ToString + ControlChars.Tab + column.MaxLength.ToString
            ElseIf Len(column.ColumnName) < 10 Then
                sData = Trim(column.ColumnName) + ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + column.DataType.ToString + ControlChars.Tab + column.MaxLength.ToString
            ElseIf Len(column.ColumnName) > 10 And Len(column.ColumnName) < 21 Then
                sData = Trim(column.ColumnName) + ControlChars.Tab + ControlChars.Tab + column.DataType.ToString + ControlChars.Tab + column.MaxLength.ToString
            Else
                'sData = Trim(column.ColumnName) + ControlChars.Tab + column.DataType.ToString + ControlChars.Tab + column.MaxLength.ToString
            End If

            FldList.Items.Add(sData)
        Next

    End Sub

    Private Sub TblList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TblList.SelectedIndexChanged

        Dim idx As Integer = 0

        idx = TblList.SelectedIndex

        Select Case gsAuxDBName

            Case "Books.mdb"

                'Select Case idx

                'Case 0
                sReportTitle = "Books"
                BooksDataSetBindingSource.DataMember = "Books"
                BooksDataSetBindingSource.Filter = ""
                BooksDataSetBindingSource.Sort = "ID1"

                'End Select

            Case "LifeLine.mdb"

                'LifeLineDataSetBindingSource.DataMember = ""
                LifeLineDataSetBindingSource.Filter = ""
                LifeLineDataSetBindingSource.Sort = ""

                Select Case idx

                    Case 0
                        sReportTitle = "Prospects - COI"
                        AddressesDataGridView.Enabled = True
                        AddressesDataGridView.Visible = True
                        AddressesSharpDataGridView.Enabled = False
                        AddressesSharpDataGridView.Visible = False
                        LifeLineDataSetBindingSource.DataMember = "Prospects - COI"
                        'LifeLineDataSetBindingSource.Filter = ""
                        LifeLineDataSetBindingSource.Sort = "CustNo,PostCode"
                        tbl = LifeLineDataSet1._Prospects___COI
                        PrintDataTableColumnInfo()
                    Case 1
                        sReportTitle = "Prospects - ex Hilton"
                        AddressesDataGridView.Enabled = True
                        AddressesDataGridView.Visible = True
                        AddressesSharpDataGridView.Enabled = False
                        AddressesSharpDataGridView.Visible = False
                        LifeLineDataSetBindingSource.DataMember = "Prospects - ex Hilton"
                        'LifeLineDataSetBindingSource.Filter = ""
                        LifeLineDataSetBindingSource.Sort = "CustNo,PostCode"
                        'tbl = LifeLineDataSet1._Prospects___COI
                    Case 3
                        sReportTitle = "Sharp"
                        AddressesDataGridView.Enabled = False
                        AddressesDataGridView.Visible = False
                        AddressesSharpDataGridView.Enabled = True
                        AddressesSharpDataGridView.Visible = True
                        LifeLineDataSetBindingSource.DataMember = "Sharp"
                        'LifeLineDataSetBindingSource.Filter = ""
                        LifeLineDataSetBindingSource.Sort = "Category,LastName,Firstname"
                        tbl = LifeLineDataSet1.Sharp
                        PrintDataTableColumnInfo()

                End Select


            Case "Video.mdb"

                'Select Case idx

                'Case 0
                sReportTitle = "VIDEO"
                VideoDataSetBindingSource.DataMember = "VIDEO3"
                VideoDataSetBindingSource.Filter = ""
                VideoDataSetBindingSource.Sort = "Tape Id"

                'End Select

        End Select

        'CmdSaveQuery.Enabled = False

    End Sub

    Private Sub QryList_GotFocus(sender As Object, e As EventArgs) Handles QryList.GotFocus

        'txtSQLDisp.Text = txtSQL.Text

    End Sub

    Private Sub QryList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QryList.SelectedIndexChanged

        txtSQL.Tag = txtSQL.Text
        txtSQLDisp.Text = txtSQL.Text

        Call DisplayRecords()

    End Sub

    Private Sub DisplayRecords()

        Dim sFilter As String = Nothing 'Where
        Dim sSort As String = Nothing 'Order by
        Dim nFromPos As Integer = 0
        Dim nWherePos As Integer = 0
        Dim nOrderBy As Integer = 0
        Dim idx As Integer = 0

        '         10         21                              53
        'SELECT * FROM Books WHERE Books.Location = "eBook"  ORDER BY Books.Author, Books.Title;
        nFromPos = InStr(UCase(txtSQLDisp.Text), "FROM") '10
        nWherePos = InStr(UCase(txtSQLDisp.Text), "WHERE") + 5 '21
        nOrderBy = InStr(UCase(txtSQLDisp.Text), "ORDER") + 8 '53

        If nOrderBy > 8 Then
            sSort = Mid(txtSQLDisp.Text, nOrderBy, Len(txtSQLDisp.Text))
        Else
            sSort = ""
        End If

        If nWherePos > 8 Then
            sFilter = Mid(txtSQLDisp.Text, nWherePos, nOrderBy - nWherePos - 8)
        Else
            sFilter = ""
        End If

        Call GetTableName()

        If Mid(sTBName, 1, 1) = "[" Then sTBName = Mid(sTBName, 2, Len(sTBName) - 1)
        If InStr(sTBName, "]") Then sTBName = Mid(sTBName, 1, Len(sTBName) - 1)

        Select Case gsAuxDBName

            Case "Books.mdb"

                sReportTitle = CStr(txtQryName.Text)
                'sReportTitle = "Books - " + sReportTitle 'Mid(sReportTitle, 4, Len(sReportTitle))
                If Len(sReportTitle) > 40 Then
                    sReportTitle = Mid(sReportTitle, 1, 40) ' Max size!
                End If

                BooksDataSetBindingSource.Filter = sFilter
                BooksDataSetBindingSource.Sort = sSort 'jpg

            Case "LifeLine.mdb"

                Select Case sTBName

                    Case "Prospects - COI", "Prospects - ex Hilton"

                        sReportTitle = CStr(txtQryName.Text)
                        'sReportTitle = "Addresses - " + sReportTitle 'Mid(sReportTitle, 4, Len(sReportTitle))
                        If Len(sReportTitle) > 40 Then
                            sReportTitle = Mid(sReportTitle, 1, 40) ' Max size!
                        End If

                        'use default grid as using same file structure
                        AddressesSharpDataGridView.Enabled = False
                        AddressesSharpDataGridView.Visible = False
                        AddressesDataGridView.Enabled = True
                        AddressesDataGridView.Visible = True
                        LifeLineDataSetBindingSource.DataMember = sTBName
                        LifeLineDataSetBindingSource.Filter = sFilter
                        LifeLineDataSetBindingSource.Sort = sSort

                    Case "Sharp"

                        sReportTitle = CStr(txtQryName.Text)
                        'sReportTitle = "Addresses - " + sReportTitle 'Mid(sReportTitle, 4, Len(sReportTitle))
                        If Len(sReportTitle) > 40 Then
                            sReportTitle = Mid(sReportTitle, 1, 40) ' Max size!
                        End If

                        'use separate grid & datasource as different file structure
                        AddressesDataGridView.Enabled = False
                        AddressesDataGridView.Visible = False
                        AddressesSharpDataGridView.Enabled = True
                        AddressesSharpDataGridView.Visible = True
                        SharpDataSetBindingSource.DataMember = sTBName 'change Table
                        SharpDataSetBindingSource.Filter = sFilter
                        SharpDataSetBindingSource.Sort = sSort

                    Case Else

                End Select

            Case "Video.mdb"

                sReportTitle = CStr(txtQryName.Text)

                If Len(sReportTitle) > 40 Then
                    sReportTitle = Mid(sReportTitle, 1, 40) ' Max size!
                End If

                VideoDataSetBindingSource.Filter = sFilter
                VideoDataSetBindingSource.Sort = sSort

        End Select

        cmdReport.Enabled = True

    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click

        If txtSQLDisp.Text <> "" Then

            If txtSQLDisp.Text <> txtSQL.Text Then
                'need to validate sql!

                'update display
                Call DisplayRecords()

                GroupBoxSaveQuery.Visible = True
                cmdSaveQuery.Enabled = True
                'cmdReport.Enabled = True

            End If

        End If

    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click

        Dim sReportDir As String
        Dim sSql As String
        Dim sSqlSelect As String
        Dim sSqlFromWhereOrder As String
        Dim nFromPos As Integer = 0
        Dim nWherePos As Integer = 0
        Dim nOrderBy As Integer = 0
        Dim Result As Short = 0

        sReportDir = gsReportDir

        Call SetHourGlassWait()

        'On Error GoTo CmdReport_Click_Error

        Call DropTable("RptTemp")

        Call GetTableName()

        If Mid(sTBName, 1, 4) = "[Pro" Then sTBName = "LifeLine" 'have one report format instead of three

        '         10         21                       44
        'SELECT * FROM Books WHERE Location = "eBook" ORDER BY Author, Title;

        nFromPos = InStr(UCase(txtSQL.Text), "FROM")
        nWherePos = InStr(UCase(txtSQL.Text), "WHERE") ' + 5 '21
        nOrderBy = InStr(UCase(txtSQL.Text), "ORDER") ' + 8 '53

        sSqlSelect = Mid(txtSQL.Text, 1, nFromPos - 1)
        sSqlFromWhereOrder = Mid(txtSQL.Text, nFromPos, Len(txtSQL.Text))

        sSql = sSqlSelect & " INTO RptTemp "
        sSql = sSql & sSqlFromWhereOrder

        'Debug.Print sSql

        If DoSql(sSql, 1) Then

            sSql = "Update RptTemp"
            sSql = sSql & " Set ReportTitle = " & qte(sReportTitle)

            If DoSql(sSql, 1) Then

                AxCrystalReport1.ReportFileName = sReportDir & "\" & sTBName & ".rpt"
                AxCrystalReport1.ReportSource = 0            'use rpt format
                AxCrystalReport1.Destination = 0             'Screen
                'Call SetPrinterOrient(PORTRAIT)
                'On Error GoTo Retry
                'Result = AxCrystalReport1.PrintReport       'Do it
                AxCrystalReport1.Action = 1                'Do it
                'On Error GoTo 0
                'Call ReSetPrinterOrient()

            End If

        End If

        Call SetHourGlassDefault()

        cmdView.Enabled = True
        cmdReport.Enabled = True
        cmdClose.Enabled = True

        Exit Sub

CmdReport_Click_Error:

        Call MsgBox("Print Report", vbExclamation, sSql)
        On Error GoTo 0

        Call SetHourGlassDefault()

        cmdView.Enabled = True
        cmdReport.Enabled = True
        cmdClose.Enabled = True

        Exit Sub

    End Sub

    Private Sub GetTableName()

        Dim nFromPos As Integer = 0
        Dim nWherePos As Integer = 0
        Dim nOrderBy As Integer = 0

        '         10         21                       44
        'SELECT * FROM Books WHERE Location = "eBook" ORDER BY Author, Title;

        nFromPos = InStr(UCase(txtSQL.Text), "FROM")
        nWherePos = InStr(UCase(txtSQL.Text), "WHERE") ' + 5 '21
        nOrderBy = InStr(UCase(txtSQL.Text), "ORDER") ' + 8 '53

        If nWherePos > 0 Then
            sTBName = Trim(Mid(txtSQL.Text, nFromPos + 5, nWherePos - 1 - nFromPos - 5))
        ElseIf nOrderBy > 0 Then
            sTBName = Trim(Mid(txtSQL.Text, nFromPos + 5, nOrderBy - 1 - nFromPos - 5))
        Else
            sTBName = Trim(Mid(txtSQL.Text, nFromPos + 5, Len(txtSQL.Text) - nFromPos - 5))
        End If

    End Sub

    Private Sub txtSQL_TextChanged(sender As Object, e As EventArgs) Handles txtSQL.TextChanged

        cmdReport.Enabled = True

    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click

        Dim VideoId As Integer

        miUpdate = giADD

        Select Case gsAuxDBName

            Case "Books.mdb"

                GroupBoxBooks.Visible = True
                Call ClearBooksFields()

            Case "LifeLine.mdb"

                GroupBoxAddress.Visible = True
                Call ClearAddressFields()

            Case "Video.mdb"
                GroupBoxVideos.Visible = True
                Call ClearVideoFields()
                If GetNextVideoIdNo(VideoId) = True Then
                    txtTapeID.Text = CStr(VideoId)
                    txtTapeID.Tag = txtTapeID.Text
                End If
        End Select

    End Sub

    Private Sub ClearBooksFields()

        txtID.Text = ""
        txtTitle.Text = ""
        cboMedia.Text = ""
        cboCategory.Text = ""
        txtAuthor.Text = ""
        txtPublisher.Text = ""
        cboLocation.Text = ""
        txtReadby.Text = ""
        'txtreporttitle.text = ""

    End Sub

    Private Sub ClearAddressFields()

        txtCustID.Text = ""
        txtFirstName.Text = ""
        txtAddressTitle.Text = ""
        txtStatus.Text = ""
        txtLastName.Text = ""
        txtCard.Text = ""
        txtHomePhone.Text = ""
        txtMobilePhone.Text = ""
        txtOfficePhone.Text = ""
        txtSource.Text = ""
        txtAddress1.Text = ""
        txtAddress2.Text = ""
        txtTown.Text = ""
        txtEmail.Text = ""
        txtCounty.Text = ""
        txtPostCode.Text = ""
        txtCompany.Text = ""
        txtNotes.Text = ""
        txtCountry.Text = ""
        'txtreporttitle.text = ""

        Select Case sTBName

            Case "Prospects - COI", "Prospects - ex Hilton"

                'not used
                'txtAddress2.Text = ""
                'txtCountry.Text = ""
                txtMobilePhone.Text = ""
                txtOfficePhone.Text = ""
                txtCustID.Enabled = False
                txtAddress2.Enabled = False
                txtCountry.Enabled = False
                txtMobilePhone.Enabled = False
                txtOfficePhone.Enabled = False
                're-enable
                txtSource.Enabled = True
                txtStatus.Enabled = True

            Case "Sharp"

                'Not used
                'txtSource.Text = ""
                'txtStatus.Text = ""
                txtSource.Enabled = False
                txtStatus.Enabled = False
                're-enable
                txtCustID.Enabled = True
                txtAddress2.Enabled = True
                txtCountry.Enabled = True
                txtMobilePhone.Enabled = True
                txtOfficePhone.Enabled = True

        End Select

    End Sub

    Private Sub ClearVideoFields()

        txtTapeID.Text = ""
        txtDescription.Text = ""
        cboVideoMedia.Text = ""
        cboVideoCategory.Text = ""
        txtArtist.Text = ""
        txtTime.Text = ""
        'txtTotalTime.Text = ""

    End Sub

    Private Function GetNextVideoIdNo(ByRef VideoId As Integer) As Integer

        Dim ds As New DataTable
        Dim sSql As String

        On Error GoTo GetNextVideoIdNo

        sSql = "SELECT max([Tape ID]) as MaxTapeID FROM Video3"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)

        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            GetNextVideoIdNo = True
            VideoId = Val(ds.Rows.Item(0)("MaxTapeID")) + 1
        Else
            GetNextVideoIdNo = False
            VideoId = 0
        End If

        ds.Dispose()

        Exit Function

GetNextVideoIdNo:

        GetNextVideoIdNo = False
        ds.Dispose()

    End Function

    Private Sub cmdChange_Click(sender As Object, e As EventArgs) Handles cmdChange.Click

        miUpdate = giCHANGE

        Select Case gsAuxDBName

            Case "Books.mdb"

                GroupBoxBooks.Visible = True
                'Books
                Dim sName As String

                ' Iterate through the SelectedCells collection and extract the values.
                For counter = 0 To (BooksDataGridView.SelectedCells.Count - 1)

                    'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

                    sName = BooksDataGridView.Columns(counter).HeaderText.ToString

                    If BooksDataGridView.SelectedCells(counter).FormattedValueType Is _
                    Type.GetType("System.String") Then

                        Dim value As String = Nothing

                        ' If the cell contains a value that has not been committed,
                        ' use the modified value.
                        If (BooksDataGridView.IsCurrentCellDirty = True) Then

                            value = BooksDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue.ToString()
                        Else

                            value = BooksDataGridView.SelectedCells(counter) _
                                .FormattedValue.ToString()
                        End If

                        Select Case sName
                            Case "ID1"
                                txtID.Text = value
                            Case "Title"
                                txtTitle.Text = value
                            Case "Media"
                                cboMedia.Text = value
                            Case "Category"
                                cboCategory.Text = value
                            Case "Author"
                                txtAuthor.Text = value
                            Case "Location"
                                cboLocation.Text = value
                            Case "Publisher"
                                txtPublisher.Text = value
                            Case "ReadBy"
                                txtReadby.Text = value
                            Case Else

                        End Select

                    End If

                    If BooksDataGridView.SelectedCells(counter).FormattedValueType Is _
                    Type.GetType("System.date") Then

                        Dim dvalue As Date = Nothing

                        If (BooksDataGridView.IsCurrentCellDirty = True) Then

                            dvalue = BooksDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue.
                        Else

                            dvalue = BooksDataGridView.SelectedCells(counter) _
                                .FormattedValue

                        End If

                        Select Case sName

                            Case "BalanceDate"
                                'sBalanceDate = dvalue

                            Case Else

                        End Select

                    End If

                    If BooksDataGridView.SelectedCells(counter).FormattedValueType Is _
                     Type.GetType("System.Number") Then

                        Dim nvalue As Double = 0

                        If (BooksDataGridView.IsCurrentCellDirty = True) Then

                            nvalue = BooksDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue
                        Else

                            nvalue = BooksDataGridView.SelectedCells(counter) _
                                .FormattedValue

                        End If

                        Select Case sName

                            Case "Balance"
                                'nBalance = nvalue

                            Case Else

                        End Select

                    End If
                Next


            Case "LifeLine.mdb"

                'addresses

                GroupBoxAddress.Visible = True

                Dim sName As String

                Select Case sTBName

                    Case "Prospects - COI", "Prospects - ex Hilton"

                        ' Iterate through the SelectedCells collection and extract the values.
                        For counter = 0 To (AddressesDataGridView.SelectedCells.Count - 1)

                            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

                            sName = AddressesDataGridView.Columns(counter).HeaderText.ToString

                            If AddressesDataGridView.SelectedCells(counter).FormattedValueType Is _
                            Type.GetType("System.String") Then

                                Dim value As String = Nothing

                                ' If the cell contains a value that has not been committed,
                                ' use the modified value.
                                If (AddressesDataGridView.IsCurrentCellDirty = True) Then

                                    value = AddressesDataGridView.SelectedCells(counter) _
                                        .EditedFormattedValue.ToString()
                                Else

                                    value = AddressesDataGridView.SelectedCells(counter) _
                                        .FormattedValue.ToString()
                                End If

                                Select Case sName
                                    Case "CustNo"
                                        txtCustID.Text = value
                                    Case "LastName"
                                        txtLastName.Text = value
                                    Case "Title"
                                        txtAddressTitle.Text = value
                                    Case "Phone"
                                        txtHomePhone.Text = value
                                    Case "Salutation"
                                        txtFirstName.Text = value
                                    Case "Source"
                                        txtSource.Text = value
                                        'lblSource.Text = "Source"
                                    Case "Address"
                                        txtAddress1.Text = value
                                    Case "Town"
                                        txtTown.Text = value
                                        'lblTown.Text = "Town"
                                    Case "PostCode"
                                        txtPostCode.Text = value
                                    Case "Email address"
                                        txtEmail.Text = value
                                    Case "County"
                                        txtCounty.Text = value
                                    Case "Campaign"
                                        txtCard.Text = value
                                    Case "CompanyName"
                                        txtCompany.Text = value
                                    Case "Notes"
                                        txtNotes.Text = value
                                    Case "Status"
                                        txtStatus.Text = value
                                        'lblStatus.Text = "Status"
                                    Case Else

                                End Select

                            End If

                            If AddressesDataGridView.SelectedCells(counter).FormattedValueType Is _
                            Type.GetType("System.date") Then

                                Dim dvalue As Date = Nothing

                                If (AddressesDataGridView.IsCurrentCellDirty = True) Then

                                    dvalue = AddressesDataGridView.SelectedCells(counter) _
                                        .EditedFormattedValue.
                                Else

                                    dvalue = AddressesDataGridView.SelectedCells(counter) _
                                        .FormattedValue

                                End If

                                Select Case sName

                                    Case "BalanceDate"
                                        'sBalanceDate = dvalue

                                    Case Else

                                End Select

                            End If

                            If AddressesDataGridView.SelectedCells(counter).FormattedValueType Is _
                             Type.GetType("System.Number") Then

                                Dim nvalue As Double = 0

                                If (AddressesDataGridView.IsCurrentCellDirty = True) Then

                                    nvalue = AddressesDataGridView.SelectedCells(counter) _
                                        .EditedFormattedValue
                                Else

                                    nvalue = AddressesDataGridView.SelectedCells(counter) _
                                        .FormattedValue

                                End If

                                Select Case sName

                                    Case "Balance"
                                        'nBalance = nvalue

                                    Case Else

                                End Select

                            End If
                        Next

                        'not used
                        txtAddress2.Text = ""
                        txtCountry.Text = ""
                        txtMobilePhone.Text = ""
                        txtOfficePhone.Text = ""
                        txtCustID.Enabled = False
                        txtAddress2.Enabled = False
                        txtCountry.Enabled = False
                        txtMobilePhone.Enabled = False
                        txtOfficePhone.Enabled = False
                        're-enable
                        txtSource.Enabled = True
                        txtStatus.Enabled = True

                    Case "Sharp"
                        ' Iterate through the SelectedCells collection and extract the values.
                        For counter = 0 To (AddressesSharpDataGridView.SelectedCells.Count - 1)

                            'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

                            sName = AddressesSharpDataGridView.Columns(counter).HeaderText.ToString

                            If AddressesSharpDataGridView.SelectedCells(counter).FormattedValueType Is _
                            Type.GetType("System.String") Then

                                Dim value As String = Nothing

                                ' If the cell contains a value that has not been committed,
                                ' use the modified value.
                                If (AddressesSharpDataGridView.IsCurrentCellDirty = True) Then

                                    value = AddressesSharpDataGridView.SelectedCells(counter) _
                                        .EditedFormattedValue.ToString()
                                Else

                                    value = AddressesSharpDataGridView.SelectedCells(counter) _
                                        .FormattedValue.ToString()
                                End If

                                Select Case sName
                                    Case "Category"
                                        txtCustID.Text = value
                                        txtCustID.Tag = txtCustID.Text
                                    Case "LastName"
                                        txtLastName.Text = value
                                        txtLastName.Tag = txtLastName.Text
                                    Case "Title"
                                        txtAddressTitle.Text = value
                                    Case "Home#"
                                        txtHomePhone.Text = value
                                    Case "Mobile#"
                                        txtMobilePhone.Text = value
                                    Case "Office#"
                                        txtOfficePhone.Text = value
                                    Case "FirstName"
                                        txtFirstName.Text = value
                                        txtFirstName.Tag = txtFirstName.Text
                                    Case "Town"
                                        txtTown.Text = value
                                    Case "Address1"
                                        txtAddress1.Text = value
                                    Case "Address2"
                                        txtAddress2.Text = value
                                    Case "Postcode"
                                        txtPostCode.Text = value
                                    Case "E-mail"
                                        txtEmail.Text = value
                                    Case "County"
                                        txtCounty.Text = value
                                    Case "Christmascard"
                                        txtCard.Text = value
                                    Case "Company"
                                        txtCompany.Text = value
                                    Case "Note"
                                        txtNotes.Text = value
                                    Case "Country"
                                        txtCountry.Text = value
                                    Case Else

                                End Select

                            End If

                        Next

                        'Not used
                        txtSource.Text = ""
                        txtStatus.Text = ""
                        txtSource.Enabled = False
                        txtStatus.Enabled = False
                        're-enable
                        txtAddress2.Enabled = True
                        txtCountry.Enabled = True
                        txtMobilePhone.Enabled = True
                        txtOfficePhone.Enabled = True

                End Select

            Case "Video.mdb"

                'Videos
                GroupBoxVideos.Visible = True

                Dim sName As String

                ' Iterate through the SelectedCells collection and extract the values.
                For counter = 0 To (VideoDataGridView.SelectedCells.Count - 1)

                    'Debug.Print(DataGridDirPbs.SelectedCells(counter).FormattedValueType.ToString) ' Is Type.GetType)

                    sName = VideoDataGridView.Columns(counter).HeaderText.ToString

                    If VideoDataGridView.SelectedCells(counter).FormattedValueType Is _
                    Type.GetType("System.String") Then

                        Dim value As String = Nothing

                        ' If the cell contains a value that has not been committed,
                        ' use the modified value.
                        If (VideoDataGridView.IsCurrentCellDirty = True) Then

                            value = VideoDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue.ToString()
                        Else

                            value = VideoDataGridView.SelectedCells(counter) _
                                .FormattedValue.ToString()
                        End If

                        Select Case sName
                            Case "Tape Id"
                                txtTapeID.Text = value
                                txtTapeID.Tag = txtTapeID.Text
                            Case "Description"
                                txtDescription.Text = value
                            Case "Media"
                                cboVideoMedia.Text = value
                            Case "Category"
                                cboVideoCategory.Text = value
                            Case "Artist"
                                txtArtist.Text = value
                            Case "Time"
                                If value = "" Then value = "0"
                                txtTime.Text = value
                            Case Else

                        End Select

                    End If

                    If VideoDataGridView.SelectedCells(counter).FormattedValueType Is _
                    Type.GetType("System.date") Then

                        Dim dvalue As Date = Nothing

                        If (VideoDataGridView.IsCurrentCellDirty = True) Then

                            dvalue = VideoDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue.
                        Else

                            dvalue = VideoDataGridView.SelectedCells(counter) _
                                .FormattedValue

                        End If

                        Select Case sName

                            Case "BalanceDate"
                                'sBalanceDate = dvalue

                            Case Else

                        End Select

                    End If

                    If VideoDataGridView.SelectedCells(counter).FormattedValueType Is _
                     Type.GetType("System.Number") Then

                        Dim nvalue As Double = 0

                        If (VideoDataGridView.IsCurrentCellDirty = True) Then

                            nvalue = VideoDataGridView.SelectedCells(counter) _
                                .EditedFormattedValue
                        Else

                            nvalue = VideoDataGridView.SelectedCells(counter) _
                                .FormattedValue

                        End If

                        Select Case sName

                            Case "Balance"
                                'nBalance = nvalue

                            Case Else

                        End Select

                    End If
                Next

        End Select

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click

        Dim sSql As String = Nothing
        Dim Msg As String
        Dim Style As Short
        Dim Title As String = Nothing
        Dim iResponse As Short
        'Dim bok As Boolean

        Select Case gsAuxDBName

            Case "Books.mdb"

                GroupBoxBooks.Visible = True
                'get values from currently selected record
                Call cmdChange_Click(AcceptButton, e)

                sSql = "Delete From Books"
                sSql = sSql + " Where ID1 = " + txtID.Text

            Case "LifeLine.mdb"

                GroupBoxAddress.Visible = True
                'get values from currently selected record
                Call cmdChange_Click(AcceptButton, e)

                Select Case sTBName

                    Case "Prospects - COI"

                        sSql = "Delete From [Prospects - COI]"
                        sSql = sSql + " Where CustNo = " + txtCustID.Text

                    Case "Prospects - ex Hilton"

                        sSql = "Delete From [Prospects - ex Hilton]"
                        sSql = sSql + " Where CustNo = " + txtCustID.Text

                    Case "Sharp"

                        sSql = "Delete From Sharp"
                        sSql = sSql + " Where Sharp.LastName = " + qte(txtLastName.Text)
                        sSql = sSql + " And Sharp.FirstName = " + qte(txtFirstName.Text)

                End Select

            Case "Video.mdb"

                GroupBoxVideos.Visible = True
                'get values from currently selected record
                Call cmdChange_Click(AcceptButton, e)

                sSql = "Delete From Video3"
                sSql = sSql + " Where [Tape Id] = " + txtTapeID.Text

            Case Else

        End Select

        Msg = " Confirm deletion of current transaction "
        Title = "Delete Transaction"
        Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
        iResponse = MsgBox(Msg, Style, Title)

        If iResponse = MsgBoxResult.Yes And sSql <> Nothing Then

            Call SetHourGlassWait()

            'miUpdate = giDELETE

            'turn off grid
            BooksDataGridView.Enabled = False
            AddressesDataGridView.Enabled = False
            AddressesSharpDataGridView.Enabled = False
            VideoDataGridView.Enabled = False

            If DoSql(sSql, 1) Then
                Msg = "Current transaction deleted"
                MsgBox(Msg, vbExclamation, Title)
            Else
                Msg = "Current transaction NOT deleted"
                MsgBox(Msg, vbExclamation, Title)
            End If

            BooksDataGridView.Enabled = True
            AddressesDataGridView.Enabled = True
            AddressesSharpDataGridView.Enabled = True
            VideoDataGridView.Enabled = True

            Call SetHourGlassDefault()

        Else
            Msg = "Current transaction NOT deleted"
            MsgBox(Msg, vbExclamation, Title)
        End If

        Call RefreshDetails()
        GroupBoxBooks.Visible = False
        GroupBoxAddress.Visible = False
        GroupBoxVideos.Visible = False

    End Sub

    Private Sub cmdSaveQuery_Click(sender As Object, e As EventArgs) Handles cmdSaveQuery.Click

        GroupBoxSaveQuery.Visible = True
        txtQueryName.Focus()

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        'update db
        Select Case gsAuxDBName

            Case "Books.mdb"

                GroupBoxBooks.Visible = False

                Select Case miUpdate
                    Case giADD
                        Call AddBookTransaction()
                    Case giCHANGE
                        Call EditBookTransaction()
                    Case Else
                End Select

            Case "LifeLine.mdb"

                Select Case sTBName

                    Case "Prospects - COI", "Prospects - ex Hilton"
                        GroupBoxAddress.Visible = False

                        Select Case miUpdate
                            Case giADD
                                Call AddLifeLineAddressTransaction()
                            Case giCHANGE
                                Call EditLifeLineAddressTransaction()
                            Case Else
                        End Select

                    Case "Sharp"
                        GroupBoxAddress.Visible = False

                        Select Case miUpdate
                            Case giADD
                                Call AddLifeLineSharpAddressTransaction()
                            Case giCHANGE
                                Call EditLifeLineSharpAddressTransaction()
                            Case Else
                        End Select

                End Select

            Case "Video.mdb"

                GroupBoxVideos.Visible = False

                Select Case miUpdate
                    Case giADD
                        Call AddVideoTransaction()
                    Case giCHANGE
                        Call EditVideoTransaction()
                    Case Else
                End Select

        End Select


        'Call SaveQuery()


        Call RefreshDetails()

    End Sub

    Private Sub AddBookTransaction()

        Dim sSql As String = Nothing

        sSql = "Insert into Books"
        sSql = sSql + " (Title, Media, Category, Author, Publisher, Location, ReadBy, ReportTitle)"
        sSql = sSql + " Values ("
        'sSql = sSql + qte(txtID.Text) 'auto-increment
        sSql = sSql + " " + qte(txtTitle.Text)
        sSql = sSql + ", " + qte(cboMedia.Text)
        sSql = sSql + ", " + qte(cboCategory.Text)
        sSql = sSql + ", " + qte(txtAuthor.Text)
        sSql = sSql + ", " + qte(txtPublisher.Text)
        sSql = sSql + ", " + qte(cboLocation.Text)
        sSql = sSql + ", " + qte(txtReadby.Text)
        sSql = sSql + ", " + "'')" 'qte(txtreporttile.text)

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub EditBookTransaction()

        Dim sSql As String = Nothing

        sSql = "Update Books Set"
        sSql = sSql + " Title =  " + qte(txtTitle.Text)
        sSql = sSql + ", Media = " + qte(cboMedia.Text)
        sSql = sSql + ", Category = " + qte(cboCategory.Text)
        sSql = sSql + ", Author = " + qte(txtAuthor.Text)
        sSql = sSql + ", Publisher = " + qte(txtPublisher.Text) ' & " ")
        sSql = sSql + ", Location = " + qte(cboLocation.Text)
        sSql = sSql + ", Readby = " + qte(txtReadby.Text)
        sSql = sSql + " Where ID1 = " + txtID.Text

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub AddLifeLineAddressTransaction()

        Dim sSql As String = Nothing

        Select Case sTBName
            Case "Prospects - COI"
                sSql = "Insert into  [Prospects - COI]"
            Case "Prospects - ex Hilton"
                sSql = "Insert into  [Prospects - ex Hilton]"
            Case Else
                Exit Sub
        End Select

        sSql = sSql + " (LastName, Title, Phone, Salutation, Source, Address, Town, PostCode, [Email address], County, Campaign, CompanyName, Notes, Status)"
        sSql = sSql + " Values ("
        'sSql = sSql + qte(txtID.Text) 'auto-increment
        sSql = sSql + " " + qte(txtLastName.Text)
        sSql = sSql + ", " + qte(txtAddressTitle.Text)
        sSql = sSql + ", " + qte(txtHomePhone.Text)
        sSql = sSql + ", " + qte(txtFirstName.Text) 'Salutation
        sSql = sSql + ", " + qte(txtSource.Text)
        sSql = sSql + ", " + qte(txtAddress1.Text)
        sSql = sSql + ", " + qte(txtTown.Text)
        sSql = sSql + ", " + qte(txtPostCode.Text)
        sSql = sSql + ", " + qte(txtEmail.Text)
        sSql = sSql + ", " + qte(txtCounty.Text)
        sSql = sSql + ", " + qte(txtCard.Text) 'Campaign
        sSql = sSql + ", " + qte(txtCompany.Text)
        sSql = sSql + ", " + qte(txtNotes.Text)
        sSql = sSql + ", " + qte(txtStatus.Text)
        sSql = sSql + ")" 'qte(txtreporttile.text)

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub EditLifeLineAddressTransaction()

        Dim sSql As String = Nothing

        Select Case sTBName
            Case "Prospects - COI"
                sSql = "Update [Prospects - COI] Set"
            Case "Prospects - ex Hilton"
                sSql = "Update [Prospects - ex Hilton] Set"
            Case Else
                Exit Sub
        End Select

        sSql = sSql + " LastName =  " + qte(txtLastName.Text)
        sSql = sSql + ", Title = " + qte(txtAddressTitle.Text)
        sSql = sSql + ", Source = " + qte(txtSource.Text)
        sSql = sSql + ", Salutation = " + qte(txtFirstName.Text)
        sSql = sSql + ", Phone = " + qte(txtHomePhone.Text)
        sSql = sSql + ", Address = " + qte(txtAddress1.Text)
        sSql = sSql + ", Town = " + qte(txtTown.Text)
        sSql = sSql + ", PostCode = " + qte(txtPostCode.Text)
        sSql = sSql + ", [Email address] = " + qte(txtEmail.Text)
        sSql = sSql + ", County = " + qte(txtCounty.Text)
        sSql = sSql + ", Campaign = " + qte(txtCard.Text)
        sSql = sSql + ", CompanyName = " + qte(txtCompany.Text)
        sSql = sSql + ", Notes = " + qte(txtNotes.Text)
        sSql = sSql + ", Status = " + qte(txtStatus.Text)
        'sSql = sSql + " "  + qte(txtreporttile.text)
        sSql = sSql + " Where CustNo = " + txtCustID.Text

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub AddLifeLineSharpAddressTransaction()

        Dim sSql As String = Nothing

        sSql = "Insert into  Sharp"
        sSql = sSql + " (Category, FirstName, Title, LastName, Christmascard, Home#], [Mobile#], [Office#], Address1, Address2, Town, [E-mail], County, Postcode, Company, [Note], Country)"
        sSql = sSql + " Values ("
        sSql = sSql + " " + qte(txtCustID.Text) '"Personal or Business"" use cbo?
        sSql = sSql + ", " + qte(txtFirstName.Text)
        sSql = sSql + ", " + qte(txtAddressTitle.Text)
        sSql = sSql + ", " + qte(txtLastName.Text)
        sSql = sSql + ", " + qte(txtCard.Text)
        sSql = sSql + ", " + qte(txtHomePhone.Text)
        sSql = sSql + ", " + qte(txtMobilePhone.Text)
        sSql = sSql + ", " + qte(txtOfficePhone.Text)
        sSql = sSql + ", " + qte(txtAddress1.Text)
        sSql = sSql + ", " + qte(txtAddress2.Text)
        sSql = sSql + ", " + qte(txtTown.Text)
        sSql = sSql + ", " + qte(txtEmail.Text)
        sSql = sSql + ", " + qte(txtCounty.Text)
        sSql = sSql + ", " + qte(txtPostCode.Text)
        sSql = sSql + ", " + qte(txtCompany.Text)
        sSql = sSql + ", " + qte(txtNotes.Text)
        sSql = sSql + ", " + qte(txtCountry.Text)
        sSql = sSql + ")" 'qte(txtreporttile.text)

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub EditLifeLineSharpAddressTransaction()

        Dim sSql As String = Nothing

        sSql = "Update Sharp Set"
        'sSql = sSql + " Category = " + qte(txtCustID.Text)
        sSql = sSql + " FirstName = " + qte(txtFirstName.Text)
        sSql = sSql + ", Title = " + qte(txtAddressTitle.Text)
        sSql = sSql + ", LastName =  " + qte(txtLastName.Text)
        sSql = sSql + ", Christmascard = " + qte(txtCard.Text)
        sSql = sSql + ", [Home#] = " + qte(txtHomePhone.Text)
        sSql = sSql + ", [Mobile#] = " + qte(txtMobilePhone.Text)
        sSql = sSql + ", [Office#] = " + qte(txtOfficePhone.Text)
        sSql = sSql + ", Address1 = " + qte(txtAddress1.Text)
        sSql = sSql + ", Address2 = " + qte(txtAddress2.Text)
        sSql = sSql + ", Town = " + qte(txtTown.Text)
        sSql = sSql + ", [E-mail] = " + qte(txtEmail.Text)
        sSql = sSql + ", County = " + qte(txtCounty.Text)
        sSql = sSql + ", Postcode = " + qte(txtPostCode.Text)
        sSql = sSql + ", Company = " + qte(txtCompany.Text)
        sSql = sSql + ", [Note] = " + qte(txtNotes.Text)
        sSql = sSql + ", Country = " + qte(txtCountry.Text)
        'sSql = sSql + " "  + qte(txtreporttile.text)
        sSql = sSql + " Where Category = " + qte(txtCustID.Tag)
        sSql = sSql + " And LastName =  " + qte(txtLastName.Tag)
        sSql = sSql + " And FirstName =  " + qte(txtFirstName.Tag)

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub AddVideoTransaction()

        Dim sSql As String = Nothing

        sSql = "Insert into Video3"
        sSql = sSql + " ([Tape Id], Description, Media, Category, Artist, [Time])" 'Total Time)"
        sSql = sSql + " Values ("
        sSql = sSql + txtTapeID.Text
        sSql = sSql + ", " + qte(txtDescription.Text)
        sSql = sSql + ", " + qte(cboVideoMedia.Text)
        sSql = sSql + ", " + qte(cboVideoCategory.Text)
        sSql = sSql + ", " + qte(txtArtist.Text)
        sSql = sSql + ", " + txtTime.Text '+ "0" removed '0' 30/12/16
        'sSql = sSql + ", ' + txtTotalTime.Text"
        sSql = sSql + ")"

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub EditVideoTransaction()

        Dim sSql As String = Nothing

        sSql = "Update Video3 Set"
        sSql = sSql + " [Tape Id] = " + txtTapeID.Text
        sSql = sSql + ", Description =  " + qte(txtDescription.Text)
        sSql = sSql + ", Media = " + qte(cboVideoMedia.Text)
        sSql = sSql + ", Category = " + qte(cboVideoCategory.Text)
        sSql = sSql + ", Artist = " + qte(txtArtist.Text)
        sSql = sSql + ", [Time] = " + txtTime.Text '+ "0" removed '0' 30/12/16
        'sSql = sSql + ", [Total Time] = " + txtTotalTime.Text
        sSql = sSql + " Where [Tape ID] = " + txtTapeID.Tag

        If DoSql(sSql, 1) Then

        End If

    End Sub

    Private Sub SaveQuery()

        Dim sSql As String = Nothing
        Dim Msg As String
        Dim Title As String = Nothing
        Dim Style As Short
        Dim iResponse As Short

        Select Case gsAuxDBName

            Case "Books.mdb"

                'does qryName already exist?
                sSql = "Select qryName from qryBooks"
                sSql = sSql + " Where qryName = " + qte(txtQueryName.Text)
                Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
                Dim ds As New DataTable
                adapter.Fill(ds)

                If ds.Rows.Count > 0 Then

                    'qryName already exists
                    Msg = "Query Name already exists, 'Yes' to overwrite Query or 'No' to enter a new Name"
                    Title = "Query Changed"
                    Style = MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2
                    iResponse = MsgBox(Msg, Style, Title)

                    If iResponse = MsgBoxResult.Yes Then

                        'update existing query
                        sSql = "Update qryBooks Set"
                        sSql = sSql + " txtSQL = " + qte(txtSQLDisp.Text)
                        sSql = sSql + " Where qryName = " + qte(txtQueryName.Text)

                        If DoSql(sSql, 1) Then
                            txtSQLDisp.Tag = txtSQLDisp.Text
                            Call RefreshDetails()
                            BooksQryBindingSource.MoveLast()
                            'QryList.SelectedItem.
                            txtSQL.Text = txtSQLDisp.Tag
                            Call RefreshDetails()
                        End If

                    Else

                        'enter new name
                        txtQueryName.Focus()

                    End If

                Else

                    'write new query
                    sSql = "Insert into qryBooks"
                    sSql = sSql + " (qryName, txtSQL)"
                    sSql = sSql + " Values ("
                    sSql = sSql + " " + qte(txtQueryName.Text)
                    sSql = sSql + ", " + qte(txtSQLDisp.Text)
                    sSql = sSql + ")"

                    If DoSql(sSql, 1) Then
                        txtSQLDisp.Tag = txtSQLDisp.Text
                        Call RefreshDetails()
                        BooksQryBindingSource.MoveLast()
                        'QryList.SelectedItem.
                        txtSQL.Text = txtSQLDisp.Tag
                        Call RefreshDetails()
                    End If

                End If

                GroupBoxSaveQuery.Visible = False
                cmdSaveQuery.Enabled = False

            Case "Lifeline.mdb"

            Case "Video.mdb"

            Case Else

        End Select

    End Sub

    Private Sub RefreshDetails()

        Dim bOk As Boolean

        Select Case gsAuxDBName

            Case "Books.mdb"
                bOk = BooksTableAdapter.ClearBeforeFill
                Me.BooksTableAdapter.Fill(Me.BooksDataSet1.Books)
                bOk = QryBooksTableAdapter.ClearBeforeFill
                Me.QryBooksTableAdapter.Fill(Me.BooksDataSet1.qryBooks)

            Case "LifeLine.mdb"

                Select Case sTBName

                    Case "Prospects - COI"
                        bOk = Prospects___COITableAdapter.ClearBeforeFill
                        Me.Prospects___COITableAdapter.Fill(Me.LifeLineDataSet1._Prospects___COI)
                    Case "Prospects - ex_Hilton"
                        bOk = Prospects___ex_HiltonTableAdapter.ClearBeforeFill
                        Me.Prospects___ex_HiltonTableAdapter.Fill(Me.LifeLineDataSet1._Prospects___ex_Hilton)
                    Case "Sharp"
                        bOk = SharpTableAdapter.ClearBeforeFill
                        Me.SharpTableAdapter.Fill(Me.LifeLineDataSet1.Sharp)
                End Select
                '
                bOk = QryLifelineTableAdapter.ClearBeforeFill
                Me.QryLifelineTableAdapter.Fill(Me.LifeLineDataSet1.qryLifeline)

            Case "Video.mdb"
                bOk = VideoTableAdapter.ClearBeforeFill
                Me.VideoTableAdapter.Fill(Me.VideoDataSet1.VIDEO3)
                bOk = QryVideoTableAdapter.ClearBeforeFill
                Me.QryVideoTableAdapter.Fill(Me.VideoDataSet1.qryVideo)

            Case Else

        End Select

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        GroupBoxBooks.Visible = False
        GroupBoxAddress.Visible = False
        GroupBoxVideos.Visible = False
        GroupBoxSaveQuery.Visible = False
        cmdSaveQuery.Enabled = False

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click

        gsAuxDBName = ""
        Me.Close()

    End Sub

    Private Sub txtTapeID_Lostfocus(sender As Object, e As EventArgs) Handles txtTapeID.LostFocus

        Dim msg As String
        Dim Title As String
        Dim nTapeId As Integer

        nTapeId = Val(txtTapeID.Text)

        If nTapeId < 1 Then
            msg = " Enter valid Video ID number - please rectify"
            Title = "Enter Video ID"
            MsgBox(msg, vbExclamation, Title)
            txtTapeID.Text = txtTapeID.Tag
            txtTapeID.Focus()
        ElseIf CheckVideoNumber(nTapeId) = True Then
            msg = " This Video ID already exists - please rectify"
            Title = "Enter Video ID"
            MsgBox(msg, vbExclamation, Title)
            txtTapeID.Focus()
        End If

    End Sub

    Private Function CheckVideoNumber(nTapeId As Integer)

        Dim sSql As String = Nothing

        sSql = "Select * FROM Video3"
        sSql = sSql & " Where [Tape Id] = " + CStr(nTapeId)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            CheckVideoNumber = True
        Else
            CheckVideoNumber = False
        End If

        ds.Dispose()

    End Function

End Class