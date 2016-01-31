using UnityEngine;
using System.Collections;

public class PalmDetectorScript : MonoBehaviour
{
    public int _whichHand = 0;

    private Transform _prevGrabbedParent = null;
    private Transform _grabbedObj = null;
    private bool _grabbing = false;
    private SixenseInput.Controller _handController = null;

    void Start()
    {
    }

    void Update()
    {
        var grabbing = false;
        if (SixenseInput.Controllers[_whichHand].GetButton(SixenseButtons.TRIGGER))
            grabbing = true;

        if (grabbing == false && grabbing != _grabbing && _grabbedObj != null)
        {
            //_grabbedObj.parent = _prevGrabbedParent;
            _grabbedObj = null;
            _prevGrabbedParent = null;

            var joint = GetComponent<FixedJoint>();
            Destroy(joint);
        }
            _grabbing = grabbing;
    }

    void OnCollisionEnter(Collision collision)
    {
        //TODO: SAM HERE; add audio or force or trigger aniamations or do anything cool
        Debug.Log("Palm " + this.name + " collided with " + collision.gameObject.name + "!");
        
        //if (_grabbing && collision.gameObject.tag == Tags.Grabbable)
        //{
        //    _grabbedObj = collision.transform;
        //    _prevGrabbedParent = _grabbedObj.parent;
        //    _grabbedObj.parent = transform;
        //}
    }

    void OnCollisionStay(Collision collision)
    {
        if (_grabbing && _grabbedObj == null &&  collision.gameObject.tag == Tags.Grabbable)
        {
            _grabbedObj = collision.transform;
            var joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
}