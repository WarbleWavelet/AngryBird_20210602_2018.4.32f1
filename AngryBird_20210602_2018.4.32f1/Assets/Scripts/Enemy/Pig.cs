using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig :Enemy
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void PlayCollisionAudioClip()
    {
        PlayAudioClip(DataHub._instance.pigCollisionClip);
    }
    override public  void PlayDestroyedAudioClip()
    {
        PlayAudioClip(DataHub._instance.pigDestroyedClip);
    }
}
