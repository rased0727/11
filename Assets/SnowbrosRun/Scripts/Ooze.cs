using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class Ooze : MonoBehaviour
    {
        GameManager _gameMgr;

        SpriteRenderer _spriteRenderer;
        public Color _newColor;

        public float _speed = -0.005f; // ���뱫���� �������� �̵��ϴ� �ӵ�
                                // Start is called before the first frame update
        void Start()
        {
            /* ����ȭ �� �� ���
            _gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _newColor.a = 0;
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameMgr._isPlay && _gameMgr._isIntro == false && _gameMgr._isGameOver == false)
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0); // x�����θ� �����̵�
            }
            
        }
        /* ����ȭ �� �� ���
        public void Transparency()
        {
            //_spriteRenderer.color = _newColor;
        }
        */
    }
}

