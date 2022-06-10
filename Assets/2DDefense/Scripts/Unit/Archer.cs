using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    public GameObject _arrowTemplate;
    public Transform _firePosTrans;
    protected override void Attack()
    {
        base.Attack();
        if(_arrowTemplate != null)
        {
            GameObject arrowObj = Instantiate(_arrowTemplate);
            arrowObj.SetActive(true);
            arrowObj.transform.position = _firePosTrans.position;
            arrowObj.name = "Arrow";

            Arrow arrow = arrowObj.GetComponent<Arrow>();
            arrow._team = _team;
        }
       

    }
}