using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class SceneItemInfo
    {
        public string _name;
        public int _count;



    }

    public class Inventory : MonoBehaviour
    {
        public static Inventory I; //싱글톤 인스턴스
        
        public List<string> _itemList;

        void Awake()
        {
            I = this;
        }


        public void AddItem(string itemName)
        {
            if(_itemList.Contains(itemName) == false)
            {
                _itemList.Add(itemName);

                // UI_Inventory에 알려서 UI에도 추가하기
                UIManager.I._ui_iven.Add(itemName);

            }
            
        }
    }
}
