using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
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
            /*foreach(SceneObject obj in _sceneObjectList)
            {
                obj.OnClick_BackBtn();
            }*/


            for(int i=0; i< _sceneObjectList.Length; i++)
            {
                SceneObject obj = _sceneObjectList[i];
                obj.OnClick_BackBtn();
            }


        }
    }
}
