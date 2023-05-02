using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test01_Parent : MonoBehaviour
{

    public float timer = 0f;
    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            timer = 0f;
        }
    }




}
