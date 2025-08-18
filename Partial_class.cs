using System;

namespace Rayelle_Csharp_Test
{
    class Program
    {
        //Partial Class: 클래스, 구조체, 메서드등 두 개 이상의 파일로 분할하는 것을 가능하게 만드는 기능
        //하나의 클래스를 여러 .cs 파일에 걸쳐서 정의할 수 있게 하는 키워드

        //ex) Calc_Add.cs 파일에서 클래스 정의
        public partial class Calculator
        {
            public void Add() { Console.WriteLine("add"); }
        }

        //ex) Calc_Sub.cs 파일에서 클래스 정의
        public partial class Calculator
        {
            public void Sub() { Console.WriteLine("sub"); }
        }

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            //두 클래스가 다른 파일에서 정의되어 있어도 Add,Sub 함수를 호출 가능
            calculator.Add();
            calculator.Sub();
        }
    }
}
