using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalGameController : MonoBehaviour
{
    public GameObject left,right;
    public MusicGameController musicGameController;
    public int score;


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
            musicGameController.Hit("left");
            Debug.Log("left up");
        }
        if(otherObj.gameObject==right) {
            musicGameController.Hit("right");
            Debug.Log("right up");
        }
    }
}
