using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSetup : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject Boss;
    public Text BossName;
    public int ChozenSeed;
    // Start is called before the first frame update
    void Start()
    {
        ChozenSeed = Random.Range(0, 4);
        switch (ChozenSeed)
        {

            case 0:
                BackGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BG_01");
                break;
            case 1:
                BackGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BG_02");
                break;
            case 2:
                BackGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BG_03");
                break;
            case 3:
                BackGround.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BG_04");
                break;
        }
        ChozenSeed = Random.Range(0,3);
        switch (ChozenSeed)
        {

            case 0:
                BossName.text = "主管 痿名賤聖";
                break;
            case 1:
                BossName.text = "經理 慈孤觀音";
                break;
            case 2:
                BossName.text = "總裁 黑洞醬";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
