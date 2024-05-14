using UnityEngine;

namespace Aili.Items
{
    [AddComponentMenu("Aili/Items/Cursor")]
    public class Cursor : MonoBehaviour
    {
        [SerializeField]
        float m_MoveSpeed = 8f;

        [SerializeField]
        float m_Lifetime = 5f;

        Rigidbody2D _rigidbody2D;
        float lifetimeTime;

        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(-25, 25)));
        }

        void FixedUpdate()
        {
            lifetimeTime += Time.fixedDeltaTime;
            if (lifetimeTime >= m_Lifetime)
                Destroy(gameObject);

            Shot();
        }

        void Shot()
        {
            _rigidbody2D.AddForce(transform.right * m_MoveSpeed, ForceMode2D.Force);
        }
    }
}
