using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract키워드를 붙이면 추상 클래스가 된다
//함수들에게 abstract 키워드를 붙일 수 있게됨
public abstract class BaseMonster : MonoBehaviour {
    /*자식에게 자기가 가진 필드나 함수를 상속시켜 주지만 동시에 자기 자신은 껍데기와 같아 
    인스턴스화 될 수 없다 -> 인터페이스랑 유사함*/
    //상속을 제한하는 sealed와는 같이 사용할 수 없음
    //※단 인터페이스는 내부에 값을 가질 수 없다(변수가 없음), 추상클래스는 어느정도 가능


    //변수나 Update함수처럼 실제 구현물도 어느정도 포함할 수 있다
    public float damage = 100f;

    void Update() {
    /*필요한 기능들만 자식들이 직접 오버라이딩해서 구현하도록하고 
    그 기능이 어떻게 동작하는지는 상위클래스인 BaseMonster가 알아서 취급하고있다*/
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }
    
    //virtual 키워드를 사용했다면 {}까지 필요하지만 추상 메서드에서는 구현부가 존재하지 않는다
    //추상메서드는 암시적으로 가상(virtual)함수다 -> 기본적인 동작은 가상함수와 같지만 abstract는 자식 클래스에서 "반드시" 구현해야한다
    //private, static, virtual 키워드와는 사용이 불가능
    public abstract void Attack();
}

class Goblin: BaseMonster{
    //반드시 추상클래스에 있는 추상함수들을 오버라이딩해서 구현해줘야한다
    public override void Attack(){
        Debug.Log("고블린이 공격했다. 데미지: " + damage);
    }
}