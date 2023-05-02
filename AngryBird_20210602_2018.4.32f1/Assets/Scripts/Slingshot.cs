using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform leftPos;
    public Transform rightPos;

    public LineRenderer leftLine;
    public LineRenderer rightLine;
    [Tooltip("开始位置")] public Transform startPos;

    public int count = 0;

    public static Slingshot _instance;

    void Awake()
    {
        _instance = this;
        leftPos = transform.Find("Slingshot_Left/LeftPos");
        rightPos = transform.Find("Slingshot_Right/RightPos");
        leftLine = transform.Find("Slingshot_Left/LeftPos").GetComponent<LineRenderer>();
        rightLine = transform.Find("Slingshot_Right/RightPos").GetComponent<LineRenderer>();
        startPos = transform.Find("startPos"); ;
    }


    void Update()
    {
        count = leftLine.positionCount;
    }
    public void Line(Transform projectile)//发射物
    {

        leftLine.SetPosition(0, leftPos.position);
        leftLine.SetPosition(1, projectile.position);

        rightLine.SetPosition(0, rightPos.position);
        rightLine.SetPosition(1, projectile.position);
    }
}
