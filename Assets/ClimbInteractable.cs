using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    [System.Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    protected override void OnSelectEntered(SelectEnterEventArgs args)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        base.OnSelectEntered(args);

        if (args.interactor is XRDirectInteractor)
            Climber.climbingHand = args.interactor.GetComponent<XRController>();
    }

    [System.Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    protected override void OnSelectExited(SelectExitEventArgs args)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        base.OnSelectExited(args);

        if (args.interactor is XRDirectInteractor)
        {
            if (Climber.climbingHand && (Climber.climbingHand.name == args.interactor.name))
            {
                Climber.climbingHand = null;
            }
        }
    }
}
