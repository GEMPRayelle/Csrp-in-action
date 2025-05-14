using System;
using System.Reflection; //Reflection을 사용하기 위해 이 네임스페이스를 불러야함
/* Reflection Docs -> https://learn.microsoft.com/ko-kr/dotnet/csharp/advanced-topics/reflection-and-attributes/ */

namespace Rayelle_Csharp_Test
{
    class Program
    {
        class Monster
        {
            public int hp;
            protected int attack;
            private float moveSpeed;

            void Attack() { }
        }

        public enum Temp { }

        //Reflection: 컴파일시에 알 수 없었던 타입이나 멤버들을 찾아내고 사용할 수 있게 해주는 메커니즘
        //Reflection을 사용하면 객체의 이름, 모든 멤버, 이벤트 목록등 객체의 세부적인 정보들을 Runtime중에 가져와서 분석하고 사용할 수 있다
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            //모든 클래스들은 Object를 상속받는다. 그래서 모든 객체들은 Object 클래스에서 가지고 있는 함수들을 상속 받아 가지고 있음
            //Object 클래스의 GetType()함수를 통해 해당 객체의 Type을 리턴
            //type에는 monster가 참조하는 객체의 모든 정보를 가짐
            Type type = monster.GetType();

            //GetType() -> Runtime 시점, Object를 상속받는 객체 인스턴스의 Type을 알려주고
            //typeof() -> Compile 시점, 클래스 자체의 Type을 알려준다
            Type type1 = typeof(Monster);//Monster
            Type type2 = typeof(Temp); //Temp
            Type type3 = typeof(int); //Int32

            Console.WriteLine(type1.Name);
            Console.WriteLine(type2.Name);
            Console.WriteLine(type3.Name);


            //Type 클래스의 GetFields() -> 객체의 필드의 정보를 배열로 리턴
            //객체의 필드들을 FieldInfo 타입의 배열로 리턴해줌
            //FieldInfo 타입은 해당 필드의 정보를 담은 클래스
            //매개변수가 없을시 자동으로 public 필드들의 정보를 배열에 담아 리턴
            //BindingFlags 열거형 변수 + & 또는 | 연산자를 통해 제약된 조건으로 검색가능

            //Type 클래스의 GetConstructors() -> 객체의 생성자 목록을 배열로 리턴
            //Type 클래스의 GetMethods() -> 객체의 메서드들의 목록을 리턴
            //monster가 참조하는 객체에 대한 정보들을 가져옴
            FieldInfo[] fieldInfos = type.GetFields(
                //public이거나 NonPublic이거나 static이거나 Instance(메모리를 차지하는 인스턴스 멤버)인 조건에
                //해당하는 필드의 정보를 배열에 담게한다
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance);

            //* BindingFlags Enum Official Docs *
            //https://learn.microsoft.com/ko-kr/dotnet/api/system.reflection.bindingflags?view=net-5.0

            //FieldInfo 타입의 객체도 해당 필드의 정보를 볼 수 있는 여러 메서드와 프로퍼티를 가지고 있음
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                string access = "protected";
                //해당 필드가 public이면 ? true : false
                if (fieldInfo.IsPublic)
                    access = "public";
                //해당 필드가 private이면 ? true : false
                else if (fieldInfo.IsPrivate)
                    access = "private";

                //접근 지정자와, 필드의 자료형 이름, 필드의 이름을 출력
                Console.WriteLine($"{access} {fieldInfo.FieldType.Name} {fieldInfo.Name}");

                /* output
                Temp
                Int32
                public Int32 hp
                protected Int32 attack
                private Single moveSpeed
                */

            }
        }
    }
}
