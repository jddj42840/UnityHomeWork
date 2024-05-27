using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class NPCs_Load : MonoBehaviour
{
    // Start is called before the first frame update
    public static int NPC_Count = 0;
    public static int max_NPC_Count = 5;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float number = Random.Range(0, 100f);
        if (number > 99 && NPC_Count <= max_NPC_Count)
        {
            NPC_Count += 1;
            GameObject NPC = Instantiate(Resources.Load("NPC1", typeof(GameObject))) as GameObject;
            NPC.transform.position = NPC.transform.position + new Vector3(Random.Range(-5f, -5f), 0, Random.Range(-5f, -5f));
        }

    }
}

