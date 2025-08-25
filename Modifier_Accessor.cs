using System;
using System.Collections.Generic;

namespace Rayelle_Csharp_Test
{
    public class User
    {
        //[required 필수 한정자]: 객체 초기화시 반드시 초기화 되어야 하는 필드들
        
        //접근 제어자도 클래스에 맞게 지정되어야 한다
        public required string _name;
        public required int? _age;

        //[Init 키워드]: 한번 초기화시 불변성을 지원하는 기능
        public string? UUID { get; init; } //한번 설정되면 절대 지워지지 않아야 하는 프로퍼티에 사용

        //Obsolete Attribute: 코드를 더이상 사용하지 않도록 표시해준다
        [Obsolete] 
        public void GetUUID()
        {
            Console.WriteLine($"user uuid: {UUID}");
        }

        public User() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //초기화를 null로 해도 상관없음
            User user = new User { _name = "rayelle", _age = null};

            //user.UUID = "20"; //[Compile error -> init 키워드를 사영한 필드의 값 변경 불가능]
            
            user.GetUUID(); //Obsolete가 붙은 함수는 사용이 불가능함
        }
    }
}
