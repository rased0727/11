using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : MonoBehaviour
{
    public float _speed = 1.0f; // ĳ���� �̵��ӵ�
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
        // rigidbody �� �ǵ���� ������ �̵�

        // ĳ���͸� �̵��ϴ� 2���� ���
        // 1. rigidbody.Addforce �Լ��� ���� �־ �̵� = ���ӵ� �̵�
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity ����(x�ุ)�� ���� �ǵ���� �̵� = ��ӵ� �̵�
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
        
        if (_enemyObj != null) // ���� �����Ǿ� ��������
        {
            CheckDistance(); // �Ÿ� üũ �Լ� ȣ��
        }
        

    }
    void CheckDistance() // �Ÿ��� üũ�ϴ� �Լ�
    {
        // ���� �� ĳ���� ���� �Ÿ��� ��� �ؼ�, ������ ���ݹ��� �ȿ� ������ ���ݰ���
        
        float pos1 = transform.position.x; // �� ĳ������ ��ġ
        float pos2 = _enemyObj.transform.position.x;

        float distance = Mathf.Abs(pos1 - pos2); // �� ĳ���� ���� �Ÿ��� ��Ÿ���� ���� ( �� ��ü���� x��ǥ ������ �Ÿ� )
        // Mathf�� ����Ƽ���� �������ִµ� �� f�� ���� float��� ����


        if ( distance < _attackRange) // ���� �� ĳ���Ͱ��� �Ÿ��� ���ݹ��� �ȿ� ������
        {
            // ����
            _anim.SetBool("attack", true);
        }
        else // ���ݹ����� �����
        {
            _anim.SetBool("attack", false);
        }
    }
}
