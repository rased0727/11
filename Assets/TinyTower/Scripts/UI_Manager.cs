using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Manager : MonoBehaviour
    {
        Text _goldTxt;

        public static UI_Manager I; // I?? ????? ?¥í?????? ???

        void Awake()
        {
            I = this;
        }

        // Start is called before the first frame update
        public void Init()
        {

            _goldTxt = transform.Find("UI_Topbar/gold/goldTxt").GetComponent<Text>();

            // ??? UI???? ????????
            Refresh_Gold_UI();

        }

        public void Refresh_Gold_UI()
        {
            _goldTxt.text = UserData.I.Gold.ToString();
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}