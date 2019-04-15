using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{   public int BattlePhase = 0; //0 雙方無動作 1敵人先攻 2玩家先攻 3結果計算
    public float EnemyHP_Current;
    public float EnemyInner_Current;
    public float PlayerHP_Current;

    public float AttackTimer = 0.0f;
    public float AttackLimtTime = 1.0f;
    public float IdleTimer = 0.0f;
    public float IdleLimtTime = 5.0f;
    public float ChanceTimer = 0.0f;
    public float ChanceLimitTime = 3.0f;

    public int PlayerAct=3;
    public int EnemyAct=3;
    public bool PlayerActable;

    private void RPSfunction(int playercmd, int enemyattack) {
        //
        // 上>中>下>上 
        // 上 0 中 1 下 2
        //
        if (playercmd == enemyattack && playercmd!=3 && enemyattack!=3) {
            DataCtrl.Data.EnemyInner_Current +=15;
        }
        switch (playercmd) {

            case 0:
                if (enemyattack == 1) {
                    DataCtrl.Data.EnemyHP_Current -= 5;
                }
                if (enemyattack == 2)
                {
                    DataCtrl.Data.PlayerHP_Current -= 30;
                }
                break;
            case 1:
                if (enemyattack == 2)
                {
                    DataCtrl.Data.EnemyHP_Current -= 5;
                }
                if (enemyattack == 0)
                {
                    DataCtrl.Data.PlayerHP_Current -= 30;
                }
                break;
            case 2:
                if (enemyattack == 0)
                {
                    DataCtrl.Data.EnemyHP_Current -= 5;
                }
                if (enemyattack == 1)
                {
                    DataCtrl.Data.PlayerHP_Current -= 30;
                }
                break;
        }
    }
    void PlayerAction()
    {
        if (DataCtrl.Data.PlayerisActble)
        {
            if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.W))
            {
                //播放相對動畫
                PlayerAct = 0;
                EnemyAct = Random.Range(0, 2);
                DataCtrl.Data.PlayerisActble = false;
            }
            else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.S))
            {
                //播放相對動畫
                PlayerAct = 1;
                EnemyAct = Random.Range(0, 2);
                DataCtrl.Data.PlayerisActble = false;
            }
            else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.X))
            {
                //播放相對動畫
                PlayerAct = 2;
                EnemyAct = Random.Range(0, 2);
                DataCtrl.Data.PlayerisActble = false;
            }
        }
    }
    void ShinobeEx()
    {
        if (DataCtrl.Data.EnemyInner_Current >= 100.0f)
        {
            if (Input.GetKey(KeyCode.Space)) //斬殺
            {
                if (DataCtrl.Data.EnemyUP_Current > 0)
                {
                    //播放爆炸動畫和音效
                    DataCtrl.Data.EnemyUP_Current -= 1;
                    DataCtrl.Data.EnemyHP_Current = 100.0f;
                    DataCtrl.Data.EnemyInner_Current = 0.0f;
                }
                else
                {
                    //過關
                    //SceneManager.LoadScene();
                }
            }
        }
    }
    void EnemyAction()
    {
        //
        // DeadFace
        //
        EnemyAct = Random.Range(0, 2);
    }
        void debugview()
        {
            BattlePhase = DataCtrl.Data.StageState;
            EnemyHP_Current = DataCtrl.Data.EnemyHP_Current;
            EnemyInner_Current = DataCtrl.Data.EnemyInner_Current;
            PlayerHP_Current = DataCtrl.Data.PlayerHP_Current;
        }
        // Start is called before the first frame update
        void Start()
        {
            BattlePhase = DataCtrl.Data.StageState;
            EnemyHP_Current = DataCtrl.Data.EnemyHP_Current;
            EnemyInner_Current = DataCtrl.Data.EnemyInner_Current;
            PlayerHP_Current = DataCtrl.Data.PlayerHP_Current;
        }

        // Update is called once per frame
        void Update()
        {
            if (!DataCtrl.Data.PlayerisHPEmtpy)
            {
                PlayerAction();
            if (PlayerAct == 3)
            {
                IdleTimer += Time.deltaTime;
                if (IdleTimer >= IdleLimtTime)
                {
                    //玩家頭上冒"爆"字
                    ChanceTimer += Time.deltaTime;
                    if (ChanceTimer >= ChanceLimitTime && DataCtrl.Data.EnemyHP_Current>0)
                    {
                        //敵方使用半血攻擊
                        EnemyAction();
                        DataCtrl.Data.PlayerHP_Current -= 50;
                        IdleTimer = 0;
                        ChanceTimer = 0;
                    }
                }
            }
            else
            {
                IdleTimer = 0;
                ChanceTimer = 0;
            }
            }
            ShinobeEx();
            if (DataCtrl.Data.PlayerisActble == false) {
                if (AttackTimer < DataCtrl.Data.PlayerAct_TimeLimt)
                {
                    AttackTimer += Time.deltaTime;
                }
                else {
                    AttackTimer = 0;
                    DataCtrl.Data.PlayerisActble = true;
                }
            }
            RPSfunction(PlayerAct, EnemyAct);
            PlayerAct = 3;
            EnemyAct = 3;
            PlayerActable = DataCtrl.Data.PlayerisActble;
            debugview();
        }
    }
