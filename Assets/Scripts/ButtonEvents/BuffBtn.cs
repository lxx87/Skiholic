using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuffBtn : MonoBehaviour
{
    [SerializeField]
    private Sprite magnetImg;
    [SerializeField]
    private Sprite overbearingImg;
    [SerializeField]
    private Sprite speedupImg;
    [SerializeField]
    private Sprite wingsuitImg;
    [SerializeField]
    private GameObject management;
    [SerializeField]
    private GameObject character;
    private delegate void Handler();
    private Handler handler = null;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        int choise = management.GetComponent<Managememt>().choise;
        
        switch(choise)
        {
            case 4:
                GetComponent<Image>().sprite = overbearingImg;
                handler = overbearing;
                break;
            case 3:
                GetComponent<Image>().sprite = magnetImg;
                handler = magnet;
                break;
            case 2:
                GetComponent<Image>().sprite = speedupImg;
                handler = speedUp;
                break;
            case 1:
                GetComponent<Image>().sprite = wingsuitImg;
                handler = wingsuit;
                break;
            default:
                destotyItself();
                return;
        }   
    }

    public void useProp()
    {
        handler();
        destotyItself();
        return;
    }

    private void Update()
    {
        if (character.GetComponent<ScoreCaculate>().isDeathOrFail())
        {
            destotyItself();
        }
    }

    private void magnet()
    {
        this.character.AddComponent<Magnet>();
    }

    private void overbearing()
    {
        this.character.AddComponent<Overbearing>();
    }

    private void speedUp()
    {
        this.character.AddComponent<SpeedUp>();
    }

    private void wingsuit()
    {
        this.character.AddComponent<Wingsuit>();
    }

    private void destotyItself()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }

    private void OnDestroy()
    {
        
    }
}
