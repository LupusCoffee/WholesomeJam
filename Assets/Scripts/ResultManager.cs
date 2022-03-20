using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    float time;
    public GameObject timer;
    public GameObject winPanel;
    public GameObject losePanel;
    
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    private void Update()
    {
        time = Timer.time;

        if (enemy1 == null && enemy2 == null && enemy3 == null)
        {
            timer.SetActive(false);
            winPanel.SetActive(true);
        }

        if (player == null)
        {
            timer.SetActive(false);
            losePanel.SetActive(true);
        }

        if(time <= 0)
        {
            timer.SetActive(false);
            if (enemy1 == null)
            {
                if (PlayerMovement.groupSize <= enemy2.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count
                        || PlayerMovement.groupSize <= enemy3.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy2 == null)
            {
                if (PlayerMovement.groupSize <= enemy1.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count
                        || PlayerMovement.groupSize <= enemy3.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy3 == null)
            {
                if (PlayerMovement.groupSize <= enemy2.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count
                        || PlayerMovement.groupSize <= enemy1.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy1 == null && enemy2 == null)
            {
                if (PlayerMovement.groupSize <= enemy3.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy1 == null && enemy3 == null)
            {
                if (PlayerMovement.groupSize <= enemy2.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy2 == null && enemy3 == null)
            {
                if (PlayerMovement.groupSize <= enemy1.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
            if (enemy1 != null && enemy2 != null && enemy3 != null)
            {
                if (PlayerMovement.groupSize <= enemy1.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count
                         || PlayerMovement.groupSize <= enemy2.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count
                         || PlayerMovement.groupSize <= enemy3.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count)
                {
                    losePanel.SetActive(true);
                }
                else
                {
                    winPanel.SetActive(true);
                }
            }
        }
    }
}
