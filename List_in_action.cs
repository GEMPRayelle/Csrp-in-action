using System;
using System.Collections.Generic;//리스트를 사용하기위해 이 네임스페이스를 선언해야함

namespace CsharpKitTest{
    class List_in_action
    {
        class Student{
            public int grade;
            public string name;
        }

        public int[] scores = new int[10];

        static void Main(string[] args){

            //배열같은 경우는 크기를 늘리기위해 다시 공간을 할당하면
            //기존에 있던 배열의 정보는 전부다 날아가고 새로 생성된다 -> 배열의 한계점(실시간 불가능)
            scores = new int[11];

            //리스트는 배열의 확장으로서 여러 게임 오브젝트를 한 번에 다룰수있다

            //리스트 선언 방식
            List<Student> students = new List<Student>();
            //생성자를 사용하여 초기화를 할 수 있다
            students.Add(new Student() { name = "rayelle", grade = 1});
            students.Add(new Student() { name = "hit", grade = 2});
            students.Add(new Student() { name = "stage", grade = 3});
            students.Add(new Student() { name = "yeonhwa", grade = 4});
            students.Remove(students[0]);//특정 요소를 리스트에서 제거가능
            students.RemoveAt(0);//특정위치에 있는 요소를 제거 인덱스값을 넣어야함

            //리스트는 배열형태이기에 foreach를 써서 반복문을 줄일 수 있다
            foreach (var item in students)
            {
                System.Console.WriteLine(item.name + " : " + item.grade);
            }
        }

    }
}