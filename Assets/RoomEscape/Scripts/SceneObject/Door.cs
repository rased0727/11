using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RoomEscape
{
    public class Door : SceneObject
    {
        Transform _doorPanelTrans;
        [SerializeField]bool _opened = false;


        protected override void Start()
        {
            base.Start();


            _doorPanelTrans = transform.Find("DoorWood32/Group 14");


            _opened = false;
        }


        protected override void OnMouseDown()
        {
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

            _doorPanelTrans = transform.Find("DoorWood32/Group 14");

            float y = _doorPanelTrans.localPosition.y;

            _doorPanelTrans.localPosition = new Vector3(0.3f, y, 1.3f);
            _doorPanelTrans.rotation = Quaternion.Euler(0, 100, 0);

        }

        public void Close()
        {
            _opened = false;

            _doorPanelTrans = transform.Find("DoorWood32/Group 14");

            float y = _doorPanelTrans.localPosition.y;

            _doorPanelTrans.localPosition = new Vector3(-0.03f, y, 0.6f);
            _doorPanelTrans.rotation = Quaternion.Euler(0, 45, 0);
        }

    }
}
