using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    public float traceDist = 5.0f;
    public float UI = 2.0f;

    private Transform npcTr;
    private Transform playerTr;

    public GameObject dialog;

    void Start()
    {
        npcTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        StartCoroutine(CheckNpcState());
    }

   IEnumerator CheckNpcState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            float distance = Vector3.Distance(playerTr.position, npcTr.position);

            if (distance <= traceDist)
            {
                dialog.SetActive(true);
            }
           
            else
            {
                dialog.SetActive(false);
            }
        }
    }

    void Update()
    {
       
    }
}