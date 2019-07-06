using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class PropPanel : MonoBehaviour
{
    private Button[] buffBtns = new Button[4];
    private List<Button> activeBuffBtns = new List<Button>();
    [SerializeField] private GameObject character;
    private int choise = 0;
    // Start is called before the first frame update
    void Start()
    {
        string m_FileName = "道具.txt";
        string[] strs;
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
        for(int i=0;i<4;i++)
        {
            buffBtns[i] = transform.GetChild(i).gameObject.GetComponent<Button>();
            if(strs[i].Equals("0"))
            {
                ButtonUtil.Disactive(buffBtns[i]);
                buffBtns[i].gameObject.transform.Find("Lock").gameObject.SetActive(true);
            }
            else
            {
                activeBuffBtns.Add(buffBtns[i]);
            }
        }
        for(int i=0;i<activeBuffBtns.Count;i++)
        {
            int index = i;
            activeBuffBtns[i].onClick.AddListener(delegate ()
            {
                Active(activeBuffBtns[index]);
            });
        }
    }

    private void Update()
    {
        if (character.GetComponent<ScoreCaculate>().isDeathOrFail())
        {
            destotyItself();
        }
    }

    private void Active(Button b)
    {
        foreach(Button button in activeBuffBtns)
        {
            if(b.Equals(button))
            {
                ButtonUtil.Active(button);
            }
            else
            {
                ButtonUtil.Disactive(button);
            }
        }
    }

    public void changeListener()
    {
        for(int i=0;i<4;i++)
        {
            if(ButtonUtil.IsActive(buffBtns[i]))
            {
                choise = i;
            }
            /*else
            {
                buffBtns[i].gameObject.SetActive(false);
            }*/
        }
        Debug.Log("choise " + choise);
        for(int i=0;i<4;i++)
        {
            if(i!=choise)
            {
                Debug.Log("222");
                buffBtns[i].gameObject.SetActive(false);
            }
        }
        switch(choise)
        {
            case 0:
                buffBtns[choise].onClick.RemoveAllListeners();
                buffBtns[choise].onClick.AddListener(delegate ()
                {
                    character.AddComponent<Magnet>();
                    destotyItself();
                });
                break;
            case 1:
                buffBtns[choise].onClick.RemoveAllListeners();
                buffBtns[choise].onClick.AddListener(delegate ()
                {
                    character.AddComponent<SpeedUp>();
                    destotyItself();
                });
                break;
            case 2:
                buffBtns[choise].onClick.RemoveAllListeners();
                buffBtns[choise].onClick.AddListener(delegate ()
                {
                    character.AddComponent<Overbearing>();
                    destotyItself();
                });
                break;
            case 3:
                buffBtns[choise].onClick.RemoveAllListeners();
                buffBtns[choise].onClick.AddListener(delegate ()
                {
                    character.AddComponent<Wingsuit>();
                    destotyItself();
                });
                break;
        }

        
    }

    private void destotyItself()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }

    class ButtonUtil
    {
        static Color gray = new Color(0.78f, 0.78f, 0.78f, 0.5f);
        public static void Disactive(Button b)
        {
            b.gameObject.GetComponent<Image>().color = b.colors.disabledColor;
        }

        public static void Active(Button b)
        {
            b.gameObject.GetComponent<Image>().color = Color.white;
        }

        public static bool IsActive(Button b)
        {
            return b.gameObject.GetComponent<Image>().color.Equals(Color.white);
        }
    }
}
