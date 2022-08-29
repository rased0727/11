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
            if (Input.GetMouseButtonDown(0)) // 0 �� ���� ���콺 ��ư, ��������
            {
                _dragStartPos = Input.mousePosition; 

            }
            else if(Input.GetMouseButton(0)) // 0 �� ���� ���콺 ��ư, ��� ������ ������
            {
                Vector3 currentPos = Input.mousePosition;

                // �������� ����� ���� _dragStartPos - currentPos �� �ϸ� ������ �� �� �����Ƿ� ���Ⱚ�� �־��ش�.
                Vector3 dir = currentPos - _dragStartPos;

                // ���� ������ ��� UI��ǥ(mousePosition) �̹Ƿ� ������ǥ�� ���尪���� �ٲ���
                Vector3 worldDir = Camera.main.ScreenToViewportPoint(dir);
                Vector3 move = -1 * new Vector3(/*worldDir.x * _drageSpeed*/ 0, worldDir.y * _drageSpeed, 0);

                if (move.y > 0) // �ö� ����
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

