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
    private Animator anim;
    public Slider SpeedController;

    public List<AudioSource> btn_sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        for (int i = 0; i < 4; i++)
            boolOfActions[i] = false;

    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = SpeedController.value;
    }

    public void OpenTab()
    {
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

        open = !open;

        PersonalScore += 5;
    }
}
