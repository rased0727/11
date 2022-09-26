using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelDungeon
{
    public class UI_GameLog : UI_Base
    {
        public Text _log;
        // Start is called before the first frame update
        public override void Init()
        {
            _log = transform.Find("gameLog").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void Hit()
        {
            gameObject.SetActive(true);
            _log.text = "쥐에게 공격을 받았습니다";
        }
    }
}

