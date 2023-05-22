using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float duration = 1;
    [SerializeField] List<Transform> positions;

    int index = 0;
    private void Start()
    {
        Move();
    }

    private void Move()
    {
        var pos = positions[index];
        this.transform
            .DOMove(pos.position,duration)
            .onComplete = Move;

        index += 1;
        if (index == positions.Count)
        {
            index = 0;
        }
    }
}
