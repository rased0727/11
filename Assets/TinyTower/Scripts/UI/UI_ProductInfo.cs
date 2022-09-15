using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace TinyTower
{
    public class UI_ProductInfo : MonoBehaviour
    {
        public Text _nameTxt;
        public Text _costTxt;
        public Text _timeTxt;
        public Text _qtyTxt;
        public Image _icon;

        public GameData_Product _data;
        private int _state = 0; // 0 - 판매대기, 1 - 주문 중, 2 - 판매
        public bool _test = false;
        public Text _oderingTxt;
        public Image _progressBar;
        public Button _sellingStartBtn;
        public Image _blockImg;

        public void Init() // 초기화
        {
            _nameTxt = transform.Find("nameTxt").GetComponent<Text>();
            _costTxt = transform.Find("costTxt").GetComponent<Text>();
            _timeTxt = transform.Find("timeTxt").GetComponent<Text>();
            _qtyTxt = transform.Find("qtyTxt").GetComponent<Text>();
            _icon = transform.Find("icon").GetComponent<Image>();

            _oderingTxt = transform.Find("orderingTxt").GetComponent<Text>();
            _oderingTxt.gameObject.SetActive(false);

            _progressBar = transform.Find("ProgressBar/fill").GetComponent<Image>();
            _progressBar.transform.parent.gameObject.SetActive(false);
            _progressBar.type = Image.Type.Filled;
            _progressBar.fillMethod = Image.FillMethod.Horizontal;

            _sellingStartBtn = transform.Find("Button").GetComponent<Button>();
            /*_sellingStartBtn.onClick.AddListener(delegate () {

                _state = 1;

            });*/
            _sellingStartBtn.onClick.AddListener(OnClick_StartSelling);

            _blockImg = transform.Find("block").GetComponent<Image>();


            // 코루틴을 통해서 상품의 상태(단계) 및 수입 발생 제어
            if (_test == true)
                UI_Manager.I.StartCoroutine(_State_WaitForSelling());
        }

        public void OnClick_StartSelling()
        {
            _state = 1;
        }

        IEnumerator _State_WaitForSelling() // 판매 대기 상태
        {
            _state = 0;

            while (true)
            {
                Debug.Log("판매대기: " + Time.time);

                if (_state != 0)
                    break;

                yield return null;
            }

            StartCoroutine(_State_Odering());

        }

        IEnumerator _State_Odering() // 주문 중 상태
        {

            _oderingTxt.gameObject.SetActive(true);
            _progressBar.transform.parent.gameObject.SetActive(true);

            float totalTime = _data.time;
            float currentTime = _data.time;

            while (true)
            {
                _progressBar.fillAmount = currentTime / totalTime;

                if (0.5f <= _progressBar.fillAmount && _progressBar.fillAmount < 0.7f)
                {
                    _progressBar.color = new Color(1.0f, 1.0f, 0.0f, 1.0f); //yellow
                }
                else if (_progressBar.fillAmount < 0.5f)
                {
                    //_progressBar.color = new Color32(255, 0, 0, 255); //red
                    _progressBar.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); //red
                }

                currentTime -= Time.deltaTime; // 프레임시간만큼 시간을 계속 감소시켜주기

                if (currentTime <= 0.0f)
                {
                    break;
                }

                Debug.Log("주문 중: " + Time.time);

                if (_state != 1)
                    break;

                yield return null;
            }

            _oderingTxt.gameObject.SetActive(false);


            StartCoroutine(_State_Selling());
        }


        IEnumerator _State_Selling() // 판매 상태
        {
            _progressBar.transform.parent.gameObject.SetActive(false);
            _sellingStartBtn.gameObject.SetActive(false);
            _blockImg.gameObject.SetActive(false);

            yield return null;
        }


        public void ShowInfo(GameData_Product data)
        {
            _data = data;

            _nameTxt.text = data.name;
            _costTxt.text = data.cost.ToString();
            _timeTxt.text = data.time.ToString();
            _qtyTxt.text = "Qty: " + data.quantity.ToString();

            _icon.sprite = data.spriteImg;
        }
    }
}


