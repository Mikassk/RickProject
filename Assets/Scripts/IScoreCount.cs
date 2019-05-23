using System.Collections;
using UnityEngine.EventSystems;

public interface IScoreCount : IEventSystemHandler
{

    IEnumerable ApplyScore(float point);
    float? GetScore();

}
