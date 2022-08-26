using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public delegate void callback(bool result);


    public class UserData : MonoBehaviour
    {
        const string KEY_GOLD = "user_data_gold";

        [SerializeField] int _gold = 0;
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
            if (PlayerPrefs.HasKey(KEY_GOLD) == false)
            {
                PlayerPrefs.SetInt(KEY_GOLD, Common.INITIAL_GOLD);
            }

            _gold = PlayerPrefs.GetInt(KEY_GOLD);
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

    }
}