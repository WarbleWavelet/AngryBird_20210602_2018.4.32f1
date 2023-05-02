using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel : MonoBehaviour
{


    [Tooltip("背景")] public Transform bg;
    [Tooltip("第几关")] public int level = 1;
    //
    public Transform collectedStars;
    [Tooltip("当前关获得了多少星星")] public int starNum = 0;
    [Tooltip("当前关获得了多少星星文本")] public Text starNumText;
    //
    public Transform unlockNeedStars;
    [Tooltip("解锁这一关需要上一关的多少星星")] public int unlockNeedStarNum = 0;
    [Tooltip("解锁这一关需要上一关的多少星星进度")] public Text starProgressText;
    //
    [Tooltip("这一关是否解锁")] public bool isLocked = false;
    [Tooltip("解锁图标")] public Transform lockImage;
    //

    [Tooltip("点击了这一关")] public bool isSelected = false;
    //



    // Update is called once per frame
    void Update()
    {
        if (isLocked)
        {
            Lock();
        }
        else if (!isLocked)
        {
            Unlock();
        }
        //
        starNumText.text = starNum.ToString();
        starProgressText.text = unlockNeedStarNum.ToString();
    }

    void Lock()
    {
        lockImage.gameObject.SetActive(true);
        unlockNeedStars.gameObject.SetActive(true);
        collectedStars.gameObject.SetActive(false);
    }
    void Unlock()
    {
        lockImage.gameObject.SetActive(false);
        unlockNeedStars.gameObject.SetActive(false);
        collectedStars.gameObject.SetActive(true);
    }
    //
    public void OnButtonClick()
    {
        if (isLocked == true)//未解锁无法进入
            return;
        if(isLocked == false)//还未用到
            isSelected = true;

        int index = PanelController._instance.panelList.IndexOf(this);//获得自己在父节点的子节点列表的索引
       
        //更换sky，grounp
        EnvController._instance.ChangeBg(index);
        //进入相应的Panel
        LevelController._instance.panelList[index].gameObject.SetActive(true);
        //隐藏Panel页面
        PanelController._instance.transform.GetChild(0).gameObject.SetActive(false);
         LevelRoot._instance.btnBack.gameObject.SetActive(true);
    }


}
