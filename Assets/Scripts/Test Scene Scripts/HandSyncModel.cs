using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class HandSyncModel
{
    // the right way is probably to do this with a Normal IModel... need to learn that in the future
    [RealtimeProperty(1, false, true)]
    private int _handPoseId;
    [RealtimeProperty(2, false, true)]
    private float _flex;
    [RealtimeProperty(3, false, true)]
    private float _point;
    [RealtimeProperty(4, false, true)]
    private float _thumbsUp;
    [RealtimeProperty(5, false, true)]
    private float _pinch;
}
/* ----- Begin Normal Autogenerated Code ----- */
public partial class HandSyncModel : IModel {
    // Properties
    public System.Int32 handPoseId {
        get { return _handPoseId; }
        set { if (value == _handPoseId) return; _handPoseIdShouldWrite = true; _handPoseId = value; FireHandPoseIdDidChange(value); }
    }
    public System.Single flex {
        get { return _flex; }
        set { if (value == _flex) return; _flexShouldWrite = true; _flex = value; FireFlexDidChange(value); }
    }
    public System.Single point {
        get { return _point; }
        set { if (value == _point) return; _pointShouldWrite = true; _point = value; FirePointDidChange(value); }
    }
    public System.Single thumbsUp {
        get { return _thumbsUp; }
        set { if (value == _thumbsUp) return; _thumbsUpShouldWrite = true; _thumbsUp = value; FireThumbsUpDidChange(value); }
    }
    public System.Single pinch {
        get { return _pinch; }
        set { if (value == _pinch) return; _pinchShouldWrite = true; _pinch = value; FirePinchDidChange(value); }
    }
    
    // Events
    public delegate void HandPoseIdDidChange(HandSyncModel model, System.Int32 value);
    public event         HandPoseIdDidChange handPoseIdDidChange;
    public delegate void FlexDidChange(HandSyncModel model, System.Single value);
    public event         FlexDidChange flexDidChange;
    public delegate void PointDidChange(HandSyncModel model, System.Single value);
    public event         PointDidChange pointDidChange;
    public delegate void ThumbsUpDidChange(HandSyncModel model, System.Single value);
    public event         ThumbsUpDidChange thumbsUpDidChange;
    public delegate void PinchDidChange(HandSyncModel model, System.Single value);
    public event         PinchDidChange pinchDidChange;
    
    private bool _handPoseIdShouldWrite;
    private bool _flexShouldWrite;
    private bool _pointShouldWrite;
    private bool _thumbsUpShouldWrite;
    private bool _pinchShouldWrite;
    
    public HandSyncModel() {
    }
    
    // Events
    public void FireHandPoseIdDidChange(System.Int32 value) {
        try {
            if (handPoseIdDidChange != null)
                handPoseIdDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FireFlexDidChange(System.Single value) {
        try {
            if (flexDidChange != null)
                flexDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePointDidChange(System.Single value) {
        try {
            if (pointDidChange != null)
                pointDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FireThumbsUpDidChange(System.Single value) {
        try {
            if (thumbsUpDidChange != null)
                thumbsUpDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePinchDidChange(System.Single value) {
        try {
            if (pinchDidChange != null)
                pinchDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        HandPoseId = 1,
        Flex = 2,
        Point = 3,
        ThumbsUp = 4,
        Pinch = 5,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Write all properties
            length += WriteStream.WriteVarint32Length((uint)PropertyID.HandPoseId, (uint)_handPoseId);
            length += WriteStream.WriteFloatLength((uint)PropertyID.Flex);
            length += WriteStream.WriteFloatLength((uint)PropertyID.Point);
            length += WriteStream.WriteFloatLength((uint)PropertyID.ThumbsUp);
            length += WriteStream.WriteFloatLength((uint)PropertyID.Pinch);
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_handPoseIdShouldWrite) {
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.HandPoseId, (uint)_handPoseId);
                }
                if (_flexShouldWrite) {
                    length += WriteStream.WriteFloatLength((uint)PropertyID.Flex);
                }
                if (_pointShouldWrite) {
                    length += WriteStream.WriteFloatLength((uint)PropertyID.Point);
                }
                if (_thumbsUpShouldWrite) {
                    length += WriteStream.WriteFloatLength((uint)PropertyID.ThumbsUp);
                }
                if (_pinchShouldWrite) {
                    length += WriteStream.WriteFloatLength((uint)PropertyID.Pinch);
                }
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteVarint32((uint)PropertyID.HandPoseId, (uint)_handPoseId);
            _handPoseIdShouldWrite = false;
            stream.WriteFloat((uint)PropertyID.Flex, _flex);
            _flexShouldWrite = false;
            stream.WriteFloat((uint)PropertyID.Point, _point);
            _pointShouldWrite = false;
            stream.WriteFloat((uint)PropertyID.ThumbsUp, _thumbsUp);
            _thumbsUpShouldWrite = false;
            stream.WriteFloat((uint)PropertyID.Pinch, _pinch);
            _pinchShouldWrite = false;
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_handPoseIdShouldWrite) {
                    stream.WriteVarint32((uint)PropertyID.HandPoseId, (uint)_handPoseId);
                    _handPoseIdShouldWrite = false;
                }
                if (_flexShouldWrite) {
                    stream.WriteFloat((uint)PropertyID.Flex, _flex);
                    _flexShouldWrite = false;
                }
                if (_pointShouldWrite) {
                    stream.WriteFloat((uint)PropertyID.Point, _point);
                    _pointShouldWrite = false;
                }
                if (_thumbsUpShouldWrite) {
                    stream.WriteFloat((uint)PropertyID.ThumbsUp, _thumbsUp);
                    _thumbsUpShouldWrite = false;
                }
                if (_pinchShouldWrite) {
                    stream.WriteFloat((uint)PropertyID.Pinch, _pinch);
                    _pinchShouldWrite = false;
                }
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.HandPoseId: {
                    System.Int32 previousValue = _handPoseId;
                    
                    _handPoseId = (int)stream.ReadVarint32();
                    _handPoseIdShouldWrite = false;
                    
                    if (_handPoseId != previousValue)
                        FireHandPoseIdDidChange(_handPoseId);
                    break;
                }
                case (uint)PropertyID.Flex: {
                    System.Single previousValue = _flex;
                    
                    _flex = stream.ReadFloat();
                    _flexShouldWrite = false;
                    
                    if (_flex != previousValue)
                        FireFlexDidChange(_flex);
                    break;
                }
                case (uint)PropertyID.Point: {
                    System.Single previousValue = _point;
                    
                    _point = stream.ReadFloat();
                    _pointShouldWrite = false;
                    
                    if (_point != previousValue)
                        FirePointDidChange(_point);
                    break;
                }
                case (uint)PropertyID.ThumbsUp: {
                    System.Single previousValue = _thumbsUp;
                    
                    _thumbsUp = stream.ReadFloat();
                    _thumbsUpShouldWrite = false;
                    
                    if (_thumbsUp != previousValue)
                        FireThumbsUpDidChange(_thumbsUp);
                    break;
                }
                case (uint)PropertyID.Pinch: {
                    System.Single previousValue = _pinch;
                    
                    _pinch = stream.ReadFloat();
                    _pinchShouldWrite = false;
                    
                    if (_pinch != previousValue)
                        FirePinchDidChange(_pinch);
                    break;
                }
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
