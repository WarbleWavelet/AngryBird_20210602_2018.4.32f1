using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public List<GameObject> levelList;
    void Awake()
    {


        
    }
    // Start is called before the first frame update
    void Start()
    {
        string levelName;
        if (!PlayerPrefs.HasKey("IsSelected"))
            levelName = "Level01_01";
        else
            levelName = PlayerPrefs.GetString("IsSelected");

        GameObject go = Resources.Load<GameObject>(levelName);
        Instantiate(go);
        //
        //for (int i = 0; i < levelList.Count; i++)
        //{
        //    if(levelList[i].gameObject.name == levelName)
        //        Instantiate( levelList[i] );
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
