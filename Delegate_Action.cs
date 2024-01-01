using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System을 선언해줘야 Action키워드를 사용할 수 있음 
using System;

public class Worker : MonoBehaviour
{
    //delegate타입 선언, 입력도 없고 리턴도 없는 함수를 대행해줄 수 있다
    delegate void Work();
    //새로운 delegate타입의 변수선언
    Work work;

    //void를 리턴하고 입력도 없는 함수를 대행할 delegate는 수없이 많기때문에
    //Work delegate를 지우고 Action이란 타입으로 대체 할 수 있다
    //리턴값이 없고 입력 값이 없는 delegate 타입이다
    Action worker; //delegate void Action()과 동일함

    void moveBricks() { Debug.Log("벽돌 옮기기"); }

    void digIn() { Debug.Log("땅을 파다"); }

    void Start(){
        work += moveBricks;
        work += digIn;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            work();
        }
    }
}
