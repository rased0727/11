using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
    public class Rat : Unit
    {
        public AudioSource _hitSnd;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            _hitSnd = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Attack()
        {
            _anim.SetTrigger("attack");

            _hitSnd.Play();

            //TODO :
        }
    }
}


