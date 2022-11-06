using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCCtrl : MonoBehaviour
{
    
    //NPC��  ���� ����
    
    //��ȭ �����Ÿ�
    public float traceDist = 5.0f;
    //uiâ �����Ÿ�
    public float UI = 2.0f;

    //������Ʈ ĳ�ø� ó���� ����
    private Transform npcTr;
    private Transform playerTr;
    private Animator anim;
    private NavMeshAgent agent;

    public GameObject dialog;

    //Animator �Ķ���� �ؽð� ����
    private readonly int hashTrace = Animator.StringToHash("IsTrace");

    void Start()
    {
        //npc�� Transform �Ҵ�
        npcTr = GetComponent<Transform>();
        //��ȭ ����� Player�� Transform �Ҵ�
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //Animator ������Ʈ �Ҵ�
        anim = GetComponent<Animator>();
        //NavMeshAgent ������Ʈ �Ҵ�
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //NPC�� ���¸�üũ�ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(CheckNpcState());
       

        //���¿� ���� NPC�� �ൿ�� �����ϴ� �ڷ�ƾ �Լ� ȣ��
        //StartCoroutine(NpcAction());
    }

   //������ �������� Npc�� �ൿ üũ
   IEnumerator CheckNpcState()
    {
        while(true)
        {
            //0.3�� ���� �����ϴ� ���� �޽��� ������ �纸
            yield return new WaitForSeconds(0.3f);
            //Npc�� ���ΰ� ĳ���� ������ �Ÿ��� ����
            float distance = Vector3.Distance(playerTr.position, npcTr.position);

            //��ȭ �����Ÿ��� ���Դ��� Ȯ��

            if (distance <= traceDist)
            {
                dialog.SetActive(true);
            }
           
            else
            {
                anim.SetBool(hashTrace, false);
                dialog.SetActive(false);

            }
        }
          

    }

    void Update()
    {
       
    }
}
