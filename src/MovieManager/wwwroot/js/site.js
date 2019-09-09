﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Fade in login error message.

$("#errorLog").fadeIn(50).delay(3000).fadeOut(3000);

/*
// Logo image. 
console.log(window.innerHeight);
$("#logoImage").height(window.innerHeight - 0.15 * window.innerHeight);
window.addEventListener("resize", () => $("#logoImage").height(window.innerHeight - 0.15 * window.innerHeight));
*/


// Vertical centering of register form

function centerRegisterForm() {

    var headerHeight = document.getElementById("header").getBoundingClientRect().height;
    var footerHeight = document.getElementById("footer").getBoundingClientRect().height;
    var registerFormHeight = document.getElementById("registerForm").getBoundingClientRect().height;

    var emptySpaceHeight = window.innerHeight - headerHeight - footerHeight;

    var x = (emptySpaceHeight - registerFormHeight) / 2;

    document.getElementById("registerForm").style.marginTop = x + "px";

    $("#registerForm").css({ opacity: 0, visibility: "visible" }).animate({ opacity: 1 }, "slow");

}



centerRegisterForm();

window.addEventListener("resize", centerRegisterForm);



