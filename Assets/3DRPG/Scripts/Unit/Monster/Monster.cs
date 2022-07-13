using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Monster : Unit
    {
        public float _attackRange = 1.5f;
        public GameObject _enemyObj;

        void Update()
        {
            CheckDistance();
        }

        void CheckDistance()
        {
            // 나와 적 캐릭터 간의 거리를 계산해서,
            // 설정된 공격범위 안에 들어오면 공격!!
            if (_enemyObj == null)
                return;

            Vector3 pos1 = transform.position; // 나(슬라임)의 위치
            Vector3 pos2 = _enemyObj.transform.position; // 적(플레이어)의 위치

            float distance = Vector3.Distance(pos1, pos2);


            if (distance < _attackRange) // 공격범위 안에 들어오면
            {
                // 공격!!
                _anim.SetTrigger("attack");
            }
            /*else  // 공격 범위를 벗어나거나 체력이 0이면
            {
                // 다시, idle 로 전환

                _anim.SetTrigger("attack");
            }*/
        }
    }
}
