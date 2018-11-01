namespace Lab3___Algorithmic_task_2.Handlers
{
    interface IRecordsHandler
    {
        int GetSubstringEntriesCount( string substring );
        bool AddNewRecord( string word );
    }
}
