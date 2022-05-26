using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ���� �������� ������ ������ �帧�� �����ϴ� Ŭ����
public class GameManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _gameOverUI;
    public Rigidbody2D _birdRigid;
    public PipeManager _pipeMgr;

    public bool _isIntro = true; // ��Ʈ�� ���¸� ��Ÿ��
    public bool _isGameOver = false; // ���ӿ��� ���¸� ��Ÿ��

    public Text _scoreNumberText;
    public int _score = 0;


    // Start is called before the first frame update
    void Start()
    {
        /*
        GameObject canvasUI = GameObject.Find("Canvas");
        Transform playUITrnas = canvasUI.transform.Find("UI_Play");
        Transform scoreNumberTrans = canvasUI.transform.Find("Txt_ScoreNumber");
        _scoreNumberText = scoreNumberTrans.gameObject.GetComponent<Text>();
        */
        Transform scoreNumberTrans = _playUI.transform.Find("Txt_ScoreNumber");
        _scoreNumberText = scoreNumberTrans.gameObject.GetComponent<Text>();

        // �ð��� ���� �ɷ��� ���� ������ �Ⱦ���, �� Ŭ��������(�������)�� ���� �� �ν����� â���� �巡�׾� ����� ��
        // �ٵ� ���� ������ ���� ���ϸ� Null reference error �� ����
        //_introUI = GameObject.Find("UI_intro");


        // 1. UI ó��
        _playUI.SetActive(false);
        _gameOverUI.SetActive(false);
        _introUI.SetActive(true);

        // 2. �߷�(����) ��Ȱ��ȭ
        // �ٷ� �Ʒ� ������ ������� �ʴ� ������ �ð��� ���� �ɷ���
        //_birdRigid = GameObject.Find("bird").GetComponent < Rigidbody2D() >;
        _birdRigid.simulated = false;

        // 3. ���� �Է� ��Ȱ��ȭ
        _isIntro = true;

    }

    // Update is called once per frame
    void Update()
    {
        _scoreNumberText.text = _score.ToString();


    }

    // ���ӽ��� ��ư �̺�Ʈ �Լ�. �̺�Ʈ �Լ��� ���ʻ� On�� �����
    public void OnClick_GameStart()
    {
        Debug.Log("���� ���� ��ư ����!!!");

        // ��Ʈ�� UI�� ���ְ�, �÷��� UI�� ����
        _introUI.SetActive(false);
        _playUI.SetActive(true);
       
        // 2. �߷�(����) Ȱ��ȭ
        _birdRigid.simulated = true;

        // 3. ���� �Է� ��Ȱ��ȭ
        _isIntro = false;


        // ������ ���� ����
        _pipeMgr.Start_MakePipeSet();
    }

    // ���ӿ��� �̺�Ʈ �Լ�
    public void OnGameOver()
    {
        Debug.Log("OnGameOver�Լ� ȣ��");
        
        // �÷��� UI�� ���ְ�
        _playUI.SetActive(false);

        // ���ӿ��� UI�� ���ش�
        _gameOverUI.SetActive(true);

        // �׸��� �߷��� ��Ȱ��ȭ �����ش�
        _birdRigid.simulated = false;

        _isGameOver = true;
    }
    public void OnClickRetry()
    {
        Debug.Log("OnClickRetry ��ư ����");
        SceneManager.LoadScene("MyFirstGame");
    }


}
