using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookScript : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappable;
    public LayerMask groundLayer;
    public GameObject gunTip;
    private GameObject vrRig;
    private float maxDistance = 40f;
    private SpringJoint joint;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        vrRig = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        DrawRope();

        if (vrRig.GetComponents<SpringJoint>().Length == 0 && vrRig.GetComponent<Rigidbody>())
        {
            if (Grounded())
            {
                // Vector3 velocity = vrRig.GetComponent<Rigidbody>().velocity;
                Destroy(vrRig.GetComponent<Rigidbody>());
                Destroy(vrRig.GetComponent<SphereCollider>());
                vrRig.GetComponent<CharacterController>().enabled = true;
                // vrRig.GetComponent<ContinuousMovement>().enabled = true;
                // vrRig.GetComponent<PlayerMovement>().enabled = true;
                // vrRig.GetComponent<CharacterController>().Move(velocity * Time.fixedDeltaTime);
            }
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    public void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.transform.position,gunTip.transform.forward, out hit, maxDistance, whatIsGrappable))
        {
            
            //  Debug.DrawRay(gunTip.transform.position, gunTip.transform.forward * 100, Color.red, 100);
            grapplePoint = hit.point;
            joint = vrRig.AddComponent<SpringJoint>();
            if (!vrRig.GetComponent<SphereCollider>())
            {
                vrRig.AddComponent<SphereCollider>();
            }
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            // Rigid Body fixes
            vrRig.GetComponent<CharacterController>().enabled = false;
            // vrRig.GetComponent<ContinuousMovement>().enabled = false;
            // vrRig.GetComponent<PlayerMovement>().enabled = false;
            vrRig.GetComponent<Rigidbody>().freezeRotation = true;
            // vrRig.GetComponent<Rigidbody>().useGravity = false;
            vrRig.GetComponent<Rigidbody>().isKinematic = false;

            float distanceFromPoint = Vector3.Distance(vrRig.transform.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.5f;

            // Variables to fit individual needs
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;
        if (lr.positionCount != 2) return;
        lr.SetPosition(0, gunTip.transform.position);
        lr.SetPosition(1, grapplePoint);
    }

    bool Grounded()
    {
        // Debug.DrawRay(vrRig.transform.position, Vector3.down, Color.blue, 2);
        return Physics.Raycast(vrRig.transform.position, Vector3.down, 0.5f, groundLayer);
    }

    public void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
}
