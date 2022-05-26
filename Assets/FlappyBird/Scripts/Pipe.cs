using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze_green : MonoBehaviour
{
    public GameManager _gameMgr;
    float _speed = -0.005f; // 파이프가 좌측으로 속도

    // Start is called before the first frame update
    void Start()
    {
        // FindObjectOfType 함수는 오브젝트 객체를 가져오는 것이 아니라 객체 안의 컴퍼넌트를 가져오는 함수임.
        _gameMgr = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // 게임 인트로와 게임오버가 아닐때만 파이프 움직이게
        if(_gameMgr._isIntro == false && _gameMgr._isGameOver == false)
        {
            transform.Translate(_speed, 0, 0); // x축으로만 좌측이동
        }
        
    }
}
