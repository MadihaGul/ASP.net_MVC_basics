// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var IndexPostBackURL = '/Home/Index';
$(function () {

    $(".IndexRedirect").click(function () {

        $.ajax({
            type: "GET",
            url: IndexPostBackURL,
            contentType: "application/json; charset=utf-8",

            datatype: "json",
            success: function (data) {
                $('#pageContent').html(data);
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

});