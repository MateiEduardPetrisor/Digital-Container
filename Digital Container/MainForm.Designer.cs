namespace DigitalContainer
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ContextMenuStripDecode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DecodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabEncode = new System.Windows.Forms.TabPage();
            this.ButtonAddFiles = new System.Windows.Forms.Button();
            this.ListViewFilesToEncode = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuStripEncode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonEncode = new System.Windows.Forms.Button();
            this.TabDecode = new System.Windows.Forms.TabPage();
            this.ButtonDecode = new System.Windows.Forms.Button();
            this.ButtonOpenContainer = new System.Windows.Forms.Button();
            this.ListViewFilesInsideContainer = new System.Windows.Forms.ListView();
            this.EncodedFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncodedFileOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl.SuspendLayout();
            this.ContextMenuStripDecode.SuspendLayout();
            this.TabEncode.SuspendLayout();
            this.ContextMenuStripEncode.SuspendLayout();
            this.TabDecode.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.ContextMenuStrip = this.ContextMenuStripDecode;
            this.TabControl.Controls.Add(this.TabEncode);
            this.TabControl.Controls.Add(this.TabDecode);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(785, 435);
            this.TabControl.TabIndex = 0;
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // ContextMenuStripDecode
            // 
            this.ContextMenuStripDecode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DecodeFileToolStripMenuItem});
            this.ContextMenuStripDecode.Name = "ContextMenuStripDecode";
            this.ContextMenuStripDecode.Size = new System.Drawing.Size(136, 26);
            // 
            // DecodeFileToolStripMenuItem
            // 
            this.DecodeFileToolStripMenuItem.Name = "DecodeFileToolStripMenuItem";
            this.DecodeFileToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.DecodeFileToolStripMenuItem.Text = "Decode File";
            this.DecodeFileToolStripMenuItem.Click += new System.EventHandler(this.DecodeFileToolStripMenuItem_Click);
            // 
            // TabEncode
            // 
            this.TabEncode.Controls.Add(this.ButtonAddFiles);
            this.TabEncode.Controls.Add(this.ListViewFilesToEncode);
            this.TabEncode.Controls.Add(this.ButtonEncode);
            this.TabEncode.Location = new System.Drawing.Point(4, 22);
            this.TabEncode.Name = "TabEncode";
            this.TabEncode.Padding = new System.Windows.Forms.Padding(3);
            this.TabEncode.Size = new System.Drawing.Size(777, 409);
            this.TabEncode.TabIndex = 0;
            this.TabEncode.Text = "Encode";
            this.TabEncode.UseVisualStyleBackColor = true;
            // 
            // ButtonAddFiles
            // 
            this.ButtonAddFiles.Location = new System.Drawing.Point(296, 386);
            this.ButtonAddFiles.Name = "ButtonAddFiles";
            this.ButtonAddFiles.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddFiles.TabIndex = 2;
            this.ButtonAddFiles.Text = "Add Files";
            this.ButtonAddFiles.UseVisualStyleBackColor = true;
            this.ButtonAddFiles.Click += new System.EventHandler(this.ButtonAddFiles_Click);
            // 
            // ListViewFilesToEncode
            // 
            this.ListViewFilesToEncode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize});
            this.ListViewFilesToEncode.ContextMenuStrip = this.ContextMenuStripEncode;
            this.ListViewFilesToEncode.FullRowSelect = true;
            this.ListViewFilesToEncode.Location = new System.Drawing.Point(0, 0);
            this.ListViewFilesToEncode.MultiSelect = false;
            this.ListViewFilesToEncode.Name = "ListViewFilesToEncode";
            this.ListViewFilesToEncode.Size = new System.Drawing.Size(777, 380);
            this.ListViewFilesToEncode.TabIndex = 1;
            this.ListViewFilesToEncode.UseCompatibleStateImageBehavior = false;
            this.ListViewFilesToEncode.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File Name";
            this.FileName.Width = 120;
            // 
            // FileSize
            // 
            this.FileSize.Text = "File Size";
            this.FileSize.Width = 120;
            // 
            // ContextMenuStripEncode
            // 
            this.ContextMenuStripEncode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.removeFileToolStripMenuItem,
            this.clearFormToolStripMenuItem});
            this.ContextMenuStripEncode.Name = "ContextMenuStripEncode";
            this.ContextMenuStripEncode.Size = new System.Drawing.Size(139, 70);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.AddFileToolStripMenuItem_Click);
            // 
            // removeFileToolStripMenuItem
            // 
            this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
            this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.removeFileToolStripMenuItem.Text = "Remove File";
            this.removeFileToolStripMenuItem.Click += new System.EventHandler(this.RemoveFileToolStripMenuItem_Click);
            // 
            // clearFormToolStripMenuItem
            // 
            this.clearFormToolStripMenuItem.Name = "clearFormToolStripMenuItem";
            this.clearFormToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.clearFormToolStripMenuItem.Text = "Clear Form";
            this.clearFormToolStripMenuItem.Click += new System.EventHandler(this.ClearFormToolStripMenuItem_Click);
            // 
            // ButtonEncode
            // 
            this.ButtonEncode.Location = new System.Drawing.Point(377, 386);
            this.ButtonEncode.Name = "ButtonEncode";
            this.ButtonEncode.Size = new System.Drawing.Size(75, 23);
            this.ButtonEncode.TabIndex = 0;
            this.ButtonEncode.Text = "Encode";
            this.ButtonEncode.UseVisualStyleBackColor = true;
            this.ButtonEncode.Click += new System.EventHandler(this.ButtonEncode_Click);
            // 
            // TabDecode
            // 
            this.TabDecode.Controls.Add(this.ButtonDecode);
            this.TabDecode.Controls.Add(this.ButtonOpenContainer);
            this.TabDecode.Controls.Add(this.ListViewFilesInsideContainer);
            this.TabDecode.Location = new System.Drawing.Point(4, 22);
            this.TabDecode.Name = "TabDecode";
            this.TabDecode.Padding = new System.Windows.Forms.Padding(3);
            this.TabDecode.Size = new System.Drawing.Size(777, 409);
            this.TabDecode.TabIndex = 1;
            this.TabDecode.Text = "Decode";
            this.TabDecode.UseVisualStyleBackColor = true;
            // 
            // ButtonDecode
            // 
            this.ButtonDecode.Location = new System.Drawing.Point(376, 386);
            this.ButtonDecode.Name = "ButtonDecode";
            this.ButtonDecode.Size = new System.Drawing.Size(105, 23);
            this.ButtonDecode.TabIndex = 2;
            this.ButtonDecode.Text = "Decode Container";
            this.ButtonDecode.UseVisualStyleBackColor = true;
            this.ButtonDecode.Click += new System.EventHandler(this.ButtonDecode_Click);
            // 
            // ButtonOpenContainer
            // 
            this.ButtonOpenContainer.Location = new System.Drawing.Point(277, 386);
            this.ButtonOpenContainer.Name = "ButtonOpenContainer";
            this.ButtonOpenContainer.Size = new System.Drawing.Size(93, 23);
            this.ButtonOpenContainer.TabIndex = 1;
            this.ButtonOpenContainer.Text = "Open Container";
            this.ButtonOpenContainer.UseVisualStyleBackColor = true;
            this.ButtonOpenContainer.Click += new System.EventHandler(this.ButtonOpenContainer_Click);
            // 
            // ListViewFilesInsideContainer
            // 
            this.ListViewFilesInsideContainer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EncodedFileName,
            this.EncodedFileSize,
            this.EncodedFileOffset});
            this.ListViewFilesInsideContainer.FullRowSelect = true;
            this.ListViewFilesInsideContainer.Location = new System.Drawing.Point(0, 0);
            this.ListViewFilesInsideContainer.MultiSelect = false;
            this.ListViewFilesInsideContainer.Name = "ListViewFilesInsideContainer";
            this.ListViewFilesInsideContainer.Size = new System.Drawing.Size(777, 380);
            this.ListViewFilesInsideContainer.TabIndex = 0;
            this.ListViewFilesInsideContainer.UseCompatibleStateImageBehavior = false;
            this.ListViewFilesInsideContainer.View = System.Windows.Forms.View.Details;
            // 
            // EncodedFileName
            // 
            this.EncodedFileName.Text = "File Name";
            this.EncodedFileName.Width = 120;
            // 
            // EncodedFileSize
            // 
            this.EncodedFileSize.Text = "File Size";
            this.EncodedFileSize.Width = 120;
            // 
            // EncodedFileOffset
            // 
            this.EncodedFileOffset.Text = "File Offset";
            this.EncodedFileOffset.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Digital Container";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.ContextMenuStripDecode.ResumeLayout(false);
            this.TabEncode.ResumeLayout(false);
            this.ContextMenuStripEncode.ResumeLayout(false);
            this.TabDecode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabEncode;
        private System.Windows.Forms.TabPage TabDecode;
        private System.Windows.Forms.ListView ListViewFilesToEncode;
        private System.Windows.Forms.Button ButtonEncode;
        private System.Windows.Forms.Button ButtonAddFiles;
        private System.Windows.Forms.ListView ListViewFilesInsideContainer;
        private System.Windows.Forms.Button ButtonDecode;
        private System.Windows.Forms.Button ButtonOpenContainer;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripDecode;
        private System.Windows.Forms.ToolStripMenuItem DecodeFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripEncode;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader EncodedFileName;
        private System.Windows.Forms.ColumnHeader EncodedFileSize;
        private System.Windows.Forms.ColumnHeader EncodedFileOffset;
        private System.Windows.Forms.ToolStripMenuItem clearFormToolStripMenuItem;
    }
}

