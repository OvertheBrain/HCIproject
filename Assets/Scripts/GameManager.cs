using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Smokes;
    public GameObject Fire;
    public GameObject Confetti;
    public GameObject Lights;
    public GameObject SpinLights;
    public GameObject Panels;
    public GameObject StageLights;
    public GameObject FrontLights;
    public GameObject Lasers;

    public bool isAlerting = false;
    public int currentHotness = 0;
    public bool isHiting = false;

    public bool isInFever = false;
    public float currentFeverTime = 0;
    public float FeverDuration = 30;

    public bool isJumping = false;
    public int perOfJumpig = 0;
    public int jumpBoundary = 0;

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
        if (!isAlerting)
            currentHotness = 0;
        if (isAlerting)
        {
            
        }

        if (isInFever)
        {
            currentFeverTime += Time.deltaTime;
        }
        if(currentFeverTime >= FeverDuration)
        {
            Fever2Normal();
        }

        if (isJumping)
        {
            if(perOfJumpig >= jumpBoundary)
            {
                PlayJumping();
            }
        }
    }

    public void LaunchFever()
    {
        foreach (GameObject Smoke in Smokes)
            Smoke.GetComponent<SmokeController>().SmokeLaunch();
        Fire.GetComponent<FlameController>().LaunchFlame();
        Confetti.GetComponent<ConfettiController>().LaunchConfetti();

        isAlerting = false;
        isInFever = true;

        SpinLights.GetComponent<SpinLightsController>().turnOn();
        Lights.GetComponent<SpotsController>().turnOff();
        Panels.GetComponent<PanelController>().PlayAnimation();
        FrontLights.GetComponent<FrontLightsController>().PlayFever();
        StageLights.GetComponent<StageLightsController>().PlayFever();
    }

    public void Fever2Normal()
    {
        isInFever = false;   
        SpinLights.GetComponent<SpinLightsController>().turnOff();
        Lights.GetComponent<SpotsController>().turnOn();
        Panels.GetComponent<PanelController>().StopAnimation();
        StageLights.GetComponent<StageLightsController>().StopFever();
        FrontLights.GetComponent<FrontLightsController>().StopFever();
        StageLights.GetComponent<StageLightsController>().TurnLights(false);

        currentFeverTime = 0;
    }

    public void Alert2Normal()
    {
        isAlerting = false;
        StageLights.GetComponent<StageLightsController>().TurnLights(false);
    }

    IEnumerator Opening()
    {
        StageLightsController stageLight = StageLights.GetComponent<StageLightsController>();
        stageLight.TurnLights(true);
        yield return new WaitForSeconds(1.5f);
        stageLight.PlayOpening();
        yield return new WaitForSeconds(3.2f);
        stageLight.TurnLights(false);
        Lasers.GetComponent<CeilingController>().LaserLaunch();
        yield return new WaitForSeconds(1.5f);
        yield return null;
    }

    public void PlayOpening()
    {
        StartCoroutine(Opening());
    }

    public void PlayJumping()
    {
        Fire.GetComponent<FlameController>().LaunchFlame();
        perOfJumpig = 0;
    }
}
