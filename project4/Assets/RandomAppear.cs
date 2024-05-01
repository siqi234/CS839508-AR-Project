using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RandomAppearance : MonoBehaviour
{
    public GameObject[] objects;  // Array of objects to appear randomly for this specific target
    private ObserverBehaviour mObserverBehaviour;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnStatusChanged;
        }

        // Initially disable all objects
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED ||
            targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            // Randomly pick an object to activate
            GameObject selectedObject = objects[Random.Range(0, objects.Length)];
            HideAllObjects();
            selectedObject.SetActive(true);
        }
        else
        {
            HideAllObjects();
        }
    }

    void HideAllObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}
