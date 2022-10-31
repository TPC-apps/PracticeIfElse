using UnityEngine;

public class script : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    // カメラの描画範囲を定数定義
    private const float CAMERA_RANGE = 8.94f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // キーを押している間だけ移動させたいので速度を0にする
        SetHorizontalVerocity(0f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetHorizontalVerocity(5f);

            // 右(正)方向で画面外に出た場合画面出ないように位置を設定
            if (rigidbody.position.x > CAMERA_RANGE)
            {
                SetHorizontalPosition(CAMERA_RANGE);
            }
        }

        // else if にすると左右どちらも押しているときに左キー
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetHorizontalVerocity(-5f);

            // 左(負)方向で画面外に出た場合画面出ないように位置を設定
            if (rigidbody.position.x < -CAMERA_RANGE)
            {
                SetHorizontalPosition(-CAMERA_RANGE);
            }
        }
    }

    /**
     * rigidbodyの速度を変更する処理を関数化して
     * この関数に速度を与えるだけで変更できるようにする
     * 
     * @param velocity 物体の速度
     */
    private void SetHorizontalVerocity(float velocity)
    {
        // 横方向の速度を設定
        rigidbody.velocity = new Vector2(velocity, 0.0f);
    }

    // 速度と同様に値を与えるだけで位置を設定できるようにする
    private void SetHorizontalPosition(float position)
    {
        rigidbody.position = new Vector2(position, rigidbody.position.y);
    }
}
