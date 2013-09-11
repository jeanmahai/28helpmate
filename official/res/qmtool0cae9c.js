
var drx=new Date().getTime(),
fS,hz;


















var qmAnimation=function(wq)
{
this.aOK=null;
this.asF=[];
this.dzw={};
this.arS(wq,true);
};

hz=qmAnimation;
fS=hz.prototype;








fS.play=function(wq)
{
if(typeof wq=="function")
{
if(this.aOK)
{
this.asF.push(wq);
}
else
{
this.yg(wq(),true);
}
}
else
{
this.stop();
this.yg(wq);
}
};

fS.stop=function()
{
var cA=this;
var dvv=this.asF;
this.asF=[];

this.Qh();

E(dvv,function(dUf)
{
var bhr=dUf();
if(bhr)
{
cA.arS(bhr);
if(typeof(cA.bcL)=="function")
{
cA.bcL.call(cA,cA.bgM,true);
}
}
}
);
};













fS.updateStyle=function(oQ,aU,beb)
{
var cvz=this.cWQ||(this.cWQ={}),
cm=aU.style;

if(beb)
{
cvz[oQ]=cm.cssText;
for(var i in beb)
{
cm[i]=beb[i];
}
}
else
{
cm.cssText=cvz[oQ];
}
};



fS.ast=function(cJG)
{
var cio=true,
cxD=now();

if(cJG||(cxD>this.cJY))
{
this.bLV.clearInterval(this.aOK);

this.cJY=0;
this.aOK=null;

if(typeof(this.bcL)=="function")
{
this.bcL.call(this,this.dcQ,cJG);
}

if(this.asF.length>0)
{
this.yg(this.asF.shift()(),true);
}

cio=false;
}
else
{
var cwP=cxD-this.cmn;
if(typeof(this.bPK)=="function")
{
this.bPK.call(this,this.cmt(cwP,this.bVQ,this.dOV,this.boW),
cwP/this.boW);
}
}
return cio;
};

fS.yg=function(wq,dGM)
{
if(dGM&&!wq)
{
if(this.asF.length>0)
{
this.yg(this.asF.shift()(),true);
}
return;
}

this.arS(wq);

this.cmn=now();
this.cJY=this.cmn+this.boW;

if(this.ast())
{
var cA=this;
this.aOK=this.bLV.setInterval(function()
{
cA.ast();
},
13
);
}
};

fS.arS=function(wq,dLI)
{
if(wq)
{
var apF=this.dzw;
var RQ=dLI?apF:this;
var cJU=this.constructor;

RQ.bLV=wq.win||apF.bLV||window;

RQ.bVQ=typeof(wq.from)=="number"?wq.from:apF.bVQ;
RQ.bgM=typeof(wq.to)=="number"?wq.to:apF.bgM;
RQ.dcQ=typeof(wq.completeto)=="number"?wq.completeto:RQ.bgM;
RQ.dOV=RQ.bgM-RQ.bVQ;

RQ.boW={fast:200,slow:600}[wq.speed]||wq.speed||apF.boW;

var biH=cJU.cGc[wq.tween]||apF.cmt||cJU.cGc.Linear;
RQ.cmt=typeof(biH)=="function"?biH:(biH[wq.easing]||biH.easeIn);

RQ.bPK=wq.onaction||apF.bPK;
RQ.bcL=wq.oncomplete||apF.bcL;
}
};

fS.Qh=function()
{
if(!this.aOK)
return false;

return this.ast(true);
};





















hz.play=function(ah,ag)
{
var ae=this,
fJ=ae.fO,
aN=fJ.cxc,
aka=now()+Math.random(),
aM=extend({},aN,ag),
aL,aA,bz,lP;

try
{
aL=ah.ownerDocument;
aA=aL.defaultView||aL.parentWindow;
bz=aA[fJ.bmF];
}
catch(aZ)
{
return ah;
}
try
{
var ae=this,
fJ=ae.fO,
aN=fJ.cxc,
aka=now()+Math.random(),
aM=extend({},aN,ag),
aL=ah.ownerDocument,
aA=aL.defaultView||aL.parentWindow,
bz=aA[fJ.bmF],
lP;

}
catch(e)
{
callBack.call(ah,ag.oncomplete,[ag.to,false,false]);
return ah;
}

if(!bz)
{
bz=aA[fJ.bmF]={};
}

function cvu(Kr,aMF)
{
ah.setAttribute(fJ.aRA,Kr+"|"+aMF);
}

function cvQ(Kr)
{
return(ah.getAttribute(fJ.aRA)||"").split("|")[0];
}

function chN(dkS)
{
ah.setAttribute(fJ.bWy,dkS);
}

function cJC()
{
return ah.getAttribute(fJ.bWy)||"";
}

function yg(Kr,acc)
{
var cff=bz[Kr],
aMW=cff[fJ.czU],
RL;

cvu(Kr,aMW.actiontype);

if(typeof aMW.onready=="function")
{
RL=aMW.onready.call(ah,acc);
}


if(acc||RL==false)
{
var gx=RL&&RL.to;
aMW.oncomplete(
typeof gx=="number"?gx:aMW.to,
acc,
RL==false
);
}
else
{

if(RL)
{
RL.onaction=RL.oncomplete=null;
}

cff.play(RL||{});
}
}

aM.onaction=function(bW,ho)
{
ag.onaction.call(ah,bW,ho);
};

aM.oncomplete=function(bW,acc,bRf)
{
cvu("",ag.actiontype);
delete bz[aka];

ag.oncomplete.call(ah,bW,acc,bRf);

var bUA=cJC().split("|"),
bAG=bUA.shift();


if(bAG)
{
chN(bUA.join("|"));

if(bUA.length==0)
{
yg(bAG);
}
else
{
yg(bAG,acc);
}
}
};

aM.win=aA;
lP=bz[aka]=new ae(aM);
lP[fJ.czU]=aM;

if(cvQ())
{
var cxP=cJC();
chN(cxP+(cxP?"|":"")+aka);

if(aM.type!="wait")
{

var ahP=bz[cvQ()];
ahP&&ahP.stop();
}
}
else
{
yg(aka);
}

return ah;
};






hz.stop=function(ah)
{
var ae=this,
fJ=ae.fO,
aL,aA,bz,bQZ;

try
{
aL=ah&&ah.ownerDocument;
aA=aL.defaultView||aL.parentWindow;
bz=aA[fJ.bmF];
bQZ=(ah.getAttribute(fJ.aRA)||"").split("|")[0];

if(bQZ)
{
ah.setAttribute(fJ.bWy,"");
bz[bQZ].stop();
}
}
catch(aZ)
{
}

return ah;
};






hz.isPlaying=function(ah)
{
return!!ah.getAttribute(this.fO.aRA);
};






hz.getActionType=function(ah)
{
return(ah.getAttribute(this.fO.aRA)||"").split("|").pop();
};






















hz.cgI=function(ah,aMF,ag)
{
var qF=gbIsIE?1:0,
aM=ag||{},
qJ=aM.speed,
iC=aM.from,
gx=aM.to,
bii=aM.durlimit||0,
dmm=aM.basespeed||1.8,
dur=aM.unilimit,
ckQ=typeof qJ=="undefined"||qJ=="uniform",
bXR=false;

function bPp()
{
var sZ=arguments,
nc=aM["on"+sZ[0]];
if(typeof nc=="function")
{
return nc.call(sZ[1],sZ[2]);
}
}

function cIt(_aoDom)
{
return _aoDom.scrollHeight-(gbIsIE
?0:parseInt(getStyle(_aoDom,"paddingTop"))
+parseInt(getStyle(_aoDom,"paddingBottom")));
}

return qmAnimation.play(ah,extend({},aM,
{
actiontype:aMF,
speed:ckQ?"fast":qJ,
to:qF,
onready:function(acc)
{
if(!acc)
{
var cm=this.style,
JI,JT,aLZ,PU;

bXR=false;
PU=bPp("ready",this)||{};
aLZ=PU.speed;
JI=typeof PU.from=="number"
?PU.from:iC;
JT=typeof PU.to=="number"
?PU.to:gx;

if(aMF=="expand")
{
if(typeof JI!="number"||isNaN(JI))
{
var cF=parseInt(cm.height);
if(isNaN(cF))
{
JI=cm.height=qF;
}
else
{
JI=cF;
}
}
else
{
cm.height=JI;
}
}
else
{
if(typeof JT!="number"||isNaN(JT)||JT<qF)
{
JT=qF;
}
}
cm.overflow="hidden";
cm.visibility="visible";
if(cm.display=="none")
{
cm.display="";
}


if(gbIsIE)
{
var qE=this.scrollHeight;
}

if(aMF=="expand")
{
if(typeof JT!="number"||isNaN(JT))
{
JT=cIt(this);
bXR=true;
}
}
else
{
if(typeof JI!="number"||isNaN(JI))
{
var cF=parseInt(cm.height);
JI=isNaN(cF)
?cIt(this):cF;
}
}

var gZ=JT-JI,
dFB=JT;
if(bii>0&&Math.abs(gZ)>bii)
{
if(gZ>0)
{
JT=JI+bii;
}
else
{
JI=JT+bii;
}
}

if(!aLZ)
{
if(ckQ)
{
var cDl=Math.abs(JI-JT),
bPm=PU.unilimit||dur;
aLZ=(PU.basespeed||dmm)
*(bPm
?Math.min(Math.max(cDl,bPm[0]),bPm[1])
:cDl);
}
else
{
aLZ=qJ;
}
}

return JT==JI
?false
:{
from:Math.max(JI,qF),
to:Math.max(JT,qF),
completeto:dFB,
speed:aLZ
};
}
},
onaction:function(bW,ho)
{
this.style.height=bW+"px";
bPp("action",this,ho);
},
oncomplete:function(bW,acc,bRf)
{
if(!acc)
{
if(bW==qF)
{
show(this,false);
}


this.style.height=bXR?"auto":(bW+"px");
bPp("complete",this,bW,bRf);
}
}
}
));
};






hz.expand=function(ah,ag)
{
return this.cgI(ah,"expand",ag);
};







hz.fold=function(ah,ag)
{
return this.cgI(ah,"fold",ag);
};

hz.fO={
bmF:"QMaNiMatiON_CachE",
czU:"sTatiC_Play_Conf",
aRA:"QMaNiMatiON_PlaY",
bWy:"QMaNiMatiON_WaiT",
cxc:{
from:1,
to:100,
speed:"fast"
}
};

hz.cGc=
{


Linear:function(t,b,c,d)
{
return c*t/d+b;
},
Sine:
{
easeIn:function(t,b,c,d)
{
return-c*Math.cos(t/d*(Math.PI/2))+c+b;
},
easeOut:function(t,b,c,d)
{
return c*Math.sin(t/d*(Math.PI/2))+b;
},
easeInOut:function(t,b,c,d){
return-c/2*(Math.cos(Math.PI*t/d)-1)+b;
}
},
Cubic:
{
easeIn:function(t,b,c,d)
{
return c*(t/=d)*t*t+b;
},
easeOut:function(t,b,c,d)
{
return c*((t=t/d-1)*t*t+1)+b;
},
easeInOut:function(t,b,c,d)
{
if((t/=d/2)<1)return c/2*t*t*t+b;
return c/2*((t-=2)*t*t+2)+b;
}
},
none:false
};





























var qmTab=function(hB)
{
this.aIU(hB);
this.bnW();
};

hz=qmTab;
fS=hz.prototype;



fS.change=function(Wc)
{
var amR=this.bFj,
lI=this.sI,
alj=lI.bau,
zz=amR[Wc];

if(!zz||!zz.zf)
return false;

if(alj==Wc)
return true;

if(alj)
{
var auL=amR[alj].nC;
var aZr=zz.nC;

setClass(amR[alj].eU,this.aaO.normal);

if(this.anu)
{
this.anu.stop();

function aEi(bW)
{
var jZ=bW/100;
setOpacity(auL,jZ);
setOpacity(aZr,1-jZ);
}

var bLi={
display:"",
position:"absolute",
width:getStyle(auL,"width"),
height:getStyle(auL,"height"),
zIndex:1
};

this.anu.updateStyle("pre",auL,bLi);
this.anu.updateStyle("cur",aZr,(bLi.zIndex=2)&&bLi);

var eWH=[];
var coe=this.HN.dxK;
this.anu.play(
{
onaction:function(sx,elE)
{
aEi(sx);
},
oncomplete:function(sx,bkp)
{
aEi(sx);

this.updateStyle("pre",auL);
this.updateStyle("cur",aZr);

show(auL,false);
show(aZr,true);

if(typeof(coe)=="function")
coe(Wc,alj);

}
}
);
}
else
{
show(auL,false);
show(aZr,true);
}
}
else{
show(zz.nC,true);
}

setClass(zz.eU,this.aaO.select);

lI.bau=Wc;

if(typeof(this.HN.mw)=="function")
this.HN.mw(Wc,alj);

return true;
};

fS.enable=function(Wc,bWU){
var zz=this.bFj[Wc];
if(!zz)
return false;

setClass(zz.eU,this.aaO[
(zz.zf=bWU||typeof(bWU)=="undefined"?true:false)?
"normal":"disable"]);

return true;
};

fS.getSelectedTabId=function(){
return this.sI.bau;
};



fS.aIU=function(hB){
var amR=this.bFj={};
for(var i in hB.tab)
amR[i]={
rg:i,
eU:hB.tab[i].obj,
nC:hB.tab[i].container,
zf:true
};

this.aaO=hB.style;
this.HN={
mw:hB.onchange,
dxK:hB.onchangeend
};
this.sI={
bau:null
};

if(hB.isEnableAnimation!=false)
{
this.anu=new qmAnimation({
win:hB.win,
from:100,
to:0,
speed:400,
tween:"Sine",
easing:"easeOut"
});
}
};

fS.bnW=function(){
var cA=this;
var amR=this.bFj;

for(var i in amR){
(function(){
var kU=amR[i];
show(kU.nC,false);








kU.eU.onclick=function()
{
cA.change(kU.rg);
}
kU.eU.onmouseover=function(kt){
if(kU.zf&&cA.sI.bau!=kU.rg)
setClass(kU.eU,cA.aaO.over);
}






kU.eU.onmouseout=function(kt){
try{
if(kU.zf&&cA.sI.bau!=kU.rg&&
!isObjContainTarget(kU.eU,kt.relatedTarget||kt.toElement))
setClass(kU.eU,cA.aaO.normal);
}
catch(e)
{}
}






})();
}
};









































var qmSimpleThumb=function(hB){
this.aIU(hB);
this.bnW();
};

hz=qmSimpleThumb;
fS=hz.prototype;



fS.enable=function(){
var lI=this.sI;
if(lI.zf==true)
return;

lI.zf=true;
if(lI.zH==-1)
return this.goPage(1);

this.bGY();
};

fS.disable=function(){
var lI=this.sI;
if(lI.zf==false)
return;

lI.zf=false;
this.bGY();
};

fS.getDataLength=function(){
return this.atM.length;
};

fS.getId=function(){
return this.JD;
};

fS.getSelectedData=function(){
var akA=this.sI.akA;

return akA<0?null:this.atM[akA];
};

fS.goPage=function(ape){
var lI=this.sI,
KP=lI.zH;
if(lI.zf&&ape>=1&&ape<=lI.apy){
lI.zH=ape;

this.bGY();
if(this.dsz())
this.cyW();
this.dWc();

callBack.call(this,this.HN.dih,[ape,KP]);


return true;
}
return false;
};

fS.select=function(Pt){
var qN=this.atM,
lI=this.sI;

Pt=parseInt(Pt);

if(Pt<0)
{

}
else if(isNaN(Pt)||((Pt=Pt%qN.length)==lI.akA))
{
this.HN.Oi.call(this,Pt,lI.bjx);
return false;
}

lI.bjx=lI.akA;
lI.akA=Pt;

this.cyW();

if(typeof(this.HN.Oi)=="function")
{
this.HN.Oi.call(this,Pt,lI.bjx);
}

return true;
};

fS.onmouseover=function(ah)
{
if(typeof(this.HN.aLA)=="function")
{
this.HN.aLA.call(this,ah);
}
return true;
},

fS.onmouseout=function(ah)
{
if(typeof(this.HN.aNf)=="function")
{
this.HN.aNf.call(this,ah);
}
return true;
},

fS.setExternInfo=function(vn,dbE)
{
var eI=parseInt(vn),
av=this.atM,
bfB=this.aTq.ayd,
gc=av.length-1;

if(!isNaN(eI)&&eI>=0&&eI<=gc)
{
var aDA=Math.floor((gc-eI)/bfB),
_nIdx=gc-eI-aDA*bfB,
bm=this.abG.aEb[aDA].firstChild.childNodes;

if(_nIdx<0||_nIdx>=bm.length)
{
return;
}

bm[_nIdx].lastChild.innerHTML=dbE;
}
};

fS.update=function(aUs){
this.dFF(aUs);
this.dsF();
this.goPage(this.sI.zH=Math.min(this.sI.zH,this.sI.apy));
};



fS.dzA=function(){
var zq=[];
var ZU=qmSimpleThumb.bN.baN;
var lI=this.sI;
var dQY=this.aaO.thumb.container;

for(var i=0,bV=Math.max(lI.apy,1);i<bV;i++)
zq.push(ZU.replace({border:dQY}));

return qmSimpleThumb.bN.tj.replace({
container:zq.join("")
});
};

fS.bNM=function(aDc,dMp){
return qmSimpleThumb.bN.abz.replace({
images_path:getPath("image"),
msg:aDc,
dispload:dMp?"":"none"
});
};

fS.dPI=function(ape){
var aoP=this.atM;
var azZ=aoP.length;

if(azZ==0)
return this.bNM("\u6682\u65E0\u6570\u636E");

var cxM=this.aTq.ayd;
var ciN=ape*cxM;
var aym=ciN-cxM;
var dYQ=ciN-1;



if(aoP[aym].indexOf)
{
if(aoP[aym].indexOf("loading")==0)
{
return this.bNM(aoP[aym].substr(7)||"\u6570\u636E\u52A0\u8F7D\u4E2D...",true);
}
else if(aoP[aym].indexOf("custom")==0)
{
return this.bNM(aoP[aym].substr(6));
}
}

var zq=[];
var ZU=qmSimpleThumb.bN.bNQ;
var tn=this.aaO.thumb;
var acZ={
img:tn.img,
normal:tn.normal,
over:tn.over,
images_path:this.aTq.djG
};

if(aoP[aym].thumb.indexOf("http")==0)
{

acZ.images_path="";
}

for(var i=aym,bV=Math.min(azZ--,dYQ+1);i<bV;i++){
var czG=azZ-i;
acZ.value=czG;
acZ.url=aoP[czG].thumb;
zq.push(ZU.replace(acZ));
}

return zq.join("");
};

fS.aIU=function(hB){
this.JD=hB.id||T("qmSimpleThumb_$date$").replace({
date:now()
});
this.aTq={
djG:hB.imgpath,
ayd:hB.numperpage||8
};
this.abG=hB.dom;
this.aaO=hB.style;
this.HN={
dih:hB.onchangepage,
Oi:hB.onselect,
aLA:hB.onmouseover,
aNf:hB.onmouseout
};
this.sI={
zH:-1,
apy:0,
akA:-1,
bjx:-1,
zf:null
};

var nC=this.abG.container;
this.anu=new qmAnimation({
win:hB.win,
speed:"slow",
tween:"Cubic",
easing:"easeOut",
onaction:function(sx){
nC.scrollLeft=sx;
},
oncomplete:function(sx,bkp){
if(!bkp)
nC.scrollLeft=sx;
}
});

this.update(hB.data);
this[hB.enabled?"enable":"disable"]();
};

fS.dsF=function(){
var nC=this.abG.container;
nC.innerHTML=this.dzA();
this.abG.aEb=GelTags("td",nC);
};

fS.bGY=function(){
var iq=this.abG;
var lI=this.sI;
var tn=this.aaO.btn;
var zf=lI.zf;
var zH=lI.zH;
var apy=lI.apy;

if(iq.pagetxt&&zf)
iq.pagetxt.innerHTML=qmSimpleThumb.bN.brh.replace({
page:zH,
total:apy
});

if(iq.prevbtn)
{



setClass(iq.prevbtn,!zf||zH==1?
tn.disable:tn.normal);

}

if(iq.nextbtn)
{
setClass(iq.nextbtn,!zf||zH==apy?
tn.disable:tn.normal);


}
};

fS.dsz=function(){
var zH=this.sI.zH;
if(zH>0){
var bjI=this.abG.aEb[zH-1].firstChild;
if(!bjI.innerHTML){
bjI.innerHTML=this.dPI(zH);
return true;
}
}
return false;
};

fS.cyW=function(){
var tn=this.aaO.thumb;
var lI=this.sI;

var azZ=this.atM.length-1;
var ayd=this.aTq.ayd;
var aEb=this.abG.aEb;

function cJw(bma,cKS){
if(bma<0||bma>azZ)
return;

var csB=Math.floor((azZ-bma)/ayd);
var adi=azZ-bma-csB*ayd;

var NQ=aEb[csB].firstChild.childNodes;
if(adi<0||adi>=NQ.length)
return;

var eU=NQ[adi];
eU.setAttribute("select",cKS&&tn.select&&tn.select!=tn.over
&&tn.select!=tn.normal?"true":"false");
setClass(eU,cKS?tn.select:tn.normal);
};

cJw(lI.akA,true);
cJw(lI.bjx,false);
};

fS.bnW=function(){
var cA=this;
var iq=this.abG;
var lI=this.sI;

addEvent(iq.prevbtn,"click",function(_aoEvent){
preventDefault(_aoEvent);
cA.goPage(lI.zH-1);
});

addEvent(iq.nextbtn,"click",function(_aoEvent){
preventDefault(_aoEvent);
cA.goPage(lI.zH+1);
});

addEvent(iq.container,"drag",preventDefault);

addEvent(iq.container,"click",function(kt){
preventDefault(kt);
var mX=kt.srcElement||kt.target;
var acZ=mX.getAttribute("param");
if(acZ)
cA.select(acZ);
});

addEvent(iq.container,"mouseover",function(_aoEvent)
{

cA.onmouseover(_aoEvent);
});
addEvent(iq.container,"mouseout",function(_aoEvent)
{

cA.onmouseout(_aoEvent);
});
};

fS.dWc=function(){
var zH=this.sI.zH;
if(zH>0){
var nC=this.abG.container;
var bjI=this.abG.aEb[zH-1];


this.anu.stop();
this.anu.play({
from:nC.scrollLeft,
to:bjI.offsetLeft
});










}
};

fS.dFF=function(aUs){
this.atM=aUs;
this.sI.apy=1+parseInt((this.atM.length-1)/this.aTq.ayd);
};


hz.bN={};

hz.bN.tj=T([
'<table cellpadding="0" cellspacing="0" border="0">',
'<tr>$container$</tr>',
'</table>'
]);

hz.bN.baN=T([
'<td><div class="$border$"></div></td>'
]);

hz.bN.fzs=T([
'<div class="$border$">$content$</div>'
]);

hz.bN.bNQ=T([
'<div class="$normal$" un="item" param="$value$"',
'onmouseover="',
'this.getAttribute(\x27select\x27)!=\x27true\x27&&getTop().setClass(this,\x27$over$\x27);',
'" onmouseout="',
'this.getAttribute(\x27select\x27)!=\x27true\x27&&getTop().setClass(this,\x27$normal$\x27);',
'">',
'<img class="$img$" src="$images_path$$url$" param="$value$"/>',

'</div>'
]);

hz.bN.abz=T([
'<div style="text-align:center;">',
'<img src="$images_path$ico_loading10aa5d9.gif" style="display:$dispload$;"/>',
'$msg$',
'</div>'
]);

hz.bN.brh=T([
'$page$ / $total$'
]);
































































var qmGroupThumb=function(hB){
this.aIU(hB);
};

hz=qmGroupThumb;
fS=hz.prototype;



fS.changeGroup=function(OA){
this.aGI.change(OA);
};

fS.enable=function(){
if(this.sI.zf==true)
return false;

this.sI.zf=true;

var aCI=this.aGI.getSelectedTabId();
if(aCI)
this.abR[aCI].enable();
};

fS.disable=function(){
if(this.sI.zf==false)
return false;

this.sI.zf=false;

var aCI=this.aGI.getSelectedTabId();
if(aCI)
this.abR[aCI].disable();
};

fS.getDataLength=function(OA){
return this.abR[OA].getDataLength();
};

fS.getId=function(){
return this.JD;
};

fS.getSelectedData=function(){
var MG=this.sI.MG;
return!MG?null:this.abR[MG].getSelectedData();
};

fS.goPage=function(ape){
var aiJ=this.abR[this.aGI.getSelectedTabId()];
if(aiJ)
aiJ.goPage(ape);
};

fS.select=function(Pt,OA){
var aiJ=this.abR[OA||this.aGI.getSelectedTabId()];
return aiJ?aiJ.select(Pt):false;
};

fS.update=function(aUs,OA){
var aiJ=this.abR[OA];
aiJ&&aiJ.update(aUs);
};



fS.aIU=function(hB){
this.JD=hB.id||T("qmSimpleThumb_$date$").replace({
date:now()
});

this.HN={
Oi:hB.onselect,
mw:hB.onchange
};

this.sI={
MG:null,
aoc:-1,
zf:null
};

var cA=this;
var bvW=this.abR={};
var cKQ={};
var cxw=hB.group;
for(var aZW in cxw){
var bRb=cxw[aZW];
cKQ[aZW]=bRb.dom;
bvW[aZW]=new qmSimpleThumb({
id:aZW,
win:hB.win,
imgpath:hB.imgpath,
numperPage:hB.numperpage||8,
enabled:false,
dom:{
container:bRb.dom.container,
prevbtn:hB.dom.prevbtn,
nextbtn:hB.dom.nextbtn,
pagetxt:hB.dom.pagetxt
},
style:{
thumb:hB.style.thumb,
btn:hB.style.btn
},
data:bRb.data,
onselect:function(aBR,bxi){
cA.dYv(this,aBR,bxi);
}
});
}

this.aGI=new qmTab({
win:hB.win,
tab:cKQ,
style:hB.style.group,
onchange:function(Wc,alj){
cA.dph(Wc,alj);
}
});

this.aGI.change(hB.defgroupid||aZW);
this[hB.enabled==false?"disable":"enable"]();
};

fS.dph=function(OA,bwW){
var ae=this;
if(!ae.sI.zf)
return;


callBack.call(ae,ae.HN.mw,[OA,bwW]);

if(bwW)
ae.abR[bwW].disable();
ae.abR[OA].enable();
};

fS.dYv=function(bMo,aBR,bxi){
var lI=this.sI;
var MG=lI.MG;
var aoc=lI.aoc;

if(aBR!=-1){
lI.MG=bMo.getId();
lI.aoc=aBR;

var cFC=this.abR[MG];
if(aBR!=-1&&MG!=bMo.getId()&&cFC)
cFC.select(-1);
}
else if(MG==bMo.getId()){

lI.aoc=-1;
}

if((MG!=lI.MG||aoc!=lI.aoc)&&
typeof(this.HN.Oi)=="function")
this.HN.Oi.call(this,
{
groupid:lI.MG,
thumbidx:lI.aoc
},
{
groupid:MG,
thumbidx:aoc
});
};





qmActivex=function(){
this.JD="qmActiveX_"+(new Date()).valueOf();
this.bGi={};
this.aat=null;
};

hz=qmActivex;
fS=hz.prototype;

fS.screenSnap=function(cxq){
var Nm=this.aFV("screensnap");
if(!Nm)
return false;

try{
Nm.emv=(getDomain()=="foxmail.com")?1:0;
}
catch(e){
}

var aCu=function(rj){
return function(){
if(typeof(cxq)=="function")
cxq(rj);
};
};

Nm.OnCaptureFinished=aCu(true);
Nm.OnCaptureCanceled=aCu(false);

Nm.DoCapture();

return true;
};














fS.upload=function(cFV){
this.stopUpload();
this.aat=cFV;

var pQ=cFV.config;
if(!pQ||!pQ.url)
throw{message:"qmActivex:no upload cgi url"};


pQ.mode=pQ.mode||"download";
pQ.from=pQ.from||"";
pQ.scale=pQ.scale||"";
pQ.widthlimit=pQ.widthlimit||"";
pQ.heightlimit=pQ.heightlimit||"";

return this.dwz()?true:this.dxJ();
};

fS.stopUpload=function(){
var nb=this.aat;
if(!nb)
return;

this.aat=null;
if(nb.bBl=="form"){
removeSelf(nb.aHy);
}
else if(nb.bBl=="activex"){
if(nb.adJ!=90)
this.aFV("uploader").StopUpload();
}
};

fS.hasClipBoardImage=function(){
var Nm=this.aFV("screensnap");
return Nm?Nm.IsClipBoardImage:false;
};

fS.checkImageType=function(dzS,cyr){
var dkZ=dzS.toLowerCase();
var bsI="gif|jpg|jpeg|bmp|png".split("|");
for(var i=bsI.length-1;i>=0;i--)
if(dkZ.indexOf(bsI[i])!=-1)
break;

if(-1==i){
var zG=T("\u53EA\u5141\u8BB8\u4E0A\u4F20 <b>#type#</b> \u683C\u5F0F\u7684\u56FE\u7247","#").replace({
type:bsI
});
if(cyr=="showerr")
showError(zG);
return cyr=="returnerr"?zG:false;
}

return true;
};

fS.aFV=function(Rb)
{
var cis={
"screensnap":0,
"uploader":2
}[Rb];
if(!detectActiveX(cis,1))
return null;

if(!this.bGi[Rb])
this.bGi[Rb]=createActiveX(cis);

return this.bGi[Rb];
};

fS.djb=function()
{
var Nm=this.aFV("screensnap");
return Nm&&Nm.IsClipBoardImage?Nm.SaveClipBoardBmpToFile(1):null;
};

fS.dwz=function()
{
var vi=this.aFV("uploader");


if(!vi)
{
return false;
}

var nb=this.aat;
if(nb.fileCtrl&&(getTop().gnIEVer>6||!getTop().gbIsIE))
{

return false;
}

nb.screenImg=this.djb();
if(!nb.fileCtrl&&!nb.screenImg)
{
nb.config.url='';
return false;
}


nb.bBl="activex";
nb.adJ=0;
nb.onupload.call(this,"start");

vi.StopUpload();
vi.ClearHeaders();
vi.ClearFormItems();

var pQ=nb.config;

if(pQ.url.indexOf("http")!=0)
{
vi.URL=[location.protocol,"//",location.host,pQ.url].join("");
}
else
{
vi.URL=pQ.url;
}

var cA=this;
vi.OnEvent=function(mA,bmc,aCH,bej,bYA){
cA.dtK(mA,bmc,aCH,bej,bYA);
}

vi.AddHeader("Cookie",document.cookie);

vi.AddFormItem("sid",0,0,getSid());
vi.AddFormItem("mode",0,0,pQ.mode);
vi.AddFormItem("from",0,0,nb.fileCtrl?pQ.from:"snapscreen");
vi.AddFormItem("scale",0,0,pQ.scale);
vi.AddFormItem("widthlimit",0,0,pQ.widthlimit||0);
vi.AddFormItem("heightlimit",0,0,pQ.heightlimit||0);


if(nb.fileCtrl){
vi.AddFormItemObject(nb.fileCtrl);
}
else{
vi.AddFormItem("UploadFile",1,4,nb.screenImg);
}

vi.StartUpload();

return true;
};

fS.dxJ=function(){
var nb=this.aat;
if(!nb.fileCtrl)
return false;

for(var Er=nb.fileCtrl.parentNode;Er&&Er.tagName!="FORM"&&Er.tagName!="BODY";)
Er=Er.parentNode;

if(!Er||Er.tagName!="FORM")
return false;

nb.bBl="form";
nb.onupload.call(this,"start");

var Qb=nb.window||window;
var bDS=this.JD;

Qb[bDS+"Instance"]=this;
Qb.qmActiveXDoUploadFinish=function(dpm){
var eU=Qb[dpm.id+"Instance"];
if(eU)
eU.dLw();
};

if(nb.aHy)
{
fwB(nb.aHy);
}

createBlankIframe(Qb,{
id:bDS,
onload:dbz
});
var cfr=false;
function dbz(aq)
{
var qj=this;

if(!cfr)
{
nb.aHy=qj;

var pQ=nb.config||{};
Er.action=pQ.url||["/cgi-bin/upload?sid=",getTop.getSid()].join("");
Er.target=bDS;

Er.sid.value=getSid();
Er.mode.value=pQ.mode||"download";
Er.scale.value=pQ.scale||"";
Er.widthlimit.value=pQ.widthlimit||"";
Er.heightlimit.value=pQ.heightlimit||"";
Er.submit();
return cfr=true;
}
aq.qmActiveXDoUploadFinish(qj);
}
};

fS.dLw=function()
{
var nb=this.aat;
if(!nb)
return debug("_doFormUploaderEvent: upload info not exist",null,61882714);
if(!nb.aHy)
return;
try
{
var chv=nb.aHy.contentWindow.document;
var eca=chv.body;
if(eca.className==nb.aHy.id)
return;

var cxn=[];
var cgC=GelTags("script",chv);
for(var i=0;i<cgC.length;i++)
cxn.push(cgC[i].innerHTML);
this.beW(cxn.join(""));
}
catch(e)
{
debug(e.message,61882714);
this.asd(false);
}
};

fS.dtK=function(mA,bmc,aCH,bej,bYA){
var nb=this.aat;
if(!nb)
return debug("_doActivexUploaderEvent: upload info not exist",null,61882714);
switch(bmc){
case 1:

return this.asd(false,{
errCode:aCH
});
case 2:

nb.adJ=parseInt(aCH*90/bej);
return nb.onupload.call(this,"uploading",{
percent:nb.adJ
});
case 3:

var vi=this.aFV("uploader");
if(vi.ResponseCode!="200")
return this.asd(false,{
errCode:aCH
});

this.beW(vi.Response);
}
};

fS.beW=function(dJl){

var awM=dJl||"";
var JE=awM.indexOf('On_upload("');
var ane=awM.indexOf('");',JE);
var apR=(JE!=-1&&ane!=-1)?awM.substring(JE+11,ane):"err";

if(apR!="err")
{
apR=awM.substring(JE+11,ane).replace(new RegExp("\"","ig"),"").split(",");
return this.asd(true,{

imgParam:apR[0],
imgwidth:apR[1],
imgheight:apR[2]
});
}
JE=awM.indexOf('On_upload_Fail("');
ane=awM.indexOf('");',JE);

var cxy=function(sx){
sx=parseInt(sx);
return(isNaN(sx)?"5":(parseInt(100*parseInt(sx)/(1024*1024))/100));
};
if(JE!=-1&&ane!=-1){
apR=awM.substring(JE+16,ane).replace(new RegExp("\"","ig"),"").split(",");
return this.asd(false,{
curSize:cxy(apR[0]),
allowSize:cxy(apR[1])
});
}

return this.asd(false);
};
fS.asd=function(rj,ajy){
if(!this.aat)
return;

try
{
this.aat.onupload.call(this,rj?"ok":"fail",ajy);
}
catch(aZ)
{
doPageError(aZ.message,this.aat.window.location.href,"_uploadFinish callback");
}

this.stopUpload();
};














function qmFlash(hB)
{
if(!(this.JD=hB.id))
{
throw Error(0,"config.id can't use null");
}

if(!(this.cvw=hB.win))
{
throw Error(0,"config.win win is null");
}

this.dYl=this.constructor;
this.VL=hB;
this.Xc();
}

hz=qmFlash;
fS=hz.prototype;

hz.get=function(bsY,SE)
{
var EE=SE[this.fO.clT];
return EE&&EE[bsY];
};

hz.getFlashVer=function()
{
var kU="";
var bmn=-1;
var boR=-1;
var bgJ=-1;
var bgG=navigator.plugins;
if(bgG&&bgG.length){

for(var i=0,dyq=bgG.length;i<dyq;i++){
var cpI=bgG[i];
if(cpI.name.indexOf('Shockwave Flash')!=-1){
kU=cpI.description.split('Shockwave Flash ')[1];
bmn=parseFloat(kU);
bgJ=parseInt(kU.split("r")[1]);
boR=parseInt(kU.split("b")[1]);
break;
}
}
}
else{
try
{
var cmj=new ActiveXObject('ShockwaveFlash.ShockwaveFlash');
if(cmj)
{
kU=cmj.GetVariable("$version").split(" ")[1];
var bMc=kU.split(",");
bmn=parseFloat(bMc.join("."));
bgJ=parseInt(bMc[2]);
boR=parseInt(bMc[3]);
}
}
catch(e)
{
}
}

return{
version:(isNaN(bmn)?-1:bmn)||-1,
build:(isNaN(bgJ)?-1:bgJ)||-1,
beta:(isNaN(boR)?-1:boR)||-1,
desc:kU
};
};

hz.isSupported=function()
{
var aFf=this.getFlashVer();
return aFf.version>=10||aFf.version==9&&aFf.build>50;
};

hz.fO={
cBg:5*1000 ,
clT:"qmFlashCaches_ASDr431gGas",
cvM:"onFlashEvent_ASDr431gGas"
};

fS.getFlash=function(){
return getFlash(this.JD,this.cvw);
};

fS.isDisabled=function(){
return this.dBG||false;
};

fS.disable=function(dko){
this.dBG=dko!=false;
return this;
};











fS.getLoadedPercent=function(dqQ){
var cA=this;
function nc(sx){
try{
dqQ.call(cA,sx);
}
catch(e){
}
}

var eU=this.getFlash();
if(!eU)
return nc("notfound");

var cDa=0;
(function(){
var apn=arguments.callee;
if(!apn.cNz)
apn.cNz=getTop().now();

var adJ=0;
var beL=false;
try{
adJ=eU.PercentLoaded();
}
catch(e){
beL=true;
}

if(adJ!=cDa)
nc(cDa=adJ);

if(adJ!=100){
if(getTop().now()-apn.cNz>qmFlash.fO.cBg){
nc(beL?"noflash":"timeout");
}
else{
setTimeout(apn,100);
}
}
})();
};












fS.setup=function(dDK){
var cA=this;
function nc(rj,adX){
try{
dDK.call(cA,rj,adX);
}
catch(e){
}
}

this.getLoadedPercent(function(sx){
if(sx==100){
setTimeout(function(){

try{
if(!cA.getFlash().setup(qmFlash.fO.cvM,cA.JD))
return nc(false,"setuperr");
}
catch(e){
return nc(false,"nosetup");
}

nc(true);
});
}
else if(typeof sx!="number"){
nc(false,sx);
}



});
};



fS.Xc=function(){
var alG=this.cvw;
var ctA=this.dYl.fO;
var bpK=ctA.clT;
var amr=ctA.cvM;

if(!alG[bpK])
alG[bpK]=new alG.Object;

alG[bpK][this.JD]=this;

if(!alG[amr]){
alG[amr]=function(){
var rg=arguments[0];
var cig=arguments[1];
var aTb=alG[bpK][rg];

if(aTb&&typeof(aTb.VL[cig])=="function"){
var cnS=[];
for(var i=2,bV=arguments.length;i<bV;i++)
cnS.push(arguments[i]);
aTb.VL[cig].apply(aTb,cnS);
}
};
}
};





function clsXfBatchDownload()
{
this.constructor=arguments.callee;
}

clsXfBatchDownload.prototype=
{
init:function()
{
if(!this.dzp())
{
return false;
}
var aUr=new Date();
setCookie("qm_ftn_key","",aUr,"/","qq.com");
return true;
},

DoXfBatchDownload:function(bUI)
{
var cA=this;
waitFor(function(){
return typeof(BatchTask)!="undefined";
},function(aVu){
if(aVu){
cA.cmF(bUI);
}
else{
showError("\u8C03\u7528\u65CB\u98CE\u5931\u8D25\uFF0C\u8BF7\u5237\u65B0\u9875\u9762\u91CD\u8BD5\u3002");
}
});
},


makeGetUrlArray:function()
{
return 0;
},


dzp:function()
{
try
{
var aqO=new ActiveXObject("QQIEHelper.QQRightClick.2");
delete aqO;
loadJsFile("$js_path$lib/xunfeng/xflib_xw0bdf91.js",true);
return true;
}
catch(e)
{
if(confirm("\u60A8\u8FD8\u6CA1\u5B89\u88C5QQ\u65CB\u98CE\uFF0C\u73B0\u5728\u53BB\u4E0B\u8F7D\u5B89\u88C5\u4E48\uFF1F\u5B89\u88C5\u5B8C\u540E\u8BF7\u5237\u65B0\u672C\u9875\u9762\u3002"))
{
window.open("http://xf.qq.com/xf2/index.html");
}
return false;
}
},

cmF:function(bUI)
{
var bCY=bUI||this.makeGetUrlArray();
if(bCY.length<=0)
{
return;
}
var _nLen=Math.min(50,bCY.length),
dW=new QMAjax,
aE={},
ae=this;
showProcess(1,true,"\u6B63\u5728\u83B7\u53D6\u4E0B\u8F7D\u94FE\u63A5...");
(function dip(fX)
{
if(fX>=_nLen)
{
return ae.dfW(aE,_nLen);
}
QMAjax.send([bCY[fX],"&nm=",fX,"&rn=",Math.random()].join(""),
{
method:"GET",
onload:function(aV,bQ){
var aP="name"+fX;
if(aV&&bQ.indexOf(aP)>0)
{
aE[aP]=bQ.split('"')[1];
}
dip(fX+1);
}
},
dW);
})(0);
},

fdQ:function(){
showError("\u94FE\u63A5\u83B7\u53D6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5");
},

dfW:function(cCS,bOq){

var blo=0,
cKP=[];
for(var aD=0;aD<bOq;aD++){
if(typeof cCS["name"+aD]!="undefined"){
var bmu=cCS["name"+aD].split("|");
if(bmu[0]!="error"&&bmu[0].indexOf("http://")==0){
cKP.push(bmu[0].replace(/#/g,"_"));
var Uj=bmu[1],
aUr=new Date(now()+3600*1000),
diG=getCookie("qm_ftn_key");
setCookie("qm_ftn_key",[diG,Uj].join(","),aUr,"/","qq.com");

blo++;
}
}
}

if(blo==bOq){
showProcess(0);
}else{
showError((bOq-blo)+"\u4E2A\u6587\u4EF6\u94FE\u63A5\u83B7\u53D6\u5931\u8D25");
}

if(blo>0){
this.dnJ(cKP);
}
},

dnJ:function(cfR)
{
var aZk=[];
for(var aD=0,bV=cfR.length;aD<bV;aD++)
{
{
aZk.push(cfR[aD]);
aZk.push("http://mail.qq.com/");
aZk.push("\u6587\u4EF6\u4E2D\u8F6C\u7AD9");
}
}
BatchTask(aZk.length,aZk);
}
}





















var QMSender=function(zu)
{
this.bE=zu.oWin;
this.Dz=[];
this.bIT=false;
this.bNF=null;
this.dEg(zu);
}

hz=QMSender;
fS=hz.prototype;

fS.dEg=function(zu)
{
var _oContainer=S("Senderdiv",this.bE);
if(!_oContainer)
{
return;
}
try
{
var iS=getDefalutAllMail();
}
catch(e)
{
var nE=arguments.callee;
return setTimeout(function()
{
nE.apply(this.bE,arguments);
},500);
}

if(!iS.length)
{
return;
}

var aKv=zu.nCurFolderId;
var atj=zu.sCurSaveFrom;
var btF=zu.bShowNode;
var cLu=typeof(zu.sTitle)=="undefined"?
"\u53EF\u9009\u62E9\u90AE\u7BB1\u522B\u540D\u6216POP\u6587\u4EF6\u5939\u7684\u90AE\u4EF6\u5730\u5740&#10;\u4F5C\u4E3A\u53D1\u4FE1\u5E10\u53F7\u3002":zu.sTitle;

var coI=typeof(zu.sDesContent)=="undefined"?
"\u53D1\u4EF6\u4EBA\uFF1A":zu.sDesContent;

this.bNF=function(aj)
{

var dLW=S("sendmailname_val",this.bE);
if(!dLW)
{
return;
}


var ya="",
aHo=GelTags("span",S("sendmailname_val",this.bE))[0],
bnM=GelTags("b",S("sendmailname_val",this.bE))[0],
jh=aHo.getAttribute("nickname"),
da=jh?jh.split("|"):[];


if(da[0]==aj.email)
{
ya=da[1];
}
aHo.innerHTML=this.bN.btc.replace(aj);
bnM.innerHTML=htmlEncode(ya)||aj.nick.replace(/(^\"|\"$)/g,"");
S("sendname",this.bE).value=htmlDecode(bnM.innerHTML);


this.ceG(aj);


if(aj.sms)
{
loadJsFileToTop(["$js_path$qmtip0be06f.js"]);
var arn=this.bE;

waitFor(function()
{
return QMTip;
},
function(aV)
{

if(aV&&S("sendmailname",arn).value==aj.email)
{
QMTip.show({
tipid:10001,
domid:'sendmailname_val',
win:arn,
msg:['<span class="black">\u5C06\u4F7F\u7528\u624B\u673A\u53F7\u90AE\u7BB1\u53D1\u4FE1\uFF0C\u8FD9\u6837\u5BF9\u65B9\u56DE<br/>\u4FE1\u60A8\u5C31\u4F1A\u83B7\u5F97\u77ED\u4FE1\u63D0\u9192\u3002<a onclick="window.open(\'http://service.mail.qq.com/cgi-bin/help?subtype=1&&id=8&&no=1000605\')">\u8BE6\u60C5</a></span>'].join(''),
arrow_direction:'down',
arrow_offset:25,
height_offset:4,
tip_offset:-110,
width:305,
auto_hide:1,
notlog:true,
bForceShow:true
});
}
}
);
}
callBack.call(this,zu.onclickItemCallBack,[aj]);
}

var buj=typeof(zu.sAlignType)=="undefined"?
"left":buj,
ebC=zu.sVerAlign||"bottom";

var aQd=300;
var cy=parseInt(zu.sWidth)||aQd;
var aBo,bJu;
this.bIT=(cy<0);


if(this.bIT)
{
aBo=getStrDispLen(zu.sCurSaveFrom)+60;
cy=aBo+(gbIsIE?50:50);
}
else
{
aBo=cy-(gbIsIE?40:40);
}
bJu=aBo-25;

var cME=Math.floor(cy*23/aQd);
var cuW=Math.floor(cy*20/aQd);

var sk=[];
var wS=[];
var xR=null;
var adM=this.fO;
var bYX=this.bN.cEG;
var cga=this.bN.btc;
var cDi=this.bN.bEX;
var cKd=this.bN.sR;

var cxK=this.Dz=[];

var cJF=this;



















for(var i=0;i<iS.length;i++)
{
(function()
{
var av=iS[i];
var fd=av.email;
var _sDomain=fd.split("@").pop();
var bwa=adM.hasOwnProperty(_sDomain);
var abq={
nick:av.nickname&&"\""+av.nickname+"\"",
email:fd,
phone:av.phone,
emaildisp:this.bIT?fd:subAsiiStr(fd,bwa?cuW:cME,"..."),
signid:av.signid,
domain:cDi.replace({images_path:getPath("image"),margin_top:(av.phone==1?416:(bwa?adM[_sDomain]:321))}),
sms:av.phone==1&&av.smsleft>0


};

cxK.push(abq);
sk.push(extend({smtp:av.smtp==2?'':''},abq));

wS.push(function(e)
{
cJF.bNF(abq);
});

if(!aKv&&!atj&&getDefaultSender()==fd)
{

xR=abq;
}
else if((atj&&atj.toLowerCase()==av.email)
||(!atj&&aKv&&aKv==av.folderid)
||xR==null)
{
xR=abq;
}
})();
}

_oContainer.innerHTML=cKd.replace({
title:cLu,
desContent:coI,
email_width:bJu,
sel_width:aBo,
width:cy,
images_path:getPath("image"),
nick:xR.nick,
email:cga.replace(xR)
});

var ZA=0;
S("sendmailname_val",this.bE).onclick=function()
{
if(!ZA)
{
for(var i=0;i<iS.length;i++)
{
var bvO=getStrDispLen(iS[i].email+(iS[i].smtp==2?'':''));
if(ZA<bvO)
{
ZA=bvO;
}
}
ZA=Math.max(this.clientWidth,ZA+42);
}
var aGi=calcPos(this),
bm=[],
doM=GelTags("span",this)[0];
for(var i=0;i<sk.length;i++)
{

bm.push({
sId:i,
sItemValue:bYX.replace(extend({selected:doM.innerHTML==sk[i].email},sk[i]))
});
}

var aHo=this.getElementsByTagName("span")[0],
ya="",
cOn=aHo&&aHo.innerHTML||"";

for(var i=0;i<iS.length;i++)
{

if(iS[i].email==cOn)
{
ya=iS[i].nickname;

var jh=aHo.getAttribute("nickname"),
da=jh?jh.split("|"):[];



if(da[0]==cOn)
{
ya=da[1];
}

break;
}
}

bm.push({
sId:"border",
nHeight:5,
sItemValue:[
'<div style="border-top:1px solid;margin-top:2px;padding-top:2px;font-size:0;line-height:0;height:0;"></div>'
].join(""),
bDisSelect:true
});
bm.push({
sId:"send__nickname",
nHeight:25,
sItemValue:[
'<div style="padding-left:15px;overflow:hidden">',

'<span id="snn_getAlias" style="line-height:25px;">',
'<font style="color:#000">\u53D1\u4FE1\u6635\u79F0\uFF1A</font>',
'<span title="',ya,'">',subAsiiStr(ya,16,"...",true),'</span>',
'&nbsp;<a href="javascript:;" onclick="getTop().QMSender.initAlias(\'',ya,'\');return false">\u4FEE\u6539</a>',
'</span>',
'<span id="snn_setAlias" style="display:none;line-height:25px;">',
'<input onkeyup="if(event.keyCode==13){getTop().QMSender.setAlias()};" class="text" onchange="" style="width:120px" type="text" value=""/>',

'&nbsp;<input type="button" value="\u786E\u8BA4" onclick="getTop().QMSender.setAlias();return false" />',
'</span>',
'</div>'
].join(""),
bDisSelect:true
});

new(getTop().QMMenu)({
oEmbedWin:cJF.bE,
sId:"sendermenu",
nX:buj=="left"?aGi[3]:aGi[3]-(ZA-this.clientWidth),
nY:ebC=="bottom"?aGi[2]:(aGi[2]-21*bm.length-35),

nMinWidth:230,
bAnimation:false,
nItemHeight:21,
oItems:bm,
onitemclick:function(aG)
{
wS[aG]();
}
});
};

if(S("sendmailname",this.bE))
{
S("sendmailname",this.bE).value=xR.email;
}
var arn=this.bE;
if(arn.setSignature)
{
if(getUserSignatureId()!=-1)
{
S("signtype",this.bE)&&(S("signtype",this.bE).value=getUserSignatureId());
}
arn.setSignature("sign",getUserSignatureId());












}
show(btF?_oContainer[btF]:_oContainer,true);
if(sk.length>1)
{
getTop().requestShowTip("sendmailname_val",17,this.bE);
}
};
hz.setAlias=function()
{
var _oTop=getTop(),
aA=_oTop.getMainWin(),
HB=S("sendermenu_QMMenu",aA)?"sendermenu_QMMenu_":"sendermenu__",
bC=GelTags("input",S(HB+"snn_setAlias",aA))[0],
bLu=GelTags("span",S(HB+"snn_getAlias",aA))[0],
bdh=GelTags("span",S("sendmailname_val",aA))[0],
bnM=GelTags("b",S("sendmailname_val",aA))[0],
bM=bC.value;

S("sendname",aA).value=bM||" ";
bdh.setAttribute("nickname",[bdh.innerHTML,bM].join("|"));

bnM.innerHTML=htmlEncode(bM);
bLu.innerHTML=htmlEncode(bM);

if(S("useraddr").innerHTML==bdh.innerHTML)
{
S("useralias").innerHTML=htmlEncode(bM);
}

show(S(HB+"snn_setAlias",aA),false);
show(S(HB+"snn_getAlias",aA),true);
}
hz.initAlias=function(cwA)
{
var _oTop=getTop(),
aA=_oTop.getMainWin(),
HB=S("sendermenu_QMMenu",aA)?"sendermenu_QMMenu_":"sendermenu__",
bLu=GelTags("span",S(HB+"snn_getAlias",aA))[0],
bC=GelTags("input",S(HB+"snn_setAlias",aA))[0];



bC.value=htmlDecode(bLu.innerHTML);

show(S(HB+"snn_setAlias",aA),true);
show(S(HB+"snn_getAlias",aA),false);
setTimeout(function(){
bC.select();
});
}

fS.ceG=function(aj)
{
var arn=this.bE;
S("sendmailname",arn).value=aj.email;
if(arn.setSignature)
{
arn.setSignature("sign",aj.signid==-2?getUserSignatureId():aj.signid);
}
}


fS.setSenderSelected=function(my)
{
var bm=this.Dz;
for(var i=bm.length-1;i>=0;i--)
{
if(bm[i].email==my)
{
this.bNF(bm[i]);
return;
}
}
}

fS.fO={

"hotmail.com":0,
"live.com":0,
"live.cn":0,
"msn.com":0,
"msn.cn":0,

"yahoo.com.cn":30,
"yahoo.cn":30,
"yahoo.com":30,
"ymail.com":30,
"rocketmail.com":30,

"gmail.com":61,
"vipgmail.com":61,

"sina.com":95,
"sina.com.cn":95,
"vip.sina.com":95,
"my3ia.sina.com":95,
"sina.cn":95,

"163.com":383,
"vip.163.com":383,
"126.com":352,
"vip.126.com":352,
"yeah.net":223,

"foxmail.com":159,

"sohu.com":193,
"vip.sohu.com":193,

"vip.qq.com":288,
"qq.com":288,

"21cn.com":256,
"21cn.net":256
};

fS.bN={
sR:T([
'<div title="$title$" style="float:left; margin-left:-3px;" class="textoftitle">&nbsp;$desContent$</div>',
'<div id="sendmailname_val" unselectable="on" onmousedown="return false" ',
'style="cursor:pointer; padding:0 0 0 3px;  float:left;">',
'<b>$nick$</b> &lt;<span>$email$</span>&gt;<span class="addrtitle" style="font-family: arial,sans-serif; padding-left:4px; font-size:9px; position:relative; top:-1px;" >\u25BC</span>',
'</div>',
]),
cEG:TE([



'<div class="composeAccount" style="">',
'<input type="button" class="ft_upload_success" style="$@$if(!$selected$)$@$visibility:hidden;$@$endif$@$">$email$$smtp$',
'</div>'
]),
btc:T([



'$email$'
]),
bEX:T([
'<img src="$images_path$spacer083516.gif" style="background-position:0 -$margin_top$px;" valign="absmiddle" >'
])
};



var QMTimeLang={
cLg:new Date(1970,0,5,0,0,0,0)
};

hz=QMTimeLang;







hz.formatRefer=function(mM,bMl)
{
return T('$date$$time$').replace({
date:this.formatDate(mM,bMl),
time:this.formatTime(mM)
});
};







hz.formatDate=function(mM,bMl)
{
var cV=mM;
var cFi=bMl||new Date();

var cqd=cV-this.cLg;
var cmD=cFi-this.cLg;
var bzM=24*3600000;
var cLY=Math.floor(cqd/bzM)
-Math.floor(cmD/bzM);

if(Math.abs(cLY)<3)
{

return T('$day$').replace({
day:["\u524D\u5929","\u6628\u5929","\u4ECA\u5929","\u660E\u5929","\u540E\u5929"][cLY+2]
});
}

var cIO=7*bzM;
var cqQ=Math.floor(cqd/cIO)
-Math.floor(cmD/cIO);

if(Math.abs(cqQ)<2)
{

return T('$weekpos$\u5468$weekday$').replace({
weekpos:["\u4E0A","\u672C","\u4E0B"][cqQ+1],
weekday:this.formatWeek(cV)
});
}


return T([cV.getYear()==cFi.getYear()?'':'$YY$\u5E74',
'$MM$\u6708$DD$\u65E5']).replace({
YY:cV.getFullYear(),
MM:cV.getMonth()+1,
DD:cV.getDate()
});
};







hz.formatTime=function(mM)
{
var lx=mM.getHours();
var za=mM.getMinutes();
var GW;
if(lx<6)
{
GW="\u51CC\u6668";
}else if(lx<9)
{
GW="\u65E9\u4E0A";
}else if(lx<12)
{
GW="\u4E0A\u5348";
}else if(lx<13)
{
GW="\u4E2D\u5348";
}else if(lx<18)
{
GW="\u4E0B\u5348";
}else if(lx<22)
{
GW="\u665A\u4E0A";
}else
{
GW="\u6DF1\u591C";
}
return T('$desc$$hour$:$min$').replace({
desc:GW,
hour:lx==12?lx:lx%12,
min:this.GA(za)
});
};






hz.formatWeek=function(mM)
{
return["\u65E5","\u4E00","\u4E8C","\u4E09","\u56DB","\u4E94","\u516D"][mM.getDay()];
};






hz.GA=function(kO)
{
return kO<10?"0"+kO:kO;
};




var QMDragDrop={
groups:{},
setGroup:function(aG,bXl)
{
var ae=this;
if(!ae.aTi(aG))
{
ae.groups[aG]=bXl;
for(var i=0;i<bXl.length;i++)
{
bXl[i].setGroupId(aG);
}
}
return ae;
},

addGroup:function(aG,cKu)
{
var ae=this,
eN;
if(!(eN=ae.aTi(aG)))
{
eN=[];
ae.setGroup(aG,eN);
}

eN.push(cKu);
cKu.setGroupId(aG);

return ae;
},

delGroup:function(aG)
{
var ae=this,
eN;
if(eN=ae.aTi(aG))
{
if(delete ae.groups[aG])
{

}
else
{
debug('error delete dragdrop group:'+aG);
}
}

return ae;
},

getDragFromGroup:function(aG)
{
var ae=this,
eN,
cIl=[];
if(eN=ae.aTi(aG))
{
if(eN[i]instanceof QMDragDrop.Draggable)
{
cIl.push(eN[i]);
}
}
return cIl;
},

getDropFromGroup:function(aG)
{
var ae=this,
eN,
zn=[];
if(eN=ae.aTi(aG))
{
for(var i=0;eN&&i<eN.length;i++)
{
if(eN[i]instanceof QMDragDrop.DropTarget)
{
zn.push(eN[i]);
}
}
}
return zn;
},

aTi:function(aG)
{
var ae=this;
for(var groupid in ae.groups)
{
if(groupid==aG)
{
return ae.groups[groupid];
}
}
}
};

hz=QMDragDrop;


























hz.Draggable=function(_aoDom,bf,Mg)
{
this.he=null;
this.bLn=[];
this.lF={};
this.mD={};
this.aXj=0;
this.aXl=0;
this.gH=2;

this.dN(_aoDom,bf,Mg);
};

hz.Draggable.STATE={
cyt:0,
arG:1,
aDo:2
};

hz.Draggable.prototype={
setGroupId:function(aG)
{
this.hc=aG;
return this;
},

addDropTarget:function(btq)
{
if(btq)
{
this.bLn.push(btq);
}
return this;
},

moveTo:function(ry,qD,bv,ay)
{
var ae=this,
_oDom=ae.he,
aIo=_oDom.offsetLeft,
aIn=_oDom.offsetTop;
qmAnimation.play(_oDom,{
from:0,
to:1,
speed:Math.max(Math.abs(ry-aIo),Math.abs(qD-aIn))*0.5||10,
onaction:function(bW){
bW=bW||0;
this.style.left=aIo+(ry-aIo)*bW;
this.style.top=aIn+(qD-aIn)*bW;
},
oncomplete:function(){
this.style.left=ry;
this.style.top=qD;

if(bv)
{
bv.call(ae,ay);
}
}
});
},


exchangePos:function(aBf)
{
if(aBf&&this.NI)
{
aBf.parentNode.insertBefore(this.he,aBf);
this.NI.parentNode.insertBefore(aBf,this.NI);
this.he.parentNode.insertBefore(this.NI,this.he);
}
},

getElement:function()
{
return this.he;
},

getPlaceHolder:function()
{
return this.NI;
},

lock:function(cKi)
{
this.lF.lockx=!!cKi;
this.lF.locky=!!cKi;
},

dN:function(_aoDom,bf,Mg)
{
if(_aoDom)
{
this.he=_aoDom;
this.yR=_aoDom.ownerDocument;
this.hN=this.yR.parentWindow||this.yR.defaultView;
this.djX=getStyle(_aoDom,'position');
this.arS(bf).coL(Mg);
}
},

arS:function(bf)
{
var ae=this,
ba=ae.lF;

ba.handle=bf.handle||ae.he;
ba.maxContainer=bf.maxcontainer;
ba.lockx=!!bf.lockx;
ba.locky=!!bf.locky;
ba.transparent=!!bf.transparent;
ba.placeholder=!!bf.placeholder;
ba.threshold=bf.threshold||5;
ba.holderhtml=bf.holderhtml;


ba.oTitle=bf.oTitle;

if(ba.transparent)
{
var _oPos=calcPos(ae.he);
var cAH='<div style="display:none;background:#FFF;position:absolute;opacity:0.5;filter:alpha(opacity=50);width:100%;height:100%;z-index:999;cursor:move;"></div>';
insertHTML(ae.he,'afterBegin',cAH);
ae.adp=ae.he.firstChild;
ae.adp.style.height=_oPos[5]+'px';
}

return ae;
},

coL:function(Mg)
{
var ae=this;

ae.mD={
ondragstart:function(){},
ondrag:function(){},
ondragend:function(){}
};
extend(ae.mD,Mg);

function ade(_aoEvent)
{

var yw=getEventTarget(_aoEvent).tagName;
if(!gbIsIE&&yw&&yw.toLowerCase()=='input')
{
return;
}


if(ae.lF.lockx&&ae.lF.locky)
{
return;
}

ae.aXj=_aoEvent.clientX-ae.he.offsetLeft+(parseInt(getStyle(ae.he,'marginLeft'))||0)+bodyScroll(ae.hN,'scrollLeft');
ae.aXl=_aoEvent.clientY-ae.he.offsetTop+(parseInt(getStyle(ae.he,'marginTop'))||0)+bodyScroll(ae.hN,'scrollTop');


if(ae.lF.oTitle)
{
var Hn=gbIsIE?calcPos(ae.hN.frameElement):[0,0,0,0];
ae.baV=Hn[3]+_aoEvent.clientX;
ae.baX=Hn[0]+_aoEvent.clientY;
}
else
{
ae.baV=_aoEvent.clientX;
ae.baX=_aoEvent.clientY;
}

ae.gH=QMDragDrop.Draggable.STATE.aDo;

ae.aGy(_aoEvent);
}

addEvent(ae.lF.handle,'mousedown',ade);
return ae;
},

aGy:function(_aoEvent)
{
var ae=this,
ba=ae.lF,
aAh=QMDragDrop.DataTransfer;


if(!ba.oTitle)
{


preventDefault(_aoEvent);
}

if(!ae.avl||!ae.OX)
{
ae.avl=function(_aoEvent)
{

preventDefault(_aoEvent);


if(gbIsIE&&ba.oTitle)
{
}
else
{
ae.hN.getSelection?ae.hN.getSelection().removeAllRanges():ae.yR.selection.empty();
}


if(ae.gH==QMDragDrop.Draggable.STATE.aDo&&ba.threshold)
{

var bSr=Math.abs(ae.baV-_aoEvent.clientX),
bTt=Math.abs(ae.baX-_aoEvent.clientY);
if(bSr>ba.threshold||bTt>ba.threshold)
{
callBack.call(ae,ae.mD['ondragstart'],[_aoEvent]);

ae.gH=QMDragDrop.Draggable.STATE.cyt;
ae.byr();

if(!ba.oTitle)
{

ae.he.style.left=ae.baV-ae.aXj+bodyScroll(ae.hN,'scrollLeft');
ae.he.style.top=ae.baX-ae.aXl+bodyScroll(ae.hN,'scrollTop');
}
}
return;
}

var aZP=_aoEvent.clientX-ae.aXj+bodyScroll(ae.hN,'scrollLeft'),
aZR=_aoEvent.clientY-ae.aXl+bodyScroll(ae.hN,'scrollTop');

if(ba.oTitle)
{
}
else
{

if(!ba.lockx)
{
ae.he.style.left=aZP+'px';
}

if(!ba.locky)
{
ae.he.style.top=aZR+'px';
}
}

if(ba.maxContainer)
{
var yL=calcPos(ba.maxContainer),
ZT=calcPos(ae.he);

if(ZT[1]>yL[1])
{
ae.he.style.left=aZP+yL[1]-ZT[1]+'px';
}
else if(ZT[3]<yL[3])
{
ae.he.style.left=aZP+yL[3]-ZT[3]+'px';
}

if(ZT[2]>yL[2])
{
ae.he.style.top=aZR+yL[2]-ZT[2]+'px';
}
else if(ZT[0]<yL[0])
{
ae.he.style.top=aZR+yL[0]-ZT[0]+'px';
}
}

ae.gH=QMDragDrop.Draggable.STATE.arG;
callBack.call(ae,ae.mD['ondrag'],[_aoEvent]);


var aXz=new aAh(aAh.TYPE.DOWN,ae,_aoEvent.clientX,_aoEvent.clientY,_aoEvent);
ae.UD(aXz);
};

ae.OX=function(_aoEvent)
{

if(ae.gH==QMDragDrop.Draggable.STATE.aDo)
{
ae.Qh();
return;
}


ae.Qh();

var aXz=new aAh(aAh.TYPE.UP,ae,_aoEvent.clientX,_aoEvent.clientY,_aoEvent);
ae.UD(aXz);

ae.gH=QMDragDrop.Draggable.STATE.aDo;

callBack.call(ae,ae.mD['ondragend'],[_aoEvent]);

ae.byr();
};
}

if(gbIsIE&&ae.he.setCapture)
{
var yv=ba.oTitle||ae.he;
yv.setCapture(true);
addEvents(yv,{
mousemove:ae.avl,
mouseup:ae.OX,
losecapture:ae.OX
});



}
else
{
addEvents(ae.yR,{
mousemove:ae.avl,
mouseup:ae.OX
});



ae.hN.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
addEvent(ae.hN,'blur',ae.OX);
}

return ae;
},

Qh:function()
{
var ae=this;

var ba=ae.lF,
yv=ba.oTitle||ae.he;

if(gbIsIE&&yv.releaseCapture)
{
addEvents(yv,{
mousemove:ae.avl,
mouseup:ae.OX,
losecapture:ae.OX
},true);

yv.releaseCapture();





}
else
{
addEvents(ae.yR,{
mousemove:ae.avl,
mouseup:ae.OX
},true);


ae.hN.releaseEvents(Event.MOUSEMOVE|Event.MOUSEUP);
removeEvent(ae.hN,'blur',ae.OX);
}

return ae;
},

bxz:function(bmN)
{

var ae=this;
if(bmN)
{
var lV=ae.he.cloneNode(true),
_oPos=calcPos(ae.he);

lV.style.position='static';
lV.style.width=_oPos[4]+'px';
lV.style.height=_oPos[5]+'px';
if(ae.lF.holderhtml)
{
lV.innerHTML=ae.lF.holderhtml;

}
lV.removeAttribute('id');
lV.removeAttribute('name');
ae.he.parentNode.insertBefore(lV,ae.he);
ae.NI=lV;
}
else
{
if(ae.NI)
{
ae.he.parentNode.removeChild(ae.NI);
ae.NI=null;
}
ae.he.style.position=ae.djX;
}
},

byr:function()
{
var ae=this,
ba=ae.lF,
XC=ae.gH==QMDragDrop.Draggable.STATE.aDo;

if(ba.oTitle)
{
return;
}

ae.he.style.position=XC?'absolute':'absolute';

if(ba.transparent)
{
show(ae.adp,!XC);
}
if(ba.placeholder)
{
var aDt=ae.NI,
yu=aDt&&aDt.offsetLeft,
rY=aDt&&aDt.offsetTop;

!XC&&ae.bxz(true);
XC&&ae.moveTo(yu,rY,ae.bxz,false);
}

return ae;
},

UD:function(rJ)
{
var ae=this,
zn=QMDragDrop.getDropFromGroup(ae.hc);

for(var i=0;i<zn.length;i++)
{
if(ae!=zn[i])
{
zn[i].listen(rJ);
}
}
return ae;
}
};














hz.DropTarget=function(cjh,Mg,bhv)
{
this.he=null;
this.mD={};
this.bdY=null;
this.gH=-1;

this.dN(cjh,Mg,bhv);
};

hz.DropTarget.STATE={
bbx:0,
aVb:1,
bxv:2,
RC:3
};

hz.DropTarget.prototype={
setGroupId:function(aG)
{
this.hc=aG;
return this;
},

getElement:function()
{
return this.he;
},

getDragTarget:function()
{
return this.bdY;
},

listen:function(rJ)
{
var ae=this,
HU=QMDragDrop.DropTarget.STATE;

ae.bdY=rJ.target;









var Gy=ae.bdY.getElement(),
yu=Gy.offsetLeft+Gy.offsetWidth/2,
rY=Gy.offsetTop+Gy.offsetHeight/2;


if(ae.isOver(yu,rY,rJ))
{
if(rJ.type==QMDragDrop.DataTransfer.TYPE.DOWN)
{
ae.gH=(ae.gH==HU.bbx||ae.gH==HU.aVb)
?HU.aVb:HU.bbx;
}
else
{
ae.gH=HU.RC;
}
}
else
{
ae.gH=HU.bxv;
}

switch(ae.gH)
{
case HU.bbx:
callBack.call(ae,ae.mD['ondragenter'],[rJ]);

break;
case HU.aVb:
callBack.call(ae,ae.mD['ondragover'],[rJ]);

break;
case HU.RC:
callBack.call(ae,ae.mD['ondrop'],[rJ]);

break;
case HU.bxv:
callBack.call(ae,ae.mD['ondragleave'],[rJ]);

break;
default:
break;
}
},


isOver:function(ry,qD)
{
var ib=this.he;

var aiV=ib.offsetLeft;
var	atD=aiV+ib.offsetWidth;
var	aiv=ib.offsetTop;
var atO=aiv+ib.offsetHeight;
return(ry>aiV&&ry<atD&&qD>aiv&&qD<atO);
},

dN:function(_aoDom,Mg,bhv)
{
if(_aoDom)
{
this.he=_aoDom;

this.mD={
ondragenter:function(){},
ondragover:function(){},
ondragleave:function(){},
ondrop:function(){}
};
extend(this.mD,Mg);

if(bhv)
{
this.isOver=bhv;
}
}
}
};

hz.DataTransfer=function(dD,ctg,ry,qD,_aoEvent)
{
this.type=dD;
this.target=ctg;
this.x=ry;
this.y=qD;
this.event=_aoEvent;
};

hz.DataTransfer.TYPE={
DOWN:1,
UP:2
};






























































var QMPanel=inheritEx("QMPanel",Object,
function(ax)
{
return{
$_constructor_:function(ag)
{
if(ag)
{
var FM=this.constructor,
cBp=FM.get(ag.sId);

cBp&&cBp.destroy();
this.cIi(ag);
FM.$_add&&FM.$_add(ag.sId,this);
this.dN(ag);
}
},

ze:function(ag,NC,aci)
{
for(var i in NC)
{
if(aci||typeof(ag[i])=="undefined"||ag[i]==null)
{
ag[i]=NC[i];
}
}
return ag;
},

cKG:function()
{
var ae=this,
aM=ae.cR,
hS=ae.rw,
Tw=aM.oEmbedWin||getTop(),
biu=Tw.document.body;

if(!aM.nX)
{
var yu=(biu.clientWidth-hS.offsetWidth)/2+bodyScroll(Tw,"scrollLeft");
aM.nX=yu;
hS.style.left=yu+"px";
}
if(!aM.nY)
{
var rY=Math.max(2,(biu.clientHeight-hS.offsetHeight)/2
+bodyScroll(Tw,"scrollTop")-25);
aM.nY=rY;
hS.style.top=rY+"px";
}
},

afu:function(ag)
{
var Tw=ag.oEmbedWin||getTop(),
biu=Tw.document.body;

this.ze(ag,
{
oEmbedWin:Tw,
oEmbedToDom:biu,
sEmbedPos:"afterBegin",
oCallerWin:window,
nZIndex:1100,
nWidth:100,
nHeight:163,
bDisplay:true,
sBodyHtml:""
}
);



},

cIi:function(ag)
{
return this.Md=[
ag.sId||(ag.sId=["__QmDefPanelId","__"].join(unikey())),
this.constructor.name
].join("_");
},

ard:function(cP)
{
var bcn=this.Md;
return cP.toString().replace(/ (id|for)=[\"\']?(\w+)[\"\']?/gi,[' $1="',bcn,'_$2"'].join(""));
},

ahV:function(ag)
{
ag.sPanelId=this.Md;
ag.sBodyHtml=this.ard(ag.sBodyHtml);
insertHTML(ag.oEmbedToDom,ag.sEmbedPos,QMPanel.bN.CB.replace(ag));
},

BF:function(ag)
{
this.cR=ag;
this.ky="";
this.rw=S(this.Md,ag.oEmbedWin);
},

aNN:function(ag)
{
var ae=this;
ae.ky="hide";
callBack.call(this,ag.onload);
ae.mj();
ag.bDisplay&&this.show();
},

mj:function()
{
},


ahr:function(Pf,bv)
{
var ae=this;
show(ae.rw,Pf);
if(Pf)
{
ae.cKG();
}
callBack.call(ae,bv);
},


bKk:function()
{
var ae=this;
removeSelf(ae.rw);
ae.rw=null;
},

bBj:function()
{
var ae=this,
aT=ae.cR.sId,
FM=ae.constructor;

if(FM.get(aT))
{
FM.$_del(aT);
ae.bKk();
}
},

dN:function(ag)
{
this.afu(ag);
this.ahV(ag);
this.BF(ag);
this.aNN(ag);
},


destroy:function()
{
var ae=this;
ae.ahr(false);
ae.bBj();
},



option:function(KB,JZ)
{
var ae=this,
dWq=
{
nX:"left",
nY:"top",
nWidth:"width",
nHeight:"height",
nZIndex:"zIndex"
},
bXp=
{
nWidth:"scrollWidth",
nHeight:"scrollHeight"
},
Aq;

if(typeof JZ!="undefined")
{
ae.cR[KB]=JZ;
if(Aq=dWq[KB])
{
ae.rw.style[Aq]=typeof JZ=="number"&&Aq!="zIndex"
?JZ+"px":JZ;
}
}

if(KB=="status")
{
return ae.ky;
}

if(!JZ&&ae.cR[KB]=="auto"&&bXp[KB])
{

var iV=ae.rw,
ckA,jI;
if(!isShow(iV))
{
ckA=getStyle(iV,"left");
iV.style.left="-9999px";
jI=show(iV,true)[bXp[KB]];
show(iV,false).style.left=ckA;

}
else
{
jI=iV[bXp[KB]];
}
return jI;
}

return JZ?ae:ae.cR[KB];
},


S:function(aJp)
{
var Tw=this.cR.oEmbedWin||getTop();
return S([this.Md,aJp].join("_"),Tw);
},


isContain:function(aU)
{
return isObjContainTarget(this.rw,aU);
},


getPanelDom:function()
{
return this.rw;
},


show:function()
{
var ae=this;
if(ae.ky!="showing"&&ae.ky!="show")
{
ae.ky="showing";

ae.ahr(true,function()
{
ae.ky="show";
setTimeout(function()
{
try
{
callBack.call(ae,ae.cR.onshow);
}
catch(aZ)
{
debug("onshow error : "+aZ.message);
}
}
);
}
);
}
return ae;
},


hide:function(bv)
{
var ae=this;
if(ae.ky!="hiding"||ae.ky!="hide")
{
ae.ky="hiding";
ae.ahr(false,function()
{
ae.ky="hide";
setTimeout(function()
{
callBack.call(ae,ae.cR.onhide);
}
);
callBack.call(ae,bv);
}
);
}
else
{
callBack.call(ae,bv);
}
return ae;
},





daQ:function()
{
try
{
var hS=this.rw;




if(hS.parentNode==null)
{
return false;
}

if(gbIsIE)
{
return!!hS.ownerDocument;
}
else
{
var aA=hS.ownerDocument.defaultView,
qj=aA.frameElement;
if(qj)
{
return qj.contentDocument==hS.ownerDocument;
}
else
{

return aA==getTop();
}
}
}
catch(e)
{
return false;
}
},


close:function(dAy)
{
if(this.ky!="close")
{
var ae=this;
if(ae.daQ())
{
dAy&&(this.cR.bAnimation=false);
this.hide(function()
{
ae.ky="close";
ae.bBj();
callBack.call(ae,ae.cR.onclose);
}
);
}
else
{

ae.ky="close";
ae.bBj();
}

}
return this;
},

setBody:function(cP)
{
this.rw.innerHTML=this.ard(cP);
callBack.call(this,this.cR.onload);
return this;
},


setHtml:function(dRj,cP)
{
((typeof dRj=="string"?this.S(dRj):dRj)||{}).innerHTML=this.ard(cP);
return this;
},


isShow:function()
{
return this.ky=="show"||this.ky=="showing";
},


isClose:function()
{
return this.ky=="close";
}
};
},
{
bN:
{
CB:TE([
'<div id="$sPanelId$" class="$sClassName$" $sAttr$ ',
'style="$sStyle$;display:none;z-index:$nZIndex$;position:absolute;left:$nX$px;top:$nY$px;',
'$@$if($nHeight$&&!isNaN($nHeight$))$@$ height:$nHeight$px; $@$endif$@$',
'$@$if($nWidth$&&!isNaN($nWidth$))$@$ width:$nWidth$px; $@$endif$@$"',
'>',
'$sBodyHtml$',
'</div>'])
}
}
);

















































var QMDialog=inheritEx("QMDialog",QMPanel,
function(ax)
{
return{
BF:function(ag)
{
callBack.call(this,ax.BF,[ag]);
this.adp=null;
this.bCF=null;
this.ate=null;

var FM=this.constructor;
this.dJI=ag.bModal?FM.aPk:FM.bSE;

},


clK:function(bqT)
{
var ae=this,
cG=ae,
FM=ae.constructor,
bWI,
bmg=ae.dJI,
bsl=function(csG,dZc,dYf)
{
for(var i=csG.length-1;i>=0;i--)
{
cG=csG[i];
cG.option("nZIndex",bWI?dYf:dZc);
cG.cNu(bWI);
bWI=true;
}
};

if(bqT>0)
{
for(var i in bmg)
{
if(bmg[i]==ae)
{
cG=bmg.splice(i,1)[0];
break;
}
}
if(bqT==2)
{
bqT=0;
}
}
if(bqT==0)
{
bmg.push(cG);
}
bsl(FM.aPk,1120,1106);
bsl(FM.bSE,1110,1105);
},

mj:function()
{
var aM=this.cR,
ae=this;

if(aM.bModal)
{
addEvent(this.adp,"mousedown",function()
{
var biQ=ae.constructor.aPk,
czK=biQ[biQ.length-1];
czK&&czK.spark();
}
);
}
else
{
addEvent(this.rw,"mousedown",function()
{
if(!aM.bModal)
{
ae.clK(2);
}
}
);
}

var Tw=aM.oEmbedWin,
hS=this.rw;

if(aM.bMin)
{
this.S("_minbtn_").onclick=function()
{
ae.min();
}
}
if(aM.bClose)
{
this.S("_closebtn2_").onclick=function()
{
ae.close();
}
}

hS.tabindex="-1";
addEvent(hS,"keydown",function(_aoEvent){
if(_aoEvent&&_aoEvent.keyCode==27)
{
ae.close();
preventDefault(_aoEvent);
}
});

new(QMDragDrop.Draggable)(ae.rw,
{
handle:ae.S("_title_td_"),
maxcontainer:aM.oEmbedWin.document.body
},
{
ondragstart:function(){
callBack.call(ae,aM.ondragstart);
},
ondrag:function(){
callBack.call(ae,aM.ondrag);
},
ondragend:function()
{
ae.cR.nX=parseInt(ae.rw.style.left);
ae.cR.nY=parseInt(ae.rw.style.top);
}
}
).lock(!aM.bDraggable);
},

afu:function(ag)
{

this.ze(ag,{bModal:true});

var aVW=
{
bDraggable:true,
bClose:true,
bAnimation:true,
sEmbedPos:"beforeEnd",
nWidth:408,
nHeight:395,
sTitle:""
};

var FM=this.constructor,
ei=ag.bModal?FM.aPk:FM.bSE,
bFz=ei[ei.length-1];

if(bFz&&!ag.bAlignCenter)
{
extend(aVW,
{
nX:bFz.option("nX")+20,
nY:bFz.option("nY")+20
}
);
}
this.ze(ag,aVW);

var _oContainer=S("qmdialog_container",getTop());
if(!_oContainer)
{
var aL=getTop().document;

insertHTML(aL.body,
aL.readyState=="complete"?"beforeEnd":"afterBegin",
'<span id="qmdialog_container"></span>');

_oContainer=S("qmdialog_container",getTop());
}

this.ze(ag,
{
oEmbedWin:getTop(),
oEmbedToDom:_oContainer,
nZIndex:ag.bModal?1110:1105
},
true
);

return callBack.call(this,ax.afu,[ag]);
},

ahV:function(ag)
{
var bcn=this.Md;

ag.sBodyHtml=QMDialog.bN.CB.replace(
extend({},
ag,
{
tWidth:ag.nWidth-3,
imgpath:getPath("image"),
iwidth:ag.nWidth-5,
cHeight:ag.nHeight-32,
iheight:ag.nHeight-33
}
));
callBack.call(this,ax.ahV,[ag]);
},

aNN:function(ag)
{
var ae=this;
if(ag.bModal)
{
ae.adp=ae.dXb(ag.oEmbedWin);
}
if(ag.bMin)
{
insertHTML(ae.rw,"afterEnd",
ae.ard(ae.constructor.bN.dQh.replace(ag))
);
this.bCF=this.S("_min_animation_");
}

callBack.call(this,ax.aNN,[ag]);
},


dXb:function(aq)
{
aq=aq||getTop();
var aT="qqmail_mask",
ara=S(aT,aq);

if(!ara)
{
insertHTML(
aq.document.body,

"beforeEnd",
T([
'<div id="$id$" class="$class$" style="z-index:1115;display:none;"',
' onkeypress="return false;" onkeydown="return false;"',
' tabindex="0"></div>'
]).replace(
{

'class':'editor_mask opa50Mask ',
id:aT
}
)
);
ara=S(aT,aq);
}
return ara;
},





ahr:function(Pf,bv,baG)
{

this.clK(Pf?0:1);

var	ae=this,
aM=ae.cR,
baG=baG||(aM.bAnimation?"ani1":"ani0"),
lP=getTop().qmAnimation,
deE=this.constructor.aPk.length,
hS=ae.rw,
mu=ae.S("_content_");

if(this.cR.bModal&&deE==(Pf?1:0))
{


callBack(getTop().iPadPrevent);
show(this.adp,Pf);
}

hideWindowsElement(!Pf);

if(baG=="ani0")
{
callBack.call(this,ax.ahr,[Pf,bv]);
}
else if(baG=="ani2")
{
var bbn=ae.bCF,
cDf=ae.ate,
qQ=calcPos(show(cDf,true)),
cJQ=aM.nWidth-qQ[4],
ckG=aM.nHeight-qQ[5],
cnR=aM.nX-qQ[3],
cmh=aM.nY-qQ[0],
cFB=function(dcV)
{
E(["left","top","width","height"],function(dJp,ta)
{
bbn.style[dJp]=dcV[ta]+"px";
}
);
};

if(Pf)
{
lP.play(hS,
{
win:window,
speed:300,
onready:function()
{
show(bbn,true);
show(cDf,false);
},
onaction:function(bW,ho)
{
cFB(
[
qQ[3]+(cnR*ho),
qQ[0]+(cmh*ho),
qQ[4]+(cJQ*ho),
qQ[5]+(ckG*ho)
]
);
},
oncomplete:function()
{
show(bbn,false);
show(hS,true);
callBack.call(ae,bv);
}
}
);
}
else
{
lP.play(hS,
{
win:window,
speed:300,
onready:function()
{
show(hS,false);
show(bbn,true);
},
onaction:function(bW,ho)
{
cFB(
[
aM.nX-(cnR*ho),
aM.nY-(cmh*ho),
aM.nWidth-(cJQ*ho),
aM.nHeight-(ckG*ho)
]
);
},
oncomplete:function()
{
show(bbn,false);
callBack.call(ae,bv);
}
}
);
}
return;
}
else if(baG=="ani1")
{
if(Pf)
{
lP.play(hS,
{
win:window,
speed:300,
easing:"easeOut",
tween:"Sina",
from:-30,
to:0,
onready:function()
{
show(setOpacity(hS,0),true);
ae.cKG();
mu.style.visibility="hidden";
},
onaction:function(bW,ho)
{
setOpacity(hS,ho).style.marginTop=bW+"px";
},
oncomplete:function()
{
setOpacity(hS,1).style.marginTop=0;
mu.style.visibility="visible";
callBack.call(ae,bv);
}
}
);
}
else
{
lP.play(hS,
{
win:window,
speed:300,
easing:"easeIn",
tween:"Sina",
from:0,
to:-30,
onaction:function(bW,ho)
{
setOpacity(hS,1-ho).style.marginTop=bW+"px";
},
oncomplete:function(bW)
{
show(hS,false);
callBack.call(ae,bv);
}
}
);
}
}
},


bKk:function()
{
var ae=this;
if(ae.cR.sUrl)
{

try
{
ae.S("_dlgiframe_").contentWindow.location.replace("javascript:'';");
}
catch(aZ)
{
}
}
if(ae.cR.bAnimation)
{
qmAnimation.stop(ae.rw);
}
ae.ate&&removeSelf(ae.ate);
removeSelf(ae.rw);
removeSelf(ae.bCF);
ae.rw=null;
},

cNu:function(cFg)
{
var ae=this;
setClass(ae.S("_title_td_"),"editor_dialog_titlebar "+(cFg?"toolbg":"fdbody"));
setClass(ae.S("_title_div_"),cFg?"":"fdbody");
},






S:function(aJp)
{
var ae=this,
aM=ae.cR,
_oDom=callBack.call(ae,ax.S,[aJp]);
if(aM.sUrl&&!_oDom)
{
_oDom=S(aJp,ax.S("_dlgiframe_").contentWindow);
}
return _oDom;
},


close:function(ebF)
{
var aSR=this.cR.onbeforeclose;
if(aSR&&!aSR.call(this))
{
return;
}
if(ebF)
{
this.cR.bAnimation=false;
}
callBack.call(this,ax.close);
callBack(getTop().iPadRemoveEvent);
return this;
},

min:function()
{
if(this.ky!="show")
{
return;
}

var ae=this,
dvq=S("minimize_container",getTopWin()),
aM=ae.cR,
csN=ae.Md+"_min",
aJn=ae.ate,
cxx=ae.cR.onbeforemin;

if(cxx&&!cxx.call(ae))
{
return;
}

if(!aJn)
{
insertHTML(dvq,"beforeEnd",ae.constructor.bN.dDE.replace(
{
dialogId:aM.sId,
id:csN,
title:aM.sTitle
}
));
this.ate=aJn=S(csN,getTopWin());
}

ae.ahr(false,
function()
{
ae.ky="min";
show(aJn,true);
callBack.call(ae,ae.cR.onmin);
},
"ani2"
);
return ae;
},

max:function()
{
if(this.ky!="min")
{
return;
}
var ae=this,
aJn=ae.ate,
qQ=calcPos(aJn),
aM=ae.cR;

ae.ahr(true,function(){
ae.ky="show";
show(aJn,false);
callBack.call(ae,ae.cR.onmax);
},"ani2");
return this;
},

spark:function()
{
var ae=this,
eW=4,
cLf=function()
{
if(--eW>0)
{
setTimeout(arguments.callee,80);
}
var cdz=eW%2;
ae.cNu(cdz);
};
cLf();
return ae;
},

getMinDom:function()
{
return this.ate;
},

getDialogWin:function()
{
var aM=this.cR;
return aM.sUrl?this.S("_dlgiframe_").contentWindow:aM.oEmbedWin;
},

setHeader:function(cP)
{
this.S("_title_").innerHTML=this.ard(cP);
return this;
},

setBody:function(cP)
{
this.S("_content_").innerHTML=this.ard(cP);
callBack.call(this,this.cR.onload);
return this;
}

};
},
{
bN:
{
CB:TE([
'<div class="tipbg" >',
'<div id="_opashow_" class="opashowOuter qmpanel_shadow" ',
'$@$if($sUrl$)$@$',
'$@$else$@$',
'$@$endif$@$',
'style="background:#DDD;"',
'>',
'<table class="bd_upload" cellspacing="0" cellpadding="0" style="$@$if($tWidth$&&!isNaN($tWidth$))$@$width:$tWidth$px;$@$endif$@$ $@$if($nHeight$&&!isNaN($nHeight$))$@$height:$nHeight$px;$@$endif$@$ background:white;" >',
'<tr><td id="_title_td_" class="fdbody" style="height:28px;border:none;background-image:none;cursor:$@$if($bDraggable$)$@$move$@$endif$@$;overflow:hidden;">',
'<div class="fdbody" style="cursor:default;float:right;width:40px;border:none;background-image:none;" id="_title_div_">',
'$@$if($bClose$)$@$',
'<div id="_closebtn2_" class="editor_close" onmouseover="this.className=\'editor_close_mover\';" onmouseout="this.className=\'editor_close\';">',
'<img src="$imgpath$ico_closetip.gif" width="12" height="12" ondragstart="return false;">',
'</div>',
'$@$endif$@$',
'$@$if($bMin$)$@$',
'<div onmouseout="this.className=\'editor_min\';" onmouseover="this.className=\'editor_min_mover\';" class="editor_min" id="_minbtn_">',
'<img width="12" height="12" ondragstart="return false;" title="\u6700\u5C0F\u5316" src="$imgpath$ico_minimizetip.gif">',
'</div>',
'$@$endif$@$',
'</div>',
'<div class="editor_dialog_title" id="_title_">$sTitle$</div>',
'</td></tr>',
'<tr><td id="_content_" class="editor_dialog_content $@$if($sUrl$)$@$ toolbg $@$endif$@$" style="$@$if($cHeight$&&!isNaN($cHeight$))$@$height:$cHeight$px;$@$endif$@$border:none;" valign="top">',
'$@$if($sUrl$)$@$',
'<iframe id="_dlgiframe_" frameborder="0" scrolling="no" src="$sUrl$" style="$@$if($iwidth$&&!isNaN($iwidth$))$@$width:$iwidth$px;$@$endif$@$ $@$if($iheight$)$@$height:$iheight$px;$@$endif$@$"></iframe>',
'$@$else$@$',
'<div style="border:none;height:100%;display:inline;" class="mailinfo">',
'$sBodyHtml$',
'</div>',
'$@$endif$@$',
'</td></tr>',
'</table>',
'</div>',
'</div>']),

dDE:T('<span id="$id$" style="display:none;"><a onclick="getTop().QMDialog(\'$dialogId$\',\'max\');" nocheck="true">$title$</a>&nbsp;|&nbsp;</span>'),

dQh:T('<div id="_min_animation_" style="display:none;position:absolute;z-index:$nZIndex$;border-width:2px;left:$nX$;top:$nY$;width:$nWidth$px;height:$nHeight$px;" class="bd_upload"></div>')
},

bSE:[],
aPk:[]
}
);

















































var QMMenu=inheritEx("QMMenu",QMPanel,
function(ax)
{
return{
BF:function(ag)
{
var ae=this;
callBack.call(ae,ax.BF,[ag]);
ae.afs;
ae.eKU;

ae.WI=null;
ae.anj=null;
ae.aCF=null;
ae.aCx=null;


ae.awv=null;
},

mj:function()
{
var ae=this,
aM=ae.cR,
feo=null,
Bi=ae.S("_menuall_"),
cCH=ae.S("_foot_"),
iV=ae.getPanelDom();





function aaM(ah,dVL)
{




while(ah)
{
var aT=ah.id||"";
if(aT.indexOf("_menuitem_")>-1)
{
return!dVL&&ah.className.indexOf("menu_item_nofun")>-1?0:ah;
}
else if(/_QMMenu$/.test(aT))
{

return 0;
}
ah=ah.parentNode;
}
return null;
}

function btD(_aoEvent)
{
if(aM.bProxyScroll!==false)
{
var aB=getEventTarget(_aoEvent),
wR=typeof(_aoEvent.wheelDelta)=="undefined"?
_aoEvent.detail/3:-_aoEvent.wheelDelta/120,
oR=Bi.scrollTop+wR*20;
Bi.scrollTop=Math.min(Math.max(oR,0),Bi.scrollHeight-Bi.offsetHeight);

while(aB)
{
if(aB.getAttribute&&aB.getAttribute('scroll')=='true')
{
return;
}
aB=aB.parentNode;
}

preventDefault(_aoEvent);
stopPropagation(_aoEvent);
}
}

function cHt(aG)
{
var bm=aM.oItems;
for(var i in bm)
{
if(bm[i].sId==aG)
{
return bm[i];
}
}
}


addEvents(iV,
{
contextmenu:preventDefault,
mousewheel:btD,
DOMMouseScroll:btD,

mouseout:function(_aoEvent)
{
var bpp=ae.afs,
aHI=aaM(_aoEvent.relatedTarget||_aoEvent.toElement,1);

if(aHI==null&&aM.bAutoClose)
{
ae.cGr();
}
if(aHI===0||aHI==bpp)
{

return;
}
if(bpp)
{


var	aT=bpp.getAttribute("itemid"),
dgD=['sub',aT,'_QMMenu'].join(''),
bpU=aHI;

while(bpU)
{
if(bpU.id==dgD)
{
return;
}
bpU=bpU.parentNode;
}
if(ae.WI&&aHI==null&&bpp==ae.WI.bja)
{

return;
}
ae.aUu().ckm();
ae.aCx=setTimeout(function(){

ae.bAq();
},100);
setClass(ae.afs,"menu_item");
return ae.afs=null;
}
},
mouseover:function(_aoEvent)
{
if(aM.bAutoClose)
{
ae.dGX();
}
var aB=aaM(getEventTarget(_aoEvent));
if(aB)
{

ae.kS(aB);


var aT=aB.getAttribute("itemid"),
_oItem=cHt(aT);
if(_oItem.oSubMenu)
{
ae.ccM(_oItem,aB);
}
}
if(ae.anj)
{

ae.anj.aUu().ckm();
ae.anj.selectItem(ae.bja);
}
},
click:function(_aoEvent)
{
var eWI=getEventTarget(_aoEvent),
aB;

if(eWI.getAttribute("qmmenuopt")=="close")
{
ae.close();
}
else if(aB=aaM(getEventTarget(_aoEvent)))
{
var aT=aB.getAttribute("itemid"),
_oItem=cHt(aT);


if(!_oItem.oSubMenu)
{
ae.aUu();
callBack.call(ae,aM.onitemclick,[aT,_oItem]);
setClass(aB,"menu_item");
ae.close();
ae.bOa();
}
}
}
}
);

addEvent(ae.rw,"mousedown",stopPropagation);
},

afu:function(ag)
{
this.ze(ag,
{
bAutoClose:true,
nZIndex:1121,
nWidth:"auto",
nMinWidth:100,
nMaxWidth:9999,
bAnimation:true,
nMaxItemView:1000000,
sClassName:"qmpanel_shadow rounded5"
}
);


this.ze(ag,
{
nHeight:"auto",
sStyle:"background:#fff"
},true);

if(ag.nArrowPos)
{
ag.nX-=ag.nArrowPos;
ag.nY+=12;
}

return callBack.call(this,ax.afu,[ag]);
},

ahV:function(ag)
{
var ae=this,
bm=ag.oItems,
aDL=ag.oFootItems,
cuB=bm.length>ag.nMaxItemView,
dtI=cuB?ag.nMaxItemView:bm.length,
bcn=ae.Md,
RW=0;

for(var i=0;i<bm.length;i++)
{
var ddx=bm[i].nHeight=bm[i].nHeight||ag.nItemHeight||22;
if(i<dtI)
{
RW+=ddx;
}
if(bm[i].sId===0)
{
bm[i].sId="0";
}
ae.ze(bm[i],{
bDisSelect:!(bm[i].sId)
});
}

if(aDL)
{
for(var i=0,bV=aDL.length;i<bV;i++)
{
if(aDL[i].sId===0)
{
aDL[i].sId="0";
}
ae.ze(aDL[i],{
nHeight:ag.nItemHeight||22,
bDisSelect:!(aDL[i].sId)
});
}
}
ag.sBodyHtml=QMMenu.bN.CB.replace(
{
nArrowPos:ag.nArrowPos||0,
sWidthDetect:ag.sWidthDetect||"mini",
mwidth:ag.nWidth-3,
mheight:cuB?RW:"auto",
nMinWidth:ag.nMinWidth,
oItems:ag.oItems,
oFootItems:ag.oFootItems
}
);

callBack.call(this,ax.ahV,[ag]);
},

bgm:function()
{
var ae=this;
if(ae.cR.nWidth=="auto")
{
var hH=ae.S("_menuall_"),
cCH=ae.S("_foot_");
if(hH&&hH.offsetWidth>10)
{



cCH.style.width=hH.style.width=(Math.max(ae.cR.nMinWidth,Math.min(hH.scrollWidth,ae.cR.nMaxWidth))+(gbIsIE?0:hH.offsetWidth-hH.scrollWidth))+"px";

setClass(hH,"txtflow");

}
}
},

ahr:function(Pf,bv)
{
var	ae=this,
hS=ae.rw;

if(!this.cR.bAnimation||gbIsIE)
{
callBack.call(this,ax.ahr,[Pf,bv]);
return ae.bgm();
}

if(Pf)
{
var abw=true;
show(hS,true);
qmAnimation.expand(hS.lastChild,
{
win:window,
from:0,
speed:200,
easing:"easeOut",
tween:"Cubic",
oncomplete:function()
{
callBack.call(ae,bv);
},
onaction:function()
{
if(abw)
{
ae.bgm();
abw=0;
}
}
}
);
}
else
{
qmAnimation.fold(hS.lastChild,
{
win:window,
speed:200,
easing:"easeIn",
tween:"Cubic",
oncomplete:function()
{
show(hS,false);
callBack.call(ae,bv);
}
}
);
}
},


bKk:function()
{
var ae=this;
if(ae.cR.bAnimation)
{
qmAnimation.stop(ae.rw);
}
removeSelf(ae.rw);
ae.rw=null;
},


bTU:function(ta)
{
var ae=this;
return typeof(ta)=="number"?
ae.S("_menuall_").childNodes[ta]:
ae.S("_menuitem_"+ta);
},

kS:function(kq)
{
var yF=(typeof(kq)=="string"||typeof(kq)=="number")?this.S("_menuitem_"+kq):kq;

if(this.afs==yF)
{
return this;
}

if(yF)
{
yF.className="menu_item_high";
}
if(this.afs)
{
this.afs.className="menu_item";
}
this.afs=yF;
return this;
},

aUu:function()
{
var ae=this;
if(ae.aCF)
{
clearTimeout(ae.aCF);
ae.aCF=null;
}
return ae;
},

ckm:function()
{
var ae=this;
if(ae.aCx)
{
clearTimeout(ae.aCx);
ae.aCx=null;
}
return ae;
},




dGX:function()
{
var ae=this,
hH=ae;
while(hH.anj)
{
hH=hH.anj;
}
while(hH)
{
if(hH.awv)
{
clearTimeout(hH.awv);
hH.awv=null;
}
hH=hH.WI;
}
return ae;
},

cGr:function()
{
var ae=this;
if(ae.awv)
{
clearTimeout(ae.awv);
}
ae.awv=setTimeout(function(){
ae.bOa().close();
ae.awv=null;
},500);
return ae;
},

ccM:function(crK,cyb)
{
var ae=this,
aM=ae.cR,

PU=ae.ze(crK.oSubMenu,aM);
PU.sId="sub"+crK.sId;
PU.nZIndex=aM.nZIndex+1;
if(ae.WI)
{
if(ae.WI.cR.sId==PU.sId)
{

return ae;
}
}
ae.aUu();
ae.aCF=setTimeout(function(){

if(ae.WI)
{


ae.bAq();
}
if(ae.isShow())
{
var _oPos=calcPos(cyb);
_oPos[0]-=5;
_oPos[1]-=1;
_oPos[2]+=7;
_oPos[3]+=2;
var	bmk=ae.WI=new QMMenu(PU),
cNY=calcAdjPos(_oPos,bmk.option('nWidth'),bmk.option('nHeight'),aM.oEmbedWin,1);
bmk.option('nY',Math.max(0,cNY[0])).option('nX',Math.max(0,cNY[3])).anj=ae;
bmk.bja=cyb;
}
},100);
},

bAq:function()
{
var ae=this;
if(ae.WI)
{

ae.WI.close();
ae.WI=null;
}
return ae;
},




bOa:function()
{
var ae=this,
bTG=ae.anj;
if(bTG)
{
bTG.WI=null;
bTG.bOa().close();
ae.anj=null;
}
return ae;
},


toggle:function()
{
var ae=this;
ae.isShow()?ae.hide():ae.show();
return ae;
},

selectItem:function(kq)
{
var ae=this;
ae.kS(kq);
if(ae.afs)
{

scrollIntoMidView(ae.afs,ae.S("_menuall_"));
}
return ae;
},

addItem:function(ta,bt)
{
var ae=this,
yF=ae.bTU(ta);
ae.ze(bt,{
nHeight:22
});
if(yF)
{
insertHTML(yF,"beforeBegin",ae.constructor.bN.CB.replace(bt,"item"));
}
else
{

var _oNodes=ae.S("_menuall_").childNodes;
insertHTML(ae.S("_menuall_"),"beforeEnd",ae.constructor.bN.CB.replace(bt,"item"));
}
},

delItem:function(ta)
{
var ae=this,
yF=ae.bTU(ta);
if(yF)
{
removeSelf(yF);
}
},

itemOption:function(ta,aK,bK)
{
var yF=this.bTU(ta);
if(yF)
{
switch(aK)
{
case"bDisSelect":
yF.className=(bK?"menu_item_nofun":"menu_item");
break;
case"bDisplay":
yF.style.display=bK?"":"none";
break;
}
}
},

close:function(dAy)
{
var ae=this,
aSR=ae.cR.onbeforeclose;
if(aSR&&!aSR.call(ae))
{
return;
}

dAy&&(this.cR.bAnimation=false);
ae.aUu();
ae.bAq();
return callBack.call(ae,ax.close);
},




autoClose:function()
{
return this.cGr();
},

option:function(KB,JZ)
{
var ae=this;
if(typeof JZ!="undefined")
{
switch(KB)
{
case"nHeight":

var Bi=ae.S("_menuall_");
Bi.style.height=typeof JZ=="number"?
(JZ-12+'px'):JZ;

break;
case"nX":
ae.cR.nArrowPos&&(JZ-=ae.cR.nArrowPos);
break;
case"nY":
ae.cR.nArrowPos&&(JZ+=12);
break;
}
return callBack.call(ae,ax.option,[KB,JZ]);
}
else
{
var hy=callBack.call(ae,ax.option,[KB]);
switch(KB)
{
case"nX":
ae.cR.nArrowPos&&(hy+=ae.cR.nArrowPos);
break;
case"nY":
ae.cR.nArrowPos&&(hy-=12);
break;
}
return hy;
}
}


};
},
{



makeMenuItem:function(bED,bqO)
{
var bm=[];
for(var aD=0,_nLen=bqO?Math.min(bED.length,bqO.length):bED.length;aD<_nLen;aD++)
{
bm.push({
sId:bqO?bqO[aD]:aD,
sItemValue:bED[aD]
});
}
return bm;
},
bN:
{
CB:TE([
'$@$if($nArrowPos$>0)$@$',
'<span class="arrow" style="left:$nArrowPos$px;"></span>',
'$@$endif$@$',
'<div style="margin:0pt;">',
'<div class="menu_base">',
'<div class="menu_bd">',

'<div id="_menuall_"',
'style="overflow-y:auto;$@$if(isNaN($mwidth$))$@$width:$@$if(gbIsIE&&$sWidthDetect$!="float")$@$$nMinWidth$px;$@$else$@$auto$@$endif$@$;$@$else$@$overflow-x:hidden;width:$mwidth$px;$@$endif$@$',
'$@$if($mheight$)$@$height:$mheight$$@$endif$@$$@$if(!isNaN($mheight$))$@$px$@$endif$@$;">',
'$@$for($oItems$)$@$',
'$@$sec item$@$',
'<div id="_menuitem_$sId$" itemid="$sId$" class="menu_item$@$if($bDisSelect$)$@$_nofun$@$endif$@$"',

'style="height:$nHeight$$@$if(!isNaN($nHeight$))$@$px$@$endif$@$;line-height:$nHeight$$@$if(!isNaN($nHeight$))$@$px$@$endif$@$;$sStyle$" onclick=";">$sItemValue$</div>',
'$@$endsec$@$',
'$@$endfor$@$',
'</div>',
'<div id="_foot_"',
'style="overflow-y:auto;$@$if(isNaN($mwidth$))$@$width:$@$if(gbIsIE)$@$$nMinWidth$px;$@$else$@$auto$@$endif$@$;$@$else$@$overflow-x:hidden;width:$mwidth$px;$@$endif$@$',
'padding-top:3px;border-top:1px solid #ccc;$@$if(!$oFootItems$)$@$display:none;$@$endif$@$height:auto;">',
'$@$for($oFootItems$)$@$',
'<div id="_menuitem_$sId$" itemid="$sId$" class="menu_item$@$if($bDisSelect$)$@$_nofun$@$endif$@$"',
'style="height:$nHeight$px;line-height:$nHeight$px;" onclick=";">$sItemValue$</div>',
'$@$endfor$@$',
'</div>',
'$@$if($nArrowPos$>0)$@$',
'<a class="btn_close" qmmenuopt="close"  onmousedown="return false;"></a>',
'$@$endif$@$',
'</div>',
'</div>',
'</div>'])
}
}
);







































function QMSelect(ag)
{
this.constructor=arguments.callee;
this.aFv(ag).BH();
}



QMSelect.prototype=
{





get:function(dD)
{
var ae=this;
switch(dD=dD||1)
{
case 1:
case 2:
return ae.aEN[dD==1?"sItemValue":"sId"];
case 8:
return S(ae.fcX,ae.bE);
case"menu":
return ae.Dl;
}
},







set:function(bK,dD)
{
var ae=this,
_oItem=ae.aGO(bK,dD);
if(!_oItem.dXT)
{
S(ae.cR.sId,ae.bE).innerHTML=(ae.aEN=_oItem).sItemValue;
}
return ae;
},







update:function(ag)
{
var ae=this;
ae.ze(ag,ae.cR);





ae.ze(ag.oMenu,ae.cR.oMenu);

ae.cR=ag;
ae.aEN=ae.aGO(ag.sDefaultId,2,1);
ae.BH().set(ag.sDefaultId,2);
},




aGO:function(bK,dD,abw)
{
var aX=(dD==2)?"sId":"sItemValue",
aM=this.cR,
_oItem,
bm=aM.oMenu.oItems;
if(aM.oMenu.oFootItems)
{
bm=bm.concat(aM.oMenu.oFootItems);
}
for(var aD=0,bV=bm.length;aD<bV;aD++)
{
if(bm[aD].sId||bm[aD].sId===0)
{
if(bm[aD][aX]==bK)
{
return bm[aD];
}
else if(abw&&!_oItem)
{
_oItem=bm[aD];
}
}
}
return _oItem||{sItemValue:aM.sDefaultItemValue,dXT:1};
},


ze:function(ag,NC,aci)
{
for(var i in NC)
{
if(aci||typeof(ag[i])=="undefined"||ag[i]==null)
{
ag[i]=NC[i];
}
}
return ag;
},

aFv:function(ag)
{
var ae=this;
ae.bE=ag.oContainer.ownerDocument.parentWindow||ag.oContainer.ownerDocument.defaultView;

ae.ze(ag,{
sDefaultItemValue:"",
sId:QMSelect.bN.dQC+Math.random()
});
ae.cR=ag;
ae.aEN=ae.aGO(ag.sDefaultId,2,!ag.sDefaultItemValue);

return this;
},

BH:function()
{
var _oTop=getTop(),
ae=this,
aM=ae.cR,
ru=S(aM.sId,ae.bE);
if(!ru)
{
if(aM.sName)
{
insertHTML(aM.oContainer,"beforeEnd",
QMSelect.bN.dYy.replace(aM)
);
}

insertHTML(aM.oContainer,"beforeEnd",
QMSelect.bN.djT.replace(
extend(aM,{
content:ae.aEN.sItemValue,
images_path:getPath("image")
})
)
);


}
if(!(ru=S(aM.sId+"_div",ae.bE)))
{

return;
}

ae.ze(aM.oMenu,
{
oEmbedWin:ae.bE,

sId:"select",

nWidth:ru.clientWidth+3,
nMinWidth:ru.clientWidth+3,
onitemclick:function(aG)
{
if(aM.sName)
{
S(aM.sName,ae.bE).value=aG;
}
if(!callBack.call(ae,aM.onselect,[ae.aGO(aG,2)]))
{
ae.aEN=ae.aGO(aG,2);
ae.set(aG,2);
}
callBack.call(ae,aM.onchange,[ae.aGO(aG,2)])
},
onshow:function()
{
var aT=ae.aEN.sId;
if(aT||aT===0)
{
this.selectItem(aT);
}
},
onload:function()
{

var tV=this,
_oPos=calcPos(ru),
agb=bodyScroll(ae.bE,'clientHeight'),
OM=bodyScroll(ae.bE,'scrollTop'),
qm=agb+OM;

callBack.call(ae,aM.onafteropenmenu,[tV,ru]);

var cF=parseInt(tV.option("nHeight")),
bY=_oPos[2],
bDi=ru.offsetHeight,
Iw=bY-cF-bDi;

if(aM.oMenu.bAutoItemView)
{
var dTr=agb/2+OM,
kL;

if(bY<dTr)
{

kL=Math.floor((qm-bY)*0.66);
}
else if(bY+cF<qm)
{

kL=cF;
}
else
{

kL=Math.floor((agb-(qm-bY+bDi))*0.66);
bY=bY-Math.min(cF,kL)-bDi;
}
if(cF>kL)
{
tV.option("nHeight",kL);
}
}
else if(Iw>0&&bY+cF>qm)
{
bY=Iw;
}
tV.option("nX",_oPos[3]).option("nY",bY);
}
}
);

addEvent(ae.bE.document.body,(gbIsIE?"mousewheel":"DOMMouseScroll"),function()
{
_oTop.QMMenu("select","close");
}
);

ru.onclick=function()
{
callBack.call(ae,aM.onbeforeopenmenu,[aM.oMenu]);
ae.Dl=new _oTop.QMMenu(aM.oMenu);
};

return ae;
}
};

QMSelect.bN=
{
djT:T(
[
'<div id="$sId$_div" class="bd" unselectable="on" onmousedown="return false;" style="border-width:1px 2px 2px 1px;cursor:pointer;width:$nWidth$px;padding:1px 1px 1px 2px;background:#fff;float:left;$sStyle$">',
'<div class="attbg" style="width:16px;height:18px;overflow:hidden;text-align:center;float:right;"><img src="$images_path$webqqshow_on0aa5d9.gif" align="absmiddle" style="margin:3px 0 0 0;" /></div>',
'<div id="$sId$" class="txtflow" style="padding-left:3px;padding-left:3px!important;line-height:16px;height:18px;">$content$</div>',
'</div>'
]
),
dYy:T(
'<input type="hidden" id="$sName$" name="$sName$" value="$sDefaultId$"/>'
),
dQC:"QmCs_2_"
};








































var QMAutoComplete=inherit("QMAutoComplete",Object,
function(ax)
{
return{

$_constructor_:function(ag)
{
this.aFv(ag);
},






show:function(aj)
{
var ae=this;
ae.nf=aj;
return ae.eH();
},
close:function()
{
var ae=this;
ae.Dl&&ae.Dl.hide();
return ae;
},
isShow:function()
{
var hH=this.Dl;
return hH&&hH.isShow();
},
getSelection:function()
{
return this.nf[this.Dl.getSelectItemId()];
},









setHeader:function(cP)
{
var hH=this.Dl;
return hH&&hH.setHeader(cP);
},

aFv:function(ag)
{
var ae=this,
bC=ae.Hj=ag.oInput;

ae.bAD=ag.oPosObj||bC;
ae.bE=ae.bAD.ownerDocument.parentWindow
||ae.bAD.ownerDocument.defaultView;
ae.nf=null;
ae.Dl=null;
ae.bDo=ag.defaultValue||"";
ae.cDd=!(ag.notSupportKey||0);

ae.jV=ag.type||"";

bC.setAttribute("autocomplete","off");


ae.bdJ=ag.sUrl;
ae.dbS=ag.ondata;

ae.Nk=ae.bdJ?500:20;
ae.Nk=(typeof ag.nDelay=="number")?
ag.nDelay:ae.Nk;

ae.dGg=ag.ongetdata;
ae.Oi=ag.onselect;
ae.asB=ag.onclick;
ae.bvG=ag.onkeydown;
ae.dRn=ag.ontouchstart;

addEvents(bC,
{
keydown:ae.lw(ae.aGW),
keypress:ae.lw(ae.aTE),
keyup:ae.lw(ae.aRC),
focus:ae.lw(ae.va),
blur:ae.lw(ae.aqK)
}
);

ae.Dl=new QMAutoComplete.dVT(
{
sId:unikey(),
oItems:[],
supportKey:ae.cDd,
oEmbedWin:ae.bE,
nWidth:ag.nWidth||"auto",
nMinWidth:ag.nMinWidth||100,
nItemHeight:ag.nItemHeight||21,
nMaxItemView:ag.nMaxItemView||0,
type:ag.type,
oClass:ag.oClass,
bDisplay:false,
onselect:function(aG)
{
callBack.call(ae,ae.Oi,[ae.nf[aG]]);
},
onclick:function(_aoEvent,aG)
{
callBack.call(ae,ae.asB,[_aoEvent,ae.nf[aG]]);
},
ontouchstart:function(_aoEvent)
{
callBack.call(ae,ae.dRn,[_aoEvent]);
}
}
);
return ae.aVo();
},
lw:function(fN)
{
var ae=this;
return function(_aoEvent)
{
return fN.call(ae,_aoEvent);
};
},
aTE:function(_aoEvent)
{
if(gbIsOpera&&_aoEvent.keyCode==13)
{
preventDefault(_aoEvent);
}
},
aRC:function(_aoEvent)
{
if(!_aoEvent.ctrlKey)
{
var dG=_aoEvent.keyCode,
ae=this;
if(!(dG==38||dG==40||(dG==13&&ae.cwG!=229)||dG==27))
{
ae.bkx&&clearTimeout(ae.bkx);
ae.bkx=setTimeout(function()
{

if(ae.bdJ)
{
var Ah=trim(ae.Hj.value);
if(Ah=="")
{
ae.close();
}
else
{
Ah=encodeURIComponent(Ah);
QMAjax.send([ae.bdJ,"&resp_charset=UTF8&q=",Ah].join(""),
{
method:"get",
onload:function(aV,bQ)
{
if(aV)
{
ae.nf=ae.dbS.call(ae,bQ);
ae.eH().bkx=0;
}




}
}
);
}
}
else
{
ae.nf=ae.dGg(ae.Hj,dG);
ae.eH().bkx=0;
}
},
ae.Nk
);
}
}
},
aGW:function(_aoEvent)
{
var ae=this,
dG=_aoEvent.keyCode;
callBack.call(ae,ae.bvG,[_aoEvent,1]);


ae.cwG=dG;
if(ae.isShow()&&this.cDd)
{
switch(dG)
{
case 13:
callBack.call(ae,ae.Oi,[ae.getSelection()]);
ae.close();
preventDefault(_aoEvent);
break;
case 38:
ae.Dl.selectItem(-1);
preventDefault(_aoEvent);
break;
case 40:
ae.Dl.selectItem(1);
preventDefault(_aoEvent);
break;
case 9:
callBack.call(ae,ae.Oi,[ae.getSelection()]);
ae.close();

break;
case 27:


ae.close();
preventDefault(_aoEvent);
break;
}
}
callBack.call(ae,ae.bvG,[_aoEvent,0]);
},
va:function(_aoEvent,avd)
{
var ae=this;
ae.Su=true;
avd&&ae.Hj.focus();
return ae.aVo();
},
aqK:function(_aoEvent)
{
var ae=this;
ae.Su=false;
setTimeout(function()
{
!ae.Su&&
ae.close().aVo();
},
20
);
},
aVo:function()
{
var ae=this;
if(ae.bDo)
{
var nm=ae.Hj,
bM=nm.value;
if(ae.Su)
{
if(bM==ae.bDo)
{
var cI=nm.className.replace(/graytext/ig,"");
if(this.jV=="rss")
{
cI=cI.replace(/textInput/ig," textInput2");
}
nm.className=cI;
nm.value="";
}
}
else
{
if(bM=="")
{
var cI=(this.jV=="rss"?nm.className.replace(/textInput2/ig," textInput"):nm.className)+" graytext";
nm.className=cI;
nm.value=ae.bDo;
}
}
}
return ae;
},
eH:function()
{
var ae=this;
if(!ae.nf||ae.nf.length==0)
{
ae.close();
}
else
{
var _oPos=calcPos(ae.bAD);
ae.Dl.setContent(
{
oItems:ae.nf
}
).option("nX",_oPos[3]).option("nY",_oPos[2]);
}
return ae;
}
}
}
);

QMAutoComplete.dVT=inheritEx("QMAutoCompleteMenu",QMPanel,
function(ax)
{
return{
ard:function(cP)
{
return cP;
},

BF:function(ag)
{
callBack.call(this,ax.BF,[ag]);

if(ag.supportKey)
{
this.bOi(this.vt=0);
}
},

mj:function()
{
var aM=this.cR,
ae=this,
Bi=this.S("_menuall_"),
TR=this.S("_title_"),
cBY=function(_aoEvent){
var _aoEvent=_aoEvent||aM.oEmbedWin.event,
aB=getEventTarget(_aoEvent);
while(aB&&aB!=Bi&&aB.parentNode!=Bi)
{
aB=aB.parentNode;
}
return aB;
};

if(aM.supportKey)
{
Bi.onmouseover=function(_aoEvent){


if(now()-(ae.dGK||0)>500)
{
var aB=cBY(_aoEvent),
xZ=parseInt(aB.id.substr(ae.Md.length+1));
if(!isNaN(xZ))
{
ae.bOi(xZ);
}
}
};
TR.onclick=function(_aoEvent){
var _aoEvent=_aoEvent||aM.oEmbedWin.event;
callBack.call(ae,aM.onclick,[_aoEvent,""]);
};
Bi.onclick=function(_aoEvent){
var aB=cBY(_aoEvent),
bp=aB.getAttribute("key");
callBack.call(ae,aM.onclick,[_aoEvent,bp]);
if(bp)
{
callBack.call(ae,aM.onselect,[bp]);
setClass(aB,"menu_item");
if(aM.type!="rss")
{
ae.hide();
}
}
};
}

addEvents(this.rw,
{
mousedown:preventDefault,
touchstart:function(_aoEvent)
{
callBack.call(ae,aM.ontouchstart,[_aoEvent]);
}
}
);
},

afu:function(ag)
{
var bm=ag.oItems,
RW=(ag.nItemHeight||21)*(ag.nMaxItemView||bm.length);

this.ze(ag,
{
mheight:RW,
nWidth:"auto",
nHeight:RW,
nZIndex:1121
}
);


this.ze(ag,{sStyle:"background:#fff"},true);
return callBack.call(this,ax.afu,[ag]);
},







crI:function(ag)
{
var bm=ag.oItems,
bi=[],
aM=this.cR,
kb=(aM&&aM.oClass&&aM.oClass.classnormal)?aM.oClass.classnormal:"menu_item";
this.bjQ=0;
for(var i=0,bV=bm.length;i<bV;i++)
{

bi.push('<div unselectable="on" style="height:',bm[i].nItemHeight||ag.nItemHeight,'px;" onclick=";" ');
var aT=bm[i].sId;
if(aT||aT===0)
{
bi.push('key="',i,'" id="',this.Md,'_',this.bjQ++,'" class="',kb,'" >');
}
else
{
bi.push('class="menu_item_onfun">');
}
bi.push(bm[i].sItemValue,'</div>');
}
return bi;
},


ahV:function(ag)
{

var bm=ag.oItems,
bi=[
'<div style="margin:0px;">',
'<div class="menu_base">',
'<div class="menu_bd" style="padding:0;">',
'<div unselectable="on" id="',this.Md,'__title_" style="white-space:nowrap;width:',ag.nMinWidth,'px;line-height:',ag.nItemHeight,'px;',(ag.header?'':'display:none;'),'">',ag.header,'</div>',
'<div unselectable="on" id="',this.Md,'__menuall_" style="overflow-y:auto;height:auto;line-height:',ag.nItemHeight,'px;width:'];


if(ag.nWidth=="auto")
{

bi.push(!getTop().gbIsIE?ag.nMinWidth+"px":"auto");
}
else
{

bi.push(ag.nWidth-(getTop().gbIsIE?0:2),"px;overflow-x:hidden;");
}
bi.push('">');
bi=bi.concat(this.crI(ag));
bi.push('</div></div></div></div>');
ag.sBodyHtml=bi.join("");

callBack.call(this,ax.ahV,[ag]);
},

bgm:function(aaj,bln)
{
var cDW=this.cR.nMaxItemView||this.cR.oItems.length,
Tq=this.bjQ<=cDW?"auto":this.cR.nItemHeight*cDW;
this.option("nHeight",Tq);
aaj.style.height=Tq=="auto"?"auto":Tq+"px";

if(this.cR.nWidth!="auto")
{
if(aaj.style.width!=this.cR.nWidth)
{
bln.style.width=aaj.style.width=this.cR.nWidth-(getTop().gbIsIE?0:2)+"px";
}
}
else
{
if(gnIEVer>6&&aaj.ownerDocument.documentElement.clientHeight)
{
bln.style.width=aaj.style.width="auto";
}

if(aaj.offsetWidth>10)
{
bln.style.width=aaj.style.width=
(Math.max(aaj.offsetWidth,bln.offsetWidth,this.cR.nMinWidth)
+(gbIsIE?(gnIEVer>6?18:0):aaj.offsetWidth-aaj.scrollWidth))+"px";
}

}
},

setHeader:function(cP)
{
if(cP)
{
this.S("_title_").innerHTML=this.ard(cP);
show(this.S("_title_"),1);
}
else if(cP=="")
{
show(this.S("_title_"),0);
}
},

setContent:function(ag)
{
var ae=this,
Bi=ae.S("_menuall_"),
TR=ae.S("_title_");

this.ze(ae.cR,ag,true);
if(ae.cR.nWidth=="auto")
{
TR.style.width=Bi.style.width=gbIsIE&&gnIEVer!=7?ae.cR.nMinWidth+"px":"auto";
}
ae.setHeader(ag.oItems.header);

Bi.innerHTML=ae.crI(ag).join("");
if(ae.cR.supportKey)
{
ae.selectItem(ae.vt=0);
}

ae.show();
ae.bgm(Bi,TR);
callBack.call(ae,ae.cR.onload,[ag]);

ae.dGK=now();

return ae;
},

selectItem:function(qg)
{
var ae=this,
yF=ae.bOi((ae.vt+qg+ae.bjQ)%ae.bjQ);

scrollIntoMidView(yF,ae.S("_menuall_"));



},

getSelectItemId:function()
{
var cAK=this.S(this.vt);
return cAK&&cAK.getAttribute("key");
},

bOi:function(cAq)
{
var yF=this.S(this.vt),
aM=this.cR,
kb=(aM&&aM.oClass&&aM.oClass.classnormal)?aM.oClass.classnormal:"menu_item",
dVu=(aM&&aM.oClass&&aM.oClass.classhigh)?aM.oClass.classhigh:"menu_item_high";

if(yF)
{
yF.className=kb;
}

if(yF=this.S(cAq))
{
yF.className=dVu;
this.vt=cAq;
}
return yF;
}
};
}
);
















function UQ(ag)
{
ag.bT.push('&t=mail_mgr2&resp_charset=UTF8&ef=js&sid=',getSid(),getTop().bnewwin?'&newwin=true':'');
QMAjax.send(ag.aO||'/cgi-bin/mail_mgr',{
content:ag.bT.join(""),
onload:function(aV,bQ,eQ){
var czf=bQ.indexOf(ag.Vr)>=0,
chT=bQ.indexOf("cgi exception")>=0;
if(aV&&(czf||chT))
{
var aE=evalValue(bQ);
if(chT)
{

showError(aE.errmsg,0,true);
}
else
{
ag.wZ(aE,bQ,eQ);
}
}
else if(ag.ys)
{
showError(ag.ys);
}
}
});
}

function setRollBack(bA,_asMsg)
{

if(bA&&bA>0)
{
setGlobalVarValue('DEF_ROLLBACK_ACTION',{
msg:_asMsg,
rbkey:bA
});
}
}

function getRollbackText(bA)
{
return bA&&bA>0?"&nbsp;<a href='#' style='color:white' onclick='getTop().rollback(2);return false;'>[\u64A4\u9500]</a>":"";
}














function setMailFilter(aQ,ag)
{

var bpG=true,
bw=ag.oMail,
_nLen=bw.length,
aWg=QMMailList.cnJ(ag),
diV=aWg[1],
bSD=aWg[0];

for(var i=_nLen-1;i>=0;i--)
{
var oi=bw[i].oChk;

if(oi&&/^[@C]/.test(oi.value))
{
bpG=false;
}
}

bpG=bpG&&ag.sFid==1&&_nLen>1&&bSD&&!/(10000|newsletter-noreply|postmaster)@qq.com/g.test(bSD);
if(!bpG)
{
return;
}

aQ.sEmail=bSD;
aQ.sNickname=htmlEncode(diV);
aQ.sFolderName=htmlEncode(aQ.sFolderName);

var bJf='\u8BBE\u7F6E\u8FC7\u6EE4\u89C4\u5219',
aRa="\u5DF2\u5C06\u90AE\u4EF6\u6210\u529F",
aSt="&fun=addfilter&t=foldermgr_json&resp_charset=UTF8&ef=js&sid="+getSid(),
aM=
({
move:{

mt:3,
aPD:aRa+"\u79FB\u52A8",
aSi:"\u81EA\u52A8\u79FB\u52A8\u5230\u6587\u4EF6\u5939 $sFolderName$ \u4E2D",
cC:T(aSt+'&action=move&sender=$sEmail$&folderid=$sFolderId$&oldmail=$oldmail$')
},
star:{

mt:2,
aPD:aRa+"\u6807\u661F",
aSi:"\u81EA\u52A8\u6807\u661F",
cC:T(aSt+'&action=star&sender=$sEmail$&oldmail=$oldmail$')
},
tag:{

mt:2,
aPD:aRa+"\u8BBE\u7F6E\u6807\u7B7E",
aSi:"\u81EA\u52A8\u8BBE\u7F6E $sTagName$ \u6807\u7B7E",
cC:T(aSt+'&action=tag&sender=$sEmail$&tagid=$sTagId$&oldmail=$oldmail$')
},
read:{

mt:1,
aPD:aRa+"\u6807\u4E3A\u5DF2\u8BFB",
aSi:"\u81EA\u52A8\u6807\u4E3A\u5DF2\u8BFB",
cC:T(aSt+'&action=read&sender=$sEmail$&oldmail=$oldmail$')
},
"delete":{

mt:4,
aPD:aRa+"\u6807\u4E3A\u5220\u9664",
aSi:"\u81EA\u52A8\u5220\u9664",
cC:T(aSt+'&action=delete&sender=$sEmail$&oldmail=$oldmail$')
}
})[aQ.sFilterType];


ossLog("realtime","all","stat=noting&locval=,,auto_filter_label,"+aM.mt);

confirmBox({
style:'cnfx_move',
confirmBtnTxt:'\u662F',
cancelBtnTxt:'\u5426',
recordInfo:'\u5BF9\u5386\u53F2\u90AE\u4EF6\u6267\u884C\u8BE5\u8FC7\u6EE4\u89C4\u5219',
enableRecord:true,
defaultChecked:true,
title:bJf,
msg:T([
aM.aPD,
'<div style="margin-top:6px;overflow:hidden;">\u60A8\u662F\u5426\u9700\u8981\u5EFA\u7ACB\u4E00\u4E2A\u8FC7\u6EE4\u89C4\u5219\uFF0C\u5C06 <b>$sNickname$</b> \u7684\u6765\u4FE1\uFF0C',aM.aSi,'\uFF1F</div>',
''
]).replace(aQ),
onreturn:function(rj,chQ,dIz){

if(rj)
{
aQ.oldmail=chQ?1:0;

QMAjax.send('/cgi-bin/foldermgr',{
content:aM.cC.replace(aQ),
onload:function(aV,qZ)
{
if(aV&&qZ.indexOf("addfilter")>0)
{
showInfo(bJf+"\u6210\u529F");
if(chQ)
{

reloadFrmLeftMain(false,true);
}
}
else
{
showError(bJf+"\u5931\u8D25");
}
}
});
}
}
});
return;
}



var QMMailList={};







































QMMailList.getCBInfo=function(aq,aI)
{
var bVi=true,
aE={
oMail:[],
oWin:aq,
sFid:aq.location.getParams()['folderid'],
bML:true
};

E(GelTags("input",S('list',aq)),function(bo)
{
if(bo.title=="\u9009\u4E2D/\u53D6\u6D88\u9009\u4E2D")
{

aE.oACB=bo;
}
else if(bo.type=="checkbox"&&bo.name=="mailid"&&(aI&&bo.value==aI||!aI&&bo.checked))
{
var lp=bo.value,
gn=bo.parentNode;
while(gn.tagName.toUpperCase()!="TABLE")
{
gn=gn.parentNode;
}

var Av=gn.rows[0].cells,
qh=Av[Av.length-1],
bjr=GelTags("input",qh)[0],
boQ=GelTags("td",GelTags('tr',qh)[0]),

bLy=boQ[boQ.length-1],
Ek=GelTags("table",qh),
Lj,
yI=[],
bw={};
for(var aD=0,_nLen=Ek.length;aD<_nLen;aD++)
{
if(Lj=Ek[aD].getAttribute("tagid"))
{
yI.push(Lj);
}
}

bw.sMid=lp;
bw.bSys=bjr&&{"s1bg":1}[bjr.className];
bw.bDft=bjr&&{"drifticon":1}[bjr.className];
bw.bUnr=bo.getAttribute("unread")=="true";
bw.bSubUnr=boQ[1].className=="new_g"&&GelTags("b",boQ[1]).length>0;
bw.bStar=bLy.className=="fg fs1";
bw.bTms=bo.getAttribute("isendtime")==1;
bw.oTagIds=yI;
bw.sSName=bo.getAttribute("fn");
bw.sSEmail=bo.getAttribute("fa");
bw.sColId=bo.getAttribute("colid");
var foC=bo.getAttribute("rf");



bw.oTable=gn;
bw.oStar=bLy;
bw.oChk=bo;
aE.oMail.push(bw);

var bSF=GelTags('div',qh);
for(var aD=0,_nLen=bSF.length;aD<_nLen;aD++)
{
if(bSF[aD].className=='TagDiv')
{
bw.oTCont=bSF[aD];
break;
}
}

}
bVi&&bo.type=="checkbox"&&bo.name=="mailid"&&!bo.checked&&(bVi=false);
});


aE.bSelectAll=bVi;
return aE;
};






QMMailList.selectedUI=function(ag)
{
var aA=getMainWin(),
czl={},
bqi=false;
if(aA.location.href.indexOf('/cgi-bin/mail_list')<0)
{
return;
}
for(var bw=ag.oMail,i=bw.length-1;i>=0;i--)
{
czl[bw[i].sMid]=1;
}
ag=ag||this.getCBInfo(aA);
E(SN("mailid",aA),function(bo)
{
if(bo.type=="checkbox")
{
var uy=bo.value in czl,
Tx=bo.getAttribute('unread')=='true'&&ag.sFid!=4,
gn=bo;
while(gn.tagName.toUpperCase()!="TABLE")
{
gn=gn.parentNode;
}

if(gn.style.backgroundColor!="")
{
gn.style.backgroundColor="";
}
setClass(gn,[Tx?"i F":"i M",uy?" B":""].join(""));

setClass(GelTags("table",gn)[0],Tx?"i bold":"i");


var azU=bo.getAttribute("isendtime"),
atc=bo.getAttribute("rf");

setClass(GelTags("div",gn.rows[0].cells[1])[1],
'cir '+((Tx?'Ru':'')||{0:'Rc',1:'Ti'}[azU]||{r:'Rh',f:'Rz'}[atc]||(Tx?'':'Rr'))
);

bo.checked=uy;
bqi=bqi||uy;

}
});
if(!bqi&&ag.oACB)
{

ag.oACB.checked=bqi;
}
};







QMMailList.cnJ=function(HW)
{
for(var bqV=null,bmr=null,bw=HW.oMail,i=bw.length-1;i>=0;i--)
{
var bO=bw[i],
jh=bO.sSName,
fd=bO.sSEmail;
if(bmr!=jh)
{
bmr=bmr===null?jh:'';
}
if(bqV!=fd)
{
bqV=bqV===null?fd:'';
}
}
return[bqV,bmr];
};





























function BaseMailOper(ag)
{
var ae=this;
ae.dN(ae.cR=ag);
}




BaseMailOper.ebo=function(ag)
{
var aGB=BaseMailOper,
aA=ag.oWin;
if(!aGB.getInstance(aA))
{
new aGB(ag);
}
return aGB.getInstance(aA);
};

BaseMailOper.getInstance=function(aq)
{
return aq["__gBmOi_"];
};

BaseMailOper.prototype={
dN:function(ag)
{
var ae=this,
aA=ag.oWin,
ja=aA.location,
fz=ja.href;
if(fz.indexOf("/cgi-bin/mail_list")>0)
{
ag.mnFolderType=0;
}
else if(fz.indexOf("t=readmail_conversation")>0)
{
ag.mnFolderType=2;
}
else if(fz.indexOf("readmail_group.html")>0)
{
ag.mnFolderType=3;
}
else
{

ag.mnFolderType=1;
}
ag.bAutoTag=ja.getParams()['folderid']==1||ag.sFolderid==1||ag.bAutoTag;
aA["__gBmOi_"]=ae;

return ae;
},

getConfig:function()
{
return this.cR;
},

setMailInfo:function(HW)
{
this.cR.bMB=HW;
},

getMailInfo:function()
{
return this.cR.bMB;
},







apply:function(kq,dOh)
{
var ae=this,
aM=ae.cR,
zk=aM.bMB,
aA=aM.oWin;







switch(kq)
{
case"mark":
case"move":
case"preview":
return false;
case"opennew":
if(zk.oMail.length==1)
{

var Rs=GelTags("table",zk.oMail[0].oTable)[0].parentNode.onclick.toString().split("{")[1].split("}")[0].replace(/event/ig,"{shiftKey:true}");
if(/\WRD/.test(Rs))
{
eval(Rs);
}
else
{
debug("opennew error");
}
}
break;
case"new":
configPreRmMail(zk,'moveMailJs');
moveMailJs('new','',zk.sFid,zk);
break;
case"delmail":

configPreRmMail(zk,'rmMail');
rmMail(0,zk);
break;
case'predelmail':
configPreRmMail(zk,'rmMail');
rmMail(1,zk);
break;
case'frwmail':


zk.oWin.FwMailML();
break;
case'spammail':

configPreRmMail(zk,'spammail');
reportSpamJson({bBlackList:true},zk);
break;
case"read":
case"unread":
setMailRead(kq=="unread",zk);
break;
case"star":
case"unstar":
starMail(kq=="star",zk);
break;
case"rmalltag":
QMTag.rmTag('',zk);
break;
case"newtag":
QMTag.newMailTag(zk);
break;
case'autotag':
QMTag.setMailAutoTag(zk);
break;
default:
if(/fid_(.+)/.test(kq))
{
configPreRmMail(zk,'moveMailJs');

var dYX=RegExp.$1;
moveMailJs(dYX,dOh,zk.sFid,zk);
}
else if(/tid_(.+)/.test(kq))
{

var Lj=RegExp.$1;
QMTag.setMailTag(Lj,zk);
}
break;
}
return true;
}
};















var QMTag={
cwo:"",
aXO:{},
bSt:[]
};






QMTag.set=function(yY,Ej)
{
var ae=this;
if(!Ej||Ej>ae.cwo)
{
Ej&&(ae.cwo=Ej);
ae.bSt=[];
ae.aXO={};

for(var aD=0,_nLen=yY.length;aD<_nLen;aD++)
{
var ux=yY[aD],
Lj=ux.id,
dHu;
if(Lj!=dHu)
{
ae.bSt.push(Lj);
ae.aXO[Lj]=ux;
ux.fmm=aD;
}
}
}
};

QMTag.get=function()
{
for(var eZ=[],ae=this,iY=ae.bSt,aD=0,_nLen=iY.length;aD<_nLen;aD++)
{
eZ.push(ae.aXO[iY[aD]]);
}
return eZ;
};





QMTag.setItem=function(jl,pc,bK)
{
var cNf=this.aXO;
if(cNf[jl])
{
cNf[jl][pc]=bK;
}
};

QMTag.getItem=function(jl,pc)
{
var ux=this.aXO[jl];

return ux&&pc?ux[pc]:ux;
};


QMTag.bkH=function(bQ)
{
try
{
var aE=eval(bQ),
bDj=aE.taglist;
aE.mailids.length--;
aE.taglist.length--;

bDj&&bDj.length&&QMTag.set(bDj,aE.timestamp);
}
catch(e)
{

}
return aE;
};

QMTag.setMailTag=function(jl,ag)
{
var bw=ag.oMail,
_nLen=bw.length,
eW=0,

bT=[],
cp=getMainWin(),
xe=isSelectAllFld(cp);

if(!_nLen)
{
return showError('\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6');
}

else if(xe)
{
var cX=awm(cp);

bT=['mailaction=',cX.type,'&fun=mail_flagtag&tagid=',jl];
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);
}
else
{
bT=['mailaction=mail_tag&fun=add&tagid=',jl];


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=23");
}
showSelectALL(cp,false);


for(var i=0;i<_nLen;i++)
{
var bO=bw[i],
bd=bO.sMid;

if(QMTag.addTagUI(bO.oTCont,jl,ag.sFid,bd,!ag.bML))
{
eW++;
bT.push('&mailid=',bd);
rdVer(bd,1);
QMMailCache.addData(bd,{addTagId:jl});
if(bO.bUnr)
{

var gX='tag_'+jl;
setTagUnread(gX,getFolderUnread(gX)+1);
if(!bO.oTagIds.length)
{
setTagUnread('tag',getFolderUnread('tag')+1);
}
}
}
}
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});

if(eW)
{
UQ({
bT:bT,
Vr:'mail_tag successful',
ys:'\u8BBE\u7F6E\u6807\u7B7E\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
var aE=QMTag.bkH(bQ),
aA=ag.oWin;


if(aA.QMReadMail)
{
aA.QMReadMail.modifyTag(jl,0);
}

if(_nLen>2)
{
setMailFilter({
sFilterType:"tag",
sTagId:jl,
sTagName:QMTag.getItem(jl).name
},ag
);
}
xe&&reloadLeftWin();
return;
}
});
}
};






QMTag.newMailTag=function(ag)
{
ag=ag||{};
promptFolder({
type:'tag',
onreturn:function(fk){
var bw=ag&&ag.oMail,
_nLen=bw&&bw.length,
bT=[],
cp=getMainWin(),
xe=isSelectAllFld(cp);

if(xe)
{
var cX=awm(cp);

bT=['mailaction=',cX.type,'&fun=mail_flagtag_new&tagname=',encodeURI(fk)];
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);
}
else
{
bT=['&mailaction=mail_tag&fun=add&tagname=',encodeURI(fk)];


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=23");
}
showSelectALL(cp,false);


for(var i=0;i<_nLen;i++)
{
bT.push('&mailid=',bw[i].sMid);
}

UQ({
bT:bT,
Vr:'mail_tag successful',
ys:'\u521B\u5EFA\u6807\u7B7E\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
showInfo("\u6807\u7B7E\u521B\u5EFA\u6210\u529F");
reloadLeftWin();
var cqI=ag&&ag.oWin.QMReadMail;

if(cqI)
{

rdVer(cqI.getMailId(),1);
return reloadFrmLeftMain(true,true);
}
else if(!ag)
{

return reloadFrmLeftMain(true,true);
}

var aE=QMTag.bkH(bQ);
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});

for(var i=0;i<_nLen;i++)
{
var bO=bw[i];
QMTag.addTagUI(bO.oTCont,aE.newtag.id,ag.sFid,bO.sMid,!ag.bML);
}

reloadFrmLeftMain(true,false);
xe&&reloadLeftWin();
}
});
}
});

};


QMTag.dvV=function(dBX,dCN)
{
confirmBox({
title:"\u6536\u4FE1\u89C4\u5219",
msg:"\u5BF9\u4E8E\u6536\u4EF6\u7BB1\u4E2D\u7B26\u5408\u6761\u4EF6\u7684\u5DF2\u6709\u90AE\u4EF6\uFF0C\u60A8\u662F\u5426\u4E5F\u8981\u6807\u4E0A\u6B64\u6807\u7B7E\uFF1F",
confirmBtnTxt:'\u662F',
cancelBtnTxt:'\u5426',
onreturn:function(aV)
{
if(aV)
{
UQ({
bT:['&fun=AutoTag&mailaction=mail_filter&filterid=',dBX],
Vr:'mail_tag successful',
ys:'\u64CD\u4F5C\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
var aE=eval(bQ);
if(aE.count)
{
reloadFrmLeftMain(1,1);
}
return showInfo(
T(aE.count?"\u64CD\u4F5C\u6210\u529F\uFF0C\u6807\u8BB0\u4E86$count$\u5C01\u90AE\u4EF6\u3002<a href='/cgi-bin/mail_list?sid=$sid$&folderid=all&tagid=$tagid$'  style='color:white' onclick='getTop().hiddenMsg();' target='mainFrame'>[\u67E5\u770B]</a>":"\u64CD\u4F5C\u6210\u529F\uFF0C\u60A8\u6CA1\u6709\u9700\u8981\u79FB\u52A8\u6216\u6807\u8BB0\u7684\u90AE\u4EF6\u3002").replace(aE),
30000);
}
});
}
else
{
reloadFrmLeftMain(1,!dCN);
}
}
});
};






QMTag.setMailAutoTag=function(ag)
{
var bw=ag.oMail,
anZ=false,
cKc=/[~!#\$%\^&\*\(\)=\+|\\\[\]\{\};\':\",\?\/<>]/ig,
bT=['&mailaction=mail_tag&Fun=AutoTag'];


if(isSelectAllFld(getMainWin()))
{
return showError('\u5168\u9009\u6587\u4EF6\u5939\u4E0D\u80FD\u65B0\u5EFA\u81EA\u52A8\u6807\u7B7E');
}

for(var aD=bw.length-1;aD>=0;aD--)
{
if(bw[aD].bSys)
{
return showError('\u7CFB\u7EDF\u90AE\u4EF6\u4E0D\u80FD\u65B0\u5EFA\u81EA\u52A8\u6807\u7B7E');
}
bT.push('&mailid=',bw[aD].sMid);
}
confirmBox(
{
mode:"prompt",
height:160,
title:'\u65B0\u5EFA\u81EA\u52A8\u6807\u7B7E',
msg:['<div style="width:100%;margin:10px;"><b>\u5BF9\u4E8E\u53D1\u4EF6\u4EBA</b><input type="text" id="addr" style="width:300px;margin-left:60px;"/></div>',
'<div style="margin:10px;"><b>\u6765\u4FE1\u81EA\u52A8\u6807\u4E3A\u6807\u7B7E</b><input type="text" id="name" style="width:300px;margin-left:15px;"/></div>',
'<div class="graytext" style="width:450px;margin:10px;">\u8BE5\u53D1\u4EF6\u5730\u5740\u7684\u6765\u4FE1\uFF0C\u4F1A\u81EA\u52A8\u52A0\u4E0A\u6807\u7B7E\uFF0C\u4FBF\u4E8E\u60A8\u8BC6\u522B\u548C\u7BA1\u7406\u90AE\u4EF6\u3002</div>'].join(''),
onload:function()
{
var ae=this;
addEvents([ae.S("addr"),ae.S("name")],
{
keydown:function(_aoEvent)
{
if(_aoEvent.keyCode==13)
{
anZ=true;
ae.close();
}
}
}
);
},
onshow:function()
{
var cG=this,
bO=ag.bMB,
aWg=QMMailList.cnJ(ag),
ya=aWg[1],
fd=aWg[0];

if(!ya||!fd)
{
cG.S('addr').focus();
}
else
{
cG.S('addr').value=fd.split(',')[0];
cG.S('name').value=trim(htmlDecode(ya).split(/[,@]/)[0].replace(cKc,''))+"\u7684\u6765\u4FE1";
}
},
onreturn:function(aV)
{

var cG=this,
de=trim(cG.S('addr').value),
aP=trim(cG.S('name').value);
if(!aV&&!anZ)
{
return;
}
if(!de)
{
return showError('\u8BF7\u8F93\u5165\u53D1\u4EF6\u4EBA\u540D\u79F0\u6216\u5730\u5740');
}
var _nLen=getAsiiStrLen(aP);
if(_nLen==0||_nLen>50)
{
return showError(_nLen?"\u6807\u7B7E\u540D\u79F0\u592A\u957F\uFF0C\u8BF7\u4F7F\u7528\u5C11\u4E8E50\u4E2A\u5B57\u7B26(25\u4E2A\u6C49\u5B57)\u7684\u540D\u79F0":'\u8BF7\u8F93\u5165\u6807\u7B7E\u540D\u79F0');
}
if(cKc.test(aP))
{
return showError('\u6807\u7B7E\u540D\u79F0\u4E0D\u80FD\u5305\u542B ~!#$%^&*()=+|\\[]{};\':",?/<> \u7B49\u5B57\u7B26');
}

bT.push('&sender=',encodeURI(de),'&tagname=',encodeURI(aP));
UQ({
aO:'/cgi-bin/setting2',
bT:bT,
Vr:'mail_tag successful',
ys:'\u8BBE\u7F6E\u81EA\u52A8\u6807\u7B7E\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
showInfo("\u8BBE\u7F6E\u81EA\u52A8\u6807\u7B7E\u6210\u529F\uFF0C\u901A\u8FC7\u6536\u4FE1\u89C4\u5219\uFF0C\u6765\u4FE1\u5C06\u81EA\u52A8\u6807\u4E0A\u6807\u7B7E\u3002");

var aA=ag.oWin,
aE=QMTag.bkH(bQ);

if(!ag.bML&&aA.QMReadMail)
{

rdVer(aA.QMReadMail.getMailId(),1);

}
else
{
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});
for(var i=bw.length-1;i>=0;i--)
{
var bO=bw[i];
QMTag.addTagUI(bO.oTCont,aE.newtag.id,ag.sFid,bO.sMid,!ag.bML);
}
}

QMTag.dvV(aE.filterid,ag.bML);
return;
}
});
}
}
);


};








QMTag.rmTag=function(jl,ag)
{
var bw=ag.oMail,
_nLen=bw.length,
eW=0,
bT=[],
cp=getMainWin(),
xe=isSelectAllFld(cp);

if(!_nLen)
{
return showError('\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6');
}
else if(xe)
{
var cX=awm(cp);

bT=['mailaction=',cX.type,'&fun=mail_flaguntag'];
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);
}
else
{
bT=['&mailaction=mail_tag&fun=del'];


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=23");
}
showSelectALL(cp,false);

if(jl)
{
bT.push('&tagid=',jl);
}


for(var i=bw.length-1;i>=0;i--)
{
if(QMTag.rmTagUI(bw[i].oTCont,jl))
{
eW++;
var bO=bw[i],
bd=bO.sMid;
bT.push('&mailid=',bd);
rdVer(bd,1);
QMMailCache.addData(bd,{removeTagId:jl});

if(bO.bUnr)
{

var yI=jl?bO.oTagIds:[jl];

if(jl)
{
var gX='tag_'+jl;
setTagUnread(gX,getFolderUnread(gX)-1);
}
else
{
E(bO.oTagIds,function(sp){
var gX='tag_'+sp;
setTagUnread(gX,getFolderUnread(gX)-1);
});
}

if(bO.oTagIds.length==1||!jl)
{
setTagUnread('tag',getFolderUnread('tag')-1);
}
}
}
}
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});

if(eW)
{
UQ({
bT:bT,
Vr:"mail_tag successful",
ys:T(['\u79FB\u9664\u6807\u7B7E\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5']),
wZ:function(aE,bQ,eQ)
{
QMTag.bkH(bQ);
























xe&&reloadLeftWin();
}
});
}
};










QMTag.rmTagUI=function(aQA,jl)
{
if(jl)
{
for(var Ek=GelTags("table",aQA),aD=Ek.length-1;aD>=0;aD--)
{
if(Ek[aD].getAttribute("tagid")==jl)
{
removeSelf(Ek[aD]);
return true;
}
}
}
else
{
aQA.innerHTML='';
return true;
}
return false;
};



QMTag.addTagUI=function(aQA,jl,ec,aI,dxT)
{
for(var Nf=GelTags("table",aQA),aD=Nf.length-1;aD>=0;aD--)
{
if(Nf[aD].getAttribute('tagid')==jl)
{
return false;
}
}

var bq=
TE([
'<table cellspacing="0" cellpadding="0" border="0" class="tagleftDiv flagbg$flagbg$" tagid="$id$">',
'<tr>',
'<td class="falg_rounded">\n',
'</td>',
'<td colspan="2">\n',
'</td>',
'<td class="falg_rounded">\n',
'</td>',
'</tr>',
'<tr>',
'<td>\n',
'</td>',
'<td class="tagbgSpan" tid2="$id$">',
'<span>\u4E2Da</span>$name$<span>\u4E2Da</span>',
'$@$if($t$=="mail_list")$@$<div class="closeTagSideDiv flagbg$flagbg$" style="display:none" title="\u53D6\u6D88\u6B64\u6807\u7B7E" tid2="$id$">&nbsp;&nbsp;&nbsp;</div>$@$endif$@$',
'</td>',
'$@$if($t$!="mail_list")$@$<td title="\u53D6\u6D88\u6B64\u6807\u7B7E" class="closeTagDiv $disclose$" tid2="$id$">&nbsp;</td>$@$endif$@$',
'<td>\n',
'</td>',
'</tr>',
'<tr>',
'<td class="falg_rounded">\n',
'</td>',
'<td colspan="2">\n',
'</td>',
'<td class="falg_rounded">\n',
'</td>',
'</tr>',
'</table>'
]).replace(extend({
t:dxT?"readmail":"mail_list",
folderid:ec,
mailid:aI||""
},QMTag.getItem(jl)));

insertHTML(aQA,"beforeEnd",bq);
return true;
};






QMTag.showTagClose=function(aKh,fA)
{
function eH(aKh,fA)
{
try
{
for(var nh=GelTags("div",aKh),aD=nh.length-1;aD>=0;aD--)
{
if(nh[aD].className.indexOf("closeTagSideDiv")>-1)
{
show(nh[aD],fA);
return;
}
}
}
catch(e)
{
}
}

var ae=arguments.callee;

if(ae.uT)
{
clearTimeout(ae.uT);
}
if(ae.aqD!=aKh)
{
eH(ae.aqD,0);
}
ae.aqD=aKh;
ae.uT=setTimeout(function()
{
eH(aKh,fA);
},
fA?500:100);
};


function colorTag(_aoEvent,jl,aq)
{
_aoEvent=_aoEvent||aq.event;
stopPropagation(_aoEvent);
preventDefault(_aoEvent);

var aT="tag"+jl,
cnW=QMMenu(aT,"isClose");
if(cnW===false)
{
return;
}

var ah=getEventTarget(_aoEvent),
bvh=function(_asClass)
{
return/\bflagbg(\d+)\b/.test(_asClass)&&RegExp.$1;
},
clc=bvh(ah.className),

ctN=T(['<div class="flag_menu_item"><div id="flagbg$flagbg$" class="flagbg$flagbg$"></div></div>']),
aLG=[
['0','1','2','3','4'],
['5','6','7','8','9'],
['11','12','13','14','15'],
['16','17','18','19','20'],
['21','22','23','24','25'],
['26','27','28','29','30'],
['31','32','33','34','35']
],
beo=
{
nHeight:5,
sItemValue:'<div style="height:1px; overflow:hidden;"></div>'
},
bm=[];

bm.push(beo);

for(var aD=0,Kp=aLG.length;aD<Kp;aD++)
{
for(var nh=[],fy=0,Nx=aLG[aD].length;fy<Nx;fy++)
{
nh.push(ctN.replace({
flagbg:aLG[aD][fy]
}));
}
bm.push({
nHeight:24,
sItemValue:nh.join("")
});
if(aD==1)
{
bm.push(beo);
}
}

bm.push(beo);

new QMMenu({
oEmbedWin:aq,
sId:aT,
nWidth:148,
oItems:bm,

onshow:function()
{




},
onload:function()
{
var tV=this,
_oPos=calcPos(ah),
cF=parseInt(tV.option("nHeight")),
bY=_oPos[2],

qm=bodyScroll(aq,'clientHeight')+bodyScroll(aq,'scrollTop'),
Iw=bY-cF-ah.clientHeight;
if(Iw>0&&bY+cF>qm)
{
bY=Iw;
}
tV.option("nX",_oPos[3]).option("nY",bY);

var Bi=tV.S("_menuall_"),
aZB=null;
function aaM(_aoEvent)
{
var aB=getEventTarget(_aoEvent);
while(aB&&aB!=Bi)
{
if(aB.id.indexOf("flagbg")>-1)
{
return aB;
}
aB=aB.parentNode;
}
return null;
}

addEvents(Bi,
{
mousemove:function(_aoEvent)
{
var aB=aaM(_aoEvent);
if(aZB)
{
aZB.parentNode.style.borderColor="#fff";
}
if(aZB=aB)
{

aB.parentNode.style.borderColor="#aaa";
}
},
click:function(_aoEvent)
{
var aB=aaM(_aoEvent);
if(aB)
{
colorTag.dIp(jl,bvh(aB.className),clc,ah,aq);

tV.close();
}
}
}
);
}
});
}


colorTag.dIp=function(jl,bWc,ecA,ah,aq)
{
var fq='\u9009\u62E9\u6807\u7B7E\u989C\u8272\u6210\u529F';
if(bWc==ecA)
{
return showInfo(fq);
}

QMAjax.send('/cgi-bin/foldermgr',{
content:['&fun=setcolor&sid=',getSid(),"&tagid=",jl,"&flagbg=",bWc].join(""),
onload:function(aV,bQ,eQ){
var aO=aq.location.href,
doj=getMainWin().location.href;

if(aV&&bQ.indexOf(fq)>0)
{



setClass(ah,ah.className.replace(/\bflagbg\d+\b/i,"flagbg"+bWc));

if(aO.indexOf('t=folderlist_setting')>-1)
{
reloadLeftWin();
}
else
{

if(/cgi-bin\/(mail_list|readmail)|t=folderlist_setting/.test(doj))
{
reloadFrmLeftMain(false,true);
}
}
return showInfo(fq);
}
var wy=getErrMsg(eQ,'msg_txt');
showError(wy||"\u6807\u7B7E\u989C\u8272\u8BBE\u7F6E\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5");
}
});
};







QMTag.readclose=function(_aoEvent,ag)
{
var aB=getEventTarget(_aoEvent),
cI;
while(aB)
{
cI=aB.className;
if(/closeTag(Side)?Div/.test(cI))
{


QMTag.rmTag(aB.getAttribute('tid2'),ag);
return true;
}
else if(cI=='tagbgSpan')
{

readTag(aB.getAttribute('tid2'),ag.oWin,ag.sFid);
return true;
}
aB=aB.parentNode;
}
return false;
};


function readTag(jl,aq,nx)
{
nx=nx>100?nx:"all";
goUrlMainFrm(T('/cgi-bin/mail_list?sid=$sid$&tagid=$tagid$&folderid=$folderid$&page=0').replace({
tagid:jl,
folderid:nx,
sid:getSid()
}));




}














function setMailRead(xm,ag)
{
var bw=ag.oMail,
_nLen=bw.length,
Fc=0,
blM=xm?1:-1,
bT=[],
cp=getMainWin(),
xe=isSelectAllFld(cp),
gX=ag.sFid;

if(!_nLen)
{
return showError('\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6');
}

else if(xe)
{
var cX=awm(cp),
aDS=xm?cX.totalcnt:0;

bT=['mailaction=',cX.type,'&fun=mail_flag',xm?'unread':'read'];
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);

setFolderUnread(gX,aDS);
setMailListInfo(aDS,null);
}
else
{
bT=['mailaction=mail_flag&flag=new&status=',xm];


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=21");
}
showSelectALL(cp,false);

for(var i=0;i<_nLen;i++)
{
var bO=bw[i];
if(bO.bUnr!=xm)
{
if(bO.oChk)
{
bO.oChk.setAttribute('unread',xm?'true':'false');

var Bl=bO.oChk.getAttribute('gid');
setGroupUnread(Bl,getGroupUnread(Bl)+blM);
}
Fc++;
bT.push('&mailid=',bO.sMid);
if(bO.oTable&&!xm)
{

var dEP=GelTags("table",bO.oTable)[0],
qh=dEP.rows[0].cells[1];
if(qh.className=="new_g")
{
qh.innerHTML="";
}
}

for(var yI=bO.oTagIds,cNL=yI.length,j=0;j<cNL;j++)
{
var gX='tag_'+yI[j];
setTagUnread(gX,getFolderUnread(gX)+blM);
}
if(cNL)
{
setTagUnread('tag',getFolderUnread('tag')+blM);
}
}
}
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});
if(Fc||xe)
{



var bBb=blM*Fc;

if(!xe)
{
setFolderUnread(ag.sFid,getFolderUnread(ag.sFid)+bBb);
setMailListInfo(getMailListInfo().unread+bBb,null);
}

rdVer(bO.sMid,1);
var aA=ag.oWin;
if(ag.sFid==8)
{


setGroupUnread("gall",getGroupUnread("gall")+bBb);
}


var ctJ='\u8BBE\u7F6E'+(xm?'\u672A\u8BFB':'\u5DF2\u8BFB');

UQ({
bT:bT,
Vr:"new successful",
ys:T([ctJ,'\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5']),
wZ:function(aE,bQ,eQ)
{


var axh=0,
bSM=0;
for(var i=0;i<_nLen;i++)
{
var bO=bw[i];
if(bO.bUnr!=xm&&bO.bStar)
{
axh++;
}
if(!xm)
{

QMMailCache.addData(bO.sMid,{bUnread:null});
bSM=1;
}
else
{

QMMailCache.addData(bO.sMid,{bUnread:true});
bSM=1;
}
}
if(bSM)
{
QMMailCache.setExpire();
}


(gX!=5&&gX!=6)&&
setFolderUnread("starred",getFolderUnread("starred")+(xm?1:-1)*axh);





if(aA.goback)
{
aA.goback();
}

if(/folderid=(pop|personal|all)/i.test(aA.location.href)||xe)
{
reloadLeftWin();
}

if(!xm&&Fc>4)
{
setMailFilter({
sFilterType:"read"
},ag
);
}
setRollBack(aE.rbkey,ctJ+"\u90AE\u4EF6");
}
});
}

}














function starMail(Je,ag)
{
var bw=ag.oMail,
_nLen=bw.length,
cgd={
fg:0,
'fg fs1':1,
qm_ico_flagoff:2,
qm_ico_flagon:3
},
dtg=['fg','fg fs1','qm_ico_flagoff','qm_ico_flagon'],
bT=[],
cp=getMainWin(),
xe=isSelectAllFld(cp),
gX=ag.sFid;


if(!_nLen)
{
return showError('\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6');
}

else if(xe&&_nLen>1)
{
var cX=awm(cp);

bT=['mailaction=',cX.type,'&fun=mail_flag',Je?'star':'unstar'];
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);
}
else
{
bT=['mailaction=mail_flag&flag=star'];


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=22");
}
showSelectALL(cp,false);

for(var i=0;i<_nLen;i++)
{
var bO=bw[i];
bT.push('&mailid=',bO.sMid);
if(Je==null)
{
Je=!(cgd[bO.oStar.className]&1);
}
}

for(var i=0,ko=0;i<_nLen;i++)
{
var bO=bw[i],
Qu=bO.oStar;
if(bO.oChk)
{

bO.oChk.setAttribute('star',Je?'1':'0');
}
if(bO.bStar!=Je)
{
ko+=bO.bUnr?1:0;
QMMailCache.addData(bO.sMid,{star:Je});
rdVer(bO.sMid,1);
}
setClass(Qu,dtg[(cgd[Qu.className]&2)+(Je?1:0)]);
Qu.title=(Je?'\u53D6\u6D88':'\u6807\u4E3A')+'\u661F\u6807';
}

bT.push('&status='+Je);


if(ko&&(gX!=5&&gX!=6))
{
setFolderUnread("starred",getFolderUnread("starred")+(Je?1:-1)*ko);
}

UQ({
bT:bT,
Vr:'star successful',
ys:(Je?'\u6807\u8BB0':'\u53D6\u6D88')+'\u661F\u6807\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{


QMMailList.selectedUI({oMail:[],oACB:ag.oACB});


if(!callBack(ag.oncomplete,[ag,Je]))
{
var aA=ag.oWin;
if(aA.showMailFlag)
{
aA.showMailFlag(Je);

}
}
if(Je&&_nLen>2)
{
setMailFilter({
sFilterType:"star"
},ag
);
}

xe&&reloadLeftWin();
}
});
}









function moveMailJs(LH,doP,dca,ag)
{
if(dca==LH)
{
return showError(gsMsgMoveMailSameFldErr);
}

var dOc=ag.bML,
bw=ag.oMail,
_nLen=bw.length,
IS=unikey('mv'),
bT=[ag.bML?'&location=mail_list':''],
aqP=LH=="new",

bcU=false;



cp=getMainWin(),
xe=isSelectAllFld(cp);


for(var i=_nLen-1;i>=0;i--)
{
var bO=bw[i],
oi=bO.oChk;
if(bO.bTms)
{
return showError("\u8BF7\u4E0D\u8981\u9009\u62E9\u5B9A\u65F6\u90AE\u4EF6\uFF0C\u60A8\u4E0D\u80FD\u79FB\u52A8\u5B9A\u65F6\u90AE\u4EF6\u3002");
}





bcU=bcU||bO.bUnr;
bT.push('&mailid=',bO.sMid);
}











ag.oWin[IS]=1;

var bth=function()
{

!ag.bIsJump&&showInfo('\u90AE\u4EF6\u79FB\u52A8\u4E2D...',-1);

var Oe=aqP?"\u5DF2\u5C06\u90AE\u4EF6\u6210\u529F\u79FB\u52A8":T("\u5DF2\u5C06\u90AE\u4EF6\u6210\u529F\u79FB\u52A8 <a href='/cgi-bin/mail_list?sid=$sid$&folderid=$folderid$&page=0' style='color:white' onclick='getTop().hiddenMsg();' target='mainFrame' >[\u67E5\u770B]</a>").replace({
sid:getSid(),
folderid:LH
});


UQ({
bT:bT,
Vr:'mail_move successful',
ys:'\u79FB\u52A8\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
var aar;
if(ag.oWin[IS])
{
aar=callBack(ag.onbeforesend,[{sucMsg:Oe+getRollbackText(aE.rbkey)}]);
}

var RY=callBack(ag.oncomplete,[ag,aE]);
debug(["msg",aar,RY,aE.rbkey,getRollbackText(aE.rbkey)]);


!(aar&&RY)&&aE.msg&&showInfo(aE.msg+getRollbackText(aE.rbkey));


aqP&&reloadLeftWin();

if(ag.oWin[IS])
{

if(!RY)
{
if(
!(ag.bML&&ag.oWin.location.href.indexOf('s=search')>0)
&&aE&&aE.url&&!ag.bIsJump
)
{
goUrlMainFrm(aE.url,true,true);
}
else
{
reloadFrmLeftMain(true,true);
}
}
else
{
QMMailList.selectedUI({oMail:[],oACB:ag.oACB});
bcU
&&!aqP&&reloadLeftWin();
}
}
else
{

(bcU||xe)&&!aqP&&reloadLeftWin();
}

if(!aqP&&_nLen>2)
{
setMailFilter({
sFilterType:"move",
sFolderId:LH,
sFolderName:doP
},ag
);
}

setRollBack(aE.rbkey,'\u79FB\u52A8\u90AE\u4EF6');
}
});
};

if(xe)
{
var cX=awm(cp);

bT=[];
bT.push('&mailaction=',cX.type);
bT.push('&fun=mail_move'+(aqP?'_new':''));
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&srctagid=',cX.tid);
}
else
{

bT.push('&mailaction=',dOc&&!_nLen&&aqP?"onlyaddfolder":"mail_move");


ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=24");
}
bT.push('&destfolderid=',aqP?-1:LH);

if(aqP)
{
promptFolder({
type:'folder',
onreturn:function(fk){




bT.push('&foldername=',fk);
bth();
}
});
}
else if(_nLen)
{




bth();
}
else
{
showError('\u672A\u9009\u4E2D\u4EFB\u4F55\u90AE\u4EF6');
}
}











function configPreRmMail(ag,jt)
{
var bT=ag.oWin.location.getParams();

if(bT['s']=='search'||!ag.bML||((ag.sFid=='pop'||ag.sFid=='personal')&&jt=='moveMailJs')||getMainWin().tmpSortTypePrev=='5')
{
return false;
}

var eZO={},
aM=ag,
dAt=aM.onbeforesend,
dIc=aM.oncomplete,
bCW=false;
if((bT['s']=='star'||bT['showtag']=='1')&&jt=='moveMailJs')
{

bCW=true;
}
else
{
aM.onbeforesend=function(ahs)
{
callBack(dAt,[ahs]);
return(bCW=configPreRmMail.dRw(aM,ahs));
};
}
aM.oncomplete=function(ag,aC)
{
callBack(dIc,[ag,aC]);
return bCW;
}
return true;
}

















configPreRmMail.dRw=function(ag,ahs)
{













var dja="toarea",
aA=ag.oWin,
bw=ag.oMail,
_nLen=bw.length,
cuR=S('nextpage',aA),
aO=null,
cjg=null,
bih=null,
avB=null,
abP=null,

bp="_pReRmMaIl_",
cgh=0;
E(SN("mailid",aA),function(bo)
{
if(bo.type=="checkbox")
{
cgh++;
}
}
);
if(cgh==_nLen||_nLen==0)
{
return false;
}
aA[bp]=aA[bp]||{aA:aA,Sl:0};


if(cuR)
{
aO=[cuR.href.replace(/(&|\?)(loc|r|t)=.*?(&|$)/gi,"$1"),'&ef=js&resp_charset=UTF8&record=n&t=mail_list_fragment&listcount=',_nLen,'&r=',Math.random()].join('');
}

function aib()
{









var aMS=getMailListInfo(),
ko=0;

for(var i=0;i<_nLen;i++)
{
aMS.totle--;
bw[i].bStar&&(aMS.star--);
bw[i].bUnr&&ko++;

var cO=bw[i].oTable.parentNode,
jE=cO.previousSibling;
if(!jE.tagName||jE.tagName.toLowerCase()!='a')
{
jE=jE.previousSibling;
}
if(!abP)
{
abP=cO;
while((abP=abP.nextSibling)&&abP.className!='list_btline');


avB=abP;
while((avB=avB.previousSibling)&&avB.className!=dja);
}
removeSelf(bw[i].oTable);

cjg=jE;
bih=cO;
var qr=GelTags('span',jE)[0];
qr.innerHTML=(parseInt(qr.innerHTML)-1)+" \u5C01";
if(GelTags('table',cO).length==0)
{
removeSelf(jE);
removeSelf(cO);
}


if(bw[i].oChk&&bw[i].bUnr)
{

var Bl=bw[i].oChk.getAttribute('gid');
setGroupUnread(Bl,getGroupUnread(Bl)-1);
}
}
ag.oACB.checked=false;

setMailListInfo(ag.sFid==4?null:aMS.unread-ko,aMS.star,aMS.totle);

if(ag.sFid==8)
{
setGroupUnread("gall",getGroupUnread("gall")-ko);
}
_nLen&&(ahs||{}).sucMsg&&showInfo(ahs.sucMsg);

if(ko)
{
setFolderUnread(ag.sFid,getFolderUnread(ag.sFid)-ko);
}
QMMailCache.setExpire();
}

function aum(aV,bQ)
{
if(aV)
{


var cp=getMainWin();

bQ=trim(bQ);
var cok=bQ.substr(0,19),
aFp;
if(/<!--mlf\d{8}-->/.test(cok))
{
aFp=bQ.split(cok);
aFp.shift();
}

if(cp[bp].aA!=cp||!aFp||!aFp.length)
{

return;
}







if(abP)
{

if(avB==bih)
{

abP.parentNode.insertBefore(bih,abP);
abP.parentNode.insertBefore(cjg,bih);

}



for(var i=0,cqB=Math.min(cp[bp].Sl,aFp.length);i<cqB;i++)
{
insertHTML(avB,'beforeEnd',aFp[i]);
}
cp[bp].Sl=0;


var jE=avB.previousSibling;
if(!jE.tagName||jE.tagName.toLowerCase()!='a')
{
jE=jE.previousSibling;
}
var qr=GelTags('span',jE)[0];
qr.innerHTML=(parseInt(qr.innerHTML)+cqB)+" \u5C01";


var brf=SN("mailid",cp);
for(var i=brf.length-1;i>=0;i--)
{
if(brf[i].getAttribute('init')!="true"&&brf[i].type=='checkbox')
{
MLIUIEvent(brf[i],aA,ag.sFid);
}
}
}
}
else
{

}
}

aib();
if(aO)
{
if(aA[bp].Sl)
{
aA[bp].Sl+=_nLen;
}
else
{
aA[bp].Sl=_nLen;
QMAjax.send(aO,
{
method:'GET',
onload:aum
}
);
}
}

return true;
};










function rmMail(dD,ag)
{
var bw=ag.oMail,
_nLen=bw.length,
atV=0,
bT=[],
bhu={},
bIv=[],
cp=getMainWin(),
xe=isSelectAllFld(cp);

if(!_nLen)
{
showError(gsMsgNoMail);
return false;
}

else if(xe)
{
var cX=awm(cp);

bT.push('&mailaction=',cX.type);
cX.fid&&bT.push('&folderid=',cX.fid);
cX.tid&&bT.push('&tagid=',cX.tid);

}

else
{
bT=['mailaction=mail_del',ag.bML?'&location=mail_list':''];

for(var i=0;i<_nLen;i++)
{
var bO=bw[i],
aJa=bO.sSName,
dhk=bO.sSEmail;

bT.push('&mailid=',bO.sMid);
atV=bO.bUnr||atV;



if(bO.bUnr&&dhk.match(/tuan@mail-admin.qq.com|newsletter-noreply@qq.com/))
{
var aDi=bO.sColId;

bhu[aDi]?(bhu[aDi]++):(bhu[aDi]=1);
bhu[aDi]==5&&bIv.push(aDi);
}
}

ag.bSelectAll&&getTop().ossLog("delay","all","stat=selectall&opt=25");
}

if(dD==1)
{
var ciH=bIv.length,
ic=getTop().getSid();

confirmBox({
title:"\u5220\u9664\u786E\u8BA4",
mode:"prompt",
msg:TE([
'<div>\u5F7B\u5E95\u5220\u9664\u540E\u90AE\u4EF6\u5C06\u65E0\u6CD5\u6062\u590D\uFF0C\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417\uFF1F</div>',
'$@$if($bUnsubscribe$)$@$',
'<div style="margin:12px 0 0 0;">',
'<input style="vertical-align:middle; height:13px; width:13px; padding:0; margin:0 5px 0 0" id="unsubscribe" type="checkbox" name="Unsubscribe" >',
'<label for="unsubscribe"><span id="unsubscribe_text" style="color:#333; font-size:12px;">\u540C\u65F6\u9000\u8BA2\u9009\u4E2D\u7684\u8BA2\u9605\u90AE\u4EF6</span></label>',
'</div>',
'$@$endif$@$'
]).replace(
{
bUnsubscribe:(ciH>0)
}
),
onreturn:function(aV)
{
if(aV)
{
if(xe)
{
bT.push('&fun=mail_perdelall');
}
else
{
var oi=this.S("unsubscribe");

bT.push('&Fun=PerDel');


if(oi&&oi.checked)
{
var cML=""
for(var i=0;i<ciH;i++)
{
cML+=("&colid="+bIv[i]);
}
getTop().QMAjax.send(getTop().T("/cgi-bin/setting10?action=desubscribe&sid=$sid$$colidlist$").replace({
sid:ic,
colidlist:cML
}),
{
method:"GET",
onload:function(aV,bQ){}
});
ag.sDelRetMsg="\u5220\u9664\u90AE\u4EF6\u5E76\u9000\u8BA2\u6210\u529F";
}
}

cAG(ag,bT,atV);
}
}
});
}




else
{
xe&&bT.push('&fun=mail_delall');
cAG(ag,bT,atV);
}

return true;
}

function cAG(ag,eg,ecw)
{
var Oe=ag.sDelRetMsg||"\u5DF2\u5C06\u90AE\u4EF6\u6210\u529F\u5220\u9664",
iX=ag.sFid,
IS=unikey('rm');

if(ag.bPop&&getGlobalVarValue("POP_PROPOSE"))
{
confirmBox({
title:"\u90AE\u7BB1\u529F\u80FD\u63A8\u8350",
mode:"prompt",
msg:T([
'<div style="margin-top:8px" class="bold">\u5728$dn$\u90AE\u7BB1\u4E2D\u5220\u9664\u90AE\u4EF6\uFF0C\u540C\u65F6\u4E5F\u5220\u9664\u539F\u90AE\u7BB1\u4E2D\u7684\u5BF9\u5E94\u90AE\u4EF6?</div>',
'<div class="addrtitle" style="margin:4px 0 0 0;">',
'\u60A8\u4E5F\u53EF\u4EE5\u8FDB\u5165\u201C\u4FEE\u6539\u8BBE\u7F6E\u201D\u4E2D\u8BBE\u7F6E\u3002',
'<a href="http://service.mail.qq.com/cgi-bin/help?subtype=1&&id=26&&no=326" target="_blank" >\u4E86\u89E3\u8BE6\u8BF7</a>',
'</div>'
]).replace(
{
dn:getDomain(true)
}
),
onreturn:function(aV)
{
if(aV)
{
runUrlWithSid(T("/cgi-bin/foldermgr?fun=updpop&updflag=22&folderid=$folderid$").replace({
folderid:iX
}
));
showInfo('\u8BBE\u7F6E\u6210\u529F\uFF01\u5E76\u5C06\u5F53\u524D\u9009\u4E2D\u90AE\u4EF6\u5220\u9664\u3002');

}
}
});
}






showInfo('\u90AE\u4EF6\u5220\u9664\u4E2D...',-1);
ag.oWin[IS]=1;



UQ({
bT:eg,
Vr:'mail_del successful',
ys:'\u5220\u9664\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
Oe=Oe+getRollbackText(aE.rbkey);

var aar;
if(ag.oWin[IS])
{
aar=callBack(ag.onbeforesend,[{sucMsg:Oe}]);
}

var aO=aE.url,
RY=callBack(ag.oncomplete,[ag,aE]);






!(aar&&RY)&&showInfo(Oe);
if(!RY&&ag.oWin[IS])
{
if(ag.bML&&ag.oWin.location.href.indexOf('s=search')>0)
{
reloadFrmLeftMain(false,true);
}
else
{
ag.oWin.location.href=aO+"&r="+Math.random();
}
}
if(ecw||isSelectAllFld(ag.oWin)||ag.sFid==3||ag.sFid==4)
{
reloadLeftWin();
}
if(ag.oMail.length>4)
{
setMailFilter({
sFilterType:"delete"
},ag
);
}

setRollBack(aE.rbkey,'\u5220\u9664\u90AE\u4EF6');
}
});
}



























































function reportSpamJson(aQ,ag)
{

if(getTop().isSelectAllFld(getMainWin()))
{
return showError('\u4E0D\u80FD\u5BF9\u5168\u6587\u4EF6\u5939\u6267\u884C\u6B64\u64CD\u4F5C');
}


var bw=ag.oMail,
_nLen=bw.length,
atV=0,
bYp=ag.sFid==6,
bT=[ag.bML?'&location=mail_list':'','&mailaction=mail_spam&isspam=true&Fun=',3<ag.sFid&&ag.sFid<7?"PerDel":"Del",'&srcfolderid=',ag.sFid];

if(!_nLen)
{
showError(gsMsgNoMail);
return false;
}

var cHo=aQ.bBlackList===false?false:true,
_oInfo,

pu={};
for(var i=0;i<_nLen;i++)
{
_oInfo=bw[i];
bT.push('&mailid=',_oInfo.sMid);

if(/(@groupmail.qq.com|10000@qq.com)/.test(_oInfo.sSEmail))
{

cHo=false;
}

if(typeof pu.sender=="undefined")
{
pu.sender=_oInfo.sSEmail;
pu.nickname=_oInfo.sSName;
}
else if(pu.sender!=_oInfo.sSEmail)
{
pu.sender="";
}
}











QMMailList.selectedUI(ag);



var Hf=["\u53D1\u4EF6\u4EBA"];

if(pu&&pu.sender&&pu.sender.indexOf(',')<0)
{
Hf[0]=pu.sender;
}


var Ex=aQ.oAddrList,
aqx=0;
if(Ex&&Ex.length>0)
{
if(Ex[0].length>0)Hf[aqx++]=Ex[0];
if(Ex[1])Hf[aqx++]=Ex[1];
}

var Qi=T([
'<div>',
'<input type="radio" name="reporttype" id="r$value$" value="$value$" $checked$>',
'<label for="r$value$">$content$</label>',
'</div>'
]),
cj=([
"<div style='padding:10px 10px 0 25px;text-align:left;'>",
"<form id='frm_spamtype'>",
"<div style='margin:3px 0 3px 3px'><b>\u8BF7\u9009\u62E9\u8981\u4E3E\u62A5\u7684\u5783\u573E\u7C7B\u578B\uFF1A</b></div>",
Qi.replace({
value:(bYp?11:8),
checked:"checked",
content:"\u5176\u4ED6\u90AE\u4EF6"
}),

Qi.replace({
value:(bYp?10:4),
checked:"",
content:"\u5E7F\u544A\u90AE\u4EF6"
}),

Qi.replace({
value:(bYp?9:1),
checked:"",
content:"\u6B3A\u8BC8\u90AE\u4EF6"
}),
"<div style=\"padding:5px 0 2px 0;\">",
(cHo?reportSpamJson.dti(Hf):"&nbsp;"),
"</div><div style='margin:10px 3px 0px 3px' class='addrtitle' >\u6E29\u99A8\u63D0\u793A\uFF1A\u6211\u4EEC\u5C06\u4F18\u5148\u91C7\u7EB3\u51C6\u786E\u5206\u7C7B\u7684\u4E3E\u62A5\u90AE\u4EF6\u3002</div>",
"</form>",
"</div><div style='padding:3px 15px 12px 10px;text-align:right;'>",
"<input type=button id='btn_ok' class='btn wd2' value=\u786E\u5B9A>",
"<input type=button id='btn_cancel' class='btn wd2' value=\u53D6\u6D88>",
"</div>"
]).join("");

new QMDialog({
sId:"reportSpam",

sTitle:"\u4E3E\u62A5\u5E76\u62D2\u6536\u9009\u4E2D\u90AE\u4EF6",
sBodyHtml:cj,
nWidth:450,

nHeight:220,
onload:function(){
var bI=this;
addEvent(bI.S("btn_ok"),"click",function()
{
var WQ=bI.S("frm_spamtype").reporttype,
Dx=bI.S("frm_spamtype").refuse0,
Hx=bI.S("frm_spamtype").refuse1,

bcQ,
AR="readmail_spam";



for(var i=0,_nLen=WQ.length;i<_nLen;i++)
{
if(WQ[i].checked)
{
bcQ=WQ[i].value;
break;
}
}

var om=Dx&&Dx.checked?["1","1"]:["0","0"];
if(Hx)
{

om[0]=Dx&&Dx.checked?"1":"0";
om[1]=Hx.checked?"1":"0";
}
if((Dx&&Dx.checked)||
(Hx&&Hx.checked))
{
AR="readmail_reject";
}
bT.push("&s=",AR,"&reporttype=",bcQ,"&s_reject_what=",om[0]+om[1]);

reportSpamJson.dQQ(bT,AR,ag);


bI.close();
});
addEvent(bI.S("btn_cancel"),"click",function()
{
bI.close()
}
);

},
onshow:function(){
this.S("btn_cancel").focus();
}
});

return false;
}

reportSpamJson.dTP=function(cD)
{
var dM=cD.indexOf("@"),
Ei='...';
if(dM>-1)
{
var dBQ=cD.substr(0,dM),
dCo=cD.substr(dM);
return subAsiiStr(dBQ,18,Ei)+subAsiiStr(dCo,18,Ei);
}
else
{
return subAsiiStr(cD,36,Ei);
}
};


reportSpamJson.dti=function(HL)
{
var aOT=T([
'<div><input type="checkbox" name="refuse$id$" id="refuese$id$" $TCHECK$>\u5C06<label for="refuese$id$">$TVALUE$</label>\u52A0\u5165\u9ED1\u540D\u5355</div>'
]),
eZ=[],
i;
for(i=0;i<HL.length;i++)
{
eZ.push(aOT.replace({
id:i,
TVALUE:HL[i]!="\u53D1\u4EF6\u4EBA"?"&lt;"+reportSpamJson.dTP(HL[i])+"&gt;":HL[i],
TCHECK:""
})
);
}
return eZ.join('');
};

reportSpamJson.dQQ=function(eg,dJo,ag)
{















var Oe="\u8BBE\u4E3A\u5783\u573E\u90AE\u4EF6\u6210\u529F",
bgl=0,
IS=unikey('spam'),
bw=ag.oMail,
atV=0,
cvd=false,
bT=['mailaction=mail_spam&isspam=true'],
aar;

switch(dJo)
{
case"readmail_spam":
case"readmail_spam_newwin":

Oe="\u4E3E\u62A5\u6210\u529F\uFF0C\u611F\u8C22\u60A8\u5BF9QQ\u90AE\u7BB1\u53CD\u5783\u573E\u90AE\u4EF6\u5DE5\u4F5C\u7684\u652F\u6301";
break;
case"readmail_reject":
case"readmail_reject_newwin":
Oe="\u5DF2\u5C06\u6B64\u53D1\u4EF6\u4EBA\u6DFB\u52A0\u5230\u9ED1\u540D\u5355\uFF0C\u5E76\u5C06\u8BE5\u90AE\u4EF6\u79FB\u5165\u5783\u573E\u90AE\u4EF6\u7BB1";
break;
case"readmail_group":
case"readmail_group_newwin":
Oe="\u62D2\u6536\u6210\u529F\uFF0C\u5C06\u4E0D\u518D\u6536\u53D6\u6B64\u8BDD\u9898\u90AE\u4EF6"
break;
}

for(var i=bw.length-1;i>=0;i--)
{
cvd=cvd||bw[i].bSys;
atV+=bw[i].bUnr?1:0;
}

showInfo('\u90AE\u4EF6\u4E3E\u62A5\u4E2D...',-1);
ag.oWin[IS]=1;
if(ag.bML&&!getTop().QMTip)
{
loadJsFileToTop(["$js_path$qmtip0be06f.js"]);
}



UQ({
bT:eg,
Vr:'spam successful',
ys:'\u4E3E\u62A5\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
var aO=aE.url,
RY=callBack(ag.oncomplete,[ag,aE]);

!(aar&&RY)&&showInfo(Oe);

if(aO&&!RY&&ag.oWin[IS])
{
if(ag.bML&&ag.oWin.location.href.indexOf('s=search')>0)
{
reloadFrmLeftMain(false,true);
}
else
{
goUrl(ag.oWin,aO,false);
}

if(!aE.nodlg&&aE.showReportInfo)
{
aE.showReportInfo(aE.reportCnt,aE.acceptCnt,aE.allCnt,aE.trushCnt);
}
}
else if(ag.bML&&!aE.nodlg&&getTop().QMTip&&ag.oWin[IS])
{

var cIm=10002;

aE.sid=getSid();
aE.tipid=cIm;
var djw=TE([
"<p>\u60A8\u603B\u5171\u4E3E\u62A5\u4E86 $reportCnt$ \u6B21</p>",
"<p style='font-weight:normal;'>$@$if($acceptCnt$)$@$\u88AB\u7CFB\u7EDF\u91C7\u7EB3\u4E86 $acceptCnt$ \u6B21<br/>$@$endif$@$\u4ECA\u5929\u6211\u4EEC\u7CFB\u7EDF\u6536\u5230 $allCnt$ \u6B21\u4E3E\u62A5<br/>\u603B\u5171\u62E6\u622A\u4E86 $trushCnt$ \u5C01\u5783\u573E\u90AE\u4EF6<br/>\u611F\u8C22\u60A8\u5BF9QQ\u90AE\u7BB1\u53CD\u5783\u573E\u5DE5\u4F5C\u7684\u652F\u6301\uFF01",
"<div style=''></div>",
"<div style='text-align:right;font-weight:normal;'><a onclick=\"javascript: getTop().goUrlMainFrm('/cgi-bin/help_report_spam?sid=$sid$', false);getTop().QMTip.close('', $tipid$, false, true);\" style='text-decoration:underline;'>\u4E3E\u62A5\u6570\u636E\u4E2D\u5FC3</a>&nbsp;<a href='javascript;' onclick='getTop().runUrlWithSid(\"/cgi-bin/help_report_spam?type=0&ixspaminfo=1\");getTop().QMTip.close(\"\", $tipid$, false, true);return false;' style='text-decoration:underline;'>\u4EE5\u540E\u4E0D\u518D\u63D0\u793A</a></div>"
]).replace(aE);

QMTip.show2({
bForceShow:true,
type:4,
win:ag.oWin,
tipid:cIm,
domid:"gotnomail",
msg:djw,
arrow_direction:"none",
arrow_offset:0,
width:400,
height_offset:150,
tip_offset:-300,
close_fork:1
});
}
if(bgl)
{
reloadLeftWin();
}
}
});
};








function reportNoSpamJson(aQ,ag)
{

var Oe="\u6210\u529F\u6807\u8BB0\u4E3A\u201C\u975E\u5783\u573E\u90AE\u4EF6\u201D",
bw=ag.oMail,
_nLen=bw.length,
bgl=0,
IS=unikey('spam'),
bT=[ag.bML?'&location=mail_list':'','&mailaction=mail_spam&isspam=false'],
_oInfo;

if(!_nLen)
{
showError(gsMsgNoMail);
return false;
}

for(var i=0;i<_nLen;i++)
{
_oInfo=bw[i];
bT.push('&mailid=',_oInfo.sMid);
bgl+=_oInfo.bUnr?1:0;
}


ag.oWin[IS]=1;



var aar=false;

UQ({
bT:bT,
Vr:'spam successful',
ys:'\u8BBE\u7F6E\u4E0D\u662F\u5783\u573E\u90AE\u4EF6\u5931\u8D25\uFF0C\u8BF7\u91CD\u8BD5',
wZ:function(aE,bQ,eQ)
{
var aO=aE.url,

RY=false;

!(aar&&RY)&&showInfo(Oe+getRollbackText(aE.rbkey));
if(aO&&!RY&&ag.oWin[IS])
{
ag.oWin.location.href=aO;
}
if(bgl)
{
reloadLeftWin();
}
setRollBack(aE.rbkey,"\u8BBE\u7F6E\u4E0D\u662F\u5783\u573E\u90AE\u4EF6");
}
});
}








function isSelectAllFld(dp)
{
var csl=false;
E(GelTags("div",S("selectAll",dp)),
function(bn,cU)
{
if("selected"==bn.getAttribute("un"))
{
csl=isShow(bn);
return false;
}
}
);
return csl;
}






function awm(dp)
{
var Hd=S("selectAll",dp);
return{
"type":Hd.getAttribute("ftype"),
"fid":Hd.getAttribute("fid"),
"tid":Hd.getAttribute("tid"),
"totalcnt":Hd.getAttribute("totalcnt")};
}






function showSelectALL(dp,Gv)
{
var Hd=S("selectAll",dp);

if(Hd)
{
displayGrayTip(Hd,Gv);
!Gv&&selectAllFld(dp,Gv);
show(S("tips_bar",dp),!Gv);
}
}






function selectAllFld(dp,abSelect)
{
var la="&selectall="+(abSelect?1:0),
Hd=S("selectAll",dp);

if(Hd)
{
E(GelTags("div",Hd),
function(bn,cU)
{
var Im=bn.getAttribute("un");
Im=="unselect"&&show(bn,!abSelect);
if(Im=="selected")
{
var qr=GelTags("span",bn)[0],
eB=qr.getAttribute("start"),
gk=qr.getAttribute("end"),
bId=4,
oW=parseInt((gk-eB)/bId),
bMp=function(aZl){qr.innerHTML=aZl;};

if(!!abSelect)
{
if(qr.innerHTML==gk)
{
return;
}
bMp(eB);
setTimeout(function()
{
bMp(gk-(--bId)*oW);
bId!=0&&setTimeout(arguments.callee,150);
},
150
);
}
else
{
bMp(eB);
}
show(bn,!!abSelect);
}
}
);
E(["prevpage","nextpage","prevpage1","nextpage1"],function(aG)
{
var iQ=S(aG,dp);
if(iQ)
{
var fz=iQ.href;
iQ.href=fz.match(/selectall/)?fz.replace(/&selectall=\d/,la):(fz+la);
}
});
}
}










function initMailSelect(bPI,cHY,dea,aq,ec,dZY,doI)
{
var aGB=BaseMailOper,
aM={
sFolderid:ec,
bReadMode:cHY&&ec!=4,
bStarMode:cHY,
bAutoTag:dZY||false,
bTagMode:dea&&ec!=5&&ec!=6,
moMoveItem:bPI,
bSpam:doI||false,
oWin:aq
},
Bm=aGB.ebo(aM);

aM=Bm.getConfig();


if(bPI)
{
E(SN("selmContainer",aq),function(_aoDom){
if(!_aoDom.innerHTML)
{
new QMSelect({
oContainer:_aoDom,
nWidth:80,
sDefaultItemValue:"\u79FB\u52A8\u5230...",
oMenu:{
nWidth:"auto",
nMaxWidth:180,

bAutoItemView:true,
bAutoClose:true,
oItems:bPI
},
onafteropenmenu:function(hH,aZV){
var bO;
if(aM.mnFolderType==0)
{

bO=QMMailList.getCBInfo(aM.oWin);
}
else
{


bO=aM.oWin.QMReadMail.getCBInfo(aM.oWin);
}

Bm.setMailInfo(bO);
},
onselect:function(bt){


Bm.apply(bt.sId,bt.sItemValue);
return true;
}
});
}
});
}


function cvC()
{
var bm=[],
Lu={nHeight:10,sItemValue:'<div style="background:#CCC; height:1px; margin-top:5px; overflow:hidden;"></div>'},
cNk=T([
'<div style="white-space:nowrap;zoom:1;">',
'<input type="button" class="item_square flagbg$flagbg$"/>',
'<span class="item_square_txt">$name$ &nbsp</span>',


'</div>']);

if(aM.bReadMode)
{
bm.push(
{sId:"read",sItemValue:"\u5DF2\u8BFB\u90AE\u4EF6"},
{sId:"unread",sItemValue:"\u672A\u8BFB\u90AE\u4EF6"},
Lu
);
}
if(aM.bStarMode)
{
bm.push(
{sId:"star",sItemValue:"\u661F\u6807\u90AE\u4EF6"},
{sId:"unstar",sItemValue:"\u53D6\u6D88\u661F\u6807"}
);
if(aM.bTagMode)
{
bm.push(Lu);
}
}
if(aM.bTagMode)
{
bm.push(
{
sId:'rmalltag',
sItemValue:'\u53D6\u6D88\u6807\u7B7E'
},
extend({bDisSelect:true,sId:'deltaghr'},Lu)
);
for(var bxT=QMTag.get(),i=0,_nLen=bxT.length;i<_nLen;i++)
{
var ux=bxT[i];
bm.push(
{
sId:'tid_'+ux.id,
sItemValue:cNk.replace(ux)
}
);
}
if(_nLen)
{
bm.push(Lu);
}
bm.push({
sId:'newtag',
sItemValue:'\u65B0\u5EFA\u6807\u7B7E'
});

if(aM.bAutoTag)
{
bm.push(Lu,{
sId:'autotag',
sItemValue:'\u65B0\u5EFA\u81EA\u52A8\u6807\u7B7E'
});
}
}
return bm;
}


E(SN("markContainer",aq),function(_aoDom){
if(_aoDom.innerHTML)
{
return;
}
if(!(aM.bReadMode||aM.bStarMode||aM.bTagMode))
{
show(_aoDom,false);
return;
}
new QMSelect({
oContainer:_aoDom,
nWidth:80,
sDefaultItemValue:"\u6807\u8BB0\u4E3A...",
oMenu:{
nWidth:"auto",
nMaxWidth:180,

bAutoItemView:true,
bAutoClose:true,
oItems:[]
},
onselect:function(bt){
var hH=this.get("menu");

Bm.apply(bt.sId,bt.sItemValue);
hH.hide();

return true;
},

onbeforeopenmenu:function(cLQ)
{
aM.fwy=aM.bTagMode?QMTag.get():[];
cLQ.sDefaultId="";
cLQ.oItems=cvC();
},

onafteropenmenu:function(hH){
var bO;

if(aM.mnFolderType==0)
{

bO=QMMailList.getCBInfo(aM.oWin);
var btV=bO.oMail.length;
hH.itemOption("rmalltag","bDisplay",btV);
hH.itemOption("deltaghr","bDisplay",btV);
}
else
{


bO=aM.oWin.QMReadMail.getCBInfo(aM.oWin);
}

Bm.setMailInfo(bO);
}
});
});
}



var JS=(function()
{
var bz={};

function aFR(eA,Le)
{
var _oTop=getTop();
Le=typeof Le=="string"?[Le]:Le;

E(Le,function(iO)
{
if(bz[iO]!==true)
{
loadJsFile(eA+iO,true,_oTop.document,function()
{
var awJ=bz[iO];
bz[iO]=true;
if(isArr(awJ))
{
for(var i in awJ)
{
awJ[i]();
}
}
}
);
}
});
}

function cMY(Le,bG)
{
Le=(typeof Le=="string")?[Le]:Le;

function bDv()
{
var Dw=true;
E(Le,function(iO)
{
Dw=Dw&&(bz[iO]===true);
});
Dw&&bG();
return Dw;
}

if(!bDv())
{
E(Le,function(iO)
{
var awJ=bz[iO];
if(awJ===true)
{
return;
}
else if(!isArr(awJ))
{
bz[iO]=[bDv];
}
else
{
awJ.push(bDv);
}
});
}
}


















return(
{
load:aFR,
wait:cMY
})
})();

var gnQmToolLoad=new Date().getTime()-drx;




function qmtool_js(){}