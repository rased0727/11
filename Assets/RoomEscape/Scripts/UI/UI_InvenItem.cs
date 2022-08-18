using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{
    public class UI_InvenItem : MonoBehaviour
    {
        public Text _itemNameTxt;


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // 획득된 아이템 정보를 받아서
        // 그 정보대로, 이름, 아이콘, 수량 등 표시
        public void SetInfo(string itemName)
        {
            _itemNameTxt = transform.Find("itemNameTxt").GetComponent<Text>();
            _itemNameTxt.text = itemName;


        }
    }


}
