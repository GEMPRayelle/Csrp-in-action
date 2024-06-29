using System.Collections.Generic;


public class Nullable_System : MonoBehaviour {
    void Start(){
        int i = 2;
        float f = 3.14;
        //일반적인 값 타입에는 값을 넣을 수 있다
        bool b = null;
        //하지만 값 타입에는 null을 넣을 수는 없음

        //일반적으로 i,f같은 변수의 원시 타입은 struct형으로 메모리에서
        //스택에 할당되어 값으로서 저장이 된다

        //하지만 Transform 타입의 변수나 string 타입의 변수 같은 경우는
        //class가 원시 타입이라 힙에 할당되면서 스택에는 그 포인터를 가지고있다 
        //이런 클래스 형태인 참조형식인 것들은
        Transform transform = null;
        string s = null;
        //null을 넣어줄 수 있다, (원시형태가)struct 형태의 변수들에게는 불가능


        //값에도 null을 넣어 줄 수 있게 C#에서 만든 기능이 Nullable

        int? t = null;//?를 값형식 자료형 데이터 뒤에 붙여준다 
        Vector3 vec = null;

        //Nullable의 기본형 <>안에 있는건 제네릭
        System.Nullable<bool> myBool;

        if(t.HasValue){//Nullable일 경우 HasValue로 null이 아닌지 검사를 가능, t != null과 동일
            int tValue = t.Value;//t는 int? 라 그 Value를 반환시키면 int가 된다, 무조건 null체크를 받아야 함, 
            //t가 null이 아닐 경우에만 실행해야함, 아니면 에러 발생
            //int tValue = (int)t 랑 동일한 기능을 수행
            print(tValue);//그걸 int로 변환해서 출력할 수 있음
        }
        int tValue = t.GetValueOrDefault();
        //이걸 사용할시 null이 아니여도 에러가 안남(null일시 그 자료형의 기본값을 리턴 시켜주기 때문)
        int tValue = t ?? -1;//위랑 동일한 기능을 수행
        //t가 Nullable이라 조건을 판단해서 null이면 ?? 뒤에 값을 넣어줌
        
        t = t ?? -1;
        t ??= -1; //위랑 동일하게 연산 가능


        string s = "스트링 치즈";
        //string s = null; class 타입이라 null을 넣어줄 수 있음
        
        print(s.IndexOf('링'));//2가 출력
        //만약 s가 null이라면 출력이 안 됨
        print(s?.IndexOf('링'));
        //s가 null인지를 체크해서 null이면 뒷부분을 실행하지 않음, null이 출력됨
        print(s?.IndexOf('링') ?? -1);//-1이 출력됨
    }
}

namespace System
{
    //반환형식이 struct(값 형식), where T가 제네릭 T를 관리함, 값 형식만 가능함
    public struct Nullable<T> where T : struct
    {
        public Nullable(T value);

        public bool HasValue { get; }//값이 null이 아닌지 체크, 아니면 True, null이면 False
        public T Value { get; }//그 값을 리턴해줌 

        public override bool Equals(object other);
        public override int GetHashCode();
        public T GetValueOrDefault();//null일 경우 기본값을 리턴해줌, 매개변수가 없을 경우 int일 경우 기본값 0을 반환
        public T GetValueOrDefault(T defaultValue);//매개변수를 주면 그 값대로 기본값 리턴
        public override string ToString();

        public static implicit operator T?(T value);
        public static explicit operator T(T? value);
    }
}