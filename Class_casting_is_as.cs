namespace Rayelle_Csharp_Test
{
    class Program
    {
        class Player //부모 클래스
        {
            public int hp;
            public int attack;
        }

        class Knight : Player
        {
            public void Move() { Console.Write("Kight Move"); }
            public void Attack() { Console.Write("Kight Attack"); }
        }

        class Mage : Player
        {
            public void Move() { Console.Write("Maze Move"); }
            public void Attack() { Console.Write("Maze Attack"); }
        }

        static void Main(string[] args)
        {
            {
                //knight스택 메모리에서 new Knight()로 생성한 힙 메모리 객체의 주소를 담음
                Knight knight = new Knight();

                //Up-Casting (자식->부모)
                //자식 타입의 객체를 부모 타입의 변수로 참조하는건 가능함
                Player player = knight;
                player.hp = 10;//부모로부터 상속받은 멤버들만 호출이 가능

                player.Move(); //-> [Compile Error]
                //부모 객체가 자식 객체를 참조하고 있더라도
                //부모 변수로 상속받지 않은 자식만의 멤버들을 호출하려 하면 컴파일 에러가 난다
            }

            {
                //Down-Casting (부모->자식)
                //자식타입의 객체 new Knight();를 참조하던 부모 타입 변수 player_1을 다시 자식 타입으로 형변환하는게 가능하다
                Player player_1 = new Knight();

                Knight knight1 = player_1; //-> [Compile Error]
                //근데 컴파일러는 이를 자동으로 형변환 해주지 않는다 (묵시적 형변환을 해주지 않는다)
                //컴파일러 타임엔 부모 타입 변수인 player_1가 어떤 타입의 객체를 가리키고 있는지 알 수 없기 때문
                //객체가 메모리를 할당 받는 일은 해당 코드가 실행되는 "런타임"이기 때문에 컴파일 타임에서
                //player_1가 어떤 타입의 객체를 가리키고 있는지 알 수 없음, 그래서 프로그래머가 직접 명시적으로 형변환을 해야 한다

                Knight knight2 = (Knight)player_1;
                //이렇게 명시적 형변환을 해주어야 한다

                //[하지만 명시적 형변환은 컴파일에선 문제가 없어도 런타임 에러가 발생할 수도 있다]
                //->실제로 형변환이 가능한지는 프로그램을 실행해서 알아봐야함
                //->객체가 메모리를 할당 받는 일은 해당 코드가 실행되는 런타임이기 때문
            }

            {
                Player player_2 = new Knight();
                Knight knight3 = (Knight)player_2;
                //부모 타입 변수 player_2는 자식 타입인 Knight 타입 객체를 참고하고 있었기 때문에
                //player_2변수를 Knight 타입으로 형변환 해주는건 문제가 되지 않는다 (player_2가 Knight타입 객체를 참고하고 있었기 때문)

                Mage mage = (Mage)player_2;//-> [Runtime Error]
                //부모타입 변수 player_2는 Knight타입 객체를 참고하고 있었기 때문에 Mage타입으로 형변환 될 수 없다
                //컴파일 타임에선 player_2가 어떤 객체를 가리키고 있는지 알 수 없고 런타임때 해당 코드를 실행해봐야 알 수 있는 부분인데
                //Knight와 Mage둘다 Player의 자식이지만 Knight타입의 객체는 Mage에만 정의되어있는 멤버들을 담고 있지 않기 때문
                //-> Mage 타입의 변수 mage로 Knight타입의 객체를 참조할 수 없기 때문에,
                //-> Knight 타입의 객체를 가리키고 있는 player_2는 Mage로 형변환 될 수 없음


                //Down-Casting시 Runtime Error 방지 방법

                //[1]. Is 사용
                bool isMage = (player_2 is Mage);
                if (isMage)
                    Mage mage = (Mage)player_2; //-> [Compile Error]
                //A is B -> [ A가 B타입의 객체를 참조하고 있다면 ? True : False ]

                //player_2는 Knight타입의 객체를 참조하고 있기 때문에 isMage의 결과는 False이다
                //따라서 if문 아래 코드가 IDE상에서 Error로 뜨기 때문에 Runtime Error를 방지할 수 있음


                //[2]. As 사용
                Player player_3 = new Mage();

                Mage mage_1 = (player_3 as Mage);
                if (mage_1 != null)
                    mage_1 = (Mage)player_3;
                //A as B -> [ A를 B타입으로 형변환 하는 것이 가능하다면 ? 형변환을 진행후 그 결과(A가 참조하고 있던 객체)를 return : null return ]

                //player_3는 Mage타입의 객체를 참조하고 있기 때문에 Mage로 형변환이 가능하다
                //따라서 mage_1엔 player_3가 참조하고 있던 객체가 리턴이 되고
                //mage_1와 player_3는 힙 메모리에 있는 동일한 객체를 가리키게 된다
                //-> mage_1는 player_3가 Mage로 형변환된 결과다
                //-> 그래서 if문 아래 코드가 실행된다, 형변환이 불가능 했다면 실행되지 않았음
            }
        }
    }
}
