using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze_green : MonoBehaviour
{
    public GameManager _gameMgr;
    float _speed = -0.005f; // �������� �������� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // FindObjectOfType �Լ��� ������Ʈ ��ü�� �������� ���� �ƴ϶� ��ü ���� ���۳�Ʈ�� �������� �Լ���.
        _gameMgr = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // ���� ��Ʈ�ο� ���ӿ����� �ƴҶ��� ������ �����̰�
        if(_gameMgr._isIntro == false && _gameMgr._isGameOver == false)
        {
            transform.Translate(_speed, 0, 0); // x�����θ� �����̵�
        }
        
    }
}
