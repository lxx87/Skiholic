using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Props : MonoBehaviour
{
    string m_FileName;
    string[] strs;
    int fly, speed, magnet, shield;

    public Button shieldButton;
    public Button magnetButton;
    public Button speedButton;
    public Button flyButton;

    public GameObject management;
    public GameObject lock_4;
    public GameObject lock_3;
    public GameObject lock_2;
    public GameObject lock_1;

    public GameObject shb;
    public GameObject mab;
    public GameObject spb;
    public GameObject flb;

    bool choosed = false;

    // Start is called before the first frame update
    void Start()
    {
        m_FileName = "道具.txt";
        string path = Application.persistentDataPath + "/" + m_FileName;
        if (!File.Exists(path))
        {
            strs = new string[] { "1", "1", "1", "0" };
            File.Create(path).Dispose();
            File.WriteAllLines(path, strs);
        }
        else
        {
            strs = File.ReadAllLines(path);
        }

        shield = int.Parse(strs[0]);
        magnet = int.Parse(strs[1]);
        speed = int.Parse(strs[2]);
        fly = int.Parse(strs[3]);

        if (shield == 0)
            shieldButton.interactable = false;
        else
            lock_1.SetActive(false);

        if (magnet==0)
            magnetButton.interactable = false;
        else
            lock_2.SetActive(false);

        if (speed == 0)
            speedButton.interactable = false;
        else
            lock_3.SetActive(false);

        if (fly == 0)
            flyButton.interactable = false;
        else
            lock_4.SetActive(false);

        shieldButton.onClick.AddListener(delegate ()
        {
            if (choosed == false)
            {
                choosed = true;
                this.management.GetComponent<Managememt>().choise = 4;
                flyButton.interactable = false;
                speedButton.interactable = false;
                magnetButton.interactable = false;
            }
            else
            {
                choosed = false;
                if (fly == 1)
                    flyButton.interactable = true;
                if (speed == 1)
                    speedButton.interactable = true;
                if (magnet == 1)
                    magnetButton.interactable = true;
            }
        });

        magnetButton.onClick.AddListener(delegate ()
        {
            if (!choosed)
            {
                choosed = true;
                this.management.GetComponent<Managememt>().choise = 3;
                flyButton.interactable = false;
                speedButton.interactable = false;
                shieldButton.interactable = false;
            }
            else
            {
                choosed = false;
                if (fly == 1)
                    flyButton.interactable = true;
                if (speed == 1)
                    speedButton.interactable = true;
                if (shield == 1)
                    shieldButton.interactable = true;
            }
        });

        speedButton.onClick.AddListener(delegate ()
        {
            if (!choosed)
            {
                choosed = true;
                this.management.GetComponent<Managememt>().choise = 2;
                flyButton.interactable = false;
                magnetButton.interactable = false;
                shieldButton.interactable = false;
            }
            else
            {
                choosed = false;
                if (fly == 1)
                    flyButton.interactable = true;
                if (shield == 1)
                    shieldButton.interactable = true;
                if (magnet == 1)
                    magnetButton.interactable = true;
            }
        });

        flyButton.onClick.AddListener(delegate ()
        {
            if (!choosed)
            {
                choosed = true;
                this.management.GetComponent<Managememt>().choise = 1;

                speedButton.interactable = false;
                magnetButton.interactable = false;
                shieldButton.interactable = false;
            }
            else
            {
                choosed = false;
                if (shield == 1)
                    shieldButton.interactable = true;
                if (speed == 1)
                    speedButton.interactable = true;
                if (magnet == 1)
                    magnetButton.interactable = true;
            }
        });
    }

    public void clearProps()
    {
        this.shb.SetActive(false);
        this.mab.SetActive(false);
        this.spb.SetActive(false);
        this.flb.SetActive(false);
        this.lock_1.SetActive(false);
        this.lock_2.SetActive(false);
        this.lock_3.SetActive(false);
        this.lock_4.SetActive(false);
    }

}
