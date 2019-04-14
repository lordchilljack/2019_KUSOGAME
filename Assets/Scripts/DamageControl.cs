using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageControl : MonoBehaviour
{
    public bool PlayerAliveOrNot;
    public bool PlayerisHPEmpty;
    public float EnemyHP_Current; // 敵人血量
    public int EnemyUP_Current; // 敵人生命
    public float EnemyInner_Current; //敵人內傷

    public float PlayerHP_Current; // 玩家血量
    public int PlayerUP_Current; // 玩家生命
    public bool PlayerUP_Used; // 玩家是否使用過復活
    public Text DieMsg; //屎的畫面
    private byte DieMsgTrans = 0;

    // 條狀進度條
    public Image EHP;
    public Image EI;
    public Image PHP;
    // 圓點貼圖
    public Image EUP1;
    public Image EUP2;
    public Image PUP1;
    public Image PUP2;

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
            DieMsgTrans = 0;
        }
        else if (chose == "D")
        {
            DataCtrl.Data.PlayerAliveOrNot = false; //死透
            DieMsgTrans = 0;
            //結束遊戲 回主畫面
            SceneManager.LoadScene(0);
        }
        DieMsg.transform.localScale = new Vector3(0, 0, 0);
        Dead.transform.localScale = new Vector3(0, 0, 0);
        Revive.transform.localScale = new Vector3(0, 0, 0);
    }

    private void debugview()
    {
        PlayerAliveOrNot = DataCtrl.Data.PlayerAliveOrNot;
        PlayerisHPEmpty = DataCtrl.Data.PlayerisHPEmtpy;
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
        PlayerisHPEmpty = DataCtrl.Data.PlayerisHPEmtpy;
        EnemyHP_Current = DataCtrl.Data.EnemyHP_Current;
        EnemyUP_Current = DataCtrl.Data.EnemyUP_Current;
        EnemyInner_Current = DataCtrl.Data.EnemyInner_Current;

        PlayerHP_Current = DataCtrl.Data.PlayerHP_Current;
        PlayerUP_Current = DataCtrl.Data.PlayerUP_Current;
        PlayerUP_Used = DataCtrl.Data.PlayerUP_Used;

        EHP.fillAmount = EnemyHP_Current/100.0f;
        EI.fillAmount = EnemyInner_Current/100.0f;
        PHP.fillAmount = PlayerHP_Current/100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 更新血量
        EHP.fillAmount = EnemyHP_Current / 100.0f;
        EI.fillAmount = EnemyInner_Current / 100.0f;
        PHP.fillAmount = PlayerHP_Current / 100.0f;
        if (DataCtrl.Data.EnemyUP_Current == 1)
        {
            EUP1.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (DataCtrl.Data.EnemyUP_Current == 0)
        {
            EUP2.transform.localScale = new Vector3(0, 0, 0);
        }
        if (DataCtrl.Data.PlayerUP_Current == 1)
        {
            PUP1.transform.localScale = new Vector3(0, 0, 0);
            PUP2.color = new Color(0.0f,0.0f,0.0f);
        }

        // 敵人內傷計算
        if (DataCtrl.Data.EnemyInner_Current >= 100.0f)
        {
            DataCtrl.Data.EnemyInner_Current = 100;
        }

        //玩家血量計算
        if (DataCtrl.Data.PlayerHP_Current <= 0.0f)
        {
            DataCtrl.Data.PlayerHP_Current = 0;
            DataCtrl.Data.PlayerisHPEmtpy = true;
            DieMsg.color = new Color32(180,0,0, DieMsgTrans);
            if (DataCtrl.Data.PlayerUP_Used == false)
            {
                DieMsg.transform.localScale = new Vector3(1, 1, 1);
                Dead.transform.localScale = new Vector3(1, 1, 1);
                Revive.transform.localScale = new Vector3(1, 1, 1);
            }
            else // 死透了 遊戲結束
            {
                DataCtrl.Data.PlayerAliveOrNot = false;
                DieMsg.transform.localScale = new Vector3(1, 1, 1);
                Dead.transform.localScale = new Vector3(1, 1, 1);
            }
            if (DieMsgTrans < 245)
            {
                DieMsgTrans+=10;
            }
            
        }
        debugview();
    }
}
