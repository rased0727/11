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
        bool _isJump = false;

        [Header("========스탯========")]
        [SerializeField]
        public PlayerStat _stat;

        public AnimationCurve _expCurve;
        public int _maxLevel = 100;
        public int _level = 1;

        public long _maxExp = 100000000;
        public long _exp;
        public long _requiredExp;


        public override void Init()
        {
            base.Init();
            InitStat();

        }
        void Update()
        {
            /*
            int nextLevel = _level + 1;

            float expRatio = _expCurve.Evaluate((float)nextLevel / (float)_maxLevel);

            // 다음 레벨로 가기 위한 경험치
            _requiredExp = (long)(_maxExp * expRatio);
            */


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
        public void InitStat()
        {
            if (PlayerPrefs.HasKey("STAT_STRENGTH")) // 이미 스탯 랜덤을 결정한 적이 있음
            {
                _stat._strength = PlayerPrefs.GetInt("STAT_STRENGTH");
                _stat._magic = PlayerPrefs.GetInt("STAT_MAGIC");
                _stat._agility = PlayerPrefs.GetInt("STAT_AGILITY");
                _stat._attack = PlayerPrefs.GetInt("STAT_ATTACK");
                _stat._defense = PlayerPrefs.GetInt("STAT_DEFENSE");
            }
            else // 한번도 게임을 안해본 상태
            {
                _stat._strength = UnityEngine.Random.Range(5, 10);
                _stat._magic = UnityEngine.Random.Range(5, 10);
                _stat._agility = UnityEngine.Random.Range(5, 10);
                _stat._attack = UnityEngine.Random.Range(5, 10);
                _stat._defense = UnityEngine.Random.Range(5, 10);

                SaveStat();
            }
            _uiMgr.RefreshStat();
        }
        public void SaveStat()
        {
            PlayerPrefs.SetInt("STAT_STRENGTH", _stat._strength);
            PlayerPrefs.SetInt("STAT_MAGIC", _stat._magic);
            PlayerPrefs.SetInt("STAT_AGILITY", _stat._agility);
            PlayerPrefs.SetInt("STAT_ATTACK", _stat._attack);
            PlayerPrefs.SetInt("STAT_DEFENSE", _stat._defense);
        }
        void JumpActive()
        {
            _isJump = false;
        }
        protected override void ProcessHit(int damage, Unit attacker)
        {
            base.ProcessHit(damage, attacker);

            RefreshHpBar(); // 나는 Execution Order가 잘 안먹혀서 어쩔 수 없이 Unit에 존재함(원래는 UIManager에 있는게 좋음)
        }
        public void AddExp(int exp)
        {
            _exp += exp;
            _uiMgr.RefreshStat();
        }
    }
}
