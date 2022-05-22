using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    public List<GameObject> Confettis1;
    public List<ParticleSystem> Confettis1Editor;
    public List<GameObject> Confettis2;
    public List<ParticleSystem> Confettis2Editor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Confettis1.Count; i++)
        {
            Confettis1Editor.Add(Confettis1[i].GetComponent<ParticleSystem>());
        }
        for (int j = 0;j < Confettis2.Count; j++)
        {
            Confettis2Editor.Add(Confettis2[j].GetComponent<ParticleSystem>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchConfetti()
    {
        for (int i = 0; i < Confettis1.Count; i++)
        {
            Confettis1Editor[i].Play();
        }

        for (int j = 0; j < Confettis2.Count; j++)
        {
            Confettis2Editor[j].Play();
        }
    }
}
