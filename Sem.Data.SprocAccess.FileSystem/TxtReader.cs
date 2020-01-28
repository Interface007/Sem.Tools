using System;
using System.IO;
using System.Threading.Tasks;

namespace Sem.Data.SprocAccess.FileSystem
{
    public class TxtReader : IReader
    {
        private readonly string fileName;

        private string[] fileLines;

        private int lineIndex = -1;

        private int resultIndex;

        public TxtReader(string fileName)
        {
            this.fileName = fileName;
            this.fileLines = File.ReadAllLines(fileName + ".txt");
        }

        public Task<bool> Read()
        {
            this.lineIndex++;
            return Task.FromResult(this.lineIndex < fileLines.Length - 1);
        }

        public Task<T> Get<T>(int index)
        {
            return Task.FromResult((T)Convert.ChangeType(this.fileLines[lineIndex + 1].Split('\t')[index], typeof(T)));
        }

        public Task NextResult()
        {
            this.resultIndex++;
            this.fileLines = File.ReadAllLines(fileName + $"+{this.resultIndex}.txt");
            return Task.CompletedTask;
        }

        public Task Close()
        {
            return Task.CompletedTask;
        }
    }
}