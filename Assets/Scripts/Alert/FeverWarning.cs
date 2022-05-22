using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverWarning : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private float alphaSpeed = 10f;
    private float alpha = 0.2f;
    private bool isShow = true;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
        {
            if(canvasGroup.alpha != alpha)
            {
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alpha, alphaSpeed * Time.deltaTime);

                if(Mathf.Abs(canvasGroup.alpha - alpha) <= 0.01)
                {
                    canvasGroup.alpha = alpha;
                    isShow = false;
                }
            }
        }
        else
        {
            if(canvasGroup.alpha != 1)
            {
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, alphaSpeed * Time.deltaTime);

                if (Mathf.Abs(1 - canvasGroup.alpha) <= 0.01)
                {
                    canvasGroup.alpha = 1;
                    isShow = true;
                }
            }
        }

    }
}
