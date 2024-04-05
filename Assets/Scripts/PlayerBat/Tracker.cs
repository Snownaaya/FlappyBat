using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Bat _bat;
    [SerializeField] private float _offset;

    private void Update()
    {
        var position = transform.position;
        position.x = _bat.transform.position.x + _offset;
        transform.position = position;
    }
}
