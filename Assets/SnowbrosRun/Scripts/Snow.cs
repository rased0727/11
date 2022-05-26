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

        Rigidbody2D _rigid;
        Animator _anim;


    
    

        // ���2 (�θ�ü�� ã�� �� �� ���� transform ������Ʈ ���� �ڽ� ��ü�� �̸����� ã��)
        //GameObject obj = GameObject.Find("SoundManager").transform.Find("JumpSound").gameObject;

        // ���3 (�θ�ü�� ã�� �� �� ���� transform ������Ʈ ���� �ڽ� ��ü�� �ε����� ã��)
        //GameObject obj = GameObject.Find("SoundManager").transform.GetChild(0).gameObject;


        // Start is called before the first frame update
        void Start()
        {
            _gameMgrObj = GameObject.Find("GameManager");
            _gameMgr = _gameMgrObj.GetComponent<GameManager>();

            // JumpSound ��ü ã�� �ű⿡ �پ� �ִ� AudioSource ������Ʈ ��������
            GameObject obj = GameObject.Find("JumpSound");
            _jumpSound = obj.GetComponent<AudioSource>();

            _rigid = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            //_anim.enabled.
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

            // GameManager�� Game Over ����� �˷��ֱ⸸ �ϸ� ��
            if (collision.gameObject.name != "Ground")
            {
                _gameMgr._isGameOver = true;
                _gameMgr.OnGameOver();
                Debug.Log("GameOver�� ������");
            }

        }
    }
}
