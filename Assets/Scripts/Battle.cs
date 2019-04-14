using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
public int BattlePhase = 0; //0 雙方無動作 1敵人先攻 2玩家先攻 3結果計算
public float EnemyHP_Current;
public float EnemyInner_Current;
public float PlayerHP_Current;
  
public float AttackTimer = 0.0f;
public float AttackLimtTime = 1.0f;
public float IdleTimer = 0.0f;
public float IdleLimtTime = 5.0f;
public float ChanceTimer = 0.0f;
public float ChanceLimitTime = 3.0f;
public Animator PlayerAni;
public Animator EnemyAni;
  
public int PlayerAct=3;
public int EnemyAct=3;
public bool PlayerActable;
public Text Danger;
public byte DangerTrans;
  
private void RPSfunction(int playercmd, int enemyattack) {
    //
    // 上>中>下>上 
    // 上 0 中 1 下 2
    //
    if (playercmd == enemyattack && playercmd!=3 && enemyattack!=3)
    {
        DataCtrl.Data.EnemyInner_Current +=15;
        EnemyAni.GetComponentInParent<AudioSource>().clip = (AudioClip)Resources.Load("SE_wheep");
        EnemyAni.GetComponentInParent<AudioSource>().Play();
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
            EnemyAni.SetTrigger("EA");
            EnemyAni.GetComponentInParent<AudioSource>().clip = (AudioClip)Resources.Load("SE_kick");
            EnemyAni.GetComponentInParent<AudioSource>().Play();
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
            EnemyAni.GetComponentInParent<AudioSource>().clip = (AudioClip)Resources.Load("SE_Punch");
            EnemyAni.GetComponentInParent<AudioSource>().Play();
            EnemyAni.SetTrigger("EA");
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
            EnemyAni.GetComponentInParent<AudioSource>().clip = (AudioClip)Resources.Load("SE_slap");
            EnemyAni.GetComponentInParent<AudioSource>().Play();
            EnemyAni.SetTrigger("EA");
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
            PlayerAni.SetTrigger("PTA");
            EnemyAct = Random.Range(0, 3);
            DataCtrl.Data.PlayerisActble = false;
            Danger.color = new Color32(180, 0, 0, 0);
            }
        else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.S))
        {
            //播放相對動畫
            PlayerAct = 1;
            PlayerAni.SetTrigger("PMA");
            EnemyAct = Random.Range(0, 3);
            DataCtrl.Data.PlayerisActble = false;
            Danger.color = new Color32(180, 0, 0, 0);
            }
        else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.X))
        {
            //播放相對動畫
            PlayerAct = 2;
            PlayerAni.SetTrigger("PBA");
            EnemyAct = Random.Range(0, 3);
            DataCtrl.Data.PlayerisActble = false;
            Danger.color = new Color32(180, 0, 0, 0);
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
                DataCtrl.Data = null;
                SceneManager.LoadScene(3);
            }
        }
    }
}
void EnemyAction()
{
    //
    // DeadFace
    //
    EnemyAct = Random.Range(0, 3);
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
            ShinobeEx();
            if (PlayerAct == 3)
            {
                IdleTimer += Time.deltaTime;
                if (IdleTimer >= IdleLimtTime)
                {
                    if (this.GetComponent<AudioSource>().isPlaying == false)
                    {
                        this.GetComponent<AudioSource>().Play();
                    }
                    ChanceTimer += Time.deltaTime;
                    //玩家頭上冒"爆"字
                    if (DangerTrans <= 205)
                    {
                        DangerTrans += 50;
                    }
                    Danger.color = new Color32(180, 0, 0, DangerTrans);
                    if (DangerTrans ==100)
                    {
                        Danger.GetComponent<AudioSource>().Play();
                    }
                    ChanceTimer += Time.deltaTime;
                    if (ChanceTimer >= ChanceLimitTime && DataCtrl.Data.EnemyHP_Current>0)
                    {
                        EnemyAni.SetTrigger("EA");
                        DangerTrans = 0;
                        Danger.color = new Color32(180, 0, 0, DangerTrans);
                        //敵方使用半血攻擊
                        EnemyAction();
                        DataCtrl.Data.PlayerHP_Current -= 50;
                        this.GetComponent<AudioSource>().Stop();
                        IdleTimer = 0;
                        ChanceTimer = 0;
                    }
                }
            }
            else
            {
                this.GetComponent<AudioSource>().Stop();
                IdleTimer = 0;
                ChanceTimer = 0;
            }
        }
          
        if (DataCtrl.Data.PlayerisActble == false) {
            this.GetComponent<AudioSource>().Stop();
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
