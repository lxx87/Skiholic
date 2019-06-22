using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverPanel : MonoBehaviour {

    public Text ScoreText;

    public GameObject reserButton;

    private float score = 0;

    private void OnEnable()
    {
        ScoreText.text = "0";
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        if ((int)(score + 0.5f) != GameManager.Instance.Score) {
            score = Mathf.Lerp(score, GameManager.Instance.Score, 0.15f);
            ScoreText.text = "" + (int)(score + 0.5f);
        }
        if ((int)(score + 0.5f) == GameManager.Instance.Score && !reserButton.activeSelf) {
            reserButton.SetActive(true);
        }
    }
}
