using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*[1]싱글톤의 정의*/

    //static을 사용하는 대표적인 디자인패턴 -> 단 하나의 인스턴스만 존재하게 한다
    //"반드시" 클래스도 하나 인스턴스도 하나여야 하는게 보장되어야한다
    //GameManager같은 매니저급은 씬에 하나만 존재하기에 싱글톤이 가능


    /*[2]싱글톤의 사용법*/
    //씬을 아무리 이동시켜도 이 싱글톤 패턴을 사용할시 절대 파괴되지않음
    #region 싱글톤
    public static Test Inst{get; private set;}
    //public타입의 static으로 자기 클래스의 인스턴스를 만든다
    //다른곳에서 접근해서 수정못하도록 private set을 사용하는 property를 사용
    //get set property는 Inst를 내부적으로 변수를 만들어 변수처럼 사용하게함, 외부 클래스에서 읽을수있음
    void Awake(){
        if(Inst == null){
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    #endregion

    //Awake는 Start함수보다 빨라 초기화할때 유용
    void Awake() => Inst = this;//this는 자기 자신의 스크립트 = GetComponent<Test>()와 같음, 인스턴스화된걸 넣어야함



    /*[3]static의 추가 응용법*/

    //아래처럼 public으로 선언된 변수나 함수를 외부 클래스에서 접근하려면
    //Test.Inst.age 이런식으로 해야함, Inst까지 빼고싶을경우 static 키워드 사용
    public int age;
    public static void TestFunc() => {
        Inst.age = 3;
        Debug.Log("TestFunc 호출");
    }
}