using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    //받는 사람이 있는 형태에 함수를 대행해주는 delegate선언
    public delegate void SendMessange(string reciever);
    SendMessange onSend;

    void sendMail(string reciever){ Debug.Log("Mail sent to: " + reciever); }
    void sendMoney(string reciever){ Debug.Log("Money sent to: " + reciever); }

    void Start(){
        onSend += sendMail;
        onSend += sendMoney;
        //람다함수는 이름이 없는 함수를 뜻한다(익명함수) 함수이면서 오브젝트이기도 함
        //여기저기 주고받고 변수에 저장할 수 있다. 즉석으로 함수를 만들어 저장할 수 있음

        //man이라는 입력을 받아서 그럴 어떻게 사용한지를 만들었지만 이름이 없다
        //man앞에 string으로 일일이 명시할 필요가 없음
        //람다표현식인 =>는 입력이 들어와서 오른쪽에서 처리한다는걸 의미
        onSend += man => Debug.Log("Assasinate " + man);

        //{}안에 두가지 기능이 들어갈때는 {}를 사용하여 둘다 넣을 수 있다
        //입력이 하나면 ()도 생략가능, 입력을 명시적으로 괄호로 사용하고 타입도 명시할 수 있다
        onSend += (string man) => {
            Debug.Log("Assasinate " + man); 
            Debug.Log("Hide Body "); 
        };
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            onSend("Rayelle");
        }
    }
}
