using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Stage1
{
    [TestFixture]
    public class EnumerableEnumeratorTests
    {
        [Test]
        public void EnumerableTest()
        {
            Key[] keys = new Key[3]
            {
                new Key("A", "black"),
                new Key("B", "black"),
                new Key("C", "black"),
            };

            Keyboard keyboard = new Keyboard(keys);

            foreach (Key item in keyboard)
            {
                Console.WriteLine(item.Name + " " + item.Color);
            }
        }

        [Test]
        public void EnumerableTest1()
        {
            Key[] keys = new Key[6]
            {
                new Key("Q", "white"),
                new Key("W", "white"),
                new Key("E", "white"),
                new Key("R", "white"),
                new Key("T", "white"),
                new Key("Y", "white")
            };

            Keyboard keyboard = new Keyboard(keys);

            IEnumerator enumerator = keyboard.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Key item = (Key)enumerator.Current;
                Console.WriteLine(item);
            }

            enumerator.Reset();
        }


        public class Key
        {
            public string Name { get; set; }
            public  string Color { get; set; }

            public Key(string name, string color)
            {
                Name = name;
                Color = color;
            }
        }

        public class Keyboard : IEnumerable
        {
            Key[] _keys;

            public Keyboard(Key[] keys)
            {
                if (keys != null)
                {
                    _keys = keys;
                }
                else throw new NullReferenceException();
            }

            public IEnumerator GetEnumerator()
            {
                return new KeyboardEnumerator(_keys);
            }
        }

        public class KeyboardEnumerator : IEnumerator
        {
            public string Name { get; set; }
            public string Color { get; set; }

            public KeyboardEnumerator(string name, string color)
            {
                Name = name;
                Color = color;
            }


            Key[] _keys;
            int _position = -1;

            public KeyboardEnumerator(Key[] keys)
            {
                _keys = keys;
            }

            public object Current
            {
                get
                {
                    if (_position == -1 || _position >= _keys.Length)
                        throw new InvalidOperationException();

                    return _keys[_position];
                }
            }

            public bool MoveNext()
            {
                if (_position < _keys.Length - 1)
                {
                    _position++;
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                _position = -1;
            }
        }

    }
}
