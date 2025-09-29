using UnityEngine;

public abstract class PopupWindow : MonoBehaviour
{
    //Common properties
    protected bool isCompleted = false;

    // Reference to manager (to notify success/fail)
    protected GameManager manager;

    public void Init(GameManager mgr)
    {
        manager = mgr;
        OnInit();
    }

    //Methods for minigames
    protected abstract void OnInit();
    protected abstract void OnComplete();

    protected void Complete()
    {
        if (isCompleted) return;
        isCompleted = true;
        OnComplete();
        manager.OnPopUpClosed(this, true);
        Destroy(gameObject);
    }

    protected void Fail()
    {
        if (isCompleted) return;
        isCompleted = true;
        manager.OnPopUpClosed(this, false);
        Destroy(gameObject);
    }
}
