using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class CameraRotator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // >> 오른쪽 버튼 누르면, 카메라 각도(y축) 90씩 증가
        public void OnLeftButton()
        {
            //transform.Rotate(Vector3.up, -90);
            
            float yAngle = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yAngle - 90, 0);

        }
        // << 왼쪽 버튼 누르면, 카메라 각도(y축) 90씩 감소
        public void OnRightButton()
        {
            //transform.Rotate(Vector3.up, 90);

            float yAngle = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yAngle + 90, 0);
        }

    }
}
