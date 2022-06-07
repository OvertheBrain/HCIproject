using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLightsController : MonoBehaviour
{
    public List<GameObject> SpinLights;
    public List<Animator> anim;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject light in SpinLights)
        {
            anim.Add(light.GetComponent<Animator>());
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySpinLights()
    {
        on = !on;

        if (on)
            turnOn();
        else
            turnOff();
    }

    public void turnOn()
    {
        foreach (Animator animator in anim)
        {
            animator.SetBool("On", true);
        }
    }

    public void turnOff()
    {
        foreach (Animator animator in anim)
        {
            animator.SetBool("On", false);
        }
    }
}
