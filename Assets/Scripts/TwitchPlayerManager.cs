using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwitchPlayerManager : MonoBehaviour {

    Dictionary<string, TwitchPlayer> twitchPlayers = new Dictionary<string, TwitchPlayer>();
    GameObject Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void chatReceived(string user, string msg)
    {
        if (twitchPlayers.ContainsKey(user))
        {
            TwitchPlayer twitchPlayer = twitchPlayers[user];
            twitchPlayer.displayChatMessage(msg);
        }
        else
        {
            GameObject instance = Instantiate(Resources.Load("TwitchPlayer", typeof(GameObject))) as GameObject;
            instance.transform.position = new Vector3(0, 1, 0);
            TwitchPlayer twitchPlayer = instance.GetComponent<TwitchPlayer>();
            twitchPlayer.setUserName(user);
            twitchPlayer.displayChatMessage(msg);
            
            if(twitchPlayers.Count < 2)
            {
                twitchPlayer.setTarget(Player);
            }
            else
            {
                TwitchPlayer[] twitchPlayersArray = new TwitchPlayer[twitchPlayers.Count];
                twitchPlayers.Values.CopyTo(twitchPlayersArray, 0);

                GameObject target = twitchPlayersArray[Random.Range(0, twitchPlayersArray.Length - 1)].gameObject;
                twitchPlayer.setTarget(target);
                Debug.Log("target set to: " + twitchPlayer.getUserName());
            }
            
            twitchPlayers.Add(user, twitchPlayer);
        }
    }
}
