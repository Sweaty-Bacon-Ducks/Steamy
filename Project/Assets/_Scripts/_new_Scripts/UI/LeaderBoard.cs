using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    List<PlayerStats> PlayersStats;
    public GameObject PlayerScore;

    // Start is called before the first frame update
    void Start()
    {
        PlayersStats = new List<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {

        }
    }

    void UpdateLeaderBoard()
    {
        //foreach (GameObject playerStats in PlayersStats)
        //{

        //}
    }

    public void AddPlayer(string name)
    {
        PlayerScore = Instantiate(PlayerScore, transform);
        PlayerScore.GetComponent<PlayerStats>().NameText.SetText(name);
        PlayersStats.Add(PlayerScore.GetComponent<PlayerStats>());
    }
}
