<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddChgAcc
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddChgAcc))
        Me.VpbsTestDataSet = New VPBS13.VPBSTestDataSet()
        Me.DataGridDirPbs = New System.Windows.Forms.DataGridView()
        Me.AccountNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountDescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankBranchDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceEquivalentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OdLimitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BudgetNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirpbsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VpbsDataSet = New VPBS13.VPBSDataSet()
        Me.DirpbsTableAdapterTest = New VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdChange = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboGroupNo = New System.Windows.Forms.ComboBox()
        Me.cboAccountName = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOdLimit = New System.Windows.Forms.TextBox()
        Me.txtBankCode = New System.Windows.Forms.TextBox()
        Me.txtBankBranch = New System.Windows.Forms.TextBox()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.txtAccountDesc = New System.Windows.Forms.TextBox()
        Me.cboUserName = New System.Windows.Forms.ComboBox()
        Me.cboCcy = New System.Windows.Forms.ComboBox()
        Me.cboBankName = New System.Windows.Forms.ComboBox()
        Me.DirpbsTableAdapterLive = New VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter()
        Me.VpbsArchiveDataSet = New VPBS13.VpbsArchiveDataSet()
        Me.DirpbsTableAdapterArc = New VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter()
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridDirPbs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VpbsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VpbsTestDataSet
        '
        Me.VpbsTestDataSet.DataSetName = "VPBSTestDataSet"
        Me.VpbsTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridDirPbs
        '
        Me.DataGridDirPbs.AutoGenerateColumns = False
        Me.DataGridDirPbs.BackgroundColor = System.Drawing.Color.White
        Me.DataGridDirPbs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridDirPbs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridDirPbs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDirPbs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountNoDataGridViewTextBoxColumn, Me.AccountNameDataGridViewTextBoxColumn, Me.AccountDescDataGridViewTextBoxColumn, Me.BankNameDataGridViewTextBoxColumn, Me.BankBranchDataGridViewTextBoxColumn, Me.BankCodeDataGridViewTextBoxColumn, Me.BalanceDataGridViewTextBoxColumn, Me.CurrencyDataGridViewTextBoxColumn, Me.BalanceDateDataGridViewTextBoxColumn, Me.BalanceEquivalentDataGridViewTextBoxColumn, Me.OdLimitDataGridViewTextBoxColumn, Me.UserNameDataGridViewTextBoxColumn, Me.BudgetNoDataGridViewTextBoxColumn, Me.BalanceStatusDataGridViewTextBoxColumn})
        Me.DataGridDirPbs.DataSource = Me.DirpbsBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridDirPbs.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridDirPbs.Location = New System.Drawing.Point(12, 12)
        Me.DataGridDirPbs.MultiSelect = False
        Me.DataGridDirPbs.Name = "DataGridDirPbs"
        Me.DataGridDirPbs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridDirPbs.Size = New System.Drawing.Size(802, 264)
        Me.DataGridDirPbs.TabIndex = 0
        '
        'AccountNoDataGridViewTextBoxColumn
        '
        Me.AccountNoDataGridViewTextBoxColumn.DataPropertyName = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.HeaderText = "AccountNo"
        Me.AccountNoDataGridViewTextBoxColumn.Name = "AccountNoDataGridViewTextBoxColumn"
        Me.AccountNoDataGridViewTextBoxColumn.Width = 125
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.Width = 120
        '
        'AccountDescDataGridViewTextBoxColumn
        '
        Me.AccountDescDataGridViewTextBoxColumn.DataPropertyName = "AccountDesc"
        Me.AccountDescDataGridViewTextBoxColumn.HeaderText = "AccountDesc"
        Me.AccountDescDataGridViewTextBoxColumn.Name = "AccountDescDataGridViewTextBoxColumn"
        Me.AccountDescDataGridViewTextBoxColumn.Width = 110
        '
        'BankNameDataGridViewTextBoxColumn
        '
        Me.BankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName"
        Me.BankNameDataGridViewTextBoxColumn.HeaderText = "BankName"
        Me.BankNameDataGridViewTextBoxColumn.Name = "BankNameDataGridViewTextBoxColumn"
        '
        'BankBranchDataGridViewTextBoxColumn
        '
        Me.BankBranchDataGridViewTextBoxColumn.DataPropertyName = "BankBranch"
        Me.BankBranchDataGridViewTextBoxColumn.HeaderText = "BankBranch"
        Me.BankBranchDataGridViewTextBoxColumn.Name = "BankBranchDataGridViewTextBoxColumn"
        '
        'BankCodeDataGridViewTextBoxColumn
        '
        Me.BankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode"
        Me.BankCodeDataGridViewTextBoxColumn.HeaderText = "BankCode"
        Me.BankCodeDataGridViewTextBoxColumn.Name = "BankCodeDataGridViewTextBoxColumn"
        Me.BankCodeDataGridViewTextBoxColumn.Width = 85
        '
        'BalanceDataGridViewTextBoxColumn
        '
        Me.BalanceDataGridViewTextBoxColumn.DataPropertyName = "Balance"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.BalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.BalanceDataGridViewTextBoxColumn.HeaderText = "Balance"
        Me.BalanceDataGridViewTextBoxColumn.Name = "BalanceDataGridViewTextBoxColumn"
        Me.BalanceDataGridViewTextBoxColumn.Width = 70
        '
        'CurrencyDataGridViewTextBoxColumn
        '
        Me.CurrencyDataGridViewTextBoxColumn.DataPropertyName = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.HeaderText = "Ccy"
        Me.CurrencyDataGridViewTextBoxColumn.Name = "CurrencyDataGridViewTextBoxColumn"
        Me.CurrencyDataGridViewTextBoxColumn.Width = 40
        '
        'BalanceDateDataGridViewTextBoxColumn
        '
        Me.BalanceDateDataGridViewTextBoxColumn.DataPropertyName = "BalanceDate"
        Me.BalanceDateDataGridViewTextBoxColumn.HeaderText = "BalanceDate"
        Me.BalanceDateDataGridViewTextBoxColumn.Name = "BalanceDateDataGridViewTextBoxColumn"
        '
        'BalanceEquivalentDataGridViewTextBoxColumn
        '
        Me.BalanceEquivalentDataGridViewTextBoxColumn.DataPropertyName = "BalanceEquivalent"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.BalanceEquivalentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.BalanceEquivalentDataGridViewTextBoxColumn.HeaderText = "BalanceEquivalent"
        Me.BalanceEquivalentDataGridViewTextBoxColumn.Name = "BalanceEquivalentDataGridViewTextBoxColumn"
        '
        'OdLimitDataGridViewTextBoxColumn
        '
        Me.OdLimitDataGridViewTextBoxColumn.DataPropertyName = "odLimit"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.OdLimitDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.OdLimitDataGridViewTextBoxColumn.HeaderText = "odLimit"
        Me.OdLimitDataGridViewTextBoxColumn.Name = "OdLimitDataGridViewTextBoxColumn"
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        '
        'BudgetNoDataGridViewTextBoxColumn
        '
        Me.BudgetNoDataGridViewTextBoxColumn.DataPropertyName = "BudgetNo"
        Me.BudgetNoDataGridViewTextBoxColumn.HeaderText = "BudgetNo"
        Me.BudgetNoDataGridViewTextBoxColumn.Name = "BudgetNoDataGridViewTextBoxColumn"
        '
        'BalanceStatusDataGridViewTextBoxColumn
        '
        Me.BalanceStatusDataGridViewTextBoxColumn.DataPropertyName = "BalanceStatus"
        Me.BalanceStatusDataGridViewTextBoxColumn.HeaderText = "BalanceStatus"
        Me.BalanceStatusDataGridViewTextBoxColumn.Name = "BalanceStatusDataGridViewTextBoxColumn"
        '
        'DirpbsBindingSource
        '
        Me.DirpbsBindingSource.DataMember = "dirpbs"
        Me.DirpbsBindingSource.DataSource = Me.VpbsDataSet
        '
        'VpbsDataSet
        '
        Me.VpbsDataSet.DataSetName = "VPBSDataSet"
        Me.VpbsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DirpbsTableAdapterTest
        '
        Me.DirpbsTableAdapterTest.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.cmdDelete)
        Me.GroupBox1.Controls.Add(Me.cmdChange)
        Me.GroupBox1.Controls.Add(Me.cmdNew)
        Me.GroupBox1.Controls.Add(Me.cmdSelect)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 496)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(802, 66)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.LightGray
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(703, 19)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 35)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.LightGray
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(617, 19)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 35)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.LightGray
        Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(531, 19)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 35)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.LightGray
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(273, 19)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(80, 35)
        Me.cmdDelete.TabIndex = 3
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdChange
        '
        Me.cmdChange.BackColor = System.Drawing.Color.LightGray
        Me.cmdChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChange.Location = New System.Drawing.Point(187, 19)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.Size = New System.Drawing.Size(80, 35)
        Me.cmdChange.TabIndex = 2
        Me.cmdChange.Text = "&Change"
        Me.cmdChange.UseVisualStyleBackColor = False
        '
        'cmdNew
        '
        Me.cmdNew.BackColor = System.Drawing.Color.LightGray
        Me.cmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNew.Location = New System.Drawing.Point(101, 19)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(80, 35)
        Me.cmdNew.TabIndex = 1
        Me.cmdNew.Text = "&New"
        Me.cmdNew.UseVisualStyleBackColor = False
        '
        'cmdSelect
        '
        Me.cmdSelect.BackColor = System.Drawing.Color.LightGray
        Me.cmdSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelect.Location = New System.Drawing.Point(15, 19)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(80, 35)
        Me.cmdSelect.TabIndex = 0
        Me.cmdSelect.Text = "&Select"
        Me.cmdSelect.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.cboGroupNo)
        Me.GroupBox2.Controls.Add(Me.cboAccountName)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtOdLimit)
        Me.GroupBox2.Controls.Add(Me.txtBankCode)
        Me.GroupBox2.Controls.Add(Me.txtBankBranch)
        Me.GroupBox2.Controls.Add(Me.cboAccountNo)
        Me.GroupBox2.Controls.Add(Me.txtAccountDesc)
        Me.GroupBox2.Controls.Add(Me.cboUserName)
        Me.GroupBox2.Controls.Add(Me.cboCcy)
        Me.GroupBox2.Controls.Add(Me.cboBankName)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(802, 214)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "New/Change"
        '
        'cboGroupNo
        '
        Me.cboGroupNo.FormattingEnabled = True
        Me.cboGroupNo.Location = New System.Drawing.Point(601, 58)
        Me.cboGroupNo.Name = "cboGroupNo"
        Me.cboGroupNo.Size = New System.Drawing.Size(182, 24)
        Me.cboGroupNo.TabIndex = 21
        '
        'cboAccountName
        '
        Me.cboAccountName.FormattingEnabled = True
        Me.cboAccountName.Location = New System.Drawing.Point(187, 21)
        Me.cboAccountName.Name = "cboAccountName"
        Me.cboAccountName.Size = New System.Drawing.Size(182, 24)
        Me.cboAccountName.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(429, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 24)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "User Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(429, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 24)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Overdraft Limit"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(16, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 24)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Bank Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(429, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 24)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Group No"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(429, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 24)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Account No"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(429, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 24)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Currency"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(16, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Bank Branch"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(16, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 24)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Bank Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Account Desc."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Account Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOdLimit
        '
        Me.txtOdLimit.Location = New System.Drawing.Point(601, 140)
        Me.txtOdLimit.Name = "txtOdLimit"
        Me.txtOdLimit.Size = New System.Drawing.Size(182, 22)
        Me.txtOdLimit.TabIndex = 9
        Me.txtOdLimit.Text = "0"
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(187, 179)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(182, 22)
        Me.txtBankCode.TabIndex = 8
        '
        'txtBankBranch
        '
        Me.txtBankBranch.Location = New System.Drawing.Point(187, 142)
        Me.txtBankBranch.Name = "txtBankBranch"
        Me.txtBankBranch.Size = New System.Drawing.Size(182, 22)
        Me.txtBankBranch.TabIndex = 6
        '
        'cboAccountNo
        '
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.Location = New System.Drawing.Point(601, 20)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(182, 24)
        Me.cboAccountNo.TabIndex = 5
        '
        'txtAccountDesc
        '
        Me.txtAccountDesc.Location = New System.Drawing.Point(187, 60)
        Me.txtAccountDesc.Name = "txtAccountDesc"
        Me.txtAccountDesc.Size = New System.Drawing.Size(182, 22)
        Me.txtAccountDesc.TabIndex = 4
        '
        'cboUserName
        '
        Me.cboUserName.FormattingEnabled = True
        Me.cboUserName.Location = New System.Drawing.Point(601, 180)
        Me.cboUserName.Name = "cboUserName"
        Me.cboUserName.Size = New System.Drawing.Size(182, 24)
        Me.cboUserName.TabIndex = 3
        '
        'cboCcy
        '
        Me.cboCcy.FormattingEnabled = True
        Me.cboCcy.Location = New System.Drawing.Point(601, 101)
        Me.cboCcy.Name = "cboCcy"
        Me.cboCcy.Size = New System.Drawing.Size(182, 24)
        Me.cboCcy.TabIndex = 2
        '
        'cboBankName
        '
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(187, 100)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(182, 24)
        Me.cboBankName.TabIndex = 1
        '
        'DirpbsTableAdapterLive
        '
        Me.DirpbsTableAdapterLive.ClearBeforeFill = True
        '
        'VpbsArchiveDataSet
        '
        Me.VpbsArchiveDataSet.DataSetName = "VpbsArchiveDataSet"
        Me.VpbsArchiveDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DirpbsTableAdapterArc
        '
        Me.DirpbsTableAdapterArc.ClearBeforeFill = True
        '
        'frmAddChgAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(826, 572)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridDirPbs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddChgAcc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VPBS - New/Change Account"
        CType(Me.VpbsTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridDirPbs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DirpbsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VpbsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.VpbsArchiveDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VpbsTestDataSet As VPBS13.VPBSTestDataSet
    Friend WithEvents DataGridDirPbs As System.Windows.Forms.DataGridView
    Friend WithEvents DirpbsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DirpbsTableAdapterTest As VPBS13.VPBSTestDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents AccountNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountDescDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankBranchDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceEquivalentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OdLimitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdChange As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOdLimit As System.Windows.Forms.TextBox
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankBranch As System.Windows.Forms.TextBox
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtAccountDesc As System.Windows.Forms.TextBox
    Friend WithEvents cboUserName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCcy As System.Windows.Forms.ComboBox
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroupNo As System.Windows.Forms.ComboBox
    Friend WithEvents VpbsDataSet As VPBS13.VPBSDataSet
    Friend WithEvents DirpbsTableAdapterLive As VPBS13.VPBSDataSetTableAdapters.dirpbsTableAdapter
    Friend WithEvents VpbsArchiveDataSet As VPBS13.VpbsArchiveDataSet
    Friend WithEvents DirpbsTableAdapterArc As VPBS13.VpbsArchiveDataSetTableAdapters.dirpbsTableAdapter
End Class
