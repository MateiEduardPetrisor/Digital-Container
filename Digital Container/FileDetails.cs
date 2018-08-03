using System;
using System.IO;
using static System.Text.Encoding;

namespace DigitalContainer
{
    class FileDetails
    {
        private String FileName;
        private Int64 FileSize;
        private byte[] FileData;
        private Int64 FileOffset;

        public FileDetails()
        {
            this.FileData = null;
        }

        public FileDetails(String FilePath)
        {
            try
            {
                FileInfo FileInfoObject = new FileInfo(FilePath);
                this.FileName = FileInfoObject.Name;
                this.FileSize = FileInfoObject.Length;
                FileStream FileStreamObject = new FileStream(FilePath, FileMode.Open);
                BinaryReader BinaryReaderObject = new BinaryReader(FileStreamObject, UTF8);
                byte[] FileData = new byte[this.FileSize];
                BinaryReaderObject.Read(FileData, 0, (Int32)this.FileSize);
                this.FileData = FileData;
                BinaryReaderObject.Close();
                FileStreamObject.Close();
                BinaryReaderObject.Dispose();
                FileStreamObject.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public String GetFileName()
        {
            return this.FileName;
        }

        public Int64 GetFileSize()
        {
            return this.FileSize;
        }

        public byte[] GetFileData()
        {
            return this.FileData;
        }

        public void SetFileName(String FileName)
        {
            this.FileName = FileName;
        }

        public void SetFileSize(Int64 FileSize)
        {
            this.FileSize = FileSize;
        }

        public void SetFileData(byte[] FileData)
        {
            this.FileData = FileData;
        }


        public void SetFileOffset(Int64 FileOffset)
        {
            this.FileOffset = FileOffset;
        }

        public Int64 GetFileOffset()
        {
            return this.FileOffset;
        }

        public void ReadFileData(String ContainerFileName)
        {
            FileStream FileStreamObject = new FileStream(ContainerFileName, FileMode.Open);
            BinaryReader BinaryReaderObject = new BinaryReader(FileStreamObject, UTF8);
            BinaryReaderObject.BaseStream.Seek(this.FileOffset, SeekOrigin.Begin);
            byte[] FileData = new byte[this.FileSize];
            BinaryReaderObject.Read(FileData, 0, (Int32)this.FileSize);
            this.FileData = FileData;
            BinaryReaderObject.Close();
            FileStreamObject.Close();
            BinaryReaderObject.Dispose();
            FileStreamObject.Dispose();
        }

        public void WriteFile(String ContainerFileName, String Path, bool UseOriginalFileName)
        {
            try
            {
                this.ReadFileData(ContainerFileName);
                String PathToExtract = null;
                if (UseOriginalFileName)
                {
                    PathToExtract = Path + "\\Decoded_" + this.FileName;
                }
                else
                {
                    PathToExtract = Path;
                }
                FileStream FileStreamObject = new FileStream(PathToExtract, FileMode.Create);
                BinaryWriter BinaryWriterObject = new BinaryWriter(FileStreamObject, UTF8);
                Array.Reverse(this.FileData, 0, (int)this.FileSize);
                BinaryWriterObject.Write(this.FileData, 0, (Int32)this.FileSize);
                BinaryWriterObject.Close();
                FileStreamObject.Close();
                BinaryWriterObject.Dispose();
                FileStreamObject.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}