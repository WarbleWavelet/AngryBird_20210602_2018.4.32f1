using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public string levelName;
    public int star;


    void Start()
    {

        levelName = gameObject.name;
        star = PlayerPrefs.GetInt(gameObject.name);
    }

    public void OnButtonClick()
    {
        PlayerPrefs.SetString("IsSelected", gameObject.name);//用于实例那一关
        SceneManager.LoadScene(2);//游戏主场景
    }

    public int StarNum()//根据星星评价图得到星星数量
    {
        Sprite starSprite = transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;//得到那张星星评价的图
        int starIndex = LevelController._instance.rankList.IndexOf(starSprite);//到levelController找在rankList中的索引

        return starIndex;
    }
    //

}
