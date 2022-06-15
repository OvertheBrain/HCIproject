using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMP;

public class songController : MonoBehaviour
{
    // Start is called before the first frame update
    UniversalMediaPlayer ump;

    public FlameController fire;
    public SmokeController smokes1;
    public SmokeController smokes2;
    public CeilingController laser;
    public SpotsController lights;
    public StageLightsController stage;

    public GameObject UI;
    public GameObject UI2;

    public GameObject canvas;

    float curtime=-1,lasttime;
    void Start()
    {
        ump=GetComponent<UniversalMediaPlayer>();
    }

    // Update is called once per frame

    public void SongStart(){
        ump.Play();
        curtime=0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SongStart();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.PlayWarmUp();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.PlayOpening();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameManager.instance.PlayClapping();
        }

        if (curtime>=0){
            lasttime=curtime;
            curtime+=Time.deltaTime;
            checkSche();
        }
        
    }

    void checkSche(){

        
        if(OnTime(13.5f)){
            //喷火
            fire.LaunchFlame();
        }
        if (OnTime(35.3f))
        {
            fire.LaunchFlame();
        }
        if (OnTime(44))
        {
            laser.LaserLaunch();
        }
        if (OnTime(58))
        {
            GameObject Alert = Instantiate(UI, new Vector3(0, 0, 0), Quaternion.identity);
            Alert.transform.SetParent(canvas.transform, false);
            Alert.GetComponent<AlerController>().time = 10;
            Alert.GetComponent<AlerController>().hotness = 100;
            GameManager.instance.FeverDuration = 35;
            GameManager.instance.isAlerting = true;
            stage.TurnLights(true);
        }
        if (OnTime(93))
        {
            smokes1.SmokeLaunch();
            smokes2.SmokeLaunch();
            fire.LaunchFlame();
        }
        if (OnTime(94))
        {
            GameObject JumpAlert = Instantiate(UI2, new Vector3(0, 0, 0), Quaternion.identity);
            JumpAlert.transform.SetParent(canvas.transform, false);
            JumpAlert.GetComponent<JumpController>().time = 11;
            GameManager.instance.jumpBoundary = 1;

            GameManager.instance.isJumping = true;
        }
        if (OnTime(111))
        {
            smokes1.SmokeLaunch();
            smokes2.SmokeLaunch();
            lights.turnOff();
        }

    }

    bool OnTime(float time){
        if(lasttime<time&&curtime>=time) return true;
        else return false;
    }


}
