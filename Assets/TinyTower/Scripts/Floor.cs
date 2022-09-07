using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{

    public interface IIncomeCollector
    {
        void CollectGold();
    }


    public enum FloorType
    {
        RESIDENTIAL, //주거
        FOOD_STORE,  //음식점
        SERVICE,     //서비스 스토어
        CULTURE,     //문화시설
        CREATIVE,    //예술, 창작
        RETAIL,      //각종 판매점
        BUSINESS     //사무실, 사업장
    }


    public class Floor : MonoBehaviour, IIncomeCollector
    {
        public FloorType _type;

        public int _income = 1; // 단위 시간당 수익
        public float _time = 1.0f; // 단위 시간

        private float _elapsed = 0.0f; // 경과 시간

        [SerializeField] private string _stopTime = "";

        public void Init()
        {
            if (PlayerPrefs.HasKey("game_stop_time"))
            {
                string lastGameTime = PlayerPrefs.GetString("game_stop_time");

                DateTime now = DateTime.Now;

                DateTime stopTime = DateTime.Parse(lastGameTime);

                TimeSpan span = now - stopTime;
                int incomeTotal = (int)(span.TotalSeconds / _time * _income);

                bool uiRefresh = false;
                UserData.I.AddGold(incomeTotal, null, uiRefresh);
            }
        }


        void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed > _time)
            {
                CollectGold(); // _time 초마다 호출이 됨

                _elapsed = 0.0f;
            }

        }


        public void CollectGold()
        {
            // 테스트 코드: n초 마다 n골드 수입 증가 하는 루틴

            // 골드 1 증가
            UserData.I.AddGold(_income);
        }

        public void ShowInfo()
        {
            // 이 상점의 정보를 표시

            // 이름
            // 업종
            // 종업원
            // 고객의 수
            // 단위 시간 당 수익

        }

        void OnMouseDown()
        {
            ShowInfo();
        }

    }
}

