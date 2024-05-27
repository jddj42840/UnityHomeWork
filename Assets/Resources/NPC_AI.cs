using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC_AI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public GameObject TargetObj;
    public Animator NPC01_ani;
    public int DetectDistance = 10;
    public float AttkDistance = .9f;
    static public bool NPC_isAttacking = false;
    public Image NPC_HpImage;
    public float NPC_HP = 100.0f;
    public static float player_hurt = 20f;

    void Start()
    {

        npcNavi = GetComponent<NavMeshAgent>();
        NPC01_ani = GetComponent<Animator>();
        TargetObj = GameObject.Find("player");
        
    }
    // Update is called once per frame
    void Update()
    {

        NPC_HpImage.fillAmount = NPC_HP * 0.01f;


        float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        
        float NPC_Speed = npcNavi.velocity.magnitude;   // ���oNPC���t��. 


        if (dist < DetectDistance) // ����NPC�M���a�������Z��, �p�b�ҳ]�w���Z����, �}�l�l��
        {
            npcNavi.destination = TargetObj.transform.position;
            NPC01_ani.SetFloat("Blend", 1);
        }
        else // �S������, �h�l�ܦۤv �Τ]�i�H�令�^��NPC�������m. 
        {
            npcNavi.destination = transform.position;
            NPC01_ani.SetFloat("Blend", 0);
        }
        if (dist < AttkDistance)
        {
            NPC01_ani.SetBool("NPC_ATK", true);
            NPC_isAttacking = true;
        }
        else
        {
            NPC01_ani.SetBool("NPC_ATK", false);
            NPC_isAttacking = false;

        }

        if(NPC_HP <= 0)
        {
            NPC01_ani.SetBool("NPC_Dying", true);
            Destroy(gameObject, 1);

        }

        //NPC_isAttacking = NPC01_ani.GetFloat("NPC_attack_time") > 0.01 ? true: false;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            Debug.Log("NPC_GET_ATT");
            NPC_HP -= player_hurt;
            Debug.Log(NPC_HP);

        }

    }



    //NavMeshAgent NPCNav;
    //public GameObject TargetObj;
    //void Start()
    //{
    //    NPCNav = GetComponent<NavMeshAgent>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    NPCNav.destination = TargetObj.transform.position;
    //}
}
