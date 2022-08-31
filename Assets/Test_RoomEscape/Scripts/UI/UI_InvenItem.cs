using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Test_RoomEscape
{
    public class UI_InvenItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Text _itemNameTxt;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown: "+ eventData.position);
        }
        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag: " + eventData.position);

            //해당 3D 모델(예 : 열쇠)를 이 마우스위치로 월드포지션으로 변형한 위치로 연동

        }
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp: " + eventData.position);
        }

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
            Debug.Log("1 " + itemName);
            _itemNameTxt = transform.Find("itemNameTxt").GetComponent<Text>();
            _itemNameTxt.text = itemName;


        }
    }


}
