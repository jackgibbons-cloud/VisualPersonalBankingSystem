<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPbsTrans
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPbsTrans))
        Me.DataGridDirPbs = New System.Windows.Forms.DataGridView()
        Me.AccountNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountDescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankBranchDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceEquivalentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OdLimitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BudgetNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirpbsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VPBSDataSet = New VPBS13.VPBSDataSet()
        Me.lblAccountHeader = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTransferID = New System.Windows.Forms.TextBox()
        Me.txtTimeKey = New System.Windows.Forms.TextBox()
        Me.cboTransfer = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.txtEquiv = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPayReceipt = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboGLcode = New System.Windows.Forms.ComboBox()
        Me.GLCodeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboAnalysis = New System.Windows.Forms.ComboBox()
        Me.AnalysisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboReference = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDateFind = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rdoOption11 = New System.Windows.Forms.RadioButton()
        Me.rdoOption9 = New System.Windows.Forms.RadioButton()
        Me.rdoOption10 = New System.Windows.Forms.RadioButton()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.rdoOption3 = New System.Windows.Forms.RadioButton()
        Me.rdoOption2 = New System.Windows.Forms.RadioButton()
        Me.rdoOption1 = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtGroup3 = New System.Windows.Forms.TextBox()
        Me.txtGroup2 = New System.Windows.Forms.TextBox()
        Me.txtGroup1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboGroup3 = New System.Windows.Forms.ComboBox()
        Me.cboGroup2 = New System.Windows.Forms.ComboBox()
        Me.cboGroup1 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ProjDateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtProjBalance = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAcToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewAccountDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeAccountDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ArchiveTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportBankStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportBankStatementDevToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrinterSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoStandingOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualStandingOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconciliationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BudgetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FirstTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LastTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoStandingOrdersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualStandingOrdersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconciliationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ForwardProjectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinanceStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ActualsVBudgetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshBalancesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GLcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AmountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultipleEnquiryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandingOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconciiationStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FinanceStatementToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ActualsVBudgetsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserNamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnalysisCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GLCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrenciesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConcurrentSOsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordsOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonslAccountingSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutVisualPBSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.DataGridPbsTrans = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnalysisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GlcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReconciledDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VATDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitCreditDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PbstransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdFind = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdChange = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdSelect = New System.Windows.Forms.Button()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdOkProj = New System.Windows.Forms.Button()
        Me.CmdOkFind = New System.Windows.Forms.Button()
        Me.CmdOkReport = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.VpbsTestDataSet = New VPBS13.VPBSTestDataSet()
        Me.PbstransTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.pbstransTableAdapter()
        Me.DirpbsTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter()
        Me.AnalysisTableAdapter = New VPBS13.VPBSDataSetTableAdapters.AnalysisTableAdapter()
        Me.CustomersTableAdapter = New VPBS13.VPBSDataSetTableAdapters.CustomersTableAdapter()
        Me.GLCodeTableAdapter = New VPBS13.VPBSDataSetTableAdapters.GLCodeTableAdapter()
        Me.VpbsArchiveDataSet = New VPBS13.VpbsArchiveDataSet()
        Me.PbstransTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.pbstransTableAdapter()
        Me.DirpbsTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter()
        Me.AnalysisTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.AnalysisTableAdapter()
        Me.GLCodeTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.GLCodeTableAdapter()
        Me.CustomersTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.CustomersTableAdapter()
        Me.DirpbsTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter()
        Me.PbstransTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.pbstransTableAdapter()
        Me.AnalysisTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.AnalysisTableAdapter()
        Me.GLCodeTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.GLCodeTableAdapter()
        Me.CustomersTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.CustomersTableAdapter()
        Me.TransTempATableAdapter1 = New VPBS13.VPBSDataSet1TableAdapters.TransTempATableAdapter()
        Me.PrintDialog2 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.AxCrystalReport1 = New AxCrystal.AxCrystalReport()
        CType(Me.DataGridDirPbs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLCodeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnalysisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridPbsTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbstransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridDirPbs
        '
        Me.DataGridDirPbs.AllowUserToAddRows = False
        Me.DataGridDirPbs.AllowUserToDeleteRows = False
        Me.DataGridDirPbs.AllowUserToOrderColumns = True
        Me.DataGridDirPbs.AllowUserToResizeRows = False
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.White
        Me.DataGridDirPbs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle27
        Me.DataGridDirPbs.AutoGenerateColumns = False
        Me.DataGridDirPbs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridDirPbs.BackgroundColor = System.Drawing.Color.White
        Me.DataGridDirPbs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridDirPbs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridDirPbs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.DataGridDirPbs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridDirPbs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountNoDataGridViewTextBoxColumn, Me.AccountNameDataGridViewTextBoxColumn, Me.AccountDescDataGridViewTextBoxColumn, Me.BankNameDataGridViewTextBoxColumn, Me.BalanceDataGridViewTextBoxColumn, Me.CurrencyDataGridViewTextBoxColumn, Me.BalanceDateDataGridViewTextBoxColumn, Me.BankBranchDataGridViewTextBoxColumn, Me.BankCodeDataGridViewTextBoxColumn, Me.BalanceEquivalentDataGridViewTextBoxColumn, Me.OdLimitDataGridViewTextBoxColumn, Me.UserNameDataGridViewTextBoxColumn, Me.BudgetNoDataGridViewTextBoxColumn1, Me.BalanceStatusDataGridViewTextBoxColumn})
        Me.DataGridDirPbs.DataSource = Me.DirpbsBindingSource
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridDirPbs.DefaultCellStyle = DataGridViewCellStyle32
        Me.DataGridDirPbs.GridColor = System.Drawing.Color.White
        Me.DataGridDirPbs.Location = New System.Drawing.Point(13, 62)
        Me.DataGridDirPbs.MultiSelect = False
        Me.DataGridDirPbs.Name = "DataGridDirPbs"
        Me.DataGridDirPbs.ReadOnly = True
        Me.DataGridDirPbs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridDirPbs.Size = New System.Drawing.Size(781, 264)
        Me.DataGridDirPbs.TabIndex = 1
        '
        'AccountNoDataGridViewTextBoxColumn
        '
        Me.AccountNoDataGridViewTextBoxColumn.DataPropertyName = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.HeaderText = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.Name = "AccountNoDataGridViewTextBoxColumn"
        Me.AccountNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.AccountNoDataGridViewTextBoxColumn.Width = 108
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.AccountNameDataGridViewTextBoxColumn.Width = 129
        '
        'AccountDescDataGridViewTextBoxColumn
        '
        Me.AccountDescDataGridViewTextBoxColumn.DataPropertyName = "AccountDesc"
        Me.AccountDescDataGridViewTextBoxColumn.HeaderText = "AccountDesc"
        Me.AccountDescDataGridViewTextBoxColumn.Name = "AccountDescDataGridViewTextBoxColumn"
        Me.AccountDescDataGridViewTextBoxColumn.ReadOnly = True
        Me.AccountDescDataGridViewTextBoxColumn.Width = 124
        '
        'BankNameDataGridViewTextBoxColumn
        '
        Me.BankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName"
        Me.BankNameDataGridViewTextBoxColumn.HeaderText = "BankName"
        Me.BankNameDataGridViewTextBoxColumn.Name = "BankNameDataGridViewTextBoxColumn"
        Me.BankNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.BankNameDataGridViewTextBoxColumn.Width = 109
        '
        'BalanceDataGridViewTextBoxColumn
        '
        Me.BalanceDataGridViewTextBoxColumn.DataPropertyName = "Balance"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.NullValue = Nothing
        Me.BalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle29
        Me.BalanceDataGridViewTextBoxColumn.HeaderText = "Balance"
        Me.BalanceDataGridViewTextBoxColumn.Name = "BalanceDataGridViewTextBoxColumn"
        Me.BalanceDataGridViewTextBoxColumn.ReadOnly = True
        Me.BalanceDataGridViewTextBoxColumn.Width = 90
        '
        'CurrencyDataGridViewTextBoxColumn
        '
        Me.CurrencyDataGridViewTextBoxColumn.DataPropertyName = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.HeaderText = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.Name = "CurrencyDataGridViewTextBoxColumn"
        Me.CurrencyDataGridViewTextBoxColumn.ReadOnly = True
        Me.CurrencyDataGridViewTextBoxColumn.Width = 94
        '
        'BalanceDateDataGridViewTextBoxColumn
        '
        Me.BalanceDateDataGridViewTextBoxColumn.DataPropertyName = "BalanceDate"
        Me.BalanceDateDataGridViewTextBoxColumn.HeaderText = "BalanceDate"
        Me.BalanceDateDataGridViewTextBoxColumn.Name = "BalanceDateDataGridViewTextBoxColumn"
        Me.BalanceDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.BalanceDateDataGridViewTextBoxColumn.Width = 123
        '
        'BankBranchDataGridViewTextBoxColumn
        '
        Me.BankBranchDataGridViewTextBoxColumn.DataPropertyName = "BankBranch"
        Me.BankBranchDataGridViewTextBoxColumn.HeaderText = "BankBranch"
        Me.BankBranchDataGridViewTextBoxColumn.Name = "BankBranchDataGridViewTextBoxColumn"
        Me.BankBranchDataGridViewTextBoxColumn.ReadOnly = True
        Me.BankBranchDataGridViewTextBoxColumn.Width = 116
        '
        'BankCodeDataGridViewTextBoxColumn
        '
        Me.BankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode"
        Me.BankCodeDataGridViewTextBoxColumn.HeaderText = "BankCode"
        Me.BankCodeDataGridViewTextBoxColumn.Name = "BankCodeDataGridViewTextBoxColumn"
        Me.BankCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.BankCodeDataGridViewTextBoxColumn.Width = 105
        '
        'BalanceEquivalentDataGridViewTextBoxColumn
        '
        Me.BalanceEquivalentDataGridViewTextBoxColumn.DataPropertyName = "BalanceEquivalent"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.BalanceEquivalentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle30
        Me.BalanceEquivalentDataGridViewTextBoxColumn.HeaderText = "BalanceEquivalent"
        Me.BalanceEquivalentDataGridViewTextBoxColumn.Name = "BalanceEquivalentDataGridViewTextBoxColumn"
        Me.BalanceEquivalentDataGridViewTextBoxColumn.ReadOnly = True
        Me.BalanceEquivalentDataGridViewTextBoxColumn.Width = 163
        '
        'OdLimitDataGridViewTextBoxColumn
        '
        Me.OdLimitDataGridViewTextBoxColumn.DataPropertyName = "odLimit"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.OdLimitDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle31
        Me.OdLimitDataGridViewTextBoxColumn.HeaderText = "odLimit"
        Me.OdLimitDataGridViewTextBoxColumn.Name = "OdLimitDataGridViewTextBoxColumn"
        Me.OdLimitDataGridViewTextBoxColumn.ReadOnly = True
        Me.OdLimitDataGridViewTextBoxColumn.Width = 83
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        Me.UserNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.UserNameDataGridViewTextBoxColumn.Width = 107
        '
        'BudgetNoDataGridViewTextBoxColumn1
        '
        Me.BudgetNoDataGridViewTextBoxColumn1.DataPropertyName = "BudgetNo"
        Me.BudgetNoDataGridViewTextBoxColumn1.HeaderText = "BudgetNo"
        Me.BudgetNoDataGridViewTextBoxColumn1.Name = "BudgetNoDataGridViewTextBoxColumn1"
        Me.BudgetNoDataGridViewTextBoxColumn1.ReadOnly = True
        Me.BudgetNoDataGridViewTextBoxColumn1.Width = 102
        '
        'BalanceStatusDataGridViewTextBoxColumn
        '
        Me.BalanceStatusDataGridViewTextBoxColumn.DataPropertyName = "BalanceStatus"
        Me.BalanceStatusDataGridViewTextBoxColumn.HeaderText = "BalanceStatus"
        Me.BalanceStatusDataGridViewTextBoxColumn.Name = "BalanceStatusDataGridViewTextBoxColumn"
        Me.BalanceStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.BalanceStatusDataGridViewTextBoxColumn.Width = 133
        '
        'DirpbsBindingSource
        '
        Me.DirpbsBindingSource.DataMember = "dirpbs"
        Me.DirpbsBindingSource.DataSource = Me.VPBSDataSet
        '
        'VPBSDataSet
        '
        Me.VPBSDataSet.DataSetName = "VPBSDataSet"
        Me.VPBSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblAccountHeader
        '
        Me.lblAccountHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAccountHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAccountHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountHeader.Location = New System.Drawing.Point(12, 35)
        Me.lblAccountHeader.Name = "lblAccountHeader"
        Me.lblAccountHeader.Size = New System.Drawing.Size(782, 27)
        Me.lblAccountHeader.TabIndex = 1
        Me.lblAccountHeader.Text = "Select an Account Number to start..."
        Me.lblAccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAccountHeader.UseMnemonic = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.txtTransferID)
        Me.GroupBox2.Controls.Add(Me.txtTimeKey)
        Me.GroupBox2.Controls.Add(Me.cboTransfer)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtRec)
        Me.GroupBox2.Controls.Add(Me.txtEquiv)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboPayReceipt)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDetails)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboCustomer)
        Me.GroupBox2.Controls.Add(Me.cboGLcode)
        Me.GroupBox2.Controls.Add(Me.cboAnalysis)
        Me.GroupBox2.Controls.Add(Me.cboReference)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtDate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtDateFind)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 358)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(781, 156)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Changing Current Transaction"
        Me.GroupBox2.Visible = False
        '
        'txtTransferID
        '
        Me.txtTransferID.Location = New System.Drawing.Point(654, 133)
        Me.txtTransferID.Multiline = True
        Me.txtTransferID.Name = "txtTransferID"
        Me.txtTransferID.Size = New System.Drawing.Size(121, 24)
        Me.txtTransferID.TabIndex = 27
        Me.txtTransferID.Visible = False
        '
        'txtTimeKey
        '
        Me.txtTimeKey.Location = New System.Drawing.Point(225, 20)
        Me.txtTimeKey.Name = "txtTimeKey"
        Me.txtTimeKey.Size = New System.Drawing.Size(62, 22)
        Me.txtTimeKey.TabIndex = 25
        '
        'cboTransfer
        '
        Me.cboTransfer.AllowDrop = True
        Me.cboTransfer.DropDownHeight = 130
        Me.cboTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboTransfer.IntegralHeight = False
        Me.cboTransfer.Location = New System.Drawing.Point(410, 20)
        Me.cboTransfer.Name = "cboTransfer"
        Me.cboTransfer.Size = New System.Drawing.Size(365, 24)
        Me.cboTransfer.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Silver
        Me.Label12.Location = New System.Drawing.Point(547, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 24)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Equivalent"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Silver
        Me.Label11.Location = New System.Drawing.Point(547, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 24)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Amount"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(410, 110)
        Me.txtRec.Multiline = True
        Me.txtRec.Name = "txtRec"
        Me.txtRec.Size = New System.Drawing.Size(65, 24)
        Me.txtRec.TabIndex = 21
        '
        'txtEquiv
        '
        Me.txtEquiv.Location = New System.Drawing.Point(654, 110)
        Me.txtEquiv.Multiline = True
        Me.txtEquiv.Name = "txtEquiv"
        Me.txtEquiv.Size = New System.Drawing.Size(121, 24)
        Me.txtEquiv.TabIndex = 20
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(654, 80)
        Me.txtAmount.Multiline = True
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(121, 24)
        Me.txtAmount.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(481, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 24)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "(Y/N)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(303, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Reconciled"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(303, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 24)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Pay/Receipt"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(547, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "GL code"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(303, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 24)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Analysis code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPayReceipt
        '
        Me.cboPayReceipt.FormattingEnabled = True
        Me.cboPayReceipt.Items.AddRange(New Object() {"Payment", "Receipt"})
        Me.cboPayReceipt.Location = New System.Drawing.Point(410, 80)
        Me.cboPayReceipt.Name = "cboPayReceipt"
        Me.cboPayReceipt.Size = New System.Drawing.Size(121, 24)
        Me.cboPayReceipt.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(5, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 24)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Details"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(118, 110)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetails.Size = New System.Drawing.Size(169, 40)
        Me.txtDetails.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 24)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Customer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomer
        '
        Me.cboCustomer.AllowDrop = True
        Me.cboCustomer.DataSource = Me.CustomersBindingSource
        Me.cboCustomer.DisplayMember = "ShortName"
        Me.cboCustomer.DropDownHeight = 96
        Me.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.IntegralHeight = False
        Me.cboCustomer.Location = New System.Drawing.Point(118, 80)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(169, 24)
        Me.cboCustomer.TabIndex = 8
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "Customers"
        Me.CustomersBindingSource.DataSource = Me.VPBSDataSet
        '
        'cboGLcode
        '
        Me.cboGLcode.AllowDrop = True
        Me.cboGLcode.DataSource = Me.GLCodeBindingSource
        Me.cboGLcode.DisplayMember = "Code"
        Me.cboGLcode.DropDownHeight = 130
        Me.cboGLcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboGLcode.FormattingEnabled = True
        Me.cboGLcode.IntegralHeight = False
        Me.cboGLcode.Location = New System.Drawing.Point(654, 50)
        Me.cboGLcode.Name = "cboGLcode"
        Me.cboGLcode.Size = New System.Drawing.Size(121, 24)
        Me.cboGLcode.TabIndex = 7
        '
        'GLCodeBindingSource
        '
        Me.GLCodeBindingSource.DataMember = "GLCode"
        Me.GLCodeBindingSource.DataSource = Me.VPBSDataSet
        '
        'cboAnalysis
        '
        Me.cboAnalysis.AllowDrop = True
        Me.cboAnalysis.DataSource = Me.AnalysisBindingSource
        Me.cboAnalysis.DisplayMember = "Code"
        Me.cboAnalysis.DropDownHeight = 130
        Me.cboAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboAnalysis.FormattingEnabled = True
        Me.cboAnalysis.IntegralHeight = False
        Me.cboAnalysis.Location = New System.Drawing.Point(410, 50)
        Me.cboAnalysis.Name = "cboAnalysis"
        Me.cboAnalysis.Size = New System.Drawing.Size(121, 24)
        Me.cboAnalysis.TabIndex = 6
        '
        'AnalysisBindingSource
        '
        Me.AnalysisBindingSource.DataMember = "Analysis"
        Me.AnalysisBindingSource.DataSource = Me.VPBSDataSet
        '
        'cboReference
        '
        Me.cboReference.AllowDrop = True
        Me.cboReference.DropDownWidth = 169
        Me.cboReference.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboReference.FormattingEnabled = True
        Me.cboReference.Location = New System.Drawing.Point(118, 50)
        Me.cboReference.Name = "cboReference"
        Me.cboReference.Size = New System.Drawing.Size(169, 24)
        Me.cboReference.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Reference"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(303, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Transfer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDate
        '
        Me.txtDate.CustomFormat = "dd/MM/yyyy"
        Me.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDate.Location = New System.Drawing.Point(118, 20)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(105, 22)
        Me.txtDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(5, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDateFind
        '
        Me.txtDateFind.Location = New System.Drawing.Point(118, 20)
        Me.txtDateFind.Multiline = True
        Me.txtDateFind.Name = "txtDateFind"
        Me.txtDateFind.Size = New System.Drawing.Size(169, 24)
        Me.txtDateFind.TabIndex = 26
        Me.txtDateFind.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 336)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(783, 179)
        Me.TabControl1.TabIndex = 17
        Me.TabControl1.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Silver
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(775, 150)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Date Range         "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Controls.Add(Me.GroupBox10)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(766, 165)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Date Range"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(600, 86)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(137, 22)
        Me.DateTimePicker2.TabIndex = 7
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(238, 86)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(137, 22)
        Me.DateTimePicker1.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(383, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(179, 16)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "and/or Where date (optional)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Where date"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rdoOption11)
        Me.GroupBox9.Controls.Add(Me.rdoOption9)
        Me.GroupBox9.Controls.Add(Me.rdoOption10)
        Me.GroupBox9.Location = New System.Drawing.Point(386, 44)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(200, 95)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        '
        'rdoOption11
        '
        Me.rdoOption11.AutoSize = True
        Me.rdoOption11.Location = New System.Drawing.Point(12, 66)
        Me.rdoOption11.Name = "rdoOption11"
        Me.rdoOption11.Size = New System.Drawing.Size(98, 20)
        Me.rdoOption11.TabIndex = 4
        Me.rdoOption11.TabStop = True
        Me.rdoOption11.Text = "Not equal to"
        Me.rdoOption11.UseVisualStyleBackColor = True
        '
        'rdoOption9
        '
        Me.rdoOption9.AutoSize = True
        Me.rdoOption9.Location = New System.Drawing.Point(12, 22)
        Me.rdoOption9.Name = "rdoOption9"
        Me.rdoOption9.Size = New System.Drawing.Size(83, 20)
        Me.rdoOption9.TabIndex = 3
        Me.rdoOption9.TabStop = True
        Me.rdoOption9.Text = "Less than"
        Me.rdoOption9.UseVisualStyleBackColor = True
        '
        'rdoOption10
        '
        Me.rdoOption10.AutoSize = True
        Me.rdoOption10.Location = New System.Drawing.Point(12, 44)
        Me.rdoOption10.Name = "rdoOption10"
        Me.rdoOption10.Size = New System.Drawing.Size(135, 20)
        Me.rdoOption10.TabIndex = 2
        Me.rdoOption10.TabStop = True
        Me.rdoOption10.Text = "Less than/equal to"
        Me.rdoOption10.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.rdoOption3)
        Me.GroupBox10.Controls.Add(Me.rdoOption2)
        Me.GroupBox10.Controls.Add(Me.rdoOption1)
        Me.GroupBox10.Location = New System.Drawing.Point(23, 44)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(200, 95)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        '
        'rdoOption3
        '
        Me.rdoOption3.AutoSize = True
        Me.rdoOption3.Location = New System.Drawing.Point(17, 66)
        Me.rdoOption3.Name = "rdoOption3"
        Me.rdoOption3.Size = New System.Drawing.Size(75, 20)
        Me.rdoOption3.TabIndex = 2
        Me.rdoOption3.TabStop = True
        Me.rdoOption3.Text = "Equal to"
        Me.rdoOption3.UseVisualStyleBackColor = True
        '
        'rdoOption2
        '
        Me.rdoOption2.AutoSize = True
        Me.rdoOption2.Location = New System.Drawing.Point(17, 44)
        Me.rdoOption2.Name = "rdoOption2"
        Me.rdoOption2.Size = New System.Drawing.Size(151, 20)
        Me.rdoOption2.TabIndex = 1
        Me.rdoOption2.TabStop = True
        Me.rdoOption2.Text = "Greater than/equal to"
        Me.rdoOption2.UseVisualStyleBackColor = True
        '
        'rdoOption1
        '
        Me.rdoOption1.AutoSize = True
        Me.rdoOption1.Location = New System.Drawing.Point(17, 22)
        Me.rdoOption1.Name = "rdoOption1"
        Me.rdoOption1.Size = New System.Drawing.Size(99, 20)
        Me.rdoOption1.TabIndex = 0
        Me.rdoOption1.TabStop = True
        Me.rdoOption1.Text = "Greater than"
        Me.rdoOption1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Silver
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(775, 150)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Report Detail        "
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.txtGroup3)
        Me.GroupBox5.Controls.Add(Me.txtGroup2)
        Me.GroupBox5.Controls.Add(Me.txtGroup1)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.cboGroup3)
        Me.GroupBox5.Controls.Add(Me.cboGroup2)
        Me.GroupBox5.Controls.Add(Me.cboGroup1)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(764, 148)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Report Detail Section"
        '
        'txtGroup3
        '
        Me.txtGroup3.Location = New System.Drawing.Point(437, 109)
        Me.txtGroup3.Name = "txtGroup3"
        Me.txtGroup3.Size = New System.Drawing.Size(121, 22)
        Me.txtGroup3.TabIndex = 12
        Me.txtGroup3.Text = "txtGroup"
        '
        'txtGroup2
        '
        Me.txtGroup2.Location = New System.Drawing.Point(290, 109)
        Me.txtGroup2.Name = "txtGroup2"
        Me.txtGroup2.Size = New System.Drawing.Size(121, 22)
        Me.txtGroup2.TabIndex = 11
        Me.txtGroup2.Text = "txtGroup"
        '
        'txtGroup1
        '
        Me.txtGroup1.Location = New System.Drawing.Point(139, 109)
        Me.txtGroup1.Name = "txtGroup1"
        Me.txtGroup1.Size = New System.Drawing.Size(121, 22)
        Me.txtGroup1.TabIndex = 10
        Me.txtGroup1.Text = "txtGroup"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Silver
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(734, 29)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Includes repeating records in main body of report - decide which fields you want " &
    "to include in report."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(653, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 22)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Balance"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGroup3
        '
        Me.cboGroup3.FormattingEnabled = True
        Me.cboGroup3.Location = New System.Drawing.Point(437, 72)
        Me.cboGroup3.Name = "cboGroup3"
        Me.cboGroup3.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup3.TabIndex = 4
        '
        'cboGroup2
        '
        Me.cboGroup2.FormattingEnabled = True
        Me.cboGroup2.Location = New System.Drawing.Point(290, 72)
        Me.cboGroup2.Name = "cboGroup2"
        Me.cboGroup2.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup2.TabIndex = 3
        '
        'cboGroup1
        '
        Me.cboGroup1.FormattingEnabled = True
        Me.cboGroup1.Location = New System.Drawing.Point(139, 72)
        Me.cboGroup1.Name = "cboGroup1"
        Me.cboGroup1.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup1.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(570, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 22)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Amount"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(56, 74)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 22)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.ProjDateTimePicker1)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtProjBalance)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 386)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(780, 128)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Forward Projections"
        Me.GroupBox4.Visible = False
        '
        'ProjDateTimePicker1
        '
        Me.ProjDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ProjDateTimePicker1.Location = New System.Drawing.Point(164, 59)
        Me.ProjDateTimePicker1.Name = "ProjDateTimePicker1"
        Me.ProjDateTimePicker1.Size = New System.Drawing.Size(103, 22)
        Me.ProjDateTimePicker1.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Silver
        Me.Label13.Location = New System.Drawing.Point(422, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Projected Balance"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Silver
        Me.Label14.Location = New System.Drawing.Point(26, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 16)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Enter Projected Date"
        '
        'txtProjBalance
        '
        Me.txtProjBalance.Location = New System.Drawing.Point(550, 59)
        Me.txtProjBalance.Name = "txtProjBalance"
        Me.txtProjBalance.Size = New System.Drawing.Size(139, 22)
        Me.txtProjBalance.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FindToolStripMenuItem, Me.ViewToolStripMenuItem, Me.QueryToolStripMenuItem, Me.ReportToolStripMenuItem, Me.SetupToolStripMenuItem, Me.AccountsToolStripMenuItem, Me.AccountsToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(810, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAcToolStripMenuItem, Me.NewAccountDetailsToolStripMenuItem, Me.ChangeAccountDetailsToolStripMenuItem, Me.ToolStripSeparator1, Me.ArchiveTransactionsToolStripMenuItem, Me.ImportBankStatementToolStripMenuItem, Me.ImportBankStatementDevToolStripMenuItem, Me.PrinterSetupToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SelectAcToolStripMenuItem
        '
        Me.SelectAcToolStripMenuItem.Name = "SelectAcToolStripMenuItem"
        Me.SelectAcToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SelectAcToolStripMenuItem.Text = "&Select Account"
        '
        'NewAccountDetailsToolStripMenuItem
        '
        Me.NewAccountDetailsToolStripMenuItem.Name = "NewAccountDetailsToolStripMenuItem"
        Me.NewAccountDetailsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.NewAccountDetailsToolStripMenuItem.Text = "&New Account Details"
        '
        'ChangeAccountDetailsToolStripMenuItem
        '
        Me.ChangeAccountDetailsToolStripMenuItem.Name = "ChangeAccountDetailsToolStripMenuItem"
        Me.ChangeAccountDetailsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ChangeAccountDetailsToolStripMenuItem.Text = "&Change Account Details"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        '
        'ArchiveTransactionsToolStripMenuItem
        '
        Me.ArchiveTransactionsToolStripMenuItem.Name = "ArchiveTransactionsToolStripMenuItem"
        Me.ArchiveTransactionsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ArchiveTransactionsToolStripMenuItem.Text = "&Archive Transactions"
        '
        'ImportBankStatementToolStripMenuItem
        '
        Me.ImportBankStatementToolStripMenuItem.Name = "ImportBankStatementToolStripMenuItem"
        Me.ImportBankStatementToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ImportBankStatementToolStripMenuItem.Text = "&Import Bank Statement"
        '
        'ImportBankStatementDevToolStripMenuItem
        '
        Me.ImportBankStatementDevToolStripMenuItem.Name = "ImportBankStatementDevToolStripMenuItem"
        Me.ImportBankStatementDevToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ImportBankStatementDevToolStripMenuItem.Text = "Import Bank Statement - Dev"
        Me.ImportBankStatementDevToolStripMenuItem.Visible = False
        '
        'PrinterSetupToolStripMenuItem
        '
        Me.PrinterSetupToolStripMenuItem.Name = "PrinterSetupToolStripMenuItem"
        Me.PrinterSetupToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.PrinterSetupToolStripMenuItem.Text = "&Printer Setup"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(242, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoStandingOrdersToolStripMenuItem, Me.ManualStandingOrdersToolStripMenuItem, Me.ReconciliationToolStripMenuItem, Me.ToolStripSeparator5, Me.BudgetsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'AutoStandingOrdersToolStripMenuItem
        '
        Me.AutoStandingOrdersToolStripMenuItem.Name = "AutoStandingOrdersToolStripMenuItem"
        Me.AutoStandingOrdersToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.AutoStandingOrdersToolStripMenuItem.Text = "&Auto Standing Orders"
        '
        'ManualStandingOrdersToolStripMenuItem
        '
        Me.ManualStandingOrdersToolStripMenuItem.Name = "ManualStandingOrdersToolStripMenuItem"
        Me.ManualStandingOrdersToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ManualStandingOrdersToolStripMenuItem.Text = "&Manual Standing Orders"
        '
        'ReconciliationToolStripMenuItem
        '
        Me.ReconciliationToolStripMenuItem.Name = "ReconciliationToolStripMenuItem"
        Me.ReconciliationToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ReconciliationToolStripMenuItem.Text = "Bank &Reconciliation"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(217, 6)
        '
        'BudgetsToolStripMenuItem
        '
        Me.BudgetsToolStripMenuItem.Name = "BudgetsToolStripMenuItem"
        Me.BudgetsToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.BudgetsToolStripMenuItem.Text = "&Budgets"
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem1, Me.FirstTransactionToolStripMenuItem, Me.LastTransactionToolStripMenuItem})
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.FindToolStripMenuItem.Text = "&Find"
        '
        'FindToolStripMenuItem1
        '
        Me.FindToolStripMenuItem1.Name = "FindToolStripMenuItem1"
        Me.FindToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.FindToolStripMenuItem1.Text = "&Find"
        '
        'FirstTransactionToolStripMenuItem
        '
        Me.FirstTransactionToolStripMenuItem.Name = "FirstTransactionToolStripMenuItem"
        Me.FirstTransactionToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.FirstTransactionToolStripMenuItem.Text = "&First Transaction"
        '
        'LastTransactionToolStripMenuItem
        '
        Me.LastTransactionToolStripMenuItem.Name = "LastTransactionToolStripMenuItem"
        Me.LastTransactionToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.LastTransactionToolStripMenuItem.Text = "&Last Transaction"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoStandingOrdersToolStripMenuItem1, Me.ManualStandingOrdersToolStripMenuItem1, Me.ReconciliationToolStripMenuItem1, Me.ToolStripSeparator6, Me.ForwardProjectionsToolStripMenuItem, Me.FinanceStatementToolStripMenuItem, Me.ToolStripSeparator7, Me.ActualsVBudgetsToolStripMenuItem, Me.ToolStripSeparator11, Me.RefreshBalancesToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'AutoStandingOrdersToolStripMenuItem1
        '
        Me.AutoStandingOrdersToolStripMenuItem1.Name = "AutoStandingOrdersToolStripMenuItem1"
        Me.AutoStandingOrdersToolStripMenuItem1.Size = New System.Drawing.Size(220, 22)
        Me.AutoStandingOrdersToolStripMenuItem1.Text = "&Auto Standing Orders"
        '
        'ManualStandingOrdersToolStripMenuItem1
        '
        Me.ManualStandingOrdersToolStripMenuItem1.Name = "ManualStandingOrdersToolStripMenuItem1"
        Me.ManualStandingOrdersToolStripMenuItem1.Size = New System.Drawing.Size(220, 22)
        Me.ManualStandingOrdersToolStripMenuItem1.Text = "&Manual Standing Orders"
        '
        'ReconciliationToolStripMenuItem1
        '
        Me.ReconciliationToolStripMenuItem1.Name = "ReconciliationToolStripMenuItem1"
        Me.ReconciliationToolStripMenuItem1.Size = New System.Drawing.Size(220, 22)
        Me.ReconciliationToolStripMenuItem1.Text = "&Reconciliation"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(217, 6)
        '
        'ForwardProjectionsToolStripMenuItem
        '
        Me.ForwardProjectionsToolStripMenuItem.Name = "ForwardProjectionsToolStripMenuItem"
        Me.ForwardProjectionsToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ForwardProjectionsToolStripMenuItem.Text = "&Forward Projections"
        '
        'FinanceStatementToolStripMenuItem
        '
        Me.FinanceStatementToolStripMenuItem.Name = "FinanceStatementToolStripMenuItem"
        Me.FinanceStatementToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.FinanceStatementToolStripMenuItem.Text = "&Finance Statement"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(217, 6)
        '
        'ActualsVBudgetsToolStripMenuItem
        '
        Me.ActualsVBudgetsToolStripMenuItem.Name = "ActualsVBudgetsToolStripMenuItem"
        Me.ActualsVBudgetsToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ActualsVBudgetsToolStripMenuItem.Text = "&Actuals v Budgets"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(217, 6)
        '
        'RefreshBalancesToolStripMenuItem
        '
        Me.RefreshBalancesToolStripMenuItem.Name = "RefreshBalancesToolStripMenuItem"
        Me.RefreshBalancesToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.RefreshBalancesToolStripMenuItem.Text = "&Refresh Balances"
        '
        'QueryToolStripMenuItem
        '
        Me.QueryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateToolStripMenuItem, Me.ReferenceToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.AnalysisToolStripMenuItem, Me.GLcodeToolStripMenuItem, Me.AmountToolStripMenuItem, Me.MultipleEnquiryToolStripMenuItem})
        Me.QueryToolStripMenuItem.Name = "QueryToolStripMenuItem"
        Me.QueryToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.QueryToolStripMenuItem.Text = "&Query"
        '
        'DateToolStripMenuItem
        '
        Me.DateToolStripMenuItem.Name = "DateToolStripMenuItem"
        Me.DateToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DateToolStripMenuItem.Text = "&Date Range"
        '
        'ReferenceToolStripMenuItem
        '
        Me.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem"
        Me.ReferenceToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ReferenceToolStripMenuItem.Text = "&Reference"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CustomerToolStripMenuItem.Text = "&Customer"
        '
        'AnalysisToolStripMenuItem
        '
        Me.AnalysisToolStripMenuItem.Name = "AnalysisToolStripMenuItem"
        Me.AnalysisToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AnalysisToolStripMenuItem.Text = "&Analysis"
        '
        'GLcodeToolStripMenuItem
        '
        Me.GLcodeToolStripMenuItem.Name = "GLcodeToolStripMenuItem"
        Me.GLcodeToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.GLcodeToolStripMenuItem.Text = "&GLcode"
        '
        'AmountToolStripMenuItem
        '
        Me.AmountToolStripMenuItem.Name = "AmountToolStripMenuItem"
        Me.AmountToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AmountToolStripMenuItem.Text = "&Amount"
        '
        'MultipleEnquiryToolStripMenuItem
        '
        Me.MultipleEnquiryToolStripMenuItem.Name = "MultipleEnquiryToolStripMenuItem"
        Me.MultipleEnquiryToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.MultipleEnquiryToolStripMenuItem.Text = "&Multiple Query"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BankStatementToolStripMenuItem, Me.StandingOrdersToolStripMenuItem, Me.ReconciiationStatementToolStripMenuItem, Me.ToolStripSeparator2, Me.FinanceStatementToolStripMenuItem1, Me.ToolStripSeparator4, Me.ActualsVBudgetsToolStripMenuItem1})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.ReportToolStripMenuItem.Text = "&Reports"
        '
        'BankStatementToolStripMenuItem
        '
        Me.BankStatementToolStripMenuItem.Name = "BankStatementToolStripMenuItem"
        Me.BankStatementToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.BankStatementToolStripMenuItem.Text = "&Bank Statement"
        '
        'StandingOrdersToolStripMenuItem
        '
        Me.StandingOrdersToolStripMenuItem.Name = "StandingOrdersToolStripMenuItem"
        Me.StandingOrdersToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.StandingOrdersToolStripMenuItem.Text = "&Standing Orders"
        '
        'ReconciiationStatementToolStripMenuItem
        '
        Me.ReconciiationStatementToolStripMenuItem.Name = "ReconciiationStatementToolStripMenuItem"
        Me.ReconciiationStatementToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ReconciiationStatementToolStripMenuItem.Text = "&Reconciiation Statement"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(218, 6)
        '
        'FinanceStatementToolStripMenuItem1
        '
        Me.FinanceStatementToolStripMenuItem1.Name = "FinanceStatementToolStripMenuItem1"
        Me.FinanceStatementToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.FinanceStatementToolStripMenuItem1.Text = "&Finance Statement"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(218, 6)
        '
        'ActualsVBudgetsToolStripMenuItem1
        '
        Me.ActualsVBudgetsToolStripMenuItem1.Name = "ActualsVBudgetsToolStripMenuItem1"
        Me.ActualsVBudgetsToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.ActualsVBudgetsToolStripMenuItem1.Text = "&Actuals v Budgets"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccountNameToolStripMenuItem, Me.BankNameToolStripMenuItem, Me.CustomersToolStripMenuItem, Me.UserNamesToolStripMenuItem, Me.ToolStripSeparator13, Me.AnalysisCodesToolStripMenuItem, Me.GLCodesToolStripMenuItem, Me.BudgetsToolStripMenuItem1, Me.CurrenciesToolStripMenuItem, Me.ToolStripSeparator12, Me.ConcurrentSOsToolStripMenuItem, Me.ToolStripSeparator8, Me.ChangePasswordToolStripMenuItem, Me.PasswordsOnToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.SetupToolStripMenuItem.Text = "&Setup"
        '
        'AccountNameToolStripMenuItem
        '
        Me.AccountNameToolStripMenuItem.Name = "AccountNameToolStripMenuItem"
        Me.AccountNameToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.AccountNameToolStripMenuItem.Text = "&Account Names"
        '
        'BankNameToolStripMenuItem
        '
        Me.BankNameToolStripMenuItem.Name = "BankNameToolStripMenuItem"
        Me.BankNameToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.BankNameToolStripMenuItem.Text = "&Bank Names"
        '
        'CustomersToolStripMenuItem
        '
        Me.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem"
        Me.CustomersToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.CustomersToolStripMenuItem.Text = "&Customer Names"
        '
        'UserNamesToolStripMenuItem
        '
        Me.UserNamesToolStripMenuItem.Name = "UserNamesToolStripMenuItem"
        Me.UserNamesToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.UserNamesToolStripMenuItem.Text = "&User Names"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(274, 6)
        '
        'AnalysisCodesToolStripMenuItem
        '
        Me.AnalysisCodesToolStripMenuItem.Name = "AnalysisCodesToolStripMenuItem"
        Me.AnalysisCodesToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.AnalysisCodesToolStripMenuItem.Text = "&Analysis Codes"
        '
        'GLCodesToolStripMenuItem
        '
        Me.GLCodesToolStripMenuItem.Name = "GLCodesToolStripMenuItem"
        Me.GLCodesToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.GLCodesToolStripMenuItem.Text = "&General Ledger Codes"
        '
        'BudgetsToolStripMenuItem1
        '
        Me.BudgetsToolStripMenuItem1.Name = "BudgetsToolStripMenuItem1"
        Me.BudgetsToolStripMenuItem1.Size = New System.Drawing.Size(277, 22)
        Me.BudgetsToolStripMenuItem1.Text = "&Budgets"
        '
        'CurrenciesToolStripMenuItem
        '
        Me.CurrenciesToolStripMenuItem.Name = "CurrenciesToolStripMenuItem"
        Me.CurrenciesToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.CurrenciesToolStripMenuItem.Text = "&Currencies"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(274, 6)
        Me.ToolStripSeparator12.Visible = False
        '
        'ConcurrentSOsToolStripMenuItem
        '
        Me.ConcurrentSOsToolStripMenuItem.Name = "ConcurrentSOsToolStripMenuItem"
        Me.ConcurrentSOsToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ConcurrentSOsToolStripMenuItem.Text = "&Post SO's on all a/c's concurrently"
        Me.ConcurrentSOsToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(274, 6)
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "&Change Password"
        '
        'PasswordsOnToolStripMenuItem
        '
        Me.PasswordsOnToolStripMenuItem.Name = "PasswordsOnToolStripMenuItem"
        Me.PasswordsOnToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.PasswordsOnToolStripMenuItem.Text = "&Passwords On"
        Me.PasswordsOnToolStripMenuItem.Visible = False
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonslAccountingSystemToolStripMenuItem})
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.AccountsToolStripMenuItem.Text = "&Accounts"
        '
        'PersonslAccountingSystemToolStripMenuItem
        '
        Me.PersonslAccountingSystemToolStripMenuItem.Name = "PersonslAccountingSystemToolStripMenuItem"
        Me.PersonslAccountingSystemToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.PersonslAccountingSystemToolStripMenuItem.Text = "&Personal Accounting System"
        '
        'AccountsToolStripMenuItem1
        '
        Me.AccountsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutVisualPBSToolStripMenuItem})
        Me.AccountsToolStripMenuItem1.Name = "AccountsToolStripMenuItem1"
        Me.AccountsToolStripMenuItem1.Size = New System.Drawing.Size(49, 20)
        Me.AccountsToolStripMenuItem1.Text = "&Help"
        '
        'AboutVisualPBSToolStripMenuItem
        '
        Me.AboutVisualPBSToolStripMenuItem.Name = "AboutVisualPBSToolStripMenuItem"
        Me.AboutVisualPBSToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AboutVisualPBSToolStripMenuItem.Text = "&About Visual PBS"
        '
        'DataGridPbsTrans
        '
        Me.DataGridPbsTrans.AllowUserToAddRows = False
        Me.DataGridPbsTrans.AllowUserToDeleteRows = False
        Me.DataGridPbsTrans.AllowUserToResizeRows = False
        Me.DataGridPbsTrans.AutoGenerateColumns = False
        Me.DataGridPbsTrans.BackgroundColor = System.Drawing.Color.White
        Me.DataGridPbsTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridPbsTrans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.NullValue = Nothing
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPbsTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.DataGridPbsTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridPbsTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.ReferenceDataGridViewTextBoxColumn, Me.CustomerDataGridViewTextBoxColumn, Me.DetailsDataGridViewTextBoxColumn, Me.PaymentDataGridViewTextBoxColumn, Me.ReceiptDataGridViewTextBoxColumn, Me.BalanceDataGridViewTextBoxColumn1, Me.AnalysisDataGridViewTextBoxColumn, Me.AccountDataGridViewTextBoxColumn, Me.GlcodeDataGridViewTextBoxColumn, Me.FolioDataGridViewTextBoxColumn, Me.ReconciledDataGridViewTextBoxColumn, Me.VATDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.DebitCreditDataGridViewTextBoxColumn, Me.TimeKeyDataGridViewTextBoxColumn, Me.AccountNoDataGridViewTextBoxColumn1, Me.TransferDataGridViewTextBoxColumn, Me.TransferIDDataGridViewTextBoxColumn})
        Me.DataGridPbsTrans.DataSource = Me.PbstransBindingSource
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridPbsTrans.DefaultCellStyle = DataGridViewCellStyle39
        Me.DataGridPbsTrans.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridPbsTrans.Location = New System.Drawing.Point(12, 65)
        Me.DataGridPbsTrans.MultiSelect = False
        Me.DataGridPbsTrans.Name = "DataGridPbsTrans"
        Me.DataGridPbsTrans.ReadOnly = True
        Me.DataGridPbsTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridPbsTrans.Size = New System.Drawing.Size(781, 264)
        Me.DataGridPbsTrans.TabIndex = 13
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.Format = "dd-MMM-yy"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.DateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle34
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 80
        '
        'ReferenceDataGridViewTextBoxColumn
        '
        Me.ReferenceDataGridViewTextBoxColumn.DataPropertyName = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.HeaderText = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.Name = "ReferenceDataGridViewTextBoxColumn"
        Me.ReferenceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CustomerDataGridViewTextBoxColumn
        '
        Me.CustomerDataGridViewTextBoxColumn.DataPropertyName = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.Name = "CustomerDataGridViewTextBoxColumn"
        Me.CustomerDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DetailsDataGridViewTextBoxColumn
        '
        Me.DetailsDataGridViewTextBoxColumn.DataPropertyName = "Details"
        Me.DetailsDataGridViewTextBoxColumn.HeaderText = "Details"
        Me.DetailsDataGridViewTextBoxColumn.Name = "DetailsDataGridViewTextBoxColumn"
        Me.DetailsDataGridViewTextBoxColumn.ReadOnly = True
        Me.DetailsDataGridViewTextBoxColumn.Width = 140
        '
        'PaymentDataGridViewTextBoxColumn
        '
        Me.PaymentDataGridViewTextBoxColumn.DataPropertyName = "Payment"
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "N2"
        DataGridViewCellStyle35.NullValue = Nothing
        Me.PaymentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle35
        Me.PaymentDataGridViewTextBoxColumn.HeaderText = "Payment"
        Me.PaymentDataGridViewTextBoxColumn.Name = "PaymentDataGridViewTextBoxColumn"
        Me.PaymentDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaymentDataGridViewTextBoxColumn.Width = 80
        '
        'ReceiptDataGridViewTextBoxColumn
        '
        Me.ReceiptDataGridViewTextBoxColumn.DataPropertyName = "Receipt"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.Format = "N2"
        DataGridViewCellStyle36.NullValue = Nothing
        Me.ReceiptDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle36
        Me.ReceiptDataGridViewTextBoxColumn.HeaderText = "Receipt"
        Me.ReceiptDataGridViewTextBoxColumn.Name = "ReceiptDataGridViewTextBoxColumn"
        Me.ReceiptDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReceiptDataGridViewTextBoxColumn.Width = 80
        '
        'BalanceDataGridViewTextBoxColumn1
        '
        Me.BalanceDataGridViewTextBoxColumn1.DataPropertyName = "Balance"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.BalanceDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle37
        Me.BalanceDataGridViewTextBoxColumn1.HeaderText = "Balance"
        Me.BalanceDataGridViewTextBoxColumn1.Name = "BalanceDataGridViewTextBoxColumn1"
        Me.BalanceDataGridViewTextBoxColumn1.ReadOnly = True
        Me.BalanceDataGridViewTextBoxColumn1.Width = 80
        '
        'AnalysisDataGridViewTextBoxColumn
        '
        Me.AnalysisDataGridViewTextBoxColumn.DataPropertyName = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.HeaderText = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.Name = "AnalysisDataGridViewTextBoxColumn"
        Me.AnalysisDataGridViewTextBoxColumn.ReadOnly = True
        Me.AnalysisDataGridViewTextBoxColumn.Width = 80
        '
        'AccountDataGridViewTextBoxColumn
        '
        Me.AccountDataGridViewTextBoxColumn.DataPropertyName = "Account"
        Me.AccountDataGridViewTextBoxColumn.HeaderText = "Account"
        Me.AccountDataGridViewTextBoxColumn.Name = "AccountDataGridViewTextBoxColumn"
        Me.AccountDataGridViewTextBoxColumn.ReadOnly = True
        Me.AccountDataGridViewTextBoxColumn.Visible = False
        '
        'GlcodeDataGridViewTextBoxColumn
        '
        Me.GlcodeDataGridViewTextBoxColumn.DataPropertyName = "Glcode"
        Me.GlcodeDataGridViewTextBoxColumn.HeaderText = "Glcode"
        Me.GlcodeDataGridViewTextBoxColumn.Name = "GlcodeDataGridViewTextBoxColumn"
        Me.GlcodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FolioDataGridViewTextBoxColumn
        '
        Me.FolioDataGridViewTextBoxColumn.DataPropertyName = "Folio"
        Me.FolioDataGridViewTextBoxColumn.HeaderText = "Folio"
        Me.FolioDataGridViewTextBoxColumn.Name = "FolioDataGridViewTextBoxColumn"
        Me.FolioDataGridViewTextBoxColumn.ReadOnly = True
        Me.FolioDataGridViewTextBoxColumn.Visible = False
        '
        'ReconciledDataGridViewTextBoxColumn
        '
        Me.ReconciledDataGridViewTextBoxColumn.DataPropertyName = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.HeaderText = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.Name = "ReconciledDataGridViewTextBoxColumn"
        Me.ReconciledDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VATDataGridViewTextBoxColumn
        '
        Me.VATDataGridViewTextBoxColumn.DataPropertyName = "VAT"
        Me.VATDataGridViewTextBoxColumn.HeaderText = "Equiv."
        Me.VATDataGridViewTextBoxColumn.Name = "VATDataGridViewTextBoxColumn"
        Me.VATDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.AmountDataGridViewTextBoxColumn.Visible = False
        '
        'DebitCreditDataGridViewTextBoxColumn
        '
        Me.DebitCreditDataGridViewTextBoxColumn.DataPropertyName = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.HeaderText = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.Name = "DebitCreditDataGridViewTextBoxColumn"
        Me.DebitCreditDataGridViewTextBoxColumn.ReadOnly = True
        Me.DebitCreditDataGridViewTextBoxColumn.Visible = False
        '
        'TimeKeyDataGridViewTextBoxColumn
        '
        Me.TimeKeyDataGridViewTextBoxColumn.DataPropertyName = "TimeKey"
        DataGridViewCellStyle38.Format = "T"
        DataGridViewCellStyle38.NullValue = Nothing
        Me.TimeKeyDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle38
        Me.TimeKeyDataGridViewTextBoxColumn.HeaderText = "TimeKey"
        Me.TimeKeyDataGridViewTextBoxColumn.Name = "TimeKeyDataGridViewTextBoxColumn"
        Me.TimeKeyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AccountNoDataGridViewTextBoxColumn1
        '
        Me.AccountNoDataGridViewTextBoxColumn1.DataPropertyName = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn1.HeaderText = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn1.Name = "AccountNoDataGridViewTextBoxColumn1"
        Me.AccountNoDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'TransferDataGridViewTextBoxColumn
        '
        Me.TransferDataGridViewTextBoxColumn.DataPropertyName = "Transfer"
        Me.TransferDataGridViewTextBoxColumn.HeaderText = "Transfer"
        Me.TransferDataGridViewTextBoxColumn.Name = "TransferDataGridViewTextBoxColumn"
        Me.TransferDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TransferIDDataGridViewTextBoxColumn
        '
        Me.TransferIDDataGridViewTextBoxColumn.DataPropertyName = "TransferID"
        Me.TransferIDDataGridViewTextBoxColumn.HeaderText = "TransferID"
        Me.TransferIDDataGridViewTextBoxColumn.Name = "TransferIDDataGridViewTextBoxColumn"
        Me.TransferIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PbstransBindingSource
        '
        Me.PbstransBindingSource.DataMember = "pbstrans"
        Me.PbstransBindingSource.DataSource = Me.VPBSDataSet
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.CmdReport)
        Me.GroupBox1.Controls.Add(Me.CmdExit)
        Me.GroupBox1.Controls.Add(Me.CmdCancel)
        Me.GroupBox1.Controls.Add(Me.CmdFind)
        Me.GroupBox1.Controls.Add(Me.CmdDelete)
        Me.GroupBox1.Controls.Add(Me.CmdChange)
        Me.GroupBox1.Controls.Add(Me.CmdAdd)
        Me.GroupBox1.Controls.Add(Me.CmdSelect)
        Me.GroupBox1.Controls.Add(Me.CmdOk)
        Me.GroupBox1.Controls.Add(Me.CmdOkProj)
        Me.GroupBox1.Controls.Add(Me.CmdOkFind)
        Me.GroupBox1.Controls.Add(Me.CmdOkReport)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 521)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 66)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'CmdReport
        '
        Me.CmdReport.BackColor = System.Drawing.Color.LightGray
        Me.CmdReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReport.Location = New System.Drawing.Point(105, 19)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(80, 35)
        Me.CmdReport.TabIndex = 11
        Me.CmdReport.Text = "&Report"
        Me.CmdReport.UseVisualStyleBackColor = False
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.LightGray
        Me.CmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.Location = New System.Drawing.Point(683, 19)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(80, 35)
        Me.CmdExit.TabIndex = 7
        Me.CmdExit.Text = "&Exit VPBS"
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.LightGray
        Me.CmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.Location = New System.Drawing.Point(577, 19)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(80, 35)
        Me.CmdCancel.TabIndex = 6
        Me.CmdCancel.Text = "&Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdFind
        '
        Me.CmdFind.BackColor = System.Drawing.Color.LightGray
        Me.CmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFind.Location = New System.Drawing.Point(105, 19)
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Size = New System.Drawing.Size(80, 35)
        Me.CmdFind.TabIndex = 4
        Me.CmdFind.Text = "&Find"
        Me.CmdFind.UseVisualStyleBackColor = False
        '
        'CmdDelete
        '
        Me.CmdDelete.BackColor = System.Drawing.Color.LightGray
        Me.CmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDelete.Location = New System.Drawing.Point(383, 19)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(80, 35)
        Me.CmdDelete.TabIndex = 3
        Me.CmdDelete.Text = "&Delete"
        Me.CmdDelete.UseVisualStyleBackColor = False
        '
        'CmdChange
        '
        Me.CmdChange.BackColor = System.Drawing.Color.LightGray
        Me.CmdChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdChange.Location = New System.Drawing.Point(297, 19)
        Me.CmdChange.Name = "CmdChange"
        Me.CmdChange.Size = New System.Drawing.Size(80, 35)
        Me.CmdChange.TabIndex = 2
        Me.CmdChange.Text = "&Change"
        Me.CmdChange.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.LightGray
        Me.CmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.Location = New System.Drawing.Point(211, 19)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(80, 35)
        Me.CmdAdd.TabIndex = 1
        Me.CmdAdd.Text = "&Add"
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'CmdSelect
        '
        Me.CmdSelect.BackColor = System.Drawing.Color.LightGray
        Me.CmdSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSelect.Location = New System.Drawing.Point(19, 19)
        Me.CmdSelect.Name = "CmdSelect"
        Me.CmdSelect.Size = New System.Drawing.Size(80, 35)
        Me.CmdSelect.TabIndex = 0
        Me.CmdSelect.Text = "&Select a/c"
        Me.CmdSelect.UseVisualStyleBackColor = False
        '
        'CmdOk
        '
        Me.CmdOk.BackColor = System.Drawing.Color.LightGray
        Me.CmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOk.Location = New System.Drawing.Point(491, 19)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(80, 35)
        Me.CmdOk.TabIndex = 5
        Me.CmdOk.Text = "&Ok"
        Me.CmdOk.UseVisualStyleBackColor = False
        '
        'CmdOkProj
        '
        Me.CmdOkProj.BackColor = System.Drawing.Color.LightGray
        Me.CmdOkProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOkProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOkProj.Location = New System.Drawing.Point(491, 19)
        Me.CmdOkProj.Name = "CmdOkProj"
        Me.CmdOkProj.Size = New System.Drawing.Size(80, 35)
        Me.CmdOkProj.TabIndex = 10
        Me.CmdOkProj.Text = "&OkProj"
        Me.CmdOkProj.UseVisualStyleBackColor = False
        Me.CmdOkProj.Visible = False
        '
        'CmdOkFind
        '
        Me.CmdOkFind.BackColor = System.Drawing.Color.LightGray
        Me.CmdOkFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOkFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOkFind.Location = New System.Drawing.Point(491, 19)
        Me.CmdOkFind.Name = "CmdOkFind"
        Me.CmdOkFind.Size = New System.Drawing.Size(80, 35)
        Me.CmdOkFind.TabIndex = 8
        Me.CmdOkFind.Text = "&OkFind"
        Me.CmdOkFind.UseVisualStyleBackColor = False
        Me.CmdOkFind.Visible = False
        '
        'CmdOkReport
        '
        Me.CmdOkReport.BackColor = System.Drawing.Color.LightGray
        Me.CmdOkReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOkReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOkReport.Location = New System.Drawing.Point(491, 19)
        Me.CmdOkReport.Name = "CmdOkReport"
        Me.CmdOkReport.Size = New System.Drawing.Size(80, 35)
        Me.CmdOkReport.TabIndex = 12
        Me.CmdOkReport.Text = "&OkReport"
        Me.CmdOkReport.UseVisualStyleBackColor = False
        Me.CmdOkReport.Visible = False
        '
        'VpbsTestDataSet
        '
        Me.VpbsTestDataSet.DataSetName = "VPBSTestDataSet"
        Me.VpbsTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PbstransTableAdapterLive
        '
        Me.PbstransTableAdapterLive.ClearBeforeFill = True
        '
        'DirpbsTableAdapterLive
        '
        Me.DirpbsTableAdapterLive.ClearBeforeFill = True
        '
        'AnalysisTableAdapter
        '
        Me.AnalysisTableAdapter.ClearBeforeFill = True
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'GLCodeTableAdapter
        '
        Me.GLCodeTableAdapter.ClearBeforeFill = True
        '
        'VpbsArchiveDataSet
        '
        Me.VpbsArchiveDataSet.DataSetName = "VpbsArchiveDataSet"
        Me.VpbsArchiveDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PbstransTableAdapterTest
        '
        Me.PbstransTableAdapterTest.ClearBeforeFill = True
        '
        'DirpbsTableAdapterTest
        '
        Me.DirpbsTableAdapterTest.ClearBeforeFill = True
        '
        'AnalysisTableAdapterTest
        '
        Me.AnalysisTableAdapterTest.ClearBeforeFill = True
        '
        'GLCodeTableAdapterTest
        '
        Me.GLCodeTableAdapterTest.ClearBeforeFill = True
        '
        'CustomersTableAdapterTest
        '
        Me.CustomersTableAdapterTest.ClearBeforeFill = True
        '
        'DirpbsTableAdapterArc
        '
        Me.DirpbsTableAdapterArc.ClearBeforeFill = True
        '
        'PbstransTableAdapterArc
        '
        Me.PbstransTableAdapterArc.ClearBeforeFill = True
        '
        'AnalysisTableAdapterArc
        '
        Me.AnalysisTableAdapterArc.ClearBeforeFill = True
        '
        'GLCodeTableAdapterArc
        '
        Me.GLCodeTableAdapterArc.ClearBeforeFill = True
        '
        'CustomersTableAdapterArc
        '
        Me.CustomersTableAdapterArc.ClearBeforeFill = True
        '
        'TransTempATableAdapter1
        '
        Me.TransTempATableAdapter1.ClearBeforeFill = True
        '
        'PrintDialog2
        '
        Me.PrintDialog2.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'AxCrystalReport1
        '
        Me.AxCrystalReport1.Enabled = True
        Me.AxCrystalReport1.Location = New System.Drawing.Point(782, 332)
        Me.AxCrystalReport1.Name = "AxCrystalReport1"
        Me.AxCrystalReport1.OcxState = CType(resources.GetObject("AxCrystalReport1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxCrystalReport1.Size = New System.Drawing.Size(28, 28)
        Me.AxCrystalReport1.TabIndex = 19
        '
        'frmPbsTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(810, 597)
        Me.Controls.Add(Me.AxCrystalReport1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblAccountHeader)
        Me.Controls.Add(Me.DataGridDirPbs)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.DataGridPbsTrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Location = New System.Drawing.Point(300, 200)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmPbsTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visual Personal Banking System"
        CType(Me.DataGridDirPbs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLCodeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnalysisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridPbsTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbstransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents DataGridDirPbs As System.Windows.Forms.DataGridView


    Friend WithEvents VPBSDataSet As VPBS13.VPBSDataSet
    Friend WithEvents PbstransTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents DirpbsTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents lblAccountHeader As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPayReceipt As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboAnalysis As System.Windows.Forms.ComboBox
    Friend WithEvents cboReference As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents txtEquiv As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTransfer As System.Windows.Forms.ComboBox
    Friend WithEvents AnalysisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AnalysisTableAdapter As VPBS13.VPBSDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As VPBS13.VPBSDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents GLCodeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLCodeTableAdapter As VPBS13.VPBSDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents DirpbsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAcToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewAccountDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeAccountDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ArchiveTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrinterSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoStandingOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualStandingOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconciliationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BudgetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FirstTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoStandingOrdersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualStandingOrdersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconciliationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ForwardProjectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinanceStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActualsVBudgetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GLcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AmountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultipleEnquiryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandingOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconciiationStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FinanceStatementToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActualsVBudgetsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConcurrentSOsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CurrenciesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UserNamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalysisCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GLCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonslAccountingSystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutVisualPBSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshBalancesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTimeKey As System.Windows.Forms.TextBox
    Friend WithEvents AccountNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountDescDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankBranchDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceEquivalentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OdLimitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PbstransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VpbsTestDataSet As VPBS13.VPBSTestDataSet
    Friend WithEvents PbstransTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents DirpbsTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents AnalysisTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents GLCodeTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents CustomersTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents txtDateFind As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProjBalance As System.Windows.Forms.TextBox
    Friend WithEvents ProjDateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridPbsTrans As System.Windows.Forms.DataGridView
    Friend WithEvents FindToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AxCrystalReport1 As AxCrystal.AxCrystalReport
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdFind As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdChange As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdSelect As System.Windows.Forms.Button
    Friend WithEvents CmdOkProj As System.Windows.Forms.Button
    Friend WithEvents CmdOkFind As System.Windows.Forms.Button
    Friend WithEvents CmdOkReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoOption11 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOption9 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOption10 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoOption3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGroup3 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboGroup3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BankNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTransferID As System.Windows.Forms.TextBox
    Friend WithEvents PasswordsOnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VpbsArchiveDataSet As VPBS13.VpbsArchiveDataSet
    Friend WithEvents DirpbsTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents PbstransTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents AnalysisTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents GLCodeTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents CustomersTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents TransTempATableAdapter1 As VPBS13.VPBSDataSet1TableAdapters.TransTempATableAdapter
    Friend WithEvents ImportBankStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImportBankStatementDevToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDialog2 As PrintDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DetailsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PaymentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BalanceDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents AnalysisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AccountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GlcodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FolioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReconciledDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VATDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DebitCreditDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimeKeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AccountNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TransferDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TransferIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    'Friend WithEvents AxCrystalReport1 As AxCrystal.AxCrystalReport
    'Friend WithEvents DataSet11 As VPBS13.DataSet1


End Class
