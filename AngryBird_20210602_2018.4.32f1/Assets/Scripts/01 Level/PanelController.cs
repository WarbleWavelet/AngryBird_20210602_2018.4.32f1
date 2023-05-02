using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [Tooltip("子节点是关卡的节点")] public Transform panelContent;
    [Tooltip("关卡的列表")] public List<Panel> panelList = new List<Panel>();

    [Tooltip("背景图")] public List<Sprite> bgList = new List<Sprite>();
    //

    [Tooltip("每个panel获得的星星总数")] public List<int> starNumList;
    [Tooltip("每个panel解锁需要的的星星")] public List<int> unlockNeedStarNumList;//一开始是new List<int>() { 0,10,10,10,10,   10,10};

    //

    public static PanelController _instance;

    void Awake()
    {
        _instance = this;

        //索引节点
        for (int i = 0; i < panelContent.childCount; i++)
        {
            panelList.Add(panelContent.GetChild(i).GetComponent<Panel>());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //
        starNumList = LevelController._instance.starNumList;
        unlockNeedStarNumList = new List<int>() { 0, 10, 13, 10, 16, 10, 19 };

        //
     

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < panelList.Count; i++)
        {
            panelList[i].level = i + 1;
            //背景
            panelList[i].bg.GetComponent<Image>().sprite = bgList[i];
            //获得的

            panelList[i].starNum = starNumList[i];
            panelList[i].starNumText.text = starNumList[i].ToString();
            //解锁所需星星
            panelList[i].unlockNeedStarNum = unlockNeedStarNumList[i];
            if (i > 0)
            {
                //显示
                panelList[i].starProgressText.text = starNumList[i - 1].ToString() + "/" + unlockNeedStarNumList[i].ToString();
                //判断解锁
                if (starNumList[i - 1] >= unlockNeedStarNumList[i])
                {
                    panelList[i].isLocked = false;
                }
            }
            //
            panelList[0].isLocked = false;


        }

    }


}
