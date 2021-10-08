using System;
using System.Collections;

namespace Workspace.Learning.ObjectsEssence.Resources
{
    public class Garage : IEnumerable
    {
        private Motorcycle[] _motorcycles = new Motorcycle[4];

        public int Length => _motorcycles.Length;
        
        public Garage()
        {
            _motorcycles[0] = new Motorcycle("Yamaha");
            _motorcycles[1] = new Motorcycle("Kurawa", 110);
            _motorcycles[2] = new Motorcycle("Sirogawa", 150);
            _motorcycles[3] = new Motorcycle("Kazekawa", 170);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // delegate IEnumerator implementation to _motorcycles collection
            return _motorcycles.GetEnumerator();
        }

        // public MotorcycleEnum GetEnumerator()
        // {
        //     // or can manually implement IEnumerator
        //     return new MotorcycleEnum(_motorcycles);
        // }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < _motorcycles.Length; i++)
            {
                yield return _motorcycles[i];
            }
        }
        
        // IEnumerator implementation 
        // public object Current => ((IEnumerable) this).GetEnumerator().Current;
    }
    
    

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class MotorcycleEnum : IEnumerator
    {
        public Motorcycle[] _motorcycles;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        private int _position = -1;

        public MotorcycleEnum(Motorcycle[] list)
        {
            _motorcycles = list;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _motorcycles.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;

        public Motorcycle Current
        {
            get
            {
                try
                {
                    return _motorcycles[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        
    }
}