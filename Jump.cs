using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D _rigid;
    public AudioSource _fxBird;
    
    // Start is called before the first frame update
    void Start()
    {
        // 이 스크림트는 bird에 붙어 있으므로 밑의 gameObject는 bird를 뜻함
        _rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            // Vector2의 첫번째 파라메터는 x좌표, 두번째 파라메터는 y좌표
            Vector2 force = new Vector2(0, 100);
            _rigid.AddForce(force);

            _fxBird.Play();
        }
        Vector3 vel = _rigid.velocity;
        
        // 점프 속도 제한 값 limit이 5.0f를 넘지 않도록
        // Mathf는 유니티에서 지원하는 수학개념이 포함되어 있는 클래스
        // Min 함수는 들어있는 파라메터 2개를 비교해서 작은 값을 반환
        float limit = Mathf.Min(5.0f, vel.y);

        // 중력의 속도를 x는 그대로 유지하기 위해서 vel.x 를 넣고, y는 위에서 정해준 limit 값을 넣고, z축은 안쓰기 때문에 0.0f 넣었음
        _rigid.velocity = new Vector3(vel.x, limit, 0.0f);
    }
}
