<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankRec
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankRec))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblAccountHeader = New System.Windows.Forms.Label()
        Me.DataGridPbsTrans = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnalysisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GlcodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReconciledDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitCreditDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VATDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PbstransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VpbsDataSet = New VPBS13.VPBSDataSet()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdReport = New System.Windows.Forms.Button()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.CmdAutoRec = New System.Windows.Forms.Button()
        Me.CmdNext = New System.Windows.Forms.Button()
        Me.CmdUndo = New System.Windows.Forms.Button()
        Me.CmdPrevious = New System.Windows.Forms.Button()
        Me.CmdAccept = New System.Windows.Forms.Button()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdOkReport = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtGroup4 = New System.Windows.Forms.TextBox()
        Me.cboGroup4 = New System.Windows.Forms.ComboBox()
        Me.cboGroup3 = New System.Windows.Forms.ComboBox()
        Me.cboGroup2 = New System.Windows.Forms.ComboBox()
        Me.cboGroup1 = New System.Windows.Forms.ComboBox()
        Me.txtGroup3 = New System.Windows.Forms.TextBox()
        Me.txtGroup2 = New System.Windows.Forms.TextBox()
        Me.txtGroup1 = New System.Windows.Forms.TextBox()
        Me.txtDetailAmount = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblAdjBankBal = New System.Windows.Forms.Label()
        Me.lblCurrentPBSBal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCurrentBankBal = New System.Windows.Forms.TextBox()
        Me.AxCrystalReport1 = New AxCrystal.AxCrystalReport()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtCurrentPBSBal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridBankTrans = New System.Windows.Forms.DataGridView()
        Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DebitAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reconciled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SortCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecTransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VPBSDataSet9 = New VPBS13.VPBSDataSet9()
        Me.VpbsTestDataSet = New VPBS13.VPBSTestDataSet()
        Me.PbstransTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.pbstransTableAdapter()
        Me.PbstransTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.pbstransTableAdapter()
        Me.VpbsArchiveDataSet = New VPBS13.VpbsArchiveDataSet()
        Me.PbstransTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.pbstransTableAdapter()
        Me.VpbsTestDataSet1 = New VPBS13.VPBSTestDataSet1()
        Me.RecTransTableAdapterTest = New VPBS13.VPBSTestDataSet1TableAdapters.RecTransTableAdapter()
        Me.VpbsArchiveDataSet4 = New VPBS13.VpbsArchiveDataSet4()
        Me.RecTransTableAdapterArc = New VPBS13.VpbsArchiveDataSet4TableAdapters.RecTransTableAdapter()
        Me.RecTransTableAdapterLive = New VPBS13.VPBSDataSet9TableAdapters.RecTransTableAdapter()
        Me.txtnPbsDebitAmount = New System.Windows.Forms.TextBox()
        Me.txtnPbsCreditAmount = New System.Windows.Forms.TextBox()
        Me.txtPayReceipt = New System.Windows.Forms.TextBox()
        Me.txtdDateKey = New System.Windows.Forms.TextBox()
        Me.txtdTimeKey = New System.Windows.Forms.TextBox()
        Me.txtsPbsCustomer = New System.Windows.Forms.TextBox()
        CType(Me.DataGridPbsTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbstransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DataGridBankTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecTransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSDataSet9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsTestDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsArchiveDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAccountHeader
        '
        Me.lblAccountHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAccountHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccountHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountHeader.Location = New System.Drawing.Point(12, 9)
        Me.lblAccountHeader.Name = "lblAccountHeader"
        Me.lblAccountHeader.Size = New System.Drawing.Size(800, 27)
        Me.lblAccountHeader.TabIndex = 27
        Me.lblAccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAccountHeader.UseMnemonic = False
        '
        'DataGridPbsTrans
        '
        Me.DataGridPbsTrans.AllowUserToOrderColumns = True
        Me.DataGridPbsTrans.AutoGenerateColumns = False
        Me.DataGridPbsTrans.BackgroundColor = System.Drawing.Color.AntiqueWhite
        Me.DataGridPbsTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPbsTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridPbsTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridPbsTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.ReferenceDataGridViewTextBoxColumn, Me.CustomerDataGridViewTextBoxColumn, Me.DetailsDataGridViewTextBoxColumn, Me.AnalysisDataGridViewTextBoxColumn, Me.AccountDataGridViewTextBoxColumn, Me.GlcodeDataGridViewTextBoxColumn, Me.FolioDataGridViewTextBoxColumn, Me.PaymentDataGridViewTextBoxColumn, Me.ReceiptDataGridViewTextBoxColumn, Me.ReconciledDataGridViewTextBoxColumn, Me.DebitCreditDataGridViewTextBoxColumn, Me.VATDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.BalanceDataGridViewTextBoxColumn, Me.TimeKeyDataGridViewTextBoxColumn, Me.AccountNoDataGridViewTextBoxColumn, Me.TransferDataGridViewTextBoxColumn, Me.TransferIDDataGridViewTextBoxColumn})
        Me.DataGridPbsTrans.DataSource = Me.PbstransBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridPbsTrans.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridPbsTrans.Location = New System.Drawing.Point(12, 70)
        Me.DataGridPbsTrans.Name = "DataGridPbsTrans"
        Me.DataGridPbsTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridPbsTrans.Size = New System.Drawing.Size(800, 153)
        Me.DataGridPbsTrans.TabIndex = 28
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        DataGridViewCellStyle2.Format = "dd-MMM-yy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.CustomerDataGridViewTextBoxColumn.Width = 120
        '
        'DetailsDataGridViewTextBoxColumn
        '
        Me.DetailsDataGridViewTextBoxColumn.DataPropertyName = "Details"
        Me.DetailsDataGridViewTextBoxColumn.HeaderText = "Details"
        Me.DetailsDataGridViewTextBoxColumn.Name = "DetailsDataGridViewTextBoxColumn"
        Me.DetailsDataGridViewTextBoxColumn.ReadOnly = True
        Me.DetailsDataGridViewTextBoxColumn.Width = 130
        '
        'AnalysisDataGridViewTextBoxColumn
        '
        Me.AnalysisDataGridViewTextBoxColumn.DataPropertyName = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.HeaderText = "Analysis"
        Me.AnalysisDataGridViewTextBoxColumn.Name = "AnalysisDataGridViewTextBoxColumn"
        Me.AnalysisDataGridViewTextBoxColumn.ReadOnly = True
        Me.AnalysisDataGridViewTextBoxColumn.Visible = False
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
        Me.GlcodeDataGridViewTextBoxColumn.Visible = False
        '
        'FolioDataGridViewTextBoxColumn
        '
        Me.FolioDataGridViewTextBoxColumn.DataPropertyName = "Folio"
        Me.FolioDataGridViewTextBoxColumn.HeaderText = "Folio"
        Me.FolioDataGridViewTextBoxColumn.Name = "FolioDataGridViewTextBoxColumn"
        Me.FolioDataGridViewTextBoxColumn.ReadOnly = True
        Me.FolioDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentDataGridViewTextBoxColumn
        '
        Me.PaymentDataGridViewTextBoxColumn.DataPropertyName = "Payment"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PaymentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PaymentDataGridViewTextBoxColumn.HeaderText = "Payment"
        Me.PaymentDataGridViewTextBoxColumn.Name = "PaymentDataGridViewTextBoxColumn"
        '
        'ReceiptDataGridViewTextBoxColumn
        '
        Me.ReceiptDataGridViewTextBoxColumn.DataPropertyName = "Receipt"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ReceiptDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ReceiptDataGridViewTextBoxColumn.HeaderText = "Receipt"
        Me.ReceiptDataGridViewTextBoxColumn.Name = "ReceiptDataGridViewTextBoxColumn"
        '
        'ReconciledDataGridViewTextBoxColumn
        '
        Me.ReconciledDataGridViewTextBoxColumn.DataPropertyName = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.HeaderText = "Reconciled"
        Me.ReconciledDataGridViewTextBoxColumn.Name = "ReconciledDataGridViewTextBoxColumn"
        Me.ReconciledDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReconciledDataGridViewTextBoxColumn.Width = 90
        '
        'DebitCreditDataGridViewTextBoxColumn
        '
        Me.DebitCreditDataGridViewTextBoxColumn.DataPropertyName = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.HeaderText = "DebitCredit"
        Me.DebitCreditDataGridViewTextBoxColumn.Name = "DebitCreditDataGridViewTextBoxColumn"
        Me.DebitCreditDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VATDataGridViewTextBoxColumn
        '
        Me.VATDataGridViewTextBoxColumn.DataPropertyName = "VAT"
        Me.VATDataGridViewTextBoxColumn.HeaderText = "VAT"
        Me.VATDataGridViewTextBoxColumn.Name = "VATDataGridViewTextBoxColumn"
        Me.VATDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.AmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'BalanceDataGridViewTextBoxColumn
        '
        Me.BalanceDataGridViewTextBoxColumn.DataPropertyName = "Balance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.BalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.BalanceDataGridViewTextBoxColumn.HeaderText = "Balance"
        Me.BalanceDataGridViewTextBoxColumn.Name = "BalanceDataGridViewTextBoxColumn"
        Me.BalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TimeKeyDataGridViewTextBoxColumn
        '
        Me.TimeKeyDataGridViewTextBoxColumn.DataPropertyName = "TimeKey"
        Me.TimeKeyDataGridViewTextBoxColumn.HeaderText = "TimeKey"
        Me.TimeKeyDataGridViewTextBoxColumn.Name = "TimeKeyDataGridViewTextBoxColumn"
        Me.TimeKeyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AccountNoDataGridViewTextBoxColumn
        '
        Me.AccountNoDataGridViewTextBoxColumn.DataPropertyName = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.HeaderText = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.Name = "AccountNoDataGridViewTextBoxColumn"
        Me.AccountNoDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.PbstransBindingSource.DataSource = Me.VpbsDataSet
        '
        'VpbsDataSet
        '
        Me.VpbsDataSet.DataSetName = "VPBSDataSet"
        Me.VpbsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(801, 66)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Edit"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightGray
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(361, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 35)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "&Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightGray
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(706, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 35)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "&Close"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightGray
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(620, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 35)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "&Cancel"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LightGray
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(534, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 35)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "&Ok"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.LightGray
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(450, 19)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(80, 35)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "&Change"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.CmdCancel)
        Me.GroupBox1.Controls.Add(Me.CmdReport)
        Me.GroupBox1.Controls.Add(Me.CmdClose)
        Me.GroupBox1.Controls.Add(Me.CmdAutoRec)
        Me.GroupBox1.Controls.Add(Me.CmdNext)
        Me.GroupBox1.Controls.Add(Me.CmdUndo)
        Me.GroupBox1.Controls.Add(Me.CmdPrevious)
        Me.GroupBox1.Controls.Add(Me.CmdAccept)
        Me.GroupBox1.Controls.Add(Me.CmdOk)
        Me.GroupBox1.Controls.Add(Me.CmdOkReport)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 588)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 66)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.LightGray
        Me.CmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.Location = New System.Drawing.Point(621, 19)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(80, 35)
        Me.CmdCancel.TabIndex = 13
        Me.CmdCancel.Text = "&Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdReport
        '
        Me.CmdReport.BackColor = System.Drawing.Color.LightGray
        Me.CmdReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReport.Location = New System.Drawing.Point(17, 19)
        Me.CmdReport.Name = "CmdReport"
        Me.CmdReport.Size = New System.Drawing.Size(80, 35)
        Me.CmdReport.TabIndex = 11
        Me.CmdReport.Text = "&Report"
        Me.CmdReport.UseVisualStyleBackColor = False
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.Color.LightGray
        Me.CmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.Location = New System.Drawing.Point(706, 19)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(80, 35)
        Me.CmdClose.TabIndex = 7
        Me.CmdClose.Text = "&Close"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'CmdAutoRec
        '
        Me.CmdAutoRec.BackColor = System.Drawing.Color.LightGray
        Me.CmdAutoRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdAutoRec.Enabled = False
        Me.CmdAutoRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAutoRec.Location = New System.Drawing.Point(449, 19)
        Me.CmdAutoRec.Name = "CmdAutoRec"
        Me.CmdAutoRec.Size = New System.Drawing.Size(80, 35)
        Me.CmdAutoRec.TabIndex = 6
        Me.CmdAutoRec.Text = "&Auto Rec"
        Me.CmdAutoRec.UseVisualStyleBackColor = False
        '
        'CmdNext
        '
        Me.CmdNext.BackColor = System.Drawing.Color.LightGray
        Me.CmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNext.Location = New System.Drawing.Point(189, 19)
        Me.CmdNext.Name = "CmdNext"
        Me.CmdNext.Size = New System.Drawing.Size(80, 35)
        Me.CmdNext.TabIndex = 4
        Me.CmdNext.Text = "&Next"
        Me.CmdNext.UseVisualStyleBackColor = False
        '
        'CmdUndo
        '
        Me.CmdUndo.BackColor = System.Drawing.Color.LightGray
        Me.CmdUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUndo.Location = New System.Drawing.Point(361, 19)
        Me.CmdUndo.Name = "CmdUndo"
        Me.CmdUndo.Size = New System.Drawing.Size(80, 35)
        Me.CmdUndo.TabIndex = 2
        Me.CmdUndo.Text = "&Undo"
        Me.CmdUndo.UseVisualStyleBackColor = False
        '
        'CmdPrevious
        '
        Me.CmdPrevious.BackColor = System.Drawing.Color.LightGray
        Me.CmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrevious.Location = New System.Drawing.Point(275, 19)
        Me.CmdPrevious.Name = "CmdPrevious"
        Me.CmdPrevious.Size = New System.Drawing.Size(80, 35)
        Me.CmdPrevious.TabIndex = 1
        Me.CmdPrevious.Text = "&Previous"
        Me.CmdPrevious.UseVisualStyleBackColor = False
        '
        'CmdAccept
        '
        Me.CmdAccept.BackColor = System.Drawing.Color.LightGray
        Me.CmdAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAccept.Location = New System.Drawing.Point(103, 19)
        Me.CmdAccept.Name = "CmdAccept"
        Me.CmdAccept.Size = New System.Drawing.Size(80, 35)
        Me.CmdAccept.TabIndex = 0
        Me.CmdAccept.Text = "&Accept"
        Me.CmdAccept.UseVisualStyleBackColor = False
        '
        'CmdOk
        '
        Me.CmdOk.BackColor = System.Drawing.Color.LightGray
        Me.CmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOk.Location = New System.Drawing.Point(535, 20)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(80, 35)
        Me.CmdOk.TabIndex = 12
        Me.CmdOk.Text = "&Ok"
        Me.CmdOk.UseVisualStyleBackColor = False
        '
        'CmdOkReport
        '
        Me.CmdOkReport.BackColor = System.Drawing.Color.LightGray
        Me.CmdOkReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdOkReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOkReport.Location = New System.Drawing.Point(535, 19)
        Me.CmdOkReport.Name = "CmdOkReport"
        Me.CmdOkReport.Size = New System.Drawing.Size(80, 35)
        Me.CmdOkReport.TabIndex = 14
        Me.CmdOkReport.Text = "&OkReport"
        Me.CmdOkReport.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.txtGroup4)
        Me.GroupBox4.Controls.Add(Me.cboGroup4)
        Me.GroupBox4.Controls.Add(Me.cboGroup3)
        Me.GroupBox4.Controls.Add(Me.cboGroup2)
        Me.GroupBox4.Controls.Add(Me.cboGroup1)
        Me.GroupBox4.Controls.Add(Me.txtGroup3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.txtGroup2)
        Me.GroupBox4.Controls.Add(Me.txtGroup1)
        Me.GroupBox4.Controls.Add(Me.txtDetailAmount)
        Me.GroupBox4.Controls.Add(Me.txtDate)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 482)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(800, 108)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report Detail Section"
        '
        'txtGroup4
        '
        Me.txtGroup4.Location = New System.Drawing.Point(550, 79)
        Me.txtGroup4.Name = "txtGroup4"
        Me.txtGroup4.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup4.TabIndex = 12
        Me.txtGroup4.Text = "txtGroup4"
        Me.txtGroup4.Visible = False
        '
        'cboGroup4
        '
        Me.cboGroup4.FormattingEnabled = True
        Me.cboGroup4.Items.AddRange(New Object() {"3"})
        Me.cboGroup4.Location = New System.Drawing.Point(550, 49)
        Me.cboGroup4.Name = "cboGroup4"
        Me.cboGroup4.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup4.TabIndex = 11
        '
        'cboGroup3
        '
        Me.cboGroup3.FormattingEnabled = True
        Me.cboGroup3.Items.AddRange(New Object() {"3"})
        Me.cboGroup3.Location = New System.Drawing.Point(410, 49)
        Me.cboGroup3.Name = "cboGroup3"
        Me.cboGroup3.Size = New System.Drawing.Size(121, 24)
        Me.cboGroup3.TabIndex = 8
        '
        'cboGroup2
        '
        Me.cboGroup2.FormattingEnabled = True
        Me.cboGroup2.Items.AddRange(New Object() {"2"})
        Me.cboGroup2.Location = New System.Drawing.Point(272, 49)
        Me.cboGroup2.Name = "cboGroup2"
        Me.cboGroup2.Size = New System.Drawing.Size(122, 24)
        Me.cboGroup2.TabIndex = 7
        '
        'cboGroup1
        '
        Me.cboGroup1.FormattingEnabled = True
        Me.cboGroup1.Location = New System.Drawing.Point(133, 49)
        Me.cboGroup1.Name = "cboGroup1"
        Me.cboGroup1.Size = New System.Drawing.Size(122, 24)
        Me.cboGroup1.TabIndex = 6
        '
        'txtGroup3
        '
        Me.txtGroup3.Location = New System.Drawing.Point(410, 79)
        Me.txtGroup3.Name = "txtGroup3"
        Me.txtGroup3.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup3.TabIndex = 5
        Me.txtGroup3.Text = "txtGroup3"
        Me.txtGroup3.Visible = False
        '
        'txtGroup2
        '
        Me.txtGroup2.Location = New System.Drawing.Point(272, 79)
        Me.txtGroup2.Name = "txtGroup2"
        Me.txtGroup2.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup2.TabIndex = 4
        Me.txtGroup2.Text = "txtGroup2"
        Me.txtGroup2.Visible = False
        '
        'txtGroup1
        '
        Me.txtGroup1.Location = New System.Drawing.Point(133, 79)
        Me.txtGroup1.Name = "txtGroup1"
        Me.txtGroup1.Size = New System.Drawing.Size(103, 22)
        Me.txtGroup1.TabIndex = 3
        Me.txtGroup1.Text = "txtGroup"
        Me.txtGroup1.Visible = False
        '
        'txtDetailAmount
        '
        Me.txtDetailAmount.Location = New System.Drawing.Point(677, 49)
        Me.txtDetailAmount.Name = "txtDetailAmount"
        Me.txtDetailAmount.Size = New System.Drawing.Size(62, 22)
        Me.txtDetailAmount.TabIndex = 1
        Me.txtDetailAmount.Text = "Amount"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(35, 51)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(62, 22)
        Me.txtDate.TabIndex = 0
        Me.txtDate.Text = "Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(710, 16)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Includes repeating records in main body of report - decide which fields you want " &
    "to include in report. then click on OkRpt."
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.lblAdjBankBal)
        Me.GroupBox5.Controls.Add(Me.lblCurrentPBSBal)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 420)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(800, 54)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        '
        'lblAdjBankBal
        '
        Me.lblAdjBankBal.BackColor = System.Drawing.Color.White
        Me.lblAdjBankBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjBankBal.Location = New System.Drawing.Point(642, 9)
        Me.lblAdjBankBal.Name = "lblAdjBankBal"
        Me.lblAdjBankBal.Size = New System.Drawing.Size(100, 19)
        Me.lblAdjBankBal.TabIndex = 4
        Me.lblAdjBankBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCurrentPBSBal
        '
        Me.lblCurrentPBSBal.BackColor = System.Drawing.Color.White
        Me.lblCurrentPBSBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPBSBal.Location = New System.Drawing.Point(642, 30)
        Me.lblCurrentPBSBal.Name = "lblCurrentPBSBal"
        Me.lblCurrentPBSBal.Size = New System.Drawing.Size(100, 19)
        Me.lblCurrentPBSBal.TabIndex = 3
        Me.lblCurrentPBSBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(259, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Adjusted Current Bank Statement balance:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(232, 28)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Adjusted Current PBS balance:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtCurrentBankBal)
        Me.GroupBox3.Controls.Add(Me.AxCrystalReport1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(800, 31)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(398, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(238, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Current Bank Statement balance:"
        '
        'txtCurrentBankBal
        '
        Me.txtCurrentBankBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentBankBal.Location = New System.Drawing.Point(642, 6)
        Me.txtCurrentBankBal.Name = "txtCurrentBankBal"
        Me.txtCurrentBankBal.Size = New System.Drawing.Size(100, 22)
        Me.txtCurrentBankBal.TabIndex = 5
        Me.txtCurrentBankBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AxCrystalReport1
        '
        Me.AxCrystalReport1.Enabled = True
        Me.AxCrystalReport1.Location = New System.Drawing.Point(3, 0)
        Me.AxCrystalReport1.Name = "AxCrystalReport1"
        Me.AxCrystalReport1.OcxState = CType(resources.GetObject("AxCrystalReport1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxCrystalReport1.Size = New System.Drawing.Size(28, 28)
        Me.AxCrystalReport1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(273, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Less  Unreconciled PBS transactions:"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.txtCurrentPBSBal)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 229)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(800, 31)
        Me.GroupBox6.TabIndex = 36
        Me.GroupBox6.TabStop = False
        '
        'txtCurrentPBSBal
        '
        Me.txtCurrentPBSBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentPBSBal.Location = New System.Drawing.Point(642, 6)
        Me.txtCurrentPBSBal.Name = "txtCurrentPBSBal"
        Me.txtCurrentPBSBal.Size = New System.Drawing.Size(100, 22)
        Me.txtCurrentPBSBal.TabIndex = 4
        Me.txtCurrentPBSBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(398, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Current PBS balance:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(287, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Less  Unreconciled Bank transactions:"
        '
        'DataGridBankTrans
        '
        Me.DataGridBankTrans.AllowUserToOrderColumns = True
        Me.DataGridBankTrans.AutoGenerateColumns = False
        Me.DataGridBankTrans.BackgroundColor = System.Drawing.Color.AntiqueWhite
        Me.DataGridBankTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridBankTrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridBankTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridBankTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionDateDataGridViewTextBoxColumn, Me.TransactionTypeDataGridViewTextBoxColumn, Me.TransactionDescriptionDataGridViewTextBoxColumn, Me.AccountNumberDataGridViewTextBoxColumn, Me.DebitAmountDataGridViewTextBoxColumn, Me.CreditAmountDataGridViewTextBoxColumn, Me.Reconciled, Me.SortCodeDataGridViewTextBoxColumn, Me.TimeKey})
        Me.DataGridBankTrans.DataSource = Me.RecTransBindingSource
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.AntiqueWhite
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridBankTrans.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridBankTrans.Location = New System.Drawing.Point(12, 260)
        Me.DataGridBankTrans.Name = "DataGridBankTrans"
        Me.DataGridBankTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridBankTrans.Size = New System.Drawing.Size(800, 153)
        Me.DataGridBankTrans.TabIndex = 37
        '
        'TransactionDateDataGridViewTextBoxColumn
        '
        Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "Transaction Date"
        DataGridViewCellStyle9.Format = "dd-MMM-yy"
        Me.TransactionDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
        Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TransactionTypeDataGridViewTextBoxColumn
        '
        Me.TransactionTypeDataGridViewTextBoxColumn.DataPropertyName = "Transaction Type"
        Me.TransactionTypeDataGridViewTextBoxColumn.HeaderText = "Reference"
        Me.TransactionTypeDataGridViewTextBoxColumn.Name = "TransactionTypeDataGridViewTextBoxColumn"
        Me.TransactionTypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TransactionDescriptionDataGridViewTextBoxColumn
        '
        Me.TransactionDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Transaction Description"
        Me.TransactionDescriptionDataGridViewTextBoxColumn.HeaderText = "Customer"
        Me.TransactionDescriptionDataGridViewTextBoxColumn.Name = "TransactionDescriptionDataGridViewTextBoxColumn"
        Me.TransactionDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.TransactionDescriptionDataGridViewTextBoxColumn.Width = 150
        '
        'AccountNumberDataGridViewTextBoxColumn
        '
        Me.AccountNumberDataGridViewTextBoxColumn.DataPropertyName = "Account Number"
        Me.AccountNumberDataGridViewTextBoxColumn.HeaderText = "Acct No."
        Me.AccountNumberDataGridViewTextBoxColumn.Name = "AccountNumberDataGridViewTextBoxColumn"
        Me.AccountNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DebitAmountDataGridViewTextBoxColumn
        '
        Me.DebitAmountDataGridViewTextBoxColumn.DataPropertyName = "Debit Amount"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DebitAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.DebitAmountDataGridViewTextBoxColumn.HeaderText = "Payment"
        Me.DebitAmountDataGridViewTextBoxColumn.Name = "DebitAmountDataGridViewTextBoxColumn"
        Me.DebitAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreditAmountDataGridViewTextBoxColumn
        '
        Me.CreditAmountDataGridViewTextBoxColumn.DataPropertyName = "Credit Amount"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.CreditAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.CreditAmountDataGridViewTextBoxColumn.HeaderText = "Receipt"
        Me.CreditAmountDataGridViewTextBoxColumn.Name = "CreditAmountDataGridViewTextBoxColumn"
        Me.CreditAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Reconciled
        '
        Me.Reconciled.DataPropertyName = "Sort Code"
        Me.Reconciled.HeaderText = "Reconciled"
        Me.Reconciled.Name = "Reconciled"
        Me.Reconciled.ReadOnly = True
        Me.Reconciled.Width = 90
        '
        'SortCodeDataGridViewTextBoxColumn
        '
        Me.SortCodeDataGridViewTextBoxColumn.DataPropertyName = "Balance"
        Me.SortCodeDataGridViewTextBoxColumn.HeaderText = "Sort Code"
        Me.SortCodeDataGridViewTextBoxColumn.Name = "SortCodeDataGridViewTextBoxColumn"
        Me.SortCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.SortCodeDataGridViewTextBoxColumn.Visible = False
        '
        'TimeKey
        '
        DataGridViewCellStyle12.Format = "T"
        Me.TimeKey.DefaultCellStyle = DataGridViewCellStyle12
        Me.TimeKey.HeaderText = "TimeKey"
        Me.TimeKey.Name = "TimeKey"
        Me.TimeKey.ReadOnly = True
        Me.TimeKey.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TimeKey.Visible = False
        '
        'RecTransBindingSource
        '
        Me.RecTransBindingSource.DataMember = "RecTrans"
        Me.RecTransBindingSource.DataSource = Me.VPBSDataSet9
        Me.RecTransBindingSource.Filter = "[Sort Code] <> 'Y'"
        Me.RecTransBindingSource.Sort = "Balance"
        '
        'VPBSDataSet9
        '
        Me.VPBSDataSet9.DataSetName = "VPBSDataSet9"
        Me.VPBSDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VpbsTestDataSet
        '
        Me.VpbsTestDataSet.DataSetName = "VPBSTestDataSet"
        Me.VpbsTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PbstransTableAdapterTest
        '
        Me.PbstransTableAdapterTest.ClearBeforeFill = True
        '
        'PbstransTableAdapterLive
        '
        Me.PbstransTableAdapterLive.ClearBeforeFill = True
        '
        'VpbsArchiveDataSet
        '
        Me.VpbsArchiveDataSet.DataSetName = "VpbsArchiveDataSet"
        Me.VpbsArchiveDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PbstransTableAdapterArc
        '
        Me.PbstransTableAdapterArc.ClearBeforeFill = True
        '
        'VpbsTestDataSet1
        '
        Me.VpbsTestDataSet1.DataSetName = "VpbsTestDataSet1"
        Me.VpbsTestDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RecTransTableAdapterTest
        '
        Me.RecTransTableAdapterTest.ClearBeforeFill = True
        '
        'VpbsArchiveDataSet4
        '
        Me.VpbsArchiveDataSet4.DataSetName = "VpbsArchiveDataSet4"
        Me.VpbsArchiveDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RecTransTableAdapterArc
        '
        Me.RecTransTableAdapterArc.ClearBeforeFill = True
        '
        'RecTransTableAdapterLive
        '
        Me.RecTransTableAdapterLive.ClearBeforeFill = True
        '
        'txtnPbsDebitAmount
        '
        Me.txtnPbsDebitAmount.Location = New System.Drawing.Point(373, 664)
        Me.txtnPbsDebitAmount.Name = "txtnPbsDebitAmount"
        Me.txtnPbsDebitAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtnPbsDebitAmount.TabIndex = 38
        '
        'txtnPbsCreditAmount
        '
        Me.txtnPbsCreditAmount.Location = New System.Drawing.Point(479, 664)
        Me.txtnPbsCreditAmount.Name = "txtnPbsCreditAmount"
        Me.txtnPbsCreditAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtnPbsCreditAmount.TabIndex = 39
        '
        'txtPayReceipt
        '
        Me.txtPayReceipt.Location = New System.Drawing.Point(585, 664)
        Me.txtPayReceipt.Name = "txtPayReceipt"
        Me.txtPayReceipt.Size = New System.Drawing.Size(100, 20)
        Me.txtPayReceipt.TabIndex = 40
        '
        'txtdDateKey
        '
        Me.txtdDateKey.Location = New System.Drawing.Point(15, 664)
        Me.txtdDateKey.Name = "txtdDateKey"
        Me.txtdDateKey.Size = New System.Drawing.Size(100, 20)
        Me.txtdDateKey.TabIndex = 41
        '
        'txtdTimeKey
        '
        Me.txtdTimeKey.Location = New System.Drawing.Point(121, 664)
        Me.txtdTimeKey.Name = "txtdTimeKey"
        Me.txtdTimeKey.Size = New System.Drawing.Size(100, 20)
        Me.txtdTimeKey.TabIndex = 42
        '
        'txtsPbsCustomer
        '
        Me.txtsPbsCustomer.Location = New System.Drawing.Point(227, 664)
        Me.txtsPbsCustomer.Name = "txtsPbsCustomer"
        Me.txtsPbsCustomer.Size = New System.Drawing.Size(100, 20)
        Me.txtsPbsCustomer.TabIndex = 43
        '
        'frmBankRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(825, 664)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtsPbsCustomer)
        Me.Controls.Add(Me.txtdTimeKey)
        Me.Controls.Add(Me.txtdDateKey)
        Me.Controls.Add(Me.txtPayReceipt)
        Me.Controls.Add(Me.txtnPbsCreditAmount)
        Me.Controls.Add(Me.txtnPbsDebitAmount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.DataGridBankTrans)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DataGridPbsTrans)
        Me.Controls.Add(Me.lblAccountHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBankRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VPBS - BANK RECONCILATION"
        CType(Me.DataGridPbsTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbstransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.AxCrystalReport1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DataGridBankTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecTransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSDataSet9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsTestDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsArchiveDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAccountHeader As System.Windows.Forms.Label
    Friend WithEvents VpbsDataSet As VPBS13.VPBSDataSet
    Friend WithEvents VpbsTestDataSet As VPBS13.VPBSTestDataSet
    Friend WithEvents PbstransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PbstransTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents DataGridPbsTrans As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboGroup3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtGroup3 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGroup1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDetailAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAdjBankBal As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPBSBal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGroup4 As System.Windows.Forms.TextBox
    Friend WithEvents cboGroup4 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdReport As System.Windows.Forms.Button
    Friend WithEvents CmdClose As System.Windows.Forms.Button
    Friend WithEvents CmdAutoRec As System.Windows.Forms.Button
    Friend WithEvents CmdNext As System.Windows.Forms.Button
    Friend WithEvents CmdUndo As System.Windows.Forms.Button
    Friend WithEvents CmdPrevious As System.Windows.Forms.Button
    Friend WithEvents CmdAccept As System.Windows.Forms.Button
    Friend WithEvents CmdOkReport As System.Windows.Forms.Button
    Friend WithEvents PbstransTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents AxCrystalReport1 As AxCrystal.AxCrystalReport
    Friend WithEvents VpbsArchiveDataSet As VPBS13.VpbsArchiveDataSet
    Friend WithEvents PbstransTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.pbstransTableAdapter
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPBSBal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridBankTrans As System.Windows.Forms.DataGridView
    Friend WithEvents RecTransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VpbsTestDataSet1 As VPBS13.VPBSTestDataSet1
    Friend WithEvents RecTransTableAdapterTest As VPBS13.VPBSTestDataSet1TableAdapters.RecTransTableAdapter
    Friend WithEvents VpbsArchiveDataSet4 As VPBS13.VpbsArchiveDataSet4
    Friend WithEvents RecTransTableAdapterArc As VPBS13.VpbsArchiveDataSet4TableAdapters.RecTransTableAdapter
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentBankBal As System.Windows.Forms.TextBox
    Friend WithEvents VPBSDataSet9 As VPBS13.VPBSDataSet9
    Friend WithEvents RecTransTableAdapterLive As VPBS13.VPBSDataSet9TableAdapters.RecTransTableAdapter
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnalysisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GlcodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FolioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReconciledDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitCreditDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VATDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reconciled As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtnPbsDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtnPbsCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPayReceipt As System.Windows.Forms.TextBox
    Friend WithEvents txtdDateKey As System.Windows.Forms.TextBox
    Friend WithEvents txtdTimeKey As System.Windows.Forms.TextBox
    Friend WithEvents txtsPbsCustomer As System.Windows.Forms.TextBox
End Class
