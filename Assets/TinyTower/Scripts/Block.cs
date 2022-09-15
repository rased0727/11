using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; // 블록의 높이 : 5m



        void OnMouseDown()
        {
            // 공사가능한 층(블록) 터치!!
            //Debug.Log("블록 터치!!: " + Input.mousePosition.ToString());
#if LEEYUNGHYUN_TEST

            Debug.Log("hello");
#endif



            UserData.I.UseGold(Common.COST_SHOP, UseGoldCb);
        }

        public void Raise()
        {
            // 자신은 이제 한 층 위로 올려가기
            Vector3 blockPos = transform.position;
            transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);
        }

        void UseGoldCb(bool result)
        {
            if( result == true ) // 성공
            {
                FloorManager.I.Create(transform.position);
                Raise(); //플로어 생성 후, 블락 올려주기
            }
            else
            {
                // TODO : 돈 부족 팝업창 구현 (Native Platform Dialog 사용)
                // 돈이 부족합니다 등의 팝업 안내창 띄우기

                PlatformDialog.SetButtonLabel("OK");
                PlatformDialog.Show(
                    "알림",
                    "골드가 부족합니다.",
                    PlatformDialog.Type.SubmitOnly,
                    OkCb,
                    CancelCb
                );


            }
        }


        void OkCb()
        {
            Debug.Log("OK");
        }

        void CancelCb()
        {

        }
    }



}
