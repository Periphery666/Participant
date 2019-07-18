//Visual Studio 2015
// .net 4.5
//Stas ryazanov
//+380501346717

using System.Collections;

namespace Test_Task
{
    interface IContainer : IEnumerable
    {
        int Count { get; }
        object this[int index] { get; set; }

    }
}
