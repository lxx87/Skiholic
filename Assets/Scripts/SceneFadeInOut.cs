using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SceneFadeInOut : MonoBehaviour
{
    [SerializeField]
    public Material material;  //材质球
    [SerializeField]
    public float ChangeSpeed = 3f;  
    private float count;
    private Action action;
    void Awake()
    {
        
    }

    void Start()
    {
        StartCoroutine(fadeIn());
    }


    //所有渲染完成后被调用，来渲染图片的后期处理效果 https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnRenderImage.html  
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    IEnumerator fadeIn()
    {
        material.SetFloat("_Radius", 0);
        while (material.GetFloat("_Radius") <= 1.5)
        {
            count = material.GetFloat("_Radius") + ChangeSpeed * Time.deltaTime;
            material.SetFloat("_Radius", count);
            yield return 0;
        }
        yield return 0;
    }

    IEnumerator fadeOut()
    {
        material.SetFloat("_Radius", 1.5f);
        while (material.GetFloat("_Radius") >= 0)
        {
            float change = 0;
            if(Time.timeScale>0.1f)
            {
                change = ChangeSpeed * Time.deltaTime;
            }
            else
            {
                change = ChangeSpeed * 0.025f;
            }
            count = material.GetFloat("_Radius") - change;
            material.SetFloat("_Radius", count);
            yield return 0;
        }
        action();
        yield return 0;
    }

    public void startFadeOut(Action a)
    {
        action = a;
        StartCoroutine(fadeOut());
    }
}


