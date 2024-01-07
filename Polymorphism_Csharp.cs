using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    //다형성: 기본 형태에서 파생된 여러 가지 물건들을 기본 형태로서 한 방에 관리할 수 있음
    public string name;
    public float weight;
    public int year;

    public void Print(){
        Debug.Log(name + "| 몸무게: " + weight + "| 나이: " + year);
    }

    protected float GetSpeed(){
        //캡슐화
        //GetSpeed함수를 사용하는 자식클래스는 사용만하지 그 안에서 무슨일이 일어나는지 알 필요가 없다
        return CalcSpeed();
    }

    private float CalcSpeed(){
        return 100f/(weight * year);
    }
}

public class Dog: Animal{
    public void Hunt(){
        float speed = GetSpeed();
        Debug.Log(speed + "의 속도로 달려가서 사냥했다");

        weight += 10f;
    }
}

public class Cat: Animal{
    public void Stealth(){
        Debug.Log(name + "가 숨었다");
    }
}

public class Test{
    void Start() {
        Cat nate = new Cat();
        nate.name = "Nate";
        nate.weight = 1.5f;
        nate.year = 3;

        Dog jack = new Dog()
        jack.name = "jack"
        jack.weight = 5f;
        jack.year = 2;

        //Animal로서 기능하기에 Hunt함수를 사용할 수 없다
        //Hunt함수는 메모리상에 없어지는게 아니라 계속 올라가있지만 Animal로서 동작하기에 사용할 수 없는것뿐 
        Animal animalT = jack;

        //다형성의 이유
        //다양한 타입의 파생 형태가 있어도 한방에 Animal로서 관리해서 깔끔하게함
        Animal[] animals = new Animal[2];
        animals[0] = nate;
        animals[1] = jack;

        for (int i = 0; i < animals.Length; i++){
            animals[i].Print();
        }
        
    }
}