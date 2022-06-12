using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MapObject
{
    public GameObject _fireEffTemplate;
    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);

        // ������ ���� �� �ǹ����� ���� ����Ʈ �־��ֱ�
        if (_hp > 0)
        {
        }
        else
        {
            // ü���� 0�� �Ǿ����� ���� ����Ʈ 
            GameObject fireEffObj = Instantiate(_fireEffTemplate);
            fireEffObj.SetActive(true);
            fireEffObj.transform.position = transform.position; // ���� ���ĵǴ� �ǹ��� ���� ��ü�� �ɾ���
            Invoke("Disappear", 1.5f); // 1.5���� �����̸� �ְ� MapObject Ŭ������ Disappear �Լ� ȣ���ؼ� ��ü ����
        }

    }
    
}
