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

    // �� ���� ������ �޾� ������ �� ��ȯ���ִ� �Լ�
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
        // ���α׷��� ����� ������ �ð��� ǥ���Ѵ�.
        //Debug.Log("Hello World! " + Time.time);
    }

}
