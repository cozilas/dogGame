using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    [SerializeField] float forwardSpeed;
    [SerializeField] float maxSpeed;

    private int desiredLane = 1;//0:left 1:middle 2:right
    [SerializeField] float laneDistance = 4; // distance between 2 lanes

    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    private Animator animator;
    private Animator leftEar;
    private Animator rightEar;
    private bool hasJumped = false;
    private bool hasSlided = false;
    private bool goingDown = false;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;
    public static bool hasRedBone, hasGreenBone, hasBlueBone = false;

    void Start()
    {
        AudioManager.instance.Play("dogPanting");
        controller = GetComponent<CharacterController>();
        animator = GameObject.Find("dogModelFinished").GetComponent<Animator>();
        leftEar = GameObject.Find("Bone001Left").GetComponent<Animator>();
        rightEar = GameObject.Find("Bone001Right").GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetButtonDown("s") || IsDoubleTap())
        {
            animator.Play("spin");
        }
     
        if (!PlayerManager.isGameStarted) return;

        if(forwardSpeed < maxSpeed){
            forwardSpeed+=0.1f * Time.deltaTime;
        }

        direction.z = forwardSpeed;

        if(controller.isGrounded){
            direction.y=-1;
           
            if (hasJumped)
            {
                hasJumped = false;
                animator.Play("hasLandedFromJump");
            }
            if(SwipeManager.swipeUp){
                Jump();
            }
        }else{
            direction.y += gravity*Time.deltaTime;
        }

        if(SwipeManager.swipeRight){
            desiredLane++;
            animator.Play("turnRight");
            if (desiredLane == 3)
            {             
                desiredLane = 2;
            }
        }

        if(SwipeManager.swipeLeft){
            desiredLane--;
            animator.Play("turnLeft");
            if (desiredLane == -1) desiredLane = 0;
        }
        if (SwipeManager.swipeDown)
        {
            goingDown = true;
            hasSlided = true;
            StartCoroutine(makeCharacterControllerSmaller(1));

            animator.Play("dolphinDive");
            leftEar.Play("leftEarDolphinDiveAnim");
            rightEar.Play("rightEarDolphinDiveAnim");
        }
        if (hasSlided)
        {
            if (goingDown)
            {
                gameObject.GetComponent<CharacterController>().height += -2 * Time.deltaTime;
                gameObject.GetComponent<CharacterController>().radius += -1* Time.deltaTime;
                //   gameObject.GetComponent<CharacterController>().radius = 0.3f;
            }
            else {
                gameObject.GetComponent<CharacterController>().height += 2 * Time.deltaTime;
                gameObject.GetComponent<CharacterController>().radius += 1 * Time.deltaTime;
            }
            if (gameObject.GetComponent<CharacterController>().height == 0.5) { goingDown = false; }
        }


            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y* transform.up;
        if(desiredLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2){
            targetPosition +=Vector3.right * laneDistance;
        }
       
        if(transform.position == targetPosition) return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 10 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude){
            controller.Move(moveDir);
        }else{
            controller.Move(diff);
        }
    }

    private void FixedUpdate() {
        if(!PlayerManager.isGameStarted) return;
        controller.Move(direction * Time.fixedDeltaTime);

    }

    private void Jump(){
        direction.y = jumpForce;
        animator.Play("jumpedUp");
        hasJumped = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.tag == "Obstacle") {
            if (hasRedBone)
            {
                AudioManager.instance.Play("breakObsticle");
                hit.collider.enabled = false;
                
            }
            else
            {
                PlayerManager.gameOver = true;

                AudioManager.instance.Play("GameOver");
            }
        }
    }
    public bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
    IEnumerator makeCharacterControllerSmaller(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        goingDown = false;
        yield return new WaitForSeconds(waitTime);
        hasSlided = false;
           gameObject.GetComponent<CharacterController>().height = 2;
            gameObject.GetComponent<CharacterController>().radius = 0.5f;
    }
}




