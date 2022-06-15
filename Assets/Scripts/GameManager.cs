using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private float jumpPeriod = 0;

    public int perOfClapping = 0;
    public AudioSource Applause;
    public bool isClapping = false;

    public AudioSource WarmUp;
    public AudioSource FeverCheer;

    public Text Clappers;

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

            jumpPeriod += Time.deltaTime;
        }

        Clappers.text = perOfClapping.ToString();

        
    }

    public void LaunchFever()
    {
        foreach (GameObject Smoke in Smokes)
            Smoke.GetComponent<SmokeController>().SmokeLaunch();
        Fire.GetComponent<FlameController>().LaunchFlame();
        Confetti.GetComponent<ConfettiController>().LaunchConfetti();
        FeverCheer.Play();

        isAlerting = false;
        isInFever = true;

        SpinLights.GetComponent<SpinLightsController>().turnOn();
        Lights.GetComponent<SpotsController>().turnOff();
        Panels.GetComponent<PanelController>().PlayAnimation();
        FrontLights.GetComponent<FrontLightsController>().PlayFever();
        StageLights.GetComponent<StageLightsController>().PlayFever();

        currentHotness = 0;
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
        currentHotness = 0;
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
        WarmUp.Stop();
        StartCoroutine(Opening());
    }

    public void PlayJumping()
    {
        if (jumpPeriod >= 2.5f)
        {
            Fire.GetComponent<FlameController>().LaunchFlame();
            perOfJumpig = 0;
            jumpPeriod = 0;
        }
        else
            return;
    }

    public void PlayClapping()
    {
        if (perOfClapping < 1) return;
        if(perOfClapping >= 1 && isClapping)
        {
            Applause.Play();
            Confetti.GetComponent<ConfettiController>().LaunchConfetti();
            perOfClapping = 0;
        }
    }

    public void PlayWarmUp()
    {
        StageLights.GetComponent<StageLightsController>().TurnLights(false);
        WarmUp.Play();
    }
}
