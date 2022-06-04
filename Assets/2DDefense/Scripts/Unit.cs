using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public RectTransform _hpBarTrans;
    public Vector3 _hpBarOffset;
    public int _maxHp = 100;
    public int _hp = 0;

    public float _speed = 1.0f; // 캐릭터 이동속도
    public float _attackRange = 0.75f;

    public GameObject _enemyObj;

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    BoxCollider2D _attackCol;

    // Start is called before the first frame update
    void Start()
    {
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
        

        //체력 초기화
        _hp = _maxHp;
        RefreshHpBar();





    }

    void RefreshHpBar() // 체력바 초기화 및 연동
    {
        // 체력바 초기화 및 연동
        if (_hpBarTrans != null)
        {
            // fill 이미지 컴포넌트 찾기
            Image fillImg = _hpBarTrans.Find("fill").GetComponent<Image>();
            // 최대 체력 대비 현재 체력 비율을 fillAmount 에 넣어줌
            fillImg.fillAmount = (float)_hp / (float)_maxHp; // fillAmount는 float 이기 때문에 _hp와 _maxHp의 경우 int 여서 형변환 해줌.
        }
    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody 를 건드려서 앞으로 이동

        // 캐릭터를 이동하는 2가지 방법
        // 1. rigidbody.Addforce 함수를 힘을 주어서 이동 = 가속도 이동
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity 변수(x축만)를 직접 건드려서 이동 = 등속도 이동
        bool isAttacking = _anim.GetBool("attack");

        /*
         * if (isAttacking)
        {
            Vector2 vel = _rigid.velocity;
            vel.x = 0.0f;
            _rigid.velocity = vel;
        }
        else*/
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
       
       
        

        if (_enemyObj != null) // 적이 설정되어 있을때만
        {
            CheckDistance(); // 거리 체크 함수 호출
        }

        UpdateHpBarPos();

    } // Update() 메서드 종료

    void UpdateHpBarPos() // 체력바가 항상 유닛을 따라 다니도록 해주는 메서드
    {
        // 이 유닛의 위치를 가져와서 (월드 좌표)
        Vector3 unitPos = transform.position;

        // 위에서 가져온 월드좌표를 UI좌표(스크린 좌표)로 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

        // 혹시 _hpBarTrans 객체에 아직 아무것도 들어 있지 않다면 널체크
        if(_hpBarTrans != null)
        {
            // 체력바의 UI좌표를 위에서 변환한 캐릭터의 UI좌표로 바꿔줌
            _hpBarTrans.position = screenPos;
        }
        


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

    public void DoDamage(int damage)
    {
        _hp -= damage;

        // 히트 애니메이션 재생
        _anim.SetTrigger("hit");

        RefreshHpBar();
    }

    void CheckDistance() // 거리를 체크하는 함수
    {
        // 나와 적 캐릭터 간의 거리를 계산 해서, 설정된 공격범위 안에 들어오면 공격개시

        float pos1 = transform.position.x; // 내 캐릭터의 위치
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리를 나타내는 변수 ( 두 객체간의 x좌표 사이의 거리 )
        // Mathf는 유니티에서 제공해주는데 이 f의 뜻은 float라는 뜻임


        if (distance < _attackRange) // 나와 적 캐리터간의 거리가 공격범위 안에 들어오면
        {
            // 공격
            _anim.SetBool("attack", true);

            // 데미지 처리
            //Unit enemyUnit = _enemyObj.GetComponent<Unit>();
            //enemyUnit.DoDamage(10);
        }
        else // 공격범위를 벗어나면
        {
            _anim.SetBool("attack", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        Debug.Log("나는 누구인가? " + gameObject.name);

        Debug.Log("나를 충돌한 물체는 무엇인가? " + collison.gameObject.name);

        if(collison.gameObject.name == "AttackCol")
        {
            DoDamage(10);
        }
    }
}
