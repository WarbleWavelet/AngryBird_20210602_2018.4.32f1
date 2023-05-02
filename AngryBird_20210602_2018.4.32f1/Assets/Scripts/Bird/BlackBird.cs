using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{

    public List<Enemy> enemyList;
    public Transform boomFiledSprite;

    // Start is called before the first frame update
    void Start()
    {
        boomFiledSprite.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
    }

    public override void ShowSkill()//鼠标左键触发
    {
        base.ShowSkill();//继承家产

        AudioSource.PlayClipAtPoint(DataHub._instance.woodDestroyedClip, transform.position);//爆炸音效          
        
        boomFiledSprite.gameObject.SetActive(true);//显示爆炸范围            
            
        //
        TrimDead();
        //杀敌
        while(enemyList.Count > 0)
        { 
            Destroy(enemyList[0].gameObject);               
        }
        //
        
    }


    //
    private void OnTriggerEnter2D(Collider2D other)
    {
        UIController._instance.ShowMessage("撞击");
        if (other.CompareTag(Tags.Enemy))
        {
            if (other.GetComponent<Enemy>() != null)
            {
                enemyList.Add(other.GetComponent<Enemy>());
            }
                           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        UIController._instance.ShowMessage("撞出");

        enemyList.Remove(other.gameObject.GetComponent<Enemy>());
    }
    void TrimDead() //剔除一撞就死了，导致挂的Enemy也没了的物体
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.Remove(enemyList[i]);
                i--;
            }
        }
    }
    //
    public override void IsDead()
    {
        boomFiledSprite.transform.SetParent(transform.parent.parent.parent);
        Destroy(boomFiledSprite.gameObject, 1f);

        isDead = true;
    }
}
