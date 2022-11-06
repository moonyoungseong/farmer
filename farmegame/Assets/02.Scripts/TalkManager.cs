using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public List<GameObject> TalkingBox = new List<GameObject>(); // 대화창 담을 리스트;
    //public List<Text> language = new List<Text>();
    public GameObject accept;
    public GameObject refuse;
    public GameObject Inventory;

    public void TruckTalkfirst() // 트럭기사 버튼 클릭시 이벤트, 플레이어가 대답
    {
        TalkingBox[0].SetActive(true);
    }

    public void TruckTalking() // NPC가 대답
    {
        TalkingBox[0].SetActive(false);
        TalkingBox[1].SetActive(true);
    }

    public void Truckchange() // 플레이어가 대답
    {
        TalkingBox[1].SetActive(false);
        TalkingBox[2].SetActive(true);
    }

    public void ExchangePlease() // NPC 고민, 수락, 거절버튼 나온다.
    {
        TalkingBox[2].SetActive(false);
        TalkingBox[3].SetActive(true);
        accept.SetActive(true);
        refuse.SetActive(true);
    }

    public void acceptBtn() // 수락 눌렀을시
    {
        TalkingBox[3].SetActive(false);
        Inventory.SetActive(true);
        accept.SetActive(false);
        refuse.SetActive(false);
    }

    public void refuseBtn() // 거절 눌렀을시
    {
        TalkingBox[3].SetActive(false);
        accept.SetActive(false);
        refuse.SetActive(false);
    }
}
