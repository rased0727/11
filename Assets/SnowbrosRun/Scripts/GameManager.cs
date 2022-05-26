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

        public bool _isIntro = true; // ��Ʈ�� ���¸� ��Ÿ��
        public bool _isPlay = false; // ������ ���¸� ��Ÿ��
        public bool _isGameOver = false; // ���ӿ��� ���¸� ��Ÿ��



        // Start is called before the first frame update
        void Start()
        {
            _introUI = GameObject.Find("UI_Intro");
            _playUI = GameObject.Find("UI_Play");
            _gameOverUI = GameObject.Find("UI_GameOver");

            _snowRigid = GameObject.Find("Snow").GetComponent<Rigidbody2D>(); ;
            _oozeMgr = GameObject.Find("OozeManager").GetComponent<OozeManager>();
            _snow = GameObject.Find("Snow").GetComponent<Snow>();

            // ������ ����Ǹ� UI_Intro�� ���ش�
            _introUI.SetActive(true);
            _playUI.SetActive(false);
            _gameOverUI.SetActive(false);
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        // ���ӽ��� ��ư �̺�Ʈ �Լ�. �̺�Ʈ �Լ��� ���ʻ� On�� �����
        public void OnClick_GameStart()
        {
            // �÷��� UI�� ���ְ� �� �� UI�� ��Ȱ��ȭ
            _introUI.SetActive(false);
            _playUI.SetActive(true);
            _gameOverUI.SetActive(false);

            // ������ ���� ����
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


