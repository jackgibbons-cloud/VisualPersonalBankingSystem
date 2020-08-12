<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSOTrans
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSOTrans))
        Me.DataGridSOTrans = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnalysisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GlcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReconciledDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VATDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitCreditDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonthlyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumPaymentsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayDueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SotransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VpbsArchiveDataSet = New VPBS13.VpbsArchiveDataSet()
        Me.VPBSTestDataSet = New VPBS13.VPBSTestDataSet()
        Me.VPBSDataSet = New VPBS13.VPBSDataSet()
        Me.SotransTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.sotransTableAdapter()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdReportOk = New System.Windows.Forms.Button()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdChange = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.lblAccountHeader = New System.Windows.Forms.Label()
        Me.AxCrystalReport1 = New AxCrystal.AxCrystalReport()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtNumPayments = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDayDue = New System.Windows.Forms.TextBox()
        Me.txtMonthly = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDaily = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboGroup3 = New System.Windows.Forms.ComboBox()
        Me.cboGroup2 = New System.Windows.Forms.ComboBox()
        Me.cboGroup1 = New System.Windows.Forms.ComboBox()
        Me.txtGroup3 = New System.Windows.Forms.TextBox()
        Me.txtGroup2 = New System.Windows.Forms.TextBox()
        Me.txtGroup1 = New System.Windows.Forms.TextBox()
        Me.txtDetailFrequency = New System.Windows.Forms.TextBox()
        Me.txtDetailAmount = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.AnalysisTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.AnalysisTableAdapter()
        Me.GLCodeTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.GLCodeTableAdapter()
        Me.CustomersTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.CustomersTableAdapter()
        Me.DirpbsTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter()
        Me.SotransTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.sotransTableAdapter()
        Me.AnalysisTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.AnalysisTableAdapter()
        Me.GLCodeTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.GLCodeTableAdapter()
        Me.CustomersTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.CustomersTableAdapter()
        Me.DirpbsTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter()
        Me.DirpbsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SotransTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.sotransTableAdapter()
        Me.DirpbsTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter()
        Me.CustomersTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.CustomersTableAdapter()
        Me.AnalysisTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.AnalysisTableAdapter()
        Me.GLCodeTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.GLCodeTableAdapter()
        CType(Me.DataGridSOTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SotransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLCodeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnalysisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridSOTrans
        '
        Me.DataGridSOTrans.AllowUserToDeleteRows = False
        Me.DataGridSOTrans.AllowUserToResizeRows = False
        Me.DataGridSOTrans.AutoGenerateColumns = False
        Me.DataGridSOTrans.BackgroundColor = System.Drawing.Color.AntiqueWhite
        Me.DataGridSOTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridSOTrans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridSOTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridSOTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridSOTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.ReferenceDataGridViewTextBoxColumn, Me.CustomerDataGridViewTextBoxColumn, Me.DetailsDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.AnalysisDataGridViewTextBoxColumn, Me.AccountDataGridViewTextBoxColumn, Me.GlcodeDataGridViewTextBoxColumn, Me.FolioDataGridViewTextBoxColumn, Me.ReconciledDataGridViewTextBoxColumn, Me.VATDataGridViewTextBoxColumn, Me.DebitCreditDataGridViewTextBoxColumn, Me.TimeKeyDataGridViewTextBoxColumn, Me.AccountNoDataGridViewTextBoxColumn, Me.TransferDataGridViewTextBoxColumn, Me.MonthlyDataGridViewTextBoxColumn, Me.DailyDataGridViewTextBoxColumn, Me.NumPaymentsDataGridViewTextBoxColumn, Me.DayDueDataGridViewTextBoxColumn})
        Me.DataGridSOTrans.DataSource = Me.SotransBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridSOTrans.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridSOTrans.Location = New System.Drawing.Point(13, 37)
        Me.DataGridSOTrans.Name = "DataGridSOTrans"
        Me.DataGridSOTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridSOTrans.Size = New System.Drawing.Size(781, 244)
        Me.DataGridSOTrans.TabIndex = 0
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        '
        'ReferenceDataGridViewTextBoxColumn
        '
        Me.ReferenceDataGridViewTextBoxColumn.DataPropertyName = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.HeaderText = "Reference"
        Me.ReferenceDataGridViewTextBoxColumn.Name = "ReferenceDataGridViewTextBoxColumn"
        '
        'CustomerDataGridViewTextBoxColumn
        '
        Me.CustomerDataGridViewTextBoxColumn.DataPropertyName = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.CustomerDataGridViewTextBoxColumn.Name = "CustomerDataGridViewTextBoxColumn"
        '
        'DetailsDataGridViewTextBoxColumn
        '
        Me.DetailsDataGridViewTextBoxColumn.DataPropertyName = "Details"
        Me.DetailsDataGridViewTextBoxColumn.HeaderText = "Details"
        Me.DetailsDataGridViewTextBoxColumn.Name = "DetailsDataGridViewTextBoxColumn"
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.AmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        '
        'AnalysisDataGridViewTextBoxColumn
        '
        Me.AnalysisDataGridViewTextBoxColumn.DataPropertyName = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.HeaderText = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.Name = "AnalysisDataGridViewTextBoxColumn"
        '
        'AccountDataGridViewTextBoxColumn
        '
        Me.AccountDataGridViewTextBoxColumn.DataPropertyName = "Account"
        Me.AccountDataGridViewTextBoxColumn.HeaderText = "Account"
        Me.AccountDataGridViewTextBoxColumn.Name = "AccountDataGridViewTextBoxColumn"
        Me.AccountDataGridViewTextBoxColumn.Visible = False
        '
        'GlcodeDataGridViewTextBoxColumn
        '
        Me.GlcodeDataGridViewTextBoxColumn.DataPropertyName = "Glcode"
        Me.GlcodeDataGridViewTextBoxColumn.HeaderText = "Glcode"
        Me.GlcodeDataGridViewTextBoxColumn.Name = "GlcodeDataGridViewTextBoxColumn"
        '
        'FolioDataGridViewTextBoxColumn
        '
        Me.FolioDataGridViewTextBoxColumn.DataPropertyName = "Folio"
        Me.FolioDataGridViewTextBoxColumn.HeaderText = "Folio"
        Me.FolioDataGridViewTextBoxColumn.Name = "FolioDataGridViewTextBoxColumn"
        Me.FolioDataGridViewTextBoxColumn.Visible = False
        '
        'ReconciledDataGridViewTextBoxColumn
        '
        Me.ReconciledDataGridViewTextBoxColumn.DataPropertyName = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.HeaderText = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.Name = "ReconciledDataGridViewTextBoxColumn"
        '
        'VATDataGridViewTextBoxColumn
        '
        Me.VATDataGridViewTextBoxColumn.DataPropertyName = "VAT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.VATDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.VATDataGridViewTextBoxColumn.HeaderText = "Equiv."
        Me.VATDataGridViewTextBoxColumn.Name = "VATDataGridViewTextBoxColumn"
        '
        'DebitCreditDataGridViewTextBoxColumn
        '
        Me.DebitCreditDataGridViewTextBoxColumn.DataPropertyName = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.HeaderText = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.Name = "DebitCreditDataGridViewTextBoxColumn"
        '
        'TimeKeyDataGridViewTextBoxColumn
        '
        Me.TimeKeyDataGridViewTextBoxColumn.DataPropertyName = "TimeKey"
        Me.TimeKeyDataGridViewTextBoxColumn.HeaderText = "TimeKey"
        Me.TimeKeyDataGridViewTextBoxColumn.Name = "TimeKeyDataGridViewTextBoxColumn"
        '
        'AccountNoDataGridViewTextBoxColumn
        '
        Me.AccountNoDataGridViewTextBoxColumn.DataPropertyName = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.HeaderText = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.Name = "AccountNoDataGridViewTextBoxColumn"
        '
        'TransferDataGridViewTextBoxColumn
        '
        Me.TransferDataGridViewTextBoxColumn.DataPropertyName = "Transfer"
        Me.TransferDataGridViewTextBoxColumn.HeaderText = "Transfer"
        Me.TransferDataGridViewTextBoxColumn.Name = "TransferDataGridViewTextBoxColumn"
        '
        'MonthlyDataGridViewTextBoxColumn
        '
        Me.MonthlyDataGridViewTextBoxColumn.DataPropertyName = "Monthly"
        Me.MonthlyDataGridViewTextBoxColumn.HeaderText = "Monthly"
        Me.MonthlyDataGridViewTextBoxColumn.Name = "MonthlyDataGridViewTextBoxColumn"
        '
        'DailyDataGridViewTextBoxColumn
        '
        Me.DailyDataGridViewTextBoxColumn.DataPropertyName = "Daily"
        Me.DailyDataGridViewTextBoxColumn.HeaderText = "Daily"
        Me.DailyDataGridViewTextBoxColumn.Name = "DailyDataGridViewTextBoxColumn"
        '
        'NumPaymentsDataGridViewTextBoxColumn
        '
        Me.NumPaymentsDataGridViewTextBoxColumn.DataPropertyName = "NumPayments"
        Me.NumPaymentsDataGridViewTextBoxColumn.HeaderText = "NumPayments"
        Me.NumPaymentsDataGridViewTextBoxColumn.Name = "NumPaymentsDataGridViewTextBoxColumn"
        '
        'DayDueDataGridViewTextBoxColumn
        '
        Me.DayDueDataGridViewTextBoxColumn.DataPropertyName = "DayDue"
        Me.DayDueDataGridViewTextBoxColumn.HeaderText = "DayDue"
        Me.DayDueDataGridViewTextBoxColumn.Name = "DayDueDataGridViewTextBoxColumn"
        '
        'SotransBindingSource
        '
        Me.SotransBindingSource.DataMember = "sotrans"
        Me.SotransBindingSource.DataSource = Me.VpbsArchiveDataSet
        '
        'VpbsArchiveDataSet
        '
        Me.VpbsArchiveDataSet.DataSetName = "VpbsArchiveDataSet"
        Me.VpbsArchiveDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VPBSTestDataSet
        '
        Me.VPBSTestDataSet.DataSetName = "VPBSTestDataSet"
        Me.VPBSTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VPBSDataSet
        '
        Me.VPBSDataSet.DataSetName = "VPBSDataSet"
        Me.VPBSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SotransTableAdapterTest
        '
        Me.SotransTableAdapterTest.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdReportOk)
        Me.GroupBox1.Controls.Add(Me.CmdReport)
        Me.GroupBox1.Controls.Add(Me.CmdClose)
        Me.GroupBox1.Controls.Add(Me.CmdCancel)
        Me.GroupBox1.Controls.Add(Me.CmdOk)
        Me.GroupBox1.Controls.Add(Me.CmdDelete)
        Me.GroupBox1.Controls.Add(Me.CmdChange)
        Me.GroupBox1.Controls.Add(Me.CmdAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 494)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 66)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CmdReportOk
        '
        Me.CmdReportOk.BackColor = System.Drawing.Color.LightGray
        Me.CmdReportOk.Enabled = False
        Me.CmdReportOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReportOk.Location = New System.Drawing.Point(395, 19)
        Me.CmdReportOk.Name = "CmdReportOk"
        Me.CmdReportOk.Size = New System.Drawing.Size(80, 35)
        Me.CmdReportOk.TabIndex = 23
        Me.CmdReportOk.Text = "&OkRpt"
        Me.CmdReportOk.UseVisualStyleBackColor = False
        Me.CmdReportOk.Visible = False
        '
        'CmdReport
        '
        Me.CmdReport.BackColor = System.Drawing.Color.LightGray
        Me.CmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReport.Location = New System.Drawing.Point(17, 19)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(80, 35)
        Me.CmdReport.TabIndex = 22
        Me.CmdReport.Text = "&Report"
        Me.CmdReport.UseVisualStyleBackColor = False
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.Color.LightGray
        Me.CmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.Location = New System.Drawing.Point(677, 19)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(80, 35)
        Me.CmdClose.TabIndex = 21
        Me.CmdClose.Text = "&Close"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.LightGray
        Me.CmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.Location = New System.Drawing.Point(568, 19)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(80, 35)
        Me.CmdCancel.TabIndex = 20
        Me.CmdCancel.Text = "&Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdOk
        '
        Me.CmdOk.BackColor = System.Drawing.Color.LightGray
        Me.CmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOk.Location = New System.Drawing.Point(482, 19)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(80, 35)
        Me.CmdOk.TabIndex = 19
        Me.CmdOk.Text = "&Ok"
        Me.CmdOk.UseVisualStyleBackColor = False
        '
        'CmdDelete
        '
        Me.CmdDelete.BackColor = System.Drawing.Color.LightGray
        Me.CmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDelete.Location = New System.Drawing.Point(295, 19)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(80, 35)
        Me.CmdDelete.TabIndex = 18
        Me.CmdDelete.Text = "&Delete"
        Me.CmdDelete.UseVisualStyleBackColor = False
        '
        'CmdChange
        '
        Me.CmdChange.BackColor = System.Drawing.Color.LightGray
        Me.CmdChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdChange.Location = New System.Drawing.Point(209, 19)
        Me.CmdChange.Name = "CmdChange"
        Me.CmdChange.Size = New System.Drawing.Size(80, 35)
        Me.CmdChange.TabIndex = 17
        Me.CmdChange.Text = "&Change"
        Me.CmdChange.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.LightGray
        Me.CmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.Location = New System.Drawing.Point(123, 19)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(80, 35)
        Me.CmdAdd.TabIndex = 16
        Me.CmdAdd.Text = "&Add"
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'lblAccountHeader
        '
        Me.lblAccountHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAccountHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccountHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountHeader.Location = New System.Drawing.Point(12, 7)
        Me.lblAccountHeader.Name = "lblAccountHeader"
        Me.lblAccountHeader.Size = New System.Drawing.Size(782, 27)
        Me.lblAccountHeader.TabIndex = 2
        Me.lblAccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAccountHeader.UseMnemonic = False
        '
        'AxCrystalReport1
        '
        Me.AxCrystalReport1.Enabled = True
        Me.AxCrystalReport1.Location = New System.Drawing.Point(20, 45)
        Me.AxCrystalReport1.Name = "AxCrystalReport1"
        Me.AxCrystalReport1.OcxState = CType(resources.GetObject("AxCrystalReport1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxCrystalReport1.Size = New System.Drawing.Size(28, 28)
        Me.AxCrystalReport1.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(781, 201)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Changing Current Transaction"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtNumPayments)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtDayDue)
        Me.GroupBox3.Controls.Add(Me.txtMonthly)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtDaily)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 145)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 50)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Frequency"
        '
        'txtNumPayments
        '
        Me.txtNumPayments.Location = New System.Drawing.Point(654, 18)
        Me.txtNumPayments.Multiline = True
        Me.txtNumPayments.Name = "txtNumPayments"
        Me.txtNumPayments.Size = New System.Drawing.Size(50, 24)
        Me.txtNumPayments.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Silver
        Me.Label20.Location = New System.Drawing.Point(547, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(101, 24)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "No. of Pymnts"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDayDue
        '
        Me.txtDayDue.Location = New System.Drawing.Point(481, 18)
        Me.txtDayDue.Multiline = True
        Me.txtDayDue.Name = "txtDayDue"
        Me.txtDayDue.Size = New System.Drawing.Size(50, 24)
        Me.txtDayDue.TabIndex = 14
        '
        'txtMonthly
        '
        Me.txtMonthly.Location = New System.Drawing.Point(303, 18)
        Me.txtMonthly.Multiline = True
        Me.txtMonthly.Name = "txtMonthly"
        Me.txtMonthly.Size = New System.Drawing.Size(50, 24)
        Me.txtMonthly.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Silver
        Me.Label19.Location = New System.Drawing.Point(222, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 25)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Monthly"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDaily
        '
        Me.txtDaily.Location = New System.Drawing.Point(118, 18)
        Me.txtDaily.Multiline = True
        Me.txtDaily.Name = "txtDaily"
        Me.txtDaily.Size = New System.Drawing.Size(50, 24)
        Me.txtDaily.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Silver
        Me.Label18.Location = New System.Drawing.Point(6, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 24)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Daily"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Silver
        Me.Label15.Location = New System.Drawing.Point(410, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 24)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "DayDue"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboTransfer.TabIndex = 2
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
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(410, 110)
        Me.txtRec.Multiline = True
        Me.txtRec.Name = "txtRec"
        Me.txtRec.Size = New System.Drawing.Size(65, 24)
        Me.txtRec.TabIndex = 10
        '
        'txtEquiv
        '
        Me.txtEquiv.Location = New System.Drawing.Point(654, 110)
        Me.txtEquiv.Multiline = True
        Me.txtEquiv.Name = "txtEquiv"
        Me.txtEquiv.Size = New System.Drawing.Size(121, 24)
        Me.txtEquiv.TabIndex = 11
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(654, 80)
        Me.txtAmount.Multiline = True
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(121, 24)
        Me.txtAmount.TabIndex = 8
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
        Me.cboPayReceipt.TabIndex = 7
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
        Me.txtDetails.Size = New System.Drawing.Size(169, 36)
        Me.txtDetails.TabIndex = 9
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
        Me.cboCustomer.TabIndex = 6
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
        Me.cboGLcode.TabIndex = 5
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
        Me.cboAnalysis.TabIndex = 4
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
        Me.cboReference.TabIndex = 3
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
        Me.txtDateFind.Location = New System.Drawing.Point(118, 22)
        Me.txtDateFind.Multiline = True
        Me.txtDateFind.Name = "txtDateFind"
        Me.txtDateFind.Size = New System.Drawing.Size(169, 24)
        Me.txtDateFind.TabIndex = 26
        Me.txtDateFind.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cboGroup3)
        Me.GroupBox4.Controls.Add(Me.cboGroup2)
        Me.GroupBox4.Controls.Add(Me.cboGroup1)
        Me.GroupBox4.Controls.Add(Me.txtGroup3)
        Me.GroupBox4.Controls.Add(Me.txtGroup2)
        Me.GroupBox4.Controls.Add(Me.txtGroup1)
        Me.GroupBox4.Controls.Add(Me.txtDetailFrequency)
        Me.GroupBox4.Controls.Add(Me.txtDetailAmount)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 287)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(780, 128)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report Detail Section"
        Me.GroupBox4.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(32, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(710, 16)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Includes repeating records in main body of report - decide which fields you want " &
    "to include in report. then click on OkRpt."
        '
        'cboGroup3
        '
        Me.cboGroup3.FormattingEnabled = True
        Me.cboGroup3.Items.AddRange(New Object() {"3"})
        Me.cboGroup3.Location = New System.Drawing.Point(410, 58)
        Me.cboGroup3.Name = "cboGroup3"
        Me.cboGroup3.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup3.TabIndex = 8
        '
        'cboGroup2
        '
        Me.cboGroup2.FormattingEnabled = True
        Me.cboGroup2.Items.AddRange(New Object() {"2"})
        Me.cboGroup2.Location = New System.Drawing.Point(272, 58)
        Me.cboGroup2.Name = "cboGroup2"
        Me.cboGroup2.Size = New System.Drawing.Size(122, 24)
        Me.cboGroup2.TabIndex = 7
        '
        'cboGroup1
        '
        Me.cboGroup1.FormattingEnabled = True
        Me.cboGroup1.Location = New System.Drawing.Point(133, 58)
        Me.cboGroup1.Name = "cboGroup1"
        Me.cboGroup1.Size = New System.Drawing.Size(122, 24)
        Me.cboGroup1.TabIndex = 6
        '
        'txtGroup3
        '
        Me.txtGroup3.Location = New System.Drawing.Point(410, 88)
        Me.txtGroup3.Name = "txtGroup3"
        Me.txtGroup3.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup3.TabIndex = 5
        Me.txtGroup3.Text = "txtGroup3"
        '
        'txtGroup2
        '
        Me.txtGroup2.Location = New System.Drawing.Point(272, 88)
        Me.txtGroup2.Name = "txtGroup2"
        Me.txtGroup2.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup2.TabIndex = 4
        Me.txtGroup2.Text = "txtGroup2"
        '
        'txtGroup1
        '
        Me.txtGroup1.Location = New System.Drawing.Point(133, 88)
        Me.txtGroup1.Name = "txtGroup1"
        Me.txtGroup1.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup1.TabIndex = 3
        Me.txtGroup1.Text = "txtGroup"
        '
        'txtDetailFrequency
        '
        Me.txtDetailFrequency.Location = New System.Drawing.Point(654, 58)
        Me.txtDetailFrequency.Name = "txtDetailFrequency"
        Me.txtDetailFrequency.Size = New System.Drawing.Size(73, 22)
        Me.txtDetailFrequency.TabIndex = 2
        Me.txtDetailFrequency.Text = "Frequency"
        '
        'txtDetailAmount
        '
        Me.txtDetailAmount.Location = New System.Drawing.Point(563, 58)
        Me.txtDetailAmount.Name = "txtDetailAmount"
        Me.txtDetailAmount.Size = New System.Drawing.Size(62, 22)
        Me.txtDetailAmount.TabIndex = 1
        Me.txtDetailAmount.Text = "Amount"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(35, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 22)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Date"
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
        'DirpbsTableAdapterTest
        '
        Me.DirpbsTableAdapterTest.ClearBeforeFill = True
        '
        'SotransTableAdapterLive
        '
        Me.SotransTableAdapterLive.ClearBeforeFill = True
        '
        'AnalysisTableAdapterLive
        '
        Me.AnalysisTableAdapterLive.ClearBeforeFill = True
        '
        'GLCodeTableAdapterLive
        '
        Me.GLCodeTableAdapterLive.ClearBeforeFill = True
        '
        'CustomersTableAdapterLive
        '
        Me.CustomersTableAdapterLive.ClearBeforeFill = True
        '
        'DirpbsTableAdapterLive
        '
        Me.DirpbsTableAdapterLive.ClearBeforeFill = True
        '
        'DirpbsBindingSource
        '
        Me.DirpbsBindingSource.DataMember = "dirpbs"
        Me.DirpbsBindingSource.DataSource = Me.VPBSDataSet
        '
        'SotransTableAdapterArc
        '
        Me.SotransTableAdapterArc.ClearBeforeFill = True
        '
        'DirpbsTableAdapterArc
        '
        Me.DirpbsTableAdapterArc.ClearBeforeFill = True
        '
        'CustomersTableAdapterArc
        '
        Me.CustomersTableAdapterArc.ClearBeforeFill = True
        '
        'AnalysisTableAdapterArc
        '
        Me.AnalysisTableAdapterArc.ClearBeforeFill = True
        '
        'GLCodeTableAdapterArc
        '
        Me.GLCodeTableAdapterArc.ClearBeforeFill = True
        '
        'frmSOTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(804, 572)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.AxCrystalReport1)
        Me.Controls.Add(Me.lblAccountHeader)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridSOTrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSOTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VPBS - STANDING ORDERS and DIRECT DEBITS "
        CType(Me.DataGridSOTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SotransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLCodeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnalysisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridSOTrans As System.Windows.Forms.DataGridView
    Friend WithEvents VPBSTestDataSet As VPBS13.VPBSTestDataSet
    Friend WithEvents SotransTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.sotransTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents lblAccountHeader As System.Windows.Forms.Label
    Friend WithEvents CmdClose As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdChange As System.Windows.Forms.Button
    Friend WithEvents AxCrystalReport1 As AxCrystal.AxCrystalReport
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumPayments As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDayDue As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthly As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDaily As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTimeKey As System.Windows.Forms.TextBox
    Friend WithEvents cboTransfer As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents txtEquiv As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPayReceipt As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboAnalysis As System.Windows.Forms.ComboBox
    Friend WithEvents cboReference As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateFind As System.Windows.Forms.TextBox
    Friend WithEvents CmdReportOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboGroup3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtGroup3 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDetailFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtDetailAmount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents AnalysisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AnalysisTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents GLCodeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLCodeTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents DirpbsTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents VPBSDataSet As VPBS13.VPBSDataSet
    Friend WithEvents SotransTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.sotransTableAdapter
    Friend WithEvents AnalysisTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents GLCodeTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents CustomersTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents DirpbsTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents SotransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DirpbsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VpbsArchiveDataSet As VPBS13.VpbsArchiveDataSet
    Friend WithEvents SotransTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.sotransTableAdapter
    Friend WithEvents DirpbsTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents CustomersTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents AnalysisTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.AnalysisTableAdapter
    Friend WithEvents GLCodeTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.GLCodeTableAdapter
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnalysisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GlcodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FolioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReconciledDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VATDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitCreditDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthlyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumPaymentsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayDueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
