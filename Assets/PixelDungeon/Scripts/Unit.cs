using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
    public class Unit : MonoBehaviour
    {
        public int _hp;
        public int _maxHp; // 인스펙터에서 정해주기

        protected Animator _anim;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            _anim = GetComponent<Animator>();

            // 체력초기화
            _hp = _maxHp;

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void DoDamage()
        {
            if (_hp <= 0)
            {
                UI_Manager.I.Gameover.Show();
            }
            else
            {
                Player.I.DoHitEffect();
                UI_Manager.I.Gamelog.Hit();
                _hp -= 10;
            }
        }
    }
}


