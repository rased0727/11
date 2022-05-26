using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class Ooze_green : MonoBehaviour
    {
        GameManager _gameMgr;

        public float _speed = -0.005f; // 진흙괴물이 좌측으로 이동하는 속도
                                // Start is called before the first frame update
        void Start()
        {
            _gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameMgr._isPlay && _gameMgr._isIntro == false && _gameMgr._isGameOver == false)
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0); // x축으로만 좌측이동
            }
            
        }
    }
}

