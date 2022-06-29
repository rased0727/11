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
        GameObject _ExtBtnObj;
        GameObject _testItemUIObj;

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
            _testItemUIObj = _canvasObj.transform.Find("TestItemUI").gameObject;
            _ExtBtnObj = _canvasObj.transform.Find("TestItemUI").Find("ExtBtn").gameObject;



            _heartText = _canvasObj.transform.Find("Title").transform.Find("HeartUI").transform.Find("Text").GetComponent<Text>();
            _coinText = _canvasObj.transform.Find("Title").transform.Find("CoinUI").transform.Find("Text").GetComponent<Text>();
            _heartText.text = "없음";
            _coinText.text = "없음";

            _testItemUIObj.SetActive(false);
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
        public void OnClick_TestItem()
        {
            _testItemUIObj.SetActive(true);
        }
        public void OnClick_Ext()
        {
            _testItemUIObj.SetActive(false);
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
        public void DropItem(Transform target)
        {
            /* 내가 했었던 랜덤 함수 
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
            */





            GameObject cloneHeartObj = Instantiate(_heartObj);
            cloneHeartObj.SetActive(true);

            float deltaRandius = 0.3f;
            float minRadius = 1.2f;

            // Unit은 1을 뜻함. 즉 insideUnitCircle은 반지름이 1인 것임
            Vector2 circleRange = UnityEngine.Random.insideUnitCircle * deltaRandius;

            // 위의 원형의 벡터 길이를 1로 노멀라이즈 해줌
            Vector2 normalVector = circleRange.normalized;

            Vector2 randomPos = circleRange + normalVector * minRadius;

            // 위에서 정해진 최종값을 포지션으로 해줌
            cloneHeartObj.transform.position = target.position + new Vector3(randomPos.x, randomPos.y);
            cloneHeartObj.gameObject.name = Cat.ITEM_NAME_HEART;

        }


    }
}




