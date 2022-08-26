using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class TinyHuman : MonoBehaviour
    {
        [SerializeField] float _maxDistance = 15.0f;
        [SerializeField] float _moveDelta = 0.0001f;
        [SerializeField] float _distance = 0.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            move();

        }

        void move()
        {
            // normalized 를 하면 길이가 1이 됨(=단위벡터)
            Vector3 dirNormalized = transform.forward.normalized; 

            _distance += _moveDelta;

            transform.Translate(dirNormalized * _moveDelta, Space.World);

            if (_distance > _maxDistance)
            {
                transform.Rotate(Vector3.up, 180.0f);
                _distance = 0.0f;
            }
        }


        float direction = 1.0f;
        void move2()
        {
            _distance += _moveDelta;

            transform.Translate(new Vector3(direction * _moveDelta, 0, 0), Space.World);

            if (_distance > _maxDistance)
            {
                transform.Rotate(Vector3.up, 180.0f);
                _distance = 0.0f;

                direction *= -1.0f;
            }
        }
    }
}