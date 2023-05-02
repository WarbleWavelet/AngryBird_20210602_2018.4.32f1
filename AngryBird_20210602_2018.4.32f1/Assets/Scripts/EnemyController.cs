using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public List<Transform> pigList;
    public Transform pig;
    public Transform Barrier;


    public static EnemyController _instance;

	void Awake()
    {
        _instance = this;
    }
    void Start()
    {

        for (int i = 0; i < pig.childCount; i++)
        {
            pigList.Add( pig.GetChild(i) );
        }
    }                                   
    void Update()
    {     
        
    }
}
