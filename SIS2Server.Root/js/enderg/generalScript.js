const apiHost = "https://enderg.bsite.net";
const serverHost = "https://enderg.bsite.net";



var apiEPoints = {};
apiEPoints["origin"] = apiHost + "/api";
apiEPoints["login"] = apiEPoints["origin"] + "/User/Login";
apiEPoints["register"] = apiEPoints["origin"] + "/User/Register";
apiEPoints["faculty"] = apiEPoints["origin"] + "/Faculty";
apiEPoints["subject"] = apiEPoints["origin"] + "/Subject";

var staticEPoints = {};
staticEPoints["home"] = serverHost + "/sis2";
staticEPoints["login"] = staticEPoints["home"] + "/Login";
staticEPoints["register"] = staticEPoints["home"] + "/Register";
staticEPoints["faculty"] = staticEPoints["home"] + "/Faculty";

// functions //
function decodeJWT(jwt) {
    const [header, payload, signature] = jwt.split('.');
    const decodedPayload = atob(payload);
    const jsonPayload = JSON.parse(decodedPayload);
    return jsonPayload;
}

function setLocalToken(token) {
    localStorage.setItem('auth-token', token);
}
function getLocalToken() {
    return localStorage.getItem('auth-token');
}

function sendRequest(url, data, callback, sendType = "POST", dataType = "application/json") {
    var xhr = new XMLHttpRequest();
    xhr.open(sendType, url, true);
    xhr.setRequestHeader("Content-Type", dataType);
    xhr.setRequestHeader("Authorization", getLocalToken())

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            callback(xhr.responseText);
        }
    };

    // var jsonData = JSON.stringify(data);
    xhr.send(data);
}

function getRequest(url, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url, true);
    xhr.setRequestHeader("Authorization", getLocalToken())

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            callback(xhr.responseText);
        }
    };

    xhr.send();
}

function jsonSender(formId, url, callback, sendType = "POST") {
    let form = document.getElementById(formId);

    form.addEventListener("click", function (event) {
        event.preventDefault();
    });

    let formData = {};

    for (let i = 0; i < form.elements.length; i++) {
        const element = form.elements[i];

        if (element.tagName === 'INPUT') {
            formData[element.name] = element.value;
        }
    }

    sendRequest(url, JSON.stringify(formData), callback, sendType, "application/json");
}

function fixHref(className, endPoint) {
    const elements = document.getElementsByClassName(className);
    Array.from(elements).forEach(element => {
        element.href = endPoint;
    });
}
function fixAllHref(fixer) {
    for (let key in staticEPoints) {
        fixHref(key + fixer, staticEPoints[key]);
    }
}

// //
fixAllHref("-link");