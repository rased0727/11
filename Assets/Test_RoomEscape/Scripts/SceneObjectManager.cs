using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_RoomEscape
{
    public class SceneObjectManager : MonoBehaviour
    {
        public SceneObject[] _sceneObjectList;


        // Start is called before the first frame update
        void Start()
        {
            _sceneObjectList = GetComponentsInChildren<SceneObject>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnClick_BackBtn()
        {
            // SceneObject 컴포넌트가 붙은 요소들을 각각 배열에 다 넣어줌
            for(int i=0; i< _sceneObjectList.Length; i++)
            {
                SceneObject obj = _sceneObjectList[i];
                obj.OnClick_BackBtn();
            }
        }
    }
}
