using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class Unit : MonoBehaviour
    {
        public int _maxHp = 100;
        public int _hp = 0;

        // 공격 효과음
        public AudioSource _sound_attack;

        // 각종 붙어있는 콤포넌트들
        BoxCollider _attackCol;
        protected Animator _anim;


        // Start is called before the first frame update
        void Start()
        {
            _anim = GetComponent<Animator>();

            if (this is Knight)
            {
                _attackCol = transform.Find("arm_R_weapon/Knight_handsword").GetComponent<BoxCollider>();

                if (_attackCol != null)
                {
                    // 시작할때 공격충돌체 꺼주기
                    _attackCol.enabled = false;
                }

            }

            // 체력 초기화
            _hp = _maxHp;

        }





        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Post-process Volume")
                return; // 포스트프로세스볼륨과 충돌체크 스킵

            if (other.gameObject.name.Contains("Terrain"))
                return; // 터레인과의 충돌체크 스킵


            //string log = string.Format("this : {0}, other: {1}", this.gameObject.name, other.gameObject.name);
            //Debug.Log(log);


            if (other.gameObject.tag == "AttackCol")
            {

                Debug.Log("==== 데미지 발생!! =====");

                Debug.Log("attacker : " + other.gameObject.name);

                Debug.Log("========================");

                _hp -= 10;

                if (_anim != null)
                    _anim.SetTrigger("hit");

                if (_hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        protected void Attack()
        {
            if (_anim != null)
            {
                _anim.SetTrigger("attack");
            }

        }




        #region ANIMATION_EVENT

        public void SetAttackCol(int on) // 1 - on, 0 - off
        {
            if (_attackCol == null) // 공격 충돌체가 없다면 실행하지 않기
                return;

            if (on == 1)
            {
                _attackCol.enabled = true; // 공격 충돌체를 켠다
            }

            if (on == 0)
            {
                _attackCol.enabled = false; // 공격 충돌체를 꺼둔다
            }
        }

        public void AnimSound(string name)
        {
            if (name == "attack")
            {
                _sound_attack.Play();
            }
        }


        #endregion
    }
}
