"use strict";
var m1 = require("m1");
exports.a1 = 10;
var c1 = (function () {
    function c1() {
    }
    return c1;
}());
exports.c1 = c1;
exports.instance1 = new c1();
function f1() {
    return exports.instance1;
}
exports.f1 = f1;
exports.a2 = m1.m1_c1;
//# sourceMappingURL=/tests/cases/projects/outputdir_module_simple/mapFiles/test.js.map