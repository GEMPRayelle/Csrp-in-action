using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    //void형태를 반환하고 입력으로 Event라는 타입을 받는 함수를 대행하는 delegate형을 선언함
    public delegate void Boost(Event target);

    //delegate자체는 public 변수임
    public Boost playerBoost;


    //이벤트는 이벤트를 제공하는 Publisher와 그 기능을 사용하는 Subscriber 2개로 나눠서 오브젝트 사이에 커플링을 낮춰준다
    //event 키워드를 사용함으로써 더 엄격하게 delegate를 이벤트에 맞춰 사용할 수 있다

    //event 키워드를 넣게되면 Booster스크립트에서 추가, 제거만 가능하고 덮어쓰기는 불가능함(에러출력)
    //delegate의 기능이 "이벤트"가 아닌 방향으로 작성되는것을 막아주는 역할을 함
    //또한 Booster스크립트에서 player.playerBoost(player); 같이 Event밖에서 이벤트가 임의로 발동되지않게 한다
    public event Boost playerBoost1;

    public string playerName = "Rayelle";

    public float hp = 100;
    public float defense = 50;
    public float damage = 30;

    void Start() {
        //델리게이트에 담긴 기능을 이 객체가 수행한다
        playerBoost(this);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            playerBoost(this);
        }
    }

    /*Booster 스크립트 (함수들)
    public void healthBoost(Event target){
        Debug.Log(target.playerName + "의 체력을 강화함");
        target.hp += 10;
    }

    public void shieldBoost(Event target){
        Debug.Log(target.playerName + "의 방어력을 강화함");
        target.defense += 10;
    }

    public void damageBoost(Event target){
        Debug.Log(target.playerName + "의 공격력을 강화함");
        target.damage += 10;
    }

    void Awake() {
        Event player = FindObjectOfType<Event>();
        player.playerBoost += healthBoost;
        player.playerBoost += shieldBoost;
        player.playerBoost += damageBoost;
        
        
    }
        만약 += damageBoost가 아니라
        단순히 = damageBoost로 해버리면 덮어쓰기가되서 playerBoost에 여태까지
        추가한 기능들이 날아가버리고 damageBoost만 남게된다
    */
}
