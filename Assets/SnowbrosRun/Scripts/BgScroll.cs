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

                // x 좌표가 leftPos의 값보다 작다면
                if (transform.position.x < _leftPos)
                {
                    // 아래 코드는 position이 프로퍼티이므로 직접 수정이 안되서 아래아래 코드처럼 진행
                    //transform.position.x = _rightPos;

                    // 오른쪽 기준점으로 강제 이동시킨다.
                    Vector3 pos = transform.position;
                    pos.x = _rightPos;
                    transform.position = pos;
                }
            }
        }
    }
}
