using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class OnButtonSetTrigger : MonoBehaviour
{
    [TooltipAttribute("The method name to call with SendMessage. The message is sent to all script components attached to me (the trigger) on enter.")]
    [SerializeField] private string messageSelf1 = null;				// The method name to call with SendMessage. The message is sent to all script components attached to me (the trigger) on enter.
    [SerializeField] private string messageSelf2 = null;

    bool m_slime = false;
    private bool slimed = false;
    // Start is called before the first frame update
    void Start()
    {
	Debug.Log(slimed);
    }

    // Update is called once per frame
    void Update()
    {
        // Read the input in Update so button presses aren't missed.
        m_slime = CrossPlatformInputManager.GetButtonDown("Fire2");
            if (m_slime == true) { 
                Debug.Log (slimed);
                ProcessMessage();
		slimed = !slimed;
        }
    }


    private void ProcessMessage()
    {
        // send messages as requested:
        if ((messageSelf1 != "") && (slimed == false)) SendMessage(messageSelf1);                // send a message to all scripts attached to me (the trigger),
	if ((messageSelf2 != "") && (slimed == true)) SendMessage(messageSelf2);
    }
}