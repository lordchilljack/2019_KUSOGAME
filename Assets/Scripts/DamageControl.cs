using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageControl : MonoBehaviour
{
    public bool PlayerAliveOrNot;
    public bool PlayerisDead;
    public float EnemyHP_Current; // 敵人血量
    public int EnemyUP_Current; // 敵人生命
    public float EnemyInner_Current; //敵人內傷

    public float PlayerHP_Current; // 玩家血量
    public int PlayerUP_Current; // 玩家生命
    public bool PlayerUP_Used; // 玩家是否使用過復活
    public Text DieMsg; //屎的畫面

    // 條狀進度條
    public Image EHP;
    public Image EI;
    public Image PHP;
    // 圓點貼圖
    public Image EUP;
    public Image PUP;

    public Button Revive; //復活
    public Button Dead; //就此屎去

    // 生命值
    private Sprite Inner1; // 生命值為一
    private Sprite Inner2; // 生命值為二

    public void ReLife(string chose)
    {
        if (PlayerUP_Used == true) {
            Revive.enabled = false;
        }
        if (chose =="R")
        {
            PlayerUP_Current -= 1;
            PlayerUP_Used = true;
        }
        else if (chose == "D")
        {
            PlayerAliveOrNot = false; //死透
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerAliveOrNot = true;
        PlayerisDead = false;
        EnemyHP_Current = 100.0f;
        EnemyUP_Current = 2;
        EnemyInner_Current = 0.0f;

        PlayerHP_Current = 100.0f;
        PlayerUP_Current = 2;
        PlayerUP_Used = false;

        EHP.fillAmount = EnemyHP_Current;
        EI.fillAmount = EnemyInner_Current;
        PHP.fillAmount = PlayerHP_Current;

        Inner1 = Resources.Load<Sprite>("Inner1");
        Inner2 = Resources.Load<Sprite>("Inner2");
    }

    // Update is called once per frame
    void Update()
    {
        // 更新血量
        // 敵人血量計算
        if(EnemyHP_Current <= 0.0f && Input.GetKey(KeyCode.Space))
        {
            if(EnemyUP_Current > 0)
            {
                
            }
            else
            {
                // 王死去 下一隻
            }   
        }
        // 敵人內傷計算
        if(EnemyInner_Current >= 100.0f)
        {
            if (Input.GetKey(KeyCode.Space)) //斬殺
            {
                if (EnemyUP_Current > 0)
                {
                    EnemyUP_Current -= 1;
                    EnemyHP_Current = 100.0f;
                }
                else
                {
                    // 王死去 下一隻
                }
            }
            else
            {
                // 繼續讓玩家砍王
            }
        }

        //玩家血量計算
        if (PlayerHP_Current <= 0.0f)
        {
            if (PlayerUP_Used == false)
            {
                PlayerisDead = true;
            }
            else // 死透了 遊戲結束
            {
                PlayerAliveOrNot = false;
            }
        }
    }
}
