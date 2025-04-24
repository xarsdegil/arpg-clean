using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Ice Shard")]
public class IceShardSkill : Skill
{
    public GameObject iceShardPrefab;
    private Transform castOrigin;

    public override void Execute(GameObject user)
    {
        castOrigin = GameObject.FindWithTag("SpellCastGround").transform;

        if (iceShardPrefab != null && castOrigin != null)
        {
            GameObject instance = Instantiate(iceShardPrefab, castOrigin.position, castOrigin.rotation);

            ParticleSystem ps = instance.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                CoroutineRunner.Instance.StartCoroutine(DestroyAfterParticle(ps));
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
