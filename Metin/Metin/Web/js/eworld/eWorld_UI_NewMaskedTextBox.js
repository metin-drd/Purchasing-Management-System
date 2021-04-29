/*************************************************************************
* Excentrics World Masked Textbox Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.8
* Date Last Updated: January 27, 2004
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@Supported
/*************************************************************************
* Supported Javascript 
*************************************************************************/
var isOpera=navigator.userAgent.indexOf("Opera")>-1;
var isIE=(navigator.userAgent.indexOf("MSIE")>1&&!isOpera);
var isMoz=(navigator.userAgent.indexOf("Mozilla/5.")==0&&!isOpera);
var MaskCharStatus_LiteralChar=1;
var MaskCharStatus_DigitChar=2;
var MaskCharStatus_CustomAnsiChar=4;
var MaskCharStatus_UpperCaseChar=8;
var MaskCharStatus_LowerCaseChar=16;
var MaskCharStatus_AlphaNumericChar=32;
var MaskCharStatus_LetterChar=64;
var MaskCharStatus_RequiredChar=128;
var MaskCharStatus_Other=0;
var DigitMustPlaceHolder='0';
var CharPlaceHolder='&';
var AlphaNumericMustPlaceHolder='A';
var AlphaNumericOptionalPlaceHolder='a';
var DigitOptionalPlaceHolder='9';
var LetterPlaceHolder='?';
var EscapeChar='\\';
var UpperCaseChar='>';
var LowerCaseChar='<';
var MaskChars=new Array('0','&','A','a','9','?');
var Ignorechars=new Array('\\','>','<');
var _PromptChar='_';
var NullChar='\0';
var SpaceCharCode=' '.charCodeAt(0);
var CursorPosition=0;
var MaskCharStatusArray=new Array();

function mbx_IsStringEmpty(str){
	if(str==null||str=="")
		return true;
	return false;
}

function mbx_getKeyCode(evt){
	if(isIE)
		return evt.keyCode;
	else 
		if(isMoz)return evt.charCode;
}

function mbx_doSetCaretPosition(ctrl){
	if(isIE){
		if(ctrl.isTextEdit)
			ctrl.setAttribute("caretPos",document.selection.createRange());
	}
	else { }
}

function mbx_selectCursorPos(ctrl,iStart,iLength){iStart=iStart>=ctrl.value.length?iStart-1:iStart;
	if(isIE){
		var oRange=ctrl.createTextRange();
		oRange.moveStart("character",iStart);
		oRange.moveEnd("character",iLength+iStart-ctrl.value.length);
		oRange.select();
		ctrl.caretPos=oRange;
	} 
	else 
		if(isMoz)ctrl.setSelectionRange(iStart,iStart+iLength);
}

function mbx_getCursorPos(ctrl){
	var i=-1;
	if(isIE){
		if(ctrl.isTextEdit&&ctrl.caretPos) {
			if(ctrl.createTextRange){
				rg=document.selection.createRange().duplicate();
				rg.moveStart('textedit',-1);
				i=rg.text.length
			}
			else 
				if(ctrl.setSelectionRange){
					i=ctrl.selectionStart
				}
		}
	}
	else 
		i=ctrl.selectionStart;
	
	return i
}
function InsertInString(str,ZeroBasePosition,InputString){
	if(ZeroBasePosition>str.length)
		return str;
	
	str=str.substring(0,ZeroBasePosition)+InputString+str.substring(ZeroBasePosition,str.length);
	return str;
}

function RemoveFromString(str,ZeroBasePosition,NumberOfChar){
	if(ZeroBasePosition>str.length)
		return str;
	str=str.substring(0,ZeroBasePosition)+str.substring(ZeroBasePosition+NumberOfChar,str.length);
	return str;
}

function IsBlank(s){
	for(var i=0;i<s.length;i++){
		var c=s.charAt(i);
		if((c!=' '.charCodeAt(0))&&(c!='\n'.charCodeAt(0))&&(c!='\t'.charCodeAt(0)))
			return false;
	}
	
	return true;
}

function IsDigit(c){
	if((c>='0'.charCodeAt(0))&&(c<='9'.charCodeAt(0)))
		return true;
	else 
		return false;
}

function IsAlpha(c){
	if(((c>='A'.charCodeAt(0))&&(c<='Z'.charCodeAt(0)))||((c>='a'.charCodeAt(0))&&(c<='z'.charCodeAt(0))))
		return true;
	else 
		return false;
}

function IsAlphaNum(s){
	for(var i=0;i<s.length;i++){
		var c=s.charAt(i);
		if(!IsDigit(c)&&!IsAlpha(c))
			return false
	}
	return true;
}

function IsNum(s){
	for(var i=0;i<s.length;i++){
		var c=s.charAt(i);
		if(!IsDigit(c))
			return false
	}	
	return true;
}

function mbx_setMask(ctrl){
	var _Mask=ctrl.getAttribute("mask");
	if(mbx_IsStringEmpty(_Mask))
		return;
	ctrl.value="";
	var bPrevEscapeChar=false;
	for(var i=0;i<_Mask.length;i++){
		var Ch=_Mask.split('')[i];
		if(Ch==UpperCaseChar||Ch==LowerCaseChar)
			continue;
		if(!bPrevEscapeChar){
			if(Ch==EscapeChar){
				bPrevEscapeChar=true;
				continue;
			}
			if(IsMaskChar(Ch)){
				ctrl.value+=ctrl.getAttribute("promptchar").toString();
				continue;
			}
		}
		
		ctrl.value+=_Mask.split('')[i];
		bPrevEscapeChar=false;
	}
	
	ctrl.setAttribute("MaskString",ctrl.value);
}

function IsMaskChar(Ch){
	for(var mChInt in MaskChars){
		mCh=MaskChars[mChInt];
		if(mCh==Ch)
			return true;
	}
	
	return false;
}

function mbx_initMaskCharArray(ctrl){
	MaskCharStatusArray=new Array(ctrl.value.length);
	var UpperLowerCaseStatus=MaskCharStatus_Other;
	var Pos=0;
	var PrevEscapeChar=false;
	var maskArr=ctrl.getAttribute("mask").split('');
	for(var chInt in maskArr){
		var ch=maskArr[chInt];
		var CharStatus=0;
		if(ch==UpperCaseChar){UpperLowerCaseStatus=MaskCharStatus_UpperCaseChar;
			continue
		}
		else 
			if(ch==LowerCaseChar){
				UpperLowerCaseStatus=MaskCharStatus_LowerCaseChar;
				continue
			}
		
		if(PrevEscapeChar){
			PrevEscapeChar=false;
			MaskCharStatusArray[Pos]=(MaskCharStatus_RequiredChar|MaskCharStatus_LiteralChar);
			Pos++;
			continue;
		}
		
		if(ch==EscapeChar){
			PrevEscapeChar=true;
			continue;
		}
		
		switch(ch){
			case DigitMustPlaceHolder:
				CharStatus=(MaskCharStatus_RequiredChar|MaskCharStatus_DigitChar);
				break;

			case CharPlaceHolder:
				CharStatus=(MaskCharStatus_RequiredChar|MaskCharStatus_CustomAnsiChar|UpperLowerCaseStatus);
				break;
			case AlphaNumericMustPlaceHolder:
				CharStatus=(MaskCharStatus_RequiredChar|MaskCharStatus_DigitChar|MaskCharStatus_LetterChar|UpperLowerCaseStatus);
				break;
			case AlphaNumericOptionalPlaceHolder:
				CharStatus=(MaskCharStatus_DigitChar|MaskCharStatus_LetterChar|UpperLowerCaseStatus);
				break;
			case DigitOptionalPlaceHolder:
				CharStatus=(MaskCharStatus_DigitChar);
				break;
			case LetterPlaceHolder:
				CharStatus=(MaskCharStatus_RequiredChar|MaskCharStatus_LetterChar|UpperLowerCaseStatus);
				break;
			default:
				CharStatus=(MaskCharStatus_RequiredChar|MaskCharStatus_LiteralChar);
				break;
		}
		
		MaskCharStatusArray[Pos]=CharStatus;
		Pos++;
	}
}

function mbx_doFocus(ctrl){
	if(ctrl.getAttribute("isFirstTime")==null||ctrl.getAttribute("isFirstTime")=="true"){
		var ctrlValue=ctrl.value;
		mbx_Init(ctrl,ctrl.getAttribute("mask"));
		ctrl.setAttribute("isFirstTime","false");
		ctrl.setAttribute("isFirstClick","true");
		if(ctrlValue!=""){
			ctrl.value=ctrlValue;
			ctrl.value=mbx_formatControlValue(ctrl,true);
		}
		
		ctrl.setAttribute("LastValidValue",ctrl.value)
	}
	else {
		CursorPosition=ctrl.getAttribute("CursorPosition");
		MaskCharStatusArray=ctrl.getAttribute("MaskCharStatusArray").toString().split(",");
		ctrl.value=mbx_formatControlValue(ctrl,true)
	}
	
	if(ctrl.value=="")
		mbx_Init(ctrl,ctrl.getAttribute("mask"));
		
	mbx_checkAndPositionCursor(ctrl);
}

function mbx_doBlur(ctrl){
	if(ctrl.value==ctrl.getAttribute("MaskString")){
		ctrl.value="";
		ctrl.setAttribute("isFirstTime","true");
		return;
	}
	
	var isValid=mbx_validateFullValue(ctrl);
	if(!isValid){
		alert(ctrl.getAttribute("ErrorMessage").toString());
		if(ctrl.getAttribute("LastValidValue")!=null)
			ctrl.value=ctrl.getAttribute("LastValidValue");
		else 
			ctrl.value="";
		
		ctrl.setAttribute("isFirstTime","true")
	}
	else {
		ctrl.setAttribute("LastValidValue",ctrl.value);
		ctrl.value=mbx_formatControlValue(ctrl,false);
	}
	
	ctrl.setAttribute("CursorPosition",CursorPosition);
	ctrl.setAttribute("MaskCharStatusArray",MaskCharStatusArray);
}

function mbx_Init(ctrl,MaskString){
	ctrl.setAttribute("mask",MaskString);
	mbx_initMaskCharArray(ctrl);
	mbx_setMask(ctrl);
	ctrl.setAttribute("CursorPosition",0);
	ctrl.setAttribute("MaskCharStatusArray",MaskCharStatusArray);
	mbx_checkAndPositionCursor(ctrl);
}

function mbx_doMouseUp(ctrl,ctrlEvent){
	if(isOpera)
		return false;
	if(ctrl.getAttribute("isFirstClick")=="true"){
		ctrl.setAttribute("isFirstClick","false");
		var ipos=CursorPosition;
	}
	else{
		mbx_doSetCaretPosition(ctrl);
		var ipos=mbx_getCursorPos(ctrl)
	}
	if(ipos<MaskCharStatusArray.length&&!(MaskCharStatusArray[ipos]&MaskCharStatus_LiteralChar)==MaskCharStatus_LiteralChar){
		CursorPosition=ipos-1;
		mbx_setPosition(ctrl,1);
		mbx_selectCursorPos(ctrl,CursorPosition,1);
		return true
	} else {
		CursorPosition-=1;
		mbx_setPosition(ctrl,1);
		mbx_selectCursorPos(ctrl,CursorPosition,1);
	}
	return false;
}

function mbx_doKeyDown(ctrl,ctrlEvent){
	var keyData=ctrlEvent.keyCode;
	var Offset=0;
	ctrlEvent.cancelBubble=true;
	switch(keyData){
		case 39:
		case 40:
			if(CursorPosition<ctrl.value.length)
				Offset=1;
			else 
				Offset=-1;
			break;
			
		case 37:
		case 38:
			if(CursorPosition<0)
				Offset=1;
			else 
				Offset=-1;
			break;

		case 46:
			if(CursorPosition>=ctrl.value.length){
				Offset=-1;
				break;
			}
			Offset=0;
			ctrl.value=RemoveFromString(ctrl.value,CursorPosition,1);
			ctrl.value=InsertInString(ctrl.value,CursorPosition,ctrl.getAttribute("promptchar").toString());
			break;
			
		case 8:
			Offset=-1;
			if(CursorPosition>=ctrl.value.length)
				break;
			ctrl.value=RemoveFromString(ctrl.value,CursorPosition,1);
			ctrl.value=InsertInString(ctrl.value,CursorPosition,ctrl.getAttribute("promptchar").toString());
			break;
		
		case 36:
		case 33:
			CursorPosition=-1;
			Offset=1;
			break;
			
		case 35:
		case 34:
			CursorPosition=MaskCharStatusArray.length;
			Offset=-1;
			break;
			
		default:
			ctrlEvent.cancelBubble=false;
			return true;
	}
	
	mbx_setPosition(ctrl,Offset);
	return false;
}

function mbx_doKeyPress(ctrl,ctrlEvent){
	var keyData=mbx_getKeyCode(ctrlEvent);
	var InputChar=mbx_validate(ctrl,keyData);
	if(String.fromCharCode(InputChar)!=NullChar){
		var s=ctrl.value;
		var str=ctrl.value+":";
		s=RemoveFromString(s,CursorPosition,1);
		str+=s;
		s=InsertInString(s,CursorPosition,String.fromCharCode(InputChar));
		str+=":"+s;
		ctrl.value=s;
		mbx_setPosition(ctrl,1);
	}
	
	return false;
}

function mbx_checkAndPositionCursor(ctrl){
	var Text=ctrl.value.split('');
	var bCursorSet=false;
	for(var i=0;i<Text.length;i++){
		var ch=Text[i];
		if(ch==ctrl.getAttribute("promptchar")){
			mbx_selectCursorPos(ctrl,i,1);
			CursorPosition=i;
			bCursorSet=true;
			break;
		}
	}
	
	if(!bCursorSet){
		CursorPosition=-1;
		mbx_setPosition(ctrl,1);
	}
}

function mbx_validate(ctrl,ch){
	var status=MaskCharStatusArray[CursorPosition];
	var ReturnChar=NullChar;
	var PromptCharCode=ctrl.getAttribute("promptchar").charCodeAt(0);
	
	if((status&MaskCharStatus_RequiredChar)==MaskCharStatus_RequiredChar){
		if(ch==SpaceCharCode){
			if(ctrl.getAttribute("mask").split('')[CursorPosition]!=String.fromCharCode(SpaceCharCode))
				return ReturnChar;
		}
		
		if(ch==PromptCharCode&&((status&MaskCharStatus_LiteralChar)!=MaskCharStatus_LiteralChar))
			return ReturnChar;
	}
	else {
		if(ch==PromptCharCode)
			return PromptCharCode;
	}
	
	if((status&(MaskCharStatus_DigitChar|MaskCharStatus_LetterChar))==(MaskCharStatus_DigitChar|MaskCharStatus_LetterChar)){
		if(IsDigit(ch)||IsAlpha(ch)||ch==SpaceCharCode)
			ReturnChar=ch;
	}
	
	if((status&MaskCharStatus_LetterChar)==MaskCharStatus_LetterChar){
		if(IsAlpha(ch)||ch==SpaceCharCode)
			ReturnChar=ch;
	}
	
	if((status&MaskCharStatus_DigitChar)==MaskCharStatus_DigitChar){
		if(IsDigit(ch)||ch==SpaceCharCode)
			ReturnChar=ch;
	}
	
	if((status&MaskCharStatus_CustomAnsiChar)==MaskCharStatus_CustomAnsiChar){
		var AsciiCode=ch;
		if((AsciiCode>='32'&&AsciiCode<='255')&&AsciiCode!='127')
			ReturnChar=ch;
	}
	
	if((status&MaskCharStatus_LowerCaseChar)==MaskCharStatus_LowerCaseChar){
		ReturnChar=String.fromCharCode(ReturnChar).toLowerCase().charCodeAt(0);
	}
	
	if((status&MaskCharStatus_UpperCaseChar)==MaskCharStatus_UpperCaseChar){
		ReturnChar=String.fromCharCode(ReturnChar).toUpperCase().charCodeAt(0);
	}
	
	if((status&MaskCharStatus_LiteralChar)==MaskCharStatus_LiteralChar){
		ReturnChar=ch;
	}
	
	return ReturnChar;
}

function mbx_validateFullValue(ctrl){
	var bValid=true;
	CursorPosition=0;
	var Text=ctrl.value.split('');
	for(var i=0;i<Text.length;i++){
		var ch=Text[i];
		if(mbx_validate(ctrl,ch.charCodeAt(0))==NullChar){
			bValid=false;
			break;
		}
		
		CursorPosition++
	}
	
	return bValid;
}

function mbx_formatControlValue(ctrl,isFocus){
	var Text=ctrl.value.split('');
	var PromptCharCode=ctrl.getAttribute("promptchar").charCodeAt(0);
	for(var i=0;i<Text.length;i++){
		var ch=Text[i];
		var status=MaskCharStatusArray[i];
		if((status&MaskCharStatus_LiteralChar)!=MaskCharStatus_LiteralChar){
			if(isFocus){
				if(ch==String.fromCharCode(SpaceCharCode))
					Text[i]=String.fromCharCode(PromptCharCode);
			} else {
				if(ch==String.fromCharCode(PromptCharCode))
					Text[i]=String.fromCharCode(SpaceCharCode);
			}
		}
	}
	return Text.join('');
}

function mbx_setPosition(ctrl,Offset){
	var Pos=CursorPosition;
	while(true){
		Pos+=Offset;
		if(Pos<0||Pos>MaskCharStatusArray.length-1){
			Offset=(Pos-CursorPosition);
			CursorPosition=Pos;
			mbx_setPosition(ctrl,-Offset);
			return;
		}
		
		if((MaskCharStatusArray[Pos]&MaskCharStatus_LiteralChar)!=MaskCharStatus_LiteralChar){
			CursorPosition=Pos;
			mbx_selectCursorPos(ctrl,CursorPosition,1);
			return;
		}
	}
}

//@&@&@&@&@Unsupported
/*************************************************************************
* UnSupported Javascript 
*************************************************************************/
