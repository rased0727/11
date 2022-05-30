using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : MonoBehaviour
{
    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();


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
            vel.x = 5.0f;
        }
        else
        {
            vel.x = -5.0f;
        }
        _rigid.velocity = vel;

    }
}
