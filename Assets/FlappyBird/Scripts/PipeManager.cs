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
        // 원본은 꺼둔다(동작 안하도록)
        _pipeSetTemplate.SetActive(false);
        _gameMgr = FindObjectOfType<GameManager>();

    }
    public void Start_MakePipeSet()
    {
        // 최초 1초 딜레이 후 함수 호출
        // Invoke는 딜레이 후 함수를 호출하는 메서드임
        Invoke("MakePipeSet", _delay);
        


    }
    void MakePipeSet()
    {
        // 복제한 것을 cloneobj 변수에 넣어주고, 복제된 건 활성화(원본은 비활성화 했기때문에)
        GameObject cloneObj = Instantiate(_pipeSetTemplate);
        cloneObj.SetActive(true);

        float yPos = Random.Range(-_pipeRandom, _pipeRandom);
        cloneObj.transform.position = new Vector3(0, yPos, 0);

        // 이 과정이 반복되도록, 1초 딜레이 후, MakePipeSet 함수 호출
        if (_gameMgr._isGameOver == false)
        {
            Invoke("MakePipeSet", _delay); // 자신을 다시 재귀호출 하므로 딜레이를 두고 복제가 반복 됨
        }
            


    }
}
