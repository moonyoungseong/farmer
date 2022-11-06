using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject target;


    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float DelayTime;

    void LateUpdate()
    {
        Vector3 FixedPos = new Vector3(
                target.transform.position.x + offsetX,
                target.transform.position.y + offsetY,
                target.transform.position.z + offsetZ
                );
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);

        //Camera �ǹ� ��ǥ�� ���� ȸ��
        transform.LookAt(target.transform.position);
    }


    /*
    public Transform targetTr;
    //MainCamera �ڽ��� Transform������Ʈ
    private Transform camTr;

    //���� ������κ��� ������ �Ÿ�
    [Range(2.0f, 20.0f)]
    public float distance = 5.0f;

    //Y������ �̵��� ����
    [Range(0.0f, 20.0f)]
    public float height = 10.0f;

    

    void Start()
    {
        //Main Camera �ڽ��� Transform ������Ʈ ����
        camTr = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        transform.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        //Camera�� �ǹ� ��ǥ�� ���� ȸ��
        camTr.LookAt(targetTr.position);

        Vector3 rot = transform.eulerAngles;

        rot.x = Mathf.Clamp(rot.x, -90f, 90f);

        transform.eulerAngles = rot; 
       
            MoveLookAt();
    }
    void MoveLookAt()
    {
        //����ī�޶� �ٶ󺸴� �����Դϴ�.
        Vector3 dir = camTr.localRotation * Vector3.forward;
        //ī�޶� �ٶ󺸴� �������� �Ѹǵ� �ٶ󺸰� �մϴ�.
        transform.localRotation = camTr.localRotation;
        //�Ѹ��� Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� �������־����ϴ�.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        �ٶ󺸴� ���� �������� �̵��մϴ�.
        //gameObject.transform.Translate(dir * 0.1f);
    }
    */

}
