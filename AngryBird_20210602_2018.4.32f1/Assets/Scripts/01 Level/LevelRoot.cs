using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Canvas上，饮用一些Active麻烦的
/// </summary>
public class LevelRoot : MonoBehaviour
{
    public Button btnBack;

    public static LevelRoot _instance;

    void Awake()
    {
        _instance = this;
        btnBack = transform.Find("BackButton").GetComponent<Button>();
        btnBack.gameObject.SetActive(false);
    }


}
