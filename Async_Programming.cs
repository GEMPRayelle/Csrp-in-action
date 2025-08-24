using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

//동기(Synchronous): 한 가지 작업이 완료되어야만 다음 작업이 시작되는 방식
//비동기(Asynchronous): 한 가지 작업이 완료되지 않아도 다음 작업이 시작될 수 있는 방식
public class AssetLoader : MonoBehaviour
{
    //비동기 프로그래밍의 중요 3가지 키워드
    //async > 비동기 메서드를 선언할때 사용하는 키워드
    //-> 반환 타입으로는 Task, Task<T> 또는 void를 사용

    //await > 비동기 메서드 내에서 사용되는 키워드
    //-> 비동기 작업이 완료될때까지 메서드의 실행을 일시 중지하고,
    //비동기 작업이 완료되면 메서드의 실행을 계속 실행
    //전체 프로그램을 중단 시키는게 아님, async 메서드 내에서만 사용가능

    //Task > 비동기 작업을 나타내는 클래스
    //Task는 리턴이 없는 작업, Task<T>는 T타입의 결과를 리턴해야함
    //Task.Run()을 사용해서 새 작업을 시작 가능


    //1. 텍스처 에셋을 비동기적으로 로드하는 메서드
    public async Task<Texture> LoadAssetAsync(string path)
    {
        //2. UWR를 사용해 텍스처 다운로드를 요청
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(path);

        //3. 요청을 비동기적으로 전송하고 완료될때까지 대기
        await www.SendWebRequest();

        //4. 전송이 실패했다면
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            return null;
        }

        //5. 전송이 성공했다면
        return DownloadHandlerTexture.GetContent(www);
    }

}