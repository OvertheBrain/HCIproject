using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class emotionContoller : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] sprites;
    float rotLerp,yLerp;
    float x0,y0,z0;

    public Dropdown dropdown;
    public Image butimg;

    public AudioSource btn_sound;
    
    void Start()
    {
        yLerp=7;
        z0=transform.localPosition.z;
        y0=transform.localPosition.y;
        x0=transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rot=new Vector3(0,0,1f);
        transform.Rotate(rot*Mathf.Cos(rotLerp));
        rotLerp+=Time.deltaTime*10;
        
        
        yLerp+=Time.deltaTime;
        transform.localPosition=posLerp(yLerp);
        gameObject.GetComponent<SpriteRenderer>().color=new Color(255,255,255, alphaLerp(yLerp));
    }

    Vector3 posLerp(float yLerp){

        float y=y0;
        if(yLerp<1){
            y=y0+yLerp-1;
        }
        else if(yLerp>3){
            y=y0+(yLerp-3)*3;
        }
        else{
            y=y0;
        }
        Vector3 ret=new Vector3(x0,y,z0);

        return ret;
    }
    float alphaLerp(float yLerp){
        float a=0;
        if(yLerp<1){
            a=yLerp;
        }
        else if(yLerp>3){
            a=(4-yLerp);
        }
        else{
           a=1;
        }
        return a/2;
    }

    public void Launch(int id){
        gameObject.GetComponent<SpriteRenderer>().sprite=sprites[id];
        yLerp=0;
    }

    public void OnSwitch(){
        if(dropdown==null||butimg==null) return;
        int id= dropdown.value;
        butimg.sprite =sprites[id];
    }

    public void ButtonLaunch(){
        if(dropdown==null) return;
        int id= dropdown.value;
        btn_sound.Play();
        Launch(id);
    }
}
