using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Projectile = 발사체, 날아가는 공격 물체를 구현하는 용도
public class Projectile : MonoBehaviour
{
    public Team _team;
    Rigidbody2D _rigid;
    public float _flyForce = 500.0f; // x축으로의 투사체 속도

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(_flyForce, 0.0f);
        _rigid.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
