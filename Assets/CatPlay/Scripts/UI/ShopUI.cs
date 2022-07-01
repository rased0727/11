using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPlay
{
    public class ShopUI : MonoBehaviour
    {
        public GameData _gameData;

        public List<TestItem> _itemList;

        public Transform _contentTrans;
        public GameObject _template_shopItem;
        public GameObject _popup;

        // Start is called before the first frame update
        void Start()
        {
            _contentTrans = transform.Find("Scroll View_Items").Find("Viewport").Find("Content");
            _template_shopItem = _contentTrans.GetComponentInChildren<TestItem>(true).gameObject;
            _template_shopItem.SetActive(false);

            _itemList = new List<TestItem>();

            List<GameData_TestItem> shopDataList = _gameData._test_item_data;

            for (int i = 0; i < shopDataList.Count; i++)
            {
                //Debug.Log("아이템 : " + i);
                GameObject obj = Instantiate(_template_shopItem);
                obj.transform.parent = _contentTrans;
                obj.SetActive(true);
                TestItem item = obj.GetComponent<TestItem>();

                GameData_TestItem data = shopDataList[i];

                item.SetData(data); // 일일미션데이터를 각 항목(item)에 넣어준다
                _itemList.Add(item);                
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnClose()
        {
            gameObject.SetActive(false);
        }
        public void OnClick_Popup()
        {
            _popup.SetActive(true);
        }
        public void OnClick_PopupCancel()
        {
            _popup.SetActive(false);
        }
    }
}
