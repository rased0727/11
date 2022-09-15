using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class TinyHuman : WaypointTraveller
    {
        [SerializeField] float _maxDistance = 15.0f;
        [SerializeField]float _moveDelta = 0.01f;
        [SerializeField]float _distance = 0.0f;



        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }



        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            if (_waypoints.Count > 0)
            {

            }
            else
            {
                move();
            }
        }

        void move()
        {
            Vector3 dirNormalized = transform.forward.normalized;

            _distance += _moveDelta;

            transform.Translate(dirNormalized * _moveDelta, Space.World);

            if (_distance > _maxDistance)
            {
                // ео го╠Б
                transform.Rotate(Vector3.up, 180.0f);
                _distance = 0.0f;
            }
        }


    }
}
