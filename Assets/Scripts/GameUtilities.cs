using System.Collections;
using UnityEngine;

public static class GameUtilities{
    
    public static void PlayHitSequence(GameObject hitSourceGameObject, GameObject hitReceiver, MonoBehaviour script)
    {
        Transform hitSourceTransform = hitSourceGameObject.transform;
        Transform hitReceiverTransform = hitReceiver.transform;
        
        Vector3 jumpPosition = Vector3.zero, fallPosition = Vector3.zero;
        int jumpX = 20, jumpY = 30;
        int fallX = 30, fallY = 10;

        if (hitSourceTransform.position.x < hitReceiverTransform.position.x)
            fallY *= -1;
        else
        {
            jumpX *= -1;
            fallX *= -1;
            fallY *= -1;
        }

        jumpPosition = new Vector3(jumpX, jumpY, 0);
        fallPosition = new Vector3(fallX, fallY, 0);

        script.StartCoroutine(MoveToPosition(hitReceiverTransform, hitReceiverTransform.position + jumpPosition, 0.05f));
        script.StartCoroutine(MoveToPosition(hitReceiverTransform, hitReceiverTransform.position + fallPosition, 0.2f));
    }
    
    private static IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}

