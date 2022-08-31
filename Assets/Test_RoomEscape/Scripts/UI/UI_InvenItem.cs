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

            //�ش� 3D ��(�� : ����)�� �� ���콺��ġ�� �������������� ������ ��ġ�� ����

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

        // ȹ��� ������ ������ �޾Ƽ�
        // �� �������, �̸�, ������, ���� �� ǥ��
        public void SetInfo(string itemName)
        {
            Debug.Log("1 " + itemName);
            _itemNameTxt = transform.Find("itemNameTxt").GetComponent<Text>();
            _itemNameTxt.text = itemName;


        }
    }


}
