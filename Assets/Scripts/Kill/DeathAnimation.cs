using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{

    public Animator animator;

    public void AlertObservers(string message)
    {
        if (message.Equals("DeathAnimationEnded"))
        {
            Destroy(gameObject);
        }
    }
}
