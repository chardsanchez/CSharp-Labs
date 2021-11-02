using System;
using System.Collections;
using System.Collections.Generic;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruits = new Fruit[]{ new Fruit{ Name = "Apple"}};
            FruitCollection fruitList = new FruitCollection(fruits);
            // AppleCollection appleList = new AppleCollection();
            // FruitComparer fruitComparer = new FruitComparer();
            // AppleComparer appleComparer = new AppleComparer();
            // ListItems(appleList);
            // //SortFruits(appleComparer);
            // SortApples(fruitComparer);
        }
        // [MyMethod]
        // static void ListItems(IEnumerate<Fruit> items){}
        // static void ListApples(IEnumerate<Apple> apples){}
        // static void SortFruits(IMyComparer<Fruit> fruits){}
        // static void SortApples(IMyComparer<Apple> apples){}
    }

    // interface IEnumerate<out T>{
    //     T MyMethod();
    // }


    // interface IMyComparer<in T>{
    //     void AnotherMethod(T item);
    // }

    [Serializable()]
    [My("Name")]
    public class Fruit{
        public string Name{get; set;}
    }
    class Apple : Fruit{}

    class FruitCollection : IEnumerable {
            Fruit[] _fruits;
            public FruitCollection(Fruit[] fruits){
                _fruits = fruits;
            }
            public IEnumerator GetEnumerator() 
            {
                
                return new FruitEnumerator(_fruits);
            }

            [MyMethod]
            public void AnotherMethod(){}

            public string Name {get;set;}
    }

    class FruitEnumerator : IEnumerator {

            Fruit[] _fruits;
            int position = 0;

            public FruitEnumerator(Fruit[] fruits){
                _fruits = fruits;
            }
            public object Current{ 
                get
                {
                    return _fruits[position];
                } 
            }
            public bool MoveNext()
            { 
                position++;
                return position < _fruits.Length;
                }
            public void Reset(){ position = 0;}
    }
    // class AppleCollection : IEnumerate<Apple>{
    //         public Apple MyMethod(){ return new Apple();}
    // }
    // class FruitComparer : IMyComparer<Fruit>{ 
    //         public void AnotherMethod(Fruit item){}
    // }
    // class AppleComparer : IMyComparer<Apple>{
    //         public void AnotherMethod(Apple item){}
    // }

    [AttributeUsage(AttributeTargets.Class)]
    public class MyAttribute : Attribute
    {
        public MyAttribute(string name){}
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyMethodAttribute : Attribute{}

    [AttributeUsage(AttributeTargets.Property)]
    public class MyPropertyAttribute : Attribute{}
    

}
