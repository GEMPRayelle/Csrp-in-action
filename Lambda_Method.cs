using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    public int health = 0;
    
    //메서드는 람다식으로 다시 표현될 수 있다 
    //특히 메서드가 한줄에서 두줄 정도의 문장으로 구성된 경우, 동일한 작업을 하는 코드를 매우 간결하게 표현할 수 있다는 장점이 있습니다.
    public void RestoreHealth(int amount){
    	health += amount;
    }
    public bool IsDead() {
	    return (health <= 0);
    }

    //RestoreHealth()와 IsDead() 메서드 모두 람다식을통해 아래와 같이 표현할 수 있다
    public void RestoreHealth(int amount) => health += amount; //RestoreHealth(int amount)는 health += amount 으로 대응된다
    public bool IsDead() => (health <= 0);//IsDead()는 heath <= 0 으로 대응된다.

    //private타입의 변수
    private int mana;
    public int Mana {
	    get { return mana; }
	    set { mana = value; }
    }
    //변수처럼 동작하는 메서드인 프로퍼티도 람다 식으로 표현할 수 있다
    //프로퍼티 Mana의 get, set 접근자는 위에 mana변수를 감싸는 역할을 한다

    //아래 처럼 프로퍼티를 람다 식으로 표현하는 것은 개인의 선택이다
    public int Mana {
	    get => mana;
	    set => mana = value;
    }

    public bool IsDead {
	    get { return (mana <= 0); }
    }
    //IsDead 프로퍼티는 체력이 0보다 작다면 true, 크다면 false를 반환합니다.
    public bool IsDead => (health <= 0);
    //단 이 코드처럼 get만 존재하거나 한 두줄로만 이루어진 메서드 또는 프로퍼티에 경우 람다식으로 활용하는걸 추천함
}
