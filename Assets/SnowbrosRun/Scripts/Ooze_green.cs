using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowbrosRun
{
    public class Ooze_green : MonoBehaviour
    {

        public float _speed = -0.005f; // 진흙괴물이 좌측으로 이동하는 속도
                                // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(_speed*Time.deltaTime, 0, 0); // x축으로만 좌측이동
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("콜리전 이벤트 발생 : " + collision.gameObject.name);

            // GameManager에 Game Over 사실을 알려주기만 하면 됨
            //_gameMgr._isGameOver = true;
            //_gameMgr.OnGameOver();

        }
    }
}

