using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : MonoBehaviour
{
    public float _speed = 1.0f; // 캐릭터 이동속도
    public float _attackRange = 1.75f;

    public GameObject _enemyObj;

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody 를 건드려서 앞으로 이동

        // 캐릭터를 이동하는 2가지 방법
        // 1. rigidbody.Addforce 함수를 힘을 주어서 이동 = 가속도 이동
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity 변수(x축만)를 직접 건드려서 이동 = 등속도 이동
        Vector2 vel = _rigid.velocity;
        if(_renderer.flipX == false)
        {
            vel.x = _speed;
        }
        else
        {
            vel.x = -1.0f * _speed;
        }
        _rigid.velocity = vel;
        
        if (_enemyObj != null) // 적이 설정되어 있을때만
        {
            CheckDistance(); // 거리 체크 함수 호출
        }
        

    }
    void CheckDistance() // 거리를 체크하는 함수
    {
        // 나와 적 캐릭터 간의 거리를 계산 해서, 설정된 공격범위 안에 들어오면 공격개시
        
        float pos1 = transform.position.x; // 내 캐릭터의 위치
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리를 나타내는 변수 ( 두 객체간의 x좌표 사이의 거리 )
        // Mathf는 유니티에서 제공해주는데 이 f의 뜻은 float라는 뜻임


        if ( distance < _attackRange) // 나와 적 캐리터간의 거리가 공격범위 안에 들어오면
        {
            // 공격
            _anim.SetBool("attack", true);
        }
        else // 공격범위를 벗어나면
        {
            _anim.SetBool("attack", false);
        }
    }
}
