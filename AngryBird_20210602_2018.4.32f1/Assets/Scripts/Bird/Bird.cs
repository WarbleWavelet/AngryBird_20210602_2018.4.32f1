using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Tooltip("悬挂点，访问它的画线方法，挂着Line")] protected Transform slingshot_Right;

    [Tooltip("涉及弹簧弹力大小")] public float maxDistance=1.5f;


     [Tooltip("死亡特效")] public GameObject deadPrefab;
    [Tooltip("是否")] public bool isDrag;
    [Tooltip("是否已经弹射，检查死亡和画线")] public bool isUp;
    //
    [Tooltip("是否已经死亡")] public bool isDead;
    [Tooltip("处理鸟是否移动")] public Vector3 prePos;
    public float deadDistance = 0.01f;
    //
    [Tooltip("控制飞行的音效只播放一次")] protected bool hasPlayedFly = false;
    protected bool hasPlayedCollision = false;
    //
    public Sprite hurtSprite;
    //
    [Tooltip("技能次数")] public int skillCount = 1;
    public float coolTimer = 0f;
    public float coolTime = 1f;

    [Tooltip("可能是维持技能的唯一性，时间久忘了")] public bool useSkill = false;
    public float skillPower = 2f;
    public Sprite skillSprite;
    //
    void Awake()
    {
    }

    // Start is called before the first frame update
     void Start()
    {
       // PreDragMouseButton(false);//开始false，后面会index=0会调用.不行，用的话BirdController设index=0也没用    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
        
    }
    public void UpdateFunc()//为子类少写点
    {
        //
        if (isDrag)//按下，预备发射
        {
            DragMouseButton();
        }

        if (!isUp)//比isDrag跟线时间更长
        {
            PreUpMouseButton();
        }
        else if (isUp)//松开
        {

            UpMouseButton();
        }
        //
        if ( Input.GetKeyDown(KeyCode.LeftShift) && useSkill == false)
        {
            useSkill = true;
        }
        if (useSkill && skillCount > 0)
        {
            skillCount--;
            ShowSkill();
            //
            coolTimer += Time.deltaTime;
            if (coolTimer > coolTime)
            {
                coolTimer = 0f;
                useSkill = false;
            }
        }
    }



    //
    private void OnMouseDrag()
    {
        if (!UIController._instance.isPause)
        {
            isDrag = true;
        }
        UIController._instance.ShowMessage("按下");
    }
    private void OnMouseUp()
    {
        if (!UIController._instance.isPause)
        {
            isDrag = false;
            isUp = true;
        }
        UIController._instance.ShowMessage("抬起");
    }
    //
    public void PreDragMouseButton(bool isTurn)
    {
        isDrag = false;
        isUp = false;
        isDead = false;
        //
        hasPlayedFly = false;
        hasPlayedCollision = false;
        //一开始设置，不然从发射位一下子，蹬到发射位冲量大.限制距离用到
        slingshot_Right = Slingshot._instance.rightPos;
        //
        if (isTurn)
        {
            GetComponent<SpringJoint2D>().enabled = true;
            transform.position = Slingshot._instance.startPos.position;       
        }
        else
        {
            GetComponent<SpringJoint2D>().enabled = false;
        }

    }
    public void DragMouseButton()//被按着移动
    {
        GetComponent<SpringJoint2D>().enabled = true;//受力牵引
        GetComponent<Rigidbody2D>().isKinematic = true;//

        transform.position = FollowMouse(transform.position);//跟随鼠标         
        transform.position = LimitDistance(transform.position, slingshot_Right.position, maxDistance);//限制距离
    }
    public Vector3 FollowMouse(Vector3 targetPos)//跟随鼠标移动
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetPos);//转屏幕
        screenPos = Input.mousePosition - Camera.main.transform.position;//屏幕中操作
        targetPos = Camera.main.ScreenToWorldPoint(screenPos);//转世界

        return targetPos;
    }
    public Vector3 LimitDistance(Vector3 movePoint, Vector3 basePoint, float maxDistance)//让movePoint始终在距离内
    {
        if (Vector3.Distance(movePoint, basePoint) > maxDistance)
        {
            Vector3 pos = (movePoint - basePoint).normalized;//归一
            movePoint = basePoint + maxDistance * pos;
        }

        return movePoint;
    }
    //
    public void PreUpMouseButton()
    {
        Slingshot._instance.Line(transform);//划线，放这里未发射线都会跟着小鸟，看起来好看
    }
    public void UpMouseButton()//发射
    {
        Slingshot._instance.Line(Slingshot._instance.startPos);
        //
        GetComponent<Rigidbody2D>().isKinematic = false;
        Invoke("RemoveForce", 0.1f);
        
        /**
         * 检测死亡
         */
        //返回isDead
        prePos = transform.position;
        Invoke("IsDead", 2f);//类似于心跳监测
        //
        if (isDead)
        {  
            Dead();
            BirdController._instance.NextBird();//检查状态
        }
        //防止多次播放
        if (hasPlayedFly == false)
        {
            AudioSource.PlayClipAtPoint(DataHub._instance.birdFlyClip, transform.position);
            hasPlayedFly = true;
        }        
    }
    public void RemoveForce()//移除弹簧力，不然力会累加
    {
        GetComponent<SpringJoint2D>().enabled = false;
    }
    //
    private void OnCollisionEnter(Collision collision)
    {
        Hurt(true);
        UIController._instance.ShowMessage("撞击");
    }
    public void Hurt(bool isHurted)
    {
        GetComponent<SpriteRenderer>().sprite = hurtSprite;
    }
    public virtual void IsDead()//位移监测，判断死亡
    {
        if ((Vector3.Distance(transform.position, prePos) < deadDistance))
        {
            isDead = true;         
        }
    }
    public  void Dead()//死亡
    {
        AudioSource.PlayClipAtPoint(DataHub._instance.birdCollisionClip, transform.position);

        Destroy(gameObject);
        BirdController._instance.birdList.RemoveAt(0);
        GameController._instance.StepAfterShoot();
        //TODO:鸟死亡，没特效
    }
    //
    public  virtual void ShowSkill()
    {
        GetComponent<SpriteRenderer>().sprite = skillSprite;
        UIController._instance.ShowMessage("加速");//显示看看
    }

}