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

        public bool _isIntro = true; // ��Ʈ�� ���¸� ��Ÿ��
        public bool _isPlay = false; // ������ ���¸� ��Ÿ��
        public bool _isGameOver = false; // ���ӿ��� ���¸� ��Ÿ��



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


            // ������ ���۵Ǹ� UI_Intro�� ���ش�
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
            Debug.Log("���� ���� ��ư ����!!!");

            // ��Ʈ�� UI�� ���ְ�, �÷��� UI�� ����
            _introUI.SetActive(false);
            _playUI.SetActive(true);

            // ������ ���� ����
            _oozeMgr.Start_OozePipeSet();
           
            _isPlay = true;
        }

        public void OnGameOver()
        {
            Debug.Log("OnGameOver�Լ� ȣ��");

            // �÷��� UI�� ���ְ�
            //_playUI.SetActive(false);

            // ���ӿ��� UI�� ���ش�
            //_gameOverUI.SetActive(true);

            // �׸��� �߷��� ��Ȱ��ȭ �����ش�
            //_snowRigid.simulated = false;

            _isGameOver = true;
        }
    }
}


