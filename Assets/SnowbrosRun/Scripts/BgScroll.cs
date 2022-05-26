using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class BgScroll : MonoBehaviour
    {
        public float _speed = -0.02f;
        public float _leftPos = -11.0f;
        public float _rightPos = 11.0f;
        public GameManager _gameMgr;

        // Start is called before the first frame update
        void Start()
        {
            _gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameMgr._isPlay)
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);

                // x ��ǥ�� leftPos�� ������ �۴ٸ�
                if (transform.position.x < _leftPos)
                {
                    // �Ʒ� �ڵ�� position�� ������Ƽ�̹Ƿ� ���� ������ �ȵǼ� �Ʒ��Ʒ� �ڵ�ó�� ����
                    //transform.position.x = _rightPos;

                    // ������ ���������� ���� �̵���Ų��.
                    Vector3 pos = transform.position;
                    pos.x = _rightPos;
                    transform.position = pos;
                }
            }
        }
    }
}
