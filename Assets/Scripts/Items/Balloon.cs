using UnityEngine;

namespace Aili.Items
{
    [AddComponentMenu("Aili/Items/Ballon")]
    public class Balloon : MonoBehaviour
    {
        [SerializeField]
        float m_UpSpeed = 5f;

        [SerializeField]
        float m_Lifetime = 5f;

        Rigidbody2D _rigidbody2D;
        float lifetimeTime;

        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            lifetimeTime += Time.fixedDeltaTime;
            if (lifetimeTime >= m_Lifetime)
                Destroy(gameObject);

            MoveUp();
        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.TryGetComponent<Cursor>(out Cursor cursor))
            {
                Destroy(gameObject);
            }
        }

        void MoveUp()
        {
            _rigidbody2D.velocity += (Vector2.up * m_UpSpeed) * Time.fixedDeltaTime;
        }
    }
}
