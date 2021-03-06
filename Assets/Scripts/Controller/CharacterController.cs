using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    public float maxAngle;
    public float minAngle;
    public float angle;
    public float arrowSpeed = 3.0f;
    public float gaugeSpeed = 2.0f;
    public float energy = 5.0f;
    public float distance;
    public float jump;
    public int defaultScale = 1;
    public int gravityScale = 30;

    private Rigidbody2D rigidBody;

    private int angleDir = 1;
    private int gaugeDir = 1;

    private float gauge = 0;
    private float minGauge = 0;
    private float maxGauge = 100;

    GaugeBar gaugeBar;
    Arrow arrow;

    GameScene scene;
    public bool isPlaying = false;
    public bool isJumping = false;
    SkeletonAnimation skeletonAnimation;

    private void AddGaugeBar()
    {
        GameObject go = Managers.Resource.Instantiate("UI/GaugeBar", transform);
        go.transform.localPosition = new Vector3(0, 1.0f, 0);
        go.name = "GaugeBar";
        gaugeBar = go.GetComponent<GaugeBar>();
        gaugeBar.SetGaugeBar(0);
    }

    private void AddArrow()
    {
        GameObject go = Managers.Resource.Instantiate("UI/Arrow", transform);
        go.transform.localPosition = new Vector3(0, 0.5f, 0);
        go.name = "Arrow";
        arrow = go.GetComponent<Arrow>();
        arrow.SetAngle(angle, distance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isJumping && isPlaying && collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            rigidBody.gravityScale = defaultScale;
            rigidBody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            isJumping = true;
            Managers.Sound.Play("sfx_boing", Define.Sound.Effect, scene.EffectFitch);
            skeletonAnimation.AnimationState.SetAnimation(0, "randing", false);
            skeletonAnimation.AnimationState.AddAnimation(0, "jump", false, 0.167f);
        }

        if (isPlaying && collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            scene.State = Define.GameState.End;
            Managers.Sound.Play("sfx_dead", Define.Sound.Effect, scene.EffectFitch);
        }
    }

    private void OnBecameInvisible()
    {
        scene.IsOverScreen = true;
    }

    private void OnBecameVisible()
    {
        scene.IsOverScreen = false;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        AddGaugeBar();
        AddArrow();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        rigidBody.gravityScale = defaultScale;
        scene = Managers.Scene.CurrentScene as GameScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            scene.State = Define.GameState.Ready;
        }

        if (rigidBody.velocity.y < 0)
        {
            isJumping = false;
        }
            
        if (!isPlaying)
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (gauge >= maxGauge)
                {
                    gauge = maxGauge;
                    gaugeDir *= -1;
                }

                if (gauge <= minGauge)
                {
                    gauge = minGauge;
                    gaugeDir *= -1;
                }

                gauge += gaugeSpeed * gaugeDir * Time.deltaTime;
                gaugeBar.SetGaugeBar(gauge / maxGauge);


                if (angle >= maxAngle)
                {
                    angle = maxAngle;
                    angleDir *= -1;
                }

                if (angle <= minAngle)
                {
                    angle = minAngle;
                    angleDir *= -1;
                }

                angle += Time.deltaTime * arrowSpeed * angleDir;
                arrow.SetAngle(angle, distance);
            }

            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 dir = arrow.LocalPosition - transform.position;
                Vector2 speed = dir * energy * Mathf.Max(0.01f, gaugeBar.Ratio);
                //rigidBody.velocity = new Vector2(0, speed.y);

                //jump = speed.y;
                rigidBody.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
                gaugeBar.gameObject.SetActive(false);
                arrow.gameObject.SetActive(false);
                scene.Speed = speed.x;
                scene.State = Define.GameState.Playing;
                skeletonAnimation.AnimationState.SetAnimation(0, "jump", false);
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                rigidBody.gravityScale = gravityScale;
            }
        }
    }
}
