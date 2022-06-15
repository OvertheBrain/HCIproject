using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Actions { Wave, Hit, Clap, PPPH }
    public bool[] boolOfActions = new bool[4];

    public int PersonalScore = 0;

    public bool open = false;
    public Animator anim;
    public Slider SpeedController;
    public Toggle auto;

    public bool isClapping = false;

    public List<AudioSource> btn_sound;
    void Start()
    {
        for (int i = 0; i < 4; i++)
            boolOfActions[i] = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(anim.enabled)
            anim.speed = SpeedController.value;

        if (open)
        {
            auto.interactable = false;
        }
        else
        {
            auto.interactable = true;
        }

        GameManager.instance.isClapping = isClapping;
    }

    public void OpenTab()
    {
        isClapping = false;
        if (!anim.enabled)
            return;
        if (!open)
        {
            anim.SetTrigger("Open");
            open = true;
        }
        else if (open)
        {
            anim.SetTrigger("Close");
            open = false;

        }

        btn_sound[0].Play();
    }

    public void PlayAction(int actionId)
    {
        Actions act = (Actions)actionId;

        anim.SetTrigger(act.ToString());
        btn_sound[1].Play();

        if(actionId == 3)
        {
            isClapping = true;
            GameManager.instance.perOfClapping++;
        }

        open = !open;

        PersonalScore += 5;
    }

    public void AutoOn(bool on)
    {
        anim.enabled = on;
    }
}
