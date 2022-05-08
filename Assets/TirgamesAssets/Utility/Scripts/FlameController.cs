using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> flames;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchFlame()
    {
        for(int i=0; i<18; i++)
        {
            flames[i].GetComponent<TGUtilsAnimatorPeriodParam>().Launch();
        }
    }
}
