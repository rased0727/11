using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomEscape
{
    public class Camera : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnLeftButton()
        {
            //transform.Rotate(Vector3.up, -90);
            
            float yAngle = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yAngle - 90, 0);

        }

        public void OnRightButton()
        {
            //transform.Rotate(Vector3.up, 90);

            float yAngle = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, yAngle + 90, 0);
        }

    }
}
