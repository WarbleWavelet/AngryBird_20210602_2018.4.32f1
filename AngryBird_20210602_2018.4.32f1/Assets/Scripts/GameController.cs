using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public string nameTest;
    public int fullStars=3;
    public int pigMaxCount;
    //

    //
    public int star ;
    public int starSave ;

    public static GameController _instance;

	void Awake()
    {
        _instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        nameTest = gameObject.name;

        pigMaxCount =EnemyController._instance.pig.childCount;

    }
    void Update()
    {
        
    }


    public void  StepAfterShoot()
    {      
        int pigCount = EnemyController._instance.pig.childCount;
        int birdCount = BirdController._instance.birdList.Count;
        //
        if (birdCount <= 0 || (birdCount > 0 && pigCount <= 0) )
        {
            UIController ui = UIController._instance;
            //
            ui.ShowMessage("游戏通关");
            ui.resultUI.SetActive(true);
            star = fullStars - pigCount;
            ui.ShowStar(star);

            
        }
        else if (birdCount > 0 && pigCount > 0)
        {
            BirdController._instance.NextBird();//下一只鸟
        }
        else
        {
            throw new System.Exception("异常");
        }
        //
        Save(gameObject.name, star);

        starSave = PlayerPrefs.GetInt(gameObject.name);
    }
    //

    //存读档
    public void Save(string level, int star)
    {

        if (PlayerPrefs.HasKey(level))//有且大于
        {
            if (star < PlayerPrefs.GetInt(level))
            {
                return;
            }
        }

        //其他情况，有且大于；没有
        PlayerPrefs.SetInt(level, star);
    }


}
