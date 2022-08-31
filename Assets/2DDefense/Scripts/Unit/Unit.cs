using System;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MapObject, IAttacker
{
    public float _speed = 1.0f; // ĳ���� �̵��ӵ�
    public float _attackRange = 1.75f;

    public GameObject _enemyObj;
    

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    BoxCollider2D _attackCol;

    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start(); // �θ��� Start() �Լ��� ���� �����ؾ� ü���ʱ�ȭ�� ��

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
        







    }

   

    // Update is called once per frame
    void Update()
    {
        base.UpdateHpBarPos();

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


        // ���� ã�� �޼���
        _enemyObj = FindEnemy();
        

        if (_enemyObj != null) // ���� �����Ǿ� ��������
        {
            CheckDistance(); // �Ÿ� üũ �Լ� ȣ��
        }
        else
        {
            _anim.SetBool("attack", false);
        }
    } // Update() �޼��� ����
    
    GameObject FindEnemy()
    {
        GameObject enemyObj = null;

        // �� ������ ���� ã�� ���� ����
        // �� ������ ����Ʈ �� ���� ù��° �� ã��
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

    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);

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

    public virtual void Attack()
    {
       
    }
}
