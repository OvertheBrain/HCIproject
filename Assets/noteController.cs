using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noteController : MonoBehaviour
{
    public float velocity;
    public float baselineposy;

    public float deadlineposy;
    public string type;//leftorright
    // Start is called before the first frame update
    public float posx,posy;

    public Color highlight;
    public bool state;
    void Start()
    {
        posx=transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        posy=transform.localPosition.y;
        if(posy<deadlineposy){
            Destroy(gameObject);
        }
        gameObject.transform.localPosition=new Vector3(posx,posy-Time.deltaTime*velocity,0);
        if(state==true){
            GetComponent<Image>().color=highlight;
        }

    }
}
