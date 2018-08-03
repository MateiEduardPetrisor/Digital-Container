using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DigitalContainer
{
    public partial class MainForm : Form
    {
        private DigitalContainer DigitalContainerObject;
        private String SavedContainerFileName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DigitalContainerObject = null;
            this.SavedContainerFileName = null;
        }

        private void ButtonAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialogObject = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Multimedia Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG;*.MP3;*.WAW;*.WMA;*.FLAC)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG;*.MP3;*.WAW;*.WMA;*.FLAC",
            };
            if (OpenFileDialogObject.ShowDialog() == DialogResult.OK)
            {
                if (this.DigitalContainerObject == null)
                {
                    this.DigitalContainerObject = new DigitalContainer();
                }
                String[] FIleNames = OpenFileDialogObject.FileNames;
                foreach (String FileName in FIleNames)
                {
                    try
                    {
                        FileDetails File = new FileDetails(FileName);
                        this.DigitalContainerObject.InsertFileInContainer(File);
                        ListViewItem listViewItem = new ListViewItem(File.GetFileName());
                        listViewItem.SubItems.Add(File.GetFileSize() + "");
                        this.ListViewFilesToEncode.Items.Add(listViewItem);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            OpenFileDialogObject.Dispose();
        }

        private void ButtonEncode_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialogObject = new SaveFileDialog
            {
                DefaultExt = ".dc",
                AddExtension = true,
                Filter = "Digital Container Files (*.dc)|*.dc",
                Title = "Choose Where To Save The Container",
            };
            if (this.DigitalContainerObject != null)
            {
                if (SaveFileDialogObject.ShowDialog() == DialogResult.OK)
                {
                    if (this.DigitalContainerObject.GetFiles().Count > 0)
                    {
                        this.SavedContainerFileName = SaveFileDialogObject.FileName;
                        this.DigitalContainerObject.EncodeContainer(this.SavedContainerFileName);
                        MessageBox.Show("Encode Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Container Has No Files!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Add Files First To The Container!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SaveFileDialogObject.Dispose();
        }

        private void DecodeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListViewFilesInsideContainer.SelectedIndices.Count > 0)
            {
                String FileName = this.ListViewFilesInsideContainer.SelectedItems[0].SubItems[0].Text;
                if (this.DigitalContainerObject.GetFiles().TryGetValue(FileName, out FileDetails FileToDecode))
                {
                    SaveFileDialog SaveFileDialogObject = new SaveFileDialog
                    {
                        AddExtension = true,
                        Filter = "All Files (*.*)|*.*",
                        Title = "Choose Where To Extract The File!",
                        FileName = "Decoded_" + FileName,
                    };
                    if (SaveFileDialogObject.ShowDialog() == DialogResult.OK)
                    {
                        String Path = SaveFileDialogObject.FileName;
                        FileToDecode.WriteFile(this.SavedContainerFileName, Path, false);
                        this.ListViewFilesInsideContainer.Items.Remove(this.ListViewFilesInsideContainer.SelectedItems[0]);
                        this.DigitalContainerObject.DeleteFileFronContainer(FileToDecode);
                        MessageBox.Show("Decode Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select A File First!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonOpenContainer_Click(object sender, EventArgs e)
        {
            this.ClearDigitalContainer();
            OpenFileDialog OpenFileDialogObject = new OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = ".dc",
                Filter = "Digital Container Files (*.dc)|*.dc",
            };
            if (OpenFileDialogObject.ShowDialog() == DialogResult.OK)
            {
                this.SavedContainerFileName = OpenFileDialogObject.FileName;
                this.DigitalContainerObject = new DigitalContainer(OpenFileDialogObject.FileName);
                foreach (KeyValuePair<String, FileDetails> Pair in this.DigitalContainerObject.GetFiles())
                {
                    ListViewItem listViewItem = new ListViewItem(Pair.Value.GetFileName());
                    listViewItem.SubItems.Add(Pair.Value.GetFileSize() + "");
                    listViewItem.SubItems.Add(Pair.Value.GetFileOffset() + "");
                    this.ListViewFilesInsideContainer.Items.Add(listViewItem);
                }
                MessageBox.Show("Container Loaded!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonDecode_Click(object sender, EventArgs e)
        {
            if (this.DigitalContainerObject != null)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (this.DigitalContainerObject.GetFiles().Count > 0)
                    {
                        String FolderPath = folderBrowserDialog.SelectedPath;
                        this.DigitalContainerObject.ExtractContainer(this.SavedContainerFileName, FolderPath);
                        MessageBox.Show("Decode Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearDigitalContainer();
                    }
                    else
                    {
                        MessageBox.Show("Container Has No Files!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Container Not Loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ClearDigitalContainer();
        }

        private void AddFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialogObject = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Multimedia Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG;*.MP3;*.WAW;*.WMA;*.FLAC)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG;*.MP3;*.WAW;*.WMA;*.FLAC",
            };
            if (OpenFileDialogObject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.DigitalContainerObject == null)
                    {
                        this.DigitalContainerObject = new DigitalContainer();
                    }
                    String SelectedFile = OpenFileDialogObject.FileName;
                    FileDetails File = new FileDetails(SelectedFile);
                    this.DigitalContainerObject.InsertFileInContainer(File);
                    ListViewItem ListViewItem = new ListViewItem(File.GetFileName());
                    ListViewItem.SubItems.Add(File.GetFileSize() + "");
                    this.ListViewFilesToEncode.Items.Add(ListViewItem);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            OpenFileDialogObject.Dispose();
        }

        private void RemoveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ListViewFilesToEncode.SelectedIndices.Count > 0)
            {
                String FileName = this.ListViewFilesToEncode.SelectedItems[0].SubItems[0].Text;
                FileDetails FileToDelete;
                if (this.DigitalContainerObject.GetFiles().TryGetValue(FileName, out FileToDelete))
                {
                    this.DigitalContainerObject.DeleteFileFronContainer(FileToDelete);
                    this.ListViewFilesToEncode.Items.Remove(this.ListViewFilesToEncode.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("Select A File First!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearDigitalContainer();
        }

        private void ClearDigitalContainer()
        {
            if (this.DigitalContainerObject != null)
            {
                this.DigitalContainerObject.GetFiles().Clear();
                this.DigitalContainerObject = null;
                this.SavedContainerFileName = null;
                this.ListViewFilesToEncode.Items.Clear();
                this.ListViewFilesInsideContainer.Items.Clear();
                GC.Collect();
                GC.WaitForFullGCApproach();
            }
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            this.ClearDigitalContainer();
        }
    }
}