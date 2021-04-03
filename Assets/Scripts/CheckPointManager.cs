using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    CheckPoint[] checkpoints;

    void Start()
    {
        checkpoints = GetComponentsInChildren<CheckPoint>();
    }

    public CheckPoint GetLastCheckPointPassed()
    {
        return checkpoints.Last(t => t.Passed);
    }
}
