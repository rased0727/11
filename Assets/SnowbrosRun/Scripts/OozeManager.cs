using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozeManager : MonoBehaviour
{
    public GameObject _oozeTemplate;

    public float _delay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _oozeTemplate.SetActive(false);
    }
    public void Start_OozePipeSet()
    {
        // ���� 1�� ������ �� �Լ� ȣ��
        // Invoke�� ������ �� �Լ��� ȣ���ϴ� �޼�����
        Invoke("MakeOozeSet", _delay);



    }
    void MakeOozeSet()
    {
        // ������ ���� cloneobj ������ �־��ְ�, ������ �� Ȱ��ȭ(������ ��Ȱ��ȭ �߱⶧����)
        GameObject cloneObj = Instantiate(_oozeTemplate);
        cloneObj.SetActive(true);

        
        Invoke("MakeOozeSet", _delay); // �ڽ��� �ٽ� ���ȣ�� �ϹǷ� �����̸� �ΰ� ������ �ݺ� ��



    }
}
