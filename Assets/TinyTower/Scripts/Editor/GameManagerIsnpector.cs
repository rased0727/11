using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TinyTower
{

    [CustomEditor(typeof(GameManager))]
    public class GameManagerInpector : Editor
    {
        GameManager _gameMgr;

        public override void OnInspectorGUI()
        {
            if (_gameMgr == null)
                _gameMgr = target as GameManager;

            if (GUILayout.Button("초기화"))
            {
                PlayerPrefs.DeleteAll();
            }
            if (GUILayout.Button("골드 치트키 10000"))
            {
                UserData.I.AddGold(10000);
            }


            base.OnInspectorGUI();
        }
    }
}