if(typeof console=='undefined'){console={log:function(){}}}
if(typeof String.prototype.trim!=='function'){String.prototype.trim=function(){return this.replace(/^\s+|\s+$/g,'');}}
if(typeof String.prototype.endsWith!=='function'){String.prototype.endsWith=function(suffix){return this.indexOf(suffix,this.length-suffix.length)!==-1;};}
if(typeof Array.prototype.reduce!=='function'){Array.prototype.reduce=function(callback){'use strict';if(this==null){throw new TypeError('Array.prototype.reduce called on null or undefined');}
if(typeof callback!=='function'){throw new TypeError(callback+' is not a function');}
var t=Object(this),len=t.length>>>0,k=0,value;if(arguments.length==2){value=arguments[1];}else{while(k<len&&!(k in t)){k++;}
if(k>=len){throw new TypeError('Reduce of empty array with no initial value');}
value=t[k++];}
for(;k<len;k++){if(k in t){value=callback(value,t[k],k,t);}}
return value;};}
function numbersonly(myfield,e,dec){var key;var keychar;if(window.event)
key=window.event.keyCode;else if(e)
key=e.which;else
return true;if((key==86)&&(e.ctrlKey==true)||(key==67)&&(e.ctrlKey==true)){return true;}
if(key>=96&&key<=105)
key=key-48;keychar=String.fromCharCode(key);if((key==null)||(key==0)||(key==8)||(key==9)||(key==27)||key==16||key==35||key==36||key==46||(key>=48&&key<=57)||key==37||key==39){return true;}
if(key==13){if($(myfield).attr('id')=="txtBetMoney"){BetlogInsert();}
return false;}
else if((("0123456789").indexOf(keychar)>-1))
return true;else if(dec&&(key==190||key==110)){return $(myfield).val().indexOf('.')<0;}
else
return false;}
function SelectAngularJS(_options){this.GetValue=function(attr){if(attr===undefined){return $(_options.SelectorValue).val();}else{return $(_options.SelectorValue).attr(attr);}}
this.GetText=function(){return $(_options.SelectorText).text();}
return this;}
function IsEmail(control){var input=$(control).val();var regex=/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}(.[a-zA-Z]{2,6}){0,1}$/;if(input!=''){if(regex.test(input)){return true;}}
return false;}
function isNumberKey(evt){var charCode=(evt.which)?evt.which:event.keyCode;if(charCode>31&&(charCode<48||charCode>57))
return false;return true;}
var uniChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZàáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ1234567890~!@#$%^&*()_+=-{}][|\":;'\\/.,<>? \n\r\t";var KoDauChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZaaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU1234567890~!@#$%^&*()_+=-{}][|\":;'\\/.,<>? \n\r\t";var uniCharsAlfabe="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZàáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ1234567890 ";var KoDauCharsAlfabe="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZaaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU1234567890 ";var Alphabe="qwertyuioplkjhgfdsazxcvbnm0123456789QWERTYUIOPASDFGHJKLZXCVBNM";function UnicodeToKoDau(s,forSuggest){var retVal='';if(s==null)
return retVal;var pos;var c='a';for(var i=0;i<s.length;i++){if(c==' '&&s[i]==' ')
continue;c=s[i];if(forSuggest===undefined){pos=uniChars.indexOf(c);if(pos>=0)
retVal+=KoDauChars[pos];}else{pos=uniCharsAlfabe.indexOf(c);if(pos>=0)
retVal+=KoDauCharsAlfabe[pos];}}
return retVal;}
function UnicodeToKoDauUrl(s){var retval='';if(s!=null&&s!=''){var reg_replace_white_space=new RegExp('( )+',"g");s=s.replace(reg_replace_white_space,'-');if(s.length>100)
s=s.substring(0,100);s=UnicodeToKoDau(s);var reg_replace_html_tag=new RegExp('<[^>]*>');s=s.replace(reg_replace_html_tag,'');var ss='';for(var i=0;i<s.length;i++){if(Alphabe.indexOf(s[i])>=0)
ss+=s[i];else
ss+='-';}
ss=ss.replace(reg_replace_white_space,'-');retval=ss;var reg_replace_urlchar=new RegExp('-+');retval=retval.replace(reg_replace_urlchar,'-');return retval.length>100?retval.substring(0,100):retval;}
return retval;}
function VNDateTimeToUTCDateTime(vnDatetime,separatorChar){try{var strDate=vnDatetime.toString();var aDate=strDate.split(separatorChar);var retDate=new Date(aDate[2]+'/'+aDate[1]+'/'+aDate[0]).toDateString();return retDate;}catch(ex){return new Date();}}
function UTCDateTimeToVNDateTime(utcDatetime,separator){var strdate='';try{strdate=new Date(utcDatetime);}catch(ex){strdate=new Date();}
var day=strdate.getDate()<9?'0'+(strdate.getDate()):strdate.getDate();var month=strdate.getMonth()<9?"0"+(strdate.getMonth()+1):(strdate.getMonth()+1);var retDate=day+separator+month+separator+strdate.getFullYear();return retDate;}
function GetMoneyText(money){if(money<=0){return "0 đồng";}
money=Math.round(money*10)/10;var retval='';var sodu=0;if(money>=1000000000){sodu=Math.floor(money/1000000000);retval+=sodu+' tỷ ';money=money-(sodu*1000000000);}
if(money>=1000000){sodu=Math.floor(money/1000000);retval+=sodu+' triệu ';money=money-(sodu*1000000);}
if(money>=1000){sodu=Math.floor(money/1000);retval+=sodu+' nghìn ';money=money-(sodu*1000);}
money=Math.floor(money);if(money>0){retval+=money+' đồng';}
return retval.trim();}
function GetMoneyText2(money){money=Math.round(money*10)/10;var retval='';var sodu=0;if(money>=1000000000){sodu=money/1000000000;return sodu+' tỷ ';}
if(money>=1000000){sodu=money/1000000;return sodu+' triệu ';}
return GetMoneyText(money);}
function ArrangeUrl(arrangeId){setCookie('ArrangeId',arrangeId,3)
var url=location.href;url=url.replace(new RegExp("/p([0-9]+)"),"");url=url.replace("#product-list","");location.href=url;}
function setCookie(cname,cvalue,exdays){var d=new Date();d.setTime(d.getTime()+(exdays*24*60*60*1000));var expires="expires="+d.toUTCString();document.cookie=cname+"="+cvalue+";"+expires+";path=/";}
function getCookie(cname){var name=cname+"=";var ca=document.cookie.split(';');for(var i=0;i<ca.length;i++){var c=ca[i];while(c.charAt(0)==' '){c=c.substring(1);}
if(c.indexOf(name)==0){return c.substring(name.length,c.length);}}
return "";}
function Loading(){$('#loadding').html('<div class="bg-popup"> <img src="/Content/img/loading300.gif" class="loading"/></div>');NoScroll();}
function Loaded(){$('#loadding').empty();ScoreScroll();}
function ReloadPage(){$(function(){document.location.href='/';});}
function ClosePopup(){$('#popup').empty();ScoreScroll();}
function NoScroll(){var width=$('body').width();$('body').css('overflow','hidden')
var scrollWidth=$('body').width()-width;$('body').css('margin-right',scrollWidth+'px');}
function ScoreScroll(){$('body').removeAttr('style');}
function RefreshCaptchar(){$("#imgCaptcha").attr("src","/HandlerWeb/CaptchaHandler.ashx?type=register&time="+new Date().getTime());}
function RefreshCaptcharPopup(id){$("#"+id).attr("src","/HandlerWeb/CaptchaHandler.ashx?type=register&time="+new Date().getTime());}
$(function(){if($('.row-rate').length){RatingFunc.Init();}});var RatingFunc={Init:function(){$('.icon-star-empty i').mouseover(function(){var obj=$(this);RatingFunc.FocusRating(obj.data('title'),obj.data('class'));}).click(function(){var obj=$(this);RatingFunc.SaveRating(obj.data('title'));});$('.pn-rating').mouseout(function(){RatingFunc.RemoveRating();});RatingFunc.ShowRateText();},FocusRating:function(_val,_class){$('.pn-rating:hover .rate-tooltip').text(_val+'/5');$('.icon-star-empty').removeClass('icon-star-half-alt').removeClass('icon-star');$('.icon-star-empty i').each(function(){var value=$(this).data('title');var parent=$(this).parent();if(value==_val){parent.removeClass('icon-star-half-alt').removeClass('icon-star');parent.addClass(_class);}
else if(value<_val){parent.addClass('icon-star');}});},SaveRating:function(_val){var id=$('#hddid').val();var type=$('#hddtype').val();var keyname='rateid_'+id+'_type_'+type;if(parseFloat(getCookie(keyname))>0){objMessagePopup.NotifyMessage('Cảm ơn, bạn đã đánh giá thành công!');}
else{$.ajax({type:"POST",cache:false,url:"/Rating/Rate",data:{"rate":_val,"id":id,"type":type},success:function(data){setCookie(keyname,_val,0.1)
$('#hddclass').val(data.ClassCss);$('#hddrate').val(data.Rate);RatingFunc.ShowRateText();$('.rate-text').html(data.Rate+' ('+data.Percent+'%) '+data.Count+' votes');}});objMessagePopup.NotifyMessage('Cảm ơn, bạn đã đánh giá thành công!');}},RemoveRating:function(){$('.icon-star-empty').removeClass('icon-star-half-alt').removeClass('icon-star');RatingFunc.ShowRateText();},ShowRateText:function(){RatingFunc.FocusRating($('#hddrate').val(),$('#hddclass').val());}};function CallSubmitIndexing(url,productId){$.ajax({type:"POST",cache:false,url:"/MyAccount/SubmitIndexing",data:{"url":'https://batdongsanviet.vn'+url,"key":'key'},beforeSend:function(){},success:function(data){if(data=='ok'){$.ajax({type:"POST",cache:false,url:"/MyAccount/ProductSubmitLink/",data:{"productId":productId},beforeSend:function(){},success:function(data){},complete:function(){}});}},complete:function(){}});}