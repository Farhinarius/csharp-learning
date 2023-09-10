using System;
using System.Collections;
using System.Collections.Generic;

namespace Workspace.Learning.Classes.Resources.Vehicles
{
    public class Garage : IEnumerable<Vehicle>
    {
        // cannot change reference to memory for _vehicles
        private readonly List<Vehicle> _vehicles;      // mark memory of classes that IS Vehicle (a.k.a inherited) 

        public int Count => _vehicles.Count;

        public Garage()
        {
            _vehicles = new List<Vehicle>
            {
                new Car("Nissan R-34 Skyline", maxSpeed: 350),
                new Car("Nissan 350z", maxSpeed: 300),
                new Car("Mazda RX7", 170, 350),
                new Motorcycle("Kuragawa Z5", 110, 200),
                new Motorcycle("Sirogawa Z7", 150, 200),
                new Motorcycle("Ducati", 0, 250)
            };
        }

        public List<Vehicle> Vehicles
        {
            get => _vehicles;
        }

        // read/write access tier
        public Vehicle this[int index]
        {
            get => _vehicles[index];
            set => _vehicles[index] = value;
        }

        // read access tier
        // implicit IEnumerator<T> implementation
        public IEnumerator<Vehicle> GetEnumerator()
        {
            // delegate IEnumerator implementation to _vehicles collection
            return _vehicles.GetEnumerator();
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return _vehicles.GetEnumerator();
        //}

        // explicit IEnumerator implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            // recommended implementation:
            // this.GetEnumerator();

            // До первого прохода по элементам (или доступа к любому элементу или просто вызова этого метода)
            // никакой код в методе GetEnumerator ( ) не выполняется.
            // Таким образом, если до выполнения оператора yield возникает условие для исключения, то оно не будет сгенерировано при
            // первом вызове метода, а лишь во время первого вызова MoveNext()
            // Исключение не сгенерируется до тех пор, пока не будет вызван метод MoveNext().
            // uncomment below to test
            // throw new Exception("This won't get called");        
            foreach (var v in _vehicles)
            {
                yield return v;
            }
        }

        public IEnumerator CustomEnumeration()
        {
            foreach (var m in _vehicles)
            {
                yield return m;
            }
        }

        public IEnumerator GetFieldEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                yield return vehicle.Cost;
            }
        }

        // За счет перемещения yield return внутрь локальной функции, которая
        // возвращается из главного тела метода, операторы верхнего уровня (до возвращения
        // локальной функции) выполняются немедленно. Локальная функция выполняется при
        // вызове MoveNext().
        public IEnumerator GetEnumeratorProtected()
        {
            // Это исключение сгенерируется немедленно,
            throw new Exception("This will get called");
            return ActualImplementation();
            // Локальная функция и фактическая реализация IEnumerator.
            IEnumerator ActualImplementation()
            {
                foreach (var vehicle in _vehicles)
                {
                    yield return vehicle;
                }
            }
        }

        public IEnumerable GetTheVehicles(bool returnReversed)
        {
            // Выполнить проверку на предмет ошибок,
            return ActualImplementation();
            IEnumerable ActualImplementation()
            {
                // Возвратить элементы в обратном порядке,
                if (returnReversed)
                {
                    for (int i = _vehicles.Count; i != 0; i--)
                    {
                        yield return _vehicles[i - 1];
                    }
                }
                else
                {
                    // Возвратить элементы в том порядке, в каком они размещены в массиве,
                    foreach (var v in _vehicles)
                    {
                        yield return v;
                    }
                }
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