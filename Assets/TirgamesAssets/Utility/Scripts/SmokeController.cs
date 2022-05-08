using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> smokes;
    public List<ParticleSystem> SmokeEditor;

    void Start()
    {
        for(int i=0; i<smokes.Count; i++)
        {
            SmokeEditor.Add(smokes[i].GetComponent<ParticleSystem>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SmokeLaunch()
    {
        for (int i = 0; i < smokes.Count; i++)
        {
            SmokeEditor[i].Play();
        }
    }
}
