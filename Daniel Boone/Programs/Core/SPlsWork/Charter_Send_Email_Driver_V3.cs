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

namespace UserModule_CHARTER_SEND_EMAIL_DRIVER_V3
{
    public class UserModuleClass_CHARTER_SEND_EMAIL_DRIVER_V3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SEND_USER_MSG;
        Crestron.Logos.SplusObjects.DigitalInput SEND_SYSTEM_MSG;
        Crestron.Logos.SplusObjects.DigitalInput SEND_TEST_MSG;
        Crestron.Logos.SplusObjects.StringInput SYSTEM_IP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput VTC_IP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput VTC_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput ROOM_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput STATE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput CITY__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput BUILDING__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput USER_MSG__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput SYSTEM_MSG__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput USER_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput USER_CONTACT__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput SUCCESS;
        Crestron.Logos.SplusObjects.DigitalOutput PART_SUCCESS;
        Crestron.Logos.SplusObjects.DigitalOutput FAILURE;
        Crestron.Logos.SplusObjects.AnalogOutput ERROR_NUMBER;
        Crestron.Logos.SplusObjects.StringOutput ERROR_TEXT__DOLLAR__;
        StringParameter TO_FIELD;
        StringParameter FROM_FIELD;
        StringParameter CC_FIELD;
        StringParameter SERVER;
        StringParameter USER_NAME;
        StringParameter PASSWORD;
        short IERROR = 0;
        CrestronString SUBJECT;
        CrestronString MESSAGE;
        CrestronString DISCLAIMER;
        object SEND_USER_MSG_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 117;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SERVER  ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( FROM_FIELD  ) > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TO_FIELD  ) > 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 119;
                    PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 120;
                    SUCCESS  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 121;
                    FAILURE  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 122;
                    ERROR_TEXT__DOLLAR__  .UpdateValue ( "Sending e-mail. Please wait....."  ) ; 
                    __context__.SourceCodeLine = 123;
                    ERROR_NUMBER  .Value = (ushort) ( 1000 ) ; 
                    __context__.SourceCodeLine = 126;
                    MakeString ( SUBJECT , "User Generated message") ; 
                    __context__.SourceCodeLine = 127;
                    MakeString ( MESSAGE , "Room name: {0}\r\nRoom Location: {1}-{2}-{3}\r\nSystem IP Address: {4}\r\nCodec IP Address: {5}\r\nMessage: {6}\r\n\r\nUser Name: {7}\r\nUser Contact Info: {8}\r\n\r\n{9}", ROOM_NAME__DOLLAR__ , STATE__DOLLAR__ , CITY__DOLLAR__ , BUILDING__DOLLAR__ , SYSTEM_IP__DOLLAR__ , VTC_IP__DOLLAR__ , USER_MSG__DOLLAR__ , USER_NAME__DOLLAR__ , USER_CONTACT__DOLLAR__ , DISCLAIMER ) ; 
                    __context__.SourceCodeLine = 129;
                    IERROR = (short) ( SendMail( SERVER  , USER_NAME  , PASSWORD  , FROM_FIELD  , TO_FIELD  , CC_FIELD  , SUBJECT , MESSAGE ) ) ; 
                    __context__.SourceCodeLine = 138;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERROR >= 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 140;
                        switch ((int)IERROR)
                        
                            { 
                            case 0 : 
                            
                                { 
                                __context__.SourceCodeLine = 144;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 145;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 146;
                                SUCCESS  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 147;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Mail sent successfully."  ) ; 
                                __context__.SourceCodeLine = 148;
                                break ; 
                                } 
                            
                            goto case 3 ;
                            case 3 : 
                            
                                { 
                                __context__.SourceCodeLine = 152;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 153;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 154;
                                PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 155;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the To: list."  ) ; 
                                __context__.SourceCodeLine = 156;
                                break ; 
                                } 
                            
                            goto case 4 ;
                            case 4 : 
                            
                                { 
                                __context__.SourceCodeLine = 160;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 161;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 162;
                                PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 163;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the CC: list."  ) ; 
                                __context__.SourceCodeLine = 164;
                                break ; 
                                } 
                            
                            goto case 5 ;
                            case 5 : 
                            
                                { 
                                __context__.SourceCodeLine = 168;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 169;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 170;
                                PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 171;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error sending the message body."  ) ; 
                                __context__.SourceCodeLine = 172;
                                break ; 
                                } 
                            
                            goto default;
                            default : 
                            
                                { 
                                __context__.SourceCodeLine = 176;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 177;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 178;
                                PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 179;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Unknown Error."  ) ; 
                                __context__.SourceCodeLine = 180;
                                break ; 
                                } 
                            break;
                            
                            } 
                            
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 186;
                        IERROR = (short) ( Functions.ToSignedInteger( -( IERROR ) ) ) ; 
                        __context__.SourceCodeLine = 187;
                        switch ((int)IERROR)
                        
                            { 
                            case 1 : 
                            
                                { 
                                __context__.SourceCodeLine = 191;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 192;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 193;
                                FAILURE  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 194;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error in Server, From: or To: field."  ) ; 
                                __context__.SourceCodeLine = 195;
                                break ; 
                                } 
                            
                            goto case 3 ;
                            case 3 : 
                            
                                { 
                                __context__.SourceCodeLine = 199;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 200;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 201;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 202;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error connceting to mail server."  ) ; 
                                __context__.SourceCodeLine = 203;
                                break ; 
                                } 
                            
                            goto case 4 ;
                            case 4 : 
                            
                                { 
                                __context__.SourceCodeLine = 207;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 208;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 209;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 210;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error sending the message."  ) ; 
                                __context__.SourceCodeLine = 211;
                                break ; 
                                } 
                            
                            goto case 6 ;
                            case 6 : 
                            
                                { 
                                __context__.SourceCodeLine = 215;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 216;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 217;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 218;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error preparing to send the message."  ) ; 
                                __context__.SourceCodeLine = 219;
                                break ; 
                                } 
                            
                            goto case 7 ;
                            case 7 : 
                            
                                { 
                                __context__.SourceCodeLine = 223;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 224;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 225;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 226;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error buffering the message."  ) ; 
                                __context__.SourceCodeLine = 227;
                                break ; 
                                } 
                            
                            goto case 8 ;
                            case 8 : 
                            
                                { 
                                __context__.SourceCodeLine = 231;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 232;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 233;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 234;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error logging in to the server."  ) ; 
                                __context__.SourceCodeLine = 235;
                                break ; 
                                } 
                            
                            goto case 9 ;
                            case 9 : 
                            
                                { 
                                __context__.SourceCodeLine = 239;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 240;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 241;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 242;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, server does not support Authentication login."  ) ; 
                                __context__.SourceCodeLine = 243;
                                break ; 
                                } 
                            
                            goto default;
                            default : 
                            
                                { 
                                __context__.SourceCodeLine = 247;
                                SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 248;
                                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 249;
                                FAILURE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 250;
                                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, unknown error."  ) ; 
                                __context__.SourceCodeLine = 251;
                                break ; 
                                } 
                            break;
                            
                            } 
                            
                        
                        } 
                    
                    __context__.SourceCodeLine = 255;
                    ERROR_NUMBER  .Value = (ushort) ( IERROR ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SEND_SYSTEM_MSG_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 261;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SERVER  ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( FROM_FIELD  ) > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TO_FIELD  ) > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 263;
                PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 264;
                SUCCESS  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 265;
                FAILURE  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 266;
                ERROR_TEXT__DOLLAR__  .UpdateValue ( "Sending e-mail. Please wait....."  ) ; 
                __context__.SourceCodeLine = 267;
                ERROR_NUMBER  .Value = (ushort) ( 1000 ) ; 
                __context__.SourceCodeLine = 270;
                MakeString ( SUBJECT , "System Generated message") ; 
                __context__.SourceCodeLine = 271;
                MakeString ( MESSAGE , "Room name: {0}\r\nRoom Location: {1}-{2}-{3}\r\nSystem IP Address: {4}\r\nCodec IP Address: {5}\r\n\r\nMessage: {6}\r\n\r\n{7}", ROOM_NAME__DOLLAR__ , STATE__DOLLAR__ , CITY__DOLLAR__ , BUILDING__DOLLAR__ , SYSTEM_IP__DOLLAR__ , VTC_IP__DOLLAR__ , SYSTEM_MSG__DOLLAR__ , DISCLAIMER ) ; 
                __context__.SourceCodeLine = 273;
                IERROR = (short) ( SendMail( SERVER  , USER_NAME  , PASSWORD  , FROM_FIELD  , TO_FIELD  , CC_FIELD  , SUBJECT , MESSAGE ) ) ; 
                __context__.SourceCodeLine = 282;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERROR >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 284;
                    switch ((int)IERROR)
                    
                        { 
                        case 0 : 
                        
                            { 
                            __context__.SourceCodeLine = 288;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 289;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 290;
                            SUCCESS  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 291;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Mail sent successfully."  ) ; 
                            __context__.SourceCodeLine = 292;
                            break ; 
                            } 
                        
                        goto case 3 ;
                        case 3 : 
                        
                            { 
                            __context__.SourceCodeLine = 296;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 297;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 298;
                            PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 299;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the To: list."  ) ; 
                            __context__.SourceCodeLine = 300;
                            break ; 
                            } 
                        
                        goto case 4 ;
                        case 4 : 
                        
                            { 
                            __context__.SourceCodeLine = 304;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 305;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 306;
                            PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 307;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the CC: list."  ) ; 
                            __context__.SourceCodeLine = 308;
                            break ; 
                            } 
                        
                        goto case 5 ;
                        case 5 : 
                        
                            { 
                            __context__.SourceCodeLine = 312;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 313;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 314;
                            PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 315;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error sending the message body."  ) ; 
                            __context__.SourceCodeLine = 316;
                            break ; 
                            } 
                        
                        goto default;
                        default : 
                        
                            { 
                            __context__.SourceCodeLine = 320;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 321;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 322;
                            PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 323;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Unknown Error."  ) ; 
                            __context__.SourceCodeLine = 324;
                            break ; 
                            } 
                        break;
                        
                        } 
                        
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 330;
                    IERROR = (short) ( Functions.ToSignedInteger( -( IERROR ) ) ) ; 
                    __context__.SourceCodeLine = 331;
                    switch ((int)IERROR)
                    
                        { 
                        case 1 : 
                        
                            { 
                            __context__.SourceCodeLine = 335;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 336;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 337;
                            FAILURE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 338;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error in Server, From: or To: field."  ) ; 
                            __context__.SourceCodeLine = 339;
                            break ; 
                            } 
                        
                        goto case 3 ;
                        case 3 : 
                        
                            { 
                            __context__.SourceCodeLine = 343;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 344;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 345;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 346;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error connceting to mail server."  ) ; 
                            __context__.SourceCodeLine = 347;
                            break ; 
                            } 
                        
                        goto case 4 ;
                        case 4 : 
                        
                            { 
                            __context__.SourceCodeLine = 351;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 352;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 353;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 354;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error sending the message."  ) ; 
                            __context__.SourceCodeLine = 355;
                            break ; 
                            } 
                        
                        goto case 6 ;
                        case 6 : 
                        
                            { 
                            __context__.SourceCodeLine = 359;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 360;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 361;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 362;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error preparing to send the message."  ) ; 
                            __context__.SourceCodeLine = 363;
                            break ; 
                            } 
                        
                        goto case 7 ;
                        case 7 : 
                        
                            { 
                            __context__.SourceCodeLine = 367;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 368;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 369;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 370;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error buffering the message."  ) ; 
                            __context__.SourceCodeLine = 371;
                            break ; 
                            } 
                        
                        goto case 8 ;
                        case 8 : 
                        
                            { 
                            __context__.SourceCodeLine = 375;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 376;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 377;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 378;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error logging in to the server."  ) ; 
                            __context__.SourceCodeLine = 379;
                            break ; 
                            } 
                        
                        goto case 9 ;
                        case 9 : 
                        
                            { 
                            __context__.SourceCodeLine = 383;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 384;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 385;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 386;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, server does not support Authentication login."  ) ; 
                            __context__.SourceCodeLine = 387;
                            break ; 
                            } 
                        
                        goto default;
                        default : 
                        
                            { 
                            __context__.SourceCodeLine = 391;
                            SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 392;
                            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 393;
                            FAILURE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 394;
                            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, unknown error."  ) ; 
                            __context__.SourceCodeLine = 395;
                            break ; 
                            } 
                        break;
                        
                        } 
                        
                    
                    } 
                
                __context__.SourceCodeLine = 399;
                ERROR_NUMBER  .Value = (ushort) ( IERROR ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SEND_TEST_MSG_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 405;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SERVER  ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( FROM_FIELD  ) > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TO_FIELD  ) > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 407;
            PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 408;
            SUCCESS  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 409;
            FAILURE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 410;
            ERROR_TEXT__DOLLAR__  .UpdateValue ( "Sending e-mail. Please wait....."  ) ; 
            __context__.SourceCodeLine = 411;
            ERROR_NUMBER  .Value = (ushort) ( 1000 ) ; 
            __context__.SourceCodeLine = 414;
            MakeString ( SUBJECT , "Test message sent from room system") ; 
            __context__.SourceCodeLine = 415;
            MakeString ( MESSAGE , "Room name: {0}\r\nRoom Location: {1}-{2}-{3}\r\nSystem IP Address: {4}\r\n\r\nMessage: This message is a test to see if the email system is functioning properly.\r\n\r\n{5}", ROOM_NAME__DOLLAR__ , STATE__DOLLAR__ , CITY__DOLLAR__ , BUILDING__DOLLAR__ , SYSTEM_IP__DOLLAR__ , DISCLAIMER ) ; 
            __context__.SourceCodeLine = 417;
            IERROR = (short) ( SendMail( SERVER  , USER_NAME  , PASSWORD  , FROM_FIELD  , TO_FIELD  , CC_FIELD  , SUBJECT , MESSAGE ) ) ; 
            __context__.SourceCodeLine = 426;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERROR >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 428;
                switch ((int)IERROR)
                
                    { 
                    case 0 : 
                    
                        { 
                        __context__.SourceCodeLine = 432;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 433;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 434;
                        SUCCESS  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 435;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Mail sent successfully."  ) ; 
                        __context__.SourceCodeLine = 436;
                        break ; 
                        } 
                    
                    goto case 3 ;
                    case 3 : 
                    
                        { 
                        __context__.SourceCodeLine = 440;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 441;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 442;
                        PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 443;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the To: list."  ) ; 
                        __context__.SourceCodeLine = 444;
                        break ; 
                        } 
                    
                    goto case 4 ;
                    case 4 : 
                    
                        { 
                        __context__.SourceCodeLine = 448;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 449;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 450;
                        PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 451;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error in the CC: list."  ) ; 
                        __context__.SourceCodeLine = 452;
                        break ; 
                        } 
                    
                    goto case 5 ;
                    case 5 : 
                    
                        { 
                        __context__.SourceCodeLine = 456;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 457;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 458;
                        PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 459;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message sent with an error sending the message body."  ) ; 
                        __context__.SourceCodeLine = 460;
                        break ; 
                        } 
                    
                    goto default;
                    default : 
                    
                        { 
                        __context__.SourceCodeLine = 464;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 465;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 466;
                        PART_SUCCESS  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 467;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Unknown Error."  ) ; 
                        __context__.SourceCodeLine = 468;
                        break ; 
                        } 
                    break;
                    
                    } 
                    
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 474;
                IERROR = (short) ( Functions.ToSignedInteger( -( IERROR ) ) ) ; 
                __context__.SourceCodeLine = 475;
                switch ((int)IERROR)
                
                    { 
                    case 1 : 
                    
                        { 
                        __context__.SourceCodeLine = 479;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 480;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 481;
                        FAILURE  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 482;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error in Server, From: or To: field."  ) ; 
                        __context__.SourceCodeLine = 483;
                        break ; 
                        } 
                    
                    goto case 3 ;
                    case 3 : 
                    
                        { 
                        __context__.SourceCodeLine = 487;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 488;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 489;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 490;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error connceting to mail server."  ) ; 
                        __context__.SourceCodeLine = 491;
                        break ; 
                        } 
                    
                    goto case 4 ;
                    case 4 : 
                    
                        { 
                        __context__.SourceCodeLine = 495;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 496;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 497;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 498;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error sending the message."  ) ; 
                        __context__.SourceCodeLine = 499;
                        break ; 
                        } 
                    
                    goto case 6 ;
                    case 6 : 
                    
                        { 
                        __context__.SourceCodeLine = 503;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 504;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 505;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 506;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error preparing to send the message."  ) ; 
                        __context__.SourceCodeLine = 507;
                        break ; 
                        } 
                    
                    goto case 7 ;
                    case 7 : 
                    
                        { 
                        __context__.SourceCodeLine = 511;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 512;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 513;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 514;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error buffering the message."  ) ; 
                        __context__.SourceCodeLine = 515;
                        break ; 
                        } 
                    
                    goto case 8 ;
                    case 8 : 
                    
                        { 
                        __context__.SourceCodeLine = 519;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 520;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 521;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 522;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, error logging in to the server."  ) ; 
                        __context__.SourceCodeLine = 523;
                        break ; 
                        } 
                    
                    goto case 9 ;
                    case 9 : 
                    
                        { 
                        __context__.SourceCodeLine = 527;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 528;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 529;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 530;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, server does not support Authentication login."  ) ; 
                        __context__.SourceCodeLine = 531;
                        break ; 
                        } 
                    
                    goto default;
                    default : 
                    
                        { 
                        __context__.SourceCodeLine = 535;
                        SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 536;
                        PART_SUCCESS  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 537;
                        FAILURE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 538;
                        ERROR_TEXT__DOLLAR__  .UpdateValue ( "Message not sent, unknown error."  ) ; 
                        __context__.SourceCodeLine = 539;
                        break ; 
                        } 
                    break;
                    
                    } 
                    
                
                } 
            
            __context__.SourceCodeLine = 543;
            ERROR_NUMBER  .Value = (ushort) ( IERROR ) ; 
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
        
        __context__.SourceCodeLine = 562;
        IERROR = (short) ( 0 ) ; 
        __context__.SourceCodeLine = 563;
        ERROR_TEXT__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 564;
        ERROR_NUMBER  .Value = (ushort) ( 1000 ) ; 
        __context__.SourceCodeLine = 565;
        SUBJECT  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 566;
        MESSAGE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 567;
        DISCLAIMER  .UpdateValue ( "This message was sent from the Crestron control system in an integrated conference room on the Charter network. If you are not the intended recipient of this message, please disregard. For problems with this message please contact the Charter conferencing admin at 704-731-3821"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SUBJECT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    MESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
    DISCLAIMER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
    
    SEND_USER_MSG = new Crestron.Logos.SplusObjects.DigitalInput( SEND_USER_MSG__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_USER_MSG__DigitalInput__, SEND_USER_MSG );
    
    SEND_SYSTEM_MSG = new Crestron.Logos.SplusObjects.DigitalInput( SEND_SYSTEM_MSG__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_SYSTEM_MSG__DigitalInput__, SEND_SYSTEM_MSG );
    
    SEND_TEST_MSG = new Crestron.Logos.SplusObjects.DigitalInput( SEND_TEST_MSG__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_TEST_MSG__DigitalInput__, SEND_TEST_MSG );
    
    SUCCESS = new Crestron.Logos.SplusObjects.DigitalOutput( SUCCESS__DigitalOutput__, this );
    m_DigitalOutputList.Add( SUCCESS__DigitalOutput__, SUCCESS );
    
    PART_SUCCESS = new Crestron.Logos.SplusObjects.DigitalOutput( PART_SUCCESS__DigitalOutput__, this );
    m_DigitalOutputList.Add( PART_SUCCESS__DigitalOutput__, PART_SUCCESS );
    
    FAILURE = new Crestron.Logos.SplusObjects.DigitalOutput( FAILURE__DigitalOutput__, this );
    m_DigitalOutputList.Add( FAILURE__DigitalOutput__, FAILURE );
    
    ERROR_NUMBER = new Crestron.Logos.SplusObjects.AnalogOutput( ERROR_NUMBER__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ERROR_NUMBER__AnalogSerialOutput__, ERROR_NUMBER );
    
    SYSTEM_IP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SYSTEM_IP__DOLLAR____AnalogSerialInput__, 25, this );
    m_StringInputList.Add( SYSTEM_IP__DOLLAR____AnalogSerialInput__, SYSTEM_IP__DOLLAR__ );
    
    VTC_IP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( VTC_IP__DOLLAR____AnalogSerialInput__, 25, this );
    m_StringInputList.Add( VTC_IP__DOLLAR____AnalogSerialInput__, VTC_IP__DOLLAR__ );
    
    VTC_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( VTC_NAME__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( VTC_NAME__DOLLAR____AnalogSerialInput__, VTC_NAME__DOLLAR__ );
    
    ROOM_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ROOM_NAME__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ROOM_NAME__DOLLAR____AnalogSerialInput__, ROOM_NAME__DOLLAR__ );
    
    STATE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( STATE__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( STATE__DOLLAR____AnalogSerialInput__, STATE__DOLLAR__ );
    
    CITY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( CITY__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( CITY__DOLLAR____AnalogSerialInput__, CITY__DOLLAR__ );
    
    BUILDING__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( BUILDING__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( BUILDING__DOLLAR____AnalogSerialInput__, BUILDING__DOLLAR__ );
    
    USER_MSG__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( USER_MSG__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( USER_MSG__DOLLAR____AnalogSerialInput__, USER_MSG__DOLLAR__ );
    
    SYSTEM_MSG__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SYSTEM_MSG__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( SYSTEM_MSG__DOLLAR____AnalogSerialInput__, SYSTEM_MSG__DOLLAR__ );
    
    USER_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( USER_NAME__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( USER_NAME__DOLLAR____AnalogSerialInput__, USER_NAME__DOLLAR__ );
    
    USER_CONTACT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( USER_CONTACT__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( USER_CONTACT__DOLLAR____AnalogSerialInput__, USER_CONTACT__DOLLAR__ );
    
    ERROR_TEXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ERROR_TEXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ERROR_TEXT__DOLLAR____AnalogSerialOutput__, ERROR_TEXT__DOLLAR__ );
    
    TO_FIELD = new StringParameter( TO_FIELD__Parameter__, this );
    m_ParameterList.Add( TO_FIELD__Parameter__, TO_FIELD );
    
    FROM_FIELD = new StringParameter( FROM_FIELD__Parameter__, this );
    m_ParameterList.Add( FROM_FIELD__Parameter__, FROM_FIELD );
    
    CC_FIELD = new StringParameter( CC_FIELD__Parameter__, this );
    m_ParameterList.Add( CC_FIELD__Parameter__, CC_FIELD );
    
    SERVER = new StringParameter( SERVER__Parameter__, this );
    m_ParameterList.Add( SERVER__Parameter__, SERVER );
    
    USER_NAME = new StringParameter( USER_NAME__Parameter__, this );
    m_ParameterList.Add( USER_NAME__Parameter__, USER_NAME );
    
    PASSWORD = new StringParameter( PASSWORD__Parameter__, this );
    m_ParameterList.Add( PASSWORD__Parameter__, PASSWORD );
    
    
    SEND_USER_MSG.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_USER_MSG_OnPush_0, false ) );
    SEND_SYSTEM_MSG.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_SYSTEM_MSG_OnPush_1, false ) );
    SEND_TEST_MSG.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_TEST_MSG_OnPush_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_CHARTER_SEND_EMAIL_DRIVER_V3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SEND_USER_MSG__DigitalInput__ = 0;
const uint SEND_SYSTEM_MSG__DigitalInput__ = 1;
const uint SEND_TEST_MSG__DigitalInput__ = 2;
const uint SYSTEM_IP__DOLLAR____AnalogSerialInput__ = 0;
const uint VTC_IP__DOLLAR____AnalogSerialInput__ = 1;
const uint VTC_NAME__DOLLAR____AnalogSerialInput__ = 2;
const uint ROOM_NAME__DOLLAR____AnalogSerialInput__ = 3;
const uint STATE__DOLLAR____AnalogSerialInput__ = 4;
const uint CITY__DOLLAR____AnalogSerialInput__ = 5;
const uint BUILDING__DOLLAR____AnalogSerialInput__ = 6;
const uint USER_MSG__DOLLAR____AnalogSerialInput__ = 7;
const uint SYSTEM_MSG__DOLLAR____AnalogSerialInput__ = 8;
const uint USER_NAME__DOLLAR____AnalogSerialInput__ = 9;
const uint USER_CONTACT__DOLLAR____AnalogSerialInput__ = 10;
const uint SUCCESS__DigitalOutput__ = 0;
const uint PART_SUCCESS__DigitalOutput__ = 1;
const uint FAILURE__DigitalOutput__ = 2;
const uint ERROR_NUMBER__AnalogSerialOutput__ = 0;
const uint ERROR_TEXT__DOLLAR____AnalogSerialOutput__ = 1;
const uint TO_FIELD__Parameter__ = 10;
const uint FROM_FIELD__Parameter__ = 11;
const uint CC_FIELD__Parameter__ = 12;
const uint SERVER__Parameter__ = 13;
const uint USER_NAME__Parameter__ = 14;
const uint PASSWORD__Parameter__ = 15;

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
