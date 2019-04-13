using System.Collections;
using System.Collections.Generic;

public class GameDataManager
{
    public bool PlayerAliveOrNot = true; //玩家是否活著 true活 false死透
    public bool PlayerisHPEmtpy = false;     //玩家是否觸發沒血
    public float EnemyHP_Current = 100.0f; // 敵人血量
    public int EnemyUP_Current = 2; // 敵人生命
    public float EnemyInner_Current = 0.0f; //敵人內傷

    public float PlayerHP_Current = 100.0f; // 玩家血量
    public int PlayerUP_Current = 2; // 玩家生命
    public bool PlayerUP_Used = false;// 本面是否使用過回生

    public int PlayerAct = 3; //玩家攻擊 0上段 1中段 2下段 3待機
    public int EnemyAct = 3; //敵人攻擊 0上段 1中段 2下段 3待機

    public float PlayerAct_TimeLimt = 0.2f;//玩家指令不接受時間
    public int StageState = 0; //關卡狀況 0:普通 1:可忍殺 2:玩家死亡 3:換敵人
    public bool PlayerisActble = true;//玩家可以進行攻擊

}
