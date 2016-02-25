using UnityEngine;
using System.Collections;

public class TwitchPlayer : MonoBehaviour {

    public enum TwitchPlayerStates {Idle,FollowTarget,GoToLocation };
    public TwitchPlayerStates playerState = TwitchPlayerStates.FollowTarget;

    string username;
    public TextMesh userNameTxtMesh;
    public TextMesh userMessageTxtMesh;

    public GameObject ChatBubbleGO;

    GameObject target;
    Rigidbody rigidbody;

    float lastMessageReceivedCounter = 0;
    GameObject gotoLocationObject = null;

    NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        navAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        lastMessageReceivedCounter += Time.deltaTime;
        if(lastMessageReceivedCounter > 5)
        {
            userMessageTxtMesh.text = "";
        }

        switch (playerState)
        {
            case TwitchPlayerStates.Idle: IdleUpdate(); break;
            case TwitchPlayerStates.FollowTarget: FollowTargetUpdate(); break;
            case TwitchPlayerStates.GoToLocation: GoToLocationUpdate(); break;
        }
    }

    void switchState(TwitchPlayerStates newState)
    {
        switch (playerState)
        {
            case TwitchPlayerStates.Idle: IdleExit(); break;
            case TwitchPlayerStates.FollowTarget: FollowTargetExit(); break;
            case TwitchPlayerStates.GoToLocation: GoToLocationExit(); break;
        }
        playerState = newState;

        switch (playerState)
        {
            case TwitchPlayerStates.Idle: IdleEnter(); break;
            case TwitchPlayerStates.FollowTarget: FollowTargetEnter(); break;
            case TwitchPlayerStates.GoToLocation: GoToLocationEnter(); break;
        }
    }

    void IdleEnter() { }
    void IdleUpdate() { }
    void IdleExit() { }

    void FollowTargetEnter() {
        rigidbody.isKinematic = false;
    }
    void FollowTargetUpdate() {

        Vector3 heading = target.gameObject.transform.position - gameObject.transform.position;
        float distance = heading.magnitude;

        if (distance > 5)
        {
            Vector3 direction = heading / distance;
            rigidbody.velocity = direction * 10;
        }
        else if (distance < 4)
        {
            Vector3 direction = heading / distance;
            rigidbody.velocity = -direction * 10;
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity / 2;
        }
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
    }
    void FollowTargetExit() {
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
    }

    void GoToLocationEnter() {
        NavMeshPath path = new NavMeshPath();
        Debug.Log(gotoLocationObject.transform.position);
        navAgent.CalculatePath(gotoLocationObject.transform.position, path);
        navAgent.SetPath(path);
        navAgent.Resume();
    }
    void GoToLocationUpdate() {

    }
    void GoToLocationExit() {
        navAgent.Stop();
        Debug.Log("stopped path");
    }

    public void displayChatMessage(string msg)
    {
        char firstRealCharacter = ' ';
        int i = 0;
        while (firstRealCharacter == ' ')
        {
            firstRealCharacter = msg[i];
            i++;
        }

        if(firstRealCharacter == '!')
        {
            checkCommands(msg);
        }
        else
        {
            userMessageTxtMesh.text = msg;
            lastMessageReceivedCounter = 0;
        }
    } 

    void checkCommands(string command)
    {
        string[] splitCommand = command.Split();

        switch (splitCommand[0])
        {
            case "!goto": startNavigationTo(splitCommand[1]); break;
            case "!move": startNavigationTo(splitCommand[1]); break;
            case "!rally": switchState(TwitchPlayerStates.FollowTarget); break;
        }
    }

    public void startNavigationTo(string location)
    {
        if(location == "player")
        {
            switchState(TwitchPlayerStates.FollowTarget);
            return;
        }
        GameObject foundObject = GameObject.Find(location);
        if (foundObject != null)
        {
            gotoLocationObject = foundObject;
            switchState(TwitchPlayerStates.GoToLocation);
        }
    }

    public void setUserName(string name)
    {
        userNameTxtMesh.text = name;
        username = name;
    }
    public string getUserName()
    {
        return username;
    }
    public void setTarget(GameObject _target)
    {
        target = _target;
    }
}
