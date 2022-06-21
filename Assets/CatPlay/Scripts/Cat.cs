using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPlay
{
	public class Cat : MonoBehaviour
	{
		Rigidbody2D _rigid;
		public float _speed = 10.0f;
		SpriteRenderer _renderer;
		Animator _anim;


		// 이모티콘들 모음
		GameObject _emoteSweat;
		GameObject _emoteHappy;


		void Start()
	    {
			// 이모티콘들 넣어주기
			_emoteSweat = transform.Find("emote_sweat").gameObject;
			_emoteSweat.SetActive(false);
			_emoteHappy = transform.Find("emote_happy").gameObject;
			_emoteHappy.SetActive(false);


			// 주요 컴포넌트들 넣어주기
			_rigid = GetComponent<Rigidbody2D>();
			_renderer = GetComponent <SpriteRenderer>();
			_anim = GetComponent<Animator>();


			// Idle 랜덤 애니메이션 재생용 
			float delay = Random.Range(3.0f, 10.0f);
			Invoke("PlayIdle", delay);

		}
		void PlayIdle()
        {
			int random = Random.Range(2, 4); // 주사위가 아니면 2 아니면 3이 나옴. 랜덤 앞의 파라메터는 포함최소값, 뒤의 파라메터는 배제최대값임
			/*if (random == 2)
            {
				_anim.SetTrigger("idle2");
			}
			else if(random == 3)
            {
				_anim.SetTrigger("idle3");
			}
			//위 수식을 아래처럼 오늘 배운 삼항 연산자로 바꿔 봄 */
			string temp = "";
			temp = (random == 2) ? "idle2" : "idle3";
			_anim.SetTrigger(temp);


			float delay = Random.Range(3.0f, 10.0f);
			Invoke("PlayIdle", delay);
        }

	    void FixedUpdate()
	    {
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			if(h == 0 && v == 0)
            {
				_anim.SetBool("moving", false);

			}
            else
            {
				_anim.SetBool("moving", true);
				
			}
			if (_anim.GetBool("eating") == false)
            {
				Move(h, v);
				Flip(h);
			}
			




		}
        void Move(float h, float v)
        {
			//Debug.Log("h : " + h);
			//Debug.Log(string.Format("v : {0}", v));

			// 왼쪽 시프트 키를 누르면 대쉬!
			float runSpeed = 1.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
				runSpeed = 2.0f;
            }

			float fixedDeltaTime = Time.fixedDeltaTime;

			_rigid.velocity = new Vector2(h, v) * fixedDeltaTime * _speed * runSpeed;

			float vel = _rigid.velocity.magnitude;
			_anim.SetFloat("velocity", vel); // 현재 속도에 따라 Walk 애니메이션을 줄지 Run 애니메이션을 줄지가 정해짐

			
		}

		void Flip(float h)
        {
			if (h < 0)
            {
				_renderer.flipX = false;
			}
            else if ( h > 0)
            {
				_renderer.flipX = true;
			}
        }

		void Eat()
        {
			_emoteSweat.SetActive(true);
			_anim.SetBool("eating", true);

			Invoke("StopEat", 5.0f);

		}
		void StopEat()
        {
			_emoteSweat.SetActive(false);
			_emoteHappy.SetActive(true);
			_anim.SetBool("eating", false);

			Invoke("StopHappy", 3.0f);
		}
		void StopHappy()
        {
			_emoteHappy.SetActive(false);
			Debug.Log("됐나?");
		}
		void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.name == "Dish")
			{
				Eat();
			}

		}
		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.name.Contains("Heart"))
			{
				Destroy(collision.gameObject);
			}
			else if (collision.gameObject.name.Contains("Coin"))
			{
				Destroy(collision.gameObject);
			}

		}

	}
}

