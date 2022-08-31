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

        [SerializeField] int _gold = 0;
        [SerializeField] string _floorList;
        public string FloorList
        {
            get { return _floorList; }
        }
        public int Gold
        {
            get { return _gold; }
        }

        public static UserData I;


        void Awake()
        {
            I = this;
        }


        // Start is called before the first frame update
        public void Init()
        {
            #region LOAD GOLD
            if (PlayerPrefs.HasKey(KEY_GOLD) == false)
            {
                PlayerPrefs.SetInt(KEY_GOLD, Common.INITIAL_GOLD);
            }

            _gold = PlayerPrefs.GetInt(KEY_GOLD);
            #endregion

            #region LOAD FLOOR
            LoadFloor();
            #endregion


        }

        public void UseGold(int cost, callback cb)
        {
            if(_gold >= cost)
            {
                _gold -= cost;
                PlayerPrefs.SetInt(KEY_GOLD, _gold);
                UI_Manager.I.Refresh_Gold_UI();

                //결과를 알려주도록 콜백함수 호출
                cb(true);
            }
            else
            {
                //실패
                cb(false);
            }
        }
        public void AddGold(int gold, callback cb = null)
        {
        
            _gold += gold;
            PlayerPrefs.SetInt(KEY_GOLD, _gold);
            UI_Manager.I.Refresh_Gold_UI();

            //결과를 알려주도록 콜백함수 호출
            if(cb!=null)
                cb(true);

        }
        public void SaveFloor(string floorName)
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))
            {
                // 이미 저장된 floor 정보가 있다면 콤마(,)로 이어붙이기
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);

                _floorList += ", " + floorName;

                PlayerPrefs.SetString(KEY_FLOOR_LIST, _floorList);
            }
            else
            {
                _floorList = floorName;
                PlayerPrefs.SetString(KEY_FLOOR_LIST, floorName);
            }
        }
        public void LoadFloor()
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))
            {
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);
            }
        }

    }
}