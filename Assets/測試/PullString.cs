using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullString : MonoBehaviour
{
    // 宣告一條射線
    private Ray mouseRay1;

    // RaycastHit是用來儲存被射線所打到的位置
    private RaycastHit rayHit;

    // 用來接收滑鼠點擊座標的X、Y值
    public float posX, posY, length, arrowStartX;

    // 指向String子物件
    public GameObject MyString;

    // 用來讀取MyString上的LineRender Component
    private LineRenderer MyStringLine;

    // 新增箭矢
    public GameObject Arrow;

    public void Start()
    {
        // 讀取弓弦的LineRender元件
        MyStringLine = MyString.GetComponent<LineRenderer>();      
    }

    void Update()
    {     
        // 按住滑鼠左鍵開始進行拉弓功能
        if (Input.GetMouseButton(0))
        {
            // 存取弓箭起始X座標
            arrowStartX = Arrow.transform.position.x;
            
            // 呼叫拉弓功能
            GetPos();
        }

        if (Input.GetMouseButtonUp(0))
        { 
            // 射出箭矢
            ShootArrow();

            // 弓弦回彈
            length = 0;

            StringNodeChange();
        }
    }

    // 拉弓功能
    private void GetPos()
    {
        // 設定射線的行徑方向(螢幕-滑鼠點擊位置)
        mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 如果射線以MouseRay1方向前進(螢幕到滑鼠點擊座標),有打到colliedr就會執行大括弧裡的程式碼
        if (Physics.Raycast(mouseRay1, out rayHit, 1000f))
        {
            // 儲存滑鼠所點擊的座標
            posX = rayHit.point.x;

            posY = rayHit.point.y;

            // 計算拉動的幅度
            Vector2 mousePos = new Vector2(transform.position.x - posX, transform.position.y - posY);

            length = mousePos.magnitude / 3f;

            // 讓弓身隨滑鼠旋轉
            float angleZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, angleZ);

            // 拉動的幅度只會介於0與1之間
            length = Mathf.Clamp(length, 0, 1);

            // 將箭矢向後拉動
            Vector3 arrowPosition = Arrow.transform.localPosition;

            arrowPosition.x = (arrowStartX - length);

            Arrow.transform.localPosition = arrowPosition;

            // 呼叫弓弦變形功能
            StringNodeChange();
        }
    }

    // 射箭函式
    private void ShootArrow()
    {
        if (Arrow.GetComponent<Rigidbody>() == null)
        {
            Arrow.AddComponent<Rigidbody>();

            // Arrow.transform.parent = gameManager.transform;
            Arrow.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)) * new Vector3(25f * length, 0, 0), ForceMode.VelocityChange);
        }
    }

    // 弓弦依照拖曳幅度length變形
    private void StringNodeChange()
    {
        // 改變LineRender中第2個點的座標藉此達到拉弓效果
        MyStringLine.SetPosition(1, new Vector3(-0.4f + (length * -1), 0, 0));
    }
}