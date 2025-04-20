using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDepartment.CommonLibrary
{
    internal class PersonCollection : ICollection<Person>, INotifyCollectionChanged
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void Add(Person item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Person item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Person item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
