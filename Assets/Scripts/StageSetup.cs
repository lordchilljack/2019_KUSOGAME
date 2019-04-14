using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSetup : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject Boss;
    public Text SongName;
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
        ChozenSeed = Random.Range(0,1);//目前只有劍聖0 其他BOSS製作中
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
        ChozenSeed = Random.Range(0, 3);
        switch (ChozenSeed)
        {
            case 0:
                this.GetComponent<AudioSource > ().clip = (AudioClip)Resources.Load("Asura");
                SongName.text = "♪Asura by ilodolly";
                this.GetComponent<AudioSource>().Play();
                break;
            case 1:
                this.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BibidoBlue");
                SongName.text = "♪ビビッドブルー  by かずち";
                this.GetComponent<AudioSource>().Play();
                break;
            case 2:
                this.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Bloodsucker");
                SongName.text = "♪Bloodsucker by MFP【Marron Fields Production】";
                this.GetComponent<AudioSource>().Play();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
