using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public static GameManager Instance {
        get {
            if(instance != null)
                return instance;
            return null;
        }
    }



    [HideInInspector]
    public Vector3 nextFloor;
    [HideInInspector]
    public Vector3 nowFloor;
    [HideInInspector]
    public bool isJumping;
    [HideInInspector]
    public bool isLeft;
    [HideInInspector]
    public bool isGameing = false;

    public Transform CameraTransform;

    public GameObject floor;

    public GameObject Player;

    public GameObject floorEffect;

    public Text ScoreText;

    public Animator ScoreAnimator;

    public int Score;

    public GameObject OverPanel;
    public GameObject StartPanel;
    public GameObject GamePanel;
    [Header("天空材质")]
    public Material skyMaterial;
    
    /// <summary>
    /// 改变天空颜色计时器
    /// </summary>
    private int nestSkyCount;

    private void Awake()
    {
        this.name = "GameManager";
        instance = this;
    }

    private void Update()
    {
        //镜头跟随
        if (isGameing) {
            CameraTransform.position = Vector3.Lerp(CameraTransform.position , new Vector3((nextFloor.x - nowFloor.x) * 0.5f + nowFloor.x, 0 , (nextFloor.z - nowFloor.z)*0.5f + nowFloor.z) , 0.05f);
        }
    }

    public void GameStart() {
        ScoreAnimator = ScoreText.GetComponent < Animator > ();

        OverPanel.SetActive(false);
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        Score = -2;

        ScoreText.text = "0";

        nowFloor = Vector3.zero;

        nextFloor = Vector3.zero; 

        //预加载指定对象
        if (!GamePool.Instance.SelectObject("floor"))
            GamePool.Instance.PreloadingGameObject(floor, 6, "floor");

        if (!GamePool.Instance.SelectObject("floorEffect"))
            GamePool.Instance.PreloadingGameObject(floorEffect, 1, "floorEffect");

        GamePool.Instance.DisableObjectWitchTable("floor");
        GamePool.Instance.DisableObjectWitchTable("floorEffect");


        CameraTransform.position = Vector3.zero;

        //创建地板
        nowFloor = GamePool.Instance.InstantiatePoolObject<Transform>("floor", new Vector3(0, -9, 0), Quaternion.identity, new Vector3(-100, -100, -100)).position;
        //创建主角
        GameObject.Instantiate(Player, Vector3.up * 3 , Quaternion.identity);

        isGameing = true;
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver() {
        Debug.Log("<color=red>GameOver</color>");
        isGameing = false;
        OverPanel.SetActive(true);
        StartPanel.SetActive(false);
        GamePanel.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    /// <summary>
    /// 生成下一个跳跃平台
    /// </summary>
    public void NextFloor(Vector3 pos) {
        nestSkyCount -= 1;
        if (nestSkyCount <= 0) {
            StartCoroutine(changeBreak());
            nestSkyCount = Random.Range(2,5);
        }
        nowFloor = pos;
        isLeft = (Random.Range(0, 2) < 1) ? true : false;
        float Floorscale = Random.Range(1.5f, 2.5f);

        float length = Random.Range(3f , 6);
        if (isLeft)
        {
           nextFloor = GamePool.Instance.InstantiatePoolObject<Transform>("floor", new Vector3(nowFloor.x + length, -9, nowFloor.z) , Quaternion.identity , new Vector3(Floorscale, 1 , Floorscale)).position;
        }
        else {
           nextFloor = GamePool.Instance.InstantiatePoolObject<Transform>("floor", new Vector3(nowFloor.x, -9, nowFloor.z + length), Quaternion.identity, new Vector3(Floorscale, 1, Floorscale)).position;
        }
        //清理远距离的方块
        clearFloor();
    }

    public void clearFloor() {
        GamePool.Instance.GetActiveObjectAll("floor").ForEach(floorT => {
            if ((CameraTransform.position.x - floorT.transform.position.x) >= 8 || CameraTransform.position.z - floorT.transform.position.z >= 8) {
                floorT.SetActive(false);
            }
        });
    }

    public void addScore(int scoreValue) {
        Score += scoreValue;
        ScoreAnimator.Play(0);
        ScoreText.text = "" + Score;
    }

    /// <summary>
    /// 改变天空颜色动画
    /// </summary>
    /// <returns></returns>
    IEnumerator changeBreak() {
        //Debug.Log("改变天空颜色");
        Color oldColor = skyMaterial.color;
        Color[] prefabsColor = {Color.yellow , Color.green, Color.red , Color.magenta};
        Color newColor = prefabsColor[Random.Range(0, prefabsColor.Length)];
        float count = 2;
        while (count >= 0) {
            count -= 0.02f;
            skyMaterial.color = Color.Lerp(skyMaterial.color, newColor , 0.05f);
            yield return 0;
        }
        skyMaterial.color = newColor;
        //Debug.Log("改变颜色完成");
        yield return 0;
    }
}
