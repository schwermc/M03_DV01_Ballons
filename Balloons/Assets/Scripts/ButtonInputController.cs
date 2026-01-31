using UnityEngine;
using UnityEngine.Events;

public class ButtonInputController : MonoBehaviour
{
    public UnityEvent ButtonDownEvent = new UnityEvent();
    public UnityEvent ButtonUpEvent = new UnityEvent();

    void Update()
    {
        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            ButtonDownEvent.Invoke();
        }
        else if (Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            Debug.Log("Button Up");
            ButtonUpEvent.Invoke();
        }
    }
}
