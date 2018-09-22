using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interface;
using UnityEngine;

public class Entity
{

    public static GameObject GetObjectAtSpecifiedDirection(Transform transform, Direction direction)
    {
        Debug.DrawLine(transform.position, direction.ConvertToVector2(transform.position), Color.red);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, direction.ConvertToVector2(transform.position),
            LayerMask.GetMask("Interactable"));


        return (hit.collider == null ? null : hit.collider.gameObject);
    }

    public static void ExecuteActionOnInteract(GameObject obj)
    {
        if (obj == null)
            return;

        Component[] hits = obj.GetComponents(typeof(IInteract));
        if (hits.Length == 0)
            return;

        IInteract interact = hits[0] as IInteract;
        if (interact.IsInteractable())
            interact.TryInteract();
    }
	
}
