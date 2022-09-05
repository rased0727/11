using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; // ��� 1�� ���� ����


        void OnMouseDown() // ������ ���� ��ġ�ϸ�
        {
            

            // UserData ���� ����� �޼��� ȣ��
            UserData.I.UseGold(Common.COST_SHOP, ChangeGoldCb);
        }
        void ChangeGoldCb(bool result)
        {
            if (result == true)
            {
                //Debug.Log("�����ġ!! " + Input.mousePosition.ToString());

                FloorManager.I.Create(transform.position);

                // �� ��(������ ��)�� �� �� ���� �÷��ֱ�
                Raise();
            }
            else
            {
                // TODO : �� ���� �˾�â ����
                // ���� �����մϴ� �˾�â ����
                PlatformDialog.SetButtonLabel("OK");
                PlatformDialog.Show(
                    "�˸�",
                    "��尡 �����մϴ�.",
                    PlatformDialog.Type.SubmitOnly,
                    () => {
                        Debug.Log("OK");
                    },
                    null
                );
            }
        }
        public void Raise()
        {
            Vector3 blockPos = transform.position;
            transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);
        }
    }
}

