using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class OnButtonSetTrigger : MonoBehaviour
{
    [TooltipAttribute("The method name to call with SendMessage. The message is sent to all script components attached to the colliding Game Object (e.g. the player).")]
    [SerializeField] private string messageOther = null;                // The method name to call with SendMessage. The message is sent to all script components attached to the colliding Game Object (e.g. the player).
    [TooltipAttribute("The method name to call with SendMessage. The message is sent to all script components attached to me (the trigger) on enter.")]
    [SerializeField] private string messageSelf = null;				// The method name to call with SendMessage. The message is sent to all script components attached to me (the trigger) on enter.
    [TooltipAttribute("The method name to call with BroadcastMessage. The message is sent to all script components and children attached to me (the trigger) on enter.")]
    [SerializeField] private string messageBroadcast = null;            // The method name to call with BroadcastMessage. The message is sent to all script components and children attached to me (the trigger) on enter.
    [TooltipAttribute("The Game Object to call SendMessage on. The message is sent to all script components attached to target on enter.")]
    [SerializeField] private GameObject messageTarget = null;           // The Game Object to call SendMessage on. The message is sent to all script components attached to target on enter.
    [TooltipAttribute("The method name to call with SendMessage. The message is sent to all script componenets attached to target (messageTarget) on enter.")]
    [SerializeField] private string messageTargetMessage = null;        // The method name to call with SendMessage. The message is sent to all script componenets attached to target (messageTarget) on enter.
    [TooltipAttribute("The tag to filter collisions.")]
    [SerializeField] private string filterTag = null;					// The tag to filter collisions.

    public GameObject playerGameObject;
    bool m_slime = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Read the jump input in Update so button presses aren't missed.
        m_slime = CrossPlatformInputManager.GetButtonDown("Jump");
        if (m_slime == true) { 
            Debug.Log ("slimed");
            ProcessMessage();
        }
    }


    private void ProcessMessage()
    {
        // send messages as requested:
        if (messageOther != "") playerGameObject.SendMessage(messageOther);            // send a message to all scripts attached to other (the player / thing doing the colliding),
        if (messageSelf != "") SendMessage(messageSelf);                // send a message to all scripts attached to me (the trigger),
        if (messageBroadcast != "") BroadcastMessage(messageBroadcast); // send a message to all scripts attached to me and any children,
        if (messageTarget != null && messageTargetMessage != "") messageTarget.SendMessage(messageTargetMessage); // send a message to a particular game object.
    }
}
