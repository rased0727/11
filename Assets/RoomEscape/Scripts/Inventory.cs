using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RoomEscape
{
    /*
    public class SceneItemInfo
    {
        public string _name;
        public int _count;

    }
    */
    public class Inventory : MonoBehaviour
    {
        public static Inventory I;

        // 아래 소스는 private로 두고 싶지만 인스펙터에 보여주고 싶을 때 SerializeField 를 사용한다.
        [SerializeField]List<string> _itemList;
        //public List<SceneItemInfo> _itemList; // 위의 SceneItemInfo와 연동해서 사용하는 방식도 있음

        private void Awake()
        {
            I = this;
        }

        public void AddItem(string itemName)
        {

            if (_itemList.Contains(itemName) == false)
            {
                _itemList.Add(itemName);
            }
            else
            {
                Debug.Log("이미 아이템이 있음");
            }
        }
    }
}
