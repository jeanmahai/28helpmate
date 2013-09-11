



























var 
gsAgent=navigator.userAgent.toLowerCase(),
gsAppVer=navigator.appVersion.toLowerCase(),
gsAppName=navigator.appName.toLowerCase(),
gbIsOpera=gsAgent.indexOf("opera")>-1,
gbIsWebKit=gsAgent.indexOf("applewebkit")>-1,
gbIsKHTML=gsAgent.indexOf("khtml")>-1
||gsAgent.indexOf("konqueror")>-1||gbIsWebKit,
gbIsIE=(gsAgent.indexOf("compatible")>-1&&!gbIsOpera)
||gsAgent.indexOf("msie")>-1,
gbIsTT=gbIsIE?(gsAppVer.indexOf("tencenttraveler")!=-1?1:0):0,
gbIsQBWebKit=gbIsWebKit?(gsAppVer.indexOf("qqbrowser")!=-1?1:0):0,
gbIsChrome=gbIsWebKit&&!gbIsQBWebKit&&gsAgent.indexOf("chrome")>-1&&gsAgent.indexOf("se 2.x metasr 1.0")<0,
gbIsSafari=gbIsWebKit&&!gbIsChrome&&!gbIsQBWebKit,
gbIsQBIE=gbIsIE&&gsAppVer.indexOf("qqbrowser")!=-1,
gbIsFF=gsAgent.indexOf("gecko")>-1&&!gbIsKHTML,
gbIsNS=!gbIsIE&&!gbIsOpera&&!gbIsKHTML&&(gsAgent.indexOf("mozilla")==0)
&&(gsAppName=="netscape"),
gbIsAgentErr=!(gbIsOpera||gbIsKHTML||gbIsSafari||gbIsIE||gbIsTT
||gbIsFF||gbIsNS),
gbIsWin=gsAgent.indexOf("windows")>-1||gsAgent.indexOf("win32")>-1,
gbIsVista=gbIsWin&&(gsAgent.indexOf("nt 6.0")>-1||gsAgent.indexOf("windows vista")>-1),
gbIsWin7=gbIsWin&&gsAgent.indexOf("nt 6.1")>-1,
gbIsMac=gsAgent.indexOf("macintosh")>-1||gsAgent.indexOf("mac os x")>-1,
gsMacVer=/mac os x (\d+)(\.|_)(\d+)/.test(gsAgent)&&parseFloat(RegExp.$1+"."+RegExp.$3),
gbIsLinux=gsAgent.indexOf("linux")>-1,
gbIsAir=gsAgent.indexOf("adobeair")>-1,
gnIEVer=/MSIE (\d+.\d+);/i.test(gsAgent)&&parseFloat(RegExp["$1"]),
gsFFVer=/firefox\/((\d|\.)+)/i.test(gsAgent)&&RegExp["$1"],
gsSafariVer=""+(/version\/((\d|\.)+)/i.test(gsAgent)&&RegExp["$1"]),
gsChromeVer=""+(/chrome\/((\d|\.)+)/i.test(gsAgent)&&RegExp["$1"]),
gsQBVer=""+(/qqbrowser\/((\d|\.)+)/i.test(gsAgent)&&RegExp["$1"]),

azk="_For_E_Built";




if(document.domain!="qq.com"||!window.getTop)
{
document.domain="qq.com";






window.getTop=function()
{
var vz=arguments.callee;

if(!vz.TX)
{
try
{
if(window!=parent)
{
vz.TX=parent.getTop?parent.getTop():parent.parent.getTop();
}
else
{
vz.TX=window;
}
}
catch(aZ)
{
vz.TX=window;
}
}

return vz.TX;
};


try
{


}
catch(aZ)
{

eval("var top = getTop();");
}
}







function KM(bv,oO)
{
return typeof bv=="function"
?bv.apply(this,oO||[]):null;
}







function callBack(bv,oO)
{
if(!window.Console)
{
try
{
return KM.call(this,bv,oO);
}
catch(aZ)
{
debug(aZ.message);
}
}
else
{
return KM.call(this,bv,oO);
}
}









function waitFor(aaQ,Oy,
DN,rh)
{
var ej=0,
oW=DN||500,
abc=(rh||10*500)/oW;

function aAO(pl)
{
try
{
Oy(pl)
}
catch(aZ)
{
debug(aZ,2);
}
};

(function()
{
try
{
if(aaQ())
{
return aAO(true);
}
}
catch(aZ)
{
debug(aZ,2);
}

if(ej++>abc)
{
return aAO(false);
}

setTimeout(arguments.callee,oW);
})();
}






function unikey(Hg)
{
return[Hg,now(),Math.random()].join("").split(".").join("");
}




function genGlobalMapIdx()
{
return Math.round(Math.random()*10000).toString()+new Date().getMilliseconds();
}






function isLeapYear(fh)
{
return(fh%400==0||(fh%4==0&&fh%100!=0));
}







function calDays(fh,gG)
{
return[null,31,null,31,30,31,30,31,31,30,31,30,31][gG]||(isLeapYear(fh)?29:28);
}





function now()
{
return+new Date;
}






function trim(bL)
{
return(bL&&bL.replace?bL:"").replace(/(^\s*)|(\s*$)/g,"");
}

function trim2(bL)
{


if(bL&&bL.substring)
{
var sg=/\s/,Iy=-1,Ip=bL.length;
while(sg.test(bL.charAt(--Ip)));
while(sg.test(bL.charAt(++Iy)));
return bL.substring(Iy,Ip+1);
}

}












function strReplace(bL,Jb,bOk,cL)
{
return(bL||"").replace(
new RegExp(regFilter(Jb),cL),bOk);
}






function encodeURI(bL)
{
return bL&&bL.replace?bL.replace(/%/ig,"%25").replace(/\+/ig,"%2B")
.replace(/&/ig,"%26").replace(/#/ig,"%23")
.replace(/\'/ig,"%27").replace(/\"/ig,"%22"):bL;
}






function decodeURI(bL)
{
return decodeURIComponent(bL||"");
}






function regFilter(abH)
{
return abH.replace(/([\^\.\[\$\(\)\|\*\+\?\{\\])/ig,"\\$1");
}






function isUrl(fk)
{
return(fk||"").replace(
/http?:\/\/[\w.]+[^ \f\n\r\t\v\"\\\<\>\[\]\u2100-\uFFFF]*/,"url")=="url";
}













function cookQueryString(bc,ay)
{
var cC=bc.split("#"),
ud=cC[1]?("#"+cC[1]):"";

bc=cC[0];

for(var i in ay)
{
var bM=ay[i],
fD=new RegExp(["([?&]",i,"=)[^&#]*"].join(""),"gi");

bc=fD.test(bc)?
bc.replace(fD,"$1"+bM):[bc,"&",i,"=",bM,ud].join("");
}
return bc;
}









function formatNum(kO,aFd)
{
var tw=(isNaN(kO)?0:kO).toString(),
adY=aFd-tw.length;
return adY>0?[new Array(adY+1).join("0"),tw].join(""):tw;
}







function numToStr(kO,bPC)
{
var tw=String(kO.toFixed(bPC));
var re=/(-?\d+)(\d{3})/;
while(re.test(tw))
{
tw=tw.replace(re,"$1,$2");
}
return tw;
}




function numToTimeStr(kO,Es)
{
var Nn=Es||"$HH$:$MM$:$SS$";
return	T(Nn).replace({
SS:formatNum(parseInt(kO)%60,2),
MM:formatNum(parseInt(kO/60)%60,2),
HH:formatNum(parseInt(kO/3600)%60,2)
})
}








function formatDate(mM,Es,bFG)
{
var cV=mM||new Date(),
OT=formatNum;

return T(Es,bFG).replace({
YY:OT(cV.getFullYear(),4),
MM:OT(cV.getMonth()+1,2),
DD:OT(cV.getDate(),2),
hh:OT(cV.getHours(),2),
mm:OT(cV.getMinutes(),2),
ss:OT(cV.getSeconds(),2)
});
}







function getAsiiStrLen(bL)
{
return(bL||"").replace(/[^\x00-\xFF]/g,"aa").length;
}





function clearHtmlStr(bL)
{
return bL?bL.replace(/<[^>]*>/g,""):bL;
}








function subAsiiStr(bL,xL,agd,Lo)
{
var Hu=function(fk){return fk},
MF=Lo?htmlEncode:Hu,
fI=(Lo?htmlDecode:Hu)(trim((bL||"").toString())),
Ei=agd||"",
TT=Math.max(xL-Ei.length,1),
agU=fI.length,
CK=0,
zL=-1,
ug;

for(var i=0;i<agU;i++)
{
ug=fI.charCodeAt(i);


CK+=ug==35||ug==87
?1.2
:(ug>255?1.5:1);

if(zL==-1&&CK>TT)
{
zL=i;
}

if(CK>xL)
{
return MF(fI.substr(0,zL))+Ei;
}
}

return MF(fI);
}













function setCookie(aK,bK,oP,eA,mc,rO)
{
if(aK)
{
document.cookie=T(
[
'$name$=$value$; ',
!oP?'':'expires=$expires$; ',
'path=$path$; ',
'domain=$domain$; ',
!rO?'':'$secure$'
]
).replace(
{
name:aK,
value:encodeURIComponent(bK||""),
expires:oP&&oP.toGMTString(),
path:eA||'/',
domain:mc||["mail.",getDomain()].join(""),
secure:rO?"secure":""
}
);
return true;
}
else
{
return false;
}
}






function getCookie(aK)
{
var jN=(new RegExp(["(^|;|\\s+)",regFilter(aK),"=([^;]*);?"].join("")));

if(jN.test(document.cookie))
{

try
{
return decodeURIComponent(RegExp["$2"]);
}
catch(e)
{
return RegExp["$2"];
}
}
}







function deleteCookie(aK,eA,mc)
{
setCookie(aK,"",new Date(0),eA,mc);
}









function setCookieFlag(aK,cU,yT,atp)
{
var iF=atp||getCookieFlag(aK),
JL=new Date();


JL.setTime(JL.getTime()+(30*24*3600*1000));
iF[cU]=yT;
setCookie(aK,iF.join(""),JL);

return iF;
}






function getCookieFlag(aK)
{
var ain=(getCookie(aK)||"").split("");

for(var i=ain.length;i<6;i++)
{
ain[i]='0';
}

return ain;
}








function isArr(ay)
{
return Object.prototype.toString.call(ay)=="[object Array]";
}









function E(Gw,Tp,YS,QE)
{
if(!Gw)
{
return;
}

if(Gw.length!=null)
{
var _nLen=Gw.length,
gk;

if(QE<0)
{
gk=_nLen+QE;
}
else
{
gk=QE<_nLen?QE:_nLen;
}

for(var i=(YS||0);i<gk;i++)
{
try
{
if(Tp(Gw[i],i,_nLen)===false)
{
break;
}
}
catch(aZ)
{
debug([aZ.message,"<br>line:",aZ.lineNumber,'<br>file:',aZ.fileName,"<br>",Tp]);
}
}
}
else
{
for(var i in Gw)
{
try
{
if(Tp(Gw[i],i)===false)
{
break;
}
}
catch(aZ)
{
debug([aZ.message,"<br>",Tp]);
}
}
}
}









function extend()
{
for(var bk=arguments,vJ=bk[0],i=1,_nLen=bk.length;i<_nLen;i++)
{
var Dk=bk[i];
for(var j in Dk)
{
vJ[j]=Dk[j];
}
}
return vJ;
}







function delAtt(aU,Op)
{
try
{
delete aU[Op];
}
catch(aZ)
{
}
return aU;
}







function saveAtt(aU,Op)
{
if(aU)
{
var bQX=aU.hasOwnProperty(Op),
hy=aU[Op];
return function()
{
if(bQX)
{
aU[Op]=hy;
}
else
{
delAtt(aU,Op);
}
return aU;
};
}
else
{
return function(){};
}
}









function globalEval(hu,tk)
{
var IG=getTop().globalEval||arguments.callee;

if(!IG.ayV&&typeof(IG.bad)!="boolean")
{
var aT="testScriptEval"+now();

IG.ayV=true;
IG(T('window.$id$=1;').replace({
id:aT
}));
IG.ayV=false;

IG.bad=getTop()[aT]?true:false;
}

var gT=trim(hu);
if(!gT)
{
return false;
}

var aL=(tk||window).document,
wB=GelTags("head",aL)[0]||aL.documentElement,
fa=aL.createElement("script");

fa.type="text/javascript";
if(IG.bad||arguments.callee.ayV)
{
try
{
fa.appendChild(aL.createTextNode(gT));
}
catch(aZ)
{
}
}
else
{

fa.text=gT;
}

wB.insertBefore(fa,wB.firstChild);
wB.removeChild(fa);

return true;
}





function evalValue(hu,tk)
{
var bp=unikey("_u"),
aA=tk||window,
iF;

globalEval(
[
"(function(){try{window.",bp,"=",hu,";}catch(_oError){}})();"
].join(""),
aA
);
iF=aA[bp];
aA[bp]=null;

return iF;
}







function evalCss(aiC,tk,yN)
{
if(aiC)
{
var aL=tk?tk.document||tk:document,
ais="cssfrom",
aCS="style"
cm=aL.getElementsByTagName(aCS);

if(yN)
{
for(var i=cm.length-1;i>=0;i--)
{
if(cm[i].getAttribute(ais)==yN)
{
return;
}
}
}

try
{

var cm=aL.createStyleSheet();
cm.cssText=getRes(aiC);
yN&&cm.owningElement.setAttribute(ais,yN);
}
catch(e)
{

var cm=aL.createElement(aCS);
cm.type="text/css";
cm.textContent=getRes(aiC);
aL.getElementsByTagName("head")[0].appendChild(cm);
yN&&cm.setAttribute(ais,yN);
}
}
}







function S(aG,dp)
{
try
{
return(dp&&(dp.document||dp)
||document).getElementById(aG);
}
catch(aZ)
{
return null;
}
}







function SN(aK,dp)
{
try
{
var II=(dp&&(dp.document||dp)
||document).getElementsByName(aK);
if(II)
{
II[azk]=true;
}
return II;
}
catch(aZ)
{
return null;
}
}









function attr(_aoDom,eG,bK)
{

if(!_aoDom||!_aoDom.nodeType||_aoDom.nodeType===3||_aoDom.nodeType===8)
{
return undefined;
}
if(bK===undefined)
{
return _aoDom.getAttribute(eG);
}
else
{
_aoDom.setAttribute(eG,bK);
return _aoDom;
}
}







function GelTags(hq,bn)
{
var II=(bn||document).getElementsByTagName(hq);
if(II)
{
II[azk]=true;
}
return II;

}







function CN(Un,_aoDom,jW)
{
_aoDom=_aoDom||document;

if(_aoDom.getElementsByClassName)
{
return _aoDom.getElementsByClassName(Un);
}
else
{
jW=jW||"*";
var eV=[],
aeD=(jW=='*'&&_aoDom.all)?_aoDom.all:_aoDom.getElementsByTagName(jW),
i=aeD.length;
Un=Un.replace(/\-/g,'\\-');
var jN=new RegExp('(^|\\s)'+Un+'(\\s|$)');
while(--i>=0)
{
if(jN.test(aeD[i].className))
{
eV.push(aeD[i]);
}
}
return eV;
}
};







function F(aG,aq)
{
var zC=S(aG,aq);
return zC&&(zC.contentWindow||(aq||window).frames[aG]);
}

function appendToUrl(bc,bFe)
{
var cC=bc.split("#");
return[cC[0],bFe,(cC.length>1?"#"+cC[1]:"")].join("");
}









function insertHTML(bn,gV,cP)
{
if(!bn)
{
return false;
}
try
{

if(bn.insertAdjacentHTML)
{
bn.insertAdjacentHTML(gV,cP);
}
else
{
var cZ=bn.ownerDocument.createRange(),
mV=gV.indexOf("before")==0,
Mj=gV.indexOf("Begin")!=-1;
if(mV==Mj)
{
cZ[mV?"setStartBefore":"setStartAfter"](bn);
bn.parentNode.insertBefore(
cZ.createContextualFragment(cP),Mj
?bn
:bn.nextSibling
);
}
else
{
var dj=bn[mV?"lastChild":"firstChild"];
if(dj)
{
cZ[mV?"setStartAfter":"setStartBefore"](dj);
bn[mV?"appendChild":"insertBefore"](cZ
.createContextualFragment(cP),dj);
}
else
{

bn.innerHTML=cP;
}
}
}
return true;
}
catch(aZ)
{

return false;
}
}

















function setHTML(afS,cP)
{
var afn=typeof afS==="string"?S(afS):afS,
afp=afn.cloneNode(false);
afp.innerHTML=cP;
afn.parentNode.replaceChild(afp,afn);
return afp;
}



















function createIframe(aq,qG,bR)
{
var Xg="_creAteifRAmeoNlQAd_",
dI=bR||{},
aT=bR.id||unikey(),
yh=S(aT,aq);


if(typeof aq[Xg]!="function")
{
aq[Xg]=function(aG,bID)
{
callBack.call(bID,arguments.callee[aG],[aq]);
};
}


aq[Xg][aT]=bR.onload;
if(!yh)
{
insertHTML(
dI.obj||aq.document.body,
dI.where||"afterBegin",
TE([
'<iframe frameborder="0" scrolling="$scrolling$" id="$id$" name="$id$" ',
'$@$if($transparent$)$@$allowTransparent$@$endif$@$ class="$className$" ',
'onload="this.setAttribute(\x27loaded\x27,\x27true\x27);$cb$(\x27$id$\x27,this);" ',
'src="$src$" style="$style$" $attrs$>',
'</iframe>'
]).replace(extend(
{
"id":aT,
"cb":Xg,
style:"display:none;",
scrolling:"no",
src:qG
}
,bR))
);
yh=S(aT,aq);
yh.aFL=bR.onload;
}
else if(yh.getAttribute("loaded")=="true")
{
aq[Xg](aT,yh);
}
return yh;
}





function removeSelf(bn)
{
try
{
















bn.parentNode.removeChild(bn);
}
catch(aZ)
{
}

return bn;
}







function isObjContainTarget(bn,iE)
{
try
{
if(!bn||!iE)
{
return false;
}
else if(bn.contains)
{
return bn.contains(iE);
}
else if(bn.compareDocumentPosition)
{
var MD=bn.compareDocumentPosition(iE);
return(MD==20||MD==0);
}
}
catch(zt)
{


}

return false;
}






function isDisableCtl(ayi,aq)
{
var aXG=SN(ayi,aq);
for(var i=aXG.length-1;i>=0;i--)
{
if(aXG[i].disabled)
{
return true;
}
}
return false;
}







function disableCtl(ayi,qk,dp)
{
E(SN(ayi,dp),function(bEh)
{
bEh.disabled=qk;
}
);
}








function isShow(pq,dp)
{
return(getStyle((typeof(pq)=="string"?S(pq,dp):pq),"display")||"none")
!="none";
}







function show(pq,nq,dp)
{
var dj=(typeof(pq)=="string"?S(pq,dp):pq);
if(dj)
{
dj.style.display=(nq?"":"none");
}
else if(!dp&&typeof(pq)=="string")
{

}
return dj;
}


var Show=show;





function toggle(pq,dp)
{
return show(pq,!isShow(pq,dp),dp);
}







function setClass(bn,ow)
{
if(bn&&typeof(ow)!="undefined"&&bn.className!=ow)
{
bn.className=ow;
}
return bn;
}







function addClass(bn,ow)
{
if(bn)
{
var kb=" "+bn.className+" ";
if(kb.indexOf(" "+ow+" ")<0)
{
bn.className+=bn.className?" "+ow:ow;
}
}
return bn;
};







function rmClass(bn,ow)
{
if(bn)
{
if(ow)
{
var kb=" "+bn.className+" ";
kb=kb.replace(" "+ow+" "," ");
bn.className=trim(kb);
}
else
{
bn.className="";
}
}
return bn;
};





function hasClass(bn,ow)
{
return bn&&(" "+bn.className+" ").indexOf(" "+ow+" ")>-1;
};







function getStyle(bn,aRF)
{
var vV=bn&&(bn.currentStyle
?bn.currentStyle
:bn.ownerDocument.defaultView.getComputedStyle(bn,null));
return vV&&vV[aRF]||"";
}







function setOpacity(bn,Rp)
{
if(bn&&bn.tagName)
{
var cm=bn.style,
mT=Rp||0;











if(typeof cm.opacity=="undefined")
{
cm.filter=mT==1
?"":["alpha(opacity=",mT*100,")"].join("");
}
else
{
cm.opacity=mT;
}
}
return bn;
}






function getOpacity(bn,Rp)
{
if(bn&&bn.tagName)
{
var cm=bn.style,
mT=1;









if(typeof cm.opacity=="undefined")
{
mT=parseFloat(cm.filter.split("=").pop())/100;
}
else
{
mT=parseFloat(cm.opacity);
}

if(isNaN(mT))
{
mT=1;
}
}
return mT;
}






function getStrDispLen(bL)
{
var aMs="__QMStrCalcer__";
var ajl=S(aMs,getTop());
if(!ajl)
{
var cY=getTop().document.body;
insertHTML(
cY,
"afterBegin",
T([
'<div id="$id$" ',
'style="width:1px;height:1px;overflow:auto;*overflow:hidden;white-space:nowrap;',
'position:absolute;left:0;top:0;">','</div>']).replace({
id:aMs
})
);
ajl=cY.firstChild;
}
ajl.innerHTML=htmlEncode(bL);
return ajl.scrollWidth;
}







function calcPos(bn,amg)
{
var bY=0,
dz=0,
cy=0,
cF=0;

if(bn&&bn.tagName)
{
var VO=bn,
dj=bn.parentNode,
aub=bn.offsetParent,
aL=bn.ownerDocument,
gu=aL.documentElement,
cY=aL.body;

dz+=bn.offsetLeft;
bY+=bn.offsetTop;
cy=bn.offsetWidth;
cF=bn.offsetHeight;

while(aub&&dj&&dj!=gu&&dj!=cY)
{
if(calcPos.aNm()&&VO.style&&getStyle(VO,"position")==="fixed")
{
break;
}

if(aub==dj)
{
dz+=dj.offsetLeft;
bY+=dj.offsetTop;
aub=dj.offsetParent;
}

dz-=dj.scrollLeft;
bY-=dj.scrollTop;
VO=dj;
dj=dj.parentNode;

}

if(calcPos.aNm()&&VO.style&&getStyle(VO,"position")==="fixed")
{
dz+=bodyScroll(aL,'scrollLeft');
bY+=bodyScroll(aL,'scrollTop');
}
}

return amg=="json"
?{top:bY,bottom:bY+cF,left:dz,
right:dz+cy,width:cy,height:cF}
:[bY,dz+cy,bY+cF,dz,cy,cF];
}

calcPos.aNm=function()
{

var bYo,
ae=this;
if(ae.bbJ==bYo)
{
var cO=document.createElement("div");
cO.style.cssText="'position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;";
cO.innerHTML="<div style='position:fixed;top:20px;'></div>";
document.body.appendChild(cO);
ae.bbJ=!!{20:1,15:1}[cO.firstChild.offsetTop];
}
return ae.bbJ;
};







function calcPosFrame(bn,aq)
{
aq=aq||window;
var qd=calcPos(bn),
_oTop=getTop();
while(aq.frameElement&&aq!=_oTop)
{
var ff=calcPos(aq.frameElement);
for(var i=0;i<4;i++)
{

qd[i]+=ff[i&1?3:0]-bodyScroll(aq,i&1?"scrollLeft":"scrollTop");

}
aq=aq.parent;
}
return qd;
}










function calcAdjPos(jj,od,kz,aq,dD)
{
var agb=bodyScroll(aq,'clientHeight'),
aRG=bodyScroll(aq,'clientWidth'),
Ol=bodyScroll(aq,'scrollTop'),
arC=bodyScroll(aq,'scrollLeft'),
abK=Ol+agb,
aLy=arC+aRG,
aE=[0,0,0,0];
if(dD<2)
{

var ij=arC-jj[1];
if(dD==0&&jj[3]<od
||dD==1&&aLy-jj[1]>od)
{

aE[1]=(aE[3]=jj[1])+od;
}
else
{

aE[3]=(aE[1]=jj[3])-od;
}
if(jj[0]+kz>abK)
{


aE[0]=(aE[2]=(jj[2]-kz<Ol?abK:jj[2]))-kz;
}
else
{

aE[2]=(aE[0]=jj[0])+kz;
}
}
else
{

if(dD==2&&jj[0]-Ol<kz
||dD==3&&abK>jj[2]+kz)
{

aE[2]=(aE[0]=jj[2])+kz;
}
else
{

aE[0]=(aE[2]=jj[0])-kz;
}
aE[1]=jj[1];
aE[3]=jj[3];
}
return aE;
}







function bodyScroll(dp,aw,bW)
{
var aL=(dp||window).document||dp,
cY=aL.body,
sP=aL.documentElement;

if(typeof(bW)=="number")
{
cY[aw]=sP[aw]=bW;
}
else
{
if(aw=="scrollTop"&&typeof dp.pageYOffset!="undefined")
{
return dp.pageYOffset;
}
else
{
return sP[aw]||cY[aw];
}
}
}








function htmlDecode(bL)
{
return bL&&bL.replace?(bL.replace(/&nbsp;/gi," ").replace(/&lt;/gi,"<").replace(/&gt;/gi,">")
.replace(/&amp;/gi,"&").replace(/&quot;/gi,"\"").replace(/&#39;/gi,"'")
):bL;
}






function htmlEncode(bL)
{
return bL&&bL.replace?(bL.replace(/&/g,"&amp;").replace(/\"/g,"&quot;")
.replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\'/g,"&#39;")):bL;
}







function filteScript(bL,bMA)
{
return bL
&&bL.replace(/<script ?.*>(.*?)<\/script>/ig,
"<script>$1\n</script>"
).replace(/<script ?.*>([\s\S]*?)<\/script>/ig,bMA||"");
}






function textToHtml(dR)
{

return[
'<DIV>',
dR.replace((dR.indexOf("<BR>")>=0)?/<BR>/ig:/\n/g,
"</DIV><DIV>"
),
"</DIV>"
].join("")
.replace(new RegExp("\x0D","g"),"")
.replace(new RegExp("\x20","g"),"&nbsp;")
.replace(new RegExp("(<DIV><\/DIV>)*$","g"),"")
.replace(/<DIV><\/DIV>/g,"<DIV>&nbsp;</DIV>");
}






function textToHtmlForNoIE(dR)
{
return dR.replace(/\n/g,"<br>");
}






function htmlToText(dR)
{
return dR

.replace(/\n/ig,"")

.replace(/(<\/div>)|(<\/p>)|(<br\/?>)|(<\/li>)/ig,"\n");
}






function fixNonBreakSpace(bL)
{
return(bL||"").replace(/\xA0/ig," ");
}









function pasteHTML(UL,acX,bzr,aq)
{
aq=aq||getMainWin();
UL=filteScript(UL);
var _oContainer=(typeof(acX)=="string"?S(acX,aq):acX);
if(!_oContainer||!UL)
{
return false;
}
if(bzr)
{
_oContainer.innerHTML=UL;
}
else
{
insertHTML(_oContainer,"afterBegin",UL);
}
return true;
}







function T(jy,oY)
{
return new T.yf(jy,oY);
}









































function TE(jy,oY)
{
var _oTop=getTop();
if(_oTop.QMTmplChecker)
{
var aZ=(new _oTop.QMTmplChecker(jy.join?jy:[jy],
oY)).getErrors();
if(aZ.length)
{
debug(aZ.join("\n"),"code");
}
}
return new T.yf(jy,oY,"exp");
}

T.yf=function(jy,oY,aw)
{
this.CG=jy.join?jy.join(""):jy.toString();
this.wr=oY||"$";
this.ags=aw=="exp"
?this.ahA
:this.agY;
};

T.yf.prototype=
{
toString:function()
{
return this.CG;
},

replace:function(jx,oz)
{
return this.ags(jx,oz);
},

agY:function(jx,aei)
{
var ae=this,
rM=ae.wr,
pb=ae.Lq,
BG=ae.aiD,
Ms=!pb;

if(Ms)
{

pb=ae.Lq=ae.CG.split(ae.wr);
BG=ae.aiD=ae.Lq.concat();
}

for(var i=1,_nLen=pb.length;i<_nLen;i+=2)
{
BG[i]=ae.sQ(Ms?(pb[i]=pb[i].split("."))
:pb[i],jx,aei,rM);
}

return BG.join("");
},

ahA:function(jx,oz,OD)
{
var ae=this,
pr;

if(!ae.LG)
{
ae.aho();
}

if(typeof oz=="string")
{
var vW=ae.Lc[oz];
if(vW)
{
pr=typeof vW!="function"
?ae.Lc[oz]=ae.Mr(vW)
:vW;
}
}
else
{
pr=ae.LG;
}

try
{
return pr&&pr(jx,ae.Zl,
ae.sQ,ae.wr,htmlEncode,OD||oz)||"";
}
catch(aZ)
{
return aZ.message;
}
},




aho:function()
{
var ae=this,
jz=0,
gW=[],
CJ=[],
Cc=[],
afG=ae.Lc=[],
rM=ae.wr,
jN=new RegExp(["","(.*?)",""].join(regFilter(rM)),"g"),
rV="_afG('$1'.split('.'),_oD,_aoD,_aoR)",
xY=ae.Zl=ae.CG.split(["","@",""].join(rM)),
ek;

for(var i=0,_nLen=xY.length;i<_nLen;i++)
{
ek=xY[i];

if(i%2==0)
{
gW.push("_oR.push(_aoT[",i,"].replace(_oD,_aoD));");
xY[i]=T(ek,rM);
}
else if(ek=="else")
{
gW.push("}else{");
}
else if(ek=="endsec")
{
if(Cc.length)
{
var av=Cc.pop();
afG[av[0]]=gW.slice(av[1]);
}
}
else if(ek=="endfor")
{
CJ.length&&gW.push(
"try{delete _oD._parent_;delete _oD._idx_;}catch(e){}}_oD=_oS",CJ.pop(),";");
}
else if(ek=="endif")
{
gW.push("}");
}
else if(ek.indexOf("else if(")==0)
{
gW.push("}",ek.replace(jN,rV),"{");
}
else if(ek.indexOf("if(")==0)
{
gW.push(ek.replace(jN,rV),"{");
}
else if(ek.indexOf("for(")==0)
{
CJ.push(++jz);
gW.push(
"var _sI",jz,",_oD",jz,",_oS",jz,"=_oD;",
ek.replace(jN,
["_sI",jz," in (_oD",jz,"=",rV,")"].join("")),
"{",
"_oD=_oD",jz,"[_sI",jz,"];",
"if(!_oD){continue;}",
"try{_oD._parent_=_oS",jz,";",
"_oD._idx_=_sI",jz,";}catch(e){}"
);
}
else if(ek.indexOf("sec ")==0)
{
Cc.push([ek.split(" ").pop(),gW.length]);
}
else if(ek.indexOf("eval ")==0)
{
gW.push("_oR.push(",ek.substr(5).replace(jN,rV),");");
}
else if(ek.indexOf("html(")==0)
{
gW.push("_oR.push(_afE(",ek.substr(5).replace(jN,rV),");");
}
}

ae.LG=ae.Mr(gW);

return gW;
},

Mr:function(aiZ)
{
try
{
return eval(
[
'([function(_aoD,_aoT,_afG,_aoR, _afE, A){var _oR=[],_oD=_aoD;',
aiZ.join(""),
'return _oR.join("");}])'
].join("")
)[0];
}
catch(fY)
{
return function(){return"compile err!"};
}
},

sQ:function(BN,jx,agI,aaX)
{
var _nLen=BN.length,
bp,
hy;

if(_nLen>1)
{
try
{
hy=jx;
for(var i=0;i<_nLen;i++)
{
bp=BN[i];
if(bp=="_root_")
{
hy=agI;
}
else
{
hy=hy[bp];
}
}
}
catch(aZ)
{
hy="";
}
}
else
{
hy={
"_var_":aaX,
"_this_":jx
}[bp=BN[0]]||jx[bp];
}

return hy;
}
};










var addEvent=(function()
{








function Af(iE,aw,Oe,rz)
{
if(iE&&Oe)
{
if(iE.addEventListener)
{
iE[rz?"removeEventListener":"addEventListener"](
aw,Oe,false
);
}
else if(iE.attachEvent)
{
iE[rz?"detachEvent":"attachEvent"]("on"+aw,
Oe
);
}
else
{
iE["on"+aw]=rz?null:Oe;
}
}

return iE;
}

return function(iE,aw,aFy,rz)
{
if(iE&&(iE.join||iE[azk]))
{
E(iE,function(_aoDom)
{
Af(_aoDom,aw,aFy,rz);
}
);
}
else
{
Af(iE,aw,aFy,rz);
}

return iE;
};
}
)();








function addEvents(iE,kN,rz)
{
E(kN,function(zN,aw)
{
addEvent(iE,aw,zN,rz);
}
);
return iE;
}








function removeEvent(iE,aw,Oe)
{
return addEvent(iE,aw,Oe,true);
}







function removeEvents(iE,kN)
{
return addEvents(iE,kN,true);
}






function preventDefault(_aoEvent)
{
if(_aoEvent)
{
if(_aoEvent.preventDefault)
{
_aoEvent.preventDefault();
}
else
{
_aoEvent.returnValue=false;
}
}
return _aoEvent;
}






function stopPropagation(_aoEvent)
{
if(_aoEvent)
{
if(_aoEvent.stopPropagation)
{
_aoEvent.stopPropagation();
}
else
{
_aoEvent.cancelBubble=true;
}
}
return _aoEvent;
}






function getEventTarget(_aoEvent)
{
return _aoEvent&&(_aoEvent.srcElement||_aoEvent.target);
}











function getUserTarget(_aoDom,_aoEvent,eG)
{
var aB=getEventTarget(_aoEvent);
while(aB&&isObjContainTarget(_aoDom,aB))
{
if(attr(aB,eG))
{
return aB;
}
aB=aB.parentNode;
}
}











function fireMouseEvent(bn,aeu,_aoEvent)
{
if(bn)
{
_aoEvent=_aoEvent||{};
if(bn.dispatchEvent)
{

var aL=bn.ownerDocument,
aA=aL.defaultView,
bJ=aL.createEvent("MouseEvents");
bJ.initMouseEvent(aeu,true,true,aA,0,0,0,0,0,!!_aoEvent.ctrlKey,!!_aoEvent.altKey,!!_aoEvent.shiftKey,!!_aoEvent.metaKey,0,null);
bn.dispatchEvent(bJ);
}
else
{


if(bn.tagName=="INPUT"&&bn.getAttribute("type")=="submit"&&aeu=="click")
{
bn.click();
}
else
{
var bJ=bn.ownerDocument.createEventObject();
for(var bk=["ctrlKey","altKey","shiftKey","metaKey"],i=bk.length-1;i>=0;i--)
{
bJ[bk[i]]=_aoEvent[bk[i]];
}
bn.fireEvent("on"+aeu,bJ);
}
}
}
return bn;
}











function loadJsFile(iO,atl,ez,OP,pV)
{
var aL=ez||document,
bYh=typeof OP=="function",
dLN,fa,
wS=getTop().loadJsFile,
_sFile=getRes(iO),
iS=wS.iS||(wS.iS={});

if(atl)
{
for(var WD=GelTags("script",aL),
i=WD.length-1;i>=0;i--)
{
if(WD[i].src.indexOf(_sFile)!=-1)
{
if(bYh)
{
var bp=WD[i].getAttribute("_key_");
if(iS[bp]===true)
{
callBack.call(WD[i],OP);
}
else
{
iS[bp].push(OP);
}
}
return WD[i];
}
}
}

fa=aL.createElement("script");
E(pV,function(mJ,bA)
{
fa.setAttribute(bA,mJ);
}
);

var bp=unikey();
fa.setAttribute("_key_",bp);
iS[bp]=[];

function aTg()
{
var ae=this,bp=ae.getAttribute("_key_");
callBack.call(ae,OP);
E(iS[bp],function(fN){fN()});
iS[bp]=true;
}

(GelTags("head",aL)[0]||aL.documentElement)
.appendChild(extend(fa,

{
onload:aTg,
onreadystatechange:function()
{
var ae=this;
({loaded:true,complete:true}[ae.readyState])&&aTg.call(this);
}
},
{
type:"text/javascript",
charset:pV&&pV.charset||"gb2312",
src:_sFile
}
)
);

return fa;
}






function loadJsFileToTop()
{

if(arguments.length==2)
{
var asr=arguments[0],
pd=arguments[1];
}
else
{
var asr="",
pd=arguments[0];
}
var bFk=window.loadJsFile;


function biP(iO)
{
if(iO)
{

bFk(asr+iO,true,getTop().document);
}
}
E(pd,biP);
}









function loadCssFile(iO,atl,ez)
{
var aL=ez||document,
_sFile=getRes(iO);

if(atl)
{
for(var aZf=GelTags("link",aL),
i=aZf.length-1;i>=0;i--)
{
if(aZf[i].href.indexOf(_sFile)!=-1)
{
return;
}
}
}

var iQ=aL.createElement("link"),
awS=GelTags("link",aL);

iQ.type="text/css";
iQ.rel="stylesheet";
iQ.href=_sFile;

if(awS.length>0)
{
var aYi=awS[awS.length-1];
aYi.parentNode.insertBefore(iQ,
aYi.nextSibling);
}
else
{
(GelTags("head",aL)[0]||aL.documentElement).appendChild(iQ);
}

return iQ;
}








function replaceCssFile(Es,iO,ez)
{
if(Es)
{
E(GelTags("link",ez||document),function(ats)
{
if(ats&&ats.href.indexOf(Es)!=-1)
{
removeSelf(ats);
}
});
}

return loadCssFile(iO,false,ez);
}









function QMAjax(bc,kr,rh,eQ)
{
var ae=this,
_oTop=getTop(),
jC=eQ,
dS;

function bqf()
{
ae.onComplete(jC);
}

function bkz(cL)
{
ae.onError(jC,cL);
}

function bhP(bpD)
{
if(!dS)
{
dS=setTimeout(
function()
{
ae.abort();
},
bpD
);
}
}

function NX(cL)
{
if(dS)
{
clearTimeout(dS);
dS=null;
if(cL!="ok")
{
bkz(cL);
}
return true;
}
return false;
}



this.method=kr||"POST";
this.url=bc;
this.async=true;
this.content="";
this.timeout=rh;


this.onComplete=function()
{
};
this.onError=function()
{
};

if(!jC)
{
try
{
jC=new XMLHttpRequest;
}
catch(aZ)
{
try
{
jC=new ActiveXObject("MSXML2.XMLHTTP");
}
catch(aZ)
{
try
{
jC=new ActiveXObject("Microsoft.XMLHTTP");
}
catch(aZ)
{
}
}
}
}



if(!jC)
{
return false;
}





this.abort=function()
{
NX("abort");
jC.abort();
};






this.send=function(bjN)
{
if(!this.method||!this.url||!this.async)
{
return false;
}

typeof this.url=="object"&&(this.url=this.url.replace({}));

var gb=this.method.toUpperCase(),
ic=getTop().getSid&&getTop().getSid();
this.abort();

jC.open(gb,

this.url+(ic&&gb=="POST"&&((this.url.split("?")[1]||"")+"&").indexOf("&sid=")==-1
?(this.url.indexOf("?")==-1?"?sid=":"&sid=")+ic:""),
this.async
);

if(gb=="POST")
{
jC.setRequestHeader("Content-Type",document.charset);
jC.setRequestHeader("Content-length",this.content.length);
jC.setRequestHeader("Content-Type",
"application/x-www-form-urlencoded"
);
}

_oTop.E(this.headers,function(bK,bA)
{
jC.setRequestHeader(bA,bK);
}
);

jC.onreadystatechange=function()
{
try
{
if(jC.readyState==4)
{
if(jC.status==200)
{
if(NX("ok"))
{
bqf();
}
}
else
{
NX(jC.status);
}
}
}
catch(cM)
{
NX(cM.message);
}
}



bhP(this.timeout||15000);

try
{
if(gb=="POST")
{
jC.send(bjN||this.content);
}
else
{

jC.send(null);
}
}
catch(aZ)
{
NX(aZ.message);
}

return true;
}
};













QMAjax.send=function(bc,ag,bgP)
{
var _oTop=getTop(),
dW=bgP||new QMAjax,
aM=ag||{};
dW.url=bc;

_oTop.E("method,timeout,content,headers".split(","),function(bA)
{
if(aM[bA])
{
dW[bA]=aM[bA];
}
}
);

dW.onComplete=function(eQ)
{
_oTop.callBack.call(eQ,ag.onload,[true,_oTop.trim2(eQ.responseText||""),eQ]);

};

dW.onError=function(eQ,cL)
{
_oTop.callBack.call(eQ,ag.onload,[false,cL,eQ]);
};

dW.send();
}

function includeAjax(aq)
{


var gT=[];
gT.push(QMAjax.toString());
gT.push(["var QMAjaxSend =",QMAjax.send.toString()].join(""));
globalEval(gT.join(""),aq);

}

var QMAjaxRequest=QMAjax;







function getErrMsg(eQ,aIv)
{
var adC="_AjaxErrorHTML_";
var wP=S(adC);
if(!wP)
{
wP=document.createElement("div");
wP.id=adC;
wP.style.display="none";
document.body.appendChild(wP);
}
wP.innerHTML=filteScript(eQ.status==200?eQ.responseText:"");
var MP=S(aIv);
return MP&&(MP.innerText||MP.textContent)||"";
}





function getHttpProcesser()
{
var _oTop=getTop(),
agC=_oTop.gCurHttpProcesserId||0;

_oTop.gCurHttpProcesserId=(agC+1)%30;

try
{
if(_oTop.gHttpProcesserContainer[agC]!=null)
{
delete _oTop.gHttpProcesserContainer[agC];
}
}
catch(aZ)
{
_oTop.gHttpProcesserContainer={};
}

var aSa=_oTop.gHttpProcesserContainer[agC]=new _oTop.Image;
aSa.onload=function()
{
return false;
};

return aSa;
}







function goUrl(axQ,bc,bPd)
{
try
{
var pB=(axQ.contentWindow||axQ).location,
bXw=pB.href.split("#"),
aLH=bc.split("#"),
bAm=aLH[0]==bXw[0],
aO=bAm?aLH[0]:bc;

if(bPd)
{
pB.href=aO;
}
else
{
pB.replace(aO);
}
}
catch(aZ)
{
axQ.src=bc;
}
}









function generateFlashCode(aG,axm,QM,aQ)
{
var aWB=[],
auV=[],
ahH=[],
cX=aQ||{},

ahz=T(' $name$=$value$ '),
aNj=T('<param name="$name$" value="$value$" />'),
bRe=gbIsIE?T([
'<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" ',
'$codebase$ ','$attr$ $id$ >',
'$param$',
'<embed $embed$ type="application/x-shockwave-flash" ',
'$pluginspage$ ',' $name$ ></embed>',
'</object>'
]):T([
'<embed $embed$ type="application/x-shockwave-flash" ',
'$pluginspage$ ',' $name$ $id$ ></embed>'
]);

function aiI(aK,mJ)
{
return{
name:aK,
value:mJ
};
}

cX.allowScriptAccess="always";
cX.quality="high";

for(var yX in cX)
{
var cg=aiI(yX,cX[yX]);
auV.push(aNj.replace(cg));
ahH.push(ahz.replace(cg));
}

for(var yX in QM)

{
var cg=aiI(yX,QM[yX]);
aWB.push(ahz.replace(cg));
ahH.push(ahz.replace(cg));
}

if(axm)
{
auV.push(aNj.replace(aiI("movie",axm)));
ahH.push(ahz.replace(aiI("src",axm)));
}

return bRe.replace({
id:aG&&[' id="',aG,'"'].join(""),
name:aG&&[' name="',aG,'"'].join(""),
attr:aWB.join(""),
param:auV.join(""),
embed:ahH.join(""),
codebase:location.protocol=="https:"
?''
:'codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" ',
pluginspage:location.protocol=="https:"
?''
:'pluginspage="http://www.adobe.com/cn/products/flashplayer" '
}
);
}







function getFlash(aG,aq)
{
var aA=aq||window,
dj=aA[aG]||aA.document[aG];
return dj&&(dj.length?dj[dj.length-1]:dj);
}

















function zoomFuncCreater(ag)
{














return function(od,kz,bJb,bCy)
{
var avX=bJb||ag.limitWidth||1,
aua=bCy||ag.limitHeight||1,
aCh=(od/avX)||1,
aDd=(kz/aua)||1,
rA=[aCh<1?"w":"W",aDd<1?"h":"H"]
.join(""),
yH=ag[rA]||ag.all,
aE={};

switch(yH)
{
case"stretch":
aE.width=avX;
aE.height=aua;
break;
case"zoomMaxMin":
case"zoomMinMax":
var aYl=od>kz?0:1;
yH=["zoomMax","zoomMin"][yH=="zoomMinMax"
?1-aYl
:aYl];
case"zoomMax":
case"zoomMin":
var Zg=Math[yH=="zoomMax"?"min":"max"](
aDd,aCh
);
aE.width=Math.round(od/Zg);
aE.height=Math.round(kz/Zg);
break;
case"none":
default:
aE.width=od;
aE.height=kz;
break;
}

aE.left=Math.round((avX-aE.width)/2);
aE.top=Math.round((aua-aE.height)/2);

return aE;
};
}










function scrollIntoMidView(bn,eh,bSe,
bLT,bTH)
{
if(!bn||!eh)
{
return false;
}


var aWI=eh.tagName.toUpperCase()=="BODY",
aL=eh.ownerDocument,
sP=aL.documentElement;
if(aWI&&sP.clientHeight)
{
eh=sP;
}

var uh=calcPos(bn)[0]-calcPos(eh)[0]-(aWI?eh.scrollTop:0),
IV=uh,
SY=bn.offsetHeight,
ahj=eh.clientHeight,
aza=bLT||0;

if(bSe||IV<0
||IV+SY>ahj)
{
var aqt=0,
oR;

if(ahj>SY+aza)
{
if(bTH)
{
aqt=IV<0?0
:(ahj-SY-aza);
}
else
{
aqt=(ahj-SY-aza)/2
}
}

oR=eh.scrollTop=eh.scrollTop+uh-aqt;
eh==sP&&(aL.body.scrollTop=oR);
}

return true;
}





function Gel(aG,bn)
{
return(bn||document).getElementById(aG);
}





function objectActive(bn)
{





}




















function inherit(atw,qP,azV,avL,bEo)
{
var aTB=callBack(azV,[qP.prototype]),
bMi=aTB.$_constructor_,
Pj=function()
{
if(arguments[0]!="__inherit__")
{

var aNZ=callBack.call(this,bEo,arguments)||{};
if(aNZ.bReturn)
{
return aNZ.vData;
}
else
{
if(!this.bGA)
{
this.constructor=arguments.callee;
this.bGA=true;
}
qP.apply(this,arguments);
callBack.call(this,bMi,arguments);
}
}
};
extend(Pj.prototype=new qP("__inherit__"),aTB,{toString:function(){return"";}});
return extend(Pj,avL,
{
name:atw,
superclass:qP
}
);
}







function inheritEx(atw,qP,azV,avL)
{
var YG={},
Pj=inherit(atw,qP,azV,avL,
function()
{
var aX=typeof(arguments[0]),
bRr=aX=="string"||aX=="undefined";

return{
bReturn:bRr,
vData:Pj.$_call.apply(Pj,arguments)
};
}
);
return extend(
Pj,
{


$_call:function(aG,bUN,ay)
{
if(arguments.length==0)
{
return YG;
}
else
{
var er=YG[aG];
return arguments.length>1&&er?
callBack.call(er,er[bUN],ay):er;
}
},

$_add:function(aG,aU)
{
return YG[aG]=aU;
},

get:function(aG)
{
return YG[aG];
},

$_del:function(aG)
{
delete YG[aG];
}
}
);
}

























function cacheByIframe(atY,bR)
{
var dI=bR||{},
aA=dI.win||getTop(),
aT=dI.id||unikey("_"),
ge=[dI.attrs],
_oFiles=[];

for(var i=0,_nLen=atY&&atY.length||0;i<_nLen;i++)
{
for(var aiT=atY[i],j=2,byQ=aiT.length;j<byQ;j++)
{
_oFiles.push(aiT[0],":",aiT[1],aiT[j],"|");
}
}

ge.push(' _file="',encodeURIComponent(_oFiles.join("")),'"');
ge.push(' _header="',encodeURIComponent(dI.header||""),'"');
ge.push(' _body="',encodeURIComponent(dI.body||""),'"');

createIframe(aA,getBlankUrl(aA),
extend({},dI,
{
id:aT,
attrs:ge.join(""),
onload:function(aq)
{
var qj=this;
callBack.call(qj,dI.onload,[aq]);

(dI.destroy!=false||qj.getAttribute("destroy")=="true")
&&aA.setTimeout(function(){removeSelf(qj);},100);
}
}
)
);
}





function getBlankUrl(aq)
{
var ja=(aq||getTop()).location,
_sFile=getRes("$base_path$zh_CN/htmledition/domain0b63e8.html");
return[_sFile,"?",
document.domain!=ja.host?encodeURIComponent(document.domain):"",
ja.href.indexOf(_sFile)!=-1?"&r="+Math.random():""].join("");
}








function clearCache()
{












arguments.length>0&&getTop().cacheByIframe(arguments,
{
destroy:false,
onload:function()
{
if(!this.getAttribute("destroy"))
{
this.setAttribute("destroy","true");
this.contentWindow.location.reload(true);
}
}
}
);
}








function preLoad(aw,eA,pd,aYP)
{
if(window!=getTop())
{
getTop().preLoad.apply(this,arguments);
}
else
{
var ae=arguments.callee,
agq=ae.bLI=(ae.bLI||[]);

if(aw&&pd)
{
for(var i=0,_nLen=pd.length;i<_nLen;i++)
{
agq.push([[aw,eA,pd[i]]]);
}
}

if(!ae.aUN&&agq.length>0)
{
ae.aUN=true;

function Zu()
{
ae.aUN=false;
callBack(aYP,[agq.shift()[0][2]]);
setTimeout(function(){ae("","","",aYP);},100);
}

cacheByIframe(agq[0],{onload:Zu});
}
}
}





function setDblClickNoSel(bn)
{
if(bn)
{
var aCn="__MoUSeDoWnnoSEL__";
function getAtts()
{
return(bn.getAttribute(aCn)||"").toString().split(",");
}
function setAtts(ir,aw)
{
bn.setAttribute(aCn,[ir,aw]);
}
if(getAtts().length==1)
{

setAtts(0,"up");
addEvents(bn,{
mousedown:function(_aoEvent)
{
var gj=now(),
CO=parseInt(getAtts()[0]);
setAtts(gj,"down");

if(gj-CO<500)
{
preventDefault(_aoEvent);
}
},

mouseup:function()
{
setAtts(getAtts()[0],"up");
},
selectstart:function(_aoEvent)
{
if(getAtts().pop()=="up")
{
preventDefault(_aoEvent);
}
}
});
}
}

return bn;
}






































var 
gsMsgNoSubject="\u8BF7\u586B\u5199\u90AE\u4EF6\u4E3B\u9898",
gsMsgNoMail="\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6",
gsMsgSend="\u90AE\u4EF6\u6B63\u5728\u53D1\u9001\u4E2D... ",
gsMsgSave="&nbsp;&nbsp;&nbsp;\u90AE\u4EF6\u6B63\u5728\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1...",
gsMsgSaveOk="\u90AE\u4EF6\u6210\u529F\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1",
gsMsgAutoSave="&nbsp;&nbsp;&nbsp;\u90AE\u4EF6\u6B63\u5728\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1...",
gsMsgAutoSaveOk="\u90AE\u4EF6\u81EA\u52A8\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1",
gsMsgSendErrorSaveOK="\u4FE1\u4EF6\u5DF2\u88AB\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1",
gsMsgSaveErr="\u90AE\u4EF6\u672A\u80FD\u4FDD\u5B58\u5230\u8349\u7A3F\u7BB1",
gsMsgNoSender="\u8BF7\u586B\u5199\u6536\u4EF6\u4EBA\u540E\u518D\u53D1\u9001",
gsMsgNoCardSender="\u8BF7\u586B\u5199\u6536\u4EF6\u4EBA\u540E\u518D\u53D1\u9001",
gsMsgNoCard="\u8BF7\u9009\u4E2D\u8D3A\u5361\u540E\u518D\u53D1\u9001",
gsMsgSettingOk="\u8BBE\u7F6E\u4FDD\u5B58\u6210\u529F",
gsMsgLinkErr="\u7F51\u7EDC\u5E94\u7B54\u5931\u8D25",
gsMsgCheatAlert="\u7CFB\u7EDF\u4F1A\u5C06\u6B64\u90AE\u4EF6\u79FB\u5165\u5230\u201C\u5783\u573E\u90AE\u4EF6\u201D\u4E2D\uFF0C\u5E76\u628A\u90AE\u4EF6\u5185\u5BB9\u63D0\u4EA4\u7ED9\u90AE\u7BB1\u7BA1\u7406\u5458\u3002\n\n\u60A8\u786E\u5B9A\u8981\u4E3E\u62A5\u6B64\u90AE\u4EF6\u5417\uFF1F",
gsMsgSendTimeErr="\u60A8\u8BBE\u7F6E\u7684\u53D1\u9001\u65F6\u95F4\u4E0D\u5B58\u5728",
gsMsgMoveMailSameFldErr="\u4E0D\u80FD\u79FB\u52A8\u5230\u76F8\u540C\u7684\u76EE\u5F55";








function doPageError(_asMsg,bc,DG)
{
var il=arguments.callee.caller,
aiQ=il&&il.caller,
bmU=aiQ&&aiQ.caller,
aHd=(il||"null").toString(),
aCB=(aiQ||"").toString(),
aCo=(bmU||"").toString(),
acg;

try
{

if(_asMsg.indexOf(" Script ")!=-1)
{
return;
}


log("err:",_asMsg,"-",bc,"-",DG);

if(_asMsg.indexOf("flashUploader")!=-1)
{
var bbA=qmFlash.getFlashVer();
for(var i in bbA)
{
_asMsg+="|"+bbA[i];
}
}

if(!(bc&&bc.indexOf("/cgi-bin/mail_list?")!=-1&&DG==2)&&location.getParams)
{
var cX=location.getParams(bc);
aXS=(bc||"").split("?")[0].split("/"),
aRH=encodeURIComponent(
aHd.replace(/[\r\n\t ]/ig,"")
.substr(0,50)
);

if(aXS.length>0)
{
cX.cgi=aXS.pop();
getTop().ossLog("delay","sample",[
"stat=js_run_err&msg=",
_asMsg,
"&line=",
DG,
"&url=",
T('$cgi$?t=$t$&s=$s$').replace(cX),
"&func=",
aRH,(gbIsIE?"":"_NIE")
].join(""));
}
else
{
acg=aRH;
}
}

getTop().debug([
"error:",
_asMsg,
"<br><b>line</b>:",
DG,
"<br><b>url</b>:",
bc,
"<br><b>function</b>:",
aHd.substr(0,100),
aCB?"<br><b>parent function</b>:"
+aCB.substr(0,100):"",
aCo?"<br><b>parent parent function</b>:"
+aCo.substr(0,100):""].join(""),"error");
}
catch(aZ)
{
acg=aZ.message;
}

acg&&log("err:doPageError ",acg,"-",bc,"-",DG);







return location.host.indexOf("dev.")!=0;
}




var QMFileType={};

QMFileType.data={
doc:"doc",
docx:"doc",

xls:"exl",
xlsx:"exl",

ppt:"ppt",
pptx:"ppt",

pdf:"pdf",

txt:"txt",
log:"txt",
xml:"txt",
js:"txt",
css:"txt",
php:"txt",
asp:"txt",
aspx:"txt",
jsp:"txt",
vbs:"txt",
h:"txt",
cpp:"txt",

eml:"eml",

rar:"rar",
zip:"rar",
"7z":"rar",
arj:"rar",

wav:"mov",
mp3:"mov",
wma:"mov",
mid:"mov",
rmi:"mov",
ra:"mov",
ram:"mov",

mp1:"mov",
mp2:"mov",
mp4:"mov",
rm:"mov",
rmvb:"mov",
avi:"mov",
mov:"mov",
qt:"mov",
mpg:"mov",
mpeg:"mov",
mpeg4:"mov",
dat:"mov",
asf:"mov",
wmv:"mov",
"3gp":"mov",
ac3:"mov",
asf:"mov",
divx:"mov",
mkv:"mov",
ogg:"mov",
pmp:"mov",
ts:"mov",
vob:"mov",
xvid:"mov",

htm:"html",
html:"html",
mht:"html",

swf:"swf",
flv:"swf",

bmp:"bmp",
gif:"gif",
jpg:"jpg",
jpeg:"jpg",
jpe:"jpg",
psd:"psd",
pdd:"psd",
eps:"psd",

tif:"tu",
tiff:"tu",
ico:"tu",
png:"tu",
pic:"tu",
ai:"tu"
};






QMFileType.getFileType=function(aaC)
{
return this.data[(trim(aaC||"")).toLowerCase()]||"qita";
};






QMFileType.getFileTypeForFile=function(gp)
{
return this.getFileType((gp||"").split(".").pop());
};






var QMHistory={
Yt:{




},
Zp:{





}
};






QMHistory.getId=function(aG)
{
return aG;
};






QMHistory.getUrl=function(aG)
{
var bz=getTop().QMHistory.Zp[QMHistory.getId(aG)];
return bz&&bz.aO;
};





QMHistory.getLastRecordId=function()
{
return getTop().QMHistory.Yt.bNh;
};






QMHistory.tryBackTo=function(aG)
{
try
{
var cg=getTop().QMHistory.Yt,
aeq=QMHistory.getId(aG),
Ot=getTop().QMHistory.Zp[aeq],
aTh=Ot&&Ot.aO,
aQx=Ot
&&Ot.bKU>=getTop().history.length,
aQy=Ot&&cg.bGe==aTh,
aQz=Ot&&!cg.bKa;

function bEt()
{
var aO=aTh.split("#")[0];

if(getTop().location.getParams
&&getTop().location.getParams(aO)["folderid"]==4)
{
return goUrlMainFrm(aO);
}


if(gbIsIE&&gnIEVer==6)
{
return getTop().history.go(aO);
}
getTop().history.back();
};

if((gbIsIE&&(aQx||aQy)&&aQz)
||(!gbIsWebKit&&aQx&&aQy&&aQz))
{

bEt();
return true;
}
}
catch(aZ)
{

}

return false;
};





QMHistory.recordCurrentUrl=function(aq)
{
var aO=aq.location.href,
IW=getTop().QMHistory.Zp,
cg=getTop().QMHistory.Yt;

var bEk=cg.bGe=cg.bAo,
DH=cg.bAo=aO;

var Zd,QN;


for(var i in IW)
{
if(IW[i].aO==bEk)
{
Zd=i;
}
if(IW[i].aO==DH)
{
QN=i;
}
}


if(Zd&&QN)
{
delete IW[Zd];
}


if(aO.indexOf("/mail_list")!=-1)
{
this.azz("mail_list",aO);
}

if(aO.indexOf("t=readmail")!=-1)
{
this.azz("readmail",aO);
}

if(aO.indexOf("/today")!=-1)
{
this.azz("today",aO);
}
};





QMHistory.recordActionFrameChange=function(cL)
{
getTop().QMHistory.Yt.bKa=cL!="clear";
};






QMHistory.azz=function(aG,bc)
{
var _oTop=getTop(),
aeq=QMHistory.getId(aG),
IW=_oTop.QMHistory.Zp,
bz=IW[aeq];

if(!bz)
{
bz=IW[aeq]=new _oTop.Object;
}

bz.bKU=history.length+1;
bz.aO=bc;

_oTop.QMHistory.Yt.bNh=aG;
};












function QMCache(ag)
{
var CO=this.bFp=ag.timeStamp||1;
var GR=this.Tj=ag.appName;

if(!CO||!GR)
{
throw{
message:"QMCache construct : config error!"
};
}

var aef=getTop().QMCache.NM;
if(!aef)
{
aef=getTop().QMCache.NM={};
}

var EE=aef[GR];
if(!EE)
{
EE=aef[GR]={
avr:"0",
qN:{}
};
}

if(this.bcA(EE.avr,CO)==1)
{
EE.avr=CO;
}
};





QMCache.prototype.isHistoryTimeStamp=function()
{
return this.bcA(
getTop().QMCache.NM[this.Tj].avr,
this.bFp
)!=0;
};






QMCache.prototype.setData=function(bA,bK)
{
getTop().QMCache.NM[this.Tj][bA]=bK;
};

QMCache.prototype.getAll=function(bA)
{
return getTop().QMCache.NM[this.Tj];
}






QMCache.prototype.getData=function(bA)
{
return getTop().QMCache.NM[this.Tj][bA];
};





QMCache.prototype.delData=function(bA)
{
delete getTop().QMCache.NM[this.Tj][bA];
};







QMCache.prototype.bcA=function(bbe,bbf)
{
if(bbe==bbf)
{
return 0;
}
return bbe>bbf?-1:1;
};








var QMMailCache=
{
Jr:now()
};







QMMailCache.newCache=function(tk,axD)
{
var Nz=false,
_oTop=getTop();

if(!_oTop.gMailListStamp||_oTop.gMailListStamp<axD)
{
_oTop.gMailListStamp=axD;
if(!_oTop.goMailListMap)
{
_oTop.goMailListMap=new _oTop.Object;
}
Nz=true;
}
else if(_oTop.gnExpireTimeStamp>=axD)
{







reloadFrm(tk);
}

return tk["isNewQMMailCache"+this.Jr]=Nz;
};




QMMailCache.setExpire=function()
{
getTop().gnExpireTimeStamp=getTop().gMailListStamp;
};













QMMailCache.addData=function(aI,aQ)
{
if(!aI||!getTop().goMailListMap)
{
return;
}

if(!this.hasData(aI))
{
getTop().goMailListMap[aI]={
oTagIds:{},
bUnread:null,
star:null,
reply:null
};
}

if(!aQ)
{
return;
}

var gv=getTop().goMailListMap[aI];
for(var i in aQ)
{
switch(i)
{
case"removeTagId":
gv.oTagIds[aQ[i]]=0;
break;
case"addTagId":
gv.oTagIds[aQ[i]]=1;
break;
default:
if(typeof aQ[i]!="undefined")
{
gv[i]=aQ[i];
}
break;
}
}
};





QMMailCache.delData=function(aI)
{
if(getTop().goMailListMap)
{
delete getTop().goMailListMap[aI];
}
};






QMMailCache.hasData=function(aI)
{
return getTop().goMailListMap&&getTop().goMailListMap[aI]!=null;
};






QMMailCache.getData=function(aI)
{
return getTop().goMailListMap&&getTop().goMailListMap[aI];
};







QMMailCache.addVar=function(aiw,bW)
{
return getMainWin()[aiw]=this.getVar(aiw,0)+bW;
};







QMMailCache.getVar=function(aiw,bAQ)
{
return getMainWin()[aiw]||bAQ;
};






QMMailCache.isRefresh=function(tk)
{
return tk["isNewQMMailCache"+this.Jr];
};










function rdVer(OM,VE,ayw)
{

var asJ,oV,JO,auf,
bz=new QMCache({appName:"readmail"});

if(VE==-1)
{
return bz.delData(OM);
}

asJ=bz.getData("on");
if(OM=="on")
{
return VE==0?(asJ||0):(bz.setData("on",VE));
}

if(!asJ||!OM)
{
return 0;
}

auf=OM=="BaseVer";

JO=bz.getData("BaseVer");
if(!JO||(auf&&VE==1))
{

JO=JO||(rdVer("on",0)+(+Math.random().toFixed(2)));
JO+=10;
bz.setData("BaseVer",JO);
}

if(auf)
{
return JO;
}

oV=(bz.getData(OM)||0);
var aPg=(!oV||VE==1);

if(aPg||ayw)
{
if(aPg)
{
oV+=10000;
}
if(ayw)
{
oV=Math.floor(oV/10000)*10000+parseInt(ayw,10)%10000;
}
bz.setData(OM,oV);
}
return oV;
}

rdVer.batch=function(aw)
{
var bz=new QMCache({appName:"readmail"}),
jN=new RegExp("^"+aw),
gv=bz.getAll();

E(gv,function(aao,aI)
{
if(jN.test(aI))
{
rdVer(aI,1);
}
}
);
}






rdVer.check=function(aq,aI,adn)
{
if(aq)
{
var ja=aq.location,
aI=aI||ja.getParams()["mailid"],
adn=adn||ja.getParams()["ver"]||0,
aWZ=rdVer(aI,0);

if(aWZ>adn)
{
goUrl(aq,cookQueryString(ja.href,{ver:aWZ}),true);
return true;
}
else
{
return false;
}
}
}






rdVer.log=function(aI,amG)
{
var azD=new QMCache({appName:"preload"}),
aEx=new Date().getTime(),
ej=azD.getData(aI),
axg=ej&&(aEx-ej)<rdVer.maxage(aI)*1000;

switch(amG)
{
case"pre":
if(!axg)
{
azD.setData(aI,aEx);
ossLog("delay","all","stat=rdcache&type=281&locval=,rdcache,preload,1");
}
break;
case"hit":
if(axg)
{
ossLog("delay","all","stat=rdcache&type=291&locval=,rdcache,hit,1");
}
if(ej)
{
azD.delData(aI);
}
break;
}
return axg;
}

rdVer.isPre=function(Om)
{

return!(Om>2&&Om<7||Om==9||Om==11);
}


rdVer.preRD=function(Qc,Qj)
{
var ali=function()
{
preLoad("html","/cgi-bin/readmail?",Qc,function(iO)
{
rdVer.log(location.getParams(iO)["mailid"],"pre");
}
);
}
if(Qc&&Qc.length>0)
{
Qj=Qj||40;

Qc=Qc.slice(0,rdVer("on",0)>1?2:1);

if(Qc.length>0)
{
if(Qj)
{
setTimeout(ali,Qj);
}
else
{
ali();
}
}
}
}

rdVer.maxage=function(aI)
{
if(!aI)
{
return 0;
}
return(aI[0]=="@"||aI[0]=="C"?10:60)*60;
}










rdVer.url=function(aI,nx,bAC,dD,bBn,YM,
asZ,awi,aXV)
{
var aTv='/cgi-bin/$cgi$?folderid=$folderid$$s$&t=$t$&mailid=$mailid$$cache$&sid=$sid$',
axw,
Gc,AR,aO,uD="readmail";

if(asZ)
{
Gc="readmail&s=draft";
}
else if(dD===0)
{
Gc=awi==100?"compose_card&s=draft"
:"compose&s=draft";
}
else if(nx=="9")
{
aTv=[location.protocol,"//msgopt.mail.qq.com",aTv].join("");
Gc="sms_list_v2";
uD="readtemplate";
}
else if(nx=="11"||/^(LP|ZP)/.test(aI))
{
uD="bottle_panel";
Gc="bottle";
}
else
{
switch(aI.charAt(0))
{
case'C':
Gc="readmail_conversation";
break;
case'@':
Gc="readmail_group";
break;
default:
Gc="readmail";
break;
}
axw=true;
}

if(bBn)
{
AR=["&newwin=true","&compose_new=compose"][dD?0:1];
}
else
{
AR=["","&s=from_unread_list","&s=from_star_list"][
YM!=1&&YM!=2?0:YM];
}

var oV=axw?rdVer(aI,0,bAC):0;

if(!oV&&aXV)
{
return"";
}

aO=T(aTv).replace(
{
cgi:uD,
mailid:aI,
folderid:nx,
t:Gc,
s:AR,
sid:getSid(),
cache:oV?T("&mode=pre&maxage=$maxage$&base=$base$&ver=$ver$").replace(
{
maxage:rdVer.maxage(aI),
base:rdVer("BaseVer",0),
ver:oV
}
):""
}
);

return aXV?aO.split("?")[1]:aO;
}









function setGlobalVarValue(bA,fe,bBI)
{
var _oTop=getTop();

if(!_oTop.goDataBase)
{
_oTop.goDataBase=new _oTop.Object;
}

if(bA&&!bBI)
{
_oTop.goDataBase[bA]=fe;
}

return fe;
}






function getGlobalVarValue(bA)
{
return getTop().goDataBase&&getTop().goDataBase[bA];
}






function hideWindowsElement(gl,aq)
{
aq=aq||getMainWin();
if(!gbIsIE||gnIEVer>6||(aq.gbIsHasHideElements||false)!=(gl||false))
{
return;
}

getTop().setGlobalVarValue("WINDOWS_ELEMENT_NOT_DISPLAY",gl?"":"true");

aq.gbIsHasHideElements=!gl;

var cY=aq.document.body;

E(aq.QMReadMail?["select","object","embed"]:["select"],
function(bJI)
{
E(GelTags(bJI,cY),
function(bn)
{
if(gl)
{
bn.style.visibility=
bn.getAttribute("savevisibility");
}
else
{
bn.setAttribute("savevisibility",
getStyle(bn,"visibility"));
bn.style.visibility="hidden";
}
}
);
}
);
}






function controlWindowsElement()
{
var bPJ=getTop().getGlobalVarValue("WINDOWS_ELEMENT_NOT_DISPLAY");
if(bPJ=="true")
{
hideWindowsElement(false);
}
}





function setKeepAlive(aq)
{
if(getTop().gKeepAliveNum==null)
{
getTop().gKeepAliveNum=0;
}

if(aq==null||aq.gbIsSetKeepAlive==true)
{
return;
}

aq.gbIsSetKeepAlive=true;
getTop().gKeepAliveNum++;

if(getTop().gKeepAliveTimer==null)
{

getTop().gKeepAliveTimer=getTop().setInterval(
function()
{
getTop().runUrlWithSid("/cgi-bin/readtemplate?t=keep_alive");
},
15*60*1000
);
}
addEvent(
aq,
"unload",
function()
{
aq.gbIsSetKeepAlive=false;
getTop().gKeepAliveNum--;
if(getTop().gKeepAliveNum==0)
{
getTop().clearInterval(getTop().gKeepAliveTimer);
getTop().gKeepAliveTimer=null;
}
}
);
}







function encodeNick(pT)
{
return pT&&pT.replace(/\\/g,"\\\\").replace(/\"/ig,"\\\"").replace(/\'/ig,"\\\'")||"";
}






function decodeNick(pT)
{
return pT&&pT.replace(/\\\"/ig,"\"").replace(/\\\\/ig,"\\")||"";
}






function rollback(dD)
{
var acJ=getGlobalVarValue('DEF_ROLLBACK_ACTION');
if(acJ&&acJ.rbkey)
{
confirmBox({
title:"\u64A4\u9500\u786E\u8BA4",
mode:"prompt",

height:135,
msg:T([
'<b>\u64A4\u9500\u6700\u8FD1\u4E00\u6B21$msg$\u5417\uFF1F</b>',
]).replace(acJ),
onreturn:function(aV)
{
if(aV)
{
QMAjax.send("/cgi-bin/mail_mgr",
{
method:"POST",
content:["sid=",getSid(),"&mailaction=mail_revert&t=mail_mgr2&timekey=",acJ.rbkey,"&logtype=",dD].join(''),
onload:function(aV,bQ)
{
if(aV&&bQ.indexOf("mail_revert successful")>=0)
{
var tG=getMainWin().location.getParams()["t"];
debug(["_sT",tG,!tG,getMainWin().location.href]);
if(tG=="mail_list"||tG=="mail_list_group"||(!tG&&getMainWin().location.href.indexOf("/cgi-bin/mail_list?")>-1))
{
reloadFrmLeftMain(true,true);
}
else if(tG=="folderlist_setting")
{
goUrlMainFrm(getMainWin().location.href.replace(/\#.+/,"").replace(/&s=.+?(&|$)/,"&")+"&s="+getMainWin().getType());
reloadFrmLeftMain(true,false);
}
else
{
reloadFrmLeftMain(true,false);
}

setGlobalVarValue('DEF_ROLLBACK_ACTION',null);
showInfo("\u6210\u529F\u64A4\u9500\u6700\u8FD1\u4E00\u6B21"+acJ.msg);
}
else
{
var aZ=globalEval(bQ);
showInfo(aZ&&aZ.errmsg||("\u64A4\u9500\u6700\u8FD1\u4E00\u6B21"+acJ.msg+"\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5"));
}
}
});
}
}
});
}
}


var QMPageInit={
aYT:function(aq)
{
var _oTop=getTop();
if(aq==_oTop)
{
var il=new(_oTop.Function)(
"var _oLogs = arguments.callee.logs;_oLogs.length > 500 && _oLogs.shift();"+
"_oLogs.push([+new Date, [].slice.apply(arguments).join('')].join(' '));");
il.logs=new(_oTop.Array);
return il;
}
else
{
return _oTop.log||(_oTop.log=this.aYT(_oTop));
}
},

bXo:function(bSU)
{
return function()
{
try
{
var aAa=arguments.length,
atm=arguments[aAa-1],
aOI=atm>100000;
if(typeof(atm)=="number"
&&(aOI&&atm!=getTop().g_uin))
{
return;
}
}
catch(e)
{

return;
}

if(getTop().Console)
{
if(aAa==0||(aAa==1&&aOI))
{
if(location.host=="dev.mail.qq.com")
{
debugger;
}
}
else
{
try
{
var _oConsole=getTop().Console[bSU];
_oConsole.add.apply(_oConsole,arguments);
}
catch(aZ)
{
}
}
}
}
},

bII:function(aq)
{
return function(aK,bzb,cL,bCU,dH)
{
if(getTop().QMTimeTracer&&(!dH||dH==getTop().g_uin))
{
getTop().QMTimeTracer.getTracer().trace(aK,bzb,
aq,cL,bCU
);
}
}
},

bGR:function(aq)
{
var pB=aq.location;
pB.aXI=false;
pB.params={};
pB.getParams=function(bc)
{
if(!bc&&this.aXI)
{
return this.params;
}

var cX={},
aIV=bc
?bc.substr(bc.indexOf("?")+1).split("#")[0]
:this.search.substr(1);

if(aIV)
{
E(aIV.split("&"),function(mA)
{
var bT=mA.split("=");
cX[bT.shift()]=unescape(bT.join("="));
}
);
}

if(!bc)
{
this.params=cX;
this.aXI=true;
}

return cX;
};

var fz=pB.href,
_oTop=getTop();

if(aq==_oTop
&&getSid()
&&fz.indexOf("/cgi-bin/")>-1
&&fz.indexOf("/frame_html?")==-1
&&fz.indexOf("/log")==-1
&&(fz.indexOf("/ftnExs_")==-1||fz.indexOf("/ftnExs_files")>-1)
&&!aq.gbIsNoCheck
&&pB.getParams()["nocheckframe"]!="true")
{
if(fz.indexOf("/cgi-bin/bizmail")==-1)
{

goNewWin(pB,true,!aq.gbSupportNW);
}
else
{
goNewWin(pB,true,false,{frametmpl:"dm_frame",frametmplparam:"&dmtype=bizmail"});
}
}

else if(aq!=_oTop&&_oTop.bnewwin&&aq==getMainWin())
{
if(!aq.gbSupportNW)
{
goNewWin(pB,true,true);
}
else if(pB.getParams()["newwin"]!="true")
{
aq.location.replace(fz+"&newwin=true");
}
}
},

bEP:function(_aoEvent,bRs)
{
var dh=_aoEvent.srcElement||_aoEvent.target,
acO=_aoEvent.ctrlKey,
ead=_aoEvent.altKey,
uG=_aoEvent.shiftKey,
dhh=_aoEvent.metaKey,
dG=_aoEvent.keyCode,
Sb=dh.type=="text"
||dh.tagName=="TEXTAREA",
bYi=bRs
&&(dh.tagName=="INPUT"&&dh.type!="button"),
bTk=dh.tagName=="BUTTON"||dh.type=="button";

switch(dG)
{

case 8:

if(!Sb&&goBackHistory())
{
preventDefault(_aoEvent);
}
break;

case 13:


if(!bTk&&((!Sb&&QMReadedItem.read(dh))||bYi))
{
preventDefault(_aoEvent);
}
break;

case 37:

case 39:

if(acO)
{
goPrevOrNextMail(dG==39);
preventDefault(_aoEvent);
}
break;

case 38:

case 40:

case 188:

case 190:

if(!Sb)
{
var UT=dG==38||dG==188;
if(QMReadedItem.move(!UT))
{
preventDefault(_aoEvent);
}
}
break;

case 46:


if(!Sb)
{
var bcS=S(
uG?"quick_completelydel":"quick_del",
getMainWin()
),
bcT=uG?S("quick_del",getMainWin()):null,
bcW=S("del",getMainWin());
if(isShow(bcS)||isShow(bcT)||isShow(bcW))
{
preventDefault(_aoEvent);
fireMouseEvent((bcS||bcT||bcW),"click");
}
}
break;

case 88:

if(!Sb&&QMReadedItem.check(uG))
{
preventDefault(_aoEvent);
}
break;
case 90:
var yw=dh.tagName.toUpperCase();
if(acO&&!(yw=="INPUT"&&dh.type.toLowerCase()!="button"||yw=="TEXTAREA"))
{
rollback(1);
}
break;

case 65:
if(!Sb&&(dhh||acO))
{
preventDefault(_aoEvent);
var cyR=S("frm",getMainWin());
if(cyR)
{
var cfY=GelTags("table",cyR)[0];
if(cfY)
{
var NI=GelTags("input",cfY)[0];


!NI.addEventListener&&NI.click&&NI.click()
||fireMouseEvent(NI,"click");

}
}
}
break;
}
},

bAF:function(aq)
{
aq.Log=aq.log=this.aYT("log");
aq.Debug=aq.debug=this.bXo("debug");

aq.Trace=aq.trace=this.bII(aq);
aq.onerror=doPageError;
},

bTi:function(aq)
{
if(aq!=getTop()&&aq==getMainWin())
{

getTop().QMHistory.recordCurrentUrl(aq);
getTop().QMHistory.recordActionFrameChange("clear");


var ae=this,fz=aq.location.href,
azi=fz.indexOf("t=sms_list_v2")>0,
bVW=fz.indexOf("t=bottle")>0;

addEvents(aq,
{load:function()
{
initAD(aq)
},
unload:function()
{

showProcess(0);
if(isshowMsg()&&getTop().gMsgDispTime
&&now()-getTop().gMsgDispTime>2000)
{
hiddenMsg();
}

azi&&startWebpush(2);

}
});

azi&&closeWebpush(2);
bVW&&closeWebpush(4);
getTop().QMWebpushTip&&getTop().QMWebpushTip.hideAll(3000);

aq.setTimeout(function()
{



















if(!(getTop().QQPlusMail&&getTop().QQPlusMail.getPageTitle()))
{
aq.document.title&&(getTop().document.title=aq.document.title);
}

},
200
);
}
},

bHU:function(aq)
{

if(aq==getTop()&&aq.location.href.indexOf("/frame_html")!=-1)
{



















addEvents(aq,{
load:function(e)
{
var cY=getTop().document.body;

function aRY(_aoEvent)
{
var dh=_aoEvent.srcElement||_aoEvent.target;

for(var Cx=0;dh&&Cx<3;
dh=dh.parentNode,Cx++)
{
if(dh.tagName=="A")
{
break;
}
}

return dh||{};
};

function bLQ(_aoEvent)
{
if((_aoEvent.target||_aoEvent.srcElement)==cY)
{
preventDefault(_aoEvent);
}
}

function aYY(_aoEvent)
{
var dh=aRY(_aoEvent);
if(dh.tagName=="A")
{
if(dh.getAttribute("initlized")!="true")
{
dh.setAttribute("initlized","true");

var aTM=dh.onclick;
dh.onclick=function(bVl)
{
var bJ=bVl||getTop().event,
dS=parseInt(dh
.getAttribute("md"));
if(!isNaN(dS)&&dS>0)
{
getTop().clearTimeout(dS);
dh.setAttribute("md","0");

var uG=bJ.shiftKey,
acO=bJ.ctrlKey,
bWt=bJ.metaKey,
aVE=uG||acO||bWt,
aRx=trim(dh.href)
.indexOf("http")==0;

function aZD()
{
if(aTM)
{
aTM.call(dh);
preventDefault(bJ);
}

if(aRx)
{
if(aVE&&dh.href.indexOf("java")!=0)
{
open(dh.href);
preventDefault(bJ);
}
else
{
switch(dh.target)
{
case"mainFrame":
var aO=dh.href;
goUrlMainFrm(
aO+(aO.indexOf("?")!=-1?"#stattime="+now():""),
false
);
preventDefault(bJ);
break;
case"_parent":
case"_self":
try
{
aq.location.href=dh.href;
}
catch(zt)
{
}
preventDefault(bJ);
break;
default:
break;
}
}
}
};

if(!aVE
&&dh.getAttribute("nocheck")!="true"
&&(!aRx||dh.target!="_blank"))
{
preventDefault(bJ);
QMPageInit
.bai(aZD);
}
else
{
aZD();
}
}
};
}

dh.setAttribute(
"md",
getTop().setTimeout(
function()
{
dh.setAttribute("md","0");
},
1000
)
);
}

}

function ame(_aoEvent)
{
var dh=aRY(_aoEvent);
if(dh.tagName=="A"
&&dh.getAttribute("initlized")!="true")
{
preventDefault(_aoEvent);
}
}

addEvents(cY,
{
mousewheel:bLQ,
mousedown:aYY,
keydown:aYY,
click:ame
}
);
}


});
}
},

bPY:function(aq,_aoEvent)
{
var tG,
bce=["u","1","2","3","4"],
aB=getEventTarget(_aoEvent),
bcX=function(_aoDom)
{
if(_aoDom&&_aoDom.getAttribute)
{
var Aq=_aoDom.getAttribute("t");
for(var i in bce)
{
if(bce[i]==Aq)
{
return Aq;
}
}
}
};

tG=bcX(aB);

while(aB&&aB!=aq.document.body&&tG)
{
if(tG=="u")
{
aB=aB.parentNode;
tG=bcX(aB)||tG;
}
else
{
return aB;
}
}
return null;
},

bbo:function(aw,aq,_aoEvent)
{
var aB=this.bPY(aq,_aoEvent);
if(aB)
{
var tG=aB.getAttribute("t");
switch(tG)
{
case"1":
case"2":
case"3":
waitFor(
function()
{
return getTop().QMProfileTips;
},
function(pl)
{
if(pl)
{
getTop().QMProfileTips.doMouseEvent(aw,aq,aB);
}
}
);
break;
case"4":
var aeM="simpletip",
aZq="stitle",
aRi="smt_hide";
if(aB.title)
{
aB.setAttribute(aZq,aB.title);
aB.title="";
}
if(aw=="over")
{
var gO=aB.getAttribute(aZq),
qx=S(aeM,aq);
if(!qx)
{
insertHTML(aq.document.body,"afterBegin",'<div id="'+aeM+'" class="smt_container smt_u smt_hide"><span class="smt_inner"></span></div>');
qx=S(aeM,aq);
}
if(qx)
{
qx.firstChild.innerHTML!=gO&&(qx.firstChild.innerHTML=gO);
rmClass(qx,aRi);

var JM=calcPos(aB),
aYf=(JM[1]+JM[3])/2;
JM[0]-=3;
JM[2]+=3;

var	cF=parseInt(qx.offsetHeight),
cy=parseInt(qx.offsetWidth),
_oPos=calcAdjPos([JM[0],aYf,JM[2],aYf],cy,cF,aq,2),
kb=qx.className,
bcq=_oPos[2]==JM[0]?"smt_d":"smt_u";
if(kb.indexOf(bcq)<0)
{
qx.className="smt_container "+bcq;
}
qx.style.top=_oPos[0]+"px";
qx.style.left=(_oPos[3]-cy/2)+"px";
}
}
else if(aw=="out")
{
var qx=S(aeM,aq);
qx&&addClass(qx,aRi);
}
break;
}
}
},

bAg:function(aq)
{
aq.call=function()
{
var bk=arguments,aNR=[],i,l,
ge=bk[0].split("."),
ae=il=aq;

for(i=1,l=bk.length;i<l;i++)
{
aNR.push(bk[i]);
}

for(i=0,l=ge.length;i<l&&il;i++)
{
ae=il;
il=il[ge[i]];
}

if(typeof il=="function")
{
return il.apply(ae,aNR);
}
}
},



bEY:function(aq)
{
var ae=this;
aq.setTimeout(
function()
{
var bFX=(aq.location.getParams
&&aq.location.getParams()["t"]||"")
.indexOf("compose")==0;

addEvents(aq.document,
{
mousedown:hideMenuEvent,
touchend:getTop().iPadCloseMenu||function(){},
keydown:function(_aoEvent)
{
hideMenuEvent(_aoEvent);
ae.bEP(_aoEvent,bFX);
},
click:function(_aoEvent)
{
hideEditorMenu();


getTop().QMWebpushTip&&getTop().QMWebpushTip.hideAll(3000);
},
mouseover:function(_aoEvent)
{
ae.bbo("over",aq,_aoEvent);
},
mouseout:function(_aoEvent)
{
ae.bbo("out",aq,_aoEvent);
}
}
);
},100
);
},

Xc:function(aq)
{
aq=aq||window;

if(aq.gIsInitPageEventProcess)
{
return;
}

aq.gIsInitPageEventProcess=true;

var jR=0;
try
{
jR=1;
this.bAF(aq);

jR=2;
this.bGR(aq);

jR=3;
this.bTi(aq);

jR=4;
this.bHU(aq);

jR=5;
this.bEY(aq);

jR=6;
this.bAg(aq);
}
catch(aZ)
{
doPageError(aZ.message,aq.location.href,
"initPageEvent_processid:"+jR
);
}

try
{

aq.document.execCommand("BackgroundImageCache",false,true);
}
catch(aZ)
{
}
},

bai:function(akb)
{
try
{
if(getMainWin().exitConfirm)
{
return getMainWin().exitConfirm(akb);
}
}
catch(aZ)
{
debug(aZ.message);
}


akb();
}
}





function initPageEvent(aq)
{
QMPageInit.Xc(aq);
}

(function()
{
initPageEvent(window);
})();






function getTopWin()
{
return getTop();
}





function getMainWin()
{
return F("mainFrame",getTop())||getTop();
}





function getActionWin()
{
return F("actionFrame",getTopWin());
}





function getLeftWin()
{
return getTop();
}
var GetLeftWin=getLeftWin;





function getLeftDateWin()
{
return F("leftFrame",getTop());
}





function getSignatureWin()
{
return F("signatureFrame",getTop());
}






function reloadFrm(aq)
{
if(aq&&aq!=getTop())
{
try
{
if(aq.location.search)
{


var ahb=aq.location.href.split("#")[0].split("?"),
aTW="r="+now();
ahb[1]=!ahb[1]?aTW:
(("&"+ahb[1]+"&").replace(/&r=.*?&/,"&")+aTW).slice(1);
aq.location.replace(ahb.join("?"));
return true;
}
}
catch(aZ)
{
}
}
return false;
}




function reloadLeftWin()
{
var zC;
if(!reloadFrm(getLeftDateWin())&&(zC=S("leftFrame",getTop())))
{
zC.src=T('/cgi-bin/folderlist?sid=$sid$&r=$rand$').replace(
{
sid:getSid(),
rand:Math.random()
}
);
}
}








function reloadAllFrm(dnT,dPd,aet,ahh)
{
function Ib(bQJ)
{
var aNY=arguments.callee;
getTop().setTimeout(bQJ,aNY.jM);
aNY.jM+=200;
}
Ib.jM=0;

if(ahh==null||ahh)
{
Ib(
function()
{
reloadFrm(getMainWin());
}
);
}

if(aet==null||aet)
{
Ib(
function()
{
reloadFrm(reloadLeftWin());
}
);
}
}






function reloadFrmLeftMain(aet,ahh)
{
reloadAllFrm(false,false,aet,ahh);
}













function goUrlTopWin(bc,bFW)
{

goUrl(getTop(),bc,!bFW);
}







function goUrlMainFrm(bc,bBN,aST)
{
if(bBN!=false)
{
reloadLeftWin();
setTimeout(
function()
{
goUrl(S("mainFrame",getTop())||getTop(),bc,!aST);
},
300
);
}
else
{
goUrl(S("mainFrame",getTop())||getTop(),bc,!aST);
}
}

function bNV(aaU)
{
return aaU&&aaU.substr&&("?"+(["&",aaU.substr(1),"&"].join("")
.replace(/&sid=.*?&/ig,"&")
.replace(/&loc=.*?&/ig,"&")
.replace(/&newwin=true/ig,"&")
.slice(1,-1)));
}










function goNewWin(OW,bWd,bUk,aiq)
{
var aak="",
AT="",
nT="";

if(typeof(OW)=="object")
{
aak=OW.pathname;
AT=OW.search;
}
else
{
var tx=OW.indexOf("?");
aak=OW.substring(0,tx);
AT=OW.substr(tx);
}

if(aiq)
{
nT=aiq.frametmpl;
}
else
{
nT=bUk?"frame_html":"newwin_frame";
}

var aRN='';
if(aak.indexOf('reader_')>-1)
{
aRN=getTop().location.protocol+"//mail.qq.com";
}

var aO=T(aRN+'/cgi-bin/frame_html?t=$t$&sid=$sid$&url=$url$').replace(
{
t:nT,
sid:getSid(),
url:encodeURI(aak+bNV(AT))
}
);

if(aiq)
{
aO+=aiq.frametmplparam;
}

if(bWd)
{
goUrlTopWin(aO,true);
}
else
{

window.open(aO);
}
}






function isMaximizeMainFrame()
{
return getTop().maximizeMainFrame.bEE;
}






function maximizeMainFrame(aiu)
{
var atk=S("mainFrame",getTop()),
ahv=S("leftPanel",getTop()),
aiY=S("imgLine",getTop());

if(!atk||!aiY||!ahv
||aiu!=2&&(aiu==0)==!isMaximizeMainFrame())
{
return false;
}

var WS=getTop().maximizeMainFrame,
EY=WS.bEE=aiu==2
?!isMaximizeMainFrame():(aiu?true:false);

if(EY)
{
WS.bXm=ahv.style.width;
WS.bDa=aiY.parentNode.style.cssText;
}

atk.parentNode.style.marginLeft=
EY?"5px":WS.bXm;
ahv.parentNode.style.cssText=
EY?"border-left:none;":"";
aiY.parentNode.style.cssText=
(EY?"border-left:none;margin-left:0;padding:0;":"")+WS.bDa;

show(ahv,!EY);
show(aiY,!EY);
show(S("qqplus_panel",getTop()),!EY);
show(S("folder",getTop()),!EY);
}







function filteSignatureTag(bL,cL)
{
var fI=typeof bL=="string"?bL:"";

if(cL=="2LOWCASE")
{
return fI.replace(/<sign(.*?)\/>/ig,"<sign$1>")
.replace(/<qzone(.*?)\/>/ig,"<qzone$1>")
.replace(/<taotao(.*?)\/>/ig,"<taotao$1>")
.replace(/<\/sign>/ig,"</sign>")
.replace(/<\/qzone>/ig,"</qzone>")
.replace(/<\/taotao>/ig,"</taotao>")
.replace(/<(\/?)includetail>/ig,"<$1tincludetail>");
}
if(cL=="FILTE<:")
{
return fI.replace(/<:sign.*?>/ig,"")
.replace(/<:qzone.*?>/ig,"")
.replace(/<:taotao.*?>/ig,"")
.replace(/<:includetail.*?>/ig,"");
}
else
{
return fI.replace(/<\/?sign.*?>/ig,"")
.replace(/<\/?qzone.*?>/ig,"")
.replace(/<\/?taotao.*?>/ig,"")
.replace(/<\/?includetail.*?>/ig,"");
}
}





function getSignatureHeader()
{
return T([
'<div style="color:#909090;font-family:Arial Narrow;font-size:12px">',
'------------------',
'</div>'
]);
}




function checkSignatureFrame()
{
if(getTop().gLoadSignTimeout)
{
getTop().clearTimeout(getTop().gLoadSignTimeout);
getTop().gLoadSignTimeout=null;
}

if(getSignatureWin())
{
getTop().gSignStatus="finish";

var agM=true;
try
{
if(!getSignatureWin().getRealUserSignature)
{
agM=false;
}
}
catch(aZ)
{
agM=false;
}


if(!agM&&getTop().reloadSignTimeout==null)
{
getTop().gReloadSignTimeout=getTop().setTimeout(
"getTop().reloadSignature( true );",5000
);
}
else if(agM)
{


bindAccount();
}
}
}




function loadSignature()
{
try
{
if(!S("signatureFrame",getTop())
||S("signatureFrame",getTop()).src.indexOf("getcomposedata")==-1)
{
reloadSignature();
}
}
catch(aZ)
{
return;
}

if(getTop().gSignStatus!="finish")
{
throw{
message:"get sign error..."
};
}
}





function reloadSignature(RV)
{
if(window!=getTop())
{
return getTop().reloadSignature(RV);
}

if(RV)
{
if(getTop().gnReloadSignatureErrorTime==null)
{
getTop().gnReloadSignatureErrorTime=0;
}

if(getTop().gnReloadSignatureErrorTime>4)
{
return;
}

getTop().gnReloadSignatureErrorTime++;
}

if(getTop().gReloadSignTimeout)
{
getTop().clearTimeout(getTop().gReloadSignTimeout);
getTop().gReloadSignTimeout=null;
}

getTop().gSignStatus="load";

removeSelf(S("signatureFrame",getTop()));

var aO=T(["/cgi-bin/getcomposedata?t=signature&fun=compose&sid=$sid$&qzonesign=$qzonesign$&r=$rand$"])
.replace({
sid:getSid(),
qzonesign:"",
rand:now()
});
createIframe(getTop(),aO,{
id:"signatureFrame",
onload:function(aq){
getTop().checkSignatureFrame();
}
});

if(getTop().gLoadSignTimeout)
{
getTop().clearTimeout(getTop().gLoadSignTimeout);
getTop().gLoadSignTimeout=null;
}

getTop().gLoadSignTimeout=getTop().setTimeout("getTop().checkSignatureFrame();",10000);
}







function getSignature(ec,bVy)
{
try
{
return getSignatureWin().getRealUserSignature(ec,bVy);
}
catch(aZ)
{
loadSignature();
return"";
}
}







function getDetaultStationery(aw)
{
try
{
return aw=="Header"?
getSignatureWin().getRealUserDefaultStationeryHeader():
getSignatureWin().getRealUserDefaultStationeryBottom();
}
catch(aZ)
{
loadSignature();
return"";
}
}





function getDefaultEditor()
{
try
{
return getSignatureWin().getRealDefaultEditor();
}
catch(aZ)
{
loadSignature();
return 0;
}
}





function getUserNick()
{
try
{
return getSignatureWin().getRealUserNick();
}
catch(aZ)
{
loadSignature();
return"";
}
}





function getDefaultSaveSendbox()
{
try
{
return getSignatureWin().getRealDefaultSaveSendbox();
}
catch(aZ)
{
loadSignature();
return 0;
}
}





function getUserAlias()
{
try
{
return getSignatureWin().getRealUserAlias();
}
catch(aZ)
{
loadSignature();
return"";
}
}





function getDefalutAllMail()
{
try
{
return getSignatureWin().getRealDefaultAllMail();
}
catch(aZ)
{
loadSignature();
return[];
}
}





function getOpenSpellCheck()
{
try
{
return getSignatureWin().getRealOpenSpellCheck();
}
catch(aZ)
{

return 0;
}
}






function getDefaultSender()
{
try
{
return getSignatureWin().getRealDefaulSender();
}
catch(aZ)
{
loadSignature();
return"";
}
}






function setDefaultSender(my)
{

getTop().setGlobalVarValue("DEF_MAIL_FROM",my);

}





function getAllSignature()
{
try
{
return getSignatureWin().getRealAllSignature();
}
catch(aZ)
{
loadSignature();
return{};
}
}





function getUserSignatureId()
{
try
{
return getSignatureWin().getRealUserSignatureId();
}
catch(aZ)
{
loadSignature();
return"";
}
}





function getIsQQClub()
{
try
{
return getSignatureWin().getRealIsQQClub();
}
catch(aZ)
{
loadSignature();
return false;
}
}





function getBindAccount()
{
try
{
return getSignatureWin().getRealBindAccount();
}
catch(aZ)
{
loadSignature();
return null;
}
}





function getRecognizeNickName()
{
try
{
return getSignatureWin().getRealRecognizeNickName();
}
catch(aZ)
{
loadSignature();
return false;
}
}

function getMailZoomTool()
{
return getTop().getGlobalVarValue("DEF_MAILZOOMTOOL")=="1";
}

function setMailZoomTool(Sc)
{
getTop().setGlobalVarValue("DEF_MAILZOOMTOOL",Sc?"1":"0");
}





function closeRecognizeNickName()
{
ossLog("realtime","all","stat=tips&type=know&tipid=66");
setGlobalVarValue("DEF_RECOGNIZENICKNAME",false);
}






function getUserInfoText(aw)
{
var dj=S("user"+aw,getTopWin())||{};
return fixNonBreakSpace(dj.innerText||dj.textContent);
}






function getUserInfo(aw)
{
return(S("user"+aw,getTopWin())||{}).innerHTML||"";
}







function setUserInfo(aw,bK)
{
try
{
S("user"+aw,getTopWin()).innerHTML=htmlEncode(bK);
return true;
}
catch(aZ)
{
return false;
}
}










function msgBox(_asMsg,Qp,agn,zM,
bcV,aq)
{
if(window!=getTop())
{
return getTop().msgBox(_asMsg,Qp,agn,zM,
bcV,aq);
}

var fq=_asMsg;

if(!fq)
{
var Od=S("msg_txt",aq||window)
||S("msg_txt",getActionWin());

if(Od&&(Od.innerText||Od.textContent)
&&Od.getAttribute("ok")!="true")
{
fq=filteScript(Od.innerHTML);
Od.setAttribute("ok","true");
}
}

if(!fq||!(fq=trim(fq.replace(/[\r\n]/ig,""))))
{
return;
}

hiddenMsg();

if(Qp=="dialog")
{
alertBox(
{
msg:fq,
title:bcV||"\u786E\u8BA4"
}
);
}
else
{
setClass(arguments.callee.createMessageBox().firstChild,
Qp=="success"?"msg":"errmsg").innerHTML=fq;

showMsg();

if(agn)
{
getTop().gMsgBoxTimer=getTop().setInterval(getTop().hiddenMsg,zM||5000);
}

getTop().gMsgDispTime=now();
}
};




msgBox.createMessageBox=function(IF)
{
var NW=S("msgBoxDIV",getTop());
if(!NW)
{

var bY=typeof IF=="undefined"?(getTop().bnewwin?0:43):IF;
insertHTML(
getTop().document.body,
"afterBegin",
T([
'<div id="msgBoxDIV" style="position:absolute;width:100%;display:none;',
'padding-top:2px;height:24px;*height:24px;_height:20px;top:$top$px;text-align:center;">',
'<span></span>',
'</div>'
]).replace({
top:bY
})
);
NW=S("msgBoxDIV",getTop());
}
return NW;
};





function isshowMsg()
{
return getTop().isShow("msgBoxDIV");
}




function hiddenMsg()
{
if(getTop().gMsgBoxTimer)
{
getTop().clearInterval(getTop().gMsgBoxTimer);
getTop().gMsgBoxTimer=null;
}
getTop().show("msgBoxDIV",false);
getTop().showProcess(0);
}






function displayGrayTip(_aoDom,fA)
{
var cm=_aoDom.style;

cm.visibility=!fA?"hidden":"";
cm.height=!fA?"0":"";
}




function showMsg()
{
getTop().show("msgBoxDIV",true);
}







function showError(kp,zM,cLD)
{
msgBox(kp,"",zM!=-1,zM||5000);
var NW=S("msgBoxDIV",getTop());
if(NW&&cLD)
{
var adF=[];
E(GelTags("script",NW),function(aEe)
{
adF.push(aEe.innerHTML);
}
);
globalEval(adF.join(";"),getTop());
}
}






function showInfo(bTu,zM)
{
msgBox(bTu,"success",zM!=-1,zM||5000);
}











function showProcess(yT,bDQ,avh,aPh,bFL)
{
var aT="load_process",
aLX=arguments.callee.bJr(aT);

if(yT==0)
{
return show(aLX,false);
}

hiddenMsg();
show(aLX,true);

var PZ=yT==2;

if(PZ)
{
var gg=parseInt(avh);

if(isNaN(gg))
{
gg=0;
}
else
{
gg=Math.max(0,Math.min(100,gg));
}
if(aPh)
{
S(aT+"_plan_info",getTop()).innerHTML=aPh+(gg?":":"");
}

S(aT+"_plan_rate",getTop()).innerHTML=
S(aT+"_plan_bar",getTop()).style.width=[gg,"%"].join("");
}
else
{
if(avh)
{
S(aT+"_info",getTop()).innerHTML=avh;
}
}

show(S(aT+"_plan",getTop()),PZ);
show(S(aT+"_img",getTop()),PZ?false:bDQ);
show(S(aT+"_plan_info",getTop()),PZ);
show(S(aT+"_plan_rate",getTop()),PZ&&gg);
show(S(aT+"_info",getTop()),!PZ);
show(S(aT+"_cancel",getTop()),bFL!=false);
}






showProcess.bJr=function(aG)
{
var azx=S(aG,getTop());
if(!azx)
{
insertHTML(
getTop().document.body,
"afterBegin",
T([
'<table id="$id$" cellspacing=0 cellpadding=0 border=0 ',
'style="position:absolute;top:$top$px;left:0;width:100%;display:none;z-index:9999;">',
'<tr><td align="center">',
'<table cellspacing=0 cellpadding=0 border=0 class="autosave autosave_txt" style="height:20px;"><tr>',
'<td style="width:2px;"></td>',
'<td id="$id$_img" style="padding:0 0 0 5px;">',
'<img src="$image_path$ico_loading0aa5d9.gif" style="width:16px;height:16px;vertical-align:middle;">',
'</td>',
'<td id="$id$_plan" valign=center style="padding:0 0 0 5px;">',
'<div style="font:1px;border:1px solid white;width:104px;text-align:left;">',
'<div id="$id$_plan_bar" style="font:1px;background:#fff;height:8px;margin:1px 0;width:50%;"></div>',
'</div>',
'</td>',
'<td id="$id$_plan_info" style="padding:0 0 0 5px;"></td>',
'<td id="$id$_plan_rate" style="width:40px;text-align:right;padding:0;"></td>',
'<td id="$id$_info" style="padding:0 0 0 5px;"></td>',
'<td id="$id$_cancel" style="padding:0 0 0 5px;">',
'[<a onclick="getTop().cancelDoSend();" nocheck="true" style="color:white;">\u53D6\u6D88</a>]',
'</td>',
'<td style="padding:0 0 0 5px;"></td>',
'<td style="width:2px;"></td>',
'</tr></table>',
'</td></tr>',
'</table>'
]).replace(
{
id:aG,
top:getTop().bnewwin?0:45,
image_path:getPath("image",true)
}
)
);
azx=S(aG,getTop());
}
return azx;
};





function getProcessInfo()
{
var aT="load_process",
nl=getTop();

if(isShow(S(aT,nl)))
{
var aXZ=S(aT+"_plan_rate",nl),
auo=S(aT+"_info",nl);

if(auo&&isShow(auo))
{
return auo.innerHTML;
}

if(aXZ&&isShow(S(aT+"_plan",nl)))
{
return parseInt(aXZ.innerHTML);
}
}
return"";
}






function replaceCss(aq,tD)
{
replaceCssFile(
"skin",
[getPath("style"),getFullResSuffix(["skin",
typeof tD=="undefined"?getPath("skin"):tD,".css"].join(""))
].join(""),
(aq||window).document
);
}






function aRj(tD,agW)
{
var _oTop=getTop();

return!agW&&_oTop.gLogoUrl?_oTop.gLogoUrl.replace(/(.*)_[^_]+_([^_]+)/,"$1_"+tD+"_$2")
:TE([
'$images_path$logo',
'$@$if($bFoxmail$)$@$',
'_foxmail',
'$@$else$@$',
'$sSubfolder$',
'$@$endif$@$',
'/logo_$nSkinId$_',
'$@$if($bFoxmail$)$@$',
'0',
'$@$else$@$',
'$sLogoid$',
'$@$endif$@$.gif'
]).replace(
{
images_path:getPath("image"),
bFoxmail:agW,
sSubfolder:_oTop.gsLogoFolder,
nSkinId:tD,
sLogoid:(_oTop.gsLogoFolder||tD==0)?(_oTop.gLogoId||0):0
}
);
}








function doRealChangeStyle(bHo,tD,agW,rT,bPE)
{
var _oTop=getTop(),
EZ=_oTop.gTempSkinId=tD,
cp=getMainWin(),
atu=[_oTop,cp],
bNR=bPE||false,
aiH=S("imglogo",_oTop);

if(aiH)
{
if(typeof rT=="undefined"||rT=="")
{
if(tD<10000000)
{
aiH.src=aRj(EZ,agW);











}
}
else
{
aiH.src=rT;
}
aiH.className=bNR?"domainmaillogo":"";
}







E(_oTop.goDialogList,function(nk,ta)
{
atu.push(F(ta,getTop()));
});

E(GelTags("iframe",cp.document),function(nk)
{
atu.push(nk.contentWindow);
});

E(atu,function(aq)
{
replaceCss(aq,EZ);
});

removeSelf(bHo);

setTimeout(resizeFolderList);

rdVer("BaseVer",1);
}






function changeStyle(tD,rT)
{
var agH=false,
ahW=false;


var aje=getTop().getGlobalVarValue("DOMAIN_MAIL_LOGO_URL")||{},
IT=getGlobalVarValue("DEF_MAIL_FROM")||'';
if(rT)
{
ahW=rT.indexOf("/cgi-bin/viewfile")>=0;
if(ahW)
{
aje[IT]=rT;
IT&&setGlobalVarValue("DOMAIN_MAIL_LOGO_URL",aje);
}
}
else if(IT&&aje[IT])
{

rT=aje[IT];
ahW=rT&&rT.indexOf("/cgi-bin/viewfile")>=0;
}

var EZ=typeof tD=="undefined"||tD==""?getTop().skin_path:tD,
bWP=getTop().gsLogoFolder,
bVa=agH?0:(bWP||EZ==0?(getTop().gLogoId||0):0),
bOg=agH?"_foxmail":"",
aWz=getTop().changeStyle,
bFZ=aWz.axK,
axK=aWz.axK=["skinCssCache",EZ,
bOg,rT||bVa].join("_");


debug("994919736");
if(axK!=bFZ)
{
cacheByIframe([
["css",getPath("style"),"skin"+EZ+".css"],
!!rT?["img","",rT]

:["img",aRj(EZ,agH)]
],
{
onload:function()
{
doRealChangeStyle(this,EZ,agH,rT,ahW);
}
}
);
}
}




function osslogCompose(ir,axM,aI,aux,auM)
{
getTop().ossLog("delay","all",T([
'stat=compose_send',
'&t=$time$&actionId=$actionId$&mailid=$mailid$',
'&isActivex=$isActivex$&failCode=$failCode$',
'&$other$'
]).replace({
time:ir,
actionId:axM,
mailId:aI,
failCode:aux,
other:["&cgitm=",getTop().g_cgiTimeStamp||-1,"&clitm=",getTop().g_clientTimeStamp||-1,"&comtm=",auM&&auM.valueOf?auM.valueOf():-1].join('')
}));
}

function osslogAjaxCompose(wb,FU,oz,aw)
{
var _oTop=getTop(),
bAA=["IE","FF","Safari","Chrome","Opera","QBIE","TT","NS"],
HB="gbIs",
cIx="Other";
for(var i=0;i<bAA.length;i++)
{
if(_oTop[HB+bAA[i]])
{
cIx=bAA[i];
break;
}
}
ossLog("realtime","all",T([
'stat=compose_ajax_send',
'&server=$server$&browser=$browser$',
'&status=$status$&code=$code$&section=$section$&sendtype=$type$&ran=$ran$',
]).replace(
{
ran:now(),
server:getCookie("ssl_edition")||location.host,
browser:cIx,

status:wb,
code:FU,
section:oz,
type:aw
}
));
}








function recodeComposeStatus(axM,aI,aux,bXc)
{
var ej=0,
Uv=getTop().gSendTimeStart;

if(!Uv||!Uv.valueOf)
{
if(!bXc)
{
return;
}
}
else
{
ej=now()-Uv.valueOf();
getTop().gSendTimeStart=null;
}



osslogCompose(ej,axM,aI,aux,Uv);













getTop().isUseActiveXCompose=false;
}




function errorProcess(axn)
{

if(typeof getMainWin().ErrorCallBack=="function")
{
getMainWin().ErrorCallBack(axn);

}
else if(typeof getTop().ErrorCallBack=="function")
{
getTop().ErrorCallBack(axn);
}
}







function doPostFinishCheck(aG,aq,brv)
{
if(aG)
{
var sR="",
aaB=false,
zC=S(aG,aq),
afZ=F(aG,aq),
bnA=-1;
try
{
bnA=0;
if(!zC
||zC.getAttribute("deleted")=="true")
{
return;
}

bnA=1;
var cY=afZ.document.body,
aaB=!cY.className&&!cY.style.cssText;

bnA=2;
if(aaB)
{
var wW=afZ.document.documentElement;
sR=(wW.textContent
||wW.innerText||"").substr(0,30);
}




}
catch(aZ)
{
doPageError([aG,aZ.message].join(":"),afZ&&afZ.location&&afZ.location.href||aG,bnA);
aaB=aZ.message||"exception";
}

QMHistory.recordActionFrameChange();

if(aaB)
{
callBack.call(zC,brv,[sR]);












errorProcess();
}
}
}




function actionFinishCheck()
{
doPostFinishCheck("actionFrame",getTop(),function(responseContent)
{
showError(gsMsgLinkErr);
}
);
}




function doSendFinishCheck()
{
doPostFinishCheck("sendmailFrame",getTop(),function(aqp)
{
recodeComposeStatus(2,null,aqp||0);
msgBox(T(['\u7531\u4E8E\u7F51\u7EDC\u539F\u56E0\uFF0C\u90AE\u4EF6\u53D1\u9001\u5931\u8D25\uFF01'
,'[<a href="/cgi-bin/switch2service?sid=$sid$&errcode=-1&time=$time$&cginame=sendmail&t=error_report">\u53D1\u9001\u9519\u8BEF\u62A5\u544A</a>]']).replace(
{
time:formatDate(new Date(),"$YY$$MM$$DD$$hh$$mm$$ss$")
}
),"dialog",true,0,"\u5931\u8D25\u4FE1\u606F");
}
);
}






function submitToActionFrm(kE)
{
try
{
kE.submit();
return true;
}
catch(aZ)
{
showError(kE.message);
return false;
}
}









function afterAutoSave(uR,aI,_asMsg,boZ)
{

var jR=0,
wy,aoH;

try
{
var cp=getTop().getMainWin();

function agj()
{
if(disableAll)
{
disableAll(false);
}
}

jR=1;

if(aI==""||!aI)
{
return agj();
}

jR=2;

if(!cp||!S("fmailid",cp))
{
return agj();
}

jR=3;
aoH=S("fmailid",cp).value;

if(aoH!=aI)
{
S("fmailid",cp).value=aI;
getTop().setTimeout(
function()
{
reloadLeftWin()
},
0
);
}

jR=4;

var _oFiles=uR.split(" |"),
GF=[],
alw=cp.QMAttach.getExistList();

for(var i=0,_nLen=alw.length;i<_nLen;i++)
{
var Tx=S("Uploader"+alw[i],cp);
if(Tx&&!Tx.disabled&&Tx.value!="")
{
GF.push(Tx);
}
}

jR=5;

var bmT=GF.length;
for(var i=0,_nLen=_oFiles.length-1;i<_nLen;i++)
{
var xV=false;
for(var j=0;j<=i&&j<bmT;j++)
{
if(!GF[j].disabled
&&GF[j].value.indexOf(_oFiles[i])!=-1)
{
GF[j].disabled=true;
xV=true;
try
{
if(gbIsIE||gbIsWebKit)
{
GF[j].parentNode.childNodes[1].innerText=_oFiles[i];
}
}
catch(aZ)
{
}
}
}
if(!xV)
{
var aP=_oFiles[i]+" |",
dM=uR.indexOf(aP);

if(dM!=-1)
{
uR=uR.substr(0,dM)
+uR.substr(dM+aP.length,
uR.length-dM-aP.length
);
}
}
}

jR=6;

cp.loadValue();

jR=7;

if(uR&&S("fattachlist",cp))
{
S("fattachlist",cp).value+=uR;
}

jR=8;







jR=9;

showInfo(_asMsg
||(formatDate(new Date,"$hh$:$mm$")+" "+getTop().gsMsgSendErrorSaveOK));

jR=10;
var ee=getTop().QMDialog("composeExitAlert");
var hC=ee&&ee.S("btn_exit_notsave");
if(hC&&hC.isShow())
{
return fireMouseEvent(hC,"click");
}

jR=11;

if(!boZ)
{
agj();
}

jR=12;

cp.enableAutoSave();
}
catch(aZ)
{
wy=aZ.message;
debug(["afterAutoSave:",aZ.message,"eid:",jR]);
}









}




function cancelDoSend()
{
var cp=getMainWin(),
Gu=cp.QMAttach;

if(Gu&&Gu.onfinish)
{
Gu.onprogress=null;
Gu.onfinish=null;
}
else
{
var afQ=S("sendmailFrame",getTop());
if(afQ)
{
afQ.setAttribute("deleted","true");
removeSelf(afQ);
}
}

recodeComposeStatus(3,null,0);
showProcess(0);
errorProcess();
}







function quickDoSend(ps,bK,_asMsg)
{
var aml=false;

if(_asMsg!="nomsg")
{
showProcess(1,0,[
"<img src='",getPath("image"),"newicon/a_send.gif' width='14px' height='14px' align='absmiddle'>&nbsp;",
(_asMsg||gsMsgSend)].join(""),null,true);
}

disableSendBtn(true);
disableSource(true);

createBlankIframe(getTop(),
{
id:"sendmailFrame",
onload:function(aq)
{
if(aml)
{
doSendFinishCheck(this);
}
else
{
aml=true;

try
{
ps.content.value=bK;
ps.target="sendmailFrame";
ps.submit();
}
catch(aZ)
{
showError("\u53D1\u9001\u5931\u8D25\uFF1A"+aZ.message);
disableSendBtn(false);
disableSource(false);
}
}
}
}
);
}






function disableSendBtn(qk,aq)
{
disableCtl("sendbtn",qk,aq||getMainWin());
}





function disableSaveBtn(qk,aq)
{
disableCtl("savebtn",qk,aq||getMainWin());
}





function disableTimeSendBtn(qk,aq)
{
disableCtl("timeSendbtn",qk,aq||getMainWin());
}





function disableSource(qk)
{
disableCtl("source",qk,getMainWin());
}




function disableAll(qk,aq)
{
var cp=aq||getMainWin();
if(cp.disableAll&&cp.disableAll!=arguments.callee)
{
return cp.disableAll(qk);
}

disableSendBtn(qk,aq);
disableSaveBtn(qk,aq);
disableTimeSendBtn(qk,aq);

var ee=getTop().QMDialog("composeExitAlert"),
aPK=ee&&ee.S("btn_exit_save");
if(aPK)
{
aPK.disabled=qk;
}
}






function verifyCode(aw,KI)
{
if(window!=getTop())
{
return getTop().verifyCode(cet);
}

var wS=arguments.callee,

bEp=wS.bIj;


setVerifyCallBack();
loadingBox(
{
model:"\u9A8C\u8BC1\u7801",
js:"$js_path$qmverify0bdf91.js",
oncheck:function()
{
return window.QMVerifyBox;
},
onload:function()
{
QMVerifyBox.open(
{
sType:aw,
sVerifyKey:KI,
onok:bEp
}
);
}
}
);
}
























function openComposeDlg(bdA,ag,aYe)
{
!(typeof QMAddress!="undefined"&&QMAddress.isInit())&&initAddress();


loadJsFileToTop(["$js_path$qqmaileditor/editor0c9efc.js"]);
loadingBox(
{
model:"\u53D1\u4FE1",
js:["$js_path$libcompose0c836e.js","$js_path$qmaddrinput0c98cd.js"],
oncheck:function()
{
return window.ComposeLib&&window.QMAddrInput&&window.QMEditor&&(!aYe||aYe());
},
onload:function()
{
ComposeLib.openDlg(bdA,ag);
}
}
);
}










function setVerifyCallBack(bv)
{
getTop().verifyCode.bIj=bv;
}







function emptyFolder(bnB,bEH,bEu)
{
confirmBox({
title:"\u6E05\u7A7A\u6587\u4EF6\u5939",
msg:bnB
?"<div class='b_size bold'>\u662F\u5426\u8981\u6E05\u7A7A\u6B64\u6587\u4EF6\u5939\uFF1F</div><div class='f_size'>\u6E05\u7A7A\u540E\u90AE\u4EF6\u5C06\u65E0\u6CD5\u6062\u590D\u3002</div>"
:"<div class='b_size bold'>\u662F\u5426\u8981\u6E05\u7A7A\u201C"+bEu+"\u201D\u4E2D\u7684\u90AE\u4EF6\uFF1F</div><div class='f_size'>\u6E05\u7A7A\u540E\u90AE\u4EF6\u5C06\u65E0\u6CD5\u6062\u590D\u3002</div>",
confirmBtnTxt:'\u662F',
cancelBtnTxt:'\u5426',
onreturn:function(aV)
{
aV&&bEH();
}
});




}








function renameFolder(ec,aw,aq,bpH)
{
promptFolder({
defaultValue:bpH||'',
type:"rename"+(aw||'folder'),
onreturn:function(hU){
var fb=S("frm",aq);
if(aw=='tag')
{
fb.fun.value="renametag";
fb.tagname.value=hU;
fb.tagid.value=ec;
}
else
{
fb.fun.value="rename";
fb.name.value=hU;
fb.folderid.value=ec;
}
submitToActionFrm(fb);
}
});
return false;
}











function promptFolder(ag)
{
var aM={
shortcutgroup:{title:'\u65B0\u5EFA\u8054\u7CFB\u4EBA\u5206\u7EC4',msg:'\u8BF7\u586B\u5199\u8054\u7CFB\u4EBA\u5206\u7EC4\u540D\u79F0',name:'\u8054\u7CFB\u4EBA\u5206\u7EC4',maxascii:32,description:"\u5199\u4FE1\u65F6\uFF0C\u53EA\u9700\u8981\u8F93\u5165\u8FD9\u4E2A\u7FA4\u7EC4\u540D(\u6C49\u5B57\u9700\u8F93\u5165\u62FC\u97F3)\uFF0C\u5C31\u53EF\u4EE5\u5FEB\u6377\u7FA4\u53D1\u4E86\u3002"},
folder:{title:'\u65B0\u5EFA\u6587\u4EF6\u5939',msg:'\u8BF7\u60A8\u8F93\u5165\u6587\u4EF6\u5939\u540D\u79F0',name:'\u6587\u4EF6\u5939',maxascii:80},
tag:{title:'\u65B0\u5EFA\u6807\u7B7E',msg:'\u8BF7\u60A8\u8F93\u5165\u6807\u7B7E\u540D\u79F0',name:'\u6807\u7B7E',maxascii:50},
renamefolder:{title:'\u91CD\u547D\u540D\u6587\u4EF6\u5939',msg:'\u8BF7\u60A8\u8F93\u5165\u65B0\u7684\u6587\u4EF6\u5939\u540D\u79F0',name:'\u6587\u4EF6\u5939',maxascii:80},
renametag:{title:'\u91CD\u547D\u540D\u6807\u7B7E',msg:'\u8BF7\u60A8\u8F93\u5165\u65B0\u7684\u6807\u7B7E\u540D\u79F0',name:'\u6807\u7B7E',maxascii:50}
}[ag.type];
aM.defaultValue=ag.defaultValue;

ag.width&&(aM.width=ag.width);
ag.height&&(aM.height=ag.height);
ag.bAlignCenter&&(aM.bAlignCenter=ag.bAlignCenter);
ag.onclose&&(aM.onclose=ag.onclose);
ag.style&&(aM.style=ag.style);

aM.onreturn=function(aV,fk){
if(!aV)
{
return;
}

var _nLen=getAsiiStrLen(trim(fk));
if(_nLen==0||_nLen>aM.maxascii)
{
return showError(TE(_nLen?"$name$\u540D\u79F0\u592A\u957F\uFF0C\u8BF7\u4F7F\u7528\u5C11\u4E8E$maxascii$\u4E2A\u5B57\u7B26($@$eval $maxascii$/2$@$\u4E2A\u6C49\u5B57)\u7684\u540D\u79F0":'$name$\u540D\u79F0\u4E0D\u80FD\u4E3A\u7A7A').replace(aM));
}
if(/[~!#\$%\^&\*\(\)=\+|\\\[\]\{\};\':\",\?\/<>]/.test(fk))
{
return showError(aM.name+'\u540D\u79F0\u4E0D\u80FD\u5305\u542B ~!#$%^&*()=+|\\[]{};\':",?/<> \u7B49\u5B57\u7B26');
}

ag.onreturn(fk);
};
promptBox(aM);
}


function aMq(ec,SC,afm,cL)
{
if(ec)
{
var awo=S(ec+"_td",SC);
if(awo)
{
setClass(awo,afm);
return awo;
}
else
{

var asM=S(ec,SC);
if(asM)
{
var aLJ=cL=="over";
if(aLJ)
{
showFolders(asM.name,true);
}
var bCJ=S(ec,SC).parentNode;
setClass(bCJ,aLJ?"fn_list":"");
return asM;
}
}
}
}











function switchFolderComm(aG,aq,akK,jW,bKe,
bVs,aUO)
{
var aws=S(akK,aq),
iX=aG;

if(iX)
{
aUO.bCq=iX;
}
else
{
iX=aUO.bCq;
}

if(aws)
{
var aNk="SwiTchFoLdErComM_gLoBaldATa",
aSm=aq[aNk],
Wv;

if(aSm!=iX)
{
aMq(aSm,aq,bVs,"none");
}

if(Wv=
aMq(aq[aNk]=iX,aq,bKe,"over"))
{

E("new|personal|pop|tag".split("|"),function(bcN)
{
var OS=S(bcN+"folders",aq);
OS&&isObjContainTarget(OS,Wv)
&&showFolders(bcN,true);
}
);

if(getStyle(aws,"overflow")!="hidden")
{

scrollIntoMidView(Wv,aws);
}
else
{

var OS=S("ScrollFolder",aq);
OS&&isObjContainTarget(OS,Wv)
&&scrollIntoMidView(Wv,OS);
}
}
}
}






function switchFolder(aG,aq)
{
getTop().switchFolderComm(aG,aq||getLeftWin(),"folder","li","fn","fs",
getTop().switchFolder
);
}







function switchRightFolder(aG,bJK,akK)
{
getTop().switchFolderComm(aG,bJK||F("rightFolderList",getMainWin()),
akK||"folder_new","div","toolbg","",getTop().switchRightFolder
);
}






function isShowFolders(aG,aq)
{
var qp=S("icon_"+aG,aq||getTop());
return!!(qp&&qp.className=="fd_off");
}





function showFolders(aG,nq,aq)
{
var aA=aq||getTop(),
_oContainer=S(aG+"folders",aA),
qp=S("icon_"+aG,aA);

if(_oContainer&&qp)
{
var hY=S(aG+"folders",aA),
bzj=GelTags("li",hY).length;

var gl=!isShowFolders(aG,aA);
if(bzj&&(typeof nq!="boolean"||gl==nq))
{
setClass(qp,gl?"fd_off":"fd_on");

if(!aq)
{
var _oTop=getTop(),
aMM="fOlDErsaNimaTion"+aG,
lP=_oTop[aMM];

if(!lP)
{
lP=_oTop[aMM]=new _oTop.qmAnimation(
{
from:1,
to:100
}
);
}

lP.stop();

if(gl)
{
_oContainer.style.height="1px";
show(_oContainer,true);
}
else
{
_oContainer.style.height="auto";
}

var qE=_oContainer.scrollHeight;

lP.play(
{
speed:qE,
onaction:function(bW,ho)
{
S(aG+"folders",_oTop).style.height=
(Math.floor((gl?ho:1-ho)*qE)
||1)+"px";
},
oncomplete:function(bW,agS)
{
var er=S(aG+"folders",_oTop);
if(gl)
{
er.style.height="auto";
}
else
{
show(er,false);
}
}
}
);
}
else
{
show(_oContainer,gl);
}

callBack(getTop().iPadResizeFolder);
}
}
}

function decreaseFolderUnread(my,xK,aq)
{
var ko,JB=my.split(';');
for(var i=JB.length-1;i>=0;i--)
{
if(ko=Fo(0,JB[i]))
{
Fo(1,JB[i],ko-1,xK,aq);
}
}
}







function getFolderUnread(ec)
{
return Fo(0,ec);
}









function setFolderUnread(ec,bW,xK,aq)
{
return Fo(1,ec,bW||0,xK,aq);
}






function getGroupUnread(Ki)
{
return Fo(0,Ki,null,null,getMainWin());
}








function setGroupUnread(Ki,bW,xK)
{
return Fo(1,Ki,bW||0,xK,getMainWin());
}









function setTagUnread(ec,bW,xK,aq)
{
return Fo(1,ec,bW||0,xK,aq,true);
}











function Fo(dD,ec,bW,xK,aq,bHj)
{
var xa=S(
[
"folder_",


(new String(ec)).toString().split("folder_").pop()
].join(""),
aq||getLeftWin()
);
if(!xa)
{
return 0;
}

var fd=xa.getAttribute("etitle"),
aAl=GelTags("div",xa),
aP=xa.name;
if(aAl.length)
{
xa=aAl[0];
}

var jZ=typeof(bW)=="number"&&bW>0?bW:0,
Yx=xa.innerText||xa.textContent||"",
afr=Yx.lastIndexOf("("),
atS=afr==-1?0
:parseInt(Yx.substring(afr+1,Yx.lastIndexOf(")")));

if(dD==0)
{
return atS;
}

if(atS==jZ)
{
return 1;
}

var bcY=jZ==0,
cg={
info:htmlEncode(afr!=-1?Yx.substring(0,afr):Yx),
title:fd,
unread:jZ
};

xa.title=T('$title$'+(xK||bcY?'':'  \u672A\u8BFB\u90AE\u4EF6 $unread$ \u5C01')).replace(cg);




xa=setHTML(xa,T(bcY&&'$info$'
||(xK?'$info$($unread$)':'<b>$info$</b><b>($unread$)</b>')
).replace(cg)+(cg.info=='\u661F\u6807\u90AE\u4EF6'?'<input type="button" class="ico_input icon_folderlist_star"/>':'')+(cg.info=='\u6F02\u6D41\u74F6'?'<input class="ico_input drifticon" type="button" hidefocus />':'')
);
xa.setAttribute("initlized","");

if(aP&&!bHj)
{
var auc=S("folder_"+aP,getTop());
if(auc)
{
try
{
Fo(dD,ec,jZ,xK,getMainWin());
}
catch(aZ)
{
doPageError(aZ.message,"all.js","_optFolderUnread");
}

return setFolderUnread(auc.id,
getFolderUnread(auc.id)-atS+jZ);
}
}

return 1;
}







function doFolderEmpty(ec,ps,lk)
{
ps.folderid.value=ec;
ps.rk.value=Math.random();

if(ps.loc)
{
ps.loc.value=lk;
}

submitToActionFrm(ps);
}







function selectAll(Gv,dp)
{
E(GelTags("input",S('list',dp)),function(iv)
{
iv.checked=Gv;
}
);
getTop().showSelectALL(dp,Gv);
}





function selectReadMail(Gv,dp)
{
E(GelTags("input",S('list',dp)),function(iv)
{
if(iv.title!="\u9009\u4E2D/\u53D6\u6D88\u9009\u4E2D")
{
iv.checked=iv.getAttribute('unread')!=Gv;
}
}
);
}





function checkAddrSelected()
{
var hm=GelTags("input"),
_nLen=hm.length,
bC;

for(var i=0;i<_nLen;i++)
{
bC=hm[i];
if(bC.type=="checkbox"&&bC.checked)
{
return true;
}
}

return false;
}






function checkBoxCount(ayK)
{
var eW=0;

E(GelTags("INPUT"),function(iu)
{
if(iu.type=="checkbox"
&&iu.name==ayK
&&iu.checked)
{
eW++;
}
}
);

return eW;
}




function PGV()
{
}






function checkCheckBoxs(aK,ps)
{
var fb=ps||S("frm",getMainWin()),
hm=GelTags("input",fb),
kP;

for(var i=0,_nLen=hm.length;i<_nLen;i++)
{
kP=hm[i];

if(kP.type=="checkbox"
&&kP.name==aK
&&kP.checked)
{
return true;
}
}

return false;
}






function setListCheck(iu,Pi)
{
if(iu.type!="checkbox")
{
return;
}

if(Pi==null)
{
Pi=iu.checked;
}
else
{
iu.checked=Pi;
}

var dj=iu.parentNode.parentNode;

if(dj.tagName=="TR")
{
dj=dj.parentNode.parentNode;
}


if(dj==S("frm",getMainWin()))
{
return;
}

var Wu=dj.className;
if(Wu=="B")
{
Wu=Pi?"B":"";
}
else
{
Wu=strReplace(Wu," B","")
+(Pi?" B":"");
}

setClass(dj,Wu);

if(Pi)
{
listMouseOut.call(dj);
}
}







function doCheck(_aoEvent,Yb,bTB,bOT)
{
var bJ=_aoEvent||window.event,
dh=Yb||bJ.srcElement||bJ.target,
cp=bOT||getMainWin();

if(!dh||!cp)
{
return;
}

if(dh.className=="one"||dh.className=="all")
{
CA(dh);
}
setListCheck(dh);

if((bJ&&bJ.shiftKey||bTB)
&&cp.gCurSelObj
&&cp.gCurSelObj!=dh
&&dh.checked==cp.gCurSelObj.checked)
{
var hm=getTop().GelTags("input",cp.document),
eW=0,
_nLen=hm.length,
kP;

for(var i=0;i<_nLen;i++)
{
kP=hm[i];

if(kP.type!="checkbox")
{
continue;
}

if((kP==cp.gCurSelObj
||kP==dh)&&eW++==1)
{
break;
}

if(eW==1)
{
setListCheck(kP,dh.checked);
}
}
}
cp.gCurSelObj=dh;

getTop().showSelectALL(cp,false)
}






function checkAll(ayK,dp)
{
E(GelTags("input",dp),function(bo)
{
if(bo.name==ayK)
{
setListCheck(bo);
}
}
);
}







function fakeReadmail(ag)
{
QMAjax.send(
T('/cgi-bin/readmail?sid=$sid$&mailid=$mailid$&t=readsubmail&mode=fake&base=$base$&pf=$pf$').replace({
sid:getSid(),
mailid:ag.sMailId,
pf:rdVer.isPre(ag.sFolderId)?1:0,
base:rdVer("BaseVer",0)
}),
{
method:"GET",
headers:{"If-Modified-Since":"0","Cache-Control":"no-cache, max-age=0"},
onload:function(aV,bQ)
{
var gy=trim2(bQ);
if(aV&&gy.indexOf("(")==0)
{
var fB=evalValue(gy);
if(fB)
{
folderOpt(extend(ag,fB));
callBack(getMainWin().updatePreAndNext,[ag]);
}
}
else
{
var zd=getActionWin().document;
zd.open();
zd.write(ke.responseText);
}
}
}
);
}













function folderOpt(ag)
{
if(!ag)
{
return;
}

var _oTop=getTop();
_oTop.recordCompareReadedMailId(ag.sMailId);
if(ag.bNewMail)
{
var iX=ag.sFolderId,
dXI;





if(iX>0)
{
try{
_oTop.setFolderUnread(iX,_oTop.getFolderUnread(iX)-1);
if(ag.bStar)
{
_oTop.setFolderUnread("starred",_oTop.getFolderUnread("starred")-1);
}

var yI=ag.oMatchTag||[],
i=yI.length-1;
i>=0&&setTagUnread('tag',getFolderUnread('tag')-1);
for(;i>=0;i--)
{
var gX='tag_'+yI[i];
debug(['getFolderUnread',gX,getFolderUnread(gX)]);
setTagUnread(gX,getFolderUnread(gX)-1);
}

}catch(e){}
}




}
}






function recordReadedMailId(aI)
{
getTop().gsReadedMailId=aI;
}





function recordCompareReadedMailId(aI)
{
if(aI&&getTop().gsReadedMailId!=aI)
{
getTop().gsReadedMailId=aI;
}

QMMailCache.addData(aI,{bUnread:null});
}






function SG(UU,bzW)
{
var cI=UU.className,
gl=!/\bsts\b/i.test(cI);



var	bC=GelTags("input",UU.parentNode)[0],
aPZ=bC&&bC.className,
XR=(bzW
?UU.parentNode.parentNode.parentNode
:UU.parentNode).nextSibling;

if(aPZ=="one"||aPZ=="all")
{
setClass(bC,gl?"one":"all");
}

setClass(UU,
gl?cI.replace(/\bhts\b/i,"sts"):cI.replace(/\bsts\b/i,"hts"));


if(XR.className!="toarea")
{
XR=XR.nextSibling;
}

if(XR.className!="toarea")
{
return;
}

return show(XR,gl);
}





function CA(WA)
{
if(WA)
{
var wJ=(WA.className=="all"
?WA.parentNode.parentNode.parentNode.parentNode
:WA.parentNode).nextSibling;

if(wJ.className!="toarea")
{
wJ=wJ.nextSibling;
}

if(wJ.className=="toarea")
{
var bMJ=WA.checked;

E(GelTags("input",wJ),function(bo)
{
setListCheck(bo,bMJ);
}
);
}
}
}















function RD(_aoEvent,aI,tC,dD,nx,YM,
asZ,awi,Ej)
{
recordReadedMailId(aI);

if(_aoEvent)
{
preventDefault(_aoEvent);


var aB=_aoEvent.srcElement||_aoEvent.target,
iX=aB&&aB.getAttribute("fid");

if(iX)
{
goUrlMainFrm(T("/cgi-bin/$cgi$?sid=$sid$&folderid=$fid$&page=0&t=$t$").replace(
{
cgi:iX=="9"?"readtemplate":"mail_list",
fid:iX,
sid:getSid(),
t:iX=="9"?"sms_list_v2":""
}
),false);
return stopPropagation(_aoEvent);
}
}

var aO=rdVer.url(aI,nx,Ej,
dD,getTop().bnewwin||(_aoEvent&&_aoEvent.shiftKey),
YM,asZ,awi);

rdVer.log(aI,"hit");

if(_aoEvent&&(_aoEvent.shiftKey||_aoEvent.ctrlKey||_aoEvent.metaKey))
{
var dh=_aoEvent.target||_aoEvent.srcElement;

while(dh&&dh.className!="i M"
&&dh.className!="i F")
{
dh=dh.parentNode;
}

dh&&QMReadedItem.disp(dh);
goNewWin(aO);
}
else
{
goUrlMainFrm([aO,"#stattime=",now()].join(""),false);
}
}









function checkPerDelML(nx,aRd,dp)
{
return delMailML(nx,aRd,"PerDel",dp);
}









function delMailML(nx,aRd,Zv,dp)
{
var aA=dp.nodeType==9?(dp.defaultView||dp.parentWindow):dp,
aM=QMMailList.getCBInfo(aA);
configPreRmMail(aM,'rmMail');
rmMail(Zv=="PerDel"?1:0,aM);
return;
}






function reportSpamML(bIi,dp)
{

if(getTop().isSelectAllFld(getMainWin()))
{
return showError('\u4E0D\u80FD\u5BF9\u5168\u6587\u4EF6\u5939\u6267\u884C\u6B64\u64CD\u4F5C');
}

var aA=dp.nodeType==9?(dp.defaultView||dp.parentWindow):dp,
aM=QMMailList.getCBInfo(aA);


configPreRmMail(aM,'spammail');
(bIi?reportSpamJson:reportNoSpamJson)({bBlackList:true},aM);
return false;
}





var QMReadedItem={};





QMReadedItem.addItem=function(iv)
{
if(!getMainWin().gMailItems)
{
getMainWin().gMailItems=[];
}

getMainWin().gMailItems.push(iv);
};





QMReadedItem.getItems=function()
{
return getMainWin().gMailItems||[];
};





QMReadedItem.save=function(bFi)
{
getMainWin().goReadedItemImg=bFi;
};





QMReadedItem.load=function()
{
return getMainWin().goReadedItemImg;
};





QMReadedItem.disp=function(aeV)
{
if(!aeV)
{
return;
}

var Ji=aeV.type=="checkbox"
?aeV.parentNode
:GelTags("input",aeV)[0].parentNode,
eu=Ji.firstChild;

if(eu.tagName!="IMG")
{
insertHTML(
Ji,
"afterBegin",
T([
'<img src="$path$ico_grouplight.gif" class="showarrow"',
' title="\u8FD9\u662F\u60A8\u6700\u8FD1\u9605\u8BFB\u7684\u4E00\u5C01\u90AE\u4EF6" />'
]).replace(
{
path:getPath("image")
}
)
);
eu=Ji.firstChild;
}

show(this.load(),false);
show(eu,true);

this.save(eu);
};





QMReadedItem.read=function(Yb)
{
if(Yb&&Yb.tagName==="U")
{
fireMouseEvent(Yb,"click");
}
else
{
if(!this.load())
{
return false;
}

fireMouseEvent(
GelTags("table",this.load().parentNode.parentNode)[0].parentNode,
"click"
);
}

return true;
};






QMReadedItem.check=function(bPL)
{
if(!this.load())
{
return false;
}

var ato=this.load().nextSibling;
ato.checked=!ato.checked;

doCheck(null,ato,bPL);
return true;
};






QMReadedItem.move=function(bPU)
{
var bm=this.getItems(),
asD=bm.length,
dM=-1;

if(asD==0)
{
return false;
}

if(this.load()!=null)
{
var bUQ=QMReadedItem.load().nextSibling;

for(var i=asD-1;i>=0;i--)
{
if(bUQ==bm[i])
{
dM=i;
break;
}
}
}

dM+=bPU?1:-1;

if(dM>-1&&dM<asD)
{
this.disp(bm[dM]);
scrollIntoMidView(bm[dM],getMainWin().document.body,false);
return true;
}

return false;
};







function listMouseOver(_aoEvent)
{
var ae=this,
cI=ae.className;

if(cI.indexOf(" B")==-1
&&cI.indexOf(" V")==-1
&&ae.getAttribute("colorchange")!="none")
{
ae.className=cI+" V";
}


if(_aoEvent)
{
var aB=getEventTarget(_aoEvent);
while(aB&&aB!=ae&&aB.className!='tagbgSpan')
{
aB=aB.parentNode;
}
if(aB&&aB!=ae)
{
QMTag.showTagClose(aB,1);
}
}
}





function listMouseOut(_aoEvent)
{
var ae=this;
if((!_aoEvent||!isObjContainTarget(ae,_aoEvent.relatedTarget
||_aoEvent.toElement))
&&ae.className.indexOf(" V")>-1
&&ae.getAttribute("colorchange")!="none")
{
ae.className=ae.className.replace(" V","");
}


if(_aoEvent)
{

var aB=getEventTarget(_aoEvent);
while(aB&&aB!=ae&&aB.className!='tagbgSpan')
{
aB=aB.parentNode;
}
if(aB&&aB!=ae)
{
QMTag.showTagClose(aB,0);
}
}

}






function listMouseEvent(bn)
{
addEvents(bn,{
contextmenu:function(_aoEvent)
{
listContextMenu.call(bn,_aoEvent);
},
mouseover:function(_aoEvent)
{
listMouseOver.call(bn,_aoEvent);
},
mouseout:function(_aoEvent)
{
listMouseOut.call(bn,_aoEvent);
}
});
}

function listContextMenu(_aoEvent)
{
var _oDom=this;
allDeferOK()&&mailRightMenu(_oDom,_aoEvent);
preventDefault(_aoEvent);
}





function GetListMouseClick(aq)
{
return function(_aoEvent)
{
ListMouseClick(_aoEvent,aq||window);
}
}






function ListMouseClick(_aoEvent,aq)
{
var dh,
bJ=_aoEvent||aq.event;

if(!(dh=getEventTarget(bJ)))
{
return;
}


if(attr(dh,"name")=="mailid"||(dh.lastChild&&attr(dh.lastChild,"name")=="mailid"))
{
if(dh.lastChild&&attr(dh.lastChild,"name")=="mailid")
{
dh.lastChild.click();
}

if(!getGlobalVarValue('TIP_46'))
{
requestShowTip('gotnomail',46,aq,function(bQ,eQ)
{



setGlobalVarValue('TIP_46',1);

return true;
}
);
}

return doCheck(bJ);
}


if(dh.className.indexOf("cir")==0)
{
var Tb=GelTags("table",dh.parentNode.parentNode)[0]
.parentNode.onclick.toString().split("{")[1]
.split("}")[0].replace(/event/ig,"{shiftKey:true}");

if(/\WRD/.test(Tb))
{
return eval(Tb);
}
else
{
Tb=GelTags("table",dh.parentNode.parentNode)[0]
.parentNode.onclick.toString().replace(/.*{/g,"")
.replace(/}.*/g,"").replace(/event/ig,"{shiftKey:true}");
return eval(Tb);
}
}
}






function listInitForComm(cL,bFf)
{
var cI,
nh=GelTags("div"),
bLf=doCheck,
PX,oi;

cI=cL?cL:"M";
for(var i=nh.length-1;i>=0;i--)
{
PX=nh[i];

if(PX.className!=cI)
{
continue;
}

if(cL=="ft")
{
PX=GelTags("table",PX)[0];
}

oi=GelTags("input",PX)[0];
if(!oi||oi.type!="checkbox")
{
continue;
}

oi.title="\u6309\u4F4Fshift\u70B9\u51FB\u4E0D\u540C\u7684\u52FE\u9009\u6846 \u53EF\u65B9\u4FBF\u5FEB\u6377\u591A\u9009";
addEvent(oi,"click",bLf);









if(!bFf)
{
listMouseEvent(PX);
}
}
}










function modifyFolder(nx,Co)
{
getMainWin().location.href=T([
'/cgi-bin/foldermgr?sid=$sid$&fun=detailpop&t=pop_detail',
'&folderid=$folderid$&acctid=$acctid$'
]).replace(
{
sid:getSid(),
folderid:nx,
acctid:Co
}
);
return false;
}





function recvPopHidden(nx)
{
getMainWin().setTimeout(
function()
{
if(!nx)
{
getTop().reloadFrmLeftMain(false,true);
}
else
{
var aT="iframeRecvPopHidden";
createBlankIframe(getMainWin(),{id:aT});

var aO=["/cgi-bin/mail_list?sid=",getSid(),"&folderid=",
nx,"&t=recv_pop_hidden"].join("");
try
{
F(aT,getMainWin()).location.replace(aO);
}
catch(aZ)
{
S(aT,getMainWin()).src=aO;
}
}
},
10000
);
}






function recvPop(Co,nx,dp)
{
recvPopCreat(Co,nx);
if(S("tips",dp))
{
S("tips",dp).innerHTML=T(
[
'<img src="$images_path$ico_loading30aa5d9.gif" align=absmiddle>',
' \u6B63\u5728\u6536\u53D6...&nbsp;\u7CFB\u7EDF\u5C06\u5728\u540E\u53F0\u81EA\u52A8\u6536\u53D6\uFF0C\u60A8\u53EF\u4EE5\u79BB\u5F00\u6B64\u9875\u9762\uFF0C\u7A0D\u540E\u56DE\u6765\u67E5\u770B\u6536\u53D6\u7ED3\u679C\u3002'
]
).replace(
{
images_path:getPath("image",true)
}
);
}


recvPopHidden(nx);
}





function recvPopCreat(Co)
{
getActionWin().location=["/cgi-bin/foldermgr?sid=",getSid(),
"&fun=recvpop&acctid=",Co].join("");
}




function recvPopAll()
{
getActionWin().location=["/cgi-bin/foldermgr?sid=",getSid(),
"&fun=recvpopall"].join("");
try
{

setTimeout(
function()
{
reloadFrmLeftMain(false,true);
},
3000
);
}
catch(aZ)
{
}
return false;
}









function setPopFlag(Co,CT,bK)
{
if(CT=="recent")
{
setPopRecentFlag(Co,bK);
}
}






function setPopRecentFlag(Co,bK)
{
runUrlWithSid(["/cgi-bin/foldermgr?sid=",getSid(),
"&fun=pop_setting&acctid=",Co,"&recentflag=",bK].join(""));
}







function checkPopMailShow(my)
{
var aSI=["@yahoo.com.cn","@sina.com","@tom.com","@gmail.com"],
bXI=my.toLowerCase();

for(var i=0;i<aSI.length;i++)
{
if(bXI.indexOf(aSI[i])>=0)
{
return true;
}
}

return false;
}









function setBeforeUnloadCheck(aq,_asMsg,MX,bOd,
eh)
{
var auK=["input","select","textarea"];

aq=aq||window;
eh=eh?(typeof(eh)=="string"
?S(eh,aq)
:eh):aq.document;
aq.gbIsBeforeUnloadCheck=true;

E(auK,
function(jW)
{
var bMZ=aq[jW+"_save"]=[];

E(GelTags(jW,eh),
function(bn,cU)
{
bMZ.push(bn.value+bn.checked);
bn.setAttribute("saveid",cU);
}
);
}
);

if(!aq.onsetbeforeunloadcheck)
{
aq.onsetbeforeunloadcheck=function()
{
if(aq.gbIsBeforeUnloadCheck)
{
for(var i=0,_nLen=auK.length;i<_nLen;i++)
{
var yw=auK[i],
aP=yw+"_save",
WZ=GelTags(yw,eh);

for(var j=0,jlen=WZ.length;j<jlen;j++)
{
var aPr=WZ[j].getAttribute("saveid");
if(aPr!=null&&WZ[j].getAttribute("nocheck")!="true"&&aq[aP][aPr]
!=(WZ[j].value+WZ[j].checked))
{
return _asMsg?_asMsg:"\u60A8\u4FEE\u6539\u7684\u8BBE\u7F6E\u5C1A\u672A\u4FDD\u5B58\uFF0C\u786E\u5B9A\u8981\u79BB\u5F00\u5417\uFF1F";
}
}
}
}
};

gbIsIE?(aq.document.body.onbeforeunload=aq.onsetbeforeunloadcheck)
:aq.document.body.setAttribute("onbeforeunload","return onsetbeforeunloadcheck();");
}

E(bOd||["cancel"],
function(azQ)
{
addEvent(
typeof(azQ)=="string"
?S(azQ,aq):azQ,
"mousedown",
function()
{
aq.gbIsBeforeUnloadCheck=false;
}
);
}
);

E(GelTags("form",aq.document),
function(kE)
{
addEvent(kE,"submit",
function()
{
aq.gbIsBeforeUnloadCheck=false;
}
);

if(!kE.Qy)
{
kE.Qy=kE.submit;
kE.submit=function()
{
aq.gbIsBeforeUnloadCheck=false;
this.Qy();
};
}
}
);
}









function popErrProcess(_asMsg,Qp,agn,zM,bEW,aOf)
{
if(_asMsg!=null)
{
msgBox(_asMsg,Qp,agn,zM);
}

if(aOf!=null)
{
getMainWin().ShowPopErr(aOf,bEW);
}

showSubmitBtn();
}




function showSubmitBtn()
{
var BX=S("submitbtn",getMainWin());

if(BX)
{
BX.disabled=false;
}
}




function showPopSvr()
{
show(S("popsvrTR",getMainWin()),true);
}





function setTaskId(vh)
{
try
{
getMainWin().document.checkFrom.taskid.value=vh;
}
catch(aZ)
{
}
}








function showQuickReply(nq)
{
show(S('quickreply',getMainWin()),nq);
show(S('upreply',getMainWin()),!nq);
runUrlWithSid("/cgi-bin/getcomposedata?Fun=setshowquickreply&isShowQuickReply="
+(nq?0:1));
}




function hiddenReceipt(aq)
{
show(S("receiptDiv",aq),false);
}





function switchOption(dp)
{
var aE=[
[
"<input type='button' class='qm_ico_quickup' title='\u9690\u85CF' />",true],
[
"<input type='button' class='qm_ico_quickdown' title='\u663E\u793A\u66F4\u591A\u64CD\u4F5C' />",false]
][
S("trOption",dp).style.display=="none"?0:1
];
S("aSwitchOption",dp).innerHTML=aE[0];
show(S("trOption",dp),aE[1]);
}






function checkPerDel(aq)
{


delMail("PerDel",aq);

}






function delMail(Zv,aq)
{
rmMail(Zv=="PerDel"?1:0,aq.QMReadMail.getCBInfo(aq));
}








function setMailType(aw,AW,Fi,dp)
{
var fb=S("mail_frm",dp);

fb.s.value=["readmail_",
AW?(Fi?"group":aw):("not"+aw),
getMainWin().newwinflag?"_newwin":""].join("");
fb.action="/cgi-bin/mail_mgr?sid="+getSid();
fb.mailaction.value="mail_spam";
fb.isspam.value=AW;
fb.reporttype.value=aw=="cheat"?"1":"";

submitToActionFrm(fb);
}



function getAddrSub(addr)
{
var _oPos=addr.indexOf("@");
if(_oPos>-1)
{
var addrName=addr.substr(0,_oPos);
var addrDom=addr.substr(_oPos);
return subAsiiStr(addrName,18,'...')+subAsiiStr(addrDom,18,'...');
}
else
{
debug("name+dom"+addr);
return subAsiiStr(addr,36,'...');
}
}

function getRefuseText(HL)
{
var aOT=T([
'<input type="checkbox" name="$TNAME$" id="$TID$" $TCHECK$>\u5C06<label for="$TID$">$TVALUE$</label>\u52A0\u5165\u9ED1\u540D\u5355'
]);
var i;
var retstr="";
var br="";
for(i in HL)
{
var tagname="refuse";
if(i>0){
tagname="refuse"+i;
br="<br>"
}
var addrlabel;
if(HL[i]!="\u53D1\u4EF6\u4EBA")
addrlabel="&lt;"+getAddrSub(HL[i])+"&gt;";
else
addrlabel=HL[i];
var ischecked="";
debug("ITEM: "+HL[i]);
retstr+=br+aOT.replace({
TNAME:tagname,
TID:tagname,
TVALUE:addrlabel,
TCHECK:ischecked
});
}
debug("RET Text"+retstr);
return retstr;
}










function reportSpam(afA,atf,aq,wb,Ex)
{
debug("Enter mail.js reportSpam "+afA);
var aA=aq||(window==getTopWin()?getMainWin():window);
if(!S("mail_frm",aA))
{
debug("enter from maillist");

var jd=QMMailList.getCBInfo(aA),
_oInfo,
aMN=0,
bV=jd.oMail.length,
pu={};
if(bV==0)
{
showError(gsMsgNoMail);
return false;
}
for(var aD=0;aD<bV;aD++)
{

_oInfo=jd.oMail[aD];
if(_oInfo.bSys)
{





}
aMN+=_oInfo.bDft?1:0;
if(_oInfo.sSEmail.indexOf("@groupmail.qq.com")!=-1)
{

afA=true;
}else if(_oInfo.sSEmail.indexOf("10000@qq.com")!=-1){

afA=true;
}
if(typeof pu.sender=="undefined")
{
pu.sender=_oInfo.sSEmail;
pu.nickname=_oInfo.sSName;
}else if(pu.sender!=_oInfo.sSEmail)
{
pu.sender="";
}
}
if(aMN==bV)
{

wb=1;
}
else
{

for(aD=0;aD<bV;aD++)
{
_oInfo=jd.oMail[aD];




}
jd=QMMailList.getCBInfo(aA);
QMMailList.selectedUI(jd);
}
}
if(pu)
debug("Has nick and sender "+pu.sender);
else
debug("No nick and sender");
var Hf=new Array();
Hf[0]="\u53D1\u4EF6\u4EBA";

if(pu&&pu.sender&&pu.sender.indexOf(',')<0)
{
Hf[0]=pu.sender;
}

var aqx=0;
if(Ex)
{
if(Ex[0].length>0)Hf[aqx++]=Ex[0];
if(Ex[1])Hf[aqx++]=Ex[1];
}
var OA=T([
'<div>',
'<input type="radio" name="reporttype" id="r$value$" value="$value$" $checked$>',
'<label for="r$value$">$content$</label>',
'</div>'
]);
var cj=(wb!==1?[
"<div style='padding:10px 10px 0 25px;text-align:left;'>",
"<form id='frm_spamtype'>",
"<div style='margin:3px 0 3px 3px'><b>\u8BF7\u9009\u62E9\u8981\u4E3E\u62A5\u7684\u5783\u573E\u7C7B\u578B\uFF1A</b></div>",
OA.replace({
value:(atf?11:8),
checked:"checked",
content:"\u5176\u4ED6\u90AE\u4EF6"
}),

OA.replace({
value:(atf?10:4),
checked:"",
content:"\u5E7F\u544A\u90AE\u4EF6"
}),

OA.replace({
value:(atf?9:1),
checked:"",
content:"\u6B3A\u8BC8\u90AE\u4EF6"
}),
"<div style=\"padding:5px 0 2px 0;\">",
(afA
?"&nbsp;"
:getRefuseText(Hf)),"</div><div style='margin:10px 3px 0px 3px' class='addrtitle' >\u6E29\u99A8\u63D0\u793A\uFF1A\u6211\u4EEC\u5C06\u4F18\u5148\u91C7\u7EB3\u51C6\u786E\u5206\u7C7B\u7684\u4E3E\u62A5\u90AE\u4EF6\u3002</div>","</form>",
"</div><div style='padding:3px 15px 12px 10px;text-align:right;'>",
"<input type=button id='btn_ok' class='btn wd2' value=\u786E\u5B9A>",
"<input type=button id='btn_cancel' class='btn wd2' value=\u53D6\u6D88>",
"</div>"
]:[
"<div class='cnfx_content'>",
"<img style='float:left; margin:5px 10px 0;' src='",getPath("image"),"ico_question.gif' />",
"<div class='b_size' style='padding:10px 10px 0 0;margin-left:65px;line-height:1.5;height:80px;text-align:left;'>",
"<form id='frm_spamtype'>",
"<strong>\u60A8\u8981\u4E3E\u62A5\u8FD9\u4E2A\u6F02\u6D41\u74F6\u5417\uFF1F</strong><br>",
"<div style=\"display:none\">",
OA.replace({
value:8,
checked:"checked",
content:""
}),
"</div>",
"\u4E3E\u62A5\u4EE5\u540E\uFF0C\u60A8\u5C06\u4E0D\u518D\u6536\u5230\u8FD9\u4E2A\u6F02\u6D41\u74F6\u7684\u56DE\u5E94\u3002","</form>",
"</div></div><div class='cnfx_btn'>",
"<input type=button id='btn_ok' class='btn wd2' value=\u786E\u5B9A>",
"<input type=button id='btn_cancel' class='btn wd2' style='margin-left:5px' value=\u53D6\u6D88>",
"</div>"
]).join("");

new(getTop().QMDialog)({
sId:"reportSpam",
sTitle:wb===1?"\u7838\u6389\u8FD9\u4E2A\u74F6\u5B50":"\u4E3E\u62A5\u5E76\u62D2\u6536\u9009\u4E2D\u90AE\u4EF6",
sBodyHtml:cj,
nWidth:450,
nHeight:wb===1?150:220,
onload:function(){
var bI=this;
addEvent(bI.S("btn_ok"),"click",function()
{
var fb=S("mail_frm",getMainWin())||S("frm",getMainWin());
if(!fb)
{
return;
}
fb.s.value="readmail_spam";
fb.isspam.value='true';
fb.mailaction.value="mail_spam";
fb.action='/cgi-bin/mail_mgr?sid='+getTop().getSid();

var WQ=bI.S("frm_spamtype").reporttype,
Dx=bI.S("frm_spamtype").refuse,
Hx=bI.S("frm_spamtype").refuse1;
for(var i=0,_nLen=WQ.length;i<_nLen;i++)
{
if(WQ[i].checked)
{
fb.reporttype.value=WQ[i].value;
break;
}
}
var om=new Array();
om[0]="0";
om[1]="0";
if((Dx&&Dx.checked)||
(Hx&&Hx.checked))
{
fb.s.value="readmail_reject";
}

if(Hx)
{
debug("Pro refuse OK* "+Dx.checked+" - "+Hx.checked);
if(Dx&&Dx.checked){
debug("what1? ---- ");
om[0]="1";

debug("SRe"+om[0]);
}else{
debug("what2? ");
om[0]="0";
}
debug("sreject1 "+om[0]+om[1]);
if(Hx.checked)
om[1]="1";
else
om[1]="0";
debug("sreject2 "+om[0]+om[1]);
}
else 
{
om[0]="1";
om[1]="1";
}

if(fb.s_reject_what){
fb.s_reject_what.value=om[0]+om[1];
debug("Reject method "+fb.s_reject_what.value);
}

submitToActionFrm(fb);
bI.close();
});
addEvent(bI.S("btn_cancel"),"click",function(){bI.close()});

},
onshow:function(){
this.S("btn_cancel").focus();
}
});

return false;
}









function setSpamMail(AW,Fi,dp)
{
var aWv=dp||(window==getTopWin()?getMainWin():window);
if(AW&&!Fi)
{
return reportSpam(null,null,aWv);
}
setMailType("spam",AW,Fi,aWv);
}






function setCheatMail(AW,Fi)
{
setMailType("cheat",AW,Fi);
}






function doReject(AW,Fi,dp,eM)
{
var aYx="\u6B64\u90AE\u4EF6\u5730\u5740";
if(eM){
aYx="<"+eM+">";
}

var fb=S("mail_frm",dp);
if(fb.s_reject_what)
{
fb.s_reject_what.value="10";
}

if(confirm("\u7CFB\u7EDF\u4F1A\u628A"+aYx+"\u653E\u5165\u201C\u9ED1\u540D\u5355\u201D\u4E2D\uFF0C\u60A8\u5C06\u4E0D\u518D\u6536\u5230\u6765\u81EA\u6B64\u5730\u5740\u7684\u90AE\u4EF6\u3002\n\n\u786E\u5B9A\u8981\u62D2\u6536\u6B64\u53D1\u4EF6\u4EBA\u7684\u90AE\u4EF6\u5417\uFF1F"))
{
setMailType("reject",AW,Fi,dp);
}
}




function setFolderReaded(ec,Ki,bMG,bFH)
{

var bQa=ec=="all"?parseInt(bFH||"0"):(Ki?getGroupUnread(Ki):getFolderUnread(ec));
if(bQa<1)
{
return showError("\u6587\u4EF6\u5939\u5185\u6CA1\u6709\u672A\u8BFB\u90AE\u4EF6");
}

var ic=getSid(),
aVn=unikey("allread"),
aPl=function()
{
QMAjax.send("/cgi-bin/mail_mgr?mailaction=read_all&t=unreadmail_reg_data&loc=setFolderUnread,,,32",
{
method:"POST",
content:T('sid=$sid$&folderid=$folderid$&groupid=$groupid$').replace(
{
sid:ic,
folderid:ec!="all"?ec:"1&folderid=3&folderid=8&folderid=9&folderid=11&folderid=personal&folderid=pop&folderid=subscribe",
groupid:Ki
}
),
onload:function(aV,bQ)
{
if(aV&&bQ.indexOf("mark_allmail_ok")>-1)
{
var fq="\u6587\u4EF6\u5939\u6807\u4E3A\u5DF2\u8BFB\u64CD\u4F5C"
reloadFrmLeftMain(true,!!getMainWin()[aVn]);
showInfo(fq+"\u6210\u529F");
var aE=eval(bQ);
setRollBack(aE.rbkey,fq);
}
else
{
showError("\u6587\u4EF6\u5939\u6807\u4E3A\u5DF2\u8BFB\u64CD\u4F5C\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5");
}
}
});
};
getMainWin()[aVn]=1;
if(ec!=1)
{
aPl();
}
else
{
var bFr={
"1":"\u6536\u4EF6\u7BB1",
"8":"\u7FA4\u90AE\u4EF6"
},
aDT=bMG||bFr[ec]||"\u90AE\u4EF6\u8BA2\u9605",
cj=T([
'<div class="markall">',
'<div class="markall-title">\u5C06 \u201C$foldername$\u201D \u5168\u90E8\u90AE\u4EF6\u6807\u4E3A\u5DF2\u8BFB\uFF1A</div>',
'<div class="markall-content">',
'<a id="btn_ok" class="markall-confirm" href="javascript:;">\u5168\u90E8\u6807\u4E3A\u5DF2\u8BFB</a>',
'<p>\u4E00\u6B21\u6027\u628A\u8BE5\u6587\u4EF6\u5939\u4E2D\u7684\u672A\u8BFB\u90AE\u4EF6\u6807\u4E3A\u5DF2\u8BFB</p>',
'<a id="mailassistant" class="markall-assis" href="javascript:;">\u4F7F\u7528\u6E05\u7406\u52A9\u624B</a>',
'<p>\u5206\u7C7B\u6E05\u7406\u672A\u8BFB\u90AE\u4EF6\uFF0C\u5982\uFF1A\u6765\u81EA\u597D\u53CB\u90AE\u4EF6\u3001\u6765\u81EA\u964C\u751F\u4EBA\u90AE\u4EF6\u3001\u8BA2\u9605\u90AE\u4EF6\u7B49</p>',
'</div>',
'</div>'
]).replace({"foldername":aDT});
new(getTop().QMDialog)({
sId:"setFolderReaded",
sTitle:"\u5168\u90E8\u6807\u4E3A\u5DF2\u8BFB",
sBodyHtml:cj,
nWidth:450,
nHeight:150,
onload:function(){
var bI=this;
addEvent(bI.S("btn_ok"),"click",function()
{
aPl();
bI.close();
});
addEvent(bI.S("mailassistant"),"click",function()
{
getMainWin().location=T("/cgi-bin/folderlist?needunread=true&sid=$sid$&t=unreadmail_reg1&needunread=true&loc=setFolderUnread,,,30").replace({"sid":ic});
bI.close();
});

},
onshow:function(){
this.S("btn_ok").focus();
}
});
}
}






function linkMaker(Jb)
{
function ayS(bL)
{
var gF=12,
fI=bL||"",
_oList=[],
_nLen=fI.length/gF;

for(var i=0;i<_nLen;i++)
{
_oList[i]=fI.substr(i*gF,gF);
}

return _oList.join("<wbr>");
}

return Jb
.replace(
/(https?:\/\/[\w.]+[^ \f\n\r\t\v\"\\\<\>\[\]\u2100-\uFFFF]*)|([a-zA-Z_0-9.-]+@[a-zA-Z_0-9.-]+\.\w+)/ig,

function(aZj,dpw,avm)
{
if(avm)
{
return['<a href="mailto:',avm,'">',
ayS(avm),'</a>'].join("");
}
else
{
return['<a href="',aZj,'">',
ayS(aZj),'</a>'].join("");
}
}
);
}





function linkIdentify(bn)
{
if(!bn||bn.tagName=="A"||bn.tagName=="SCRIPT"
||bn.tagName=="STYLE"||bn.className=="qqmailbgattach")
{
return;
}

for(var di=bn.firstChild,nextNode;di;di=nextNode)
{
nextNode=di.nextSibling;
linkIdentify(di);
}

if(bn.nodeType==3)
{
var fI=bn.nodeValue.replace(/</g,"&lt;").replace(/>/g,"&gt;"),
gT=linkMaker(fI);

if(fI!=gT)
{
var iG=false;
debug([fI,gT],61882714);
if(bn.previousSibling)
{
iG=insertHTML(bn.previousSibling,"afterEnd",gT);
}
else
{
iG=insertHTML(bn.parentNode,"afterBegin",gT);
}

if(iG)
{
removeSelf(bn);
}
}
}
}







function bcm(_aoDom)
{
var fz=_aoDom.href||"",
ez=_aoDom.ownerDocument,
ja=(ez.parentWindow||ez.defaultView).location;
return!_aoDom.onclick&&fz&&fz.indexOf("javascript:")!=0&&fz.indexOf("#")!=0&&
fz.indexOf(ja.protocol+"//"+ja.hostname+"/")!=0;

}







function swapLink(aG,Ja,dp)
{
var dj=aG.ownerDocument?aG:S(aG,dp);
if(dj)
{
function aId(akn)
{
if(bcm(akn))
{
akn.target="_blank";
akn.onclick=function()
{
return aSW.call(this,Ja);
};
}
akn=null;
}

linkIdentify(dj);
E(GelTags("a",dj),aId);
E(GelTags("area",dj),aId);
E(GelTags("form",dj),function(beO)
{
beO.onsubmit=function()
{
var ja=dp.location;

if(ja.getParams()["filterflag"]=="true"||this.action)
{
this.target="_blank";
return true;
}

showError(T(['\u51FA\u4E8E\u5B89\u5168\u8003\u8651\u8BE5\u64CD\u4F5C\u5DF2\u88AB\u5C4F\u853D [<a onclick="',
'setTimeout( function() {',
'goUrlMainFrm(\x27$url$&filterflag=true\x27);',
'showInfo(\x27\u53D6\u6D88\u5C4F\u853D\u6210\u529F\x27);','});',
'" style="color:white;" >\u53D6\u6D88\u5C4F\u853D</a>]']).replace({url:ja.pathname+ja.search}));

return false;
};
beO=null;
}
);
}
dj=null;
}






function preSwapLink(_aoEvent,Ja)
{
var aB=getEventTarget(_aoEvent);
if(aB
&&{"A":1,"AREA":1}[aB.tagName]
&&bcm(aB))
{
aSW.call(aB,Ja)&&window.open(aB.href);
preventDefault(_aoEvent);
}
}








function swapImg(aG,dez,Ja,aq)
{














































































}




function openSpam(aq)
{
aq=aq||window;
if(true||confirm("\u6B64\u90AE\u4EF6\u7684\u56FE\u7247\u53EF\u80FD\u5305\u542B\u4E0D\u5B89\u5168\u4FE1\u606F\uFF0C\u662F\u5426\u67E5\u770B\uFF1F"))
{
aq.location.replace(appendToUrl(aq.location.href,"&disptype=html&dispimg=1&clickshowimage=1"));
}
}




function openHttpsMail(aq)
{
aq.location.replace(appendToUrl(aq.location.href,"&dispimg=1"));
}






function copyToClipboard(fk)
{
try
{
if(gbIsFF)
{
netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
Components.classes["@mozilla.org/widget/clipboardhelper;1"].getService(Components.interfaces.nsIClipboardHelper).copyString(fk);
}
else
{

var EC=S("copyinputcontainer");
if(!EC)
{
insertHTML(document.body,"beforeEnd",'<input id="copyinputcontainer" style="position:absolute;top:-1000px;left:-1000px;"/>');
EC=S("copyinputcontainer");
}
EC.value=fk;
EC.select();
document.execCommand('Copy');
}
}
catch(e)
{
alert(T('\u60A8\u7684\u6D4F\u89C8\u5668\u5B89\u5168\u8BBE\u7F6E\u4E0D\u5141\u8BB8\u7F16\u8F91\u5668\u81EA\u52A8\u6267\u884C\u590D\u5236\u64CD\u4F5C\uFF0C\u8BF7\u4F7F\u7528\u952E\u76D8\u5FEB\u6377\u952E($cmd$+C)\u6765\u5B8C\u6210\u3002').replace({cmd:gbIsMac?"Command":"Ctrl"}));
return false;
}
return true;
}






function aSW(Ja)
{
var ea=this;

if(ea.href.indexOf("mailto:")==0&&ea.href.indexOf("@")!=-1)
{
window.open(["/cgi-bin/readtemplate?sid=",getSid(),
"&t=compose&s=cliwrite&newwin=true&email=",
ea.href.split("mailto:")[1]].join(""));
return false;
}
else if(ea.className=="qqmail_card_reply"
||ea.className=="qqmail_card_reply_btn"
||ea.className=="qqmail_birthcard_reply"
||ea.className=="qqmail_birthcard_reply_btn")
{






var fd=ea.name,
cI=ea.className,
aES=!!fd,
bJH=cI.indexOf("birthcard")!=-1;

getMainWin().location=T('/cgi-bin/cardlist?sid=$sid$&t=$t$&s=$s$&today_tips=$tips$&loc=readmail,readmail,sendnewcard,1&ListType=$listtype$&email=$email$$newwin$').replace(
{
sid:getSid(),
t:aES?"compose_card":"card",
s:bJH?"replybirthcard":"",
tips:cI.indexOf("btn")!=-1?"112":"111",
listtype:aES?"No":"Cards&Cate1Idx=listall",
email:fd,
newwin:getTop().bnewwin?"&newwin=true":""
});
return false;
}
else if(ea.className=="qqmail_postcard_reply_mobile")
{
var tv=getMainWin().QMReadMail;
if(tv)
{
getMainWin().location=T("/cgi-bin/readmail?sid=$sid$&mailid=$mailid$&t=compose&s=reply&disptype=html").replace(
{
sid:getSid(),
mailid:tv.getMailId()
})
}
return false;
}
else if(ea.className=="qqmail_postcard_sendhelp_mobile")
{
window.open("http://service.mail.qq.com/cgi-bin/help?subtype=1&&id=36&&no=1000696");
return false;
}
else if(ea.className=="qqmail_card_reply_thanksbtn"
||ea.className=="qqmail_card_reply_thanks"
||ea.className=="qqmail_birthcard_reply_thanksbtn")
{
var fd=ea.name;

openComposeDlg("card",{
sTitle:"\u7B54\u8C22\u597D\u53CB",
sDefAddrs:fd,
bAddrEdit:true,
sDefContent:"\u8C22\u8C22\u4F60\u7684\u8D3A\u5361\uFF01 \u4EE5\u540E\u8981\u5E38\u8054\u7CFB\u54E6\u3002",
bContentEdit:true,
sDefSubject:"\u8C22\u8C22\u4F60\u7684\u8D3A\u5361!",
bRichEditor:false,
oncomplete:function(){},

bShowResult:true
});
return false;
}












else if(ea.className=="qqmail_postcard_reply")
{
goUrlMainFrm(
T('/cgi-bin/readtemplate?sid=$sid$&t=compose_postcard&email=$email$'
).replace({
sid:getSid(),
email:ea.name
}),false
);
return false;
}
else if(ea.className=="qqmail_postcard_reply2")
{
var aVi='',
aAS='',
tv=getMainWin().QMReadMail;
if(tv)
{
try
{
var Rl=(tv.getSubMailWithDom?tv.getSubMailWithDom(ea):tv.getMailInfo()).from;
aVi=Rl&&Rl.name||'';
aAS=Rl&&Rl.addr||'';
}
catch(e)
{
}
}
goUrlMainFrm(
T('/cgi-bin/readtemplate?sid=$sid$&t=compose_postcard&email=$email$&reply=1&frname=$name$&fraddr=$addr$'
).replace({
name:escape(aVi),
addr:escape(aAS),
sid:getSid(),
email:ea.name
}),false
);
return false;
}












else if(ea.className=="qqmail_postcard_print")
{
var tv=getMainWin().QMReadMail;
if(tv)
{
window.open(T('/cgi-bin/readmail?sid=$sid$&t=print_haagendazs&s=print&filterflag=true&mailid=$mailid$').replace(
{
sid:getSid(),
mailid:tv.getMailId()
})
);
}
return false;
}
else if(ea.className=="qqmail_postcard_getmoreinfo")
{
var tv=getMainWin().QMReadMail;
if(tv)
{
window.open(T('/cgi-bin/today?t=haagendazs2010&sid=$sid$').replace(
{
sid:getSid(),
mailid:tv.getMailId()
})
);
}
return false;
}
else if(ea.className=="qqmail_videomail_reply")
{
goUrlMainFrm(
T('/cgi-bin/readtemplate?sid=$sid$&t=compose_video&email=$email$'
).replace({
sid:getSid(),
email:ea.name
}),false
);
return false;
}
else if(ea.className=="groupmail_open")
{
getMainWin().location=["/cgi-bin/grouplist?sid=",getSid(),
"&t=compose_group",(getTop().bnewwin?"&newwin=true":"")].join("");
return false;
}
else if(ea.className=="reg_alias")
{
getMainWin().location=[
"/cgi-bin/readtemplate?reg_step=1&t=regalias_announce&sid=",
getSid()].join("");
return false;
}

else if(ea.className=="mergemail_reader_article_list_link")
{
var bLv=ea.getAttribute("ctype");
var awA=ea.getAttribute("param_new");
var aO="";


if(awA.indexOf("follow=1")>=0)
{
var bFg=ea.getAttribute("followuin");
aO=(getTop().gsRssDomain||"")+"/cgi-bin/reader_mgr";
QMAjax.send(aO,
{
method:"POST",
content:"fun=followshare&followuin="+bFg+"&sid="+getSid(),
onload:function(aV,cGy)
{
if(aV)
{

getMainWin().location=T('$host$/cgi-bin/reader_article_list?sid=$sid$&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:awA
});
}
}
});
}

else
{
getMainWin().location=T('$host$/cgi-bin/reader_article_list?sid=$sid$&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:awA
});
}


if(bLv=="onefeed")
{
aO=(getTop().gsRssDomain||"")+"/cgi-bin/reader_mgr?fun=setlog&flag=3&from=2";
}
else
{
aO=(getTop().gsRssDomain||"")+"/cgi-bin/reader_mgr?fun=setlog&flag=3&from=4";
}
runUrlWithSid(aO);

return false;
}
else if(ea.className=="mergemail_reader_setting_link")
{

getMainWin().location=T('$host$/cgi-bin/reader_setting?t=rss_setting_notify&sid=$sid$&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:ea.getAttribute("param")
});


var aO=(getTop().gsRssDomain||"")+"/cgi-bin/reader_mgr?fun=setlog&flag=3&from=3";
runUrlWithSid(aO);
return false;
}
else if(ea.className=="reader_article_list_link")
{

getMainWin().location=T('$host$/cgi-bin/reader_article_list?sid=$sid$&$param$').replace(
{
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:ea.getAttribute("param")
}
);

return false;
}

else if(ea.className=="reader_detail_qqmail_link")
{
var cX=[];

E(ea.getAttribute("param").split("&"),function(bQ)
{
if(bQ.indexOf("share=1")<0)
{
cX.push(bQ);
}
}
);

getMainWin().location=T('$host$/cgi-bin/reader_detail?sid=$sid$&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:cX.join("&")
});
return false;
}
else if(ea.className=="reader_list_qqmail_link")
{
var cX=[];

E(ea.getAttribute("param").split("&"),function(bQ)
{
cX.push(bQ);
}
);
getMainWin().location=T('$host$/cgi-bin/reader_list?classtype=allfriend&refresh=1&share=1&sid=$sid$&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:cX.join("&")
});
return false;
}
else if(ea.className=="reader_catalog_list_qqmail_link")
{
var cX=[];

E(ea.getAttribute("param").split("&"),function(bQ)
{
cX.push(bQ);
}
);

getMainWin().location=T('$host$/cgi-bin/reader_catalog_list?sid=$sid$&classtype=share&share=1&refresh=1&$param$'
).replace({
host:(getTop().gsRssDomain||""),
sid:getSid(),
param:cX.join("&")
});
return false;
}
else if(ea.className=="ftn_groupshare_enter_link")
{
getMainWin().location.href=T(
'/cgi-bin/ftnExs_files?listtype=group&s=group&t=exs_ftn_files&sid=$sid$'
).replace({sid:getSid()});
return false;
}
else if(ea.className=="book_article_list_link")
{

getMainWin().location=T('/cgi-bin/setting10?sid=$sid$&$param$').replace(
{
sid:getSid(),
param:ea.getAttribute("param")
}
);

return false;
}



if(1)
{

if(ea.href.indexOf("javascript:void(0)")>=0)
{

return false;
}
if(Ja!="preview"&&getMainWin().location.href.indexOf('/cgi-bin/readmail?')<0)
{
return true;
}

var ju=ea.parentNode;
while(ju)
{
if(ju.nodeType==1&&(ju.id=="QQmailNormalAtt"||ju.id=="attachment"))
{
return true;
}
ju=ju.parentNode;
}

window.open(T('/cgi-bin/mail_spam?sid=$sid$&action=check_link&url=$url$&mailid=$mid$&spam=$spam$').replace(
{
mid:getMainWin().location.getParams()['mailid'],
spam:Ja=="spam"?1:0,
sid:getSid(),
url:escape(ea.href)
}
),"_blank");
return false;
}

var fI="http://mail.qq.com/cgi-bin/feed?u=";
if(ea.name=="_QQMAIL_QZONESIGN_"||ea.href.indexOf(fI)==0)
{
if(ea.name=="_QQMAIL_QZONESIGN_")
{
var bAj=ea.href.split("/"),
lO=parseInt(bAj[2]),
cg=[
"&sid=",
getSid(),
"&u=http%3A%2F%2Ffeeds.qzone.qq.com%2Fcgi-bin%2Fcgi_rss_out%3Fuin%3D",
lO
].join("");
}
else
{
var aPt=ea.href.substr(fI.length);
if(aPt.indexOf("http%3A%2F%2F")==0
||aPt.indexOf("https%3A%2F%2F")==0)
{
var cg=["&sid=",getSid(),"&u=",ea.href.substr(fI.length)]
.join("");
}
else
{
var cg=["&sid=",getSid(),"&u=",
encodeURIComponent(ea.href.substr(fI.length))].join("");
}
}
if(getTop().bnewwin)
{
goUrlTopWin(["/cgi-bin/frame_html?target=feed",cg].join(""));
}
else
{
goUrlMainFrm(["/cgi-bin/feed?",cg].join(""),false);
}
return false;
}
else if(ea.name=="QmRsSRecomMand")
{
getMainWin().location=T("$host$/cgi-bin/reader_detail?vs=1&feedid=$feedid$&itemid=$itemid$&t=compose&s=content&mailfmt=1&sid=$sid$&newwin=$isnewwin$&tmpltype=recommend&loc=reader_detail,rss_recommend,,2").replace({
host:(getTop().gsRssDomain||""),
feedid:ea.getAttribute("feedid"),
itemid:ea.getAttribute("itemid"),
sid:getSid(),
isnewwin:!!getTop().bnewwin
});
return false;
}

return true;
}





function goPrevOrNextMail(ary)
{
var dj,
cp=getMainWin();

if(!!(dj=S(["prevmail","nextmail"][ary?1:0],cp))
&&!dj.getAttribute("disabled"))
{

}
else if(!!(dj=S(["prevpage","nextpage","prevpage1","nextpage1"][ary?1:0],cp))
&&!dj.getAttribute("disabled"))
{
cp.location=dj.href;
}
}





function goBackHistory()
{
var Ez=SN("readmailBack",getMainWin());
if(Ez.length>0&&isShow(Ez[0]))
{
fireMouseEvent(Ez[0],"click");
return true;
}
return false;
}
















function MLIUIEvent(De,aq,ec)
{
var bd=De.value,
bz=QMMailCache,
Az=bz.isRefresh(aq),
zx=De.parentNode;
while(zx.tagName.toUpperCase()!="TABLE")
{
zx=zx.parentNode;
}
var gn=GelTags("table",zx)[0],
Av=GelTags("td",GelTags("tr",gn)[0]),
bVL=Av[1],
PR=Av[Av.length-1];

De.setAttribute('init','true');
QMReadedItem.addItem(De);


if(PR.className=="new_g")
{
PR=Av[6];
}


var atP=GelTags("div",gn),
Xf;
for(var aD=atP.length-1;aD>=0;aD--)
{
if(atP[aD].className=="TagDiv")
{
Xf=atP[aD];
break;
}
}


if(bz.hasData(bd))
{
if(!Az)
{
var av=bz.getData(bd);
if(De.getAttribute("unread")=="true")
{
bz.addVar("unread",-1);
}
aND(De,zx,false,av.reply);
aWn(De,zx);

if(av.star!=null)
{
setClass(PR,av.star?"fg fs1":"fg");
bz.addVar("star",av.star?1:-1);
}

if(av.oTagIds)
{
var Ek=GelTags("table",gn),
yI=av.oTagIds,
Mv,
aQL={};

if(Xf)
{
for(var aD=Ek.length-1;aD>=0;aD--)
{
if(Mv=Ek[aD].getAttribute("tagid"))
{
aQL[Mv]=1;
}
}
for(var agN in yI)
{
if(yI[agN]===0)
{

QMTag.rmTagUI(Xf,agN);
}
else if(!aQL[agN])
{

QMTag.addTagUI(Xf,agN,ec,bd,false);
}
}
}
}
}
else
{

bz.addData(bd,
{
bUnread:De.getAttribute("unread")=="true",
oTagIds:{},
star:null,
reply:null
});
}
}

listMouseEvent(zx);

PR.title=PR.className=="fg"?"\u6807\u8BB0\u661F\u6807":"\u53D6\u6D88\u661F\u6807";
addEvent(PR,'click',function(_aoEvent)
{
starMail(null,QMMailList.getCBInfo(aq,bd));
return stopPropagation(_aoEvent);
}
);

addEvent(zx,"click",GetListMouseClick(aq));
addEvent(zx,"selectstart",preventDefault);


var avE=gn.rows[0].cells[1];
if(avE.className.indexOf("fr")>-1)
{

loadJsFile("$js_path$qmtip0be06f.js",true);
addEvent(avE,"mouseover",MLI.aYo);
addEvent(avE,"mouseout",MLI.aYo);
}


addEvent(Xf,'click',function(_aoEvent)
{
if(QMTag.readclose(_aoEvent,QMMailList.getCBInfo(aq,bd)))
{
return stopPropagation(_aoEvent);
}
}
);

dragML(zx,De);

}






function MLI(dvU,aq,ec,Ej)
{














var aMP=SN("mailid",aq),
Jw=aMP[aMP.length-1],
bd=Jw.value,
_oItem=Jw.parentNode,
bz=QMMailCache,
Az=bz.isRefresh(aq);

while(_oItem.tagName.toUpperCase()!="TABLE")
{
_oItem=_oItem.parentNode;
}

MLIUIEvent(Jw,aq,ec);


var bSb=Jw.getAttribute("uw")=="1",
aOV=bSb?aq.oPreUWMails:aq.oPreMails,
bSk=aOV.length,
bVg=Az?2:1,

bLK=new Date()-new Date(parseInt(Jw.getAttribute("totime")))<2592000000,

bBE=!/^(LP|ZP)/.test(bd)&&bLK&&Jw.getAttribute("unread")=="true"&&bSk<bVg&&!rdVer.log(bd);

if(bBE&&rdVer.isPre(ec))
{
var aO,
Bl=Jw.getAttribute("gid");

aO=rdVer.url(bd,ec,Ej,"",false,"",false,"",true);

if(aO)
{
aOV.push(aO);
}
}

if(getTop().gsReadedMailId==bd)
{
QMReadedItem.disp(_oItem);
recordReadedMailId(null);
}

}









function MLJump(bQK,bHQ,bc,aq)
{
var bOA=SN("maillistjump",aq.document),
aVQ="_MlJuMp_",
Ty=parseInt(bQK)||0,
Nb=parseInt(bHQ)||0;

function aRb(aG)
{
var kB=getTop().QMMenu(aG).S("txt"),
cu=parseInt(kB.value);

if(isNaN(cu))
{
kB.select();
return showError("\u8BF7\u8F93\u5165\u8DF3\u8F6C\u7684\u9875\u6570");
}

cu=Math.max(0,Math.min(cu-1,Nb));
if(Ty==cu)
{
kB.select();
return showError("\u4F60\u8F93\u5165\u4E86\u5F53\u524D\u9875\u6570");
}

getTop().QMMenu(aG).close();
goUrlMainFrm([bc,'&page=',cu,'&loc=mail_list,,jump,0',getTop().isSelectAllFld(getMainWin())?"&selectall=1":""].join(''));
}

E(bOA,function(afi)
{
if(!afi.getAttribute(aVQ))
{
afi.setAttribute(aVQ,"1");
addEvents(afi,
{
click:function(_aoEvent)
{
var aT=unikey("mljump"),
_oPos=calcPos(afi),
cy=185,
cF=40;


new(getTop().QMMenu)(
{
sId:aT,
oEmbedWin:aq,
nWidth:cy,
nX:_oPos[1]-cy,
nY:bodyScroll(aq,"scrollHeight")-_oPos[2]<cF?(_oPos[0]-cF-13):_oPos[2],
bAutoClose:false,
oItems:
[
{
nHeight:cF,
sItemValue:MLJump.fK.replace({id:aT})
}
],
onshow:function()
{
this.S("txt").focus();
}
}
);

addEvent(getTop().QMMenu(aT).S("txt"),"keypress",function(_aoEvent)
{
var dG=_aoEvent.keyCode||_aoEvent.which;
if(dG===13)
{
aRb(aT);
}
else if((dG<48||dG>57)&&dG!=8&&dG!=9)
{
preventDefault(_aoEvent);
}
}
);

addEvent(getTop().QMMenu(aT).S("btn"),"click",function(_aoEvent)
{
aRb(aT);
}
);

preventDefault(_aoEvent);
}
}
);
}
}
);
}

MLJump.fK=T(
[
'<div style="position:absolute;width:160px;margin-left:-7px;">',
'<div class="addrtitle jumpmenusdjust" style="float:left;">\u8DF3\u8F6C\u5230\u7B2C <input id="txt" type="text" class="txt" style="width:30px;" /> \u9875</div>',
'<a id="btn" href="javascript:;" class="left button_gray_s" style="width:40px; margin:7px 0 0 5px; _display:inline;">&nbsp;\u786E\u5B9A&nbsp;</a>',
'</div>'
]
);







function initDropML()
{
function ahM(_aoDom)
{
var _oPos=calcPos(_aoDom),
hE=S('dragtitle'),
ry=hE.offsetLeft,
qD=hE.offsetTop;
return(_oPos[1]>ry&&_oPos[3]<ry&&_oPos[2]>qD&&_oPos[0]<qD)?_aoDom:null;
}

function Xb(_aoDom,aQJ)
{
if(_aoDom&&_aoDom.id.indexOf('folder_')>=0)
{
var cI=_aoDom.className,
aSL=cI.indexOf('toolbg')>-1;
if(aQJ&&aSL)
{
setClass(_aoDom,cI.replace(/\btoolbg\b/g,''));
}
else if(!aSL&&!aQJ)
{
setClass(_aoDom,cI+' toolbg');
}
}
}

var hE=S('dragtitle'),
aPM=S('OutFolder'),
aMb='inidrop',
Bm=BaseMailOper.getInstance(getMainWin()),
azb=QMDragDrop,
bbw='mail_list';

if(aPM.getAttribute(aMb)=='true')
{

return false;
}
aPM.getAttribute(aMb,'true');
azb.delGroup(bbw);

var Hn=null,

atF=false,
rH=null,
kw=null,
jg=null,



aWA=/^([489]|personal|pop|tag)$/,

akr=new azb.DropTarget(
S('OutFolder'),
{





ondragover:function(rJ)
{
if(rH==kw)
{
return;
}
var caA=rH&&rH.id||'',
QN=kw&&kw.id||'',
azE=rH&&rH.getAttribute('dp'),
auP=kw&&kw.getAttribute('dp'),
bcl=kw&&kw.getAttribute('dr');


if(auP)
{
showFolders(auP,true,getTop());
}
if(azE&&azE!=auP)
{
showFolders(azE,false,getTop());
}

Xb(rH,1);
Xb(kw);


if(jg)
{
clearTimeout(jg);
}
atF=bcl&&!aWA.test(bcl);
jg=setTimeout(function(){
setClass(hE,atF?'drag_over':'drag_out');
jg=null;
},50);

rH=kw;
},





ondrop:function(rJ)
{
if(!kw||!atF)
{
return;
}
var gX=Bm.getMailInfo().sFid,
aT=kw.getAttribute('dr')||'';
ossLog("delay","all","stat=drag&opr="+aT);


if(aT=='6')
{

Xb(rH,1);
rH=null;
Bm.apply('spammail');
dragML.avw=true;
return;
}
else if(aWA.test(aT))
{
Xb(rH,1);
rH=null;
return;
}
else if(aT.indexOf('tag_')>=0)
{

aT=aT.replace('tag','tid');
}
else if(aT=='starred')
{
aT='star';
}
else if((gX==5||gX==6)&&aT==5)
{
aT='predelmail';
dragML.avw=true;
}
else if(parseInt(aT))
{
aT={5:'delmail'}[aT]||'fid_'+aT;
}
else
{
return;
}
Bm.apply(aT);
hE.setAttribute('na','true');
var lP=new qmAnimation(
{
from:100,
to:1
}
);
lP.play(
{
speed:"slow",
onaction:function(bW,ho)
{
setOpacity(hE,bW/100.0);
},
oncomplete:function(bW,agS)
{
show(hE,0);
setClass(hE,'drag_out');
setOpacity(hE,100);
Xb(rH,1);
rH=null;
}
});
}
},
function(ry,qD,rJ){






if(gbIsIE)
{
var aB=getEventTarget(rJ.event),
bTL=/(folder_\w+_td|(personal|pop|tag)foldersDiv)/;
while(aB&&!bTL.test(aB.id))
{
aB=aB.parentNode;
}
kw=aB;
}
else if(kw=ahM(S('OutFolder')))
{


var ft=['personal','pop','tag'],
YQ=null,
aZU=null,
FT,
i;
for(i=ft.length-1;i>=0;i--)
{
if(YQ=ahM(S(ft[i]+'foldersDiv')))
{
break;
}
}

if(YQ=YQ||ahM(S('SysFolderList')))
{

FT=GelTags('li',YQ);
for(i=FT.length-1;i>=0;i--)
{
if(aZU=ahM(FT[i]))
{
break;
}
}
}
kw=aZU||YQ;

}
return!!(rH||kw);
}
);
azb.addGroup(bbw,akr);
}

function dragML(_aoDom,iv)
{
if(!S('OutFolder')||!QMDragDrop)
{


return;
}
var ae=dragML,
aT='dragtitle',
hE=S(aT);
if(!hE)
{
insertHTML(getTop().document.body,'afterBegin','<div id="dragtitle" class="drag_out" style="display:none;"></div>');
hE=S(aT);
}
var Hn,

Oj=new QMDragDrop.Draggable(
_aoDom,
{

threshold:5,
oTitle:hE
},
{
ondragstart:function(_aoEvent)
{
ae.avw=iv.checked==true;
iv.checked=true;
var aA=getMainWin(),
Bm=BaseMailOper.getInstance(aA),
bO=QMMailList.getCBInfo(aA);
QMMailList.selectedUI(bO);
Bm.setMailInfo(bO);
hE.innerHTML=['\u9009\u4E2D ',bO.oMail.length,' \u5C01\u90AE\u4EF6'].join('');

ossLog("delay","all","stat=drag&c="+bO.oMail.length);









Hn=gbIsIE?[0,0,0,0]:calcPos(aA.frameElement);
hE.style.left=Hn[3]+_aoEvent.clientX+'px';
hE.style.top=Hn[0]+_aoEvent.clientY+'px';
hE.setAttribute('na','');
show(hE,1);

initDropML();
},
ondrag:function(_aoEvent)
{
hE.style.left=Hn[3]+_aoEvent.clientX+'px';
hE.style.top=Hn[0]+_aoEvent.clientY+'px';
},
ondragend:function(_aoEvent)
{
if(!hE.getAttribute('na'))
{

show(hE,0);
setClass(hE,'drag_out');
}
if(!ae.avw)
{
iv.checked=false;
var bph=QMMailList.getCBInfo(getMainWin());
QMMailList.selectedUI(bph);
}
}
}
);
QMDragDrop.addGroup('mail_list',Oj);


var aL=_aoDom.ownerDocument,
aA=aL.parentWindow||aL.defaultView,
ahm=dragML.ahm=dragML.ahm||unikey('drag');
if(!aA[ahm])
{
addEvent(aA,'unload',function(){
if(hE.releaseCapture)
{
hE.releaseCapture();
}
show(hE,0);
});
aA[ahm]=1;
}
}




MLI.aYo=function(_aoEvent)
{
var _oTop=getTop(),
ae=arguments.callee,
Cb=_aoEvent.clientX,
Cd=_aoEvent.clientY,
bn=getEventTarget(_aoEvent);
while(bn&&bn.tagName.toUpperCase()!="TD")
{
bn=bn.parentNode;
}
if(ae.uT)
{
clearTimeout(ae.uT);
ae.uT=0;
}

if(_aoEvent.type=="mouseout")
{
_oTop.QMTip&&_oTop.QMTip.showMailList(0,bn.ownerDocument);
return;
}

ae.uT=setTimeout(function(){
var bab=_oTop.GelTags("b",bn.parentNode.cells[2]),
aLV=bab[bab.length-1];

if(!_oTop.QMTip||!aLV||(ae.ti==Cb&&ae.sb==Cd))
{
return;
}

ae.ti=Cb;
ae.sb=Cd;

var zG=aLV.innerHTML.replace(/^\&nbsp;-\&nbsp;/,"").replace(/\&nbsp;/gi,"&nbsp; ").replace(/&lt;br\/?&gt;/g,'<br/>');
_oTop.QMTip.showMailList(1,bn.ownerDocument,zG,Cb,Cd);
},250);
};





function MLI_A(ez)
{
var Ng=GelTags("table",ez),
bDF=Ng.length,

_oItem=Ng[bDF-1],
bd=_oItem.getAttribute("mailid");

if(QMMailCache.hasData(bd))
{
if(!QMMailCache.isRefresh(window))
{
setClass(_oItem,"i M");
}
else
{
QMMailCache.delData(bd);
}
}

listMouseEvent(_oItem);

addEvent(_oItem,"selectstart",preventDefault);
}










function aSD(iv,CH,tC,aeA)
{
if(!(iv&&iv.type=="checkbox"))
{
return false;
}

if(tC==null)
{
return iv.getAttribute("unread")=="true";
}

if(!CH)
{
CH=iv.parentNode.parentNode.parentNode.parentNode;
}

if((iv.getAttribute("unread")=="true")==!!tC
&&!aeA)
{
return tC;
}

var Bl=iv.getAttribute("gid");
if(Bl)
{
setGroupUnread(Bl,getGroupUnread(Bl)-1);
setGroupUnread("gall",getGroupUnread("gall")-1);
}

iv.setAttribute("unread",tC?"true":"false");

setClass(CH,
[tC?"i F":"i M",iv.checked?" B":""].join(""));
setClass(GelTags("table",CH)[0],tC?"i bold":"i");


var bbF=GelTags("div",CH)[1];
if(!/(s[016789]bg)|(Rw)/.test(bbF.className))
{
var atc=aeA?"r":iv.getAttribute("rf"),
azU=iv.getAttribute("isendtime"),
cI="Rr";

if(azU)
{
cI=azU=="0"?"Rc":"Ti";
}
else if(tC)
{
cI="Ru";
}
else if(atc)
{
cI=atc=="r"?"Rh":"Rz";
}

setClass(bbF,"cir "+cI);
}

return tC;
}






function bKq(iv)
{
return aSD(iv);
}









function aND(iv,CH,tC,aeA)
{
return aSD(iv,CH,tC,aeA);
}








function aWn(iv,CH)
{
if(!iv||!iv.getAttribute("gid"))
{
return false;
}

var aTF=GelTags("b",CH)[0],
Ji=aTF&&aTF.parentNode;

if(Ji&&Ji.className=="new_g")
{
Ji.style.visibility="hidden";
return true;
}

return false;
}






function getMailListInfo()
{
var cp=getMainWin(),
aNz=S("_ut_c",cp),
aNh=S("_ur_c",cp),
aTk=S("_ui_c",cp);

return{
totle:(aNz&&parseInt(aNz.innerHTML))||0,
unread:(aNh&&parseInt(aNh.innerHTML))||0,
star:(aTk&&parseInt(aTk.innerHTML))||0
};
}






function crA(dp,aPS)
{
var Hd=S("selectAll",dp);

if(Hd)
{
Hd.setAttribute("totalcnt",aPS);
E(GelTags("div",Hd),
function(bn,cU)
{
var Im=bn.getAttribute("un");
if(Im=="selected")
{
GelTags("span",bn)[0].setAttribute("end",aPS);
}
else if(Im=="unselect")
{
var bq=bn.innerHTML;
bn.innerHTML=bq.replace(/\u5168\u90E8.*\u5C01/gi,"\u5168\u90E8&nbsp;"+aPS+"&nbsp;\u5C01");
}
}
);
}
}








function setMailListInfo(EO,zZ,awN)
{
var cp=getMainWin(),
iG=true,
awB=S("_ur",cp),
bGH=S("_ui",cp),
bFN=S("_ut",cp),
dj;

if(!isNaN(EO=parseInt(EO)))
{
if(!!(dj=S("_ur_c",cp)))
{
dj.innerHTML=Math.max(0,EO);
show(awB,EO>0);
}
else
{
iG=false;
}
var afN=S("tip_unread",cp);
if(afN)
{
afN.innerHTML=EO<0?parseInt(afN.innerHTML)+EO:EO;
show(afN,EO);
}
}

if(!isNaN(zZ=parseInt(zZ)))
{
zZ=Math.max(0,zZ);
if(!!(dj=S("_ui_c",cp)))
{
dj.innerHTML=zZ;
show(bGH,zZ!=0);
}
else
{
iG=false;
}
}

if(!isNaN(awN=parseInt(awN)))
{
zZ=Math.max(0,awN);
if(!!(dj=S("_ut_c",cp)))
{
dj.innerHTML=zZ;
show(bFN,zZ!=0);

getTop().crA(cp,zZ);
}
else
{
iG=false;
}
}

show(
S("_uc",cp),
isShow(awB)

);
show(
S("_ua",cp),
isShow(awB)

);

return iG;
}








function readMailFinish(aI,aw,ec,bXF)
{
var cp=getMainWin(),
auF=S("load_"+aI,cp),
_oItem,oi;

QMMailCache.addData(aI);

if(auF)
{
show(auF,false);

_oItem=auF.parentNode.previousSibling;
oi=GelTags("input",_oItem)[0];
}
else
{
var hm=GelTags("input",cp.document);
for(var i=0,_nLen=hm.length;i<_nLen;i++)
{
if(hm[i].type=="checkbox"
&&hm[i].value==aI)
{
oi=hm[i];
break;
}
}
_oItem=oi;
while(_oItem.tagName.toUpperCase()!="TABLE")
{
_oItem=_oItem.parentNode;
}
}


var Ek=GelTags("table",_oItem),
aRU=false;
for(var aD=Ek.length-1;aD>=0;aD--)
{
if(Ek[aD].getAttribute("tagid"))
{
aRU=true;
break;
}
}

aWn(oi,_oItem);

if(oi&&bKq(oi))
{
aND(oi,_oItem,false);
setMailListInfo(getMailListInfo().unread-1);


if(oi.getAttribute('star')=='1')
{
setFolderUnread('starred',getFolderUnread('starred')-1);
}

if(ec&&parseInt(ec)>0&&!aRU)
{
setFolderUnread(ec,bXF
?getGroupUnread("gall")
:getMailListInfo().unread);
}
else
{
reloadLeftWin();
}
}
}









function checkMail(my)
{
if(my=="")
{
showError("\u6DFB\u52A0\u7684\u5185\u5BB9\u4E0D\u80FD\u4E3A\u7A7A");
return false;
}

if(!my.match(/^[\.a-zA-Z0-9_=-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/))
{
showError("\u60A8\u8F93\u5165\u7684\u90AE\u7BB1\u5730\u5740\u4E0D\u6B63\u786E\uFF0C\u8BF7\u91CD\u65B0\u8F93\u5165");
return false;
}

return true;
}








function checkAndSubmit(aG)
{
var bC=S(aG);

if(!checkMail(trim(bC.value)))
{
bC.focus();
return false;
}

submitToActionFrm(bC.form);
}






function pushToDialogList(aG)
{
var _oTop=getTop();

if(!_oTop.goDialogList)
{
_oTop.goDialogList=new _oTop.Object;
}

if(aG)
{
_oTop.goDialogList[aG]=true;
}
}





function showDialogNewReadMail(bMO,bHO,Bp,aI)
{
new(getTop().QMDialog)({
sId:"addnewremind_qqmail",
sTitle:"\u65B0\u5EFA\u63D0\u9192",
sUrl:T("/cgi-bin/read_reminder?linkid=%linkid%&linktitle=%linktitle%&sid=%sid%&t=remind_edit&from=%from%","%").replace({
sid:getSid(),
linkid:bMO,
linktitle:bHO,
from:Bp
}),
nWidth:450,
nHeight:360
})
aI&&rdVer(aI,1);
}

function setRemindSpan(aI,aq)
{


getTop().S('remind_edit_'+aI,aq).innerHTML=(getTop().reminddetail["mailid:"+aI]||"")
.replace(/linktitle=.*&sid=/g,function(bK)
{
return bK.replace(/\'/g,"&#039;");
}
);
}


function showSimpleRuleFilter(cD)
{
if(!cD)
{
showError("\u65E0\u6CD5\u83B7\u53D6\u53D1\u4EF6\u4EBA\u5730\u5740\uFF0C\u4E0D\u80FD\u521B\u5EFA\u89C4\u5219");
return;
}
var ee=new(getTop().QMDialog)(
{
sId:"addnewfilter_qqmail",
sTitle:"\u5FEB\u6377\u521B\u5EFA\u6536\u4FE1\u89C4\u5219",
sUrl:T("/cgi-bin/setting2?sid=$sid$&Fun=GetFolderList&CurFilterID=0&t=readmail_filter&fromaddr=$fromaddr$").replace({
sid:getSid(),
fromaddr:cD
}),
nWidth:410,
nHeight:237,
onshow:function()
{
var amS=this.getDialogWin();
waitFor(
function()
{
try
{
return S("jump",amS);
}
catch(e){}
},
function(aV)
{
if(aV)
{
function dOa(bgp)
{
if(bgp.length)
{
bgp.push({
bDisSelect:true,
nHeight:10,
sItemValue:'<hr/>'
});
}
bgp.push({
bDisSelect:false,
nHeight:22,
sId:"new",
sItemValue:'\u65B0\u5EFA\u6587\u4EF6\u5939...'
});

return bgp;
};
function cuE()
{
var CF=bgu.get(2);

return CF=="new"?"-1":CF;
};
function cKv()
{
bgu.set(Uu[0].sId,2);
};
function duW(aK,bK)
{
var ciF={
bDisSelect:false,
nHeight:22,
sId:bK,
sItemValue:aK
};

if(Uu.length==1)
{
Uu=bUY(Uu,{
bDisSelect:true,
nHeight:10,
sItemValue:'<hr/>'
},0);
Uu=bUY(Uu,ciF,0);
}
else
{

Uu=bUY(Uu,ciF,Uu.length-2)
}
bgu.update({
oMenu:{
oItems:Uu
}
});
bgu.set(bK,2);
};
function bUY(eh,bt,vn)
{
({}).toString.call([])!="[object Array]"&&(bt=[bt]);
return eh.slice(0,vn).concat(bt).concat(eh.slice(vn,eh.length));
};
function dTs()
{

promptFolder({
type:'folder',
bAlignCenter:true,
width:410,
height:237,
style:"createNewFolder",
onreturn:function(aK)
{
QMAjax.send(
"/cgi-bin/foldermgr",
{
method:"POST",
content:["sid=",getSid(),"&fun=new&from=simple&ef=js&resp_charset=UTF8&name=",aK].join(''),
onload:function(aV,sJ)
{
try
{
if(aV)
{
var av=eval("("+sJ+")");
if(av.errcode=="0")
{
duW(aK,av.folderid);
reloadLeftWin()
showInfo("\u5DF2\u6210\u529F\u65B0\u5EFA\u6587\u4EF6\u5939");
}
else
{
showError(av.errmsg);
}
return;
}
}
catch(e)
{}
showError("\u7F51\u7EDC\u5F02\u5E38\uFF0C\u8BF7\u7A0D\u540E\u518D\u8BD5\u3002");
}
}
);
}
});
};

var Uu=dOa(amS.oUserFolder)
bgu=new QMSelect({
oContainer:S("selectfolder",amS),


oMenu:{
nWidth:"auto",
nMaxWidth:180,
nMaxItemView:4,
oItems:Uu 
},
onselect:function(bt)
{
if(bt.sId=="new")
{
dTs();
return true;
}
}
});

addEvent(S("jump",amS),"click",function()
{
ee.close();
var iX=cuE();
iX=="-1"&&(iX="");
getMainWin().location.replace(
amS.location.href
.replace("&Fun=GetFolderList","&Fun=Create")
.replace("&t=readmail_filter","&loc=filter,simple,0,0&folderid="+iX)
);
}
);
addEvent(S("confirm",amS),"click",function()
{
var iX=cuE(),
cAM=S("oldmail",amS).checked?1:0;

if(iX=="-1")
{
showError("\u60A8\u9700\u8981\u521B\u5EFA\u4E00\u4E2A\u65B0\u6587\u4EF6\u5939");
cKv();
}
else if(!iX)
{
showError("\u8BF7\u9009\u62E9\u6587\u4EF6\u5939");
cKv();
}
else
{
QMAjax.send(
"/cgi-bin/foldermgr",
{
method:"POST",
content:["sid=",getSid(),"&fun=addfilter&from=simple&ef=js&action=move&oldmail=",cAM,"&sender=",cD,"&folderid=",iX].join(''),
onload:function(aV,sJ)
{
try
{
if(aV)
{
var av=eval("("+sJ+")");
if(av.errcode=="0")
{
if(cAM&&av.affected>0)
{
showInfo(TE([
'\u64CD\u4F5C\u6210\u529F\uFF0C',
'$@$if($num$>0)$@$',
'\u79FB\u52A8\u4E86$num$\u5C01\u90AE\u4EF6\u3002',
'$@$else$@$',
'\uFF0C\u60A8\u6CA1\u6709\u9700\u8981\u79FB\u52A8\u6216\u6807\u8BB0\u7684\u90AE\u4EF6\u3002',
'$@$endif$@$',
'<a href="/cgi-bin/mail_list?sid=$sid$&folderid=$fid$&page=0"',
'style="color:white" onclick="getTop().hiddenMsg();" target="mainFrame">',
'[\u67E5\u770B]',
'</a>']).replace({
sid:getSid(),
fid:av.folderid,
num:av.affected
}),30000);
}
else
{
showInfo("\u5DF2\u6210\u529F\u65B0\u5EFA\u89C4\u5219");
}


ossLog("realtime","all","loc=filter,simple,0,1");
ee.close();
}
else
{
showError(av.errmsg);
}
return;
}
}
catch(e)
{}
showError("\u7F51\u7EDC\u5F02\u5E38\uFF0C\u8BF7\u7A0D\u540E\u518D\u8BD5\u3002");
}

}
);
}
}
);
addEvent(S("cancel",amS),"click",function()
{
ee.close();
}
);
}
else
{
showError("\u7F51\u7EDC\u5F02\u5E38\uFF0C\u8BF7\u5237\u65B0\u540E\u91CD\u8BD5\u3002");
}
}
);
}
});

}
function closeSimpleRuleFilter(gK)
{
gK&&gK();
QMDialog("addnewfilter_qqmail").close();
}



function applyRules(cJt)
{
confirmBox({
title:"\u6536\u4FE1\u89C4\u5219",
msg:"\u60A8\u662F\u5426\u8981\u5BF9\u6536\u4EF6\u7BB1\u7684\u5DF2\u6709\u90AE\u4EF6\u6267\u884C\u6B64\u89C4\u5219?",
confirmBtnTxt:'\u662F',
cancelBtnTxt:'\u5426',
onreturn:function(aV)
{
if(aV)
{
QMAjax.send(T("/cgi-bin/exbook_mgr?sid=$sid$&fname=&optype=mailfilter").replace(
{
sid:getSid()
}),
{
method:"GET",
headers:{"If-Modified-Since":"0","Cache-Control":"no-cache, max-age=0"},
onload:function(aV,bQ)
{
showInfo("\u6210\u529F\u5BF9\u6536\u4EF6\u7BB1\u5DF2\u6709\u90AE\u4EF6\u6267\u884C\u6B64\u89C4\u5219!");
callBack(cJt);
}
});
}
else
{
callBack(cJt);
}
}
});
}

function submitSwitchForm()
{
var ey=getTop().S("frmSwitch");
ey&&ey.submit();
}
















function getDomain(bVB)
{
return[["foxmail.com","qq.com","biz"],["Foxmail.com","QQ","\u817E\u8BAF"]][
bVB?1:0][/,7$/.test(getSid())?2:(location.href.indexOf("foxmail.com")>-1?0:1)];
}
var GetDomain=getDomain;





function getSid()
{
return getTop().g_sid
||(S("sid")?S("sid").value:location.getParams(getTop().location.href)["sid"]);
}
var GetSid=getSid;





function getUin()
{
return getTop().g_uin;
}





function getPaths()
{

var Og=
{
images_path:"/zh_CN/htmledition/images/",
js_path:"/zh_CN/htmledition/js/",
css_path:"/zh_CN/htmledition/css/",
style_path:"/cgi-bin/getcss?sid="+getSid()+"ft=",
swf_path:"/zh_CN/htmledition/swf/",

stationery_path:"http://res.mail.qq.com/zh_CN/",
card_path:"http://res.mail.qq.com/zh_CN/",
mo_path:"http://res.mail.qq.com/zh_CN/",
base_path:"/",
skin_path:"0"
};
for(var k in Og)
{
Og[k]=trim(getTop()[k])||Og[k];
}
return Og;
}







function getPath(aw,bVM)
{














aw=="image"&&(aw+="s");
var hs=getPaths()[aw+"_path"]||"";
if(hs)
{
if(bVM&&aw!="skin"&&hs.indexOf("http")!=0)
{
hs=[location.protocol,"//",location.host,hs].join("");
}
}
return hs;
}








function getRes(Tc)
{
return T(Tc).replace(getPaths());
}






function getFullResSuffix(gp)
{
if(!getTop().gLn)
{
return gp;
}
var _sFile,Ke,avF=".j"+"s";
if(gp.indexOf(avF)>0)
{
_sFile=gp.substr(0,gp.indexOf(avF));
Ke=avF;
}
else if(gp.indexOf(".css")>0)
{
_sFile=gp.substr(0,gp.indexOf(".css"));
Ke=".css";
}
else if(gp.indexOf(".html")>0)
{
_sFile=gp.substr(0,gp.indexOf(".html"));
Ke=".html";
}
if(_sFile.length>0&&getTop().gLn[_sFile])
{
return _sFile+getTop().gLn[_sFile]+Ke;
}
else
{
return gp;
}
}












function outputJsReferece(eA,pd,aq)
{
var hs=eA||outputJsReferece.aWQ,
_oFileList=pd||outputJsReferece.yS,
aA=aq||window,
bZ=T(['<script language="JavaScript" src="$file$',(eA?'':'?r='+Math.random()),'"></','script>']),
sk=[];
outputJsReferece.aWQ=hs;
outputJsReferece.yS=_oFileList;

function bFC(iO)
{
var _sFile=trim(iO||""),
gL=/[0-9a-fA-F]{6}\.js$/.test(_sFile)?iO.substr(0,iO.length-9):iO.split(".")[0];

if(gL&&(eA||!aA[gL+"_js"]))
{
sk.push(bZ.replace(
{
file:hs+iO
}
));
}
}
E(_oFileList,bFC);
return sk.join("");
}





function runUrlWithSid(bc)
{
try
{

getTop().getHttpProcesser().src=T('$url$&sid=$sid$&r=$rand$').replace(
{
url:bc,
sid:getSid(),
rand:Math.random()
}
);
}
catch(aZ)
{
}
}




























function createBlankIframe(aq,bR)
{
cacheByIframe(bR&&bR.defcss==false
?[]
:[["css","",getRes("$css_path$comm0bdf8c.css")],["css",getPath("style"),"skin"]],
extend(
{
className:"menu_base_if",
transparent:false,
destroy:false
},
bR,
{
win:aq,
header:["<script>",getTop.toString().replace(/[\r\n]/g,""),"<\/script>",bR&&bR.header||""].join(""),
onload:function(aq)
{
if(this.getAttribute("cbi_inited")!="true")
{
bR&&bR.transparent&&
(this.contentWindow.document.body.style.background="transparent");
this.setAttribute("cbi_inited","true");
}
callBack.call(this,bR&&bR.onload,[aq]);
}
}
)
);
}






function createActionFrame(aq)
{
return createBlankIframe(aq,
{
id:"actionFrame",
defcss:false,
onload:actionFinishCheck
}
);
}
















function hideEditorMenu()
{
if(getTop().QMEditor)
{
getTop().QMEditor.hideEditorMenu();
}
}





function hideMenuEvent(_aoEvent)
{
var dh=getEventTarget(_aoEvent),
Ul=getTop().QMMenu&&getTop().QMMenu();
for(var i in Ul)
{
!Ul[i].isContain(dh)&&Ul[i].close();
}

try
{
getTop().QQPlusUI.hideMenuEvent(dh);
}
catch(zt)
{
}
}






















function confirmBox(ay)
{

var	aiB=2,
uy=ay.defaultChecked||false,
aOp=ay.confirmBtnTxt||"\u786E\u5B9A",
aYH=ay.cancelBtnTxt||"\u53D6\u6D88",
atB=ay.neverBtnTxt;

ay.width=ay.width||450;
ay.height=ay.height||163;
new(getTop().QMDialog)({
bAlignCenter:ay.bAlignCenter,
sId:ay.id||"QMconfirm",
sTitle:ay.title||"\u786E\u8BA4",
sBodyHtml:T([
'<div class="$sStyle$">',
'<div class="cnfx_content">',
'<span class="icon_info_b" style="float:left;margin:15px 10px 0;display:$imgdisp$;"></span>',

'<table style="width:$width$px;height:$height$px;">',
'<tr><td style="vertical-align:top;"><div style="padding-top:10px;word-break:break-all;line-height:150%;" class="b_size">$msg$</div></td></tr>',
'</table>',
'</div>',
'<div class="cnfx_status" style="display:$statusdisp$;">',
'<input id="recordstatus" type="checkbox" $checked$/><label for="recordstatus">$recordinfo$</label>',
'</div>',
'<div class=" txt_right cnfx_btn">',
'<input class="$confirmcss$ btn" type="button" id="confirm" value="$confrim$">',
'<input class="$cancelcss$ btn" type="button" id="cancel" style="display:$caceldisp$;" value="$cancel$">',
'<input class="$nevercss$ btn" type="button" id="never" style="display:$neverdisp$;" value="$never$">',
'</div>',
'</div>'
]).replace({
sStyle:ay.style||'',

msg:ay.msg,
caceldisp:ay.mode=="alert"?"none":"",
imgdisp:ay.mode=="prompt"?"none":"block",
recordinfo:ay.recordInfo,
statusdisp:ay.enableRecord?"":"none",
checked:ay.defaultChecked?"checked":"",
width:ay.width-100,
height:ay.height-83,
confrim:aOp,
confirmcss:getAsiiStrLen(aOp)>5?"":"wd2",
cancel:aYH,
cancelcss:getAsiiStrLen(aYH)>5?"":"wd2",
never:atB,
neverdisp:atB?'':'none',
nevercss:getAsiiStrLen(atB)>5?"":"wd2"
}),
nWidth:ay.width,
nHeight:ay.height,
onload:function(){
var bI=this,
aFI=bI.S("confirm"),
bdP=bI.S("cancel"),
aQM=bI.S("never");








addEvents([aFI,bdP,aQM],
{
click:function(_aoEvent)
{
var _oDom=getEventTarget(_aoEvent);
if(_oDom==aFI)
{
uy=bI.S("recordstatus").checked;
aiB=1;
}
else if(_oDom==aQM)
{
aiB=3;
}
bI.close();
}
}
);
callBack.call(bI,ay.onload);
},
onshow:function(){
this.S("confirm").focus();
callBack.call(this,ay.onshow);
},
onclose:function(){
callBack.call(this,ay.onclose)
},
onbeforeclose:function(){
try
{

callBack.call(this,ay.onreturn,[aiB==1,uy,aiB]);
}
catch(aZ)
{
}
return true;
}
});
}










function alertBox(ay)
{
confirmBox(extend({mode:"alert"},ay))
}













function promptBox(ay)
{
var anZ=false,
bSZ=ay.onreturn;
ay.onreturn=function(aV)
{
var ae=this;
callBack.call(ae,bSZ,[anZ||aV,ae.S("txt").value]);
};
ay.msg=T(
[
'<div style="margin:0 10px 10px;" class="bold">$msg$</div>',
'<div style="margin:10px 10px 5px;"><input type="text" id="txt" style="width:100%;" class="txt" value="$defaultValue$"/></div>',
'<div style="margin:0 10px 10px;" class="f_size addrtitle">$description$</div>'
]
).replace(ay);
confirmBox(extend(
{
mode:"prompt",
height:160,
onload:function()
{
var ae=this;
addEvent(ae.S("txt"),"keydown",function(_aoEvent)
{
if(_aoEvent.keyCode==13)
{
anZ=true;
ae.close();
}
}
);
},
onshow:function()
{
this.S('txt').select();
this.S("txt").focus();
}
},ay)
);
}











function loadingBox(ay)
{
if(!callBack(ay.oncheck))
{
var cG=new QMDialog(
{
sId:"LoAdINgBOx",
sTitle:ay.model+"\u6A21\u5757\u52A0\u8F7D\u4E2D...",
nWidth:400,
nHeight:200,
sBodyHtml:T(
[
'<div style="text-align:center;padding:58px;">',
'<img id="load" src="$images_path$ico_loading20aa5d9.gif">',
'<span id="err" style="display:none;">$model$\u6A21\u5757\u52A0\u8F7D\u5931\u8D25</span>',
'</div>'
]
).replace(extend(ay,{images_path:getPath("image")})),
onclose:function()
{
cG=null;
}
}
);
if(ay.js)
{
var _oFiles=[];
E(typeof ay.js=="string"?[ay.js]:ay.js,function(iO)
{
_oFiles.push(iO);
}
);
loadJsFileToTop(_oFiles);
}
waitFor(
function()
{
return callBack(ay.oncheck);
},
function(aV)
{

if(!cG)
{
return;
}
if(!aV)
{
show(cG.S("load"),false);
show(cG.S("err"),true);
}
else
{
cG.close(true);
callBack(ay.onload);
}
}
)
}
else
{
callBack(ay.onload);
}
}





















(function()
{
var _oTop=getTop();

function bNa(aAb,afm)
{
var aAb="weixinCss";

if(!_oTop.S(aAb))
{
var NJ=_oTop.document.createElement("style");
NJ.type="text/css";
NJ.id=aAb;
if(_oTop.gbIsIE)
{
NJ.styleSheet.cssText=afm;
}
else
{
NJ.innerHTML=afm;
}
_oTop.document.getElementsByTagName("head")[0].appendChild(NJ);
}
}

var bNC=TE([
'<div id="mask" class="editor_mask opa50Mask editor_maskAtt" ></div>',
'<div id="out" style="z-index:1000;position: absolute;width:$width$%;height:$height$%;margin-top:$offsetTop$%;margin-left:$offsetLeft$%;outline:0;" tabindex="-1" hidefocus="hidefocus">',
'<a id="close" href="javascript:;" title="\u5173\u95ED" style="$@$if($noclose$)$@$display:none$@$endif$@$;position:absolute;right:0;top:16px;width:23px;height:23px;margin:-24px -9px 0 0;background:url($images_path$newicon/login087169.png) no-repeat 0 0;"></a>',
'<div id="body" style="width:100%;height:100%">$html$</div>',
'</div>'
]);


function maskPanel(ar)
{
bNa(ar.sId,ar.sCssRule);

new QMPanel(
{
oEmbedWin:_oTop,
sStyle:"position:absolute;width:100%; height:100%; left:0; top:0; margin-top:-2px",
nWidth:"auto",
nHeight:"auto",
sId:"weixinnote",
sBodyHtml:bNC.replace(
{
noclose:ar.bNoCloseBtn,
html:ar.sBodyHtml,
images_path:getPath("image"),
offsetTop:(100-ar.nHeightPercent)/2,
offsetLeft:(100-ar.nWidthPercent)/2,
width:ar.nWidthPercent,
height:ar.nHeightPercent
}),
onclose:ar.onclose,
onload:function()
{
var VQ=this;
VQ.S("mask").onclick=VQ.S("close").onclick=function()
{
VQ.close();
}
ar.onload&&callBack.call(VQ,ar.onload,[VQ]);
}
}
);
}
window.maskPanel=maskPanel;
})();




function getQMPluginInfo(bTN)
{
var b=
(gbIsWin&&
(

(gbIsFF&&gsFFVer.split(".")[0]<11&&gsFFVer.split(".")[0]>=3&&(gsFFVer.split(".")[1]>0||gsFFVer.split(".")[2]>=8||parseInt(navigator.buildID.substr(0,8))>=20090701))
||(gbIsChrome&&(""+gsChromeVer).split('.')[0]>=6)
||(gbIsSafari&&gsAgent.indexOf("se 2.x metasr 1.0")<0)
||(gbIsOpera)
||(gbIsQBWebKit&&parseFloat(gsQBVer)>6.5)
)
)
||(gbIsMac&&gsMacVer>=bTN&&
(
gbIsFF&&parseFloat(gsFFVer)>=3.6
||gbIsChrome&&parseFloat(gsChromeVer)>=8
||gbIsSafari&&parseFloat(gsSafariVer)>=5
)
);
return b;
}




var QMAXInfo=
{
aPT:
{
path:"/activex/",
cab:"TencentMailActiveX.cab",
exe:"TencentMailActiveXInstall.exe",
obj:[
["TXGYMailActiveX.ScreenCapture","TXGYMailActiveX.UploadFilePartition",
"TXGYMailActiveX.Uploader","TXFTNActiveX.FTNUpload","TXGYMailActiveX.DropFile"],
["FMO.ScreenCapture","TXGYUploader.UploadFilePartition","FMO.Uploader",
"TXFTNActiveX.FTNUpload",""]],
available:["ScreenCapture","Uploader","FTNUpload","DropFile","UploadFilePartition"],
lastVer:["1.0.1.33","1.0.1.29","1.0.1.33","1.0.0.18","1.0.0.8"],
miniVer:[(getDomain()=="foxmail.com")?"1.0.0.5":"1.0.0.28",
"1.0.1.28","1.0.1.28","1.0.0.11","1.0.0.7"]
},

aHa:
{
path:"/xpi/",
xpi:"TencentMailPlugin.xpi",

obj:["ScreenCapture","","Uploader","FTNUpload",""],
available:["ScreenCapture","Uploader","FTNUpload"],
name:["QQMail Plugin","","QQMail Plugin","Tencent FTN plug-in","QQMail Plugin"],




type:(function()
{
var JF="application/txftn",
aXH="application/txftn-webkit";
return["application/x-tencent-qmail","","application/x-tencent-qmail",
(typeof navigator.mimeTypes!="undefined")&&navigator.mimeTypes[aXH]?aXH:JF,
"application/x-tencent-qmail"];
})(),
lastVer:["1.0.1.33","","1.0.1.33","1.0.0.3","1.0.0.0"],
miniVer:["1.0.0.28","","1.0.1.28","1.0.0.1","1.0.0.0"]
},

aFu:
{
path:"/crx/",
crx:"TencentMailPlugin.crx",
exe:"QQMailWebKitPlugin.exe",
obj:["ScreenCapture","","Uploader","FTNUpload",""],
available:["ScreenCapture","FTNUpload"],
name:["QQMail Plugin","","QQMail Plugin","Tencent FTN plug-in",""],
type:["application/x-tencent-qmail-webkit","","application/x-tencent-qmail-webkit","application/txftn-webkit",""],
lastVer:["1.0.1.33","","1.0.1.33","1.0.0.3",""],
miniVer:["1.0.0.28","","1.0.1.28","1.0.0.1",""]
},

aSu:
{
path:"/crx/",
pkg:"TencentMailPluginForMac.pkg",
obj:["ScreenCapture","","Uploader","",""],
available:["ScreenCapture","Uploader"],
name:["QQMailPlugin","","QQMailPlugin","Tencent FTN Plug-in",""],
type:["application/x-tencent-qmail-webkit","","application/x-tencent-qmail-webkit","application/txftn",""],
lastVer:["1.0.1.32","","1.0.1.32","",""],
miniVer:["1.0.0.28","","1.0.1.28","",""]
},







mbAblePlugin:getQMPluginInfo(10.6),



mbAbleUsePlugin:getQMPluginInfo(10.6),




bXM:true,

getTitle:function()
{
return gbIsIE?"\u63A7\u4EF6":"\u63D2\u4EF6";
},




getinfo:function()
{
if(QMAXInfo.mbAblePlugin)
{
if(gbIsWin)
{
if(gbIsIE)
{
return QMAXInfo.aPT.available;
}
if(gbIsFF)
{
return QMAXInfo.aHa.available;
}
if(gbIsChrome||gbIsSafari||gbIsOpera||gbIsQBWebKit)
{
return QMAXInfo.aFu.available;
}
}
if(gbIsMac)
{
return QMAXInfo.aSu.available;
}
}

return[];
},




bWE:function()
{








},










installer:function(aw,rW)
{
var _oInfo=this.get("whole"),
gL="";
if(/^online/.test(aw))
{
gL=_oInfo.cab||_oInfo.xpi||(gbIsChrome&&_oInfo.crx);
}
else if(/^download/.test(aw))
{
if(rW)
{
if(rW=='chrome')
{
_oInfo=this.get("whole",'WebKit');
}
else
{
_oInfo=this.get("whole",rW);
}
}
if(rW)
{
gL=_oInfo.exe||_oInfo.pkg;
}
else
{
gL=(!gbIsChrome&&_oInfo.exe)||_oInfo.pkg;
}

if(rW=='chrome')
{
gL=_oInfo.crx;
}
}
if(gL&&/Abs$/.test(aw))
{
gL=_oInfo.path+gL;
}
return gL;
},







get:function(asj,OH)
{
if(!OH)
{
gbIsIE&&(OH="IE");
gbIsFF&&(OH='FF');
(gbIsChrome||gbIsSafari||gbIsOpera||gbIsQBWebKit)&&(OH="WebKit");
!gbIsIE&&gbIsMac&&(OH="mac");
}

var jd={
IE:this.aPT,
FF:this.aHa,
WebKit:this.aFu,
mac:this.aSu
}[OH];

if(!this.bXM)
{
this.bWE();
}

return asj=="whole"?jd:jd[asj];
}
};






function createActiveX(zK,aq)
{
if(!gbIsIE)
{
return createPlugin(zK,false,aq);
}

if(zK>=0&&zK<=4)
{
var oe=QMAXInfo.get("obj"),
mN;
for(var i=0,len=oe.length;i<len;i++)
{
try
{
if(mN=new ActiveXObject(oe[i][zK]))
{
return mN;
}
}
catch(aZ)
{
}
}
}
return null;
}








function detectActiveX(zK,ES,ayI)
{
if(!gbIsIE)
{
return detectPlugin(zK,ES,ayI);
}

var Nz=typeof(ayI)=="undefined",
xV=false,
ty=Nz?createActiveX(zK)
:ayI,
gE=getActiveXVer(ty);




if(ty&&gE)
{

if(ES!=1&&ES!=2)
{
xV=true;
}
else if(parseInt(gE.split(".").join(""))
>=parseInt(QMAXInfo.get(ES==1
?"miniVer"
:"lastVer")[zK].split(".").join("")))
{
xV=true;
}

if(Nz)
{
delete ty;
ty=null;
}
}
return xV;
}






function getActiveXVer(bD)
{
if(!gbIsIE)
{
return getPluginVer(bD);
}

var gE="",
ty;
try
{
ty=typeof(bD)=="number"?createActiveX(bD):bD;
gE=ty&&(ty.version
?ty.version
:"1.0.0.8")||"";
}
catch(aZ)
{
}

return gE;
}






function checkInstallPlugin(nR)
{

if(!QMAXInfo.mbAbleUsePlugin)
{
return false;
}

var aP=QMAXInfo.get("name")[nR],
aX=QMAXInfo.get("type")[nR],
xd=navigator.plugins;
if(xd&&aP)
{
for(var i=xd.length-1;i>=0;i--)
{
for(var j=xd[i].length-1;j>=0;j--)
{
if(xd[i].name.indexOf(aP)!=-1&&xd[i][j].type==aX)
{

if(nR!=3&&(gsAgent.indexOf("vista")>-1||/nt 6/gi.test(gsAgent))&&aX=="application/x-tencent-qmail")
{
var bAY=xd[i].description.split('#')[1];
if(!bAY)
{

continue;
}
}
return true;
}
}


}
}
return false;
}









function createPlugin(nR,bAc,aq)
{
var je=null;
aq=aq||getMainWin();
switch(nR)
{
case 0:
case 2:
case 4:
if(gbIsSafari)
{
createPlugin.aQI(nR,aq);
}
je=createPlugin.aQI(nR,getTop());
break;
case 3:
je=createFTNPlugin(aq);
break;
}


if(!bAc&&checkInstallPlugin(nR))
{

getTop().ossLog("delay","all",
T([
'stat=ff_addon',
'&type=%type%&info=%info%'
],'%').replace({
type:!je?"failcreatePlugin":"successcreatePlugin",
info:["ver:",gsFFVer,",pluginId:",nR,",brtpe:",(gbIsFF?1:(gbIsChrome?2:(gbIsSafari?3:(gbIsOpera?4:5))))].join("")
})
);
}
return je;
}

createPlugin.aQI=function(nR,aq)
{
var mG,
je=null,
auD=gbIsFF?"application/x-tencent-qmail":"application/x-tencent-qmail-webkit";
aq=aq||getTop();
if(checkInstallPlugin(nR))
{
var Zi="QQMailFFPluginIns";
if(!(mG=S(Zi,aq)))
{
insertHTML(

aq.document.body,
"beforeEnd",
T('<embed id="$id$" type="$type$" hidden="true"></embed>').replace({

type:auD,
id:Zi
})
);
mG=S(Zi,aq);
}

var adI={0:"CreateScreenCapture",
2:"CreateUploader",
4:"CreateDragDropManager"
}[nR];
if(typeof mG[adI]!="undefined")
{
je=mG[adI]();



if(nR==0)
{
je.OnCaptureFinished=function(){};
}
else if(nR==2)
{
je.OnEvent=function(){};
}
}
}
return je;
};

createPlugin.aQE=function(aq,LO)
{
var mG=null,


auD=QMAXInfo.get("whole")["type"][3],
axY=LO||"npftnPlugin";
aq=aq||getTop();
if(!(mG=S(axY,aq)))
{
insertHTML(
aq.document.body,
"beforeEnd",
T('<embed id="$id$" type="$type$" style="z-index:99999;position:absolute;top:0;left:0;width:1px;height:1px;"></embed>').replace({

type:auD,
id:axY
})
);
mG=S(axY,aq);
if(mG)
{
mG.onEvent=function(){};
}
}
return mG;
};







function createFTNPlugin(aq,LO)
{
if(!checkInstallPlugin(3))
{
return null;
}
createPlugin.aQE(aq,LO);
var mG=createPlugin.aQE(getTop(),LO);
















if(LO)
{

getTop().ossLog("delay","all",T([
'stat=ff_addon',
'&type=%type%&info=%info%'
],'%').replace({
type:mG&&mG.Version?"successcreatePlugin":"failcreatePlugin",
info:["ver:",gsFFVer,",pluginId:3,insId:",LO].join("")
}));
}

return mG.Version?mG:null;
}






function detectPlugin(nR,ES,bSO)
{

var xV=false;
var axu=bSO||createPlugin(nR,true),
gE=getPluginVer(axu);

if(axu&&gE)
{
if(ES!=1&&ES!=2)
{
xV=true;
}
else if(parseInt(getPluginVer(axu).split(".").join(""))
>=parseInt(QMAXInfo.get(ES==1?"miniVer":"lastVer")[nR].split(".").join("")))
{
xV=true;
}
}
return xV;
}



function getPluginVer(bD)
{
var ty,gE="";
try
{
ty=typeof(bD)=="number"?createPlugin(bD,true):bD;
gE=(ty&&ty.Version)||"";
}
catch(aZ)
{
}

return gE;
}








































function initDialog(aG,wO,bc,od,kz)
{
new(getTop().QMDialog)({
sid:aG,
sTitle:wO,
sUrl:bc,
nWidth:od,
nHeight:kz
});
}








function requestShowTip(MC,bPT,aq,bG)
{
var aO=T('/cgi-bin/tip?sid=$sid$&args=$dom$,$tip$&r=$r$').replace({
sid:getSid(),
dom:MC,
tip:bPT,
r:Math.random()
});


QMAjax.send(aO,{
method:'GET',
onload:function(aV,bQ,eQ)
{
if(aV&&bQ.indexOf('oTop.QMTip')>0)
{
if(!bG||bG(bQ,eQ))
{
globalEval(bQ,aq);
}
}
}
});
}

function detectCapsLock(uj,brd,ez)
{
if(!uj)
{
return;
}
function showTips(_aoEvent)
{
var aB=_aoEvent.target||_aoEvent.srcElement,
_oPos=calcPos(aB),
cQ=brd||S("capTip");

function getStyle()
{
return["z-index:20;position:absolute;background:#fdf6aa;padding:1px;",
"border:1px solid #dbc492;border-right:1px solid #b49366;border-bottom:1px solid #b49366;",
"left:",_oPos[3],"px;","top:",(_oPos[2]+1),"px;"].join("");
}
if(!cQ)
{
insertHTML((ez||document).body,"afterBegin",
'<div id="capTip" style="'+getStyle()+'">\u5927\u5199\u9501\u5B9A\u5DF2\u6253\u5F00</div>');
}
else
{
cQ.style.cssText=getStyle();
}
}
function hideTips()
{
show(S("capTip",(ez||document)),false);
}
var Ak=-1;
addEvents(uj,{
keydown:function(_aoEvent)
{
var hf=_aoEvent.keyCode||_aoEvent.charCode

if(hf==20)
{
if(Ak==0)
{
showTips(_aoEvent);
Ak=1;
}
else if(Ak==1)
{
hideTips();
Ak=0;
}

}
},
keypress:function(_aoEvent)
{
var hf=_aoEvent.keyCode||_aoEvent.charCode,
uG=_aoEvent.shiftKey;

if((hf>=65&&hf<=90&&!uG)
||(hf>=97&&hf<=122&&uG))
{
Ak=1
showTips(_aoEvent);
}
else if((hf>=97&&hf<=122&&!uG)||(hf>=65&&hf<=90&&uG))
{
Ak=0;
hideTips();
}
else
{
hideTips();
}
},
blur:function()
{
hideTips();
}
});
}








function calcMainFrameDomInGlobalPos(bRP,amg)
{
var _oPos=calcPos(bRP),
bbZ=calcPos(S("mainFrame",getTop())),
aYn=getMainWin().document,
aNe=aYn.documentElement,
aNK=aYn.body,
dz=_oPos[3]+bbZ[3]
-(aNe.scrollLeft||aNK.scrollLeft||0),
bY=_oPos[0]+bbZ[0]
-(aNe.scrollTop||aNK.scrollTop||0),
cy=_oPos[4],
cF=_oPos[5];

return amg=="json"
?{top:bY,bottom:bY+cF,left:dz,
right:dz+cy,width:cy,height:cF}
:[bY,dz+cy,bY+cF,dz,cy,cF];
}

function allDeferOK()
{
return typeof all_defer_js=="function"
}






















function attachSetFlag(bD,acY,bG)
{
bD="&mailattach="+(typeof bD=="string"?bD.split(","):bD).join("&mailattach=");

var _oTop=getTop(),
aO=[bD,"&action=",acY?"setflag":"cancelflag"].join(""),
bcO=acY?"\u6536\u85CF":"\u53D6\u6D88\u6536\u85CF";


QMAjax.send(
"/cgi-bin/attachfolder?t=attachfolder.json",
{
method:"POST",
content:["r=",Math.random(),aO].join(""),
onload:function(aV,bD)
{
if(aV)
{
try
{
var av=eval(bD);
_oTop.showInfo("\u9644\u4EF6\u5DF2"+bcO);
bG&&bG.call(null,av);
}
catch(e)
{
_oTop.showError(bcO+"\u5931\u8D25");
}
}
else
{
_oTop.showError("\u64CD\u4F5C\u5931\u8D25\uFF0C\u8BF7\u7A0D\u540E\u518D\u8BD5");
}
}
}
);
};




















function getAttachList(bD,bG,bR)
{
bR=bR||{};
var nE=arguments.callee,
bk=arguments,
_oList=(typeof bD=="object"&&bD.length)?bD:[],
bic=T("/cgi-bin/readmail?sid=$sid$&t=$t$&s=forward&from=attachfolder&disptype=html&ef=js$param$"),
la=TE([
'$@$for($oAttach$)$@$',
'&mailattach=$mailid$|$attachid$|$attachname$|$fileextenal$|$filebyte$',
'$@$if($editname$)$@$',
'|$editname$',
'$@$endif$@$',
'$@$endfor$@$'
]).replace({
oAttach:_oList
});

QMAjax.send(bic.replace({
sid:getSid(),
t:"compose.json",
param:la
}),
{
method:"GET",
onload:function(aV,cv)
{
var dF=true;
if(aV)
{
try
{
var av=eval(cv),
yq=av.attach;
if(yq&&yq.length)
{
for(var i=0;i<yq.length;i++)
{
if(+yq[i]["byte"]==0)
{
dF=false;
break;
}
}
}
else
{
dF=false;
}
}
catch(e)
{
dF=false;
}
}

if(dF&&aV)
{
bG(true,av);
}
else
{
bG(false,av);
}
}
},
bR.ajax
);




























};




function backHome(bzy)
{
getMainWin().location.href=T('/cgi-bin/today?sid=$sid$&loc=backhome,,,$locid$')
.replace(
{
sid:getSid(),
locid:bzy||140
}
);
}






function resizeFolderList()
{
var asz=S("SysFolderList"),
auQ=S("ScrollFolder"),
hY=S("folder");

if(asz&&auQ&&hY)
{
var atC=["auto","hidden"],
aZw=hY.clientHeight,
aLB=asz.offsetHeight,
IV=aZw-aLB,
axX=IV<50?0:1;
hY.style.overflow=atC[axX];
hY.style.overflowX=atC[1];
auQ.style.overflow=atC[1-axX];
auQ.style.height=axX
?(aZw-aLB)+"px":"auto";
}

setAdFlag();
AdjustAD();
}






function setTopSender(bR)
{
var IT=getGlobalVarValue("DEF_MAIL_FROM")||'';
switch(bR&&bR.action)
{
case"setting4":
if(IT!=bR.email)
{
setUserInfo("addr",bR.email);
setDefaultSender(bR.email);
changeStyle(bR.skin,bR.logo);
getTop().skin_path=bR.skin;
clearCache(["css",getPath("style"),"skin"]);
}

reloadSignature();
break;
}
}




function bindAccount()
{
var afz=S("useraddr"),
azS=S("useraddrArrow"),
zh=getBindAccount(),
Lf={nHeight:10,sItemValue:'<div style="background:#CCC; height:1px; margin-top:5px; overflow:hidden;"></div>'},
bm=[],
aSZ=afz&&subAsiiStr(afz.innerHTML,20,"...");

if(!afz||!zh)
{
return;
}

if(zh.qq.length+zh.biz.length)
{
bm.push(
{
sItemValue:'<a id="manage" href="javascript:;" style="float: right;">\u7BA1\u7406</a><span class="ml">\u5173\u8054\u5E10\u53F7\uFF1A</span>'
},
{
sId:'self',
bDisSelect:true,
sItemValue:T('<div class="unread_num"><span class="ico_unreadnum"></span>$unread$</div><input type="button" class="ft_upload_success" id="self"/><span style="overflow:hidden;margin-left:0" >$myemail$</span>').replace(extend({myemail:subAsiiStr(aSZ,19,"...")},zh.self))
}
);
E(['qq','biz'],function(bK,cU)
{
var bV=zh[bK].length;
if(bV&&cU)
{
bm.push(Lf);
}
for(var bV=zh[bK].length,i=0;i<bV;i++)
{
var av=zh[bK][i],

fd=subAsiiStr(av['email'],19,"...");














bm.push(
{
aX:bK,
sId:av.uin,
sItemValue:['<div class="unread_num"><span class="ico_unreadnum"></span>',av.unread,'</div>','<span style="overflow:hidden;">',fd,'</span>'].join('')
}
);
}
}
);
}
else
{

bm.push(
{
sItemValue:'<span>\u60A8\u7684\u5F53\u524D\u90AE\u7BB1\u5E10\u53F7\uFF1A</span>'
},
{
sItemValue:T('<strong class="ml black">$myemail$</strong>').replace({myemail:aSZ})
},
Lf,
{
sItemValue:'<span>\u62E5\u6709\u5907\u7528\u90AE\u7BB1\uFF0C\u6765\u9002\u7528\u4E8E\u4E0D\u540C\u7528\u9014\u3002</span>'
},
{
sItemValue:'<span>\u5B83\u4EEC\u53EF\u4EE5\u5173\u8054\u5728\u4E00\u8D77\uFF0C</span>'
},
{
sItemValue:'<span>\u65B9\u4FBF\u968F\u610F\u5207\u6362\u4E0D\u540C\u7684\u90AE\u7BB1\u3002</span>'
},
{
nHeight:35,
sItemValue:'<input id="bind" type="button" class="btn ml"value="\u7533\u8BF7\u5907\u7528\u90AE\u7BB1" style="margin-top:5px;padding:0 10px;overflow:visible;"/>&nbsp; <a href="/cgi-bin/readtemplate?sid=$sid$&t=attrpwd_sec" target="mainFrame" id="bind_a">\u5173\u8054\u5DF2\u6709\u90AE\u7BB1</a>'
}
);
}
if(azS)
{
azS.style.visibility="visible";
azS.parentNode.onclick=function()
{
var qQ=calcPos(afz.parentNode);
new QMMenu(
{
sId:"bindaccount",
sClassName:"bindacc qmpanel_shadow",

nX:qQ[3],
nY:qQ[2],
nWidth:235,
nMinWidth:160,
nItemHeight:25,
oItems:bm,
onitemclick:function(aG,bt)
{
if(bt.aX=='biz')
{
submitSwitchForm();
}
else
{
goUrlTopWin(T('/cgi-bin/login?vt=relate&uin=$uin$&old_sid=$sid$').replace({
uin:aG,
sid:getSid()
})
);
}
},
onload:function()
{
var ae=this,
aSr=ae.S("self"),
di;
if(aSr)
{
di=aSr.parentNode;
setClass(di,di.className+' settingtable');
}

addEvent(ae.S("manage"),'click',function(_aoEvent)
{

goUrlMainFrm(
T("/cgi-bin/setting4?fun=list&acc=1&sid=$sid$&go=bind").replace({sid:getSid()})
);
ae.close();
preventDefault(_aoEvent);
}
);

addEvent(ae.S("bind"),'click',function(_aoEvent)
{

goUrlMainFrm(
T("/cgi-bin/readtemplate?sid=$sid$&t=attrpwd_sec_alone&s=regemail&by=beiyong").replace({sid:getSid()})
);
ae.close();
preventDefault(_aoEvent);
}
);

addEvent(ae.S("bind_a"),'click',function(_aoEvent)
{

goUrlMainFrm(
T("/cgi-bin/readtemplate?sid=$sid$&t=attrpwd_sec").replace({sid:getSid()})
);
ae.close();
preventDefault(_aoEvent);
}
);

}
}
);
};
}
}

bindAccount.dTQ=function()
{
var ae=arguments.callee;
if(ae.uT)
{
}

};




function initAddress(bG)
{
callBack.call(window,bG,[{sType:"loading",sMsg:""}]);

var _oTop=getTop(),
KU=_oTop.document,
bGM=getPath("js"),
eW=0,
wZ=function()
{
if(++eW>=2)
{
_oTop.QMAddress.initAddress(bG);
}
};

loadJsFile("$js_path$qmlinkman0bdf91.js",true,KU,wZ);
loadJsFile("$js_path$qmaddress0bdf91.js",true,KU,wZ);






























}




function getPhotoCGI()
{
return[location.protocol,"//",location.host,"/cgi-bin/upload?sid=",getTop().getSid()]
.join("");
}





function baR()
{
var nE=arguments.callee;
return(nE.ZC||(nE.ZC=
{"sid":1,"username":1,"foxacc":1,

"m3gmsid":1,"mcookie":1,"msid":1,"defaultf":1,
"qm_flag":1,"QFRIENDUNREADCNT":1,"RSSUNREADCNT":1,"rss_domain":1,"qqmail_activated":1,"qqmail_alias_default":1,
"qqmail_from":1,"wimrefreshrun":1,"new":1,"qm_sk":1,"qm_ssum":1,"qq2self_sid":1,"exstype":1,"lockurl":1,"new_mail_num":1})
);
}

function setUserCookie(aK,bK,oP,eA,mc,rO)
{







if(baR()[aK]==1)
{
var qR=getCookie(aK),
ei=qR?qR.split("|"):[],
dw=getUin(),
bM=dw+"&"+bK,
dF=true;


for(var i=0;i<ei.length;i++)
{
if(ei[i].match(dw))
{
ei[i]=bM;
dF=false;
}
}

qR=ei.join("|");
dF&&(qR+=(qR==""?"":"|")+bM);
return setCookie(aK,qR,oP,eA,mc,rO);
}
else
return setCookie(aK,bK,oP,eA,mc,rO);

}





function getUserCookie(aK)
{




var hG=getCookie(aK);

if(baR()[aK]!=1)
{
return hG;
}
else
{
var ei=hG?hG.split("|"):[],
dw=getUin();

for(var i=0;i<ei.length;i++)
{
if(ei[i].match(dw))
{
return((ei[i].split("&"))[1]||ei[i]);
}
}
return hG;
}

}




function deleteUserCookie(aK,eA,mc)
{
deleteCookie(aK,eA,mc);
}





function setUserCookieFlag(aK,cU,yT,atp)
{
return setCookieFlag(aK,cU,yT,atp)
}





function getUserCookieFlag(aK)
{
return getCookieFlag(aK);
}








function getReaderData(bc)
{
if(window!=getTop())
{
getTop().getReaderData(bc);
}
else
{
var vz=arguments.callee;
removeSelf(vz.jsObj);
vz.jsObj=loadJsFile(bc+"&r="+Math.random(),false,document);
}
}






function getReaderDataInterval(bc,DN)
{
if(window!=getTop())
{
return getTop().getReaderDataInterval(bc,DN);
}
else
{
var vz=arguments.callee,
aO=(window.gsRssDomain||'')+"/cgi-bin/reader_data2?sid="+getSid()+"&t=rss_data.js";

if(vz.nTimer)
{
clearInterval(vz.nTimer);
}

function Nu()
{
getReaderData(aO);
}

vz.nTimer=setInterval(Nu,DN
||(window.gnRssInterval*1000)||(10*60*1000));
Nu();
}
}


function changeStatus(aKO)
{
var bco=S("searchIcon");
bco&&setClass(bco,aKO?"ss_icon ss_fronticon ss_icon_loading":"ss_icon ss_fronticon ss_icon_search")
}





function doSearch()
{
QMPageInit.bai(
function()
{
var fb=S("frmSearch");
fb.sender.value=fb.subject.value;
fb.receiver.value=fb.subject.value;
fb.keyword.value=fb.subject.value;
fb.combinetype.value="or";
submitToActionFrm(fb);
}
);
return false;
}





function audioPlay(ag)
{
var _oTop=getTop();
if(!ag.container)
{
ag.container=S('mp3player_container',_oTop.getMainWin());
}
if(ag.global&&!ag.globalcontainer)
{
ag.globalcontainer=S('gplayer_container',_oTop);
if(!ag.globalcontainer)
{
ag.global=false;
}
}

if(!_oTop.QMPlayer)
{

loadJsFileToTop(["$js_path$qmplayer/player0bdf91.js"]);
}
waitFor(
function()
{
return!!_oTop.QMPlayer;
},
function(aV)
{
if(aV)
{



var Yk="gplayer_kernel",
aOz="qmplayer_unique";

function aSv()
{
var aT=Yk+"_dom";
if(_oTop.S(aT))
{
return _oTop.S(aT)
}
else
{
var _oDom=_oTop.document.createElement("div");
_oDom.id=aT;
_oDom.style.cssText="position:absolute;left:-100000px;";
_oTop.document.body.appendChild(_oDom);
return _oDom;
}
};

if(!ag.msg)
{
ag.msg="QQ\u90AE\u7BB1\u64AD\u653E\u5668";
}
if(ag.container&&ag.container.getElementsByTagName("div").length==0)
{
ag.container.innerHTML="";
}

if(ag.global)
{
var agG=QMPlayer.initKernel({
sId:Yk,
oContainer:aSv()
}),
aNP=QMPlayer.initSkin({
sId:Yk,
sSkin:"Global",




oContainer:ag.globalcontainer
});

_oTop.QMPlayer.init({
oSkin:aNP,
oKernel:agG
});
}

_oTop.QMPlayer.init({
oSkin:QMPlayer.initSkin({
sId:ag.id||aOz,
oContainer:ag.container,
sSkin:ag.skin||"Mini"
}),
oKernel:ag.global?agG.setInfo(ag):QMPlayer.initKernel({
sId:ag.id||aOz,
oContainer:ag.container,
oInfo:ag
})
});
}
else if(ag.container)
{
ag.container.innerHTML="\u64AD\u653E\u5668\u52A0\u8F7D\u5931\u8D25";
}
}
);
}




function audioStop()
{
var gN=getTop().QMPlayer;
gN&&gN.stop();
}














function setPlayer(ag)
{
var _oTop=getTop();

function aMw(ag)
{
if(!_oTop.QMPlayer)
{
setTimeout(function()
{
aMw(ag);
},200);
return false;
}

var aT="qqmailMediaPlayer"+(ag.id||""),
aA=ag.win||window;

if(!aA||aA[aT])
{
return false;
}

if(!ag.container
&&!(ag.container=S("mp3player_container",aA)))
{
return false;
}

return(aA[aT]=new _oTop.QMPlayer()).setup(ag);
}

if(!_oTop.QMPlayer)
{

loadJsFile("$js_path$qmplayer0bdf91.js",true,_oTop.document);
}

return aMw(ag);
}













function playUrl(hQ)
{
var gN=(hQ.win||window)["qqmailMediaPlayer"
+(hQ.id||"")];

if(!gN)
{
setPlayer(hQ);
}
else
{
gN.openUrl(hQ.url,hQ.dispInfo);
}
}









function stopUrl(hQ)
{
if(!hQ)
{
hQ={};
}

try
{
(hQ.win||window)["qqmailMediaPlayer"+(hQ.id||"")].stop();
}
catch(aZ)
{
}
}











function searchMusic(jJ,ka,bv)
{
if(window!=getTop())
{
return getTop().searchMusic(jJ,ka,bv);
}
jJ=jJ||"";
ka=ka||"";
var Jj=arguments.callee,
ayB=[jJ,ka].join("@");

Jj.fCallBack=function(mA)
{
var _oList,
aO="",
aht=[];
if(!mA.contentWindow.gMusicInfo||!(_oList=mA.contentWindow.gMusicInfo.list))
{
return bv(aht);
}

for(var i=0,_nLen=_oList.length;i<_nLen;i++)
{
var _oInfo={
song:_oList[i].songname.replace(/<\/?strong>/gi,""),
singer:_oList[i].singername.replace(/<\/?strong>/gi,"")
},
ahR=htmlDecode(_oList[i].songurl).replace(/\|/g,"").split(";");


for(var j=0,anw=ahR.length;j<anw;j+=2)
{



if(ahR[j]
&&ahR[j].indexOf("qqmusic.qq.com")==-1)
{
_oInfo.url=ahR[j].replace(/^(FI|SI|AN|QQ)/,"");
aht.push(_oInfo);
break;
}
}
}
Jj.Ht[ayB]=aht;
bv(aht);
};

if(!jJ&&!ka)
{
return bv([]);
}
if(!Jj.Ht)
{
Jj.Ht={};
}
if(Jj.Ht[ayB])
{
return bv(Jj.Ht[ayB]);
}

Jj.dTi=createBlankIframe(getTop(),{
id:"getMusicUrlFromSoSo",
style:"display:none;",
header:T(
[
'<script>',
'function searchJsonCallback(a)',
'{',
'window.gMusicInfo = a;',
'}',
'<\/script>',
'<script src="$domain$/fcgi-bin/fcg_search_xmldata.q?w=$song$%20$singer$&source=3&r=$rand$"><\/script>',
]
).replace(
{
domain:(location.protocol=="https:"?'https://ptlogin2.mail.qq.com':'http://cgi.music.soso.com'),
song:encodeURI(jJ),
singer:encodeURI(ka),
rand:Math.random()
}
),
destroy:true,
onload:function(aq)
{
searchMusic.fCallBack(this);
}
});
}








function getMusicUrl(jJ,ka,bv)
{
searchMusic(jJ,ka,function(xz)
{
if(xz.length>0)
{
var j=0,
Yj=/\.mp3$/i;
for(var i=0;(gbIsMac||gbIsLinux)&&i<xz.length;i++)
{
if(Yj.test(xz[i].url))
{
j=i;
break;
}
}
debug(xz[j].url);
bv(xz[j].song,xz[j].singer,xz[j].url,xz);
}
else
{
bv(jJ,ka,"",xz);
}
},1);
}









function startWebpush(Bo)
{
var _oTop=getTop();

_oTop.loadCssFile("$css_path$webpushtip0bdf8c.css",true);

_oTop.loadJsFile("$js_path$qmwebpushtip0bdf8c.js",
true,
_oTop.document,
function()
{
_oTop.QMWebpushTip.open(Bo);
}
);

_oTop.loadJsFile("$js_path$qmwebpush0bdf91.js",true,_oTop.document);
}







function closeWebpush(Bo)
{
getTop().QMWebpushTip&&getTop().QMWebpushTip.close(Bo,true);
}








function ftSendStatic(hu,dH)
{
if(hu)
{
ossLog("realtime","all",T('stat=exskick&sid=$sid$&uin=$uin$&log=$code$')
.replace(
{
uin:dH||getTop().g_uin,
sid:getSid(),
code:hu
}
));
}
}









function beginStatTime(aq)
{
var VV=parseInt(aq.location.hash.split("stattime=").pop());

if(!isNaN(VV)&&VV.toString().length==13&&VV>(getTop().gnStatTimeStamp||0))
{
aq.gnBeginTime=getTop().gnStatTimeStamp=VV;
aq.gnStatTimeStart=now();
}
}

















function endStatTime(aq,dg)
{
var wF=aq.gnBeginTime,
eB=aq.gnStatTimeStart,
gk=now();

if(!isNaN(eB)&&!isNaN(wF))
{
addEvent(aq,"load",function()
{
var awt=now();

ossLog("delay","sample",T(
[
'stat=cgipagespeed&type=$type$&t1=$t1$&t2=$t2$&t3=$t3$',
'&rcgi=$appname$&rt=$t$&rs=$s$&allt=$allt$&flowid=$wm_flowid$'
]
).replace(extend(dg,
{
t1:eB-wF,
t2:gk-eB,
t3:awt-gk,
allt:[wF,eB,gk,awt].join("|")
}
)));
debug([eB-wF,gk-eB,awt-gk],994919736);
}
);
}
}
















function ossLog()
{
var aUH=getTop().ossLog;
return aUH.aGT.apply(aUH,arguments);
}

ossLog.aGT=function(agr,Cs,rP,aIK)
{
var ae=this,
aiz=agr||"realtime",
LI=ae.aiP(rP),
lT=ae.lT||(ae.lT=[]),
gg=typeof Cs=="number"?Cs:{all:1}[Cs||"all"]||0.1;

if(aiz=="realtime")
{
ae.MT(gg)&&ae.azB(LI);
}

else
{

ae.MT(gg)
&&lT.push(["delayurl","=",encodeURIComponent(LI)].join(""));

lT.length>=1000?ae.azB()

:(!ae.dS&&lT.length>0&&(ae.dS=setTimeout(ae.azB,5*1000)));
}
};

ossLog.azB=function(HP)
{
var ae=ossLog,
lT=ae.lT;
if(HP||lT.length>0)
{
QMAjax.send("/cgi-bin/getinvestigate",
{
method:"POST",
timeout:500,
content:T('sid=$sid$&$rl$&$ls$').replace(
{
sid:getSid(),
rl:HP,
ls:lT.join("&")
}
)
}
);
lT.length=0;
ae.dS&&clearTimeout(ae.dS);
ae.dS=null;
}
};

ossLog.MT=function(pI)
{
return(this.CO||(this.CO=now()))%100<100*pI;
};

ossLog.aiP=function(rP)
{
var jd=[];
typeof rP=="string"
?jd.push("&",rP)
:E(rP,function(mJ,bA)
{
jd.push("&",bA,"=",encodeURIComponent(mJ));
}
);
return jd.shift()&&jd.join("");
};










function isdLog(bKD,bA,mJ)
{
var pB=T([
window.location.protocol,
"//isdspeed.qq.com/cgi-bin/r.cgi?flag1=6000&flag2=101&flag3=$flag$&$key$=$value$&r=$r$"
]),
eu=new Image();

setTimeout(function()
{
eu.src=pB.replace({
flag:bKD,
key:bA,
value:mJ||"1",
r:Math.random()
});
}
);
}



function postADlog(dhD,eF,bc,_aoEvent)
{
if(dhD=="flash")
{
var er=getEventTarget(_aoEvent);
if(er.tagName=="DIV")
{
ossLog("realtime","all",T('stat=log_ad_click&pos=$pos$')
.replace(
{
pos:eF
}
));
bc&&window.open(bc);
}
}
else
{
ossLog("realtime","all",T('stat=log_ad_click&pos=$pos$')
.replace(
{
pos:eF
}
));
}
}

function setAdFlag()
{
setCookieFlag("CCSHOW",5,getTop().document.body.clientWidth<1152?0:1);
}
function getADFlag()
{
return getCookieFlag("CCSHOW")[5];
}
function AdjustAD()
{
var cp=getTop().getMainWin(),
YN=S("qqmail_AD_container",cp),
_oContainer=S("qqmail_mailcontainer",cp);
rdVer("BaseVer",1);
if(getADFlag()=="0"&&isShow(YN)&&_oContainer)
{

YN&&(show(YN,0));
_oContainer&&(_oContainer.style.cssText="margin-right : 0px");
}
if(getADFlag()=="1"&&YN&&_oContainer&&!isShow(YN))
{

YN&&(show(YN,1));
_oContainer&&(_oContainer.style.cssText="margin-right : 170px");
initAD(cp,YN);
}

}

function initAD(aq,eh)
{
var fxA=[],bXq=[],anP="",
dIs=
{
qqmail_F_skyscraper:1,
qqmail_list_skyscraper:2,
qqmail_send_skyscraper:3,
qqmail_HY_Width:4,
qqmail_HY_Rectangle:5
},
bVq=location.protocol=="https:",
eaS=(bVq?T("https://stockweb.mail.qq.com?c=www&loc=$loc$&callback=AD_callback&rot=1&pdomain=l.qq.com"):T("http://l.qq.com?c=www&loc=$loc$&callback=AD_callback&rot=1"));
E(GelTags("qqmailad",eh||aq.document),function(_aoDom)
{
anP=attr(_aoDom,"loc")||"";
if(eh)
{
attr(_aoDom,"disp")=="0"&&anP&&bXq.push(anP)&&attr(_aoDom,"disp","1");
}
else
{
attr(_aoDom,"disp")!="0"&&anP&&bXq.push(anP);
}
});
anP=bXq.join(",");
function getHttpsUrl(bc)
{
var Aq=strReplace(bc,"http://",""),
Qk=Aq.indexOf("/"),
_sDomain=Aq.substr(0,Qk),
dtL="https://stockweb.mail.qq.com";
return strReplace(bc,"http://"+_sDomain,dtL)+"?pdomain="+_sDomain;

}
aq["AD_callback"]=function(ar)
{
function dLY(aj,lk,bG)
{
var 
bDG=(bVq?"https://stockweb.mail.qq.com/p?oid=%oid%&cid=%cid%&loc=%loc%&pdomain=p.l.qq.com":"http://p.l.qq.com/p?oid=%oid%&cid=%cid%&loc=%loc%"),
_oDom=getADDomByloc(lk);




if(_oDom&&aj.resource_url)
{
bVq&&(aj.resource_url=getHttpsUrl(aj.resource_url));
if(aj.resource_url.indexOf(".swf")!=-1)
{
var bRL=T([
"<div style=\"position:absolute; cursor:pointer; background:#FFF; filter:alpha(opacity=0); opacity:0; width:%width%px; height:%height%px; \" onclick=\"getTop().postADlog('flash','%pos%','%link_to%',event)\">&nbsp;",
"</div>",
"<style>",
".ad_btn_close{position:absolute; top:5px; right:5px; line-height:0; text-decoration:none; background:#aaa; width:12px; height:12px;  border:1px solid #999;}",
".ad_btn_close:hover{border-color:#888;background-color:#999;}",
"</style>",
"<div style=\"position:absolute; width:%width%px; height:1px;background:url(",bDG,"); \">",
(lk=="qqmail_list_skyscraper"||lk=="qqmail_F_skyscraper")?"<a class=\"ad_btn_close\" onclick=\"closeAD('%pos%')\"><img src=\"%img_path%ico_closetip.gif\"></a>":"",
"</div>",
"<object ",
gbIsIE?" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\"":"",
"style=\"outline-style: none; outline-color: invert; outline-width: medium; width: %width%px; height: %height%px\"",
" data=\"%resource_url%\"",
">",
"<param name=\"Movie\" value=\"%resource_url%\">",
"<param name=\"wmode\" value=\"transparent\">",
"</object>"],"%");
}
else
{
if(lk=="qqmail_HY_Width")
{
var bRL=T(["<span style=\"background:url(",bDG,");\"></span><a href=\"%link_to%\" target=\"_blank\"  onclick=\"getTop().postADlog('img','%pos%')\" style=\"white-space: nowrap; height:80px; overflow: hidden; display: block; margin-bottom:3px; background:url(%resource_url%) no-repeat;\"></a>"],"%");
}
else
{
var bRL=T(["<a href=\"%link_to%\" target=\"_blank\" style=\"background:url(",bDG,");\" onclick=\"getTop().postADlog('img','%pos%')\"><img src=\"%resource_url%\" width=\"%width%\" height=\"%height%\"></a>",
"<style>",
".ad_btn_close{position:absolute; top:5px; right:5px; line-height:0; text-decoration:none; background:#aaa; width:12px; height:12px;  border:1px solid #999;}",
".ad_btn_close:hover{border-color:#888;background-color:#999;}",
"</style>",
(lk=="qqmail_list_skyscraper"||lk=="qqmail_F_skyscraper")?"<a class=\"ad_btn_close\" onclick=\"closeAD('%pos%')\"><img src=\"%img_path%ico_closetip.gif\"></a>":""],"%");
}

}

var cOE=_oDom.parentNode;

show(cOE,1);
setHTML(cOE,bRL.replace(extend(aj,{img_path:getPath("image"),pos:dIs[lk]})));





}
else
{
debug("no loc dom")
}
}
function getADDomByloc(lk)
{
var eZ=null;
E(GelTags("qqmailad",aq.document),function(_aoDom)
{
dFp=attr(_aoDom,"loc")||"";
if(dFp==lk)
{
eZ=_aoDom;
}
});
return eZ;
}
for(var i=0;i<ar.length;i++)
{
var aN=ar[i]&&ar[i][0];
if(aN)
{
var Hm=aN.loc,
dFn=aN.oid,
cGF=aN.fodder;
if(dFn=="1")
{
debug("no AD publish");
if(Hm=="qqmail_HY_Width")
{
var _oDom=getADDomByloc(Hm),cjo=S("todaybarNormal",aq);
if(_oDom&&_oDom.parentNode)
{
debug("show 0")
show(_oDom.parentNode,0);
}
cjo&&show(cjo,1);
}
}
else if(cGF[0]&&Hm)
{

dLY(extend(cGF[0],{cid:aN.cid,loc:aN.loc,oid:aN.oid}),Hm)
}
else
{
debug("No AD loc or DATA")
}
}
else
{
debug("no AD")
}
}
};
aq["closeAD"]=function(eF)
{
var YN=S("qqmail_AD_container",aq),
_oContainer=S("qqmail_mailcontainer",aq);

QMAjax.send(
"/cgi-bin/setuserflag",
{
method:"POST",
content:"fun=close_ad&pos="+eF
}
);
YN&&removeSelf(YN);
_oContainer&&(_oContainer.style.cssText="margin-right : 0px");
rdVer("BaseVer",1);
}

anP&&loadJsFile(eaS.replace({loc:anP}),false,aq.document);
}





function all_js(){}