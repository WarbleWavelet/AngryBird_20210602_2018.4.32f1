using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    public static BackButton _instance;

	void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnBackButtonClick);
    }



    public void OnBackButtonClick()
    {
        PanelController._instance.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < LevelController._instance.transform.childCount; i++)
        {
            LevelController._instance.transform.GetChild(i).gameObject.SetActive(false);
        }
    
        transform.gameObject.SetActive(false);
    }
}
