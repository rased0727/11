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
        // 최초 1초 딜레이 후 함수 호출
        // Invoke는 딜레이 후 함수를 호출하는 메서드임
        Invoke("MakeOozeSet", _delay);



    }
    void MakeOozeSet()
    {
        // 복제한 것을 cloneobj 변수에 넣어주고, 복제된 건 활성화(원본은 비활성화 했기때문에)
        GameObject cloneObj = Instantiate(_oozeTemplate);
        cloneObj.SetActive(true);

        
        Invoke("MakeOozeSet", _delay); // 자신을 다시 재귀호출 하므로 딜레이를 두고 복제가 반복 됨



    }
}
