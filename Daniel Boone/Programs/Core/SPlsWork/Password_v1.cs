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

namespace UserModule_PASSWORD_V1
{
    public class UserModuleClass_PASSWORD_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENTER_PASSWORD;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR_NUMBER;
        Crestron.Logos.SplusObjects.DigitalInput NEW_PASSWORD;
        Crestron.Logos.SplusObjects.DigitalInput EXIT_PASSWORD;
        Crestron.Logos.SplusObjects.DigitalInput LOCK_PANEL;
        Crestron.Logos.SplusObjects.DigitalInput ENTERNEEDED;
        Crestron.Logos.SplusObjects.DigitalInput SHOWASTERISK;
        Crestron.Logos.SplusObjects.AnalogInput PASSWORD_NUMBER;
        Crestron.Logos.SplusObjects.AnalogInput PASSWORD_MAX_LEN;
        Crestron.Logos.SplusObjects.StringInput BACKDOOR_PASSWORD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORD_CORRECT;
        Crestron.Logos.SplusObjects.DigitalOutput NEW_PASSWORD_FB;
        Crestron.Logos.SplusObjects.DigitalOutput NEW_PASSWORD_REQ;
        Crestron.Logos.SplusObjects.DigitalOutput PANEL_LOCKED;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORD_PAGE_FLIP;
        Crestron.Logos.SplusObjects.StringOutput PASSWORD_TXT__DOLLAR__;
        
        object ENTER_PASSWORD_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 108;
                if ( Functions.TestForTrue  ( ( (Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ == BACKDOOR_PASSWORD__DOLLAR__) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ == _SplusNVRAM.NEW_PASSWORD__DOLLAR__) )) ) & Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 110;
                    if ( Functions.TestForTrue  ( ( (Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0) & Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 1)))  ) ) 
                        { 
                        __context__.SourceCodeLine = 112;
                        NEW_PASSWORD_REQ  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 113;
                        NEW_PASSWORD_FB  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 114;
                        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 115;
                        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 116;
                        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter New Passcode"  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 120;
                        Functions.Pulse ( 30, PASSWORD_CORRECT ) ; 
                        __context__.SourceCodeLine = 121;
                        PANEL_LOCKED  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 122;
                        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 123;
                        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 124;
                        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Correct!"  ) ; 
                        __context__.SourceCodeLine = 125;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_10__" , 200 , __SPLS_TMPVAR__WAITLABEL_10___Callback ) ;
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 129;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 131;
                        _SplusNVRAM.NEW_PASSWORD__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  ) ; 
                        __context__.SourceCodeLine = 132;
                        NEW_PASSWORD_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 133;
                        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 134;
                        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 135;
                        _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 136;
                        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "New Passcode Stored"  ) ; 
                        __context__.SourceCodeLine = 137;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_11__" , 200 , __SPLS_TMPVAR__WAITLABEL_11___Callback ) ;
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 143;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 145;
                            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Invalid Passcode\rPlease Try Again"  ) ; 
                            __context__.SourceCodeLine = 146;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 147;
                            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 148;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_12__" , 200 , __SPLS_TMPVAR__WAITLABEL_12___Callback ) ;
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 153;
                            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Invalid Passcode\rPlease Try Again"  ) ; 
                            __context__.SourceCodeLine = 154;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 155;
                            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 156;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_13__" , 200 , __SPLS_TMPVAR__WAITLABEL_13___Callback ) ;
                            } 
                        
                        }
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_10___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            {
            __context__.SourceCodeLine = 126;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
public void __SPLS_TMPVAR__WAITLABEL_11___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 139;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 140;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Current Passcode"  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_12___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 149;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Current Passcode"  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_13___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 157;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object CLEAR_NUMBER_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 163;
        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 164;
        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 165;
        _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 166;
        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EXIT_PASSWORD_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 171;
        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 172;
        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 173;
        _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 174;
        NEW_PASSWORD_REQ  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 175;
        NEW_PASSWORD_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 176;
        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NEW_PASSWORD_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 181;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 183;
            NEW_PASSWORD_REQ  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 184;
            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 185;
            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 186;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Current Passcode"  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 190;
            NEW_PASSWORD_REQ  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 191;
            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 192;
            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 193;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Current Passcode"  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LOCK_PANEL_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 199;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PANEL_LOCKED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 201;
            Functions.Pulse ( 30, PASSWORD_PAGE_FLIP ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 205;
            PANEL_LOCKED  .Value = (ushort) ( 1 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PASSWORD_NUMBER_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 213;
        _SplusNVRAM.PASSWORD_LEN = (ushort) ( (Functions.Length( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ ) + 1) ) ; 
        __context__.SourceCodeLine = 214;
        _SplusNVRAM.NEW_PASSWORD_LEN = (ushort) ( (Functions.Length( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ ) + 1) ) ; 
        __context__.SourceCodeLine = 215;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PASSWORD_LEN < (PASSWORD_MAX_LEN  .UshortValue + 1) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.NEW_PASSWORD_LEN < (PASSWORD_MAX_LEN  .UshortValue + 1) ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 217;
            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__ + "*"  ) ; 
            __context__.SourceCodeLine = 218;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 220;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)PASSWORD_NUMBER  .UshortValue);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 48) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 222;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "0"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 49) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 223;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "1"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 50) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 224;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "2"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 51) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 225;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "3"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 52) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 226;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "4"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 53) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 227;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "5"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 54) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 228;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "6"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 55) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 229;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "7"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 56) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 230;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "8"  ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 57) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 231;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ + "9"  ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                __context__.SourceCodeLine = 233;
                if ( Functions.TestForTrue  ( ( SHOWASTERISK  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 235;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 239;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 242;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 244;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_2__ = ((int)PASSWORD_NUMBER  .UshortValue);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 48) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 246;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "0"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 49) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 247;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "1"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 50) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 248;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "2"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 51) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 249;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "3"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 52) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 250;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "4"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 53) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 251;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "5"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 54) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 252;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "6"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 55) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 253;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "7"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 56) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 254;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "8"  ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 57) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 255;
                                _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__ + "9"  ) ; 
                                } 
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 257;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  ) ; 
                    } 
                
                }
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 262;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Maxium Number Of\rDigits = " + Functions.ItoA (  (int) ( PASSWORD_MAX_LEN  .UshortValue ) )  ) ; 
            __context__.SourceCodeLine = 263;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_14__" , 200 , __SPLS_TMPVAR__WAITLABEL_14___Callback ) ;
            } 
        
        __context__.SourceCodeLine = 282;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENTERNEEDED  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 284;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ == BACKDOOR_PASSWORD__DOLLAR__) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.PASSWORD_ENTERED__DOLLAR__ == _SplusNVRAM.NEW_PASSWORD__DOLLAR__) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 286;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 288;
                    NEW_PASSWORD_REQ  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 289;
                    NEW_PASSWORD_FB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 290;
                    _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 291;
                    _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 292;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter New Passcode"  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 296;
                    Functions.Pulse ( 30, PASSWORD_CORRECT ) ; 
                    __context__.SourceCodeLine = 297;
                    PANEL_LOCKED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 298;
                    _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 299;
                    _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 300;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Correct!"  ) ; 
                    __context__.SourceCodeLine = 301;
                    CreateWait ( "__SPLS_TMPVAR__WAITLABEL_15__" , 200 , __SPLS_TMPVAR__WAITLABEL_15___Callback ) ;
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 305;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.PASSWORD_LEN == (PASSWORD_MAX_LEN  .UshortValue + 1)) ) || Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.NEW_PASSWORD_LEN == (PASSWORD_MAX_LEN  .UshortValue + 1)) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 308;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 310;
                        _SplusNVRAM.NEW_PASSWORD__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  ) ; 
                        __context__.SourceCodeLine = 311;
                        NEW_PASSWORD_FB  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 312;
                        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 313;
                        _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 314;
                        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 315;
                        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "New Passcode Stored"  ) ; 
                        __context__.SourceCodeLine = 316;
                        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_16__" , 200 , __SPLS_TMPVAR__WAITLABEL_16___Callback ) ;
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 322;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 324;
                            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Invalid Passcode\rPlease Try Again"  ) ; 
                            __context__.SourceCodeLine = 325;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 326;
                            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 327;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_17__" , 200 , __SPLS_TMPVAR__WAITLABEL_17___Callback ) ;
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 332;
                            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Invalid Passcode\rPlease Try Again"  ) ; 
                            __context__.SourceCodeLine = 333;
                            _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 334;
                            _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 335;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_18__" , 200 , __SPLS_TMPVAR__WAITLABEL_18___Callback ) ;
                            } 
                        
                        }
                    
                    } 
                
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_14___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 265;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 267;
                if ( Functions.TestForTrue  ( ( SHOWASTERISK  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 269;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 273;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 276;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_FB  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (NEW_PASSWORD_REQ  .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 278;
                    PASSWORD_TXT__DOLLAR__  .UpdateValue ( _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  ) ; 
                    } 
                
                }
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_15___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 302;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_16___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 318;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 319;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Current Passcode"  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_17___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 328;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public void __SPLS_TMPVAR__WAITLABEL_18___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 336;
            PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 358;
        _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 359;
        _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 360;
        NEW_PASSWORD_REQ  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 361;
        NEW_PASSWORD_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 362;
        PASSWORD_TXT__DOLLAR__  .UpdateValue ( "Enter Passcode"  ) ; 
        __context__.SourceCodeLine = 364;
        PANEL_LOCKED  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 365;
        _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.PASSWORD_ENTERED__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    _SplusNVRAM.NEW_PASSWORD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    _SplusNVRAM.NEW_PASSWORD_ENTERED__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    _SplusNVRAM.PRIVATE_PASSWORD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    ENTER_PASSWORD = new Crestron.Logos.SplusObjects.DigitalInput( ENTER_PASSWORD__DigitalInput__, this );
    m_DigitalInputList.Add( ENTER_PASSWORD__DigitalInput__, ENTER_PASSWORD );
    
    CLEAR_NUMBER = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR_NUMBER__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR_NUMBER__DigitalInput__, CLEAR_NUMBER );
    
    NEW_PASSWORD = new Crestron.Logos.SplusObjects.DigitalInput( NEW_PASSWORD__DigitalInput__, this );
    m_DigitalInputList.Add( NEW_PASSWORD__DigitalInput__, NEW_PASSWORD );
    
    EXIT_PASSWORD = new Crestron.Logos.SplusObjects.DigitalInput( EXIT_PASSWORD__DigitalInput__, this );
    m_DigitalInputList.Add( EXIT_PASSWORD__DigitalInput__, EXIT_PASSWORD );
    
    LOCK_PANEL = new Crestron.Logos.SplusObjects.DigitalInput( LOCK_PANEL__DigitalInput__, this );
    m_DigitalInputList.Add( LOCK_PANEL__DigitalInput__, LOCK_PANEL );
    
    ENTERNEEDED = new Crestron.Logos.SplusObjects.DigitalInput( ENTERNEEDED__DigitalInput__, this );
    m_DigitalInputList.Add( ENTERNEEDED__DigitalInput__, ENTERNEEDED );
    
    SHOWASTERISK = new Crestron.Logos.SplusObjects.DigitalInput( SHOWASTERISK__DigitalInput__, this );
    m_DigitalInputList.Add( SHOWASTERISK__DigitalInput__, SHOWASTERISK );
    
    PASSWORD_CORRECT = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORD_CORRECT__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASSWORD_CORRECT__DigitalOutput__, PASSWORD_CORRECT );
    
    NEW_PASSWORD_FB = new Crestron.Logos.SplusObjects.DigitalOutput( NEW_PASSWORD_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( NEW_PASSWORD_FB__DigitalOutput__, NEW_PASSWORD_FB );
    
    NEW_PASSWORD_REQ = new Crestron.Logos.SplusObjects.DigitalOutput( NEW_PASSWORD_REQ__DigitalOutput__, this );
    m_DigitalOutputList.Add( NEW_PASSWORD_REQ__DigitalOutput__, NEW_PASSWORD_REQ );
    
    PANEL_LOCKED = new Crestron.Logos.SplusObjects.DigitalOutput( PANEL_LOCKED__DigitalOutput__, this );
    m_DigitalOutputList.Add( PANEL_LOCKED__DigitalOutput__, PANEL_LOCKED );
    
    PASSWORD_PAGE_FLIP = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORD_PAGE_FLIP__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASSWORD_PAGE_FLIP__DigitalOutput__, PASSWORD_PAGE_FLIP );
    
    PASSWORD_NUMBER = new Crestron.Logos.SplusObjects.AnalogInput( PASSWORD_NUMBER__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PASSWORD_NUMBER__AnalogSerialInput__, PASSWORD_NUMBER );
    
    PASSWORD_MAX_LEN = new Crestron.Logos.SplusObjects.AnalogInput( PASSWORD_MAX_LEN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PASSWORD_MAX_LEN__AnalogSerialInput__, PASSWORD_MAX_LEN );
    
    BACKDOOR_PASSWORD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( BACKDOOR_PASSWORD__DOLLAR____AnalogSerialInput__, 6, this );
    m_StringInputList.Add( BACKDOOR_PASSWORD__DOLLAR____AnalogSerialInput__, BACKDOOR_PASSWORD__DOLLAR__ );
    
    PASSWORD_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PASSWORD_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( PASSWORD_TXT__DOLLAR____AnalogSerialOutput__, PASSWORD_TXT__DOLLAR__ );
    
    __SPLS_TMPVAR__WAITLABEL_10___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_10___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_11___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_11___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_12___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_12___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_13___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_13___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_14___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_14___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_15___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_15___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_16___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_16___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_17___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_17___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_18___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_18___CallbackFn );
    
    ENTER_PASSWORD.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENTER_PASSWORD_OnPush_0, false ) );
    CLEAR_NUMBER.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLEAR_NUMBER_OnPush_1, false ) );
    EXIT_PASSWORD.OnDigitalPush.Add( new InputChangeHandlerWrapper( EXIT_PASSWORD_OnPush_2, false ) );
    NEW_PASSWORD.OnDigitalPush.Add( new InputChangeHandlerWrapper( NEW_PASSWORD_OnPush_3, false ) );
    LOCK_PANEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOCK_PANEL_OnPush_4, false ) );
    PASSWORD_NUMBER.OnAnalogChange.Add( new InputChangeHandlerWrapper( PASSWORD_NUMBER_OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PASSWORD_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_10___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_11___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_12___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_13___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_14___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_15___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_16___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_17___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_18___Callback;


const uint ENTER_PASSWORD__DigitalInput__ = 0;
const uint CLEAR_NUMBER__DigitalInput__ = 1;
const uint NEW_PASSWORD__DigitalInput__ = 2;
const uint EXIT_PASSWORD__DigitalInput__ = 3;
const uint LOCK_PANEL__DigitalInput__ = 4;
const uint ENTERNEEDED__DigitalInput__ = 5;
const uint SHOWASTERISK__DigitalInput__ = 6;
const uint PASSWORD_NUMBER__AnalogSerialInput__ = 0;
const uint PASSWORD_MAX_LEN__AnalogSerialInput__ = 1;
const uint BACKDOOR_PASSWORD__DOLLAR____AnalogSerialInput__ = 2;
const uint PASSWORD_CORRECT__DigitalOutput__ = 0;
const uint NEW_PASSWORD_FB__DigitalOutput__ = 1;
const uint NEW_PASSWORD_REQ__DigitalOutput__ = 2;
const uint PANEL_LOCKED__DigitalOutput__ = 3;
const uint PASSWORD_PAGE_FLIP__DigitalOutput__ = 4;
const uint PASSWORD_TXT__DOLLAR____AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort PASSWORD_LEN = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort NEW_PASSWORD_LEN = 0;
            [SplusStructAttribute(2, false, true)]
            public CrestronString PASSWORD_ENTERED__DOLLAR__;
            [SplusStructAttribute(3, false, true)]
            public CrestronString NEW_PASSWORD__DOLLAR__;
            [SplusStructAttribute(4, false, true)]
            public CrestronString NEW_PASSWORD_ENTERED__DOLLAR__;
            [SplusStructAttribute(5, false, true)]
            public CrestronString PRIVATE_PASSWORD__DOLLAR__;
            
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
