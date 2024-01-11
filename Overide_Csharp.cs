using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotator : MonoBehaviour 
{
    public float speed = 60f;

    void Update() {
        //Rotate를 정의하면 부모가 알아서 동작시키게 함
        Rotate();
    }

    /*[1] virtual 정의*/

    //virtual 키워드를 넣게되면 자식들이 재정의가 가능해진다
    //덮어쓰지않는다면 이 함수그대로 존재하게되고 덮어 씌우면 그 함수로 대체된다

    //abstact와는 달리 자식클래스에서 구현은 필수가 아닌 "선택"이다(구현안할시 부모의 함수를 사용)
    //static, abstract, private, override 키워드와는 [사용 불가]

    //virtual함수는 자식 클래스에서 new또는 override 키워드가 사용가능하다
    //-> override는 재정의를 하겠다는 "확장"의 의미, new는 기본 클래스를 숨긴다는 의미
    protected virtual void Rotate(){
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}

    /*[2] virtual 함수의 사용*/

class XRotator: BaseRotator{
    //보통 override 키워드를 사용
    protected override void Rotate(){
        //base 키워드를 사용하여 부모 클래스의 함수를 호출할 수 있다
        base.Rotate();
        transform.Rotate(speed*Time.deltaTime,0,0);
    }
}
class YRotator: BaseRotator{
    //new 키워드도 사용가능
    protected new void Rotate(){
        transform.Rotate(0,speed*Time.deltaTime,0);
    }
}
class ZRotator: BaseRotator{
    //오버라이딩하려면 함수의 형식이 같아야한다, 똑같은 규격을 지켜야함
    //override 키워드를 사용해야한다
    protected void Rotate(){
        //부모에서 작성한 Rotate함수를 쓰면서도 거기에 추가적인 코드를 덧붙이기 위한 코드
        base.Rotate();
        transform.Rotate(0,0,speed*Time.deltaTime);
        /*상속을 받은 ZRotator는 별다른 함수를 작성할 필요 없이 Rotate의 구현부분만 새로 정의해주면
        부모클래스 Update함수내에서 자동으로 Rotate를 실행하기때문에 간단하게 커스텀가능
        ->별개로 Update함수를 작성할 필요가 없다는 의미*/
    }   
}

class Monster{

    /*[3] virtual 함수의 예제*/

    //아래 4개의 객체에서는 Rotate가 잘 실행된다
    //사실상 각 클래스에 자기 자신을 인스턴스로 담으면 virtual의 사용의미가 없다(재정의가 필요가없음)
    BaseRotator baseRotator = new BaseRotator();
    XRotator xRotator = new XRotator();
    YRotator yRotator = new YRotator();
    ZRotator zRotator = new ZRotator();

    //단 상위클래스를 인스턴스로 담게될시

    //override를 한 XRotator만 재정의한 Rotate가 실행되고
    BaseRotator baseRotator1 = new XRotator();
    //new키워드를 사용한 YRotator는 상위 클래스의 Rotate를 실행하게된다
    //상위 클래스 객체에 담기게되면 하위 클래스가 아닌 사우이 클래스의 함수를 호출하는 의미가 된다 
    BaseRotator baseRotator2 = new YRotator();
    //new 키워드를 사용하지 않은 경우 new와 동일한 동작을 하게되어 상위 클래스의 함수를 호출하게 됨
    BaseRotator baseRotator3 = new ZRotator();



    /*[4] virtual 함수의 활용*/

    //결국 virtual와 override를 사용하여 재정의하는 이유는 상위 클래스 변수에 하위 클래스
    //인스턴스를 담을때, 하위 클래스의 함수를 호출하고 싶기 때문이다 ex)
    BaseRotator baseRotator4 = new XRotator();

    /*예를 들어 모든 몬스터가 Monster라는 하나의 클래스로 만들어지면 좋겠지만
    몬스터의 특징에 따라 상속을받아 하위 클래스로 만들어질 수 있다, 그리고 플레이어가 때렸을때
    해당 몬스터의 문구를 출력한다고 치면*/
    //해당 몬스터를 전부 오버로딩하여 별도로 호출해야하기에 이럴때 virtual을 사용한다
    void attack(Orc monster) => monster.hit();
    void attack(Elf monster) => monster.hit();
    void attack(Wolf monster) => monster.hit();

    //monster.hit()이 호출될때 Monster에 담긴 인스턴스별로 재정의되어있는 hit을 호출한다
    void attack(Monster monster) => monster.hit();
    //사실상 abstract(추상)과 interface로도 가능하지만 이 방법은 "선택적으로 재정의"가 가능하다는 점이 있다
    //모든 몬스터가 hit함수만 있는게 아니고, 재정의할 필요가 없는 함수도 있는 경우면 추상클래스를 사용하기가 어려워진다

}