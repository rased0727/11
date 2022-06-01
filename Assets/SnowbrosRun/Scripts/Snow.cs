using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SnowbrosRun
{
    public class Snow : MonoBehaviour
    {
        public float _jumpForce = 400.0f;
        public float _jumpLimit = 10.0f;
        public bool _isJump = false;

        //public GameObject _gameMgrObj;
        //public GameObject _oozeObj;

        public AudioSource _jumpSound;
        //SpriteRenderer _spriteRenderer;
        public GameManager _gameMgr;
        //public Ooze _ooze;

        public Rigidbody2D _rigid;
        public Animator _anim;



        // Start is called before the first frame update
        void Start()
        {
            _gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
            _jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
            
            
            // ����ȭ ����
            // _ooze = GameObject.Find("Ooze").GetComponent<Ooze>();
           

            _rigid = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _anim.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isJump==false) // �����̽� �ٸ� ������
            {
                // ���� �����ְ�
                _rigid.AddForce(new Vector3(0, _jumpForce, 0));

                // �ִϸ������� �Ķ���� Ʈ���� �߻����� �ִϸ��̼� ��ȯ
                _anim.SetTrigger("jump");
                
                // ���� ����
                _jumpSound.Play();

                // _isJump �� true��
                _isJump = true;
            }
            else
            {

            }

            Vector3 vel = _rigid.velocity;
            float limit = Mathf.Min(_jumpLimit, vel.y);
            _rigid.velocity = new Vector3(vel.x, limit, 0.0f);



        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ooze")
            {
                if (_isJump)
                {
                    Debug.Log("���� �߿� " + collision.gameObject.tag + "�� �ε���");
                    _isJump = false;

                    //_oozeObj = GameObject.FindWithTag("Ooze");
                    //_oozeObj.SetActive(false);
                    //_spriteRenderer = _oozeObj.GetComponent<SpriteRenderer>();
                    //_spriteRenderer.color = new Color(1, 1, 1, 0.0f);


                    /*
                    _ooze = _oozeObj.GetComponent<Ooze>();
                    _ooze.Transparency();
                    */

                }
                else
                {
                    // GameManager�� Game Over ����� �˷��ֱ�
                    _gameMgr._isGameOver = true;
                    _gameMgr.OnGameOver();
                    Debug.Log("GameOver�� ������");
                }
            }
        }
    }
}
