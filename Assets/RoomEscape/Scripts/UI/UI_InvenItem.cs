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

        // ȹ��� ������ ������ �޾Ƽ�
        // �� �������, �̸�, ������, ���� �� ǥ��
        public void SetInfo(string itemName)
        {
            _itemNameTxt = transform.Find("itemNameTxt").GetComponent<Text>();
            _itemNameTxt.text = itemName;


        }
    }


}
