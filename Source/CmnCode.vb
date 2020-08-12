Option Strict Off
Option Explicit On
'03/12/17   jpg     DoSql2 and gsVpbsConnection2 to import file to dev DB
Module CmnCode

    '***************************************************************
    ' Module Name: CMNCODE.BAS
    '
    ' Purpose: Additional general purpose application routines
    '
    '***************************************************************
    ' History:
    '
    ' Date     Who Description
    ' -------- --- -------------------------------------------------
    ' 02/11/96 JG  Created
    ' 22/02/10 JG  Modified for VB2010
    '***************************************************************
    Const miOFFSET As Short = 5 ' ASCII offset used to encode characters

    Public Sub SetHourGlassWait()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

    End Sub

    Public Sub SetHourGlassDefault()

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Public Function DoSql(ByVal sSql As String, bShowError As Integer) As Integer
        '***************************************************************
        ' Purpose           : Executes SQL updates/inserts etc
        '                           : ie execute SQL statements that do not return any values
        ' Parameters       : 
        '                           : sSql = full SQL statement
        '                           : bShowError = show or suppress error messages
        ' Assumes         : ErrorMessage()
        ' Returns         : True if success
        '***************************************************************
        ' History:
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 02/11/96 JG   Amended
        ' 12/03/15 JG   Re-written for vb10
        '***************************************************************
        'e.g.
        'Dim sSql As String = "Insert Into TransferID ..."
        'Dim sSql As String = "Update TransferID Set TransferIDIndex = '" + sTransferID + "'"
        'Dim sSql As String = "Delete From TransferID ..."

        Dim count As Integer = 0

        DoSql = True

        Using connection As New OleDb.OleDbConnection(gsVpbsConnection)

            Dim command As New OleDb.OleDbCommand(sSql, connection)

            Try
                connection.Open()
            Catch oledbexceptionerr As OleDb.OleDbException
                If bShowError = 1 Then MessageBox.Show(oledbexceptionerr.Message, "Access Error")
                DoSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            Catch InvalidOperationExceptionerr As InvalidOperationException
                If bShowError = 1 Then MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
                DoSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End Try

            If connection.State <> ConnectionState.Open Then
                If bShowError = 1 Then MessageBox.Show("Database connection Failed")
                DoSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End If

            command.CommandType = CommandType.Text
            command.CommandText = sSql
            command.ExecuteNonQuery() 'Do it!

            count = command.UpdatedRowSource
            If count = 0 Then
                If bShowError = 1 Then MessageBox.Show("No records processed")
            End If

            connection.Close()
            connection.Dispose()
            'connection = Nothing

        End Using

        Exit Function

DoSqlError:

        ' error message wanted?
        If bShowError Then
            Call MessageBox.Show("DoSQL", "Last SQL: " & sSql)
        End If

    End Function

    Public Function DoSql2(ByVal sSql As String, bShowError As Integer) As Integer
        '***************************************************************
        ' Purpose           : Executes SQL updates/inserts etc
        '                           : ie execute SQL statements that do not return any values
        ' Parameters       : 
        '                           : sSql = full SQL statement
        '                           : bShowError = show or suppress error messages
        ' Assumes         : ErrorMessage()
        ' Returns         : True if success
        '***************************************************************
        ' History:
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 02/11/96 JG   Amended
        ' 12/03/15 JG   Re-written for vb10
        '***************************************************************
        'e.g.
        'Dim sSql As String = "Insert Into TransferID ..."
        'Dim sSql As String = "Update TransferID Set TransferIDIndex = '" + sTransferID + "'"
        'Dim sSql As String = "Delete From TransferID ..."

        Dim count As Integer = 0

        DoSql2 = True

        Using connection As New OleDb.OleDbConnection(gsVpbsConnection2)

            Dim command As New OleDb.OleDbCommand(sSql, connection)

            Try
                connection.Open()
            Catch oledbexceptionerr As OleDb.OleDbException
                If bShowError = 1 Then MessageBox.Show(oledbexceptionerr.Message, "Access Error")
                DoSql2 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            Catch InvalidOperationExceptionerr As InvalidOperationException
                If bShowError = 1 Then MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
                DoSql2 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End Try

            If connection.State <> ConnectionState.Open Then
                If bShowError = 1 Then MessageBox.Show("Database connection Failed")
                DoSql2 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End If

            command.CommandType = CommandType.Text
            command.CommandText = sSql
            command.ExecuteNonQuery() 'Do it!

            count = command.UpdatedRowSource
            If count = 0 Then
                If bShowError = 1 Then MessageBox.Show("No records processed")
            End If

            connection.Close()
            connection.Dispose()
            'connection = Nothing

        End Using

        Exit Function

DoSqlError:

        ' error message wanted?
        If bShowError Then
            Call MessageBox.Show("DoSQL2", "Last SQL: " & sSql)
        End If

    End Function

    Public Function DoSql3(ByVal sSql As String, bShowError As Integer) As Integer
        '***************************************************************
        ' Purpose           : Executes SQL updates/inserts etc
        '                           : ie execute SQL statements that do not return any values
        ' Parameters       : 
        '                           : sSql = full SQL statement
        '                           : bShowError = show or suppress error messages
        ' Assumes         : ErrorMessage()
        ' Returns         : True if success
        '***************************************************************
        ' History:
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 02/11/96 JG   Amended
        ' 12/03/15 JG   Re-written for vb10
        '***************************************************************
        'e.g.
        'Dim sSql As String = "Insert Into TransferID ..."
        'Dim sSql As String = "Update TransferID Set TransferIDIndex = '" + sTransferID + "'"
        'Dim sSql As String = "Delete From TransferID ..."

        Dim count As Integer = 0

        DoSql3 = True

        Using connection As New OleDb.OleDbConnection(gsVpbsConnection3)

            Dim command As New OleDb.OleDbCommand(sSql, connection)

            Try
                connection.Open()
            Catch oledbexceptionerr As OleDb.OleDbException
                If bShowError = 1 Then MessageBox.Show(oledbexceptionerr.Message, "Access Error")
                DoSql3 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            Catch InvalidOperationExceptionerr As InvalidOperationException
                If bShowError = 1 Then MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
                DoSql3 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End Try

            If connection.State <> ConnectionState.Open Then
                If bShowError = 1 Then MessageBox.Show("Database connection Failed")
                DoSql3 = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End If

            command.CommandType = CommandType.Text
            command.CommandText = sSql
            command.ExecuteNonQuery() 'Do it!

            count = command.UpdatedRowSource
            If count = 0 Then
                If bShowError = 1 Then MessageBox.Show("No records processed")
            End If

            connection.Close()
            connection.Dispose()
            'connection = Nothing

        End Using

        Exit Function

DoSqlError:

        ' error message wanted?
        If bShowError Then
            Call MessageBox.Show("DoSQL3", "Last SQL: " & sSql)
        End If

    End Function

    Public Function DoStartUpSql(ByVal sSql As String, bShowError As Integer) As Integer
        '***************************************************************
        ' Purpose           : Executes SQL updates/inserts etc
        '                   : ie execute SQL statements that do not return any values
        ' Parameters        : 
        '                   : sSql = full SQL statement
        '                   : bShowError = show or suppress error messages
        ' Assumes           : ErrorMessage()
        ' Returns           : True if success
        '***************************************************************
        ' History:
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 02/11/96 JG   Amended
        ' 12/03/15 JG   Re-written for vb10
        '***************************************************************
        'e.g.
        'Dim sSql As String = "Insert Into TransferID ..."
        'Dim sSql As String = "Update TransferID Set TransferIDIndex = '" + sTransferID + "'"
        'Dim sSql As String = "Delete From TransferID ..."

        Dim count As Integer = 0

        DoStartUpSql = True

        Using connection As New OleDb.OleDbConnection(gsVpbsStartUpConnection)

            Dim command As New OleDb.OleDbCommand(sSql, connection)

            Try
                connection.Open()
            Catch oledbexceptionerr As OleDb.OleDbException
                If bShowError = 1 Then MessageBox.Show(oledbexceptionerr.Message, "Access Error")
                DoStartUpSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            Catch InvalidOperationExceptionerr As InvalidOperationException
                If bShowError = 1 Then MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
                DoStartUpSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End Try

            If connection.State <> ConnectionState.Open Then
                If bShowError = 1 Then MessageBox.Show("Database connection Failed")
                DoStartUpSql = False
                connection.Close()
                connection.Dispose()
                Exit Function
            End If

            command.CommandType = CommandType.Text
            command.CommandText = sSql
            command.ExecuteNonQuery() 'Do it!

            count = command.UpdatedRowSource
            If count = 0 Then
                If bShowError = 1 Then MessageBox.Show("No records processed")
            End If

            connection.Close()
            connection.Dispose()
            'connection = Nothing

        End Using

        Exit Function

        ' error message wanted?
        If bShowError Then
            Call MessageBox.Show("DoStartUpSQL", "Last SQL: " & sSql)
        End If

    End Function

    Public Function AccountExist(vsAccountNo As Object) As Integer

        Dim sSql As String

        sSql = "SELECT AccountNo FROM dirpbs"
        sSql = sSql & " WHERE AccountNo = " & qte(vsAccountNo)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            AccountExist = True
        Else
            AccountExist = False
        End If

        ds.Dispose()

    End Function

    Public Function AccountsExist() As Integer

        Dim sSql As String
        Dim nRecords As Integer

        sSql = "SELECT Count(*) as NumRecords FROM dirpbs"
        If giUserLevel = 2 Then
            sSql = sSql & " WHERE UserName = " & qte(gsUserName)
        End If

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        nRecords = ds.Rows.Item(0)("NumRecords")

        If nRecords > 0 Then
            AccountsExist = True
        Else
            AccountsExist = False
        End If

        ds.Dispose()

    End Function

    Function RecordsExist(vsAccountNo As Object) As Integer

        Dim sSql As String

        sSql = "SELECT * From pbstrans"
        sSql = sSql & " WHERE AccountNo = " & qte(CStr(vsAccountNo))

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            RecordsExist = True
        Else
            RecordsExist = False
        End If

        ds.Dispose()

    End Function

    Function FieldExists(ByRef db As Object, ByRef sTable As String, ByRef sField As String) As Short

        Dim X As Short

        FieldExists = False

        'loop around all fields in database checking for field
        For X = 0 To db.TableDefs(sTable).Fields.Count - 1
            'Debug.Print db.TableDefs(sTable).Fields(x).Name
            If UCase(db.TableDefs(sTable).Fields(X).Name) = UCase(sField) Then
                FieldExists = True
                Exit Function
            End If
        Next X

    End Function

    Function qte(ByRef vntValue As String) As String
        '***************************************************************
        ' Purpose:    Puts single quotes (') around a string passed
        '             to the function;
        '             Converts input of any type to string automatically;
        '             Also replaces any single quotes in a string with comma;
        '             Useful for SQL statements.
        '
        ' Example:    sSQl = "SELECT * FROM table WHERE name = " & qte(sName)
        '
        ' Parameters: vntValue : the string requiring single quotes
        '
        ' Assumes:    ERRHANDL.BAS available
        '
        ' Result:     The string is returned in single quotes.
        '
        ' Effects:    nothing
        '
        '***************************************************************

        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        '
        '***************************************************************

        Dim sQte As String

        sQte = "'"

        qte = DoQte(vntValue, sQte)

    End Function

    Function DoQte(ByRef vntValue As String, ByRef vsDelimiter As String) As String
        '***************************************************************
        ' Purpose:    Puts quotes, ' or ", around a string passed
        '             to the function;
        '             Converts input of any type to string automatically;
        '             Also replaces any quotes in a string with `;
        '             Useful for SQL statements.
        '
        ' Example:    sSQl = "SELECT * FROM table WHERE name = " & qte(sName)
        '
        ' Parameters: vntValue : the string requiring single quotes
        '             vsDelimiter: either a single or double quote character
        '
        ' Assumes:    ERRHANDL.BAS available
        '
        ' Result:     The string is returned in single quotes.
        '
        ' Effects:    nothing
        '
        '***************************************************************

        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 02/11/96 JG  Convert vntValue to string before performing
        '              string operations
        '***************************************************************

        Dim nQuotePos As Short
        Dim sValue As String

        On Error GoTo ERH_DoQte

        ' return NULL if null value passed in..
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(vntValue) Then
            DoQte = "NULL" 'string value only
            Exit Function
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object vntValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sValue = CStr(vntValue) 'convert to a string now - jpg

        ' replace any quotes with a `
        nQuotePos = 0
        nQuotePos = InStr(sValue, vsDelimiter)
        Do While nQuotePos > 0
            Mid(sValue, nQuotePos, 1) = "`"
            nQuotePos = InStr(nQuotePos + 1, sValue, vsDelimiter)
        Loop

        ' replace any Chr$(0) with spaces
        nQuotePos = InStr(sValue, Chr(0))
        Do While nQuotePos > 0
            Mid(sValue, nQuotePos, 1) = " "
            nQuotePos = InStr(nQuotePos + 1, sValue, Chr(0))
        Loop

        DoQte = vsDelimiter & sValue & vsDelimiter

        Exit Function

ERH_DoQte:

        'Select Case DefaultErrorHandler(Err.Number, "DoQte")
        '    Case giERROR_TYPE_RESUME
        'Resume
        '    Case giERROR_TYPE_RESUMENEXT
        'Resume Next
        '    Case giERROR_TYPE_UNRECOVERABLE
        DoQte = "NULL"
        Exit Function
        'End Select

    End Function

    Function AccessDate(ByVal varDate As Date) As String
        '***************************************************************
        '
        ' Purpose   : Returns a date string in the format necessary for AccessSQL
        '
        ' Assumes   :
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 06/12/96 JG  Created
        '***************************************************************

        AccessDate = "#" & FormatDateTime(varDate, DateFormat.LongDate) & "#"

    End Function

    Function AccessDateTime(ByVal varDate As Date) As String
        '***************************************************************
        '
        ' Purpose   : Returns a date string in the format necessary for AccessSQL
        '
        ' Assumes   :
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 06/12/96 JG  Created
        '***************************************************************

        AccessDateTime = "#" & FormatDateTime(varDate, DateFormat.LongDate) & "#"

    End Function

    Function AccessTime(ByVal varDate As Date) As String
        '***************************************************************
        '
        ' Purpose   : Returns a date string in the format necessary for AccessSQL
        '
        ' Assumes   :
        '
        '***************************************************************
        ' History:
        '
        ' Date     Who Description
        ' -------- --- -------------------------------------------------
        ' 06/12/96 JG  Created
        '***************************************************************

        AccessTime = "#" & varDate & "#"

    End Function

    Public Sub DropTable(sTable As String)

        Dim sSql As String

        sSql = "DROP TABLE " & sTable

        On Error Resume Next
        If DoSql(sSql, 1) Then 'was False
        End If
        On Error GoTo 0

    End Sub

    Public Sub DropTable2(sTable As String)

        Dim sSql As String

        sSql = "DROP TABLE " & sTable

        On Error Resume Next
        If DoSql2(sSql, 1) Then 'was False
        End If
        On Error GoTo 0

    End Sub

    Public Sub DropTable3(sTable As String)

        Dim sSql As String

        sSql = "DROP TABLE " & sTable

        On Error Resume Next
        If DoSql3(sSql, 1) Then 'was False
        End If
        On Error GoTo 0

    End Sub


    ' Purpose   : Given a month string (range Jan to Dec)
    '             returns the month number (range 1 to 12)
    ' Example   : print GetMonthAsNumber("Jan")  ' 1
    '
    Function GetMonthAsNumber(ByVal sMonth As String) As Integer

        GetMonthAsNumber = InStr("..JanFebMarAprMayJunJulAugSepOctNovDec", sMonth) / 3
        '                           3  6  9  12 15 18 21 24 27 30 33 36

    End Function

    ' Purpose   : Given a month number (range 1 to 12)
    '             returns the month string
    ' Example   : print GetMonthAsString(1)  ' Jan
    '
    Function GetMonthAsString(ByVal nMonth As Integer) As String

        If nMonth < 1 Then nMonth = 1

        GetMonthAsString = Mid("JanFebMarAprMayJunJulAugSepOctNovDec", ((nMonth - 1) * 3) + 1, 3)

    End Function

    Public Sub GetTranCCY(sAccountNo As String, ByRef sTranCCY As String)

        Dim sSql As String
        Dim nCount As Integer = 0

        sSql = "SELECT Currency FROM DirPbs"
        sSql = sSql & " WHERE AccountNo = " & qte(sAccountNo)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            sTranCCY = ds.Rows.Item(nCount)("Currency")
        End If

        ds.Dispose()

    End Sub

    Public Sub GetTranCCYFmt()

        Dim sSql As String
        Dim iNoOfDP As Integer = 0
        Dim nCount As Integer = 0

        'get currency info - transaction ccy
        sSql = "SELECT DecimalPlaces FROM Currencies"
        sSql = sSql & " WHERE Code = " & qte(gsTranCCY)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            iNoOfDP = ds.Rows.Item(nCount)("DecimalPlaces")
            gsTranCCYFmt = "###,###,##0" & IIf(iNoOfDP = 0, "", "." & Mid("000", 1, iNoOfDP))
        End If

        ds.Dispose()

    End Sub

    Public Sub GetBaseCCY()

        'Dim snCurrency As Recordset
        Dim sSql As String
        Dim iNoOfDP As Integer = 0
        Dim nCount As Integer = 0

        'get currency info - base ccy
        sSql = "SELECT Code, DecimalPlaces FROM Currencies"
        sSql = sSql & " WHERE BaseCCY = 'Y'"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            gsBaseCCY = ds.Rows.Item(nCount)("Code")
            iNoOfDP = ds.Rows.Item(nCount)("DecimalPlaces")
            gsBaseCCYFmt = "###,###,##0" & IIf(iNoOfDP = 0, "", "." & Mid("000", 1, iNoOfDP))
        End If

        ds.Dispose()

    End Sub

    Public Function ConvertAmount( _
                                CCYAmount As Double, _
                                sFromCCY As String, _
                                sToCCY As String) As Double

        Dim CCYRate As Double
        Dim sDOrM As String = ""

        'nothing to do?
        If sFromCCY = sToCCY Then
            ConvertAmount = CCYAmount
            Exit Function
        End If

        'convert from From ccy to Base ccy?
        If sFromCCY <> gsBaseCCY Then
            Call GetRate(sFromCCY, CCYRate, sDOrM)
            If sDOrM = "D" Then
                CCYAmount = CCYAmount / CCYRate
            ElseIf sDOrM = "M" Then
                CCYAmount = CCYAmount * CCYRate
            Else
                Call MsgBox("Cannot find exchange rate for currency " & sFromCCY)
            End If
        End If

        'convert from Base ccy to To ccy?
        If sToCCY <> gsBaseCCY Then
            Call GetRate(sToCCY, CCYRate, sDOrM)
            If sDOrM = "D" Then
                CCYAmount = CCYAmount * CCYRate
            ElseIf sDOrM = "M" Then
                CCYAmount = CCYAmount / CCYRate
            Else
                Call MsgBox("Cannot find exchange rate for currency " & sToCCY)
            End If
        End If

        ConvertAmount = CCYAmount

    End Function

    Public Sub GetRate(sCCYCode As String, ByRef CCYRate As Double, ByRef sDOrM As String)

        Dim sSql As String
        Dim nCount As Integer = 0

        'get currency info
        sSql = "SELECT Rate, Type FROM Currencies"
        sSql = sSql & " WHERE Code = " & qte(sCCYCode)

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        If ds.Rows.Count > 0 Then
            CCYRate = ds.Rows.Item(nCount)("Rate")
            sDOrM = ds.Rows.Item(nCount)("Type")
        Else
            CCYRate = 1
            sDOrM = ""
        End If

        ds.Dispose()

    End Sub

    Public Sub SetBalanceStatus(sAccountNo As String, iBalanceStatus As Integer)

        Dim sSql As String = Nothing

        sSql = "Update dirpbs"
        sSql = sSql + " Set BalanceStatus = " + qte(iBalanceStatus)
        sSql = sSql + " Where AccountNo = " + qte(sAccountNo)

        If DoSql(sSql, 1) Then
        End If

    End Sub

    Public Function Encrypt(ByVal vsInput) As String

        'Temporary variables
        Dim sTemp As String = ""
        Dim sTemp2 As String = ""
        Dim nChar As Integer

        'Use Ascii value plus a bit for each character in the string, and rebuild it
        For nChar = 1 To Len(vsInput)
            sTemp = sTemp + Chr(Asc(Mid(vsInput, nChar, 1)) + (nChar + miOFFSET) + nChar)
        Next nChar

        'Displace characters
        For nChar = Len(vsInput) To 1 Step -1
            sTemp2 = sTemp2 + Mid(sTemp, nChar, 1)
        Next nChar

        'There you are
        Encrypt = sTemp2

    End Function

    Public Function DeCrypt(ByVal vsInput As String) As String

        'Temporary variables
        Dim sTemp1 As String = ""
        Dim sTemp2 As String = ""
        Dim nChar As Integer

        'Turn back the right way
        For nChar = Len(vsInput) To 1 Step -1
            sTemp1 = sTemp1 + Mid(vsInput, nChar, 1)
        Next nChar

        'Read back the correct values of each character in the string
        For nChar = 1 To Len(sTemp1)
            sTemp2 = sTemp2 + Chr(Asc(Mid(sTemp1, nChar, 1)) - (nChar + miOFFSET) - nChar)
        Next nChar

        'There you are
        DeCrypt = sTemp2

    End Function

    Public Sub GetTransferID(ByRef TransferID As Integer)

        Dim sTransferID As String = Nothing

        'Now get TransferID from Live db parameter table
        Call GetParameter("TransferID", sTransferID)

        TransferID = Integer.Parse(sTransferID)

        'Make generic?
        'Dim sSql As String = "Select TransferIDIndex From TransferID"

        'Using connection As New OleDb.OleDbConnection(gsVpbsConnection)

        'Dim command As New OleDb.OleDbCommand(sSql, connection)

        'Try
        'connection.Open()
        'Catch oledbexceptionerr As OleDb.OleDbException
        'MessageBox.Show(oledbexceptionerr.Message, "Access Error")
        'Catch InvalidOperationExceptionerr As InvalidOperationException
        'MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
        'End Try

        'If connection.State <> ConnectionState.Open Then
        'MessageBox.Show("Database connection Failed")
        'End If

        'Dim reader As OleDb.OleDbDataReader = Command.ExecuteReader()

        'While reader.Read()

        'TransferID = Integer.Parse(reader.GetString(0))

        'End While

        ' always call Close when done reading.
        'reader.Close()
        'connection.Close()
        'connection.Dispose()

        'End Using

    End Sub

    Public Sub SaveTransferID(ByRef sTransferID As String)

        'Now save TransferID in Live db...
        Call SaveParameter("TransferID", sTransferID)

        'Make generic by passing sSql as parameter...
        'Dim sSql As String = "Update TransferID Set TransferIDIndex = '" + sTransferID + "'"
        'Dim count As Integer

        'Using connection As New OleDb.OleDbConnection(gsVpbsConnection)

        'Dim command As New OleDb.OleDbCommand(sSql, connection)

        'Try
        'connection.Open()
        'Catch oledbexceptionerr As OleDb.OleDbException
        'MessageBox.Show(oledbexceptionerr.Message, "Access Error")
        'Catch InvalidOperationExceptionerr As InvalidOperationException
        'MessageBox.Show(InvalidOperationExceptionerr.Message, "Access Error")
        'End Try

        'If connection.State <> ConnectionState.Open Then
        'MessageBox.Show("Database connection Failed")
        'End If

        'Command.CommandType = CommandType.Text
        'Command.CommandText = sSql
        'Command.ExecuteNonQuery() 'Do it!

        'count = Command.UpdatedRowSource

        'connection.Close()
        'connection.Dispose()
        'connection = Nothing

        'End Using

    End Sub

    Public Sub GetParameter(sParameter As String, ByRef sParameterData As String)

        Dim sSql As String
        Dim nCount As Integer = 0

        'Get ParameterData from Live DB!
        sSql = "Select ParameterData From [Parameters]" ' seems to need square brackets and a ";"
        sSql = sSql + " Where Parameter = " & qte(sParameter) & ";"

        Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sSql, gsVpbsStartUpConnection)
        Dim ds As New DataTable
        adapter.Fill(ds)

        nCount = 0
        If ds.Rows.Count > 0 Then
            sParameterData = ds.Rows.Item(nCount)("ParameterData").ToString
        Else
            sParameterData = ""
        End If

        ds.Dispose()

    End Sub

    Public Sub SaveParameter(sParameter As String, ByRef sParameterData As String)

        Dim sSql As String

        'Update ParameterData in Live DB!
        sSql = "Update [Parameters]" ' seems to need square brackets and a ";"
        sSql = sSql + " Set ParameterData = " & qte(sParameterData)
        sSql = sSql + " Where Parameter = " & qte(sParameter) & ";"

        If DoStartUpSql(sSql, 1) Then
        End If

    End Sub

    Public Sub SetRefreshReqd()

        Dim sSql As String

        'Set RefreshReqd flag in dirbud for all budgets
        sSql = "UPDATE dirbud"
        sSql = sSql & " SET RefreshReqd = 'Yes'"

        If DoSql(sSql, 1) Then
        End If

    End Sub

End Module
