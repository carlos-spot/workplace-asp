/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("SSWeb");

SSWeb.ClientControl = function(element) {
    SSWeb.ClientControl.initializeBase(this, [element]);
}

SSWeb.ClientControl.prototype = {
    initialize: function() {
        SSWeb.ClientControl.callBaseMethod(this, 'initialize');
        
        // Agregar inicialización personalizada aquí
    },
    dispose: function() {        
        //Agregar acciones de eliminación personalizadas aquí
        SSWeb.ClientControl.callBaseMethod(this, 'dispose');
    }
}
SSWeb.ClientControl.registerClass('SSWeb.ClientControl', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
