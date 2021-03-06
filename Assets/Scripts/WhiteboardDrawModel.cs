using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class WhiteboardDrawModel
{
    [RealtimeProperty(1, true, true)]
    private byte[] _drawPoints = new byte[0];
    [RealtimeProperty(2, true, true)]
    private int _whiteboardID;
}
/* ----- Begin Normal Autogenerated Code ----- */
public partial class WhiteboardDrawModel : IModel {
    // Properties
    public System.Byte[] drawPoints {
        get { return _cache.LookForValueInCache(_drawPoints, entry => entry.drawPointsSet, entry => entry.drawPoints); }
        set { if (value == drawPoints) return; _cache.UpdateLocalCache(entry => { entry.drawPointsSet = true; entry.drawPoints = value; return entry; }); FireDrawPointsDidChange(value); }
    }
    public System.Int32 whiteboardID {
        get { return _cache.LookForValueInCache(_whiteboardID, entry => entry.whiteboardIDSet, entry => entry.whiteboardID); }
        set { if (value == whiteboardID) return; _cache.UpdateLocalCache(entry => { entry.whiteboardIDSet = true; entry.whiteboardID = value; return entry; }); FireWhiteboardIDDidChange(value); }
    }
    
    // Events
    public delegate void DrawPointsDidChange(WhiteboardDrawModel model, System.Byte[] value);
    public event         DrawPointsDidChange drawPointsDidChange;
    public delegate void WhiteboardIDDidChange(WhiteboardDrawModel model, System.Int32 value);
    public event         WhiteboardIDDidChange whiteboardIDDidChange;
    
    // Delta updates
    private struct LocalCacheEntry {
        public bool          drawPointsSet;
        public System.Byte[] drawPoints;
        public bool          whiteboardIDSet;
        public System.Int32  whiteboardID;
    }
    
    private LocalChangeCache<LocalCacheEntry> _cache;
    
    public WhiteboardDrawModel() {
        _cache = new LocalChangeCache<LocalCacheEntry>();
    }
    
    // Events
    public void FireDrawPointsDidChange(System.Byte[] value) {
        try {
            if (drawPointsDidChange != null)
                drawPointsDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FireWhiteboardIDDidChange(System.Int32 value) {
        try {
            if (whiteboardIDDidChange != null)
                whiteboardIDDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        DrawPoints = 1,
        WhiteboardID = 2,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Mark unreliable properties as clean and flatten the in-flight cache.
            // TODO: Move this out of WriteLength() once we have a prepareToWrite method.
            _drawPoints = drawPoints;
            _whiteboardID = whiteboardID;
            _cache.Clear();
            
            // Write all properties
            length += WriteStream.WriteBytesLength((uint)PropertyID.DrawPoints, _drawPoints.Length);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.WhiteboardID, (uint)_whiteboardID);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.drawPointsSet)
                    length += WriteStream.WriteBytesLength((uint)PropertyID.DrawPoints, entry.drawPoints.Length);
                if (entry.whiteboardIDSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.WhiteboardID, (uint)entry.whiteboardID);
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteBytes((uint)PropertyID.DrawPoints, _drawPoints);
            stream.WriteVarint32((uint)PropertyID.WhiteboardID, (uint)_whiteboardID);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.drawPointsSet || entry.whiteboardIDSet)
                    _cache.PushLocalCacheToInflight(context.updateID);
                
                if (entry.drawPointsSet)
                    stream.WriteBytes((uint)PropertyID.DrawPoints, entry.drawPoints);
                if (entry.whiteboardIDSet)
                    stream.WriteVarint32((uint)PropertyID.WhiteboardID, (uint)entry.whiteboardID);
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        bool drawPointsExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.drawPointsSet);
        bool whiteboardIDExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.whiteboardIDSet);
        
        // Remove from in-flight
        if (context.deltaUpdatesOnly && context.reliableChannel)
            _cache.RemoveUpdateFromInflight(context.updateID);
        
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.DrawPoints: {
                    System.Byte[] previousValue = _drawPoints;
                    
                    _drawPoints = stream.ReadBytes();
                    
                    if (!drawPointsExistsInChangeCache && _drawPoints != previousValue)
                        FireDrawPointsDidChange(_drawPoints);
                    break;
                }
                case (uint)PropertyID.WhiteboardID: {
                    System.Int32 previousValue = _whiteboardID;
                    
                    _whiteboardID = (int)stream.ReadVarint32();
                    
                    if (!whiteboardIDExistsInChangeCache && _whiteboardID != previousValue)
                        FireWhiteboardIDDidChange(_whiteboardID);
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
