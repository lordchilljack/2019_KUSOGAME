using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (PlayerUP_Used == true)
        {
            Revive.enabled = false;
        }
        else
        {
            Revive.enabled = true;
        }
        if (chose =="R")
        {
            DataCtrl.Data.PlayerUP_Current -= 1;
            DataCtrl.Data.PlayerUP_Used = true;
            DataCtrl.Data.PlayerHP_Current = 100;
            DataCtrl.Data.PlayerisHPEmtpy = false;
        }
        else if (chose == "D")
        {
            DataCtrl.Data.PlayerAliveOrNot = false; //死透
            //結束遊戲 回主畫面
            //SceneManager.LoadScene();
        }
        DieMsg.transform.localScale = new Vector3(0, 0, 0);
        Dead.transform.localScale = new Vector3(0, 0, 0);
        Revive.transform.localScale = new Vector3(0, 0, 0);
    }

    private void debugview()
    {
        PlayerAliveOrNot = DataCtrl.Data.PlayerAliveOrNot;
        PlayerisDead = DataCtrl.Data.PlayerisHPEmtpy;
        EnemyHP_Current = DataCtrl.Data.EnemyHP_Current;
        EnemyUP_Current = DataCtrl.Data.EnemyUP_Current;
        EnemyInner_Current = DataCtrl.Data.EnemyInner_Current;

        PlayerHP_Current = DataCtrl.Data.PlayerHP_Current;
        PlayerUP_Current = DataCtrl.Data.PlayerUP_Current;
        PlayerUP_Used = DataCtrl.Data.PlayerUP_Used;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerAliveOrNot = DataCtrl.Data.PlayerAliveOrNot;
        PlayerisDead = DataCtrl.Data.PlayerisHPEmtpy;
        EnemyHP_Current = DataCtrl.Data.EnemyHP_Current;
        EnemyUP_Current = DataCtrl.Data.EnemyUP_Current;
        EnemyInner_Current = DataCtrl.Data.EnemyInner_Current;

        PlayerHP_Current = DataCtrl.Data.PlayerHP_Current;
        PlayerUP_Current = DataCtrl.Data.PlayerUP_Current;
        PlayerUP_Used = DataCtrl.Data.PlayerUP_Used;

        EHP.fillAmount = EnemyHP_Current/100.0f;
        EI.fillAmount = EnemyInner_Current/100.0f;
        PHP.fillAmount = PlayerHP_Current/100.0f;
        
        Inner1 = Resources.Load<Sprite>("Inner1");
        Inner2 = Resources.Load<Sprite>("Inner2");
    }

    // Update is called once per frame
    void Update()
    {
        // 更新血量
        EHP.fillAmount = EnemyHP_Current / 100.0f;
        EI.fillAmount = EnemyInner_Current / 100.0f;
        PHP.fillAmount = PlayerHP_Current / 100.0f;
        
        // 敵人內傷計算
        if(DataCtrl.Data.EnemyInner_Current >= 100.0f)
        {
            DataCtrl.Data.EnemyInner_Current = 100;
        }

        //玩家血量計算
        if (DataCtrl.Data.PlayerHP_Current <= 0.0f)
        {
            DataCtrl.Data.PlayerHP_Current = 0;
            if (DataCtrl.Data.PlayerUP_Used == false)
            {
                DataCtrl.Data.PlayerisHPEmtpy = true;
                DieMsg.transform.localScale = new Vector3(1, 1, 1);
                Dead.transform.localScale = new Vector3(1, 1, 1);
                Revive.transform.localScale = new Vector3(1, 1, 1);
            }
            else // 死透了 遊戲結束
            {
                DataCtrl.Data.PlayerAliveOrNot = false;
            }
        }
        debugview();
    }
}
