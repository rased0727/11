using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG3D
{
    public class GameManager : MonoBehaviour
    {
        public GameObject _canvas;
        public GameObject _world;
        UIManager _uiMgr;
        Lancer _lancer;
        Slime _slime;

        // Start is called before the first frame update
        void Start()
        {

            _uiMgr = _canvas.GetComponent<UIManager>();
            _uiMgr.Init();
            _lancer = _world.transform.Find("Units/Lancer").gameObject.GetComponent<Lancer>();
            _lancer.Init();
            _slime = _world.transform.Find("Units/Slime").gameObject.GetComponent<Slime>();
            _slime.Init();
            

        }
    }
}
