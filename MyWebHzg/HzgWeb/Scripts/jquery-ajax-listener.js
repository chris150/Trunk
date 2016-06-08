$(document).ajaxSend(function (event, request, setting){
    $('#loading-indicator').modal({
        backdrop: false,
        keyboard: false
    });

});

$(document).ajaxComplete(function (event, request, setting) {

    //sleep(2000);
    $('#loading-indicator').modal("hide");
});

//function sleep(delay) {
//    var start = new Date().getTime();
//    while (new Date().getTime() < start + delay);
//}