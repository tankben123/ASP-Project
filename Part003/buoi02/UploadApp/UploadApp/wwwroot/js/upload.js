/// <reference path = "../lib/jquery/jquery.min.js"/>
//console.log("upload.js has loaded!");

//document.querySelectorAll('script').forEach(s => {
//    if (s.src.toLowerCase().includes("jquery")) {
//        console.log("📌 jQuery is loaded from:", s.src);
//    }
//});

$(document).ready(function () {
 /*   console.log("jQuery ready in upload.js");*/

    $('form[name="frm"]').submit(function (ev) {
        ev.preventDefault();
       /* alert("Submit bị chặn!");*/
    });
});