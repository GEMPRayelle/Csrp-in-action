using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rayelle_Csharp_Test
{
    //[Attribute]
    //특정 클래스, 필드, 메서드 등에 추가적인 메타 데이터를 붙여주는 기능

    //사용자 지정 Attribute
    //System.Attribute를 상속받는 클래스를 만들면 됨
    class SerializedField : Attribute
    {
        string message;
        public SerializedField(string message) { this.message = message; }
    }

    class Monster
    {
        //어떤 Attribute를 클래스나 필드 혹은 메서드 등에 적용하려면 적용하려는 대상 위에 Atrribute를 써주면 됨
        [SerializedField("This field must be private")]
        //hp 변수에 SerializedFiled Attribute를 붙여줘서 추가적인 데이터를 덧붙여 주고 이를 런타임에 컴퓨터가 알 수 있음
        //hp 변수는 "This field must be private"라는 문자열이 담긴 message를 추가적으로 담고 있음
        public int      hp;
        private int     _attack;
        private float   _speed;

        void Attack() { }
    }
    //Attribute는 컴퓨터가 런타임에 참고하기 위해 사용되는 주석같은 느낌
    //대표적으로 [SerializedField]같은 Attribute는 필드가 private이더라도
    //유니티 에디터에서 UI를 열어주는 필드라고 유니티에 추가 정보를 주는 개념이다

    class Program
    {
        static void Main(string[] args)
        {
            Monster monster = new Monster();
            Type type = monster.GetType();
            FieldInfo[] fields = type.GetFields();

            var attributes = fields[0].GetCustomAttributes(); //"This field must be private"
        }
    }
}
