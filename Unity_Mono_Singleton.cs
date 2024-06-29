using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoSingleton<GameManager>{
    //싱글톤 마다 객체를 만들고 Awake에서 초기화하는게 아닌 제네릭 형태로 사용, instance도 가능
    public void Click(){
        System.Console.WriteLine("click");
    }
}

//.... 다른 클래스에서 게임매니저 싱글톤 인스턴스 사용

public class Unity_Mono_Singleton : MonoBehaviour {
    private void Start() {
        GameManager.Inst.Click();    
    }
}