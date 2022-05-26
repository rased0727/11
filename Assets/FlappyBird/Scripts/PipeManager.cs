using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    
    public GameObject _pipeSetTemplate;
    public GameManager _gameMgr;
    float _delay = 1.2f;
    public float _pipeRandom = 1.3f;

    void Start()
    {
        // ������ ���д�(���� ���ϵ���)
        _pipeSetTemplate.SetActive(false);
        _gameMgr = FindObjectOfType<GameManager>();

    }
    public void Start_MakePipeSet()
    {
        // ���� 1�� ������ �� �Լ� ȣ��
        // Invoke�� ������ �� �Լ��� ȣ���ϴ� �޼�����
        Invoke("MakePipeSet", _delay);
        


    }
    void MakePipeSet()
    {
        // ������ ���� cloneobj ������ �־��ְ�, ������ �� Ȱ��ȭ(������ ��Ȱ��ȭ �߱⶧����)
        GameObject cloneObj = Instantiate(_pipeSetTemplate);
        cloneObj.SetActive(true);

        float yPos = Random.Range(-_pipeRandom, _pipeRandom);
        cloneObj.transform.position = new Vector3(0, yPos, 0);

        // �� ������ �ݺ��ǵ���, 1�� ������ ��, MakePipeSet �Լ� ȣ��
        if (_gameMgr._isGameOver == false)
        {
            Invoke("MakePipeSet", _delay); // �ڽ��� �ٽ� ���ȣ�� �ϹǷ� �����̸� �ΰ� ������ �ݺ� ��
        }
            


    }
}
