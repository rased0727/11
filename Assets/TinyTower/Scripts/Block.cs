using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; // 블록 1개 층의 높이
        [SerializeField] GameObject[] _templates;

        void OnMouseDown() // 공사중 블럭을 터치하면
        {
            

            // UserData 에서 골드사용 메서드 호출
            UserData.I.UseGold(Common.COST_SHOP, UseGoldCb);
        }
        void UseGoldCb(bool result)
        {
            if (result == true)
            {
                //Debug.Log("블록터치!! " + Input.mousePosition.ToString());
                int choice = Random.Range(0, _templates.Length);

                GameObject template = _templates[choice];
                GameObject obj = Instantiate(template);
                obj.SetActive(true);

                // 새로운층은 지금 위치에 덮어 씌워주고
                obj.transform.position = transform.position;

                // 이 블럭(공사중 블럭)은 한 층 위로 올려주기
                Vector3 blockPos = transform.position;
                transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);
            }
            else
            {
                // TODO : 돈 부족 팝업창 구현
                // 돈이 부족합니다 팝업창 띄우기
            }

        }
    }
}

