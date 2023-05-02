using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, false);//宽，高，不可修改
        Invoke("Load",2f);//延时
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
