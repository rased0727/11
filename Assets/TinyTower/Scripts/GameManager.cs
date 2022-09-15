using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 게임데이터 초기화
            GameData.I.Init();

            // 유저데이터 초기화
            UserData.I.Init();

            // 플로어매니저 초기화
            FloorManager.I.Init();

            // UI매니져 초기화
            UI_Manager.I.Init();

            StartCoroutine(_Update());
        }

        // Update is called once per frame
        IEnumerator _Update()
        {
            while(true)
            {
                CameraDrag.I.UpdateCameraDrag();

                yield return null;
            }
        }

        void OnApplicationQuit()
        {
            string stopTime = DateTime.Now.ToString();
            PlayerPrefs.SetString("game_stop_time", stopTime);
        }
    }
}
