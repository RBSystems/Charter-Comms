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

namespace UserModule_EPSON_LAMP_HOURS
{
    public class UserModuleClass_EPSON_LAMP_HOURS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.StringInput RX_FROM_PROJ__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput LAMP_HOURS;
        CrestronString TEMP__DOLLAR__;
        ushort LENGTH = 0;
        ushort LOCATION = 0;
        object RX_FROM_PROJ__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 15;
                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_19__" , 200 , __SPLS_TMPVAR__WAITLABEL_19___Callback ) ;
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_19___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 17;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ__DOLLAR__ , (int)( 1 ) ) == 76) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ__DOLLAR__ , (int)( 2 ) ) == 65) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ__DOLLAR__ , (int)( 3 ) ) == 77) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ__DOLLAR__ , (int)( 4 ) ) == 80) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ__DOLLAR__ , (int)( 5 ) ) == 61) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 23;
                TEMP__DOLLAR__  .UpdateValue ( RX_FROM_PROJ__DOLLAR__  ) ; 
                __context__.SourceCodeLine = 24;
                LOCATION = (ushort) ( Functions.Find( "\u000d" , RX_FROM_PROJ__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 25;
                TEMP__DOLLAR__  .UpdateValue ( Functions.Left ( TEMP__DOLLAR__ ,  (int) ( (LOCATION - 1) ) )  ) ; 
                __context__.SourceCodeLine = 26;
                LENGTH = (ushort) ( Functions.Length( TEMP__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 27;
                LENGTH = (ushort) ( (LENGTH - 5) ) ; 
                __context__.SourceCodeLine = 28;
                TEMP__DOLLAR__  .UpdateValue ( Functions.Right ( TEMP__DOLLAR__ ,  (int) ( LENGTH ) )  ) ; 
                __context__.SourceCodeLine = 29;
                MakeString ( LAMP_HOURS , "{0}", TEMP__DOLLAR__ ) ; 
                } 
            
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    TEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    RX_FROM_PROJ__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX_FROM_PROJ__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( RX_FROM_PROJ__DOLLAR____AnalogSerialInput__, RX_FROM_PROJ__DOLLAR__ );
    
    LAMP_HOURS = new Crestron.Logos.SplusObjects.StringOutput( LAMP_HOURS__AnalogSerialOutput__, this );
    m_StringOutputList.Add( LAMP_HOURS__AnalogSerialOutput__, LAMP_HOURS );
    
    __SPLS_TMPVAR__WAITLABEL_19___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_19___CallbackFn );
    
    RX_FROM_PROJ__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX_FROM_PROJ__DOLLAR___OnChange_0, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_EPSON_LAMP_HOURS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_19___Callback;


const uint RX_FROM_PROJ__DOLLAR____AnalogSerialInput__ = 0;
const uint LAMP_HOURS__AnalogSerialOutput__ = 0;

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
