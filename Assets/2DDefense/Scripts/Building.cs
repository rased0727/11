using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MapObject
{
    public GameObject _fireEffTemplate;
    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);

        // 데미지 입을 때 건물만의 폭파 이펙트 넣어주기
        if (_hp > 0)
        {
        }
        else
        {
            // 체력이 0이 되었으니 폭파 이펙트 
            GameObject fireEffObj = Instantiate(_fireEffTemplate);
            fireEffObj.SetActive(true);
            fireEffObj.transform.position = transform.position;
            Invoke("Disappear", 1.5f);
        }

    }
    
}
