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

namespace CrestronModule_CEC_ACTIVE_SOURCE_V1_0
{
    public class CrestronModuleClass_CEC_ACTIVE_SOURCE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.StringInput PHYSICALADDRESS;
        Crestron.Logos.SplusObjects.StringOutput ACTIVESOURCECOMMAND;
        CrestronString ACTIVESOURCE;
        object PHYSICALADDRESS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 52;
                ACTIVESOURCE  .UpdateValue ( "\u004f\u0082"  ) ; 
                __context__.SourceCodeLine = 56;
                ACTIVESOURCECOMMAND  .UpdateValue ( ACTIVESOURCE + PHYSICALADDRESS  ) ; 
                
                
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
            
            __context__.SourceCodeLine = 105;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        ACTIVESOURCE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
        
        PHYSICALADDRESS = new Crestron.Logos.SplusObjects.StringInput( PHYSICALADDRESS__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( PHYSICALADDRESS__AnalogSerialInput__, PHYSICALADDRESS );
        
        ACTIVESOURCECOMMAND = new Crestron.Logos.SplusObjects.StringOutput( ACTIVESOURCECOMMAND__AnalogSerialOutput__, this );
        m_StringOutputList.Add( ACTIVESOURCECOMMAND__AnalogSerialOutput__, ACTIVESOURCECOMMAND );
        
        
        PHYSICALADDRESS.OnSerialChange.Add( new InputChangeHandlerWrapper( PHYSICALADDRESS_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_CEC_ACTIVE_SOURCE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint PHYSICALADDRESS__AnalogSerialInput__ = 0;
    const uint ACTIVESOURCECOMMAND__AnalogSerialOutput__ = 0;
    
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
