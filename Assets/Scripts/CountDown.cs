using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
public class CountDown : MonoBehaviour
{
    public Text textToShow;
    public string[] labels = { "3", "2", "1", "GO" ,""};
    public GameObject management;
    // Start is called before the first frame update
    void Start()
    {
        textToShow.GetComponent<Text>().enabled = true;
        StartCoroutine(countDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator countDown()
    {
        for(int i=0;i<labels.Length-1;i++)
        {
            textToShow.text = labels[i];
            yield return new WaitForSeconds(1);
        }
        textToShow.text = labels[labels.Length - 1];
        yield return new WaitForSeconds(0.2f);
        textToShow.gameObject.SetActive(false);
        management.GetComponent<GameStart>().begin();
    }
}
