"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var ServiceBase = /** @class */ (function () {
    function ServiceBase(http) {
        this.http = http;
    }
    ServiceBase.prototype.deleteObjectDateProperties = function (object) {
        delete object.createdDate;
        delete object.modifiedDate;
    };
    ServiceBase.prototype.handleError = function (err) {
        var errorMessage = { statusCode: "", Message: "" };
        errorMessage.statusCode = err.status.toString();
        (err.error instanceof ErrorEvent) ? errorMessage.Message = "An error occurred: " + err.error.message
            : errorMessage.Message = "Backend returned code " + err.error.StatusCode + ": " + err.error.Message;
        return rxjs_1.throwError(errorMessage);
    };
    return ServiceBase;
}());
exports.ServiceBase = ServiceBase;
//# sourceMappingURL=serviceBase.js.map