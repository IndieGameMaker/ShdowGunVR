using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public enum MoveType
    {
        WAY_POINT,
        LOOK_AT
    }

    public MoveType moveType = MoveType.WAY_POINT; //이동 방식을 결정할 변수
    public Transform[] points;

    public float speed = 1.5f;
    public float damping = 3.0f;  //회전 계수, 민감도

    public int nextIdx = 1;

    void Start()
    {
        GameObject wayPointGroup = GameObject.Find("WayPointGroup");
        if (wayPointGroup != null)
        {
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveType)
        {
            case MoveType.WAY_POINT:
                MoveWayPoint();
                break;
            
            case MoveType.LOOK_AT:
                MoveLookAt();
                break;
        }
    }

    void MoveWayPoint()
    {
        //벡터의 뺄셈연산을 통해서 방향 벡터을 산출
        Vector3 dir = points[nextIdx].position - transform.position; 
        //방향벡터의 쿼터니언타입의 각도를 계산
        Quaternion rot = Quaternion.LookRotation(dir);
        //구체선형보간 함수를 이용해 부드럽게 회전
        transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * damping);
        //전진
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveLookAt()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("WAY_POINT"))
        {
            //삼항 연산자 (조건문) ? 참 : 거짓
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;

            /*
            ++nextIdx;
            if (nextIdx >= points.Length)
            {
                nextIdx = 1;
            }
            */
        }
    }


}
