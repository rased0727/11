using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject _ui_quest;
    GameObject _ui_cahracter;
    GameObject _ui_setting;

    void Start()
    {
        _ui_quest = transform.Find("UI_Quest").gameObject;
        _ui_quest.SetActive(false);
        _ui_cahracter = transform.Find("UI_Character").gameObject;
        _ui_cahracter.SetActive(false);
        _ui_setting = transform.Find("UI_Setting").gameObject;
        _ui_setting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 열려있으면 닫고
            if (_ui_quest.activeSelf == true)
                _ui_quest.SetActive(false);
            // 닫혀있으면 연다.
            else if (_ui_quest.activeSelf == false)
                _ui_quest.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // 열려있으면 닫고
            if (_ui_cahracter.activeSelf == true)
                _ui_cahracter.SetActive(false);
            // 닫혀있으면 연다.
            else if (_ui_cahracter.activeSelf == false)
                _ui_cahracter.SetActive(true);
        }
    }
    public void OnSettingBtn()
    {
        _ui_setting.SetActive(true);
    }
    public void OnSettingExtBtn()
    {
        _ui_setting.SetActive(false);
    }
}
