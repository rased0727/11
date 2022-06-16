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

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt = DateTime.Now;
            //_nowTimeText.text = dt.ToString();
            _nowTimeText.text = string.Format("{0:yyyy년 M월 d일 tt hh:mm:ss}", dt);
        }
    }
}

