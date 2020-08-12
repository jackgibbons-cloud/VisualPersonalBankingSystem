Option Strict Off
Option Explicit On
Module Vpbs2

    Declare Function GetModuleUsage Lib "Kernel32" (ByVal hModule As Integer) As Integer

    Public gsDBName As String 'jpg
    Public gsAuxDBName As String 'jpg added 13/02/17
    Public gsTb As String
    Public gsAccountNo As String 'New VB6.FixedLengthString(16)
    Public gsAccountName As String
    Public gsAccountDesc As String
    Public gsBankName As String
    Public gsBankBranch As String
    Public gsBankCode As String 'added 18/12/2014
    Public gcBalance As Decimal
    Public gvBalanceDate As Date
    Public giBalanceStatus As Short
    Public gcodLimit As Decimal 'added 18/12/2014
    Public gsBudgetNo As String
    Public gsBudgetType As String
    Public gsFileName As String 'added 14/11/2017

    Public gsTranCCY As String
    Public gsTranCCYFmt As String
    Public gsBaseCCY As String
    Public gsBaseCCYFmt As String

    Public giDirpbsNew As Short
    Public gvStartDate As Date
    Public gsDaysPerMonth As String
    Public gvPostDate As Date
    Public gvPreviousPostDate As Date
    Public gvPreviousPostTimeKey As Date
    Public gvPeriodFrom As Date
    Public gvPeriodTo As Date
    Public gsStartMonth As String
    Public gvdTxtDateTag As Date
    Public gsRec As String

    Public gsQueryType As String
    Public giPostAllSOs As Short
    'Dim gsPostAllSOs As String = "N"
    Public giAccountsExist As Short
    Public giSecurity As Short
    Public giRecChange As Short
    Public giAutoRec As Boolean
    Public giAutoSO As Short
    Public giProjSO As Short
    Public giBudget As Short
    Public giActual As Short

    Public gsGroupNo As String
    Public gsGroupDesc As String
    Public gsAccountYear As String
    Public gsBusinessType As String
    Public gcGLBalance As Decimal
    Public gsPalBalRpt As String
    Public gsJrnlType As String

    Public gsActual As String
    Public gsCustom As String
    Public miOptLevel As Short
    Public giChkAccounts As Boolean
    Public giChkBudgets As Boolean
    Public giChkContacts As Boolean
    Public giChkImportExport As Boolean
    Public giChkManualSOs As Boolean
    Public giChkReconciliation As Boolean
    Public giChkSafeCustody As Boolean
    Public giChkSalesandPurs As Boolean
    Public giChkEnableVAT As Boolean
    Public giChkPostAllSOs As Boolean
    Public giChkAutoNext As Boolean
    Public giChkScreenFormats As Boolean
    Public giChkSecurity As Boolean

    Public Const gsVERSION As String = "13.0.2"
    Public Const giADD As Short = 1
    Public Const giCHANGE As Short = 2
    Public Const giDELETE As Short = 3
    Public Const giFIND As Short = 4 'added 02/09/15

    Public Const gsIncExp As String = "'INC','COS','EXP'"
    Public Const gsFIX As String = "FIX"
    Public Const gsCUR As String = "CUR"
    Public Const gsCRE As String = "CRE"
    Public Const gsCAP As String = "CAP"
    Public Const gsCAB As String = "CAB"
    Public Const gsCIH As String = "CIH"
    Public Const gsOD As String = "OD "
    Public Const gsSTK As String = "STK"
    Public Const gsSUS As String = "SUS"
    Public Const gsPaL As String = "P&L"
    Public Const gsINC As String = "INC"
    Public Const gsCOS As String = "COS"
    Public Const gsEXP As String = "EXP"
    Public Const gsAUD As String = "AUD"
    Public Const gsJNL As String = "JNL"
    Public Const gsSCR As String = "SCR"
    Public Const gsSDR As String = "SDR"
    Public Const gsVAT As String = "VAT"

    Public Const giMAX_LOGINS As Short = 3

    ' Global DB variables
    'Public gsDBFileName As String ' Access Current Database path & name
    Public gbDBLive As Boolean ' True = Live; False = Archive jpg ***
    Public Const gsDBLiveFileName As String = "C:\VPBS\VPBS.MDB" 'Default DB jpg ***
    Public Const gsDBArcFileName As String = "C:\VPBS\VPBSArchive.MDB" 'Default DB jpg ***
    Public Const gsReportDir As String = "C:\VPBS" 'jpg

    Public gsVpbsStartUpConnection As String
    Public gsVpbsConnection As String
    Public gsVpbsArcConnection As String
    Public gsVpbsConnection2 As String 'added 3/11/17
    Public gsVpbsConnection3 As String 'added 13/11/17

    Public gsUserName As String
    Public gsPassword As String
    Public giUserLevel As Short
    Public giLoginAttempts As Short ' Count of login attempts
    Public gbCancel As Integer      ' Used to indicate an action Cancelled

End Module
