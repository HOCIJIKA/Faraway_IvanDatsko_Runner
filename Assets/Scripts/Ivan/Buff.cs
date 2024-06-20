using Ivan.MoveModifiers;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private IMovable _movable;
    
    private enum Buffs
    {
        None,
        Fast,
        Slow,
        Fly
    }

    [SerializeField] private Buffs _buff = Buffs.None;
    [SerializeField] private float _DefaultBuffDuration = 10;
    
    private void Awake()
    {
        switch (_buff)
        {
            case Buffs.Fast:
                _movable = new FastMove();
                break;
            
            case Buffs.Slow:
                _movable = new SlowMove();
                break;
            
            case Buffs.Fly:
                _movable = new Fly();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddBuff(_movable, _DefaultBuffDuration); 
            gameObject.SetActive(false);
        }
    }
}
