using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{   public int BaatlePhase = 0; //0 雙方無動作 1敵人先攻 2玩家先攻 3結果計算
    public float EnemyHP_Current;
    public float EnemyInner_Current;
    public float PlayerHP_Current;

    public float AttackTimer = 0.0f;
    public float AttackLimtTime = 1.0f;
    public int SneakHit_Count = 0;
    public int SneakHit_Limit = 2;
    public int PlayerAct=3;
    public int EnemyAct=3;

    private void RPSfunction(int playercmd, int enemyattack) {
        //
        // 上>中>下>上 
        // 上 0 中 1 下 2
        //
        if (playercmd == enemyattack && playercmd!=3 && enemyattack!=3) {
            EnemyInner_Current+=25;
        }
        switch (playercmd) {

            case 0:
                if (enemyattack == 1) {
                    EnemyHP_Current -= 5;
                }
                if (enemyattack == 2)
                {
                    PlayerHP_Current -= 30;
                }
                break;
            case 1:
                if (enemyattack == 2)
                {
                    EnemyHP_Current -= 5;
                }
                if (enemyattack == 0)
                {
                    PlayerHP_Current -= 30;
                }
                break;
            case 2:
                if (enemyattack == 0)
                {
                    EnemyHP_Current -= 5;
                }
                if (enemyattack == 1)
                {
                    PlayerHP_Current -= 30;
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
            }
            else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.S))
            {
                //播放相對動畫
                PlayerAct = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.X))
            {
                //播放相對動畫
                PlayerAct = 2;
            }
            EnemyAct = Random.Range(0, 2);
            DataCtrl.Data.PlayerisActble = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        BaatlePhase = DataCtrl.Data.StageState;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAction();
        if (DataCtrl.Data.PlayerisActble == false) {
            if (AttackTimer < DataCtrl.Data.PlayerACt_TimeLimt)
            {
                AttackTimer += Time.deltaTime;
            }
            else {
                AttackTimer = 0;
                DataCtrl.Data.PlayerisActble = true;
            }
        }
        RPSfunction(PlayerAct,EnemyAct);
        PlayerAct = 3;
        EnemyAct = 3;
    }
}
