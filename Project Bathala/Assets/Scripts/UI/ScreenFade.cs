using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFade : MonoBehaviour
{
    public Image ObjToFade;
    public Color OverlayColor;

    private void Start()
    {
        StartCoroutine(Fade(false)); 
    }

    public IEnumerator Fade(bool FadeIn)
    {
        ObjToFade.gameObject.SetActive(true);
        Color newCol = OverlayColor;
        if(FadeIn)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                newCol.a = i;
                ObjToFade.color = newCol;
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                newCol.a = i;
                ObjToFade.color = newCol;
                yield return null;
            }
        }
    }
}
