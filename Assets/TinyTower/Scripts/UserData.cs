using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public delegate void callback(bool result);


    public class UserData : MonoBehaviour
    {
        const string KEY_GOLD = "user_data_gold";
        const string KEY_FLOOR_LIST = "user_data_floor_list";


        [SerializeField]int _gold = 0;
        [SerializeField] string _floorList;
        public string FloorList
        {
            get { return _floorList; }
        }

        public int Gold //프로퍼티
        {
            get { return _gold; } // 읽기
        }

        public static UserData I; // I는 싱글톤 인스턴스를 의미

        void Awake()
        {
            I = this;
        }


        // Start is called before the first frame update
        public void Init()
        {
            #region LOAD GOLD
            LoadGold();
            #endregion

            #region LOAD FLOOR
            LoadFloor();
            #endregion

        }

        #region GOLD
        void LoadGold()
        {
            // 앱을 처음 실행하는 것이라면, 자금을 주고 시작
            if (PlayerPrefs.HasKey(KEY_GOLD) == false)
            {
                PlayerPrefs.SetInt(KEY_GOLD, Common.INITIAL_GOLD);
            }

            _gold = PlayerPrefs.GetInt(KEY_GOLD);
        }

        public void UseGold(int cost, callback cb)
        {
            if( _gold >= cost )
            {
                _gold -= cost;

                PlayerPrefs.SetInt(KEY_GOLD, _gold);

                UI_Manager.I.Refresh_Gold_UI();

                // 결과를 알려주도록 콜백함수 호출
                cb(true);
            }
            else
            {
                // 실패
                cb(false);
            }

        }

        public void AddGold(int gold, callback cb = null, bool refreshUI=true)
        {

            _gold += gold;

            PlayerPrefs.SetInt(KEY_GOLD, _gold);

            if(refreshUI)
                UI_Manager.I.Refresh_Gold_UI();

            // 결과를 알려주도록 콜백함수 호출
            if( cb != null )
                cb(true);

        }
        #endregion


        #region FLOOR
        public void SaveFloor(string floorName)
        {
            if(PlayerPrefs.HasKey(KEY_FLOOR_LIST))// 이미 저장된 floor 정보가 있다면
            {
                 //콤마(,)로 이어붙이기 한다.
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);

                _floorList += ", " + floorName;

                PlayerPrefs.SetString(KEY_FLOOR_LIST, _floorList);

            }
            else// 처음 저장하는 것이라면
            {
                _floorList = floorName;

                PlayerPrefs.SetString(KEY_FLOOR_LIST, floorName);
            }
        }

        void LoadFloor()
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))
            {
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);
            }
        }
        #endregion
    }
}
