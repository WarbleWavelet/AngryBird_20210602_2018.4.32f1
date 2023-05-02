using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Tooltip("受伤的最小速度")] public float minSpeed;
    [Tooltip("受伤的最大速度，大于就死亡")] public float maxSpeed;
    //
    [Tooltip("受伤的图片")] public Sprite hurtSprite;
    [Tooltip("死亡的特效")] public GameObject deadPrefab;
    [Tooltip("死亡的特效的销毁时间")] public float deadTime=1f;
    //
    public int score = 3000;
    [Tooltip("死亡的得分的图片")] public Sprite scoreSprite;//死亡的得分
    [Tooltip("死亡的得分的销毁时间")] public float scoreTime=1f;
    [Tooltip("得分的相对高度")] public Vector3 offset=new Vector3(0f,1.6f,0f);

    // Start is called before the first frame update
    void Start()
    {
        scoreSprite = DataHub._instance.score3000Pink;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D self)
    {
        //TODO:鸟撞击音效
        //Collider2D other = self.collider;
        //if (other.tag == "Player")
        //{
        //    print("撞击后鸟");
        //    AudioSource.PlayClipAtPoint(DataHub._instance.birdCollisionClip, transform.position);
        //}
        //
        float speed = self.relativeVelocity.magnitude;
        if (speed > maxSpeed)
        {
            Dead();
        }
        else if (speed < maxSpeed && speed > minSpeed)
        {
            Hurt(this.hurtSprite);
        }
        else//TODO:没打到，敌人应该给一个贱贱的图
        { 
        
        }
    }
    //
    public void Hurt(Sprite sprite)//受伤
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        
        //
        PlayCollisionAudioClip();
    }
    public void Dead()//死亡
    {
        PlayDestroyedAudioClip();
        //
        ShowScore(this.scoreSprite,this.offset,this.scoreTime,this.score);
        PlayEffect(this.deadPrefab);
        EnemyController._instance.pigList.Remove(transform);
        Destroy(gameObject);
        
        //
        


    }


    public void PlayEffect(GameObject prefab)//死亡特效，但觉得还有受伤特效，所以没写dead
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = transform.position;

        Destroy(go, deadTime);
    }
    public void ShowScore(Sprite scoreSprite, Vector3 offset ,float scoreTime,int score)//
    {
        //得分
        GameObject go = new GameObject();
        go.AddComponent<SpriteRenderer>().sprite = scoreSprite;
        go.transform.position = transform.position + offset;//正上方
        UIController._instance.ShowScore(score);

        Destroy(go, scoreTime);
    }
    //音效，木头，猪音效不一样
    virtual public void PlayCollisionAudioClip() { }
    virtual public void PlayDestroyedAudioClip() { }
    public void PlayAudioClip(AudioClip clip)//仅仅为了少写点
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    //
}
