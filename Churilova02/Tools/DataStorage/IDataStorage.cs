using System.Collections.Generic;
using Churilova02.Models;

namespace Churilova02.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void Add(Person person);

        void Remove(Person person);

        void DoChanges();

        List<Person> PersonsList { get; }
    }
}
