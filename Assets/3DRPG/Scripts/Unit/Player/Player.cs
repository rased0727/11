using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace RPG3D
{
    [Serializable]
    public class PlayerStat
    {
        public int _strength;
        public int _magic;
        public int _agility;
        public int _attack;
        public int _defense;
    }

    public class Player : Unit
    {
        [Header("========스탯========")]
        [SerializeField]
        public PlayerStat _stat;
        
        
        bool _isJump = false;


        public override void Init()
        {
            base.Init();

            if (PlayerPrefs.HasKey("STAT_STRENGTH")) // 이미 스탯 랜덤을 결정한 적이 있음
            {
                _stat._strength = PlayerPrefs.GetInt("STAT_STRENGTH");
                Debug.Log(_stat._strength);
                _stat._magic =      PlayerPrefs.GetInt("STAT_MAGIC");
                _stat._agility =    PlayerPrefs.GetInt("STAT_AGILITY");
                _stat._attack =     PlayerPrefs.GetInt("STAT_ATTACK");
                _stat._defense =    PlayerPrefs.GetInt("STAT_DEFENSE");

                _uiMgr._strLable.text = Convert.ToString(_stat._strength);
                _uiMgr._intLable.text = Convert.ToString(_stat._magic);
                _uiMgr._aglLable.text = Convert.ToString(_stat._agility);
                _uiMgr._atkLable.text = Convert.ToString(_stat._attack);
                _uiMgr._defLable.text = Convert.ToString(_stat._defense);
            }
            else // 한번도 게임을 안해본 상태
            {
                _stat._strength =   UnityEngine.Random.Range(5, 10);
                _stat._magic =      UnityEngine.Random.Range(5, 10);
                _stat._agility =    UnityEngine.Random.Range(5, 10);
                _stat._attack =     UnityEngine.Random.Range(5, 10);
                _stat._defense =    UnityEngine.Random.Range(5, 10);

                PlayerPrefs.SetInt("STAT_STRENGTH",     _stat._strength);
                PlayerPrefs.SetInt("STAT_MAGIC",        _stat._magic);
                PlayerPrefs.SetInt("STAT_AGILITY",      _stat._agility);
                PlayerPrefs.SetInt("STAT_ATTACK",       _stat._attack);
                PlayerPrefs.SetInt("STAT_DEFENSE",      _stat._defense);

            }
        }
        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {     
                Attack();
            }
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                if (_isJump == false)
                {
                    Jump();
                    _isJump = true;
                    Invoke("JumpActive", 1.0f);
                }
            }
        }
        void JumpActive()
        {
            _isJump = false;
        }
    }
}
