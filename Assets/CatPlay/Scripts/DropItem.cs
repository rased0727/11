using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPlay
{
    public class DropItem : MonoBehaviour
    {
        Rigidbody2D _rigid;
        Collider2D _col;

        // Start is called before the first frame update
        void Start()
        {
            _col = GetComponent<Collider2D>();
            _rigid = gameObject.GetComponent<Rigidbody2D>();
            _rigid.bodyType = RigidbodyType2D.Dynamic;
            _rigid.AddForce(new Vector2(0, 300.0f));

            Invoke("StopPhysics", 0.5f);
        }

        void StopPhysics()
        {
            Debug.Log("들어옴");
            _rigid.bodyType = RigidbodyType2D.Static;
            _col.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
