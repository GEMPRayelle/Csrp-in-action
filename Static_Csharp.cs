using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public string nickName;
    public float weight;

    /*[1] static 의 정의*/

    //static은 모든 오브젝트들이 공유하는 단 하나의 변수
    //static 키워드는 개별 오브젝트에게 찍어내지않고 단 하나의 카운트를 사용하게함
    //처음부터 정적으로 메모리상에 하나만 올라가있어서 오브젝트를 찍어내도 static 변수는 같이 찍혀나올수없다
    //다이나믹(오브젝트가 찍혀나올 때마다 같이 찍혀나옴)과는 반대의 개념
    public static int count = 0;
    
    void Awake() { count += 1; }
    void Start() { Bark(); }
    public void Bark(){
        Debug.Log("모든 개들의 수: " + count);
        Debug.Log(nickName + ": Bark!");
    }

    /*[2] static 의 사용원리*/
    //static 변수는 클래스가 처음 사용되는 시점에 별도에 메모리 공간에 할당된다
    //static을 함수로 사용하는 경우는 개별 오브젝트와 상관없이 모든 친구들이 동시에 사용할수 있는 경우
    //static 함수는 static 변수만 참조가능하다
    /*객체가 생성될때 할당되는 인스턴스 변수는 static 함수내에서는 참조가 불가능함 
       => static 함수도 객체가 아닌 클래스에 소속되어있기때문*/
    public static void showAnimalType(){
        Debug.Log("이것은 개입니다");
    }
    //static 키워드를 사용할 경우 public타입일때는 다른 외부 클래스에서 객체를 생성하지않고도 바로 사용할 수 있다
    //객체를 참조하는게 아닌 클래스자체를 참조해서 static 변수나 함수를 호출해야함
    //Dog.count , Dog.showAnimalType같은 방식으로 바로 사용가능
}


    /*[3] static 의 응용*/

//유니티에서 static 클래스는 MonoBehaviour를 상속할수가없다 (static 클래스는 상속이 안됨)
public static class Test {
    //static 클래스는 "반드시" static 변수와 함수만 사용해야한다
    public static int age = 0;
    public static void StaticFunc(){ Debug.Log("StaticFunc"); }

    //특별한 경우에만 사용된다
    //1. C#에 확장 메서드
    public static bool IsNumeric(this string s){
        float output;
        //float으로 변환할 수 있으면 true를 반환함
        return float.TryParse(s, out output);
    }
    /*string으로 선언된 s라는 변수에 string클래스에 원래 있던 함수처럼
      s.IsNumeric 처럼 사용이 가능하다는 의미 */
}

//static 클래스가 메모리에 할당되는 시점은 처음 호출했을때이다
//게임을 시작했을때는 메모리에 올라가있지않고 호출할때 올라가며 게임이 종료되었을때 가비지 컬렉터에 의해 사라짐
public static class TransformExtensions{
    //transform에서 float x를 넣으면
    public static void SetPosition(this Transform transform, float x){
        var newPosition = new Vector3(x, transform.position.y, transform.position.z);
        //현재위치를 새 위치로 옮겨라
        transform.position = newPosition;
    }
}