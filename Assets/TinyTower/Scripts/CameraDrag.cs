using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class CameraDrag : MonoBehaviour
    {
        public static CameraDrag I;

        Vector3 _dragStartPos;
        [SerializeField]float _dragSpeed = 1.0f;

        [SerializeField] float _yMin = 1.5f;
        [SerializeField] float _yMax = 60.0f;

        public bool _dragging = false;

        void Awake()
        {
            I = this;
        }

        
        public void UpdateCameraDrag()
        {
            if( Input.GetMouseButtonDown(0) ) // 마우스가 클릭됨 (드래그 시작)
            {
                _dragStartPos = Input.mousePosition;

                //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));

                _dragging = false;
            }
            else if( Input.GetMouseButton(0)) // 마우스가 계속 눌려지고 있는 상태
            {

                _dragging = true;

                Vector3 currentPos = Input.mousePosition; ;

                // 이 때 카메라를 움직여 주기

                Vector3 dir = currentPos - _dragStartPos;


                Vector3 worldDir = Camera.main.ScreenToViewportPoint(dir);
                Vector3 move = -1 * new Vector3(0, worldDir.y * _dragSpeed, 0);

                //Debug.Log(move);

                if (move.y > 0)
                {
                    if (transform.position.y < _yMax)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
                else if (move.y < 0)
                {
                    if (_yMin < transform.position.y)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
               
            }
            else if(Input.GetMouseButtonUp(0))
            {
                _dragging = false;
            }
            

        }


    }
}
