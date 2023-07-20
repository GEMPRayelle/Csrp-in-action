using System;

namespace CsharpKitTest{

    class List_in_action
    {
        class Student{
            public int grade;
            public string name;
        }

        static void Main(string[] args){
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