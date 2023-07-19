using System;

/* f12 = 함수 원본 찾아감
   alt f12 = 중간에서 함수 원본 봄
   ctrl shift r = 작성한 코드를 함수로 싸매기
   f2 = 변수이름과 관련된 모든걸 rename 시킴
   alt + 클릭 = 다중 클릭(클릭한 부분 동시에 타이핑가능)
   ctrl l = 한문장 전부 지정 > alt 방향키 = 문장위치 조절
   alt shift 방향키 = 행 복사후 붙여넣기
   ctrl ` 터미널 열기
   ctrl D 같은 단어들 다 연결
   /// = 함수에 설명부여
*/
namespace CsharpKitTest{
    class Program{
        static void Main(string[] args)
        {
            Console.WriteLine("kit test successful2"); 
        }

        /// <summary>
        /// 움직임 감지 함수 
        /// </summary>
        /// <param name="a"> a의 매개변수는 숫자로만 넣을것 </param>
        /// <returns>반환값이 뭔지를 적어야함</returns>
        public static int MovementCalc(int a)
        {
            int b = a + 1;
            return b;
        }
        int c = MovementCalc(1);
        //
    }

}

