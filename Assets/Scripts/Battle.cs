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
    public float AttackLimtTime = 3.0f;
    public int SneakHit_Count = 0;
    public int SneakHit_Limit = 2;
    public int PlayerAct=3;
    public int EnemyAct=3;

    private void RPSfunction(int playercmd, int enemyattack) {
        //
        // 上>中>下>上 
        // 上 0 中 1 下 2
        //
        if (playercmd == enemyattack) {
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

    // Start is called before the first frame update
    void Start()
    {
        BaatlePhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (BaatlePhase) {
            case 0:
                if (SneakHit_Count < SneakHit_Limit) {
                    if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.W)) {
                        //播放相對動畫
                        PlayerAct = 0;
                        EnemyAct = 1;
                    } else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.S)) {
                        //播放相對動畫
                        PlayerAct = 1;
                        EnemyAct = 2;
                    }
                    else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.X)) {
                        //播放相對動畫
                        PlayerAct = 2;
                        EnemyAct = 0;
                    }
                    SneakHit_Count += 1;
                }
                else {
                    if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.W))
                    {
                        //播放相對動畫
                        PlayerAct = 0;
                        EnemyAct = 2;
                    }
                    else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.S))
                    {
                        //播放相對動畫
                        PlayerAct = 1;
                        EnemyAct = 0;
                    }
                    else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.X))
                    {
                        //播放相對動畫
                        PlayerAct = 2;
                        EnemyAct = 1;
                    }
                    SneakHit_Count = 0;
                }
                BaatlePhase = 2;
                break;
            case 1:
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
                BaatlePhase = 2;
                break;
            case 2:
                RPSfunction(PlayerAct,EnemyAct);
                PlayerAct = 3;
                EnemyAct = 3;
                BaatlePhase = 0;
                break;
            default:
                break;
        }
    }
}
