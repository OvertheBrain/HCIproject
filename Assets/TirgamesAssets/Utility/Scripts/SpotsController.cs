using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lights;
    public bool on = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turn()
    {
        on = !on;
        if (on)
            turnOn();
        else
            turnOff();
    }

    public void turnOn()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
    }

    public void turnOff()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }
}
