using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
    public class Player : MonoBehaviour
    {
        public static Player I;

        [SerializeField] int _floor = 1;
        public int Floor 
        { 
            get{  return _floor; }            
        }

        [SerializeField]float _speed = 1.0f;
        Animator _anim;
        SpriteRenderer _renderer;
        Rigidbody2D _rigid;

        bool _doingWARP = false;

        void Awake()
        {
            I = this;    
        }

        void Start()
        {
            _anim = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
            _rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        //void Update()
        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h == 0 && v == 0)
            {
                _anim.SetBool("run", false);
            }
            else
            {
                _anim.SetBool("run", true);
            }


            Move(h, v);
            Flip(h);
        }


        void Move(float h, float v)
        {
            Vector2 dir = new Vector2(h, v); // 방향 벡터

            // 이동거리 = 방향벡터 * 스피드

            //이동
            //transform.Translate(dir * _speed * Time.deltaTime);
            if (_doingWARP == false)
                _rigid.velocity = dir * _speed * Time.fixedDeltaTime;
            else
                _rigid.velocity = Vector2.zero;
        }

        void Flip(float h)
        {
            if (h < 0)
            {
                //좌
                _renderer.flipX = true;

            }
            else if (h > 0)
            {
                //우
                _renderer.flipX = false;
            }

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("트리거 이벤트! : " + collision.gameObject.name);

            Stair stair = collision.gameObject.GetComponent<Stair>();
            if(stair != null) // 트리거 오브젝트가 계단인 경우
            {
                // 방금 막 이동된 경우는 워프 안함 return
                if (_doingWARP == true) return;


                // 플레이어를 다음 목적지로 워프 시켜주기
                if (stair._destObj != null)
                {
                    transform.position = stair._destObj.transform.position;
                    StartWARP();
                }

                if( stair._direction == StairDirection.DOWN)
                {
                    _floor++;
                    UI_Manager.I.Topbar.Refresh();
                }
                else if(stair._direction == StairDirection.UP)
                {
                    if (_floor == 1)
                    {
                        PlatformDialog.Show(
                            "안내",
                            "현재는 던전을 벗어날 수 없습니다",
                            PlatformDialog.Type.SubmitOnly,
                            () => {
                                Debug.Log("OK");
                            },
                            null
                        );
                    }
                    else
                    {
                        _floor--;
                        UI_Manager.I.Topbar.Refresh();
                    }
                }

            }

        }
    
        void StartWARP()
        {
            UI_Manager.I.ScreenBlock.Play();
            _doingWARP = true;
            Invoke("StopWARP", 2.0f);
        }

        void StopWARP()
        {
            _doingWARP = false;
            UI_Manager.I.ScreenBlock.Stop();
        }

        
    
    }
}
