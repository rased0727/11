using System;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MapObject, IAttacker
{
    public float _speed = 1.0f; // 캐릭터 이동속도
    public float _attackRange = 1.75f;

    public GameObject _enemyObj;
    

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    BoxCollider2D _attackCol;

    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start(); // 부모의 Start() 함수를 먼저 실행해야 체력초기화가 됨

        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();

        Transform childTrans = transform.Find("AttackCol");

        // 널 체크
        if (childTrans != null)
        {
            _attackCol = childTrans.GetComponent<BoxCollider2D>();
        }


        // 공격 충돌체는 시작할때는 꺼둔다
        if (_attackCol != null)
        {
            _attackCol.enabled = false;
        }
        







    }

   

    // Update is called once per frame
    void Update()
    {
        base.UpdateHpBarPos();

        // rigidbody 를 건드려서 앞으로 이동

        // 캐릭터를 이동하는 2가지 방법
        // 1. rigidbody.Addforce 함수를 힘을 주어서 이동 = 가속도 이동
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity 변수(x축만)를 직접 건드려서 이동 = 등속도 이동
        bool isAttacking = _anim.GetBool("attack");

        
        if (isAttacking)
        {
            Vector2 vel = _rigid.velocity;
            vel.x = 0.0f;
            _rigid.velocity = vel;
        }
        else
        {
            Vector2 vel = _rigid.velocity;
            if (_renderer.flipX == false)
            {
                vel.x = _speed;
            }
            else
            {
                vel.x = -1.0f * _speed;
            }
            _rigid.velocity = vel;
        }


        // 적을 찾는 메서드
        _enemyObj = FindEnemy();
        

        if (_enemyObj != null) // 적이 설정되어 있을때만
        {
            CheckDistance(); // 거리 체크 함수 호출
        }
        else
        {
            _anim.SetBool("attack", false);
        }
    } // Update() 메서드 종료
    
    GameObject FindEnemy()
    {
        GameObject enemyObj = null;

        // 적 진영의 적을 찾는 로직 구현
        // 적 진영의 리스트 중 가장 첫번째 적 찾기
        if (_team == Team.BLUE)
        {
            if (_gameDir._red_List != null && _gameDir._red_List.Length > 0)
                enemyObj = _gameDir._red_List[0];
        }
        else if (_team == Team.RED)
        {
            if (_gameDir._blue_List != null && _gameDir._blue_List.Length > 0)
                enemyObj = _gameDir._blue_List[0];
        }
        return enemyObj;
        


    }
   

    public void SetAttackCol(int on) // 1은 on, 0은 off로 약속
    {
        // 널 체크
        if (_attackCol == null)
            return;

        if(on == 1)
        {
            _attackCol.enabled = true; // 공격 충돌체 켜기
        }
        else
        {
            _attackCol.enabled = false; // 공격 충돌체 끄기
        }
    }

    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);

        if (_hp > 0)
        {
            // 히트 애니메이션 재생
            _anim.SetTrigger("hit");

            
        }
        else
        {
            // 죽음 애니메이션 재생
            _anim.SetBool("die", true);
            Invoke("Disappear", 1.5f);
        }
    }
    
    
    

    void CheckDistance() // 거리를 체크하는 함수
    {
        
        
        // 나와 적 캐릭터 간의 거리를 계산 해서, 설정된 공격범위 안에 들어오면 공격개시

        float pos1 = transform.position.x; // 내 캐릭터의 위치
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리를 나타내는 변수 ( 두 객체간의 x좌표 사이의 거리 )
        // Mathf는 유니티에서 제공해주는데 이 f의 뜻은 float라는 뜻임


        if (distance < _attackRange /*&& _hp > 0*/) // 나와 적 캐리터간의 거리가 공격범위 안에 들어오면
        {
            // 공격
            _anim.SetBool("attack", true);
        }
        else // 공격범위를 벗어나면
        {
            _anim.SetBool("attack", false);
        }
    }

    public void OnAttack()
    {
        Attack();
    }

    public virtual void Attack()
    {
       
    }
}
