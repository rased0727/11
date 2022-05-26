using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test1();

        int c = MyPlus(10, 20) + 5;
        Debug.Log(c);

        Test2();
    }

    // 두 개의 정수를 받아 더해준 후 반환해주는 함수
    // This function is recieve two integers and return between two integers plus value.
    int MyPlus(int a, int b)
    {
        return a + b;
    }

    void Test1()
    {
        
    }

    // define function
    void Test2()
    {
        Debug.Log("Hello");
    }



    // Update is called once per frame
    void Update()
    {
        // Time.time is time what is excuted prgoram
        // 프로그램이 실행된 이후의 시간을 표시한다.
        //Debug.Log("Hello World! " + Time.time);
    }

}
