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
        public GameObject _hpBarTrans;

        public GameObject _world;
        public Lancer _player;
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

            _hpBarTrans = transform.Find("CharacterBar/HpBar").gameObject;
            _player = _world.transform.Find("Units/Lancer").gameObject.GetComponent<Lancer>();

            _strLable = transform.Find("UI_Character/Labels/StrLable/Str").gameObject.GetComponent<TMP_Text>();
            _intLable = transform.Find("UI_Character/Labels/IntLable/Int").gameObject.GetComponent<TMP_Text>();
            _aglLable = transform.Find("UI_Character/Labels/AgilLable/Agil").gameObject.GetComponent<TMP_Text>();
            _atkLable = transform.Find("UI_Character/Labels/AttackLable/Attack").gameObject.GetComponent<TMP_Text>();
            _defLable = transform.Find("UI_Character/Labels/DefenceLable/Defence").gameObject.GetComponent<TMP_Text>();

            RefreshHpBar();

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
        public void RefreshHpBar()
        {
            if (_hpBarTrans != null)
            {
                /*
                Player player = new Player();
                int hp = player._hp;
                int maxHp = player._maxHp;
                Image fillImg = _hpBarTrans.GetComponent<Image>();
                fillImg.fillAmount = (float)hp / (float)maxHp;
                */
                _maxHp = _player._maxHp;
                _hp = _player._hp;
                Image fillImg = _hpBarTrans.GetComponent<Image>();
                fillImg.fillAmount = (float)_hp / (float)_maxHp;
            }
        }
        public void OnStatPoint(GameObject buttonOnj)
        {
            Debug.Log("-------- Stat Points Button ---------");
            Debug.Log(buttonOnj.transform.parent.gameObject.name);

            Image img = buttonOnj.GetComponent<Image>();
            Debug.Log(img.sprite.name); // 버튼의 이름이 Plus냐 Minus냐

        }
    }
}
