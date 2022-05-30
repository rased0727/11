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
        // rigidbody 를 건드려서 앞으로 이동

        // 캐릭터를 이동하는 2가지 방법
        // 1. rigidbody.Addforce 함수를 힘을 주어서 이동 = 가속도 이동
        //_rigid.AddForce(new Vector2(10, 0));

        // 2. rigidbody.vellocity 변수(x축만)를 직접 건드려서 이동 = 등속도 이동
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
