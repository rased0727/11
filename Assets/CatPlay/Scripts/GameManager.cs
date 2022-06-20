using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace CatPlay
{
    public class GameManager : MonoBehaviour
    {
        public Text _nowTimeText;
        public GameObject _world;
        public GameObject _dishObj;


        // Start is called before the first frame update
        void Start()
        {
            _dishObj = _world.transform.Find("Dish").gameObject;
            //Debug.Log(_dish);
        }

        // Update is called once per frame
        void Update()
        {
            DateTime dt = DateTime.Now;
            //_nowTimeText.text = dt.ToString();
            _nowTimeText.text = string.Format("{0:yyyy년 M월 d일 tt hh:mm:ss}", dt);
        }
        public void OnClick_Food()
        {
            _dishObj.SetActive(true);
        }
    }
}




