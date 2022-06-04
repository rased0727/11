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

    void RefreshHpBar() // ü�¹� �ʱ�ȭ �� ����
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
       
       
        

        if (_enemyObj != null) // ���� �����Ǿ� ��������
        {
            CheckDistance(); // �Ÿ� üũ �Լ� ȣ��
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

        // ��Ʈ �ִϸ��̼� ���
        _anim.SetTrigger("hit");

        RefreshHpBar();
    }

    void CheckDistance() // �Ÿ��� üũ�ϴ� �Լ�
    {
        // ���� �� ĳ���� ���� �Ÿ��� ��� �ؼ�, ������ ���ݹ��� �ȿ� ������ ���ݰ���

        float pos1 = transform.position.x; // �� ĳ������ ��ġ
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // �� ĳ���� ���� �Ÿ��� ��Ÿ���� ���� ( �� ��ü���� x��ǥ ������ �Ÿ� )
        // Mathf�� ����Ƽ���� �������ִµ� �� f�� ���� float��� ����


        if (distance < _attackRange) // ���� �� ĳ���Ͱ��� �Ÿ��� ���ݹ��� �ȿ� ������
        {
            // ����
            _anim.SetBool("attack", true);

            // ������ ó��
            //Unit enemyUnit = _enemyObj.GetComponent<Unit>();
            //enemyUnit.DoDamage(10);
        }
        else // ���ݹ����� �����
        {
            _anim.SetBool("attack", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        Debug.Log("���� �����ΰ�? " + gameObject.name);

        Debug.Log("���� �浹�� ��ü�� �����ΰ�? " + collison.gameObject.name);

        if(collison.gameObject.name == "AttackCol")
        {
            DoDamage(10);
        }
    }
}
