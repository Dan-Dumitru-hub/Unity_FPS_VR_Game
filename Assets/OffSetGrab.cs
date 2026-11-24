using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffSetGrab : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
#pragma warning disable CS0618 // Type or member is obsolete
        StoreInteractor(args.interactor);
        MatchAttachmentPoints(args.interactor);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.position;
        interactorRotation = interactor.attachTransform.rotation;
    }
    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
#pragma warning disable CS0618 // Type or member is obsolete
        ResetAttachmentPoint(args.interactor);
        ClearInteractor(args.interactor);
#pragma warning restore CS0618 // Type or member is obsolete
    }
    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.position = interactorPosition;
        interactor.attachTransform.rotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
