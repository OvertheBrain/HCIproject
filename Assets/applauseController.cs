using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applauseController : MonoBehaviour
{

    public AudioSource source;
    public AudioClip applause;
    public GameObject otherhand;
    
    // Start is called before the first frame update
    void Start()
    {
        source=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other){
        if(gameObject==otherhand){
            source.PlayOneShot(applause,1f);
            Debug.Log("clap");
        }
        
        
    }
}
