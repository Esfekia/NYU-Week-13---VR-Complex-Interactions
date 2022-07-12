using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class DragInteractable : XRBaseInteractable
{
    void StartDrag()
    {

    }

    void EndDrag()
    {

    }

    // coroutine to do the drag calculation

    IEnumerator CalculateDrag()
    {
        yield return null;
    }
    
    // when an interactor interacts with this draggable object, we can just tie into the event right here:
    protected override void OnSelectEntered(XRBaseInteractor)
    {

    }

    // and do the same thing when select is exited.
    protected override void OnSelectExited(XRBaseInteractor)
    {

    }
}
