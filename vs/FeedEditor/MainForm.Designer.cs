﻿using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace ZeroInstall.FeedEditor
{
    partial class MainForm
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Foo")]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxNeedsTerminal = new System.Windows.Forms.CheckBox();
            this.textInterfaceURL = new Common.Controls.HintTextBox();
            this.lblInterfaceURL = new System.Windows.Forms.Label();
            this.checkedListCategory = new System.Windows.Forms.CheckedListBox();
            this.textHomepage = new Common.Controls.HintTextBox();
            this.lblHomepage = new System.Windows.Forms.Label();
            this.textDescription = new Common.Controls.HintTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.groupBoxIcon = new System.Windows.Forms.GroupBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.comboIconType = new System.Windows.Forms.ComboBox();
            this.textIconUrl = new Common.Controls.HintTextBox();
            this.lblIconUrlError = new System.Windows.Forms.Label();
            this.lblIconMime = new System.Windows.Forms.Label();
            this.btnIconPreview = new System.Windows.Forms.Button();
            this.btnIconRemove = new System.Windows.Forms.Button();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.btnIconAdd = new System.Windows.Forms.Button();
            this.listIconsUrls = new System.Windows.Forms.ListBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.textSummary = new Common.Controls.HintTextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.textName = new Common.Controls.HintTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabPageFeed = new System.Windows.Forms.TabPage();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.comboBoxMinInjectorVersion = new System.Windows.Forms.ComboBox();
            this.lblMinInjectorVersion = new System.Windows.Forms.Label();
            this.textFeedFor = new Common.Controls.HintTextBox();
            this.lblFeedFor = new System.Windows.Forms.Label();
            this.groupBoxExternalFeed = new System.Windows.Forms.GroupBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.textExtFeedLanguage = new Common.Controls.HintTextBox();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.comboBoxOS = new System.Windows.Forms.ComboBox();
            this.comboBoxCPU = new System.Windows.Forms.ComboBox();
            this.btnExtFeedsRemove = new System.Windows.Forms.Button();
            this.btnExtFeedsAdd = new System.Windows.Forms.Button();
            this.listBoxExtFeeds = new System.Windows.Forms.ListBox();
            this.lblExternalFeedURL = new System.Windows.Forms.Label();
            this.textExtFeedURL = new Common.Controls.HintTextBox();
            this.groupBoxSelectedFeed = new System.Windows.Forms.GroupBox();
            this.btnExtFeedLanguageAdd = new System.Windows.Forms.Button();
            this.btnExtFeedLanguageRemove = new System.Windows.Forms.Button();
            this.listBoxExtFeedLanguages = new System.Windows.Forms.ListBox();
            this.toolStrip.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.tabAdvanced.SuspendLayout();
            this.groupBoxExternalFeed.SuspendLayout();
            this.groupBoxSelectedFeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStrip.Location = new System.Drawing.Point(7, 6);
            this.toolStrip.Margin = new System.Windows.Forms.Padding(2);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(619, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::ZeroInstall.FeedEditor.Properties.Resources.NewButton;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.ToolStripButtonNewClick);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::ZeroInstall.FeedEditor.Properties.Resources.OpenButton;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonOpenClick);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::ZeroInstall.FeedEditor.Properties.Resources.SaveButton;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogFileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Controls.Add(this.tabPageFeed);
            this.tabControlMain.Controls.Add(this.tabAdvanced);
            this.tabControlMain.Location = new System.Drawing.Point(7, 34);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(616, 490);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxNeedsTerminal);
            this.tabPageGeneral.Controls.Add(this.textInterfaceURL);
            this.tabPageGeneral.Controls.Add(this.lblInterfaceURL);
            this.tabPageGeneral.Controls.Add(this.checkedListCategory);
            this.tabPageGeneral.Controls.Add(this.textHomepage);
            this.tabPageGeneral.Controls.Add(this.lblHomepage);
            this.tabPageGeneral.Controls.Add(this.textDescription);
            this.tabPageGeneral.Controls.Add(this.lblDescription);
            this.tabPageGeneral.Controls.Add(this.groupBoxIcon);
            this.tabPageGeneral.Controls.Add(this.lblCategory);
            this.tabPageGeneral.Controls.Add(this.textSummary);
            this.tabPageGeneral.Controls.Add(this.lblSummary);
            this.tabPageGeneral.Controls.Add(this.textName);
            this.tabPageGeneral.Controls.Add(this.lblName);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(608, 464);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxNeedsTerminal
            // 
            this.checkBoxNeedsTerminal.AutoSize = true;
            this.checkBoxNeedsTerminal.Location = new System.Drawing.Point(9, 434);
            this.checkBoxNeedsTerminal.Name = "checkBoxNeedsTerminal";
            this.checkBoxNeedsTerminal.Size = new System.Drawing.Size(98, 17);
            this.checkBoxNeedsTerminal.TabIndex = 28;
            this.checkBoxNeedsTerminal.Text = "needs Terminal";
            this.checkBoxNeedsTerminal.UseVisualStyleBackColor = true;
            // 
            // textInterfaceURL
            // 
            this.textInterfaceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textInterfaceURL.HintText = "URL to a remote interface";
            this.textInterfaceURL.Location = new System.Drawing.Point(9, 368);
            this.textInterfaceURL.Name = "textInterfaceURL";
            this.textInterfaceURL.Size = new System.Drawing.Size(591, 20);
            this.textInterfaceURL.TabIndex = 27;
            // 
            // lblInterfaceURL
            // 
            this.lblInterfaceURL.AutoSize = true;
            this.lblInterfaceURL.Location = new System.Drawing.Point(6, 352);
            this.lblInterfaceURL.Name = "lblInterfaceURL";
            this.lblInterfaceURL.Size = new System.Drawing.Size(74, 13);
            this.lblInterfaceURL.TabIndex = 26;
            this.lblInterfaceURL.Text = "Interface URL";
            // 
            // checkedListCategory
            // 
            this.checkedListCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListCategory.FormattingEnabled = true;
            this.checkedListCategory.Items.AddRange(new object[] {
            "Audio",
            "AudioVideo",
            "Development",
            "Education",
            "Game",
            "Graphics",
            "Network",
            "Office",
            "Settings",
            "System",
            "Utility",
            "Video"});
            this.checkedListCategory.Location = new System.Drawing.Point(481, 20);
            this.checkedListCategory.Name = "checkedListCategory";
            this.checkedListCategory.Size = new System.Drawing.Size(119, 64);
            this.checkedListCategory.Sorted = true;
            this.checkedListCategory.TabIndex = 25;
            // 
            // textHomepage
            // 
            this.textHomepage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textHomepage.HintText = "the URL of a web-page describing this interface in more detail";
            this.textHomepage.Location = new System.Drawing.Point(9, 407);
            this.textHomepage.Name = "textHomepage";
            this.textHomepage.Size = new System.Drawing.Size(592, 20);
            this.textHomepage.TabIndex = 24;
            // 
            // lblHomepage
            // 
            this.lblHomepage.AutoSize = true;
            this.lblHomepage.Location = new System.Drawing.Point(6, 391);
            this.lblHomepage.Name = "lblHomepage";
            this.lblHomepage.Size = new System.Drawing.Size(59, 13);
            this.lblHomepage.TabIndex = 23;
            this.lblHomepage.Text = "Homepage";
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.HintText = "a full description, which can be several paragraphs long";
            this.textDescription.Location = new System.Drawing.Point(9, 275);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(591, 74);
            this.textDescription.TabIndex = 22;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Description";
            // 
            // groupBoxIcon
            // 
            this.groupBoxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxIcon.Controls.Add(this.lblIcon);
            this.groupBoxIcon.Controls.Add(this.comboIconType);
            this.groupBoxIcon.Controls.Add(this.textIconUrl);
            this.groupBoxIcon.Controls.Add(this.lblIconUrlError);
            this.groupBoxIcon.Controls.Add(this.lblIconMime);
            this.groupBoxIcon.Controls.Add(this.btnIconPreview);
            this.groupBoxIcon.Controls.Add(this.btnIconRemove);
            this.groupBoxIcon.Controls.Add(this.iconBox);
            this.groupBoxIcon.Controls.Add(this.btnIconAdd);
            this.groupBoxIcon.Controls.Add(this.listIconsUrls);
            this.groupBoxIcon.Location = new System.Drawing.Point(9, 85);
            this.groupBoxIcon.Name = "groupBoxIcon";
            this.groupBoxIcon.Size = new System.Drawing.Size(591, 171);
            this.groupBoxIcon.TabIndex = 19;
            this.groupBoxIcon.TabStop = false;
            this.groupBoxIcon.Text = "Icon";
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(6, 16);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(42, 13);
            this.lblIcon.TabIndex = 6;
            this.lblIcon.Text = "Icon url";
            // 
            // comboIconType
            // 
            this.comboIconType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboIconType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIconType.FormattingEnabled = true;
            this.comboIconType.Items.AddRange(new object[] {
            "PNG",
            "ICO"});
            this.comboIconType.Location = new System.Drawing.Point(379, 32);
            this.comboIconType.Name = "comboIconType";
            this.comboIconType.Size = new System.Drawing.Size(76, 21);
            this.comboIconType.TabIndex = 18;
            // 
            // textIconUrl
            // 
            this.textIconUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textIconUrl.HintText = "";
            this.textIconUrl.Location = new System.Drawing.Point(9, 32);
            this.textIconUrl.Name = "textIconUrl";
            this.textIconUrl.Size = new System.Drawing.Size(364, 20);
            this.textIconUrl.TabIndex = 11;
            // 
            // lblIconUrlError
            // 
            this.lblIconUrlError.AutoSize = true;
            this.lblIconUrlError.ForeColor = System.Drawing.Color.Red;
            this.lblIconUrlError.Location = new System.Drawing.Point(6, 144);
            this.lblIconUrlError.Name = "lblIconUrlError";
            this.lblIconUrlError.Size = new System.Drawing.Size(0, 13);
            this.lblIconUrlError.TabIndex = 10;
            // 
            // lblIconMime
            // 
            this.lblIconMime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIconMime.AutoSize = true;
            this.lblIconMime.Location = new System.Drawing.Point(376, 16);
            this.lblIconMime.Name = "lblIconMime";
            this.lblIconMime.Size = new System.Drawing.Size(55, 13);
            this.lblIconMime.TabIndex = 17;
            this.lblIconMime.Text = "Icon Type";
            // 
            // btnIconPreview
            // 
            this.btnIconPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIconPreview.Location = new System.Drawing.Point(377, 59);
            this.btnIconPreview.Name = "btnIconPreview";
            this.btnIconPreview.Size = new System.Drawing.Size(78, 23);
            this.btnIconPreview.TabIndex = 8;
            this.btnIconPreview.Text = "Icon Preview";
            this.btnIconPreview.UseVisualStyleBackColor = true;
            this.btnIconPreview.Click += new System.EventHandler(this.BtnIconPreviewClick);
            // 
            // btnIconRemove
            // 
            this.btnIconRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIconRemove.Location = new System.Drawing.Point(377, 117);
            this.btnIconRemove.Name = "btnIconRemove";
            this.btnIconRemove.Size = new System.Drawing.Size(78, 23);
            this.btnIconRemove.TabIndex = 16;
            this.btnIconRemove.Text = "Remove";
            this.btnIconRemove.UseVisualStyleBackColor = true;
            this.btnIconRemove.Click += new System.EventHandler(this.btnIconListRemove_Click);
            // 
            // iconBox
            // 
            this.iconBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconBox.Location = new System.Drawing.Point(461, 21);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(120, 120);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 9;
            this.iconBox.TabStop = false;
            // 
            // btnIconAdd
            // 
            this.btnIconAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIconAdd.Location = new System.Drawing.Point(377, 88);
            this.btnIconAdd.Name = "btnIconAdd";
            this.btnIconAdd.Size = new System.Drawing.Size(78, 23);
            this.btnIconAdd.TabIndex = 15;
            this.btnIconAdd.Text = "Add";
            this.btnIconAdd.UseVisualStyleBackColor = true;
            this.btnIconAdd.Click += new System.EventHandler(this.btnIconListAdd_Click);
            // 
            // listIconsUrls
            // 
            this.listIconsUrls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listIconsUrls.FormattingEnabled = true;
            this.listIconsUrls.HorizontalScrollbar = true;
            this.listIconsUrls.Location = new System.Drawing.Point(9, 59);
            this.listIconsUrls.Name = "listIconsUrls";
            this.listIconsUrls.Size = new System.Drawing.Size(364, 82);
            this.listIconsUrls.TabIndex = 14;
            this.listIconsUrls.SelectedIndexChanged += new System.EventHandler(this.listIconsUrls_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(477, 4);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category";
            // 
            // textSummary
            // 
            this.textSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textSummary.HintText = "a short one-line description";
            this.textSummary.Location = new System.Drawing.Point(9, 59);
            this.textSummary.Name = "textSummary";
            this.textSummary.Size = new System.Drawing.Size(465, 20);
            this.textSummary.TabIndex = 12;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(6, 43);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(50, 13);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Summary";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.HintText = "a short name to identify the interface (e.g. \"Foo\")";
            this.textName.Location = new System.Drawing.Point(9, 20);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(465, 20);
            this.textName.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tabPageFeed
            // 
            this.tabPageFeed.Location = new System.Drawing.Point(4, 22);
            this.tabPageFeed.Name = "tabPageFeed";
            this.tabPageFeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFeed.Size = new System.Drawing.Size(608, 464);
            this.tabPageFeed.TabIndex = 1;
            this.tabPageFeed.Text = "Feeds";
            this.tabPageFeed.UseVisualStyleBackColor = true;
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.comboBoxMinInjectorVersion);
            this.tabAdvanced.Controls.Add(this.lblMinInjectorVersion);
            this.tabAdvanced.Controls.Add(this.textFeedFor);
            this.tabAdvanced.Controls.Add(this.lblFeedFor);
            this.tabAdvanced.Controls.Add(this.groupBoxExternalFeed);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(608, 464);
            this.tabAdvanced.TabIndex = 2;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // comboBoxMinInjectorVersion
            // 
            this.comboBoxMinInjectorVersion.FormattingEnabled = true;
            this.comboBoxMinInjectorVersion.Items.AddRange(new object[] {
            "*",
            "0.31\t          ",
            "0.32\t          ",
            "0.33\t          ",
            "0.34\t          ",
            "0.35\t          ",
            "0.36\t          ",
            "0.37\t          ",
            "0.38\t          ",
            "0.39\t          ",
            "0.40\t          ",
            "0.41          ",
            "0.41.1\t          ",
            "0.42\t          ",
            "0.42.1\t          ",
            "0.43\t          ",
            "0.44"});
            this.comboBoxMinInjectorVersion.Location = new System.Drawing.Point(9, 364);
            this.comboBoxMinInjectorVersion.Name = "comboBoxMinInjectorVersion";
            this.comboBoxMinInjectorVersion.Size = new System.Drawing.Size(93, 21);
            this.comboBoxMinInjectorVersion.Sorted = true;
            this.comboBoxMinInjectorVersion.TabIndex = 4;
            // 
            // lblMinInjectorVersion
            // 
            this.lblMinInjectorVersion.AutoSize = true;
            this.lblMinInjectorVersion.Location = new System.Drawing.Point(6, 348);
            this.lblMinInjectorVersion.Name = "lblMinInjectorVersion";
            this.lblMinInjectorVersion.Size = new System.Drawing.Size(102, 13);
            this.lblMinInjectorVersion.TabIndex = 3;
            this.lblMinInjectorVersion.Text = "min. Injector Version";
            // 
            // textFeedFor
            // 
            this.textFeedFor.HintText = "URL to an Interface";
            this.textFeedFor.Location = new System.Drawing.Point(9, 325);
            this.textFeedFor.Name = "textFeedFor";
            this.textFeedFor.Size = new System.Drawing.Size(591, 20);
            this.textFeedFor.TabIndex = 2;
            // 
            // lblFeedFor
            // 
            this.lblFeedFor.AutoSize = true;
            this.lblFeedFor.Location = new System.Drawing.Point(6, 309);
            this.lblFeedFor.Name = "lblFeedFor";
            this.lblFeedFor.Size = new System.Drawing.Size(91, 13);
            this.lblFeedFor.TabIndex = 1;
            this.lblFeedFor.Text = "Feed for Interface";
            // 
            // groupBoxExternalFeed
            // 
            this.groupBoxExternalFeed.Controls.Add(this.groupBoxSelectedFeed);
            this.groupBoxExternalFeed.Controls.Add(this.listBoxExtFeeds);
            this.groupBoxExternalFeed.Controls.Add(this.btnExtFeedsAdd);
            this.groupBoxExternalFeed.Controls.Add(this.btnExtFeedsRemove);
            this.groupBoxExternalFeed.Location = new System.Drawing.Point(9, 3);
            this.groupBoxExternalFeed.Name = "groupBoxExternalFeed";
            this.groupBoxExternalFeed.Size = new System.Drawing.Size(591, 303);
            this.groupBoxExternalFeed.TabIndex = 0;
            this.groupBoxExternalFeed.TabStop = false;
            this.groupBoxExternalFeed.Text = "External Feeds";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(6, 58);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 10;
            this.lblLanguage.Text = "Language";
            // 
            // textExtFeedLanguage
            // 
            this.textExtFeedLanguage.HintText = "xx-XX";
            this.textExtFeedLanguage.Location = new System.Drawing.Point(9, 74);
            this.textExtFeedLanguage.MaxLength = 5;
            this.textExtFeedLanguage.Name = "textExtFeedLanguage";
            this.textExtFeedLanguage.Size = new System.Drawing.Size(54, 20);
            this.textExtFeedLanguage.TabIndex = 9;
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(176, 98);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(29, 13);
            this.lblCPU.TabIndex = 8;
            this.lblCPU.Text = "CPU";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(176, 58);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(22, 13);
            this.lblOS.TabIndex = 7;
            this.lblOS.Text = "OS";
            // 
            // comboBoxOS
            // 
            this.comboBoxOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOS.FormattingEnabled = true;
            this.comboBoxOS.Location = new System.Drawing.Point(179, 74);
            this.comboBoxOS.Name = "comboBoxOS";
            this.comboBoxOS.Size = new System.Drawing.Size(73, 21);
            this.comboBoxOS.TabIndex = 6;
            // 
            // comboBoxCPU
            // 
            this.comboBoxCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCPU.FormattingEnabled = true;
            this.comboBoxCPU.Location = new System.Drawing.Point(179, 114);
            this.comboBoxCPU.Name = "comboBoxCPU";
            this.comboBoxCPU.Size = new System.Drawing.Size(75, 21);
            this.comboBoxCPU.TabIndex = 5;
            this.comboBoxCPU.SelectedIndexChanged += new System.EventHandler(this.comboBoxCPU_SelectedIndexChanged);
            // 
            // btnExtFeedsRemove
            // 
            this.btnExtFeedsRemove.Location = new System.Drawing.Point(510, 48);
            this.btnExtFeedsRemove.Name = "btnExtFeedsRemove";
            this.btnExtFeedsRemove.Size = new System.Drawing.Size(75, 23);
            this.btnExtFeedsRemove.TabIndex = 4;
            this.btnExtFeedsRemove.Text = "Remove";
            this.btnExtFeedsRemove.UseVisualStyleBackColor = true;
            this.btnExtFeedsRemove.Click += new System.EventHandler(this.btnExtFeedsRemove_Click);
            // 
            // btnExtFeedsAdd
            // 
            this.btnExtFeedsAdd.Location = new System.Drawing.Point(510, 19);
            this.btnExtFeedsAdd.Name = "btnExtFeedsAdd";
            this.btnExtFeedsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnExtFeedsAdd.TabIndex = 3;
            this.btnExtFeedsAdd.Text = "Add";
            this.btnExtFeedsAdd.UseVisualStyleBackColor = true;
            this.btnExtFeedsAdd.Click += new System.EventHandler(this.btnExtFeedsAdd_Click);
            // 
            // listBoxExtFeeds
            // 
            this.listBoxExtFeeds.FormattingEnabled = true;
            this.listBoxExtFeeds.Location = new System.Drawing.Point(6, 19);
            this.listBoxExtFeeds.Name = "listBoxExtFeeds";
            this.listBoxExtFeeds.Size = new System.Drawing.Size(498, 108);
            this.listBoxExtFeeds.TabIndex = 2;
            // 
            // lblExternalFeedURL
            // 
            this.lblExternalFeedURL.AutoSize = true;
            this.lblExternalFeedURL.Location = new System.Drawing.Point(6, 16);
            this.lblExternalFeedURL.Name = "lblExternalFeedURL";
            this.lblExternalFeedURL.Size = new System.Drawing.Size(56, 13);
            this.lblExternalFeedURL.TabIndex = 1;
            this.lblExternalFeedURL.Text = "Feed URL";
            // 
            // textExtFeedURL
            // 
            this.textExtFeedURL.HintText = "URL to an external feed";
            this.textExtFeedURL.Location = new System.Drawing.Point(9, 32);
            this.textExtFeedURL.Name = "textExtFeedURL";
            this.textExtFeedURL.Size = new System.Drawing.Size(564, 20);
            this.textExtFeedURL.TabIndex = 0;
            // 
            // groupBoxSelectedFeed
            // 
            this.groupBoxSelectedFeed.Controls.Add(this.listBoxExtFeedLanguages);
            this.groupBoxSelectedFeed.Controls.Add(this.btnExtFeedLanguageRemove);
            this.groupBoxSelectedFeed.Controls.Add(this.lblLanguage);
            this.groupBoxSelectedFeed.Controls.Add(this.btnExtFeedLanguageAdd);
            this.groupBoxSelectedFeed.Controls.Add(this.lblCPU);
            this.groupBoxSelectedFeed.Controls.Add(this.lblExternalFeedURL);
            this.groupBoxSelectedFeed.Controls.Add(this.textExtFeedURL);
            this.groupBoxSelectedFeed.Controls.Add(this.comboBoxCPU);
            this.groupBoxSelectedFeed.Controls.Add(this.lblOS);
            this.groupBoxSelectedFeed.Controls.Add(this.comboBoxOS);
            this.groupBoxSelectedFeed.Controls.Add(this.textExtFeedLanguage);
            this.groupBoxSelectedFeed.Location = new System.Drawing.Point(6, 133);
            this.groupBoxSelectedFeed.Name = "groupBoxSelectedFeed";
            this.groupBoxSelectedFeed.Size = new System.Drawing.Size(579, 162);
            this.groupBoxSelectedFeed.TabIndex = 3;
            this.groupBoxSelectedFeed.TabStop = false;
            this.groupBoxSelectedFeed.Text = "Selected Feed";
            // 
            // btnExtFeedLanguageAdd
            // 
            this.btnExtFeedLanguageAdd.Location = new System.Drawing.Point(9, 100);
            this.btnExtFeedLanguageAdd.Name = "btnExtFeedLanguageAdd";
            this.btnExtFeedLanguageAdd.Size = new System.Drawing.Size(75, 23);
            this.btnExtFeedLanguageAdd.TabIndex = 4;
            this.btnExtFeedLanguageAdd.Text = "Add";
            this.btnExtFeedLanguageAdd.UseVisualStyleBackColor = true;
            this.btnExtFeedLanguageAdd.Click += new System.EventHandler(this.btnExtFeedLanguageAdd_Click_1);
            // 
            // btnExtFeedLanguageRemove
            // 
            this.btnExtFeedLanguageRemove.Location = new System.Drawing.Point(9, 129);
            this.btnExtFeedLanguageRemove.Name = "btnExtFeedLanguageRemove";
            this.btnExtFeedLanguageRemove.Size = new System.Drawing.Size(75, 23);
            this.btnExtFeedLanguageRemove.TabIndex = 5;
            this.btnExtFeedLanguageRemove.Text = "Remove";
            this.btnExtFeedLanguageRemove.UseVisualStyleBackColor = true;
            // 
            // listBoxExtFeedLanguages
            // 
            this.listBoxExtFeedLanguages.FormattingEnabled = true;
            this.listBoxExtFeedLanguages.Location = new System.Drawing.Point(90, 58);
            this.listBoxExtFeedLanguages.Name = "listBoxExtFeedLanguages";
            this.listBoxExtFeedLanguages.Size = new System.Drawing.Size(67, 95);
            this.listBoxExtFeedLanguages.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(633, 533);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(325, 247);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zero Install Feed Editor";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBoxIcon.ResumeLayout(false);
            this.groupBoxIcon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.tabAdvanced.ResumeLayout(false);
            this.tabAdvanced.PerformLayout();
            this.groupBoxExternalFeed.ResumeLayout(false);
            this.groupBoxSelectedFeed.ResumeLayout(false);
            this.groupBoxSelectedFeed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageFeed;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSummary;
        private Common.Controls.HintTextBox textName;
        private Common.Controls.HintTextBox textSummary;
        private Common.Controls.HintTextBox textIconUrl;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnIconPreview;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label lblIconUrlError;
        private System.Windows.Forms.Button btnIconRemove;
        private System.Windows.Forms.Button btnIconAdd;
        private System.Windows.Forms.ListBox listIconsUrls;
        private System.Windows.Forms.Label lblIconMime;
        private System.Windows.Forms.ComboBox comboIconType;
        private System.Windows.Forms.GroupBox groupBoxIcon;
        private System.Windows.Forms.Label lblDescription;
        private Common.Controls.HintTextBox textDescription;
        private Common.Controls.HintTextBox textHomepage;
        private System.Windows.Forms.Label lblHomepage;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.CheckedListBox checkedListCategory;

        private static Image GetImageFromUrl(Uri url)
        {
            var fileRequest = (HttpWebRequest) WebRequest.Create(url);
            var fileReponse = (HttpWebResponse) fileRequest.GetResponse();
            Stream stream = fileReponse.GetResponseStream();
            return Image.FromStream(stream);
        }

        private Common.Controls.HintTextBox textInterfaceURL;
        private System.Windows.Forms.Label lblInterfaceURL;
        private System.Windows.Forms.GroupBox groupBoxExternalFeed;
        private System.Windows.Forms.CheckBox checkBoxNeedsTerminal;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.ComboBox comboBoxOS;
        private System.Windows.Forms.ComboBox comboBoxCPU;
        private System.Windows.Forms.Button btnExtFeedsRemove;
        private System.Windows.Forms.Button btnExtFeedsAdd;
        private System.Windows.Forms.ListBox listBoxExtFeeds;
        private System.Windows.Forms.Label lblExternalFeedURL;
        private Common.Controls.HintTextBox textExtFeedURL;
        private System.Windows.Forms.ComboBox comboBoxMinInjectorVersion;
        private System.Windows.Forms.Label lblMinInjectorVersion;
        private Common.Controls.HintTextBox textFeedFor;
        private System.Windows.Forms.Label lblFeedFor;
        private System.Windows.Forms.Label lblLanguage;
        private Common.Controls.HintTextBox textExtFeedLanguage;
        private System.Windows.Forms.GroupBox groupBoxSelectedFeed;
        private System.Windows.Forms.ListBox listBoxExtFeedLanguages;
        private System.Windows.Forms.Button btnExtFeedLanguageRemove;
        private System.Windows.Forms.Button btnExtFeedLanguageAdd;
    }
}

