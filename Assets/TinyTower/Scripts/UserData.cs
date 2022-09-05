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

        public int Gold //������Ƽ
        {
            get { return _gold; } // �б�
        }

        public static UserData I; // I�� �̱��� �ν��Ͻ��� �ǹ�

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
            // ���� ó�� �����ϴ� ���̶��, �ڱ��� �ְ� ����
            if (PlayerPrefs.HasKey(KEY_GOLD) == false)
            {
                PlayerPrefs.SetInt(KEY_GOLD, Common.INITIAL_GOLD);
            }

            _gold = PlayerPrefs.GetInt(KEY_GOLD);
        }

        public void UseGold(int cost, callback cb)
        {
            if (_gold >= cost)
            {
                _gold -= cost;

                PlayerPrefs.SetInt(KEY_GOLD, _gold);

                UI_Manager.I.Refresh_Gold_UI();

                // ����� �˷��ֵ��� �ݹ��Լ� ȣ��
                cb(true);
            }
            else
            {
                // ����
                cb(false);
            }

        }

        public void AddGold(int gold, callback cb = null, bool refreshUI = true)
        {

            _gold += gold;

            PlayerPrefs.SetInt(KEY_GOLD, _gold);

            if (refreshUI)
                UI_Manager.I.Refresh_Gold_UI();

            // ����� �˷��ֵ��� �ݹ��Լ� ȣ��
            if (cb != null)
                cb(true);

        }
        #endregion


        #region FLOOR
        public void SaveFloor(string floorName)
        {
            if (PlayerPrefs.HasKey(KEY_FLOOR_LIST))// �̹� ����� floor ������ �ִٸ�
            {
                //�޸�(,)�� �̾���̱� �Ѵ�.
                _floorList = PlayerPrefs.GetString(KEY_FLOOR_LIST);

                _floorList += ", " + floorName;

                PlayerPrefs.SetString(KEY_FLOOR_LIST, _floorList);

            }
            else// ó�� �����ϴ� ���̶��
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
