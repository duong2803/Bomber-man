using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedSpriteRenderer start;
    public AnimatedSpriteRenderer middle;
    public AnimatedSpriteRenderer end;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Explosion explosionPrefab;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;
    public void SetActiveRenderer(AnimatedSpriteRenderer renderer){
        start.enabled = renderer == start;
        middle.enabled = renderer == middle;
        end.enabled = renderer == end;
    }

    public void SetDirection(Vector2 direction){
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
    public void DestroyAfter(float seconds){
        Destroy(gameObject, seconds); 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
