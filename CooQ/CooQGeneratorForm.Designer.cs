namespace CooQGenerate
{
  partial class CooQGeneratorForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CooQGeneratorForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.txtUser = new System.Windows.Forms.TextBox();
      this.txtDatabase = new System.Windows.Forms.TextBox();
      this.txtHost = new System.Windows.Forms.TextBox();
      this.btnLoadTable = new System.Windows.Forms.Button();
      this.txtConsole = new System.Windows.Forms.TextBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPreviewTemplate = new System.Windows.Forms.TabPage();
      this.btnBrowseSaveTo = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.txtSaveTo = new System.Windows.Forms.TextBox();
      this.txtPreview = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbSupportedTemplates = new System.Windows.Forms.ComboBox();
      this.cbDatabaseType = new System.Windows.Forms.ComboBox();
      this.btnGenerate = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tabEditTemplate = new System.Windows.Forms.TabPage();
      this.btnPreview = new System.Windows.Forms.Button();
      this.label8 = new System.Windows.Forms.Label();
      this.cbTemplateFiles = new System.Windows.Forms.ComboBox();
      this.spMain = new System.Windows.Forms.SplitContainer();
      this.rtbTemplate = new FastColoredTextBoxNS.FastColoredTextBox();
      this.rtbPreview = new FastColoredTextBoxNS.FastColoredTextBox();
      this.groupBox1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPreviewTemplate.SuspendLayout();
      this.tabEditTemplate.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
      this.spMain.Panel1.SuspendLayout();
      this.spMain.Panel2.SuspendLayout();
      this.spMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.rtbTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.rtbPreview)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.txtPort);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txtPass);
      this.groupBox1.Controls.Add(this.txtUser);
      this.groupBox1.Controls.Add(this.txtDatabase);
      this.groupBox1.Controls.Add(this.txtHost);
      this.groupBox1.Location = new System.Drawing.Point(12, 44);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(218, 151);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 69);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(26, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = "Port";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 119);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(30, 13);
      this.label6.TabIndex = 12;
      this.label6.Text = "Pass";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 95);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(29, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "User";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(66, 65);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(145, 20);
      this.txtPort.TabIndex = 13;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 42);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Database";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Host";
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(66, 116);
      this.txtPass.Name = "txtPass";
      this.txtPass.Size = new System.Drawing.Size(145, 20);
      this.txtPass.TabIndex = 3;
      // 
      // txtUser
      // 
      this.txtUser.Location = new System.Drawing.Point(66, 90);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new System.Drawing.Size(145, 20);
      this.txtUser.TabIndex = 2;
      // 
      // txtDatabase
      // 
      this.txtDatabase.Location = new System.Drawing.Point(66, 39);
      this.txtDatabase.Name = "txtDatabase";
      this.txtDatabase.Size = new System.Drawing.Size(145, 20);
      this.txtDatabase.TabIndex = 1;
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(66, 12);
      this.txtHost.Name = "txtHost";
      this.txtHost.Size = new System.Drawing.Size(145, 20);
      this.txtHost.TabIndex = 0;
      // 
      // btnLoadTable
      // 
      this.btnLoadTable.Location = new System.Drawing.Point(78, 201);
      this.btnLoadTable.Name = "btnLoadTable";
      this.btnLoadTable.Size = new System.Drawing.Size(75, 23);
      this.btnLoadTable.TabIndex = 1;
      this.btnLoadTable.Text = "Load Table";
      this.btnLoadTable.UseVisualStyleBackColor = true;
      this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
      // 
      // txtConsole
      // 
      this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtConsole.Location = new System.Drawing.Point(250, 63);
      this.txtConsole.Multiline = true;
      this.txtConsole.Name = "txtConsole";
      this.txtConsole.Size = new System.Drawing.Size(631, 213);
      this.txtConsole.TabIndex = 2;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPreviewTemplate);
      this.tabControl1.Controls.Add(this.tabEditTemplate);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(897, 313);
      this.tabControl1.TabIndex = 3;
      // 
      // tabPreviewTemplate
      // 
      this.tabPreviewTemplate.BackColor = System.Drawing.SystemColors.Control;
      this.tabPreviewTemplate.Controls.Add(this.btnBrowseSaveTo);
      this.tabPreviewTemplate.Controls.Add(this.label9);
      this.tabPreviewTemplate.Controls.Add(this.txtSaveTo);
      this.tabPreviewTemplate.Controls.Add(this.txtPreview);
      this.tabPreviewTemplate.Controls.Add(this.label2);
      this.tabPreviewTemplate.Controls.Add(this.cbSupportedTemplates);
      this.tabPreviewTemplate.Controls.Add(this.cbDatabaseType);
      this.tabPreviewTemplate.Controls.Add(this.btnGenerate);
      this.tabPreviewTemplate.Controls.Add(this.label1);
      this.tabPreviewTemplate.Controls.Add(this.btnLoadTable);
      this.tabPreviewTemplate.Controls.Add(this.txtConsole);
      this.tabPreviewTemplate.Controls.Add(this.groupBox1);
      this.tabPreviewTemplate.Location = new System.Drawing.Point(4, 22);
      this.tabPreviewTemplate.Name = "tabPreviewTemplate";
      this.tabPreviewTemplate.Padding = new System.Windows.Forms.Padding(3);
      this.tabPreviewTemplate.Size = new System.Drawing.Size(889, 287);
      this.tabPreviewTemplate.TabIndex = 0;
      this.tabPreviewTemplate.Text = "Main";
      // 
      // btnBrowseSaveTo
      // 
      this.btnBrowseSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowseSaveTo.Location = new System.Drawing.Point(811, 1);
      this.btnBrowseSaveTo.Name = "btnBrowseSaveTo";
      this.btnBrowseSaveTo.Size = new System.Drawing.Size(70, 23);
      this.btnBrowseSaveTo.TabIndex = 13;
      this.btnBrowseSaveTo.Text = "Browse";
      this.btnBrowseSaveTo.UseVisualStyleBackColor = true;
      this.btnBrowseSaveTo.Click += new System.EventHandler(this.btnBrowseSaveTo_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(266, 9);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(48, 13);
      this.label9.TabIndex = 12;
      this.label9.Text = "Save To";
      // 
      // txtSaveTo
      // 
      this.txtSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSaveTo.Location = new System.Drawing.Point(338, 3);
      this.txtSaveTo.Name = "txtSaveTo";
      this.txtSaveTo.Size = new System.Drawing.Size(455, 20);
      this.txtSaveTo.TabIndex = 11;
      // 
      // txtPreview
      // 
      this.txtPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.txtPreview.Location = new System.Drawing.Point(21, 220);
      this.txtPreview.Multiline = true;
      this.txtPreview.Name = "txtPreview";
      this.txtPreview.Size = new System.Drawing.Size(31, 49);
      this.txtPreview.TabIndex = 4;
      this.txtPreview.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(80, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Database Type";
      // 
      // cbSupportedTemplates
      // 
      this.cbSupportedTemplates.FormattingEnabled = true;
      this.cbSupportedTemplates.Location = new System.Drawing.Point(338, 35);
      this.cbSupportedTemplates.Name = "cbSupportedTemplates";
      this.cbSupportedTemplates.Size = new System.Drawing.Size(217, 21);
      this.cbSupportedTemplates.TabIndex = 7;
      this.cbSupportedTemplates.SelectedIndexChanged += new System.EventHandler(this.cbSupportedTemplates_SelectedIndexChanged);
      // 
      // cbDatabaseType
      // 
      this.cbDatabaseType.FormattingEnabled = true;
      this.cbDatabaseType.Location = new System.Drawing.Point(97, 20);
      this.cbDatabaseType.Name = "cbDatabaseType";
      this.cbDatabaseType.Size = new System.Drawing.Size(131, 21);
      this.cbDatabaseType.TabIndex = 9;
      // 
      // btnGenerate
      // 
      this.btnGenerate.Location = new System.Drawing.Point(559, 34);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new System.Drawing.Size(70, 23);
      this.btnGenerate.TabIndex = 6;
      this.btnGenerate.Text = "Generate";
      this.btnGenerate.UseVisualStyleBackColor = true;
      this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(266, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Templates";
      // 
      // tabEditTemplate
      // 
      this.tabEditTemplate.Controls.Add(this.btnPreview);
      this.tabEditTemplate.Controls.Add(this.label8);
      this.tabEditTemplate.Controls.Add(this.cbTemplateFiles);
      this.tabEditTemplate.Controls.Add(this.spMain);
      this.tabEditTemplate.Location = new System.Drawing.Point(4, 22);
      this.tabEditTemplate.Name = "tabEditTemplate";
      this.tabEditTemplate.Padding = new System.Windows.Forms.Padding(3);
      this.tabEditTemplate.Size = new System.Drawing.Size(889, 287);
      this.tabEditTemplate.TabIndex = 1;
      this.tabEditTemplate.Text = "Edit Template";
      this.tabEditTemplate.UseVisualStyleBackColor = true;
      // 
      // btnPreview
      // 
      this.btnPreview.Location = new System.Drawing.Point(235, 5);
      this.btnPreview.Name = "btnPreview";
      this.btnPreview.Size = new System.Drawing.Size(70, 23);
      this.btnPreview.TabIndex = 10;
      this.btnPreview.Text = "Preview";
      this.btnPreview.UseVisualStyleBackColor = true;
      this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(29, 12);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(67, 13);
      this.label8.TabIndex = 9;
      this.label8.Text = "Template file";
      // 
      // cbTemplateFiles
      // 
      this.cbTemplateFiles.FormattingEnabled = true;
      this.cbTemplateFiles.Location = new System.Drawing.Point(102, 7);
      this.cbTemplateFiles.Name = "cbTemplateFiles";
      this.cbTemplateFiles.Size = new System.Drawing.Size(127, 21);
      this.cbTemplateFiles.TabIndex = 8;
      this.cbTemplateFiles.SelectedIndexChanged += new System.EventHandler(this.cbTemplateFiles_SelectedIndexChanged);
      // 
      // spMain
      // 
      this.spMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.spMain.Location = new System.Drawing.Point(7, 37);
      this.spMain.Name = "spMain";
      // 
      // spMain.Panel1
      // 
      this.spMain.Panel1.Controls.Add(this.rtbTemplate);
      // 
      // spMain.Panel2
      // 
      this.spMain.Panel2.Controls.Add(this.rtbPreview);
      this.spMain.Size = new System.Drawing.Size(875, 241);
      this.spMain.SplitterDistance = 499;
      this.spMain.TabIndex = 1;
      // 
      // rtbTemplate
      // 
      this.rtbTemplate.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.rtbTemplate.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      this.rtbTemplate.AutoScrollMinSize = new System.Drawing.Size(122, 14);
      this.rtbTemplate.BackBrush = null;
      this.rtbTemplate.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      this.rtbTemplate.CharHeight = 14;
      this.rtbTemplate.CharWidth = 8;
      this.rtbTemplate.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.rtbTemplate.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.rtbTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtbTemplate.IsReplaceMode = false;
      this.rtbTemplate.Language = FastColoredTextBoxNS.Language.CSharp;
      this.rtbTemplate.LeftBracket = '(';
      this.rtbTemplate.LeftBracket2 = '{';
      this.rtbTemplate.Location = new System.Drawing.Point(0, 0);
      this.rtbTemplate.Name = "rtbTemplate";
      this.rtbTemplate.Paddings = new System.Windows.Forms.Padding(0);
      this.rtbTemplate.RightBracket = ')';
      this.rtbTemplate.RightBracket2 = '}';
      this.rtbTemplate.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.rtbTemplate.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("rtbTemplate.ServiceColors")));
      this.rtbTemplate.Size = new System.Drawing.Size(499, 241);
      this.rtbTemplate.TabIndex = 0;
      this.rtbTemplate.Text = "Source template";
      this.rtbTemplate.TextAreaBorder = FastColoredTextBoxNS.TextAreaBorderType.Single;
      this.rtbTemplate.Zoom = 100;
      this.rtbTemplate.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.rtbTemplate_TextChangedDelayed);
      this.rtbTemplate.Leave += new System.EventHandler(this.rtbTemplate_Leave);
      // 
      // rtbPreview
      // 
      this.rtbPreview.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.rtbPreview.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      this.rtbPreview.AutoScrollMinSize = new System.Drawing.Size(130, 14);
      this.rtbPreview.BackBrush = null;
      this.rtbPreview.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      this.rtbPreview.CharHeight = 14;
      this.rtbPreview.CharWidth = 8;
      this.rtbPreview.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.rtbPreview.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.rtbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtbPreview.IsReplaceMode = false;
      this.rtbPreview.Language = FastColoredTextBoxNS.Language.CSharp;
      this.rtbPreview.LeftBracket = '(';
      this.rtbPreview.LeftBracket2 = '{';
      this.rtbPreview.Location = new System.Drawing.Point(0, 0);
      this.rtbPreview.Name = "rtbPreview";
      this.rtbPreview.Paddings = new System.Windows.Forms.Padding(0);
      this.rtbPreview.RightBracket = ')';
      this.rtbPreview.RightBracket2 = '}';
      this.rtbPreview.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.rtbPreview.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("rtbPreview.ServiceColors")));
      this.rtbPreview.Size = new System.Drawing.Size(372, 241);
      this.rtbPreview.TabIndex = 1;
      this.rtbPreview.Text = "Preview template";
      this.rtbPreview.TextAreaBorder = FastColoredTextBoxNS.TextAreaBorderType.Single;
      this.rtbPreview.Zoom = 100;
      // 
      // CooQGeneratorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(897, 313);
      this.Controls.Add(this.tabControl1);
      this.Name = "CooQGeneratorForm";
      this.Text = "CooQ Generator";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPreviewTemplate.ResumeLayout(false);
      this.tabPreviewTemplate.PerformLayout();
      this.tabEditTemplate.ResumeLayout(false);
      this.tabEditTemplate.PerformLayout();
      this.spMain.Panel1.ResumeLayout(false);
      this.spMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
      this.spMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.rtbTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.rtbPreview)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtDatabase;
    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.Button btnLoadTable;
    private System.Windows.Forms.TextBox txtConsole;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabEditTemplate;
    private System.Windows.Forms.TextBox txtPreview;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.ComboBox cbSupportedTemplates;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbDatabaseType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.TabPage tabPreviewTemplate;
    private System.Windows.Forms.SplitContainer spMain;
    private FastColoredTextBoxNS.FastColoredTextBox rtbTemplate;
    private FastColoredTextBoxNS.FastColoredTextBox rtbPreview;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cbTemplateFiles;
    private System.Windows.Forms.Button btnPreview;
    private System.Windows.Forms.Button btnBrowseSaveTo;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txtSaveTo;
  }
}

