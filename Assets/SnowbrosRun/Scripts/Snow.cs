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
    
        public AudioSource _jumpSound;
        public GameObject _gameMgrObj;
        public GameManager _gameMgr; 

        public Rigidbody2D _rigid;
        public Animator _anim;



        // Start is called before the first frame update
        void Start()
        {
            _gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
            _jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();

            _rigid = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _anim.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ���� �����ְ�
                _rigid.AddForce(new Vector3(0, _jumpForce, 0));

                // �ִϸ������� �Ķ���� Ʈ���� �߻����� �ִϸ��̼� ��ȯ
                _anim.SetTrigger("jump");
            
                _jumpSound.Play();
            }
            Vector3 vel = _rigid.velocity;
            float limit = Mathf.Min(_jumpLimit, vel.y);
            _rigid.velocity = new Vector3(vel.x, limit, 0.0f);



        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("�ݸ��� �̺�Ʈ �߻� : " + collision.gameObject.name);

            
            if (collision.gameObject.name != "Ground")
            {
                // GameManager�� Game Over ����� �˷��ֱ�
                _gameMgr._isGameOver = true;
                _gameMgr.OnGameOver();
                Debug.Log("GameOver�� ������");
            }

        }
    }
}
