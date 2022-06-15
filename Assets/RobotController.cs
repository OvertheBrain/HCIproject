using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    public Color col1,col2;
    public GameObject[] c1_group,c2_group;
    // Start is called before the first frame update
    public GameObject Head,Body,RightUpperArm,RightLowerArm,LeftUpperArm,LeftLowerArm;
    public GameObject emotion,glowstick_L,glowstick_R;

    Quaternion ru,rl,lu,ll,hd;

    float jumpingLerp=2,y0;
    public float jumpHeight,moveSpeed;

    public int PersonalScore = 0;
    public PersonalGameController scorer1;
    public JumpGameController scorer2;
    public ActionController score3;

    AudioSource au;
    public AudioClip[] cheer;

    public Text ScoreBoard;

    //public bool isJumping = false;
    //public bool ground = true;
    //private float mJumpSpeed = 100f;


    void Start(){
        foreach(GameObject x in c1_group){
            x.GetComponent<MeshRenderer>().materials[0].SetColor("_Color",adjuster.color1);
        }
        foreach(GameObject x in c2_group){
            x.GetComponent<MeshRenderer>().materials[0].SetColor("_Color",adjuster.color2);
        }
        ru=RightUpperArm.transform.localRotation;
        rl=RightLowerArm.transform.localRotation;
        lu=LeftUpperArm.transform.localRotation;
        ll=LeftLowerArm.transform.localRotation;
        hd=Head.transform.localRotation;
        y0=transform.localPosition.y;

        au=GetComponent<AudioSource>();

        score3 = GetComponent<ActionController>();
    }
    public float motionscale=0f;
    public Quaternion EulerVariation(PosJson j,Quaternion k){
        Quaternion q=k*Quaternion.Euler(j.x*motionscale,j.y*motionscale,j.z*motionscale);
        //Quaternion q = Quaternion.Euler(j.x * motionscale + k.x, j.y * motionscale + k.y, j.z * motionscale + k.z);

        return q;

    }


    public void UpdatePose(PoseJson pose){
        
       
       // Body.transform.localRotation=Quaternion.Euler(pose.Spine.x*0.0f*motionscale,pose.Spine.y*0.3f*motionscale,pose.Spine.z*0.0f*motionscale);
        RightUpperArm.transform.localRotation=EulerVariation(pose.RightUpperArm,ru);
        RightLowerArm.transform.localRotation=EulerVariation(pose.RightLowerArm,rl);
        
        LeftUpperArm.transform.localRotation=EulerVariation(pose.LeftUpperArm,lu);
        LeftLowerArm.transform.localRotation=EulerVariation(pose.LeftLowerArm,ll);
         Head.transform.localRotation=hd*Quaternion.Euler(pose.Head.x*0.7f*motionscale,pose.Head.y*0.7f*motionscale,pose.Head.z*0.7f*motionscale);
        
        
        if(pose.MouthShape.A>=1){
            Debug.Log(pose.MouthShape.A);
            if(!au.isPlaying)
            au.PlayOneShot(cheer[Random.Range(0,3)]);
        }
    }

    

    void Update(){

        if(Input.GetKeyDown(KeyCode.L)){
            glowstick_L.GetComponent<glowStickController>().SwitchColor();
            glowstick_R.GetComponent<glowStickController>().SwitchColor();
        }
        if(Input.GetKeyDown(KeyCode.O)){
            emotion.GetComponent<emotionContoller>().Launch(0);
        }
        if(Input.GetKeyDown(KeyCode.P)){
            emotion.GetComponent<emotionContoller>().Launch(1);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        updateMovement();

        PersonalScore = scorer1.PersonalScore + scorer2.PersonalScore + score3.PersonalScore;
        ScoreBoard.text = PersonalScore.ToString();
    }

    

    void updateMovement(){
        //移动
        float theta=transform.localEulerAngles.y/180 *Mathf.PI;
      

        transform.localPosition+=new Vector3(-Mathf.Sin(theta),0,-Mathf.Cos(theta))*moveSpeed*Input.GetAxis("Vertical");
        float h=y0;
        if(jumpingLerp<2){
            jumpingLerp+=Time.deltaTime;
            h=y0+(1-(jumpingLerp-1)*(jumpingLerp-1))*jumpHeight;
        }
        transform.localPosition=new Vector3(transform.localPosition.x,h,transform.localPosition.z);

        

    }

    //外部可以直接调用Jump
    public void Jump(){
        if(jumpingLerp>=2)
        jumpingLerp=0;
    }


    // private void FixedUpdate()
    // {
    //     //跳跃
    //     if (isJumping)
    //     {
    //         if (ground == true)
    //         {
    //             //transform.Translate(new Vector3(Input.GetAxis("Horizontal")*distance, 2, Input.GetAxis("Vertical")*distance));
    //             GetComponent<Rigidbody>().velocity += new Vector3(0, 5, 0);
    //             GetComponent<Rigidbody>().AddForce(Vector3.up * mJumpSpeed, ForceMode.Impulse);
    //             ground = false;
    //             Debug.Log("I am jumping");
    //             //isJumping = false;
    //         }
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.collider.CompareTag("Ground"))
    //     {
    //         ground = true;
    //     }
    // }

}
