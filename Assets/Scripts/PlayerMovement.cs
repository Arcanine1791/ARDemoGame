using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent nvAgent;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                nvAgent.destination = hit.point;
            }
        }

        scoreText.text = "Coins:  "+score.ToString();

        if(activequestion)
        {
            question.SetActive(true);
            
            activequestion = false;
        }

        if(score==50)
        {
            activequestion = true;
        }
    }


    public Text scoreText,gamewin;
    public int score;
    public bool activequestion;

    public GameObject girl, question;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="coins")
        {
            score += 10;
           
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "question")
        {
            girl.SetActive(true);

        }

        if (other.gameObject.tag == "girl")
        {
            gamewin.text = " You have rescued the Girl";

        }
    }
}
