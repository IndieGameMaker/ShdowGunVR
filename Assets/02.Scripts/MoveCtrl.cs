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

    }

    void MoveLookAt()
    {
        
    }


}
