using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartMenu : MonoBehaviour {

    Sequence menuSequence;
    public Transform playGame;

	void Start () {
        menuSequence = DOTween.Sequence();

        menuSequence.Append(transform.DOLocalMoveY(-300, 2).SetEase(Ease.OutBack, 2).SetDelay(1.0f));

        DOTween.To(() => transform.position, x => transform.position = x, new Vector3(200, 100, 0), 0.5f);

        playGame.transform.DOLocalMove(new Vector3(0, -49, 0), 2);
	}

}
