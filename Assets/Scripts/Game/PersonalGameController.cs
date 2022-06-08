using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalGameController : MonoBehaviour
{
    public GameObject left,right;
    public int PersonalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //musicGameController=GetComponent<MusicGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider otherObj) {
        if (otherObj.gameObject==left) {
            GameManager.instance.isHiting = true;
            Debug.Log("left up");
        }
        if(otherObj.gameObject==right) {
            GameManager.instance.isHiting = true;
            Debug.Log("right up");
        }

        PersonalScore += 1;

        if (GameManager.instance.isAlerting)
        {
            PersonalScore += 2;
        }
    }
}
