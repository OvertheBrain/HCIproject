using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Smokes;
    public GameObject Fire;
    public GameObject Confetti;

    public bool isAlerting = false;

    static public GameManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchFever()
    {
        foreach (GameObject Smoke in Smokes)
            Smoke.GetComponent<SmokeController>().SmokeLaunch();
        Fire.GetComponent<FlameController>().LaunchFlame();
        Confetti.GetComponent<ConfettiController>().LaunchConfetti();
        isAlerting = false;
    }
}
