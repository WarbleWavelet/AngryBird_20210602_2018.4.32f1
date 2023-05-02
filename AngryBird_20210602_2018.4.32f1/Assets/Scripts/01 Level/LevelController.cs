using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{


    [Tooltip("评价0123颗星星")] public List<Sprite> rankList;
    [Tooltip("关卡解锁后的底图")] public List<Sprite> bgList;
    //
    [Tooltip("子节点,即panel")] public List<Transform> panelList;
    //

    [Tooltip("记录点击关卡")] public int selectedLevel;
    //
    public string levelTestName;
   


    public static LevelController _instance;
    public List<int> starNumList;

    void Awake()
    {
        _instance = this;
        

       
    }
        
    // Start is called before the first frame update
    void Start()
    {
        Init();
        starNumList = new List<int>() { 0,0,0,0,0, 0,0};
       
    }
    void Init()
    {
        //每个面板
        for (int i = 0; i < transform.childCount; i++)
        {
            panelList.Add(transform.GetChild(i));
        }
        //
        for (int i = 0; i < panelList.Count; i++)
        {
            Transform panel = panelList[i];
            //面板下的关卡
            for (int j = 0; j < panel.childCount; j++)
            {
                //为可读
                Transform level = panel.GetChild(j);
                //
                string levelName;
                levelName = "Level";
                levelName += "0" + (i+1);
                levelName += "_";
                levelName += "0" + (j + 1);
                level.gameObject.name = levelName;
                //
                Transform lockTrans = level.GetChild(1);
                Transform unlockTrans = level.GetChild(0);
                lockTrans.gameObject.SetActive(false);
                unlockTrans.gameObject.SetActive(true);
                //0关卡，1星星
                unlockTrans.GetChild(0).GetComponent<Text>().text = (j + 1).ToString();//关卡数
                //
                int star = PlayerPrefs.GetInt(level.gameObject.name);
                unlockTrans.GetChild(1).GetComponent<Image>().sprite = rankList[star];//评价星星数
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        starNumList = StarNum();
    }
    public List<int> StarNum()//计算每个Panel下的星星总数
    {
        for (int i = 0; i < panelList.Count; i++)
        {
            int star = 0;
            for (int j = 0; j < panelList[i].childCount; j++)
            {
                Transform level = panelList[i].GetChild(j);
                star += level.GetComponent<Level>().star;
            }
            starNumList[i]=star;
        }

        return starNumList;
    }
    //
    public void OnBackButtonClick()
    {
        PanelController._instance.transform.GetChild(0).gameObject.SetActive(true);
        LevelController._instance.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }
}
