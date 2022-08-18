using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RoomEscape
{

    [CustomEditor(typeof(Door))]
    public class DoorInpector : Editor
    {
        Door _door;

        public override void OnInspectorGUI()
        {
            if (_door == null)
                _door = target as Door;

            if ( GUILayout.Button("�� ����") )
            {
                _door.Open();
            }

            if( GUILayout.Button("�� �ݱ�") )
            {
                _door.Close();
            }


            base.OnInspectorGUI(); //������ Door�� �������� �ν����Ϳ� ������
        }
    }
}
