using System.Collections;
using UnityEngine;

public class SpellCastController : MonoBehaviour
{
    [SerializeField] private GameObject spellCastPrefab;
    [SerializeField] private Transform castOrigin;

    public void CastSpell()
    {
        if (spellCastPrefab != null && castOrigin != null)
        {
            GameObject instance = Instantiate(spellCastPrefab, castOrigin.position, castOrigin.rotation);

            ParticleSystem ps = instance.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                StartCoroutine(DestroyAfterParticle(ps));
            }
            else
            {
                Destroy(instance, 5f);
            }
        }
    }

    private IEnumerator DestroyAfterParticle(ParticleSystem ps)
    {
        ps.Play();

        yield return new WaitUntil(() => !ps.IsAlive(true));

        Destroy(ps.gameObject);
    }
}
