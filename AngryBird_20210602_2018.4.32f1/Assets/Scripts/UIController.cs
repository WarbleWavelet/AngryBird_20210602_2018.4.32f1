using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text scoreText;
    public Text messageText;
    //
    public GameObject resultUI;
    public Transform Star_1;
    public Transform Star_2;
    public Transform Star_3;
    //
    public GameObject pauseUI;
    public bool isPause = false;
    public int score=0;
    //

    public static UIController _instance;

	void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        messageText.gameObject.SetActive(false);
        resultUI.SetActive(false);
        transform.Find("PauseButton").GetComponent<Button>().onClick.AddListener(() => Pause());
        //pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }
    public void ShowMessage(string str)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = str;

        StartCoroutine(DisableMessage());
    }


    
    IEnumerator DisableMessage()
    {
        yield return new WaitForSeconds(2f);
        messageText.gameObject.SetActive(false);
    }

    public void ShowStar(int startCount)
    {
        switch (startCount)
        {
            case 0: break;
            case 1: Star_1.gameObject.SetActive(true); break;
            case 2: Star_2.gameObject.SetActive(true); break;
            case 3: Star_3.gameObject.SetActive(true); break;
            default: throw new System.Exception("星级评价异常"); 
        }
    }
    //
    public void Pause()//鼠标事件不能传参
    {
        isPause = !isPause;
        pauseUI.SetActive(isPause);
        pauseUI.GetComponent<Animator>().SetBool("isPause",isPause);
    }
    public void LoadLevel()
    {

        SceneManager.LoadScene(1);   
    }
    //
    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

}
