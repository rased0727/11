using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RPG3D
{
    public class UIManager : MonoBehaviour
    {
        GameObject _ui_quest;
        GameObject _ui_cahracter;
        GameObject _ui_setting;
        GameObject _ui_chrBar;

        public GameObject _world;
        public Player _player;
        public int _maxHp;
        public int _hp;

        public TMP_Text _strLable;
        public TMP_Text _intLable;
        public TMP_Text _aglLable;
        public TMP_Text _atkLable;
        public TMP_Text _defLable;



        public void Init()
        {
            _ui_quest = transform.Find("UI_Quest").gameObject;
            _ui_quest.SetActive(false);
            _ui_cahracter = transform.Find("UI_Character").gameObject;
            _ui_cahracter.SetActive(false);
            _ui_setting = transform.Find("UI_Setting").gameObject;
            _ui_setting.SetActive(false);
            _ui_chrBar = transform.Find("CharacterBar").gameObject;
            _ui_chrBar.SetActive(true);
            _player = _world.transform.GetComponentInChildren<Player>();

            InitStat();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // 열려있으면 닫고
                if (_ui_quest.activeSelf == true)
                {
                    _ui_quest.SetActive(false);
                    _ui_chrBar.SetActive(true);
                }
                    
                // 닫혀있으면 연다.
                else if (_ui_quest.activeSelf == false)
                {
                    _ui_quest.SetActive(true);
                    _ui_cahracter.SetActive(false);
                    _ui_chrBar.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                // 열려있으면 닫고
                if (_ui_cahracter.activeSelf == true)
                {
                    _ui_cahracter.SetActive(false);
                    _ui_chrBar.SetActive(true);
                }
                    
                // 닫혀있으면 연다.
                else if (_ui_cahracter.activeSelf == false)
                {
                    _ui_cahracter.SetActive(true);
                    _ui_quest.SetActive(false);
                    _ui_chrBar.SetActive(false);
                }
                    
            }
            //RefreshHpBar();
        }
        public void OnSettingBtn()
        {
            if (_ui_setting.activeSelf == false)
            {
                _ui_setting.SetActive(true);
            }
            else
            {
                _ui_setting.SetActive(false);
            }
                
            
        }
        public void OnSettingExtBtn()
        {
            _ui_setting.SetActive(false);
        }
        public void InitStat()
        {
            _strLable = transform.Find("UI_Character/Labels/StrLable/Str").gameObject.GetComponent<TMP_Text>();
            _intLable = transform.Find("UI_Character/Labels/IntLable/Int").gameObject.GetComponent<TMP_Text>();
            _aglLable = transform.Find("UI_Character/Labels/AgilLable/Agil").gameObject.GetComponent<TMP_Text>();
            _atkLable = transform.Find("UI_Character/Labels/AttackLable/Attack").gameObject.GetComponent<TMP_Text>();
            _defLable = transform.Find("UI_Character/Labels/DefenceLable/Defence").gameObject.GetComponent<TMP_Text>();
        }
        public void OnStatPoint(GameObject buttonObj)
        {
            Debug.Log("-------- Stat Points Button -------------");
            string statName = buttonObj.transform.parent.gameObject.name;
            Debug.Log(statName); // 스탯 종류
            Image img = buttonObj.GetComponent<Image>();
            string btnName = img.sprite.name;
            Debug.Log(btnName); // 버튼 종류(증가, 감소)

            switch (statName)
            {
                case "StrLable":
                    {
                        if (btnName.Contains("plus"))
                            _player._stat._strength++;
                        else
                            _player._stat._strength--;
                    }
                    break;
                case "IntLable":
                    {
                        if (btnName.Contains("plus"))
                            _player._stat._magic++;
                        else
                            _player._stat._magic--;
                    }
                    break;
                case "AgilLable":
                    {
                        if (btnName.Contains("plus"))
                            _player._stat._agility++;
                        else
                            _player._stat._agility--;
                    }
                    break;
                case "AttackLable":
                    {
                        if (btnName.Contains("plus"))
                            _player._stat._attack++;
                        else
                            _player._stat._attack--;
                    }
                    break;
                case "DefenceLable":
                    {
                        if (btnName.Contains("plus"))
                            _player._stat._defense++;
                        else
                            _player._stat._defense--;
                    }
                    break;
            }
            if(_player != null)
                _player.SaveStat();

            RefreshStat();
        }
        public void RefreshStat()
        {
            _strLable.text = _player._stat._strength.ToString();
            _intLable.text = _player._stat._magic.ToString();
            _aglLable.text = _player._stat._agility.ToString();
            _atkLable.text = _player._stat._attack.ToString();
            _defLable.text = _player._stat._defense.ToString();
        }
    }
}
