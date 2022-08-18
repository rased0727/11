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

            if ( GUILayout.Button("문 열기") )
            {
                _door.Open();
            }

            if( GUILayout.Button("문 닫기") )
            {
                _door.Close();
            }


            base.OnInspectorGUI(); //원래의 Door의 변수들이 인스펙터에 보여짐
        }
    }
}
