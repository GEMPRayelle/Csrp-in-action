using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //은닉성을 위해서 private으로 선언된 age변수
    private int age;

    //private인 age를 접근하기위해선 함수를만들어 리턴하거나 값을 대입하여 수정해야함
    //다른 클래스에서 접근할때는 아래함수들을 사용해서 접근해야함
    public int getAge() { return age; }
    public void setAge(int num) { age = num; }

    //C#에서는 이렇게 긴 함수를 선언하는거보다 get set Property를 지원하게 되어 이걸 사용하는게 더 용이함
    public int Age{ get{ return age; } set{ age = value; } }
    //get에는 int age = test(객체).Age 이런식으로 사용되고
    //set은 값을 저장할때 즉, test.Age = 26; 처럼 사용될때 set이 사용됨

    //*다만 만약 Age프로퍼티안에 변수age를 오타를내어 프로퍼티이름인 Age와 똑같이 해버리면 무한루프에 빠지게된다
    //자기를 읽었는데 계속 자기를 읽어들이기때문에 무한루프에 빠지게된다

    public int Age{ get; set; }
    //따로 소문자로된 변수가 없으면 이렇게 축약도 가능함

    public int Age{ get; private set; }
    //set을 private으로 하면 자기 클래스내에서만 age를 set할수있고 다른 클래스에선 접근이 안됨

    public int Age{ get; }//만약 get만 있게되면 읽기만 가능해서 값을 넣거나 대입할 수 없다 그럼 초기값으로는 0이 된다
    public int Age{ get; } = 5;//단 이런식으로 처음부터 초기화가 가능하다
    public int Age => 5; //get을 지우고 이런식으로 표현가능한데 위랑 똑같은 getter다

     public int Age{ get => age; private set => age = value; }
     //이 코드처럼 get과 set의 문구가 하나뿐이라면 
     //return age를   get => age , private set또는 set은 중괄호를 생략하고 위처럼 대입할 수 있음



    //만약 아래처럼 set을 3번을 실행하게되면
    test.Age = 26; test.Age = 22; test.Age = 25;
    public int Age{ 
        get{return age; } 
        set{ 
            age = value; 
            //마치 이벤트를 받는것 처럼 age가 바뀔때마다 age를 넘겨줄수있다
            onAgeChanged(value);
        } 
    }
    //
    void onAgeChanged(int _age){
        Debug.Log($"{_age} 나이 변화");
    }
}
