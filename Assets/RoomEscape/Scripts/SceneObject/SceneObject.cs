using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{

    // 잠긴문, 콘센트,
    // 화분, 책장, 조명
    // 액자, 창문, 시계



    public class SceneObject : MonoBehaviour
{
        public RectTransform _infoTextTrans;
        public string _infoText = "";

        // Start is called before the first frame update
        void Start()
        {
            GameObject canvas = UIManager.I.gameObject;

            _infoTextTrans = canvas.transform.Find("InfoText").GetComponent<RectTransform>();

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
    }
}
