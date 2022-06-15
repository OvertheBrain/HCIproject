using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class glowStickController : MonoBehaviour
{
    // Start is called before the first frame update

    public Color[] colors;
    public int colorId;
    public bool colorful=false;

    public Color GlowColor;

    public Button control;

    private Light glowLight;

    float ctime;

    void Start()
    {
        colorId=colors.Length;
        colorful=true;
        glowLight = GetComponentInChildren<Light>();
    }

     public static Color ConvertHsvToRgb(double h, double s, double v, float alpha)
    {
 
        double r = 0, g = 0, b = 0;
 
        if (s == 0)
        {
            r = v;
            g = v;
            b = v;
        }
 
        else
        {
            int i;
            double f, p, q, t;
 
 
            if (h == 360)
                h = 0;
            else
                h = h / 60;
 
            i = (int)(h);
            f = h - i;
 
            p = v * (1.0 - s);
            q = v * (1.0 - (s * f));
            t = v * (1.0 - (s * (1.0f - f)));
 
 
            switch (i)
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;
 
                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;
 
                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;
 
                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;
 
                default:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }
        }
        return new Color((float)r, (float)g, (float)b, alpha);
    }


    // Update is called once per frame
    void Update()
    {
        if(colorful==true){
            ctime+=Time.deltaTime;
            if(ctime>4) ctime-=4;
            float h=90*ctime;
            Color col=ConvertHsvToRgb(h,1,1,1);
            GlowColor = col;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", GlowColor);
            if(control!=null)
            control.image.color=GlowColor;
        }

        glowLight.color = GlowColor;
        
    }

    public void SetColorful(bool on)
    {
        colorful = on;
    }
    public void SwitchColor(){
        colorId++;
        if(colorId>colors.Length)colorId=0;

        

        if(colorId==colors.Length){
            colorful=true;
            ctime=0;
        }
        else
        {
            GlowColor = colors[colorId];
            colorful=false;
            if(control!=null)
            control.image.color=new Color(GlowColor.r,GlowColor.g,GlowColor.b,1);
            GetComponent<Renderer>().material.SetColor("_EmissionColor", GlowColor);
        } 

        
    }
}
