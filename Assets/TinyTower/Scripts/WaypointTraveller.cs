using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class WaypointTraveller : MonoBehaviour
    {
        [SerializeField] GameObject _waypointObj;
        [SerializeField] protected List<Transform> _waypoints;
        [SerializeField] int _curWaypoint = 0;
        [SerializeField] float _speed = 1.0f;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            if (_waypointObj != null)
            {
                Transform[] tarr = _waypointObj.GetComponentsInChildren<Transform>();
                _waypoints.AddRange(tarr);
                _waypoints.Remove(_waypointObj.transform);

            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "waypoint")
            {
                // reach for waypoint    
                if (_curWaypoint < _waypoints.Count - 1)
                {
                    _curWaypoint++;
                }
                else
                {
                    _curWaypoint = 0;
                }
            }
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (_waypoints.Count > 0)
            {
                Vector3 targetPos = _waypoints[_curWaypoint].position;
                float step = _speed * Time.deltaTime;
                Vector3 dir = targetPos - transform.position;
                dir.y = 0.0f;
                transform.forward = dir;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }
            else
            {

            }
        }
    }
}
