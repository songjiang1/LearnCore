/*----------内容浏览-------------
一、 扩展
 1.时间格式 dateFormat    例:str.dateFormat("yyyy-MM-dd")
 2-3.数组max方法和min方法   例:ary.max(),ary.min()
 
二、  判断
 1.空判断：  例:isEmpty(obj)


三、 数据分组
 1.分组    例:var updateArry = groupBy(dirtyItems, function (arryitem) {  return [arryitem.Mark, arryitem.Source];   });

四、 其他通用
 1.生成guid  例：getGuid()
 */
/*==============================扩展 开始============================= */
/*==============================扩展 结束=============================*/
/*==============================扩展 开始=============================  */
function ChineseTimeToString(time) {
    try {
        var d = new Date(time);
        var datetime = d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate() + ' ' + d.getHours() + ':' + d.getMinutes() + ':' + d.getSeconds(); 
        return datetime.indexOf("NaN") > -1 ? "" : datetime;
    } catch (e) {
        return "";
    }

}

//时间格式 dateFormat
String.prototype.dateFormat = function (mask) {
    var value = this;
    value = value.replace(/\-/g, "/").replace(/T/, " ");
    var d = new Date(value);
    var zeroize = function (value, length) {
        if (!length) length = 2;
        value = String(value);
        for (var i = 0, zeros = ''; i < (length - value.length); i++) {
            zeros += '0';
        }
        return zeros + value;
    };
    return mask.replace(/"[^"]*"|'[^']*'|\b(?:d{1,4}|m{1,4}|yy(?:yy)?|([hHMstT])\1?|[lLZ])\b/g, function ($0) {
        switch ($0) {
            case 'd': return d.getDate();
            case 'dd': return zeroize(d.getDate());
            case 'ddd': return ['Sun', 'Mon', 'Tue', 'Wed', 'Thr', 'Fri', 'Sat'][d.getDay()];
            case 'dddd': return ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'][d.getDay()];
            case 'M': return d.getMonth() + 1;
            case 'MM': return zeroize(d.getMonth() + 1);
            case 'MMM': return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()];
            case 'MMMM': return ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'][d.getMonth()];
            case 'yy': return String(d.getFullYear()).substr(2);
            case 'yyyy': return d.getFullYear();
            case 'h': return d.getHours() % 12 || 12;
            case 'hh': return zeroize(d.getHours() % 12 || 12);
            case 'H': return d.getHours();
            case 'HH': return zeroize(d.getHours());
            case 'm': return d.getMinutes();
            case 'mm': return zeroize(d.getMinutes());
            case 's': return d.getSeconds();
            case 'ss': return zeroize(d.getSeconds());
            case 'l': return zeroize(d.getMilliseconds(), 3);
            case 'L': var m = d.getMilliseconds();
                if (m > 99) m = Math.round(m / 10);
                return zeroize(m);
            case 'tt': return d.getHours() < 12 ? 'am' : 'pm';
            case 'TT': return d.getHours() < 12 ? 'AM' : 'PM';
            case 'Z': return d.toUTCString().match(/[A-Z]+$/);
            // Return quoted strings with the surrounding quotes removed
            default: return $0.substr(1, $0.length - 2);
        }
    });
}
//转int
String.prototype.toInt = function () {
    var value = this;
    if (value == undefined || value == "" || value == null)
        return 0;
    else {
        try {
            return parseInt(value.toString());
        } catch (e) {
            return 0;
        }
    }
}
//转float
String.prototype.toFloat = function (mask) {
    var value = this;
    if (value == undefined || value == "" || value == null)
    {
        return 0;
    }
    else {
        try {
            return parseFloat(parseFloat(value.toString()).toFixed(mask));
        } catch (e) {
            return 0;
        }
    }
}
/**
 * 
 *  把srting 转number
 */
String.prototype.toNumber = function () {
    var value = Number(this);
    if (value == "NaN" || value == NaN)
    {
        return 0;
    }
    return value;
}
this.REGX_HTML_ENCODE = /"|&|'|<|>|[\x00-\x20]|[\x7F-\xFF]|[\u0100-\u2700]/g;
this.REGX_HTML_DECODE = /&\w+;|&#(\d+);/g;
this.REGX_TRIM = /(^\s*)|(\s*$)/g;
this.HTML_DECODE = {
    "&lt;": "<",
    "&gt;": ">",
    "&amp;": "&",
    "&nbsp;": " ",
    "&quot;": "\"",
    "©": ""
    // Add more
};
//转义
String.prototype.encodeHtml = function (s) { 
    s = (s != undefined) ? s : this.toString();
    return (typeof s != "string") ? s :
        s.replace(this.REGX_HTML_ENCODE,
            function ($0) {
                var c = $0.charCodeAt(0), r = ["&#"];
                c = (c == 0x20) ? 0xA0 : c;
                r.push(c); r.push(";");
                return r.join("");
            });
};
//反转义
String.prototype.decodeHtml = function (s) {
    var HTML_DECODE = this.HTML_DECODE; 
    s = (s != undefined) ? s : this.toString();
    return (typeof s != "string") ? s :
        s.replace(this.REGX_HTML_DECODE,
            function ($0, $1) {
                var c = HTML_DECODE[$0];
                if (c == undefined) {
                    // Maybe is Entity Number
                    if (!isNaN($1)) {
                        c = String.fromCharCode(($1 == 160) ? 32 : $1);
                    } else {
                        c = $0;
                    }
                }
                return c;
            });
};
String.prototype.hashCode = function () {
    var hash = this.__hash__, _char;
    if (hash == undefined || hash == 0) {
        hash = 0;
        for (var i = 0, len = this.length; i < len; i++) {
            _char = this.charCodeAt(i);
            hash = 31 * hash + _char;
            hash = hash & hash; // Convert to 32bit integer
        }
        hash = hash & 0x7fffffff;
    }
    this.__hash__ = hash; 
    return this.__hash__;
};
//string format
String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    var reg = new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}

//数组max方法和min方法
/** 
 *  求数组max
 */
Array.prototype.max = function () {
    return Math.max.apply({}, this)
}


//数组max方法和min方法
Array.prototype.min = function () {
    return Math.min.apply({}, this)
}
//数组max方法和min方法
Array.prototype.avg = function () {
    //var sum = eval(this.join("+"));
    //return ~~(sum / arr.length * 100) / 100; 
    return this.reduce((acc, val) => parseFloat(acc) + parseFloat(val), 0) / this.length;
}
//数组求和
Array.prototype.sum = function () { 
    return this.reduce((total, currentValue, currentIndex, arr) => { 
        return parseFloat(total) + parseFloat(currentValue);
    })
}
//去掉 数组最大值和最小值
/**
 * extrem 去掉数组最大值和最小值
 *  */
Array.prototype.extrem = function () {
    if (this.length < 2) {
        return this;
    } 
    let min, max,arry;
    min = this.min();
    max = this.max();
    arry = this.filter((item) => {
        return item != min && item != max;
    })
    return arry; 
}

Array.prototype.ulineToPoint = function () {
    return this.replace("_", ".");
}
//排序
//s.sort(sortNumASC) 数值升序
function sortNumASC(a, b) {
    return a - b;
}
//s.sort(sortNumDESC) 数值降序序
function sortNumDESC(a, b) {
    return b - a;
}
//s.sort(sortCompare('startRow')) 对象升序
function sortCompare(prop) {
    return function (a, b) {
        var value1 = a[prop];
        var value2 = b[prop];
        return value1 - value2;
    }
}
//四舍六入五成双
Number.prototype.toRound = function (n) {
    n = n ? parseInt(n) : 0;
    return (Math.round(parseFloat(this) * Math.pow(10, n)) / Math.pow(10, n)).toFixed(n).toNumber();
}
//四舍六入五成双
Number.prototype.toVBARound = function (n) {
    n = n ? parseInt(n) : 0;
    return VBARound(parseFloat(this), n);
}
//四舍六入五成双 vba算法
function VBARound(num, decimalPlaces) { 
    var d = decimalPlaces || 0;
    var m = Math.pow(10, d);
    var n = +(d ? num * m : num).toFixed(8); // Avoid rounding errors
    var i = Math.floor(n), f = n - i;
    var e = 1e-8; // Allow for rounding errors in f
    var r = (f > 0.5 - e && f < 0.5 + e) ?
        ((i % 2 == 0) ? i : i + 1) : Math.round(n);
    return d ? r / m : r;
}
/*==============================扩展 结束==============================*/


/*==============================判断 开始==============================*/
//空判断
function isEmpty(obj) {
    if (typeof obj == "undefined" || obj == null || obj == "") {
        return true;
    } else {
        return false;
    }
}
/*==============================判断 结束==============================*/

/*==============================数据分组 开始==============================*/
//分组 
//array 数据  分组函数
//用例： var updateArry = groupBy(dirtyItems, function (arryitem) {  return [arryitem.Mark, arryitem.Source];   }); 
function groupBy(array, f) {

    const groups = {};
    array.forEach(function (o) {
        const group = JSON.stringify(f(o));
        groups[group] = groups[group] || [];
        groups[group].push(o);
    });
    return Object.keys(groups).map(function (group) {
        return groups[group];
    });
}
/*==============================数据分组 结束==============================*/


/*==============================其他通用 开始==============================*/
//生成guid
function getGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}
/*==============================其他通用 结束==============================*/


/*==============================返回ID 的第一个对象的引用 开始==============================*/
//返回ID 的第一个对象的引用
function _getElementById(id) {
    return document.getElementById(id);
}
/*==============================返回ID 的第一个对象的引用 开始==============================*/

 
/*==============================HTM编码 开始==============================*/
//HTML转义
function HTMLEncode(html) {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}
//HTML反转义
function HTMLDecode(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}
/*==============================HTM编码 开始==============================*/

/*==============================表单 开始==============================*/
//表单 $.isEmptyObject(obj) ：jquery方法，判断实体是否为空
//serialize 获取表单字 返回符串，&连接，如a=1&b=2。。。
//serializeArray 获取表单 返回数组
//serializeObject 获取表单 返回实体
$.fn.serializeObject = function () {
    var obj = new Object();
    $(this).serializeArray().forEach(item => {
        obj[item.name] = item.value;
    }) 
    return obj;
}
//设置表单值
$.fn.setForm = function (data) {
    var $id = $(this)
    for (var key in data) { 
        if (typeof (data[key]) === "object") {
            $id.setForm(data[key]);
        } else {
            var id = $id.find('#' + key);
            if (id.attr('id')) {
                var type = id.attr('type');
                var value = $.trim(data[key]).replace(/&nbsp;/g, '');
                switch (type) {
                    case "checkbox":
                        if (value == 1) {
                            id.attr("checked", 'checked');
                        } else {
                            id.removeAttr("checked");
                        }
                        form.render("checkbox");
                        break;
                    case "select":
                        id.val(value);
                        form.render("select");
                        break;
                    default:
                        id.val(value);
                        break;
                }
            }
        }
    }
} 
/*==============================表单 结束==============================*/