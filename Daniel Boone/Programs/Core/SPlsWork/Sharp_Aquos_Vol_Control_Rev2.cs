using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_SHARP_AQUOS_VOL_CONTROL_REV2
{
    public class UserModuleClass_SHARP_AQUOS_VOL_CONTROL_REV2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_MUTE_TOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_MUTE;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_UNMUTE;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_MUTE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_TO_ANALOG;
        Crestron.Logos.SplusObjects.StringOutput VOLUME_TO_SHARP;
        Crestron.Logos.SplusObjects.StringOutput VOLUME_TO_TEXT;
        private void SET_VOLUME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 50;
            _SplusNVRAM.VOLUME_LEVEL_DEVICE = (short) ( ((((_SplusNVRAM.VOLUME_MAX_DEVICE - _SplusNVRAM.VOLUME_MIN_DEVICE) * _SplusNVRAM.VOLUME_LEVEL) / _SplusNVRAM.VOLUME_MAX_LEVEL) + _SplusNVRAM.VOLUME_MIN_DEVICE) ) ; 
            __context__.SourceCodeLine = 52;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.VOLUME_LEVEL_DEVICE < 10 ))  ) ) 
                { 
                __context__.SourceCodeLine = 54;
                MakeString ( VOLUME_TO_SHARP , "VOLM{0:d}\u0020\u0020\u0020\u000D", (short)_SplusNVRAM.VOLUME_LEVEL_DEVICE) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 58;
                MakeString ( VOLUME_TO_SHARP , "VOLM{0:d}\u0020\u0020\u000D", (short)_SplusNVRAM.VOLUME_LEVEL_DEVICE) ; 
                } 
            
            __context__.SourceCodeLine = 61;
            MakeString ( VOLUME_TO_TEXT , "{0:d}%", (short)_SplusNVRAM.VOLUME_LEVEL) ; 
            __context__.SourceCodeLine = 62;
            VOLUME_TO_ANALOG  .Value = (ushort) ( ((_SplusNVRAM.VOLUME_LEVEL * 65535) / 100) ) ; 
            
            }
            
        object VOLUME_UP_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 67;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUME_MUTED == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 69;
                    MakeString ( VOLUME_TO_SHARP , "MUTE0\u0020\u0020\u0020\u000D") ; 
                    __context__.SourceCodeLine = 70;
                    VOLUME_MUTE_FB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 71;
                    _SplusNVRAM.VOLUME_MUTED = (short) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 73;
                _SplusNVRAM.VOLUME_LEVEL = (short) ( (_SplusNVRAM.VOLUME_LEVEL + 1) ) ; 
                __context__.SourceCodeLine = 75;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.VOLUME_LEVEL > _SplusNVRAM.VOLUME_MAX_LEVEL ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 77;
                    _SplusNVRAM.VOLUME_LEVEL = (short) ( _SplusNVRAM.VOLUME_MAX_LEVEL ) ; 
                    } 
                
                __context__.SourceCodeLine = 79;
                SET_VOLUME (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object VOLUME_DOWN_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 84;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUME_MUTED == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 86;
                MakeString ( VOLUME_TO_SHARP , "MUTE0\u0020\u0020\u0020\u000D") ; 
                __context__.SourceCodeLine = 87;
                VOLUME_MUTE_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 88;
                _SplusNVRAM.VOLUME_MUTED = (short) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 91;
            _SplusNVRAM.VOLUME_LEVEL = (short) ( (_SplusNVRAM.VOLUME_LEVEL - 1) ) ; 
            __context__.SourceCodeLine = 93;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.VOLUME_LEVEL < _SplusNVRAM.VOLUME_MIN_LEVEL ))  ) ) 
                { 
                __context__.SourceCodeLine = 95;
                _SplusNVRAM.VOLUME_LEVEL = (short) ( _SplusNVRAM.VOLUME_MIN_LEVEL ) ; 
                } 
            
            __context__.SourceCodeLine = 97;
            SET_VOLUME (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object VOLUME_MUTE_TOGGLE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 103;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.VOLUME_MUTED == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 105;
            MakeString ( VOLUME_TO_SHARP , "MUTE0\u0020\u0020\u0020\u000D") ; 
            __context__.SourceCodeLine = 106;
            VOLUME_MUTE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 107;
            _SplusNVRAM.VOLUME_MUTED = (short) ( 0 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 111;
            MakeString ( VOLUME_TO_SHARP , "MUTE1\u0020\u0020\u0020\u000D") ; 
            __context__.SourceCodeLine = 112;
            VOLUME_MUTE_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 113;
            _SplusNVRAM.VOLUME_MUTED = (short) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 119;
        MakeString ( VOLUME_TO_SHARP , "MUTE1\u0020\u0020\u0020\u000D") ; 
        __context__.SourceCodeLine = 120;
        VOLUME_MUTE_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 121;
        _SplusNVRAM.VOLUME_MUTED = (short) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_UNMUTE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 126;
        MakeString ( VOLUME_TO_SHARP , "MUTE2\u0020\u0020\u0020\u000D") ; 
        __context__.SourceCodeLine = 127;
        VOLUME_MUTE_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 128;
        _SplusNVRAM.VOLUME_MUTED = (short) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 134;
        _SplusNVRAM.VOLUME_MIN_LEVEL = (short) ( 0 ) ; 
        __context__.SourceCodeLine = 135;
        _SplusNVRAM.VOLUME_MAX_LEVEL = (short) ( 100 ) ; 
        __context__.SourceCodeLine = 136;
        _SplusNVRAM.VOLUME_MIN_DEVICE = (short) ( 0 ) ; 
        __context__.SourceCodeLine = 137;
        _SplusNVRAM.VOLUME_MAX_DEVICE = (short) ( 100 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_UP__DigitalInput__, VOLUME_UP );
    
    VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_DOWN__DigitalInput__, VOLUME_DOWN );
    
    VOLUME_MUTE_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_MUTE_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_MUTE_TOGGLE__DigitalInput__, VOLUME_MUTE_TOGGLE );
    
    VOLUME_MUTE = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_MUTE__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_MUTE__DigitalInput__, VOLUME_MUTE );
    
    VOLUME_UNMUTE = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_UNMUTE__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_UNMUTE__DigitalInput__, VOLUME_UNMUTE );
    
    VOLUME_MUTE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_MUTE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_MUTE_FB__DigitalOutput__, VOLUME_MUTE_FB );
    
    VOLUME_TO_ANALOG = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_TO_ANALOG__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_TO_ANALOG__AnalogSerialOutput__, VOLUME_TO_ANALOG );
    
    VOLUME_TO_SHARP = new Crestron.Logos.SplusObjects.StringOutput( VOLUME_TO_SHARP__AnalogSerialOutput__, this );
    m_StringOutputList.Add( VOLUME_TO_SHARP__AnalogSerialOutput__, VOLUME_TO_SHARP );
    
    VOLUME_TO_TEXT = new Crestron.Logos.SplusObjects.StringOutput( VOLUME_TO_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( VOLUME_TO_TEXT__AnalogSerialOutput__, VOLUME_TO_TEXT );
    
    
    VOLUME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_UP_OnPush_0, false ) );
    VOLUME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_DOWN_OnPush_1, false ) );
    VOLUME_MUTE_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_TOGGLE_OnPush_2, false ) );
    VOLUME_MUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_OnPush_3, false ) );
    VOLUME_UNMUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_UNMUTE_OnPush_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SHARP_AQUOS_VOL_CONTROL_REV2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint VOLUME_UP__DigitalInput__ = 0;
const uint VOLUME_DOWN__DigitalInput__ = 1;
const uint VOLUME_MUTE_TOGGLE__DigitalInput__ = 2;
const uint VOLUME_MUTE__DigitalInput__ = 3;
const uint VOLUME_UNMUTE__DigitalInput__ = 4;
const uint VOLUME_MUTE_FB__DigitalOutput__ = 0;
const uint VOLUME_TO_ANALOG__AnalogSerialOutput__ = 0;
const uint VOLUME_TO_SHARP__AnalogSerialOutput__ = 1;
const uint VOLUME_TO_TEXT__AnalogSerialOutput__ = 2;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public short VOLUME_LEVEL = 0;
            [SplusStructAttribute(1, false, true)]
            public short VOLUME_LEVEL_DEVICE = 0;
            [SplusStructAttribute(2, false, true)]
            public short VOLUME_MUTED = 0;
            [SplusStructAttribute(3, false, true)]
            public short VOLUME_MIN_LEVEL = 0;
            [SplusStructAttribute(4, false, true)]
            public short VOLUME_MAX_LEVEL = 0;
            [SplusStructAttribute(5, false, true)]
            public short VOLUME_MIN_DEVICE = 0;
            [SplusStructAttribute(6, false, true)]
            public short VOLUME_MAX_DEVICE = 0;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
