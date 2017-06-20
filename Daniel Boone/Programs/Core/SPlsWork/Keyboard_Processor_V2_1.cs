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

namespace UserModule_KEYBOARD_PROCESSOR_V2_1
{
    public class UserModuleClass_KEYBOARD_PROCESSOR_V2_1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput KEYBOARDSEND;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.DigitalInput BACK;
        Crestron.Logos.SplusObjects.DigitalInput DOT_COM;
        Crestron.Logos.SplusObjects.AnalogInput MAXCHARACTERS;
        Crestron.Logos.SplusObjects.AnalogInput KEYBOARDVAL;
        Crestron.Logos.SplusObjects.StringInput TEXTIN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TEXT__DOLLAR__;
        CrestronString END;
        object KEYBOARDSEND_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 45;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEXTIN__DOLLAR__ ) < MAXCHARACTERS  .UshortValue ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 47;
                    TEXT__DOLLAR__  .UpdateValue ( TEXTIN__DOLLAR__ + Functions.Chr (  (int) ( KEYBOARDVAL  .UshortValue ) )  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DOT_COM_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 53;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEXTIN__DOLLAR__ ) < MAXCHARACTERS  .UshortValue ))  ) ) 
                { 
                __context__.SourceCodeLine = 55;
                TEXT__DOLLAR__  .UpdateValue ( TEXTIN__DOLLAR__ + END  ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CLEAR_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 60;
        TEXT__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACK_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 65;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEXTIN__DOLLAR__ ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 67;
            TEXT__DOLLAR__  .UpdateValue ( Functions.Left ( TEXTIN__DOLLAR__ ,  (int) ( (Functions.Length( TEXTIN__DOLLAR__ ) - 1) ) )  ) ; 
            } 
        
        
        
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
        
        __context__.SourceCodeLine = 80;
        TEXT__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 81;
        END  .UpdateValue ( ".com"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    END  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
    
    KEYBOARDSEND = new Crestron.Logos.SplusObjects.DigitalInput( KEYBOARDSEND__DigitalInput__, this );
    m_DigitalInputList.Add( KEYBOARDSEND__DigitalInput__, KEYBOARDSEND );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    BACK = new Crestron.Logos.SplusObjects.DigitalInput( BACK__DigitalInput__, this );
    m_DigitalInputList.Add( BACK__DigitalInput__, BACK );
    
    DOT_COM = new Crestron.Logos.SplusObjects.DigitalInput( DOT_COM__DigitalInput__, this );
    m_DigitalInputList.Add( DOT_COM__DigitalInput__, DOT_COM );
    
    MAXCHARACTERS = new Crestron.Logos.SplusObjects.AnalogInput( MAXCHARACTERS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MAXCHARACTERS__AnalogSerialInput__, MAXCHARACTERS );
    
    KEYBOARDVAL = new Crestron.Logos.SplusObjects.AnalogInput( KEYBOARDVAL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( KEYBOARDVAL__AnalogSerialInput__, KEYBOARDVAL );
    
    TEXTIN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TEXTIN__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( TEXTIN__DOLLAR____AnalogSerialInput__, TEXTIN__DOLLAR__ );
    
    TEXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TEXT__DOLLAR____AnalogSerialOutput__, TEXT__DOLLAR__ );
    
    
    KEYBOARDSEND.OnDigitalPush.Add( new InputChangeHandlerWrapper( KEYBOARDSEND_OnPush_0, false ) );
    DOT_COM.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOT_COM_OnPush_1, false ) );
    CLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_OnPush_2, false ) );
    BACK.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACK_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_KEYBOARD_PROCESSOR_V2_1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint KEYBOARDSEND__DigitalInput__ = 0;
const uint CLEAR__DigitalInput__ = 1;
const uint BACK__DigitalInput__ = 2;
const uint DOT_COM__DigitalInput__ = 3;
const uint MAXCHARACTERS__AnalogSerialInput__ = 0;
const uint KEYBOARDVAL__AnalogSerialInput__ = 1;
const uint TEXTIN__DOLLAR____AnalogSerialInput__ = 2;
const uint TEXT__DOLLAR____AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
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
