using System.Collections.Generic;

namespace Assignment6.Services
{
	/*
	* This class stores multiple lists of strings. Each list of strings can be looked up by a string key.
	*/
	public class MemoryDatabase : IDatabase
    {
		private Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

		public int Size { get { return data.Count; } }

		public void AddString(string key, string newData)
		{
			List<string> keyData;
			if (this.data.TryGetValue(key, out keyData))
			{
				keyData.Add(newData);
				return;
			}
			keyData = new List<string>() { newData };
			this.data.Add(key, keyData);
		}

		public IEnumerable<string> GetData(string key)
		{
			List<string> keyData;
			if (this.data.TryGetValue(key, out keyData))
			{
				return keyData;
			}
			return new List<string>();
		}

        int IDatabase.Size()
        {
            return this.Size;
        }
    }
}
