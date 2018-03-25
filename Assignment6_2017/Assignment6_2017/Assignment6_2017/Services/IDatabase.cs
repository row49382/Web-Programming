using System.Collections.Generic;

namespace Assignment6.Services
{
    public interface IDatabase
    {
        int Size();

        void AddString(string key, string newData);

        IEnumerable<string> GetData(string key);
    }
}