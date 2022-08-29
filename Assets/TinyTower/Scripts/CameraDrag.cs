using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class CameraDrag : MonoBehaviour
    {
        Vector3 _dragStartPos;
        [SerializeField]float _drageSpeed = 1;
        [SerializeField]float _yMin = 21.7f;
        [SerializeField] float _yMax = 60.0f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // 0 이 왼쪽 마우스 버튼, 눌렀을때
            {
                _dragStartPos = Input.mousePosition; 

            }
            else if(Input.GetMouseButton(0)) // 0 이 왼쪽 마우스 버튼, 계속 눌러져 있을때
            {
                Vector3 currentPos = Input.mousePosition;

                // 위에서의 결과를 통해 _dragStartPos - currentPos 를 하면 방향을 알 수 있으므로 방향값을 넣어준다.
                Vector3 dir = currentPos - _dragStartPos;

                // 위의 값들은 모두 UI좌표(mousePosition) 이므로 방향좌표를 월드값으로 바꿔줌
                Vector3 worldDir = Camera.main.ScreenToViewportPoint(dir);
                Vector3 move = -1 * new Vector3(/*worldDir.x * _drageSpeed*/ 0, worldDir.y * _drageSpeed, 0);

                if (move.y > 0) // 올라갈 때는
                {
                    if(transform.position.y < _yMax)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
                else if(move.y < 0)
                {
                    if(_yMin < transform.position.y)
                    {
                        transform.Translate(move, Space.World);
                    }
                }
            }

        }
    }
}

