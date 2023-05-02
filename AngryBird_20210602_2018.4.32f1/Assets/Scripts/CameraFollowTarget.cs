using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    public Transform target;
    // clamp
    public float startX = 0f;
    public float endX = 15f;
    public float smooth = 3f;
    //
    private Vector3 pos;
    //

    public static CameraFollowTarget _instance;

	void Awake()
    {
        _instance = this;
    }
        
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            CameraFollowTargetFunc();
        }
        else
        {
            transform.position = pos;
        }
    }

    public void CameraFollowTargetFunc()
    {
        float posX = Mathf.Clamp(target.position.x, startX, endX);
        float posY = transform.position.y;
        float posZ = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, posZ), smooth);



    }
}
