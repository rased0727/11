using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D _rigid;
    public AudioSource _fxBird;
    
    public float _jumpForce = 20f;
    public float _jumpLimit = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        // �� ��ũ��Ʈ�� bird�� �پ� �����Ƿ� ���� gameObject�� bird�� ����
        _rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            // Vector2�� ù��° �Ķ���ʹ� x��ǥ, �ι�° �Ķ���ʹ� y��ǥ
            Vector2 force = new Vector2(0, _jumpForce);
            _rigid.AddForce(force);

            _fxBird.Play();
        }
        Vector3 vel = _rigid.velocity;
        
        // ���� �ӵ� ���� �� limit�� ���� �ʵ���
        // Mathf�� ����Ƽ���� �����ϴ� ���а����� ���ԵǾ� �ִ� Ŭ����
        // Min �Լ��� ����ִ� �Ķ���� 2���� ���ؼ� ���� ���� ��ȯ
        float limit = Mathf.Min(_jumpLimit, vel.y);

        // �߷��� �ӵ��� x�� �״�� �����ϱ� ���ؼ� vel.x �� �ְ�, y�� ������ ������ limit ���� �ְ�, z���� �Ⱦ��� ������ 0.0f �־���
        _rigid.velocity = new Vector3(vel.x, limit, 0.0f);
    }
}
