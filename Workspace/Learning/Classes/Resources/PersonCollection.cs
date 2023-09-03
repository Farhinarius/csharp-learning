using System.Collections;
using System.Collections.Generic;

namespace Workspace.Learning.Classes.Resources
{
    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople =
            new Dictionary<string, Person>();

        // Этот индексатор возвращает объект лица на основе строкового индекса.
        public Person this[string name]
        {
            get => listPeople[name];
            set => listPeople[name] = value;
        }

        #region IEnumerator implementation

        public IEnumerator GetEnumerator()
        {
            return listPeople.GetEnumerator();
        }

        #endregion


    }

}
