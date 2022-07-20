using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG3D
{
    public class Unit : MonoBehaviour
    {
        // 각종 조절값 들
        public int _maxHp = 100;
        public int _hp = 0;
        public int _JumpPower = 5;

        // 공격 효과음
        public AudioSource _sound_attack;

        // 각종 붙어있는 콤포넌트들
        BoxCollider _attackCol;
        protected Animator _anim;
        public Rigidbody _rigid;
        
        public GameObject _canvas;
        public GameObject _world;

        public UIManager _uiMgr;
        public GameObject _hpBarTrans;
        public Lancer _player;


        // Start is called before the first frame update
        public virtual void Init()
        {
            _anim = GetComponent<Animator>();
            _rigid = gameObject.GetComponent<Rigidbody>();
            _uiMgr = _canvas.GetComponent<UIManager>();
            _player = _world.transform.Find("Units/Lancer").gameObject.GetComponent<Lancer>();
            _hpBarTrans = _canvas.transform.Find("CharacterBar/HpBar").gameObject;
            _player.RefreshHpBar();


            if (this is Knight)
            {
                _attackCol = transform.Find("arm_R_weapon/Knight_handsword").GetComponent<BoxCollider>();
            }
            else if (this is Lancer)
            {
                _attackCol = transform.Find("arm_R_weapon/lancer_weapon").GetComponent<BoxCollider>();
            }
            else if (this is Slime)
            {
                _attackCol = transform.Find("Body/attack").GetComponent<BoxCollider>();
            }
            if (_attackCol != null)
            {
                // 시작할때 공격충돌체 꺼주기
                _attackCol.enabled = false;
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


            if (other.gameObject.tag == "AttackCol")
            {
                /*
                Debug.Log("==== 데미지 발생!! =====");
                Debug.Log("attacker : " + other.gameObject.name);
                Debug.Log("========================");
                */
                _hp -= 10;

                if (_anim != null)
                    _anim.SetTrigger("hit");

                if (_hp <= 0)
                {
                    Destroy(gameObject);
                }
                RefreshHpBar();
            }
        }

        protected void Attack()
        {
            if (_anim != null)
            {
                //Debug.Log("in1");
                _anim.SetTrigger("attack");
            }

        }
        protected void Jump()
        {
            if (_anim != null)
            {
                //Debug.Log("in2");
                _anim.SetTrigger("jump");
                _rigid.AddForce(Vector3.up * _JumpPower, ForceMode.Impulse);
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
        public void RefreshHpBar()
        {
            if (_hpBarTrans != null)
            {
                /*
                Player player = new Player();
                int hp = player._hp;
                int maxHp = player._maxHp;
                Image fillImg = _hpBarTrans.GetComponent<Image>();
                fillImg.fillAmount = (float)hp / (float)maxHp;
                */
                _maxHp = _player._maxHp;
                _hp = _player._hp;
                Image fillImg = _hpBarTrans.GetComponent<Image>();
                fillImg.fillAmount = (float)_hp / (float)_maxHp;
            }
        }


        #endregion
    }
}
