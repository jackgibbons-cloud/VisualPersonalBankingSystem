<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStartUp))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StartUpPanel = New System.Windows.Forms.Panel()
        Me.lblSelectOption = New System.Windows.Forms.Label()
        Me.CmdVideos = New System.Windows.Forms.Button()
        Me.CmdMusic = New System.Windows.Forms.Button()
        Me.CmdBooks = New System.Windows.Forms.Button()
        Me.CmdAddresses = New System.Windows.Forms.Button()
        Me.CmdFinance = New System.Windows.Forms.Button()
        Me.CmdPBS = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchiveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrinterSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PostSOsOnAllActsConcurrentlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordsOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InTheSummerOf1980ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalBankingSystemVersonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputerHardwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalDataSystemToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSelectOptionold = New System.Windows.Forms.Label()
        Me.lblLogInOut = New System.Windows.Forms.Label()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdLogout = New System.Windows.Forms.Button()
        Me.CmdLogin = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cboUserName = New System.Windows.Forms.ComboBox()
        Me.UsersLiveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VPBSDataSet = New VPBS13.VPBSDataSet()
        Me.UsersTestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VPBSTestDataSet = New VPBS13.VPBSTestDataSet()
        Me.UsersTestTableAdapter = New VPBS13.VPBSTestDataSetTableAdapters.UsersTableAdapter()
        Me.UsersLiveTableAdapter = New VPBS13.VPBSDataSetTableAdapters.UsersTableAdapter()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StartUpPanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UsersLiveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsersTestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VPBSTestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(92, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(556, 58)
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(92, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(556, 58)
        Me.Label2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(101, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(539, 42)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Welcome to the"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(101, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(539, 42)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Personal Data System"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StartUpPanel
        '
        Me.StartUpPanel.BackColor = System.Drawing.Color.Silver
        Me.StartUpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.StartUpPanel.Controls.Add(Me.lblSelectOption)
        Me.StartUpPanel.Controls.Add(Me.CmdVideos)
        Me.StartUpPanel.Controls.Add(Me.CmdMusic)
        Me.StartUpPanel.Controls.Add(Me.CmdBooks)
        Me.StartUpPanel.Controls.Add(Me.CmdAddresses)
        Me.StartUpPanel.Controls.Add(Me.CmdFinance)
        Me.StartUpPanel.Controls.Add(Me.CmdPBS)
        Me.StartUpPanel.Enabled = False
        Me.StartUpPanel.Location = New System.Drawing.Point(92, 230)
        Me.StartUpPanel.Name = "StartUpPanel"
        Me.StartUpPanel.Size = New System.Drawing.Size(556, 230)
        Me.StartUpPanel.TabIndex = 6
        '
        'lblSelectOption
        '
        Me.lblSelectOption.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSelectOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSelectOption.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectOption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelectOption.Location = New System.Drawing.Point(7, 9)
        Me.lblSelectOption.Name = "lblSelectOption"
        Me.lblSelectOption.Size = New System.Drawing.Size(539, 36)
        Me.lblSelectOption.TabIndex = 10
        Me.lblSelectOption.Text = "Select an Option"
        Me.lblSelectOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdVideos
        '
        Me.CmdVideos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdVideos.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdVideos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdVideos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdVideos.Location = New System.Drawing.Point(371, 139)
        Me.CmdVideos.Name = "CmdVideos"
        Me.CmdVideos.Size = New System.Drawing.Size(175, 81)
        Me.CmdVideos.TabIndex = 5
        Me.CmdVideos.Text = "Videos"
        Me.CmdVideos.UseVisualStyleBackColor = False
        '
        'CmdMusic
        '
        Me.CmdMusic.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdMusic.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdMusic.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdMusic.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMusic.Location = New System.Drawing.Point(189, 139)
        Me.CmdMusic.Name = "CmdMusic"
        Me.CmdMusic.Size = New System.Drawing.Size(175, 81)
        Me.CmdMusic.TabIndex = 4
        Me.CmdMusic.Text = "Music"
        Me.CmdMusic.UseVisualStyleBackColor = False
        '
        'CmdBooks
        '
        Me.CmdBooks.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdBooks.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdBooks.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdBooks.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBooks.Location = New System.Drawing.Point(7, 139)
        Me.CmdBooks.Name = "CmdBooks"
        Me.CmdBooks.Size = New System.Drawing.Size(175, 81)
        Me.CmdBooks.TabIndex = 3
        Me.CmdBooks.Text = "Books"
        Me.CmdBooks.UseVisualStyleBackColor = False
        '
        'CmdAddresses
        '
        Me.CmdAddresses.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdAddresses.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdAddresses.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAddresses.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAddresses.Location = New System.Drawing.Point(371, 54)
        Me.CmdAddresses.Name = "CmdAddresses"
        Me.CmdAddresses.Size = New System.Drawing.Size(175, 81)
        Me.CmdAddresses.TabIndex = 2
        Me.CmdAddresses.Text = "Addresses"
        Me.CmdAddresses.UseVisualStyleBackColor = False
        '
        'CmdFinance
        '
        Me.CmdFinance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdFinance.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdFinance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdFinance.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFinance.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdFinance.Location = New System.Drawing.Point(189, 54)
        Me.CmdFinance.Name = "CmdFinance"
        Me.CmdFinance.Size = New System.Drawing.Size(175, 81)
        Me.CmdFinance.TabIndex = 1
        Me.CmdFinance.Text = "Finance Summary"
        Me.CmdFinance.UseVisualStyleBackColor = False
        '
        'CmdPBS
        '
        Me.CmdPBS.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdPBS.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.CmdPBS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPBS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPBS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdPBS.Location = New System.Drawing.Point(7, 54)
        Me.CmdPBS.Name = "CmdPBS"
        Me.CmdPBS.Size = New System.Drawing.Size(175, 81)
        Me.CmdPBS.TabIndex = 0
        Me.CmdPBS.Text = "Personal Banking"
        Me.CmdPBS.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(738, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.PrinterSetupToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchiveDataToolStripMenuItem, Me.LiveDataToolStripMenuItem, Me.TestDataToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "&Select DataBase"
        '
        'ArchiveDataToolStripMenuItem
        '
        Me.ArchiveDataToolStripMenuItem.Name = "ArchiveDataToolStripMenuItem"
        Me.ArchiveDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ArchiveDataToolStripMenuItem.Text = "&Archive Data"
        '
        'LiveDataToolStripMenuItem
        '
        Me.LiveDataToolStripMenuItem.Checked = True
        Me.LiveDataToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LiveDataToolStripMenuItem.Name = "LiveDataToolStripMenuItem"
        Me.LiveDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LiveDataToolStripMenuItem.Text = "&Live Data"
        '
        'TestDataToolStripMenuItem
        '
        Me.TestDataToolStripMenuItem.Name = "TestDataToolStripMenuItem"
        Me.TestDataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestDataToolStripMenuItem.Text = "&Test Data"
        Me.TestDataToolStripMenuItem.Visible = False
        '
        'PrinterSetupToolStripMenuItem
        '
        Me.PrinterSetupToolStripMenuItem.Name = "PrinterSetupToolStripMenuItem"
        Me.PrinterSetupToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrinterSetupToolStripMenuItem.Text = "&Printer Setup"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PostSOsOnAllActsConcurrentlyToolStripMenuItem, Me.PasswordsOnToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.AboutToolStripMenuItem.Text = "&Setup"
        '
        'PostSOsOnAllActsConcurrentlyToolStripMenuItem
        '
        Me.PostSOsOnAllActsConcurrentlyToolStripMenuItem.Name = "PostSOsOnAllActsConcurrentlyToolStripMenuItem"
        Me.PostSOsOnAllActsConcurrentlyToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.PostSOsOnAllActsConcurrentlyToolStripMenuItem.Text = "Post SO's on ALL a/c's concurrently?"
        '
        'PasswordsOnToolStripMenuItem
        '
        Me.PasswordsOnToolStripMenuItem.Name = "PasswordsOnToolStripMenuItem"
        Me.PasswordsOnToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.PasswordsOnToolStripMenuItem.Text = "Passwords On/Off"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InTheSummerOf1980ToolStripMenuItem, Me.PersonalBankingSystemVersonsToolStripMenuItem, Me.ComputerHardwareToolStripMenuItem, Me.PersonalDataSystemToolStripMenuItem2})
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem1.Text = "&About"
        '
        'InTheSummerOf1980ToolStripMenuItem
        '
        Me.InTheSummerOf1980ToolStripMenuItem.Name = "InTheSummerOf1980ToolStripMenuItem"
        Me.InTheSummerOf1980ToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.InTheSummerOf1980ToolStripMenuItem.Text = "In the Summer of 1980 ..."
        '
        'PersonalBankingSystemVersonsToolStripMenuItem
        '
        Me.PersonalBankingSystemVersonsToolStripMenuItem.Name = "PersonalBankingSystemVersonsToolStripMenuItem"
        Me.PersonalBankingSystemVersonsToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.PersonalBankingSystemVersonsToolStripMenuItem.Text = "Personal Banking System versons"
        '
        'ComputerHardwareToolStripMenuItem
        '
        Me.ComputerHardwareToolStripMenuItem.Name = "ComputerHardwareToolStripMenuItem"
        Me.ComputerHardwareToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ComputerHardwareToolStripMenuItem.Text = "Computer Hardware"
        '
        'PersonalDataSystemToolStripMenuItem2
        '
        Me.PersonalDataSystemToolStripMenuItem2.Name = "PersonalDataSystemToolStripMenuItem2"
        Me.PersonalDataSystemToolStripMenuItem2.Size = New System.Drawing.Size(249, 22)
        Me.PersonalDataSystemToolStripMenuItem2.Text = "Personal Data System"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.GroupBox1.Controls.Add(Me.lblSelectOptionold)
        Me.GroupBox1.Controls.Add(Me.lblLogInOut)
        Me.GroupBox1.Controls.Add(Me.CmdExit)
        Me.GroupBox1.Controls.Add(Me.CmdLogout)
        Me.GroupBox1.Controls.Add(Me.CmdLogin)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.cboUserName)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(92, 463)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 107)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'lblSelectOptionold
        '
        Me.lblSelectOptionold.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSelectOptionold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectOptionold.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.lblSelectOptionold.Location = New System.Drawing.Point(318, 60)
        Me.lblSelectOptionold.Name = "lblSelectOptionold"
        Me.lblSelectOptionold.Size = New System.Drawing.Size(131, 36)
        Me.lblSelectOptionold.TabIndex = 8
        Me.lblSelectOptionold.Text = "Select an Option"
        Me.lblSelectOptionold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSelectOptionold.Visible = False
        '
        'lblLogInOut
        '
        Me.lblLogInOut.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblLogInOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogInOut.ForeColor = System.Drawing.Color.Red
        Me.lblLogInOut.Location = New System.Drawing.Point(209, 60)
        Me.lblLogInOut.Name = "lblLogInOut"
        Me.lblLogInOut.Size = New System.Drawing.Size(93, 36)
        Me.lblLogInOut.TabIndex = 7
        Me.lblLogInOut.Text = "Logged out"
        Me.lblLogInOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.LightGray
        Me.CmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.Location = New System.Drawing.Point(455, 58)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(93, 40)
        Me.CmdExit.TabIndex = 6
        Me.CmdExit.Text = "&Exit"
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdLogout
        '
        Me.CmdLogout.BackColor = System.Drawing.Color.LightGray
        Me.CmdLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLogout.Location = New System.Drawing.Point(110, 58)
        Me.CmdLogout.Name = "CmdLogout"
        Me.CmdLogout.Size = New System.Drawing.Size(93, 40)
        Me.CmdLogout.TabIndex = 5
        Me.CmdLogout.Text = "L&ogout"
        Me.CmdLogout.UseVisualStyleBackColor = False
        '
        'CmdLogin
        '
        Me.CmdLogin.BackColor = System.Drawing.Color.LightGray
        Me.CmdLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLogin.Location = New System.Drawing.Point(9, 58)
        Me.CmdLogin.Name = "CmdLogin"
        Me.CmdLogin.Size = New System.Drawing.Size(93, 40)
        Me.CmdLogin.TabIndex = 4
        Me.CmdLogin.Text = "&Login"
        Me.CmdLogin.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Gainsboro
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(322, 21)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(89, 25)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password:"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Gainsboro
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(11, 21)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(89, 25)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(422, 21)
        Me.txtPassword.Multiline = True
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(124, 25)
        Me.txtPassword.TabIndex = 1
        '
        'cboUserName
        '
        Me.cboUserName.DataSource = Me.UsersLiveBindingSource
        Me.cboUserName.DisplayMember = "UserName"
        Me.cboUserName.FormattingEnabled = True
        Me.cboUserName.Location = New System.Drawing.Point(112, 21)
        Me.cboUserName.Name = "cboUserName"
        Me.cboUserName.Size = New System.Drawing.Size(190, 24)
        Me.cboUserName.TabIndex = 0
        '
        'UsersLiveBindingSource
        '
        Me.UsersLiveBindingSource.DataMember = "Users"
        Me.UsersLiveBindingSource.DataSource = Me.VPBSDataSet
        Me.UsersLiveBindingSource.Sort = "UserName"
        '
        'VPBSDataSet
        '
        Me.VPBSDataSet.DataSetName = "VPBSDataSet"
        Me.VPBSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UsersTestBindingSource
        '
        Me.UsersTestBindingSource.DataMember = "Users"
        Me.UsersTestBindingSource.DataSource = Me.VPBSTestDataSet
        Me.UsersTestBindingSource.Sort = "UserName"
        '
        'VPBSTestDataSet
        '
        Me.VPBSTestDataSet.DataSetName = "VPBSTestDataSet"
        Me.VPBSTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UsersTestTableAdapter
        '
        Me.UsersTestTableAdapter.ClearBeforeFill = True
        '
        'UsersLiveTableAdapter
        '
        Me.UsersLiveTableAdapter.ClearBeforeFill = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmStartUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(738, 603)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StartUpPanel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmStartUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personal Data System"
        Me.StartUpPanel.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UsersLiveBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsersTestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VPBSTestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StartUpPanel As System.Windows.Forms.Panel
    Friend WithEvents CmdVideos As System.Windows.Forms.Button
    Friend WithEvents CmdMusic As System.Windows.Forms.Button
    Friend WithEvents CmdBooks As System.Windows.Forms.Button
    Friend WithEvents CmdAddresses As System.Windows.Forms.Button
    Friend WithEvents CmdFinance As System.Windows.Forms.Button
    Friend WithEvents CmdPBS As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchiveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrinterSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdLogin As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cboUserName As System.Windows.Forms.ComboBox
    Friend WithEvents CmdLogout As System.Windows.Forms.Button
    Friend WithEvents VPBSTestDataSet As VPBS13.VPBSTestDataSet
    Friend WithEvents UsersTestBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsersTestTableAdapter As VPBS13.VPBSTestDataSetTableAdapters.UsersTableAdapter
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents VPBSDataSet As VPBS13.VPBSDataSet
    Friend WithEvents UsersLiveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsersLiveTableAdapter As VPBS13.VPBSDataSetTableAdapters.UsersTableAdapter
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalDataSystemToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PostSOsOnAllActsConcurrentlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasswordsOnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLogInOut As System.Windows.Forms.Label
    Friend WithEvents lblSelectOptionold As System.Windows.Forms.Label
    Friend WithEvents lblSelectOption As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents InTheSummerOf1980ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonalBankingSystemVersonsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComputerHardwareToolStripMenuItem As ToolStripMenuItem
End Class
