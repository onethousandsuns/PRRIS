using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Lab3___Algorithmic_task_2.Handlers
{
    class RecordsHandler : IRecordsHandler
    {
        private readonly HashSet<string> _records;
        private readonly Dictionary<string, int> _substringsCounts;

        public RecordsHandler()
        {
            _records = new HashSet<string>();
            _substringsCounts = new Dictionary<string, int>();
        }

        public int GetSubstringEntriesCount( string requestedSubstring )
        {
            return _substringsCounts.TryGetValue(requestedSubstring, out int substringEntriesCount)
                ? substringEntriesCount
                : 0;
        }

        public bool AddNewRecord(string word)
        {
            bool isRecordAdded = _records.Add( word );

            if ( isRecordAdded )
            {
                foreach ( string substring in GetStringSubstrings( word ) )
                {
                    if ( _substringsCounts.ContainsKey( substring ) )
                    {
                        _substringsCounts[substring]++;
                    }
                    else
                    {
                        _substringsCounts.Add( substring, 1 );
                    }
                }
            }

            return isRecordAdded;
        }

        private List<string> GetStringSubstrings( string stringValue )
        {
            List<string> substringsList = new List<string>();
            for ( var i = 1; i <= stringValue.Length; ++i )
            {
                substringsList.Add( stringValue.Substring( 0, i ) );
            }

            return substringsList;
        }
    }
}
