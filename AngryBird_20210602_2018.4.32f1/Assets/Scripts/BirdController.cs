using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public List<Bird> birdList;


    public static BirdController _instance;

	void Awake()
    {
        _instance = this;
    }
        
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            birdList.Add(transform.GetChild(i).GetComponent<Bird>());
        }
        NextBird();
    }



    public void NextBird()//index==0，就
    {
        for (int i = 0; i < birdList.Count; i++)
        {
            bool isTurn = i == 0 ? true : false;//轮到了？

            birdList[i].enabled = isTurn;//不然进不去组件
            birdList[i].PreDragMouseButton(isTurn);
            //
            CameraFollowTarget._instance.target = birdList[0].transform;
        }
    }
}
