using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour
{

    public List<int> list = new List<int> { 0, 1, 2, 3, 4 };

    // Start is called before the first frame update
    void Start()
    {
        list.Remove(list[2]);

        print(list.IndexOf(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
