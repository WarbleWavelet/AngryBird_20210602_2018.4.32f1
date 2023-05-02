using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : Bird
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
            //GetComponent<Rigidbody2D>().AddForce(-Vector2.left*Time.deltaTime * skillPower);//加力数值太大
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity *= -1f;
            GetComponent<Rigidbody2D>().velocity = velocity;
        
    }
}
