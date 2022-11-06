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

        //Camera 피벗 좌표를 향해 회전
        transform.LookAt(target.transform.position);
    }


    /*
    public Transform targetTr;
    //MainCamera 자신의 Transform컴포넌트
    private Transform camTr;

    //따라갈 대상으로부터 떨어질 거리
    [Range(2.0f, 20.0f)]
    public float distance = 5.0f;

    //Y축으로 이동할 높이
    [Range(0.0f, 20.0f)]
    public float height = 10.0f;

    

    void Start()
    {
        //Main Camera 자신의 Transform 컴포넌트 추출
        camTr = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        transform.position = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        //Camera를 피벗 좌표를 향해 회전
        camTr.LookAt(targetTr.position);

        Vector3 rot = transform.eulerAngles;

        rot.x = Mathf.Clamp(rot.x, -90f, 90f);

        transform.eulerAngles = rot; 
       
            MoveLookAt();
    }
    void MoveLookAt()
    {
        //메인카메라가 바라보는 방향입니다.
        Vector3 dir = camTr.localRotation * Vector3.forward;
        //카메라가 바라보는 방향으로 팩맨도 바라보게 합니다.
        transform.localRotation = camTr.localRotation;
        //팩맨의 Rotation.x값을 freeze해놓았지만 움직여서 따로 Rotation값을 0으로 세팅해주었습니다.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        바라보는 시점 방향으로 이동합니다.
        //gameObject.transform.Translate(dir * 0.1f);
    }
    */

}
