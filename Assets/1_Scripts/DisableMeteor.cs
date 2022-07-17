using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeteor : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Meteor"))
        {
            Events.onDisableMeteor?.Invoke(collider.GetComponent<Meteor>());
        }
    }
}
