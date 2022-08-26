using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; // ��� 1�� ���� ����
        [SerializeField] GameObject[] _templates;

        void OnMouseDown() // ������ ���� ��ġ�ϸ�
        {
            

            // UserData ���� ����� �޼��� ȣ��
            UserData.I.UseGold(Common.COST_SHOP, UseGoldCb);
        }
        void UseGoldCb(bool result)
        {
            if (result == true)
            {
                //Debug.Log("�����ġ!! " + Input.mousePosition.ToString());
                int choice = Random.Range(0, _templates.Length);

                GameObject template = _templates[choice];
                GameObject obj = Instantiate(template);
                obj.SetActive(true);

                // ���ο����� ���� ��ġ�� ���� �����ְ�
                obj.transform.position = transform.position;

                // �� ��(������ ��)�� �� �� ���� �÷��ֱ�
                Vector3 blockPos = transform.position;
                transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);
            }
            else
            {
                // TODO : �� ���� �˾�â ����
                // ���� �����մϴ� �˾�â ����
            }

        }
    }
}

