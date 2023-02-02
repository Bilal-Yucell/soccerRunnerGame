using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator ballAnimator;
    public Animator playerAnimator;
    public Animator transitionAnimator;
    CharacterController cc;
    bool canmove = true;
    Vector3 movec = Vector3.zero;
    int line = 1;
    int targetLine = 1;

    public int Can = 3;
    public GameObject AudioManager;


    public float forwardForce = 10f;
    public float sidewayForce = 4f;

    public float jumpForce = 10f;
    private float gravity = -20f;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (!line.Equals(targetLine))
        {
            //ortadan sola geçmek 0 < -2 
            if (targetLine == 0 && pos.x < -2.5)
            {
                gameObject.transform.position = new Vector3(-2.5f, pos.y, pos.z);
                line = targetLine;
                canmove = true;
                movec.x = 0;
            }

            //soldan ortaya ya da sağdan ortaya geçmek
            else if (targetLine == 1 && (pos.x > 0 || pos.x < 0))
            {
                if (line == 0 && pos.x > 0)
                {

                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    canmove = true;
                    movec.x = 0;
                }
                else if (line == 2 && pos.x < 0)
                {

                    gameObject.transform.position = new Vector3(-2.5f, pos.y, pos.z);
                    line = targetLine;
                    canmove = true;
                    movec.x = 0;
                }
            }

            //ortadan sağa geçmek için
            else if (targetLine == 2 && pos.x > 2.5)
            {
                gameObject.transform.position = new Vector3(2.5f, pos.y, pos.z);
                line = targetLine;
                canmove = true;
                movec.x = 0;
            }
        }

        CheckInputs();

        if (cc.isGrounded)
        {
            //movec.y = -1;
            playerAnimator.SetBool("isJump", false);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {

                Jump();
                canmove = true;
            }
        }
        else
        {
            movec.y += gravity * Time.deltaTime;
        }


        movec.z = forwardForce + forwardForce * Time.time * 0.05f;


        cc.Move(movec * Time.deltaTime);
    }

    void CheckInputs()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && canmove && line > 0)
        {
            targetLine--;
            canmove = false;
            movec.x = -sidewayForce;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && canmove && line < 2)
        {
            targetLine++;
            canmove = false;
            movec.x = sidewayForce;
        }
    }

    private void Jump()
    {
        canmove = false;
        movec.y = jumpForce;
        playerAnimator.SetBool("isJump", true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
        {
            Can -= 1;
            if (Can == 0)
            {
                Debug.Log("Öldün");
                cc.enabled = false;
                playerAnimator.enabled = false;
                AudioManager.SetActive(false);
                ballAnimator.enabled = false;
                transitionAnimator.SetTrigger("GoToMenu");
            }

            Destroy(hit.gameObject);
        }
    }
}