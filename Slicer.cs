using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;
    [SerializeField] private int _delay;
    [SerializeField] private int _delayTime;
    public int _timer = 0;
    private bool _timerStart = false;

    private BzKnife _knife;

    private void Start()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
    }

    private void FixedUpdate()
    {
        if (_timerStart == true)
        {
            _timer += _delay;
            if (_timer == _delayTime)
            {
                _timer = 0;
                _timerStart = false;
            }
        }

        if (Input.GetMouseButton(0) & (_timer == 0))
        {
            _timerStart = true;
            _knife.BeginNewSlice();
            _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
