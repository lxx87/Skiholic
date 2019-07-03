using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowCoinNum : MonoBehaviour
{
    private Text numText;
    [SerializeField] GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        numText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        numText.text = character.GetComponent<ScoreCaculate>().getCoinNum().ToString();
    }
}
