using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Text.Encoding;

namespace DigitalContainer
{
    class DigitalContainer
    {
        private Dictionary<String, FileDetails> Files;
        private Int64 HeaderSize;

        public DigitalContainer()
        {
            this.Files = new Dictionary<String, FileDetails>();
        }

        public Dictionary<String, FileDetails> GetFiles()
        {
            return this.Files;
        }

        public void InsertFileInContainer(FileDetails FileDetailsObject)
        {
            if (this.Files.ContainsKey(FileDetailsObject.GetFileName()))
            {
                throw new Exception("File Already Exists In Container!");
            }
            else
            {
                this.Files.Add(FileDetailsObject.GetFileName(), FileDetailsObject);
            }
        }

        public void DeleteFileFronContainer(FileDetails FileDetailsObject)
        {
            if (this.Files.ContainsKey(FileDetailsObject.GetFileName()))
            {
                this.Files.Remove(FileDetailsObject.GetFileName());
            }
            else
            {
                throw new Exception("File Does Not Exist In Container!");
            }
        }

        public bool EncodeContainer(String ContainerFileName)
        {
            try
            {
                FileStream FileStreamObject = new FileStream(ContainerFileName, FileMode.Create);
                BinaryWriter BinaryWriterObject = new BinaryWriter(FileStreamObject, UTF8);
                BinaryWriterObject.Write(this.Files.Count);
                this.ComputeHeaderSize();
                for (int i = 0; i < this.Files.Count; i++)
                {
                    BinaryWriterObject.Write(this.Files.ElementAt(i).Value.GetFileName());
                    BinaryWriterObject.Write(this.Files.ElementAt(i).Value.GetFileSize());
                    Int64 FileOffset = this.ComputeFileOffset(i);
                    BinaryWriterObject.Write(FileOffset);
                }
                Console.WriteLine(BinaryWriterObject.BaseStream.Position);
                for (int i = 0; i < this.Files.Count; i++)
                {
                    Array.Reverse(this.Files.ElementAt(i).Value.GetFileData(), 0, (int)this.Files.ElementAt(i).Value.GetFileSize());
                    BinaryWriterObject.Write(this.Files.ElementAt(i).Value.GetFileData());
                }
                BinaryWriterObject.Close();
                FileStreamObject.Close();
                BinaryWriterObject.Dispose();
                FileStreamObject.Dispose();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public DigitalContainer(String ContainerFileName)
        {
            try
            {
                this.Files = new Dictionary<string, FileDetails>();
                FileStream FileStreamObject = new FileStream(ContainerFileName, FileMode.Open);
                BinaryReader BinaryReaderObject = new BinaryReader(FileStreamObject, UTF8);
                Int32 NumberOfFiles = BinaryReaderObject.ReadInt32();
                for (int i = 0; i < NumberOfFiles; i++)
                {
                    String FileName = BinaryReaderObject.ReadString();
                    Int64 FileSize = BinaryReaderObject.ReadInt64();
                    Int64 FileOfsset = BinaryReaderObject.ReadInt64();
                    FileDetails FileDetails = new FileDetails();
                    FileDetails.SetFileName(FileName);
                    FileDetails.SetFileSize(FileSize);
                    FileDetails.SetFileOffset(FileOfsset);
                    this.Files.Add(FileDetails.GetFileName(), FileDetails);
                }
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

        private void ComputeHeaderSize()
        {
            this.HeaderSize = 0;
            this.HeaderSize += sizeof(Int32);
            foreach (KeyValuePair<String, FileDetails> Pair in this.Files)
            {
                this.HeaderSize += System.Text.Encoding.UTF8.GetByteCount(Pair.Value.GetFileName()) + 1;
                this.HeaderSize += sizeof(Int64);
                this.HeaderSize += sizeof(Int64);
            }
        }

        private Int64 ComputeFileOffset(int FileIndex)
        {
            Int64 FileOffset = 0;
            FileOffset = this.HeaderSize;
            for (int i = 0; i < FileIndex; i++)
            {
                FileOffset += this.Files.ElementAt(i).Value.GetFileSize();
            }
            return FileOffset;
        }

        public bool ExtractContainer(String ContainerFileName, String PathToExtract)
        {
            try
            {
                foreach (KeyValuePair<String, FileDetails> Pair in this.Files)
                {
                    Pair.Value.WriteFile(ContainerFileName, PathToExtract, true);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}