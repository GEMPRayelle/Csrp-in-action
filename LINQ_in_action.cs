using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;//LINQ를 사용하려면 이게 선언되어야 함

class LINQ_in_action{
    //LINQ(Langauge- INtergrated Query): 데이터를 읽고 정렬하는 등 질의 기능을 C#에서 사용할 수 있는 기술
    static void Main(string[] args){
        string[] strings = { "Apple", "Banana", "Car", "Angular", "Add",};

        /*[1] LINQ 식 버전*/

        var linqResult = from str in strings 
                        //쿼리 식은 from 절로 시작해야한다 from 절에는 다음 내용을 지정한다
                        //from은 중첩할 수 있다
                        //1. 쿼리 또는 하위 쿼리가 실행될 데이터 소스
                        //2. 소스 시퀀스의 각 요소를 나타내는 지역 범위 변수
                        //strings라는 배열에서 각각 하나를 선택해서 str에 담는다 
                        where str.Length == 0
                        //원하는 값을 추출하기 위한 조건
                        orderby str descending
                        //어떻게 정렬을 할지, ascending은 오름차순 descending은 내림차순
                        select str;
                        //데이터에서 str를 추출한다
    }
}
