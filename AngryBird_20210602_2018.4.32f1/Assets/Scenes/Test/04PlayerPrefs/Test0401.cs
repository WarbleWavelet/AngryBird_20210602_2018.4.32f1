using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0401 : MonoBehaviour
{
    public int test04;

    public string name;
    // Start is called before the first frame update
    void Start()
    {
        test04 = PlayerPrefs.GetInt("Test04");
        name = gameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
