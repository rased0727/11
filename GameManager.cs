using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 눈에 보이지는 않지만 게임의 흐름을 제어하는 클래스
public class GameManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _gameOverUI;
    public GameObject _bird;
    public Rigidbody2D _birdRigid;

    public bool _isIntro = true;

    // Start is called before the first frame update
    void Start()
    {
        // 시간이 오래 걸려서 밑의 라인은 안쓰고, 위 클래스변수(멤버변수)를 선언 후 인스펙터 창에서 드래그앤 드롭을 함
        // 근데 만약 슬롯을 참조 안하면 Null reference error 가 나옴
        //_introUI = GameObject.Find("UI_intro");
        
        
        // 1. UI 처리
        _playUI.SetActive(false);
        _gameOverUI.SetActive(false);
        _introUI.SetActive(true);

        // 2. 중력(물리) 비활성화
        // 바로 아래 라인을 사용하지 않는 이유는 시간이 오래 걸려서
        //_birdRigid = GameObject.Find("bird").GetComponent < Rigidbody2D() >;
        _birdRigid.simulated = false;

        // 3. 유저 입력 비활성화
        _isIntro = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 게임시작 버튼 이벤트 함수. 이벤트 함수는 관례상 On을 사용함
    public void OnClick_GameStart()
    {
        Debug.Log("게임 시작 버튼 눌림!!!");

        // 인트로 UI를 꺼주고, 플레이 UI를 켜줌
        _introUI.SetActive(false);
        _playUI.SetActive(true);
       
        // 2. 중력(물리) 비활성화
        _birdRigid.simulated = true;

        // 3. 유저 입력 비활성화
        _isIntro = false;
    }

    // 게임오버 이벤트 함수
    public void OnGameOver()
    {
        Debug.Log("OnGameOver함수 호출");
        
        // 플레이 UI를 꺼주고
        _playUI.SetActive(false);

        // 게임오버 UI를 켜준다
        _gameOverUI.SetActive(true);

        // 그리고 중력을 비활성화 시켜준다
        _birdRigid.simulated = false;

        _bird.SetActive(false);
    }


}
