using Spine.Unity;
using UnityEngine;

public class Poolable : MonoBehaviour
{
	bool isUsing;
	public bool IsUsing
    {
        get { return isUsing; }
        set
        {
            GetComponent<MapObject>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SkeletonAnimation>().enabled = true;
        }
    }
}