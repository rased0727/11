using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Test_RoomEscape
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager I;

        GameObject _backBtnObj;
        GameObject _leftBtnObj;
        GameObject _rightBtnObj;

        public UI_Inventory _ui_iven;

        GraphicRaycaster _raycaster;

        void Awake()
        {
            I = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            _raycaster = GetComponent<GraphicRaycaster>();
            _ui_iven = transform.Find("UI_Inventory").GetComponent<UI_Inventory>();

            _backBtnObj = transform.Find("BackButton").gameObject;
            _leftBtnObj = transform.Find("LeftButton").gameObject;
            _rightBtnObj = transform.Find("RightButton").gameObject;

            bool mainView = true;
            OnChangeView(mainView);
        }
        public void OnChangeView(bool isMainView) // true: ���� �� ����, false: Ȯ��� ����
        {
            // ���� ���κ� ���¶�� (true) ���ư�� ���̻� ���ϵ��� ��Ȱ��ȭ, �������� Ȱ��ȭ
            _backBtnObj.SetActive(!isMainView);
            _leftBtnObj.SetActive(isMainView);
            _rightBtnObj.SetActive(isMainView);
        }


        // Update is called once per frame
        void Update()
        {
            IsUITouched();
        }
        public bool IsUITouched() // UI��Ұ� ��ġ�Ǿ����� �˷��ִ� �Լ�
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            bool uiTouched = false;
            _raycaster.Raycast(data, results);
            foreach (RaycastResult r in results)
            {
                //Debug.Log("�ɸ� UI��ü : " + r.gameObject.name);
                uiTouched = true;
            }
            return uiTouched;
        }
    }
}
