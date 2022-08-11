using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{
    public class SceneItem : MonoBehaviour
    {
        RectTransform _infoTextTrans;
        public string _infoText = "";

        // Start is called before the first frame update
        void Start()
        {
            GameObject canvas = UIManager.I.gameObject;

            _infoTextTrans = canvas.transform.Find("InfoText_Item").GetComponent<RectTransform>();

            _infoTextTrans.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnMouseEnter()
        {
            Debug.Log("OnMouseEnter: " + gameObject.name);

            _infoTextTrans.gameObject.SetActive(true);
            Text text = _infoTextTrans.GetComponent<Text>();
            text.text = _infoText;
        }
        void OnMouseExit()
        {
            Debug.Log("OnMouseExit: " + gameObject.name);

            _infoTextTrans.gameObject.SetActive(false);
        }

        void OnMouseDown()
        {
            // 인벤토리에 접근해서, 데이터(아이템)를 넣어주기

            Inventory.I.AddItem(_infoText);

            gameObject.SetActive(false);

            _infoTextTrans.gameObject.SetActive(false);
        }
    }
}
