using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
public class ButtonEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    public GameObject character;
    public GameObject lineDrawer;
    public Button comfirmBtn;
    public Button restartBtn;
    
    private bool startRunning = false;
    void Start()
    {

        
        comfirmBtn.onClick.AddListener(delegate ()
        {
            this.camera.GetComponent<CameraMove>().enabled = false;
            this.camera.GetComponent<CameraFollow>().enabled = true;
            this.camera.GetComponent<CountDown>().enabled = true;
            //character.GetComponent<Platformer2DUserControl>().enabled = true;
            lineDrawer.GetComponent<DrawLine>().enabled = false;
            //Debug.Log("position: "+comfirmBtn.transform.position);
            //comfirmBtn.transform.position = 2 * comfirmBtn.transform.position;
            comfirmBtn.gameObject.SetActive(false);
            restartBtn.gameObject.SetActive(false);
            startRunning = true;
        });

        restartBtn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(4);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
