using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


public class Delegate_Csharp{
    //델리게이트 정의 = 대신해줄 대행자를 명시한다(앞으로 탄생할 delegate들의 원형이됨)
    //아래는 float타입의 매개변수 2개를 받고 float타입을 리턴하는 함수만 대행해줄 수 있다
    delegate float Calculate(float a, float b);
    //델리게이트 타입의 변수를 생성
    Calculate onCalculate;

    void Start(){
        //대행할 기능을 onCalculate에 넣어준다
        onCalculate = Sum;
        // +나 -연산자로 등록하거나 제거가능
        onCalculate += Subtract;
        //onCalculate -= Subtract;

        //한번에 여러개를 대행해주면 리턴값은 마지막으로 추가된 기능의 리턴값만 가져오게 된다
        //여러개를 동시에 대행해도 여러개의 값을 동시에 리턴할 수는 없는게 유의할 점
        onCalculate += Multiply;
    }

    public float Sum(float a, float b){
        System.Console.WriteLine(a+b);
        return a+b;
    }

    public float Subtract(float a, float b){
        System.Console.WriteLine(a-b);
        return a-b;
    } 

    public float Multiply(float a, float b){
        System.Console.WriteLine(a*b);
        return a*b;
    }

    void Update() {
        onCalculate(1,10);
        //리턴 값도 가져올 수 있음
        System.Console.WriteLine("결과 값: " + onCalculate(1,10));
    }
}