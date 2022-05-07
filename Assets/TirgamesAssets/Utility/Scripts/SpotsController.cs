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
        {
            for(int i=0; i<lights.Count; i++)
            {
                lights[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SetActive(false);
            }
        }
    }
}
