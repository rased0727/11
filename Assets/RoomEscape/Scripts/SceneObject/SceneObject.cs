using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{

    // ��乮, �ܼ�Ʈ,
    // ȭ��, å��, ����
    // ����, â��, �ð�



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
            // ���콺 Ŭ����, ���� ����ī�޶� �ִٸ�, �ش� ī�޶� ���ֱ�
            if(_showCamera != null)
            {
                //���� ī�޶� Ȱ��ȭ
                _showCamera.gameObject.SetActive(true);

                Collider col = GetComponent<Collider>();
                col.enabled = false;

                // �䰡 �ٲ������ �˸���(������ ����)
                UIManager.I.OnChangeView(false);

            }

        }

        public void OnClick_BackBtn()
        {
            // ����ī�޶� ���ִ� ��������Ʈ�� ���󺹱� ��Ų��
            if(_showCamera != null)
            {
                if( _showCamera.gameObject.activeSelf == true )
                {
                    //���� ī�޶� ��Ȱ��ȭ
                    _showCamera.gameObject.SetActive(false);

                    Collider col = GetComponent<Collider>();
                    col.enabled = true;

                    // �䰡 �ٲ������ �˸���(���κ�� ���ư���)
                    UIManager.I.OnChangeView(true);
                }
            }
        }
    }
}
