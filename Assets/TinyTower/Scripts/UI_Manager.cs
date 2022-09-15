using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TinyTower
{
    public class UI_Manager : MonoBehaviour
    {
        Text _goldTxt;
        GraphicRaycaster _raycaster;

        public static UI_Manager I; // I는 싱글톤 인스턴스를 의미

        public UI_Info_Floor _ui_info_floor;

        void Awake()
        {
            I = this;
        }

        // Start is called before the first frame update
        public void Init()
        {
            _raycaster = GetComponent<GraphicRaycaster>();

            _ui_info_floor = transform.Find("UI_Info_Floor").GetComponent<UI_Info_Floor>();
            _ui_info_floor.gameObject.SetActive(false);
            _ui_info_floor.Init();

            _goldTxt = transform.Find("UI_Topbar/gold/goldTxt").GetComponent<Text>();

            // 골드 UI부터 리프레시
            Refresh_Gold_UI();

        }

        public void Refresh_Gold_UI()
        {
            _goldTxt.text = UserData.I.Gold.ToString();
        }


        // Update is called once per frame
        void Update()
        {
            
        }

        public bool UI_Touched()
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            bool uiTouched = false;
            _raycaster.Raycast(data, results);
            foreach (RaycastResult r in results)
            {
                /*if (r.gameObject.name == "LeftTouchArea" ||
                    r.gameObject.name == "Handle" ||
                    r.gameObject.name == "Fixed Joystick")
                {

                }
                else*/
                {
                    uiTouched = true;
                    Debug.Log("UI 요소가 터치 되었습니다: " + r.gameObject.name);
                }
            }

            return uiTouched;
        }
    }
}
