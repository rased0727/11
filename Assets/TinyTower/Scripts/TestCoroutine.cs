using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class TestCoroutine : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 코루틴 : 시간의 흐름을 제어하기 매우 용이
            // 코루틴 테스트 Coroutine

            // 코루틴의 호출 방법

            StartCoroutine( TestCo() );

            // StartCoroutine(MyUpdate());

            // StopCoroutine("MyUpdate");

            Invoke("Test", 1.0f);

            StartCoroutine(Test(100));
        }

        void Test()
        {

        }

        IEnumerator Test(int a)
        {
            yield return new WaitForSeconds(1.0f);


            // 

            yield return null;
        }


        IEnumerator MyUpdate()
        {
            while(true)
            {
                //





                //
                yield return null;
            }
        }


        IEnumerator TestCo()
        {
            Debug.Log("테스트 1: " + Time.time);

            yield return null; // 한 프레임 대기

            Debug.Log("테스트 2 : " + Time.time);

            yield return new WaitForSeconds(4.0f); //4초간 대기

            Debug.Log("테스트 3 : " + Time.time);

            while (true)
            {
                yield return null;

                Debug.Log("테스트 : " + Time.time);
            }
        }




        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
