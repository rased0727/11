using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class Ooze_green : MonoBehaviour
    {

        public float _speed = -0.005f; // ���뱫���� �������� �̵��ϴ� �ӵ�
                                // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(_speed*Time.deltaTime, 0, 0); // x�����θ� �����̵�
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("�ݸ��� �̺�Ʈ �߻� : " + collision.gameObject.name);

            // GameManager�� Game Over ����� �˷��ֱ⸸ �ϸ� ��
            //_gameMgr._isGameOver = true;
            //_gameMgr.OnGameOver();

        }
    }
}

