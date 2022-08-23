using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test_RoomEscape
{
    public class Door : SceneObject
    {
        Transform _doorPanelTrans;
        [SerializeField]bool _opened = false;


        protected override void Start()
        {
            base.Start();


            _doorPanelTrans = transform.Find("Component1/Group 4949");


            _opened = false;
        }


        protected override void OnMouseDown()
        {
            if (UIManager.I.IsUITouched() == true)
                return;
            base.OnMouseDown();

            // 문을 열고 닫고


            if (_opened == false) // 문이 닫혀있으면, 열고
            {
                Open();
            }
            else if (_opened) // 문이 열려있으면, 닫고
            {
                Close();
            }

        }

        public void Open()
        {
            _opened = true;

            _doorPanelTrans = transform.Find("Component1/Group 4949");

            float y = _doorPanelTrans.localPosition.y;

            _doorPanelTrans.localPosition = new Vector3(0.63f, y, 1.3f);
            _doorPanelTrans.localRotation = Quaternion.Euler(0, 80, 0);

        }

        public void Close()
        {
            _opened = false;

            _doorPanelTrans = transform.Find("Component1/Group 4949");

            float y = _doorPanelTrans.localPosition.y;

            _doorPanelTrans.localPosition = new Vector3(0.1f, y, -0.011f);
            _doorPanelTrans.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
