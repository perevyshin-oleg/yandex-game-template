using System.Collections;
using UnityEngine;

namespace YGameTemplate.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}