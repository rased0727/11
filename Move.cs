using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameManager _gameMgr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameMgr._isIntro == true)
        {
            return;
        }
        
        /* �÷��ǹ���� �¿���� �̵��� �ʿ� ���� ������ ��ü �ּ�ó��
        // GetKey�� ���������� ������
        // GetkeyDown�� �ѹ� ������ ��
        // GetKeyUp�� �ѹ� ������ ���� ��
        if( Input.GetKey(KeyCode.LeftArrow) ) // ���� ȭ��ǥ�� ������ �ִ� ���̸�
        {
            //transform.position.x = transform.position.x - 1.0f; // �̰� ���� �Ǿ� ������ transform.position �� ���� ������ �Ұ���
            Vector3 pos = transform.position; // pos�� Vector3 ��� Ŭ������ ��Ƶδ� ������ �����Ͱ� ����ִ� ������� �����ϸ� ����
            
            // ���1 : new��� Ű����� ��üȭ �ϰ� ���
            transform.position = new Vector3(pos.x - 0.01f, pos.y, pos.z);

            // ���2 : �׳� �ٷ� Ŭ���������� ���� ������ ����
            // pos.x = pos.x - 0.1f;
            // transform.position = pos;

        }
        if (Input.GetKey(KeyCode.RightArrow)) // ���� ȭ��ǥ�� ������ �ִ� ���̸�
        {
            Vector3 pos = transform.position; // pos�� Vector3 ��� Ŭ������ ��Ƶδ� ������ �����Ͱ� ����ִ� ������� �����ϸ� ����

            // ���1 : new��� Ű����� ��üȭ �ϰ� ���
            //transform.position = new Vector3(pos.x + 0.01f, pos.y, pos.z);

            // ���2 : �׳� �ٷ� Ŭ���������� ���� ������ ����
            pos.x = pos.x + 0.01f;
            transform.position = pos;


        }
        if (Input.GetKey(KeyCode.UpArrow)) // ���� ȭ��ǥ�� ������ �ִ� ���̸�
        {
            Vector3 pos = transform.position; // pos�� Vector3 ��� Ŭ������ ��Ƶδ� ������ �����Ͱ� ����ִ� ������� �����ϸ� ����

            // ���1 : new��� Ű����� ��üȭ �ϰ� ���
            transform.position = new Vector3(pos.x, pos.y + 0.01f, pos.z);

        }
        if (Input.GetKey(KeyCode.DownArrow)) // ���� ȭ��ǥ�� ������ �ִ� ���̸�
        {
            Vector3 pos = transform.position; // pos�� Vector3 ��� Ŭ������ ��Ƶδ� ������ �����Ͱ� ����ִ� ������� �����ϸ� ����

            // ���1 : new��� Ű����� ��üȭ �ϰ� ���
            transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);

        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ݸ��� �̺�Ʈ �߻� : " + collision.gameObject.name);

        // GameManager�� Game Over ����� �˷��ֱ⸸ �ϸ� ��
        _gameMgr._isGameOver = true;
        _gameMgr.OnGameOver();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ʈ���� �̺�Ʈ �߻� : " + collision.gameObject.name);

        _gameMgr._score = _gameMgr._score + 1;
        //_gameMgr._score += 1; // �̷��� ���ų�
        //_gameMgr._score++; // �̷��� �ᵵ ��



    }
}
