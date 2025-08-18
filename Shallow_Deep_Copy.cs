using System;
using System.Net;

namespace Rayelle_Csharp_Test
{
    class Program
    {
        //깊은 복사 전용 class
        public class Person
        {
            public string? _name;

            public Person DeepCopy()
            {
                return new Person { _name = this._name };
            }
        }

        static void Increase(int[] numbers) { numbers[0] = 10; }

        static void Main(string[] args)
        {
            //원본 배열
            int[] numbers = { 1, 2, 3, 4 };

            //numbers는 배열 객체를 참조하는 포인터라 참조 타입임
            //함수의 매개변수로 전달하면 배열의 참조가 전달되어 원본의 수정이 일어남
            Increase(numbers);

            //원본의 수정을 막으려면 얕은 복사를 통해 복사본을 전달해야함
            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(numbers[i]);

            #region 얕은 복사 (Shallow Copy)
            //struct타입의 배열, 리스트는 얕은 복사로도 깊은 복사의 역할을 수행 가능
            //하지만참조 타입의 경우 내부 객체의 참조만 복사한다. 원본과 복사본이 같은 객체를 가리킴

            //Clone()함수는 배열의 타입에따라 값의 복사 방식이 달라짐
            //값: struct(int, float, long, double, bool)
            //참조: class, string, array, object 등
            int[] clonenumbers = (int[])numbers.Clone();

            //얕은 복사를 통해 복사본의 변화가 일어나도 [원본에는 영향을 미치진 않음]
            Increase(clonenumbers);//clonenumbers: 10,2,3,4
            Console.WriteLine(string.Join(",", numbers));//numbers: 1,2,3,4


            Person[] original =
            {
                new Person { _name = "Rayelle" },
                new Person { _name = "Jaffna" }
            };
            Person[] shallowCopy = (Person[])original.Clone();

            //만약에 Class타입의 객체 배열 original을 얕은 복사로 복사본을 생성할시
            //배열 복사본은 객체 참조만 복사했기에 내부 객체(Person)을 공유하게 됨
            //-> 복사본의 수정이 일어날시 [원본에도 영향이 감]

            shallowCopy[0]._name = "Changed";
            Console.WriteLine(original[0]._name); // 결과: "Changed"
            #endregion


            #region 깊은 복사 (Deep Copy)
            //내부 객체까지 새로 복사해서 독립적인 복사본(객체를 새로)을 생성
            //클래스 타입에 경우 깊은 복사가 원본을 건드리지 않는 해결법

            //Deep Copy
            Person[] deepCopied = new Person[original.Length];
            for (int i = 0; i < original.Length; i++)
                deepCopied[i] = original[i].DeepCopy();

            //복사본 수정
            deepCopied[0]._name = "Minho";

            // 복사본의 수정이 일어나도 원본에는 영향이 없음
            foreach (var person in original)
                Console.WriteLine(person._name); // Rayelle, Jaffna

            #endregion

        }
    }
}
