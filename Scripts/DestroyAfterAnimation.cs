using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    void AnimEndDestroy()
    {
        Destroy(gameObject);
    }
}
