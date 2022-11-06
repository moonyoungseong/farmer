
#pragma warning disable IDE0051
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private Animator anim;
    private new Transform transform;
    private Vector3 moveDir;
    private readonly int hashWalk = Animator.StringToHash("IsWalk");
    private readonly int hashPick = Animator.StringToHash("IsPick");

   
    //��ó ������Ʈ�� �����ϱ� ���� ����
    public GameObject nearObject;

    public Transform nearPoint;
    public GameObject button_01;
    public GameObject button_02;

    public GameObject Seed;
    public bool hasSeed;
    public bool Pick;
    public int count=0;

    void Start()
    {
        transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        button_01.SetActive(false);
        button_02.SetActive(false);

    }
    
    void Update()
    {
       
        if (moveDir == Vector3.zero)
        {
            anim.SetBool(hashWalk, false);
        }
        
        if (moveDir != Vector3.zero)
        {
            //���� �������� ȸ��
            transform.rotation = Quaternion.LookRotation(moveDir);

            //ȸ���� �� ������������ �̵�
            transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
        }
        transform.LookAt(transform.position + moveDir);

    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        //2���� ��ǥ�� 3���� ��ǥ�� ��ȯ
        moveDir = new Vector3(dir.x, 0, dir.y);

        anim.SetBool(hashWalk, true);

        Debug.Log($"Move= ({dir.x},{dir.y})");
    }


    void OnPickup()
    {
        
        anim.SetTrigger(hashPick);
        anim.SetBool(hashWalk, false);
       
            if (nearObject.tag == "Seed" )
            {
                Destroy(nearObject, 0.5f);
                hasSeed = true;
            button_02.SetActive(true);
            Invoke("OnButton_02", 2.0f);
        }
    }
    private void OnButton_02()
    {
        button_02.SetActive(false);
    }

    void OnPlant()
    {

        anim.SetTrigger(hashPick);
        anim.SetBool(hashWalk, false);

        if (hasSeed==true)
        {
            Instantiate(Seed,nearPoint.position, nearPoint.rotation);
            hasSeed = true;
        }
        button_01.SetActive(true);
        Invoke("OnButton_01",2.0f);
    }
    private void OnButton_01()
    {
        button_01.SetActive(false);   
    }


    void OnTriggerStay(Collider other)
    {
        if(other.tag=="Seed")
        {
            nearObject=other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Seed")
        {
            nearObject = null;
        }
    }
}
