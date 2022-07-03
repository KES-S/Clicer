using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCall : MonoBehaviour
{
    public static EventCall next;
    private void Awake()
    {
        next = this;
    }

    public event Action killSomeOne;
    public void TrigerKillSome() {
        if (killSomeOne != null) {
            killSomeOne();
        }


    }
}
