using System;

/// <summary>
/// 클래스 = 참조형의 자료형(주소 기반, 주소가 할당되어있다), 원하는 새로운 자료형 정의
/// 객체는 힙에 저장된다
/// </summary>
class Car{
    //접근 수정자는 주로 public, private, internal, protected 를 사용
    //인스턴스 변수 선언 [접근 제한자] [자료형] [이름];
    public int carNumber;
    public DateTime inTime;
    public DateTime outTime;
    int Money;
    public void SetInTime(){
        this.inTime = DateTime.Now;
    }
    public void SetOutTime(){
        //this 키워드는 클래스의 현재 인스턴스(객체)를 가리키고, 
        //확장 메서드에 대해 첫 번째 매개 변수에 대한 한정자로 사용한다
        this.outTime = DateTime.Now;
    }
    public void GetMoney(int Money){
        //GetMoney의 매개변수 Money와 this.Money는 다르며 int Money와 = Money;가 같은 변수다
        //차이점을 명확하게 표기하기 위해 this를 사용한다
        this.Money = Money;
    }
    //Car(){} <- 생성자는 이런식으로 숨어져서 이미 선언되어있다, 초기화를 시킬경우 사용
    //ex) Money를 생성되자마자 0으로 초기화하고 싶으면 Car(){ money=0; } 으로 초기화시키면됨
}

/// <summary>
/// 구조체 = 값형의 자료형(값 기반, 값이 할당되어있다), 클래스와 동일하게 객체의 구조와 행위를 정의하는 방법
/// 객체는 스택에 저장된다, 상속 불가능, 소멸자를 가질 수 없다, 초기값을 가질 수 없다
/// </summary>
struct Class_in_action
{
    
}

/*
1.네임스페이스는 서로 연관된 클래스,인터페이스,구조체,열거,델리게이트,하위 네임스페이스를 하나의 그룹으로 묶어놓은것
2.클래스의 이름을 지정할때 발생 되는 이름 충돌 문제 해결
using 키워드로 다른 프로젝트 파일에서 네임스페이스 사용가능
*/
namespace CsharpKitTest
{
    class Product{
        public string name;
        public double price;
    }
    class Class_in_action
    {    
        public static int instanceVariable = 10;

        static void Main(string[] args)
        {
            //82번줄 같은 클래스 메소드에서는 메모리에 올라가있지 않은 변수,메소드는 사용 할 수 없다
            //instanceVariable 변수를 사용하기 위해서 static을 추가해주어야 한다
            Console.WriteLine(instanceVariable);

            //객체 car는 클래스내에 여러가지 정의와 기능들을 받아와 사용할 수 있음

            /*Car()는 생성자로서 메소드이다, 클래스의 동일한 이름을 가지며,
             객체를 생성하는 역할을 하며, 객체 생성시 자동으로 실행된다 */
            /*new 키워드는 생성자를 호출해서 객체를 생성하는데 사용하는 연산자이다
            new와 생성자는 바늘과 실같은 존재*/
            Car car = new Car();
            //실제로 객체 car는 클래스내에 메소드 SetInTime의 기능을 사용할 수 있음
            car.SetInTime();

            //객체 배열을 생성, 10개를 찍어내어 각각 다른값을 넣어 각기 다른 객체로 사용가능
            Car[] cars = new Car[10];
            //0번 인덱스의 객체에 값을 넣어줄 수 있음
            cars[0].carNumber = 0;

            //인스턴스 변수를 생성하자마자 초기화 하는법
            Product productA = new Product() { name = "", price = 0};
            Car car1 = new Car() { carNumber = 0};
            
            //인스턴스(객체)를 생성하지않고도 바로 클래스의 이름만으로 그 클래스의 변수와 메서드를 사용
            //[접근 제한자] static [자료형] [이름] 으로 생성시 아래와 같이 사용가능
            Math.Sqrt(car1.carNumber);
            productA.price = Math.PI;


        }
    }
}