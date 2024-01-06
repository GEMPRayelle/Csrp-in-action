using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    void Start(){
        Print<int>(30);
        Print<string>("hello");

        //대표적으로 GP가 제네릭문법을 사용해서 여러가지 타입에 대응할 수 있다
        GetComponent<RigidBody>();

        //컨테이너를 만들때 어떤 타입에 대해서 컨테이너를 만들지만 지정해주면된다
        Container<string> container = new Container<string>();
        container.messages = new string[3];

        container.messages[0] = "Hello";
        container.messages[1] = "World";
        container.messages[2] = "Generic";
        for(int i = 0; i < container.messages.Length; i++){
           Debug.Log(container.messages[i]);
        }
    }

    //출력을 int 타입에 대해서도 할 수 있지만 문자혹은 다른 타입에 대해서도 출력을 하려면
    //오버로딩을 하거나 각각의 이름을 가진 함수를 만들어서 파생형을 직접 정의해야한다
    public void Print(int inputMessage){
        Debug.Log(inputMessage);
    }

    //제네릭을 사용해서 여러가지 타입에 한번에 대응할 수 있게된다
    //<>안에 자신만의 가상의 타입의 이름을 아무렇게나 지어주면된다
    //Print함수가 T타입에 맞춰서 발동된다
    public void Print<T>(T inputMessage){
        Debug.Log(inputMessage);
    }

}

//이 클래스는 원래 string타입에 대해서만 사용할 수 있다 
//하지만 제네릭을 사용해서 T타입에 대해서 클래스를 사용할 수 있게 한다
public class Containe<T>{
    public string[] messages;
    public T[] messages1;

}