/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


__webpack_require__(1);

__webpack_require__(2);

/***/ }),
/* 1 */
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function(global) {

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

var _module = __webpack_require__(4);

var root = function (root) {
    if ((typeof root === 'undefined' ? 'undefined' : _typeof(root)) === 'object' && (root.self === root || root.global === global) && root) {
        return root;
    }
}(self || global || {});

var $ = function ($) {
    if (typeof $ === 'function') {
        return $;
    } else {
        throw new Error('You must import jQuery');
    }
}(root.jQuery);

$.fn[_module.ModuleName] = function () {
    var args = Array.prototype.slice.call(arguments, 0);
    var method = args[0];
    var options = args.slice(1).length <= 0 ? void 0 : args.slice(1, args.length);
    var isReturnMethod = this.length === 1 && typeof method === 'string' && _module.ModuleReturns.indexOf(method) !== -1;
    var methodRunner = function methodRunner(method, options, uesReturn) {
        var $this = $(this);
        var module = $this.data(_module.ModuleName);
        if (module) {
            if (typeof method === 'string' && !uesReturn) {
                module[method].apply(module, options);
            } else if (typeof method === 'string' && !!uesReturn) {
                return module[method].apply(module, options);
            } else {
                throw new Error('unsupported options!');
            }
        } else {
            throw new Error('You must run first this plugin!');
        }
    };
    if (isReturnMethod) {
        return methodRunner.call(this, method, options, isReturnMethod);
    } else {
        return this.each(function () {
            var $this = $(this);
            var module = $this.data(_module.ModuleName);
            var opts = null;
            if (module) {
                methodRunner.call(this, method, options);
                if (method === "destroy") {
                    module = null;
                }
            } else {
                opts = $.extend(true, {}, _module.ModuleDefaults, (typeof method === 'undefined' ? 'undefined' : _typeof(method)) === 'object' && method, (typeof options === 'undefined' ? 'undefined' : _typeof(options)) === 'object' && options);
                module = new _module.Module(this, opts);
                $this.data(_module.ModuleName, module);
                module.init();
            }
        });
    }
};
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(3)))

/***/ }),
/* 3 */
/***/ (function(module, exports) {

var g;

// This works in non-strict mode
g = (function() {
	return this;
})();

try {
	// This works if eval is allowed (see CSP)
	g = g || Function("return this")() || (1,eval)("this");
} catch(e) {
	// This works if the window reference is available
	if(typeof window === "object")
		g = window;
}

// g can still be undefined, but nothing to do about it...
// We return undefined, instead of nothing here, so it's
// easier to handle this case. if(!global) { ...}

module.exports = g;


/***/ }),
/* 4 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

/**
 * Define module name here 
 */
var ModuleName = 'cl_rtol';
/**
 * Props default value write here
 */
var ModuleDefaults = {
    properties: 'value'
};
/**
 * Define you want to get function returns from outside of scope
 */
var ModuleReturns = [];

var Module = function () {
    function Module(ele, options) {
        _classCallCheck(this, Module);

        this.ele = ele;
        this.$ele = $(ele);
        this.option = options;
        this.obj = {
            bigimgLi: this.$ele.find(".pt-bannerList li"),
            ptPrev: this.$ele.find(".pt-prev"),
            ptNext: this.$ele.find(".pt-next"),
            imgMax: this.$ele.find(".pt-bannerList li").length,
            startPos: 0,
            animateTo: 0,
            imgNow: 0,
            imgNext: null,
            animateV: 650,
            nextClick: 4000,
            dragState: false,
            dragStartX: 0,
            dragDate: null,
            dpos: null
        };
    }

    _createClass(Module, [{
        key: 'init',
        value: function init() {
            // first run here
            var _obj = this.obj,
                bigimgLi = _obj.bigimgLi,
                imgNow = _obj.imgNow,
                imgMax = _obj.imgMax,
                ptNext = _obj.ptNext,
                ptPrev = _obj.ptPrev;

            var self = this;
            bigimgLi.eq(imgNow).addClass('active').siblings().css({ "left": '100%' });
            if (imgMax < 2) {
                ptNext.hide();ptPrev.hide();
            }
            this.$ele.off('click').on('click', function (event) {
                self.handleClick($(event.target), event);
            });
        }
    }, {
        key: 'moveNext',
        value: function moveNext() {
            var _this = this;

            this.obj.startPos = this.obj.imgNext > this.obj.imgNow ? 100 : -100;
            this.obj.animateTo = this.obj.imgNext > this.obj.imgNow ? "-100%" : "100%";
            this.obj.imgNext = this.obj.imgNext > this.obj.imgNow ? this.obj.imgNext % this.obj.imgMax : (this.obj.imgNext + this.obj.imgMax) % this.obj.imgMax;
            if (this.obj.dragState) {
                this.obj.startPos = this.obj.startPos + this.obj.dpos / this.$ele.find('.btn-bannerList').width() * 100;
            }
            this.obj.bigimgLi.eq(this.obj.imgNow).removeClass("active").stop().animate({ left: this.obj.animateTo }, this.obj.animateV);
            this.obj.bigimgLi.eq(this.obj.imgNext).addClass("active").css({ "left": this.obj.startPos + "%" }).stop().animate({ "left": "0%" }, this.obj.animateV, function () {
                _this.obj.imgNow = _this.obj.imgNext;
                _this.obj.imgNext = null;
            });
            return this;
        }
    }, {
        key: 'handleClick',
        value: function handleClick(target, event) {
            if (target.hasClass("pt-prev")) {
                if (this.obj.imgNext == null && this.obj.imgMax > 1) {
                    this.obj.imgNext = this.obj.imgNow - 1;
                    this.moveNext();
                }
            }

            if (target.hasClass("pt-next")) {
                if (this.obj.imgNext == null && this.obj.imgMax > 1) {
                    this.obj.imgNext = this.obj.imgNow + 1;
                    this.moveNext();
                }
            }
        }
    }]);

    return Module;
}();

Module.prototype.destory = function () {
    this.$ele.children().remove();
};

exports.ModuleName = ModuleName;
exports.ModuleDefaults = ModuleDefaults;
exports.ModuleReturns = ModuleReturns;
exports.Module = Module;

/***/ })
/******/ ]);