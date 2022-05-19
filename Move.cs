using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameManager _gameMgr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameMgr._isIntro == true)
        {
            return;
        }
        
        /* 플래피버드는 좌우상하 이동이 필요 없기 때문에 전체 주석처리
        // GetKey는 지속적으로 누를때
        // GetkeyDown은 한번 눌렀을 때
        // GetKeyUp은 한번 누르고 땠을 때
        if( Input.GetKey(KeyCode.LeftArrow) ) // 왼쪽 화살표를 누르고 있는 중이면
        {
            //transform.position.x = transform.position.x - 1.0f; // 이건 원래 되야 하지만 transform.position 은 직접 수정이 불가능
            Vector3 pos = transform.position; // pos에 Vector3 라는 클래스를 담아두는 복수의 데이터가 들어있는 변수라고 생각하면 편함
            
            // 방법1 : new라는 키워드로 객체화 하고 사용
            transform.position = new Vector3(pos.x - 0.01f, pos.y, pos.z);

            // 방법2 : 그냥 바로 클래스변수의 값을 수정도 가능
            // pos.x = pos.x - 0.1f;
            // transform.position = pos;

        }
        if (Input.GetKey(KeyCode.RightArrow)) // 왼쪽 화살표를 누르고 있는 중이면
        {
            Vector3 pos = transform.position; // pos에 Vector3 라는 클래스를 담아두는 복수의 데이터가 들어있는 변수라고 생각하면 편함

            // 방법1 : new라는 키워드로 객체화 하고 사용
            //transform.position = new Vector3(pos.x + 0.01f, pos.y, pos.z);

            // 방법2 : 그냥 바로 클래스변수의 값을 수정도 가능
            pos.x = pos.x + 0.01f;
            transform.position = pos;


        }
        if (Input.GetKey(KeyCode.UpArrow)) // 왼쪽 화살표를 누르고 있는 중이면
        {
            Vector3 pos = transform.position; // pos에 Vector3 라는 클래스를 담아두는 복수의 데이터가 들어있는 변수라고 생각하면 편함

            // 방법1 : new라는 키워드로 객체화 하고 사용
            transform.position = new Vector3(pos.x, pos.y + 0.01f, pos.z);

        }
        if (Input.GetKey(KeyCode.DownArrow)) // 왼쪽 화살표를 누르고 있는 중이면
        {
            Vector3 pos = transform.position; // pos에 Vector3 라는 클래스를 담아두는 복수의 데이터가 들어있는 변수라고 생각하면 편함

            // 방법1 : new라는 키워드로 객체화 하고 사용
            transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);

        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 발생 : " + collision.gameObject.name);

        // GameManager에 Game Over 사실을 알려주기만 하면 됨
        _gameMgr.OnGameOver();

    }
}
