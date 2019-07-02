using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ClickLevel1()
    {
        SceneManager.LoadScene(5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
