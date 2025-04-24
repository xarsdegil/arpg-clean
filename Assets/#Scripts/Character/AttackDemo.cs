using UnityEngine;

public class AttackDemo : MonoBehaviour
{
    public Animator animator;
    public int upperBodyLayerIndex = 1;

    private bool releaseRequested = false;
    private SpellCastController spellCastController;

    [SerializeField] private Skill rmbSkill;

    private void Start()
    {
        spellCastController = GetComponent<SpellCastController>();
    }

    void Update()
    {
        if(Time.timeScale == 0f) return;

        if (DodgeRollController.Instance.IsDodging()) return;

        if (ActiveSkillManager.Instance.skills.Count == 0) return;

        rmbSkill = ActiveSkillManager.Instance.skills[0];

        if (Input.GetMouseButtonDown(1) && ActiveSkillManager.Instance.CanUseSkill(rmbSkill))
        {
            Vector3 lockedPos = GetMouseWorldPosition();
            LookAtCursor.Instance.SetLookLock(true, lockedPos);

            animator.SetTrigger("Attack");
            animator.SetLayerWeight(upperBodyLayerIndex, 1f);
            releaseRequested = false;

            ActiveSkillManager.Instance.UseSkill(rmbSkill);
        }

        if (Input.GetMouseButtonUp(1))
        {
            releaseRequested = true;
        }

        if (releaseRequested)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(upperBodyLayerIndex);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                animator.SetLayerWeight(upperBodyLayerIndex, 0f);
                releaseRequested = false;
                LookAtCursor.Instance.SetLookLock(false);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            return ray.GetPoint(rayDistance);
        }
        return Vector3.zero;
    }
}
