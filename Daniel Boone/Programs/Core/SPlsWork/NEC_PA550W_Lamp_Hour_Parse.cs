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

namespace UserModule_NEC_PA550W_LAMP_HOUR_PARSE
{
    public class UserModuleClass_NEC_PA550W_LAMP_HOUR_PARSE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.StringInput RX_FROM_PROJ;
        Crestron.Logos.SplusObjects.AnalogOutput LAMP_HOURS;
        Crestron.Logos.SplusObjects.AnalogOutput LAMP_HOURS_REMAINING;
        Crestron.Logos.SplusObjects.StringOutput LAMP_HOURS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput LAMP_HOURS_REMAINING__DOLLAR__;
        uint [] TEMP;
        uint ILAMP_HOURS = 0;
        uint ILAMP_HOURS_REMAINING = 0;
        object RX_FROM_PROJ_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 33;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ , (int)( 1 ) ) == 35) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ , (int)( 2 ) ) == 140) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ , (int)( 3 ) ) == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX_FROM_PROJ , (int)( 5 ) ) == 16) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 36;
                    TEMP [ 1] = (uint) ( (Byte( RX_FROM_PROJ , (int)( 9 ) ) * 16777216) ) ; 
                    __context__.SourceCodeLine = 37;
                    Trace( "Byte 9 {0:d}", (int)TEMP[ 1 ]) ; 
                    __context__.SourceCodeLine = 38;
                    TEMP [ 2] = (uint) ( (Byte( RX_FROM_PROJ , (int)( 8 ) ) * 65536) ) ; 
                    __context__.SourceCodeLine = 39;
                    Trace( "Byte 8 {0:d}", (int)TEMP[ 2 ]) ; 
                    __context__.SourceCodeLine = 40;
                    TEMP [ 3] = (uint) ( (Byte( RX_FROM_PROJ , (int)( 7 ) ) * 256) ) ; 
                    __context__.SourceCodeLine = 41;
                    Trace( "Byte 7 {0:d}", (int)TEMP[ 3 ]) ; 
                    __context__.SourceCodeLine = 42;
                    TEMP [ 4] = (uint) ( Byte( RX_FROM_PROJ , (int)( 6 ) ) ) ; 
                    __context__.SourceCodeLine = 43;
                    Trace( "Byte 6 {0:d}", (int)TEMP[ 4 ]) ; 
                    __context__.SourceCodeLine = 45;
                    ILAMP_HOURS_REMAINING = (uint) ( ((7200000 - (((TEMP[ 4 ] + TEMP[ 3 ]) + TEMP[ 2 ]) + TEMP[ 1 ])) / 3600) ) ; 
                    __context__.SourceCodeLine = 46;
                    ILAMP_HOURS = (uint) ( ((((TEMP[ 4 ] + TEMP[ 3 ]) + TEMP[ 2 ]) + TEMP[ 1 ]) / 3600) ) ; 
                    __context__.SourceCodeLine = 48;
                    Trace( "Final {0:d}", (int)ILAMP_HOURS) ; 
                    __context__.SourceCodeLine = 50;
                    LAMP_HOURS  .Value = (ushort) ( ILAMP_HOURS ) ; 
                    __context__.SourceCodeLine = 51;
                    LAMP_HOURS_REMAINING  .Value = (ushort) ( ILAMP_HOURS_REMAINING ) ; 
                    __context__.SourceCodeLine = 52;
                    LAMP_HOURS_REMAINING__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( ILAMP_HOURS_REMAINING ) )  ) ; 
                    __context__.SourceCodeLine = 53;
                    LAMP_HOURS__DOLLAR__  .UpdateValue ( Functions.LtoA (  (int) ( ILAMP_HOURS ) )  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        TEMP  = new uint[ 5 ];
        
        LAMP_HOURS = new Crestron.Logos.SplusObjects.AnalogOutput( LAMP_HOURS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( LAMP_HOURS__AnalogSerialOutput__, LAMP_HOURS );
        
        LAMP_HOURS_REMAINING = new Crestron.Logos.SplusObjects.AnalogOutput( LAMP_HOURS_REMAINING__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( LAMP_HOURS_REMAINING__AnalogSerialOutput__, LAMP_HOURS_REMAINING );
        
        RX_FROM_PROJ = new Crestron.Logos.SplusObjects.StringInput( RX_FROM_PROJ__AnalogSerialInput__, 100, this );
        m_StringInputList.Add( RX_FROM_PROJ__AnalogSerialInput__, RX_FROM_PROJ );
        
        LAMP_HOURS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( LAMP_HOURS__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( LAMP_HOURS__DOLLAR____AnalogSerialOutput__, LAMP_HOURS__DOLLAR__ );
        
        LAMP_HOURS_REMAINING__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( LAMP_HOURS_REMAINING__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( LAMP_HOURS_REMAINING__DOLLAR____AnalogSerialOutput__, LAMP_HOURS_REMAINING__DOLLAR__ );
        
        
        RX_FROM_PROJ.OnSerialChange.Add( new InputChangeHandlerWrapper( RX_FROM_PROJ_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_NEC_PA550W_LAMP_HOUR_PARSE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RX_FROM_PROJ__AnalogSerialInput__ = 0;
    const uint LAMP_HOURS__AnalogSerialOutput__ = 0;
    const uint LAMP_HOURS_REMAINING__AnalogSerialOutput__ = 1;
    const uint LAMP_HOURS__DOLLAR____AnalogSerialOutput__ = 2;
    const uint LAMP_HOURS_REMAINING__DOLLAR____AnalogSerialOutput__ = 3;
    
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
