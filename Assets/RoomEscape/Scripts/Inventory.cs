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
        public static Inventory I; //ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
        
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

                UIManager.I._ui_inven.Add();
            }
            
        }
    }
}
