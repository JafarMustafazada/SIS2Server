
function cLogin(formId) {
    jsonSender(formId, apiEPoints["login"], function (response) {
        setLocalToken(response);
        window.location.href = staticEPoints["home"];
    });
}

function cRegister(formId) {
    jsonSender(formId, apiEPoints["register"], function (response) {
        console.log(response);
        window.location.href = staticEPoints["login"];
    });
}
