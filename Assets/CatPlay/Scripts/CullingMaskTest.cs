using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingMaskTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        Debug.Log($"Player : {LayerMask.NameToLayer("Player")}");
        Debug.Log($"Item : {LayerMask.NameToLayer("Item")}");
        Debug.Log($"Background : {LayerMask.NameToLayer("Background")}");

        Debug.Log(Camera.main.cullingMask);
        */

        /*** 나중에 사용할 템플릿 
        // 플레이어만 선택한 상태
        Camera.main.cullingMask = (1 << LayerMask.NameToLayer("Player"));
        // 플레이어만 뺀 상태
        Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer("Player"));
        // 플레이어와 아이템 레이어를 선택한 상태(논리합 연산자)
        Camera.main.cullingMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Item"));
        ***/



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
