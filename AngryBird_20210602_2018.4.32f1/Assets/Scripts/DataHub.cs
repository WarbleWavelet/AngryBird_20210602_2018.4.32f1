using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHub : MonoBehaviour
{
    public Sprite score3000PinkYellow;
    public Sprite score3000Pink;
    public Sprite score3000Yellow;
    public Sprite score3000Red;
                  
    public Sprite score5000Green;
                  
    public Sprite score10000Red;
    public Sprite score10000Blue;
    public Sprite score10000Yellow;
    public Sprite score10000Black;
    public Sprite score10000White;
    public Sprite score10000Green;
    public Sprite score1000Orange;
    //
    public AudioClip bgmClip;

    public AudioClip birdFlyClip;
    public AudioClip birdSelectClip;
    public AudioClip birdCollisionClip;

    public AudioClip woodDestroyedClip;
    public AudioClip woodCollisionClip;

    public AudioClip pigDestroyedClip;
    public AudioClip pigCollisionClip;

    public static DataHub _instance;

	void Awake()
    {
        _instance = this;
    }
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
