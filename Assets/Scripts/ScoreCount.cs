using UnityEngine;
using System.Collections;


public class ScoreCount : MonoBehaviour, IScoreCount
{
    public float coinpoint=0;

    public IEnumerable ApplyScore (float point)
    {
        Debug.Log("Adicionar:"+coinpoint);
        coinpoint += 1;
        yield return null;
    }
    public float? GetScore()
    {
        return coinpoint;
    }
}
