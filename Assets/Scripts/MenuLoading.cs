using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoading : MonoBehaviour {

    Sequence menuSequence;

    void Start()
    {
        menuSequence.Append(transform.DOLocalMoveY(-300, 2));
        menuSequence = DOTween.Sequence();

    }
}
