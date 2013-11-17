using UnityEngine;
using System.Collections;

public class LevelEvent {
    private Time _triggerTime;
    private string _eventAction;

    public Time getTime()
    {
        return _triggerTime;
    }

    public Time getEventAction()
    {
        return _eventAction;
    }
}
