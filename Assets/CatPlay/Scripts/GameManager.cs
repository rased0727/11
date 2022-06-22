using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace CatPlay
{
    public class GameManager : MonoBehaviour
    {
        public GameObject _worldObj;
        public GameObject _canvasObj;
        GameObject _dishObj;
        GameObject _coinObj;
        GameObject _heartObj;

        // UI 요소들
        public Text _nowTimeText;

        Text _coinText;
        Text _heartText;
        int scoreCoin = 0;
        int scoreHeart = 0;

        public float _randomFloat = 1.3f;


        // Start is called before the first frame update
        void Start()
        {
            _dishObj = _worldObj.transform.Find("Item").Find("Dish").gameObject;
            _coinObj = _worldObj.transform.Find("Item").Find("Coin").gameObject;
            _heartObj = _worldObj.transform.Find("Item").Find("Heart").gameObject;


            _heartText = _canvasObj.transform.Find("Title").transform.Find("HeartUI").transform.Find("Text").GetComponent<Text>();
            _coinText = _canvasObj.transform.Find("Title").transform.Find("CoinUI").transform.Find("Text").GetComponent<Text>();
            _heartText.text = "없음";
            _coinText.text = "없음";
        }

        // Update is called once per frame
        void Update()
        {
            DateTime dt = DateTime.Now;
            _nowTimeText.text = string.Format("{0:yyyy년 M월 d일 tt hh:mm:ss}", dt);
        }
        public void OnClick_Food()
        {
            _dishObj.SetActive(true);
        }
        public void AddHeart(int count)
        {
            scoreHeart += count;
            _heartText.text = scoreHeart.ToString("D4");
        }
        public void AddCoin(int count)
        {
            scoreCoin += count;
            _coinText.text = scoreCoin.ToString("D4");
        }
        public void OnFinishEat()
        {
            _dishObj.SetActive(false);
        }
        public void DropItem()
        {
            GameObject cloneCoinObj = Instantiate(_coinObj);
            cloneCoinObj.SetActive(true);
            float randomXPos = UnityEngine.Random.Range(-_randomFloat, _randomFloat);
            float randomYPos = UnityEngine.Random.Range(-_randomFloat, _randomFloat);
            cloneCoinObj.transform.position = new Vector3(randomXPos, randomYPos, 0);

            GameObject cloneHeartObj = Instantiate(_heartObj);
            cloneHeartObj.SetActive(true);
            randomXPos = UnityEngine.Random.Range(-_randomFloat, _randomFloat);
            randomYPos = UnityEngine.Random.Range(-_randomFloat, _randomFloat);
            cloneHeartObj.transform.position = new Vector3(randomXPos, randomYPos, 0);

        }


    }
}




