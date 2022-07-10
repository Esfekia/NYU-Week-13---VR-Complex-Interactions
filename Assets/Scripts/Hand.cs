using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public enum HandType
{
    Left,
    Right
};

public class Hand : MonoBehaviour
{

    public HandType type = HandType.Left;

    // public getter, private setter for our isHidden boolean
    public bool isHidden { get; private set; } = false;

    // we want to get updated when this device's action updates so we create a binding to look into this input
    public InputAction trackedAction = null;

    bool m_isCurrentlyTracked = false;

    List<MeshRenderer> m_currentRenderers = new List<MeshRenderer>();
    
    // Start is called before the first frame update
    void Start()
    {
        // need to enable it before it can be used. It will give us a float
        trackedAction.Enable();

        // this will hide the hand in the beginning and the function will populate our m_currentRenderers for use in Show()
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        float isTracked = trackedAction.ReadValue<float>();

        // if it is tracked, then lets show our hand
        if (isTracked == 1.0f && !m_isCurrentlyTracked)
        {
            m_isCurrentlyTracked = true;
            Show();
        }
        // if it is no longer tracked but still showing, lets hide it
        else if(isTracked == 0 && m_isCurrentlyTracked)
        {
            m_isCurrentlyTracked = false;
            Hide();
        }
    }

    public void Show()
    {
        // currentRenderers got all the meshrenderers added to it in Hide() below!
        foreach (MeshRenderer renderer in m_currentRenderers)
        {
            renderer.enabled = true;                       
        }
        isHidden = false;
    }
    public void Hide()
    {
        m_currentRenderers.Clear();

        // get all the possible meshrenderers in the children and go through each of them
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;

            // add it to the currentRenderers list so that you can show them again when they are turned back on
            m_currentRenderers.Add(renderer);
        }
        isHidden = true;
    }
}
