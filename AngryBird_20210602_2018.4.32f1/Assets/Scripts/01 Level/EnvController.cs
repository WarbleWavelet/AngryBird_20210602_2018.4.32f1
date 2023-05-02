using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvController : MonoBehaviour
{

    public Transform sky;
    public Transform ground;
    //
    public List<Sprite> skyList;
    public List<Sprite> groundList;
    //

    public static EnvController _instance;

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

    public void ChangeBg(int level)
    {
        if (level > skyList.Count - 1)
            return;

        sky.GetComponent<Image>().sprite = skyList[level];
        ground.GetComponent<Image>().sprite = groundList[level];
    }
    
}
