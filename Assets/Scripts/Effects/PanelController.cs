using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<GameObject> Panels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation()
    {
        foreach(GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }

    public void StopAnimation()
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(true);
        }
    }
}
