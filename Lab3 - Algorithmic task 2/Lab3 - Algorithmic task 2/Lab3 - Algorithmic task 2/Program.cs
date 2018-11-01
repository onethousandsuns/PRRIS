using System;
using System.Collections.Generic;
using System.Linq;
using Lab3___Algorithmic_task_2.Handlers;

namespace Lab3___Algorithmic_task_2
{
    class Program
    {
        // Задание - https://docs.google.com/document/d/1RFlHU-aAjaUwC9L7tBdaLY4t5VgQgChTajD632HXjHI/edit

        static void Main(string[] args)
        {
            Console.WriteLine("Simple notebook program.\n\n" +
                              "Write Add <somename> to add new entry\n" +
                              "Write Find <somename> to show word entries count\n" +
                              "Write Exit to terminate program\n");


            IRecordsHandler recordsHandler = new RecordsHandler();

            while (true)
            {
                string command = Console.ReadLine();
                if ( string.IsNullOrEmpty( command ) )
                {
                    continue;
                }

                List<string> parameters = command.Split().ToList();
                command = parameters[0].ToLower();
                string recordValue = parameters[1].ToLower();

                if ( command == "exit" )
                {
                    return;
                }
                else if ( command == "add")
                {
                    if ( recordsHandler.AddNewRecord( recordValue ) )
                    {
                        Console.WriteLine( String.Format( "<{0}> successfully added to records.", recordValue ) );
                        continue;
                    }
                    Console.WriteLine( String.Format( "<{0}> already exists in records.", recordValue ) );
                }
                else if ( command == "find" )
                {
                    Console.WriteLine( String.Format( "<{0}> has {1} entries.", recordValue, recordsHandler.GetSubstringEntriesCount( recordValue ) ) );
                    continue;
                }
            }

        }
    }
}
