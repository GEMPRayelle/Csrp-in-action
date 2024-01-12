using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    /*[1] 인터페이스의 정의*/

    //인터페이스는 클래스의 형태를 디자인/정의 하는것
    //이 인터페이스를 상속받는 클래스에게 무조건 어떤 함수나 property를 만들도록 강제하는 장치

    //인터페이스는 클래스와 달리 "다중 상속"이 가능하다
    //인터페이스 자체로 변수를 생성해내진 못한다 (new)


    /*[2] 인터페이스를 사용하는 이유*/

    //만약 아이템을 얻고 OnTriggerEnter함수를 통해 충돌을 검사하여 아이템획득마다 특정기능을 시행하려고할때
    //아이템종류가 하나가 아니기때문에 아이템 종류가 늘어날때마다 계속 if문을 늘려가며 충돌검사를 시행해야한다
    //충돌한 상대방이 Item 종류면 무조건 Use라는 함수를 가지고 있다고 알고 있어야한다
    //그런데 인터페이스를 구현을 안하면 굳이 상대방이 Use라는 함수를 가지고 있는걸 아는데도 아이템종류 타입별로 if문을 쪼개서 작성해야함
    //이럴때 인터페이스를 사용하여 상속받는 클래스가 무조건 이 함수는 구현해야 한다고 명시해줘야한다

    /*[3] 인터페이스 생성 방법*/
    public interface IItem{//앞에 인터페이스를 뜻하는 I를 더 붙여줘야함
        void Use();//인터페이스는 내부를 구현하지 않는다

    }
}

//인터페이스를 상속
class GoldItem: MonoBehaviour, IItem {

    //이 클래스내에서 Use함수를 구현하지 않으면 에러가 발생
    public void Use(){
        Debug.Log("골드를 얻음");
        //Player타입의 오브젝트를 찾는다
        Player player = FindObjectOfType<Player>();
        player.gold += goldAmount;

        //오브젝트 씬내에서 비활성화
        gameOjbect.SetActive(false);
    }
    //인터페이스를 상속한 클래스에선 무조건 Use함수를 가지고 있는걸 알고있다
    //단 클래스들이 Use를 어떻게 구현하고 있는지는 각자 다르다 -> 동작이 다 다름

    //인터페이스는 그 클래스가 무슨 타입인지 관심이 없다 Use라는 함수를 가지고 있는지에만 관심이 있다
}

class Player{
    private void OnTriggerEnter2D(Collider2D other) {
        //인터페이스를 상속하면 매번 아이템종류마다 if문으로 검사할 필요가 없다
        GoldItem goldItem = other.GetComponent<GoldItem>();
        if(goldItem != null) => goldItem.Use();    

        //IItem으로서 가져올 수 있는지만 보면된다
        //충돌한 상대방이 어떤 타입인지 신경안쓰고 IItem으로서 가져와서 Use함수를 가지고있는지만 확인
        IItem item = other.GetComponent<IItem>();
        //item은 IItem을 상속받은 다른 클래스들의 변수나 고유한 기능은 사용못하고 구현하라고 시킨 함수는 무조건 사용가능
        if(item != null){
            //이런방식으로 일일이 타입을 체크할 필요가 없어짐
            item.Use();
        }

    }
}
