using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager I;

        GameObject _backBtnObj;
        GameObject _leftBtnObj;
        GameObject _rightBtnObj;

        public UI_Inventory _ui_iven;

        void Awake()
        {
            I = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            _ui_iven = transform.Find("UI_Inventory").GetComponent<UI_Inventory>();

            _backBtnObj = transform.Find("BackButton").gameObject;


            _leftBtnObj = transform.Find("LeftButton").gameObject;


            _rightBtnObj = transform.Find("RightButton").gameObject;

            bool mainView = true;
            OnChangeView(mainView);
        }

        public void OnChangeView(bool isMainView) // true: ���� �� ����, false: Ȯ��� ����
        {
            _backBtnObj.SetActive(!isMainView);
            _leftBtnObj.SetActive(isMainView);
            _rightBtnObj.SetActive(isMainView);
        }


        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
