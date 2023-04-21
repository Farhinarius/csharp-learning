using System;
using System.Collections;

namespace Workspace.Learning.Classes.Resources
{
    public class Garage : IEnumerable
    {
        private readonly Motorcycle[] _motorcycles = new Motorcycle[4];

        public int Length => _motorcycles.Length;
        
        public Garage()
        {
            _motorcycles[0] = new Motorcycle("Yamaha");
            _motorcycles[1] = new Motorcycle("Kurawa", 110);
            _motorcycles[2] = new Motorcycle("Sirogawa", 150);
            _motorcycles[3] = new Motorcycle("Kazekawa", 170);
            _motorcycles[4] = new Motorcycle("Ducati");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // delegate IEnumerator implementation to _motorcycles collection
            return _motorcycles.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var m in _motorcycles)
            {
                yield return m;
            }
        }
        
        // or can manually implement IEnumerator
        // public MotorcycleEnum GetEnumerator()
        // {
        //     return new MotorcycleEnum(_motorcycles);
        // }
        
        // IEnumerator implementation 
        // public object Current => ((IEnumerable) this).GetEnumerator().Current;
    }
    
    

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class MotorcycleEnum : IEnumerator
    {
        public Motorcycle[] Motorcycles;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        private int _position = -1;

        public MotorcycleEnum(Motorcycle[] list)
        {
            Motorcycles = list;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < Motorcycles.Length);
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
                    return Motorcycles[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        
    }
}