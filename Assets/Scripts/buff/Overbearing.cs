using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overbearing : MonoBehaviour
{
    private GameObject effortPref;
    private GameObject effort;
    // Start is called before the first frame update
    void Start()
    {
        effortPref = (GameObject)Resources.Load("Prefabs/overbearingEffort");
        effort = GameObject.Instantiate(effortPref);
        effort.transform.parent = this.transform;
        effort.transform.localPosition = new Vector3(0, 0, -4);
        //effort.transform.localScale = new Vector3(radius, radius, 1);
        effort.transform.rotation = this.transform.rotation;
    }
}
