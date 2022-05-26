using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnowbrosRun
{
    public class GameManager : MonoBehaviour
    {
        public GameObject _introUI;
        public GameObject _playUI;
        public GameObject _gameOverUI;
        public Rigidbody2D _snowRigid;
        public OozeManager _oozeMgr;
        public Snow _snow;

        public bool _isIntro = true; // 인트로 상태를 나타냄
        public bool _isPlay = false; // 게임중 상태를 나타냄
        public bool _isGameOver = false; // 게임오버 상태를 나타냄



        // Start is called before the first frame update
        void Start()
        {
            _introUI = GameObject.Find("UI_Intro");
            _playUI = GameObject.Find("UI_Play");
            _gameOverUI = GameObject.Find("UI_GameOver");

            _snowRigid = GameObject.Find("Snow").GetComponent<Rigidbody2D>(); ;
            _oozeMgr = GameObject.Find("OozeManager").GetComponent<OozeManager>();
            _snow = GameObject.Find("Snow").GetComponent<Snow>();

            // 게임이 실행되면 UI_Intro를 켜준다
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
            // 플레이 UI를 켜주고 그 외 UI는 비활성화
            _introUI.SetActive(false);
            _playUI.SetActive(true);
            _gameOverUI.SetActive(false);

            // 슬라임 복제 시작
            _oozeMgr.Start_OozePipeSet();

            _isIntro = false;
            _isPlay = true;
            _isGameOver = false;

            _snow._anim.enabled = true;
        }

        public void OnGameOver()
        {
            _introUI.SetActive(false);
            _playUI.SetActive(false);
            _gameOverUI.SetActive(true);

            _snow._anim.enabled = false;
        }
        public void OnClickRetry()
        {
            SceneManager.LoadScene("SnowbrosRun");
        }
    }
}


