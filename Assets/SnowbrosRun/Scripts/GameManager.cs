using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class GameManager : MonoBehaviour
    {
        public GameObject _introUI;
        public GameObject _playUI;
        public GameObject _gameOverUI;
        public GameObject _snowObj;
        public GameObject _oozeMgrObj;
        public Rigidbody2D _snowRigid;
        public OozeManager _oozeMgr;

        public bool _isIntro = true; // 인트로 상태를 나타냄
        public bool _isPlay = false; // 게임중 상태를 나타냄
        public bool _isGameOver = false; // 게임오버 상태를 나타냄



        // Start is called before the first frame update
        void Start()
        {
            _snowObj = GameObject.Find("Snow");
            _snowRigid = _snowObj.GetComponent<Rigidbody2D>();
            _oozeMgrObj = GameObject.Find("OozeManager");
            _oozeMgr = _oozeMgrObj.GetComponent<OozeManager>();

            _introUI = GameObject.Find("UI_Intro");
            _playUI = GameObject.Find("UI_Play");
            _gameOverUI = GameObject.Find("UI_GameOver");


            // 게임이 시작되면 UI_Intro를 켜준다
            _introUI.SetActive(true);
            _playUI.SetActive(false);
            _gameOverUI.SetActive(false);
            
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

            // 파이프 생성 시작
            _oozeMgr.Start_OozePipeSet();
           
            _isPlay = true;
        }

        public void OnGameOver()
        {
            Debug.Log("OnGameOver함수 호출");

            // 플레이 UI를 꺼주고
            //_playUI.SetActive(false);

            // 게임오버 UI를 켜준다
            //_gameOverUI.SetActive(true);

            // 그리고 중력을 비활성화 시켜준다
            //_snowRigid.simulated = false;

            _isGameOver = true;
        }
    }
}


