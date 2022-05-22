using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class RobotController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject Head,Body,RightUpperArm,RightLowerArm,LeftUpperArm,LeftLowerArm;

    public Quaternion ru,rl,lu,ll;
    public void init(){
        
    }
    public float motionscale=0f;
    public Quaternion EulerVariation(PosJson j,Quaternion k){
        Quaternion q=Quaternion.Euler(j.x*motionscale+k.x,j.y*motionscale+k.y,j.z*motionscale+k.z);
        
        return q;

    }


    public void UpdatePose(PoseJson pose){
        
        Head.transform.localRotation=Quaternion.Euler(pose.Head.x*0.7f*motionscale,pose.Head.y*0.7f*motionscale,pose.Head.z*0.7f*motionscale);
        Body.transform.localRotation=Quaternion.Euler(pose.Spine.x*0.0f*motionscale,pose.Spine.y*0.3f*motionscale,pose.Spine.z*0.0f*motionscale);
        RightUpperArm.transform.localRotation=EulerVariation(pose.RightUpperArm,ru);
        RightLowerArm.transform.localRotation=EulerVariation(pose.RightLowerArm,rl);
        
        LeftUpperArm.transform.localRotation=EulerVariation(pose.LeftUpperArm,lu);
        LeftLowerArm.transform.localRotation=EulerVariation(pose.LeftLowerArm,ll);
        


    }

}
