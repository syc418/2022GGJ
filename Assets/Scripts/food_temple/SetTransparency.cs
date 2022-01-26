using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransparency : MonoBehaviour
{

    public float defaultTransparency = 255f;
    public float toFadeTo = 0f;
    public float fadeDuration = 3f;

    float currentTransparency;
    
    float tempDist;
    bool isFadingUp;
    bool isFadingDown = true;



    void Start()
    {
        currentTransparency = defaultTransparency;
        ApplyTransparency();
    }

    void FixedUpdate()
    {
        if (isFadingUp)
        {
            if (currentTransparency < toFadeTo)
            {
                currentTransparency += (tempDist / fadeDuration) * Time.deltaTime;
                ApplyTransparency();
            }
            else
            {
                isFadingUp = false;
            }
        }
        else if (isFadingDown)
        {
            if (currentTransparency > toFadeTo)
            {
                currentTransparency -= (tempDist / fadeDuration) * Time.deltaTime;
                ApplyTransparency();
            }
            else
            {
                isFadingDown = false;
            }
        }
    }

    void ApplyTransparency()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, currentTransparency);
    }



    public void SetT(float newT)
    {
        currentTransparency = newT;
        ApplyTransparency();
    }

    public void FadeT(float newT)
    {
        toFadeTo = newT;
        if (currentTransparency < toFadeTo)
        {
            tempDist = toFadeTo - currentTransparency;
            isFadingUp = true;
        }
        else
        {
            tempDist = currentTransparency - toFadeTo;
            isFadingDown = true;
        }
    }


}