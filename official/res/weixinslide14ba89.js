(function (_aoWin)
{
	var _oTop = getTop(),
		_oAni = _oTop.qmAnimation;

		_S = function(_asId)
		{
			return _oTop.S(_asId, _aoWin);
		},
		_pos = function(_aoDom, _asAttr, _anValue)
		{
			if (typeof _anValue == "undefined")
			{
				return _aoDom["offset" + _asAttr.charAt(0).toUpperCase() + _asAttr.slice(1)];
				//return parseInt(_aoDom.style[_asAttr]);
			}
			else
			{
				_aoDom.style[_asAttr] = _anValue + "px";
			}
		};

	var qmDySlider = function(_aoConfig)
	{
		var _oSelf = this;

		_oTop.extend(_oSelf, _aoConfig);

		_oSelf._mnCurPos = 0;
		_oSelf._setPos(_oSelf.oBoxs[0], 0);
		for (var i = 1; i < _oSelf.oBoxs.length; i++)
		{
			_oSelf._setPos(_oSelf.oBoxs[i], 100);
		}
	}

	qmDySlider.prototype = {

		_slider : function(_aoDom1, _aoDom2, _anFromPercent, _anDirection)
		{
			var _oSelf = this;

			_oAni.play(_oSelf.oBoxContainer, 
			{
				win : _aoWin,
				speed : 200,
				onready : function()
				{
					_oSelf._setPos(_aoDom1, _anFromPercent);
					_oSelf._setPos(_aoDom2, _anFromPercent + 100);
				},
				onaction : function(_anValue, _anProcess)
				{
					_oSelf._setPos(_aoDom1, _anFromPercent + _anProcess * 100 * _anDirection);
					_oSelf._setPos(_aoDom2, _anFromPercent + 100 + _anProcess * 100 * _anDirection);
				},
				oncomplete : function()
				{
					_oSelf._setPos(_aoDom1, _anFromPercent + 100 * _anDirection);
					_oSelf._setPos(_aoDom2, _anFromPercent + 100 + 100 * _anDirection);
				}
			});
		},

		//_anPercent: -100 0 100
		_setPos : function(_aoDom, _anPercent)
		{
			var _oSelf = this,
				_oBoxContainer = _oSelf.oBoxContainer,
				_nLeft = _pos(_oBoxContainer, "left"),
				_nWidth = _pos(_oBoxContainer, "width");

			_pos(_aoDom, "left",  _nLeft +  _anPercent/100 * _nWidth);
			_pos(_aoDom, "top", _pos(_oBoxContainer, "top"));
		},

		next : function()
		{
			var _oSelf = this;
			return _oSelf.goto(_oSelf._mnCurPos + 1);
		},

		prev : function()
		{
			var _oSelf = this;
			return _oSelf.goto(_oSelf._mnCurPos - 1);
		},

		goto : function(_anPos)
		{
			var _oSelf = this,
				_anDirection,
				_oDom1, _oDom2, _anFrom,
				_nLen = _oSelf.oBoxs.length,
				_nRealPos = (parseInt(_anPos) + _nLen) % _nLen;
			
			if (_nRealPos == _oSelf._mnCurPos)
			{
				return _nRealPos;
			}
			if (_oSelf._mnCurPos > _anPos)
			{
				_anDirection = 1;
				_anFrom = -100;
				_aoDom1 = _oSelf.oBoxs[_nRealPos];
				_aoDom2 = _oSelf.oBoxs[_oSelf._mnCurPos];
			}
			else
			{
				_anDirection = -1;
				_anFrom = 0;
				_aoDom1 = _oSelf.oBoxs[_oSelf._mnCurPos];
				_aoDom2 = _oSelf.oBoxs[_nRealPos];
			}
			_oSelf._slider(_aoDom1, _aoDom2, _anFrom, _anDirection);
			return (_oSelf._mnCurPos = _nRealPos);
		}
	}
	_aoWin.pageReady = function(_aoConfig)
	{
		var _oBoxs = [],
			_oBoxsDot = [],
			_oBoxContainer = _S(_aoConfig.sBoxContainerId),
			_fSetPresent = function(_anPos)
			{
				_oTop.E(_oBoxsDot, function(_aoDom, _anIdx)
					{
						_oTop.setClass(_oBoxsDot[_anIdx],
						_anPos == _anIdx ? "current_pic" : "") 
					}
				);
			};

		_oTop.E(_aoConfig.oBoxsId, function(_asItem)
			{
				_oBoxs.push(_S(_asItem));
			}
		)

		var _oDySlider = new qmDySlider(
		{
			oBoxContainer : _oBoxContainer,
			oBoxs : _oBoxs
		});


		_oTop.E(_aoConfig.oBoxsDotId, function(_asItem)
			{
				_oBoxsDot.push(_S(_asItem));
				_S(_asItem).onclick = function()
				{
					var _sIdx = _oTop.attr(this, "idx"),
						_nPos = _oDySlider.goto(_sIdx);

					_fSetPresent(_nPos);
				}
			}
		);

		var _bAutoRun = true;

		_oBoxContainer.onmouseover = function()
		{
			_bAutoRun = false;
		}
		_oBoxContainer.onmouseout = function()
		{
			_bAutoRun = true;
		}

		setInterval(function()
		{
			if (_bAutoRun)
			{
				fireMouseEvent(_S("rightMove"), "click");
			}
		}, 5000);
		/*add by gabyliu*/
		_S("circlePic").onmouseover = function(){
			_S("rightMove").style.display="block";
			_S("leftMove").style.display="block";
		}

		_S("circlePic").onmouseout = function(){
			_S("rightMove").style.display="none";
			_S("leftMove").style.display="none";
		}
		/*add by gabyliu end*/
		_S("rightMove").onclick = function(){
			var _nPos = _oDySlider.next();
			_nPos > -1 && _fSetPresent(_nPos);
		}

		_S("leftMove").onclick = function(){
			var _nPos = _oDySlider.prev();
			_nPos > -1 && _fSetPresent(_nPos);
		}

		_fSetPresent(0);

	}

})(window)
