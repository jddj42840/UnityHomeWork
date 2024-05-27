using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class playerC : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public float jumpForce = 5f;
    public float mtfk;
    public static bool player_isatk = false;
  //  private bool isJumping = false;
  //  private bool groundedPlayer = false;
    private Rigidbody rb;
    private float moveInput;
    public Animator anim;
    public GameObject knife;
    public float gravity = 9.8f;
    private Vector3 moveDirection;
    public Image playerHpImage;
    public float playerHP = 100.0f;
    public int NPC_HurtNum = 10;

    public GameObject PlayerHpBar;
    public GameObject CameraObj;
    public GameObject bullet;
    public Transform FirePoint;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        PlayerHpBar = GameObject.Find("player");
        PlayerHpBar = GameObject.Find("Main Camera");

    }
    private void Update()
    {

        if (controller.isGrounded)
        {
            PlayerHpBar.transform.LookAt(CameraObj.transform.position);
            float tunX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            playerHpImage.fillAmount = playerHP * 0.01f;

            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 6 : 2; //當按下左Shift鍵時，verticalInput的值為3，否則為1  
            //Debug.Log(moveSpeed);
            //Debug.Log(Mathf.Abs(moveZ * moveSpeed));
            anim.SetFloat("Blend", Mathf.Abs(moveZ * moveSpeed));
            // 計算移動方向
           // moveDirection = new Vector3(0f, 0f, moveZ);
            moveDirection = transform.TransformDirection(new Vector3(0f, 0f, moveZ)* moveSpeed);
            //moveDirection *= moveSpeed;
            //處理角色轉向
            transform.Rotate(Vector3.up * tunX * turnSpeed * Time.deltaTime); // 
                                                                              // Move forward and backward
            moveInput = Input.GetAxis("Vertical");
            // 處理重力

            if (playerHP <= 0)
            {
                anim.SetBool("player_die", true);

            }


            //if (Input.GetKey(KeyCode.LeftShift)&& Input.GetAxisRaw("Vertical")!=0 )
            //{
            //    transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime * 2f);
            //    anim.SetFloat("Blend", 2);
            //}
            //else
            //{
            //    transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
            //    anim.SetFloat("Blend", moveInput);
            //}

            //// Turn left and right
            //float turnInput = Input.GetAxis("Horizontal");

            // transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);


            // Jump
            if (Input.GetButton("Jump"))
            {
                // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetTrigger("player_jump");
                moveDirection.y = jumpForce;

                // anim.SetTrigger("player_jp");
            }

           
        }
            moveDirection.y -= gravity * Time.deltaTime;
            // 移動角色
            controller.Move(moveDirection * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Player_attack", true);
            player_isatk = true;
        }
        else
        {
            anim.SetBool("Player_attack", false);
            player_isatk = false;

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            print(FirePoint.rotation);
            Vector3 ky=new Vector3(FirePoint.position.x,FirePoint.position.y,FirePoint.position.z+1);
            Instantiate(bullet, ky, FirePoint.rotation);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Reset jump state when touching the ground
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isJumping = false;
        //}
    }
    void playerAttack()
    {
       
        StartCoroutine("attack");

    }
    IEnumerator attack()
    {
        
        yield return new WaitForSeconds(2f);
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     print("OnTriggerEnter");
    //     if(other.CompareTag("COIN"))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
    //取武器碰撞偵測的function 
    private void OnTriggerEnter(Collider other)
    {
        //print("OnTriggerEnter"); //當物件進入觸發區時，印出OnTriggerEnter
        // if (other.CompareTag("weapon"))
        // {
        //    // playerPickWeapon = true;
        //     sword.SetActive(true); 
        //     Destroy(other.gameObject); // 刪除進入觸發區的物件
        // }
        if(other.CompareTag("COIN"))
        {
            // playerPickWeapon = true;
            knife.SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "NPC01" && NPC_AI.NPC_isAttacking)
        {
            //Debug.Log("ATT");

            playerHP -= NPC_HurtNum;
            //Debug.Log(playerHP);
        }

    }
}