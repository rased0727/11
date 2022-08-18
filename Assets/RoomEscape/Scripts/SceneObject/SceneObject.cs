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
        public Camera _showCamera;
        public RectTransform _infoTextTrans;
        public string _infoText = "";

        // Start is called before the first frame update
        protected virtual void Start()
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

        protected virtual void OnMouseDown()
        {
            // 마우스 클릭시, 만일 연출카메라가 있다면, 해당 카메라 켜주기
            if(_showCamera != null)
            {
                //연출 카메라 활성화
                _showCamera.gameObject.SetActive(true);

                Collider col = GetComponent<Collider>();
                col.enabled = false;

                // 뷰가 바뀌었음을 알린다(연출뷰로 간다)
                UIManager.I.OnChangeView(false);

            }

        }

        public void OnClick_BackBtn()
        {
            // 연출카메라가 켜있던 씬오브젝트는 원상복귀 시킨다
            if(_showCamera != null)
            {
                if( _showCamera.gameObject.activeSelf == true )
                {
                    //연출 카메라 비활성화
                    _showCamera.gameObject.SetActive(false);

                    Collider col = GetComponent<Collider>();
                    col.enabled = true;

                    // 뷰가 바뀌었음을 알린다(메인뷰로 돌아간다)
                    UIManager.I.OnChangeView(true);
                }
            }
        }
    }
}
