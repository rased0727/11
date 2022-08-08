using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{

    public class SceneItem : MonoBehaviour
    {
        public RectTransform _itemTextTrans;
        public string _itemText = "";

        // Start is called before the first frame update
        void Start()
        {
            GameObject canvas = UIManager.I.gameObject;

            _itemTextTrans = canvas.transform.Find("ItemText").GetComponent<RectTransform>();

            _itemTextTrans.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseEnter()
        {
            _itemTextTrans.gameObject.SetActive(true);
            Text text = _itemTextTrans.GetComponent<Text>();
            text.text = _itemText;
        }

        void OnMouseExit()
        {
            _itemTextTrans.gameObject.SetActive(false);
        }

        void OnMouseDown()
        {

        }


    }
}
