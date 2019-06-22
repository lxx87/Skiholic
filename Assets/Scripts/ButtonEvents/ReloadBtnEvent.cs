using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class ReloadBtnEvent : MonoBehaviour
{
    [SerializeField]
    private Button reloadBtn;     // Start is called before the first frame update
    void Start()
    {
        reloadBtn.onClick.AddListener(delegate ()
        {
            
            SceneManager.LoadScene(4);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
