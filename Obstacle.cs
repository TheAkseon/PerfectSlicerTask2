using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Slicer _slicer;

    private int _timeStunning = -100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Blade blade))
        {
            _slicer._timer = _timeStunning;
        }
    }
}
