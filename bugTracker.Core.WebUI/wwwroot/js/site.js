// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#createBug").click(function() {
    //assume that validation is alreaedy done
    var modelToPost = {
        Title: $("#createBugModal #title").val(),
        Description: $("#createBugModal #description").val(),
        Status: $("#status").find(":selected").val()
    }
    var otherModel = $("#detailsForm").serialize();
    debugger;
    $.post("/Bug/Create", modelToPost, function() {
        debugger;
    });
});