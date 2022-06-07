using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLightsController : MonoBehaviour
{
    public List<Animator> anim;
    public List<GameObject> Lights;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject light in Lights)
        {
            anim.Add(light.GetComponent<Animator>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFever()
    {
        foreach(Animator Anim in anim)
            Anim.SetBool("Fever", true);
    }

    public void StopFever()
    {
        foreach (Animator Anim in anim)
            Anim.SetBool("Fever", false);
    }
}
