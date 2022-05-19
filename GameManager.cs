using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �������� ������ ������ �帧�� �����ϴ� Ŭ����
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
        
    }

    // ���ӽ��� ��ư �̺�Ʈ �Լ�. �̺�Ʈ �Լ��� ���ʻ� On�� �����
    public void OnClick_GameStart()
    {
        Debug.Log("���� ���� ��ư ����!!!");

        // ��Ʈ�� UI�� ���ְ�, �÷��� UI�� ����
        _introUI.SetActive(false);
        _playUI.SetActive(true);
       
        // 2. �߷�(����) ��Ȱ��ȭ
        _birdRigid.simulated = true;

        // 3. ���� �Է� ��Ȱ��ȭ
        _isIntro = false;
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

        _bird.SetActive(false);
    }


}
