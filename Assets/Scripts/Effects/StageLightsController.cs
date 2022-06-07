using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLightsController : MonoBehaviour
{
    private Animator anim;
    public List<GameObject> Lights;
    public List<GameObject> LightBeam;
    public List<GameObject> DiscoLights;

    private AudioSource Opening;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Opening = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnLights(bool on)
    {
        foreach(GameObject light in Lights)
        {
            light.SetActive(on);
        }
        foreach (GameObject light in LightBeam)
        {
            light.SetActive(on);
        }

        if (on)
        {
            foreach(GameObject light in DiscoLights)
            {
                light.GetComponent<AudioSource>().Play();
            }
        }
    }

    public void PlayOpening()
    {
        Opening.Play();
        anim.SetTrigger("Opening");
    }


    public void PlayFever()
    {
        anim.SetBool("Fever", true);
    }

    public void StopFever()
    {
        anim.SetBool("Fever", false);
    }
}
