using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleObjectCheck : StateMachineBehaviour
{

    RifleAnimationObject rifle;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (rifle == null)
        {
            rifle = animator.GetComponentInChildren<RifleAnimationObject>();
        }
        if (!rifle.gameObject.activeInHierarchy)
        {
            rifle.gameObject.SetActive(true);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (rifle == null)
        {
            rifle = animator.GetComponentInChildren<RifleAnimationObject>();
        }
        if (rifle.gameObject.activeInHierarchy)
        {
            rifle.gameObject.SetActive(false);
        }
    }
}
