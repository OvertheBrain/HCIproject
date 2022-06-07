using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lasers;
    public List<Animator> LaserAnim;
    void Start()
    {
        for(int i=0; i<lasers.Count; i++)
        {

            LaserAnim.Add(lasers[i].GetComponent<Animator>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaserLaunch()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            lasers[i].GetComponent<AudioSource>().Play();
            LaserAnim[i].SetTrigger("Laser");
        }
    }
}
