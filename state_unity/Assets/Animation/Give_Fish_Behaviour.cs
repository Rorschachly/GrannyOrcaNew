using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Give_Fish_Behaviour : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Granny_Behavior>().roundfish.SetActive(true);
        animator.gameObject.GetComponent<Granny_Behavior>().salmon.SetActive(true);
        animator.gameObject.GetComponent<Granny_Behavior>().firstRoundFishMove = true;
        animator.gameObject.GetComponent<Granny_Behavior>().startFirstRoundMouthTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int fishHash = Animator.StringToHash("give_fish");
        animator.ResetTrigger(fishHash);
        
        //animator.gameObject.GetComponent<Granny_Behavior>().StartCoroutine("GrannyEatFish");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
