using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour
{
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;


    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject pickup;
    private bool pickedUp;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (controller.GetPressUp(gripButton) && pickup != null)
        {
            if (!pickedUp)
            {
                pickup.transform.parent = this.transform;
                pickup.transform.position = this.transform.position;
                pickup.transform.rotation = this.transform.rotation;
                pickup.transform.Translate(new Vector3(0, 0, 1));
                pickup.transform.Rotate(new Vector3(90, 0, 0));
                


                pickedUp = true;
            }
            else
            {
                pickup.transform.parent = null;
                pickedUp = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("enter");
        pickup = collider.gameObject;
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("exit");
        pickup = null;
    }
}