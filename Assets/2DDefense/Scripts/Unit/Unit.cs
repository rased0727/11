using System;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public RectTransform _hpBarTrans;
    public Vector3 _hpBarOffset;
    public int _maxHp = 100;
    public int _hp = 0;

    public float _speed = 1.0f; // ĳ���� �̵��ӵ�
    public float _attackRange = 0.75f;

    public GameObject _enemyObj;
    public GameObject _hitEffectTemplate;

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

        // �� üũ
        if (childTrans != null)
        {
            _attackCol = childTrans.GetComponent<BoxCollider2D>();
        }


        // ���� �浹ü�� �����Ҷ��� ���д�
        if (_attackCol != null)
        {
            _attackCol.enabled = false;
        }
        

        //ü�� �ʱ�ȭ
        _hp = _maxHp;
        RefreshHpBar();





    }

    // ü�¹� �ʱ�ȭ �� ����
    void RefreshHpBar() 
    {
        // ü�¹� �ʱ�ȭ �� ����
        if (_hpBarTrans != null)
        {
            // fill �̹��� ������Ʈ ã��
            Image fillImg = _hpBarTrans.Find("fill").GetComponent<Image>();
            // �ִ� ü�� ��� ���� ü�� ������ fillAmount �� �־���
            fillImg.fillAmount = (float)_hp / (float)_maxHp; // fillAmount�� float �̱� ������ _hp�� _maxHp�� ��� int ���� ����ȯ ����.
        }
    }

    // Update is called once per frame
    void Update()
    {
        // rigidbody �� �ǵ���� ������ �̵�

        // ĳ���͸� �̵��ϴ� 2���� ���
        // 1. rigidbody.Addforce �Լ��� ���� �־ �̵� = ���ӵ� �̵�
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity ����(x�ุ)�� ���� �ǵ���� �̵� = ��ӵ� �̵�
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
       
       
        

        if (_enemyObj != null) // ���� �����Ǿ� ��������
        {
            CheckDistance(); // �Ÿ� üũ �Լ� ȣ��
        }
        else
        {
            _anim.SetBool("attack", false);
        }

        UpdateHpBarPos();

    } // Update() �޼��� ����

    void UpdateHpBarPos() // ü�¹ٰ� �׻� ������ ���� �ٴϵ��� ���ִ� �޼���
    {
        // �� ������ ��ġ�� �����ͼ� (���� ��ǥ)
        Vector3 unitPos = transform.position;

        // ������ ������ ������ǥ�� UI��ǥ(��ũ�� ��ǥ)�� ��ȯ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

        // Ȥ�� _hpBarTrans ��ü�� ���� �ƹ��͵� ��� ���� �ʴٸ� ��üũ
        if(_hpBarTrans != null)
        {
            // ü�¹��� UI��ǥ�� ������ ��ȯ�� ĳ������ UI��ǥ�� �ٲ���
            _hpBarTrans.position = screenPos;
        }
        


    }
    public void SetAttackCol(int on) // 1�� on, 0�� off�� ���
    {
        // �� üũ
        if (_attackCol == null)
            return;

        if(on == 1)
        {
            _attackCol.enabled = true; // ���� �浹ü �ѱ�
        }
        else
        {
            _attackCol.enabled = false; // ���� �浹ü ����
        }
    }

    public void DoDamage(int damage)
    {
        _hp -= damage;
        _hp = Math.Max(_hp, 0); // _hp�� 0 �� ���ؼ� ū ���� �־��ش�. �� �ּҰ��� 0���� �����ϴ� �ڵ�

        if (_hp > 0)
        {
            // ��Ʈ �ִϸ��̼� ���
            _anim.SetTrigger("hit");

            
        }
        else
        {
            // ���� �ִϸ��̼� ���
            _anim.SetBool("die", true);
            Invoke("Disappear", 1.5f);
        }

        // ü�� ���� �Լ� ȣ��
        RefreshHpBar();

        // �ǰ� ����Ʈ ��� �Լ� ȣ��
        if (_hitEffectTemplate != null)
        {
            PlayHitEffect();
        }
    }
    
    // �ǰ� ����Ʈ ���
    void PlayHitEffect()
    {
        GameObject hitEffObj = Instantiate(_hitEffectTemplate);
        hitEffObj.SetActive(true);
        hitEffObj.transform.position = transform.position;
    }
    void Disappear()
    {
        Destroy(gameObject);
        Destroy(_hpBarTrans.gameObject);
    }

    void CheckDistance() // �Ÿ��� üũ�ϴ� �Լ�
    {
        
        
        // ���� �� ĳ���� ���� �Ÿ��� ��� �ؼ�, ������ ���ݹ��� �ȿ� ������ ���ݰ���

        float pos1 = transform.position.x; // �� ĳ������ ��ġ
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // �� ĳ���� ���� �Ÿ��� ��Ÿ���� ���� ( �� ��ü���� x��ǥ ������ �Ÿ� )
        // Mathf�� ����Ƽ���� �������ִµ� �� f�� ���� float��� ����


        if (distance < _attackRange /*&& _hp > 0*/) // ���� �� ĳ���Ͱ��� �Ÿ��� ���ݹ��� �ȿ� ������
        {
            // ����
            _anim.SetBool("attack", true);
        }
        else // ���ݹ����� �����
        {
            _anim.SetBool("attack", false);
        }
    }

    public void OnAttack()
    {
        Attack();
    }

    protected virtual void Attack()
    {
       
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        Debug.Log("��(" + gameObject.name + ")�� �浹�� ��ü�� �����ΰ�? " + collison.gameObject.name);

        //if(collison.gameObject.name == "AttackCol" || collison.gameObject.name == "Arrow")

        if(collison.gameObject.tag == "AttackCol")
        {
            DoDamage(10);

            // ȭ�� ������ �� �� ȭ�� �����ֱ�
            Arrow arrow = collison.gameObject.GetComponent<Arrow>();
            if(arrow != null)
            {
                Destroy(arrow.gameObject);
            }

        }
    }


    void Test(params object[] o)
    {

    }
    
}
